using System;
using System.Collections.Generic;
using System.Linq;
using #hye;
using #owe;
using #Qcd;
using Aspose.Words;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Resources;
using StructurePoint.CoreAssets.Localizer;

namespace StructurePoint.CoreAssets.AppManager.Column.Reporting.Documents.Pages
{
	// Token: 0x020011C8 RID: 4552
	internal sealed class ExternalAndInternalPointsPage : #nwe
	{
		// Token: 0x0600997B RID: 39291 RVA: 0x00079E04 File Offset: 0x00078004
		public ExternalAndInternalPointsPage(#pwe context) : base(context)
		{
		}

		// Token: 0x0600997C RID: 39292 RVA: 0x00209E40 File Offset: 0x00208040
		public override void #pEd()
		{
			if (base.Model.Input.Options.SectionType != SectionType.Irregular && base.Model.Input.Options.SectionType != SectionType.IrregularTemplate)
			{
				return;
			}
			bool flag = base.Options.SectionSolids.#ISd();
			bool flag2 = base.Options.SectionOpenings.#ISd();
			List<SectionPolygon> list = base.Model.BasicProperties.Polygons.Where(new Func<SectionPolygon, bool>(ExternalAndInternalPointsPage.<>c.<>9.#ycf)).OrderBy(new Func<SectionPolygon, int>(ExternalAndInternalPointsPage.<>c.<>9.#zcf)).ToList<SectionPolygon>();
			List<SectionPolygon> list2 = base.Model.BasicProperties.Polygons.Where(new Func<SectionPolygon, bool>(ExternalAndInternalPointsPage.<>c.<>9.#Acf)).OrderBy(new Func<SectionPolygon, int>(ExternalAndInternalPointsPage.<>c.<>9.#Bcf)).ToList<SectionPolygon>();
			if (base.Model.TestOptions.TestMode)
			{
				SectionPolygon sectionPolygon = list.FirstOrDefault<SectionPolygon>();
				if (flag && sectionPolygon != null)
				{
					#ldd #ldd = base.Renderer;
					string stringExteriorPoints = Localization.StringExteriorPoints;
					StyleIdentifier #4cd = StyleIdentifier.Heading2;
					string #Tcd = base.Options.SectionSolids.BookmarkName;
					#ldd.#3cd(stringExteriorPoints, #4cd, null, #Tcd, null);
					this.#6ye(sectionPolygon.Points.Select(new Func<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point, StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.Point>(ExternalAndInternalPointsPage.<>c.<>9.#Ccf)).ToList<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.Point>());
					base.Renderer.#3cd(string.Empty, StyleIdentifier.NoSpacing, null, null, null);
				}
				SectionPolygon sectionPolygon2 = list2.FirstOrDefault<SectionPolygon>();
				if (flag2 && sectionPolygon2 != null)
				{
					#ldd #ldd2 = base.Renderer;
					string stringInteriorPoints = Localization.StringInteriorPoints;
					StyleIdentifier #4cd2 = StyleIdentifier.Heading2;
					string #Tcd = base.Options.SectionOpenings.BookmarkName;
					#ldd2.#3cd(stringInteriorPoints, #4cd2, null, #Tcd, null);
					this.#6ye(sectionPolygon2.Points.Select(new Func<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point, StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.Point>(ExternalAndInternalPointsPage.<>c.<>9.#Dcf)).ToList<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.Point>());
					base.Renderer.#3cd(string.Empty, StyleIdentifier.NoSpacing, null, null, null);
					return;
				}
			}
			else
			{
				if (flag && list.Any<SectionPolygon>())
				{
					#ldd #ldd3 = base.Renderer;
					string stringSolids = Strings.StringSolids;
					StyleIdentifier #4cd3 = StyleIdentifier.Heading2;
					string #Tcd = base.Options.SectionSolids.BookmarkName;
					#ldd3.#3cd(stringSolids, #4cd3, null, #Tcd, null);
					for (int i = 0; i < list.Count; i++)
					{
						SectionPolygon sectionPolygon3 = list[i];
						Option option = base.Options.SectionSolids.Children[i];
						if (option.#ISd())
						{
							#ldd #ldd4 = base.Renderer;
							string displayId = sectionPolygon3.DisplayId;
							StyleIdentifier #4cd4 = StyleIdentifier.Heading3;
							#Tcd = option.BookmarkName;
							#ldd4.#3cd(displayId, #4cd4, null, #Tcd, null);
							this.#6ye(sectionPolygon3.Points.Select(new Func<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point, StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.Point>(ExternalAndInternalPointsPage.<>c.<>9.#Ecf)).ToList<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.Point>());
							base.Renderer.#3cd(string.Empty, StyleIdentifier.NoSpacing, null, null, null);
						}
					}
				}
				if (flag2 && list2.Any<SectionPolygon>())
				{
					#ldd #ldd5 = base.Renderer;
					string stringOpenings = Strings.StringOpenings;
					StyleIdentifier #4cd5 = StyleIdentifier.Heading2;
					string #Tcd = base.Options.SectionOpenings.BookmarkName;
					#ldd5.#3cd(stringOpenings, #4cd5, null, #Tcd, null);
					for (int j = 0; j < list2.Count; j++)
					{
						SectionPolygon sectionPolygon4 = list2[j];
						Option option2 = base.Options.SectionOpenings.Children[j];
						if (option2.#ISd())
						{
							#ldd #ldd6 = base.Renderer;
							string displayId2 = sectionPolygon4.DisplayId;
							StyleIdentifier #4cd6 = StyleIdentifier.Heading3;
							#Tcd = option2.BookmarkName;
							#ldd6.#3cd(displayId2, #4cd6, null, #Tcd, null);
							this.#6ye(sectionPolygon4.Points.Select(new Func<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point, StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.Point>(ExternalAndInternalPointsPage.<>c.<>9.#Fcf)).ToList<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.Point>());
							base.Renderer.#3cd(string.Empty, StyleIdentifier.NoSpacing, null, null, null);
						}
					}
				}
			}
		}

		// Token: 0x0600997D RID: 39293 RVA: 0x00079EB1 File Offset: 0x000780B1
		private void #6ye(IReadOnlyList<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.Point> #BP)
		{
			base.#Rcd(new #Qye(base.Model, #BP, 3));
		}
	}
}
