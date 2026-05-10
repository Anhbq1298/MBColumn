using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using #7hc;
using #npe;
using #qJ;
using #v1c;
using NetTopologySuite.Geometries;
using NetTopologySuite.Utilities;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Other;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Units;
using StructurePoint.Products.Column.Model;

namespace #Z
{
	// Token: 0x02000011 RID: 17
	internal static class #Y
	{
		// Token: 0x06000054 RID: 84 RVA: 0x00084DFC File Offset: 0x00082FFC
		public static void #P()
		{
			EyeshotInitializer instance = EyeshotInitializer.Instance;
			string name = #Phc.#3hc(107396143);
			Action initializer;
			if ((initializer = #Y.#2Ui.#a) == null)
			{
				initializer = (#Y.#2Ui.#a = new Action(#Y.#U));
			}
			instance.Register(name, initializer);
			EyeshotInitializer instance2 = EyeshotInitializer.Instance;
			string name2 = #Phc.#3hc(107396146);
			Action initializer2;
			if ((initializer2 = #Y.#2Ui.#b) == null)
			{
				initializer2 = (#Y.#2Ui.#b = new Action(#Y.#T));
			}
			instance2.Register(name2, initializer2);
			EyeshotInitializer instance3 = EyeshotInitializer.Instance;
			string name3 = #Phc.#3hc(107396117);
			Action initializer3;
			if ((initializer3 = #Y.#2Ui.#c) == null)
			{
				initializer3 = (#Y.#2Ui.#c = new Action(#Y.#V));
			}
			instance3.Register(name3, initializer3);
		}

		// Token: 0x06000055 RID: 85 RVA: 0x000032C7 File Offset: 0x000014C7
		private static void #Q()
		{
			#E1c.#z1c(AppDomain.CurrentDomain.BaseDirectory);
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00084EB4 File Offset: 0x000830B4
		private static void #R(string[] #S)
		{
			foreach (string assemblyName in #S)
			{
				try
				{
					AppDomain.CurrentDomain.Load(new AssemblyName(assemblyName));
				}
				catch
				{
				}
			}
		}

		// Token: 0x06000057 RID: 87 RVA: 0x000032E4 File Offset: 0x000014E4
		private static void #T()
		{
			#Y.#R(#Y.#b);
		}

		// Token: 0x06000058 RID: 88 RVA: 0x000032F4 File Offset: 0x000014F4
		private static void #U()
		{
			#Y.#R(#Y.#a);
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00084F08 File Offset: 0x00083108
		private static void #V()
		{
			#Y.#Q();
			Coordinate coordinate = new Coordinate();
			Assert.IsTrue(coordinate.X == 0.0);
			BoundingBoxData boundingBoxData = new BoundingBoxData(new StructurePoint.CoreAssets.Infrastructure.Data.Point(0.0, 0.0), new StructurePoint.CoreAssets.Infrastructure.Data.Point(10.0, 10.0));
			Assert.IsTrue(Math.Abs(boundingBoxData.Width - 10.0) <= 0.0);
			PolygonData polygonData = new PolygonData(new List<Point3D>
			{
				new Point3D(0.0, 0.0),
				new Point3D(10.0, 0.0),
				new Point3D(10.0, 10.0),
				new Point3D(0.0, 10.0),
				new Point3D(0.0, 0.0)
			});
			Assert.IsTrue(polygonData.#twc() != null);
			ColumnStorageModel columnStorageModel = new ColumnStorageModel
			{
				Options = 
				{
					ProblemType = ProblemType.Investigation,
					Code = DesignCodes.ACI19,
					Unit = UnitSystem.USCustomary,
					SectionType = SectionType.Rectangle
				},
				BarGroupType = BarGroupType.ASTM615
			};
			columnStorageModel.Bars.AddRange(#mpe.#bpe(columnStorageModel.BarGroupType, columnStorageModel.Options.Unit));
			#Y.#W(columnStorageModel);
			ColumnModel #Od = new ColumnModel(columnStorageModel);
			ColumnModelHelper.#2W(new #RP(), #Od);
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00003304 File Offset: 0x00001504
		private static void #W(ColumnStorageModel #X)
		{
			#X.DraftingSettings = DraftingSettings.Default(#X.Options.Unit);
			#wpe.#xkb(#X);
			#Wpe.#xkb(#X);
			#wpe.#qpe(#X);
		}

		// Token: 0x0400001C RID: 28
		private static readonly string[] #a = new string[]
		{
			#Phc.#3hc(107396604),
			#Phc.#3hc(107396571),
			#Phc.#3hc(107396494),
			#Phc.#3hc(107396449),
			#Phc.#3hc(107396440),
			#Phc.#3hc(107396359),
			#Phc.#3hc(107395830),
			#Phc.#3hc(107395801),
			#Phc.#3hc(107395716),
			#Phc.#3hc(107395655)
		};

		// Token: 0x0400001D RID: 29
		private static readonly string[] #b = new string[]
		{
			#Phc.#3hc(107395590),
			#Phc.#3hc(107395601),
			#Phc.#3hc(107396092),
			#Phc.#3hc(107396047),
			#Phc.#3hc(107396038),
			#Phc.#3hc(107396057),
			#Phc.#3hc(107396008),
			#Phc.#3hc(107395979),
			#Phc.#3hc(107395942),
			#Phc.#3hc(107395913),
			#Phc.#3hc(107395900)
		};

		// Token: 0x02000012 RID: 18
		[CompilerGenerated]
		private static class #2Ui
		{
			// Token: 0x0400001E RID: 30
			public static Action #a;

			// Token: 0x0400001F RID: 31
			public static Action #b;

			// Token: 0x04000020 RID: 32
			public static Action #c;
		}
	}
}
