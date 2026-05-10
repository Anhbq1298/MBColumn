using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using #7hc;
using #Fmc;
using #NWc;
using #T0c;
using #UYd;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor.Drawing;
using StructurePoint.CoreAssets.GUI.Framework.Tools.Selection;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace #hLc
{
	// Token: 0x02000BC2 RID: 3010
	internal abstract class #OLc : IEntitiesSelector
	{
		// Token: 0x0600627B RID: 25211 RVA: 0x00180F00 File Offset: 0x0017F100
		protected #OLc(#oW #Yc, #V0c #uLc, #Qrc #NDc, #GLc #vLc)
		{
			#X0d.#V0d(#Yc, #Phc.#3hc(107383985), Component.GUIFramework, #Phc.#3hc(107414788));
			#X0d.#V0d(#uLc, #Phc.#3hc(107414223), Component.GUIFramework, #Phc.#3hc(107414226));
			#X0d.#V0d(#NDc, #Phc.#3hc(107417084), Component.GUIFramework, #Phc.#3hc(107414173));
			#X0d.#V0d(#vLc, #Phc.#3hc(107414088), Component.GUIFramework, #Phc.#3hc(107414055));
			this.ProjectContext = #Yc;
			this.ModelEditorViewModel = #uLc;
			this.SnappingProvider = #NDc;
			this.EntitiesSelectorSettings = #vLc;
			this.SupportsSnapping = true;
		}

		// Token: 0x17001BEC RID: 7148
		// (get) Token: 0x0600627C RID: 25212 RVA: 0x00050595 File Offset: 0x0004E795
		// (set) Token: 0x0600627D RID: 25213 RVA: 0x0005059D File Offset: 0x0004E79D
		public virtual bool IsActive { get; set; }

		// Token: 0x17001BED RID: 7149
		// (get) Token: 0x0600627E RID: 25214 RVA: 0x000505A6 File Offset: 0x0004E7A6
		// (set) Token: 0x0600627F RID: 25215 RVA: 0x000505AE File Offset: 0x0004E7AE
		public bool SupportsSnapping { get; set; }

		// Token: 0x17001BEE RID: 7150
		// (get) Token: 0x06006280 RID: 25216 RVA: 0x000505B7 File Offset: 0x0004E7B7
		// (set) Token: 0x06006281 RID: 25217 RVA: 0x000505BF File Offset: 0x0004E7BF
		private protected #oW ProjectContext { protected get; private set; }

		// Token: 0x17001BEF RID: 7151
		// (get) Token: 0x06006282 RID: 25218 RVA: 0x000505C8 File Offset: 0x0004E7C8
		// (set) Token: 0x06006283 RID: 25219 RVA: 0x000505D0 File Offset: 0x0004E7D0
		private protected #V0c ModelEditorViewModel { protected get; private set; }

		// Token: 0x17001BF0 RID: 7152
		// (get) Token: 0x06006284 RID: 25220 RVA: 0x000505D9 File Offset: 0x0004E7D9
		// (set) Token: 0x06006285 RID: 25221 RVA: 0x000505E1 File Offset: 0x0004E7E1
		public #Qrc SnappingProvider { get; private set; }

		// Token: 0x17001BF1 RID: 7153
		// (get) Token: 0x06006286 RID: 25222 RVA: 0x000505EA File Offset: 0x0004E7EA
		// (set) Token: 0x06006287 RID: 25223 RVA: 0x000505F2 File Offset: 0x0004E7F2
		public #GLc EntitiesSelectorSettings { get; private set; }

		// Token: 0x06006288 RID: 25224
		public abstract IReadOnlyList<object> #qLc();

		// Token: 0x06006289 RID: 25225 RVA: 0x00180FA8 File Offset: 0x0017F1A8
		protected bool #Dzb(Point3D? #Xrb, Point3D #Yrb)
		{
			int result;
			Point3D #ncb;
			for (;;)
			{
				bool flag = (result = ((#Xrb != null) ? 1 : 0)) != 0;
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
					Point3D value = #Xrb.Value;
					if (!false)
					{
						#ncb = value;
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
			return GeometryHelper.#lcb(#Yrb, #ncb) > this.SnappingProvider.MaxDistance;
		}

		// Token: 0x0600628A RID: 25226 RVA: 0x00180FEC File Offset: 0x0017F1EC
		protected PolygonData #LLc(bool #MLc, Point3D? #Xrb, Point3D #Yrb)
		{
			if (!#MLc || #Xrb == null)
			{
				return null;
			}
			bool flag3;
			bool flag2;
			bool flag = flag2 = (flag3 = this.#Dzb(#Xrb, #Yrb));
			if (8 != 0)
			{
				if (false)
				{
					goto IL_3C;
				}
				if (!flag)
				{
					#Xrb = null;
				}
				flag2 = (#Xrb != null);
			}
			if (!flag2)
			{
				goto IL_54;
			}
			IL_2F:
			flag3 = GeometryHelper.#6nc(#Xrb.Value, #Yrb);
			IL_3C:
			if (flag3)
			{
				if (!false)
				{
					return new PolygonData(#OLc.#NLc(#Xrb.Value, #Yrb));
				}
				goto IL_2F;
			}
			IL_54:
			return null;
		}

		// Token: 0x0600628B RID: 25227
		public abstract void #uR(IEnumerable<object> #8f);

		// Token: 0x0600628C RID: 25228
		public abstract void #ljb(object #Rf);

		// Token: 0x0600628D RID: 25229
		public abstract void #rLc(IEnumerable<object> #8f);

		// Token: 0x0600628E RID: 25230
		public abstract void #rLc(object #Rf);

		// Token: 0x0600628F RID: 25231
		public abstract bool #sLc(object #Rf);

		// Token: 0x06006290 RID: 25232
		public abstract IReadOnlyList<object> #wLc(bool #xLc, Point3D? #Xrb, Point3D #Yrb);

		// Token: 0x06006291 RID: 25233 RVA: 0x00181050 File Offset: 0x0017F250
		private static List<Point3D> #NLc(Point3D #Xrb, Point3D #Yrb)
		{
			List<Point3D> list2;
			if (4 != 0)
			{
				List<Point3D> list = new List<Point3D>();
				if (6 != 0)
				{
					list2 = list;
				}
				List<Point3D> list3 = list2;
				IEnumerable<Point3D> collection = GeometryHelper.#8nc(#Xrb, #Yrb);
				if (!false)
				{
					list3.AddRange(collection);
				}
				if (!false && !VisualMeshTriangulator.CanPerformTriangulation(list2))
				{
					List<Point3D> list4 = list2;
					if (!false)
					{
						list4.Clear();
					}
				}
			}
			return list2;
		}

		// Token: 0x0400287A RID: 10362
		[CompilerGenerated]
		private bool #a;

		// Token: 0x0400287B RID: 10363
		[CompilerGenerated]
		private bool #b;

		// Token: 0x0400287C RID: 10364
		[CompilerGenerated]
		private #oW #c;

		// Token: 0x0400287D RID: 10365
		[CompilerGenerated]
		private #V0c #d;

		// Token: 0x0400287E RID: 10366
		[CompilerGenerated]
		private #Qrc #e;

		// Token: 0x0400287F RID: 10367
		[CompilerGenerated]
		private #GLc #f;
	}
}
