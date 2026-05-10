using System;
using System.IO;
using System.Linq;
using #5Fd;
using #7hc;
using #Ded;
using #FCd;
using #jCd;
using #owe;
using #wdd;
using #yUi;
using Aspose.Words;
using StructurePoint.CoreAssets.AppManager.Column.Core;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;
using StructurePoint.CoreAssets.Localizer;

namespace StructurePoint.Products.Column.BatchExecution
{
	// Token: 0x020006E1 RID: 1761
	internal sealed class BatchSummaryWriter
	{
		// Token: 0x06003A9C RID: 15004 RVA: 0x001155C0 File Offset: 0x001137C0
		public static void #fp(#ep #Od, Stream #gp)
		{
			#mGd #mGd = new #mGd(#gp);
			BatchSummaryWriter.#QVb #ib = new BatchSummaryWriter.#QVb(#mGd, true, ColumnGlobalInfo.LongName, new #uwe());
			new BatchSummaryWriter.#PVb(#Od, #ib)
			{
				WriteEmptyHeaders = false
			}.#bCd(null);
			#mGd.#lGd();
		}

		// Token: 0x020006E2 RID: 1762
		private sealed class #PVb : #BCd
		{
			// Token: 0x06003A9E RID: 15006 RVA: 0x00115610 File Offset: 0x00113810
			public #PVb(#ep #Od, #uCd #ib) : base(#ib)
			{
				BatchSummaryWriter.#TVb #xS = new BatchSummaryWriter.#TVb(#Od);
				base.#eb(#xS);
			}
		}

		// Token: 0x020006E3 RID: 1763
		private sealed class #QVb : #uCd
		{
			// Token: 0x06003A9F RID: 15007 RVA: 0x00032D61 File Offset: 0x00030F61
			public #QVb(#gGd #En, bool #RVb, string #SVb, #uwe #mA) : base(new #kCd(), #En)
			{
			}
		}

		// Token: 0x020006E4 RID: 1764
		private sealed class #TVb : #Ced
		{
			// Token: 0x06003AA0 RID: 15008 RVA: 0x00032D6F File Offset: 0x00030F6F
			public #TVb(#ep #Od)
			{
				this.#a = #Od;
			}

			// Token: 0x06003AA1 RID: 15009 RVA: 0x00115634 File Offset: 0x00113834
			protected override void #gpb()
			{
				Option option = new Option(#Phc.#3hc(107380592));
				option.Value = new bool?(true);
				option.IsEnabled = true;
				#JGd #Ae = base.#zed(StyleIdentifier.Heading1, string.Empty, option);
				base.#ved(#Ae, new BatchSummaryWriter.BatchSummaryTable(this.#a), null);
			}

			// Token: 0x040018FB RID: 6395
			private readonly #ep #a;
		}

		// Token: 0x020006E5 RID: 1765
		private sealed class BatchSummaryTable : #7Dd
		{
			// Token: 0x06003AA2 RID: 15010 RVA: 0x00032D7E File Offset: 0x00030F7E
			public BatchSummaryTable(#ep model)
			{
				this.#a = model;
			}

			// Token: 0x06003AA3 RID: 15011 RVA: 0x00115694 File Offset: 0x00113894
			public override void #npb(#6Dd #opb)
			{
				#aed #aed = new #aed(new double[]
				{
					1.0,
					1.0,
					1.0,
					1.0,
					1.0,
					1.0,
					1.0,
					1.0
				});
				using (#5Dd #5Dd = #opb.#ul(1, #aed.#7dd()))
				{
					this.#Ppb(#5Dd);
					this.#UVb(#5Dd);
				}
			}

			// Token: 0x06003AA4 RID: 15012 RVA: 0x001156FC File Offset: 0x001138FC
			private void #Ppb(#5Dd #Ipb)
			{
				#Ipb.#QDd(new string[]
				{
					Strings.StringNo_DOT
				});
				#Ipb.#QDd(new string[]
				{
					Strings.StringFileName
				});
				#Ipb.#QDd(new string[]
				{
					Strings.StringStatus
				});
				#Ipb.#QDd(new string[]
				{
					Strings.StringSection
				});
				#Ipb.#QDd(new string[]
				{
					Strings.StringSize
				});
				#Ipb.#QDd(new string[]
				{
					Strings.StringRho_PERCENT
				});
				#Ipb.#QDd(new string[]
				{
					Strings.StringC_R
				});
				#Ipb.#QDd(new string[]
				{
					Strings.StringErrorWarning
				});
			}

			// Token: 0x06003AA5 RID: 15013 RVA: 0x001157C8 File Offset: 0x001139C8
			private void #UVb(#5Dd #Ipb)
			{
				for (int i = 0; i < this.#a.BatchItems.Count; i++)
				{
					BatchItemViewModel batchItemViewModel = this.#a.BatchItems[i];
					#Ipb.#QDd(new int?(i + 1));
					#Ipb.#QDd(new string[]
					{
						batchItemViewModel.FileName
					});
					#Ipb.#QDd(new string[]
					{
						batchItemViewModel.StateText
					});
					#Ipb.#QDd(new string[]
					{
						batchItemViewModel.Section
					});
					#Ipb.#QDd(new string[]
					{
						batchItemViewModel.Size
					});
					#Ipb.#QDd(new string[]
					{
						batchItemViewModel.Rho
					});
					#Ipb.#QDd(new string[]
					{
						batchItemViewModel.CapacityRatio
					});
					string text = string.Join(#Phc.#3hc(107399922), batchItemViewModel.FeedbackItems.Select(new Func<BatchItemFeedbackData, string>(BatchSummaryWriter.BatchSummaryTable.<>c.<>9.#zdc)));
					#Ipb.#jDd(string.IsNullOrWhiteSpace(text), #Phc.#3hc(107408434), text);
				}
			}

			// Token: 0x040018FC RID: 6396
			private readonly #ep #a;
		}
	}
}
