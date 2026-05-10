using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;
using #7hc;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Basic
{
	// Token: 0x02000A87 RID: 2695
	public sealed class CommandAction : TriggerAction<DependencyObject>
	{
		// Token: 0x17001918 RID: 6424
		// (get) Token: 0x060057FE RID: 22526 RVA: 0x00048AA3 File Offset: 0x00046CA3
		// (set) Token: 0x060057FF RID: 22527 RVA: 0x00048ABD File Offset: 0x00046CBD
		public ICommand Command
		{
			get
			{
				return (ICommand)base.GetValue(CommandAction.CommandProperty);
			}
			set
			{
				base.SetValue(CommandAction.CommandProperty, value);
			}
		}

		// Token: 0x17001919 RID: 6425
		// (get) Token: 0x06005800 RID: 22528 RVA: 0x00048AD7 File Offset: 0x00046CD7
		// (set) Token: 0x06005801 RID: 22529 RVA: 0x00048AEC File Offset: 0x00046CEC
		public object CommandParameter
		{
			get
			{
				return base.GetValue(CommandAction.CommandParameterProperty);
			}
			set
			{
				base.SetValue(CommandAction.CommandParameterProperty, value);
			}
		}

		// Token: 0x06005802 RID: 22530 RVA: 0x00168648 File Offset: 0x00166848
		protected override void Invoke(object parameter)
		{
			ICommand command = this.Command;
			if (command != null)
			{
				command.Execute(this.CommandParameter);
			}
		}

		// Token: 0x06005803 RID: 22531 RVA: 0x00048B06 File Offset: 0x00046D06
		protected override void OnDetaching()
		{
			IDisposable disposable = this.canExecuteChanged;
			if (disposable != null)
			{
				disposable.Dispose();
			}
			base.OnDetaching();
		}

		// Token: 0x06005804 RID: 22532 RVA: 0x00168678 File Offset: 0x00166878
		private static void OnCommandChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
		{
			CommandAction ev = sender as CommandAction;
			if (ev != null)
			{
				IDisposable disposable = ev.canExecuteChanged;
				if (disposable != null)
				{
					disposable.Dispose();
				}
				object newValue = e.NewValue;
				ICommand command = newValue as ICommand;
				if (command != null)
				{
					ev.canExecuteChanged = Observable.FromEventPattern(delegate(EventHandler x)
					{
						command.CanExecuteChanged += x;
					}, delegate(EventHandler x)
					{
						command.CanExecuteChanged -= x;
					}).Subscribe(delegate(EventPattern<object> _)
					{
						ev.SynchronizeElementState();
					});
				}
			}
		}

		// Token: 0x06005805 RID: 22533 RVA: 0x00168730 File Offset: 0x00166930
		private static void OnCommandParameterChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
		{
			CommandAction commandAction = sender as CommandAction;
			if (commandAction != null)
			{
				commandAction.SynchronizeElementState();
			}
		}

		// Token: 0x06005806 RID: 22534 RVA: 0x0016875C File Offset: 0x0016695C
		private void SynchronizeElementState()
		{
			ICommand command = this.Command;
			if (command != null)
			{
				FrameworkElement frameworkElement = base.AssociatedObject as FrameworkElement;
				if (frameworkElement != null)
				{
					frameworkElement.IsEnabled = command.CanExecute(this.CommandParameter);
				}
			}
		}

		// Token: 0x040024D5 RID: 9429
		public static readonly DependencyProperty CommandProperty = DependencyProperty.Register(#Phc.#3hc(107350928), typeof(ICommand), typeof(CommandAction), new PropertyMetadata(null, new PropertyChangedCallback(CommandAction.OnCommandChanged)));

		// Token: 0x040024D6 RID: 9430
		public static readonly DependencyProperty CommandParameterProperty = DependencyProperty.Register(#Phc.#3hc(107350883), typeof(object), typeof(CommandAction), new PropertyMetadata(null, new PropertyChangedCallback(CommandAction.OnCommandParameterChanged)));

		// Token: 0x040024D7 RID: 9431
		private IDisposable canExecuteChanged;
	}
}
