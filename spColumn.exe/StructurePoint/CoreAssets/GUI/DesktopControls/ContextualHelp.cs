using System;
using System.Windows;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace StructurePoint.CoreAssets.GUI.DesktopControls
{
	// Token: 0x02000885 RID: 2181
	public static class ContextualHelp
	{
		// Token: 0x060044FD RID: 17661 RVA: 0x00039726 File Offset: 0x00037926
		public static DependencyObject GetParentElement(DependencyObject element)
		{
			#X0d.#V0d(element, #Phc.#3hc(107455424), Component.DesktopControls, #Phc.#3hc(107455443));
			return (DependencyObject)element.GetValue(ContextualHelp.ParentElementProperty);
		}

		// Token: 0x060044FE RID: 17662 RVA: 0x0003975F File Offset: 0x0003795F
		public static void SetParentElement(DependencyObject element, DependencyObject value)
		{
			#X0d.#V0d(element, #Phc.#3hc(107455424), Component.DesktopControls, #Phc.#3hc(107455390));
			element.SetValue(ContextualHelp.ParentElementProperty, value);
		}

		// Token: 0x060044FF RID: 17663 RVA: 0x00039794 File Offset: 0x00037994
		public static void SetParentElementType(DependencyObject element, Type value)
		{
			#X0d.#V0d(element, #Phc.#3hc(107455424), Component.DesktopControls, #Phc.#3hc(107455443));
			element.SetValue(ContextualHelp.ParentElementTypeProperty, value);
		}

		// Token: 0x06004500 RID: 17664 RVA: 0x000397C9 File Offset: 0x000379C9
		public static Type GetParentElementType(DependencyObject element)
		{
			#X0d.#V0d(element, #Phc.#3hc(107455424), Component.DesktopControls, #Phc.#3hc(107455305));
			return (Type)element.GetValue(ContextualHelp.ParentElementTypeProperty);
		}

		// Token: 0x06004501 RID: 17665 RVA: 0x00039802 File Offset: 0x00037A02
		public static void SetHelpID(DependencyObject element, HelpID value)
		{
			#X0d.#V0d(element, #Phc.#3hc(107455424), Component.DesktopControls, #Phc.#3hc(107455284));
			element.SetValue(ContextualHelp.HelpIDProperty, value);
		}

		// Token: 0x06004502 RID: 17666 RVA: 0x00039837 File Offset: 0x00037A37
		public static HelpID GetHelpID(DependencyObject element)
		{
			#X0d.#V0d(element, #Phc.#3hc(107455424), Component.DesktopControls, #Phc.#3hc(107454719));
			return (HelpID)element.GetValue(ContextualHelp.HelpIDProperty);
		}

		// Token: 0x06004503 RID: 17667 RVA: 0x00039870 File Offset: 0x00037A70
		public static void SetHelpIDTree(DependencyObject element, HelpID value)
		{
			#X0d.#V0d(element, #Phc.#3hc(107455424), Component.DesktopControls, #Phc.#3hc(107454634));
			element.SetValue(ContextualHelp.HelpIDTreeProperty, value);
		}

		// Token: 0x06004504 RID: 17668 RVA: 0x000398A5 File Offset: 0x00037AA5
		public static HelpID GetHelpIDTree(DependencyObject element)
		{
			#X0d.#V0d(element, #Phc.#3hc(107455424), Component.DesktopControls, #Phc.#3hc(107454613));
			return (HelpID)element.GetValue(ContextualHelp.HelpIDTreeProperty);
		}

		// Token: 0x04001F70 RID: 8048
		public static readonly DependencyProperty HelpIDProperty = DependencyProperty.RegisterAttached(#Phc.#3hc(107454528), typeof(HelpID), typeof(ContextualHelp), new FrameworkPropertyMetadata(null));

		// Token: 0x04001F71 RID: 8049
		public static readonly DependencyProperty ParentElementTypeProperty = DependencyProperty.RegisterAttached(#Phc.#3hc(107454551), typeof(Type), typeof(ContextualHelp), new PropertyMetadata(null));

		// Token: 0x04001F72 RID: 8050
		public static readonly DependencyProperty ParentElementProperty = DependencyProperty.RegisterAttached(#Phc.#3hc(107454526), typeof(DependencyObject), typeof(ContextualHelp), new PropertyMetadata(null));

		// Token: 0x04001F73 RID: 8051
		public static readonly DependencyProperty HelpIDTreeProperty = DependencyProperty.RegisterAttached(#Phc.#3hc(107454473), typeof(HelpID), typeof(ContextualHelp), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits));
	}
}
