using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using #2ic;
using StructurePoint.CoreAssets.DataExchange.ExternFormat;

namespace #Vjc
{
	// Token: 0x0200077A RID: 1914
	internal sealed class #kkc : #Qjc
	{
		// Token: 0x170012AA RID: 4778
		// (get) Token: 0x06003D89 RID: 15753 RVA: 0x00034AC1 File Offset: 0x00032CC1
		public List<#sjc> Arcs
		{
			get
			{
				return this.#a;
			}
		}

		// Token: 0x170012AB RID: 4779
		// (get) Token: 0x06003D8A RID: 15754 RVA: 0x00034AC9 File Offset: 0x00032CC9
		public List<#tjc> Circles
		{
			get
			{
				return this.#b;
			}
		}

		// Token: 0x170012AC RID: 4780
		// (get) Token: 0x06003D8B RID: 15755 RVA: 0x00034AD1 File Offset: 0x00032CD1
		public List<#fjc> Ellipses
		{
			get
			{
				return this.#c;
			}
		}

		// Token: 0x170012AD RID: 4781
		// (get) Token: 0x06003D8C RID: 15756 RVA: 0x00034AD9 File Offset: 0x00032CD9
		public List<ILine> Lines
		{
			get
			{
				return this.#d;
			}
		}

		// Token: 0x170012AE RID: 4782
		// (get) Token: 0x06003D8D RID: 15757 RVA: 0x00034AE1 File Offset: 0x00032CE1
		public List<IPoint> Points
		{
			get
			{
				return this.#e;
			}
		}

		// Token: 0x170012AF RID: 4783
		// (get) Token: 0x06003D8E RID: 15758 RVA: 0x00034AE9 File Offset: 0x00032CE9
		public List<#pjc> Polylines
		{
			get
			{
				return this.#f;
			}
		}

		// Token: 0x170012B0 RID: 4784
		// (get) Token: 0x06003D8F RID: 15759 RVA: 0x00034AF1 File Offset: 0x00032CF1
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		[SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public List<#ljc> PolygonPolylines
		{
			get
			{
				return this.#g;
			}
		}

		// Token: 0x170012B1 RID: 4785
		// (get) Token: 0x06003D90 RID: 15760 RVA: 0x00034AF9 File Offset: 0x00032CF9
		public List<IVertex> Vertexes
		{
			get
			{
				return this.#h;
			}
		}

		// Token: 0x170012B2 RID: 4786
		// (get) Token: 0x06003D91 RID: 15761 RVA: 0x00034B01 File Offset: 0x00032D01
		public List<#jjc> Layers
		{
			get
			{
				return this.#i;
			}
		}

		// Token: 0x170012B3 RID: 4787
		// (get) Token: 0x06003D92 RID: 15762 RVA: 0x00034B09 File Offset: 0x00032D09
		[SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		public List<#yjc> XLines
		{
			get
			{
				return this.#j;
			}
		}

		// Token: 0x170012B4 RID: 4788
		// (get) Token: 0x06003D93 RID: 15763 RVA: 0x00034B11 File Offset: 0x00032D11
		public List<#Ikc> Texts
		{
			get
			{
				return this.#k;
			}
		}

		// Token: 0x170012B5 RID: 4789
		// (get) Token: 0x06003D94 RID: 15764 RVA: 0x00034B19 File Offset: 0x00032D19
		public List<#lkc> MultiTexts
		{
			get
			{
				return this.#l;
			}
		}

		// Token: 0x170012B6 RID: 4790
		// (get) Token: 0x06003D95 RID: 15765 RVA: 0x00034B21 File Offset: 0x00032D21
		public List<#Bkc> Solids
		{
			get
			{
				return this.#m;
			}
		}

		// Token: 0x170012B7 RID: 4791
		// (get) Token: 0x06003D96 RID: 15766 RVA: 0x00034B29 File Offset: 0x00032D29
		public List<#ekc> Hatches
		{
			get
			{
				return this.#n;
			}
		}

		// Token: 0x170012B8 RID: 4792
		// (get) Token: 0x06003D97 RID: 15767 RVA: 0x00034B31 File Offset: 0x00032D31
		public List<#5jc> CurvePolygons
		{
			get
			{
				return this.#o;
			}
		}

		// Token: 0x170012B9 RID: 4793
		// (get) Token: 0x06003D98 RID: 15768 RVA: 0x00034B39 File Offset: 0x00032D39
		public List<#9jc> Dimensions
		{
			get
			{
				return this.#p;
			}
		}

		// Token: 0x170012BA RID: 4794
		// (get) Token: 0x06003D99 RID: 15769 RVA: 0x00034B41 File Offset: 0x00032D41
		// (set) Token: 0x06003D9A RID: 15770 RVA: 0x00034B49 File Offset: 0x00032D49
		public ExternDrawingUnit DrawingUnit { get; set; }

		// Token: 0x06003D9B RID: 15771 RVA: 0x0011C6B8 File Offset: 0x0011A8B8
		public #kkc()
		{
			this.#a = new List<#sjc>();
			this.#b = new List<#tjc>();
			this.#c = new List<#fjc>();
			this.#d = new List<ILine>();
			this.#e = new List<IPoint>();
			this.#f = new List<#pjc>();
			this.#g = new List<#ljc>();
			this.#h = new List<IVertex>();
			this.#j = new List<#yjc>();
			this.#i = new List<#jjc>();
			this.#k = new List<#Ikc>();
			this.#l = new List<#lkc>();
			this.#m = new List<#Bkc>();
			this.#n = new List<#ekc>();
			this.#o = new List<#5jc>();
			this.#p = new List<#9jc>();
		}

		// Token: 0x04001BF1 RID: 7153
		private readonly List<#sjc> #a;

		// Token: 0x04001BF2 RID: 7154
		private readonly List<#tjc> #b;

		// Token: 0x04001BF3 RID: 7155
		private readonly List<#fjc> #c;

		// Token: 0x04001BF4 RID: 7156
		private readonly List<ILine> #d;

		// Token: 0x04001BF5 RID: 7157
		private readonly List<IPoint> #e;

		// Token: 0x04001BF6 RID: 7158
		private readonly List<#pjc> #f;

		// Token: 0x04001BF7 RID: 7159
		private readonly List<#ljc> #g;

		// Token: 0x04001BF8 RID: 7160
		private readonly List<IVertex> #h;

		// Token: 0x04001BF9 RID: 7161
		private readonly List<#jjc> #i;

		// Token: 0x04001BFA RID: 7162
		private readonly List<#yjc> #j;

		// Token: 0x04001BFB RID: 7163
		private readonly List<#Ikc> #k;

		// Token: 0x04001BFC RID: 7164
		private readonly List<#lkc> #l;

		// Token: 0x04001BFD RID: 7165
		private readonly List<#Bkc> #m;

		// Token: 0x04001BFE RID: 7166
		private readonly List<#ekc> #n;

		// Token: 0x04001BFF RID: 7167
		private readonly List<#5jc> #o;

		// Token: 0x04001C00 RID: 7168
		private readonly List<#9jc> #p;

		// Token: 0x04001C01 RID: 7169
		[CompilerGenerated]
		private ExternDrawingUnit #q;
	}
}
