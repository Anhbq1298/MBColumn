using System;
using #7hc;
using #n8;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.Products.Column.Model.Entities;

namespace #5Z
{
	// Token: 0x020003AB RID: 939
	internal sealed class #W3 : #20, #q8<#L8>, #L8
	{
		// Token: 0x06001F2E RID: 7982 RVA: 0x0001E5E1 File Offset: 0x0001C7E1
		public #W3()
		{
			this.AboveLeft = new StructurePoint.Products.Column.Model.Entities.Beam();
			this.AboveRight = new StructurePoint.Products.Column.Model.Entities.Beam();
			this.BelowLeft = new StructurePoint.Products.Column.Model.Entities.Beam();
			this.BelowRight = new StructurePoint.Products.Column.Model.Entities.Beam();
		}

		// Token: 0x06001F2F RID: 7983 RVA: 0x000C3678 File Offset: 0x000C1878
		public #W3(SlendernessOfBeams #Rf)
		{
			this.AboveLeft = new StructurePoint.Products.Column.Model.Entities.Beam(#Rf.AboveLeft);
			this.AboveRight = new StructurePoint.Products.Column.Model.Entities.Beam(#Rf.AboveRight);
			this.BelowLeft = new StructurePoint.Products.Column.Model.Entities.Beam(#Rf.BelowLeft);
			this.BelowRight = new StructurePoint.Products.Column.Model.Entities.Beam(#Rf.BelowRight);
		}

		// Token: 0x17000AE3 RID: 2787
		// (get) Token: 0x06001F30 RID: 7984 RVA: 0x000C36D0 File Offset: 0x000C18D0
		public bool HasErrors
		{
			get
			{
				return this.#a.HasErrors || this.#b.HasErrors || this.#c.HasErrors || this.#d.HasErrors;
			}
		}

		// Token: 0x17000AE4 RID: 2788
		// (get) Token: 0x06001F31 RID: 7985 RVA: 0x0001E615 File Offset: 0x0001C815
		// (set) Token: 0x06001F32 RID: 7986 RVA: 0x0001E621 File Offset: 0x0001C821
		public StructurePoint.Products.Column.Model.Entities.Beam AboveLeft
		{
			get
			{
				return this.#a;
			}
			set
			{
				this.SetProperty<StructurePoint.Products.Column.Model.Entities.Beam>(ref this.#a, value, #Phc.#3hc(107412750));
			}
		}

		// Token: 0x17000AE5 RID: 2789
		// (get) Token: 0x06001F33 RID: 7987 RVA: 0x0001E647 File Offset: 0x0001C847
		// (set) Token: 0x06001F34 RID: 7988 RVA: 0x0001E653 File Offset: 0x0001C853
		public StructurePoint.Products.Column.Model.Entities.Beam AboveRight
		{
			get
			{
				return this.#b;
			}
			set
			{
				this.SetProperty<StructurePoint.Products.Column.Model.Entities.Beam>(ref this.#b, value, #Phc.#3hc(107412737));
			}
		}

		// Token: 0x17000AE6 RID: 2790
		// (get) Token: 0x06001F35 RID: 7989 RVA: 0x0001E679 File Offset: 0x0001C879
		// (set) Token: 0x06001F36 RID: 7990 RVA: 0x0001E685 File Offset: 0x0001C885
		public StructurePoint.Products.Column.Model.Entities.Beam BelowLeft
		{
			get
			{
				return this.#c;
			}
			set
			{
				this.SetProperty<StructurePoint.Products.Column.Model.Entities.Beam>(ref this.#c, value, #Phc.#3hc(107412752));
			}
		}

		// Token: 0x17000AE7 RID: 2791
		// (get) Token: 0x06001F37 RID: 7991 RVA: 0x0001E6AB File Offset: 0x0001C8AB
		// (set) Token: 0x06001F38 RID: 7992 RVA: 0x0001E6B7 File Offset: 0x0001C8B7
		public StructurePoint.Products.Column.Model.Entities.Beam BelowRight
		{
			get
			{
				return this.#d;
			}
			set
			{
				this.SetProperty<StructurePoint.Products.Column.Model.Entities.Beam>(ref this.#d, value, #Phc.#3hc(107412195));
			}
		}

		// Token: 0x06001F39 RID: 7993 RVA: 0x000C3720 File Offset: 0x000C1920
		public void CopyFrom(#L8 source)
		{
			this.AboveLeft.CopyFrom(source.AboveLeft);
			this.AboveRight.CopyFrom(source.AboveRight);
			this.BelowLeft.CopyFrom(source.BelowLeft);
			this.BelowRight.CopyFrom(source.BelowRight);
		}

		// Token: 0x06001F3A RID: 7994 RVA: 0x000C3780 File Offset: 0x000C1980
		public SlendernessOfBeams #CY()
		{
			SlendernessOfBeams slendernessOfBeams = new SlendernessOfBeams();
			StructurePoint.Products.Column.Model.Entities.Beam beam = this.BelowLeft;
			StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Beam belowLeft;
			if ((belowLeft = ((beam != null) ? beam.#CY() : null)) == null)
			{
				belowLeft = new StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Beam();
			}
			slendernessOfBeams.BelowLeft = belowLeft;
			StructurePoint.Products.Column.Model.Entities.Beam beam2 = this.BelowRight;
			StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Beam belowRight;
			if ((belowRight = ((beam2 != null) ? beam2.#CY() : null)) == null)
			{
				belowRight = new StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Beam();
			}
			slendernessOfBeams.BelowRight = belowRight;
			StructurePoint.Products.Column.Model.Entities.Beam beam3 = this.AboveLeft;
			StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Beam aboveLeft;
			if ((aboveLeft = ((beam3 != null) ? beam3.#CY() : null)) == null)
			{
				aboveLeft = new StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Beam();
			}
			slendernessOfBeams.AboveLeft = aboveLeft;
			StructurePoint.Products.Column.Model.Entities.Beam beam4 = this.AboveRight;
			slendernessOfBeams.AboveRight = (((beam4 != null) ? beam4.#CY() : null) ?? new StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Beam());
			return slendernessOfBeams;
		}

		// Token: 0x04000C59 RID: 3161
		private StructurePoint.Products.Column.Model.Entities.Beam #a;

		// Token: 0x04000C5A RID: 3162
		private StructurePoint.Products.Column.Model.Entities.Beam #b;

		// Token: 0x04000C5B RID: 3163
		private StructurePoint.Products.Column.Model.Entities.Beam #c;

		// Token: 0x04000C5C RID: 3164
		private StructurePoint.Products.Column.Model.Entities.Beam #d;
	}
}
