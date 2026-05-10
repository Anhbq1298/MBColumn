using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using #7hc;
using #eU;
using StructurePoint.CoreAssets.GUI.DesktopControls;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;

namespace StructurePoint.Products.Column.Services
{
	// Token: 0x020002A5 RID: 677
	internal sealed class ColumnCommandsManager : NotifyPropertyChangedObjectBase, #wU
	{
		// Token: 0x060015F5 RID: 5621 RVA: 0x000B36C0 File Offset: 0x000B18C0
		public ColumnCommandsManager(ICommandFactory factory)
		{
			if (factory == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107405805));
			}
			this.#b = factory.CreateProxy();
			this.#c = factory.CreateProxy();
			this.#e = factory.CreateProxy();
			this.#d = factory.CreateProxy();
			this.#f = factory.CreateProxy();
			this.#g = factory.CreateProxy();
			this.#h = factory.CreateProxy();
			this.#i = factory.CreateProxy();
			this.#j = factory.CreateProxy();
			this.#k = factory.CreateProxy();
			this.#l = factory.CreateProxy();
			this.#m = factory.CreateProxy();
			this.#n = factory.CreateProxy();
			this.#o = factory.CreateProxy();
			this.#p = factory.CreateProxy();
			this.#q = factory.CreateProxy();
			this.#r = factory.CreateProxy();
			this.#t = factory.CreateProxy();
			this.#u = factory.CreateProxy();
			this.#v = factory.CreateProxy();
			this.#w = factory.CreateProxy();
			this.#x = factory.CreateProxy();
			this.#y = factory.CreateProxy();
			this.#A = factory.CreateProxy();
			this.#z = factory.CreateProxy();
			this.#s = factory.CreateProxy();
			this.#B = factory.CreateProxy();
			this.#C = factory.CreateProxy();
			this.#D = factory.CreateProxy();
			this.#a.AddRange(typeof(ColumnCommandsManager).GetProperties(BindingFlags.Instance | BindingFlags.Public).Where(new Func<PropertyInfo, bool>(ColumnCommandsManager.<>c.<>9.#8Zb)).Select(new Func<PropertyInfo, IDelegateCommandProxy>(this.#oK)));
		}

		// Token: 0x170007C1 RID: 1985
		// (get) Token: 0x060015F6 RID: 5622 RVA: 0x00016EA0 File Offset: 0x000150A0
		public IDelegateCommandProxy Undo { get; }

		// Token: 0x170007C2 RID: 1986
		// (get) Token: 0x060015F7 RID: 5623 RVA: 0x00016EAC File Offset: 0x000150AC
		public IDelegateCommandProxy Redo { get; }

		// Token: 0x170007C3 RID: 1987
		// (get) Token: 0x060015F8 RID: 5624 RVA: 0x00016EB8 File Offset: 0x000150B8
		public IDelegateCommandProxy Save { get; }

		// Token: 0x170007C4 RID: 1988
		// (get) Token: 0x060015F9 RID: 5625 RVA: 0x00016EC4 File Offset: 0x000150C4
		public IDelegateCommandProxy SaveAs { get; }

		// Token: 0x170007C5 RID: 1989
		// (get) Token: 0x060015FA RID: 5626 RVA: 0x00016ED0 File Offset: 0x000150D0
		public IDelegateCommandProxy Open { get; }

		// Token: 0x170007C6 RID: 1990
		// (get) Token: 0x060015FB RID: 5627 RVA: 0x00016EDC File Offset: 0x000150DC
		public IDelegateCommandProxy OpenExamples { get; }

		// Token: 0x170007C7 RID: 1991
		// (get) Token: 0x060015FC RID: 5628 RVA: 0x00016EE8 File Offset: 0x000150E8
		public IDelegateCommandProxy New { get; }

		// Token: 0x170007C8 RID: 1992
		// (get) Token: 0x060015FD RID: 5629 RVA: 0x00016EF4 File Offset: 0x000150F4
		public IDelegateCommandProxy OpenSolver { get; }

		// Token: 0x170007C9 RID: 1993
		// (get) Token: 0x060015FE RID: 5630 RVA: 0x00016F00 File Offset: 0x00015100
		public IDelegateCommandProxy OpenSuperImpose { get; }

		// Token: 0x170007CA RID: 1994
		// (get) Token: 0x060015FF RID: 5631 RVA: 0x00016F0C File Offset: 0x0001510C
		public IDelegateCommandProxy OpenReporter { get; }

		// Token: 0x170007CB RID: 1995
		// (get) Token: 0x06001600 RID: 5632 RVA: 0x00016F18 File Offset: 0x00015118
		public IDelegateCommandProxy OpenResults { get; }

		// Token: 0x170007CC RID: 1996
		// (get) Token: 0x06001601 RID: 5633 RVA: 0x00016F24 File Offset: 0x00015124
		public IDelegateCommandProxy OpenSettings { get; }

		// Token: 0x170007CD RID: 1997
		// (get) Token: 0x06001602 RID: 5634 RVA: 0x00016F30 File Offset: 0x00015130
		public IDelegateCommandProxy Close { get; }

		// Token: 0x170007CE RID: 1998
		// (get) Token: 0x06001603 RID: 5635 RVA: 0x00016F3C File Offset: 0x0001513C
		public IDelegateCommandProxy ActivateScopeWithParameters { get; }

		// Token: 0x170007CF RID: 1999
		// (get) Token: 0x06001604 RID: 5636 RVA: 0x00016F48 File Offset: 0x00015148
		public IDelegateCommandProxy ActivateDiagramWithParameters { get; }

		// Token: 0x170007D0 RID: 2000
		// (get) Token: 0x06001605 RID: 5637 RVA: 0x00016F54 File Offset: 0x00015154
		public IDelegateCommandProxy AddToReport { get; }

		// Token: 0x170007D1 RID: 2001
		// (get) Token: 0x06001606 RID: 5638 RVA: 0x00016F60 File Offset: 0x00015160
		public IDelegateCommandProxy PrintExport { get; }

		// Token: 0x170007D2 RID: 2002
		// (get) Token: 0x06001607 RID: 5639 RVA: 0x00016F6C File Offset: 0x0001516C
		public IDelegateCommandProxy CleanReport { get; }

		// Token: 0x170007D3 RID: 2003
		// (get) Token: 0x06001608 RID: 5640 RVA: 0x00016F78 File Offset: 0x00015178
		public IDelegateCommandProxy ExportSection { get; }

		// Token: 0x170007D4 RID: 2004
		// (get) Token: 0x06001609 RID: 5641 RVA: 0x00016F84 File Offset: 0x00015184
		public IDelegateCommandProxy ExportLoads { get; }

		// Token: 0x170007D5 RID: 2005
		// (get) Token: 0x0600160A RID: 5642 RVA: 0x00016F90 File Offset: 0x00015190
		public IDelegateCommandProxy ExportDiagram2D { get; }

		// Token: 0x170007D6 RID: 2006
		// (get) Token: 0x0600160B RID: 5643 RVA: 0x00016F9C File Offset: 0x0001519C
		public IDelegateCommandProxy ExportDiagram3D { get; }

		// Token: 0x170007D7 RID: 2007
		// (get) Token: 0x0600160C RID: 5644 RVA: 0x00016FA8 File Offset: 0x000151A8
		public IDelegateCommandProxy ImportSection { get; }

		// Token: 0x170007D8 RID: 2008
		// (get) Token: 0x0600160D RID: 5645 RVA: 0x00016FB4 File Offset: 0x000151B4
		public IDelegateCommandProxy ImportLoads { get; }

		// Token: 0x170007D9 RID: 2009
		// (get) Token: 0x0600160E RID: 5646 RVA: 0x00016FC0 File Offset: 0x000151C0
		public IDelegateCommandProxy ExportDxf { get; }

		// Token: 0x170007DA RID: 2010
		// (get) Token: 0x0600160F RID: 5647 RVA: 0x00016FCC File Offset: 0x000151CC
		public IDelegateCommandProxy ImportDxf { get; }

		// Token: 0x170007DB RID: 2011
		// (get) Token: 0x06001610 RID: 5648 RVA: 0x00016FD8 File Offset: 0x000151D8
		public IDelegateCommandProxy ChangeUnitSystem { get; }

		// Token: 0x170007DC RID: 2012
		// (get) Token: 0x06001611 RID: 5649 RVA: 0x00016FE4 File Offset: 0x000151E4
		public IDelegateCommandProxy ChangeSectionType { get; }

		// Token: 0x170007DD RID: 2013
		// (get) Token: 0x06001612 RID: 5650 RVA: 0x00016FF0 File Offset: 0x000151F0
		public IDelegateCommandProxy StartDesignTrace { get; }

		// Token: 0x06001613 RID: 5651 RVA: 0x000B38A0 File Offset: 0x000B1AA0
		public void #cg()
		{
			this.#a.ForEach(new Action<IDelegateCommandProxy>(ColumnCommandsManager.<>c.<>9.#9Zb));
			this.ExportDiagram2D.InvalidateCanExecute();
			this.ExportDiagram3D.InvalidateCanExecute();
		}

		// Token: 0x06001614 RID: 5652 RVA: 0x00016FFC File Offset: 0x000151FC
		[CompilerGenerated]
		private IDelegateCommandProxy #oK(PropertyInfo #Rf)
		{
			return (IDelegateCommandProxy)#Rf.GetValue(this, null);
		}

		// Token: 0x040008C7 RID: 2247
		private readonly List<IDelegateCommandProxy> #a = new List<IDelegateCommandProxy>();

		// Token: 0x040008C8 RID: 2248
		[CompilerGenerated]
		private readonly IDelegateCommandProxy #b;

		// Token: 0x040008C9 RID: 2249
		[CompilerGenerated]
		private readonly IDelegateCommandProxy #c;

		// Token: 0x040008CA RID: 2250
		[CompilerGenerated]
		private readonly IDelegateCommandProxy #d;

		// Token: 0x040008CB RID: 2251
		[CompilerGenerated]
		private readonly IDelegateCommandProxy #e;

		// Token: 0x040008CC RID: 2252
		[CompilerGenerated]
		private readonly IDelegateCommandProxy #f;

		// Token: 0x040008CD RID: 2253
		[CompilerGenerated]
		private readonly IDelegateCommandProxy #g;

		// Token: 0x040008CE RID: 2254
		[CompilerGenerated]
		private readonly IDelegateCommandProxy #h;

		// Token: 0x040008CF RID: 2255
		[CompilerGenerated]
		private readonly IDelegateCommandProxy #i;

		// Token: 0x040008D0 RID: 2256
		[CompilerGenerated]
		private readonly IDelegateCommandProxy #j;

		// Token: 0x040008D1 RID: 2257
		[CompilerGenerated]
		private readonly IDelegateCommandProxy #k;

		// Token: 0x040008D2 RID: 2258
		[CompilerGenerated]
		private readonly IDelegateCommandProxy #l;

		// Token: 0x040008D3 RID: 2259
		[CompilerGenerated]
		private readonly IDelegateCommandProxy #m;

		// Token: 0x040008D4 RID: 2260
		[CompilerGenerated]
		private readonly IDelegateCommandProxy #n;

		// Token: 0x040008D5 RID: 2261
		[CompilerGenerated]
		private readonly IDelegateCommandProxy #o;

		// Token: 0x040008D6 RID: 2262
		[CompilerGenerated]
		private readonly IDelegateCommandProxy #p;

		// Token: 0x040008D7 RID: 2263
		[CompilerGenerated]
		private readonly IDelegateCommandProxy #q;

		// Token: 0x040008D8 RID: 2264
		[CompilerGenerated]
		private readonly IDelegateCommandProxy #r;

		// Token: 0x040008D9 RID: 2265
		[CompilerGenerated]
		private readonly IDelegateCommandProxy #s;

		// Token: 0x040008DA RID: 2266
		[CompilerGenerated]
		private readonly IDelegateCommandProxy #t;

		// Token: 0x040008DB RID: 2267
		[CompilerGenerated]
		private readonly IDelegateCommandProxy #u;

		// Token: 0x040008DC RID: 2268
		[CompilerGenerated]
		private readonly IDelegateCommandProxy #v;

		// Token: 0x040008DD RID: 2269
		[CompilerGenerated]
		private readonly IDelegateCommandProxy #w;

		// Token: 0x040008DE RID: 2270
		[CompilerGenerated]
		private readonly IDelegateCommandProxy #x;

		// Token: 0x040008DF RID: 2271
		[CompilerGenerated]
		private readonly IDelegateCommandProxy #y;

		// Token: 0x040008E0 RID: 2272
		[CompilerGenerated]
		private readonly IDelegateCommandProxy #z;

		// Token: 0x040008E1 RID: 2273
		[CompilerGenerated]
		private readonly IDelegateCommandProxy #A;

		// Token: 0x040008E2 RID: 2274
		[CompilerGenerated]
		private readonly IDelegateCommandProxy #B;

		// Token: 0x040008E3 RID: 2275
		[CompilerGenerated]
		private readonly IDelegateCommandProxy #C;

		// Token: 0x040008E4 RID: 2276
		[CompilerGenerated]
		private readonly IDelegateCommandProxy #D;
	}
}
