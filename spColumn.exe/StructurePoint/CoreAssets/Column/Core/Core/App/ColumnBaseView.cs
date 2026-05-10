using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace StructurePoint.CoreAssets.Column.Core.Core.App
{
	// Token: 0x0200002E RID: 46
	public abstract class ColumnBaseView : UserControl, IView
	{
		// Token: 0x06000353 RID: 851 RVA: 0x0000881B File Offset: 0x00006A1B
		protected ColumnBaseView()
		{
			Validation.AddErrorHandler(this, new EventHandler<ValidationErrorEventArgs>(this.Handler));
		}

		// Token: 0x1400000C RID: 12
		// (add) Token: 0x06000354 RID: 852 RVA: 0x00086364 File Offset: 0x00084564
		// (remove) Token: 0x06000355 RID: 853 RVA: 0x0008639C File Offset: 0x0008459C
		public event EventHandler<ValidationErrorEventArgs> BindingValidationOccurred;

		// Token: 0x06000356 RID: 854 RVA: 0x00008835 File Offset: 0x00006A35
		private void Handler(object sender, ValidationErrorEventArgs e)
		{
			EventHandler<ValidationErrorEventArgs> bindingValidationOccurred = this.BindingValidationOccurred;
			if (bindingValidationOccurred == null)
			{
				return;
			}
			bindingValidationOccurred(this, e);
		}

		// Token: 0x06000357 RID: 855 RVA: 0x00008623 File Offset: 0x00006823
		void IView.add_Loaded(RoutedEventHandler value)
		{
			base.Loaded += value;
		}

		// Token: 0x06000358 RID: 856 RVA: 0x0000862C File Offset: 0x0000682C
		void IView.remove_Loaded(RoutedEventHandler value)
		{
			base.Loaded -= value;
		}

		// Token: 0x06000359 RID: 857 RVA: 0x00008670 File Offset: 0x00006870
		void IView.add_PreviewMouseDown(MouseButtonEventHandler value)
		{
			base.PreviewMouseDown += value;
		}

		// Token: 0x0600035A RID: 858 RVA: 0x00008679 File Offset: 0x00006879
		void IView.remove_PreviewMouseDown(MouseButtonEventHandler value)
		{
			base.PreviewMouseDown -= value;
		}

		// Token: 0x0600035B RID: 859 RVA: 0x00008682 File Offset: 0x00006882
		Visibility IView.get_Visibility()
		{
			return base.Visibility;
		}

		// Token: 0x0600035C RID: 860 RVA: 0x0000868A File Offset: 0x0000688A
		void IView.set_Visibility(Visibility value)
		{
			base.Visibility = value;
		}

		// Token: 0x0600035D RID: 861 RVA: 0x00008693 File Offset: 0x00006893
		double IView.get_ActualWidth()
		{
			return base.ActualWidth;
		}

		// Token: 0x0600035E RID: 862 RVA: 0x0000869B File Offset: 0x0000689B
		double IView.get_ActualHeight()
		{
			return base.ActualHeight;
		}

		// Token: 0x0600035F RID: 863 RVA: 0x000086A3 File Offset: 0x000068A3
		bool IView.get_IsVisible()
		{
			return base.IsVisible;
		}

		// Token: 0x06000360 RID: 864 RVA: 0x000086AB File Offset: 0x000068AB
		object IView.get_DataContext()
		{
			return base.DataContext;
		}

		// Token: 0x06000361 RID: 865 RVA: 0x000086B3 File Offset: 0x000068B3
		void IView.set_DataContext(object value)
		{
			base.DataContext = value;
		}

		// Token: 0x06000362 RID: 866 RVA: 0x000086BC File Offset: 0x000068BC
		CommandBindingCollection IView.get_CommandBindings()
		{
			return base.CommandBindings;
		}

		// Token: 0x06000363 RID: 867 RVA: 0x000086C4 File Offset: 0x000068C4
		InputBindingCollection IView.get_InputBindings()
		{
			return base.InputBindings;
		}
	}
}
