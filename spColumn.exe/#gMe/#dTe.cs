using System;
using System.Collections.Generic;
using #hZe;
using #s6e;
using #wUe;
using #y6e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Input;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.Geometry;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace #gMe
{
	// Token: 0x020012CF RID: 4815
	internal sealed class #dTe
	{
		// Token: 0x0600A122 RID: 41250 RVA: 0x0007E6B8 File Offset: 0x0007C8B8
		public #dTe(InputModel #hMe, RuntimeModel #iMe)
		{
			this.#a = #hMe;
			this.#b = #iMe;
		}

		// Token: 0x17002E62 RID: 11874
		// (get) Token: 0x0600A123 RID: 41251 RVA: 0x0007E6CE File Offset: 0x0007C8CE
		private #x0e GeometryProperties
		{
			get
			{
				return this.#b.GeometryProperties;
			}
		}

		// Token: 0x17002E63 RID: 11875
		// (get) Token: 0x0600A124 RID: 41252 RVA: 0x0007E6DB File Offset: 0x0007C8DB
		private #K1e ReinforcementBars
		{
			get
			{
				return this.#b.ReinforcementBars;
			}
		}

		// Token: 0x17002E64 RID: 11876
		// (get) Token: 0x0600A125 RID: 41253 RVA: 0x0007E6E8 File Offset: 0x0007C8E8
		private Options Options
		{
			get
			{
				return this.#a.Options;
			}
		}

		// Token: 0x0600A126 RID: 41254 RVA: 0x0007E6F5 File Offset: 0x0007C8F5
		public bool #YSe()
		{
			this.#bpb(true);
			return this.ReinforcementBars.#J1e();
		}

		// Token: 0x0600A127 RID: 41255 RVA: 0x00225890 File Offset: 0x00223A90
		public void #bpb(bool #ZSe = false)
		{
			this.GeometryProperties.AreaOfSteel = this.ReinforcementBars.#I1e();
			this.ReinforcementBars.#H1e(#I6e.#a);
			this.GeometryProperties.#q0e();
			this.GeometryProperties.AreaOfSteelWithinSection = this.GeometryProperties.AreaOfSteel;
			if (#ZSe && this.Options.ProblemType == #z6e.#a)
			{
				this.#6Se();
			}
		}

		// Token: 0x0600A128 RID: 41256 RVA: 0x002258F8 File Offset: 0x00223AF8
		public void #0Se()
		{
			#t6e #2Se = this.#cTe();
			#t6e #3Se = this.#bTe();
			ReinforcementBar[] array = this.ReinforcementBars.Bars;
			for (int i = 0; i < this.ReinforcementBars.NumberOfBars; i++)
			{
				this.#7Se(array[i], #2Se, #3Se);
			}
		}

		// Token: 0x0600A129 RID: 41257 RVA: 0x0007E709 File Offset: 0x0007C909
		private static #I6e #1Se(StructurePoint.CoreAssets.Infrastructure.Data.Point #rG, #t6e #2Se, #t6e #3Se)
		{
			if (#3Se != null && #3Se.#q6e(#rG))
			{
				return #I6e.#c;
			}
			if (#2Se != null && !#2Se.#q6e(#rG))
			{
				return #I6e.#b;
			}
			return #I6e.#a;
		}

		// Token: 0x0600A12A RID: 41258 RVA: 0x00225940 File Offset: 0x00223B40
		private static #t6e #4Se(Figures #5Se)
		{
			List<StructurePoint.CoreAssets.Infrastructure.Data.Point[]> list = new List<StructurePoint.CoreAssets.Infrastructure.Data.Point[]>();
			for (int i = 0; i < #5Se.SectionFigures.Count; i++)
			{
				Points points = #5Se.SectionFigures[i];
				int num = points.NumberOfPoints;
				StructurePoint.CoreAssets.Infrastructure.Data.Point[] array = new StructurePoint.CoreAssets.Infrastructure.Data.Point[num];
				for (int j = 0; j < num; j++)
				{
					array[j].X = (double)(1000f * points.InitialPoints[j].X);
					array[j].Y = (double)(1000f * points.InitialPoints[j].Y);
				}
				list.Add(array);
			}
			return new #u6e(list);
		}

		// Token: 0x0600A12B RID: 41259 RVA: 0x002259F8 File Offset: 0x00223BF8
		private void #6Se()
		{
			this.GeometryProperties.AreaOfSteelWithinSection = 0f;
			#t6e #2Se = this.#cTe();
			#t6e #3Se = this.#bTe();
			ReinforcementBar[] array = this.ReinforcementBars.Bars;
			for (int i = 0; i < this.ReinforcementBars.NumberOfBars; i++)
			{
				this.#7Se(array[i], #2Se, #3Se);
				if (array[i].Location == #I6e.#a || array[i].Location == #I6e.#d)
				{
					this.GeometryProperties.AreaOfSteelWithinSection += array[i].Area;
				}
			}
		}

		// Token: 0x0600A12C RID: 41260 RVA: 0x00225A80 File Offset: 0x00223C80
		private void #7Se(ReinforcementBar #rG, #t6e #2Se, #t6e #3Se)
		{
			StructurePoint.CoreAssets.Infrastructure.Data.Point #rG2 = new StructurePoint.CoreAssets.Infrastructure.Data.Point
			{
				X = (double)(1000f * #rG.X),
				Y = (double)(1000f * #rG.Y)
			};
			#rG.#VWi(#dTe.#1Se(#rG2, #2Se, #3Se));
			if (#rG.Location != #I6e.#a)
			{
				return;
			}
			float #HS = #xke.#eke(#rG.Area / 3.1415927f);
			switch (this.Options.SectionType)
			{
			case #G6e.#a:
				this.#9Se(#rG, #HS);
				return;
			case #G6e.#b:
				this.#aTe(#rG, #HS);
				return;
			case #G6e.#c:
				if (this.#b.Solids.#X2e())
				{
					this.#8Se(#rG, #HS);
				}
				return;
			default:
				return;
			}
		}

		// Token: 0x0600A12D RID: 41261 RVA: 0x00225B34 File Offset: 0x00223D34
		private void #8Se(ReinforcementBar #rG, float #HS)
		{
			foreach (Points points in this.#b.Solids.SectionFigures)
			{
				if (points.#Lnc(#rG.X, #rG.Y))
				{
					int num = points.NumberOfPoints - 1;
					StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.Point[] array = points.InitialPoints;
					for (int i = 0; i < num; i++)
					{
						float num2 = array[i + 1].X - array[i].X;
						float num3 = array[i + 1].Y - array[i].Y;
						float num4 = #xke.#eke(num2 * num2 + num3 * num3);
						if (num4 > 0f)
						{
							float num5 = num3 / num4;
							float num6 = num2 / num4;
							float num7 = #rG.X - array[i].X;
							float num8 = #rG.Y - array[i].Y;
							float num9 = num7 * num6 + num8 * num5;
							if (num9 >= 0f && num9 <= num4 && #xke.#hke(-num7 * num5 + num8 * num6) < #HS)
							{
								#rG.#VWi(#I6e.#d);
							}
						}
					}
				}
			}
		}

		// Token: 0x0600A12E RID: 41262 RVA: 0x00225CA0 File Offset: 0x00223EA0
		private void #9Se(ReinforcementBar #rG, float #HS)
		{
			float[] array = this.#b.SectionDimensionsForInvestigate;
			float #4gb = #xke.#rke(array[0] / 2f - #rG.X, #rG.X + array[0] / 2f);
			float #5gb = #xke.#rke(array[1] / 2f - #rG.Y, #rG.Y + array[1] / 2f);
			if (#xke.#rke(#4gb, #5gb) < #HS)
			{
				#rG.#VWi(#I6e.#b);
			}
		}

		// Token: 0x0600A12F RID: 41263 RVA: 0x0007E728 File Offset: 0x0007C928
		private void #aTe(ReinforcementBar #rG, float #HS)
		{
			if (this.#b.SectionDimensionsForInvestigate[0] / 2f - #xke.#eke(#rG.X * #rG.X + #rG.Y * #rG.Y) < #HS)
			{
				#rG.#VWi(#I6e.#b);
			}
		}

		// Token: 0x0600A130 RID: 41264 RVA: 0x0007E768 File Offset: 0x0007C968
		private #t6e #bTe()
		{
			if (this.Options.SectionType == #G6e.#c && this.#b.Openings.#X2e())
			{
				return #dTe.#4Se(this.#b.Openings);
			}
			return null;
		}

		// Token: 0x0600A131 RID: 41265 RVA: 0x00225D14 File Offset: 0x00223F14
		private #t6e #cTe()
		{
			if (this.Options.SectionType == #G6e.#b)
			{
				return new #r6e(500f * this.#b.SectionDimensionsForInvestigate[0]);
			}
			if (this.Options.SectionType == #G6e.#a)
			{
				float num = 500f * this.#b.SectionDimensionsForInvestigate[0];
				float num2 = 500f * this.#b.SectionDimensionsForInvestigate[1];
				return new #w6e(-num, -num2, num, num2);
			}
			if (this.Options.SectionType == #G6e.#c && this.#b.Solids.#X2e())
			{
				return #dTe.#4Se(this.#b.Solids);
			}
			return null;
		}

		// Token: 0x04004676 RID: 18038
		private readonly InputModel #a;

		// Token: 0x04004677 RID: 18039
		private readonly RuntimeModel #b;
	}
}
