using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace KickBrain
{
	public class VUMeter : UserControl
	{
		Font font;

		DateTime peakTime;
		float peak;

		public float Peak
		{
			get { return peak; }
			set 
			{ 
				peak = value; 
				
				if(peak > Current)
					Current = peak; 

				peakTime = DateTime.Now; 
			}
		}

		public float Current;
		public float Rate;
		
		double _refresh;
		public double RefreshRateHz
		{
			get{ return _refresh; }
			set{ _refresh = value; timer.Interval = (int)(1000 / _refresh); }
		}

		Timer timer;
		StringFormat sf;

		public VUMeter() : base()
		{
			sf = new StringFormat();
			sf.LineAlignment = StringAlignment.Center;
			sf.Alignment = StringAlignment.Center;

			font = new Font(FontFamily.GenericSansSerif, 8.0f);

			Peak = 0.0f;
			Rate = 0.9f;
			_refresh = 30;

			timer = new Timer();
			timer.Interval = (int)(1000 / RefreshRateHz);
			timer.Tick += new EventHandler(delegate(object sender, EventArgs e) { Current = Current * Rate; this.Invalidate(); });
			timer.Start();
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			var g = e.Graphics;

			g.Clear(Color.White);
			int vuSize = this.Height;
			float activeArea = vuSize * Current;

			g.FillRectangle(Brushes.Red, 0, (vuSize - activeArea), this.Width, activeArea);
		}
	}
}
