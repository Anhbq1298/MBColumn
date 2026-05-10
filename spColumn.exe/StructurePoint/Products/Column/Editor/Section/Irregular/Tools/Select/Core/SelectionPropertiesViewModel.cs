using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using #7hc;
using #ABb;
using #eU;
using #gOb;
using #lH;
using #N6c;
using #RJb;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.Products.Column.Core.API;
using StructurePoint.Products.Column.Editor.Core.Selection;
using StructurePoint.Products.Column.Editor.Section.Common;
using StructurePoint.Products.Column.Model;
using StructurePoint.Products.Column.Model.Entities;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.Viewports.API;
using Telerik.Windows.Data;

namespace StructurePoint.Products.Column.Editor.Section.Irregular.Tools.Select.Core
{
	// Token: 0x0200055F RID: 1375
	internal sealed class SelectionPropertiesViewModel : #HH<#mCb>, INotifyPropertyChanged, IViewModel, IViewModel<#mCb>, #oCb
	{
		// Token: 0x060030D0 RID: 12496 RVA: 0x000FA174 File Offset: 0x000F8374
		public SelectionPropertiesViewModel(Lazy<#mCb> view, IExtendedServices services, IEditorService editorService) : base(view, services)
		{
			this.#a = services;
			this.#b = editorService;
			services.MessageBus.EditorSelectionChanged += this.#yyb;
			services.MessageBus.EditorNodesSelectionChanged += this.#qCb;
			services.MessageBus.SlabsEditorSelectionChanged += this.#pCb;
			services.UndoManager.PropertyChanged += this.#7j;
			services.MessageBus.DefinitionChangesCommitted += this.#owb;
			this.#c = new #MBb(base.Project);
			this.EmptyBarSizeOrAreaText = #Phc.#3hc(107355353);
		}

		// Token: 0x17000FBB RID: 4027
		// (get) Token: 0x060030D1 RID: 12497 RVA: 0x0002B3DA File Offset: 0x000295DA
		public #cLb EditorContext
		{
			get
			{
				IModelEditorViewport modelEditorViewport = this.#a.ViewportsManager.ActiveViewport as IModelEditorViewport;
				if (modelEditorViewport == null)
				{
					return null;
				}
				return modelEditorViewport.EditorContext;
			}
		}

		// Token: 0x17000FBC RID: 4028
		// (get) Token: 0x060030D2 RID: 12498 RVA: 0x0002B408 File Offset: 0x00029608
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x060030D3 RID: 12499 RVA: 0x0002B418 File Offset: 0x00029618
		public void #5b()
		{
			base.RaisePropertyChanged(#Phc.#3hc(107355308));
			this.#uCb();
		}

		// Token: 0x060030D4 RID: 12500 RVA: 0x000FA2B0 File Offset: 0x000F84B0
		public void #nCb()
		{
			try
			{
				this.#e = true;
				this.#sCb();
				this.#uCb();
				if (this.HasErrors)
				{
					base.ClearErrors();
				}
			}
			finally
			{
				this.#e = false;
			}
		}

		// Token: 0x060030D5 RID: 12501 RVA: 0x0002B43C File Offset: 0x0002963C
		private void #owb(object #Ge, EventArgs #He)
		{
			this.#nCb();
		}

		// Token: 0x060030D6 RID: 12502 RVA: 0x000FA304 File Offset: 0x000F8504
		private void #7j(object #Ge, PropertyChangedEventArgs #He)
		{
			if (this.SectionPositionAndSizeVisibility == Visibility.Visible && base.UndoManager.TransactionDepth <= 0L)
			{
				this.#rCb();
			}
			if (this.BarPositionVisibility == Visibility.Visible && base.UndoManager.TransactionDepth <= 0L)
			{
				this.#tCb();
			}
		}

		// Token: 0x060030D7 RID: 12503 RVA: 0x0002B43C File Offset: 0x0002963C
		private void #pCb(object #Ge, EventArgs #He)
		{
			this.#nCb();
		}

		// Token: 0x060030D8 RID: 12504 RVA: 0x0002B43C File Offset: 0x0002963C
		private void #qCb(object #Ge, EventArgs #He)
		{
			this.#nCb();
		}

		// Token: 0x060030D9 RID: 12505 RVA: 0x0002B43C File Offset: 0x0002963C
		private void #yyb(object #Ge, EventArgs #He)
		{
			this.#nCb();
		}

		// Token: 0x060030DA RID: 12506 RVA: 0x000FA358 File Offset: 0x000F8558
		private void #rCb()
		{
			#cLb #cLb = this.EditorContext;
			#47c<ShapeModel> #47c = (#cLb != null) ? #cLb.Selection.Shapes.SelectedObjects : null;
			bool flag = this.#r;
			this.#r = true;
			if (this.SectionPositionAndSizeVisibility == Visibility.Visible && #47c != null && #47c.Count == 1)
			{
				ShapeModel shapeModel = #47c.First<ShapeModel>();
				PolygonData polygonData = shapeModel.#cxc(0);
				this.SectionFigureType = shapeModel.FigureType;
				if (shapeModel.FigureType == PolygonFigureType.Circle && shapeModel.CircleCenter != null && shapeModel.CircleRadius != null)
				{
					this.SectionPositionX = shapeModel.CircleCenter.Value.X;
					this.SectionPositionY = shapeModel.CircleCenter.Value.Y;
					this.SectionDimensionX = shapeModel.CircleRadius.Value * 2.0;
				}
				else
				{
					this.SectionPositionX = polygonData.BoundingBoxData.TopLeft.X;
					this.SectionPositionY = polygonData.BoundingBoxData.TopLeft.Y;
					this.SectionDimensionX = polygonData.BoundingBoxData.Width;
					this.SectionDimensionY = polygonData.BoundingBoxData.Height;
				}
			}
			this.#r = flag;
		}

		// Token: 0x060030DB RID: 12507 RVA: 0x000FA4CC File Offset: 0x000F86CC
		private void #sCb()
		{
			SelectionState selectionState = this.EditorContext.Selection.State;
			SelectionManager selectionManager = this.EditorContext.Selection;
			this.SectionPanelVisibility = selectionState.Slabs.AnySelected.ToVisibility();
			this.SectionPositionAndSizeVisibility = (selectionState.Slabs.OnlySelected && selectionState.Slabs.SingleSelected).ToVisibility();
			List<PolygonApplication> list = selectionManager.Shapes.SelectedObjects.Select(new Func<ShapeModel, PolygonApplication>(SelectionPropertiesViewModel.<>c.<>9.#Azf)).Distinct<PolygonApplication>().ToList<PolygonApplication>();
			if (list.Count == 1)
			{
				this.SectionPolygonApplication = new PolygonApplication?(list[0]);
				this.EmptySectionTypeComboBoxText = string.Empty;
			}
			else
			{
				this.SectionPolygonApplication = null;
				this.EmptySectionTypeComboBoxText = #Phc.#3hc(107355319);
			}
			this.#rCb();
		}

		// Token: 0x060030DC RID: 12508 RVA: 0x000FA5D8 File Offset: 0x000F87D8
		private void #tCb()
		{
			#cLb #cLb = this.EditorContext;
			#47c<ReinforcementBar> #47c = (#cLb != null) ? #cLb.Selection.Bars.SelectedObjects : null;
			bool flag = this.#r;
			this.#r = true;
			if (this.BarPositionVisibility == Visibility.Visible && #47c != null && #47c.Count == 1)
			{
				ReinforcementBar reinforcementBar = #47c[0];
				this.BarPositionX = (double)reinforcementBar.X;
				this.BarPositionY = (double)reinforcementBar.Y;
			}
			this.#r = flag;
		}

		// Token: 0x060030DD RID: 12509 RVA: 0x000FA65C File Offset: 0x000F885C
		private void #uCb()
		{
			try
			{
				this.#d = true;
				SelectionState selectionState = this.EditorContext.Selection.State;
				SelectionManager selectionManager = this.EditorContext.Selection;
				this.BarsPanelVisibility = selectionState.Bars.AnySelected.ToVisibility();
				this.BarPositionVisibility = (selectionState.Bars.OnlySelected && selectionState.Bars.SingleSelected).ToVisibility();
				#47c<ReinforcementBar> source = selectionManager.Bars.SelectedObjects;
				List<int?> list = source.Select(new Func<ReinforcementBar, int?>(this.#ywf)).Distinct<int?>().ToList<int?>();
				List<double> list2 = source.Select(new Func<ReinforcementBar, double>(SelectionPropertiesViewModel.<>c.<>9.#Bzf)).Distinct<double>().ToList<double>();
				this.SelectedBarArea = ((list2.Count == 1) ? new double?(list2[0]) : null);
				if (list.Any<int?>())
				{
					if (list.All(new Func<int?, bool>(SelectionPropertiesViewModel.<>c.<>9.#Czf)))
					{
						this.SelectedBarDimensionSpecifierType = new BarDimensionSpecifierType?(BarDimensionSpecifierType.Size);
						int? num;
						if (list.Count != 1)
						{
							num = null;
						}
						else
						{
							int? num2 = list[0];
							num = ((num2 != null) ? num2 : null);
						}
						this.SelectedBarSize = num;
						goto IL_1C2;
					}
				}
				bool flag = list.Any(new Func<int?, bool>(SelectionPropertiesViewModel.<>c.<>9.#Dzf));
				bool flag2 = list2.Any<double>();
				this.SelectedBarDimensionSpecifierType = ((flag && flag2) ? null : new BarDimensionSpecifierType?(BarDimensionSpecifierType.Area));
				this.SelectedBarSize = null;
				IL_1C2:
				this.#tCb();
			}
			finally
			{
				this.#d = false;
			}
		}

		// Token: 0x060030DE RID: 12510 RVA: 0x000FA870 File Offset: 0x000F8A70
		private int? #vCb(double #wCb)
		{
			SelectionPropertiesViewModel.#uZb #uZb = new SelectionPropertiesViewModel.#uZb();
			#uZb.#a = #wCb;
			StandardBar standardBar = base.Project.Model.Bars.FirstOrDefault(new Func<StandardBar, bool>(#uZb.#u9b));
			if (standardBar == null)
			{
				return null;
			}
			return new int?(standardBar.Size);
		}

		// Token: 0x060030DF RID: 12511 RVA: 0x000FA8D0 File Offset: 0x000F8AD0
		private void #xCb()
		{
			ShapesSelectionManager shapesSelectionManager = this.EditorContext.Selection.Shapes;
			if (this.#r || shapesSelectionManager.NoOfSelectedObjects != 1 || this.#e)
			{
				return;
			}
			this.#b.#0Pb(new Func<bool>(this.#zwf));
		}

		// Token: 0x060030E0 RID: 12512 RVA: 0x000FA92C File Offset: 0x000F8B2C
		private void #yCb()
		{
			#QOb<ReinforcementBar> #QOb = this.EditorContext.Selection.Bars;
			if (this.#r || #QOb.NoOfSelectedObjects != 1 || this.#e)
			{
				return;
			}
			this.#b.#0Pb(new Func<bool>(this.#Awf));
		}

		// Token: 0x060030E1 RID: 12513 RVA: 0x000FA988 File Offset: 0x000F8B88
		private void #zCb()
		{
			#oW #xn = base.Project;
			if (!false)
			{
				ColumnModelHelper.#VW(#xn);
			}
			this.#a.SnappingCache.#uP(base.Project);
			this.#a.Renderer.#9f(false, false);
		}

		// Token: 0x060030E2 RID: 12514 RVA: 0x000FA9D8 File Offset: 0x000F8BD8
		private bool #ACb(double #f, [CallerMemberName] string #em = null)
		{
			string #;
			bool flag = this.#c.#HBb(#f, out #);
			this.#CCb(#em, flag, #);
			return flag;
		}

		// Token: 0x060030E3 RID: 12515 RVA: 0x000FAA0C File Offset: 0x000F8C0C
		private bool #BCb(double #f, [CallerMemberName] string #em = null)
		{
			string #;
			bool flag = this.#c.#GBb(#f, out #);
			this.#CCb(#em, flag, #);
			return flag;
		}

		// Token: 0x060030E4 RID: 12516 RVA: 0x0002B44C File Offset: 0x0002964C
		private void #CCb(string #em, bool #DCb, string #5)
		{
			if (#DCb)
			{
				base.RemoveError(#em);
				return;
			}
			this.AddError(#em, #5);
		}

		// Token: 0x060030E5 RID: 12517 RVA: 0x000FAA40 File Offset: 0x000F8C40
		private bool #ECb(double #f, [CallerMemberName] string #em = null)
		{
			string #;
			bool flag = this.#c.#FBb(#f, out #);
			this.#CCb(#em, flag, #);
			return flag;
		}

		// Token: 0x17000FBD RID: 4029
		// (get) Token: 0x060030E6 RID: 12518 RVA: 0x0002B46D File Offset: 0x0002966D
		public RadObservableCollection<ComboItem<PolygonApplication>> PolygonApplications { get; }

		// Token: 0x17000FBE RID: 4030
		// (get) Token: 0x060030E7 RID: 12519 RVA: 0x0002B479 File Offset: 0x00029679
		// (set) Token: 0x060030E8 RID: 12520 RVA: 0x000FAA74 File Offset: 0x000F8C74
		public string EmptySectionTypeComboBoxText
		{
			get
			{
				return this.#q;
			}
			set
			{
				if (this.#q != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107355274));
					this.#q = value;
					base.RaisePropertyChanged(#Phc.#3hc(107355274));
				}
			}
		}

		// Token: 0x17000FBF RID: 4031
		// (get) Token: 0x060030E9 RID: 12521 RVA: 0x0002B485 File Offset: 0x00029685
		// (set) Token: 0x060030EA RID: 12522 RVA: 0x0002B491 File Offset: 0x00029691
		public Visibility SectionPanelVisibility
		{
			get
			{
				return this.#f;
			}
			set
			{
				if (this.#f != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107355233));
					this.#f = value;
					base.RaisePropertyChanged(#Phc.#3hc(107355233));
				}
			}
		}

		// Token: 0x17000FC0 RID: 4032
		// (get) Token: 0x060030EB RID: 12523 RVA: 0x0002B4CF File Offset: 0x000296CF
		// (set) Token: 0x060030EC RID: 12524 RVA: 0x0002B4DB File Offset: 0x000296DB
		public Visibility SectionPositionAndSizeVisibility
		{
			get
			{
				return this.#g;
			}
			set
			{
				if (this.#g != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107355200));
					this.#g = value;
					base.RaisePropertyChanged(#Phc.#3hc(107355200));
				}
			}
		}

		// Token: 0x17000FC1 RID: 4033
		// (get) Token: 0x060030ED RID: 12525 RVA: 0x0002B519 File Offset: 0x00029719
		// (set) Token: 0x060030EE RID: 12526 RVA: 0x0002B525 File Offset: 0x00029725
		public Visibility ReinforcementPanelVisibility
		{
			get
			{
				return this.#h;
			}
			set
			{
				if (this.#h != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107355187));
					this.#h = value;
					base.RaisePropertyChanged(#Phc.#3hc(107355187));
				}
			}
		}

		// Token: 0x17000FC2 RID: 4034
		// (get) Token: 0x060030EF RID: 12527 RVA: 0x0002B563 File Offset: 0x00029763
		// (set) Token: 0x060030F0 RID: 12528 RVA: 0x0002B56F File Offset: 0x0002976F
		public Visibility ReinforcementPositionVisibility
		{
			get
			{
				return this.#i;
			}
			set
			{
				if (this.#i != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107355626));
					this.#i = value;
					base.RaisePropertyChanged(#Phc.#3hc(107355626));
				}
			}
		}

		// Token: 0x17000FC3 RID: 4035
		// (get) Token: 0x060030F1 RID: 12529 RVA: 0x0002B5AD File Offset: 0x000297AD
		// (set) Token: 0x060030F2 RID: 12530 RVA: 0x0002B5B9 File Offset: 0x000297B9
		public PolygonFigureType SectionFigureType
		{
			get
			{
				return this.#j;
			}
			set
			{
				if (this.#j != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107355613));
					this.#j = value;
					base.RaisePropertyChanged(#Phc.#3hc(107355613));
				}
			}
		}

		// Token: 0x17000FC4 RID: 4036
		// (get) Token: 0x060030F3 RID: 12531 RVA: 0x0002B5F7 File Offset: 0x000297F7
		// (set) Token: 0x060030F4 RID: 12532 RVA: 0x000FAAC4 File Offset: 0x000F8CC4
		public double SectionPositionX
		{
			get
			{
				return this.#k;
			}
			set
			{
				if (this.#k != value)
				{
					double #MW = this.#k;
					if (this.#BCb(value, #Phc.#3hc(107355556)) && this.SetProperty<double>(ref this.#k, value, #Phc.#3hc(107355556)) && ColumnModelHelper.#LW(base.Project, value, #MW))
					{
						this.#xCb();
					}
				}
			}
		}

		// Token: 0x17000FC5 RID: 4037
		// (get) Token: 0x060030F5 RID: 12533 RVA: 0x0002B603 File Offset: 0x00029803
		// (set) Token: 0x060030F6 RID: 12534 RVA: 0x000FAB30 File Offset: 0x000F8D30
		public double SectionPositionY
		{
			get
			{
				return this.#l;
			}
			set
			{
				if (this.#l != value)
				{
					double #MW = this.#l;
					if (this.#BCb(value, #Phc.#3hc(107355531)) && this.SetProperty<double>(ref this.#l, value, #Phc.#3hc(107355531)) && ColumnModelHelper.#LW(base.Project, value, #MW))
					{
						this.#xCb();
					}
				}
			}
		}

		// Token: 0x17000FC6 RID: 4038
		// (get) Token: 0x060030F7 RID: 12535 RVA: 0x0002B60F File Offset: 0x0002980F
		// (set) Token: 0x060030F8 RID: 12536 RVA: 0x000FAB9C File Offset: 0x000F8D9C
		public double SectionDimensionX
		{
			get
			{
				return this.#m;
			}
			set
			{
				if (this.#m != value)
				{
					double #MW = this.#m;
					if (this.#ECb(value, #Phc.#3hc(107355538)) && this.SetProperty<double>(ref this.#m, value, #Phc.#3hc(107355538)) && ColumnModelHelper.#LW(base.Project, value, #MW))
					{
						this.#xCb();
					}
				}
			}
		}

		// Token: 0x17000FC7 RID: 4039
		// (get) Token: 0x060030F9 RID: 12537 RVA: 0x0002B61B File Offset: 0x0002981B
		// (set) Token: 0x060030FA RID: 12538 RVA: 0x000FAC08 File Offset: 0x000F8E08
		public double SectionDimensionY
		{
			get
			{
				return this.#n;
			}
			set
			{
				if (this.#n != value)
				{
					double #MW = this.#n;
					if (this.#ECb(value, #Phc.#3hc(107355513)) && this.SetProperty<double>(ref this.#n, value, #Phc.#3hc(107355513)) && ColumnModelHelper.#LW(base.Project, value, #MW))
					{
						this.#xCb();
					}
				}
			}
		}

		// Token: 0x17000FC8 RID: 4040
		// (get) Token: 0x060030FB RID: 12539 RVA: 0x0002B627 File Offset: 0x00029827
		// (set) Token: 0x060030FC RID: 12540 RVA: 0x000FAC74 File Offset: 0x000F8E74
		public PolygonApplication? SectionPolygonApplication
		{
			get
			{
				return this.#o;
			}
			set
			{
				SelectionPropertiesViewModel.#Ezf #Ezf = new SelectionPropertiesViewModel.#Ezf();
				#Ezf.#a = this;
				#Ezf.#b = value;
				PolygonApplication? polygonApplication = this.#o;
				PolygonApplication? polygonApplication2 = #Ezf.#b;
				if (!(polygonApplication.GetValueOrDefault() == polygonApplication2.GetValueOrDefault() & polygonApplication != null == (polygonApplication2 != null)))
				{
					base.RaisePropertyChanging(#Phc.#3hc(107355456));
					this.#o = #Ezf.#b;
					if (#Ezf.#b != null && !this.#e && !this.#r)
					{
						this.#b.#0Pb(new Action(#Ezf.#v9b));
					}
					base.RaisePropertyChanged(#Phc.#3hc(107355456));
				}
			}
		}

		// Token: 0x17000FC9 RID: 4041
		// (get) Token: 0x060030FD RID: 12541 RVA: 0x0002B633 File Offset: 0x00029833
		// (set) Token: 0x060030FE RID: 12542 RVA: 0x0002B63F File Offset: 0x0002983F
		public int NumberOfSelectedShapes
		{
			get
			{
				return this.#p;
			}
			set
			{
				if (this.#p != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107355451));
					this.#p = value;
					base.RaisePropertyChanged(#Phc.#3hc(107355451));
				}
			}
		}

		// Token: 0x17000FCA RID: 4042
		// (get) Token: 0x060030FF RID: 12543 RVA: 0x0002B67D File Offset: 0x0002987D
		// (set) Token: 0x06003100 RID: 12544 RVA: 0x000FAD48 File Offset: 0x000F8F48
		public BarDimensionSpecifierType? SelectedBarDimensionSpecifierType
		{
			get
			{
				return this.#s;
			}
			set
			{
				BarDimensionSpecifierType? barDimensionSpecifierType = this.#s;
				BarDimensionSpecifierType? barDimensionSpecifierType2 = value;
				if (!(barDimensionSpecifierType.GetValueOrDefault() == barDimensionSpecifierType2.GetValueOrDefault() & barDimensionSpecifierType != null == (barDimensionSpecifierType2 != null)))
				{
					base.RaisePropertyChanging(#Phc.#3hc(107355418));
					this.#s = value;
					base.RaisePropertyChanged(#Phc.#3hc(107355418));
				}
			}
		}

		// Token: 0x17000FCB RID: 4043
		// (get) Token: 0x06003101 RID: 12545 RVA: 0x0002B689 File Offset: 0x00029889
		public RadObservableCollection<ComboItem<BarDimensionSpecifierType>> BarDimensionSpecifierTypes { get; }

		// Token: 0x17000FCC RID: 4044
		// (get) Token: 0x06003102 RID: 12546 RVA: 0x0002B695 File Offset: 0x00029895
		// (set) Token: 0x06003103 RID: 12547 RVA: 0x000FADB4 File Offset: 0x000F8FB4
		public int? SelectedBarSize
		{
			get
			{
				return this.#t;
			}
			set
			{
				SelectionPropertiesViewModel.#3Tb #3Tb = new SelectionPropertiesViewModel.#3Tb();
				#3Tb.#a = this;
				#3Tb.#b = value;
				int? num = this.#t;
				int? num2 = #3Tb.#b;
				if (!(num.GetValueOrDefault() == num2.GetValueOrDefault() & num != null == (num2 != null)))
				{
					if (#3Tb.#b == null)
					{
						this.#t = new int?(this.#p);
						base.RaisePropertyChanged(#Phc.#3hc(107354829));
						return;
					}
					if (this.SetProperty<int?>(ref this.#t, #3Tb.#b, #Phc.#3hc(107354829)) && !this.#e && !this.#r)
					{
						this.#b.#0Pb(new Func<bool>(#3Tb.#x9b));
					}
				}
			}
		}

		// Token: 0x17000FCD RID: 4045
		// (get) Token: 0x06003104 RID: 12548 RVA: 0x0002B6A1 File Offset: 0x000298A1
		// (set) Token: 0x06003105 RID: 12549 RVA: 0x000FAE9C File Offset: 0x000F909C
		public double? SelectedBarArea
		{
			get
			{
				return this.#u;
			}
			set
			{
				SelectionPropertiesViewModel.#Xwf #Xwf = new SelectionPropertiesViewModel.#Xwf();
				SelectionPropertiesViewModel.#Xwf #Xwf2;
				if (true)
				{
					#Xwf2 = #Xwf;
				}
				#Xwf2.#a = this;
				#Xwf2.#b = value;
				double? num = this.#u;
				double? num2 = #Xwf2.#b;
				if (!(num.GetValueOrDefault() == num2.GetValueOrDefault() & num != null == (num2 != null)))
				{
					if (#Xwf2.#b == null)
					{
						this.#u = null;
						base.RaisePropertyChanged(#Phc.#3hc(107354840));
						return;
					}
					double #MW = this.#v;
					if (this.#ACb(#Xwf2.#b.Value, #Phc.#3hc(107354840)) && this.SetProperty<double?>(ref this.#u, #Xwf2.#b, #Phc.#3hc(107354840)) && ColumnModelHelper.#LW(base.Project, #Xwf2.#b.Value, #MW) && !this.#e && !this.#r)
					{
						this.#b.#0Pb(new Action(#Xwf2.#A9b));
					}
					if (this.#d && !this.#ACb(#Xwf2.#b.Value, #Phc.#3hc(107354840)))
					{
						this.SetProperty<double?>(ref this.#u, #Xwf2.#b, #Phc.#3hc(107354840));
						return;
					}
				}
				else if (this.#d && #Xwf2.#b != null && !this.#ACb(#Xwf2.#b.Value, #Phc.#3hc(107354840)))
				{
					this.SetProperty<double?>(ref this.#u, #Xwf2.#b, #Phc.#3hc(107354840));
				}
			}
		}

		// Token: 0x17000FCE RID: 4046
		// (get) Token: 0x06003106 RID: 12550 RVA: 0x0002B6AD File Offset: 0x000298AD
		// (set) Token: 0x06003107 RID: 12551 RVA: 0x000FB054 File Offset: 0x000F9254
		public double BarPositionX
		{
			get
			{
				return this.#v;
			}
			set
			{
				if (this.#v != value)
				{
					double #MW = this.#v;
					if (this.#BCb(value, #Phc.#3hc(107354787)) && this.SetProperty<double>(ref this.#v, value, #Phc.#3hc(107354787)) && ColumnModelHelper.#LW(base.Project, value, #MW))
					{
						this.#yCb();
					}
				}
			}
		}

		// Token: 0x17000FCF RID: 4047
		// (get) Token: 0x06003108 RID: 12552 RVA: 0x0002B6B9 File Offset: 0x000298B9
		// (set) Token: 0x06003109 RID: 12553 RVA: 0x000FB0C0 File Offset: 0x000F92C0
		public double BarPositionY
		{
			get
			{
				return this.#w;
			}
			set
			{
				if (this.#w != value)
				{
					double #MW = this.#w;
					if (this.#BCb(value, #Phc.#3hc(107354802)) && this.SetProperty<double>(ref this.#w, value, #Phc.#3hc(107354802)) && ColumnModelHelper.#LW(base.Project, value, #MW))
					{
						this.#yCb();
					}
				}
			}
		}

		// Token: 0x17000FD0 RID: 4048
		// (get) Token: 0x0600310A RID: 12554 RVA: 0x0002B6C5 File Offset: 0x000298C5
		// (set) Token: 0x0600310B RID: 12555 RVA: 0x0002B6D1 File Offset: 0x000298D1
		public Visibility BarPositionVisibility
		{
			get
			{
				return this.#x;
			}
			set
			{
				if (this.#x != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107354753));
					this.#x = value;
					base.RaisePropertyChanged(#Phc.#3hc(107354753));
				}
			}
		}

		// Token: 0x17000FD1 RID: 4049
		// (get) Token: 0x0600310C RID: 12556 RVA: 0x0002B70F File Offset: 0x0002990F
		// (set) Token: 0x0600310D RID: 12557 RVA: 0x0002B71B File Offset: 0x0002991B
		public Visibility BarsPanelVisibility
		{
			get
			{
				return this.#y;
			}
			set
			{
				if (this.#y != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107354724));
					this.#y = value;
					base.RaisePropertyChanged(#Phc.#3hc(107354724));
				}
			}
		}

		// Token: 0x17000FD2 RID: 4050
		// (get) Token: 0x0600310E RID: 12558 RVA: 0x0002B759 File Offset: 0x00029959
		// (set) Token: 0x0600310F RID: 12559 RVA: 0x0002B765 File Offset: 0x00029965
		public string EmptyBarSizeOrAreaText { get; set; }

		// Token: 0x06003110 RID: 12560 RVA: 0x0002B776 File Offset: 0x00029976
		[CompilerGenerated]
		private int? #ywf(ReinforcementBar #Rf)
		{
			return this.#vCb((double)#Rf.Area);
		}

		// Token: 0x06003111 RID: 12561 RVA: 0x000FB12C File Offset: 0x000F932C
		[CompilerGenerated]
		private bool #zwf()
		{
			ShapeModel shapeModel = this.EditorContext.Selection.Shapes.SelectedObjects.FirstOrDefault<ShapeModel>();
			if (shapeModel == null)
			{
				return false;
			}
			if (shapeModel.FigureType == PolygonFigureType.Circle)
			{
				shapeModel.#q0(this.SectionDimensionX / 2.0);
				shapeModel.#o0(new StructurePoint.CoreAssets.Infrastructure.Data.Point?(new StructurePoint.CoreAssets.Infrastructure.Data.Point(this.SectionPositionX, this.SectionPositionY)));
				ColumnShapesHelper.#vHb(base.Project, default(StructurePoint.CoreAssets.Infrastructure.Data.Point), shapeModel);
			}
			else
			{
				PolygonData polygonData = shapeModel.#cxc(0);
				BoundingBoxData boundingBoxData = polygonData.BoundingBoxData;
				StructurePoint.CoreAssets.Infrastructure.Data.Vector #EHb = StructurePoint.CoreAssets.Infrastructure.Data.Point.#H3d(new StructurePoint.CoreAssets.Infrastructure.Data.Point(this.SectionPositionX, this.SectionPositionY), boundingBoxData.TopLeft);
				polygonData = polygonData.#mwc(#EHb);
				boundingBoxData = polygonData.BoundingBoxData;
				double #qwc = this.SectionDimensionX / boundingBoxData.Width;
				double #rwc = this.SectionDimensionY / boundingBoxData.Height;
				if (#MBb.#EBb(#rwc) && #MBb.#EBb(#qwc))
				{
					polygonData = polygonData.#pwc(#qwc, #rwc);
				}
				polygonData = polygonData.#mwc(boundingBoxData.MinX - polygonData.BoundingBoxData.MinX, boundingBoxData.MaxY - polygonData.BoundingBoxData.MaxY);
				shapeModel.#8wc(polygonData);
			}
			this.#zCb();
			return true;
		}

		// Token: 0x06003112 RID: 12562 RVA: 0x000FB280 File Offset: 0x000F9480
		[CompilerGenerated]
		private bool #Awf()
		{
			ReinforcementBar reinforcementBar = this.EditorContext.Selection.Bars.SelectedObjects.FirstOrDefault<ReinforcementBar>();
			if (reinforcementBar == null)
			{
				return false;
			}
			IEnumerable<ReinforcementBar> #8f = ColumnModelHelper.#5W(base.Project.Model.ReinforcementBars, this.BarPositionX, this.BarPositionY);
			base.Project.Model.ReinforcementBars.#F7c(#8f);
			reinforcementBar.X = (float)this.BarPositionX;
			reinforcementBar.Y = (float)this.BarPositionY;
			if (!base.Project.Model.ReinforcementBars.Contains(reinforcementBar))
			{
				base.Project.Model.ReinforcementBars.Add(reinforcementBar);
			}
			this.#zCb();
			return true;
		}

		// Token: 0x040013D3 RID: 5075
		private readonly IExtendedServices #a;

		// Token: 0x040013D4 RID: 5076
		private readonly IEditorService #b;

		// Token: 0x040013D5 RID: 5077
		private readonly #MBb #c;

		// Token: 0x040013D6 RID: 5078
		private bool #d;

		// Token: 0x040013D7 RID: 5079
		private bool #e;

		// Token: 0x040013D8 RID: 5080
		private Visibility #f = Visibility.Collapsed;

		// Token: 0x040013D9 RID: 5081
		private Visibility #g = Visibility.Collapsed;

		// Token: 0x040013DA RID: 5082
		private Visibility #h = Visibility.Collapsed;

		// Token: 0x040013DB RID: 5083
		private Visibility #i = Visibility.Collapsed;

		// Token: 0x040013DC RID: 5084
		private PolygonFigureType #j;

		// Token: 0x040013DD RID: 5085
		private double #k;

		// Token: 0x040013DE RID: 5086
		private double #l;

		// Token: 0x040013DF RID: 5087
		private double #m;

		// Token: 0x040013E0 RID: 5088
		private double #n;

		// Token: 0x040013E1 RID: 5089
		private PolygonApplication? #o;

		// Token: 0x040013E2 RID: 5090
		private int #p;

		// Token: 0x040013E3 RID: 5091
		private string #q;

		// Token: 0x040013E4 RID: 5092
		private bool #r;

		// Token: 0x040013E5 RID: 5093
		private BarDimensionSpecifierType? #s;

		// Token: 0x040013E6 RID: 5094
		private int? #t;

		// Token: 0x040013E7 RID: 5095
		private double? #u;

		// Token: 0x040013E8 RID: 5096
		private double #v;

		// Token: 0x040013E9 RID: 5097
		private double #w;

		// Token: 0x040013EA RID: 5098
		private Visibility #x = Visibility.Collapsed;

		// Token: 0x040013EB RID: 5099
		private Visibility #y = Visibility.Collapsed;

		// Token: 0x040013EC RID: 5100
		[CompilerGenerated]
		private readonly RadObservableCollection<ComboItem<PolygonApplication>> #z = new RadObservableCollection<ComboItem<PolygonApplication>>
		{
			new ComboItem<PolygonApplication>(PolygonApplication.Solid, Strings.StringSolid),
			new ComboItem<PolygonApplication>(PolygonApplication.Opening, Strings.StringOpening)
		};

		// Token: 0x040013ED RID: 5101
		[CompilerGenerated]
		private readonly RadObservableCollection<ComboItem<BarDimensionSpecifierType>> #A = new RadObservableCollection<ComboItem<BarDimensionSpecifierType>>
		{
			new ComboItem<BarDimensionSpecifierType>(BarDimensionSpecifierType.Area, Strings.StringArea),
			new ComboItem<BarDimensionSpecifierType>(BarDimensionSpecifierType.Size, Strings.StringSize)
		};

		// Token: 0x040013EE RID: 5102
		[CompilerGenerated]
		private string #B;

		// Token: 0x02000561 RID: 1377
		[CompilerGenerated]
		private sealed class #uZb
		{
			// Token: 0x0600311A RID: 12570 RVA: 0x0002B7D9 File Offset: 0x000299D9
			internal bool #u9b(StandardBar #Rf)
			{
				return Math.Abs(this.#a - (double)#Rf.Area) <= 0.001;
			}

			// Token: 0x040013F4 RID: 5108
			public double #a;
		}

		// Token: 0x02000562 RID: 1378
		[CompilerGenerated]
		private sealed class #Ezf
		{
			// Token: 0x0600311C RID: 12572 RVA: 0x000FB354 File Offset: 0x000F9554
			internal void #v9b()
			{
				foreach (ShapeModel shapeModel in this.#a.EditorContext.Selection.Shapes.SelectedObjects)
				{
					shapeModel.Application = this.#b.Value;
					this.#a.Project.#1Uh(shapeModel);
				}
				this.#a.#a.Renderer.#9f(false, false);
			}

			// Token: 0x040013F5 RID: 5109
			public SelectionPropertiesViewModel #a;

			// Token: 0x040013F6 RID: 5110
			public PolygonApplication? #b;
		}

		// Token: 0x02000563 RID: 1379
		[CompilerGenerated]
		private sealed class #3Tb
		{
			// Token: 0x0600311E RID: 12574 RVA: 0x000FB400 File Offset: 0x000F9600
			internal bool #x9b()
			{
				IEnumerable<StandardBar> source = this.#a.Project.Model.Bars;
				Func<StandardBar, bool> predicate;
				if ((predicate = this.#c) == null)
				{
					predicate = (this.#c = new Func<StandardBar, bool>(this.#y9b));
				}
				StandardBar standardBar = source.FirstOrDefault(predicate);
				if (standardBar == null)
				{
					return false;
				}
				foreach (ReinforcementBar reinforcementBar in this.#a.EditorContext.Selection.Bars.SelectedObjects)
				{
					reinforcementBar.Area = standardBar.Area;
				}
				this.#a.#zCb();
				this.#a.#uCb();
				return true;
			}

			// Token: 0x0600311F RID: 12575 RVA: 0x0002B808 File Offset: 0x00029A08
			internal bool #y9b(StandardBar #Rf)
			{
				return #Rf.Size == this.#b.Value;
			}

			// Token: 0x040013F7 RID: 5111
			public SelectionPropertiesViewModel #a;

			// Token: 0x040013F8 RID: 5112
			public int? #b;

			// Token: 0x040013F9 RID: 5113
			public Func<StandardBar, bool> #c;
		}

		// Token: 0x02000564 RID: 1380
		[CompilerGenerated]
		private sealed class #Xwf
		{
			// Token: 0x06003121 RID: 12577 RVA: 0x000FB4DC File Offset: 0x000F96DC
			internal void #A9b()
			{
				foreach (ReinforcementBar reinforcementBar in this.#a.EditorContext.Selection.Bars.SelectedObjects)
				{
					reinforcementBar.Area = (float)this.#b.Value;
				}
				this.#a.#zCb();
				this.#a.#uCb();
			}

			// Token: 0x040013FA RID: 5114
			public SelectionPropertiesViewModel #a;

			// Token: 0x040013FB RID: 5115
			public double? #b;
		}
	}
}
