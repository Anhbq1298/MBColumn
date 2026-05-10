using System;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using #7hc;
using #hg;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.Products.Column.Viewports;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Animation;
using Telerik.Windows.Controls.Docking;

namespace #Xc
{
	// Token: 0x020000B7 RID: 183
	internal sealed class #Ke : NotifyPropertyChangedObjectBase
	{
		// Token: 0x060005C3 RID: 1475 RVA: 0x0008ADE8 File Offset: 0x00088FE8
		private #Ke(RadPane #Le, #gg #ze)
		{
			this.#a = #ze;
			if (#Le == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107384649));
			}
			this.#i = #Le;
			this.Pane.CanDockInDocumentHost = false;
			this.Pane.CanFloat = true;
			this.Pane.CanUserPin = false;
			this.Pane.Activated -= this.#Ie;
			this.Pane.Activated += this.#Ie;
			this.Pane.Deactivated -= this.#Fe;
			this.Pane.Deactivated += this.#Fe;
			this.#b.BorderThickness = new Thickness(1.0, 0.0, 1.0, 1.0);
			this.#b.BorderBrush = Brushes.Transparent;
			this.#b.Background = Brushes.White;
			this.#b.Child = this.#c;
		}

		// Token: 0x170002D1 RID: 721
		// (get) Token: 0x060005C4 RID: 1476 RVA: 0x0000A3AA File Offset: 0x000085AA
		// (set) Token: 0x060005C5 RID: 1477 RVA: 0x0000A3B6 File Offset: 0x000085B6
		public #ig Overlay { get; private set; }

		// Token: 0x170002D2 RID: 722
		// (get) Token: 0x060005C6 RID: 1478 RVA: 0x0000A3C7 File Offset: 0x000085C7
		// (set) Token: 0x060005C7 RID: 1479 RVA: 0x0000A3D3 File Offset: 0x000085D3
		public CustomRadPaneGroup PaneGroup { get; private set; }

		// Token: 0x170002D3 RID: 723
		// (get) Token: 0x060005C8 RID: 1480 RVA: 0x0000A3E4 File Offset: 0x000085E4
		public RadPane Pane { get; }

		// Token: 0x170002D4 RID: 724
		// (get) Token: 0x060005C9 RID: 1481 RVA: 0x0000A3F0 File Offset: 0x000085F0
		// (set) Token: 0x060005CA RID: 1482 RVA: 0x0000A3FC File Offset: 0x000085FC
		public RadSplitContainer Container { get; private set; }

		// Token: 0x170002D5 RID: 725
		// (get) Token: 0x060005CB RID: 1483 RVA: 0x0000A40D File Offset: 0x0000860D
		// (set) Token: 0x060005CC RID: 1484 RVA: 0x0008AF3C File Offset: 0x0008913C
		public #me DiplayMode
		{
			get
			{
				return this.#f;
			}
			set
			{
				if (this.#f != value)
				{
					this.#f = value;
					if (this.Overlay == null || this.#e == null)
					{
						return;
					}
					this.#xe();
					base.RaisePropertyChanged(#Phc.#3hc(107384640));
				}
			}
		}

		// Token: 0x170002D6 RID: 726
		// (get) Token: 0x060005CD RID: 1485 RVA: 0x0000A419 File Offset: 0x00008619
		// (set) Token: 0x060005CE RID: 1486 RVA: 0x0008AF8C File Offset: 0x0008918C
		public string Header
		{
			get
			{
				return this.Pane.Header as string;
			}
			set
			{
				#Ke.#NTb #NTb = new #Ke.#NTb();
				#NTb.#a = this;
				#NTb.#b = value;
				if (this.Pane.Header as string != #NTb.#b)
				{
					if (this.Pane.Header != null)
					{
						this.Pane.Header = #NTb.#b;
					}
					else
					{
						LayoutHelper.BeginInvokeOnApplicationThread(new Action(#NTb.#MTb));
					}
				}
				if (this.Pane.Title as string != #NTb.#b)
				{
					this.Pane.Title = #NTb.#b;
				}
			}
		}

		// Token: 0x060005CF RID: 1487 RVA: 0x0008B048 File Offset: 0x00089248
		public void #xe()
		{
			#me #me = this.DiplayMode;
			#me #me2;
			if (2 != 0)
			{
				#me2 = #me;
			}
			if (#me2 == #me.#a)
			{
				this.Overlay.Visibility = Visibility.Collapsed;
				this.#e.Visibility = Visibility.Visible;
				return;
			}
			if (#me2 != #me.#b)
			{
				throw new ArgumentOutOfRangeException(#Phc.#3hc(107384640), this.DiplayMode, null);
			}
			this.#e.Visibility = Visibility.Hidden;
			this.Overlay.Visibility = Visibility.Visible;
		}

		// Token: 0x060005D0 RID: 1488 RVA: 0x0000A437 File Offset: 0x00008637
		public void #1()
		{
			this.Pane.Activated -= this.#Ie;
			this.Pane.Deactivated -= this.#Fe;
		}

		// Token: 0x060005D1 RID: 1489 RVA: 0x0008B0C0 File Offset: 0x000892C0
		internal static #Ke #ye(#gg #ze, string #Ae)
		{
			RadPane radPane = new RadPane();
			radPane.Header = #Ae;
			radPane.Title = #Ae;
			radPane.Focusable = false;
			RadPane radPane2;
			if (3 != 0)
			{
				radPane2 = radPane;
			}
			AnimationManager.SetIsAnimationEnabled(radPane2, false);
			return new #Ke(radPane2, #ze);
		}

		// Token: 0x060005D2 RID: 1490 RVA: 0x0008B104 File Offset: 0x00089304
		public void #Be(RadSplitContainer #5d, CustomRadPaneGroup #Ce, Orientation #De)
		{
			if (#Ce == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107384623));
			}
			this.PaneGroup = #Ce;
			if (#5d == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107384720));
			}
			this.Container = #5d;
			this.#Je(#De);
		}

		// Token: 0x060005D3 RID: 1491 RVA: 0x0008B15C File Offset: 0x0008935C
		public void #od(object #Ee)
		{
			if (#Ee == null)
			{
				return;
			}
			if (this.Pane.Content != this.#b)
			{
				this.#c.Children.Add((FrameworkElement)#Ee);
				this.Overlay = this.#a.#Ne();
				this.#e = (FrameworkElement)#Ee;
				this.#c.Children.Add((UIElement)this.Overlay.View);
				this.Pane.Content = this.#b;
			}
			if (#Ee != this.#e)
			{
				if (this.#e != null)
				{
					this.#c.Children.Remove(this.#e);
				}
				this.#e = (FrameworkElement)#Ee;
				this.#c.Children.Add(this.#e);
			}
		}

		// Token: 0x060005D4 RID: 1492 RVA: 0x0000A473 File Offset: 0x00008673
		private void #Fe(object #Ge, EventArgs #He)
		{
			this.#b.BorderBrush = Brushes.Transparent;
		}

		// Token: 0x060005D5 RID: 1493 RVA: 0x0000A491 File Offset: 0x00008691
		private void #Ie(object #Ge, EventArgs #He)
		{
			this.#b.BorderBrush = this.#d;
		}

		// Token: 0x060005D6 RID: 1494 RVA: 0x0008B250 File Offset: 0x00089450
		private void #Je(Orientation #De)
		{
			AnimationManager.SetIsAnimationEnabled(this.Container, false);
			this.Container.Items.Add(this.PaneGroup);
			this.Container.Focusable = false;
			this.Container.Orientation = #De;
			this.Container.InitialPosition = DockState.DockedLeft;
			AnimationManager.SetIsAnimationEnabled(this.PaneGroup, false);
			this.PaneGroup.Items.Add(this.Pane);
			this.PaneGroup.Focusable = false;
		}

		// Token: 0x0400013F RID: 319
		private readonly #gg #a;

		// Token: 0x04000140 RID: 320
		private readonly Border #b = new Border();

		// Token: 0x04000141 RID: 321
		private readonly Grid #c = new Grid();

		// Token: 0x04000142 RID: 322
		private readonly SolidColorBrush #d = new SolidColorBrush(Color.FromArgb(byte.MaxValue, 25, 135, 209));

		// Token: 0x04000143 RID: 323
		private FrameworkElement #e;

		// Token: 0x04000144 RID: 324
		private #me #f;

		// Token: 0x04000145 RID: 325
		[CompilerGenerated]
		private #ig #g;

		// Token: 0x04000146 RID: 326
		[CompilerGenerated]
		private CustomRadPaneGroup #h;

		// Token: 0x04000147 RID: 327
		[CompilerGenerated]
		private readonly RadPane #i;

		// Token: 0x04000148 RID: 328
		[CompilerGenerated]
		private RadSplitContainer #j;

		// Token: 0x020000B8 RID: 184
		[CompilerGenerated]
		private sealed class #NTb
		{
			// Token: 0x060005D8 RID: 1496 RVA: 0x0000A4B0 File Offset: 0x000086B0
			internal void #MTb()
			{
				this.#a.Pane.Header = this.#b;
			}

			// Token: 0x04000149 RID: 329
			public #Ke #a;

			// Token: 0x0400014A RID: 330
			public string #b;
		}
	}
}
