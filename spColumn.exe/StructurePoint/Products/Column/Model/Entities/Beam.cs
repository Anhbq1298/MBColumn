using System;
using #7hc;
using #n8;
using #xZ;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.Products.Column.Model.Validation.API.Slenderness;

namespace StructurePoint.Products.Column.Model.Entities
{
	// Token: 0x02000398 RID: 920
	[#zZ(typeof(ISlendernessBeamsValidator))]
	internal sealed class Beam : ValidatableBaseEntity, #q8<#o8>, #o8, IBeam
	{
		// Token: 0x06001DDE RID: 7646 RVA: 0x0001CA5C File Offset: 0x0001AC5C
		public Beam()
		{
			this.#a = BeamType.None;
		}

		// Token: 0x06001DDF RID: 7647 RVA: 0x000C2084 File Offset: 0x000C0284
		public Beam(IBeam item)
		{
			this.#a = ((item.BeamType == BeamType.Undefined) ? BeamType.None : item.BeamType);
			this.#b = item.Length;
			this.#c = item.Width;
			this.#d = item.Depth;
			this.#e = item.MofI;
			this.#f = item.Fcp;
			this.#g = item.Ec;
			this.#h = item.IsConcreteStandard;
			this.#i = item.IsInertiaStandard;
		}

		// Token: 0x17000A64 RID: 2660
		// (get) Token: 0x06001DE0 RID: 7648 RVA: 0x0001CA6B File Offset: 0x0001AC6B
		// (set) Token: 0x06001DE1 RID: 7649 RVA: 0x0001CA77 File Offset: 0x0001AC77
		public BeamType BeamType
		{
			get
			{
				return this.#a;
			}
			set
			{
				base.#Z0<BeamType>(ref this.#a, value, #Phc.#3hc(107412484));
			}
		}

		// Token: 0x17000A65 RID: 2661
		// (get) Token: 0x06001DE2 RID: 7650 RVA: 0x0001CA9D File Offset: 0x0001AC9D
		// (set) Token: 0x06001DE3 RID: 7651 RVA: 0x0001CAA9 File Offset: 0x0001ACA9
		public float Length
		{
			get
			{
				return this.#b;
			}
			set
			{
				base.#Z0<float>(ref this.#b, value, #Phc.#3hc(107412503));
			}
		}

		// Token: 0x17000A66 RID: 2662
		// (get) Token: 0x06001DE4 RID: 7652 RVA: 0x0001CACF File Offset: 0x0001ACCF
		// (set) Token: 0x06001DE5 RID: 7653 RVA: 0x0001CADB File Offset: 0x0001ACDB
		public float Width
		{
			get
			{
				return this.#c;
			}
			set
			{
				base.#Z0<float>(ref this.#c, value, #Phc.#3hc(107412974));
			}
		}

		// Token: 0x17000A67 RID: 2663
		// (get) Token: 0x06001DE6 RID: 7654 RVA: 0x0001CB01 File Offset: 0x0001AD01
		// (set) Token: 0x06001DE7 RID: 7655 RVA: 0x0001CB0D File Offset: 0x0001AD0D
		public float Depth
		{
			get
			{
				return this.#d;
			}
			set
			{
				base.#Z0<float>(ref this.#d, value, #Phc.#3hc(107412965));
			}
		}

		// Token: 0x17000A68 RID: 2664
		// (get) Token: 0x06001DE8 RID: 7656 RVA: 0x0001CB33 File Offset: 0x0001AD33
		// (set) Token: 0x06001DE9 RID: 7657 RVA: 0x0001CB3F File Offset: 0x0001AD3F
		public float MofI
		{
			get
			{
				return this.#e;
			}
			set
			{
				base.#Z0<float>(ref this.#e, value, #Phc.#3hc(107412988));
			}
		}

		// Token: 0x17000A69 RID: 2665
		// (get) Token: 0x06001DEA RID: 7658 RVA: 0x0001CB65 File Offset: 0x0001AD65
		// (set) Token: 0x06001DEB RID: 7659 RVA: 0x0001CB71 File Offset: 0x0001AD71
		public float Fcp
		{
			get
			{
				return this.#f;
			}
			set
			{
				base.#Z0<float>(ref this.#f, value, #Phc.#3hc(107412979));
			}
		}

		// Token: 0x17000A6A RID: 2666
		// (get) Token: 0x06001DEC RID: 7660 RVA: 0x0001CB97 File Offset: 0x0001AD97
		// (set) Token: 0x06001DED RID: 7661 RVA: 0x0001CBA3 File Offset: 0x0001ADA3
		public float Ec
		{
			get
			{
				return this.#g;
			}
			set
			{
				base.#Z0<float>(ref this.#g, value, #Phc.#3hc(107412942));
			}
		}

		// Token: 0x17000A6B RID: 2667
		// (get) Token: 0x06001DEE RID: 7662 RVA: 0x0001CBC9 File Offset: 0x0001ADC9
		// (set) Token: 0x06001DEF RID: 7663 RVA: 0x0001CBD5 File Offset: 0x0001ADD5
		public bool IsConcreteStandard
		{
			get
			{
				return this.#h;
			}
			set
			{
				base.#Z0<bool>(ref this.#h, value, #Phc.#3hc(107412937));
			}
		}

		// Token: 0x17000A6C RID: 2668
		// (get) Token: 0x06001DF0 RID: 7664 RVA: 0x0001CBFB File Offset: 0x0001ADFB
		// (set) Token: 0x06001DF1 RID: 7665 RVA: 0x0001CC07 File Offset: 0x0001AE07
		public bool IsInertiaStandard
		{
			get
			{
				return this.#i;
			}
			set
			{
				base.#Z0<bool>(ref this.#i, value, #Phc.#3hc(107412944));
			}
		}

		// Token: 0x06001DF2 RID: 7666 RVA: 0x000C2110 File Offset: 0x000C0310
		public void CopyFrom(#o8 source)
		{
			this.BeamType = source.BeamType;
			this.Length = source.Length;
			this.Width = source.Width;
			this.Depth = source.Depth;
			this.MofI = source.MofI;
			this.Fcp = source.Fcp;
			this.Ec = source.Ec;
			this.IsConcreteStandard = source.IsConcreteStandard;
			this.IsInertiaStandard = source.IsInertiaStandard;
		}

		// Token: 0x06001DF3 RID: 7667 RVA: 0x000C2198 File Offset: 0x000C0398
		public Beam #CY()
		{
			return new Beam
			{
				Length = this.Length,
				Width = this.Width,
				Depth = this.Depth,
				Fcp = this.Fcp,
				MofI = this.MofI,
				Ec = this.Ec,
				BeamType = this.BeamType,
				IsConcreteStandard = this.IsConcreteStandard,
				IsInertiaStandard = this.IsInertiaStandard
			};
		}

		// Token: 0x04000BE5 RID: 3045
		private BeamType #a;

		// Token: 0x04000BE6 RID: 3046
		private float #b;

		// Token: 0x04000BE7 RID: 3047
		private float #c;

		// Token: 0x04000BE8 RID: 3048
		private float #d;

		// Token: 0x04000BE9 RID: 3049
		private float #e;

		// Token: 0x04000BEA RID: 3050
		private float #f;

		// Token: 0x04000BEB RID: 3051
		private float #g;

		// Token: 0x04000BEC RID: 3052
		private bool #h;

		// Token: 0x04000BED RID: 3053
		private bool #i;
	}
}
