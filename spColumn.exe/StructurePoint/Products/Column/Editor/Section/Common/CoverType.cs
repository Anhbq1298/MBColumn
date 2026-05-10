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
	// Token: 0x02000620 RID: 1568
	internal sealed class CoverType : UserControl, IComponentConnector
	{
		// Token: 0x06003552 RID: 13650 RVA: 0x0002ECFA File Offset: 0x0002CEFA
		public CoverType()
		{
			this.InitializeComponent();
		}

		// Token: 0x170010A5 RID: 4261
		// (get) Token: 0x06003553 RID: 13651 RVA: 0x0002ED08 File Offset: 0x0002CF08
		// (set) Token: 0x06003554 RID: 13652 RVA: 0x0002ED22 File Offset: 0x0002CF22
		public GridLength LabelWidth
		{
			get
			{
				return (GridLength)base.GetValue(CoverType.LabelWidthProperty);
			}
			set
			{
				base.SetValue(CoverType.LabelWidthProperty, value);
			}
		}

		// Token: 0x06003555 RID: 13653 RVA: 0x00107F0C File Offset: 0x0010610C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107352290), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06003556 RID: 13654 RVA: 0x0002ED41 File Offset: 0x0002CF41
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x0400160D RID: 5645
		public static readonly DependencyProperty LabelWidthProperty = DependencyProperty.Register(#Phc.#3hc(107352851), typeof(GridLength), typeof(CoverType), new PropertyMetadata(GridLength.Auto));

		// Token: 0x0400160E RID: 5646
		private bool _contentLoaded;
	}
}
