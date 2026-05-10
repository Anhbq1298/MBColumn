using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using #12e;
using #3Qb;
using #5Ve;
using #7hc;
using #Aae;
using #eU;
using #hR;
using #o1d;
using #P6e;
using #RJb;
using #wqe;
using #z5e;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using StructurePoint.CoreAssets.AppManager.Column.Core;
using StructurePoint.CoreAssets.AppManager.Column.Engineer;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.AppManager.Column.Validation;
using StructurePoint.CoreAssets.Column.Core.Templates.Rendering;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core.Entities;
using StructurePoint.CoreAssets.Infrastructure;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Logger;
using StructurePoint.CoreAssets.Units;
using StructurePoint.Products.Column.Model;
using StructurePoint.Products.Column.Model.Entities;
using StructurePoint.Products.Column.Model.Entities.Units;
using StructurePoint.Products.Column.Viewports.API;
using TriangleNet.Geometry;
using TriangleNet.Meshing;
using TriangleNet.Topology;

namespace StructurePoint.Products.Column.Services.Rendering
{
	// Token: 0x020002ED RID: 749
	internal sealed class ModelRenderer : #ER, #WV
	{
		// Token: 0x060019E0 RID: 6624 RVA: 0x000B9454 File Offset: 0x000B7654
		private void #wS(ColumnStorageModel #X, ModelRenderer.#b1b #xS)
		{
			if (#xS.BoundingBoxWithBars == null)
			{
				return;
			}
			bool flag = #X.Options.SectionType == SectionType.Irregular;
			bool flag2 = !flag && #X.Options.ProblemType == ProblemType.Investigation && #X.Options.InvestigationReinforcement == ReinforcementType.Irregular;
			if (flag || flag2)
			{
				return;
			}
			List<ModelRenderer.#I0b> list = (#X.Options.ProblemType == ProblemType.Investigation) ? this.#yS(#X, #xS) : this.#AS(#X, #xS);
			foreach (ModelRenderer.#I0b #DS in list)
			{
				this.#CS(#DS, #xS);
			}
		}

		// Token: 0x060019E1 RID: 6625 RVA: 0x000B9524 File Offset: 0x000B7724
		private List<ModelRenderer.#I0b> #yS(ColumnStorageModel #X, ModelRenderer.#b1b #xS)
		{
			List<ModelRenderer.#I0b> list = new List<ModelRenderer.#I0b>();
			List<ModelRenderer.#I0b> list2;
			if (7 != 0)
			{
				list2 = list;
			}
			List<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar> source = #xS.Bars;
			InvestigationReinforcement investigationReinforcement = #X.InvestigationReinforcement;
			if (!source.Any<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar>())
			{
				return list2;
			}
			StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar reinforcementBar = source.OrderBy(new Func<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar, float>(ModelRenderer.<>c.<>9.#c1b)).ThenByDescending(new Func<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar, float>(ModelRenderer.<>c.<>9.#d1b)).First<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar>();
			devDept.Geometry.Point3D point3D = new devDept.Geometry.Point3D((double)reinforcementBar.X, (double)reinforcementBar.Y);
			ReinforcementType investigationReinforcement2 = #X.Options.InvestigationReinforcement;
			if (investigationReinforcement2 > ReinforcementType.EqualSpace)
			{
				if (investigationReinforcement2 == ReinforcementType.Different)
				{
					return this.#zS(#X, #xS);
				}
			}
			else
			{
				list2.Add(new ModelRenderer.#I0b
				{
					Location = point3D,
					MinCount = investigationReinforcement.AllEqual.NumberOfBars,
					MinSize = #X.Bars[investigationReinforcement.AllEqual.BarSize].Size
				});
			}
			return list2;
		}

		// Token: 0x060019E2 RID: 6626 RVA: 0x000B9640 File Offset: 0x000B7840
		private List<ModelRenderer.#I0b> #zS(ColumnStorageModel #X, ModelRenderer.#b1b #xS)
		{
			List<ModelRenderer.#I0b> list = new List<ModelRenderer.#I0b>();
			InvestigationReinforcementSidesDifferent different = #X.InvestigationReinforcement.Different;
			List<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar> list2 = #xS.Bars;
			List<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar> list3 = list2.OrderByDescending(new Func<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar, float>(ModelRenderer.<>c.<>9.#e1b)).ThenBy(new Func<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar, float>(ModelRenderer.<>c.<>9.#f1b)).Take(different.TopNumberOfBars).ToList<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar>();
			List<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar> list4 = list2.OrderBy(new Func<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar, float>(ModelRenderer.<>c.<>9.#g1b)).ThenBy(new Func<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar, float>(ModelRenderer.<>c.<>9.#h1b)).Take(different.BottomNumberOfBars).ToList<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar>();
			List<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar> source = list2.Except(list3.Concat(list4)).ToList<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar>();
			List<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar> list5 = source.OrderBy(new Func<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar, float>(ModelRenderer.<>c.<>9.#i1b)).ThenByDescending(new Func<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar, float>(ModelRenderer.<>c.<>9.#j1b)).Take(different.LeftNumberOfBars).ToList<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar>();
			List<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar> list6 = source.OrderByDescending(new Func<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar, float>(ModelRenderer.<>c.<>9.#k1b)).ThenByDescending(new Func<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar, float>(ModelRenderer.<>c.<>9.#l1b)).Take(different.RightNumberOfBars).ToList<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar>();
			if (list3.Any<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar>())
			{
				list.Add(new ModelRenderer.#I0b
				{
					Location = new devDept.Geometry.Point3D((double)list3[0].X, (double)list3[0].Y),
					MinCount = different.TopNumberOfBars,
					MinSize = #X.Bars[different.TopBarSize].Size
				});
			}
			if (list4.Any<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar>())
			{
				list.Add(new ModelRenderer.#I0b
				{
					Location = new devDept.Geometry.Point3D((double)list4[0].X, (double)list4[0].Y),
					MinCount = different.BottomNumberOfBars,
					MinSize = #X.Bars[different.BottomBarSize].Size
				});
			}
			if (list5.Any<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar>())
			{
				list.Add(new ModelRenderer.#I0b
				{
					Location = new devDept.Geometry.Point3D((double)list5[0].X, (double)list5[0].Y),
					MinCount = different.LeftNumberOfBars,
					MinSize = #X.Bars[different.LeftBarSize].Size
				});
			}
			if (list6.Any<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar>())
			{
				list.Add(new ModelRenderer.#I0b
				{
					Location = new devDept.Geometry.Point3D((double)list6[0].X, (double)list6[0].Y),
					MinCount = different.RightNumberOfBars,
					MinSize = #X.Bars[different.RightBarSize].Size,
					IsRightSide = true
				});
			}
			return list;
		}

		// Token: 0x060019E3 RID: 6627 RVA: 0x000B9998 File Offset: 0x000B7B98
		private List<ModelRenderer.#I0b> #AS(ColumnStorageModel #X, ModelRenderer.#b1b #xS)
		{
			List<ModelRenderer.#I0b> list = new List<ModelRenderer.#I0b>();
			List<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar> list2 = #xS.Bars;
			DesignReinforcement designReinforcement = #X.DesignReinforcement;
			if (!list2.Any<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar>())
			{
				return list;
			}
			StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar reinforcementBar = list2.OrderBy(new Func<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar, float>(ModelRenderer.<>c.<>9.#m1b)).ThenByDescending(new Func<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar, float>(ModelRenderer.<>c.<>9.#n1b)).First<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar>();
			devDept.Geometry.Point3D point3D = new devDept.Geometry.Point3D((double)reinforcementBar.X, (double)reinforcementBar.Y);
			ReinforcementType designReinforcement2 = #X.Options.DesignReinforcement;
			if (designReinforcement2 > ReinforcementType.EqualSpace)
			{
				if (designReinforcement2 == ReinforcementType.Different)
				{
					return this.#BS(#X, #xS);
				}
			}
			else if (#xS.IsDesignResult)
			{
				list.Add(new ModelRenderer.#I0b
				{
					Location = point3D,
					MinCount = list2.Count,
					MinSize = #X.Bars[#xS.Reinforcement.BarNumber[0]].Size
				});
			}
			else
			{
				list.Add(new ModelRenderer.#I0b
				{
					Location = point3D,
					MinCount = designReinforcement.AllEqual.MinNumberOfBars,
					MaxCount = new int?(designReinforcement.AllEqual.MaxNumberOfBars),
					MinSize = #X.Bars[designReinforcement.AllEqual.MinBarSize].Size,
					MaxSize = new int?(#X.Bars[designReinforcement.AllEqual.MaxBarSize].Size)
				});
			}
			return list;
		}

		// Token: 0x060019E4 RID: 6628 RVA: 0x000B9B40 File Offset: 0x000B7D40
		private List<ModelRenderer.#I0b> #BS(ColumnStorageModel #X, ModelRenderer.#b1b #xS)
		{
			List<ModelRenderer.#I0b> list = new List<ModelRenderer.#I0b>();
			List<ModelRenderer.#I0b> list2;
			if (!false)
			{
				list2 = list;
			}
			DesignReinforcementSidesDifferent different = #X.DesignReinforcement.Different;
			List<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar> source = #xS.Bars;
			StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar reinforcementBar = source.OrderByDescending(new Func<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar, float>(ModelRenderer.<>c.<>9.#o1b)).ThenBy(new Func<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar, float>(ModelRenderer.<>c.<>9.#p1b)).FirstOrDefault<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar>();
			StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar reinforcementBar2 = source.OrderBy(new Func<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar, float>(ModelRenderer.<>c.<>9.#q1b)).ThenByDescending(new Func<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar, float>(ModelRenderer.<>c.<>9.#r1b)).Skip(1).FirstOrDefault<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar>();
			if (#xS.IsDesignResult)
			{
				if (reinforcementBar != null)
				{
					list2.Add(new ModelRenderer.#I0b
					{
						Location = new devDept.Geometry.Point3D((double)reinforcementBar.X, (double)reinforcementBar.Y),
						MinCount = #xS.Reinforcement.AmountOfBars[0] * 2,
						MinSize = #X.Bars[#xS.Reinforcement.BarNumber[0]].Size
					});
				}
				if (reinforcementBar2 != null)
				{
					list2.Add(new ModelRenderer.#I0b
					{
						Location = new devDept.Geometry.Point3D((double)reinforcementBar2.X, (double)reinforcementBar2.Y),
						MinCount = #xS.Reinforcement.AmountOfBars[2] * 2,
						MinSize = #X.Bars[#xS.Reinforcement.BarNumber[2]].Size
					});
				}
			}
			else
			{
				if (reinforcementBar != null)
				{
					list2.Add(new ModelRenderer.#I0b
					{
						Location = new devDept.Geometry.Point3D((double)reinforcementBar.X, (double)reinforcementBar.Y),
						MinCount = different.MinTopBottomNumberOfBars,
						MaxCount = new int?(different.MaxTopBottomNumberOfBars),
						MinSize = #X.Bars[different.MinTopBottomBarSize].Size,
						MaxSize = new int?(#X.Bars[different.MaxTopBottomBarSize].Size)
					});
				}
				if (reinforcementBar2 != null && different.MinLeftRightNumberOfBars > 0)
				{
					list2.Add(new ModelRenderer.#I0b
					{
						Location = new devDept.Geometry.Point3D((double)reinforcementBar2.X, (double)reinforcementBar2.Y),
						MinCount = different.MinLeftRightNumberOfBars,
						MaxCount = new int?(different.MaxLeftRightNumberOfBars),
						MinSize = #X.Bars[different.MinLeftRightBarSize].Size,
						MaxSize = new int?(#X.Bars[different.MaxLeftRightBarSize].Size)
					});
				}
			}
			return list2;
		}

		// Token: 0x060019E5 RID: 6629 RVA: 0x000B9E14 File Offset: 0x000B8014
		private void #CS(ModelRenderer.#I0b #DS, ModelRenderer.#b1b #xS)
		{
			string #oT = this.#ES(#DS);
			BoundingBoxData boundingBoxData = #xS.BoundingBoxWithBars;
			double x = #DS.IsRightSide ? boundingBoxData.MaxX : boundingBoxData.MinX;
			ContentAlignment #rT = #DS.IsRightSide ? ContentAlignment.BottomRight : ContentAlignment.BottomLeft;
			devDept.Geometry.Point3D point3D = #DS.Location;
			devDept.Geometry.Point3D #qT = new devDept.Geometry.Point3D(x, point3D.Y);
			this.#nT(#oT, point3D, #qT, #rT, !#DS.IsRightSide);
		}

		// Token: 0x060019E6 RID: 6630 RVA: 0x000B9E98 File Offset: 0x000B8098
		private string #ES(ModelRenderer.#I0b #DS)
		{
			int? num = #DS.MaxCount;
			int? num2;
			if (!false)
			{
				num2 = num;
			}
			if (num2 != null)
			{
				num2 = #DS.MaxSize;
				if (num2 != null)
				{
					string format = #Phc.#3hc(107401097);
					object[] array = new object[4];
					array[0] = #DS.MinCount;
					array[1] = #DS.MinSize;
					int num3 = 2;
					num2 = #DS.MaxCount;
					array[num3] = num2.Value;
					int num4 = 3;
					num2 = #DS.MaxSize;
					array[num4] = num2.Value;
					return string.Format(format, array);
				}
			}
			return string.Format(#Phc.#3hc(107401064), #DS.MinCount, #DS.MinSize);
		}

		// Token: 0x060019E7 RID: 6631 RVA: 0x000B9F68 File Offset: 0x000B8168
		private ModelRenderer.ReinforcementBlockMetadata #FS(IList<ModelRenderer.ReinforcementBlockMetadata> #GS, double #HS, bool #IS, bool #JS, bool #KS, bool #LS)
		{
			ModelRenderer.#21b #21b = new ModelRenderer.#21b();
			#21b.#a = #HS;
			#21b.#b = #IS;
			#21b.#c = #JS;
			#21b.#d = #KS;
			#21b.#e = #LS;
			return #GS.FirstOrDefault(new Func<ModelRenderer.ReinforcementBlockMetadata, bool>(#21b.#11b));
		}

		// Token: 0x060019E8 RID: 6632 RVA: 0x000B9FC0 File Offset: 0x000B81C0
		private void #MS(ModelRenderer.#b1b #xS, bool #NS)
		{
			ModelRenderer.#iZb #iZb = new ModelRenderer.#iZb();
			#iZb.#a = this;
			#iZb.#b = #NS;
			List<double> source = #xS.Bars.Where(new Func<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar, bool>(ModelRenderer.<>c.<>9.#s1b)).Select(new Func<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar, double>(#iZb.#31b)).Distinct<double>().ToList<double>();
			List<ModelRenderer.ReinforcementBlockMetadata> list = this.#b.Where(new Func<ModelRenderer.ReinforcementBlockMetadata, bool>(#iZb.#41b)).ToList<ModelRenderer.ReinforcementBlockMetadata>();
			foreach (double #HS in source.Where(new Func<double, bool>(ModelRenderer.<>c.<>9.#Bci)))
			{
				this.#OS(list, #HS, #iZb.#b, false, false);
				this.#OS(list, #HS, #iZb.#b, true, false);
				this.#OS(list, #HS, #iZb.#b, false, true);
			}
			this.#b.#F7c(list);
			base.Editor.Blocks.#F7c(list.Select(new Func<ModelRenderer.ReinforcementBlockMetadata, Block>(ModelRenderer.<>c.<>9.#t1b)));
			list.ForEach(new Action<ModelRenderer.ReinforcementBlockMetadata>(ModelRenderer.<>c.<>9.#cZh));
		}

		// Token: 0x060019E9 RID: 6633 RVA: 0x00019CD1 File Offset: 0x00017ED1
		private void #OS(List<ModelRenderer.ReinforcementBlockMetadata> #PS, double #HS, bool #NS, bool #JS, bool #KS)
		{
			this.#QS(#PS, #HS, #NS, #JS, #KS);
			this.#RS(#PS, #HS, #NS, #JS, #KS);
		}

		// Token: 0x060019EA RID: 6634 RVA: 0x000BA154 File Offset: 0x000B8354
		private void #QS(List<ModelRenderer.ReinforcementBlockMetadata> #PS, double #HS, bool #NS, bool #JS, bool #KS)
		{
			ModelRenderer.#61b #61b = new ModelRenderer.#61b();
			ModelRenderer.#61b #61b2;
			if (4 != 0)
			{
				#61b2 = #61b;
			}
			#61b2.#a = this.#FS(#PS, #HS, #NS, #JS, #KS, true);
			if (#61b2.#a != null)
			{
				if (!string.IsNullOrWhiteSpace(#61b2.#a.MaterialName))
				{
					ModelRenderer.#81b #81b = new ModelRenderer.#81b();
					#81b.#a = base.Editor.Materials[#61b2.#a.MaterialName].Diffuse;
					#61b2.#a.Block.Entities.OfType<CustomMeshEntity>().#I1d(new Action<CustomMeshEntity>(#81b.#71b));
				}
				#PS.RemoveAll(new Predicate<ModelRenderer.ReinforcementBlockMetadata>(#61b2.#51b));
				return;
			}
			Block block = this.#QS(#HS, #NS, #JS, #KS);
			base.Editor.Blocks.AddOrReplace(block);
			List<ModelRenderer.ReinforcementBlockMetadata> list = this.#b;
			ModelRenderer.ReinforcementBlockMetadata reinforcementBlockMetadata = new ModelRenderer.ReinforcementBlockMetadata();
			reinforcementBlockMetadata.Block = block;
			reinforcementBlockMetadata.Radius = #HS;
			reinforcementBlockMetadata.IsLeftRight = #NS;
			reinforcementBlockMetadata.IsSelection = #JS;
			reinforcementBlockMetadata.IsOverlapped = #KS;
			reinforcementBlockMetadata.IsFinal = true;
			Entity entity = block.Entities.FirstOrDefault(new Func<Entity, bool>(ModelRenderer.<>c.<>9.#v1b));
			reinforcementBlockMetadata.MaterialName = ((entity != null) ? entity.MaterialName : null);
			list.Add(reinforcementBlockMetadata);
		}

		// Token: 0x060019EB RID: 6635 RVA: 0x000BA2B4 File Offset: 0x000B84B4
		private void #RS(List<ModelRenderer.ReinforcementBlockMetadata> #PS, double #HS, bool #NS, bool #JS, bool #KS)
		{
			ModelRenderer.#8Ub #8Ub = new ModelRenderer.#8Ub();
			ModelRenderer.#8Ub #8Ub2;
			if (4 != 0)
			{
				#8Ub2 = #8Ub;
			}
			#8Ub2.#a = this.#FS(#PS, #HS, #NS, #JS, #KS, false);
			if (#8Ub2.#a != null)
			{
				if (!string.IsNullOrWhiteSpace(#8Ub2.#a.MaterialName))
				{
					ModelRenderer.#b2b #b2b = new ModelRenderer.#b2b();
					#b2b.#a = base.Editor.Materials[#8Ub2.#a.MaterialName].Diffuse;
					#8Ub2.#a.Block.Entities.OfType<CustomMeshEntity>().#I1d(new Action<CustomMeshEntity>(#b2b.#a2b));
				}
				#PS.RemoveAll(new Predicate<ModelRenderer.ReinforcementBlockMetadata>(#8Ub2.#91b));
				return;
			}
			Block block = this.#RS(#HS, #NS, #JS, #KS);
			base.Editor.Blocks.AddOrReplace(block);
			List<ModelRenderer.ReinforcementBlockMetadata> list = this.#b;
			ModelRenderer.ReinforcementBlockMetadata reinforcementBlockMetadata = new ModelRenderer.ReinforcementBlockMetadata();
			reinforcementBlockMetadata.Block = block;
			reinforcementBlockMetadata.Radius = #HS;
			reinforcementBlockMetadata.IsLeftRight = #NS;
			reinforcementBlockMetadata.IsSelection = #JS;
			reinforcementBlockMetadata.IsOverlapped = #KS;
			reinforcementBlockMetadata.IsFinal = false;
			Entity entity = block.Entities.FirstOrDefault(new Func<Entity, bool>(ModelRenderer.<>c.<>9.#w1b));
			reinforcementBlockMetadata.MaterialName = ((entity != null) ? entity.MaterialName : null);
			list.Add(reinforcementBlockMetadata);
		}

		// Token: 0x060019EC RID: 6636 RVA: 0x000BA414 File Offset: 0x000B8614
		private Block #RS(double #HS, bool #IS, bool #JS, bool #SS)
		{
			string text = #SS ? #Phc.#3hc(107401008) : (#JS ? #Phc.#3hc(107401005) : (#IS ? #Phc.#3hc(107401030) : #Phc.#3hc(107401083)));
			string text2 = #IS ? #Phc.#3hc(107400431) : string.Empty;
			string text3;
			if (!#SS)
			{
				if (!#JS)
				{
					string format = #Phc.#3hc(107400426);
					object arg = text2;
					int num = this.#a;
					this.#a = num + 1;
					text3 = string.Format(format, arg, num);
				}
				else
				{
					string format2 = #Phc.#3hc(107400409);
					object arg2 = text2;
					int num = this.#a;
					this.#a = num + 1;
					text3 = string.Format(format2, arg2, num);
				}
			}
			else
			{
				string format3 = #Phc.#3hc(107400348);
				int num = this.#a;
				this.#a = num + 1;
				text3 = string.Format(format3, num);
			}
			string name = text3;
			Block block = new Block(name);
			devDept.Geometry.Point3D center = new devDept.Geometry.Point3D(0.0, 0.0, 0.0);
			List<devDept.Geometry.Point3D> outerLoop = EyeshotHelper.ConstructRegularPolygon(center, #HS, 100, 0.0, true);
			List<devDept.Geometry.Point3D> item = EyeshotHelper.ConstructRegularPolygon(center, #HS * 0.85, 100, 0.0, true);
			Mesh mesh = UtilityEx.Triangulate(outerLoop, new List<IList<devDept.Geometry.Point3D>>
			{
				item
			}, null, null);
			mesh.Regen(null);
			mesh = new CustomMeshEntity(mesh)
			{
				MaterialName = text,
				ColorMethod = colorMethodType.byEntity,
				EdgeStyle = Mesh.edgeStyleType.Sharp,
				VisualOrder = 10.0 * #KT.#a + #KT.#b,
				EdgesColor = new Color?(base.Editor.Materials[text].Diffuse)
			};
			block.Entities.Add(mesh);
			return block;
		}

		// Token: 0x060019ED RID: 6637 RVA: 0x000BA5FC File Offset: 0x000B87FC
		private Block #QS(double #HS, bool #IS, bool #JS, bool #SS)
		{
			string #US = #SS ? #Phc.#3hc(107401008) : (#JS ? #Phc.#3hc(107401005) : (#IS ? #Phc.#3hc(107401030) : #Phc.#3hc(107401083)));
			string text = #IS ? #Phc.#3hc(107400431) : string.Empty;
			string text2;
			if (!#SS)
			{
				if (!#JS)
				{
					string format = #Phc.#3hc(107400287);
					object arg = text;
					int num = this.#a;
					this.#a = num + 1;
					text2 = string.Format(format, arg, num);
				}
				else
				{
					string format2 = #Phc.#3hc(107400246);
					object arg2 = text;
					int num = this.#a;
					this.#a = num + 1;
					text2 = string.Format(format2, arg2, num);
				}
			}
			else
			{
				string format3 = #Phc.#3hc(107400673);
				int num = this.#a;
				this.#a = num + 1;
				text2 = string.Format(format3, num);
			}
			string name = text2;
			Block block = new Block(name);
			this.#TS(block.Entities, #HS, #US);
			return block;
		}

		// Token: 0x060019EE RID: 6638 RVA: 0x000BA714 File Offset: 0x000B8914
		private void #TS(IList<Entity> #qR, double #HS, string #US)
		{
			devDept.Geometry.Point3D point3D = new devDept.Geometry.Point3D(0.0, 0.0, 0.0);
			devDept.Geometry.Point3D center;
			if (2 != 0)
			{
				center = point3D;
			}
			CustomRegion item = new CustomRegion(devDept.Eyeshot.Entities.Region.CreatePolygon(EyeshotHelper.ConstructRegularPolygon(center, #HS, 20, 0.0, false).ToArray()))
			{
				MaterialName = #US,
				ColorMethod = colorMethodType.byEntity,
				VisualOrder = 10.0 * #KT.#a + #KT.#b,
				EdgeColor = Color.Transparent
			};
			#qR.Add(item);
		}

		// Token: 0x060019EF RID: 6639 RVA: 0x000BA7B0 File Offset: 0x000B89B0
		private void #VS(IList<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar> #KJ)
		{
			this.#c.Clear();
			List<ModelRenderer.BarDistanceMetadata> list = #KJ.Where(new Func<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar, bool>(ModelRenderer.<>c.<>9.#x1b)).Select(new Func<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar, ModelRenderer.BarDistanceMetadata>(ModelRenderer.<>c.<>9.#y1b)).ToList<ModelRenderer.BarDistanceMetadata>();
			for (int i = 0; i < list.Count; i++)
			{
				ModelRenderer.BarDistanceMetadata value = list[i];
				devDept.Geometry.Point3D point3D = value.Location;
				double num = value.Radius;
				value.Box = new EyeshotBoundingBoxDataLight(point3D.X - num, point3D.X + num, point3D.Y - num, point3D.Y + num);
				list[i] = value;
			}
			for (int j = 0; j < list.Count; j++)
			{
				ModelRenderer.BarDistanceMetadata barDistanceMetadata = list[j];
				devDept.Geometry.Point3D a = barDistanceMetadata.Location;
				EyeshotBoundingBoxDataLight eyeshotBoundingBoxDataLight = barDistanceMetadata.Box;
				for (int k = j + 1; k < list.Count; k++)
				{
					ModelRenderer.BarDistanceMetadata barDistanceMetadata2 = list[k];
					if (eyeshotBoundingBoxDataLight.Overlaps(barDistanceMetadata2.Box))
					{
						double num2 = barDistanceMetadata.Radius + barDistanceMetadata2.Radius;
						double num3 = num2 * num2;
						if (devDept.Geometry.Point3D.DistanceSquared(a, barDistanceMetadata2.Location) < num3)
						{
							ModelRenderer.BarDistanceMetadata value2 = list[j];
							value2.IsOverlapped = true;
							list[j] = value2;
							value2 = list[k];
							value2.IsOverlapped = true;
							list[k] = value2;
						}
					}
				}
			}
			this.#c = new HashSet<devDept.Geometry.Point3D>(list.Where(new Func<ModelRenderer.BarDistanceMetadata, bool>(ModelRenderer.<>c.<>9.#dZh)).Select(new Func<ModelRenderer.BarDistanceMetadata, devDept.Geometry.Point3D>(ModelRenderer.<>c.<>9.#eZh)).ToList<devDept.Geometry.Point3D>());
		}

		// Token: 0x060019F0 RID: 6640 RVA: 0x000BA9C4 File Offset: 0x000B8BC4
		private void #WS(ColumnStorageModel #X, ModelRenderer.#b1b #xS, int #XS)
		{
			List<Entity> list = new List<Entity>(#xS.Bars.Count + 1);
			double num = (double)#XS * #KT.#a + #KT.#b;
			List<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar> list2 = #xS.Bars;
			float num2;
			if (!list2.Any<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar>())
			{
				num2 = 0f;
			}
			else
			{
				num2 = list2.Min(new Func<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar, float>(ModelRenderer.<>c.<>9.#z1b));
			}
			float num3 = num2;
			float num4;
			if (!list2.Any<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar>())
			{
				num4 = 0f;
			}
			else
			{
				num4 = list2.Max(new Func<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar, float>(ModelRenderer.<>c.<>9.#A1b));
			}
			float num5 = num4;
			bool flag = list2.Count > 1 && num3 != num5 && #Uqe.#Tqe(#X);
			this.#VS(#xS.Bars);
			List<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar> list3 = new List<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar>();
			List<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar> list4 = new List<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar>();
			List<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar> list5 = new List<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar>();
			bool flag2 = #xS.DesignWasSuccessful || #X.Options.ProblemType == ProblemType.Investigation;
			for (int i = 0; i < list2.Count; i++)
			{
				StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar reinforcementBar = list2[i];
				if ((double)reinforcementBar.Area > 0.001)
				{
					double num6 = Math.Round(CircleHelper.#wmc((double)reinforcementBar.Area), this.#t);
					if (num6 > 0.0)
					{
						bool flag3 = flag && reinforcementBar.Y > num3 && reinforcementBar.Y < num5;
						bool flag4 = this.#c.Count > 0 && this.#c.Contains(new devDept.Geometry.Point3D((double)reinforcementBar.X, (double)reinforcementBar.Y));
						ModelRenderer.ReinforcementBlockMetadata reinforcementBlockMetadata = this.#FS(this.#b, num6, flag3, false, flag4, flag2);
						if (reinforcementBlockMetadata != null)
						{
							devDept.Geometry.Point3D insPoint = new devDept.Geometry.Point3D((double)reinforcementBar.X, (double)reinforcementBar.Y, num);
							list.Add(new CustomBlockReference(insPoint, reinforcementBlockMetadata.Block.Name, 0.0)
							{
								VisualOrder = num,
								EntityData = base.ProjectContext.Model.ReinforcementBars.ElementAtOrDefault(i)
							});
							if (flag4)
							{
								list3.Add(reinforcementBar);
							}
							else if (flag3)
							{
								list4.Add(reinforcementBar);
							}
							else
							{
								list5.Add(reinforcementBar);
							}
						}
					}
				}
			}
			if (flag2)
			{
				this.#YS(list, list5, this.SectionColors.BarPointColor.ToDrawingColor(), #XS);
				this.#YS(list, list4, this.SectionColors.BarLrPointColor.ToDrawingColor(), #XS);
				this.#YS(list, list3, this.SectionColors.BarPointColor.ToDrawingColor(), #XS);
			}
			base.#pR<Entity>(list, #ER.#a);
		}

		// Token: 0x060019F1 RID: 6641 RVA: 0x000BAC98 File Offset: 0x000B8E98
		private void #YS(List<Entity> #qR, IList<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar> #KJ, Color #BR, int #XS)
		{
			ModelRenderer.#wWb #wWb = new ModelRenderer.#wWb();
			ModelRenderer.#wWb #wWb2;
			if (!false)
			{
				#wWb2 = #wWb;
			}
			if (!#KJ.Any<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar>())
			{
				return;
			}
			#wWb2.#a = (double)#XS * #KT.#a + #KT.#b * 3.0;
			List<devDept.Geometry.Point3D> points = #KJ.Select(new Func<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar, devDept.Geometry.Point3D>(#wWb2.#c2b)).ToList<devDept.Geometry.Point3D>();
			CustomPointCloud item = new CustomPointCloud(points, #KT.#1)
			{
				Color = #BR,
				ColorMethod = colorMethodType.byEntity
			};
			#qR.Add(item);
		}

		// Token: 0x060019F2 RID: 6642 RVA: 0x000BAD1C File Offset: 0x000B8F1C
		private bool #ZS()
		{
			bool flag = false;
			bool result;
			if (4 != 0)
			{
				result = flag;
			}
			foreach (CustomMeshEntity customMeshEntity in base.Editor.Entities.Where(new Func<Entity, bool>(ModelRenderer.<>c.<>9.#B1b)).OfType<CustomMeshEntity>())
			{
				ModelRenderer.#9Vb #9Vb = new ModelRenderer.#9Vb();
				#9Vb.#a = (customMeshEntity.EntityData as ShapeModel);
				if (#9Vb.#a != null)
				{
					#fS #fS = base.Editor.CoreRendererModel.Centroids.FirstOrDefault(new Func<#fS, bool>(#9Vb.#d2b));
					if (base.EditorContext.Selection.Shapes.SelectedObjects.Contains(#9Vb.#a))
					{
						if (#fS != null)
						{
							#fS.IsSelected = true;
						}
						string text = (#9Vb.#a.Application == PolygonApplication.Solid) ? #Phc.#3hc(107400591) : #Phc.#3hc(107400656);
						if (customMeshEntity.MaterialName != text)
						{
							customMeshEntity.MaterialName = text;
							customMeshEntity.RegenMode = regenType.RegenAndCompile;
							customMeshEntity.EdgesColor = new Color?(ModelRenderer.#d);
							result = true;
						}
					}
					else
					{
						if (#fS != null)
						{
							#fS.IsSelected = false;
						}
						string text2 = (#9Vb.#a.Application == PolygonApplication.Solid) ? #Phc.#3hc(107400569) : #Phc.#3hc(107400594);
						if (customMeshEntity.MaterialName != text2)
						{
							customMeshEntity.MaterialName = text2;
							customMeshEntity.RegenMode = regenType.RegenAndCompile;
							customMeshEntity.EdgesColor = null;
							result = true;
						}
					}
				}
			}
			return result;
		}

		// Token: 0x060019F3 RID: 6643 RVA: 0x000BAEF4 File Offset: 0x000B90F4
		private bool #0S()
		{
			bool result = false;
			ModelRenderer.#b1b #b1b = this.#s;
			bool #LS = ((#b1b != null) ? new bool?(#b1b.DesignWasSuccessful) : null).GetValueOrDefault(true) || base.ProjectContext.Model.Options.ProblemType == ProblemType.Investigation;
			foreach (BlockReference blockReference in base.Editor.Entities.Where(new Func<Entity, bool>(ModelRenderer.<>c.<>9.#C1b)).OfType<BlockReference>())
			{
				BlockReference blockReference2 = blockReference;
				StructurePoint.Products.Column.Model.Entities.ReinforcementBar reinforcementBar = blockReference2.EntityData as StructurePoint.Products.Column.Model.Entities.ReinforcementBar;
				if (reinforcementBar != null)
				{
					double #HS = Math.Round(CircleHelper.#wmc((double)reinforcementBar.Area), this.#t);
					if (base.EditorContext.Selection.Bars.SelectedObjects.Contains(reinforcementBar))
					{
						if (!blockReference2.BlockName.Contains(#Phc.#3hc(107400516)))
						{
							ModelRenderer.ReinforcementBlockMetadata reinforcementBlockMetadata = this.#FS(this.#b, #HS, false, true, false, #LS);
							if (((reinforcementBlockMetadata != null) ? reinforcementBlockMetadata.Block : null) != null)
							{
								blockReference2.BlockName = reinforcementBlockMetadata.Block.Name;
								blockReference2.RegenMode = regenType.RegenAndCompile;
								result = true;
							}
						}
					}
					else
					{
						bool #KS = this.#c.Contains(new devDept.Geometry.Point3D((double)reinforcementBar.X, (double)reinforcementBar.Y));
						ModelRenderer.ReinforcementBlockMetadata reinforcementBlockMetadata2 = this.#FS(this.#b, #HS, false, false, #KS, #LS);
						if (((reinforcementBlockMetadata2 != null) ? reinforcementBlockMetadata2.Block : null) != null)
						{
							string name = reinforcementBlockMetadata2.Block.Name;
							if (!string.Equals(name, blockReference2.BlockName))
							{
								blockReference2.BlockName = name;
								blockReference2.RegenMode = regenType.RegenAndCompile;
								result = true;
							}
						}
					}
				}
			}
			return result;
		}

		// Token: 0x060019F4 RID: 6644 RVA: 0x000BB10C File Offset: 0x000B930C
		public ModelRenderer(#cLb editorContext, #qW designEngineService, IModelEditorViewport ownerViewport) : base(editorContext.ProjectContext, editorContext)
		{
			this.#q = designEngineService;
			this.#r = ownerViewport;
		}

		// Token: 0x17000996 RID: 2454
		// (get) Token: 0x060019F5 RID: 6645 RVA: 0x00019CF9 File Offset: 0x00017EF9
		// (set) Token: 0x060019F6 RID: 6646 RVA: 0x00019D05 File Offset: 0x00017F05
		private protected #qRb SectionColors { protected get; private set; }

		// Token: 0x17000997 RID: 2455
		// (get) Token: 0x060019F7 RID: 6647 RVA: 0x00019D16 File Offset: 0x00017F16
		// (set) Token: 0x060019F8 RID: 6648 RVA: 0x00019D22 File Offset: 0x00017F22
		private protected double TextSize { protected get; private set; }

		// Token: 0x17000998 RID: 2456
		// (get) Token: 0x060019F9 RID: 6649 RVA: 0x00019D33 File Offset: 0x00017F33
		protected double BarPointSize
		{
			get
			{
				return 0.1;
			}
		}

		// Token: 0x060019FA RID: 6650 RVA: 0x000BB15C File Offset: 0x000B935C
		public void #eg()
		{
			if (this.#cVh())
			{
				return;
			}
			ModelRenderer.#b1b #b1b = this.#s;
			if (base.ProjectContext.Model.Options.SectionType != SectionType.Irregular || #b1b == null)
			{
				return;
			}
			base.Editor.Entities.#71d(new Predicate<Entity>(ModelRenderer.<>c.<>9.#fZh));
			this.#eb(false);
			ModelRenderer.#b1b #b1b2 = new ModelRenderer.#b1b();
			this.#CT(#b1b2);
			bool flag = this.#zT(#b1b2.CoverPoints);
			if (flag)
			{
				this.#uT(#b1b2, #b1b.Polygons.Count);
				base.Editor.Invalidate();
			}
		}

		// Token: 0x060019FB RID: 6651 RVA: 0x00019D3E File Offset: 0x00017F3E
		public void #dg()
		{
			if (this.#cVh())
			{
				return;
			}
			this.#eci();
		}

		// Token: 0x060019FC RID: 6652 RVA: 0x000BB224 File Offset: 0x000B9424
		public void #9f(bool #ag = false, bool #Cci = false)
		{
			if (this.#cVh())
			{
				return;
			}
			if (this.#p.#YXd())
			{
				try
				{
					this.#eb(true);
					base.Editor.Labels.Clear();
					base.Editor.Entities.#71d(new Predicate<Entity>(ModelRenderer.<>c.<>9.#gZh));
					base.Editor.Entities.#71d(new Predicate<Entity>(ModelRenderer.<>c.<>9.#hZh));
					base.Editor.Entities.#71d(new Predicate<Entity>(ModelRenderer.<>c.<>9.#iZh));
					base.Editor.Entities.#71d(new Predicate<Entity>(ModelRenderer.<>c.<>9.#jZh));
					if (#Cci)
					{
						base.Editor.Entities.Regen(null);
						base.Editor.Refresh();
					}
					base.Editor.TemplatesCoreRenderer.#uP(null);
					IModelEditorViewport modelEditorViewport = this.#r;
					if (modelEditorViewport != null)
					{
						modelEditorViewport.#Ed();
					}
					if (base.ProjectContext.Model.Options.SectionType == SectionType.IrregularTemplate)
					{
						this.#4S(!#ag);
					}
					else
					{
						TemplateModelRenderer templateModelRenderer = new TemplateModelRenderer(base.Editor);
						templateModelRenderer.ClearAll();
						this.#6S(#ag);
					}
					base.Editor.Invalidate();
				}
				catch (Exception exception)
				{
					base.EditorContext.Logger.Log(LoggingLevel.Error, exception);
				}
				finally
				{
					this.#p.#ZXd();
				}
			}
		}

		// Token: 0x060019FD RID: 6653 RVA: 0x000BB420 File Offset: 0x000B9620
		public void #bg()
		{
			if (this.#cVh())
			{
				return;
			}
			if (base.Editor.CoreRendererModel.UseGlobalSettings)
			{
				if (this.#s != null)
				{
					this.#dT(this.#s);
					return;
				}
			}
			else
			{
				base.Editor.ZoomFitExt(false, 60);
			}
		}

		// Token: 0x060019FE RID: 6654 RVA: 0x00019D5B File Offset: 0x00017F5B
		public void #cg()
		{
			if (this.#cVh())
			{
				return;
			}
			base.Editor.Invalidate();
		}

		// Token: 0x060019FF RID: 6655 RVA: 0x000BB478 File Offset: 0x000B9678
		public bool #fg()
		{
			if (this.#cVh())
			{
				return false;
			}
			if (base.ProjectContext.Model.Options.SectionType != SectionType.Circle && base.ProjectContext.Model.Options.SectionType != SectionType.Rectangle)
			{
				return true;
			}
			ColumnStorageModel columnStorageModel = base.ProjectContext.Model.#CY();
			if (columnStorageModel.Options.ProblemType == ProblemType.Investigation)
			{
				InvestigationReinforcementValidator investigationReinforcementValidator = new InvestigationReinforcementValidator(columnStorageModel.CreateContext());
				return investigationReinforcementValidator.Validate(columnStorageModel.InvestigationReinforcement).IsValid;
			}
			if (columnStorageModel.Options.ProblemType == ProblemType.Design)
			{
				DesignReinforcementValidator designReinforcementValidator = new DesignReinforcementValidator(columnStorageModel.CreateContext());
				return designReinforcementValidator.Validate(columnStorageModel.DesignReinforcement).IsValid;
			}
			return true;
		}

		// Token: 0x06001A00 RID: 6656 RVA: 0x000BB548 File Offset: 0x000B9748
		private void #eci()
		{
			if (base.ProjectContext.Model.Options.SectionType != SectionType.Irregular)
			{
				return;
			}
			bool flag = this.#0S();
			flag = (this.#ZS() || flag);
			if (flag)
			{
				this.#8S(this.#s);
				this.#DT();
				base.Editor.Entities.Regen(null);
			}
		}

		// Token: 0x06001A01 RID: 6657 RVA: 0x000BB5B0 File Offset: 0x000B97B0
		private bool #cVh()
		{
			return base.IsOffline || !base.Editor.IsVisible || (this.#r != null && this.#r.MarkedForClosing) || this.#p.#XXd();
		}

		// Token: 0x06001A02 RID: 6658 RVA: 0x000BB600 File Offset: 0x000B9800
		private void #4S(bool #5S)
		{
			TemplateModelRenderer templateModelRenderer = new TemplateModelRenderer(base.Editor);
			if (base.ProjectContext.TemplateExecutionResult != null)
			{
				base.Editor.TemplatesCoreRenderer.#uP(base.ProjectContext.TemplateExecutionResult);
				TemplateRenderOptions templateRenderOptions = new TemplateRenderOptions
				{
					OpeningsColor = this.SectionColors.OpeningColor,
					SolidsColor = this.SectionColors.SolidColor,
					BarsColor = this.SectionColors.BarAreaColor,
					BarPointColor = this.SectionColors.BarPointColor,
					FontSize = (float)this.SectionColors.LabelSize,
					FontColor = this.SectionColors.DimensionsColor,
					FontName = #KT.#d,
					ShowColoredZones = base.ProjectContext.Model.TemplateData.Options.ShowColoredZones,
					ShowParameters = base.ProjectContext.Model.TemplateData.Options.ShowParameters,
					ShowAnnotations = base.Settings.CurrentColorSettings.SectionAnnotationsVisibility
				};
				templateRenderOptions.ZoneInfos.AddRange(base.ProjectContext.TemplateZoneInfos);
				base.Editor.TemplatesCoreRenderer.#uP(templateRenderOptions);
				templateModelRenderer.Render(base.ProjectContext.TemplateExecutionResult, templateRenderOptions, #5S);
			}
		}

		// Token: 0x06001A03 RID: 6659 RVA: 0x000BB76C File Offset: 0x000B996C
		private void #6S(bool #ag)
		{
			if (base.Editor.CoreRendererModel.UseGlobalSettings)
			{
				base.Editor.ViewHomeOverride = new Action(this.#fci);
				base.Editor.ZoomToWorkspaceOverride = new Action(this.#gci);
			}
			else
			{
				base.Editor.ViewHomeOverride = new Action(this.#hci);
				base.Editor.ZoomToWorkspaceOverride = new Action(this.#ici);
			}
			ColumnStorageModel columnStorageModel = base.ProjectContext.Model.#CY();
			#qW #qW = this.#q;
			#4Ve #4Ve = (#qW != null) ? #qW.CurrentTraceStep : null;
			ModelRenderer.#b1b #b1b = (base.ProjectContext.Model.Options.ProblemType == ProblemType.Design && #4Ve != null && this.#q.DesignEngine != null) ? this.#iT(columnStorageModel, this.#q) : this.#jT(columnStorageModel);
			this.#s = #b1b;
			if (#b1b != null)
			{
				this.#bT(columnStorageModel, #b1b);
				bool flag = base.ProjectContext.Model.Options.SectionType == SectionType.Irregular;
				if (flag || #b1b.Polygons.Any<SectionPolygon>())
				{
					this.#cT(columnStorageModel, #b1b);
					if (!flag && !#ag)
					{
						this.#dT(#b1b);
					}
					this.#eci();
					this.#8S(#b1b);
				}
				else
				{
					this.#8S(null);
				}
				this.#aT();
			}
		}

		// Token: 0x06001A04 RID: 6660 RVA: 0x000BB8E4 File Offset: 0x000B9AE4
		private void #7S()
		{
			base.Editor.Entities.UpdateBoundingBox();
			base.Editor.UpdateBoundingBox();
			base.Editor.ZoomFitExt(false);
			base.Editor.Invalidate();
			BoundingBoxData boundingBoxData = new BoundingBoxData(base.Editor.Entities.BoxMin.#QW(), base.Editor.Entities.BoxMax.#QW());
			double? distanceInModelCoordinates = base.Editor.GetDistanceInModelCoordinates((double)(base.Editor.ZoomFitMarginAddition + base.Editor.Zoom.FitMargin));
			if (distanceInModelCoordinates != null)
			{
				boundingBoxData.#Fvc(distanceInModelCoordinates.Value, distanceInModelCoordinates.Value, distanceInModelCoordinates.Value, distanceInModelCoordinates.Value);
			}
			bool flag = base.Editor.CoreRendererModel.Labels.Any(new Func<BillboardLabel, bool>(ModelRenderer.<>c.<>9.#jci));
			bool flag2 = base.Editor.CoreRendererModel.Labels.Any(new Func<BillboardLabel, bool>(ModelRenderer.<>c.<>9.#kci));
			if (flag || flag2)
			{
				distanceInModelCoordinates = base.Editor.GetDistanceInModelCoordinates(90.0);
				if (distanceInModelCoordinates != null)
				{
					boundingBoxData.#Fvc(flag ? distanceInModelCoordinates.Value : 0.0, flag2 ? distanceInModelCoordinates.Value : 0.0, 0.0, 0.0);
				}
			}
			devDept.Eyeshot.Entities.Region region = devDept.Eyeshot.Entities.Region.CreateRectangle(boundingBoxData.BottomLeft.X, boundingBoxData.BottomLeft.Y, boundingBoxData.TopRight.X - boundingBoxData.BottomLeft.X, boundingBoxData.TopRight.Y - boundingBoxData.BottomLeft.Y, 0.0, false);
			region.Visible = true;
			region.LayerName = #ER.#c;
			region.RegenMode = regenType.RegenAndCompile;
			region.Regen(null);
			base.Editor.ZoomFit(new List<Entity>
			{
				region
			}, false);
		}

		// Token: 0x06001A05 RID: 6661 RVA: 0x00019D7D File Offset: 0x00017F7D
		private void #8S(ModelRenderer.#b1b #9S)
		{
			base.Editor.CoreRendererModel.SelectionDimensions.ModelBoundingBox = base.EditorContext.Selection.#5Ob();
		}

		// Token: 0x06001A06 RID: 6662 RVA: 0x00019DB0 File Offset: 0x00017FB0
		private void #aT()
		{
			base.Editor.AddFakeEntityIfEmpty();
		}

		// Token: 0x06001A07 RID: 6663 RVA: 0x000BBB40 File Offset: 0x000B9D40
		private void #bT(ColumnStorageModel #X, ModelRenderer.#b1b #9S)
		{
			List<devDept.Geometry.Point3D> item;
			List<SectionPolygon> source;
			this.#BT(#X, #9S, out item, out source);
			#9S.CoverPoints = new List<List<devDept.Geometry.Point3D>>
			{
				item
			};
			#9S.Polygons = source;
			this.#CT(#9S);
			List<#fS> collection = this.#wT(#X, #9S.Polygons);
			base.Editor.CoreRendererModel.Centroids.AddRange(collection);
			if (source.Any<SectionPolygon>())
			{
				List<StructurePoint.CoreAssets.Infrastructure.Data.Point> list = source.SelectMany(new Func<SectionPolygon, IEnumerable<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point>>(ModelRenderer.<>c.<>9.#lci)).Select(new Func<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point, StructurePoint.CoreAssets.Infrastructure.Data.Point>(ModelRenderer.<>c.<>9.#mci)).ToList<StructurePoint.CoreAssets.Infrastructure.Data.Point>();
				#9S.BoundingBox = new BoundingBoxData(list);
				list.AddRange(#9S.Bars.Select(new Func<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar, StructurePoint.CoreAssets.Infrastructure.Data.Point>(ModelRenderer.<>c.<>9.#nci)));
				#9S.BoundingBoxWithBars = new BoundingBoxData(list);
			}
		}

		// Token: 0x06001A08 RID: 6664 RVA: 0x000BBC60 File Offset: 0x000B9E60
		private void #cT(ColumnStorageModel #X, ModelRenderer.#b1b #9S)
		{
			this.#tT(#X, #9S);
			try
			{
				base.#8Uh();
				this.#MS(#9S, false);
				this.#MS(#9S, true);
			}
			finally
			{
				base.#9Uh();
			}
			this.#WS(#X, #9S, #9S.Polygons.Count);
			if (#9S.Polygons.Any<SectionPolygon>())
			{
				this.#ET(#X, #9S);
			}
			if (this.SectionColors.SectionAnnotationsVisibility)
			{
				this.#wS(#X, #9S);
			}
		}

		// Token: 0x06001A09 RID: 6665 RVA: 0x000BBCF0 File Offset: 0x000B9EF0
		private void #dT(ModelRenderer.#b1b #xS)
		{
			base.Editor.ZoomFitExt(false);
			base.Editor.AdjustNearAndFarPlanes();
			base.Editor.Invalidate();
			double num = this.#gT();
			if (num <= 0.0)
			{
				return;
			}
			double? num2 = this.#hT(#xS);
			if (num2 == null)
			{
				if (!#xS.Bars.Any<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar>() && !#xS.Polygons.Any<SectionPolygon>())
				{
					base.Editor.ResetCameraParameters((#xS.Model.Options.Unit == UnitSystem.USCustomary) ? LengthUnit.Inch : LengthUnit.Millimeter);
					base.Editor.Invalidate();
				}
				return;
			}
			double num3 = this.#eT(num2.Value);
			double distance = base.Editor.Camera.Distance * num / num3;
			base.Editor.Camera.Distance = distance;
			base.Editor.AdjustNearAndFarPlanes();
			base.Editor.Invalidate();
		}

		// Token: 0x06001A0A RID: 6666 RVA: 0x00019DC9 File Offset: 0x00017FC9
		private double #eT(double #fT)
		{
			if (#fT <= 40.0)
			{
				return 0.4;
			}
			if (#fT <= 80.0)
			{
				return 0.6;
			}
			return 0.8;
		}

		// Token: 0x06001A0B RID: 6667 RVA: 0x000BBDF4 File Offset: 0x000B9FF4
		private double #gT()
		{
			base.Editor.Entities.UpdateBoundingBox();
			devDept.Geometry.Point3D point3D = base.Editor.WorldToScreen(base.Editor.Entities.BoxMin);
			devDept.Geometry.Point3D point3D2 = base.Editor.WorldToScreen(base.Editor.Entities.BoxMax);
			double actualHeight = base.Editor.ActualHeight;
			double num = point3D2.Y - point3D.Y;
			double actualWidth = base.Editor.ActualWidth;
			double num2 = point3D2.X - point3D.X;
			return Math.Max(num / actualHeight, num2 / actualWidth);
		}

		// Token: 0x06001A0C RID: 6668 RVA: 0x000BBEAC File Offset: 0x000BA0AC
		private double? #hT(ModelRenderer.#b1b #xS)
		{
			if (#xS == null)
			{
				return null;
			}
			int count = #xS.Bars.Count;
			List<StructurePoint.CoreAssets.Infrastructure.Data.Point> list = #xS.Polygons.SelectMany(new Func<SectionPolygon, IEnumerable<StructurePoint.CoreAssets.Infrastructure.Data.Point>>(ModelRenderer.<>c.<>9.#oci)).ToList<StructurePoint.CoreAssets.Infrastructure.Data.Point>();
			list.AddRange(#xS.Bars.Select(new Func<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar, StructurePoint.CoreAssets.Infrastructure.Data.Point>(ModelRenderer.<>c.<>9.#qci)));
			if (list.Any<StructurePoint.CoreAssets.Infrastructure.Data.Point>())
			{
				BoundingBoxData boundingBoxData = new BoundingBoxData(list);
				return new double?((double)count * 1.0 * (2.0 - Math.Min(boundingBoxData.Width, boundingBoxData.Height) / Math.Max(boundingBoxData.Width, boundingBoxData.Height)));
			}
			return null;
		}

		// Token: 0x06001A0D RID: 6669 RVA: 0x000BBFA8 File Offset: 0x000BA1A8
		private ModelRenderer.#b1b #iT(ColumnStorageModel #X, #qW #rj)
		{
			#4Ve #4Ve = #rj.CurrentTraceStep;
			ModelRenderer.#b1b #b1b = new ModelRenderer.#b1b();
			#b1b.DimensionA = #4Ve.DimensionA;
			#b1b.DimensionB = #4Ve.DimensionB;
			#b1b.IsDesignResult = true;
			#b1b.Reinforcement = #4Ve.Reinforcement;
			#b1b.Bars = #4Ve.Bars;
			#b1b.Model = #X;
			bool flag3;
			if (#rj.CurrentTraceStepIndex == #rj.TraceResults.Count - 1)
			{
				bool? flag;
				if (#rj == null)
				{
					flag = null;
				}
				else
				{
					DesignEngine designEngine = #rj.DesignEngine;
					if (designEngine == null)
					{
						flag = null;
					}
					else
					{
						#l4e #l4e = designEngine.OutputModel;
						flag = ((#l4e != null) ? new bool?(#l4e.SolveCompleted) : null);
					}
				}
				bool? flag2 = flag;
				flag3 = flag2.GetValueOrDefault();
			}
			else
			{
				flag3 = false;
			}
			#b1b.DesignWasSuccessful = flag3;
			return #b1b;
		}

		// Token: 0x06001A0E RID: 6670 RVA: 0x000BC084 File Offset: 0x000BA284
		private ModelRenderer.#b1b #jT(ColumnStorageModel #Od)
		{
			#qW #qW = this.#q;
			DesignEngine designEngine = (#qW != null) ? #qW.DesignEngine : null;
			bool flag = designEngine != null && this.#q.TraceResults.Any<#4Ve>();
			bool flag4;
			if (designEngine != null && this.#q.CurrentTraceStepIndex == this.#q.TraceResults.Count - 1)
			{
				bool? flag2;
				if (designEngine == null)
				{
					flag2 = null;
				}
				else
				{
					#l4e #l4e = designEngine.OutputModel;
					flag2 = ((#l4e != null) ? new bool?(#l4e.SolveCompleted) : null);
				}
				bool? flag3 = flag2;
				flag4 = flag3.GetValueOrDefault();
			}
			else
			{
				flag4 = false;
			}
			bool flag5 = flag4;
			bool flag6;
			if (designEngine != null)
			{
				#l4e #l4e2 = designEngine.OutputModel;
				flag6 = ((#l4e2 == null || !#l4e2.SolveCompleted) && !this.#q.TraceResults.Any<#4Ve>());
			}
			else
			{
				flag6 = true;
			}
			bool flag7 = flag6;
			if (flag7 && (#Od.Options.SectionType == SectionType.Circle || #Od.Options.SectionType == SectionType.Rectangle))
			{
				try
				{
					designEngine = new DesignEngine(#Od, new #O6e(base.Settings.DiagramInterpolationConvergenceEpsilonPercentage));
					designEngine.#tOe();
				}
				catch (Exception)
				{
					return null;
				}
			}
			if (((designEngine != null) ? designEngine.OutputModel : null) != null)
			{
				return new ModelRenderer.#b1b
				{
					DimensionA = designEngine.OutputModel.InvestigationDimensions[0],
					DimensionB = designEngine.OutputModel.InvestigationDimensions[1],
					Bars = designEngine.OutputModel.ReinforcementBars.ToList<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar>(),
					IsDesignResult = flag,
					DesignWasSuccessful = flag5,
					Reinforcement = #c6e.#Dge(designEngine.OutputModel.InvestigationReinforcement),
					Model = #Od
				};
			}
			ModelRenderer.#b1b #b1b = new ModelRenderer.#b1b();
			#b1b.DimensionA = 0f;
			#b1b.DimensionB = 0f;
			#b1b.Bars = #Od.ReinforcementBars.Select(new Func<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.ReinforcementBar, StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar>(ModelRenderer.<>c.<>9.#rci)).ToList<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar>();
			#b1b.IsDesignResult = false;
			#b1b.Reinforcement = new #c6e();
			#b1b.Model = #Od;
			#b1b.DesignWasSuccessful = false;
			return #b1b;
		}

		// Token: 0x06001A0F RID: 6671 RVA: 0x000BC2B0 File Offset: 0x000BA4B0
		private void #eb(bool #kT = true)
		{
			if (!base.#xR(#ER.#a))
			{
				base.#zR(#ER.#a);
			}
			if (!base.#xR(#ER.#c))
			{
				base.#zR(#ER.#c);
			}
			if (!base.#xR(#ER.#b))
			{
				base.#zR(#ER.#b);
			}
			if (!base.#xR(#ER.#e))
			{
				base.#zR(#ER.#e);
			}
			if (!base.#xR(#ER.#d))
			{
				base.#zR(#ER.#d);
			}
			this.SectionColors = base.Settings.#ZN();
			this.TextSize = this.#lT(this.SectionColors.LabelSize);
			if (#kT)
			{
				base.Editor.CoreRendererModel.#yl();
			}
			this.#u = Color.FromArgb((int)this.SectionColors.SolidColor.A, #KT.#2);
			this.#v = Color.FromArgb((int)this.SectionColors.OpeningColor.A, #KT.#3);
			if (base.Editor.CoreRendererModel.UseGlobalSettings)
			{
				base.Editor.CoreRendererModel.ShowCoordinateSign = base.Settings.ShowCoordinateSystemSign;
				base.Editor.CoreRendererModel.ShowCentroid = base.Settings.ObjectCentroid;
				base.Editor.CoreRendererModel.ShowDimensions = this.SectionColors.SectionAnnotationsVisibility;
				base.Editor.CoreRendererModel.ShowAnnotations = this.SectionColors.SectionAnnotationsVisibility;
			}
			base.#CR(#Phc.#3hc(107400569), this.SectionColors.SolidColor.Convert());
			base.#CR(#Phc.#3hc(107400594), this.SectionColors.OpeningColor.Convert());
			base.#CR(#Phc.#3hc(107400535), this.SectionColors.BarPointColor.Convert());
			base.#CR(#Phc.#3hc(107401083), this.SectionColors.BarAreaColor.Convert());
			base.#CR(#Phc.#3hc(107400510), this.SectionColors.BarLrPointColor.Convert());
			base.#CR(#Phc.#3hc(107401030), this.SectionColors.BarLrAreaColor.Convert());
			base.#CR(#Phc.#3hc(107401005), #KT.#e);
			base.#CR(#Phc.#3hc(107400591), this.#u);
			base.#CR(#Phc.#3hc(107400656), this.#v);
			base.#CR(#Phc.#3hc(107401008), Color.FromArgb(255, 155, 0, 0));
			base.#CR(#Phc.#3hc(107400453), Color.FromArgb(255, 255, 0, 0));
		}

		// Token: 0x06001A10 RID: 6672 RVA: 0x000BC5A8 File Offset: 0x000BA7A8
		private double #lT(int #mT)
		{
			double #c = (double)#mT / 10.0 * 0.4;
			ColumnUnit<LengthUnit> columnUnit = base.Model.Units.Section.Width;
			LengthConverter lengthConverter = new LengthConverter();
			return lengthConverter.#Pb(LengthUnit.Inch, columnUnit.UnitType, #c);
		}

		// Token: 0x06001A11 RID: 6673 RVA: 0x000BC604 File Offset: 0x000BA804
		private void #nT(string #oT, devDept.Geometry.Point3D #pT, devDept.Geometry.Point3D #qT, ContentAlignment #rT, bool #sT)
		{
			BillboardLabel item = new BillboardLabel
			{
				Label = #oT,
				PointPosition = #pT,
				BoundingBoxIntersection = #qT,
				Alignment = #rT,
				Color = this.SectionColors.TextColor.Convert(),
				TextSize = (float)this.SectionColors.LabelSize,
				IsLeft = #sT
			};
			base.Editor.CoreRendererModel.Labels.Add(item);
		}

		// Token: 0x06001A12 RID: 6674 RVA: 0x000BC688 File Offset: 0x000BA888
		private void #tT(ColumnStorageModel #X, ModelRenderer.#b1b #9S)
		{
			int count = #9S.Polygons.Count;
			bool flag = this.#zT(#9S.CoverPoints);
			List<Entity> list = new List<Entity>();
			List<ShapeModel> source = base.ProjectContext.Model.Shapes.OrderByDescending(new Func<ShapeModel, bool>(ModelRenderer.<>c.<>9.#sci)).ThenBy(new Func<ShapeModel, int>(ModelRenderer.<>c.<>9.#tci)).ToList<ShapeModel>();
			List<SectionPolygon> list2 = #9S.Polygons.OrderByDescending(new Func<SectionPolygon, bool>(ModelRenderer.<>c.<>9.#uci)).ThenBy(new Func<SectionPolygon, int>(ModelRenderer.<>c.<>9.#vci)).ToList<SectionPolygon>();
			for (int i = 0; i < list2.Count; i++)
			{
				ModelRenderer.#9vg #9vg = new ModelRenderer.#9vg();
				SectionPolygon sectionPolygon = list2[i];
				#9vg.#a = (double)i * #KT.#a;
				List<devDept.Geometry.Point3D> list3 = sectionPolygon.Points.Select(new Func<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point, devDept.Geometry.Point3D>(#9vg.#e2b)).ToList<devDept.Geometry.Point3D>();
				if (list3.Count > 1 && list3[0].DistanceTo(list3.Last<devDept.Geometry.Point3D>()) <= 0.001)
				{
					list3.RemoveAt(list3.Count - 1);
				}
				GenericMesher genericMesher = new GenericMesher();
				Vertex[] array = list3.Select(new Func<devDept.Geometry.Point3D, Vertex>(ModelRenderer.<>c.<>9.#wci)).ToArray<Vertex>();
				devDept.Geometry.Point3D[] vertices = array.Select(new Func<Vertex, devDept.Geometry.Point3D>(#9vg.#f2b)).ToArray<devDept.Geometry.Point3D>();
				Polygon polygon = new Polygon();
				polygon.Add(new Contour(array), false);
				IMesh mesh = genericMesher.Triangulate(polygon, new ConstraintOptions
				{
					ConformingDelaunay = false
				});
				List<IndexTriangle> triangles = mesh.Triangles.Select(new Func<TriangleNet.Topology.Triangle, IndexTriangle>(ModelRenderer.<>c.<>9.#xci)).ToList<IndexTriangle>();
				list.Add(new CustomMeshEntity(vertices, triangles)
				{
					VisualOrder = #9vg.#a,
					MaterialName = ((sectionPolygon.Application == PolygonApplication.Solid) ? #Phc.#3hc(107400569) : #Phc.#3hc(107400594)),
					ColorMethod = colorMethodType.byEntity,
					EntityData = source.ElementAtOrDefault(i)
				});
			}
			base.#pR<Entity>(list, #ER.#c);
			if (flag)
			{
				this.#uT(#9S, count);
			}
		}

		// Token: 0x06001A13 RID: 6675 RVA: 0x000BC940 File Offset: 0x000BAB40
		private void #uT(ModelRenderer.#b1b #9S, int #vT)
		{
			ModelRenderer.#Vzf #Vzf = new ModelRenderer.#Vzf();
			List<Entity> list = new List<Entity>();
			#Vzf.#a = (double)#vT * #KT.#a + #KT.#b + #KT.#c;
			Color color = this.SectionColors.CoverLineColor.ToDrawingColor();
			ushort stipple = (this.SectionColors.CoverLineType == StructurePoint.CoreAssets.AppManager.Column.Core.LineType.Solid) ? 0 : 3855;
			foreach (List<devDept.Geometry.Point3D> list2 in #9S.CoverPoints)
			{
				List<devDept.Geometry.Point3D> list3 = list2;
				Action<devDept.Geometry.Point3D> action;
				if ((action = #Vzf.#b) == null)
				{
					action = (#Vzf.#b = new Action<devDept.Geometry.Point3D>(#Vzf.#h2b));
				}
				list3.ForEach(action);
				list.Add(new CustomLinearPath(list2.ToArray())
				{
					ColorMethod = colorMethodType.byEntity,
					Color = color,
					LineWeight = 1f,
					LineWeightMethod = colorMethodType.byEntity,
					Stipple = stipple
				});
			}
			base.#pR<Entity>(list, #ER.#d);
		}

		// Token: 0x06001A14 RID: 6676 RVA: 0x000BCA74 File Offset: 0x000BAC74
		private List<#fS> #wT(ColumnStorageModel #Od, List<SectionPolygon> #yP)
		{
			List<#fS> list = new List<#fS>();
			this.#xT(#yP, list);
			try
			{
				#fS #fS = null;
				if (base.ProjectContext.Metadata.SectionCentroid != null)
				{
					#fS = new #fS(base.ProjectContext.Metadata.SectionCentroid, #8R.#b);
				}
				if (#fS != null)
				{
					list.Add(#fS);
				}
			}
			catch (Exception)
			{
			}
			return list;
		}

		// Token: 0x06001A15 RID: 6677 RVA: 0x000BCAEC File Offset: 0x000BACEC
		private void #xT(List<SectionPolygon> #yP, List<#fS> #yT)
		{
			if (base.ProjectContext.Model.Options.SectionType == SectionType.Irregular)
			{
				using (IEnumerator<ShapeModel> enumerator = base.ProjectContext.Model.Shapes.Where(new Func<ShapeModel, bool>(ModelRenderer.<>c.<>9.#yci)).GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ShapeModel shapeModel = enumerator.Current;
						StructurePoint.CoreAssets.Infrastructure.Data.Point? point = shapeModel.#gxc();
						if (point != null)
						{
							#yT.Add(new #fS(shapeModel, new devDept.Geometry.Point3D(point.Value.X, point.Value.Y)));
						}
					}
					return;
				}
			}
			foreach (SectionPolygon sectionPolygon in #yP)
			{
				List<StructurePoint.CoreAssets.Infrastructure.Data.Point> points = sectionPolygon.Points.Select(new Func<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point, StructurePoint.CoreAssets.Infrastructure.Data.Point>(ModelRenderer.<>c.<>9.#zci)).ToList<StructurePoint.CoreAssets.Infrastructure.Data.Point>();
				BoundingBoxData boundingBoxData = new BoundingBoxData(points);
				StructurePoint.CoreAssets.Infrastructure.Data.Point3D point3D = boundingBoxData.#Kvc();
				devDept.Geometry.Point3D #Ng = new devDept.Geometry.Point3D(point3D.X, point3D.Y);
				#yT.Add(new #fS(null, #Ng));
			}
		}

		// Token: 0x06001A16 RID: 6678 RVA: 0x000BCC7C File Offset: 0x000BAE7C
		private bool #zT(List<List<devDept.Geometry.Point3D>> #AT)
		{
			if (!base.Editor.CoreRendererModel.UseGlobalSettings)
			{
				return base.Editor.CoreRendererModel.ShowCover;
			}
			if (base.Settings.CurrentColorSettings.CoverVisibility && #AT != null)
			{
				return #AT.Any(new Func<List<devDept.Geometry.Point3D>, bool>(ModelRenderer.<>c.<>9.#Aci));
			}
			return false;
		}

		// Token: 0x06001A17 RID: 6679 RVA: 0x00019E08 File Offset: 0x00018008
		private void #BT(ColumnStorageModel #X, ModelRenderer.#b1b #xS, out List<devDept.Geometry.Point3D> #AT, out List<SectionPolygon> #yP)
		{
			SectionGeometryHelper.#BT(#X, #xS.DimensionA, #xS.DimensionB, out #AT, out #yP, false);
		}

		// Token: 0x06001A18 RID: 6680 RVA: 0x000BCCF4 File Offset: 0x000BAEF4
		private void #CT(ModelRenderer.#b1b #9S)
		{
			if (base.ProjectContext.Model.Options.SectionType != SectionType.Irregular)
			{
				return;
			}
			#9S.CoverPoints = new List<List<devDept.Geometry.Point3D>>();
			double #sP = base.Settings.RuntimeSettings.Cover;
			for (int i = 0; i < base.ProjectContext.Model.Shapes.Count; i++)
			{
				ShapeModel #rP = base.ProjectContext.Model.Shapes[i];
				try
				{
					List<devDept.Geometry.Point3D> list = SnappingCache.#qP(#rP, #sP);
					if (list != null && list.Count > 1)
					{
						#9S.CoverPoints.Add(list);
					}
				}
				catch (Exception exception)
				{
					ModelRenderer.#Rbc #Rbc = new ModelRenderer.#Rbc();
					#Rbc.#a = i;
					base.EditorContext.Logger.Log(LoggingLevel.Warning, new Func<string>(#Rbc.#j2b), exception);
				}
			}
		}

		// Token: 0x06001A19 RID: 6681 RVA: 0x000BCDF4 File Offset: 0x000BAFF4
		private void #DT()
		{
			BoundingBoxData boundingBoxData = base.Editor.CoreRendererModel.SelectionDimensions.ModelBoundingBox;
			if (boundingBoxData == null)
			{
				return;
			}
			#7R #7R = base.Editor.CoreRendererModel.SelectionDimensions;
			#7R.ModelBoundingBox = boundingBoxData;
			#7R.TextSize = this.SectionColors.LabelSize;
			#7R.DimensionsColor = Color.FromArgb(255, 255, 74, 255);
			#7R.TextColor = Color.FromArgb(255, 255, 74, 255);
			double num = boundingBoxData.Width;
			if (num > 0.0)
			{
				#7R.HorizontalLabel = this.#FT(num, null);
			}
			num = boundingBoxData.Height;
			if (num > 0.0)
			{
				#7R.VerticalLabel = this.#FT(num, null);
			}
		}

		// Token: 0x06001A1A RID: 6682 RVA: 0x000BCEEC File Offset: 0x000BB0EC
		private void #ET(ColumnStorageModel #X, ModelRenderer.#b1b #xS)
		{
			BoundingBoxData boundingBoxData = #xS.BoundingBox;
			#7R #7R = base.Editor.CoreRendererModel.Dimensions;
			#7R.ModelBoundingBox = boundingBoxData;
			#7R.TextSize = this.SectionColors.LabelSize;
			#7R.DimensionsColor = this.SectionColors.DimensionsColor.ToDrawingColor();
			#7R.TextColor = this.SectionColors.TextColor.ToDrawingColor();
			double #GT = boundingBoxData.Width;
			double value = (double)base.Model.DesignDimensions.MaxWidth;
			string text = this.#FT(#GT, #xS.IsDesignResult ? null : new double?(value));
			#7R.HorizontalLabel = text;
			if (#X.Options.SectionType != SectionType.Circle)
			{
				#GT = boundingBoxData.Height;
				value = (double)base.Model.DesignDimensions.MaxHeight;
				text = this.#FT(#GT, #xS.IsDesignResult ? null : new double?(value));
				#7R.VerticalLabel = text;
			}
		}

		// Token: 0x06001A1B RID: 6683 RVA: 0x000BD00C File Offset: 0x000BB20C
		private string #FT(double #GT, double? #HT)
		{
			#zae #zae = new #zae(2, null);
			string text = base.Model.Units.Section.Width.Symbol;
			bool flag = base.Model.Options.ProblemType == ProblemType.Design;
			string text2 = #zae.CreateDisplayValue(#GT);
			if (flag && #HT != null)
			{
				string text3 = #zae.CreateDisplayValue(#HT.Value);
				return string.Concat(new string[]
				{
					#Phc.#3hc(107413142),
					text2,
					#Phc.#3hc(107399904),
					text3,
					#Phc.#3hc(107399927),
					text
				});
			}
			return text2 + #Phc.#3hc(107399922) + text;
		}

		// Token: 0x06001A1D RID: 6685 RVA: 0x00019E50 File Offset: 0x00018050
		[CompilerGenerated]
		private void #fci()
		{
			if (!this.#cVh())
			{
				this.#dT(this.#s);
			}
		}

		// Token: 0x06001A1E RID: 6686 RVA: 0x00019E72 File Offset: 0x00018072
		[CompilerGenerated]
		private void #gci()
		{
			if (!this.#cVh())
			{
				this.#7S();
			}
		}

		// Token: 0x06001A1F RID: 6687 RVA: 0x00019E8E File Offset: 0x0001808E
		[CompilerGenerated]
		private void #hci()
		{
			if (!this.#cVh())
			{
				this.#bg();
			}
		}

		// Token: 0x06001A20 RID: 6688 RVA: 0x00019E8E File Offset: 0x0001808E
		[CompilerGenerated]
		private void #ici()
		{
			if (!this.#cVh())
			{
				this.#bg();
			}
		}

		// Token: 0x040009EA RID: 2538
		private new int #a;

		// Token: 0x040009EB RID: 2539
		private new readonly List<ModelRenderer.ReinforcementBlockMetadata> #b = new List<ModelRenderer.ReinforcementBlockMetadata>();

		// Token: 0x040009EC RID: 2540
		private new HashSet<devDept.Geometry.Point3D> #c = new HashSet<devDept.Geometry.Point3D>();

		// Token: 0x040009ED RID: 2541
		private new static readonly Color #d = Color.FromArgb(255, 171, 206, 130);

		// Token: 0x040009EE RID: 2542
		private new const string #e = "SolidsMaterial";

		// Token: 0x040009EF RID: 2543
		private const string #f = "OpeningsMaterial";

		// Token: 0x040009F0 RID: 2544
		private const string #g = "BarPointMaterial";

		// Token: 0x040009F1 RID: 2545
		private const string #h = "BarAreaMaterial";

		// Token: 0x040009F2 RID: 2546
		private const string #i = "BarLrPointMaterial";

		// Token: 0x040009F3 RID: 2547
		private const string #j = "BarLrAreaMaterial";

		// Token: 0x040009F4 RID: 2548
		private const string #k = "SelectedBarMaterial";

		// Token: 0x040009F5 RID: 2549
		private const string #l = "SelectedSlabsMaterial";

		// Token: 0x040009F6 RID: 2550
		private const string #m = "SelectedOpeningMaterial";

		// Token: 0x040009F7 RID: 2551
		private const string #n = "OverlappingBarMaterial";

		// Token: 0x040009F8 RID: 2552
		private const string #o = "OverlappingBarPointMaterial";

		// Token: 0x040009F9 RID: 2553
		private readonly NonBlockingLock #p = new NonBlockingLock();

		// Token: 0x040009FA RID: 2554
		private readonly #qW #q;

		// Token: 0x040009FB RID: 2555
		private readonly IModelEditorViewport #r;

		// Token: 0x040009FC RID: 2556
		private ModelRenderer.#b1b #s;

		// Token: 0x040009FD RID: 2557
		private readonly int #t = 3;

		// Token: 0x040009FE RID: 2558
		private Color #u;

		// Token: 0x040009FF RID: 2559
		private Color #v;

		// Token: 0x04000A00 RID: 2560
		[CompilerGenerated]
		private #qRb #w;

		// Token: 0x04000A01 RID: 2561
		[CompilerGenerated]
		private double #x;

		// Token: 0x020002EE RID: 750
		private sealed class #I0b
		{
			// Token: 0x17000999 RID: 2457
			// (get) Token: 0x06001A21 RID: 6689 RVA: 0x00019EAA File Offset: 0x000180AA
			// (set) Token: 0x06001A22 RID: 6690 RVA: 0x00019EB6 File Offset: 0x000180B6
			public devDept.Geometry.Point3D Location { get; set; }

			// Token: 0x1700099A RID: 2458
			// (get) Token: 0x06001A23 RID: 6691 RVA: 0x00019EC7 File Offset: 0x000180C7
			// (set) Token: 0x06001A24 RID: 6692 RVA: 0x00019ED3 File Offset: 0x000180D3
			public int MinCount { get; set; }

			// Token: 0x1700099B RID: 2459
			// (get) Token: 0x06001A25 RID: 6693 RVA: 0x00019EE4 File Offset: 0x000180E4
			// (set) Token: 0x06001A26 RID: 6694 RVA: 0x00019EF0 File Offset: 0x000180F0
			public int MinSize { get; set; }

			// Token: 0x1700099C RID: 2460
			// (get) Token: 0x06001A27 RID: 6695 RVA: 0x00019F01 File Offset: 0x00018101
			// (set) Token: 0x06001A28 RID: 6696 RVA: 0x00019F0D File Offset: 0x0001810D
			public int? MaxCount { get; set; }

			// Token: 0x1700099D RID: 2461
			// (get) Token: 0x06001A29 RID: 6697 RVA: 0x00019F1E File Offset: 0x0001811E
			// (set) Token: 0x06001A2A RID: 6698 RVA: 0x00019F2A File Offset: 0x0001812A
			public int? MaxSize { get; set; }

			// Token: 0x1700099E RID: 2462
			// (get) Token: 0x06001A2B RID: 6699 RVA: 0x00019F3B File Offset: 0x0001813B
			// (set) Token: 0x06001A2C RID: 6700 RVA: 0x00019F47 File Offset: 0x00018147
			public bool IsRightSide { get; set; }

			// Token: 0x04000A02 RID: 2562
			[CompilerGenerated]
			private devDept.Geometry.Point3D #a;

			// Token: 0x04000A03 RID: 2563
			[CompilerGenerated]
			private int #b;

			// Token: 0x04000A04 RID: 2564
			[CompilerGenerated]
			private int #c;

			// Token: 0x04000A05 RID: 2565
			[CompilerGenerated]
			private int? #d;

			// Token: 0x04000A06 RID: 2566
			[CompilerGenerated]
			private int? #e;

			// Token: 0x04000A07 RID: 2567
			[CompilerGenerated]
			private bool #f;
		}

		// Token: 0x020002EF RID: 751
		private sealed class ReinforcementBlockMetadata
		{
			// Token: 0x1700099F RID: 2463
			// (get) Token: 0x06001A2E RID: 6702 RVA: 0x00019F58 File Offset: 0x00018158
			// (set) Token: 0x06001A2F RID: 6703 RVA: 0x00019F64 File Offset: 0x00018164
			public Block Block { get; set; }

			// Token: 0x170009A0 RID: 2464
			// (get) Token: 0x06001A30 RID: 6704 RVA: 0x00019F75 File Offset: 0x00018175
			// (set) Token: 0x06001A31 RID: 6705 RVA: 0x00019F81 File Offset: 0x00018181
			public double Radius { get; set; }

			// Token: 0x170009A1 RID: 2465
			// (get) Token: 0x06001A32 RID: 6706 RVA: 0x00019F92 File Offset: 0x00018192
			// (set) Token: 0x06001A33 RID: 6707 RVA: 0x00019F9E File Offset: 0x0001819E
			public bool IsLeftRight { get; set; }

			// Token: 0x170009A2 RID: 2466
			// (get) Token: 0x06001A34 RID: 6708 RVA: 0x00019FAF File Offset: 0x000181AF
			// (set) Token: 0x06001A35 RID: 6709 RVA: 0x00019FBB File Offset: 0x000181BB
			public bool IsSelection { get; set; }

			// Token: 0x170009A3 RID: 2467
			// (get) Token: 0x06001A36 RID: 6710 RVA: 0x00019FCC File Offset: 0x000181CC
			// (set) Token: 0x06001A37 RID: 6711 RVA: 0x00019FD8 File Offset: 0x000181D8
			public bool IsOverlapped { get; set; }

			// Token: 0x170009A4 RID: 2468
			// (get) Token: 0x06001A38 RID: 6712 RVA: 0x00019FE9 File Offset: 0x000181E9
			// (set) Token: 0x06001A39 RID: 6713 RVA: 0x00019FF5 File Offset: 0x000181F5
			public bool IsFinal { get; set; }

			// Token: 0x170009A5 RID: 2469
			// (get) Token: 0x06001A3A RID: 6714 RVA: 0x0001A006 File Offset: 0x00018206
			// (set) Token: 0x06001A3B RID: 6715 RVA: 0x0001A012 File Offset: 0x00018212
			public string MaterialName { get; set; }

			// Token: 0x04000A08 RID: 2568
			[CompilerGenerated]
			private Block #a;

			// Token: 0x04000A09 RID: 2569
			[CompilerGenerated]
			private double #b;

			// Token: 0x04000A0A RID: 2570
			[CompilerGenerated]
			private bool #c;

			// Token: 0x04000A0B RID: 2571
			[CompilerGenerated]
			private bool #d;

			// Token: 0x04000A0C RID: 2572
			[CompilerGenerated]
			private bool #e;

			// Token: 0x04000A0D RID: 2573
			[CompilerGenerated]
			private bool #f;

			// Token: 0x04000A0E RID: 2574
			[CompilerGenerated]
			private string #g;
		}

		// Token: 0x020002F0 RID: 752
		private struct BarDistanceMetadata
		{
			// Token: 0x170009A6 RID: 2470
			// (get) Token: 0x06001A3D RID: 6717 RVA: 0x0001A023 File Offset: 0x00018223
			// (set) Token: 0x06001A3E RID: 6718 RVA: 0x0001A02F File Offset: 0x0001822F
			public devDept.Geometry.Point3D Location { readonly get; set; }

			// Token: 0x170009A7 RID: 2471
			// (get) Token: 0x06001A3F RID: 6719 RVA: 0x0001A040 File Offset: 0x00018240
			// (set) Token: 0x06001A40 RID: 6720 RVA: 0x0001A04C File Offset: 0x0001824C
			public double Radius { readonly get; set; }

			// Token: 0x170009A8 RID: 2472
			// (get) Token: 0x06001A41 RID: 6721 RVA: 0x0001A05D File Offset: 0x0001825D
			// (set) Token: 0x06001A42 RID: 6722 RVA: 0x0001A069 File Offset: 0x00018269
			public EyeshotBoundingBoxDataLight Box { readonly get; set; }

			// Token: 0x170009A9 RID: 2473
			// (get) Token: 0x06001A43 RID: 6723 RVA: 0x0001A07A File Offset: 0x0001827A
			// (set) Token: 0x06001A44 RID: 6724 RVA: 0x0001A086 File Offset: 0x00018286
			public bool IsOverlapped { readonly get; set; }

			// Token: 0x04000A0F RID: 2575
			[CompilerGenerated]
			private devDept.Geometry.Point3D #a;

			// Token: 0x04000A10 RID: 2576
			[CompilerGenerated]
			private double #b;

			// Token: 0x04000A11 RID: 2577
			[CompilerGenerated]
			private EyeshotBoundingBoxDataLight #c;

			// Token: 0x04000A12 RID: 2578
			[CompilerGenerated]
			private bool #d;
		}

		// Token: 0x020002F1 RID: 753
		private sealed class #b1b
		{
			// Token: 0x170009AA RID: 2474
			// (get) Token: 0x06001A45 RID: 6725 RVA: 0x0001A097 File Offset: 0x00018297
			// (set) Token: 0x06001A46 RID: 6726 RVA: 0x0001A0A3 File Offset: 0x000182A3
			public bool IsDesignResult { get; set; }

			// Token: 0x170009AB RID: 2475
			// (get) Token: 0x06001A47 RID: 6727 RVA: 0x0001A0B4 File Offset: 0x000182B4
			// (set) Token: 0x06001A48 RID: 6728 RVA: 0x0001A0C0 File Offset: 0x000182C0
			public bool DesignWasSuccessful { get; set; }

			// Token: 0x170009AC RID: 2476
			// (get) Token: 0x06001A49 RID: 6729 RVA: 0x0001A0D1 File Offset: 0x000182D1
			// (set) Token: 0x06001A4A RID: 6730 RVA: 0x0001A0DD File Offset: 0x000182DD
			public List<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar> Bars { get; set; }

			// Token: 0x170009AD RID: 2477
			// (get) Token: 0x06001A4B RID: 6731 RVA: 0x0001A0EE File Offset: 0x000182EE
			// (set) Token: 0x06001A4C RID: 6732 RVA: 0x0001A0FA File Offset: 0x000182FA
			public #c6e Reinforcement { get; set; }

			// Token: 0x170009AE RID: 2478
			// (get) Token: 0x06001A4D RID: 6733 RVA: 0x0001A10B File Offset: 0x0001830B
			// (set) Token: 0x06001A4E RID: 6734 RVA: 0x0001A117 File Offset: 0x00018317
			public float DimensionA { get; set; }

			// Token: 0x170009AF RID: 2479
			// (get) Token: 0x06001A4F RID: 6735 RVA: 0x0001A128 File Offset: 0x00018328
			// (set) Token: 0x06001A50 RID: 6736 RVA: 0x0001A134 File Offset: 0x00018334
			public float DimensionB { get; set; }

			// Token: 0x170009B0 RID: 2480
			// (get) Token: 0x06001A51 RID: 6737 RVA: 0x0001A145 File Offset: 0x00018345
			// (set) Token: 0x06001A52 RID: 6738 RVA: 0x0001A151 File Offset: 0x00018351
			public List<List<devDept.Geometry.Point3D>> CoverPoints { get; set; }

			// Token: 0x170009B1 RID: 2481
			// (get) Token: 0x06001A53 RID: 6739 RVA: 0x0001A162 File Offset: 0x00018362
			// (set) Token: 0x06001A54 RID: 6740 RVA: 0x0001A16E File Offset: 0x0001836E
			public List<SectionPolygon> Polygons { get; set; }

			// Token: 0x170009B2 RID: 2482
			// (get) Token: 0x06001A55 RID: 6741 RVA: 0x0001A17F File Offset: 0x0001837F
			// (set) Token: 0x06001A56 RID: 6742 RVA: 0x0001A18B File Offset: 0x0001838B
			public BoundingBoxData BoundingBox { get; set; }

			// Token: 0x170009B3 RID: 2483
			// (get) Token: 0x06001A57 RID: 6743 RVA: 0x0001A19C File Offset: 0x0001839C
			// (set) Token: 0x06001A58 RID: 6744 RVA: 0x0001A1A8 File Offset: 0x000183A8
			public BoundingBoxData BoundingBoxWithBars { get; set; }

			// Token: 0x170009B4 RID: 2484
			// (get) Token: 0x06001A59 RID: 6745 RVA: 0x0001A1B9 File Offset: 0x000183B9
			// (set) Token: 0x06001A5A RID: 6746 RVA: 0x0001A1C5 File Offset: 0x000183C5
			public ColumnStorageModel Model { get; set; }

			// Token: 0x04000A13 RID: 2579
			[CompilerGenerated]
			private bool #a;

			// Token: 0x04000A14 RID: 2580
			[CompilerGenerated]
			private bool #b;

			// Token: 0x04000A15 RID: 2581
			[CompilerGenerated]
			private List<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar> #c;

			// Token: 0x04000A16 RID: 2582
			[CompilerGenerated]
			private #c6e #d;

			// Token: 0x04000A17 RID: 2583
			[CompilerGenerated]
			private float #e;

			// Token: 0x04000A18 RID: 2584
			[CompilerGenerated]
			private float #f;

			// Token: 0x04000A19 RID: 2585
			[CompilerGenerated]
			private List<List<devDept.Geometry.Point3D>> #g;

			// Token: 0x04000A1A RID: 2586
			[CompilerGenerated]
			private List<SectionPolygon> #h;

			// Token: 0x04000A1B RID: 2587
			[CompilerGenerated]
			private BoundingBoxData #i;

			// Token: 0x04000A1C RID: 2588
			[CompilerGenerated]
			private BoundingBoxData #j;

			// Token: 0x04000A1D RID: 2589
			[CompilerGenerated]
			private ColumnStorageModel #k;
		}

		// Token: 0x020002F3 RID: 755
		[CompilerGenerated]
		private sealed class #21b
		{
			// Token: 0x06001A94 RID: 6804 RVA: 0x000BD134 File Offset: 0x000BB334
			internal bool #11b(ModelRenderer.ReinforcementBlockMetadata #Rf)
			{
				return Math.Abs(#Rf.Radius - this.#a) < 1E-06 && #Rf.IsLeftRight == this.#b && #Rf.IsSelection == this.#c && #Rf.IsOverlapped == this.#d && #Rf.IsFinal == this.#e;
			}

			// Token: 0x04000A54 RID: 2644
			public double #a;

			// Token: 0x04000A55 RID: 2645
			public bool #b;

			// Token: 0x04000A56 RID: 2646
			public bool #c;

			// Token: 0x04000A57 RID: 2647
			public bool #d;

			// Token: 0x04000A58 RID: 2648
			public bool #e;
		}

		// Token: 0x020002F4 RID: 756
		[CompilerGenerated]
		private sealed class #iZb
		{
			// Token: 0x06001A96 RID: 6806 RVA: 0x0001A471 File Offset: 0x00018671
			internal double #31b(StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar #Rf)
			{
				return Math.Round(CircleHelper.#wmc((double)#Rf.Area), this.#a.#t);
			}

			// Token: 0x06001A97 RID: 6807 RVA: 0x0001A49B File Offset: 0x0001869B
			internal bool #41b(ModelRenderer.ReinforcementBlockMetadata #9o)
			{
				return #9o.IsLeftRight == this.#b;
			}

			// Token: 0x04000A59 RID: 2649
			public ModelRenderer #a;

			// Token: 0x04000A5A RID: 2650
			public bool #b;
		}

		// Token: 0x020002F5 RID: 757
		[CompilerGenerated]
		private sealed class #61b
		{
			// Token: 0x06001A99 RID: 6809 RVA: 0x0001A4B7 File Offset: 0x000186B7
			internal bool #51b(ModelRenderer.ReinforcementBlockMetadata #9o)
			{
				return #9o.Equals(this.#a);
			}

			// Token: 0x04000A5B RID: 2651
			public ModelRenderer.ReinforcementBlockMetadata #a;
		}

		// Token: 0x020002F6 RID: 758
		[CompilerGenerated]
		private sealed class #81b
		{
			// Token: 0x06001A9B RID: 6811 RVA: 0x0001A4D1 File Offset: 0x000186D1
			internal void #71b(CustomMeshEntity #Rf)
			{
				#Rf.EdgesColor = new Color?(this.#a);
			}

			// Token: 0x04000A5C RID: 2652
			public Color #a;
		}

		// Token: 0x020002F7 RID: 759
		[CompilerGenerated]
		private sealed class #8Ub
		{
			// Token: 0x06001A9D RID: 6813 RVA: 0x0001A4F0 File Offset: 0x000186F0
			internal bool #91b(ModelRenderer.ReinforcementBlockMetadata #9o)
			{
				return #9o.Equals(this.#a);
			}

			// Token: 0x04000A5D RID: 2653
			public ModelRenderer.ReinforcementBlockMetadata #a;
		}

		// Token: 0x020002F8 RID: 760
		[CompilerGenerated]
		private sealed class #b2b
		{
			// Token: 0x06001A9F RID: 6815 RVA: 0x0001A50A File Offset: 0x0001870A
			internal void #a2b(CustomMeshEntity #Rf)
			{
				#Rf.EdgesColor = new Color?(this.#a);
			}

			// Token: 0x04000A5E RID: 2654
			public Color #a;
		}

		// Token: 0x020002F9 RID: 761
		[CompilerGenerated]
		private sealed class #wWb
		{
			// Token: 0x06001AA1 RID: 6817 RVA: 0x0001A529 File Offset: 0x00018729
			internal devDept.Geometry.Point3D #c2b(StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar #Rf)
			{
				return new devDept.Geometry.Point3D((double)#Rf.X, (double)#Rf.Y, this.#a);
			}

			// Token: 0x04000A5F RID: 2655
			public double #a;
		}

		// Token: 0x020002FA RID: 762
		[CompilerGenerated]
		private sealed class #9Vb
		{
			// Token: 0x06001AA3 RID: 6819 RVA: 0x0001A550 File Offset: 0x00018750
			internal bool #d2b(#fS #Rf)
			{
				return #Rf.Shape == this.#a;
			}

			// Token: 0x04000A60 RID: 2656
			public ShapeModel #a;
		}

		// Token: 0x020002FB RID: 763
		[CompilerGenerated]
		private sealed class #9vg
		{
			// Token: 0x06001AA5 RID: 6821 RVA: 0x0001A56C File Offset: 0x0001876C
			internal devDept.Geometry.Point3D #e2b(StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point #Rf)
			{
				return new devDept.Geometry.Point3D((double)#Rf.X, (double)#Rf.Y, this.#a);
			}

			// Token: 0x06001AA6 RID: 6822 RVA: 0x0001A593 File Offset: 0x00018793
			internal devDept.Geometry.Point3D #f2b(Vertex #Rf)
			{
				return new devDept.Geometry.Point3D(#Rf.X, #Rf.Y, this.#a);
			}

			// Token: 0x04000A61 RID: 2657
			public double #a;
		}

		// Token: 0x020002FC RID: 764
		[CompilerGenerated]
		private sealed class #Vzf
		{
			// Token: 0x06001AA8 RID: 6824 RVA: 0x0001A5B8 File Offset: 0x000187B8
			internal void #h2b(devDept.Geometry.Point3D #Ng)
			{
				#Ng.Z = this.#a;
			}

			// Token: 0x04000A62 RID: 2658
			public double #a;

			// Token: 0x04000A63 RID: 2659
			public Action<devDept.Geometry.Point3D> #b;
		}

		// Token: 0x020002FD RID: 765
		[CompilerGenerated]
		private sealed class #Rbc
		{
			// Token: 0x06001AAA RID: 6826 RVA: 0x0001A5CE File Offset: 0x000187CE
			internal string #j2b()
			{
				return string.Format(#Phc.#3hc(107380716), this.#a);
			}

			// Token: 0x04000A64 RID: 2660
			public int #a;
		}
	}
}
