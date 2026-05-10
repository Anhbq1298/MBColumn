using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using #2ic;
using StructurePoint.CoreAssets.DataExchange.ExternFormat;

namespace #Vjc
{
	// Token: 0x0200077D RID: 1917
	internal sealed class #okc : #ijc, #ljc, #pjc
	{
		// Token: 0x170012C5 RID: 4805
		// (get) Token: 0x06003DB2 RID: 15794 RVA: 0x00034C4E File Offset: 0x00032E4E
		// (set) Token: 0x06003DB3 RID: 15795 RVA: 0x00034C5B File Offset: 0x00032E5B
		public bool IsClosed
		{
			get
			{
				return this.#a.IsClosed;
			}
			set
			{
				#skc #skc = this.#a;
				if (2 != 0)
				{
					#skc.IsClosed = value;
				}
			}
		}

		// Token: 0x170012C6 RID: 4806
		// (get) Token: 0x06003DB4 RID: 15796 RVA: 0x00034C70 File Offset: 0x00032E70
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		[SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public List<IVertex> Vertexes
		{
			get
			{
				return this.#a.Vertexes;
			}
		}

		// Token: 0x170012C7 RID: 4807
		// (get) Token: 0x06003DB5 RID: 15797 RVA: 0x00034C7D File Offset: 0x00032E7D
		// (set) Token: 0x06003DB6 RID: 15798 RVA: 0x00034C8A File Offset: 0x00032E8A
		public #jjc Layer
		{
			get
			{
				return this.#a.Layer;
			}
			set
			{
				#skc #skc = this.#a;
				if (2 != 0)
				{
					#skc.Layer = value;
				}
			}
		}

		// Token: 0x170012C8 RID: 4808
		// (get) Token: 0x06003DB7 RID: 15799 RVA: 0x00034C9F File Offset: 0x00032E9F
		// (set) Token: 0x06003DB8 RID: 15800 RVA: 0x00034CA7 File Offset: 0x00032EA7
		public bool IsOpening { get; set; }

		// Token: 0x06003DB9 RID: 15801 RVA: 0x00034CB0 File Offset: 0x00032EB0
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		public #okc(List<#Jkc> #pkc, bool #qkc, #jjc #rR, bool #rkc)
		{
			this.#a = new #skc(#pkc, #qkc, #rR);
			this.IsOpening = #rkc;
		}

		// Token: 0x04001C0C RID: 7180
		private readonly #skc #a;

		// Token: 0x04001C0D RID: 7181
		[CompilerGenerated]
		private bool #b;
	}
}
