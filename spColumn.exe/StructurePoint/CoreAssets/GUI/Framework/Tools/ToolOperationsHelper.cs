using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using #7hc;
using #8Cc;
using #cYd;
using #ezc;
using #Fmc;
using #IDc;
using #kXc;
using #NWc;
using #T0c;
using #UYd;
using #YKc;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;
using StructurePoint.CoreAssets.GUI.Framework.Model.Entities;
using StructurePoint.CoreAssets.Infrastructure;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;

namespace StructurePoint.CoreAssets.GUI.Framework.Tools
{
	// Token: 0x02000B7A RID: 2938
	public sealed class ToolOperationsHelper : #6Kc
	{
		// Token: 0x06005FD8 RID: 24536 RVA: 0x00179AD0 File Offset: 0x00177CD0
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		public ToolOperationsHelper(#GBc dependencyResolver)
		{
			#X0d.#V0d(dependencyResolver, #Phc.#3hc(107417812), Component.GUI, #Phc.#3hc(107416974));
			this.AssignmentsFactory = dependencyResolver.#vy<#1Wc>();
			this.#e = dependencyResolver.#vy<#OWc>();
			this.ProjectContext = dependencyResolver.#vy<#oW>();
			this.ModelEditorViewModel = dependencyResolver.#vy<#V0c>();
			this.UndoManager = dependencyResolver.#vy<#bDc>();
			this.#c = dependencyResolver.#vy<#5Ic>();
			this.#d = dependencyResolver.#vy<#5Kc>();
		}

		// Token: 0x17001B30 RID: 6960
		// (get) Token: 0x06005FD9 RID: 24537 RVA: 0x0004F67A File Offset: 0x0004D87A
		// (set) Token: 0x06005FDA RID: 24538 RVA: 0x0004F682 File Offset: 0x0004D882
		protected #oW ProjectContext { get; set; }

		// Token: 0x17001B31 RID: 6961
		// (get) Token: 0x06005FDB RID: 24539 RVA: 0x0004F68B File Offset: 0x0004D88B
		// (set) Token: 0x06005FDC RID: 24540 RVA: 0x0004F693 File Offset: 0x0004D893
		protected #V0c ModelEditorViewModel { get; set; }

		// Token: 0x17001B32 RID: 6962
		// (get) Token: 0x06005FDD RID: 24541 RVA: 0x0004F69C File Offset: 0x0004D89C
		// (set) Token: 0x06005FDE RID: 24542 RVA: 0x0004F6A4 File Offset: 0x0004D8A4
		protected #bDc UndoManager { get; set; }

		// Token: 0x17001B33 RID: 6963
		// (get) Token: 0x06005FDF RID: 24543 RVA: 0x0004F6AD File Offset: 0x0004D8AD
		// (set) Token: 0x06005FE0 RID: 24544 RVA: 0x0004F6B5 File Offset: 0x0004D8B5
		private protected #1Wc AssignmentsFactory { protected get; private set; }

		// Token: 0x06005FE1 RID: 24545 RVA: 0x00179B54 File Offset: 0x00177D54
		public bool #VDc(IEnumerable<ShapesIntersectionResult> #9qc, IEnumerable<PolygonData> #yP)
		{
			if (#9qc == null || #yP == null)
			{
				return false;
			}
			#WWc #WWc = this.ProjectContext.MainModel;
			#WWc #WWc2;
			if (!false)
			{
				#WWc2 = #WWc;
			}
			if (#WWc2 == null)
			{
				return false;
			}
			IBulkUpdateScope bulkUpdateScope = this.ModelEditorViewModel.View.ModelVisualizationControl.TransparencySorter.BeginBulkUpdate();
			IBulkUpdateScope bulkUpdateScope2;
			if (!false)
			{
				bulkUpdateScope2 = bulkUpdateScope;
				goto IL_40;
			}
			try
			{
				Dictionary<ShapesIntersectionResult, ShapeDataModel> dictionary;
				do
				{
					IL_40:
					dictionary = new Dictionary<ShapesIntersectionResult, ShapeDataModel>();
					IList<PolygonData> #4lc = (#yP as IList<PolygonData>) ?? #yP.ToList<PolygonData>();
					using (IEnumerator<ShapesIntersectionResult> enumerator = #9qc.GetEnumerator())
					{
						for (;;)
						{
							if (!enumerator.MoveNext())
							{
								goto IL_D7;
							}
							ShapesIntersectionResult shapesIntersectionResult = enumerator.Current;
							ShapesIntersectionResult shapesIntersectionResult2;
							if (5 != 0)
							{
								shapesIntersectionResult2 = shapesIntersectionResult;
							}
							ShapeDataModel shapeDataModel = new ShapeDataModel(this.UndoManager, shapesIntersectionResult2.ShapeGeometryData, this.AssignmentsFactory);
							ShapeDataModel shapeDataModel2;
							if (!false)
							{
								shapeDataModel2 = shapeDataModel;
							}
							if (!BooleanOperationsHelper.#5lc(shapeDataModel2, #4lc))
							{
								break;
							}
							Dictionary<ShapesIntersectionResult, ShapeDataModel> dictionary2 = dictionary;
							ShapesIntersectionResult key = shapesIntersectionResult2;
							ShapeDataModel value = shapeDataModel2;
							if (!false)
							{
								dictionary2.Add(key, value);
							}
						}
						bool result;
						if (7 != 0)
						{
							bool flag = false;
							if (6 != 0)
							{
								result = flag;
							}
						}
						return result;
					}
					IL_D7:;
				}
				while (2 == 0);
				this.ModelEditorViewModel.#8ob(dictionary.Select(new Func<KeyValuePair<ShapesIntersectionResult, ShapeDataModel>, ShapeDataModel>(ToolOperationsHelper.<>c.<>9.#F8c)));
				using (Dictionary<ShapesIntersectionResult, ShapeDataModel>.Enumerator enumerator2 = dictionary.GetEnumerator())
				{
					for (;;)
					{
						IL_1C8:
						bool flag2 = enumerator2.MoveNext();
						while (flag2)
						{
							KeyValuePair<ShapesIntersectionResult, ShapeDataModel> keyValuePair;
							ShapeDataModel shapeDataModel3;
							do
							{
								keyValuePair = enumerator2.Current;
								shapeDataModel3 = (ShapeDataModel)keyValuePair.Key.ShapeGeometryData;
							}
							while (false);
							keyValuePair.Value.#dxc(shapeDataModel3);
							bool flag3 = flag2 = shapeDataModel3.Polygons.Any<PolygonData>();
							if (3 != 0)
							{
								if (flag3)
								{
									this.ProjectContext.MainModel.#hWc(shapeDataModel3);
									List<ShapeDataModel> second = this.ProjectContext.MainModel.Shapes.ToList<ShapeDataModel>();
									ToolOperationsHelper.#vEc(shapeDataModel3);
									this.#cEc(shapeDataModel3);
									IEnumerable<ShapeDataModel> #lBb = this.ProjectContext.MainModel.Shapes.Except(second);
									this.#d.#1Kc(new #jXc(shapeDataModel3, #lBb));
									goto IL_1C8;
								}
								#WWc2.#hWc(shapeDataModel3);
								goto IL_1C8;
							}
						}
						break;
					}
				}
			}
			finally
			{
				if (bulkUpdateScope2 != null)
				{
					bulkUpdateScope2.Dispose();
				}
			}
			return true;
		}

		// Token: 0x06005FE2 RID: 24546 RVA: 0x00179DAC File Offset: 0x00177FAC
		public bool #WDc(ShapeDataModel #XDc)
		{
			string #R0d = #Phc.#3hc(107416953);
			Component #x6c = Component.GUI;
			string #Qic = #Phc.#3hc(107416900);
			if (!false)
			{
				#X0d.#V0d(#XDc, #R0d, #x6c, #Qic);
			}
			IBulkUpdateScope bulkUpdateScope = this.ModelEditorViewModel.View.ModelVisualizationControl.TransparencySorter.BeginBulkUpdate();
			IBulkUpdateScope bulkUpdateScope2;
			if (2 != 0)
			{
				bulkUpdateScope2 = bulkUpdateScope;
			}
			bool result;
			try
			{
				#WWc #WWc = this.ProjectContext.MainModel;
				#WWc #WWc2;
				if (-1 != 0)
				{
					#WWc2 = #WWc;
				}
				if (#WWc2 == null)
				{
					if (!false)
					{
						bool flag = false;
						if (!false)
						{
							result = flag;
						}
					}
				}
				else
				{
					List<ShapeDataModel> list = new List<ShapeDataModel>(#WWc2.Shapes);
					List<ShapeDataModel> second;
					if (!false)
					{
						second = list;
					}
					do
					{
						#WWc #WWc3 = #WWc2;
						if (4 != 0)
						{
							#WWc3.#dWc(#XDc);
						}
						if (false)
						{
							goto IL_A4;
						}
						this.#cEc(#XDc);
					}
					while (false);
					List<ShapeDataModel> #lBb = #WWc2.Shapes.Except(second).ToList<ShapeDataModel>();
					this.#d.#4Kc(new #jXc(#lBb));
					IL_A4:
					result = true;
				}
			}
			finally
			{
				do
				{
					if (bulkUpdateScope2 != null)
					{
						bulkUpdateScope2.Dispose();
					}
				}
				while (false);
			}
			return result;
		}

		// Token: 0x06005FE3 RID: 24547 RVA: 0x00179EA4 File Offset: 0x001780A4
		public bool #VDc(IEnumerable<Point3D> #wsc, bool #YDc, PolygonType #ZDc)
		{
			if (#wsc == null)
			{
				return false;
			}
			IBulkUpdateScope bulkUpdateScope = this.ModelEditorViewModel.View.ModelVisualizationControl.TransparencySorter.BeginBulkUpdate();
			IBulkUpdateScope bulkUpdateScope2;
			if (!false)
			{
				bulkUpdateScope2 = bulkUpdateScope;
			}
			bool result;
			try
			{
				PolygonData polygonData = new PolygonData((#wsc as Point3D[]) ?? #wsc.ToArray<Point3D>(), #ZDc);
				PolygonData polygonData2;
				if (3 != 0)
				{
					polygonData2 = polygonData;
				}
				#WWc #WWc = this.ProjectContext.MainModel;
				#WWc #WWc2;
				if (6 != 0)
				{
					#WWc2 = #WWc;
				}
				ShapeDataModel #XDc;
				bool flag2;
				bool flag4;
				if (#WWc2 == null)
				{
					bool flag = false;
					if (2 != 0)
					{
						result = flag;
					}
					if (!false)
					{
						return result;
					}
				}
				else
				{
					IList<ShapesIntersectionResult> list2;
					if (!false)
					{
						IList<ShapesIntersectionResult> list = BooleanOperationsHelper.#CP(polygonData2, #WWc2.Shapes);
						if (6 != 0)
						{
							list2 = list;
						}
					}
					if (list2 == null || !list2.Any<ShapesIntersectionResult>())
					{
						ShapeDataModel shapeDataModel = new ShapeDataModel(this.UndoManager, polygonData2, this.AssignmentsFactory);
						if (!false)
						{
							#XDc = shapeDataModel;
						}
					}
					else
					{
						flag2 = this.#VDc(list2, new PolygonData[]
						{
							polygonData2
						});
						bool flag3 = flag4 = flag2;
						if (false)
						{
							goto IL_EA;
						}
						if (flag3 && #YDc)
						{
							ShapeDataModel #XDc2 = new ShapeDataModel(this.UndoManager, polygonData2, this.AssignmentsFactory);
							flag2 = this.#WDc(#XDc2);
							goto IL_E8;
						}
						goto IL_E8;
					}
				}
				result = this.#WDc(#XDc);
				if (!false)
				{
					return result;
				}
				IL_E8:
				flag4 = flag2;
				IL_EA:
				result = flag4;
			}
			finally
			{
				if (bulkUpdateScope2 != null)
				{
					bulkUpdateScope2.Dispose();
				}
			}
			return result;
		}

		// Token: 0x06005FE4 RID: 24548 RVA: 0x00179FE0 File Offset: 0x001781E0
		public ShapeDataModel #VDc(ShapeDataModel #6lc, IEnumerable<Point3D> #wsc, PolygonType #ZDc)
		{
			if (#wsc == null)
			{
				return null;
			}
			ShapeDataModel result;
			if (!false)
			{
				IBulkUpdateScope bulkUpdateScope = this.ModelEditorViewModel.View.ModelVisualizationControl.TransparencySorter.BeginBulkUpdate();
				IBulkUpdateScope bulkUpdateScope2;
				if (2 != 0)
				{
					bulkUpdateScope2 = bulkUpdateScope;
					goto IL_2C;
				}
				try
				{
					PolygonData polygonData2;
					IList<ShapesIntersectionResult> list2;
					for (;;)
					{
						IL_2C:
						PolygonData polygonData = new PolygonData((#wsc as Point3D[]) ?? #wsc.ToArray<Point3D>(), #ZDc);
						if (!false)
						{
							polygonData2 = polygonData;
						}
						IList<ShapesIntersectionResult> list = BooleanOperationsHelper.#CP(polygonData2, new ShapeDataModel[]
						{
							#6lc
						});
						if (!false)
						{
							list2 = list;
						}
						while (list2 != null && list2.Any<ShapesIntersectionResult>())
						{
							if (list2.Count > 1)
							{
								goto Block_6;
							}
							if (6 != 0)
							{
								if (7 != 0)
								{
									goto Block_8;
								}
								goto IL_2C;
							}
						}
						break;
					}
					IL_6B:
					ShapeDataModel shapeDataModel = new ShapeDataModel(this.UndoManager, polygonData2, this.AssignmentsFactory);
					if (!false)
					{
						result = shapeDataModel;
					}
					return result;
					Block_6:
					ShapeDataModel shapeDataModel2 = null;
					if (2 != 0)
					{
						result = shapeDataModel2;
					}
					return result;
					Block_8:
					this.#xEc(list2.First<ShapesIntersectionResult>(), polygonData2);
					ShapeDataModel shapeDataModel3 = new ShapeDataModel(this.UndoManager, polygonData2, this.AssignmentsFactory);
					if (true)
					{
						result = shapeDataModel3;
					}
					if (false)
					{
						goto IL_6B;
					}
				}
				finally
				{
					if (bulkUpdateScope2 != null)
					{
						bulkUpdateScope2.Dispose();
					}
				}
			}
			return result;
		}

		// Token: 0x06005FE5 RID: 24549 RVA: 0x0017A0EC File Offset: 0x001782EC
		public void #VDc(ShapeDataModel #rP, #3Hc #czc)
		{
			ToolOperationsHelper.#ZXb #ZXb = new ToolOperationsHelper.#ZXb();
			ToolOperationsHelper.#ZXb #ZXb2;
			if (true)
			{
				#ZXb2 = #ZXb;
			}
			do
			{
				#ZXb2.#a = #rP;
				#WWc #WWc = this.ProjectContext.MainModel;
				#WWc #WWc2;
				if (!false)
				{
					#WWc2 = #WWc;
				}
				IBulkUpdateScope bulkUpdateScope = this.ModelEditorViewModel.View.ModelVisualizationControl.TransparencySorter.BeginBulkUpdate();
				IBulkUpdateScope bulkUpdateScope2;
				if (!false)
				{
					bulkUpdateScope2 = bulkUpdateScope;
					goto IL_46;
				}
				try
				{
					for (;;)
					{
						IL_46:
						IList<ShapesIntersectionResult> list = BooleanOperationsHelper.#CP(#ZXb2.#a, #WWc2.Shapes.Where(new Func<ShapeDataModel, bool>(#ZXb2.#T8c)));
						IList<ShapesIntersectionResult> list2;
						if (!false)
						{
							list2 = list;
						}
						if (list2 == null || !list2.Any<ShapesIntersectionResult>())
						{
							break;
						}
						if (!this.#VDc(list2, #ZXb2.#a.Polygons))
						{
							goto Block_4;
						}
						if (6 != 0)
						{
							goto Block_5;
						}
					}
					this.#mEc(#ZXb2.#a, #czc);
					goto IL_F3;
					Block_4:
					#5Ic #5Ic = this.#c;
					string # = Strings.StringTheResultingPolygonIsNotValid.#z2d();
					if (!false)
					{
						#5Ic.#1Ic(#czc, #);
					}
					throw new #vYd(#Phc.#3hc(107416847), Component.GUI);
					Block_5:
					this.#mEc(#ZXb2.#a, #czc);
				}
				finally
				{
					if (bulkUpdateScope2 != null)
					{
						bulkUpdateScope2.Dispose();
					}
				}
				IL_F3:;
			}
			while (false);
		}

		// Token: 0x06005FE6 RID: 24550 RVA: 0x0017A214 File Offset: 0x00178414
		public bool #0Dc(IList<PolygonData> #1Dc, bool #2Dc)
		{
			ToolOperationsHelper.#NTb #NTb = new ToolOperationsHelper.#NTb();
			ToolOperationsHelper.#NTb #NTb2;
			if (3 != 0)
			{
				#NTb2 = #NTb;
			}
			do
			{
				#NTb2.#a = this;
				string #R0d = #Phc.#3hc(107416314);
				Component #x6c = Component.GUI;
				string #Qic = #Phc.#3hc(107416265);
				if (3 != 0)
				{
					#X0d.#V0d(#1Dc, #R0d, #x6c, #Qic);
				}
				IBulkUpdateScope bulkUpdateScope = this.ModelEditorViewModel.View.ModelVisualizationControl.TransparencySorter.BeginBulkUpdate();
				IBulkUpdateScope bulkUpdateScope2;
				if (6 != 0)
				{
					bulkUpdateScope2 = bulkUpdateScope;
				}
				try
				{
					#NTb2.#b = (#2Dc ? null : new HashSet<PolygonData>(#1Dc));
					int num = #1Dc.Any(new Func<PolygonData, bool>(#NTb2.#U8c)) ? 1 : 0;
					while (num != 0)
					{
						int num2 = num = 0;
						if (num2 == 0)
						{
							bool result;
							if (4 != 0)
							{
								result = (num2 != 0);
							}
							return result;
						}
					}
				}
				finally
				{
					if (bulkUpdateScope2 != null)
					{
						bulkUpdateScope2.Dispose();
					}
				}
			}
			while (6 == 0);
			return true;
		}

		// Token: 0x06005FE7 RID: 24551 RVA: 0x0017A2DC File Offset: 0x001784DC
		public bool #0Dc(PolygonData #3Dc, HashSet<PolygonData> #4Dc)
		{
			ToolOperationsHelper.#KTb #KTb = new ToolOperationsHelper.#KTb();
			ToolOperationsHelper.#KTb #KTb2;
			if (!false)
			{
				#KTb2 = #KTb;
			}
			#KTb2.#a = #4Dc;
			#KTb2.#b = this;
			#WWc #WWc = this.ProjectContext.MainModel;
			#WWc #WWc2;
			if (true)
			{
				#WWc2 = #WWc;
			}
			if (#WWc2 == null)
			{
				return false;
			}
			IBulkUpdateScope bulkUpdateScope = this.ModelEditorViewModel.View.ModelVisualizationControl.TransparencySorter.BeginBulkUpdate();
			IBulkUpdateScope bulkUpdateScope2;
			if (!false)
			{
				bulkUpdateScope2 = bulkUpdateScope;
			}
			try
			{
				List<ShapeDataModel> list = #WWc2.Shapes.ToList<ShapeDataModel>();
				List<ShapeDataModel> list2;
				if (5 != 0)
				{
					list2 = list;
				}
				if (#KTb2.#a != null)
				{
					List<ShapeDataModel> list3 = list2.Where(new Func<ShapeDataModel, bool>(#KTb2.#U8c)).ToList<ShapeDataModel>();
					if (!false)
					{
						list2 = list3;
					}
				}
				IList<ShapesIntersectionResult> list4 = BooleanOperationsHelper.#CP(#3Dc, list2);
				IList<ShapesIntersectionResult> list5;
				if (2 != 0)
				{
					list5 = list4;
				}
				ShapeDataModel shapeDataModel;
				if (list5 == null || !list5.Any<ShapesIntersectionResult>())
				{
					shapeDataModel = new ShapeDataModel(this.UndoManager, #3Dc, this.AssignmentsFactory);
					return this.#WDc(shapeDataModel);
				}
				List<ShapeDataModel> list6 = list5.Select(new Func<ShapesIntersectionResult, ShapeData>(ToolOperationsHelper.<>c.<>9.#G8c)).OfType<ShapeDataModel>().ToList<ShapeDataModel>();
				shapeDataModel = list6[0];
				List<ShapeDataModel> list7 = list6.Select(new Func<ShapeDataModel, ShapeDataModel>(#KTb2.#W8c)).ToList<ShapeDataModel>();
				if (BooleanOperationsHelper.#Tlc(list7.OfType<ShapeData>().ToList<ShapeData>(), #3Dc))
				{
					List<ShapeDataModel> second = new List<ShapeDataModel>(this.ProjectContext.MainModel.Shapes);
					this.ModelEditorViewModel.#8ob(list6);
					foreach (ShapeDataModel shapeDataModel2 in list6)
					{
						if (shapeDataModel2 != list6.First<ShapeDataModel>())
						{
							#WWc2.#hWc(shapeDataModel2);
						}
					}
					list7[0].#dxc(shapeDataModel);
					ToolOperationsHelper.#vEc(shapeDataModel);
					this.#cEc(shapeDataModel);
					List<ShapeDataModel> #lBb = this.ProjectContext.MainModel.Shapes.Except(second).ToList<ShapeDataModel>();
					this.#d.#ZKc(new #jXc(list6, #lBb));
					return true;
				}
			}
			finally
			{
				if (bulkUpdateScope2 != null)
				{
					bulkUpdateScope2.Dispose();
				}
			}
			return false;
		}

		// Token: 0x06005FE8 RID: 24552 RVA: 0x0017A544 File Offset: 0x00178744
		public IEnumerable<PolygonData> #0Dc(IList<PolygonData> #yP, bool #Ulc, bool #Vlc)
		{
			string #R0d = #Phc.#3hc(107372425);
			Component #x6c = Component.GUI;
			string #Qic = #Phc.#3hc(107416244);
			if (!false)
			{
				#X0d.#V0d(#yP, #R0d, #x6c, #Qic);
			}
			List<PolygonData> list = new List<PolygonData>();
			List<PolygonData> list2;
			if (!false)
			{
				list2 = list;
			}
			List<PolygonData> list4;
			bool flag2;
			do
			{
				List<PolygonData> list3 = new List<PolygonData>();
				if (!false)
				{
					list4 = list3;
				}
				List<PolygonData> list5 = #yP.ToList<PolygonData>();
				List<PolygonData> list6;
				if (!false)
				{
					list6 = list5;
				}
				IEnumerator<PolygonData> enumerator = #yP.GetEnumerator();
				IEnumerator<PolygonData> enumerator2;
				if (!false)
				{
					enumerator2 = enumerator;
				}
				try
				{
					while (enumerator2.MoveNext())
					{
						ToolOperationsHelper.#yZb #yZb = new ToolOperationsHelper.#yZb();
						ToolOperationsHelper.#yZb #yZb2;
						if (8 != 0)
						{
							#yZb2 = #yZb;
						}
						#yZb2.#a = enumerator2.Current;
						do
						{
							IEnumerable<PolygonData> #yP2 = list6.Where(new Func<PolygonData, bool>(#yZb2.#U8c));
							if (#yZb2.#a.PolygonType == PolygonType.Circle && !BooleanOperationsHelper.#7lc(ShapeData.#6wc(#yP2), #yZb2.#a))
							{
								goto IL_BB;
							}
						}
						while (5 == 0);
						list2.Add(#yZb2.#a);
						continue;
						IL_BB:
						if (2 != 0)
						{
							list4.Add(#yZb2.#a);
							list6.Remove(#yZb2.#a);
						}
					}
				}
				finally
				{
					if (enumerator2 != null)
					{
						enumerator2.Dispose();
					}
				}
				bool flag = list2.Any<PolygonData>();
				while (flag)
				{
					flag2 = (flag = BooleanOperationsHelper.#Tlc(list2, #Ulc, #Vlc));
					if (!false)
					{
						goto Block_4;
					}
				}
			}
			while (false);
			return list4;
			Block_4:
			if (flag2)
			{
				return list2.Union(list4);
			}
			return null;
		}

		// Token: 0x06005FE9 RID: 24553 RVA: 0x0017A6A0 File Offset: 0x001788A0
		public bool #0Dc(IEnumerable<Point3D> #wsc, PolygonType #ZDc)
		{
			if (#wsc != null && !false)
			{
				IBulkUpdateScope bulkUpdateScope = this.ModelEditorViewModel.View.ModelVisualizationControl.TransparencySorter.BeginBulkUpdate();
				IBulkUpdateScope bulkUpdateScope2;
				if (!false)
				{
					bulkUpdateScope2 = bulkUpdateScope;
					goto IL_26;
				}
				bool result;
				try
				{
					for (;;)
					{
						IL_26:
						List<Point3D> points3D;
						if (!false && (points3D = (#wsc as List<Point3D>)) != null)
						{
							goto IL_3C;
						}
						if (7 != 0)
						{
							points3D = #wsc.ToList<Point3D>();
							goto IL_3C;
						}
						IL_52:
						if (!false)
						{
							break;
						}
						continue;
						IL_3C:
						PolygonData polygonData = new PolygonData(points3D, #ZDc);
						PolygonData #3Dc;
						if (true)
						{
							#3Dc = polygonData;
						}
						bool flag = this.#0Dc(#3Dc, null);
						if (false)
						{
							goto IL_52;
						}
						result = flag;
						goto IL_52;
					}
				}
				finally
				{
					if (bulkUpdateScope2 != null)
					{
						bulkUpdateScope2.Dispose();
					}
				}
				return result;
			}
			return false;
		}

		// Token: 0x06005FEA RID: 24554 RVA: 0x0017A728 File Offset: 0x00178928
		public void #0Dc(ShapeDataModel #rP, int #5Dc, bool #6Dc, #3Hc #czc)
		{
			ToolOperationsHelper.#cWb #cWb = new ToolOperationsHelper.#cWb();
			ToolOperationsHelper.#cWb #cWb2;
			if (!false)
			{
				#cWb2 = #cWb;
			}
			#cWb2.#a = #rP;
			IBulkUpdateScope bulkUpdateScope = this.ModelEditorViewModel.View.ModelVisualizationControl.TransparencySorter.BeginBulkUpdate();
			IBulkUpdateScope bulkUpdateScope2;
			if (!false)
			{
				bulkUpdateScope2 = bulkUpdateScope;
			}
			try
			{
				#WWc #WWc = this.ProjectContext.MainModel;
				#WWc #WWc2;
				if (!false)
				{
					#WWc2 = #WWc;
				}
				if (#6Dc)
				{
					#cWb2.#a = this.#mEc(#cWb2.#a, #czc);
				}
				IList<ShapesIntersectionResult> list = BooleanOperationsHelper.#CP(#cWb2.#a, #WWc2.Shapes.Where(new Func<ShapeDataModel, bool>(#cWb2.#U8c)));
				IList<ShapesIntersectionResult> list2;
				if (!false)
				{
					list2 = list;
				}
				if (list2 == null || !list2.Any<ShapesIntersectionResult>())
				{
					if (!#6Dc)
					{
						this.#mEc(#cWb2.#a, #czc);
					}
				}
				else
				{
					#V0c #V0c = this.ModelEditorViewModel;
					ShapeDataModel #XDc = #cWb2.#a;
					if (!false)
					{
						#V0c.#8ob(#XDc);
					}
					if (list2.Any<ShapesIntersectionResult>() && #5Dc != 0)
					{
						ShapeDataModel #rP2 = #cWb2.#a;
						if (3 != 0)
						{
							this.#VDc(#rP2, #czc);
						}
					}
					else
					{
						List<ShapeDataModel> list3 = list2.Select(new Func<ShapesIntersectionResult, ShapeData>(ToolOperationsHelper.<>c.<>9.#H8c)).OfType<ShapeDataModel>().ToList<ShapeDataModel>();
						ShapeDataModel shapeDataModel = new ShapeDataModel(this.UndoManager, #cWb2.#a, this.AssignmentsFactory);
						if (!BooleanOperationsHelper.#Tlc(shapeDataModel, list3))
						{
							this.#c.#1Ic(#czc, Strings.StringTheResultingPolygonIsNotValid.#z2d());
							throw new #vYd(#Phc.#3hc(107416191), Component.GUI);
						}
						this.ModelEditorViewModel.#8ob(list3);
						foreach (ShapeDataModel #6lc in list3)
						{
							#WWc2.#hWc(#6lc);
						}
						shapeDataModel.#dxc(#cWb2.#a);
						ToolOperationsHelper.#vEc(#cWb2.#a);
						this.#cEc(#cWb2.#a);
					}
				}
			}
			finally
			{
				if (bulkUpdateScope2 != null)
				{
					bulkUpdateScope2.Dispose();
				}
			}
		}

		// Token: 0x06005FEB RID: 24555 RVA: 0x0017A964 File Offset: 0x00178B64
		public bool #7Dc(Point3D? #HAb)
		{
			int result;
			Point3D #HAb2;
			for (;;)
			{
				bool flag = (result = ((#HAb != null) ? 1 : 0)) != 0;
				if (5 == 0)
				{
					return result != 0;
				}
				if (!flag)
				{
					break;
				}
				do
				{
					Point3D value = #HAb.Value;
					if (!false)
					{
						#HAb2 = value;
					}
				}
				while (3 == 0);
				if (!false)
				{
					goto Block_3;
				}
			}
			result = 0;
			return result != 0;
			Block_3:
			return this.ProjectContext.MainModel.WorkspaceBoundingBoxData.#Zvc(PointsConverter.#vsc(#HAb2));
		}

		// Token: 0x06005FEC RID: 24556 RVA: 0x0004F6BE File Offset: 0x0004D8BE
		public bool #8Dc(Point3D? #HAb)
		{
			return (!true || false || #HAb != null || false) && this.#7Dc(new Point3D?(#HAb.Value));
		}

		// Token: 0x06005FED RID: 24557 RVA: 0x0017A9B0 File Offset: 0x00178BB0
		public Point3D? #9Dc(Point3D #Xqc, Point3D #tzb)
		{
			if (this.#8Dc(new Point3D?(#tzb)))
			{
				return new Point3D?(#tzb);
			}
			BoundingBoxData boundingBoxData = this.ProjectContext.MainModel.WorkspaceBoundingBoxData;
			BoundingBoxData boundingBoxData2;
			if (!false)
			{
				boundingBoxData2 = boundingBoxData;
			}
			if (boundingBoxData2 == null)
			{
				return null;
			}
			SegmentData segmentData = new SegmentData(#Xqc, #tzb);
			SegmentData segmentData2;
			if (-1 != 0)
			{
				segmentData2 = segmentData;
			}
			Point? point = null;
			IEnumerator<SegmentData> enumerator = boundingBoxData2.Segments.GetEnumerator();
			IEnumerator<SegmentData> enumerator2;
			if (!false)
			{
				enumerator2 = enumerator;
			}
			try
			{
				while (enumerator2.MoveNext())
				{
					SegmentData segmentData3 = enumerator2.Current;
					SegmentData #Vrc;
					if (!false)
					{
						#Vrc = segmentData3;
					}
					Point? point2 = #jsc.#plc(segmentData2, #Vrc);
					if (3 != 0)
					{
						point = point2;
					}
					bool flag2;
					bool flag = flag2 = (point != null);
					if (false)
					{
						goto IL_AF;
					}
					Point? point4;
					Point #ncb;
					bool flag3;
					if (flag)
					{
						Point? point3 = point;
						if (!false)
						{
							point4 = point3;
						}
						#ncb = segmentData2.StartPoint;
						if (false)
						{
							goto IL_B1;
						}
						if (point4 == null)
						{
							flag3 = true;
							goto IL_C2;
						}
						flag2 = (point4 != null);
						goto IL_AF;
					}
					IL_C6:
					point = null;
					continue;
					IL_C2:
					if (flag3)
					{
						break;
					}
					goto IL_C6;
					IL_B1:
					flag3 = false;
					goto IL_C2;
					IL_AF:
					if (!flag2)
					{
						goto IL_B1;
					}
					flag3 = Point.#F3d(point4.GetValueOrDefault(), #ncb);
					goto IL_C2;
				}
			}
			finally
			{
				if (enumerator2 != null)
				{
					enumerator2.Dispose();
				}
			}
			if (point == null)
			{
				return null;
			}
			return new Point3D?(PointsConverter.#vsc(point.Value));
		}

		// Token: 0x06005FEE RID: 24558 RVA: 0x0017AB00 File Offset: 0x00178D00
		public Point3D? #aEc(Point3D #Xqc, Point3D #tzb)
		{
			ToolOperationsHelper.#CZb #CZb = new ToolOperationsHelper.#CZb();
			ToolOperationsHelper.#CZb #CZb2;
			if (!false)
			{
				#CZb2 = #CZb;
			}
			if (this.#8Dc(new Point3D?(#tzb)))
			{
				return new Point3D?(#tzb);
			}
			BoundingBoxData boundingBoxData = this.ProjectContext.MainModel.WorkspaceBoundingBoxData;
			BoundingBoxData boundingBoxData2;
			if (-1 != 0)
			{
				boundingBoxData2 = boundingBoxData;
			}
			if (boundingBoxData2 == null)
			{
				return null;
			}
			#CZb2.#a = #Xqc;
			List<Point3D> list = new List<Point3D>();
			List<Point3D> list2;
			if (!false)
			{
				list2 = list;
			}
			List<Point3D> list3 = list2;
			Point3D item = new Point3D(boundingBoxData2.MinX, #CZb2.#a.Y, 0.0);
			if (5 != 0)
			{
				list3.Add(item);
			}
			List<Point3D> list4 = list2;
			Point3D item2 = new Point3D(boundingBoxData2.MaxX, #CZb2.#a.Y, 0.0);
			if (!false)
			{
				list4.Add(item2);
			}
			List<Point3D> list5 = list2;
			Point3D item3 = new Point3D(#CZb2.#a.X, boundingBoxData2.MinY, 0.0);
			if (!false)
			{
				list5.Add(item3);
			}
			list2.Add(new Point3D(#CZb2.#a.X, boundingBoxData2.MaxY, 0.0));
			if (!list2.Any<Point3D>())
			{
				return null;
			}
			return new Point3D?(list2.OrderBy(new Func<Point3D, double>(#CZb2.#X8c)).First<Point3D>());
		}

		// Token: 0x06005FEF RID: 24559 RVA: 0x0017AC60 File Offset: 0x00178E60
		public Point3D? #aEc(Point3D #tzb)
		{
			ToolOperationsHelper.#p6b #p6b = new ToolOperationsHelper.#p6b();
			ToolOperationsHelper.#p6b #p6b2;
			if (!false)
			{
				#p6b2 = #p6b;
			}
			if (8 == 0)
			{
			}
			IL_14:
			Point? point2;
			while (!false)
			{
				bool flag = this.#7Dc(new Point3D?(#tzb));
				while (!flag)
				{
					BoundingBoxData boundingBoxData2;
					Point3D? result;
					for (;;)
					{
						#p6b2.#a = PointsConverter.#vsc(#tzb);
						BoundingBoxData boundingBoxData = this.ProjectContext.MainModel.WorkspaceBoundingBoxData;
						if (!false)
						{
							boundingBoxData2 = boundingBoxData;
						}
						if (boundingBoxData2 != null)
						{
							break;
						}
						result = null;
						if (!false)
						{
							return result;
						}
					}
					var <>f__AnonymousType = boundingBoxData2.Segments.Select(new Func<SegmentData, <>f__AnonymousType2<SegmentData, double?>>(#p6b2.#X8c)).OrderBy(new Func<<>f__AnonymousType2<SegmentData, double?>, double?>(ToolOperationsHelper.<>c.<>9.#I8c)).FirstOrDefault();
					var <>f__AnonymousType2;
					if (4 != 0)
					{
						<>f__AnonymousType2 = <>f__AnonymousType;
					}
					if (<>f__AnonymousType2 == null)
					{
						result = null;
						if (!false)
						{
							return result;
						}
						goto IL_14;
					}
					else
					{
						Point? point = #jsc.#gsc(<>f__AnonymousType2.Segment, #p6b2.#a);
						if (!false)
						{
							point2 = point;
						}
						bool flag2 = flag = (point2 != null);
						if (false)
						{
							continue;
						}
						if (!flag2)
						{
							return null;
						}
						goto IL_EA;
					}
					return result;
				}
				return new Point3D?(#tzb);
			}
			IL_EA:
			return new Point3D?(PointsConverter.#vsc(point2.Value));
		}

		// Token: 0x06005FF0 RID: 24560 RVA: 0x0017AD84 File Offset: 0x00178F84
		public bool #bEc()
		{
			bool result;
			do
			{
				IBulkUpdateScope bulkUpdateScope = this.ModelEditorViewModel.View.ModelVisualizationControl.TransparencySorter.BeginBulkUpdate();
				IBulkUpdateScope bulkUpdateScope2;
				if (true)
				{
					bulkUpdateScope2 = bulkUpdateScope;
				}
				try
				{
					#WWc #WWc = this.ProjectContext.MainModel;
					#WWc #WWc2;
					if (!false)
					{
						#WWc2 = #WWc;
					}
					int num = #WWc2.Shapes.Count<ShapeDataModel>();
					int num2;
					if (4 != 0)
					{
						num2 = num;
					}
					bool flag = false;
					bool flag2;
					if (!false)
					{
						flag2 = flag;
					}
					int num3 = 0;
					for (;;)
					{
						IL_4E:
						int num4;
						if (4 != 0)
						{
							num4 = num3;
						}
						for (;;)
						{
							for (;;)
							{
								int num5 = num3 = num4;
								if (false)
								{
									goto IL_4E;
								}
								if (num5 >= num2)
								{
									goto Block_7;
								}
								ShapeDataModel shapeDataModel = #WWc2.Shapes.ElementAt(num4);
								ShapeDataModel shapeDataModel2;
								if (5 != 0)
								{
									shapeDataModel2 = shapeDataModel;
								}
								int num6 = num4 + 1;
								while (6 != 0)
								{
									if (num6 >= num2)
									{
										num4++;
										break;
									}
									ShapeDataModel shapeDataModel3 = #WWc2.Shapes.ElementAt(num6);
									if (PolygonsRefineHelper.#Fsc(shapeDataModel2.#cxc(0), shapeDataModel3.#cxc(0), 0.001, 1E-06))
									{
										this.ModelEditorViewModel.#8ob(shapeDataModel2);
										this.ModelEditorViewModel.#8ob(shapeDataModel3);
										if (2 == 0)
										{
											continue;
										}
										this.ModelEditorViewModel.#QZc(shapeDataModel2);
										this.ModelEditorViewModel.#QZc(shapeDataModel3);
										flag2 = true;
									}
									num6++;
								}
							}
						}
					}
					Block_7:
					bulkUpdateScope2.RefreshOnCompletion = flag2;
					result = flag2;
				}
				finally
				{
					if (bulkUpdateScope2 != null)
					{
						bulkUpdateScope2.Dispose();
					}
				}
			}
			while (7 == 0);
			return result;
		}

		// Token: 0x06005FF1 RID: 24561 RVA: 0x0017AF00 File Offset: 0x00179100
		public IList<ShapeDataModel> #cEc(ShapeDataModel #rP)
		{
			if (#rP == null)
			{
				return null;
			}
			IBulkUpdateScope bulkUpdateScope = this.ModelEditorViewModel.View.ModelVisualizationControl.TransparencySorter.BeginBulkUpdate();
			IBulkUpdateScope bulkUpdateScope2;
			if (!false)
			{
				bulkUpdateScope2 = bulkUpdateScope;
			}
			IList<ShapeDataModel> result;
			try
			{
				#WWc #WWc = this.ProjectContext.MainModel;
				#WWc #WWc2;
				if (5 != 0)
				{
					#WWc2 = #WWc;
				}
				List<PolygonData> list = #rP.Polygons.Where(new Func<PolygonData, bool>(ToolOperationsHelper.<>c.<>9.#J8c)).ToList<PolygonData>();
				#V0c #V0c = this.ModelEditorViewModel;
				if (4 != 0)
				{
					#V0c.#8ob(#rP);
				}
				#WWc #WWc3 = #WWc2;
				if (!false)
				{
					#WWc3.#hWc(#rP);
				}
				List<ShapeDataModel> list2 = new List<ShapeDataModel>();
				List<ShapeDataModel> list3;
				if (!false)
				{
					list3 = list2;
				}
				List<PolygonData>.Enumerator enumerator = list.GetEnumerator();
				List<PolygonData>.Enumerator enumerator2;
				if (!false)
				{
					enumerator2 = enumerator;
				}
				try
				{
					while (enumerator2.MoveNext())
					{
						PolygonData polygonData = enumerator2.Current;
						List<PolygonData> list4 = new List<PolygonData>();
						list4.Add(polygonData);
						list4.AddRange(polygonData.ChildPolygons);
						ShapeDataModel shapeDataModel = new ShapeDataModel(this.UndoManager, list4, this.AssignmentsFactory);
						#WWc2.#dWc(shapeDataModel);
						shapeDataModel.#EXc(#rP);
						list3.Add(shapeDataModel);
						this.ModelEditorViewModel.#QZc(shapeDataModel);
					}
				}
				finally
				{
					((IDisposable)enumerator2).Dispose();
				}
				result = list3;
			}
			finally
			{
				if (bulkUpdateScope2 != null)
				{
					bulkUpdateScope2.Dispose();
				}
			}
			return result;
		}

		// Token: 0x06005FF2 RID: 24562 RVA: 0x0017B094 File Offset: 0x00179294
		public void #dEc(IList<NodeModel> #6W)
		{
			string #R0d = #Phc.#3hc(107416106);
			Component #x6c = Component.GUI;
			string #Qic = #Phc.#3hc(107416097);
			if (2 != 0)
			{
				#X0d.#V0d(#6W, #R0d, #x6c, #Qic);
			}
			IBulkUpdateScope bulkUpdateScope = this.ModelEditorViewModel.View.ModelVisualizationControl.TransparencySorter.BeginBulkUpdate();
			IBulkUpdateScope bulkUpdateScope2;
			if (5 != 0)
			{
				bulkUpdateScope2 = bulkUpdateScope;
			}
			try
			{
				ToolOperationsHelper.#R7b #R7b = new ToolOperationsHelper.#R7b();
				ToolOperationsHelper.#R7b #R7b2;
				if (!false)
				{
					#R7b2 = #R7b;
				}
				#WWc #WWc2;
				if (7 != 0)
				{
					#WWc #WWc = this.ProjectContext.MainModel;
					if (7 != 0)
					{
						#WWc2 = #WWc;
					}
					#R7b2.#a = #WWc2.Nodes.ToDictionary(new Func<NodeModel, Point>(ToolOperationsHelper.<>c.<>9.#K8c));
				}
				List<NodeModel> list = #6W.Select(new Func<NodeModel, <>f__AnonymousType3<NodeModel, NodeModel>>(#R7b2.#Y8c)).Where(new Func<<>f__AnonymousType3<NodeModel, NodeModel>, bool>(ToolOperationsHelper.<>c.<>9.#L8c)).Select(new Func<<>f__AnonymousType3<NodeModel, NodeModel>, NodeModel>(ToolOperationsHelper.<>c.<>9.#N8c)).ToList<NodeModel>();
				List<NodeModel> list2;
				if (!false)
				{
					list2 = list;
				}
				#WWc #WWc3 = #WWc2;
				IEnumerable<NodeModel> #WVc = list2;
				if (!false)
				{
					#WWc3.#jEc(#WVc);
				}
				this.ModelEditorViewModel.#8Zc(this.ProjectContext.MainModel.Nodes);
			}
			finally
			{
				if (bulkUpdateScope2 != null)
				{
					bulkUpdateScope2.Dispose();
				}
			}
		}

		// Token: 0x06005FF3 RID: 24563 RVA: 0x0017B1FC File Offset: 0x001793FC
		public void #eEc(IList<NodeModel> #6W, IEnumerable<ShapeDataModel> #6Y, bool #fEc, #3Hc #czc, bool #gEc)
		{
			string #R0d = #Phc.#3hc(107416106);
			Component #x6c = Component.GUI;
			string #Qic = #Phc.#3hc(107416556);
			if (!false)
			{
				#X0d.#V0d(#6W, #R0d, #x6c, #Qic);
			}
			string #R0d2 = #Phc.#3hc(107372113);
			Component #x6c2 = Component.GUI;
			string #Qic2 = #Phc.#3hc(107416535);
			if (!false)
			{
				#X0d.#V0d(#6Y, #R0d2, #x6c2, #Qic2);
			}
			IBulkUpdateScope bulkUpdateScope = this.ModelEditorViewModel.View.ModelVisualizationControl.TransparencySorter.BeginBulkUpdate();
			IBulkUpdateScope bulkUpdateScope2;
			if (!false)
			{
				bulkUpdateScope2 = bulkUpdateScope;
			}
			try
			{
				List<ShapeDataModel> list = new List<ShapeDataModel>();
				List<ShapeDataModel> list2 = new List<ShapeDataModel>();
				List<ShapeDataModel> list3 = new List<ShapeDataModel>();
				List<Point> #BP = #6W.Select(new Func<NodeModel, Point>(ToolOperationsHelper.<>c.<>9.#O8c)).ToList<Point>();
				foreach (ShapeDataModel shapeDataModel in #6Y.ToList<ShapeDataModel>())
				{
					ShapeDataModel shapeDataModel2;
					if (!false)
					{
						shapeDataModel2 = shapeDataModel;
					}
					List<PolygonData> list4 = new List<PolygonData>();
					List<PolygonData> list5;
					if (!false)
					{
						list5 = list4;
					}
					List<PolygonData> list6 = new List<PolygonData>();
					List<PolygonData> list7;
					if (!false)
					{
						list7 = list6;
					}
					int num = 0;
					while (num < shapeDataModel2.PolygonsCount && this.#pEc(shapeDataModel2, num, #BP, list, list5, list7, list3))
					{
						num++;
					}
					bool flag = list5.Any<PolygonData>() || list7.Any<PolygonData>();
					if (list5.Any<PolygonData>())
					{
						shapeDataModel2.#8wc(shapeDataModel2.Polygons.Except(list5).ToList<PolygonData>());
					}
					if (flag)
					{
						this.ModelEditorViewModel.#8ob(shapeDataModel2);
						shapeDataModel2 = this.#mEc(shapeDataModel2, #czc);
					}
					if (list7.Any<PolygonData>())
					{
						list2.Add(shapeDataModel2);
					}
				}
				if (!list.Any<ShapeDataModel>())
				{
					goto IL_1BB;
				}
				IL_19C:
				if (#gEc && !this.#e.#KWc())
				{
					throw new #bYd(true);
				}
				this.#nEc(list);
				IL_1BB:
				this.#lEc(list2, #czc);
				if (false)
				{
					goto IL_19C;
				}
				list3 = list3.Distinct<ShapeDataModel>().ToList<ShapeDataModel>();
				this.ModelEditorViewModel.#8ob(list3);
				foreach (ShapeDataModel shapeDataModel3 in list3)
				{
					ToolOperationsHelper.#vEc(shapeDataModel3);
					if (#fEc)
					{
						this.#0Dc(shapeDataModel3, 0, true, #czc);
					}
					else
					{
						this.#VDc(shapeDataModel3, #czc);
					}
				}
			}
			finally
			{
				if (bulkUpdateScope2 != null)
				{
					bulkUpdateScope2.Dispose();
				}
			}
		}

		// Token: 0x06005FF4 RID: 24564 RVA: 0x0017B4A8 File Offset: 0x001796A8
		public void #hEc(IList<NodeModel> #6W, IEnumerable<LinearObject> #iEc)
		{
			ToolOperationsHelper.#0Ub #0Ub = new ToolOperationsHelper.#0Ub();
			ToolOperationsHelper.#0Ub #0Ub2;
			if (!false)
			{
				#0Ub2 = #0Ub;
			}
			#0Ub2.#a = #6W;
			string #R0d = #Phc.#3hc(107416450);
			Component #x6c = Component.GUI;
			string #Qic = #Phc.#3hc(107416429);
			if (-1 != 0)
			{
				#X0d.#V0d(#iEc, #R0d, #x6c, #Qic);
			}
			object #Rf = #0Ub2.#a;
			string #R0d2 = #Phc.#3hc(107416106);
			Component #x6c2 = Component.GUI;
			string #Qic2 = #Phc.#3hc(107416408);
			if (2 != 0)
			{
				#X0d.#V0d(#Rf, #R0d2, #x6c2, #Qic2);
			}
			IBulkUpdateScope bulkUpdateScope = this.ModelEditorViewModel.View.ModelVisualizationControl.TransparencySorter.BeginBulkUpdate();
			IBulkUpdateScope bulkUpdateScope2;
			if (8 != 0)
			{
				bulkUpdateScope2 = bulkUpdateScope;
			}
			try
			{
				List<LinearObject> list = #iEc.Where(new Func<LinearObject, bool>(#0Ub2.#08c)).ToList<LinearObject>();
				Action<LinearObject> action = new Action<LinearObject>(this.ProjectContext.MainModel.#aWc);
				if (!false)
				{
					list.ForEach(action);
				}
				if (list.Any<LinearObject>())
				{
					#V0c #V0c = this.ModelEditorViewModel;
					IEnumerable<LinearObject> #iEc2 = this.ProjectContext.MainModel.LinearObjects;
					if (!false)
					{
						#V0c.#e0c(#iEc2);
					}
				}
			}
			finally
			{
				if (bulkUpdateScope2 != null)
				{
					bulkUpdateScope2.Dispose();
				}
			}
		}

		// Token: 0x06005FF5 RID: 24565 RVA: 0x0017B5D0 File Offset: 0x001797D0
		public void #jEc(IList<NodeModel> #6W, IEnumerable<ShapeDataModel> #6Y, IEnumerable<LinearObject> #iEc, bool #fEc, bool #kEc, bool #gEc, #3Hc #czc)
		{
			string #R0d = #Phc.#3hc(107416106);
			Component #x6c = Component.GUI;
			string #Qic = #Phc.#3hc(107416323);
			if (7 != 0)
			{
				#X0d.#V0d(#6W, #R0d, #x6c, #Qic);
			}
			string #R0d2 = #Phc.#3hc(107372113);
			Component #x6c2 = Component.GUI;
			string #Qic2 = #Phc.#3hc(107415758);
			if (5 != 0)
			{
				#X0d.#V0d(#6Y, #R0d2, #x6c2, #Qic2);
			}
			IBulkUpdateScope bulkUpdateScope = this.ModelEditorViewModel.View.ModelVisualizationControl.TransparencySorter.BeginBulkUpdate();
			IBulkUpdateScope bulkUpdateScope2;
			if (!false)
			{
				bulkUpdateScope2 = bulkUpdateScope;
			}
			try
			{
				if (7 != 0)
				{
					if (#kEc)
					{
						if (false)
						{
							goto IL_8A;
						}
						if (-1 != 0)
						{
							this.#dEc(#6W);
						}
					}
					if (!false)
					{
						this.#eEc(#6W, #6Y, #fEc, #czc, #gEc);
					}
				}
				if (!false)
				{
					this.#hEc(#6W, #iEc);
				}
				IL_8A:;
			}
			finally
			{
				if (bulkUpdateScope2 != null)
				{
					bulkUpdateScope2.Dispose();
				}
			}
		}

		// Token: 0x06005FF6 RID: 24566 RVA: 0x0017B6B4 File Offset: 0x001798B4
		internal void #lEc(IEnumerable<ShapeDataModel> #6Y, #3Hc #czc)
		{
			IBulkUpdateScope bulkUpdateScope = this.ModelEditorViewModel.View.ModelVisualizationControl.TransparencySorter.BeginBulkUpdate();
			IBulkUpdateScope bulkUpdateScope2;
			if (!false)
			{
				bulkUpdateScope2 = bulkUpdateScope;
			}
			try
			{
				ToolOperationsHelper.#SUb #SUb = new ToolOperationsHelper.#SUb();
				#SUb.#a = this.ProjectContext.MainModel;
				var list = #6Y.Select(new Func<ShapeDataModel, <>f__AnonymousType4<ShapeDataModel, IList<ShapesIntersectionResult>>>(#SUb.#38c)).Where(new Func<<>f__AnonymousType4<ShapeDataModel, IList<ShapesIntersectionResult>>, bool>(ToolOperationsHelper.<>c.<>9.#P8c)).Select(new Func<<>f__AnonymousType4<ShapeDataModel, IList<ShapesIntersectionResult>>, <>f__AnonymousType5<ShapeDataModel, IList<ShapesIntersectionResult>>>(ToolOperationsHelper.<>c.<>9.#Q8c)).ToList();
				this.ModelEditorViewModel.#8ob(list.Select(new Func<<>f__AnonymousType5<ShapeDataModel, IList<ShapesIntersectionResult>>, ShapeDataModel>(ToolOperationsHelper.<>c.<>9.#R8c)));
				foreach (var <>f__AnonymousType in list)
				{
					var <>f__AnonymousType2;
					if (true)
					{
						<>f__AnonymousType2 = <>f__AnonymousType;
					}
					if (!this.#VDc(<>f__AnonymousType2.Intersections, <>f__AnonymousType2.Shape.Polygons))
					{
						#5Ic #5Ic = this.#c;
						string # = Strings.StringTheResultingPolygonIsNotValid.#z2d();
						if (4 != 0)
						{
							#5Ic.#1Ic(#czc, #);
						}
						throw new #vYd(#Phc.#3hc(107416847), Component.GUI);
					}
					this.#mEc(<>f__AnonymousType2.Shape, #czc);
				}
			}
			finally
			{
				if (bulkUpdateScope2 != null)
				{
					bulkUpdateScope2.Dispose();
				}
			}
		}

		// Token: 0x06005FF7 RID: 24567 RVA: 0x0017B858 File Offset: 0x00179A58
		public ShapeDataModel #mEc(ShapeDataModel #rP, #3Hc #czc)
		{
			IBulkUpdateScope bulkUpdateScope = this.ModelEditorViewModel.View.ModelVisualizationControl.TransparencySorter.BeginBulkUpdate();
			IBulkUpdateScope bulkUpdateScope2;
			if (4 != 0)
			{
				bulkUpdateScope2 = bulkUpdateScope;
			}
			ShapeDataModel result;
			try
			{
				ShapeDataModel shapeDataModel = new ShapeDataModel(this.UndoManager, #rP, this.AssignmentsFactory);
				if (!BooleanOperationsHelper.#mmc(shapeDataModel))
				{
					#5Ic #5Ic = this.#c;
					string # = Strings.StringTheResultingPolygonIsNotValid.#z2d();
					if (!false)
					{
						#5Ic.#1Ic(#czc, #);
					}
					throw new #vYd(#Phc.#3hc(107415737), Component.GUI);
				}
				if (!false)
				{
					shapeDataModel.#dxc(#rP);
				}
				for (;;)
				{
					IList<ShapeDataModel> list = this.#cEc(#rP);
					IList<ShapeDataModel> list2;
					if (6 != 0)
					{
						list2 = list;
					}
					#5Kc #5Kc = this.#d;
					#jXc #0Kc = new #jXc(#rP, list2);
					if (true)
					{
						#5Kc.#3Kc(#0Kc);
					}
					if (!false)
					{
						ShapeDataModel shapeDataModel2 = list2.First<ShapeDataModel>();
						if (4 != 0)
						{
							result = shapeDataModel2;
						}
						if (2 != 0)
						{
							break;
						}
					}
				}
			}
			finally
			{
				if (bulkUpdateScope2 != null)
				{
					bulkUpdateScope2.Dispose();
				}
			}
			return result;
		}

		// Token: 0x06005FF8 RID: 24568 RVA: 0x0017B93C File Offset: 0x00179B3C
		public void #nEc(IEnumerable<ShapeDataModel> #6Y)
		{
			string #R0d = #Phc.#3hc(107372113);
			Component #x6c = Component.GUI;
			string #Qic = #Phc.#3hc(107415652);
			if (2 != 0)
			{
				#X0d.#V0d(#6Y, #R0d, #x6c, #Qic);
			}
			IBulkUpdateScope bulkUpdateScope = this.ModelEditorViewModel.View.ModelVisualizationControl.TransparencySorter.BeginBulkUpdate();
			IBulkUpdateScope bulkUpdateScope2;
			if (!false)
			{
				bulkUpdateScope2 = bulkUpdateScope;
			}
			try
			{
				IList<ShapeDataModel> list;
				if ((list = (#6Y as IList<ShapeDataModel>)) == null)
				{
					if (false)
					{
						goto IL_61;
					}
					list = #6Y.ToList<ShapeDataModel>();
				}
				IList<ShapeDataModel> list2 = list;
				this.ModelEditorViewModel.#8ob(list2);
				IL_61:
				using (IEnumerator<ShapeDataModel> enumerator = list2.GetEnumerator())
				{
					for (;;)
					{
						while (enumerator.MoveNext())
						{
							ShapeDataModel shapeDataModel = enumerator.Current;
							ShapeDataModel shapeDataModel2;
							if (!false)
							{
								shapeDataModel2 = shapeDataModel;
							}
							#WWc #WWc = this.ProjectContext.MainModel;
							ShapeDataModel #6lc = shapeDataModel2;
							if (6 != 0)
							{
								#WWc.#hWc(#6lc);
							}
							if (!false)
							{
								IList<NodeModel> list3 = this.#4W(shapeDataModel2, true);
								IList<NodeModel> list4;
								if (!false)
								{
									list4 = list3;
								}
								#WWc #WWc2 = this.ProjectContext.MainModel;
								IEnumerable<NodeModel> #WVc = list4;
								if (-1 != 0)
								{
									#WWc2.#jEc(#WVc);
								}
							}
						}
						break;
					}
				}
			}
			finally
			{
				while (bulkUpdateScope2 != null)
				{
					if (!false)
					{
						bulkUpdateScope2.Dispose();
						break;
					}
				}
			}
		}

		// Token: 0x06005FF9 RID: 24569 RVA: 0x0017BA54 File Offset: 0x00179C54
		public IList<NodeModel> #4W(ShapeDataModel #rP, bool #oEc)
		{
			ToolOperationsHelper.#kWb #kWb2;
			do
			{
				ToolOperationsHelper.#kWb #kWb = new ToolOperationsHelper.#kWb();
				if (!false)
				{
					#kWb2 = #kWb;
				}
			}
			while (false);
			#kWb2.#a = #rP;
			for (;;)
			{
				if (7 != 0)
				{
					#kWb2.#c = #oEc;
					object #Rf = #kWb2.#a;
					string #R0d = #Phc.#3hc(107371527);
					Component #x6c = Component.GUI;
					string #Qic = #Phc.#3hc(107415599);
					if (!false)
					{
						#X0d.#V0d(#Rf, #R0d, #x6c, #Qic);
					}
					#kWb2.#b = new HashSet<Point>(#kWb2.#a.#fxc());
					goto IL_5E;
				}
				IL_AE:
				if (!false)
				{
					if (-1 != 0)
					{
						break;
					}
					continue;
				}
				IL_5E:
				#kWb2.#d = new HashSet<Point>(this.ProjectContext.MainModel.Shapes.Where(new Func<ShapeDataModel, bool>(#kWb2.#58c)).SelectMany(new Func<ShapeDataModel, IEnumerable<Point>>(ToolOperationsHelper.<>c.<>9.#S8c)));
				goto IL_AE;
			}
			return this.ProjectContext.MainModel.Nodes.Where(new Func<NodeModel, bool>(#kWb2.#68c)).ToList<NodeModel>();
		}

		// Token: 0x06005FFA RID: 24570 RVA: 0x0017BB50 File Offset: 0x00179D50
		private bool #pEc(ShapeDataModel #rP, int #qEc, IList<Point> #BP, List<ShapeDataModel> #rEc, List<PolygonData> #sEc, List<PolygonData> #tEc, List<ShapeDataModel> #uEc)
		{
			PolygonData polygonData = #rP.#cxc(#qEc);
			PolygonData polygonData2;
			if (-1 != 0)
			{
				polygonData2 = polygonData;
			}
			List<Point> list = PointsConverter.#psc(polygonData2.Points2D, #BP);
			List<Point> list2;
			if (true)
			{
				list2 = list;
			}
			if (!false)
			{
				if (list2 == null || !list2.Any<Point>())
				{
					return true;
				}
				int num;
				int num2;
				if (#qEc == 0)
				{
					num = polygonData2.Points2DCount;
					num2 = 1;
				}
				else
				{
					int num4;
					int num3 = num = (num4 = polygonData2.Points2DCount);
					int num6;
					int num5 = num2 = (num6 = 1);
					if (num5 != 0)
					{
						num4 = (num = num3 - num5 - list2.Count);
						num6 = (num2 = PolygonData.MinNumberOfPoints);
					}
					if (-1 != 0)
					{
						if (num4 < num6)
						{
							#sEc.Add(polygonData2);
							#uEc.Add(#rP);
							return true;
						}
						List<Point> #BP2 = polygonData2.Points2D.Except(list2).ToList<Point>();
						polygonData2.#dwc(#BP2);
						if (BooleanOperationsHelper.#9W(polygonData2))
						{
							#tEc.Add(polygonData2);
							return true;
						}
						#sEc.Add(polygonData2);
						return true;
					}
				}
				if (num - num2 - list2.Count < PolygonData.MinNumberOfPoints)
				{
					if (true)
					{
						#rEc.Add(#rP);
					}
					return false;
				}
				do
				{
					#V0c #V0c = this.ModelEditorViewModel;
					if (5 != 0)
					{
						#V0c.#8ob(#rP);
					}
					List<Point> list3 = polygonData2.Points2D.Except(list2).ToList<Point>();
					List<Point> list4;
					if (!false)
					{
						list4 = list3;
					}
					PolygonData polygonData3 = polygonData2;
					IEnumerable<Point> #BP3 = list4;
					if (!false)
					{
						polygonData3.#dwc(#BP3);
					}
				}
				while (8 == 0);
				if (!BooleanOperationsHelper.#9W(polygonData2))
				{
					#rEc.Add(#rP);
					return false;
				}
				#uEc.Add(#rP);
				return true;
			}
			return true;
		}

		// Token: 0x06005FFB RID: 24571 RVA: 0x0017BC9C File Offset: 0x00179E9C
		private static void #vEc(ShapeDataModel #wEc)
		{
			do
			{
				IEnumerator<PolygonData> enumerator = #wEc.Polygons.GetEnumerator();
				IEnumerator<PolygonData> enumerator2;
				if (!false)
				{
					enumerator2 = enumerator;
				}
				try
				{
					for (;;)
					{
						if (!enumerator2.MoveNext())
						{
							goto IL_28;
						}
						IL_11:
						if (!false)
						{
							PolygonData polygonData = enumerator2.Current;
							PolygonType polygonType = PolygonType.Undefined;
							if (false)
							{
								continue;
							}
							polygonData.PolygonType = polygonType;
							continue;
						}
						IL_28:
						if (!false)
						{
							break;
						}
						goto IL_11;
					}
				}
				finally
				{
					if (enumerator2 != null)
					{
						enumerator2.Dispose();
					}
				}
			}
			while (false);
		}

		// Token: 0x06005FFC RID: 24572 RVA: 0x0017BD00 File Offset: 0x00179F00
		private ShapeDataModel #xEc(ShapesIntersectionResult #yEc, PolygonData #zEc)
		{
			if (#yEc == null || #zEc == null)
			{
				return null;
			}
			IBulkUpdateScope bulkUpdateScope = this.ModelEditorViewModel.View.ModelVisualizationControl.TransparencySorter.BeginBulkUpdate();
			IBulkUpdateScope bulkUpdateScope2;
			if (!false)
			{
				bulkUpdateScope2 = bulkUpdateScope;
			}
			try
			{
				Dictionary<ShapesIntersectionResult, ShapeDataModel> dictionary = new Dictionary<ShapesIntersectionResult, ShapeDataModel>();
				Dictionary<ShapesIntersectionResult, ShapeDataModel> dictionary2;
				if (4 != 0)
				{
					dictionary2 = dictionary;
				}
				ShapeDataModel shapeDataModel = new ShapeDataModel(this.UndoManager, #yEc.ShapeGeometryData, this.AssignmentsFactory);
				ShapeDataModel shapeDataModel2;
				if (2 != 0)
				{
					shapeDataModel2 = shapeDataModel;
				}
				bool flag2;
				bool flag = flag2 = BooleanOperationsHelper.#5lc(shapeDataModel2, new PolygonData[]
				{
					#zEc
				});
				ShapeDataModel shapeDataModel5;
				if (4 != 0)
				{
					if (!flag)
					{
						ShapeDataModel shapeDataModel3 = null;
						ShapeDataModel result;
						if (!false)
						{
							result = shapeDataModel3;
						}
						return result;
					}
					Dictionary<ShapesIntersectionResult, ShapeDataModel> dictionary3 = dictionary2;
					ShapeDataModel value = shapeDataModel2;
					if (3 != 0)
					{
						dictionary3.Add(#yEc, value);
					}
					ShapeDataModel shapeDataModel4 = (ShapeDataModel)dictionary2.Keys.First<ShapesIntersectionResult>().ShapeGeometryData;
					if (5 != 0)
					{
						shapeDataModel5 = shapeDataModel4;
					}
					dictionary2.Values.First<ShapeDataModel>().#dxc(shapeDataModel5);
					flag2 = shapeDataModel5.Polygons.Any<PolygonData>();
				}
				if (flag2)
				{
					return shapeDataModel5;
				}
			}
			finally
			{
				do
				{
					if (bulkUpdateScope2 != null)
					{
						bulkUpdateScope2.Dispose();
					}
				}
				while (false);
			}
			return null;
		}

		// Token: 0x04002784 RID: 10116
		private const double #a = 0.001;

		// Token: 0x04002785 RID: 10117
		private const double #b = 1E-06;

		// Token: 0x04002786 RID: 10118
		private readonly #5Ic #c;

		// Token: 0x04002787 RID: 10119
		private readonly #5Kc #d;

		// Token: 0x04002788 RID: 10120
		private readonly #OWc #e;

		// Token: 0x04002789 RID: 10121
		[CompilerGenerated]
		private #oW #f;

		// Token: 0x0400278A RID: 10122
		[CompilerGenerated]
		private #V0c #g;

		// Token: 0x0400278B RID: 10123
		[CompilerGenerated]
		private #bDc #h;

		// Token: 0x0400278C RID: 10124
		[CompilerGenerated]
		private #1Wc #i;

		// Token: 0x02000B7C RID: 2940
		[CompilerGenerated]
		private sealed class #ZXb
		{
			// Token: 0x0600600D RID: 24589 RVA: 0x0004F775 File Offset: 0x0004D975
			internal bool #T8c(ShapeDataModel #Rf)
			{
				return #Rf != this.#a;
			}

			// Token: 0x0400279B RID: 10139
			public ShapeDataModel #a;
		}

		// Token: 0x02000B7D RID: 2941
		[CompilerGenerated]
		private sealed class #NTb
		{
			// Token: 0x0600600F RID: 24591 RVA: 0x0004F783 File Offset: 0x0004D983
			internal bool #U8c(PolygonData #V8c)
			{
				return !this.#a.#0Dc(#V8c, this.#b);
			}

			// Token: 0x0400279C RID: 10140
			public ToolOperationsHelper #a;

			// Token: 0x0400279D RID: 10141
			public HashSet<PolygonData> #b;
		}

		// Token: 0x02000B7E RID: 2942
		[CompilerGenerated]
		private sealed class #KTb
		{
			// Token: 0x06006011 RID: 24593 RVA: 0x0004F79A File Offset: 0x0004D99A
			internal bool #U8c(ShapeDataModel #Rf)
			{
				int num2;
				int num = num2 = #Rf.PolygonsCount;
				int num3 = 1;
				bool result;
				int num6;
				do
				{
					int num5;
					int num4 = num5 = num3;
					if (num4 != 0)
					{
						if (num2 != num4)
						{
							return true;
						}
						num = (num2 = ((result = this.#a.Contains(#Rf.#cxc(0))) ? 1 : 0));
						if (7 == 0)
						{
							return result;
						}
						num5 = 0;
					}
					num6 = (num3 = num5);
				}
				while (num6 != 0);
				result = (num == num6);
				return result;
			}

			// Token: 0x06006012 RID: 24594 RVA: 0x0004F7C5 File Offset: 0x0004D9C5
			internal ShapeDataModel #W8c(ShapeDataModel #Rf)
			{
				return new ShapeDataModel(this.#b.UndoManager, #Rf, this.#b.AssignmentsFactory);
			}

			// Token: 0x0400279E RID: 10142
			public HashSet<PolygonData> #a;

			// Token: 0x0400279F RID: 10143
			public ToolOperationsHelper #b;
		}

		// Token: 0x02000B7F RID: 2943
		[CompilerGenerated]
		private sealed class #yZb
		{
			// Token: 0x06006014 RID: 24596 RVA: 0x0004F7E3 File Offset: 0x0004D9E3
			internal bool #U8c(PolygonData #Rf)
			{
				return #Rf != this.#a;
			}

			// Token: 0x040027A0 RID: 10144
			public PolygonData #a;
		}

		// Token: 0x02000B80 RID: 2944
		[CompilerGenerated]
		private sealed class #cWb
		{
			// Token: 0x06006016 RID: 24598 RVA: 0x0004F7F1 File Offset: 0x0004D9F1
			internal bool #U8c(ShapeDataModel #Rf)
			{
				return #Rf != this.#a;
			}

			// Token: 0x040027A1 RID: 10145
			public ShapeDataModel #a;
		}

		// Token: 0x02000B81 RID: 2945
		[CompilerGenerated]
		private sealed class #CZb
		{
			// Token: 0x06006018 RID: 24600 RVA: 0x0004F7FF File Offset: 0x0004D9FF
			internal double #X8c(Point3D #Rf)
			{
				return GeometryHelper.#lcb(#Rf, this.#a);
			}

			// Token: 0x040027A2 RID: 10146
			public Point3D #a;
		}

		// Token: 0x02000B82 RID: 2946
		[CompilerGenerated]
		private sealed class #p6b
		{
			// Token: 0x0600601A RID: 24602 RVA: 0x0004F80D File Offset: 0x0004DA0D
			internal <>f__AnonymousType2<SegmentData, double?> #X8c(SegmentData #PP)
			{
				return new
				{
					Segment = #PP,
					Distance = #jsc.#lcb(#PP, this.#a)
				};
			}

			// Token: 0x040027A3 RID: 10147
			public Point #a;
		}

		// Token: 0x02000B83 RID: 2947
		[CompilerGenerated]
		private sealed class #R7b
		{
			// Token: 0x0600601C RID: 24604 RVA: 0x0004F821 File Offset: 0x0004DA21
			internal <>f__AnonymousType3<NodeModel, NodeModel> #Y8c(NodeModel #Z8c)
			{
				return new
				{
					loopSelectedObject = #Z8c,
					node = this.#a.#F1d(#Z8c.Location)
				};
			}

			// Token: 0x040027A4 RID: 10148
			public Dictionary<Point, NodeModel> #a;
		}

		// Token: 0x02000B84 RID: 2948
		[CompilerGenerated]
		private sealed class #0Ub
		{
			// Token: 0x0600601E RID: 24606 RVA: 0x0017BE04 File Offset: 0x0017A004
			internal bool #08c(LinearObject #Rf)
			{
				ToolOperationsHelper.#28c #28c = new ToolOperationsHelper.#28c();
				ToolOperationsHelper.#28c #28c2;
				if (!false)
				{
					#28c2 = #28c;
				}
				#28c2.#a = #Rf;
				return this.#a.Any(new Func<NodeModel, bool>(#28c2.#18c));
			}

			// Token: 0x040027A5 RID: 10149
			public IList<NodeModel> #a;
		}

		// Token: 0x02000B85 RID: 2949
		[CompilerGenerated]
		private sealed class #28c
		{
			// Token: 0x06006020 RID: 24608 RVA: 0x0004F83A File Offset: 0x0004DA3A
			internal bool #18c(NodeModel #uXb)
			{
				return this.#a.#lwc(#uXb.Location);
			}

			// Token: 0x040027A6 RID: 10150
			public LinearObject #a;
		}

		// Token: 0x02000B86 RID: 2950
		[CompilerGenerated]
		private sealed class #SUb
		{
			// Token: 0x06006022 RID: 24610 RVA: 0x0017BE3C File Offset: 0x0017A03C
			internal <>f__AnonymousType4<ShapeDataModel, IList<ShapesIntersectionResult>> #38c(ShapeDataModel #rP)
			{
				ToolOperationsHelper.#TUb #TUb = new ToolOperationsHelper.#TUb();
				ToolOperationsHelper.#TUb #TUb2;
				if (-1 != 0)
				{
					#TUb2 = #TUb;
				}
				#TUb2.#a = #rP;
				return new
				{
					shape = #TUb2.#a,
					intersections = BooleanOperationsHelper.#CP(#TUb2.#a, this.#a.Shapes.Where(new Func<ShapeDataModel, bool>(#TUb2.#48c)).ToList<ShapeDataModel>())
				};
			}

			// Token: 0x040027A7 RID: 10151
			public #WWc #a;
		}

		// Token: 0x02000B87 RID: 2951
		[CompilerGenerated]
		private sealed class #TUb
		{
			// Token: 0x06006024 RID: 24612 RVA: 0x0004F84D File Offset: 0x0004DA4D
			internal bool #48c(ShapeDataModel #Rf)
			{
				return #Rf != this.#a;
			}

			// Token: 0x040027A8 RID: 10152
			public ShapeDataModel #a;
		}

		// Token: 0x02000B88 RID: 2952
		[CompilerGenerated]
		private sealed class #kWb
		{
			// Token: 0x06006026 RID: 24614 RVA: 0x0004F85B File Offset: 0x0004DA5B
			internal bool #58c(ShapeDataModel #Rf)
			{
				return #Rf != this.#a;
			}

			// Token: 0x06006027 RID: 24615 RVA: 0x0017BE94 File Offset: 0x0017A094
			internal bool #68c(NodeModel #uXb)
			{
				ToolOperationsHelper.#Q6b #Q6b = new ToolOperationsHelper.#Q6b();
				ToolOperationsHelper.#Q6b #Q6b2;
				if (!false)
				{
					#Q6b2 = #Q6b;
				}
				#Q6b2.#a = #uXb;
				return #Q6b2.#a.NodeType == #IXc.#a && this.#b.Any(new Func<Point, bool>(#Q6b2.#78c)) && (!this.#c || !this.#d.Any(new Func<Point, bool>(#Q6b2.#88c)));
			}

			// Token: 0x040027A9 RID: 10153
			public ShapeDataModel #a;

			// Token: 0x040027AA RID: 10154
			public HashSet<Point> #b;

			// Token: 0x040027AB RID: 10155
			public bool #c;

			// Token: 0x040027AC RID: 10156
			public HashSet<Point> #d;
		}

		// Token: 0x02000B89 RID: 2953
		[CompilerGenerated]
		private sealed class #Q6b
		{
			// Token: 0x06006029 RID: 24617 RVA: 0x0004F869 File Offset: 0x0004DA69
			internal bool #78c(Point #Ng)
			{
				return PointsConverter.#uC(#Ng, this.#a.Location);
			}

			// Token: 0x0600602A RID: 24618 RVA: 0x0004F869 File Offset: 0x0004DA69
			internal bool #88c(Point #Ng)
			{
				return PointsConverter.#uC(#Ng, this.#a.Location);
			}

			// Token: 0x040027AD RID: 10157
			public NodeModel #a;
		}
	}
}
