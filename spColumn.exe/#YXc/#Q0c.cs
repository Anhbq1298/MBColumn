using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using #7hc;
using #T0c;
using #UYd;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;
using StructurePoint.CoreAssets.GUI.Framework.Model.Entities;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace #YXc
{
	// Token: 0x02000CAB RID: 3243
	internal static class #Q0c
	{
		// Token: 0x060069D9 RID: 27097 RVA: 0x0019ACA8 File Offset: 0x00198EA8
		public static void #KZc(IEnumerable<GridLineDefinitionModel> #ooc, #U0c #Ee, HashSet<GridLineDefinitionModel> #4Xc, Action #J0c)
		{
			string #R0d = #Phc.#3hc(107368337);
			Component #x6c = Component.GUIFramework;
			string #Qic = #Phc.#3hc(107434001);
			if (!false)
			{
				#X0d.#V0d(#ooc, #R0d, #x6c, #Qic);
			}
			string #R0d2 = #Phc.#3hc(107407466);
			Component #x6c2 = Component.GUIFramework;
			string #Qic2 = #Phc.#3hc(107434460);
			if (4 != 0)
			{
				#X0d.#V0d(#Ee, #R0d2, #x6c2, #Qic2);
			}
			string #R0d3 = #Phc.#3hc(107437943);
			Component #x6c3 = Component.GUIFramework;
			string #Qic3 = #Phc.#3hc(107434375);
			if (4 != 0)
			{
				#X0d.#V0d(#4Xc, #R0d3, #x6c3, #Qic3);
			}
			string #R0d4 = #Phc.#3hc(107434354);
			Component #x6c4 = Component.GUIFramework;
			string #Qic4 = #Phc.#3hc(107434333);
			if (!false)
			{
				#X0d.#V0d(#J0c, #R0d4, #x6c4, #Qic4);
			}
			IBulkUpdateScope bulkUpdateScope = #Ee.ModelVisualizationControl.TransparencySorter.BeginBulkUpdate();
			IBulkUpdateScope bulkUpdateScope2;
			if (!false)
			{
				bulkUpdateScope2 = bulkUpdateScope;
			}
			try
			{
				bool flag = false;
				bool flag2;
				if (!false)
				{
					flag2 = flag;
				}
				IEnumerator<GridLineDefinitionModel> enumerator = #ooc.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						GridLineDefinitionModel item = enumerator.Current;
						if (#4Xc.Add(item))
						{
							flag2 = true;
						}
					}
				}
				finally
				{
					if (false || enumerator != null)
					{
						enumerator.Dispose();
					}
				}
				if (flag2)
				{
					#J0c();
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
				while (3 == 0);
			}
		}

		// Token: 0x060069DA RID: 27098 RVA: 0x0019ADEC File Offset: 0x00198FEC
		public static void #LZc(IEnumerable<GridLineDefinitionModel> #ooc, HashSet<GridLineDefinitionModel> #4Xc, Action #J0c)
		{
			bool flag2;
			if (2 != 0)
			{
				string #R0d = #Phc.#3hc(107368337);
				Component #x6c = Component.GUIFramework;
				string #Qic = #Phc.#3hc(107434248);
				if (!false)
				{
					#X0d.#V0d(#ooc, #R0d, #x6c, #Qic);
				}
				string #R0d2 = #Phc.#3hc(107437943);
				Component #x6c2 = Component.GUIFramework;
				string #Qic2 = #Phc.#3hc(107433715);
				if (6 != 0)
				{
					#X0d.#V0d(#4Xc, #R0d2, #x6c2, #Qic2);
				}
				string #R0d3 = #Phc.#3hc(107434354);
				Component #x6c3 = Component.GUIFramework;
				string #Qic3 = #Phc.#3hc(107433662);
				if (true)
				{
					#X0d.#V0d(#J0c, #R0d3, #x6c3, #Qic3);
				}
				bool flag = false;
				if (4 != 0)
				{
					flag2 = flag;
				}
			}
			IEnumerator<GridLineDefinitionModel> enumerator = #ooc.GetEnumerator();
			IEnumerator<GridLineDefinitionModel> enumerator2;
			if (!false)
			{
				enumerator2 = enumerator;
			}
			try
			{
				while (enumerator2.MoveNext() || false)
				{
					GridLineDefinitionModel gridLineDefinitionModel = enumerator2.Current;
					GridLineDefinitionModel item;
					if (!false)
					{
						item = gridLineDefinitionModel;
					}
					int num = #4Xc.Remove(item) ? 1 : 0;
					while (num != 0)
					{
						int num2 = num = 1;
						if (num2 != 0)
						{
							flag2 = (num2 != 0);
							break;
						}
					}
				}
			}
			finally
			{
				while (enumerator2 != null)
				{
					if (2 != 0)
					{
						enumerator2.Dispose();
						break;
					}
				}
			}
			if (flag2)
			{
				#J0c();
			}
		}

		// Token: 0x060069DB RID: 27099 RVA: 0x0019AEF0 File Offset: 0x001990F0
		public static Point3D? #MZc(GridLineDefinitionModel #bsc, HashSet<IAnnotationDrawingResult> #AYc)
		{
			#Q0c.#wbc #wbc2;
			while (4 != 0)
			{
				#Q0c.#wbc #wbc = new #Q0c.#wbc();
				if (!false)
				{
					#wbc2 = #wbc;
				}
				if (4 == 0)
				{
					IL_72:
					return null;
				}
				#wbc2.#a = #bsc;
				if (6 != 0)
				{
					object #a = #wbc2.#a;
					string #R0d = #Phc.#3hc(107364483);
					Component #x6c = Component.GUIFramework;
					string #Qic = #Phc.#3hc(107433577);
					if (!false)
					{
						#X0d.#V0d(#a, #R0d, #x6c, #Qic);
					}
				}
				if (7 != 0)
				{
					string #R0d2 = #Phc.#3hc(107433556);
					Component #x6c2 = Component.GUIFramework;
					string #Qic2 = #Phc.#3hc(107433479);
					if (false)
					{
						break;
					}
					#X0d.#V0d(#AYc, #R0d2, #x6c2, #Qic2);
					break;
				}
			}
			if (string.IsNullOrWhiteSpace(#wbc2.#a.Label))
			{
				goto IL_72;
			}
			return new Point3D?(#AYc.First(new Func<IAnnotationDrawingResult, bool>(#wbc2.#Rbd)).Position);
		}

		// Token: 0x060069DC RID: 27100 RVA: 0x0019AFAC File Offset: 0x001991AC
		public static void #VZc(IReadOnlyList<ShapeDataModel> #6Y, #U0c #Ee, Action<ShapeDataModel> #K0c)
		{
			while (2 != 0)
			{
				string #R0d = #Phc.#3hc(107372113);
				Component #x6c = Component.GUIFramework;
				string #Qic = #Phc.#3hc(107433970);
				if (!false)
				{
					#X0d.#V0d(#6Y, #R0d, #x6c, #Qic);
				}
				string #R0d2 = #Phc.#3hc(107407466);
				Component #x6c2 = Component.GUIFramework;
				string #Qic2 = #Phc.#3hc(107433917);
				if (!false)
				{
					#X0d.#V0d(#Ee, #R0d2, #x6c2, #Qic2);
				}
				if (2 != 0)
				{
					string #R0d3 = #Phc.#3hc(107433832);
					Component #x6c3 = Component.GUIFramework;
					string #Qic3 = #Phc.#3hc(107433851);
					if (false)
					{
						break;
					}
					#X0d.#V0d(#K0c, #R0d3, #x6c3, #Qic3);
					break;
				}
			}
			IBulkUpdateScope bulkUpdateScope = #Ee.ModelVisualizationControl.TransparencySorter.BeginBulkUpdate();
			IBulkUpdateScope bulkUpdateScope2;
			if (7 != 0)
			{
				bulkUpdateScope2 = bulkUpdateScope;
			}
			try
			{
				using (IEnumerator<ShapeDataModel> enumerator = #6Y.GetEnumerator())
				{
					while (enumerator.MoveNext() || false)
					{
						ShapeDataModel shapeDataModel2;
						if (7 != 0)
						{
							ShapeDataModel shapeDataModel = enumerator.Current;
							if (!false)
							{
								shapeDataModel2 = shapeDataModel;
							}
						}
						ShapeDataModel obj = shapeDataModel2;
						if (8 != 0)
						{
							#K0c(obj);
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
		}

		// Token: 0x060069DD RID: 27101 RVA: 0x0019B0C0 File Offset: 0x001992C0
		public static void #WZc(IReadOnlyList<ShapeDataModel> #6Y, #U0c #Ee, Action<ShapeDataModel> #L0c)
		{
			while (2 != 0)
			{
				string #R0d = #Phc.#3hc(107372113);
				Component #x6c = Component.GUIFramework;
				string #Qic = #Phc.#3hc(107433766);
				if (!false)
				{
					#X0d.#V0d(#6Y, #R0d, #x6c, #Qic);
				}
				string #R0d2 = #Phc.#3hc(107407466);
				Component #x6c2 = Component.GUIFramework;
				string #Qic2 = #Phc.#3hc(107433745);
				if (!false)
				{
					#X0d.#V0d(#Ee, #R0d2, #x6c2, #Qic2);
				}
				if (2 != 0)
				{
					string #R0d3 = #Phc.#3hc(107433180);
					Component #x6c3 = Component.GUIFramework;
					string #Qic3 = #Phc.#3hc(107433123);
					if (false)
					{
						break;
					}
					#X0d.#V0d(#L0c, #R0d3, #x6c3, #Qic3);
					break;
				}
			}
			IBulkUpdateScope bulkUpdateScope = #Ee.ModelVisualizationControl.TransparencySorter.BeginBulkUpdate();
			IBulkUpdateScope bulkUpdateScope2;
			if (7 != 0)
			{
				bulkUpdateScope2 = bulkUpdateScope;
			}
			try
			{
				using (IEnumerator<ShapeDataModel> enumerator = #6Y.GetEnumerator())
				{
					while (enumerator.MoveNext() || false)
					{
						ShapeDataModel shapeDataModel2;
						if (7 != 0)
						{
							ShapeDataModel shapeDataModel = enumerator.Current;
							if (!false)
							{
								shapeDataModel2 = shapeDataModel;
							}
						}
						ShapeDataModel obj = shapeDataModel2;
						if (8 != 0)
						{
							#L0c(obj);
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
		}

		// Token: 0x060069DE RID: 27102 RVA: 0x0019B1D4 File Offset: 0x001993D4
		public static void #XZc(IReadOnlyList<ShapeDataModel> #6Y, #U0c #Ee, Action<ShapeDataModel> #M0c)
		{
			while (2 != 0)
			{
				string #R0d = #Phc.#3hc(107372113);
				Component #x6c = Component.GUIFramework;
				string #Qic = #Phc.#3hc(107433070);
				if (!false)
				{
					#X0d.#V0d(#6Y, #R0d, #x6c, #Qic);
				}
				string #R0d2 = #Phc.#3hc(107407466);
				Component #x6c2 = Component.GUIFramework;
				string #Qic2 = #Phc.#3hc(107433049);
				if (!false)
				{
					#X0d.#V0d(#Ee, #R0d2, #x6c2, #Qic2);
				}
				if (2 != 0)
				{
					string #R0d3 = #Phc.#3hc(107432964);
					Component #x6c3 = Component.GUIFramework;
					string #Qic3 = #Phc.#3hc(107433443);
					if (false)
					{
						break;
					}
					#X0d.#V0d(#M0c, #R0d3, #x6c3, #Qic3);
					break;
				}
			}
			IBulkUpdateScope bulkUpdateScope = #Ee.ModelVisualizationControl.TransparencySorter.BeginBulkUpdate();
			IBulkUpdateScope bulkUpdateScope2;
			if (7 != 0)
			{
				bulkUpdateScope2 = bulkUpdateScope;
			}
			try
			{
				using (IEnumerator<ShapeDataModel> enumerator = #6Y.GetEnumerator())
				{
					while (enumerator.MoveNext() || false)
					{
						ShapeDataModel shapeDataModel2;
						if (7 != 0)
						{
							ShapeDataModel shapeDataModel = enumerator.Current;
							if (!false)
							{
								shapeDataModel2 = shapeDataModel;
							}
						}
						ShapeDataModel obj = shapeDataModel2;
						if (8 != 0)
						{
							#M0c(obj);
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
		}

		// Token: 0x060069DF RID: 27103 RVA: 0x0019B2E8 File Offset: 0x001994E8
		public static void #8ob(ShapeDataModel #XDc, #U0c #Ee, Action<ShapeDataModel> #N0c)
		{
			string #R0d = #Phc.#3hc(107435029);
			Component #x6c = Component.GUIFramework;
			string #Qic = #Phc.#3hc(107433390);
			if (-1 != 0)
			{
				#X0d.#V0d(#XDc, #R0d, #x6c, #Qic);
			}
			string #R0d2 = #Phc.#3hc(107407466);
			Component #x6c2 = Component.GUIFramework;
			string #Qic2 = #Phc.#3hc(107433369);
			if (4 != 0)
			{
				#X0d.#V0d(#Ee, #R0d2, #x6c2, #Qic2);
			}
			string #R0d3 = #Phc.#3hc(107447757);
			Component #x6c3 = Component.GUIFramework;
			string #Qic3 = #Phc.#3hc(107433284);
			if (4 != 0)
			{
				#X0d.#V0d(#N0c, #R0d3, #x6c3, #Qic3);
			}
			IBulkUpdateScope bulkUpdateScope = #Ee.ModelVisualizationControl.TransparencySorter.BeginBulkUpdate();
			IBulkUpdateScope bulkUpdateScope2;
			if (!false)
			{
				bulkUpdateScope2 = bulkUpdateScope;
			}
			try
			{
				if (true)
				{
					#N0c(#XDc);
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

		// Token: 0x060069E0 RID: 27104 RVA: 0x0019B3A8 File Offset: 0x001995A8
		public static void #YZc(ShapeDataModel #XDc, #U0c #Ee, Action<ShapeDataModel> #O0c)
		{
			string #R0d = #Phc.#3hc(107435029);
			Component #x6c = Component.GUIFramework;
			string #Qic = #Phc.#3hc(107433231);
			if (-1 != 0)
			{
				#X0d.#V0d(#XDc, #R0d, #x6c, #Qic);
			}
			string #R0d2 = #Phc.#3hc(107407466);
			Component #x6c2 = Component.GUIFramework;
			string #Qic2 = #Phc.#3hc(107432698);
			if (4 != 0)
			{
				#X0d.#V0d(#Ee, #R0d2, #x6c2, #Qic2);
			}
			string #R0d3 = #Phc.#3hc(107432613);
			Component #x6c3 = Component.GUIFramework;
			string #Qic3 = #Phc.#3hc(107432604);
			if (4 != 0)
			{
				#X0d.#V0d(#O0c, #R0d3, #x6c3, #Qic3);
			}
			IBulkUpdateScope bulkUpdateScope = #Ee.ModelVisualizationControl.TransparencySorter.BeginBulkUpdate();
			IBulkUpdateScope bulkUpdateScope2;
			if (!false)
			{
				bulkUpdateScope2 = bulkUpdateScope;
			}
			try
			{
				if (true)
				{
					#O0c(#XDc);
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

		// Token: 0x060069E1 RID: 27105 RVA: 0x0019B468 File Offset: 0x00199668
		public static void #8ob(IEnumerable<ShapeDataModel> #6Y, #U0c #Ee, Action<ShapeDataModel> #N0c)
		{
			do
			{
				string #R0d = #Phc.#3hc(107372113);
				Component #x6c = Component.GUIFramework;
				string #Qic = #Phc.#3hc(107432519);
				if (true)
				{
					#X0d.#V0d(#6Y, #R0d, #x6c, #Qic);
				}
			}
			while (false);
			if (!false)
			{
				string #R0d2 = #Phc.#3hc(107407466);
				Component #x6c2 = Component.GUIFramework;
				string #Qic2 = #Phc.#3hc(107432498);
				if (!false)
				{
					#X0d.#V0d(#Ee, #R0d2, #x6c2, #Qic2);
				}
				string #R0d3 = #Phc.#3hc(107447757);
				Component #x6c3 = Component.GUIFramework;
				string #Qic3 = #Phc.#3hc(107432957);
				if (!false)
				{
					#X0d.#V0d(#N0c, #R0d3, #x6c3, #Qic3);
				}
			}
			IList<ShapeDataModel> list;
			if ((list = (#6Y as IList<ShapeDataModel>)) == null)
			{
				list = #6Y.ToList<ShapeDataModel>();
			}
			IList<ShapeDataModel> list2;
			if (4 != 0)
			{
				list2 = list;
			}
			IBulkUpdateScope bulkUpdateScope = #Ee.ModelVisualizationControl.TransparencySorter.BeginBulkUpdate();
			IBulkUpdateScope bulkUpdateScope2;
			if (!false)
			{
				bulkUpdateScope2 = bulkUpdateScope;
			}
			try
			{
				using (IEnumerator<ShapeDataModel> enumerator = list2.GetEnumerator())
				{
					for (;;)
					{
						ShapeDataModel obj;
						if (!false)
						{
							if (!enumerator.MoveNext())
							{
								break;
							}
							ShapeDataModel shapeDataModel = enumerator.Current;
							if (!false)
							{
								obj = shapeDataModel;
							}
						}
						#N0c(obj);
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

		// Token: 0x060069E2 RID: 27106 RVA: 0x0019B590 File Offset: 0x00199790
		public static void #ZZc(IEnumerable<ShapeDataModel> #6Y, #U0c #Ee, Action<ShapeDataModel> #O0c)
		{
			do
			{
				string #R0d = #Phc.#3hc(107372113);
				Component #x6c = Component.GUIFramework;
				string #Qic = #Phc.#3hc(107432872);
				if (true)
				{
					#X0d.#V0d(#6Y, #R0d, #x6c, #Qic);
				}
			}
			while (false);
			if (!false)
			{
				string #R0d2 = #Phc.#3hc(107407466);
				Component #x6c2 = Component.GUIFramework;
				string #Qic2 = #Phc.#3hc(107432851);
				if (!false)
				{
					#X0d.#V0d(#Ee, #R0d2, #x6c2, #Qic2);
				}
				string #R0d3 = #Phc.#3hc(107432613);
				Component #x6c3 = Component.GUIFramework;
				string #Qic3 = #Phc.#3hc(107432798);
				if (!false)
				{
					#X0d.#V0d(#O0c, #R0d3, #x6c3, #Qic3);
				}
			}
			IList<ShapeDataModel> list;
			if ((list = (#6Y as IList<ShapeDataModel>)) == null)
			{
				list = #6Y.ToList<ShapeDataModel>();
			}
			IList<ShapeDataModel> list2;
			if (4 != 0)
			{
				list2 = list;
			}
			IBulkUpdateScope bulkUpdateScope = #Ee.ModelVisualizationControl.TransparencySorter.BeginBulkUpdate();
			IBulkUpdateScope bulkUpdateScope2;
			if (!false)
			{
				bulkUpdateScope2 = bulkUpdateScope;
			}
			try
			{
				using (IEnumerator<ShapeDataModel> enumerator = list2.GetEnumerator())
				{
					for (;;)
					{
						ShapeDataModel obj;
						if (!false)
						{
							if (!enumerator.MoveNext())
							{
								break;
							}
							ShapeDataModel shapeDataModel = enumerator.Current;
							if (!false)
							{
								obj = shapeDataModel;
							}
						}
						#O0c(obj);
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

		// Token: 0x060069E3 RID: 27107 RVA: 0x0019B6B8 File Offset: 0x001998B8
		public static void #0Zc(IEnumerable<ShapeDataModel> #rP, #U0c #Ee, Action<ShapeDataModel> #P0c)
		{
			while (2 != 0)
			{
				string #R0d = #Phc.#3hc(107371527);
				Component #x6c = Component.GUIFramework;
				string #Qic = #Phc.#3hc(107432713);
				if (!false)
				{
					#X0d.#V0d(#rP, #R0d, #x6c, #Qic);
				}
				string #R0d2 = #Phc.#3hc(107407466);
				Component #x6c2 = Component.GUIFramework;
				string #Qic2 = #Phc.#3hc(107432180);
				if (!false)
				{
					#X0d.#V0d(#Ee, #R0d2, #x6c2, #Qic2);
				}
				if (2 != 0)
				{
					string #R0d3 = #Phc.#3hc(107432127);
					Component #x6c3 = Component.GUIFramework;
					string #Qic3 = #Phc.#3hc(107432078);
					if (false)
					{
						break;
					}
					#X0d.#V0d(#P0c, #R0d3, #x6c3, #Qic3);
					break;
				}
			}
			IBulkUpdateScope bulkUpdateScope = #Ee.ModelVisualizationControl.TransparencySorter.BeginBulkUpdate();
			IBulkUpdateScope bulkUpdateScope2;
			if (7 != 0)
			{
				bulkUpdateScope2 = bulkUpdateScope;
			}
			try
			{
				using (IEnumerator<ShapeDataModel> enumerator = #rP.GetEnumerator())
				{
					while (enumerator.MoveNext() || false)
					{
						ShapeDataModel shapeDataModel2;
						if (7 != 0)
						{
							ShapeDataModel shapeDataModel = enumerator.Current;
							if (!false)
							{
								shapeDataModel2 = shapeDataModel;
							}
						}
						ShapeDataModel obj = shapeDataModel2;
						if (8 != 0)
						{
							#P0c(obj);
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
		}

		// Token: 0x02000CAC RID: 3244
		[CompilerGenerated]
		private sealed class #wbc
		{
			// Token: 0x060069E5 RID: 27109 RVA: 0x00053C83 File Offset: 0x00051E83
			internal bool #Rbd(IAnnotationDrawingResult #Rf)
			{
				return #Rf.Text == this.#a.Label;
			}

			// Token: 0x04002B57 RID: 11095
			public GridLineDefinitionModel #a;
		}
	}
}
