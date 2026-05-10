using System;
using System.Threading;
using #3Rd;
using #7hc;
using #BTd;

namespace StructurePoint.CoreAssets.GUI.Reporter.Core.Data
{
	// Token: 0x02000E2C RID: 3628
	public sealed class ReportFontSizeInfoProvider : #ATd
	{
		// Token: 0x170026E3 RID: 9955
		// (get) Token: 0x06008247 RID: 33351 RVA: 0x0006A160 File Offset: 0x00068360
		public static #ATd Instance
		{
			get
			{
				return ReportFontSizeInfoProvider.#a.Value;
			}
		}

		// Token: 0x170026E4 RID: 9956
		// (get) Token: 0x06008248 RID: 33352 RVA: 0x001C3924 File Offset: 0x001C1B24
		private #dTd Small
		{
			get
			{
				#dTd #dTd = new #dTd();
				#dTd.TableOfContentsHeaderFontSize = 14.0;
				#dTd.TableOfContentsContentFontSize = 8.0;
				#dTd.Header1FontSize = 10.0;
				#dTd.Header2FontSize = 8.0;
				#dTd.Header3FontSize = 8.0;
				#dTd.Header4FontSize = 8.0;
				#dTd.Header5FontSize = 8.0;
				#dTd.ContentFontSize = 6.0;
				#dTd.ContentCharacterWidth = 3.6;
				#dTd.ContentCharacterHeight = 6.75;
				ReportFontSizes #f = ReportFontSizes.Small;
				if (2 != 0)
				{
					#dTd.SizeType = #f;
				}
				return #dTd;
			}
		}

		// Token: 0x170026E5 RID: 9957
		// (get) Token: 0x06008249 RID: 33353 RVA: 0x001C39DC File Offset: 0x001C1BDC
		private #dTd Medium
		{
			get
			{
				#dTd #dTd = new #dTd();
				#dTd.TableOfContentsHeaderFontSize = 15.0;
				#dTd.TableOfContentsContentFontSize = 9.0;
				#dTd.Header1FontSize = 11.0;
				#dTd.Header2FontSize = 9.0;
				#dTd.Header3FontSize = 9.0;
				#dTd.Header4FontSize = 9.0;
				#dTd.Header5FontSize = 9.0;
				#dTd.ContentFontSize = 7.0;
				#dTd.ContentCharacterWidth = 4.2;
				#dTd.ContentCharacterHeight = 7.91;
				ReportFontSizes #f = ReportFontSizes.Medium;
				if (2 != 0)
				{
					#dTd.SizeType = #f;
				}
				return #dTd;
			}
		}

		// Token: 0x170026E6 RID: 9958
		// (get) Token: 0x0600824A RID: 33354 RVA: 0x001C3A94 File Offset: 0x001C1C94
		private #dTd Large
		{
			get
			{
				#dTd #dTd = new #dTd();
				#dTd.TableOfContentsHeaderFontSize = 16.0;
				#dTd.TableOfContentsContentFontSize = 10.0;
				#dTd.Header1FontSize = 12.0;
				#dTd.Header2FontSize = 10.0;
				#dTd.Header3FontSize = 10.0;
				#dTd.Header4FontSize = 10.0;
				#dTd.Header5FontSize = 10.0;
				#dTd.ContentFontSize = 8.0;
				#dTd.ContentCharacterWidth = 4.8;
				#dTd.ContentCharacterHeight = 9.061;
				ReportFontSizes #f = ReportFontSizes.Large;
				if (2 != 0)
				{
					#dTd.SizeType = #f;
				}
				return #dTd;
			}
		}

		// Token: 0x0600824B RID: 33355 RVA: 0x001C3B4C File Offset: 0x001C1D4C
		public #dTd #3hc(ReportFontSizes #Cvb)
		{
			switch (#Cvb)
			{
			case ReportFontSizes.Large:
				return this.Large;
			case ReportFontSizes.Medium:
				return this.Medium;
			case ReportFontSizes.Small:
				return this.Small;
			default:
				throw new ArgumentOutOfRangeException(#Phc.#3hc(107277211), #Cvb, null);
			}
		}

		// Token: 0x04003577 RID: 13687
		private static readonly Lazy<#ATd> #a = new Lazy<#ATd>(new Func<#ATd>(ReportFontSizeInfoProvider.<>c.<>9.#8Wd), LazyThreadSafetyMode.ExecutionAndPublication);
	}
}
