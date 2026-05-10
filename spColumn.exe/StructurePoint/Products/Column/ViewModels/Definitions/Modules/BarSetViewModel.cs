using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using #0be;
using #0I;
using #2be;
using #7hc;
using #Bc;
using #BF;
using #c1d;
using #coe;
using #N6c;
using #npe;
using #o1d;
using #oKe;
using #sUd;
using #v1c;
using #WI;
using #YZ;
using FluentValidation.Results;
using StructurePoint.CoreAssets.AppManager.Column.Helpers;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.AppManager.Column.Validation;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.Framework.Collections;
using StructurePoint.CoreAssets.GUI.Framework.Core;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.CoreAssets.Logger;
using StructurePoint.CoreAssets.Units;
using StructurePoint.Products.Column.Model;
using StructurePoint.Products.Column.Model.Entities;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.ViewModels.API.Core;
using StructurePoint.Products.Column.ViewModels.Core;
using Telerik.Windows.Controls;

namespace StructurePoint.Products.Column.ViewModels.Definitions.Modules
{
	// Token: 0x0200023B RID: 571
	internal sealed class BarSetViewModel : ViewModelWithRowsBase<StructurePoint.Products.Column.Model.Entities.StandardBar, #fSh>, #VI, #5I, IChangesInfo, #ZI, #DUh
	{
		// Token: 0x06001316 RID: 4886 RVA: 0x000AD340 File Offset: 0x000AB540
		public BarSetViewModel(Lazy<#fSh> view, ICoreServices services, #nKe localization, #1Z standardBarValidator, #tUd exceptionHandler) : base(view, services)
		{
			this.#a = services;
			this.#b = standardBarValidator;
			this.#c = exceptionHandler;
			this.#j = new CustomObservableCollection<BarGroupType>(localization.AvailableBarGroupTypes.Keys);
			standardBarValidator.TotalBars = base.Items;
			this.#h = new DelegateCommand(new Action<object>(this.#sG));
			this.#i = new DelegateCommand(new Action<object>(this.#uG));
			base.Items.ItemChanged += this.#VTi;
		}

		// Token: 0x170006ED RID: 1773
		// (get) Token: 0x06001317 RID: 4887 RVA: 0x000149B4 File Offset: 0x00012BB4
		public DelegateCommand ExportFileCommand { get; }

		// Token: 0x170006EE RID: 1774
		// (get) Token: 0x06001318 RID: 4888 RVA: 0x000149C0 File Offset: 0x00012BC0
		public DelegateCommand ImportFileCommand { get; }

		// Token: 0x170006EF RID: 1775
		// (get) Token: 0x06001319 RID: 4889 RVA: 0x000149CC File Offset: 0x00012BCC
		// (set) Token: 0x0600131A RID: 4890 RVA: 0x000AD40C File Offset: 0x000AB60C
		public BarGroupType BarGroupType
		{
			get
			{
				return this.#e;
			}
			set
			{
				if (this.#e != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107408715));
					this.#e = value;
					base.Grid.CancelEdit();
					base.ClearErrors();
					base.RaisePropertyChanged(#Phc.#3hc(107408715));
					this.#vG(value);
					this.#vh();
				}
			}
		}

		// Token: 0x170006F0 RID: 1776
		// (get) Token: 0x0600131B RID: 4891 RVA: 0x000149D8 File Offset: 0x00012BD8
		public override int MaximumItemsCount
		{
			get
			{
				return 16;
			}
		}

		// Token: 0x170006F1 RID: 1777
		// (get) Token: 0x0600131C RID: 4892 RVA: 0x000149DC File Offset: 0x00012BDC
		public CustomObservableCollection<BarGroupType> BarGroupTypes { get; }

		// Token: 0x170006F2 RID: 1778
		// (get) Token: 0x0600131D RID: 4893 RVA: 0x000149E8 File Offset: 0x00012BE8
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x0600131E RID: 4894 RVA: 0x000149F8 File Offset: 0x00012BF8
		protected override void #vh()
		{
			base.#vh();
			this.ExportFileCommand.InvalidateCanExecute();
			this.ImportFileCommand.InvalidateCanExecute();
			base.AddNewRowCommand.InvalidateCanExecute();
		}

		// Token: 0x0600131F RID: 4895 RVA: 0x000AD474 File Offset: 0x000AB674
		public bool GetHasChanges()
		{
			if (this.BarGroupType == BarGroupType.UserDefined)
			{
				IList<StructurePoint.Products.Column.Model.Entities.StandardBar> #O5c = base.Items;
				IList<StructurePoint.Products.Column.Model.Entities.StandardBar> #P5c = base.Project.Model.Bars;
				Func<StructurePoint.Products.Column.Model.Entities.StandardBar, StructurePoint.Products.Column.Model.Entities.StandardBar, bool> #Q5c;
				if ((#Q5c = BarSetViewModel.#2Ui.#a) == null)
				{
					#Q5c = (BarSetViewModel.#2Ui.#a = new Func<StructurePoint.Products.Column.Model.Entities.StandardBar, StructurePoint.Products.Column.Model.Entities.StandardBar, bool>(#Oai.#uC));
				}
				if (!CollectionsComparer.#z3h<StructurePoint.Products.Column.Model.Entities.StandardBar>(#O5c, #P5c, #Q5c))
				{
					return true;
				}
			}
			return this.BarGroupType != base.Project.Model.BarGroupType;
		}

		// Token: 0x06001320 RID: 4896 RVA: 0x00014A2D File Offset: 0x00012C2D
		public void #3B()
		{
			this.#tI();
			base.View.ClearIsCurrent();
		}

		// Token: 0x06001321 RID: 4897 RVA: 0x000AD4EC File Offset: 0x000AB6EC
		public void #2B()
		{
			base.View.BindingValidationOccurred -= base.#GH;
			base.View.Table.CellEditEnded -= this.#oG;
			base.View.Table.RowEditEnded -= this.#nG;
			base.View.BindingValidationOccurred += base.#GH;
			base.View.Table.CellEditEnded += this.#oG;
			base.View.Table.RowEditEnded += this.#nG;
			this.#vh();
		}

		// Token: 0x06001322 RID: 4898 RVA: 0x00014A4C File Offset: 0x00012C4C
		public override bool #jG()
		{
			this.#pG();
			return base.Items.All(new Func<StructurePoint.Products.Column.Model.Entities.StandardBar, bool>(BarSetViewModel.<>c.<>9.#OYh));
		}

		// Token: 0x06001323 RID: 4899 RVA: 0x000AD5BC File Offset: 0x000AB7BC
		public override void UpdateFromModel(ColumnModel model)
		{
			this.#f.Clear();
			this.#f.AddRange(model.Bars.Select(new Func<StructurePoint.Products.Column.Model.Entities.StandardBar, StructurePoint.Products.Column.Model.Entities.StandardBar>(BarSetViewModel.<>c.<>9.#PYh)));
			this.#g = model.BarGroupType;
			this.#e = model.BarGroupType;
			base.RaisePropertyChanged(#Phc.#3hc(107408715));
			this.#vG(model, this.BarGroupType);
			this.#pG();
		}

		// Token: 0x06001324 RID: 4900 RVA: 0x000AD65C File Offset: 0x000AB85C
		public override void UpdateModel(ColumnModel model)
		{
			model.BarGroupType = this.BarGroupType;
			model.Bars.Clear();
			model.Bars.#pR(base.Items);
			bool flag = this.BarGroupType != this.#g;
			bool flag2 = BarGroupChangeHelper.#XF(model, this.#f, flag);
			if (flag || flag2)
			{
				base.Services.DialogService.#ZSc(base.DialogService.ActiveWindow, Strings.StringBarSetHasChanged.#z2d() + Environment.NewLine + Strings.StringReviewExistingSectionReinforcement.#z2d());
			}
		}

		// Token: 0x06001325 RID: 4901 RVA: 0x000AD710 File Offset: 0x000AB910
		protected override void #pjb(object #Sb)
		{
			if (!this.HasErrors)
			{
				if (!base.Items.Any(new Func<StructurePoint.Products.Column.Model.Entities.StandardBar, bool>(BarSetViewModel.<>c.<>9.#GXh)))
				{
					this.SelectedItem = null;
					base.#pjb(#Sb);
					return;
				}
			}
		}

		// Token: 0x06001326 RID: 4902 RVA: 0x000AD76C File Offset: 0x000AB96C
		protected override void #4B(object #5B)
		{
			BarSetViewModel.#AZb #AZb = new BarSetViewModel.#AZb();
			#AZb.#a = this;
			#AZb.#b = (StructurePoint.Products.Column.Model.Entities.StandardBar)#5B;
			StructurePoint.Products.Column.Model.Entities.StandardBar standardBar = base.Items.ElementAtOrDefault(base.Items.#C7c(#AZb.#b) - 1);
			if (standardBar != null)
			{
				#AZb.#b.Size = standardBar.Size + 1;
				#AZb.#b.Diameter = (float)Math.Round((double)(standardBar.Diameter + 0.01f), 3);
				#AZb.#b.Area = (float)Math.Round((double)(standardBar.Area + 0.01f), 3);
				#AZb.#b.Weight = (float)Math.Round((double)(standardBar.Weight + 0.01f), 3);
			}
			else
			{
				#AZb.#b.Size = 1;
				#AZb.#b.Diameter = 1f;
				#AZb.#b.Area = 1f;
				#AZb.#b.Weight = 1f;
			}
			LayoutHelper.BeginInvokeOnApplicationThread(new Action(#AZb.#8Xi));
		}

		// Token: 0x06001327 RID: 4903 RVA: 0x00014A8A File Offset: 0x00012C8A
		protected override void #lG(object #mG)
		{
			base.#lG(#mG);
			Ignore.#14d<Exception>(new Action(this.#pG), base.Logger);
		}

		// Token: 0x06001328 RID: 4904 RVA: 0x00014AB7 File Offset: 0x00012CB7
		protected override bool #vI(object #Sb)
		{
			return this.BarGroupType == BarGroupType.UserDefined && base.#vI(#Sb);
		}

		// Token: 0x06001329 RID: 4905 RVA: 0x00014AD6 File Offset: 0x00012CD6
		protected override bool #dD(object #Sb)
		{
			return this.BarGroupType == BarGroupType.UserDefined && base.#dD(#Sb);
		}

		// Token: 0x0600132A RID: 4906 RVA: 0x000AD894 File Offset: 0x000ABA94
		private void #VTi(object #Ge, #O6c #He)
		{
			BarSetViewModel.#p6b #p6b = new BarSetViewModel.#p6b();
			#p6b.#a = this;
			#p6b.#b = this.SelectedItem;
			LayoutHelper.BeginInvokeOnApplicationThread(new Action(#p6b.#2Xi));
		}

		// Token: 0x0600132B RID: 4907 RVA: 0x00014AF5 File Offset: 0x00012CF5
		private void #nG(object #Ge, GridViewRowEditEndedEventArgs #He)
		{
			Ignore.#14d<Exception>(new Action(this.#pG), base.Logger);
		}

		// Token: 0x0600132C RID: 4908 RVA: 0x00014AF5 File Offset: 0x00012CF5
		private void #oG(object #Ge, GridViewCellEditEndedEventArgs #He)
		{
			Ignore.#14d<Exception>(new Action(this.#pG), base.Logger);
		}

		// Token: 0x0600132D RID: 4909 RVA: 0x000AD8D8 File Offset: 0x000ABAD8
		private void #WTi(StructurePoint.Products.Column.Model.Entities.StandardBar #Au)
		{
			BarSetViewModel.#R7b #R7b = new BarSetViewModel.#R7b();
			#R7b.#c = #Au;
			List<StructurePoint.Products.Column.Model.Entities.StandardBar> list = base.Items.Select(new Func<StructurePoint.Products.Column.Model.Entities.StandardBar, StructurePoint.Products.Column.Model.Entities.StandardBar>(BarSetViewModel.<>c.<>9.#zVi)).ToList<StructurePoint.Products.Column.Model.Entities.StandardBar>();
			#R7b.#a = list.OrderBy(new Func<StructurePoint.Products.Column.Model.Entities.StandardBar, int>(BarSetViewModel.<>c.<>9.#AVi)).ToList<StructurePoint.Products.Column.Model.Entities.StandardBar>();
			bool flag = #R7b.#a.SequenceEqual(list);
			if (flag)
			{
				return;
			}
			#ice context = base.Project.Model.#BY();
			#R7b.#b = new ExtendedStandardBarValidator(context, new Func<IList<IStandardBar>>(#R7b.#IVi), null);
			if (#R7b.#a.All(new Func<StructurePoint.Products.Column.Model.Entities.StandardBar, bool>(#R7b.#JVi)))
			{
				base.Items.#NBc();
				base.Items.Clear();
				base.Items.#pR(#R7b.#a);
				base.Items.#OBc();
				if (#R7b.#c != null)
				{
					this.SelectedItem = base.Items.FirstOrDefault(new Func<StructurePoint.Products.Column.Model.Entities.StandardBar, bool>(#R7b.#KVi));
				}
				Ignore.#14d<Exception>(new Action(this.#pG), base.Logger);
			}
		}

		// Token: 0x0600132E RID: 4910 RVA: 0x000ADA3C File Offset: 0x000ABC3C
		private void #pG()
		{
			foreach (StructurePoint.Products.Column.Model.Entities.StandardBar #rG in base.Items)
			{
				this.#qG(#rG);
			}
		}

		// Token: 0x0600132F RID: 4911 RVA: 0x000ADA98 File Offset: 0x000ABC98
		private void #qG(StructurePoint.Products.Column.Model.Entities.StandardBar #rG)
		{
			ValidationResult validationResult = this.#b.#oZ(#rG);
			#rG.ValidationResults.Clear();
			#rG.HasCustomValidationError = !validationResult.IsValid;
			if (#rG.HasCustomValidationError)
			{
				List<ValidationResultItem> list = new List<ValidationResultItem>();
				#ice #ib = base.Project.Model.#BY();
				foreach (ValidationFailure validationFailure in validationResult.Errors)
				{
					#xce #xce = validationFailure.CustomState as #xce;
					string title = (#xce != null) ? #Zbe.#Qhc(#xce.Property, #ib) : string.Empty;
					string message = validationFailure.ErrorMessage.#32d().#22d().#A2d();
					list.Add(new ValidationResultItem(ValidationResultItemType.Error, message, title));
				}
				#rG.ValidationResults.#pR(list.OrderBy(new Func<ValidationResultItem, string>(BarSetViewModel.<>c.<>9.#BVi)));
			}
		}

		// Token: 0x06001330 RID: 4912 RVA: 0x000ADBC8 File Offset: 0x000ABDC8
		private void #sG(object #tG)
		{
			if (this.HasErrors || base.Grid.HasValidationErrors())
			{
				base.DialogService.#qn(base.ActiveWindow, Strings.StringInvalidDataSpecified.#z2d() + Environment.NewLine + Environment.NewLine + Strings.StringPleaseFixValidationErrorsBeforeExporting.#z2d());
				return;
			}
			LayoutHelper.BeginInvokeOnApplicationThread(new Action(this.#XTi));
		}

		// Token: 0x06001331 RID: 4913 RVA: 0x00014B1B File Offset: 0x00012D1B
		private void #uG(object #tG)
		{
			LayoutHelper.BeginInvokeOnApplicationThread(new Action(this.#YTi));
		}

		// Token: 0x06001332 RID: 4914 RVA: 0x000ADC40 File Offset: 0x000ABE40
		private void #vG(ColumnModel #Od, BarGroupType #wG)
		{
			if (#wG != BarGroupType.UserDefined)
			{
				this.#vG(#wG);
				return;
			}
			IEnumerable<StructurePoint.Products.Column.Model.Entities.StandardBar> #8f = this.#xG(#Od.Bars);
			base.Items.Clear();
			base.Items.#pR(#8f);
			base.Items.#I1d(new Action<StructurePoint.Products.Column.Model.Entities.StandardBar>(BarSetViewModel.<>c.<>9.#FVi));
		}

		// Token: 0x06001333 RID: 4915 RVA: 0x000ADCB4 File Offset: 0x000ABEB4
		private void #vG(BarGroupType #wG)
		{
			UnitSystem #Qg = this.#a.Project.Model.Options.Unit;
			List<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.StandardBar> source = #mpe.#bpe(#wG, #Qg);
			if (!source.Any<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.StandardBar>())
			{
				return;
			}
			base.Items.Clear();
			base.Items.#pR(source.Select(new Func<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.StandardBar, StructurePoint.Products.Column.Model.Entities.StandardBar>(BarSetViewModel.<>c.<>9.#GVi)));
			base.Items.#I1d(new Action<StructurePoint.Products.Column.Model.Entities.StandardBar>(BarSetViewModel.<>c.<>9.#HVi));
		}

		// Token: 0x06001334 RID: 4916 RVA: 0x000ADD70 File Offset: 0x000ABF70
		private IEnumerable<StructurePoint.Products.Column.Model.Entities.StandardBar> #xG(IEnumerable<StructurePoint.Products.Column.Model.Entities.StandardBar> #Ic)
		{
			List<StructurePoint.Products.Column.Model.Entities.StandardBar> list = new List<StructurePoint.Products.Column.Model.Entities.StandardBar>();
			foreach (StructurePoint.Products.Column.Model.Entities.StandardBar standardBar in #Ic)
			{
				StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.StandardBar item = standardBar.ToStorageModel();
				StructurePoint.Products.Column.Model.Entities.StandardBar item2 = new StructurePoint.Products.Column.Model.Entities.StandardBar(item);
				list.Add(item2);
			}
			return list;
		}

		// Token: 0x06001335 RID: 4917 RVA: 0x0000A950 File Offset: 0x00008B50
		void #5I.#Lr()
		{
			base.ClearErrors();
		}

		// Token: 0x06001336 RID: 4918 RVA: 0x0000A960 File Offset: 0x00008B60
		void #5I.#Or(string #em)
		{
			base.RemoveError(#em);
		}

		// Token: 0x06001337 RID: 4919 RVA: 0x000ADDDC File Offset: 0x000ABFDC
		[CompilerGenerated]
		private void #XTi()
		{
			try
			{
				string str = string.IsNullOrWhiteSpace(base.Project.LoadedFilePath) ? Strings.StringUntitled : Path.GetFileNameWithoutExtension(base.Project.LoadedFilePath);
				string text = str + #Phc.#3hc(107408434) + Strings.StringReinforcement;
				#62c #62c = new #62c(this.#d, #b1d.ReinforcementBarSetExtension, null);
				#62c.InitialFileName = text;
				string text2 = this.#a.FileSystem.#11c(#62c);
				if (!string.IsNullOrWhiteSpace(text2))
				{
					List<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.StandardBar> list = base.Items.Select(new Func<StructurePoint.Products.Column.Model.Entities.StandardBar, StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.StandardBar>(BarSetViewModel.<>c.<>9.#CVi)).ToList<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.StandardBar>();
					using (FileStream fileStream = new FileStream(text2, FileMode.Create, FileAccess.Write, FileShare.None))
					{
						base.Services.Storage.#1ie(fileStream, new #boe
						{
							Unit = base.Services.Project.Model.Options.Unit,
							Bars = list
						});
					}
					base.DialogService.#pn(base.DialogService.ActiveWindow, Strings.StringSpColumn, Strings.StringExportOperationWasSuccessful.#z2d());
				}
			}
			catch (Exception #ob)
			{
				this.#c.#3Ab(#ob);
			}
		}

		// Token: 0x06001338 RID: 4920 RVA: 0x000ADF74 File Offset: 0x000AC174
		[CompilerGenerated]
		private void #YTi()
		{
			try
			{
				#12c #R1c = new #12c(this.#d, #b1d.ReinforcementBarSetExtension, null);
				string #So = this.#a.FileSystem.#S1c(#R1c);
				if (this.#a.FileSystem.#V1c(#So))
				{
					try
					{
						List<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.StandardBar> list;
						using (Stream stream = base.FileSystem.#U1c(#So))
						{
							#boe #2ie = base.Services.Storage.#0ie(stream);
							list = ImportHelper.#gFb(base.Services.Project.Model.Options.Unit, #2ie);
						}
						if (list != null)
						{
							if (list.Count > 0)
							{
								base.Grid.CancelEdit();
								base.ClearErrors();
								base.Items.Clear();
								base.Items.#pR(list.Select(new Func<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.StandardBar, StructurePoint.Products.Column.Model.Entities.StandardBar>(BarSetViewModel.<>c.<>9.#DVi)));
								this.#pG();
								if (base.Items.Any(new Func<StructurePoint.Products.Column.Model.Entities.StandardBar, bool>(BarSetViewModel.<>c.<>9.#EVi)))
								{
									base.DialogService.#pn(base.DialogService.ActiveWindow, Strings.StringImportingCompletedWithValidationErrors.#z2d() + Environment.NewLine + Environment.NewLine + Strings.StringPleaseReviewAndFixTheValidationErrors.#z2d());
								}
								else
								{
									base.DialogService.#pn(base.DialogService.ActiveWindow, Strings.StringImportingCompleted.#z2d());
								}
							}
							else
							{
								string #hvb = Strings.StringCouldNotImportBars.#z2d().#Tm() + Strings.StringMinimumOneBarSetIsRequired;
								base.DialogService.#pn(base.DialogService.ActiveWindow, #hvb);
							}
						}
						else
						{
							string text = Strings.StringDataImportingError.#z2d().#Tm();
							text += Strings.StringCouldNotImportBars.#Tm();
							text += Environment.NewLine;
							text += Strings.StringImportOperationAborted.#z2d();
							base.DialogService.#od(base.DialogService.ActiveWindow, text, Strings.StringSpColumnBarSetImport, MessageBoxButton.OK, MessageBoxImage.Hand, MessageBoxResult.Cancel, MessageBoxOptions.None);
						}
					}
					catch (#ooe #ooe)
					{
						string #SSc = Strings.StringDataImportingError.#z2d().#Tm() + #ooe.Message;
						base.DialogService.#qn(base.DialogService.ActiveWindow, #SSc);
					}
				}
			}
			catch (Exception #ob)
			{
				this.#c.#3Ab(#ob);
			}
		}

		// Token: 0x040007D7 RID: 2007
		private readonly ICoreServices #a;

		// Token: 0x040007D8 RID: 2008
		private readonly #1Z #b;

		// Token: 0x040007D9 RID: 2009
		private readonly #tUd #c;

		// Token: 0x040007DA RID: 2010
		private readonly List<#L1c> #d = new List<#L1c>
		{
			new #L1c(#Phc.#3hc(107408764), #b1d.ReinforcementBarSetExtension)
		};

		// Token: 0x040007DB RID: 2011
		private BarGroupType #e = BarGroupType.ASTM615M;

		// Token: 0x040007DC RID: 2012
		private readonly List<StructurePoint.Products.Column.Model.Entities.StandardBar> #f = new List<StructurePoint.Products.Column.Model.Entities.StandardBar>();

		// Token: 0x040007DD RID: 2013
		private BarGroupType #g;

		// Token: 0x040007DE RID: 2014
		[CompilerGenerated]
		private readonly DelegateCommand #h;

		// Token: 0x040007DF RID: 2015
		[CompilerGenerated]
		private readonly DelegateCommand #i;

		// Token: 0x040007E0 RID: 2016
		[CompilerGenerated]
		private readonly CustomObservableCollection<BarGroupType> #j;

		// Token: 0x0200023C RID: 572
		[CompilerGenerated]
		private static class #2Ui
		{
			// Token: 0x040007E1 RID: 2017
			public static Func<StructurePoint.Products.Column.Model.Entities.StandardBar, StructurePoint.Products.Column.Model.Entities.StandardBar, bool> #a;
		}

		// Token: 0x0200023E RID: 574
		[CompilerGenerated]
		private sealed class #AZb
		{
			// Token: 0x06001348 RID: 4936 RVA: 0x000AE254 File Offset: 0x000AC454
			internal void #8Xi()
			{
				Ignore.#14d<Exception>(new Action(this.#a.#pG), this.#a.Logger);
				this.#a.#5Xi(this.#b, 1, new string[]
				{
					#Phc.#3hc(107397811),
					#Phc.#3hc(107397770),
					#Phc.#3hc(107397869),
					#Phc.#3hc(107397789)
				});
			}

			// Token: 0x040007EF RID: 2031
			public BarSetViewModel #a;

			// Token: 0x040007F0 RID: 2032
			public StructurePoint.Products.Column.Model.Entities.StandardBar #b;
		}

		// Token: 0x0200023F RID: 575
		[CompilerGenerated]
		private sealed class #p6b
		{
			// Token: 0x0600134A RID: 4938 RVA: 0x00014BD3 File Offset: 0x00012DD3
			internal void #2Xi()
			{
				this.#a.#WTi(this.#b);
				this.#a.#vh();
			}

			// Token: 0x040007F1 RID: 2033
			public BarSetViewModel #a;

			// Token: 0x040007F2 RID: 2034
			public StructurePoint.Products.Column.Model.Entities.StandardBar #b;
		}

		// Token: 0x02000240 RID: 576
		[CompilerGenerated]
		private sealed class #R7b
		{
			// Token: 0x0600134C RID: 4940 RVA: 0x00014BFD File Offset: 0x00012DFD
			internal IList<IStandardBar> #IVi()
			{
				return this.#a.OfType<IStandardBar>().ToList<IStandardBar>();
			}

			// Token: 0x0600134D RID: 4941 RVA: 0x00014C1B File Offset: 0x00012E1B
			internal bool #JVi(StructurePoint.Products.Column.Model.Entities.StandardBar #uYb)
			{
				return this.#b.Validate(#uYb).IsValid;
			}

			// Token: 0x0600134E RID: 4942 RVA: 0x00014C3A File Offset: 0x00012E3A
			internal bool #KVi(StructurePoint.Products.Column.Model.Entities.StandardBar #Rf)
			{
				return #Rf.Size == this.#c.Size;
			}

			// Token: 0x040007F3 RID: 2035
			public List<StructurePoint.Products.Column.Model.Entities.StandardBar> #a;

			// Token: 0x040007F4 RID: 2036
			public ExtendedStandardBarValidator #b;

			// Token: 0x040007F5 RID: 2037
			public StructurePoint.Products.Column.Model.Entities.StandardBar #c;
		}
	}
}
