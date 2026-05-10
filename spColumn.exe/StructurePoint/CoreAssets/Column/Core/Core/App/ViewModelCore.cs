using System;
using System.ComponentModel;
using System.Windows.Controls;
using #7hc;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;

namespace StructurePoint.CoreAssets.Column.Core.Core.App
{
	// Token: 0x02000877 RID: 2167
	public sealed class ViewModelCore<TView> : NotifyPropertyChangedObjectWithValidation, IViewModel<!0>, INotifyPropertyChanged, IViewModel where TView : IView
	{
		// Token: 0x060044C7 RID: 17607 RVA: 0x000394E2 File Offset: 0x000376E2
		protected ViewModelCore(Lazy<TView> view)
		{
			this.viewLazy = view;
		}

		// Token: 0x1700142A RID: 5162
		// (get) Token: 0x060044C8 RID: 17608 RVA: 0x0013C270 File Offset: 0x0013A470
		public TView View
		{
			get
			{
				if (!this.viewLazy.IsValueCreated)
				{
					TView value = this.viewLazy.Value;
					this.OnViewInitialized(value);
				}
				return this.viewLazy.Value;
			}
		}

		// Token: 0x1700142B RID: 5163
		// (get) Token: 0x060044C9 RID: 17609 RVA: 0x000394F1 File Offset: 0x000376F1
		public bool IsViewCreated
		{
			get
			{
				return this.viewLazy.IsValueCreated;
			}
		}

		// Token: 0x1700142C RID: 5164
		// (get) Token: 0x060044CA RID: 17610 RVA: 0x000394FE File Offset: 0x000376FE
		// (set) Token: 0x060044CB RID: 17611 RVA: 0x00039506 File Offset: 0x00037706
		public bool EnableBindingValidationErrorsHandling
		{
			get
			{
				return this.enableBindingValidationErrorsHandling;
			}
			set
			{
				if (this.enableBindingValidationErrorsHandling != value)
				{
					this.enableBindingValidationErrorsHandling = value;
					base.RaisePropertyChanged(#Phc.#3hc(107407580));
				}
			}
		}

		// Token: 0x060044CC RID: 17612 RVA: 0x00039528 File Offset: 0x00037728
		protected void EnsureViewIsInitialized()
		{
			if (this.View == null)
			{
				Console.WriteLine(#Phc.#3hc(107407495));
			}
		}

		// Token: 0x060044CD RID: 17613 RVA: 0x00009E6A File Offset: 0x0000806A
		protected void InvalidateCommands()
		{
		}

		// Token: 0x060044CE RID: 17614 RVA: 0x0013C2A8 File Offset: 0x0013A4A8
		protected void OnViewInitialized(TView view)
		{
			if (view == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107407466));
			}
			view.DataContext = this;
			ref !0 ptr = ref view;
			if (default(!0) == null)
			{
				TView tview = view;
				ptr = ref tview;
			}
			ptr.BindingValidationOccurred += this.View_BindingValidationOccurred;
		}

		// Token: 0x060044CF RID: 17615 RVA: 0x0013C30C File Offset: 0x0013A50C
		protected void UnregisterBindingValidationHandling()
		{
			if (this.viewLazy.IsValueCreated)
			{
				TView value = this.viewLazy.Value;
				value.BindingValidationOccurred -= this.View_BindingValidationOccurred;
			}
		}

		// Token: 0x060044D0 RID: 17616 RVA: 0x00039546 File Offset: 0x00037746
		private void View_BindingValidationOccurred(object sender, ValidationErrorEventArgs e)
		{
			if (this.EnableBindingValidationErrorsHandling)
			{
				base.HandleBindingValidationError(e);
			}
		}

		// Token: 0x04001F30 RID: 7984
		private readonly Lazy<TView> viewLazy;

		// Token: 0x04001F31 RID: 7985
		private bool enableBindingValidationErrorsHandling;
	}
}
