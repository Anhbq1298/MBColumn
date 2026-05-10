using System;
using System.Xml.Linq;

namespace #xKe
{
	// Token: 0x02001294 RID: 4756
	internal static class #5Le
	{
		// Token: 0x06009F59 RID: 40793 RVA: 0x0021D260 File Offset: 0x0021B460
		internal static XElement #3Le(this XElement #4Le, string #Aad)
		{
			XElement xelement = new XElement(#Aad);
			#4Le.Add(xelement);
			return xelement;
		}
	}
}
