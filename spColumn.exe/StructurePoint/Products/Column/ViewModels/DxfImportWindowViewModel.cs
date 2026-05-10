using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using #1b;
using #2be;
using #7hc;
using #bne;
using #c1d;
using #coe;
using #ede;
using #gCc;
using #HI;
using #lH;
using #N7d;
using #pXd;
using #qJ;
using #RJb;
using #u9d;
using #v1c;
using devDept.Geometry;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core;
using StructurePoint.CoreAssets.GUI.Framework.Collections;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.CoreAssets.Units;
using StructurePoint.CoreAssets.Units.UnitSets;
using StructurePoint.Products.Column.Core.API;
using StructurePoint.Products.Column.Editor.Core;
using StructurePoint.Products.Column.Model;
using StructurePoint.Products.Column.Model.Entities;
using StructurePoint.Products.Column.Services;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.Services.Rendering;
using Telerik.Windows.Controls;
using Telerik.Windows.Data;

namespace StructurePoint.Products.Column.ViewModels
{
	// Token: 0x020000D2 RID: 210
	internal sealed class DxfImportWindowViewModel : #HH<#0b>, IViewModel<#0b>, INotifyPropertyChanged, IViewModel, #GI
	{
		// Token: 0x06000663 RID: 1635 RVA: 0x0008C11C File Offset: 0x0008A31C
		public DxfImportWindowViewModel(Lazy<#0b> view, IExtendedServices services, #Ioe storageProvider, IEditorService editorService) : base(view, services)
		{
			this.#a = services;
			this.#b = storageProvider;
			this.#c = editorService;
			this.#d = true;
			this.#e = true;
			this.#f = this.#Tg(UnitSystem.USCustomary);
			this.#v = new DelegateCommand(new Action<object>(this.#Ug));
			this.#w = new DelegateCommand(new Action<object>(this.#Wg), new Predicate<object>(this.#2E));
			this.#x = new DelegateCommand(new Action<object>(this.#Gwi), new Predicate<object>(this.#KTi));
		}

		// Token: 0x170002F7 RID: 759
		// (get) Token: 0x06000664 RID: 1636 RVA: 0x0000ABE3 File Offset: 0x00008DE3
		public RadObservableCollection<ComboItem<LengthUnit>> LengthUnitItems { get; }

		// Token: 0x170002F8 RID: 760
		// (get) Token: 0x06000665 RID: 1637 RVA: 0x0000ABEF File Offset: 0x00008DEF
		// (set) Token: 0x06000666 RID: 1638 RVA: 0x0000ABFB File Offset: 0x00008DFB
		public ComboItem<LengthUnit> SelectedLengthUnit
		{
			get
			{
				return this.#f;
			}
			set
			{
				if (this.SetProperty<ComboItem<LengthUnit>>(ref this.#f, value, #Phc.#3hc(107383411)))
				{
					this.#HSh();
				}
			}
		}

		// Token: 0x170002F9 RID: 761
		// (get) Token: 0x06000667 RID: 1639 RVA: 0x0000AC28 File Offset: 0x00008E28
		public DelegateCommand CloseCommand { get; }

		// Token: 0x170002FA RID: 762
		// (get) Token: 0x06000668 RID: 1640 RVA: 0x0000AC34 File Offset: 0x00008E34
		public DelegateCommand ImportCommand { get; }

		// Token: 0x170002FB RID: 763
		// (get) Token: 0x06000669 RID: 1641 RVA: 0x0000AC40 File Offset: 0x00008E40
		public DelegateCommand OpenFileCommand { get; }

		// Token: 0x170002FC RID: 764
		// (get) Token: 0x0600066A RID: 1642 RVA: 0x0000AC4C File Offset: 0x00008E4C
		public string WindowTitle
		{
			get
			{
				if (!string.IsNullOrWhiteSpace(this.#g))
				{
					return Strings.StringImportDXFFile.#F2d() + Path.GetFileName(this.#g);
				}
				return Strings.StringImportDXFFile;
			}
		}

		// Token: 0x170002FD RID: 765
		// (get) Token: 0x0600066B RID: 1643 RVA: 0x0000AC87 File Offset: 0x00008E87
		// (set) Token: 0x0600066C RID: 1644 RVA: 0x0000AC93 File Offset: 0x00008E93
		public bool? DialogResult { get; set; }

		// Token: 0x170002FE RID: 766
		// (get) Token: 0x0600066D RID: 1645 RVA: 0x0000ACA4 File Offset: 0x00008EA4
		// (set) Token: 0x0600066E RID: 1646 RVA: 0x0000ACB0 File Offset: 0x00008EB0
		public bool IsUseUnitFromDxfFileEnabled
		{
			get
			{
				return this.#s;
			}
			set
			{
				this.SetProperty<bool>(ref this.#s, value, #Phc.#3hc(107383386));
			}
		}

		// Token: 0x170002FF RID: 767
		// (get) Token: 0x0600066F RID: 1647 RVA: 0x0000ACD6 File Offset: 0x00008ED6
		// (set) Token: 0x06000670 RID: 1648 RVA: 0x0008C268 File Offset: 0x0008A468
		public bool UseUnitFromDXFFile
		{
			get
			{
				return this.#d;
			}
			set
			{
				if (this.SetProperty<bool>(ref this.#d, value, #Phc.#3hc(107383349)))
				{
					if (value)
					{
						this.SelectedLengthUnit = this.LengthUnitItems.FirstOrDefault(new Func<ComboItem<LengthUnit>, bool>(this.#LXi));
					}
					this.#HSh();
				}
			}
		}

		// Token: 0x17000300 RID: 768
		// (get) Token: 0x06000671 RID: 1649 RVA: 0x0000ACE2 File Offset: 0x00008EE2
		// (set) Token: 0x06000672 RID: 1650 RVA: 0x0000ACEE File Offset: 0x00008EEE
		public bool AlignSectionCentroidToCoordinateOrigin
		{
			get
			{
				return this.#e;
			}
			set
			{
				if (this.SetProperty<bool>(ref this.#e, value, #Phc.#3hc(107383324)))
				{
					this.#HSh();
				}
			}
		}

		// Token: 0x17000301 RID: 769
		// (get) Token: 0x06000673 RID: 1651 RVA: 0x0000AD1B File Offset: 0x00008F1B
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x17000302 RID: 770
		// (get) Token: 0x06000674 RID: 1652 RVA: 0x0000AD2B File Offset: 0x00008F2B
		// (set) Token: 0x06000675 RID: 1653 RVA: 0x0008C2C0 File Offset: 0x0008A4C0
		public ComboItem<string> SelectedSolidsLayer
		{
			get
			{
				return this.#i;
			}
			set
			{
				if (this.#i != value)
				{
					using (this.#r.#y9h())
					{
						ComboItem<string> comboItem = this.#i;
						this.#i = value;
						if (value != null)
						{
							this.OpeningsLayers.Remove(value);
							this.BarsLayers.Remove(value);
						}
						if (comboItem != null)
						{
							this.OpeningsLayers.Add(comboItem);
							this.BarsLayers.Add(comboItem);
						}
						this.#DSh();
					}
					this.#HSh();
					base.RaisePropertyChanged(#Phc.#3hc(107383751));
				}
			}
		}

		// Token: 0x17000303 RID: 771
		// (get) Token: 0x06000676 RID: 1654 RVA: 0x0000AD37 File Offset: 0x00008F37
		// (set) Token: 0x06000677 RID: 1655 RVA: 0x0008C380 File Offset: 0x0008A580
		public ComboItem<string> SelectedOpeningsLayer
		{
			get
			{
				return this.#j;
			}
			set
			{
				if (this.#j != value)
				{
					using (this.#r.#y9h())
					{
						ComboItem<string> comboItem = this.#j;
						this.#j = value;
						if (value != null)
						{
							this.SolidsLayers.Remove(value);
							this.BarsLayers.Remove(value);
						}
						if (comboItem != null)
						{
							this.SolidsLayers.Add(comboItem);
							this.BarsLayers.Add(comboItem);
						}
						this.#DSh();
					}
					this.#HSh();
					base.RaisePropertyChanged(#Phc.#3hc(107383722));
				}
			}
		}

		// Token: 0x17000304 RID: 772
		// (get) Token: 0x06000678 RID: 1656 RVA: 0x0000AD43 File Offset: 0x00008F43
		// (set) Token: 0x06000679 RID: 1657 RVA: 0x0008C440 File Offset: 0x0008A640
		public ComboItem<string> SelectedBarsLayer
		{
			get
			{
				return this.#k;
			}
			set
			{
				if (this.#k != value)
				{
					using (this.#r.#y9h())
					{
						ComboItem<string> comboItem = this.SelectedBarsLayer;
						this.#k = value;
						this.#HSh();
						if (value != null)
						{
							this.SolidsLayers.Remove(value);
							this.OpeningsLayers.Remove(value);
						}
						if (comboItem != null)
						{
							this.SolidsLayers.Add(comboItem);
							this.OpeningsLayers.Add(comboItem);
						}
						this.#DSh();
					}
					this.#HSh();
					base.RaisePropertyChanged(#Phc.#3hc(107383693));
				}
			}
		}

		// Token: 0x17000305 RID: 773
		// (get) Token: 0x0600067A RID: 1658 RVA: 0x0000AD4F File Offset: 0x00008F4F
		public CustomObservableCollection<ComboItem<string>> SolidsLayers { get; }

		// Token: 0x17000306 RID: 774
		// (get) Token: 0x0600067B RID: 1659 RVA: 0x0000AD5B File Offset: 0x00008F5B
		public CustomObservableCollection<ComboItem<string>> OpeningsLayers { get; }

		// Token: 0x17000307 RID: 775
		// (get) Token: 0x0600067C RID: 1660 RVA: 0x0000AD67 File Offset: 0x00008F67
		public CustomObservableCollection<ComboItem<string>> BarsLayers { get; }

		// Token: 0x17000308 RID: 776
		// (get) Token: 0x0600067D RID: 1661 RVA: 0x0000AD73 File Offset: 0x00008F73
		// (set) Token: 0x0600067E RID: 1662 RVA: 0x0000AD7F File Offset: 0x00008F7F
		public bool ImportSolids
		{
			get
			{
				return this.#l;
			}
			set
			{
				if (this.SetProperty<bool>(ref this.#l, value, #Phc.#3hc(107383700)))
				{
					this.#HSh();
				}
			}
		}

		// Token: 0x17000309 RID: 777
		// (get) Token: 0x0600067F RID: 1663 RVA: 0x0000ADAC File Offset: 0x00008FAC
		// (set) Token: 0x06000680 RID: 1664 RVA: 0x0000ADB8 File Offset: 0x00008FB8
		public bool ImportOpenings
		{
			get
			{
				return this.#m;
			}
			set
			{
				if (this.SetProperty<bool>(ref this.#m, value, #Phc.#3hc(107383651)))
				{
					this.#HSh();
				}
			}
		}

		// Token: 0x1700030A RID: 778
		// (get) Token: 0x06000681 RID: 1665 RVA: 0x0000ADE5 File Offset: 0x00008FE5
		// (set) Token: 0x06000682 RID: 1666 RVA: 0x0000ADF1 File Offset: 0x00008FF1
		public bool ImportBars
		{
			get
			{
				return this.#n;
			}
			set
			{
				if (this.SetProperty<bool>(ref this.#n, value, #Phc.#3hc(107383630)))
				{
					this.#HSh();
				}
			}
		}

		// Token: 0x1700030B RID: 779
		// (get) Token: 0x06000683 RID: 1667 RVA: 0x0000AE1E File Offset: 0x0000901E
		// (set) Token: 0x06000684 RID: 1668 RVA: 0x0000AE2A File Offset: 0x0000902A
		public ColumnEditor DxfEditor
		{
			get
			{
				return this.#p;
			}
			set
			{
				this.SetProperty<ColumnEditor>(ref this.#p, value, #Phc.#3hc(107383645));
			}
		}

		// Token: 0x06000685 RID: 1669 RVA: 0x0000AE50 File Offset: 0x00009050
		protected override void #vh()
		{
			base.#vh();
			this.ImportCommand.InvalidateCanExecute();
			this.CloseCommand.InvalidateCanExecute();
			this.OpenFileCommand.InvalidateCanExecute();
		}

		// Token: 0x06000686 RID: 1670 RVA: 0x0008C508 File Offset: 0x0008A708
		public bool #od()
		{
			this.DialogResult = null;
			if (!this.#BSh())
			{
				return false;
			}
			if (!this.#JTi())
			{
				return false;
			}
			base.View.ShowDialog();
			return this.DialogResult.GetValueOrDefault();
		}

		// Token: 0x06000687 RID: 1671 RVA: 0x0000AE85 File Offset: 0x00009085
		private void #ITi(object #Ge, MouseButtonEventArgs #He)
		{
			this.#JXi();
		}

		// Token: 0x06000688 RID: 1672 RVA: 0x0000AE95 File Offset: 0x00009095
		private static StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point #Pb(StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point #Ng, double #Og)
		{
			return new StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point((double)#Ng.X * #Og, (double)#Ng.Y * #Og);
		}

		// Token: 0x06000689 RID: 1673 RVA: 0x0000AEBA File Offset: 0x000090BA
		private void #JXi()
		{
			ColumnEditor columnEditor = this.DxfEditor;
			if (columnEditor == null)
			{
				return;
			}
			columnEditor.ResetActionMode();
		}

		// Token: 0x0600068A RID: 1674 RVA: 0x0008C560 File Offset: 0x0008A760
		private bool #JTi()
		{
			List<#L1c> #m2c = new List<#L1c>
			{
				new #L1c(Strings.StringDataExchangeFormat, #b1d.DxfExtension)
			};
			#12c #R1c = new #12c(#m2c, #b1d.DxfExtension, null);
			string text = this.#a.FileSystem.#S1c(#R1c);
			if (string.IsNullOrWhiteSpace(text) || !this.#a.FileSystem.#V1c(text))
			{
				return false;
			}
			this.#g = text;
			base.RaisePropertyChanged(#Phc.#3hc(107383632));
			this.#yl();
			if (!this.#ISh())
			{
				this.#g = null;
				base.RaisePropertyChanged(#Phc.#3hc(107383632));
				return false;
			}
			this.#vh();
			LayoutHelper.BeginInvokeOnApplicationThread(new Action(this.#MXi));
			return true;
		}

		// Token: 0x0600068B RID: 1675 RVA: 0x00003375 File Offset: 0x00001575
		private bool #KTi(object #Sb)
		{
			return true;
		}

		// Token: 0x0600068C RID: 1676 RVA: 0x0008C63C File Offset: 0x0008A83C
		private bool #BSh()
		{
			return base.Project.Model.Options.SectionType != SectionType.Irregular || (!base.Project.Model.Shapes.Any<ShapeModel>() && !base.Project.Model.ReinforcementBars.Any<StructurePoint.Products.Column.Model.Entities.ReinforcementBar>()) || base.DialogService.#0Sc(base.DialogService.ActiveWindow, Strings.StringExistingIrregularSectionsWillBeDiscarded.#z2d()) == MessageBoxResult.OK;
		}

		// Token: 0x0600068D RID: 1677 RVA: 0x0008C6C8 File Offset: 0x0008A8C8
		private bool #2E(object #Vg)
		{
			#cLb #cLb = this.#o;
			ColumnModel columnModel = (#cLb != null) ? #cLb.ProjectContext.Model : null;
			return columnModel != null && (columnModel.Shapes.Any<ShapeModel>() || columnModel.ReinforcementBars.Any<StructurePoint.Products.Column.Model.Entities.ReinforcementBar>());
		}

		// Token: 0x0600068E RID: 1678 RVA: 0x0008C718 File Offset: 0x0008A918
		private void #LTi()
		{
			try
			{
				ColumnEditor columnEditor = this.DxfEditor;
				if (columnEditor != null)
				{
					columnEditor.ZoomFitExt(false, 100);
				}
			}
			catch (Exception #ob)
			{
				base.Services.ExceptionHandler.#3Ab(#ob);
			}
		}

		// Token: 0x0600068F RID: 1679 RVA: 0x0008C768 File Offset: 0x0008A968
		private void #DSh()
		{
			CustomObservableCollection<ComboItem<string>> customObservableCollection = this.OpeningsLayers;
			Comparison<ComboItem<string>> #41d = new Comparison<ComboItem<string>>(DxfImportWindowViewModel.<>c.<>9.#QXi);
			if (!false)
			{
				customObservableCollection.#DE(#41d);
			}
			this.SolidsLayers.#DE(new Comparison<ComboItem<string>>(DxfImportWindowViewModel.<>c.<>9.#RXi));
			this.BarsLayers.#DE(new Comparison<ComboItem<string>>(DxfImportWindowViewModel.<>c.<>9.#SXi));
		}

		// Token: 0x06000690 RID: 1680 RVA: 0x0008C80C File Offset: 0x0008AA0C
		private void #ESh()
		{
			if (this.#o != null)
			{
				return;
			}
			#aP #xn = new #aP(new #RP());
			this.#o = new #3Jb(this.#a.Settings, #xn, new #DCc(), new SnappingCache(this.#a.Settings, base.Logger), this.#a.ReporterSettings, base.Logger, null);
			this.DxfEditor = (ColumnEditor)this.#o.Editor;
			this.DxfEditor.CoreRendererModel.UseGlobalSettings = false;
			this.DxfEditor.CoreRendererModel.ShowCoordinateSign = false;
			this.DxfEditor.CoreRendererModel.ShowCentroid = false;
			this.DxfEditor.CoreRendererModel.ShowDimensions = true;
			this.DxfEditor.CoreRendererModel.ShowAnnotations = false;
			this.DxfEditor.CoreRendererModel.ShowCover = false;
			this.DxfEditor.ZoomToModelButtonVisibility = false;
			this.DxfEditor.BusyMessageFont = FontsCache.GetOrCreate(this.DxfEditor.BusyMessageFont.FontFamily.Name, 10f);
			this.DxfEditor.BusyMessageBackground = Color.Transparent;
			this.DxfEditor.BusyMessageForeground = Color.FromArgb(255, 157, 170, 171);
			this.DxfEditor.BusyMessageBorder = Color.Transparent;
			this.DxfEditor.MouseRightButtonDown += this.#ITi;
			#8Jb #8Jb = this.#o.RenderOptions;
			#8Jb.ShowCover = false;
			this.DxfEditor.ActiveViewport.ToolBar.Visible = true;
			this.DxfEditor.CreateControl();
			this.#q = new ModelRenderer(this.#o, null, null);
		}

		// Token: 0x06000691 RID: 1681 RVA: 0x0008C9E4 File Offset: 0x0008ABE4
		private void #KXi()
		{
			if (this.DxfEditor == null)
			{
				return;
			}
			TextColumnsAligner textColumnsAligner = TextColumnsAligner.MessageBoxAligner(#Phc.#3hc(107383615));
			textColumnsAligner.Add(Strings.StringDXFUnit_PASCAL, string.Empty.#O2d() + UnitSymbolProvider.#29d(this.SelectedLengthUnit.Value).Symbol);
			textColumnsAligner.Add(Strings.StringSpColumnUnit, string.Empty.#O2d() + UnitSymbolProvider.#29d(base.Project.Model.Units.Section.Width.UnitType).Symbol);
			this.DxfEditor.CoreRendererModel.DxfImportNote = textColumnsAligner.GetFinalMessage();
			this.DxfEditor.CoreRendererModel.ShowDxfImportNote = string.IsNullOrWhiteSpace(this.DxfEditor.BusyText);
		}

		// Token: 0x06000692 RID: 1682 RVA: 0x0008CADC File Offset: 0x0008ACDC
		private bool #OZe(#Uoe #PE, bool #FSh)
		{
			if (#PE == null || #PE == #Uoe.Null)
			{
				if (#FSh)
				{
					string #SSc = base.DialogService.#5Sc(Strings.StringImportOperationAborted.#z2d(), Strings.StringCouldNotOpenTheDXFFile.#z2d());
					base.DialogService.#qn(base.ActiveWindow, #SSc);
				}
				return false;
			}
			if (#PE == #Uoe.UnsupportedVersion)
			{
				if (#FSh)
				{
					string #SSc2 = base.DialogService.#5Sc(Strings.StringImportOperationAborted.#z2d(), Strings.StringUnsupportedDxfVersion.#z2d());
					base.DialogService.#qn(base.ActiveWindow, #SSc2);
				}
				return false;
			}
			return true;
		}

		// Token: 0x06000693 RID: 1683 RVA: 0x0008CB8C File Offset: 0x0008AD8C
		private bool #GSh()
		{
			if (this.DxfEditor != null)
			{
				this.DxfEditor.BusyText = null;
			}
			if (!base.FileSystem.#V1c(this.#g))
			{
				return false;
			}
			if (!this.ImportSolids && !this.ImportOpenings && !this.ImportBars && this.DxfEditor != null)
			{
				this.#ESh();
				using (Graphics graphics = Graphics.FromHdc(this.DxfEditor.RenderContext.DeviceContext()))
				{
					this.DxfEditor.BusyText = TextAlignmentHelper.Justify(graphics, Strings.StringNoLayersSelected.#z2d() + Environment.NewLine + Strings.StringCannotImportFromDXF.#z2d(), this.DxfEditor.BusyMessageFont);
				}
				this.DxfEditor.Invalidate();
				return false;
			}
			if (this.SelectedSolidsLayer == null && this.SelectedOpeningsLayer == null && this.OpeningsLayers == null && this.DxfEditor != null)
			{
				this.#ESh();
				using (Graphics graphics2 = Graphics.FromHdc(this.DxfEditor.RenderContext.DeviceContext()))
				{
					this.DxfEditor.BusyText = TextAlignmentHelper.Justify(graphics2, Strings.StringNoLayersAssigned.#z2d() + Environment.NewLine + Strings.StringCannotImportFromDXF.#z2d(), this.DxfEditor.BusyMessageFont);
				}
				this.DxfEditor.Invalidate();
				return false;
			}
			return true;
		}

		// Token: 0x06000694 RID: 1684 RVA: 0x0008CD24 File Offset: 0x0008AF24
		private void #yl()
		{
			#cLb #cLb = this.#o;
			ColumnModel columnModel = (#cLb != null) ? #cLb.ProjectContext.Model : null;
			if (columnModel == null)
			{
				return;
			}
			columnModel.Shapes.Clear();
			columnModel.ReinforcementBars.Clear();
			if (this.DxfEditor != null)
			{
				this.DxfEditor.Entities.Clear();
				this.DxfEditor.BusyText = null;
				this.DxfEditor.CoreRendererModel.#yl();
				this.DxfEditor.Invalidate();
			}
		}

		// Token: 0x06000695 RID: 1685 RVA: 0x0008CDB4 File Offset: 0x0008AFB4
		private void #HSh()
		{
			DxfImportWindowViewModel.#Xwf #Xwf = new DxfImportWindowViewModel.#Xwf();
			#Xwf.#a = this;
			try
			{
				if (!this.#r.AnyScopeActive)
				{
					this.#yl();
					if (this.#GSh())
					{
						using (Stream stream = base.FileSystem.#U1c(this.#g))
						{
							#dai #dai = new #dai();
							string text;
							if (!this.ImportSolids)
							{
								text = null;
							}
							else
							{
								ComboItem<string> comboItem = this.SelectedSolidsLayer;
								text = ((comboItem != null) ? comboItem.Value : null);
							}
							#dai.SolidsLayer = text;
							string text2;
							if (!this.ImportOpenings)
							{
								text2 = null;
							}
							else
							{
								ComboItem<string> comboItem2 = this.SelectedOpeningsLayer;
								text2 = ((comboItem2 != null) ? comboItem2.Value : null);
							}
							#dai.OpeningsLayer = text2;
							string text3;
							if (!this.ImportBars)
							{
								text3 = null;
							}
							else
							{
								ComboItem<string> comboItem3 = this.SelectedBarsLayer;
								text3 = ((comboItem3 != null) ? comboItem3.Value : null);
							}
							#dai.BarsLayer = text3;
							#dai.TargetUnitSystem = #4Xi.#3Xi(this.SelectedLengthUnit.Value);
							#dai.MinNoOfCircleSegments = this.#a.Settings.MinNoOfCircleSegments;
							#dai #mA = #dai;
							#Uoe #Uoe = this.#b.#6ie(stream, #mA);
							if (this.#OZe(#Uoe, false))
							{
								this.IsUseUnitFromDxfFileEnabled = !#Uoe.IsUnitless;
								if (#Uoe.IsUnitless)
								{
									this.UseUnitFromDXFFile = false;
								}
								this.#Uge(#Uoe);
								this.#gFb(#Uoe);
								this.#ESh();
								if (!#Uoe.Solids.Any<SectionPolygon>() && !#Uoe.Openings.Any<SectionPolygon>() && !#Uoe.ReinforcementBars.Any<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.ReinforcementBar>())
								{
									string text4 = Strings.StringAllSelectedLayersAreEmptyOrAssignmentsAreIncorrect.#z2d() + Environment.NewLine + Strings.StringCannotImportFromDXF.#z2d();
									using (Graphics graphics = Graphics.FromHdc(this.DxfEditor.RenderContext.DeviceContext()))
									{
										text4 = TextAlignmentHelper.Justify(graphics, text4, this.DxfEditor.BusyMessageFont);
									}
									this.DxfEditor.BusyText = text4;
								}
								else
								{
									ColumnModel columnModel = this.#o.ProjectContext.Model;
									#Xwf.#b = (!columnModel.Shapes.Any<ShapeModel>() && !columnModel.Bars.Any<StructurePoint.Products.Column.Model.Entities.StandardBar>());
									columnModel.Options.Unit = this.#a.Project.Model.Options.Unit;
									columnModel.Options.SectionType = SectionType.Irregular;
									columnModel.Options.InvestigationReinforcement = ReinforcementType.Irregular;
									columnModel.Shapes.Clear();
									columnModel.Shapes.AddRange(#Uoe.Solids.Select(new Func<SectionPolygon, ShapeModel>(DxfImportWindowViewModel.<>c.<>9.#TXi)));
									columnModel.Shapes.AddRange(#Uoe.Openings.Select(new Func<SectionPolygon, ShapeModel>(DxfImportWindowViewModel.<>c.<>9.#UXi)));
									columnModel.ReinforcementBars.Clear();
									columnModel.ReinforcementBars.AddRange(#Uoe.ReinforcementBars.Select(new Func<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.ReinforcementBar, StructurePoint.Products.Column.Model.Entities.ReinforcementBar>(DxfImportWindowViewModel.<>c.<>9.#VXi)));
									if (this.#q != null)
									{
										LayoutHelper.BeginInvokeOnApplicationThread(new Action(#Xwf.#VWh));
									}
								}
							}
						}
					}
				}
			}
			catch (IOException #ob)
			{
				string # = Strings.StringCannotImportDXF.#z2d().#Tm().#Tm() + Strings.StringAnUnknownErrorOccrued.#z2d().#Tm();
				base.Services.ExceptionHandler.#3Ab(#, #ob);
			}
			catch (Exception #ob2)
			{
				base.Services.ErrorsHandler.#1Pb(Strings.StringCouldNotImportSection.#z2d(), #ob2);
			}
			finally
			{
				this.#vh();
				this.#KXi();
				ColumnEditor columnEditor = this.DxfEditor;
				if (columnEditor != null)
				{
					columnEditor.Invalidate();
				}
			}
		}

		// Token: 0x06000696 RID: 1686 RVA: 0x0008D200 File Offset: 0x0008B400
		private bool #ISh()
		{
			bool result;
			using (this.#r.#y9h())
			{
				try
				{
					this.SelectedSolidsLayer = null;
					this.SelectedOpeningsLayer = null;
					this.SelectedBarsLayer = null;
					this.#h.Clear();
					this.SolidsLayers.Clear();
					this.OpeningsLayers.Clear();
					this.BarsLayers.Clear();
					using (Stream stream = base.FileSystem.#U1c(this.#g))
					{
						DxfImportWindowViewModel.#uAf #uAf = new DxfImportWindowViewModel.#uAf();
						#Uoe #Uoe = this.#a.Storage.#6ie(stream, new #dai
						{
							MinNoOfCircleSegments = base.Services.Settings.MinNoOfCircleSegments
						});
						if (!this.#OZe(#Uoe, true))
						{
							return false;
						}
						UnitSystem unitSystem = base.Project.Model.Options.Unit;
						#uAf.#a = ((unitSystem == UnitSystem.USCustomary) ? LengthUnit.Inch : LengthUnit.Millimeter);
						if (!#Uoe.IsUnitless)
						{
							this.UseUnitFromDXFFile = true;
							#uAf.#a = #Uoe.LengthUnit;
							this.#t = #uAf.#a;
						}
						this.SelectedLengthUnit = (this.LengthUnitItems.FirstOrDefault(new Func<ComboItem<LengthUnit>, bool>(#uAf.#iVi)) ?? this.LengthUnitItems.FirstOrDefault<ComboItem<LengthUnit>>());
						this.#h.AddRange(#Uoe.LayerNames.Select(new Func<string, ComboItem<string>>(DxfImportWindowViewModel.<>c.<>9.#WXi)));
					}
					ComboItem<string> item = this.#h.FirstOrDefault(new Func<ComboItem<string>, bool>(DxfImportWindowViewModel.<>c.<>9.#XXi));
					ComboItem<string> item2 = this.#h.FirstOrDefault(new Func<ComboItem<string>, bool>(DxfImportWindowViewModel.<>c.<>9.#YXi));
					ComboItem<string> item3 = this.#h.FirstOrDefault(new Func<ComboItem<string>, bool>(DxfImportWindowViewModel.<>c.<>9.#ZXi));
					this.SolidsLayers.#pR(this.#h);
					this.OpeningsLayers.#pR(this.#h);
					this.BarsLayers.#pR(this.#h);
					this.SolidsLayers.Remove(item2);
					this.SolidsLayers.Remove(item3);
					this.OpeningsLayers.Remove(item);
					this.OpeningsLayers.Remove(item3);
					this.BarsLayers.Remove(item);
					this.BarsLayers.Remove(item2);
					this.ImportSolids = true;
					this.SelectedSolidsLayer = item;
					this.ImportOpenings = true;
					this.SelectedOpeningsLayer = item2;
					this.ImportBars = true;
					this.SelectedBarsLayer = item3;
					result = true;
				}
				catch (#IWi)
				{
					string #SSc = string.Concat(new string[]
					{
						Strings.StringDXFFileUnitNotSupportedTheSupportedUnitsAre.#u2d().#Tm().#Tm(),
						#Phc.#3hc(107383610),
						Strings.StringEnglishInFtYd.#Tm(),
						#Phc.#3hc(107383610),
						Strings.StringMetricMmCmM.#Tm(),
						#Phc.#3hc(107383610),
						Strings.StringUnitless
					});
					this.#a.DialogService.#qn(#SSc);
					result = false;
				}
				catch (Exception #ob)
				{
					this.#a.ExceptionHandler.#3Ab(Strings.StringCouldNotReadTheDXFFile.#z2d(), #ob);
					result = false;
				}
			}
			return result;
		}

		// Token: 0x06000697 RID: 1687 RVA: 0x0008D5E4 File Offset: 0x0008B7E4
		private ComboItem<LengthUnit> #Tg(UnitSystem #Qg)
		{
			DxfImportWindowViewModel.#Ybc #Ybc = new DxfImportWindowViewModel.#Ybc();
			#Ybc.#a = ((#Qg == UnitSystem.SIMetric) ? LengthUnit.Millimeter : LengthUnit.Inch);
			return this.LengthUnitItems.Single(new Func<ComboItem<LengthUnit>, bool>(#Ybc.#nUb));
		}

		// Token: 0x06000698 RID: 1688 RVA: 0x0000AED4 File Offset: 0x000090D4
		private void #Ug(object #Vg)
		{
			base.View.Close();
		}

		// Token: 0x06000699 RID: 1689 RVA: 0x0008D628 File Offset: 0x0008B828
		private bool #MTi(out string #nzb)
		{
			#nzb = null;
			if (this.SelectedBarsLayer == null)
			{
				return true;
			}
			UnitSystem #Qg = base.Project.Model.Options.Unit;
			#ice #ib = #ice.#T9h(#Qg);
			#gee #gee = #6de.#ul(#ib);
			#6ce #6ce = #gee.Reinforcement.BarAreaImport;
			#t9d #t9d = new #t9d(#6ce.Min, #6ce.Max, #6ce.IncludeMin, #6ce.IncludeMax);
			bool flag = false;
			bool flag2 = false;
			foreach (StructurePoint.Products.Column.Model.Entities.ReinforcementBar reinforcementBar in this.#o.ProjectContext.Model.ReinforcementBars)
			{
				if (#t9d.#bYi((double)reinforcementBar.Area))
				{
					flag = true;
				}
				if (#t9d.#cYi((double)reinforcementBar.Area))
				{
					flag2 = true;
				}
			}
			string text = this.#o.ProjectContext.Model.Units.Section.BarArea.Unit.UnitSymbol.Symbol;
			string text2 = #6ce.Max.GetValueOrDefault().ToString(#Phc.#3hc(107383605), CultureInfo.CurrentCulture);
			string text3 = #6ce.Min.GetValueOrDefault().ToString(#Phc.#3hc(107383600), CultureInfo.CurrentCulture);
			if (flag && flag2)
			{
				#nzb = Strings.StringAllBarAreasShallBeGreaterThanOrEqualTo01AndSmallerThanOrEqualTo21.#D2d(new object[]
				{
					text3,
					text,
					text2
				}).#z2d();
			}
			else if (flag2)
			{
				#nzb = Strings.StringAllBarAreasShallBeSmallerThanOrEqualTo01.#D2d(new object[]
				{
					text2,
					text
				}).#z2d();
			}
			else if (flag)
			{
				#nzb = Strings.StringAllBarAreasShallBeGreaterThanOrEqualTo01.#D2d(new object[]
				{
					text3,
					text
				}).#z2d();
			}
			return !flag && !flag2;
		}

		// Token: 0x0600069A RID: 1690 RVA: 0x0008D838 File Offset: 0x0008BA38
		private void #Wg(object #Vg)
		{
			DxfImportWindowViewModel.#PUb #PUb = new DxfImportWindowViewModel.#PUb();
			DxfImportWindowViewModel.#PUb #PUb2;
			if (6 != 0)
			{
				#PUb2 = #PUb;
			}
			#PUb2.#a = this;
			try
			{
				this.DialogResult = null;
				if (this.#2E(#Vg))
				{
					string #Ukc;
					if (!this.#MTi(out #Ukc))
					{
						string #SSc = base.DialogService.#5Sc(Strings.StringCannotImportDXF.#z2d(), #Ukc);
						base.DialogService.#qn(#SSc);
					}
					else
					{
						#PUb2.#b = this.#o.ProjectContext.Model;
						this.#c.#0Pb(new Action(#PUb2.#pUb));
						this.DialogResult = new bool?(true);
						this.#Ug(null);
					}
				}
			}
			catch (Exception #ob)
			{
				base.Services.ExceptionHandler.#3Ab(#ob);
			}
		}

		// Token: 0x0600069B RID: 1691 RVA: 0x0008D928 File Offset: 0x0008BB28
		private void #Uge(#Uoe #Yg)
		{
			if (#Yg == null)
			{
				return;
			}
			if (!this.#e)
			{
				return;
			}
			ColumnStorageModel columnStorageModel = new ColumnStorageModel();
			columnStorageModel.Options.SectionType = SectionType.Irregular;
			columnStorageModel.Polygons.AddRange(#Yg.Solids);
			columnStorageModel.Polygons.AddRange(#Yg.Openings);
			Point3D point3D = SectionGeometryHelper.#gxc(columnStorageModel);
			if (point3D != null)
			{
				DxfImportWindowViewModel.#K9b #K9b = new DxfImportWindowViewModel.#K9b();
				#K9b.#a = (float)point3D.X;
				#K9b.#b = (float)point3D.Y;
				foreach (SectionPolygon sectionPolygon in #Yg.Solids)
				{
					IEnumerable<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point> points = sectionPolygon.Points;
					Func<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point, StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point> selector;
					if ((selector = #K9b.#c) == null)
					{
						selector = (#K9b.#c = new Func<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point, StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point>(#K9b.#WWh));
					}
					List<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point> collection = points.Select(selector).ToList<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point>();
					sectionPolygon.Points.Clear();
					sectionPolygon.Points.AddRange(collection);
				}
				foreach (SectionPolygon sectionPolygon2 in #Yg.Openings)
				{
					IEnumerable<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point> points2 = sectionPolygon2.Points;
					Func<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point, StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point> selector2;
					if ((selector2 = #K9b.#d) == null)
					{
						selector2 = (#K9b.#d = new Func<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point, StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point>(#K9b.#XWh));
					}
					List<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point> collection2 = points2.Select(selector2).ToList<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point>();
					sectionPolygon2.Points.Clear();
					sectionPolygon2.Points.AddRange(collection2);
				}
				List<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.ReinforcementBar> collection3 = #Yg.ReinforcementBars.Select(new Func<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.ReinforcementBar, StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.ReinforcementBar>(#K9b.#YWh)).ToList<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.ReinforcementBar>();
				#Yg.ReinforcementBars.Clear();
				#Yg.ReinforcementBars.AddRange(collection3);
			}
		}

		// Token: 0x0600069C RID: 1692 RVA: 0x0008DB18 File Offset: 0x0008BD18
		private void #gFb(#Uoe #Yg)
		{
			DxfImportWindowViewModel.#Ywf #Ywf = new DxfImportWindowViewModel.#Ywf();
			if (#Yg == null)
			{
				return;
			}
			LengthUnit #B = base.Project.Model.Units.Section.Width.UnitType;
			LengthUnit #K7d = this.UseUnitFromDXFFile ? #Yg.LengthUnit : this.SelectedLengthUnit.Value;
			#Ywf.#a = StructurePoint.CoreAssets.Units.LengthConverter.#18d(#K7d, #B);
			foreach (SectionPolygon sectionPolygon in #Yg.Solids)
			{
				IEnumerable<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point> points = sectionPolygon.Points;
				Func<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point, StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point> selector;
				if ((selector = #Ywf.#b) == null)
				{
					selector = (#Ywf.#b = new Func<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point, StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point>(#Ywf.#ZWh));
				}
				List<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point> collection = points.Select(selector).ToList<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point>();
				sectionPolygon.Points.Clear();
				sectionPolygon.Points.AddRange(collection);
			}
			foreach (SectionPolygon sectionPolygon2 in #Yg.Openings)
			{
				IEnumerable<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point> points2 = sectionPolygon2.Points;
				Func<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point, StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point> selector2;
				if ((selector2 = #Ywf.#c) == null)
				{
					selector2 = (#Ywf.#c = new Func<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point, StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point>(#Ywf.#0Wh));
				}
				List<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point> collection2 = points2.Select(selector2).ToList<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point>();
				sectionPolygon2.Points.Clear();
				sectionPolygon2.Points.AddRange(collection2);
			}
			List<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.ReinforcementBar> collection3 = #Yg.ReinforcementBars.Select(new Func<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.ReinforcementBar, StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.ReinforcementBar>(#Ywf.#1Wh)).ToList<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.ReinforcementBar>();
			#Yg.ReinforcementBars.Clear();
			#Yg.ReinforcementBars.AddRange(collection3);
		}

		// Token: 0x0600069D RID: 1693 RVA: 0x0000AEED File Offset: 0x000090ED
		[CompilerGenerated]
		private void #Gwi(object #Hi)
		{
			this.#JTi();
		}

		// Token: 0x0600069E RID: 1694 RVA: 0x0000AEFE File Offset: 0x000090FE
		[CompilerGenerated]
		private bool #LXi(ComboItem<LengthUnit> #b3b)
		{
			return #b3b.Value == this.#t;
		}

		// Token: 0x0600069F RID: 1695 RVA: 0x0000AF1A File Offset: 0x0000911A
		[CompilerGenerated]
		private void #MXi()
		{
			this.#JXi();
			this.#HSh();
			LayoutHelper.BeginInvokeOnApplicationThread(new Action(this.#LTi));
		}

		// Token: 0x04000172 RID: 370
		private readonly IExtendedServices #a;

		// Token: 0x04000173 RID: 371
		private readonly #Ioe #b;

		// Token: 0x04000174 RID: 372
		private readonly IEditorService #c;

		// Token: 0x04000175 RID: 373
		private bool #d;

		// Token: 0x04000176 RID: 374
		private bool #e;

		// Token: 0x04000177 RID: 375
		private ComboItem<LengthUnit> #f;

		// Token: 0x04000178 RID: 376
		private string #g;

		// Token: 0x04000179 RID: 377
		private readonly List<ComboItem<string>> #h = new List<ComboItem<string>>();

		// Token: 0x0400017A RID: 378
		private ComboItem<string> #i;

		// Token: 0x0400017B RID: 379
		private ComboItem<string> #j;

		// Token: 0x0400017C RID: 380
		private ComboItem<string> #k;

		// Token: 0x0400017D RID: 381
		private bool #l;

		// Token: 0x0400017E RID: 382
		private bool #m;

		// Token: 0x0400017F RID: 383
		private bool #n;

		// Token: 0x04000180 RID: 384
		private #cLb #o;

		// Token: 0x04000181 RID: 385
		private ColumnEditor #p;

		// Token: 0x04000182 RID: 386
		private ModelRenderer #q;

		// Token: 0x04000183 RID: 387
		private readonly #z9h #r = new #z9h();

		// Token: 0x04000184 RID: 388
		private bool #s;

		// Token: 0x04000185 RID: 389
		private LengthUnit #t;

		// Token: 0x04000186 RID: 390
		[CompilerGenerated]
		private readonly RadObservableCollection<ComboItem<LengthUnit>> #u = new RadObservableCollection<ComboItem<LengthUnit>>
		{
			new ComboItem<LengthUnit>(LengthUnit.Inch, Strings.StringIn),
			new ComboItem<LengthUnit>(LengthUnit.Foot, Strings.StringFoot),
			new ComboItem<LengthUnit>(LengthUnit.Yard, Strings.StringYard),
			new ComboItem<LengthUnit>(LengthUnit.Millimeter, Strings.StringMM),
			new ComboItem<LengthUnit>(LengthUnit.Centimeter, Strings.StringCM),
			new ComboItem<LengthUnit>(LengthUnit.Meter, Strings.StringM)
		};

		// Token: 0x04000187 RID: 391
		[CompilerGenerated]
		private readonly DelegateCommand #v;

		// Token: 0x04000188 RID: 392
		[CompilerGenerated]
		private readonly DelegateCommand #w;

		// Token: 0x04000189 RID: 393
		[CompilerGenerated]
		private readonly DelegateCommand #x;

		// Token: 0x0400018A RID: 394
		[CompilerGenerated]
		private bool? #y;

		// Token: 0x0400018B RID: 395
		[CompilerGenerated]
		private readonly CustomObservableCollection<ComboItem<string>> #z = new CustomObservableCollection<ComboItem<string>>();

		// Token: 0x0400018C RID: 396
		[CompilerGenerated]
		private readonly CustomObservableCollection<ComboItem<string>> #A = new CustomObservableCollection<ComboItem<string>>();

		// Token: 0x0400018D RID: 397
		[CompilerGenerated]
		private readonly CustomObservableCollection<ComboItem<string>> #B = new CustomObservableCollection<ComboItem<string>>();

		// Token: 0x020000D4 RID: 212
		[CompilerGenerated]
		private sealed class #uAf
		{
			// Token: 0x060006AF RID: 1711 RVA: 0x0000B049 File Offset: 0x00009249
			internal bool #iVi(ComboItem<LengthUnit> #Rf)
			{
				return #Rf.Value == this.#a;
			}

			// Token: 0x0400019B RID: 411
			public LengthUnit #a;
		}

		// Token: 0x020000D5 RID: 213
		[CompilerGenerated]
		private sealed class #Ybc
		{
			// Token: 0x060006B1 RID: 1713 RVA: 0x0008DCE4 File Offset: 0x0008BEE4
			internal bool #nUb(ComboItem<LengthUnit> #9o)
			{
				return #9o.Value.Equals(this.#a);
			}

			// Token: 0x0400019C RID: 412
			public LengthUnit #a;
		}

		// Token: 0x020000D6 RID: 214
		[CompilerGenerated]
		private sealed class #PUb
		{
			// Token: 0x060006B3 RID: 1715 RVA: 0x0008DD1C File Offset: 0x0008BF1C
			internal void #pUb()
			{
				this.#a.Project.Model.Options.SectionType = SectionType.Irregular;
				this.#a.Project.Model.Options.InvestigationReinforcement = ReinforcementType.Irregular;
				this.#a.Project.Model.Shapes.Clear();
				this.#a.Project.Model.Shapes.AddRange(this.#b.Shapes.Select(new Func<ShapeModel, ShapeModel>(DxfImportWindowViewModel.<>c.<>9.#0Xi)));
				this.#a.Project.Model.ReinforcementBars.Clear();
				this.#a.Project.Model.ReinforcementBars.AddRange(this.#b.ReinforcementBars.Select(new Func<StructurePoint.Products.Column.Model.Entities.ReinforcementBar, StructurePoint.Products.Column.Model.Entities.ReinforcementBar>(DxfImportWindowViewModel.<>c.<>9.#1Xi)));
				this.#a.Project.#3O();
				ColumnModelHelper.#VW(this.#a.Project);
				this.#a.#a.SnappingCache.#uP(this.#a.Project);
			}

			// Token: 0x0400019D RID: 413
			public DxfImportWindowViewModel #a;

			// Token: 0x0400019E RID: 414
			public ColumnModel #b;
		}

		// Token: 0x020000D7 RID: 215
		[CompilerGenerated]
		private sealed class #K9b
		{
			// Token: 0x060006B5 RID: 1717 RVA: 0x0000B065 File Offset: 0x00009265
			internal StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point #WWh(StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point #Rf)
			{
				return new StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point(#Rf.X - this.#a, #Rf.Y - this.#b);
			}

			// Token: 0x060006B6 RID: 1718 RVA: 0x0000B065 File Offset: 0x00009265
			internal StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point #XWh(StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point #Rf)
			{
				return new StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point(#Rf.X - this.#a, #Rf.Y - this.#b);
			}

			// Token: 0x060006B7 RID: 1719 RVA: 0x0000B092 File Offset: 0x00009292
			internal StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.ReinforcementBar #YWh(StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.ReinforcementBar #Rf)
			{
				return new StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.ReinforcementBar(#Rf.Area, #Rf.X - this.#a, #Rf.Y - this.#b, #Rf.Z);
			}

			// Token: 0x0400019F RID: 415
			public float #a;

			// Token: 0x040001A0 RID: 416
			public float #b;

			// Token: 0x040001A1 RID: 417
			public Func<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point, StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point> #c;

			// Token: 0x040001A2 RID: 418
			public Func<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point, StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point> #d;
		}

		// Token: 0x020000D8 RID: 216
		[CompilerGenerated]
		private sealed class #Ywf
		{
			// Token: 0x060006B9 RID: 1721 RVA: 0x0000B0CB File Offset: 0x000092CB
			internal StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point #ZWh(StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point #9o)
			{
				return DxfImportWindowViewModel.#Pb(#9o, this.#a);
			}

			// Token: 0x060006BA RID: 1722 RVA: 0x0000B0CB File Offset: 0x000092CB
			internal StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point #0Wh(StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point #9o)
			{
				return DxfImportWindowViewModel.#Pb(#9o, this.#a);
			}

			// Token: 0x060006BB RID: 1723 RVA: 0x0008DE84 File Offset: 0x0008C084
			internal StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.ReinforcementBar #1Wh(StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.ReinforcementBar #Rf)
			{
				return new StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.ReinforcementBar((float)((double)#Rf.Area * this.#a * this.#a), (float)((double)#Rf.X * this.#a), (float)((double)#Rf.Y * this.#a), (float)((double)#Rf.Z * this.#a));
			}

			// Token: 0x040001A3 RID: 419
			public double #a;

			// Token: 0x040001A4 RID: 420
			public Func<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point, StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point> #b;

			// Token: 0x040001A5 RID: 421
			public Func<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point, StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point> #c;
		}

		// Token: 0x020000D9 RID: 217
		[CompilerGenerated]
		private sealed class #Xwf
		{
			// Token: 0x060006BD RID: 1725 RVA: 0x0000B0E5 File Offset: 0x000092E5
			internal void #VWh()
			{
				this.#a.#q.#9f(false, false);
				if (this.#b)
				{
					this.#a.#LTi();
				}
			}

			// Token: 0x040001A6 RID: 422
			public DxfImportWindowViewModel #a;

			// Token: 0x040001A7 RID: 423
			public bool #b;
		}
	}
}
