using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.CompilerServices;
using #7hc;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace #cYd
{
	// Token: 0x0200075E RID: 1886
	internal abstract class #FYd : Exception
	{
		// Token: 0x06003CF1 RID: 15601 RVA: 0x00034725 File Offset: 0x00032925
		protected #FYd(string #5, string #Qic, Component #Ric, #IYd #Sic, #JYd #Tic) : this(#5, #Qic, #Ric, #Sic, #Tic, null)
		{
		}

		// Token: 0x06003CF2 RID: 15602 RVA: 0x00034735 File Offset: 0x00032935
		protected #FYd(string #5, string #Qic, Component #Ric, #IYd #Sic, #JYd #Tic, Exception #Uic) : base(#5, #Uic)
		{
			this.ThrowingComponent = #Ric;
			this.ErrorType = #Sic;
			this.ErrorNumber = #Tic;
			this.TrackingGuid = #Qic;
		}

		// Token: 0x1700125F RID: 4703
		// (get) Token: 0x06003CF3 RID: 15603 RVA: 0x0003475E File Offset: 0x0003295E
		// (set) Token: 0x06003CF4 RID: 15604 RVA: 0x00034766 File Offset: 0x00032966
		public #JYd ErrorNumber { get; private set; }

		// Token: 0x17001260 RID: 4704
		// (get) Token: 0x06003CF5 RID: 15605 RVA: 0x0003476F File Offset: 0x0003296F
		// (set) Token: 0x06003CF6 RID: 15606 RVA: 0x00034777 File Offset: 0x00032977
		public #IYd ErrorType { get; private set; }

		// Token: 0x17001261 RID: 4705
		// (get) Token: 0x06003CF7 RID: 15607 RVA: 0x00034780 File Offset: 0x00032980
		// (set) Token: 0x06003CF8 RID: 15608 RVA: 0x00034788 File Offset: 0x00032988
		public Component ThrowingComponent { get; private set; }

		// Token: 0x17001262 RID: 4706
		// (get) Token: 0x06003CF9 RID: 15609 RVA: 0x00034791 File Offset: 0x00032991
		// (set) Token: 0x06003CFA RID: 15610 RVA: 0x00034799 File Offset: 0x00032999
		public string TrackingGuid { get; private set; }

		// Token: 0x06003CFB RID: 15611 RVA: 0x0011C500 File Offset: 0x0011A700
		[SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Method is better here.")]
		public string #EYd()
		{
			int num = (int)this.ThrowingComponent;
			int num2;
			if (!false)
			{
				num2 = num;
			}
			string text = num2.ToString(#Phc.#3hc(107227275), CultureInfo.InvariantCulture);
			string text2;
			if (!false)
			{
				text2 = text;
			}
			int num3 = (int)this.ErrorType;
			if (!false)
			{
				num2 = num3;
			}
			string text3 = num2.ToString(#Phc.#3hc(107227275), CultureInfo.InvariantCulture);
			string text4;
			if (3 != 0)
			{
				text4 = text3;
			}
			int num4 = (int)this.ErrorNumber;
			if (3 != 0)
			{
				num2 = num4;
			}
			string text5 = num2.ToString(#Phc.#3hc(107227270), CultureInfo.InvariantCulture);
			string text6;
			if (6 != 0)
			{
				text6 = text5;
			}
			return string.Format(CultureInfo.InvariantCulture, #Phc.#3hc(107227289), new object[]
			{
				text2,
				text4,
				text6
			});
		}

		// Token: 0x06003CFC RID: 15612 RVA: 0x0011C5BC File Offset: 0x0011A7BC
		public override string ToString()
		{
			string text = string.Format(CultureInfo.InvariantCulture, #Phc.#3hc(107227240), new object[]
			{
				this.#EYd(),
				this.Message
			});
			string text2;
			if (5 != 0)
			{
				text2 = text;
			}
			string text4;
			do
			{
				string text3 = base.ToString();
				if (8 != 0)
				{
					text4 = text3;
				}
			}
			while (false);
			if (string.IsNullOrEmpty(text4))
			{
				goto IL_55;
			}
			IL_45:
			string text5 = text2 + Environment.NewLine + text4;
			if (!false)
			{
				text2 = text5;
			}
			IL_55:
			if (3 != 0)
			{
				return text2;
			}
			goto IL_45;
		}

		// Token: 0x04001BB8 RID: 7096
		[CompilerGenerated]
		private #JYd #a;

		// Token: 0x04001BB9 RID: 7097
		[CompilerGenerated]
		private #IYd #b;

		// Token: 0x04001BBA RID: 7098
		[CompilerGenerated]
		private Component #c;

		// Token: 0x04001BBB RID: 7099
		[CompilerGenerated]
		private string #d;
	}
}
