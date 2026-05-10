using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using #7hc;
using #zW;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.Products.Column.Core.API;
using StructurePoint.Products.Column.Model;
using StructurePoint.Products.Column.Model.Entities;

namespace StructurePoint.Products.Column.Services.API.Section
{
	// Token: 0x0200031F RID: 799
	internal sealed class SendToIrregularSectionService : #DW
	{
		// Token: 0x06001BB9 RID: 7097 RVA: 0x0001AEFB File Offset: 0x000190FB
		public SendToIrregularSectionService(IExtendedServices services, IEditorService editorService)
		{
			if (services == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107407561));
			}
			this.#a = services;
			if (editorService == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107401352));
			}
			this.#b = editorService;
		}

		// Token: 0x06001BBA RID: 7098 RVA: 0x000BED68 File Offset: 0x000BCF68
		public void #BW(Action<bool> #yf = null)
		{
			SendToIrregularSectionService.#dZb #dZb = new SendToIrregularSectionService.#dZb();
			#dZb.#a = this;
			#dZb.#b = #yf;
			SectionTypeDependentValuesCacheItem sectionTypeDependentValuesCacheItem = this.#a.Project.Model.SectionTypeCacheItems.FirstOrDefault(new Func<SectionTypeDependentValuesCacheItem, bool>(SendToIrregularSectionService.<>c.<>9.#o2b));
			if (sectionTypeDependentValuesCacheItem != null && (sectionTypeDependentValuesCacheItem.Polygons.Any<SectionPolygon>() || sectionTypeDependentValuesCacheItem.Bars.Any<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.ReinforcementBar>()))
			{
				#dZb.#c = this.#a.WindowLocator.#6();
				LayoutHelper.BeginInvokeOnApplicationThread(new Action(#dZb.#n2b));
				return;
			}
			this.#FW();
			Action<bool> action = #dZb.#b;
			if (action == null)
			{
				return;
			}
			action(true);
		}

		// Token: 0x06001BBB RID: 7099 RVA: 0x000BEE40 File Offset: 0x000BD040
		public bool #CW()
		{
			SectionType sectionType = this.#a.Project.Model.Options.SectionType;
			return this.#a.Project.Model.Options.ProblemType == ProblemType.Investigation && (sectionType == SectionType.Circle || sectionType == SectionType.Rectangle || sectionType == SectionType.IrregularTemplate);
		}

		// Token: 0x06001BBC RID: 7100 RVA: 0x0001AF39 File Offset: 0x00019139
		private void #FW()
		{
			this.#b.#0Pb(new Action(this.#GW));
		}

		// Token: 0x06001BBD RID: 7101 RVA: 0x000BEEA0 File Offset: 0x000BD0A0
		[CompilerGenerated]
		private void #GW()
		{
			bool flag = this.#a.Project.Model.Options.SectionType == SectionType.IrregularTemplate;
			List<ShapeModel> collection = this.#a.Project.Model.Shapes.ToList<ShapeModel>();
			List<StructurePoint.Products.Column.Model.Entities.ReinforcementBar> collection2 = this.#a.Project.Model.ReinforcementBars.ToList<StructurePoint.Products.Column.Model.Entities.ReinforcementBar>();
			this.#a.Project.Model.#JY(SectionType.Irregular, false);
			ColumnModelHelper.#2W(this.#a.StorageModelConverter, this.#a.Project.Model);
			ColumnModelHelper.#1W(this.#a.StorageModelConverter, this.#a.Project.Model);
			if (flag)
			{
				this.#a.Project.Model.Shapes.Clear();
				this.#a.Project.Model.ReinforcementBars.Clear();
				this.#a.Project.Model.Shapes.AddRange(collection);
				this.#a.Project.Model.ReinforcementBars.AddRange(collection2);
			}
			this.#a.SnappingCache.#uP(this.#a.Project);
			this.#a.MessageBus.#QV();
		}

		// Token: 0x04000AEE RID: 2798
		private readonly IExtendedServices #a;

		// Token: 0x04000AEF RID: 2799
		private readonly IEditorService #b;

		// Token: 0x02000321 RID: 801
		[CompilerGenerated]
		private sealed class #dZb
		{
			// Token: 0x06001BC2 RID: 7106 RVA: 0x000BF010 File Offset: 0x000BD210
			internal void #n2b()
			{
				string #SSc = Strings.StringExistingIrregularSectionWillBeDiscarded.#z2d().#Tm() + Strings.StringWouldYouLikeToContinue.#J2d();
				MessageBoxResult messageBoxResult = this.#a.#a.DialogService.#3Sc(this.#c, #SSc, MessageBoxButton.OKCancel, MessageBoxResult.Cancel);
				if (messageBoxResult == MessageBoxResult.OK)
				{
					this.#a.#FW();
					Action<bool> action = this.#b;
					if (action == null)
					{
						return;
					}
					action(true);
					return;
				}
				else
				{
					Action<bool> action2 = this.#b;
					if (action2 == null)
					{
						return;
					}
					action2(false);
					return;
				}
			}

			// Token: 0x04000AF2 RID: 2802
			public SendToIrregularSectionService #a;

			// Token: 0x04000AF3 RID: 2803
			public Action<bool> #b;

			// Token: 0x04000AF4 RID: 2804
			public Window #c;
		}
	}
}
