using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using #7hc;
using #lH;
using #N6c;
using #Oze;
using #S9;
using #sUd;
using #xBe;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.CoreAssets.GUI.Framework.Collections;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.Products.Column.FailureSurface.Views;
using StructurePoint.Products.Column.Services.API;
using Telerik.Windows.Controls;

namespace #nib
{
	// Token: 0x0200041C RID: 1052
	internal sealed class #ujb : #HH<ISuperImposeView>, INotifyPropertyChanged, IViewModel<ISuperImposeView>, IViewModel, #sib
	{
		// Token: 0x06002626 RID: 9766 RVA: 0x000D5C78 File Offset: 0x000D3E78
		public #ujb(Lazy<ISuperImposeView> #Ee, ICoreServices #vjb, #mAe #6c, #zBe #xq, #tbb #4c, #tUd #5x) : base(#Ee, #vjb)
		{
			this.#e = #6c;
			this.#f = #4c;
			this.#g = new DelegateCommand(new Action<object>(this.#pjb), new Predicate<object>(this.#dD));
			this.#h = new DelegateCommand(new Action<object>(this.#rjb), new Predicate<object>(this.#qjb));
			this.#i = new DelegateCommand(new Action<object>(this.#tjb));
			this.#j = new DelegateCommand(new Action<object>(this.#Ug), new Predicate<object>(this.#Zo));
			this.#a = #xq;
			this.#b = #5x;
			#6c.Diagrams.ItemChanged += this.#ojb;
		}

		// Token: 0x140000A8 RID: 168
		// (add) Token: 0x06002627 RID: 9767 RVA: 0x000D5D44 File Offset: 0x000D3F44
		// (remove) Token: 0x06002628 RID: 9768 RVA: 0x000D5D88 File Offset: 0x000D3F88
		public event EventHandler RequestClose
		{
			[CompilerGenerated]
			add
			{
				EventHandler eventHandler = this.#d;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#d, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler eventHandler = this.#d;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#d, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x17000CE6 RID: 3302
		// (get) Token: 0x06002629 RID: 9769 RVA: 0x00023D0B File Offset: 0x00021F0B
		public #mAe SuperImposeContext { get; }

		// Token: 0x17000CE7 RID: 3303
		// (get) Token: 0x0600262A RID: 9770 RVA: 0x00023D17 File Offset: 0x00021F17
		public #tbb DiagramsContext { get; }

		// Token: 0x17000CE8 RID: 3304
		// (get) Token: 0x0600262B RID: 9771 RVA: 0x00023D23 File Offset: 0x00021F23
		public DelegateCommand AddNewRowCommand { get; }

		// Token: 0x17000CE9 RID: 3305
		// (get) Token: 0x0600262C RID: 9772 RVA: 0x00023D2F File Offset: 0x00021F2F
		public DelegateCommand RemoveRowCommand { get; }

		// Token: 0x17000CEA RID: 3306
		// (get) Token: 0x0600262D RID: 9773 RVA: 0x00023D3B File Offset: 0x00021F3B
		public DelegateCommand RedrawDiagramCommand { get; }

		// Token: 0x17000CEB RID: 3307
		// (get) Token: 0x0600262E RID: 9774 RVA: 0x00023D47 File Offset: 0x00021F47
		// (set) Token: 0x0600262F RID: 9775 RVA: 0x00023D53 File Offset: 0x00021F53
		public SuperImposeDiagram SelectedItem
		{
			get
			{
				return this.#c;
			}
			set
			{
				this.SetProperty<SuperImposeDiagram>(ref this.#c, value, #Phc.#3hc(107407441));
				this.#vh();
			}
		}

		// Token: 0x17000CEC RID: 3308
		// (get) Token: 0x06002630 RID: 9776 RVA: 0x00023D7F File Offset: 0x00021F7F
		public DelegateCommand CloseCommand { get; }

		// Token: 0x17000CED RID: 3309
		// (get) Token: 0x06002631 RID: 9777 RVA: 0x00023D8B File Offset: 0x00021F8B
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x06002632 RID: 9778 RVA: 0x00023D9B File Offset: 0x00021F9B
		public void #cg()
		{
			this.#vh();
		}

		// Token: 0x06002633 RID: 9779 RVA: 0x00023DAB File Offset: 0x00021FAB
		protected override void #vh()
		{
			base.#vh();
			this.AddNewRowCommand.InvalidateCanExecute();
			this.RemoveRowCommand.InvalidateCanExecute();
		}

		// Token: 0x06002634 RID: 9780 RVA: 0x00023DD5 File Offset: 0x00021FD5
		protected void #njb()
		{
			EventHandler eventHandler = this.#d;
			if (eventHandler == null)
			{
				return;
			}
			eventHandler(this, EventArgs.Empty);
		}

		// Token: 0x06002635 RID: 9781 RVA: 0x00023DF9 File Offset: 0x00021FF9
		private void #ojb(object #Ge, #O6c #He)
		{
			if (this.SuperImposeContext.IsActive && #He.PropertyName == #Phc.#3hc(107408148))
			{
				this.RedrawDiagramCommand.Execute(null);
			}
		}

		// Token: 0x06002636 RID: 9782 RVA: 0x00023E37 File Offset: 0x00022037
		private void #Ug(object #Sb)
		{
			this.#njb();
		}

		// Token: 0x06002637 RID: 9783 RVA: 0x00003375 File Offset: 0x00001575
		private bool #Zo(object #Sb)
		{
			return true;
		}

		// Token: 0x06002638 RID: 9784 RVA: 0x00023E47 File Offset: 0x00022047
		private bool #dD(object #Sb)
		{
			return this.SuperImposeContext.CanAddDiagram;
		}

		// Token: 0x06002639 RID: 9785 RVA: 0x000D5DCC File Offset: 0x000D3FCC
		private void #pjb(object #Sb)
		{
			IReadOnlyList<#DBe> readOnlyList = this.#rq();
			foreach (#DBe #jAe in readOnlyList)
			{
				this.SuperImposeContext.#iAe(#jAe);
			}
			this.#sjb();
		}

		// Token: 0x0600263A RID: 9786 RVA: 0x00023E60 File Offset: 0x00022060
		private bool #qjb(object #Sb)
		{
			return this.SelectedItem != null && this.SuperImposeContext.Diagrams.Count > 1;
		}

		// Token: 0x0600263B RID: 9787 RVA: 0x000D5E34 File Offset: 0x000D4034
		private void #rjb(object #Sb)
		{
			if (this.SelectedItem == null)
			{
				return;
			}
			GridViewDeletingEventArgs gridViewDeletingEventArgs = #Sb as GridViewDeletingEventArgs;
			if (gridViewDeletingEventArgs != null)
			{
				gridViewDeletingEventArgs.Cancel = true;
			}
			CustomObservableCollection<SuperImposeDiagram> customObservableCollection = this.SuperImposeContext.Diagrams;
			int num = customObservableCollection.#C7c(this.SelectedItem);
			this.SuperImposeContext.#kAe(this.SelectedItem);
			this.SelectedItem = ((num < customObservableCollection.Count) ? customObservableCollection[num] : customObservableCollection.LastOrDefault<SuperImposeDiagram>());
			this.#sjb();
		}

		// Token: 0x0600263C RID: 9788 RVA: 0x000D5EB8 File Offset: 0x000D40B8
		private IReadOnlyList<#DBe> #rq()
		{
			IReadOnlyList<#DBe> result;
			try
			{
				int num = 4;
				int num2 = num - this.SuperImposeContext.Diagrams.Count;
				ConsideredAxis consideredAxis = base.Services.Project.Model.Options.ConsideredAxis;
				IReadOnlyList<#DBe> readOnlyList = (consideredAxis == ConsideredAxis.Both) ? this.#a.#ZAe() : this.#a.#YAe();
				foreach (#DBe #DBe in readOnlyList)
				{
					if (#DBe.RunAxis != consideredAxis)
					{
						throw new InvalidDataException(Strings.StringCannotSuperimposeImportedDiagramHasDifferentRunAxis);
					}
				}
				if (readOnlyList.Count > num2)
				{
					string #SSc = base.DialogService.#5Sc(Strings.StringMaximumNumberOfSuperimposedDiagrams0Exceeded.#D2d(new object[]
					{
						num
					}).#z2d(), Strings.String0SelectedDiagramSWillBeAdded.#D2d(new object[]
					{
						num2
					}).#z2d());
					base.DialogService.#ZSc(base.ActiveWindow, #SSc);
				}
				result = readOnlyList.Take(num2).ToList<#DBe>();
			}
			catch (InvalidDataException ex)
			{
				string #SSc2 = base.DialogService.#5Sc(Strings.StringImportOperationAborted, ex.Message.#A2d());
				base.DialogService.#qn(base.DialogService.ActiveWindow, #SSc2);
				result = new List<#DBe>();
			}
			catch (Exception #ob)
			{
				this.#b.#3Ab(#ob);
				result = new List<#DBe>();
			}
			return result;
		}

		// Token: 0x0600263D RID: 9789 RVA: 0x00023E8B File Offset: 0x0002208B
		private void #sjb()
		{
			base.Services.MessageBus.#RV();
			this.#vh();
		}

		// Token: 0x0600263E RID: 9790 RVA: 0x00023EAF File Offset: 0x000220AF
		private void #tjb(object #Sb)
		{
			this.#sjb();
		}

		// Token: 0x04000F1A RID: 3866
		private readonly #zBe #a;

		// Token: 0x04000F1B RID: 3867
		private readonly #tUd #b;

		// Token: 0x04000F1C RID: 3868
		private SuperImposeDiagram #c;

		// Token: 0x04000F1D RID: 3869
		[CompilerGenerated]
		private EventHandler #d;

		// Token: 0x04000F1E RID: 3870
		[CompilerGenerated]
		private readonly #mAe #e;

		// Token: 0x04000F1F RID: 3871
		[CompilerGenerated]
		private readonly #tbb #f;

		// Token: 0x04000F20 RID: 3872
		[CompilerGenerated]
		private readonly DelegateCommand #g;

		// Token: 0x04000F21 RID: 3873
		[CompilerGenerated]
		private readonly DelegateCommand #h;

		// Token: 0x04000F22 RID: 3874
		[CompilerGenerated]
		private readonly DelegateCommand #i;

		// Token: 0x04000F23 RID: 3875
		[CompilerGenerated]
		private readonly DelegateCommand #j;
	}
}
