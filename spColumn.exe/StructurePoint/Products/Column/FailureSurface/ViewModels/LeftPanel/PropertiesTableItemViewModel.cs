using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using #5Fd;
using #7hc;
using #mKd;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Presentation.Views;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Rendering;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Rendering.Tabular.TelerikGrid;

namespace StructurePoint.Products.Column.FailureSurface.ViewModels.LeftPanel
{
	// Token: 0x0200041A RID: 1050
	internal sealed class PropertiesTableItemViewModel : NotifyPropertyChangedObjectBase
	{
		// Token: 0x06002613 RID: 9747 RVA: 0x000D5998 File Offset: 0x000D3B98
		public PropertiesTableItemViewModel(string header, Option option, bool isExpanded = false, Visibility contextMenuVisibility = Visibility.Collapsed)
		{
			this.#e = header;
			this.#a = isExpanded;
			this.IsEnabled = true;
			this.#f = new #XKd(option, new #4Fd(), new Color?(Color.FromArgb(byte.MaxValue, 237, 237, 241)));
			this.Renderer.GridRenderer.ExpandLastColumn = true;
			this.Renderer.RadGridView.SetValue(ScrollViewer.VerticalScrollBarVisibilityProperty, ScrollBarVisibility.Disabled);
			this.Renderer.RadGridView.SetValue(ScrollViewer.HorizontalScrollBarVisibilityProperty, ScrollBarVisibility.Disabled);
			this.Renderer.RadGridView.Background = new SolidColorBrush(Color.FromArgb(byte.MaxValue, 245, 245, 245));
			this.Renderer.GridRenderer.DefaultRowBackground = new SolidColorBrush(Color.FromArgb(byte.MaxValue, 245, 245, 245));
			this.Renderer.GridRenderer.HeaderBackgroundBrush = new SolidColorBrush(Color.FromArgb(byte.MaxValue, 230, 230, 230));
			this.Renderer.RadGridView.UseLayoutRounding = true;
			this.Renderer.RadGridView.SnapsToDevicePixels = true;
			this.Renderer.View.ContextMenuVisibility = contextMenuVisibility;
			this.Renderer.GridRenderer.DisableScrollbarInvalidation = true;
			this.#c = Brushes.Transparent;
			this.#g = new Thickness(0.0, 20.0, 0.0, 0.0);
		}

		// Token: 0x17000CDE RID: 3294
		// (get) Token: 0x06002614 RID: 9748 RVA: 0x00023C21 File Offset: 0x00021E21
		public Brush Background { get; }

		// Token: 0x17000CDF RID: 3295
		// (get) Token: 0x06002615 RID: 9749 RVA: 0x00023C2D File Offset: 0x00021E2D
		// (set) Token: 0x06002616 RID: 9750 RVA: 0x00023C39 File Offset: 0x00021E39
		public DocumentContentOptionsCore DocumentContentOptions { get; set; }

		// Token: 0x17000CE0 RID: 3296
		// (get) Token: 0x06002617 RID: 9751 RVA: 0x00023C4A File Offset: 0x00021E4A
		public string Header { get; }

		// Token: 0x17000CE1 RID: 3297
		// (get) Token: 0x06002618 RID: 9752 RVA: 0x00023C56 File Offset: 0x00021E56
		public #XKd Renderer { get; }

		// Token: 0x17000CE2 RID: 3298
		// (get) Token: 0x06002619 RID: 9753 RVA: 0x00023C62 File Offset: 0x00021E62
		public ResultsTableView View
		{
			get
			{
				return this.Renderer.View;
			}
		}

		// Token: 0x17000CE3 RID: 3299
		// (get) Token: 0x0600261A RID: 9754 RVA: 0x00023C7B File Offset: 0x00021E7B
		// (set) Token: 0x0600261B RID: 9755 RVA: 0x00023C87 File Offset: 0x00021E87
		public bool IsExpanded
		{
			get
			{
				return this.#a;
			}
			set
			{
				if (this.#a != value)
				{
					this.#a = value;
					base.RaisePropertyChanged(#Phc.#3hc(107408133));
				}
			}
		}

		// Token: 0x17000CE4 RID: 3300
		// (get) Token: 0x0600261C RID: 9756 RVA: 0x00023CB5 File Offset: 0x00021EB5
		// (set) Token: 0x0600261D RID: 9757 RVA: 0x00023CC1 File Offset: 0x00021EC1
		public bool IsEnabled
		{
			get
			{
				return this.#b;
			}
			set
			{
				if (this.#b != value)
				{
					this.#b = value;
					base.RaisePropertyChanged(#Phc.#3hc(107408148));
				}
			}
		}

		// Token: 0x17000CE5 RID: 3301
		// (get) Token: 0x0600261E RID: 9758 RVA: 0x00023CEF File Offset: 0x00021EEF
		// (set) Token: 0x0600261F RID: 9759 RVA: 0x000D5B40 File Offset: 0x000D3D40
		public Thickness Margin
		{
			get
			{
				return this.#g;
			}
			set
			{
				if (this.#g != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107361172));
					this.#g = value;
					base.RaisePropertyChanged(#Phc.#3hc(107361172));
				}
			}
		}

		// Token: 0x06002620 RID: 9760 RVA: 0x000D5B90 File Offset: 0x000D3D90
		public IList<GridDataRowCore> #kjb()
		{
			IEnumerable enumerable = this.View.RadGridView.ItemsSource as IEnumerable;
			if (enumerable == null)
			{
				return new List<GridDataRowCore>();
			}
			return enumerable.OfType<GridDataRowCore>().ToList<GridDataRowCore>();
		}

		// Token: 0x06002621 RID: 9761 RVA: 0x000D5BD4 File Offset: 0x000D3DD4
		public void #ljb(GridDataRowCore #uI)
		{
			this.View.RadGridView.SelectedItems.Clear();
			if (#uI != null)
			{
				this.View.RadGridView.SelectedItems.Add(#uI);
				this.View.RadGridView.ScrollIntoViewAsync(#uI, new Action<FrameworkElement>(PropertiesTableItemViewModel.<>c.<>9.#m6b));
			}
		}

		// Token: 0x06002622 RID: 9762 RVA: 0x000D5C4C File Offset: 0x000D3E4C
		public void #mjb()
		{
			GridDataRowCore #uI = this.#kjb().FirstOrDefault<GridDataRowCore>();
			this.#ljb(#uI);
		}

		// Token: 0x04000F11 RID: 3857
		private bool #a;

		// Token: 0x04000F12 RID: 3858
		private bool #b;

		// Token: 0x04000F13 RID: 3859
		[CompilerGenerated]
		private readonly Brush #c;

		// Token: 0x04000F14 RID: 3860
		[CompilerGenerated]
		private DocumentContentOptionsCore #d;

		// Token: 0x04000F15 RID: 3861
		[CompilerGenerated]
		private readonly string #e;

		// Token: 0x04000F16 RID: 3862
		[CompilerGenerated]
		private readonly #XKd #f;

		// Token: 0x04000F17 RID: 3863
		private Thickness #g;
	}
}
