using System;
using System.IO;
namespace Tarabica
{
	public class Distribution
	{
		private const string UNKNOWN = "Unknown / not Linux Distribution";

		public static string Name
		{
			get 
			{
				try
				{
					foreach (var line in File.ReadLines(@"/etc/os-release"))
					{
						if (line.StartsWith("PRETTY_NAME"))
							return line.Split('=')[1].Trim('"');
					}
					return UNKNOWN;
				} 
				catch (Exception)
				{
					return UNKNOWN;
				}
				
			}
		}

		public static string Kernel
		{
			get
			{
				var osver = Environment.OSVersion;
				
				return osver.Version.ToString();
			}
		}
	}
}