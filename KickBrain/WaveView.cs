using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace SerialAudio
{

	public class WaveView : Panel
	{
		public double ZoomX;
		public WaveChannel Channel;

		double _refreshRate;
		public double RefreshRate
		{
			get { return _refreshRate; }
			set { _refreshRate = value; RefreshTimer.Interval = (int)(1/_refreshRate * 1000); }
		}

		Timer RefreshTimer;

		List<double> Values;
		int ScanPos;

		Pen redPen;
		Pen bluePen;
		Pen blackPen;

		public WaveView()
		{
			Values = new List<double>();
			TriggerPos = new List<int>();
			TriggerOffPos = new List<int>();

			redPen = new Pen(Color.FromArgb(255, 200, 200), 3.0f);
			bluePen = new Pen(Color.FromArgb(200, 200, 255), 3.0f);
			blackPen = Pens.Black;

			this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			RefreshTimer = new Timer();
			RefreshTimer.Tick += delegate(object sender, EventArgs e) { this.Invalidate(); };

			ZoomX = 0.25;
			RefreshRate = 30.0;

			RefreshTimer.Start();
		}

		int LastPaintPos;

		Bitmap buffer;

		protected override void OnPaint(PaintEventArgs e)
		{
			if (buffer == null || buffer.Width != this.Width || buffer.Height != this.Height)
				buffer = new Bitmap(this.Width, this.Height);

			var context = Graphics.FromImage(buffer);

			// Values can be modified by the AddData method while we're painting
			// create copy so we don't have to use locks
			List<double> ValCopy = null;
			int i = 0;
			int finalPaintPos = -1;

			try
			{
				lock (Values)
				{
					finalPaintPos = ScanPos; // we paint values between LastPaintPos and current ScanPos
					ValCopy = new List<double>(Values);
				}


				// Clear the area we are about to refresh
				/*if (finalPaintPos >= LastPaintPos)
					context.FillRectangle(Brushes.White, (float)(LastPaintPos + 1), 0, (float)(finalPaintPos - LastPaintPos), (float)this.Height);
				else
				{
					context.FillRectangle(Brushes.White, 0, 0, (float)(finalPaintPos), this.Height);
					context.FillRectangle(Brushes.White, LastPaintPos, 0, this.Width - LastP, this.Height);
				}*/

				context.Clear(Color.White);



				for (i = 0; i < ValCopy.Count - 1; i++)
				{
					double y = 1 - ValCopy[i];
					double y2 = 1 - ValCopy[i + 1];

					if (TriggerPos.Contains(i))
						context.DrawLine(redPen, (float)(ZoomX * i), 0, (float)(ZoomX * i), this.Height - 1);
					if (TriggerOffPos.Contains(i))
						context.DrawLine(bluePen, (float)(ZoomX * i), 0, (float)(ZoomX * i), this.Height - 1);

					context.DrawLine(blackPen, (float)(ZoomX * i), (float)(y * this.Height - 1), (float)(ZoomX * (i + 1)), (float)(y2 * this.Height - 1));
				}

				e.Graphics.DrawImageUnscaled(buffer, 0, 0);
			}
			catch (Exception ex)
			{
				int k = 23;
			}
		}

		List<int> TriggerPos;
		List<int> TriggerOffPos;

		public void Trigger(WaveChannel sender, double power)
		{
			int delay = Channel.Config.TriggerHold;
			if(power > 0.0)
				TriggerPos.Add(ScanPos - delay);
			if(power == 0.0)
				TriggerOffPos.Add(ScanPos - delay);
		}

		public void AddData(WaveChannel sender, double data)
		{
			lock (Values)
			{
				// NOTE: Width is zero when the control is not visible on screen
				// can cause weirdness when minimizing windows.

				int maxLen = (int)(this.Width / this.ZoomX);

				if (Values.Count != maxLen)
				{
					Values.Clear();
					for (int i = 0; i < maxLen; i++)
						Values.Add(0);
					ScanPos = 0;
				}

				if (ScanPos < Values.Count) // because width might be zero
				{
					Values[ScanPos] = data;
					ScanPos = (ScanPos + 1) % maxLen;

					// Remove any previous trigger
					TriggerPos.Remove(ScanPos);
					TriggerOffPos.Remove(ScanPos);
				}
				
			}
		}
	}
}
