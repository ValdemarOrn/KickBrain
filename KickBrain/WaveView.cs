using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace KickBrain
{

	public class WaveView : UserControl
	{
		public double ZoomX;
		public InputChannel Channel;

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

		int LastPainted;

		Bitmap buffer;

		Graphics context;

		protected override void OnPaint(PaintEventArgs e)
		{
			if (buffer == null || buffer.Width != this.Width || buffer.Height != this.Height)
			{
				buffer = new Bitmap(this.Width, this.Height);
				context = Graphics.FromImage(buffer);
				context.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
				context.Clear(Color.White);
				//context.ScaleTransform(4.0f, 4.0f);
			}

			// Values can be modified by the AddData method while we're painting
			// create copy so we don't have to use locks
			List<double> ValCopy = null;
			int i = 0;
			int PaintTo = -1;

			try
			{
				lock (Values)
				{
					PaintTo = ScanPos; // we paint values between LastPaintPos and current ScanPos
					ValCopy = new List<double>(Values);
				}

				// come full circle, clear the context
				if (PaintTo < LastPainted)
				{
					context.Clear(Color.White);
					LastPainted = 0;
				}

				// Paint On Triggers
				while (TriggerPos.Count > 0)
				{
					i = TriggerPos[0];
					context.DrawLine(redPen, (float)(ZoomX * i), 0, (float)(ZoomX * i), this.Height - 1);
					TriggerPos.RemoveAt(0);
				}

				// Paint off triggers
				while (TriggerOffPos.Count > 0)
				{
					i = TriggerOffPos[0];
					context.DrawLine(bluePen, (float)(ZoomX * i), 0, (float)(ZoomX * i), this.Height - 1);
					TriggerOffPos.RemoveAt(0);
				}

				// Paint signal
				for (i = LastPainted; i < (ValCopy.Count - 1) && i < (PaintTo - 1); i++)
				{
					double y = 1 - ValCopy[i];
					double y2 = 1 - ValCopy[i + 1];

					context.DrawLine(blackPen, (float)(ZoomX * i), (float)(y * this.Height - 1), (float)(ZoomX * (i + 1)), (float)(y2 * this.Height - 1));
				}

				
				e.Graphics.DrawImageUnscaled(buffer, 0, 0);

				LastPainted = PaintTo - 1;
				if (LastPainted < 0)
					LastPainted = 0;
			}
			catch (Exception ex)
			{
				int k = 23;
			}
		}

		List<int> TriggerPos;
		List<int> TriggerOffPos;

		public void Trigger(object sender)
		{
			var power = Channel.GetPower();

			int delay = 0;// Channel.Config.TriggerLength;
			if(power > 0.0)
				TriggerPos.Add(ScanPos - delay);
			if(power == 0.0)
				TriggerOffPos.Add(ScanPos - delay);
		}

		public void AddData(object sender)
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
					Values[ScanPos] = Channel.GetValue();
					//Values[ScanPos] = data;

					if (ScanPos == 0)
					{
						for (int i = 1; i < Values.Count; i++)
						{
							Values[i] = 0;
						}

						TriggerPos.Clear();
						TriggerOffPos.Clear();
					}

					ScanPos = (ScanPos + 1) % maxLen;

					// Remove any previous trigger
					TriggerPos.Remove(ScanPos);
					TriggerOffPos.Remove(ScanPos);
				}
				
			}
		}
	}
}
