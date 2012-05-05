using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;

namespace KickBrain
{
	public class Config
	{
		Dictionary<string, object> Values;
		public string Filename { get; private set; }

		public Config(string filename)
		{
			Values = new Dictionary<string, object>();
			Filename = filename;
		}

		public T Get<T>(string key)
		{
			if (Values.ContainsKey(key))
			{
				if (typeof(T) == typeof(string))
					return (T)(object)Values[key].ToString();
				else if (typeof(T) == typeof(double))
					return (T)(object)Convert.ToDouble(Values[key]);
				else if (typeof(T) == typeof(int))
					return (T)(object)Convert.ToInt32(Values[key]);
				else if (typeof(T) == typeof(long))
					return (T)(object)Convert.ToInt64(Values[key]);
				else if (typeof(T) == typeof(bool))
					return (T)(object)Convert.ToBoolean(Values[key]);
				else
					return default(T);
			}
			else
			{
				return default(T);
			}
		}

		public void Set(string key, object value)
		{
			Values[key] = value;
		}

		public void Save()
		{
			try
			{
				var output = Serializer.SerializeJSON(Values);
				File.WriteAllBytes(Filename, output);
			}
			catch (Exception e)
			{
				MessageBox.Show("Unable to save configuration settings");
			}
		}

		public void Load()
		{
			if (!File.Exists(Filename))
				return;

			try
			{
				var input = File.ReadAllBytes(Filename);
				var data = Serializer.DeserializeJSON<Dictionary<string, object>>(input);
				Values = data;
			}
			catch (Exception e)
			{
				MessageBox.Show("Unable to read configuration settings");
			}

		}
	}
}
