using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.GUI.DesktopControls;
using StructurePoint.CoreAssets.GUI.DesktopControls.Menu;
using StructurePoint.CoreAssets.GUI.DesktopControls.Ribbon;
using StructurePoint.CoreAssets.GUI.SharedResources.Icons.Ribbon;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using Telerik.Windows.Controls;

namespace #m6c
{
	// Token: 0x02000CE4 RID: 3300
	internal static class #l6c
	{
		// Token: 0x06006BFC RID: 27644 RVA: 0x001A13E0 File Offset: 0x0019F5E0
		public static #r6c #h6c(DependencyObject #eub)
		{
			string #R0d = #Phc.#3hc(107455424);
			Component #x6c = Component.GUIFramework;
			string #Qic = #Phc.#3hc(107265509);
			if (2 != 0)
			{
				#X0d.#V0d(#eub, #R0d, #x6c, #Qic);
			}
			#r6c #r6c = new #r6c();
			HelpID helpID = ContextualHelp.GetHelpID(#eub);
			if (!false)
			{
				#r6c.HelpID = helpID;
			}
			#r6c #r6c2;
			if (5 != 0)
			{
				#r6c2 = #r6c;
			}
			DependencyObject parentElement = ContextualHelp.GetParentElement(#eub);
			DependencyObject dependencyObject;
			if (6 != 0)
			{
				dependencyObject = parentElement;
			}
			if (dependencyObject != null)
			{
				#r6c #r6c3 = #r6c2;
				HelpID helpID2 = ContextualHelp.GetHelpID(dependencyObject);
				if (!false)
				{
					#r6c3.ParentHelpID = helpID2;
				}
			}
			if (#r6c2.ParentHelpID == null)
			{
				#l6c.#GTb #GTb = new #l6c.#GTb();
				#l6c.#GTb #GTb2;
				if (!false)
				{
					#GTb2 = #GTb;
				}
				#GTb2.#a = ContextualHelp.GetParentElementType(#eub);
				if (#GTb2.#a != null)
				{
					dependencyObject = #eub.GetParents().FirstOrDefault(new Func<DependencyObject, bool>(#GTb2.#ncd));
					if (dependencyObject != null)
					{
						#r6c2.ParentHelpID = ContextualHelp.GetHelpID(dependencyObject);
					}
				}
			}
			if (#r6c2.ParentHelpID == null)
			{
				#r6c2.ParentHelpID = ContextualHelp.GetHelpIDTree(#eub);
			}
			return #r6c2;
		}

		// Token: 0x06006BFD RID: 27645 RVA: 0x001A14E4 File Offset: 0x0019F6E4
		[SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "StructurePoint.CoreAssets.GUI.DesktopControls.Menu.MenuItem.set_Text(System.String)")]
		public static IList<MenuItem> #i6c(#J6c #j6c, ICommandFactory #iB)
		{
			#l6c.#v0b #v0b = new #l6c.#v0b();
			#l6c.#v0b #v0b2;
			if (2 != 0)
			{
				#v0b2 = #v0b;
			}
			#v0b2.#a = #j6c;
			object #a = #v0b2.#a;
			string #R0d = #Phc.#3hc(107265488);
			Component #x6c = Component.GUIFramework;
			string #Qic = #Phc.#3hc(107265411);
			if (!false)
			{
				#X0d.#V0d(#a, #R0d, #x6c, #Qic);
			}
			string #R0d2 = #Phc.#3hc(107409227);
			Component #x6c2 = Component.GUIFramework;
			string #Qic2 = #Phc.#3hc(107265358);
			if (5 != 0)
			{
				#X0d.#V0d(#iB, #R0d2, #x6c2, #Qic2);
			}
			List<MenuItem> list = new List<MenuItem>();
			MenuItem menuItem = new MenuItem();
			bool isSeparator = true;
			if (6 != 0)
			{
				menuItem.IsSeparator = isSeparator;
			}
			list.Add(menuItem);
			MenuItem menuItem2 = new MenuItem();
			menuItem2.Text = #Phc.#3hc(107265337);
			IDelegateCommand command = #iB.Create(new Action(#v0b2.#ocd));
			if (!false)
			{
				menuItem2.Command = command;
			}
			list.Add(menuItem2);
			MenuItem menuItem3 = new MenuItem();
			menuItem3.Text = #Phc.#3hc(107264744);
			IDelegateCommand command2 = #iB.Create(new Action(#v0b2.#a.#H6c));
			if (!false)
			{
				menuItem3.Command = command2;
			}
			list.Add(menuItem3);
			return list;
		}

		// Token: 0x06006BFE RID: 27646 RVA: 0x001A1604 File Offset: 0x0019F804
		[SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "StructurePoint.CoreAssets.GUI.DesktopControls.Ribbon.RibbonGroup.#ctor(System.String)")]
		public static RibbonGroup #k6c(#J6c #j6c, ICommandFactory #iB)
		{
			#l6c.#wbc #wbc = new #l6c.#wbc();
			#l6c.#wbc #wbc2;
			if (!false)
			{
				#wbc2 = #wbc;
			}
			#wbc2.#a = #j6c;
			object #a = #wbc2.#a;
			string #R0d = #Phc.#3hc(107265488);
			Component #x6c = Component.GUIFramework;
			string #Qic = #Phc.#3hc(107264683);
			if (true)
			{
				#X0d.#V0d(#a, #R0d, #x6c, #Qic);
			}
			if (4 != 0)
			{
				string #R0d2 = #Phc.#3hc(107409227);
				Component #x6c2 = Component.GUIFramework;
				string #Qic2 = #Phc.#3hc(107264662);
				if (!false)
				{
					#X0d.#V0d(#iB, #R0d2, #x6c2, #Qic2);
				}
			}
			RibbonGroup ribbonGroup = new RibbonGroup(#Phc.#3hc(107264577));
			ribbonGroup.Buttons.Add(new RibbonButton(RibbonIcons.Blank, #Phc.#3hc(107264572), true, #iB.Create(new Action(#wbc2.#pcd)), null, true));
			Collection<RibbonButton> buttons = ribbonGroup.Buttons;
			RibbonButton item = new RibbonButton(RibbonIcons.Blank, #Phc.#3hc(107264527), true, #iB.Create(new Action(#wbc2.#a.#H6c)), null, true);
			if (3 != 0)
			{
				buttons.Add(item);
			}
			return ribbonGroup;
		}

		// Token: 0x02000CE5 RID: 3301
		[CompilerGenerated]
		private sealed class #GTb
		{
			// Token: 0x06006C00 RID: 27648 RVA: 0x00054C9F File Offset: 0x00052E9F
			internal bool #ncd(DependencyObject #Rf)
			{
				return this.#a.IsInstanceOfType(#Rf);
			}

			// Token: 0x04002C00 RID: 11264
			public Type #a;
		}

		// Token: 0x02000CE6 RID: 3302
		[CompilerGenerated]
		private sealed class #v0b
		{
			// Token: 0x06006C02 RID: 27650 RVA: 0x00054CAD File Offset: 0x00052EAD
			internal void #ocd()
			{
				this.#a.#D6c();
			}

			// Token: 0x04002C01 RID: 11265
			public #J6c #a;
		}

		// Token: 0x02000CE7 RID: 3303
		[CompilerGenerated]
		private sealed class #wbc
		{
			// Token: 0x06006C04 RID: 27652 RVA: 0x00054CBB File Offset: 0x00052EBB
			internal void #pcd()
			{
				this.#a.#D6c();
			}

			// Token: 0x04002C02 RID: 11266
			public #J6c #a;
		}
	}
}
