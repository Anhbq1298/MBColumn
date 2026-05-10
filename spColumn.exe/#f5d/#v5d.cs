using System;
using System.IO;
using #cYd;
using log4net.Core;
using log4net.Util;

namespace #f5d
{
	// Token: 0x02000F27 RID: 3879
	internal sealed class #v5d : PatternConverter
	{
		// Token: 0x060089AA RID: 35242 RVA: 0x001D6654 File Offset: 0x001D4854
		protected void #Pb(TextWriter #Ipb, object #8Rb)
		{
			if (#Ipb != null && #8Rb != null)
			{
				LoggingEvent loggingEvent = #8Rb as LoggingEvent;
				if (loggingEvent != null && loggingEvent.ExceptionObject != null && loggingEvent.ExceptionObject is #FYd)
				{
					#Ipb.Write(((#FYd)loggingEvent.ExceptionObject).TrackingGuid);
				}
			}
		}
	}
}
