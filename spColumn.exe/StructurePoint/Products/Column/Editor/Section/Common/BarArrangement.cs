using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using #7hc;

namespace StructurePoint.Products.Column.Editor.Section.Common
{
	// Token: 0x0200061F RID: 1567
	internal sealed class BarArrangement : UserControl, IComponentConnector
	{
		// Token: 0x0600354C RID: 13644 RVA: 0x0002ECA6 File Offset: 0x0002CEA6
		public BarArrangement()
		{
			this.InitializeComponent();
		}

		// Token: 0x170010A4 RID: 4260
		// (get) Token: 0x0600354D RID: 13645 RVA: 0x0002ECB4 File Offset: 0x0002CEB4
		// (set) Token: 0x0600354E RID: 13646 RVA: 0x0002ECCE File Offset: 0x0002CECE
		public GridLength LabelWidth
		{
			get
			{
				return (GridLength)base.GetValue(BarArrangement.LabelWidthProperty);
			}
			set
			{
				base.SetValue(BarArrangement.LabelWidthProperty, value);
			}
		}

		// Token: 0x0600354F RID: 13647 RVA: 0x00107E78 File Offset: 0x00106078
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107352904), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06003550 RID: 13648 RVA: 0x0002ECED File Offset: 0x0002CEED
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x0400160B RID: 5643
		public static readonly DependencyProperty LabelWidthProperty = DependencyProperty.Register(#Phc.#3hc(107352851), typeof(GridLength), typeof(BarArrangement), new PropertyMetadata(GridLength.Auto));

		// Token: 0x0400160C RID: 5644
		private bool _contentLoaded;
	}
}
