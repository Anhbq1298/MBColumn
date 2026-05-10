using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Markup;
using #7hc;
using #nc;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using Telerik.Windows.Controls;

namespace StructurePoint.Products.Column.Views.Solver
{
	// Token: 0x02000044 RID: 68
	internal sealed class SolverWindowView : ColumnWindow, IComponentConnector, IColumnWindow, IView, #mc
	{
		// Token: 0x060003CD RID: 973 RVA: 0x00008CF4 File Offset: 0x00006EF4
		public SolverWindowView()
		{
			this.InitializeComponent();
		}

		// Token: 0x060003CE RID: 974 RVA: 0x00086DB8 File Offset: 0x00084FB8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107388007), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060003CF RID: 975 RVA: 0x00008D02 File Offset: 0x00006F02
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.ProgressBar = (RadProgressBar)target;
				return;
			}
			this._contentLoaded = true;
		}

		// Token: 0x04000081 RID: 129
		internal RadProgressBar ProgressBar;

		// Token: 0x04000082 RID: 130
		private bool _contentLoaded;
	}
}
