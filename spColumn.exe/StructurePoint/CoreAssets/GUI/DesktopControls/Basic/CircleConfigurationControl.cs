using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using #7hc;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Basic
{
	// Token: 0x02000ABB RID: 2747
	public sealed class CircleConfigurationControl : UserControl, IComponentConnector
	{
		// Token: 0x06005992 RID: 22930 RVA: 0x0004A5CD File Offset: 0x000487CD
		public CircleConfigurationControl()
		{
			this.InitializeComponent();
		}

		// Token: 0x17001954 RID: 6484
		// (get) Token: 0x06005993 RID: 22931 RVA: 0x0004A5DB File Offset: 0x000487DB
		// (set) Token: 0x06005994 RID: 22932 RVA: 0x0004A5F5 File Offset: 0x000487F5
		public int MinNumberOfSides
		{
			get
			{
				return (int)base.GetValue(CircleConfigurationControl.MinNumberOfSidesProperty);
			}
			set
			{
				base.SetValue(CircleConfigurationControl.MinNumberOfSidesProperty, value);
			}
		}

		// Token: 0x17001955 RID: 6485
		// (get) Token: 0x06005995 RID: 22933 RVA: 0x0004A614 File Offset: 0x00048814
		// (set) Token: 0x06005996 RID: 22934 RVA: 0x0004A62E File Offset: 0x0004882E
		public int MaxNumberOfSides
		{
			get
			{
				return (int)base.GetValue(CircleConfigurationControl.MaxNumberOfSidesProperty);
			}
			set
			{
				base.SetValue(CircleConfigurationControl.MaxNumberOfSidesProperty, value);
			}
		}

		// Token: 0x17001956 RID: 6486
		// (get) Token: 0x06005997 RID: 22935 RVA: 0x0004A64D File Offset: 0x0004884D
		// (set) Token: 0x06005998 RID: 22936 RVA: 0x0004A667 File Offset: 0x00048867
		public int NumberOfSides
		{
			get
			{
				return (int)base.GetValue(CircleConfigurationControl.NumberOfSidesProperty);
			}
			set
			{
				base.SetValue(CircleConfigurationControl.NumberOfSidesProperty, value);
			}
		}

		// Token: 0x06005999 RID: 22937 RVA: 0x0016D238 File Offset: 0x0016B438
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107426095), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600599A RID: 22938 RVA: 0x00008739 File Offset: 0x00006939
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600599B RID: 22939 RVA: 0x0004A686 File Offset: 0x00048886
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
		[SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
		[SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04002569 RID: 9577
		public static readonly DependencyProperty MinNumberOfSidesProperty = DependencyProperty.Register(#Phc.#3hc(107425506), typeof(int), typeof(CircleConfigurationControl), new PropertyMetadata(3));

		// Token: 0x0400256A RID: 9578
		public static readonly DependencyProperty MaxNumberOfSidesProperty = DependencyProperty.Register(#Phc.#3hc(107425481), typeof(int), typeof(CircleConfigurationControl), new PropertyMetadata(80));

		// Token: 0x0400256B RID: 9579
		public static readonly DependencyProperty NumberOfSidesProperty = DependencyProperty.Register(#Phc.#3hc(107453324), typeof(int), typeof(CircleConfigurationControl), new PropertyMetadata(40));

		// Token: 0x0400256C RID: 9580
		private bool _contentLoaded;
	}
}
