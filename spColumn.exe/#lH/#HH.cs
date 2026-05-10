using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using #7hc;
using #8Cc;
using #eU;
using #LQc;
using #v1c;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.CoreAssets.Logger;
using StructurePoint.Products.Column.Services.API;

namespace #lH
{
	// Token: 0x020000C0 RID: 192
	internal class #HH<#fx> : #TH, IViewModel<!0>, INotifyPropertyChanged, IViewModel where #fx : class, IView
	{
		// Token: 0x060005F3 RID: 1523 RVA: 0x0000A6CC File Offset: 0x000088CC
		protected #HH(Lazy<#fx> #Ee, ICoreServices #0c)
		{
			this.#a = #Ee;
			if (#0c == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107407561));
			}
			this.#c = #0c;
			this.#b = true;
		}

		// Token: 0x170002DD RID: 733
		// (get) Token: 0x060005F4 RID: 1524 RVA: 0x0008B3B4 File Offset: 0x000895B4
		public #fx View
		{
			get
			{
				if (!this.#a.IsValueCreated)
				{
					#fx value = this.#a.Value;
					this.#uh(value);
				}
				return this.#a.Value;
			}
		}

		// Token: 0x170002DE RID: 734
		// (get) Token: 0x060005F5 RID: 1525 RVA: 0x0000A6FD File Offset: 0x000088FD
		public bool IsViewCreated
		{
			get
			{
				return this.#a.IsValueCreated;
			}
		}

		// Token: 0x170002DF RID: 735
		// (get) Token: 0x060005F6 RID: 1526 RVA: 0x0000A712 File Offset: 0x00008912
		// (set) Token: 0x060005F7 RID: 1527 RVA: 0x0000A71E File Offset: 0x0000891E
		public bool EnableBindingValidationErrorsHandling
		{
			get
			{
				return this.#b;
			}
			set
			{
				if (this.#b != value)
				{
					this.#b = value;
					base.RaisePropertyChanged(#Phc.#3hc(107407580));
				}
			}
		}

		// Token: 0x170002E0 RID: 736
		// (get) Token: 0x060005F8 RID: 1528 RVA: 0x0000A74C File Offset: 0x0000894C
		public ICoreServices Services { get; }

		// Token: 0x170002E1 RID: 737
		// (get) Token: 0x060005F9 RID: 1529 RVA: 0x0000A758 File Offset: 0x00008958
		public #oW Project
		{
			get
			{
				return this.Services.Project;
			}
		}

		// Token: 0x170002E2 RID: 738
		// (get) Token: 0x060005FA RID: 1530 RVA: 0x0000A771 File Offset: 0x00008971
		protected #8Sc DialogService
		{
			get
			{
				return this.Services.DialogService;
			}
		}

		// Token: 0x170002E3 RID: 739
		// (get) Token: 0x060005FB RID: 1531 RVA: 0x0000A78A File Offset: 0x0000898A
		protected #v2c FileSystem
		{
			get
			{
				return this.Services.FileSystem;
			}
		}

		// Token: 0x170002E4 RID: 740
		// (get) Token: 0x060005FC RID: 1532 RVA: 0x0000A7A3 File Offset: 0x000089A3
		protected ILogger Logger
		{
			get
			{
				return this.Services.Logger;
			}
		}

		// Token: 0x170002E5 RID: 741
		// (get) Token: 0x060005FD RID: 1533 RVA: 0x0000A7BC File Offset: 0x000089BC
		protected #bDc UndoManager
		{
			get
			{
				return this.Services.UndoManager;
			}
		}

		// Token: 0x170002E6 RID: 742
		// (get) Token: 0x060005FE RID: 1534 RVA: 0x0000A7D5 File Offset: 0x000089D5
		protected Window MainWindow
		{
			get
			{
				return this.Services.WindowLocator.#VP() as Window;
			}
		}

		// Token: 0x170002E7 RID: 743
		// (get) Token: 0x060005FF RID: 1535 RVA: 0x0000A7F8 File Offset: 0x000089F8
		protected Window ActiveWindow
		{
			get
			{
				return this.Services.WindowLocator.#6();
			}
		}

		// Token: 0x170002E8 RID: 744
		// (get) Token: 0x06000600 RID: 1536 RVA: 0x0000A816 File Offset: 0x00008A16
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x06000601 RID: 1537 RVA: 0x0000A826 File Offset: 0x00008A26
		public override void AddError(string propertyName, string error)
		{
			base.AddError(propertyName, error);
		}

		// Token: 0x06000602 RID: 1538 RVA: 0x0000A83C File Offset: 0x00008A3C
		protected void #EH()
		{
			if (this.View == null)
			{
				Console.WriteLine(#Phc.#3hc(107407495));
			}
		}

		// Token: 0x06000603 RID: 1539 RVA: 0x00009E6A File Offset: 0x0000806A
		protected virtual void #vh()
		{
		}

		// Token: 0x06000604 RID: 1540 RVA: 0x0008B3F8 File Offset: 0x000895F8
		protected virtual void #uh(#fx #Ee)
		{
			if (#Ee == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107407466));
			}
			#Ee.DataContext = this;
			#Ee.BindingValidationOccurred += this.#GH;
		}

		// Token: 0x06000605 RID: 1541 RVA: 0x0000A866 File Offset: 0x00008A66
		protected void #FH()
		{
			if (this.#a.IsValueCreated)
			{
				this.#a.Value.BindingValidationOccurred -= this.#GH;
			}
		}

		// Token: 0x06000606 RID: 1542 RVA: 0x0000A8A2 File Offset: 0x00008AA2
		protected void #GH(object #Ge, ValidationErrorEventArgs #He)
		{
			if (this.EnableBindingValidationErrorsHandling)
			{
				base.HandleBindingValidationError(#He);
			}
		}

		// Token: 0x04000155 RID: 341
		private readonly Lazy<#fx> #a;

		// Token: 0x04000156 RID: 342
		private bool #b;

		// Token: 0x04000157 RID: 343
		[CompilerGenerated]
		private readonly ICoreServices #c;
	}
}
