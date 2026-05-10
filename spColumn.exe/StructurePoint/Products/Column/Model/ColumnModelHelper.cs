using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using #eU;
using #LFb;
using #o1d;
using #qJ;
using #RJb;
using devDept.Geometry;
using Newtonsoft.Json;
using StructurePoint.CoreAssets.AppManager.Column.Engineer;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;
using StructurePoint.CoreAssets.AppManager.Column.Helpers;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.Products.Column.Editor.Core.Selection;
using StructurePoint.Products.Column.Model.Entities;

namespace StructurePoint.Products.Column.Model
{
	// Token: 0x02000322 RID: 802
	internal static class ColumnModelHelper
	{
		// Token: 0x06001BC3 RID: 7107 RVA: 0x000BF0A0 File Offset: 0x000BD2A0
		public static bool #LW(#oW #xn, double #f, double #MW)
		{
			int precision = #xn.Model.Units.Section.Width.UnitValueFormatter.Precision;
			return Math.Abs(#f - #MW) > Math.Pow(10.0, (double)(-(double)precision));
		}

		// Token: 0x06001BC4 RID: 7108 RVA: 0x000BF0A0 File Offset: 0x000BD2A0
		public static bool #NW(#oW #xn, double #f, double #MW)
		{
			int precision = #xn.Model.Units.Section.Width.UnitValueFormatter.Precision;
			return Math.Abs(#f - #MW) > Math.Pow(10.0, (double)(-(double)precision));
		}

		// Token: 0x06001BC5 RID: 7109 RVA: 0x0001AF90 File Offset: 0x00019190
		public static StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point #OW(StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point #Ng)
		{
			return new StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point(ColumnModelHelper.#OW((double)#Ng.X), ColumnModelHelper.#OW((double)#Ng.Y));
		}

		// Token: 0x06001BC6 RID: 7110 RVA: 0x0001AFBB File Offset: 0x000191BB
		public static double #OW(double #f)
		{
			return Math.Round(#f, ColumnModelHelper.#b);
		}

		// Token: 0x06001BC7 RID: 7111 RVA: 0x0001AFD0 File Offset: 0x000191D0
		public static StructurePoint.CoreAssets.Infrastructure.Data.Point3D #PW(this StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point #Ng)
		{
			return new StructurePoint.CoreAssets.Infrastructure.Data.Point3D((double)#Ng.X, (double)#Ng.Y);
		}

		// Token: 0x06001BC8 RID: 7112 RVA: 0x0001AFF1 File Offset: 0x000191F1
		public static StructurePoint.CoreAssets.Infrastructure.Data.Point3D #PW(this devDept.Geometry.Point3D #Ng)
		{
			return new StructurePoint.CoreAssets.Infrastructure.Data.Point3D(#Ng.X, #Ng.Y);
		}

		// Token: 0x06001BC9 RID: 7113 RVA: 0x0001B010 File Offset: 0x00019210
		public static StructurePoint.CoreAssets.Infrastructure.Data.Point #QW(this devDept.Geometry.Point3D #Ng)
		{
			return new StructurePoint.CoreAssets.Infrastructure.Data.Point(#Ng.X, #Ng.Y);
		}

		// Token: 0x06001BCA RID: 7114 RVA: 0x0001B02F File Offset: 0x0001922F
		public static System.Drawing.Point #RW(this devDept.Geometry.Point3D #Ng)
		{
			return new System.Drawing.Point((int)#Ng.X, (int)#Ng.Y);
		}

		// Token: 0x06001BCB RID: 7115 RVA: 0x0001B050 File Offset: 0x00019250
		public static StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point #SW(this devDept.Geometry.Point3D #Ng)
		{
			return new StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point(#Ng.X, #Ng.Y);
		}

		// Token: 0x06001BCC RID: 7116 RVA: 0x0001B06F File Offset: 0x0001926F
		public static devDept.Geometry.Point3D #TW(this StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point #Ng)
		{
			return new devDept.Geometry.Point3D((double)#Ng.X, (double)#Ng.Y);
		}

		// Token: 0x06001BCD RID: 7117 RVA: 0x0001B090 File Offset: 0x00019290
		public static devDept.Geometry.Point3D #TW(this StructurePoint.CoreAssets.Infrastructure.Data.Point #Ng)
		{
			return new devDept.Geometry.Point3D(#Ng.X, #Ng.Y);
		}

		// Token: 0x06001BCE RID: 7118 RVA: 0x0001B0B1 File Offset: 0x000192B1
		public static devDept.Geometry.Point3D #TW(this StructurePoint.CoreAssets.Infrastructure.Data.Point3D #Ng)
		{
			return new devDept.Geometry.Point3D(#Ng.X, #Ng.Y);
		}

		// Token: 0x06001BCF RID: 7119 RVA: 0x000BF0F4 File Offset: 0x000BD2F4
		public static void #UW(#oW #xn)
		{
			ColumnModel columnModel = #xn.Model;
			columnModel.ReinforcementBars.#I1d(new Action<StructurePoint.Products.Column.Model.Entities.ReinforcementBar>(ColumnModelHelper.<>c.<>9.#p2b));
			columnModel.Shapes.Where(new Func<ShapeModel, bool>(ColumnModelHelper.<>c.<>9.#q2b)).#I1d(new Action<ShapeModel>(ColumnModelHelper.<>c.<>9.#r2b));
		}

		// Token: 0x06001BD0 RID: 7120 RVA: 0x0001B0D2 File Offset: 0x000192D2
		public static void #VW(#oW #xn)
		{
			#xn.Metadata.SectionCentroid = SectionGeometryHelper.#gxc(#xn.Model.#CY());
		}

		// Token: 0x06001BD1 RID: 7121 RVA: 0x000BF1A0 File Offset: 0x000BD3A0
		public static bool #uC(#9V #bP, ColumnModel #WW, ColumnStorageModel #ui)
		{
			ColumnModelHelper.#rWb #rWb = new ColumnModelHelper.#rWb();
			#rWb.#b = #ui;
			#rWb.#a = #bP.#Pb(#WW);
			Task<string> task = Task.Factory.StartNew<string>(new Func<string>(#rWb.#w2b));
			Task<string> task2 = Task.Factory.StartNew<string>(new Func<string>(#rWb.#x2b));
			Task.WaitAll(new Task[]
			{
				task,
				task2
			});
			string result = task.Result;
			string result2 = task2.Result;
			return string.Equals(result, result2, StringComparison.Ordinal);
		}

		// Token: 0x06001BD2 RID: 7122 RVA: 0x000BF238 File Offset: 0x000BD438
		internal static void #XW(IList<devDept.Geometry.Point3D> #En, double #6Q, double #YW, double #Sc, double #Tc, double #ZW, double #0W)
		{
			#En.#pR(new devDept.Geometry.Point3D[]
			{
				new devDept.Geometry.Point3D(-#6Q / 2.0 + #Sc, -#YW / 2.0 + #0W),
				new devDept.Geometry.Point3D(#6Q / 2.0 - #Tc, -#YW / 2.0 + #0W),
				new devDept.Geometry.Point3D(#6Q / 2.0 - #Tc, #YW / 2.0 - #ZW),
				new devDept.Geometry.Point3D(-#6Q / 2.0 + #Sc, #YW / 2.0 - #ZW),
				new devDept.Geometry.Point3D(-#6Q / 2.0 + #Sc, -#YW / 2.0 + #0W)
			});
		}

		// Token: 0x06001BD3 RID: 7123 RVA: 0x0001B0FB File Offset: 0x000192FB
		public static void #1W(#9V #bP, ColumnModel #Od)
		{
			#Od.Options.SectionType = SectionType.Irregular;
			#Od.Options.InvestigationReinforcement = ReinforcementType.Irregular;
		}

		// Token: 0x06001BD4 RID: 7124 RVA: 0x000BF328 File Offset: 0x000BD528
		public static void #2W(#9V #bP, ColumnModel #Od)
		{
			if (#Od.Options.SectionType != SectionType.Rectangle && #Od.Options.SectionType != SectionType.Circle)
			{
				return;
			}
			ColumnStorageModel columnStorageModel = #bP.#Pb(#Od);
			DesignEngine designEngine = new DesignEngine(columnStorageModel, new #EJ(false, false, false, true, 1f));
			designEngine.#tOe();
			float #R = designEngine.OutputModel.InvestigationDimensions[0];
			float #S = designEngine.OutputModel.InvestigationDimensions[1];
			#Od.Shapes.Clear();
			List<devDept.Geometry.Point3D> list;
			List<SectionPolygon> source;
			SectionGeometryHelper.#BT(columnStorageModel, #R, #S, out list, out source, true);
			#Od.Shapes.AddRange(source.Select(new Func<SectionPolygon, ShapeModel>(ColumnModelHelper.<>c.<>9.#s2b)));
			#Od.#3O();
			#Od.ReinforcementBars.Clear();
			#Od.ReinforcementBars.AddRange(designEngine.OutputModel.ReinforcementBars.Select(new Func<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar, StructurePoint.Products.Column.Model.Entities.ReinforcementBar>(ColumnModelHelper.<>c.<>9.#t2b)));
		}

		// Token: 0x06001BD5 RID: 7125 RVA: 0x0001B121 File Offset: 0x00019321
		public static StructurePoint.Products.Column.Model.Entities.ReinforcementBar #3W(ColumnModel #Od, devDept.Geometry.Point3D #Ng)
		{
			if (#Ng == null)
			{
				return null;
			}
			IEnumerable<StructurePoint.Products.Column.Model.Entities.ReinforcementBar> enumerable = ColumnModelHelper.#5W(#Od.ReinforcementBars, #Ng.X, #Ng.Y);
			if (enumerable == null)
			{
				return null;
			}
			return enumerable.FirstOrDefault<StructurePoint.Products.Column.Model.Entities.ReinforcementBar>();
		}

		// Token: 0x06001BD6 RID: 7126 RVA: 0x0001B15C File Offset: 0x0001935C
		public static StructurePoint.Products.Column.Model.Entities.ReinforcementBar #3W(ColumnModel #Od, StructurePoint.CoreAssets.Infrastructure.Data.Point #Ng)
		{
			IEnumerable<StructurePoint.Products.Column.Model.Entities.ReinforcementBar> enumerable = ColumnModelHelper.#5W(#Od.ReinforcementBars, #Ng.X, #Ng.Y);
			if (enumerable == null)
			{
				return null;
			}
			return enumerable.FirstOrDefault<StructurePoint.Products.Column.Model.Entities.ReinforcementBar>();
		}

		// Token: 0x06001BD7 RID: 7127 RVA: 0x0001B18E File Offset: 0x0001938E
		public static IList<StructurePoint.Products.Column.Model.Entities.ReinforcementBar> #4W(ColumnModel #Od, devDept.Geometry.Point3D #Ng)
		{
			if (!(#Ng == null))
			{
				return ColumnModelHelper.#5W(#Od.ReinforcementBars, #Ng.X, #Ng.Y).ToList<StructurePoint.Products.Column.Model.Entities.ReinforcementBar>();
			}
			return null;
		}

		// Token: 0x06001BD8 RID: 7128 RVA: 0x000BF444 File Offset: 0x000BD644
		public static IEnumerable<StructurePoint.Products.Column.Model.Entities.ReinforcementBar> #5W(ICollection<StructurePoint.Products.Column.Model.Entities.ReinforcementBar> #6W, double #9o, double #7W)
		{
			ColumnModelHelper.#CTb #CTb = new ColumnModelHelper.#CTb();
			ColumnModelHelper.#CTb #CTb2;
			if (!false)
			{
				#CTb2 = #CTb;
			}
			#CTb2.#a = #9o;
			#CTb2.#b = #7W;
			return #6W.Where(new Func<StructurePoint.Products.Column.Model.Entities.ReinforcementBar, bool>(#CTb2.#y2b));
		}

		// Token: 0x06001BD9 RID: 7129 RVA: 0x000BF488 File Offset: 0x000BD688
		public static IEnumerable<StructurePoint.Products.Column.Model.Entities.ReinforcementBar> #5W(ICollection<StructurePoint.Products.Column.Model.Entities.ReinforcementBar> #6W, double #9o, double #7W, double #8W)
		{
			ColumnModelHelper.#ETb #ETb = new ColumnModelHelper.#ETb();
			#ETb.#a = #9o;
			#ETb.#b = #8W;
			#ETb.#c = #7W;
			return #6W.Where(new Func<StructurePoint.Products.Column.Model.Entities.ReinforcementBar, bool>(#ETb.#y2b));
		}

		// Token: 0x06001BDA RID: 7130 RVA: 0x0001B1C3 File Offset: 0x000193C3
		public static IList<StructurePoint.Products.Column.Model.Entities.ReinforcementBar> #4W(ICollection<StructurePoint.Products.Column.Model.Entities.ReinforcementBar> #6W, StructurePoint.CoreAssets.Infrastructure.Data.Point #Ng)
		{
			return ColumnModelHelper.#5W(#6W, #Ng.X, #Ng.Y).ToList<StructurePoint.Products.Column.Model.Entities.ReinforcementBar>();
		}

		// Token: 0x06001BDB RID: 7131 RVA: 0x0001B1EA File Offset: 0x000193EA
		public static IList<StructurePoint.Products.Column.Model.Entities.ReinforcementBar> #4W(ICollection<StructurePoint.Products.Column.Model.Entities.ReinforcementBar> #6W, devDept.Geometry.Point3D #Ng)
		{
			if (!(#Ng == null))
			{
				return ColumnModelHelper.#5W(#6W, #Ng.X, #Ng.Y).ToList<StructurePoint.Products.Column.Model.Entities.ReinforcementBar>();
			}
			return null;
		}

		// Token: 0x06001BDC RID: 7132 RVA: 0x000BF4D0 File Offset: 0x000BD6D0
		public static bool #9W(IEnumerable<devDept.Geometry.Point3D> #BP)
		{
			bool result;
			try
			{
				List<StructurePoint.CoreAssets.Infrastructure.Data.Point3D> list = #BP.Select(new Func<devDept.Geometry.Point3D, StructurePoint.CoreAssets.Infrastructure.Data.Point3D>(ColumnModelHelper.<>c.<>9.#u2b)).ToList<StructurePoint.CoreAssets.Infrastructure.Data.Point3D>();
				int num = list.Select(new Func<StructurePoint.CoreAssets.Infrastructure.Data.Point3D, <>f__AnonymousType7<double, double>>(ColumnModelHelper.<>c.<>9.#v2b)).Distinct().Count();
				result = (num >= list.Count - 1 && ColumnGeometryHelper.#1lc(list));
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06001BDD RID: 7133 RVA: 0x000BF574 File Offset: 0x000BD774
		public static void #aX(#cLb #FR, #UFb #bX)
		{
			SelectionManager selectionManager = #FR.Selection;
			#oW #oW = #FR.ProjectContext;
			#oW.Model.Shapes.#F7c(selectionManager.Shapes.SelectedObjects);
			#oW.Model.ReinforcementBars.#F7c(selectionManager.Bars.SelectedObjects);
			selectionManager.#sOb();
			selectionManager.State.#cg();
			#bX.#cg(#FR, false);
			ColumnModelHelper.#VW(#FR.ProjectContext);
			#FR.SnappingCache.#uP(#oW);
		}

		// Token: 0x06001BDE RID: 7134 RVA: 0x000BF608 File Offset: 0x000BD808
		public static Stream #tBf(ColumnStorageModel #Od)
		{
			MemoryStream memoryStream = new MemoryStream();
			JsonSerializer jsonSerializer = JsonSerializer.Create();
			jsonSerializer.Serialize(new JsonTextWriter(new StreamWriter(memoryStream)), #Od);
			memoryStream.#i2d();
			return memoryStream;
		}

		// Token: 0x06001BDF RID: 7135 RVA: 0x000BF648 File Offset: 0x000BD848
		public static string #cX(ColumnStorageModel #dX)
		{
			if (!string.IsNullOrWhiteSpace((#dX != null) ? #dX.SerializedModel : null))
			{
				return #dX.SerializedModel;
			}
			string text = (#dX != null) ? JsonConvert.SerializeObject(#dX, Formatting.None) : string.Empty;
			if (#dX != null)
			{
				#dX.SerializedModel = text;
			}
			return text;
		}

		// Token: 0x04000AF5 RID: 2805
		private const double #a = 0.0001;

		// Token: 0x04000AF6 RID: 2806
		public static readonly int #b = 3;

		// Token: 0x02000323 RID: 803
		[CompilerGenerated]
		private static class #2Ui
		{
			// Token: 0x04000AF7 RID: 2807
			public static Func<StructurePoint.CoreAssets.Infrastructure.Data.Point, StructurePoint.CoreAssets.Infrastructure.Data.Point> #a;
		}

		// Token: 0x02000325 RID: 805
		[CompilerGenerated]
		private sealed class #rWb
		{
			// Token: 0x06001BEB RID: 7147 RVA: 0x0001B2D5 File Offset: 0x000194D5
			internal string #w2b()
			{
				return ColumnModelHelper.#cX(this.#a);
			}

			// Token: 0x06001BEC RID: 7148 RVA: 0x0001B2EA File Offset: 0x000194EA
			internal string #x2b()
			{
				return ColumnModelHelper.#cX(this.#b);
			}

			// Token: 0x04000B00 RID: 2816
			public ColumnStorageModel #a;

			// Token: 0x04000B01 RID: 2817
			public ColumnStorageModel #b;
		}

		// Token: 0x02000326 RID: 806
		[CompilerGenerated]
		private sealed class #CTb
		{
			// Token: 0x06001BEE RID: 7150 RVA: 0x000BF6EC File Offset: 0x000BD8EC
			internal bool #y2b(StructurePoint.Products.Column.Model.Entities.ReinforcementBar #Rf)
			{
				return Math.Abs((double)#Rf.X - this.#a) <= 0.0001 && Math.Abs((double)#Rf.Y - this.#b) <= 0.0001;
			}

			// Token: 0x04000B02 RID: 2818
			public double #a;

			// Token: 0x04000B03 RID: 2819
			public double #b;
		}

		// Token: 0x02000327 RID: 807
		[CompilerGenerated]
		private sealed class #ETb
		{
			// Token: 0x06001BF0 RID: 7152 RVA: 0x000BF748 File Offset: 0x000BD948
			internal bool #y2b(StructurePoint.Products.Column.Model.Entities.ReinforcementBar #Rf)
			{
				return Math.Abs(#Rf.Location.X - this.#a) <= this.#b && Math.Abs(#Rf.Location.Y - this.#c) < this.#b;
			}

			// Token: 0x04000B04 RID: 2820
			public double #a;

			// Token: 0x04000B05 RID: 2821
			public double #b;

			// Token: 0x04000B06 RID: 2822
			public double #c;
		}
	}
}
