using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using #eU;
using #LQc;
using #wD;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.GUI.Framework.Collections;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.Products.Column.Model.Entities;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.ViewModels.Loads.Modules;

namespace StructurePoint.Products.Column.ViewModels.Loads
{
	// Token: 0x020001D6 RID: 470
	internal sealed class ServiceLoadsToFactoredLoadsService : #vD
	{
		// Token: 0x0600107E RID: 4222 RVA: 0x000A6D54 File Offset: 0x000A4F54
		public ServiceLoadsToFactoredLoadsService(IExtendedServices services, #qW designEngine, #8Sc dialogService)
		{
			this.#a = services;
			this.#b = designEngine;
			this.#c = dialogService;
			this.#d = new List<FactoredLoad>();
		}

		// Token: 0x1700062E RID: 1582
		// (get) Token: 0x0600107F RID: 4223 RVA: 0x00012AF2 File Offset: 0x00010CF2
		public List<FactoredLoad> FactoredLoads { get; }

		// Token: 0x1700062F RID: 1583
		// (get) Token: 0x06001080 RID: 4224 RVA: 0x00012AFE File Offset: 0x00010CFE
		// (set) Token: 0x06001081 RID: 4225 RVA: 0x00012B0A File Offset: 0x00010D0A
		public CustomObservableCollection<LoadGroup> ServiceLoadsItemsGroup { private get; set; }

		// Token: 0x17000630 RID: 1584
		// (get) Token: 0x06001082 RID: 4226 RVA: 0x00012B1B File Offset: 0x00010D1B
		// (set) Token: 0x06001083 RID: 4227 RVA: 0x00012B27 File Offset: 0x00010D27
		public Func<bool> ServiceLoadsChangedFunc { get; set; }

		// Token: 0x06001084 RID: 4228 RVA: 0x00012B38 File Offset: 0x00010D38
		public bool #uB()
		{
			return this.ServiceLoadsItemsGroup.Any<LoadGroup>();
		}

		// Token: 0x06001085 RID: 4229 RVA: 0x000A6DAC File Offset: 0x000A4FAC
		public bool #vB()
		{
			this.FactoredLoads.Clear();
			if (this.ServiceLoadsChangedFunc())
			{
				this.#c.#qn(this.#c.ActiveWindow, Strings.StringCannotConvertServiceLoads.#z2d().#Tm().#Tm() + Strings.StringServiceLoadsHaveChanged.#z2d().#Tm() + Strings.StringPleaseSaveTheChangesAndRunTheSolver.#z2d());
				return false;
			}
			if (this.#b.DesignEngine == null)
			{
				this.#c.#pn(this.#c.ActiveWindow, Strings.StringCouldNotConvertLoads.#z2d(true) + Strings.StringProjectMustBeSolvedFirst.#z2d());
				return false;
			}
			if (this.#a.Project.Model.Options.ActiveLoad != LoadType.Service)
			{
				string #SSc = this.#c.#5Sc(Strings.StringCannotConvertServiceLoads.#z2d(), Strings.StringNoServiceLoadsAvailableInResults.#z2d());
				this.#c.#qn(this.#c.ActiveWindow, #SSc);
				return false;
			}
			try
			{
				for (int i = 0; i < this.#b.DesignEngine.FactoredLoads.NumberOfLoads; i++)
				{
					LoadsExt loadsExt = this.#b.DesignEngine.FactoredLoads.Loads[i];
					FactoredLoad item = new FactoredLoad(loadsExt.AxialLoad, loadsExt.MomentX, loadsExt.MomentY);
					this.FactoredLoads.Add(item);
				}
			}
			catch (Exception #ob)
			{
				this.#a.ExceptionHandler.#3Ab(Strings.StringCouldNotConvertLoads.#z2d(), #ob);
			}
			return true;
		}

		// Token: 0x04000683 RID: 1667
		private readonly IExtendedServices #a;

		// Token: 0x04000684 RID: 1668
		private readonly #qW #b;

		// Token: 0x04000685 RID: 1669
		private readonly #8Sc #c;

		// Token: 0x04000686 RID: 1670
		[CompilerGenerated]
		private readonly List<FactoredLoad> #d;

		// Token: 0x04000687 RID: 1671
		[CompilerGenerated]
		private CustomObservableCollection<LoadGroup> #e;

		// Token: 0x04000688 RID: 1672
		[CompilerGenerated]
		private Func<bool> #f = new Func<bool>(ServiceLoadsToFactoredLoadsService.<>c.<>9.#DXb);
	}
}
