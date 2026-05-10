using System;
using System.Windows;
using System.Windows.Interactivity;
using #7hc;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Basic
{
	// Token: 0x02000AA8 RID: 2728
	public static class SupplementaryInteraction
	{
		// Token: 0x060058F8 RID: 22776 RVA: 0x00049B7E File Offset: 0x00047D7E
		public static Behaviors GetBehaviors(DependencyObject obj)
		{
			return (Behaviors)obj.GetValue(SupplementaryInteraction.BehaviorsProperty);
		}

		// Token: 0x060058F9 RID: 22777 RVA: 0x00049B98 File Offset: 0x00047D98
		public static void SetBehaviors(DependencyObject obj, Behaviors value)
		{
			obj.SetValue(SupplementaryInteraction.BehaviorsProperty, value);
		}

		// Token: 0x060058FA RID: 22778 RVA: 0x00049BB2 File Offset: 0x00047DB2
		public static Triggers GetTriggers(DependencyObject obj)
		{
			return (Triggers)obj.GetValue(SupplementaryInteraction.TriggersProperty);
		}

		// Token: 0x060058FB RID: 22779 RVA: 0x00049BCC File Offset: 0x00047DCC
		public static void SetTriggers(DependencyObject obj, Triggers value)
		{
			obj.SetValue(SupplementaryInteraction.TriggersProperty, value);
		}

		// Token: 0x060058FC RID: 22780 RVA: 0x0016B724 File Offset: 0x00169924
		private static void OnPropertyBehaviorsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			BehaviorCollection behaviors = Interaction.GetBehaviors(d);
			Behaviors behaviors2 = e.NewValue as Behaviors;
			if (behaviors2 != null)
			{
				foreach (Behavior value in behaviors2)
				{
					behaviors.Add(value);
				}
			}
		}

		// Token: 0x060058FD RID: 22781 RVA: 0x0016B798 File Offset: 0x00169998
		private static void OnPropertyTriggersChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			System.Windows.Interactivity.TriggerCollection triggers = Interaction.GetTriggers(d);
			Triggers triggers2 = e.NewValue as Triggers;
			if (triggers2 != null)
			{
				foreach (System.Windows.Interactivity.TriggerBase value in triggers2)
				{
					triggers.Add(value);
				}
			}
		}

		// Token: 0x0400252E RID: 9518
		public static readonly DependencyProperty BehaviorsProperty = DependencyProperty.RegisterAttached(#Phc.#3hc(107426741), typeof(Behaviors), typeof(SupplementaryInteraction), new UIPropertyMetadata(null, new PropertyChangedCallback(SupplementaryInteraction.OnPropertyBehaviorsChanged)));

		// Token: 0x0400252F RID: 9519
		public static readonly DependencyProperty TriggersProperty = DependencyProperty.RegisterAttached(#Phc.#3hc(107426696), typeof(Triggers), typeof(SupplementaryInteraction), new UIPropertyMetadata(null, new PropertyChangedCallback(SupplementaryInteraction.OnPropertyTriggersChanged)));
	}
}
