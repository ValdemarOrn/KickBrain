using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Windows.Forms;

namespace KickBrain
{
	class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			if (args.Length >= 1)
			{
				string file = args[0];
				if (System.IO.File.Exists(file))
				{
					var xml = System.IO.File.ReadAllText(file);
					Brain.KB.FromXML(xml);
				}
			}
			
			Application.Run(Brain.KB.ui);

			try
			{
				Brain.KB.Output.Dispose();
			}
			catch (Exception e) { }

			try
			{ 
				Brain.KB.Input.Stop();
			}
			catch (Exception e) { }
		}
	}
}
