using System;
using System.Collections.Generic;
using System.Linq;
using #5Z;
using #IW;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.Products.Column.Services.API;

namespace #OT
{
	// Token: 0x02000306 RID: 774
	internal sealed class #aU : #KW
	{
		// Token: 0x06001AC5 RID: 6853 RVA: 0x0001A723 File Offset: 0x00018923
		public #aU(ICoreServices #0c)
		{
			this.#a = #0c;
		}

		// Token: 0x170009B8 RID: 2488
		// (get) Token: 0x06001AC6 RID: 6854 RVA: 0x0001A732 File Offset: 0x00018932
		public LoadType CurrentLoadType
		{
			get
			{
				return this.#9T();
			}
		}

		// Token: 0x06001AC7 RID: 6855 RVA: 0x0001A742 File Offset: 0x00018942
		public bool #1T(LoadType #GB)
		{
			switch (#GB)
			{
			case LoadType.Factored:
				return this.#6T();
			case LoadType.Axial:
				return this.#8T();
			case LoadType.NoLoads:
				return this.#7T();
			}
			return true;
		}

		// Token: 0x06001AC8 RID: 6856 RVA: 0x0001A782 File Offset: 0x00018982
		public LoadType #2T()
		{
			return #aU.#b.FirstOrDefault(new Func<LoadType, bool>(this.#1T));
		}

		// Token: 0x06001AC9 RID: 6857 RVA: 0x000BDB6C File Offset: 0x000BBD6C
		public void #3T(LoadType #4T)
		{
			#k3 #k = this.#a.Project.Model.Options;
			if (#k.ProblemType == ProblemType.Design)
			{
				#k.DesignLoad = #4T;
			}
			else
			{
				#k.InvestigationLoad = #4T;
			}
			this.#5T();
		}

		// Token: 0x06001ACA RID: 6858 RVA: 0x000BDBBC File Offset: 0x000BBDBC
		public void #5T()
		{
			bool flag = this.#1T(this.CurrentLoadType);
			if (flag)
			{
				return;
			}
			LoadType #4T = this.#2T();
			this.#3T(#4T);
		}

		// Token: 0x06001ACB RID: 6859 RVA: 0x0001A79F File Offset: 0x0001899F
		private bool #6T()
		{
			return !this.#a.Project.Model.Options.ConsiderSlenderness;
		}

		// Token: 0x06001ACC RID: 6860 RVA: 0x000BDBF4 File Offset: 0x000BBDF4
		private bool #7T()
		{
			return !this.#a.Project.Model.Options.ConsiderSlenderness && this.#a.Project.Model.Options.ProblemType == ProblemType.Investigation;
		}

		// Token: 0x06001ACD RID: 6861 RVA: 0x000BDC48 File Offset: 0x000BBE48
		private bool #8T()
		{
			return !this.#a.Project.Model.Options.ConsiderSlenderness && this.#a.Project.Model.Options.ProblemType == ProblemType.Investigation && this.#a.Project.Model.Options.ConsideredAxis != ConsideredAxis.Both;
		}

		// Token: 0x06001ACE RID: 6862 RVA: 0x000BDCBC File Offset: 0x000BBEBC
		private LoadType #9T()
		{
			#k3 #k = this.#a.Project.Model.Options;
			ProblemType problemType = #k.ProblemType;
			return (problemType == ProblemType.Design) ? #k.DesignLoad : #k.InvestigationLoad;
		}

		// Token: 0x04000AAF RID: 2735
		private readonly ICoreServices #a;

		// Token: 0x04000AB0 RID: 2736
		public static readonly IList<LoadType> #b = new List<LoadType>
		{
			LoadType.Factored,
			LoadType.NoLoads,
			LoadType.Axial,
			LoadType.Service,
			LoadType.Undefined
		};
	}
}
