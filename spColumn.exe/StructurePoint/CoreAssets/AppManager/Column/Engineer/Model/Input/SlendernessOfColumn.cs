using System;
using System.Runtime.CompilerServices;
using StructurePoint.CoreAssets.AppManager.Column.Storage.Legacy.Entities;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;

namespace StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Input
{
	// Token: 0x0200136D RID: 4973
	public sealed class SlendernessOfColumn
	{
		// Token: 0x0600A727 RID: 42791 RVA: 0x00232670 File Offset: 0x00230870
		public SlendernessOfColumn(SlendernessOfColumn item)
		{
			this.IsNoColumnPresent = (item.SlendernessColumnType == SlendernessColumnType.None);
			this.Height = item.Height;
			this.Ec = item.Ec;
			this.IsConcreteStandard = item.IsConcreteStandard;
			if (item.SlendernessColumnType == SlendernessColumnType.Circular)
			{
				float[] array = new float[2];
				array[0] = item.Depth;
				this.Dimension = array;
				return;
			}
			if (item.SlendernessColumnType == SlendernessColumnType.Rectangular)
			{
				this.Dimension = new float[]
				{
					item.Width,
					item.Depth
				};
				return;
			}
			this.Dimension = new float[2];
		}

		// Token: 0x0600A728 RID: 42792 RVA: 0x0023270C File Offset: 0x0023090C
		internal SlendernessOfColumn(SLDABVBLWCOL item)
		{
			this.IsNoColumnPresent = (item.#a == 1);
			this.Height = item.#b;
			this.Ec = item.#e;
			this.Dimension = (float[])item.#c.Clone();
		}

		// Token: 0x17003077 RID: 12407
		// (get) Token: 0x0600A729 RID: 42793 RVA: 0x00081FB1 File Offset: 0x000801B1
		public bool IsNoColumnPresent { get; }

		// Token: 0x17003078 RID: 12408
		// (get) Token: 0x0600A72A RID: 42794 RVA: 0x00081FB9 File Offset: 0x000801B9
		public float Height { get; }

		// Token: 0x17003079 RID: 12409
		// (get) Token: 0x0600A72B RID: 42795 RVA: 0x00081FC1 File Offset: 0x000801C1
		public float[] Dimension { get; }

		// Token: 0x1700307A RID: 12410
		// (get) Token: 0x0600A72C RID: 42796 RVA: 0x00081FC9 File Offset: 0x000801C9
		public float Ec { get; }

		// Token: 0x1700307B RID: 12411
		// (get) Token: 0x0600A72D RID: 42797 RVA: 0x00081FD1 File Offset: 0x000801D1
		public bool IsConcreteStandard { get; }

		// Token: 0x040049A2 RID: 18850
		[CompilerGenerated]
		private readonly bool #a;

		// Token: 0x040049A3 RID: 18851
		[CompilerGenerated]
		private readonly float #b;

		// Token: 0x040049A4 RID: 18852
		[CompilerGenerated]
		private readonly float[] #c;

		// Token: 0x040049A5 RID: 18853
		[CompilerGenerated]
		private readonly float #d;

		// Token: 0x040049A6 RID: 18854
		[CompilerGenerated]
		private readonly bool #e;
	}
}
