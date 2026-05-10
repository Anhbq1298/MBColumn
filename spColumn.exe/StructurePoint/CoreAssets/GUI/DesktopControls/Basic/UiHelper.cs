using System;
using System.Linq;
using System.Windows;
using #7hc;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Basic
{
	// Token: 0x02000AAE RID: 2734
	public static class UiHelper
	{
		// Token: 0x06005917 RID: 22807 RVA: 0x00049D5C File Offset: 0x00047F5C
		public static void SetFlagValue1(DependencyObject element, bool value)
		{
			element.SetValue(UiHelper.FlagValue1Property, value);
		}

		// Token: 0x06005918 RID: 22808 RVA: 0x00049D7B File Offset: 0x00047F7B
		public static bool GetFlagValue1(DependencyObject element)
		{
			return (bool)element.GetValue(UiHelper.FlagValue1Property);
		}

		// Token: 0x06005919 RID: 22809 RVA: 0x0016BC28 File Offset: 0x00169E28
		public static void CollapseChildExpandableObjects(object parent)
		{
			DependencyObject dependencyObject = parent as DependencyObject;
			if (dependencyObject == null)
			{
				return;
			}
			foreach (RadTreeView radTreeView in dependencyObject.GetChildrenOfType<RadTreeView>())
			{
				radTreeView.CollapseAll();
			}
			foreach (RadExpander radExpander in dependencyObject.GetChildrenOfType<RadExpander>())
			{
				radExpander.IsExpanded = false;
			}
		}

		// Token: 0x0600591A RID: 22810 RVA: 0x0016BCD4 File Offset: 0x00169ED4
		public static void ExpandChildExpandableObjects(object parent)
		{
			DependencyObject dependencyObject = parent as DependencyObject;
			if (dependencyObject == null)
			{
				return;
			}
			foreach (RadTreeView radTreeView in from item in dependencyObject.GetChildrenOfType<RadTreeView>()
			where item.IsEnabled
			select item)
			{
				radTreeView.ExpandAll();
			}
			foreach (RadExpander radExpander in from item in dependencyObject.GetChildrenOfType<RadExpander>()
			where item.IsEnabled
			select item)
			{
				radExpander.IsExpanded = true;
			}
		}

		// Token: 0x0400253D RID: 9533
		public static readonly DependencyProperty FlagValue1Property = DependencyProperty.RegisterAttached(#Phc.#3hc(107426710), typeof(bool), typeof(UiHelper), new PropertyMetadata(false));
	}
}
