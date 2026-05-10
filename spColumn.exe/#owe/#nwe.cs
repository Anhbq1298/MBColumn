using System;
using System.Runtime.CompilerServices;
using #12e;
using #Wse;
using #yEd;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;

namespace #owe
{
	// Token: 0x02001193 RID: 4499
	internal abstract class #nwe : #xEd
	{
		// Token: 0x06009890 RID: 39056 RVA: 0x0007908B File Offset: 0x0007728B
		protected #nwe(#pwe #ib) : base(#ib)
		{
			this.Context = #ib;
		}

		// Token: 0x17002C47 RID: 11335
		// (get) Token: 0x06009891 RID: 39057 RVA: 0x0007909B File Offset: 0x0007729B
		public new #pwe Context { get; }

		// Token: 0x17002C48 RID: 11336
		// (get) Token: 0x06009892 RID: 39058 RVA: 0x000790A3 File Offset: 0x000772A3
		protected #lte Model
		{
			get
			{
				return this.Context.Model;
			}
		}

		// Token: 0x17002C49 RID: 11337
		// (get) Token: 0x06009893 RID: 39059 RVA: 0x000790B0 File Offset: 0x000772B0
		protected ColumnStorageModel InputModel
		{
			get
			{
				return this.Context.Model.Input;
			}
		}

		// Token: 0x17002C4A RID: 11338
		// (get) Token: 0x06009894 RID: 39060 RVA: 0x000790C2 File Offset: 0x000772C2
		protected #l4e OutputModel
		{
			get
			{
				return this.Context.Model.Output;
			}
		}

		// Token: 0x17002C4B RID: 11339
		// (get) Token: 0x06009895 RID: 39061 RVA: 0x000790D4 File Offset: 0x000772D4
		protected #uwe Options
		{
			get
			{
				return this.Context.Options;
			}
		}

		// Token: 0x040041AA RID: 16810
		[CompilerGenerated]
		private readonly #pwe #a;
	}
}
