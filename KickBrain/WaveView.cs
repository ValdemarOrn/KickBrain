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

		public WaveView()
		{
			Values = new List<double>();
			TriggerPos = new List<int>();
			TriggerOffPos = new List<int>();

			this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			RefreshTimer = new Timer();
			RefreshTimer.Tick += delegate(object sender, EventArgs e) { this.Invalidate(); };

			ZoomX = 0.25;
			RefreshRate = 30.0;

			RefreshTimer.Start();
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			// Values can be modified by the AddData method while we're painting
			// create copy so we don't have to use locks
			List<double> ValCopy = null;
			int i = 0;

			try
			{
				lock (Values)
				{
					ValCopy = new List<double>(Values);
				}

				e.Graphics.Clear(Color.White);

				for (i = 0; i < ValCopy.Count - 1; i++)
				{
					double y = 1 - ValCopy[i];
					double y2 = 1 - ValCopy[i + 1];

					var redPen = new Pen(Color.FromArgb(255, 200, 200), 3.0f);
					var bluePen = new Pen(Color.FromArgb(200, 200, 255), 3.0f);
					if (TriggerPos.Contains(i))
						e.Graphics.DrawLine(redPen, (float)(ZoomX * i), 0, (float)(ZoomX * i), 256);
					if (TriggerOffPos.Contains(i))
						e.Graphics.DrawLine(bluePen, (float)(ZoomX * i), 0, (float)(ZoomX * i), 256);

					e.Graphics.DrawLine(Pens.Black, (float)(ZoomX * i), (float)(y*256), (float)(ZoomX * (i + 1)), (float)(y2*256));
				}
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

		int ScanPos;

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
