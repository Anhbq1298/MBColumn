using System;
using #7hc;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;

namespace #5Z
{
	// Token: 0x020003A4 RID: 932
	internal sealed class #r3 : #20
	{
		// Token: 0x06001ECA RID: 7882 RVA: 0x0001CC2D File Offset: 0x0001AE2D
		public #r3()
		{
		}

		// Token: 0x06001ECB RID: 7883 RVA: 0x0001DEA5 File Offset: 0x0001C0A5
		public #r3(ProjectInfo #Rf)
		{
			this.FileVersion = #Rf.FileVersion;
			this.Project = #Rf.Project;
			this.ColumnId = #Rf.ColumnId;
			this.Engineer = #Rf.Engineer;
		}

		// Token: 0x17000AC1 RID: 2753
		// (get) Token: 0x06001ECC RID: 7884 RVA: 0x0001DEDD File Offset: 0x0001C0DD
		// (set) Token: 0x06001ECD RID: 7885 RVA: 0x0001DEE9 File Offset: 0x0001C0E9
		public float FileVersion
		{
			get
			{
				return this.#a;
			}
			set
			{
				this.SetProperty<float>(ref this.#a, value, #Phc.#3hc(107398456));
			}
		}

		// Token: 0x17000AC2 RID: 2754
		// (get) Token: 0x06001ECE RID: 7886 RVA: 0x0001DF0F File Offset: 0x0001C10F
		// (set) Token: 0x06001ECF RID: 7887 RVA: 0x0001DF1B File Offset: 0x0001C11B
		public string Project
		{
			get
			{
				return this.#b;
			}
			set
			{
				this.SetProperty<string>(ref this.#b, value, #Phc.#3hc(107400800));
			}
		}

		// Token: 0x17000AC3 RID: 2755
		// (get) Token: 0x06001ED0 RID: 7888 RVA: 0x0001DF41 File Offset: 0x0001C141
		// (set) Token: 0x06001ED1 RID: 7889 RVA: 0x0001DF4D File Offset: 0x0001C14D
		public string ColumnId
		{
			get
			{
				return this.#c;
			}
			set
			{
				this.SetProperty<string>(ref this.#c, value, #Phc.#3hc(107398407));
			}
		}

		// Token: 0x17000AC4 RID: 2756
		// (get) Token: 0x06001ED2 RID: 7890 RVA: 0x0001DF73 File Offset: 0x0001C173
		// (set) Token: 0x06001ED3 RID: 7891 RVA: 0x0001DF7F File Offset: 0x0001C17F
		public string Engineer
		{
			get
			{
				return this.#d;
			}
			set
			{
				this.SetProperty<string>(ref this.#d, value, #Phc.#3hc(107398426));
			}
		}

		// Token: 0x06001ED4 RID: 7892 RVA: 0x000C2E88 File Offset: 0x000C1088
		public ProjectInfo #CY()
		{
			return new ProjectInfo
			{
				Project = this.Project,
				ColumnId = this.ColumnId,
				FileVersion = this.FileVersion,
				Engineer = this.Engineer
			};
		}

		// Token: 0x04000C40 RID: 3136
		private float #a;

		// Token: 0x04000C41 RID: 3137
		private string #b;

		// Token: 0x04000C42 RID: 3138
		private string #c;

		// Token: 0x04000C43 RID: 3139
		private string #d;
	}
}
