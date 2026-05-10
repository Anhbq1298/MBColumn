using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Markup;
using #7hc;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.Column.Core.Views.Templates
{
	// Token: 0x02000826 RID: 2086
	public sealed class TemplateRuntimeView : ColumnBaseView, IComponentConnector
	{
		// Token: 0x060042C2 RID: 17090 RVA: 0x000380D1 File Offset: 0x000362D1
		public TemplateRuntimeView()
		{
			this.InitializeComponent();
		}

		// Token: 0x170013B3 RID: 5043
		// (get) Token: 0x060042C3 RID: 17091 RVA: 0x000380DF File Offset: 0x000362DF
		public static int NumberTwo { get; } = 2;

		// Token: 0x170013B4 RID: 5044
		// (get) Token: 0x060042C4 RID: 17092 RVA: 0x000380E6 File Offset: 0x000362E6
		public static int NumberOne { get; } = 1;

		// Token: 0x170013B5 RID: 5045
		// (get) Token: 0x060042C5 RID: 17093 RVA: 0x000380ED File Offset: 0x000362ED
		public static int NumberZero { get; } = 0;

		// Token: 0x170013B6 RID: 5046
		// (get) Token: 0x060042C6 RID: 17094 RVA: 0x000380F4 File Offset: 0x000362F4
		// (set) Token: 0x060042C7 RID: 17095 RVA: 0x00038106 File Offset: 0x00036306
		public Thickness ContentMargin
		{
			get
			{
				return (Thickness)base.GetValue(TemplateRuntimeView.ContentMarginProperty);
			}
			set
			{
				base.SetValue(TemplateRuntimeView.ContentMarginProperty, value);
			}
		}

		// Token: 0x170013B7 RID: 5047
		// (get) Token: 0x060042C8 RID: 17096 RVA: 0x00038119 File Offset: 0x00036319
		// (set) Token: 0x060042C9 RID: 17097 RVA: 0x0003812B File Offset: 0x0003632B
		public int SelectedTabIndex
		{
			get
			{
				return (int)base.GetValue(TemplateRuntimeView.SelectedTabIndexProperty);
			}
			set
			{
				base.SetValue(TemplateRuntimeView.SelectedTabIndexProperty, value);
			}
		}

		// Token: 0x060042CA RID: 17098 RVA: 0x00136E38 File Offset: 0x00135038
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107456715), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060042CB RID: 17099 RVA: 0x0003813E File Offset: 0x0003633E
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060042CC RID: 17100 RVA: 0x00038148 File Offset: 0x00036348
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.TabControl = (RadTabControl)target;
				return;
			}
			this._contentLoaded = true;
		}

		// Token: 0x04001E10 RID: 7696
		public static readonly DependencyProperty ContentMarginProperty = DependencyProperty.Register(#Phc.#3hc(107456666), typeof(Thickness), typeof(TemplateRuntimeView), new PropertyMetadata(default(Thickness)));

		// Token: 0x04001E11 RID: 7697
		public static readonly DependencyProperty SelectedTabIndexProperty = DependencyProperty.Register(#Phc.#3hc(107356321), typeof(int), typeof(TemplateRuntimeView), new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

		// Token: 0x04001E15 RID: 7701
		internal RadTabControl TabControl;

		// Token: 0x04001E16 RID: 7702
		private bool _contentLoaded;
	}
}
