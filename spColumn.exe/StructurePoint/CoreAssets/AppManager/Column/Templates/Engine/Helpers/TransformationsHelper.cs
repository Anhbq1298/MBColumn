using System;
using System.Collections.Generic;
using System.Linq;
using #6he;
using #7hc;
using #9pe;
using #Gfe;
using devDept.Geometry;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.AppManager.Column.Templates.Engine.DTO;
using StructurePoint.CoreAssets.Geometry.Misc;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace StructurePoint.CoreAssets.AppManager.Column.Templates.Engine.Helpers
{
	// Token: 0x0200108F RID: 4239
	internal sealed class TransformationsHelper
	{
		// Token: 0x060090C4 RID: 37060 RVA: 0x00074C84 File Offset: 0x00072E84
		public TransformationsHelper(#xie transformations)
		{
			this.#a = transformations;
		}

		// Token: 0x060090C5 RID: 37061 RVA: 0x001EA868 File Offset: 0x001E8A68
		public void #Zub(TemplateExecutionResult #PE)
		{
			if (!this.#a.#wie())
			{
				return;
			}
			List<SectionPolygon> #BAb = #PE.Polygons.Where(new Func<SectionPolygon, bool>(TransformationsHelper.<>c.<>9.#Uaf)).ToList<SectionPolygon>();
			List<SectionPolygon> #CAb = #PE.Polygons.Where(new Func<SectionPolygon, bool>(TransformationsHelper.<>c.<>9.#Vaf)).ToList<SectionPolygon>();
			devDept.Geometry.Point3D point3D = SectionGeometryHelper.#gxc(#BAb, #CAb);
			if (point3D == null)
			{
				return;
			}
			StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point point = new StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point(point3D.X, point3D.Y);
			if (this.#a.MirrorVertical)
			{
				GeneralLineEquation generalLineEquation = new GeneralLineEquation(new StructurePoint.CoreAssets.Infrastructure.Data.Point((double)point.X, (double)point.Y), new StructurePoint.CoreAssets.Infrastructure.Data.Point((double)point.X, (double)(point.Y * 10f + 100f)));
				generalLineEquation.#wlc();
				this.#zhe(#PE, generalLineEquation);
			}
			if (this.#a.MirrorHorizontal)
			{
				GeneralLineEquation generalLineEquation2 = new GeneralLineEquation(new StructurePoint.CoreAssets.Infrastructure.Data.Point((double)point.X, (double)point.Y), new StructurePoint.CoreAssets.Infrastructure.Data.Point((double)(point.X * 10f + 100f), (double)point.Y));
				generalLineEquation2.#wlc();
				this.#zhe(#PE, generalLineEquation2);
			}
			if (this.#a.RotateRight)
			{
				this.#Mmc(#PE, point, -1.5707964f);
				this.#Dhe(#PE);
				this.#Bhe(#PE);
			}
			if (this.#a.RotateLeft)
			{
				this.#Mmc(#PE, point, 1.5707964f);
				this.#Dhe(#PE);
				this.#Bhe(#PE);
			}
			if (this.#a.Rotate45Deg)
			{
				this.#Mmc(#PE, point, -0.7853982f);
			}
		}

		// Token: 0x060090C6 RID: 37062 RVA: 0x001EAA18 File Offset: 0x001E8C18
		private void #zhe(TemplateExecutionResult #PE, GeneralLineEquation #Ahe)
		{
			foreach (TemplateReinforcementBar #Ng in #PE.Bars)
			{
				this.#zhe(#Ng, #Ahe);
			}
			foreach (SectionPolygon sectionPolygon in #PE.Polygons)
			{
				foreach (StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point #Ng2 in sectionPolygon.Points)
				{
					this.#zhe(#Ng2, #Ahe);
				}
			}
			foreach (SectionPolygon sectionPolygon2 in #PE.ColoredZones)
			{
				foreach (StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point #Ng3 in sectionPolygon2.Points)
				{
					this.#zhe(#Ng3, #Ahe);
				}
			}
			foreach (LeaderWithText leaderWithText in #PE.Texts)
			{
				this.#zhe(leaderWithText.TargetPoint, #Ahe);
				this.#zhe(leaderWithText.BasePoint, #Ahe);
			}
			foreach (DimensionData dimensionData in #PE.Dimensions)
			{
				this.#zhe(dimensionData.Start, #Ahe);
				this.#zhe(dimensionData.Orientation, #Ahe);
			}
			foreach (#5he #5he in #PE.ShapeLabels)
			{
				this.#zhe(#5he.Start, #Ahe);
				this.#zhe(#5he.End, #Ahe);
			}
			foreach (#Lfe #Lfe in #PE.DimTexts)
			{
				this.#zhe(#Lfe.EndPoint, #Ahe);
				this.#zhe(#Lfe.StartPoint, #Ahe);
				#Lfe.Side = ((#Lfe.Side == #Ffe.#a) ? #Ffe.#b : #Ffe.#a);
			}
		}

		// Token: 0x060090C7 RID: 37063 RVA: 0x001EACE0 File Offset: 0x001E8EE0
		private void #zhe(#mqe #Ng, GeneralLineEquation #Llc)
		{
			double num = #Llc.CoefficientA * (double)#Ng.X + #Llc.CoefficientB * (double)#Ng.Y + #Llc.CoefficientC;
			#Ng.X = (float)((double)#Ng.X - 2.0 * #Llc.CoefficientA * num);
			#Ng.Y = (float)((double)#Ng.Y - 2.0 * #Llc.CoefficientB * num);
		}

		// Token: 0x060090C8 RID: 37064 RVA: 0x00074C93 File Offset: 0x00072E93
		private void #Bhe(TemplateExecutionResult #PE)
		{
			this.#Che(#PE, #Phc.#3hc(107334112), #Phc.#3hc(107334135));
			this.#Che(#PE, #Phc.#3hc(107334094), #Phc.#3hc(107334085));
		}

		// Token: 0x060090C9 RID: 37065 RVA: 0x001EAD54 File Offset: 0x001E8F54
		private void #Che(TemplateExecutionResult #PE, string #xfb, string #yfb)
		{
			foreach (TemplateParameterName templateParameterName in #PE.ParameterNames)
			{
				string text = templateParameterName.EvaluatedName;
				if (!string.IsNullOrWhiteSpace(text))
				{
					text = text.Trim();
					if (text.StartsWith(#xfb, StringComparison.OrdinalIgnoreCase))
					{
						text = text.Substring(#xfb.Length);
						text = #yfb + text;
					}
					else if (text.StartsWith(#yfb, StringComparison.OrdinalIgnoreCase))
					{
						text = text.Substring(#yfb.Length);
						text = #xfb + text;
					}
					templateParameterName.EvaluatedName = text;
				}
			}
		}

		// Token: 0x060090CA RID: 37066 RVA: 0x001EAE00 File Offset: 0x001E9000
		private void #Dhe(TemplateExecutionResult #PE)
		{
			foreach (LeaderWithText leaderWithText in #PE.Texts)
			{
				if (leaderWithText.LeaderType1 == #Gge.#c)
				{
					leaderWithText.LeaderType1 = #Gge.#b;
				}
				else if (leaderWithText.LeaderType1 == #Gge.#b)
				{
					leaderWithText.LeaderType1 = #Gge.#c;
				}
				if (leaderWithText.LeaderType2 == #Gge.#c)
				{
					leaderWithText.LeaderType2 = #Gge.#b;
				}
				else if (leaderWithText.LeaderType2 == #Gge.#b)
				{
					leaderWithText.LeaderType2 = #Gge.#c;
				}
			}
		}

		// Token: 0x060090CB RID: 37067 RVA: 0x001EAE90 File Offset: 0x001E9090
		private void #Mmc(TemplateExecutionResult #PE, #mqe #2Mb, float #Ehe)
		{
			foreach (TemplateReinforcementBar #Ng in #PE.Bars)
			{
				this.#Mmc(#Ng, #2Mb, (double)#Ehe);
			}
			foreach (SectionPolygon sectionPolygon in #PE.Polygons)
			{
				foreach (StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point #Ng2 in sectionPolygon.Points)
				{
					this.#Mmc(#Ng2, #2Mb, (double)#Ehe);
				}
			}
			foreach (SectionPolygon sectionPolygon2 in #PE.ColoredZones)
			{
				foreach (StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point #Ng3 in sectionPolygon2.Points)
				{
					this.#Mmc(#Ng3, #2Mb, (double)#Ehe);
				}
			}
			foreach (LeaderWithText leaderWithText in #PE.Texts)
			{
				this.#Mmc(leaderWithText.TargetPoint, #2Mb, (double)#Ehe);
				this.#Mmc(leaderWithText.BasePoint, #2Mb, (double)#Ehe);
			}
			foreach (DimensionData dimensionData in #PE.Dimensions)
			{
				this.#Mmc(dimensionData.Start, #2Mb, (double)#Ehe);
				this.#Mmc(dimensionData.Orientation, #2Mb, (double)#Ehe);
			}
			foreach (#5he #5he in #PE.ShapeLabels)
			{
				this.#Mmc(#5he.Start, #2Mb, (double)#Ehe);
				this.#Mmc(#5he.End, #2Mb, (double)#Ehe);
			}
			foreach (#Lfe #Lfe in #PE.DimTexts)
			{
				this.#Mmc(#Lfe.EndPoint, #2Mb, (double)#Ehe);
				this.#Mmc(#Lfe.StartPoint, #2Mb, (double)#Ehe);
			}
		}

		// Token: 0x060090CC RID: 37068 RVA: 0x001EB15C File Offset: 0x001E935C
		private void #Mmc(#mqe #Ng, #mqe #Nmc, double #Ehe)
		{
			double num = (double)#Ng.X;
			double num2 = (double)#Ng.Y;
			double num3 = (double)#Nmc.X;
			double num4 = (double)#Nmc.Y;
			#Ng.X = (float)((num - num3) * Math.Cos(#Ehe) - (num2 - num4) * Math.Sin(#Ehe) + num3);
			#Ng.Y = (float)((num - num3) * Math.Sin(#Ehe) + (num2 - num4) * Math.Cos(#Ehe) + num4);
		}

		// Token: 0x04003CD6 RID: 15574
		private readonly #xie #a;
	}
}
