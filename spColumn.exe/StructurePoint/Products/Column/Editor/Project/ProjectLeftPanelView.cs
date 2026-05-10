using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;
using #7hc;
using #APb;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using Telerik.Windows.Controls;

namespace StructurePoint.Products.Column.Editor.Project
{
	// Token: 0x0200062C RID: 1580
	internal sealed class ProjectLeftPanelView : ColumnBaseView, IComponentConnector, IView, #LPb
	{
		// Token: 0x06003582 RID: 13698 RVA: 0x0002EF33 File Offset: 0x0002D133
		public ProjectLeftPanelView()
		{
			this.InitializeComponent();
		}

		// Token: 0x06003583 RID: 13699 RVA: 0x001085D0 File Offset: 0x001067D0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107352167), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06003584 RID: 13700 RVA: 0x0002EF41 File Offset: 0x0002D141
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.CapacityRatioInfoButton = (RadToggleButton)target;
				return;
			}
			if (connectionId != 2)
			{
				this._contentLoaded = true;
				return;
			}
			this.DisplayOptionsPopup = (Popup)target;
		}

		// Token: 0x04001626 RID: 5670
		internal RadToggleButton CapacityRatioInfoButton;

		// Token: 0x04001627 RID: 5671
		internal Popup DisplayOptionsPopup;

		// Token: 0x04001628 RID: 5672
		private bool _contentLoaded;
	}
}
