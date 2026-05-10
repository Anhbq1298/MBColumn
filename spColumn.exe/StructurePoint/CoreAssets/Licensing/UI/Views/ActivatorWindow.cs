using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Markup;
using #7hc;
using #Cgc;
using Telerik.Windows.Controls.External;

namespace StructurePoint.CoreAssets.Licensing.UI.Views
{
	// Token: 0x0200072F RID: 1839
	internal sealed class ActivatorWindow : Window, IComponentConnector, #Ggc
	{
		// Token: 0x06003C90 RID: 15504 RVA: 0x00034472 File Offset: 0x00032672
		public ActivatorWindow()
		{
			if (typeof(VisualStudio2013ThemeExternal) != null)
			{
				this.InitializeComponent();
			}
		}

		// Token: 0x06003C91 RID: 15505 RVA: 0x0011A27C File Offset: 0x0011847C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			for (;;)
			{
				if (false)
				{
					goto IL_18;
				}
				if (this._contentLoaded)
				{
					goto IL_0C;
				}
				this._contentLoaded = true;
				goto IL_18;
				IL_34:
				if (7 != 0)
				{
					return;
				}
				continue;
				IL_0C:
				if (!false)
				{
					break;
				}
				goto IL_34;
				IL_18:
				Uri uri = new Uri(#Phc.#3hc(107377379), UriKind.Relative);
				Uri uri2;
				if (7 != 0)
				{
					uri2 = uri;
				}
				if (!false)
				{
					\u0098.\u0091\u0003(this, uri2);
					goto IL_34;
				}
				goto IL_0C;
			}
		}

		// Token: 0x06003C92 RID: 15506 RVA: 0x00034492 File Offset: 0x00032692
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x06003C93 RID: 15507 RVA: 0x0003449F File Offset: 0x0003269F
		void #Ggc.add_Closing(CancelEventHandler value)
		{
			\u0099.\u0092\u0003(this, value);
		}

		// Token: 0x06003C94 RID: 15508 RVA: 0x000344B9 File Offset: 0x000326B9
		void #Ggc.remove_Closing(CancelEventHandler value)
		{
			\u0099.\u0093\u0003(this, value);
		}

		// Token: 0x06003C95 RID: 15509 RVA: 0x00008AED File Offset: 0x00006CED
		bool? #Ggc.get_DialogResult()
		{
			return base.DialogResult;
		}

		// Token: 0x06003C96 RID: 15510 RVA: 0x00008AFD File Offset: 0x00006CFD
		void #Ggc.set_DialogResult(bool? value)
		{
			base.DialogResult = value;
		}

		// Token: 0x06003C97 RID: 15511 RVA: 0x000344D3 File Offset: 0x000326D3
		void #Ggc.Close()
		{
			\u0007.\u0010(this);
		}

		// Token: 0x04001B66 RID: 7014
		private bool _contentLoaded;
	}
}
