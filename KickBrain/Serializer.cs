using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace KickBrain
{
	public class Serializer
	{
		public static T DeepCloneJSON<T>(T obj)
		{
			var ser = SerializeJSON(obj);
			var deser = DeserializeJSON<T>(ser);
			return deser;
		}

		public static T DeepCloneBinary<T>(T obj)
		{
			using (var ms = new MemoryStream())
			{
				var formatter = new BinaryFormatter();
				formatter.Serialize(ms, obj);
				ms.Position = 0;

				return (T)formatter.Deserialize(ms);
			}
		}
		
		
		public static byte[] SerializeBinary(object obj)
		{
			if (obj == null)
				return null;

			BinaryFormatter bf = new BinaryFormatter();
			MemoryStream ms = new MemoryStream();
			bf.Serialize(ms, obj);
			byte[] arr = ms.ToArray();
			return arr;
		}

		public static T DeserializeBinary<T>(byte[] arrBytes)
		{
			MemoryStream ms = new MemoryStream();
			BinaryFormatter binForm = new BinaryFormatter();
			ms.Write(arrBytes, 0, arrBytes.Length);
			ms.Seek(0, SeekOrigin.Begin);
			Object obj = (Object)binForm.Deserialize(ms);
			return (T)obj;
		}
		
		public static byte[] SerializeJSON(object obj)
		{
			var ser = Newtonsoft.Json.JsonConvert.SerializeObject(obj,Newtonsoft.Json.Formatting.None, Settings);
			var bytes = Encoding.UTF8.GetBytes(ser);
			return bytes;
		}

		static Newtonsoft.Json.JsonSerializerSettings settings;
		static Newtonsoft.Json.JsonSerializerSettings Settings
		{
			get
			{
				if (settings == null)
				{
					settings = new Newtonsoft.Json.JsonSerializerSettings();
					settings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver
					{
						DefaultMembersSearchFlags = System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance
					};
					settings.MissingMemberHandling = Newtonsoft.Json.MissingMemberHandling.Error;
					settings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
					settings.Formatting = Newtonsoft.Json.Formatting.Indented;
				}

				return settings;
			}
		}

		public static T DeserializeJSON<T>(byte[] arrBytes)
		{
			T value = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(arrBytes), Settings);
			return value;
		}
	}
}
