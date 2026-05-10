using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Controls;
using #ezc;

namespace StructurePoint.CoreAssets.GUI.Framework
{
	// Token: 0x02000B50 RID: 2896
	public class ViewBase : UserControl, #QBc, #SBc
	{
		// Token: 0x06005E88 RID: 24200 RVA: 0x0004EA7C File Offset: 0x0004CC7C
		public ViewBase()
		{
			Validation.AddErrorHandler(this, new EventHandler<ValidationErrorEventArgs>(this.Validation_OnError));
		}

		// Token: 0x17001AD0 RID: 6864
		// (get) Token: 0x06005E89 RID: 24201 RVA: 0x0004EA96 File Offset: 0x0004CC96
		// (set) Token: 0x06005E8A RID: 24202 RVA: 0x0004EA9E File Offset: 0x0004CC9E
		public string Title { get; set; }

		// Token: 0x17001AD1 RID: 6865
		// (get) Token: 0x06005E8B RID: 24203 RVA: 0x0004EAA7 File Offset: 0x0004CCA7
		// (set) Token: 0x06005E8C RID: 24204 RVA: 0x0004EAAF File Offset: 0x0004CCAF
		public IViewModel ViewModel { get; private set; }

		// Token: 0x06005E8D RID: 24205 RVA: 0x0004EAB8 File Offset: 0x0004CCB8
		public void SetViewModel(IViewModel viewModel)
		{
			if (7 != 0)
			{
				this.ViewModel = viewModel;
			}
			if (!false)
			{
				base.DataContext = viewModel;
			}
		}

		// Token: 0x14000170 RID: 368
		// (add) Token: 0x06005E8E RID: 24206 RVA: 0x001779FC File Offset: 0x00175BFC
		// (remove) Token: 0x06005E8F RID: 24207 RVA: 0x00177A54 File Offset: 0x00175C54
		public event EventHandler<ValidationErrorEventArgs> BindingValidationOccurred
		{
			[CompilerGenerated]
			add
			{
				if (!false)
				{
					EventHandler<ValidationErrorEventArgs> eventHandler;
					if (!false)
					{
						EventHandler<ValidationErrorEventArgs> bindingValidationOccurred = this.BindingValidationOccurred;
						if (!false)
						{
							eventHandler = bindingValidationOccurred;
						}
					}
					EventHandler<ValidationErrorEventArgs> eventHandler3;
					do
					{
						if (7 != 0)
						{
							EventHandler<ValidationErrorEventArgs> eventHandler2 = eventHandler;
							if (3 != 0)
							{
								eventHandler3 = eventHandler2;
							}
							EventHandler<ValidationErrorEventArgs> eventHandler4 = (EventHandler<ValidationErrorEventArgs>)Delegate.Combine(eventHandler3, value);
							EventHandler<ValidationErrorEventArgs> value2;
							if (-1 != 0)
							{
								value2 = eventHandler4;
							}
							EventHandler<ValidationErrorEventArgs> eventHandler5 = Interlocked.CompareExchange<EventHandler<ValidationErrorEventArgs>>(ref this.BindingValidationOccurred, value2, eventHandler3);
							if (6 != 0)
							{
								eventHandler = eventHandler5;
							}
						}
					}
					while (eventHandler != eventHandler3);
				}
			}
			[CompilerGenerated]
			remove
			{
				if (!false)
				{
					EventHandler<ValidationErrorEventArgs> eventHandler;
					if (!false)
					{
						EventHandler<ValidationErrorEventArgs> bindingValidationOccurred = this.BindingValidationOccurred;
						if (!false)
						{
							eventHandler = bindingValidationOccurred;
						}
					}
					EventHandler<ValidationErrorEventArgs> eventHandler3;
					do
					{
						if (7 != 0)
						{
							EventHandler<ValidationErrorEventArgs> eventHandler2 = eventHandler;
							if (3 != 0)
							{
								eventHandler3 = eventHandler2;
							}
							EventHandler<ValidationErrorEventArgs> eventHandler4 = (EventHandler<ValidationErrorEventArgs>)Delegate.Remove(eventHandler3, value);
							EventHandler<ValidationErrorEventArgs> value2;
							if (-1 != 0)
							{
								value2 = eventHandler4;
							}
							EventHandler<ValidationErrorEventArgs> eventHandler5 = Interlocked.CompareExchange<EventHandler<ValidationErrorEventArgs>>(ref this.BindingValidationOccurred, value2, eventHandler3);
							if (6 != 0)
							{
								eventHandler = eventHandler5;
							}
						}
					}
					while (eventHandler != eventHandler3);
				}
			}
		}

		// Token: 0x06005E90 RID: 24208 RVA: 0x00177AAC File Offset: 0x00175CAC
		protected virtual void OnBindingValidationOccurred(ValidationErrorEventArgs e)
		{
			EventHandler<ValidationErrorEventArgs> bindingValidationOccurred = this.BindingValidationOccurred;
			EventHandler<ValidationErrorEventArgs> eventHandler;
			if (!false)
			{
				eventHandler = bindingValidationOccurred;
			}
			if (eventHandler != null)
			{
				EventHandler<ValidationErrorEventArgs> eventHandler2 = eventHandler;
				if (!false)
				{
					eventHandler2(this, e);
				}
			}
		}

		// Token: 0x06005E91 RID: 24209 RVA: 0x0004EAD6 File Offset: 0x0004CCD6
		private void Validation_OnError(object sender, ValidationErrorEventArgs e)
		{
			if (!false)
			{
				this.OnBindingValidationOccurred(e);
			}
		}
	}
}
