using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Markup;
using #7hc;
using #aHb;
using StructurePoint.CoreAssets.Column.Core.Core.App;

namespace StructurePoint.Products.Column.Editor.Section.Common
{
	// Token: 0x020005FA RID: 1530
	internal sealed class CapacityRatioInfoView : ColumnBaseView, IComponentConnector, IView, #9Gb
	{
		// Token: 0x0600346E RID: 13422 RVA: 0x0002E287 File Offset: 0x0002C487
		public CapacityRatioInfoView()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600346F RID: 13423 RVA: 0x00104CF4 File Offset: 0x00102EF4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107353496), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06003470 RID: 13424 RVA: 0x0002E295 File Offset: 0x0002C495
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040015AD RID: 5549
		private bool _contentLoaded;
	}
}
