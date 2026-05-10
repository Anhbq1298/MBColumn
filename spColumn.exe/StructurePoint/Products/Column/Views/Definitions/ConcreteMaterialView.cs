using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using #7hc;
using #Bc;
using StructurePoint.CoreAssets.Column.Core.Core.App;

namespace StructurePoint.Products.Column.Views.Definitions
{
	// Token: 0x02000087 RID: 135
	internal sealed class ConcreteMaterialView : ColumnBaseView, IComponentConnector, IView, #Fc, #gSh
	{
		// Token: 0x0600047A RID: 1146 RVA: 0x0000963E File Offset: 0x0000783E
		public ConcreteMaterialView()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600047B RID: 1147 RVA: 0x00088060 File Offset: 0x00086260
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107384887), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600047C RID: 1148 RVA: 0x0000964C File Offset: 0x0000784C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.LayoutRoot = (Grid)target;
				return;
			}
			if (connectionId != 2)
			{
				this._contentLoaded = true;
				return;
			}
			this.StandardConcreteProperties = (CheckBox)target;
		}

		// Token: 0x040000CE RID: 206
		internal Grid LayoutRoot;

		// Token: 0x040000CF RID: 207
		internal CheckBox StandardConcreteProperties;

		// Token: 0x040000D0 RID: 208
		private bool _contentLoaded;
	}
}
