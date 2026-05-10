using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using #3wb;
using #7hc;
using #lH;
using #Swb;
using #Uwb;
using #UYd;
using Alphaleonis.Win32.Filesystem;
using StructurePoint.CoreAssets.AppManager.Column.Templates.Storage;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.CoreAssets.GUI.Framework.Collections;
using StructurePoint.Products.Column.Services.API;
using Telerik.Windows.Controls;

namespace StructurePoint.Products.Column.Editor.Section.Templates.ViewModels
{
	// Token: 0x020004BF RID: 1215
	internal sealed class TemplateSelectorViewModel : #HH<#Vwb>, INotifyPropertyChanged, IViewModel, IViewModel<#Vwb>, #7wb
	{
		// Token: 0x06002C71 RID: 11377 RVA: 0x000EC208 File Offset: 0x000EA408
		public TemplateSelectorViewModel(Lazy<#Vwb> view, ICoreServices services, #Rwb templateChangeService) : base(view, services)
		{
			this.#a = templateChangeService;
			this.#g = new DelegateCommand(new Action<object>(this.#Jxb), new Predicate<object>(this.#Kxb));
			this.#f = new DelegateCommand(new Action<object>(this.#Hxb), new Predicate<object>(this.#Ixb));
		}

		// Token: 0x17000EE9 RID: 3817
		// (get) Token: 0x06002C72 RID: 11378 RVA: 0x00027FD0 File Offset: 0x000261D0
		public CustomObservableCollection<TemplateDirectoryViewModel> Directories { get; }

		// Token: 0x17000EEA RID: 3818
		// (get) Token: 0x06002C73 RID: 11379 RVA: 0x00027FDC File Offset: 0x000261DC
		// (set) Token: 0x06002C74 RID: 11380 RVA: 0x000EC278 File Offset: 0x000EA478
		public TemplateDirectoryViewModel SelectedDirectory
		{
			get
			{
				return this.#b;
			}
			set
			{
				if (this.#b != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107356296));
					this.#b = value;
					if (value != null)
					{
						value.#oxb();
					}
					this.#vh();
					base.RaisePropertyChanged(#Phc.#3hc(107356296));
				}
			}
		}

		// Token: 0x17000EEB RID: 3819
		// (get) Token: 0x06002C75 RID: 11381 RVA: 0x00027FE8 File Offset: 0x000261E8
		// (set) Token: 0x06002C76 RID: 11382 RVA: 0x000EC2D0 File Offset: 0x000EA4D0
		public #ixb SelectedTemplate
		{
			get
			{
				return this.#c;
			}
			set
			{
				if (this.#c != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107356271));
					this.#c = value;
					this.#vh();
					base.RaisePropertyChanged(#Phc.#3hc(107356271));
				}
			}
		}

		// Token: 0x17000EEC RID: 3820
		// (get) Token: 0x06002C77 RID: 11383 RVA: 0x00027FF4 File Offset: 0x000261F4
		public DelegateCommand CancelCommand { get; }

		// Token: 0x17000EED RID: 3821
		// (get) Token: 0x06002C78 RID: 11384 RVA: 0x00028000 File Offset: 0x00026200
		public DelegateCommand OkCommand { get; }

		// Token: 0x17000EEE RID: 3822
		// (get) Token: 0x06002C79 RID: 11385 RVA: 0x0002800C File Offset: 0x0002620C
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x06002C7A RID: 11386 RVA: 0x0002801C File Offset: 0x0002621C
		protected override void #vh()
		{
			base.#vh();
			this.OkCommand.InvalidateCanExecute();
			this.CancelCommand.InvalidateCanExecute();
		}

		// Token: 0x06002C7B RID: 11387 RVA: 0x000EC320 File Offset: 0x000EA520
		public bool #6wb(out SectionTemplateDefinition #xS)
		{
			this.#d = false;
			this.#Lxb();
			base.View.SetOwner(base.Services.WindowLocator.#6());
			base.View.ShowDialog();
			#ixb #ixb = this.SelectedTemplate;
			#xS = ((#ixb != null) ? #ixb.Definition : null);
			return this.#d;
		}

		// Token: 0x06002C7C RID: 11388 RVA: 0x00028046 File Offset: 0x00026246
		private void #Hxb(object #Sb)
		{
			base.View.Close();
		}

		// Token: 0x06002C7D RID: 11389 RVA: 0x00003375 File Offset: 0x00001575
		private bool #Ixb(object #Sb)
		{
			return true;
		}

		// Token: 0x06002C7E RID: 11390 RVA: 0x0002805F File Offset: 0x0002625F
		private void #Jxb(object #Sb)
		{
			#Rwb #Rwb = this.#a;
			#ixb #ixb = this.SelectedTemplate;
			if (!#Rwb.#Qwb((#ixb != null) ? #ixb.Definition : null))
			{
				return;
			}
			this.#d = true;
			base.View.Close();
		}

		// Token: 0x06002C7F RID: 11391 RVA: 0x0002809F File Offset: 0x0002629F
		private bool #Kxb(object #Sb)
		{
			return this.SelectedTemplate != null;
		}

		// Token: 0x06002C80 RID: 11392 RVA: 0x000EC388 File Offset: 0x000EA588
		private void #Lxb()
		{
			TemplateSelectorViewModel.#KTb #KTb = new TemplateSelectorViewModel.#KTb();
			#KTb.#b = this;
			this.Directories.Clear();
			TemplateDirectoryViewModel templateDirectoryViewModel = new TemplateDirectoryViewModel(base.FileSystem, base.Logger, base.Services.Settings.StandardTemplatesPath, #Phc.#3hc(107356278))
			{
				DirectoryType = TemplateDirectoryType.VirtualRoot,
				IsExpanded = true
			};
			this.#Mxb(templateDirectoryViewModel);
			this.Directories.Add(templateDirectoryViewModel);
			templateDirectoryViewModel = new TemplateDirectoryViewModel(base.FileSystem, base.Logger, base.Services.Settings.UserDefinedTemplatesPath, #Phc.#3hc(107356233))
			{
				DirectoryType = TemplateDirectoryType.VirtualRoot,
				IsExpanded = true
			};
			this.#Mxb(templateDirectoryViewModel);
			this.Directories.Add(templateDirectoryViewModel);
			#KTb.#a = false;
			#hZd.#mbb<TemplateDirectoryViewModel>(this.Directories, new Func<TemplateDirectoryViewModel, IEnumerable<TemplateDirectoryViewModel>>(TemplateSelectorViewModel.<>c.<>9.#yzf), new Action<TemplateDirectoryViewModel>(#KTb.#97b));
		}

		// Token: 0x06002C81 RID: 11393 RVA: 0x000EC4A4 File Offset: 0x000EA6A4
		private void #Mxb(TemplateDirectoryViewModel #Nxb)
		{
			if (!base.FileSystem.#X1c(#Nxb.Path))
			{
				return;
			}
			try
			{
				string[] source = base.FileSystem.#e2c(#Nxb.Path);
				foreach (string path in source.OrderBy(new Func<string, string>(TemplateSelectorViewModel.<>c.<>9.#zzf)))
				{
					TemplateDirectoryViewModel templateDirectoryViewModel = new TemplateDirectoryViewModel(base.FileSystem, base.Logger, path, Path.GetFileName(path));
					#Nxb.Children.Add(templateDirectoryViewModel);
					this.#Mxb(templateDirectoryViewModel);
				}
			}
			catch
			{
			}
		}

		// Token: 0x040011DA RID: 4570
		private readonly #Rwb #a;

		// Token: 0x040011DB RID: 4571
		private TemplateDirectoryViewModel #b;

		// Token: 0x040011DC RID: 4572
		private #ixb #c;

		// Token: 0x040011DD RID: 4573
		private bool #d;

		// Token: 0x040011DE RID: 4574
		[CompilerGenerated]
		private readonly CustomObservableCollection<TemplateDirectoryViewModel> #e = new CustomObservableCollection<TemplateDirectoryViewModel>();

		// Token: 0x040011DF RID: 4575
		[CompilerGenerated]
		private readonly DelegateCommand #f;

		// Token: 0x040011E0 RID: 4576
		[CompilerGenerated]
		private readonly DelegateCommand #g;

		// Token: 0x020004C1 RID: 1217
		[CompilerGenerated]
		private sealed class #KTb
		{
			// Token: 0x06002C87 RID: 11399 RVA: 0x000280D2 File Offset: 0x000262D2
			internal void #97b(TemplateDirectoryViewModel #a8b)
			{
				if (!this.#a)
				{
					#a8b.#oxb();
					if (#a8b.Templates.Any<#ixb>())
					{
						this.#a = true;
						this.#b.SelectedDirectory = #a8b;
					}
				}
			}

			// Token: 0x040011E4 RID: 4580
			public bool #a;

			// Token: 0x040011E5 RID: 4581
			public TemplateSelectorViewModel #b;
		}
	}
}
