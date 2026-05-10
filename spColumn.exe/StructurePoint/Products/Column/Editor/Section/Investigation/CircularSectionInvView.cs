using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Markup;
using #7hc;
using #APb;
using StructurePoint.CoreAssets.Column.Core.Core.App;

namespace StructurePoint.Products.Column.Editor.Section.Investigation
{
	// Token: 0x020005A3 RID: 1443
	internal sealed class CircularSectionInvView : ColumnBaseView, IComponentConnector, IView, #EPb
	{
		// Token: 0x0600327A RID: 12922 RVA: 0x0002CA99 File Offset: 0x0002AC99
		public CircularSectionInvView()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600327B RID: 12923 RVA: 0x000FFF88 File Offset: 0x000FE188
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107354558), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600327C RID: 12924 RVA: 0x00008739 File Offset: 0x00006939
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600327D RID: 12925 RVA: 0x0002CAA7 File Offset: 0x0002ACA7
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04001486 RID: 5254
		private bool _contentLoaded;
	}
}
