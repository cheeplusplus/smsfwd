// SMSFWD by Andrew Koester <andrew@neocodenetworks.com>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Xml.Linq;

namespace smsfwdClient
{
	public static class SmsFwdComm
	{
		private static string _remoteURL = "http://SERVER/check.php?phone={0}";

		public static IEnumerable<SmsMessage> CheckMessages(string phoneNumber)
		{
			string finalURL = String.Format(_remoteURL, phoneNumber);
			XDocument xDoc = XDocument.Load(finalURL);

			XElement error = xDoc.Root.Element("error");
			if (error != null)
			{
				throw new SmsFwdCheckException(error.Value);
			}

			foreach (var msg in xDoc.Root.Elements("message"))
			{
				XAttribute from = msg.Attribute("from");
				if (from == null)
					throw new SmsFwdCheckException("From value is empty");

				XAttribute time = msg.Attribute("time");
				if (time == null)
					throw new SmsFwdCheckException("Time value is empty");

				double uTime;
				if (!double.TryParse(time.Value, out uTime))
					throw new SmsFwdCheckException("Time value is invalid");

				string body = msg.Value;
				if (String.IsNullOrEmpty(body))
					throw new SmsFwdCheckException("Body is empty");

				yield return new SmsMessage
				{
					From = from.Value,
					To = phoneNumber,
					Time = UnixTimeStampToDateTime(uTime),
					Body = body
				};
			}
		}

		private static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
		{
			// Unix timestamp is seconds past epoch
			System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
			dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
			return dtDateTime;
		}
	}

	public class SmsFwdCheckException : Exception
	{
		public SmsFwdCheckException() : base() { }
		public SmsFwdCheckException(string message) : base(message) { }
	}

	public struct SmsMessage
	{
		public string From;
		public string To;
		public DateTime Time;
		public string Body;
	}
}
