using System;
using System.Drawing;
using #7hc;
using #FCd;
using #owe;
using #Qcd;
using #Rwe;
using #wdd;
using #Wse;
using Aspose.Words;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Resources;
using StructurePoint.CoreAssets.Infrastructure.Extensions;

namespace #kve
{
	// Token: 0x02001181 RID: 4481
	internal sealed class #jve : #qwe
	{
		// Token: 0x06009803 RID: 38915 RVA: 0x00078C21 File Offset: 0x00076E21
		public #jve(#lte #Od, double #6dd, double #Cvb) : base(#Od)
		{
			this.#a = #6dd;
			this.#c = #Cvb;
		}

		// Token: 0x06009804 RID: 38916 RVA: 0x00200348 File Offset: 0x001FE548
		public override void #npb(#6Dd #opb)
		{
			base.Model.GeneralInfo;
			Options options = base.Model.Input.Options;
			using (#5Dd #5Dd = this.#gve(#opb, this.#a))
			{
				#5Dd.#VDd(ParagraphAlignment.Left, Array.Empty<int>());
				#5Dd.#ODd(new string[]
				{
					Localization.StringProject,
					this.#Cu(base.Model.Input.ProjectInfo.Project)
				});
				#5Dd.#ODd(new string[]
				{
					Localization.StringColumn,
					this.#Cu(base.Model.Input.ProjectInfo.ColumnId)
				});
				#5Dd.#ODd(new string[]
				{
					Localization.StringEngineer,
					this.#Cu(base.Model.Input.ProjectInfo.Engineer)
				});
				#5Dd.#ODd(new string[]
				{
					Localization.StringCode,
					#yhe.#Pwe(options.Code)
				});
				#5Dd.#ODd(new string[]
				{
					Localization.StringBarSet,
					#yhe.#Gwe(base.Model.Input.BarGroupType)
				});
				#5Dd.#ODd(new string[]
				{
					Localization.StringUnits,
					#yhe.#Owe(options.Unit)
				});
				#5Dd.#ODd(new string[]
				{
					Localization.StringRunOption,
					#yhe.#Nwe(options.ProblemType)
				});
				#5Dd.#ODd(new string[]
				{
					Localization.StringRunAxis,
					#yhe.#Mwe(options.ConsideredAxis)
				});
				#5Dd.#ODd(new string[]
				{
					Localization.StringSlenderness,
					options.ConsiderSlenderness ? Localization.StringConsidered : Localization.StringNotConsidered
				});
				#5Dd.#ODd(new string[]
				{
					Localization.StringColumnType,
					#yhe.#Jwe(options, base.Model.Output)
				});
				#5Dd.#ODd(new string[]
				{
					Localization.StringCapacityMethod,
					#yhe.#Iwe(options.SectionCapacityMethod)
				});
				#5Dd.TableWidthType = #rdd.#b;
				#5Dd.PreferredWidth = (float)this.#a;
			}
		}

		// Token: 0x06009805 RID: 38917 RVA: 0x00200588 File Offset: 0x001FE788
		private #5Dd #gve(#6Dd #opb, double #hve)
		{
			#aed #aed = new #aed(new double[]
			{
				#2dd.PropertiesFirstColumnWidth,
				#2dd.PropertiesDataColumnWidth + #2dd.PropertiesUnitColumnWidth
			});
			#5Dd #5Dd = #opb.#ul(0, #aed.#5dd(#hve));
			#5Dd.TableLeftIndent = new double?(0.0);
			#2dd.#Vdd(#5Dd);
			#5Dd.#XDd(#rdd.#b, Array.Empty<int>());
			return #5Dd;
		}

		// Token: 0x06009806 RID: 38918 RVA: 0x002005EC File Offset: 0x001FE7EC
		private string #Cu(string #Rf)
		{
			if (string.IsNullOrWhiteSpace(#Rf))
			{
				return #Phc.#3hc(107361293);
			}
			int num = 0;
			while (num < 100 && this.#ive(#Rf) > (float)this.#b)
			{
				int num2 = (int)Math.Round((double)((float)#Rf.Length * (this.#ive(#Rf) - (float)this.#b) / (float)this.#b));
				if (num2 <= 0)
				{
					break;
				}
				#Rf = #Rf.#Z2d((#Rf.Length / 2 > num2) ? (#Rf.Length - num2) : (#Rf.Length / 2));
				num++;
			}
			return #Rf;
		}

		// Token: 0x06009807 RID: 38919 RVA: 0x0020067C File Offset: 0x001FE87C
		private float #ive(string #Rf)
		{
			float emSize = (float)(this.#c / 12.0);
			System.Drawing.Font font = new System.Drawing.Font(#Phc.#3hc(107356910), emSize);
			return Graphics.FromImage(new Bitmap(1, 1)).MeasureString(#Rf, font).Width;
		}

		// Token: 0x04004160 RID: 16736
		private readonly double #a;

		// Token: 0x04004161 RID: 16737
		private readonly int #b = 11;

		// Token: 0x04004162 RID: 16738
		private readonly double #c;
	}
}
