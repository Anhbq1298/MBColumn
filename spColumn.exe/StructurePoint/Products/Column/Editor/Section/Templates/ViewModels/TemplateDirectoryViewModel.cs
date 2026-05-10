using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using #3wb;
using #7hc;
using #gfe;
using #v1c;
using StructurePoint.CoreAssets.AppManager.Column.Templates.Storage;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.Logger;
using Telerik.Windows.Data;

namespace StructurePoint.Products.Column.Editor.Section.Templates.ViewModels
{
	// Token: 0x020004B8 RID: 1208
	internal sealed class TemplateDirectoryViewModel : NotifyPropertyChangedObjectBase
	{
		// Token: 0x06002C4B RID: 11339 RVA: 0x000EBC60 File Offset: 0x000E9E60
		public TemplateDirectoryViewModel(#v2c fileSystem, ILogger logger, string path, string name)
		{
			this.#a = fileSystem;
			this.#b = logger;
			this.#e = path;
			this.#d = name;
			this.DirectoryType = TemplateDirectoryType.Regular;
		}

		// Token: 0x17000EDD RID: 3805
		// (get) Token: 0x06002C4C RID: 11340 RVA: 0x00027D59 File Offset: 0x00025F59
		public string Name { get; }

		// Token: 0x17000EDE RID: 3806
		// (get) Token: 0x06002C4D RID: 11341 RVA: 0x00027D65 File Offset: 0x00025F65
		public string Path { get; }

		// Token: 0x17000EDF RID: 3807
		// (get) Token: 0x06002C4E RID: 11342 RVA: 0x00027D71 File Offset: 0x00025F71
		// (set) Token: 0x06002C4F RID: 11343 RVA: 0x00027D7D File Offset: 0x00025F7D
		public TemplateDirectoryType DirectoryType { get; set; }

		// Token: 0x17000EE0 RID: 3808
		// (get) Token: 0x06002C50 RID: 11344 RVA: 0x00027D8E File Offset: 0x00025F8E
		public RadObservableCollection<#ixb> Templates { get; }

		// Token: 0x17000EE1 RID: 3809
		// (get) Token: 0x06002C51 RID: 11345 RVA: 0x00027D9A File Offset: 0x00025F9A
		public RadObservableCollection<TemplateDirectoryViewModel> Children { get; }

		// Token: 0x17000EE2 RID: 3810
		// (get) Token: 0x06002C52 RID: 11346 RVA: 0x00027DA6 File Offset: 0x00025FA6
		// (set) Token: 0x06002C53 RID: 11347 RVA: 0x00027DB2 File Offset: 0x00025FB2
		public bool IsExpanded
		{
			get
			{
				return this.#c;
			}
			set
			{
				if (this.#c != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107408133));
					this.#c = value;
					base.RaisePropertyChanged(#Phc.#3hc(107408133));
				}
			}
		}

		// Token: 0x06002C54 RID: 11348 RVA: 0x000EBCB0 File Offset: 0x000E9EB0
		public void #oxb()
		{
			if (this.Templates.Any<#ixb>())
			{
				return;
			}
			try
			{
				TemplateDirectoryViewModel.#CTb #CTb = new TemplateDirectoryViewModel.#CTb();
				#CTb.#a = new List<SectionTemplatesPackageFile>();
				this.#pxb(#CTb.#a);
				string[] source = this.#a.#Ro(this.Path, #Afe.SectionTemplateExtensionPattern, SearchOption.TopDirectoryOnly);
				List<#ixb> list = new List<#ixb>();
				var orderedEnumerable = source.Select(new Func<string, <>f__AnonymousType0<string, SectionTemplatesPackageFile, int>>(#CTb.#47b)).OrderByDescending(new Func<<>f__AnonymousType0<string, SectionTemplatesPackageFile, int>, bool>(TemplateDirectoryViewModel.<>c.<>9.#57b)).ThenBy(new Func<<>f__AnonymousType0<string, SectionTemplatesPackageFile, int>, int>(TemplateDirectoryViewModel.<>c.<>9.#67b));
				foreach (var <>f__AnonymousType in orderedEnumerable)
				{
					SectionTemplatesPackageFile sectionTemplatesPackageFile = <>f__AnonymousType.Arrangement;
					using (Stream stream = this.#a.#U1c(<>f__AnonymousType.Path))
					{
						SectionTemplateDefinition sectionTemplateDefinition = #Afe.#sfe(stream);
						string #wy = (!string.IsNullOrWhiteSpace((sectionTemplatesPackageFile != null) ? sectionTemplatesPackageFile.DisplayName : null)) ? sectionTemplatesPackageFile.DisplayName.Trim() : sectionTemplateDefinition.DisplayName.GetFirstMessage();
						list.Add(new #ixb(sectionTemplateDefinition, #wy, <>f__AnonymousType.Path));
					}
				}
				this.Templates.AddRange(list);
			}
			catch (Exception exception)
			{
				this.#b.Log(LoggingLevel.Warning, exception);
			}
		}

		// Token: 0x06002C55 RID: 11349 RVA: 0x000EBE98 File Offset: 0x000EA098
		private void #pxb(List<SectionTemplatesPackageFile> #qxb)
		{
			string[] array = this.#a.#Ro(this.Path, #Afe.SectionTemplatePackageExtensionPattern, SearchOption.TopDirectoryOnly);
			foreach (string #So in array)
			{
				try
				{
					using (Stream stream = this.#a.#U1c(#So))
					{
						SectionTemplatesPackageDefinition sectionTemplatesPackageDefinition = #Afe.#ufe(stream);
						if (sectionTemplatesPackageDefinition != null)
						{
							#qxb.AddRange(sectionTemplatesPackageDefinition.Files);
						}
					}
				}
				catch (Exception exception)
				{
					this.#b.Log(LoggingLevel.Warning, exception);
				}
			}
		}

		// Token: 0x040011BF RID: 4543
		private readonly #v2c #a;

		// Token: 0x040011C0 RID: 4544
		private readonly ILogger #b;

		// Token: 0x040011C1 RID: 4545
		private bool #c;

		// Token: 0x040011C2 RID: 4546
		[CompilerGenerated]
		private readonly string #d;

		// Token: 0x040011C3 RID: 4547
		[CompilerGenerated]
		private readonly string #e;

		// Token: 0x040011C4 RID: 4548
		[CompilerGenerated]
		private TemplateDirectoryType #f;

		// Token: 0x040011C5 RID: 4549
		[CompilerGenerated]
		private readonly RadObservableCollection<#ixb> #g = new RadObservableCollection<#ixb>();

		// Token: 0x040011C6 RID: 4550
		[CompilerGenerated]
		private readonly RadObservableCollection<TemplateDirectoryViewModel> #h = new RadObservableCollection<TemplateDirectoryViewModel>();

		// Token: 0x020004BA RID: 1210
		[CompilerGenerated]
		private sealed class #CTb
		{
			// Token: 0x06002C5B RID: 11355 RVA: 0x00027E23 File Offset: 0x00026023
			internal <>f__AnonymousType0<string, SectionTemplatesPackageFile, int> #47b(string #Rf)
			{
				return new
				{
					Path = #Rf,
					Arrangement = this.#a.#tfe(#Rf),
					ArrangementIndex = this.#a.IndexOf(this.#a.#tfe(#Rf))
				};
			}

			// Token: 0x040011CA RID: 4554
			public List<SectionTemplatesPackageFile> #a;
		}
	}
}
