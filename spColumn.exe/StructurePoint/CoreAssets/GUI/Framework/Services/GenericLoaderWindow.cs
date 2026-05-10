using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using #7hc;
using StructurePoint.CoreAssets.Localizer;

namespace StructurePoint.CoreAssets.GUI.Framework.Services
{
	// Token: 0x02000C32 RID: 3122
	public sealed class GenericLoaderWindow : Window, IComponentConnector, IGenericLoaderWindow
	{
		// Token: 0x0600654D RID: 25933 RVA: 0x00051C09 File Offset: 0x0004FE09
		public GenericLoaderWindow()
		{
			this.InitializeComponent();
			this.LoadingContent = Strings.StringLoading;
		}

		// Token: 0x17001C49 RID: 7241
		// (get) Token: 0x0600654E RID: 25934 RVA: 0x00051C22 File Offset: 0x0004FE22
		// (set) Token: 0x0600654F RID: 25935 RVA: 0x00051C2F File Offset: 0x0004FE2F
		public string LoadingContent
		{
			get
			{
				return this.ContentTextBlock.Text;
			}
			set
			{
				TextBlock contentTextBlock = this.ContentTextBlock;
				if (2 != 0)
				{
					contentTextBlock.Text = value;
				}
			}
		}

		// Token: 0x06006550 RID: 25936 RVA: 0x0018DF00 File Offset: 0x0018C100
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			int num = this._contentLoaded ? 1 : 0;
			IL_06:
			while (num == 0)
			{
				do
				{
					this._contentLoaded = true;
					if (!false)
					{
						int num2 = num = 107443598;
						if (num2 == 0)
						{
							goto IL_06;
						}
						Uri uri = new Uri(#Phc.#3hc(num2), UriKind.Relative);
						Uri uri2;
						if (!false)
						{
							uri2 = uri;
						}
						Uri resourceLocator = uri2;
						if (!false)
						{
							Application.LoadComponent(this, resourceLocator);
						}
					}
				}
				while (-1 == 0);
				return;
			}
		}

		// Token: 0x06006551 RID: 25937 RVA: 0x00051C44 File Offset: 0x0004FE44
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
		[SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
		[SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			do
			{
				if (connectionId != 1)
				{
					if (7 == 0)
					{
						continue;
					}
					this._contentLoaded = true;
					if (!false)
					{
						return;
					}
				}
				this.ContentTextBlock = (TextBlock)target;
			}
			while (false);
		}

		// Token: 0x06006552 RID: 25938 RVA: 0x00051C67 File Offset: 0x0004FE67
		void IGenericLoaderWindow.Show()
		{
			if (6 != 0)
			{
				base.Show();
			}
		}

		// Token: 0x06006553 RID: 25939 RVA: 0x00051C75 File Offset: 0x0004FE75
		void IGenericLoaderWindow.Close()
		{
			if (6 != 0)
			{
				base.Close();
			}
		}

		// Token: 0x04002993 RID: 10643
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal TextBlock ContentTextBlock;

		// Token: 0x04002994 RID: 10644
		private bool _contentLoaded;
	}
}
