using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using #54d;
using #7hc;
using #8Cc;
using #ezc;
using #Fmc;
using #IDc;
using #N6c;
using #NWc;
using #T0c;
using #UYd;
using #v1c;
using #YXc;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor.Drawing;
using StructurePoint.CoreAssets.GUI.DesktopControls.Tree;
using StructurePoint.CoreAssets.GUI.Framework.Collections;
using StructurePoint.CoreAssets.GUI.Framework.Model.Entities;
using StructurePoint.CoreAssets.GUI.Framework.Tools.Grid;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Logger;

namespace StructurePoint.CoreAssets.GUI.Framework.ModelEditor
{
	// Token: 0x02000CA5 RID: 3237
	[SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses")]
	public sealed class ModelEditorViewModel : #CBc<#U0c>, INotifyPropertyChanged, #RBc<#U0c>, IViewModel, #V0c
	{
		// Token: 0x17001CFD RID: 7421
		// (get) Token: 0x060068F5 RID: 26869 RVA: 0x00053744 File Offset: 0x00051944
		// (set) Token: 0x060068F6 RID: 26870 RVA: 0x0005374C File Offset: 0x0005194C
		private protected #S0c DrawingResultsManager { protected get; private set; }

		// Token: 0x17001CFE RID: 7422
		// (get) Token: 0x060068F7 RID: 26871 RVA: 0x00053755 File Offset: 0x00051955
		// (set) Token: 0x060068F8 RID: 26872 RVA: 0x0005375D File Offset: 0x0005195D
		private protected #6Gc SettingsManager { protected get; private set; }

		// Token: 0x17001CFF RID: 7423
		// (get) Token: 0x060068F9 RID: 26873 RVA: 0x00053766 File Offset: 0x00051966
		// (set) Token: 0x060068FA RID: 26874 RVA: 0x0005376E File Offset: 0x0005196E
		private protected #bDc UndoManager { protected get; private set; }

		// Token: 0x17001D00 RID: 7424
		// (get) Token: 0x060068FB RID: 26875 RVA: 0x00053777 File Offset: 0x00051977
		// (set) Token: 0x060068FC RID: 26876 RVA: 0x0005377F File Offset: 0x0005197F
		private protected IDrawingResultsFactory DrawingResultsFactory { protected get; private set; }

		// Token: 0x17001D01 RID: 7425
		// (get) Token: 0x060068FD RID: 26877 RVA: 0x00053788 File Offset: 0x00051988
		// (set) Token: 0x060068FE RID: 26878 RVA: 0x00053790 File Offset: 0x00051990
		private protected IPolygonsDrawingEngine DrawingEngine { protected get; private set; }

		// Token: 0x17001D02 RID: 7426
		// (get) Token: 0x060068FF RID: 26879 RVA: 0x00053799 File Offset: 0x00051999
		// (set) Token: 0x06006900 RID: 26880 RVA: 0x000537A1 File Offset: 0x000519A1
		private protected #1Wc AssignmentsFactory { protected get; private set; }

		// Token: 0x17001D03 RID: 7427
		// (get) Token: 0x06006901 RID: 26881 RVA: 0x000537AA File Offset: 0x000519AA
		// (set) Token: 0x06006902 RID: 26882 RVA: 0x000537B2 File Offset: 0x000519B2
		private protected VisibilityLayer GridVisibilityLayer { protected get; private set; }

		// Token: 0x17001D04 RID: 7428
		// (get) Token: 0x06006903 RID: 26883 RVA: 0x000537BB File Offset: 0x000519BB
		// (set) Token: 0x06006904 RID: 26884 RVA: 0x000537C3 File Offset: 0x000519C3
		private protected VisibilityLayer ShapesVisibilityLayer { protected get; private set; }

		// Token: 0x17001D05 RID: 7429
		// (get) Token: 0x06006905 RID: 26885 RVA: 0x000537CC File Offset: 0x000519CC
		// (set) Token: 0x06006906 RID: 26886 RVA: 0x000537D4 File Offset: 0x000519D4
		private protected VisibilityLayer AdditionalFiguresVisibilityLayer { protected get; private set; }

		// Token: 0x17001D06 RID: 7430
		// (get) Token: 0x06006907 RID: 26887 RVA: 0x000537DD File Offset: 0x000519DD
		// (set) Token: 0x06006908 RID: 26888 RVA: 0x000537E5 File Offset: 0x000519E5
		private protected VisibilityLayer NodesVisibilityLayer { protected get; private set; }

		// Token: 0x17001D07 RID: 7431
		// (get) Token: 0x06006909 RID: 26889 RVA: 0x000537EE File Offset: 0x000519EE
		// (set) Token: 0x0600690A RID: 26890 RVA: 0x000537F6 File Offset: 0x000519F6
		private protected VisibilityLayer LinearObjectsVisibilityLayer { protected get; private set; }

		// Token: 0x17001D08 RID: 7432
		// (get) Token: 0x0600690B RID: 26891 RVA: 0x000537FF File Offset: 0x000519FF
		// (set) Token: 0x0600690C RID: 26892 RVA: 0x00053807 File Offset: 0x00051A07
		private protected VisibilityLayer GridLineAnnotationsVisibilityLayer { protected get; private set; }

		// Token: 0x17001D09 RID: 7433
		// (get) Token: 0x0600690D RID: 26893 RVA: 0x00053810 File Offset: 0x00051A10
		// (set) Token: 0x0600690E RID: 26894 RVA: 0x00053818 File Offset: 0x00051A18
		private protected VisibilityLayer OrthogonalFencesVisibilityLayer { protected get; private set; }

		// Token: 0x14000197 RID: 407
		// (add) Token: 0x0600690F RID: 26895 RVA: 0x00198234 File Offset: 0x00196434
		// (remove) Token: 0x06006910 RID: 26896 RVA: 0x0019828C File Offset: 0x0019648C
		public event EventHandler LayerVisibilityChanged
		{
			[CompilerGenerated]
			add
			{
				if (!false)
				{
					EventHandler eventHandler2;
					if (!false)
					{
						EventHandler eventHandler = this.#U;
						if (!false)
						{
							eventHandler2 = eventHandler;
						}
					}
					EventHandler eventHandler4;
					do
					{
						if (7 != 0)
						{
							EventHandler eventHandler3 = eventHandler2;
							if (3 != 0)
							{
								eventHandler4 = eventHandler3;
							}
							EventHandler eventHandler5 = (EventHandler)Delegate.Combine(eventHandler4, value);
							EventHandler value2;
							if (-1 != 0)
							{
								value2 = eventHandler5;
							}
							EventHandler eventHandler6 = Interlocked.CompareExchange<EventHandler>(ref this.#U, value2, eventHandler4);
							if (6 != 0)
							{
								eventHandler2 = eventHandler6;
							}
						}
					}
					while (eventHandler2 != eventHandler4);
				}
			}
			[CompilerGenerated]
			remove
			{
				if (!false)
				{
					EventHandler eventHandler2;
					if (!false)
					{
						EventHandler eventHandler = this.#U;
						if (!false)
						{
							eventHandler2 = eventHandler;
						}
					}
					EventHandler eventHandler4;
					do
					{
						if (7 != 0)
						{
							EventHandler eventHandler3 = eventHandler2;
							if (3 != 0)
							{
								eventHandler4 = eventHandler3;
							}
							EventHandler eventHandler5 = (EventHandler)Delegate.Remove(eventHandler4, value);
							EventHandler value2;
							if (-1 != 0)
							{
								value2 = eventHandler5;
							}
							EventHandler eventHandler6 = Interlocked.CompareExchange<EventHandler>(ref this.#U, value2, eventHandler4);
							if (6 != 0)
							{
								eventHandler2 = eventHandler6;
							}
						}
					}
					while (eventHandler2 != eventHandler4);
				}
			}
		}

		// Token: 0x06006911 RID: 26897 RVA: 0x001982E4 File Offset: 0x001964E4
		[SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling")]
		public ModelEditorViewModel(#GBc dependencyResolver, #U0c modelEditorView, ILogger logger, #6Gc settingsManager) : base(dependencyResolver, modelEditorView, logger)
		{
			#X0d.#V0d(settingsManager, #Phc.#3hc(107381742), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUIFramework, #Phc.#3hc(107435617));
			#X0d.#V0d(modelEditorView, #Phc.#3hc(107441992), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUIFramework, #Phc.#3hc(107435564));
			this.SettingsManager = settingsManager;
			this.DrawingResultsFactory = base.DependencyResolver.#vy<IDrawingResultsFactory>();
			this.DrawingEngine = base.DependencyResolver.#vy<IPolygonsDrawingEngine>();
			this.UndoManager = base.DependencyResolver.#vy<#bDc>();
			this.AssignmentsFactory = base.DependencyResolver.#vy<#1Wc>();
			this.#a = base.DependencyResolver.#vy<#R2c>();
			this.DrawingResultsManager = base.DependencyResolver.#vy<#S0c>();
			this.ViewControlsPanelVisibility = (this.SettingsManager.ViewControlsPanelVisible ? Visibility.Visible : Visibility.Collapsed);
			this.ViewControlsPanelPosition = this.SettingsManager.ViewControlsPanelPosition;
			this.ViewControlsPanelCollapsed = this.SettingsManager.ViewControlsPanelCollapsed;
			this.VisibilityToolBarVisibility = Visibility.Visible;
			this.VisibilityToolBarCheckBoxes = new ObservableCollection<ICheckBoxData>();
			this.ViewControlsPanelAdditionalTools = new ObservableCollection<object>();
			this.#w0c(modelEditorView.ModelVisualizationControl);
			this.#k = this.DrawingResultsFactory.CreatePointsDrawingResult();
			this.#l = this.DrawingResultsFactory.CreatePointsDrawingResult();
			this.#b = this.DrawingResultsFactory.CreateMultilineDrawingResult();
			this.#c = this.DrawingResultsFactory.CreateMultilineDrawingResult();
			this.#n = this.DrawingResultsFactory.CreateMultilineDrawingResult();
			this.#o = this.DrawingResultsFactory.CreatePointsDrawingResult();
			this.#p = this.DrawingResultsFactory.CreateDashedMultilineDrawingResult();
			this.#q = this.DrawingResultsFactory.CreateMultilineDrawingResult();
			this.#r = new HashSet<LinearObject>();
			this.#f = new HashSet<GridLineDefinitionModel>();
			this.#e = this.DrawingResultsFactory.CreateMultilineDrawingResult();
			this.#m = new HashSet<StructurePoint.CoreAssets.Infrastructure.Data.Point>();
			this.#s = new HashSet<IAnnotationDrawingResult>();
			this.#t = this.DrawingResultsFactory.CreateMultilineDrawingResult();
			this.#u = this.DrawingResultsFactory.CreateMultilineDrawingResult();
			this.#w = this.DrawingResultsFactory.CreateMultilineDrawingResult();
			this.#v = new HashSet<IAnnotationDrawingResult>();
			this.#y = AnnotationsHelper.#TJc(base.View.ModelVisualizationControl.EditorWorkspaceSize.Width, base.View.ModelVisualizationControl.EditorWorkspaceSize.Height);
			modelEditorView.SetViewModel(this);
			modelEditorView.ModelVisualizationControl.EditorWorkspaceBackgroundColor = settingsManager.VisualizationEditorWorkspaceBackgroundColor;
			modelEditorView.ModelVisualizationControl.ScreenBackgroundColor = settingsManager.VisualizationEditorBackgroundColor;
			modelEditorView.ModelVisualizationControl.TransparencySorter.ConfigureTransparencySorting(10.0, CustomSortingModeType.ByModelZValue);
			base.View.ModelVisualizationControl.EditorMouseRightButtonDown += this.#CZc;
			base.View.EditorContextMenuOpening += this.#BZc;
			base.View.ModelVisualizationControl.CameraDistanceChanged += this.#q0c;
			base.View.ModelVisualizationControl.SuspendEventsChanged += this.#r0c;
		}

		// Token: 0x17001D0A RID: 7434
		// (get) Token: 0x06006912 RID: 26898 RVA: 0x00053821 File Offset: 0x00051A21
		// (set) Token: 0x06006913 RID: 26899 RVA: 0x00198634 File Offset: 0x00196834
		public bool SuspendEvents
		{
			get
			{
				return this.#G;
			}
			private set
			{
				for (;;)
				{
					if (this.#G == value)
					{
						goto IL_36;
					}
					string propertyName = #Phc.#3hc(107361511);
					if (5 != 0)
					{
						base.RaisePropertyChanging(propertyName);
					}
					IL_19:
					if (3 != 0)
					{
						if (false)
						{
							continue;
						}
						this.#G = value;
						string propertyName2 = #Phc.#3hc(107361511);
						if (!false)
						{
							base.RaisePropertyChanged(propertyName2);
						}
					}
					IL_36:
					if (true)
					{
						break;
					}
					goto IL_19;
				}
			}
		}

		// Token: 0x17001D0B RID: 7435
		// (get) Token: 0x06006914 RID: 26900 RVA: 0x00053829 File Offset: 0x00051A29
		// (set) Token: 0x06006915 RID: 26901 RVA: 0x00053831 File Offset: 0x00051A31
		public ObservableCollection<ICheckBoxData> VisibilityToolBarCheckBoxes { get; private set; }

		// Token: 0x17001D0C RID: 7436
		// (get) Token: 0x06006916 RID: 26902 RVA: 0x0005383A File Offset: 0x00051A3A
		// (set) Token: 0x06006917 RID: 26903 RVA: 0x00053842 File Offset: 0x00051A42
		public Visibility VisibilityToolBarVisibility { get; set; }

		// Token: 0x17001D0D RID: 7437
		// (get) Token: 0x06006918 RID: 26904 RVA: 0x0005384B File Offset: 0x00051A4B
		// (set) Token: 0x06006919 RID: 26905 RVA: 0x00198688 File Offset: 0x00196888
		public bool AreShapesVisible
		{
			get
			{
				return this.ShapesVisibilityLayer.IsVisible;
			}
			set
			{
				if (!false && (false || this.ShapesVisibilityLayer.IsVisible != value))
				{
					string propertyName = #Phc.#3hc(107435543);
					if (!false)
					{
						base.RaisePropertyChanging(propertyName);
					}
					VisibilityLayer visibilityLayer = this.ShapesVisibilityLayer;
					if (3 != 0)
					{
						visibilityLayer.IsVisible = value;
					}
					if (2 != 0 && -1 != 0)
					{
						this.#DZc();
					}
					string propertyName2 = #Phc.#3hc(107435543);
					if (6 != 0)
					{
						base.RaisePropertyChanged(propertyName2);
					}
				}
			}
		}

		// Token: 0x17001D0E RID: 7438
		// (get) Token: 0x0600691A RID: 26906 RVA: 0x00053858 File Offset: 0x00051A58
		// (set) Token: 0x0600691B RID: 26907 RVA: 0x001986FC File Offset: 0x001968FC
		public bool AreAdditionalFiguresVisible
		{
			get
			{
				return this.AdditionalFiguresVisibilityLayer.IsVisible;
			}
			set
			{
				if (!false && (false || this.AdditionalFiguresVisibilityLayer.IsVisible != value))
				{
					string propertyName = #Phc.#3hc(107436030);
					if (!false)
					{
						base.RaisePropertyChanging(propertyName);
					}
					VisibilityLayer visibilityLayer = this.AdditionalFiguresVisibilityLayer;
					if (3 != 0)
					{
						visibilityLayer.IsVisible = value;
					}
					if (2 != 0 && -1 != 0)
					{
						this.#DZc();
					}
					string propertyName2 = #Phc.#3hc(107436030);
					if (6 != 0)
					{
						base.RaisePropertyChanged(propertyName2);
					}
				}
			}
		}

		// Token: 0x17001D0F RID: 7439
		// (get) Token: 0x0600691C RID: 26908 RVA: 0x00053865 File Offset: 0x00051A65
		// (set) Token: 0x0600691D RID: 26909 RVA: 0x00198770 File Offset: 0x00196970
		public bool AreGridLinesVisible
		{
			get
			{
				return this.GridVisibilityLayer.IsVisible;
			}
			set
			{
				if (!false && (false || this.GridVisibilityLayer.IsVisible != value))
				{
					string propertyName = #Phc.#3hc(107435993);
					if (!false)
					{
						base.RaisePropertyChanging(propertyName);
					}
					VisibilityLayer visibilityLayer = this.GridVisibilityLayer;
					if (3 != 0)
					{
						visibilityLayer.IsVisible = value;
					}
					if (2 != 0 && -1 != 0)
					{
						this.#DZc();
					}
					string propertyName2 = #Phc.#3hc(107435993);
					if (6 != 0)
					{
						base.RaisePropertyChanged(propertyName2);
					}
				}
			}
		}

		// Token: 0x17001D10 RID: 7440
		// (get) Token: 0x0600691E RID: 26910 RVA: 0x00053872 File Offset: 0x00051A72
		// (set) Token: 0x0600691F RID: 26911 RVA: 0x001987E4 File Offset: 0x001969E4
		public bool AreLinearObjectsVisible
		{
			get
			{
				return this.LinearObjectsVisibilityLayer.IsVisible;
			}
			set
			{
				if (!false && (false || this.LinearObjectsVisibilityLayer.IsVisible != value))
				{
					string propertyName = #Phc.#3hc(107435964);
					if (!false)
					{
						base.RaisePropertyChanging(propertyName);
					}
					VisibilityLayer visibilityLayer = this.LinearObjectsVisibilityLayer;
					if (3 != 0)
					{
						visibilityLayer.IsVisible = value;
					}
					if (2 != 0 && -1 != 0)
					{
						this.#DZc();
					}
					string propertyName2 = #Phc.#3hc(107435964);
					if (6 != 0)
					{
						base.RaisePropertyChanged(propertyName2);
					}
				}
			}
		}

		// Token: 0x17001D11 RID: 7441
		// (get) Token: 0x06006920 RID: 26912 RVA: 0x0005387F File Offset: 0x00051A7F
		// (set) Token: 0x06006921 RID: 26913 RVA: 0x00198858 File Offset: 0x00196A58
		public bool AreNodesVisible
		{
			get
			{
				return this.NodesVisibilityLayer.IsVisible;
			}
			set
			{
				if (!false && (false || this.NodesVisibilityLayer.IsVisible != value))
				{
					string propertyName = #Phc.#3hc(107435931);
					if (!false)
					{
						base.RaisePropertyChanging(propertyName);
					}
					VisibilityLayer visibilityLayer = this.NodesVisibilityLayer;
					if (3 != 0)
					{
						visibilityLayer.IsVisible = value;
					}
					if (2 != 0 && -1 != 0)
					{
						this.#DZc();
					}
					string propertyName2 = #Phc.#3hc(107435931);
					if (6 != 0)
					{
						base.RaisePropertyChanged(propertyName2);
					}
				}
			}
		}

		// Token: 0x17001D12 RID: 7442
		// (get) Token: 0x06006922 RID: 26914 RVA: 0x0005388C File Offset: 0x00051A8C
		// (set) Token: 0x06006923 RID: 26915 RVA: 0x001988CC File Offset: 0x00196ACC
		public bool AreGridLineAnnotationsVisible
		{
			get
			{
				return this.GridLineAnnotationsVisibilityLayer.IsVisible;
			}
			set
			{
				if (!false && (false || this.GridLineAnnotationsVisibilityLayer.IsVisible != value))
				{
					string propertyName = #Phc.#3hc(107435878);
					if (!false)
					{
						base.RaisePropertyChanging(propertyName);
					}
					VisibilityLayer visibilityLayer = this.GridLineAnnotationsVisibilityLayer;
					if (3 != 0)
					{
						visibilityLayer.IsVisible = value;
					}
					if (2 != 0 && -1 != 0)
					{
						this.#DZc();
					}
					string propertyName2 = #Phc.#3hc(107435878);
					if (6 != 0)
					{
						base.RaisePropertyChanged(propertyName2);
					}
				}
			}
		}

		// Token: 0x17001D13 RID: 7443
		// (get) Token: 0x06006924 RID: 26916 RVA: 0x00053899 File Offset: 0x00051A99
		// (set) Token: 0x06006925 RID: 26917 RVA: 0x00198940 File Offset: 0x00196B40
		public bool AreOrthogonalFencesVisible
		{
			get
			{
				return this.OrthogonalFencesVisibilityLayer.IsVisible;
			}
			set
			{
				if (!false && (false || this.OrthogonalFencesVisibilityLayer.IsVisible != value))
				{
					string propertyName = #Phc.#3hc(107435869);
					if (!false)
					{
						base.RaisePropertyChanging(propertyName);
					}
					VisibilityLayer visibilityLayer = this.OrthogonalFencesVisibilityLayer;
					if (3 != 0)
					{
						visibilityLayer.IsVisible = value;
					}
					if (2 != 0 && -1 != 0)
					{
						this.#DZc();
					}
					string propertyName2 = #Phc.#3hc(107435869);
					if (6 != 0)
					{
						base.RaisePropertyChanged(propertyName2);
					}
				}
			}
		}

		// Token: 0x17001D14 RID: 7444
		// (get) Token: 0x06006926 RID: 26918 RVA: 0x000538A6 File Offset: 0x00051AA6
		public double AnnotationsRadius
		{
			get
			{
				return this.#y;
			}
		}

		// Token: 0x17001D15 RID: 7445
		// (get) Token: 0x06006927 RID: 26919 RVA: 0x000538AE File Offset: 0x00051AAE
		// (set) Token: 0x06006928 RID: 26920 RVA: 0x000538B6 File Offset: 0x00051AB6
		public ObservableCollection<object> ViewControlsPanelAdditionalTools { get; private set; }

		// Token: 0x17001D16 RID: 7446
		// (get) Token: 0x06006929 RID: 26921 RVA: 0x000538BF File Offset: 0x00051ABF
		// (set) Token: 0x0600692A RID: 26922 RVA: 0x001989B4 File Offset: 0x00196BB4
		public Visibility ViewControlsPanelVisibility
		{
			get
			{
				return this.#z;
			}
			set
			{
				if (this.#z != value)
				{
					string propertyName = #Phc.#3hc(107361522);
					if (2 != 0)
					{
						base.RaisePropertyChanging(propertyName);
					}
					this.#z = value;
					if (!false)
					{
						this.#EZc();
					}
					string propertyName2 = #Phc.#3hc(107361522);
					if (8 != 0)
					{
						base.RaisePropertyChanged(propertyName2);
					}
				}
			}
		}

		// Token: 0x17001D17 RID: 7447
		// (get) Token: 0x0600692B RID: 26923 RVA: 0x000538C7 File Offset: 0x00051AC7
		// (set) Token: 0x0600692C RID: 26924 RVA: 0x00198A0C File Offset: 0x00196C0C
		public ToolsPanelPosition ViewControlsPanelPosition
		{
			get
			{
				return this.#A;
			}
			set
			{
				if (this.#A != value)
				{
					string propertyName = #Phc.#3hc(107402933);
					if (-1 != 0)
					{
						base.RaisePropertyChanging(propertyName);
					}
					this.#A = value;
					#6Gc #6Gc = this.SettingsManager;
					if (!false)
					{
						#6Gc.ViewControlsPanelPosition = value;
					}
					string propertyName2 = #Phc.#3hc(107402933);
					if (5 != 0)
					{
						base.RaisePropertyChanged(propertyName2);
					}
				}
			}
		}

		// Token: 0x17001D18 RID: 7448
		// (get) Token: 0x0600692D RID: 26925 RVA: 0x000538CF File Offset: 0x00051ACF
		// (set) Token: 0x0600692E RID: 26926 RVA: 0x00198A6C File Offset: 0x00196C6C
		public bool ViewControlsPanelCollapsed
		{
			get
			{
				return this.#B;
			}
			set
			{
				if (this.#B != value)
				{
					string propertyName = #Phc.#3hc(107470925);
					if (-1 != 0)
					{
						base.RaisePropertyChanging(propertyName);
					}
					this.#B = value;
					#6Gc #6Gc = this.SettingsManager;
					if (!false)
					{
						#6Gc.ViewControlsPanelCollapsed = value;
					}
					string propertyName2 = #Phc.#3hc(107470925);
					if (5 != 0)
					{
						base.RaisePropertyChanged(propertyName2);
					}
				}
			}
		}

		// Token: 0x17001D19 RID: 7449
		// (get) Token: 0x0600692F RID: 26927 RVA: 0x000538D7 File Offset: 0x00051AD7
		// (set) Token: 0x06006930 RID: 26928 RVA: 0x000538DF File Offset: 0x00051ADF
		private protected VisibilityLayer NodeNumbersVisibilityLayer { protected get; private set; }

		// Token: 0x17001D1A RID: 7450
		// (get) Token: 0x06006931 RID: 26929 RVA: 0x000538E8 File Offset: 0x00051AE8
		// (set) Token: 0x06006932 RID: 26930 RVA: 0x000538F0 File Offset: 0x00051AF0
		private protected VisibilityLayer ElementNumbersVisibilityLayer { protected get; private set; }

		// Token: 0x17001D1B RID: 7451
		// (get) Token: 0x06006933 RID: 26931 RVA: 0x000538F9 File Offset: 0x00051AF9
		// (set) Token: 0x06006934 RID: 26932 RVA: 0x00198ACC File Offset: 0x00196CCC
		public double ContextMenuHorizontalOffset
		{
			get
			{
				return this.#C;
			}
			set
			{
				for (;;)
				{
					if (this.#C == value)
					{
						goto IL_36;
					}
					string propertyName = #Phc.#3hc(107435832);
					if (5 != 0)
					{
						base.RaisePropertyChanging(propertyName);
					}
					IL_19:
					if (3 != 0)
					{
						if (false)
						{
							continue;
						}
						this.#C = value;
						string propertyName2 = #Phc.#3hc(107435832);
						if (!false)
						{
							base.RaisePropertyChanged(propertyName2);
						}
					}
					IL_36:
					if (true)
					{
						break;
					}
					goto IL_19;
				}
			}
		}

		// Token: 0x17001D1C RID: 7452
		// (get) Token: 0x06006935 RID: 26933 RVA: 0x00053901 File Offset: 0x00051B01
		// (set) Token: 0x06006936 RID: 26934 RVA: 0x00198B20 File Offset: 0x00196D20
		public double ContextMenuVerticalOffset
		{
			get
			{
				return this.#D;
			}
			set
			{
				for (;;)
				{
					if (this.#D == value)
					{
						goto IL_36;
					}
					string propertyName = #Phc.#3hc(107435795);
					if (5 != 0)
					{
						base.RaisePropertyChanging(propertyName);
					}
					IL_19:
					if (3 != 0)
					{
						if (false)
						{
							continue;
						}
						this.#D = value;
						string propertyName2 = #Phc.#3hc(107435795);
						if (!false)
						{
							base.RaisePropertyChanged(propertyName2);
						}
					}
					IL_36:
					if (true)
					{
						break;
					}
					goto IL_19;
				}
			}
		}

		// Token: 0x17001D1D RID: 7453
		// (get) Token: 0x06006937 RID: 26935 RVA: 0x00053909 File Offset: 0x00051B09
		// (set) Token: 0x06006938 RID: 26936 RVA: 0x00198B74 File Offset: 0x00196D74
		public bool IsContextMenuOpen
		{
			get
			{
				return this.#F;
			}
			set
			{
				for (;;)
				{
					if (this.#F == value)
					{
						goto IL_36;
					}
					string propertyName = #Phc.#3hc(107435214);
					if (5 != 0)
					{
						base.RaisePropertyChanging(propertyName);
					}
					IL_19:
					if (3 != 0)
					{
						if (false)
						{
							continue;
						}
						this.#F = value;
						string propertyName2 = #Phc.#3hc(107435214);
						if (!false)
						{
							base.RaisePropertyChanged(propertyName2);
						}
					}
					IL_36:
					if (true)
					{
						break;
					}
					goto IL_19;
				}
			}
		}

		// Token: 0x17001D1E RID: 7454
		// (get) Token: 0x06006939 RID: 26937 RVA: 0x00053911 File Offset: 0x00051B11
		// (set) Token: 0x0600693A RID: 26938 RVA: 0x00053919 File Offset: 0x00051B19
		public #k8c<ITreeItemData> CurrentContextMenuItems
		{
			get
			{
				return this.#x;
			}
			private set
			{
				for (;;)
				{
					if (this.#x == value)
					{
						goto IL_23;
					}
					IL_09:
					this.#x = value;
					if (false)
					{
						continue;
					}
					string propertyName = #Phc.#3hc(107435221);
					if (!false)
					{
						base.RaisePropertyChanged(propertyName);
					}
					IL_23:
					if (!false)
					{
						break;
					}
					goto IL_09;
				}
			}
		}

		// Token: 0x14000198 RID: 408
		// (add) Token: 0x0600693B RID: 26939 RVA: 0x00198BC8 File Offset: 0x00196DC8
		// (remove) Token: 0x0600693C RID: 26940 RVA: 0x00198C20 File Offset: 0x00196E20
		public event EventHandler<#XXc> OpeningContextMenu
		{
			[CompilerGenerated]
			add
			{
				if (!false)
				{
					EventHandler<#XXc> eventHandler2;
					if (!false)
					{
						EventHandler<#XXc> eventHandler = this.#0;
						if (!false)
						{
							eventHandler2 = eventHandler;
						}
					}
					EventHandler<#XXc> eventHandler4;
					do
					{
						if (7 != 0)
						{
							EventHandler<#XXc> eventHandler3 = eventHandler2;
							if (3 != 0)
							{
								eventHandler4 = eventHandler3;
							}
							EventHandler<#XXc> eventHandler5 = (EventHandler<#XXc>)Delegate.Combine(eventHandler4, value);
							EventHandler<#XXc> value2;
							if (-1 != 0)
							{
								value2 = eventHandler5;
							}
							EventHandler<#XXc> eventHandler6 = Interlocked.CompareExchange<EventHandler<#XXc>>(ref this.#0, value2, eventHandler4);
							if (6 != 0)
							{
								eventHandler2 = eventHandler6;
							}
						}
					}
					while (eventHandler2 != eventHandler4);
				}
			}
			[CompilerGenerated]
			remove
			{
				if (!false)
				{
					EventHandler<#XXc> eventHandler2;
					if (!false)
					{
						EventHandler<#XXc> eventHandler = this.#0;
						if (!false)
						{
							eventHandler2 = eventHandler;
						}
					}
					EventHandler<#XXc> eventHandler4;
					do
					{
						if (7 != 0)
						{
							EventHandler<#XXc> eventHandler3 = eventHandler2;
							if (3 != 0)
							{
								eventHandler4 = eventHandler3;
							}
							EventHandler<#XXc> eventHandler5 = (EventHandler<#XXc>)Delegate.Remove(eventHandler4, value);
							EventHandler<#XXc> value2;
							if (-1 != 0)
							{
								value2 = eventHandler5;
							}
							EventHandler<#XXc> eventHandler6 = Interlocked.CompareExchange<EventHandler<#XXc>>(ref this.#0, value2, eventHandler4);
							if (6 != 0)
							{
								eventHandler2 = eventHandler6;
							}
						}
					}
					while (eventHandler2 != eventHandler4);
				}
			}
		}

		// Token: 0x0600693D RID: 26941 RVA: 0x00198C78 File Offset: 0x00196E78
		protected void #AZc(#XXc #He)
		{
			EventHandler<#XXc> eventHandler = this.#0;
			EventHandler<#XXc> eventHandler2;
			if (!false)
			{
				eventHandler2 = eventHandler;
			}
			if (eventHandler2 != null)
			{
				EventHandler<#XXc> eventHandler3 = eventHandler2;
				if (!false)
				{
					eventHandler3(this, #He);
				}
			}
		}

		// Token: 0x0600693E RID: 26942 RVA: 0x00053948 File Offset: 0x00051B48
		private void #BZc(object #Ge, RoutedEventArgs #He)
		{
			bool handled = this.#E;
			if (2 != 0)
			{
				#He.Handled = handled;
			}
		}

		// Token: 0x0600693F RID: 26943 RVA: 0x00198CA8 File Offset: 0x00196EA8
		[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
		private void #CZc(object #Ge, MouseButtonEventArgs #He)
		{
			ModelEditorViewModel.#Kbd #Kbd = new ModelEditorViewModel.#Kbd();
			ModelEditorViewModel.#Kbd #Kbd2;
			if (-1 != 0)
			{
				#Kbd2 = #Kbd;
			}
			#Kbd2.#a = this;
			if (this.#a.#C2c() && 6 != 0)
			{
				return;
			}
			#Kbd2.#b = base.View.ModelVisualizationControl.GetEditorPosition(#He);
			Point3D #HAb;
			if (!base.View.ModelVisualizationControl.GetMousePositionOnXYPlane(#Kbd2.#b, out #HAb))
			{
				return;
			}
			for (;;)
			{
				#XXc #XXc = new #XXc(PointsConverter.#vsc(#HAb));
				#XXc #XXc2;
				if (!false)
				{
					#XXc2 = #XXc;
				}
				#XXc #He2 = #XXc2;
				if (!false)
				{
					this.#AZc(#He2);
				}
				if (#XXc2.Cancel || #XXc2.ItemsSource == null || !#XXc2.ItemsSource.Any<ITreeItemData>())
				{
					break;
				}
				if (7 != 0)
				{
					goto Block_6;
				}
			}
			return;
			Block_6:
			this.#E = false;
			try
			{
				double num = #Kbd2.#b.X;
				if (true)
				{
					this.ContextMenuHorizontalOffset = num;
				}
				double num2 = #Kbd2.#b.Y;
				if (7 != 0)
				{
					this.ContextMenuVerticalOffset = num2;
				}
				for (;;)
				{
					#XXc #XXc2;
					#k8c<ITreeItemData> #k8c = #XXc2.ItemsSource;
					if (5 != 0)
					{
						this.CurrentContextMenuItems = #k8c;
					}
					Action method = new Action(#Kbd2.#Jbd);
					if (!false)
					{
						Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Background, method);
						#He.Handled = true;
						if (8 != 0)
						{
							break;
						}
					}
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06006940 RID: 26944 RVA: 0x00198DE4 File Offset: 0x00196FE4
		protected void #DZc()
		{
			EventHandler eventHandler = this.#U;
			EventHandler eventHandler2;
			if (!false)
			{
				eventHandler2 = eventHandler;
			}
			if (eventHandler2 != null)
			{
				EventHandler eventHandler3 = eventHandler2;
				EventArgs empty = EventArgs.Empty;
				if (!false)
				{
					eventHandler3(this, empty);
				}
			}
		}

		// Token: 0x06006941 RID: 26945 RVA: 0x0005395D File Offset: 0x00051B5D
		protected void #EZc()
		{
			#6Gc #6Gc = this.SettingsManager;
			bool flag = this.#z == Visibility.Visible;
			if (!false)
			{
				#6Gc.ViewControlsPanelVisible = flag;
			}
		}

		// Token: 0x06006942 RID: 26946 RVA: 0x0005397A File Offset: 0x00051B7A
		public void #FZc(IEnumerable<GridLineDefinitionModel> #ooc, bool #GZc)
		{
			bool #HZc = false;
			if (!false)
			{
				this.#FZc(#ooc, #GZc, #HZc);
			}
		}

		// Token: 0x06006943 RID: 26947 RVA: 0x00198E18 File Offset: 0x00197018
		public void #FZc(IEnumerable<GridLineDefinitionModel> #ooc, bool #GZc, bool #HZc)
		{
			string #R0d = #Phc.#3hc(107368337);
			StructurePoint.CoreAssets.Infrastructure.Exceptions.Component #x6c = StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUIFramework;
			string #Qic = #Phc.#3hc(107435188);
			if (true)
			{
				#X0d.#V0d(#ooc, #R0d, #x6c, #Qic);
			}
			IBulkUpdateScope bulkUpdateScope = base.View.ModelVisualizationControl.TransparencySorter.BeginBulkUpdate();
			IBulkUpdateScope bulkUpdateScope2;
			if (!false)
			{
				bulkUpdateScope2 = bulkUpdateScope;
			}
			try
			{
				bool flag = #44d.#c;
				List<GridLineDefinitionModel> list = #ooc.ToList<GridLineDefinitionModel>();
				List<GridLineDefinitionModel> list2;
				if (4 != 0)
				{
					list2 = list;
				}
				if (!this.#C0c(list2))
				{
					if (!false)
					{
						this.#D0c();
					}
				}
				else
				{
					bool flag2 = #44d.#c;
					List<int> list3 = this.#d;
					if (true)
					{
						list3.Clear();
					}
					List<int> list4 = this.#d;
					IEnumerable<int> collection = list2.Select(new Func<GridLineDefinitionModel, int>(ModelEditorViewModel.<>c.<>9.#Lbd));
					if (2 != 0)
					{
						list4.AddRange(collection);
					}
					this.#B0c(true);
					if (#HZc)
					{
						this.DrawingResultsManager.#ZXc(this.GridVisibilityLayer, this.#c, this.#b, list2);
					}
					else
					{
						this.DrawingResultsManager.#ZXc(this.GridVisibilityLayer, this.#b, list2);
					}
					this.#m0c(list2, false, #GZc);
					bool flag3 = #44d.#c;
				}
			}
			finally
			{
				if (bulkUpdateScope2 != null)
				{
					bulkUpdateScope2.Dispose();
				}
			}
		}

		// Token: 0x06006944 RID: 26948 RVA: 0x00198F6C File Offset: 0x0019716C
		public void #IZc(GridLineDefinitionModel #bsc)
		{
			string #R0d = #Phc.#3hc(107364483);
			StructurePoint.CoreAssets.Infrastructure.Exceptions.Component #x6c = StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUIFramework;
			string #Qic = #Phc.#3hc(107435135);
			if (true)
			{
				#X0d.#V0d(#bsc, #R0d, #x6c, #Qic);
			}
			if (this.#f.Add(#bsc))
			{
				IBulkUpdateScope bulkUpdateScope = base.View.ModelVisualizationControl.TransparencySorter.BeginBulkUpdate();
				IBulkUpdateScope bulkUpdateScope2;
				if (8 != 0)
				{
					bulkUpdateScope2 = bulkUpdateScope;
				}
				try
				{
					if (2 != 0)
					{
						this.#v0c();
					}
				}
				finally
				{
					if (bulkUpdateScope2 != null)
					{
						bulkUpdateScope2.Dispose();
					}
				}
			}
		}

		// Token: 0x06006945 RID: 26949 RVA: 0x00198FF0 File Offset: 0x001971F0
		public void #JZc(GridLineDefinitionModel #bsc)
		{
			string #R0d = #Phc.#3hc(107364483);
			StructurePoint.CoreAssets.Infrastructure.Exceptions.Component #x6c = StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUIFramework;
			string #Qic = #Phc.#3hc(107435050);
			if (true)
			{
				#X0d.#V0d(#bsc, #R0d, #x6c, #Qic);
			}
			if (this.#f.Remove(#bsc))
			{
				IBulkUpdateScope bulkUpdateScope = base.View.ModelVisualizationControl.TransparencySorter.BeginBulkUpdate();
				IBulkUpdateScope bulkUpdateScope2;
				if (8 != 0)
				{
					bulkUpdateScope2 = bulkUpdateScope;
				}
				try
				{
					if (2 != 0)
					{
						this.#v0c();
					}
				}
				finally
				{
					if (bulkUpdateScope2 != null)
					{
						bulkUpdateScope2.Dispose();
					}
				}
			}
		}

		// Token: 0x06006946 RID: 26950 RVA: 0x0005398E File Offset: 0x00051B8E
		public void #KZc(IEnumerable<GridLineDefinitionModel> #ooc)
		{
			#U0c #Ee = base.View;
			HashSet<GridLineDefinitionModel> #4Xc = this.#f;
			Action #J0c = new Action(this.#v0c);
			if (!false)
			{
				#Q0c.#KZc(#ooc, #Ee, #4Xc, #J0c);
			}
		}

		// Token: 0x06006947 RID: 26951 RVA: 0x000539B7 File Offset: 0x00051BB7
		public void #LZc(IEnumerable<GridLineDefinitionModel> #ooc)
		{
			HashSet<GridLineDefinitionModel> #4Xc = this.#f;
			Action #J0c = new Action(this.#v0c);
			if (!false)
			{
				#Q0c.#LZc(#ooc, #4Xc, #J0c);
			}
		}

		// Token: 0x06006948 RID: 26952 RVA: 0x000539D9 File Offset: 0x00051BD9
		public Point3D? #MZc(GridLineDefinitionModel #bsc)
		{
			return #Q0c.#MZc(#bsc, this.#s);
		}

		// Token: 0x06006949 RID: 26953 RVA: 0x00199074 File Offset: 0x00197274
		public void #NZc()
		{
			for (;;)
			{
				ILinesDrawingResultBase linesDrawingResultBase = this.#c;
				Color lineColor = this.SettingsManager.VisualizationDarkerGridLineColor;
				if (!false)
				{
					linesDrawingResultBase.LineColor = lineColor;
				}
				if (!false)
				{
					ILinesDrawingResultBase linesDrawingResultBase2 = this.#b;
					Color lineColor2 = this.SettingsManager.VisualizationGridLineColor;
					if (3 != 0)
					{
						linesDrawingResultBase2.LineColor = lineColor2;
					}
					ILinesDrawingResultBase linesDrawingResultBase3 = this.#u;
					Color lineColor3 = this.SettingsManager.VisualizationDarkerGridLineColor;
					if (false)
					{
						goto IL_45;
					}
					linesDrawingResultBase3.LineColor = lineColor3;
					goto IL_45;
				}
				IL_5B:
				if (false)
				{
					continue;
				}
				if (!false)
				{
					break;
				}
				IL_45:
				ILinesDrawingResultBase linesDrawingResultBase4 = this.#t;
				Color lineColor4 = this.SettingsManager.VisualizationGridLineColor;
				if (false)
				{
					goto IL_5B;
				}
				linesDrawingResultBase4.LineColor = lineColor4;
				goto IL_5B;
			}
		}

		// Token: 0x0600694A RID: 26954 RVA: 0x000539E7 File Offset: 0x00051BE7
		public bool #OZc(ShapeDataModel #XDc)
		{
			return #XDc != null && this.#g.ContainsKey(#XDc.GetHashCode());
		}

		// Token: 0x0600694B RID: 26955 RVA: 0x000539FF File Offset: 0x00051BFF
		public bool #PZc(ShapeDataModel #XDc)
		{
			return #XDc != null && this.#h.ContainsKey(#XDc.GetHashCode());
		}

		// Token: 0x0600694C RID: 26956 RVA: 0x00199100 File Offset: 0x00197300
		public void #QZc(ShapeDataModel #XDc, double #hYc, double #iYc, double #jYc, Color? #kYc, Color? #lYc)
		{
			string #R0d = #Phc.#3hc(107435029);
			StructurePoint.CoreAssets.Infrastructure.Exceptions.Component #x6c = StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUIFramework;
			string #Qic = #Phc.#3hc(107435488);
			if (2 != 0)
			{
				#X0d.#V0d(#XDc, #R0d, #x6c, #Qic);
			}
			IBulkUpdateScope bulkUpdateScope = base.View.ModelVisualizationControl.TransparencySorter.BeginBulkUpdate();
			IBulkUpdateScope bulkUpdateScope2;
			if (!false)
			{
				bulkUpdateScope2 = bulkUpdateScope;
			}
			try
			{
				Tuple<PolygonsDrawingData, IPolygonsDrawingResult> tuple = this.#E0c(#XDc, #hYc, #iYc, #jYc, #kYc, #lYc);
				Tuple<PolygonsDrawingData, IPolygonsDrawingResult> tuple2;
				if (6 != 0)
				{
					tuple2 = tuple;
				}
				this.DrawingEngine.DrawPolygons(tuple2.Item1, tuple2.Item2);
				VisibilityLayer visibilityLayer = this.ShapesVisibilityLayer;
				IPolygonsDrawingResult item = tuple2.Item2;
				if (2 != 0)
				{
					visibilityLayer.Add(item);
				}
			}
			finally
			{
				if (bulkUpdateScope2 != null)
				{
					bulkUpdateScope2.Dispose();
				}
			}
		}

		// Token: 0x0600694D RID: 26957 RVA: 0x001991B4 File Offset: 0x001973B4
		[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "z")]
		public void #RZc(ShapeDataModel #XDc, double #hYc, double #iYc, double #jYc, Color? #kYc, Color? #lYc)
		{
			string #R0d = #Phc.#3hc(107435029);
			StructurePoint.CoreAssets.Infrastructure.Exceptions.Component #x6c = StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUIFramework;
			string #Qic = #Phc.#3hc(107435435);
			if (2 != 0)
			{
				#X0d.#V0d(#XDc, #R0d, #x6c, #Qic);
			}
			IBulkUpdateScope bulkUpdateScope = base.View.ModelVisualizationControl.TransparencySorter.BeginBulkUpdate();
			IBulkUpdateScope bulkUpdateScope2;
			if (!false)
			{
				bulkUpdateScope2 = bulkUpdateScope;
			}
			try
			{
				Tuple<PolygonsDrawingData, IPolygonsDrawingResult> tuple = this.#E0c(#XDc, #hYc, #iYc, #jYc, #kYc, #lYc);
				Tuple<PolygonsDrawingData, IPolygonsDrawingResult> tuple2;
				if (6 != 0)
				{
					tuple2 = tuple;
				}
				this.DrawingEngine.DrawPolygons(tuple2.Item1, tuple2.Item2);
				VisibilityLayer visibilityLayer = this.ShapesVisibilityLayer;
				IPolygonsDrawingResult item = tuple2.Item2;
				if (2 != 0)
				{
					visibilityLayer.Add(item);
				}
			}
			finally
			{
				if (bulkUpdateScope2 != null)
				{
					bulkUpdateScope2.Dispose();
				}
			}
		}

		// Token: 0x0600694E RID: 26958 RVA: 0x00199268 File Offset: 0x00197468
		[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "z")]
		public void #RZc(ShapeDataModel #XDc, double #hYc, double #iYc, double #jYc, Color? #kYc, Color? #lYc, bool #SZc, bool #TZc)
		{
			if (3 != 0)
			{
				string #R0d = #Phc.#3hc(107435029);
				StructurePoint.CoreAssets.Infrastructure.Exceptions.Component #x6c = StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUIFramework;
				string #Qic = #Phc.#3hc(107435435);
				if (3 != 0)
				{
					#X0d.#V0d(#XDc, #R0d, #x6c, #Qic);
				}
				IBulkUpdateScope bulkUpdateScope = base.View.ModelVisualizationControl.TransparencySorter.BeginBulkUpdate();
				IBulkUpdateScope bulkUpdateScope2;
				if (7 != 0)
				{
					bulkUpdateScope2 = bulkUpdateScope;
				}
				try
				{
					Tuple<PolygonsDrawingData, IPolygonsDrawingResult> tuple = this.#F0c(#XDc, #hYc, #iYc, #jYc, #kYc, #lYc);
					Tuple<PolygonsDrawingData, IPolygonsDrawingResult> tuple2;
					if (!false)
					{
						tuple2 = tuple;
					}
					do
					{
						this.DrawingEngine.DrawPolygons(tuple2.Item1, tuple2.Item2, #SZc, #TZc);
					}
					while (-1 == 0);
					VisibilityLayer visibilityLayer = this.ShapesVisibilityLayer;
					IPolygonsDrawingResult item = tuple2.Item2;
					if (!false)
					{
						visibilityLayer.Add(item);
					}
				}
				finally
				{
					if (4 == 0 || 5 == 0 || bulkUpdateScope2 != null)
					{
						bulkUpdateScope2.Dispose();
					}
				}
			}
		}

		// Token: 0x0600694F RID: 26959 RVA: 0x00199338 File Offset: 0x00197538
		public void #UZc(ShapeDataModel #XDc, double #hYc, double #iYc, double #jYc, Color? #kYc, Color? #lYc, bool #SZc, bool #TZc)
		{
			if (3 != 0)
			{
				string #R0d = #Phc.#3hc(107435029);
				StructurePoint.CoreAssets.Infrastructure.Exceptions.Component #x6c = StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUIFramework;
				string #Qic = #Phc.#3hc(107435414);
				if (3 != 0)
				{
					#X0d.#V0d(#XDc, #R0d, #x6c, #Qic);
				}
				IBulkUpdateScope bulkUpdateScope = base.View.ModelVisualizationControl.TransparencySorter.BeginBulkUpdate();
				IBulkUpdateScope bulkUpdateScope2;
				if (7 != 0)
				{
					bulkUpdateScope2 = bulkUpdateScope;
				}
				try
				{
					Tuple<PolygonsDrawingData, IPolygonsDrawingResult> tuple = this.#G0c(#XDc, #hYc, #iYc, #jYc, #kYc, #lYc);
					Tuple<PolygonsDrawingData, IPolygonsDrawingResult> tuple2;
					if (!false)
					{
						tuple2 = tuple;
					}
					do
					{
						this.DrawingEngine.DrawPolygonsWithoutSurface(tuple2.Item1, tuple2.Item2, #SZc, #TZc);
					}
					while (-1 == 0);
					VisibilityLayer visibilityLayer = this.AdditionalFiguresVisibilityLayer;
					IPolygonsDrawingResult item = tuple2.Item2;
					if (!false)
					{
						visibilityLayer.Add(item);
					}
				}
				finally
				{
					if (4 == 0 || 5 == 0 || bulkUpdateScope2 != null)
					{
						bulkUpdateScope2.Dispose();
					}
				}
			}
		}

		// Token: 0x06006950 RID: 26960 RVA: 0x00199408 File Offset: 0x00197608
		public void #QZc(ShapeDataModel #XDc)
		{
			double #hYc = 0.01;
			double #iYc = 0.012;
			double #jYc = 0.014;
			Color? #kYc = null;
			Color? #lYc = null;
			if (8 != 0)
			{
				this.#QZc(#XDc, #hYc, #iYc, #jYc, #kYc, #lYc);
			}
		}

		// Token: 0x06006951 RID: 26961 RVA: 0x00199458 File Offset: 0x00197658
		public void #RZc(ShapeDataModel #XDc)
		{
			double #hYc = 0.01;
			double #iYc = 0.012;
			double #jYc = 0.014;
			Color? #kYc = null;
			Color? #lYc = null;
			if (8 != 0)
			{
				this.#RZc(#XDc, #hYc, #iYc, #jYc, #kYc, #lYc);
			}
		}

		// Token: 0x06006952 RID: 26962 RVA: 0x001994A8 File Offset: 0x001976A8
		public void #UZc(ShapeDataModel #XDc)
		{
			double #hYc = 0.03;
			double #iYc = 0.05;
			double #jYc = 0.07;
			Color? #kYc = null;
			Color? #lYc = null;
			bool #SZc = false;
			bool #TZc = false;
			if (!false)
			{
				this.#UZc(#XDc, #hYc, #iYc, #jYc, #kYc, #lYc, #SZc, #TZc);
			}
		}

		// Token: 0x06006953 RID: 26963 RVA: 0x001994FC File Offset: 0x001976FC
		public void #RZc(ShapeDataModel #XDc, bool #SZc, bool #TZc)
		{
			double #hYc = 0.01;
			double #iYc = 0.012;
			double #jYc = 0.014;
			Color? #kYc = null;
			Color? #lYc = null;
			if (!false)
			{
				this.#RZc(#XDc, #hYc, #iYc, #jYc, #kYc, #lYc, #SZc, #TZc);
			}
		}

		// Token: 0x06006954 RID: 26964 RVA: 0x00199550 File Offset: 0x00197750
		public void #UZc(ShapeDataModel #XDc, bool #SZc, bool #TZc)
		{
			double #hYc = 0.03;
			double #iYc = 0.05;
			double #jYc = 0.07;
			Color? #kYc = null;
			Color? #lYc = null;
			if (!false)
			{
				this.#UZc(#XDc, #hYc, #iYc, #jYc, #kYc, #lYc, #SZc, #TZc);
			}
		}

		// Token: 0x06006955 RID: 26965 RVA: 0x00053A17 File Offset: 0x00051C17
		public void #VZc(IReadOnlyList<ShapeDataModel> #6Y)
		{
			#U0c #Ee = base.View;
			Action<ShapeDataModel> #K0c = new Action<ShapeDataModel>(this.#QZc);
			if (4 != 0)
			{
				#Q0c.#VZc(#6Y, #Ee, #K0c);
			}
		}

		// Token: 0x06006956 RID: 26966 RVA: 0x00053A3A File Offset: 0x00051C3A
		public void #WZc(IReadOnlyList<ShapeDataModel> #6Y)
		{
			#U0c #Ee = base.View;
			Action<ShapeDataModel> #L0c = new Action<ShapeDataModel>(this.#RZc);
			if (4 != 0)
			{
				#Q0c.#WZc(#6Y, #Ee, #L0c);
			}
		}

		// Token: 0x06006957 RID: 26967 RVA: 0x00053A5D File Offset: 0x00051C5D
		public void #XZc(IReadOnlyList<ShapeDataModel> #6Y)
		{
			#U0c #Ee = base.View;
			Action<ShapeDataModel> #M0c = new Action<ShapeDataModel>(this.#UZc);
			if (4 != 0)
			{
				#Q0c.#XZc(#6Y, #Ee, #M0c);
			}
		}

		// Token: 0x06006958 RID: 26968 RVA: 0x00053A80 File Offset: 0x00051C80
		public void #8ob(ShapeDataModel #XDc)
		{
			#U0c #Ee = base.View;
			Action<ShapeDataModel> #N0c = new Action<ShapeDataModel>(this.#t0c);
			if (!false)
			{
				#Q0c.#8ob(#XDc, #Ee, #N0c);
			}
		}

		// Token: 0x06006959 RID: 26969 RVA: 0x00053AA2 File Offset: 0x00051CA2
		public void #YZc(ShapeDataModel #XDc)
		{
			#U0c #Ee = base.View;
			Action<ShapeDataModel> #O0c = new Action<ShapeDataModel>(this.#u0c);
			if (!false)
			{
				#Q0c.#YZc(#XDc, #Ee, #O0c);
			}
		}

		// Token: 0x0600695A RID: 26970 RVA: 0x00053AC4 File Offset: 0x00051CC4
		public void #8ob(IEnumerable<ShapeDataModel> #6Y)
		{
			#U0c #Ee = base.View;
			Action<ShapeDataModel> #N0c = new Action<ShapeDataModel>(this.#t0c);
			if (!false)
			{
				#Q0c.#8ob(#6Y, #Ee, #N0c);
			}
		}

		// Token: 0x0600695B RID: 26971 RVA: 0x00053AE6 File Offset: 0x00051CE6
		public void #ZZc(IEnumerable<ShapeDataModel> #6Y)
		{
			#U0c #Ee = base.View;
			Action<ShapeDataModel> #O0c = new Action<ShapeDataModel>(this.#u0c);
			if (!false)
			{
				#Q0c.#ZZc(#6Y, #Ee, #O0c);
			}
		}

		// Token: 0x0600695C RID: 26972 RVA: 0x00053B08 File Offset: 0x00051D08
		public void #0Zc(IEnumerable<ShapeDataModel> #rP)
		{
			#U0c #Ee = base.View;
			Action<ShapeDataModel> #P0c = new Action<ShapeDataModel>(this.#1Zc);
			if (4 != 0)
			{
				#Q0c.#0Zc(#rP, #Ee, #P0c);
			}
		}

		// Token: 0x0600695D RID: 26973 RVA: 0x00053B2B File Offset: 0x00051D2B
		public void #1Zc(ShapeDataModel #XDc)
		{
			bool #2Zc = true;
			if (2 != 0)
			{
				this.#1Zc(#XDc, #2Zc);
			}
		}

		// Token: 0x0600695E RID: 26974 RVA: 0x00053B3D File Offset: 0x00051D3D
		public void #1Zc(ShapeDataModel #XDc, bool #2Zc)
		{
			bool #2Zc2 = true;
			Color #lYc = this.SettingsManager.VisualizationSelectedShapeFillColor;
			if (!false)
			{
				this.#I0c(#XDc, #2Zc2, #lYc);
			}
		}

		// Token: 0x0600695F RID: 26975 RVA: 0x00053B5B File Offset: 0x00051D5B
		public void #1Zc(ShapeDataModel #XDc, Color #lYc)
		{
			bool #2Zc = true;
			if (!false)
			{
				this.#I0c(#XDc, #2Zc, #lYc);
			}
		}

		// Token: 0x06006960 RID: 26976 RVA: 0x001995A4 File Offset: 0x001977A4
		public void #3Zc(ShapeDataModel #XDc, bool #SZc, bool #TZc, bool #2Zc)
		{
			string #R0d = #Phc.#3hc(107435029);
			StructurePoint.CoreAssets.Infrastructure.Exceptions.Component #x6c = StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUIFramework;
			string #Qic = #Phc.#3hc(107435329);
			if (!false)
			{
				#X0d.#V0d(#XDc, #R0d, #x6c, #Qic);
			}
			int key;
			if (2 != 0)
			{
				if (!false)
				{
					int hashCode = #XDc.GetHashCode();
					if (-1 != 0)
					{
						key = hashCode;
					}
				}
				if (!false)
				{
					this.#5Zc(#XDc);
				}
			}
			ShapeDataModel shapeDataModel = new ShapeDataModel(this.UndoManager, #XDc, this.AssignmentsFactory, false);
			ShapeDataModel shapeDataModel2;
			if (true)
			{
				shapeDataModel2 = shapeDataModel;
			}
			Color color = #2Zc ? this.SettingsManager.VisualizationSelectedShapeFillColor : Colors.Transparent;
			Color value;
			if (8 != 0)
			{
				value = color;
			}
			IPointsDrawingResult pointsDrawingResult;
			for (;;)
			{
				ShapeDataModel #XDc2 = shapeDataModel2;
				double #hYc = 0.0171;
				double #iYc = 0.0191;
				double #jYc = 0.0211;
				Color? #kYc = new Color?(this.SettingsManager.VisualizationSelectedShapeEdgeColor);
				Color? #lYc = new Color?(value);
				if (!false)
				{
					this.#RZc(#XDc2, #hYc, #iYc, #jYc, #kYc, #lYc, #SZc, #TZc);
				}
				this.#h.Add(key, shapeDataModel2);
				pointsDrawingResult = this.DrawingResultsFactory.CreatePointsDrawingResult();
				pointsDrawingResult.PointColor = this.SettingsManager.VisualizationSelectedShapePointsColor;
				pointsDrawingResult.PointSize = this.SettingsManager.VisualizationShapeVertexSize;
				if (4 != 0)
				{
					List<Point3D> points = PointsConverter.#vsc(PolygonsDrawingEngine.CreateListOfPointsWithoutThoseFromCircularShapes(#XDc.Polygons, #SZc, #TZc), 0.027999999999999997);
					pointsDrawingResult.Points = points;
					if (!false)
					{
						break;
					}
				}
			}
			this.ShapesVisibilityLayer.Add(pointsDrawingResult);
			this.#i.Add(key, pointsDrawingResult);
		}

		// Token: 0x06006961 RID: 26977 RVA: 0x00199720 File Offset: 0x00197920
		public void #4Zc(IEnumerable<ShapeDataModel> #6Y)
		{
			string #R0d = #Phc.#3hc(107372113);
			StructurePoint.CoreAssets.Infrastructure.Exceptions.Component #x6c = StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUIFramework;
			string #Qic = #Phc.#3hc(107435276);
			if (5 != 0)
			{
				#X0d.#V0d(#6Y, #R0d, #x6c, #Qic);
			}
			IBulkUpdateScope bulkUpdateScope = base.View.ModelVisualizationControl.TransparencySorter.BeginBulkUpdate();
			IBulkUpdateScope bulkUpdateScope2;
			if (!false)
			{
				bulkUpdateScope2 = bulkUpdateScope;
			}
			try
			{
				IEnumerator<ShapeDataModel> enumerator = #6Y.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						ShapeDataModel shapeDataModel = enumerator.Current;
						ShapeDataModel shapeDataModel2;
						if (!false)
						{
							shapeDataModel2 = shapeDataModel;
						}
						ShapeDataModel #XDc = shapeDataModel2;
						if (7 != 0)
						{
							this.#s0c(#XDc);
						}
					}
				}
				finally
				{
					if (enumerator != null && 6 != 0)
					{
						enumerator.Dispose();
					}
				}
			}
			finally
			{
				do
				{
					if (bulkUpdateScope2 != null)
					{
						bulkUpdateScope2.Dispose();
					}
				}
				while (3 == 0);
			}
		}

		// Token: 0x06006962 RID: 26978 RVA: 0x001997D8 File Offset: 0x001979D8
		public void #5Zc(ShapeDataModel #XDc)
		{
			do
			{
				IBulkUpdateScope bulkUpdateScope = base.View.ModelVisualizationControl.TransparencySorter.BeginBulkUpdate();
				IBulkUpdateScope bulkUpdateScope2;
				if (!false)
				{
					bulkUpdateScope2 = bulkUpdateScope;
				}
				try
				{
					if (4 != 0)
					{
						this.#s0c(#XDc);
					}
				}
				finally
				{
					if (!false && bulkUpdateScope2 != null)
					{
						bulkUpdateScope2.Dispose();
					}
				}
			}
			while (false || false);
		}

		// Token: 0x06006963 RID: 26979 RVA: 0x00199834 File Offset: 0x00197A34
		public void #6Zc(ShapeDataModel #XDc, Color #BR)
		{
			string #R0d = #Phc.#3hc(107416953);
			StructurePoint.CoreAssets.Infrastructure.Exceptions.Component #x6c = StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUIFramework;
			string #Qic = #Phc.#3hc(107434743);
			if (4 != 0)
			{
				#X0d.#V0d(#XDc, #R0d, #x6c, #Qic);
			}
			int hashCode = #XDc.GetHashCode();
			if (false)
			{
				goto IL_39;
			}
			int key;
			if (2 != 0)
			{
				key = hashCode;
			}
			IL_2B:
			IPolygonsDrawingResult polygonsDrawingResult;
			this.#g.TryGetValue(key, out polygonsDrawingResult);
			IL_39:
			if (polygonsDrawingResult != null)
			{
				if (5 == 0)
				{
					goto IL_2B;
				}
				IPolygonsDrawingResult polygonsDrawingResult2 = polygonsDrawingResult;
				if (7 != 0)
				{
					polygonsDrawingResult2.OuterSurfacesFillColor = #BR;
				}
				if (2 != 0)
				{
					return;
				}
			}
		}

		// Token: 0x06006964 RID: 26980 RVA: 0x001998A0 File Offset: 0x00197AA0
		public Color #7Zc(ShapeDataModel #XDc)
		{
			string #R0d = #Phc.#3hc(107416953);
			StructurePoint.CoreAssets.Infrastructure.Exceptions.Component #x6c = StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUIFramework;
			string #Qic = #Phc.#3hc(107434658);
			if (!false)
			{
				#X0d.#V0d(#XDc, #R0d, #x6c, #Qic);
			}
			IPolygonsDrawingResult polygonsDrawingResult;
			this.#g.TryGetValue(#XDc.GetHashCode(), out polygonsDrawingResult);
			Color result = default(Color);
			if (polygonsDrawingResult != null)
			{
				Color outerSurfacesFillColor = polygonsDrawingResult.OuterSurfacesFillColor;
				if (8 != 0)
				{
					result = outerSurfacesFillColor;
				}
			}
			return result;
		}

		// Token: 0x06006965 RID: 26981 RVA: 0x00199900 File Offset: 0x00197B00
		public void #8Zc(IEnumerable<NodeModel> #6W)
		{
			string #R0d = #Phc.#3hc(107416106);
			StructurePoint.CoreAssets.Infrastructure.Exceptions.Component #x6c = StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUIFramework;
			string #Qic = #Phc.#3hc(107434605);
			if (8 != 0)
			{
				#X0d.#V0d(#6W, #R0d, #x6c, #Qic);
			}
			List<NodeModel> list = #6W.Where(new Func<NodeModel, bool>(ModelEditorViewModel.<>c.<>9.#Mbd)).ToList<NodeModel>();
			List<NodeModel> list2;
			if (!false)
			{
				list2 = list;
			}
			#S0c #S0c = this.DrawingResultsManager;
			VisibilityLayer #0Xc = this.NodesVisibilityLayer;
			IPointsDrawingResult #YQc = this.#k;
			IList<NodeModel> #cYc = list2;
			if (!false)
			{
				#S0c.#bYc(#0Xc, #YQc, #cYc);
			}
		}

		// Token: 0x06006966 RID: 26982 RVA: 0x00199984 File Offset: 0x00197B84
		public void #9Zc(NodeModel #uXb)
		{
			string #R0d = #Phc.#3hc(107440306);
			StructurePoint.CoreAssets.Infrastructure.Exceptions.Component #x6c = StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUIFramework;
			string #Qic = #Phc.#3hc(107434584);
			if (4 != 0)
			{
				#X0d.#V0d(#uXb, #R0d, #x6c, #Qic);
			}
			this.#m.Add(#uXb.Location);
			do
			{
				if (!false)
				{
					#S0c #S0c = this.DrawingResultsManager;
					VisibilityLayer #0Xc = this.NodesVisibilityLayer;
					IPointsDrawingResult #YQc = this.#l;
					HashSet<StructurePoint.CoreAssets.Infrastructure.Data.Point> #fYc = this.#m;
					if (2 != 0)
					{
						#S0c.#eYc(#0Xc, #YQc, #fYc);
					}
				}
			}
			while (2 == 0);
		}

		// Token: 0x06006967 RID: 26983 RVA: 0x001999F4 File Offset: 0x00197BF4
		public void #a0c(NodeModel #uXb)
		{
			string #R0d = #Phc.#3hc(107440306);
			StructurePoint.CoreAssets.Infrastructure.Exceptions.Component #x6c = StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUIFramework;
			string #Qic = #Phc.#3hc(107434499);
			if (4 != 0)
			{
				#X0d.#V0d(#uXb, #R0d, #x6c, #Qic);
			}
			this.#m.Remove(#uXb.Location);
			do
			{
				if (!false)
				{
					#S0c #S0c = this.DrawingResultsManager;
					VisibilityLayer #0Xc = this.NodesVisibilityLayer;
					IPointsDrawingResult #YQc = this.#l;
					HashSet<StructurePoint.CoreAssets.Infrastructure.Data.Point> #fYc = this.#m;
					if (2 != 0)
					{
						#S0c.#eYc(#0Xc, #YQc, #fYc);
					}
				}
			}
			while (2 == 0);
		}

		// Token: 0x06006968 RID: 26984 RVA: 0x00199A64 File Offset: 0x00197C64
		public void #b0c(IEnumerable<NodeModel> #6W)
		{
			if (!false)
			{
				string #R0d = #Phc.#3hc(107416106);
				StructurePoint.CoreAssets.Infrastructure.Exceptions.Component #x6c = StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUIFramework;
				string #Qic = #Phc.#3hc(107434958);
				if (!false)
				{
					#X0d.#V0d(#6W, #R0d, #x6c, #Qic);
				}
				IEnumerator<NodeModel> enumerator = #6W.GetEnumerator();
				IEnumerator<NodeModel> enumerator2;
				if (!false)
				{
					enumerator2 = enumerator;
				}
				try
				{
					if (7 != 0)
					{
						if (!false)
						{
							goto IL_55;
						}
						goto IL_43;
					}
					IL_39:
					NodeModel nodeModel = enumerator2.Current;
					NodeModel nodeModel2;
					if (!false)
					{
						nodeModel2 = nodeModel;
					}
					IL_43:
					this.#m.Remove(nodeModel2.Location);
					IL_55:
					if (enumerator2.MoveNext())
					{
						goto IL_39;
					}
				}
				finally
				{
					if (false || enumerator2 != null)
					{
						enumerator2.Dispose();
					}
				}
				#S0c #S0c = this.DrawingResultsManager;
				VisibilityLayer #0Xc = this.NodesVisibilityLayer;
				IPointsDrawingResult #YQc = this.#l;
				HashSet<StructurePoint.CoreAssets.Infrastructure.Data.Point> #fYc = this.#m;
				if (!false)
				{
					#S0c.#eYc(#0Xc, #YQc, #fYc);
				}
			}
		}

		// Token: 0x06006969 RID: 26985 RVA: 0x00199B28 File Offset: 0x00197D28
		public void #c0c(IEnumerable<NodeModel> #6W)
		{
			string #R0d = #Phc.#3hc(107416106);
			StructurePoint.CoreAssets.Infrastructure.Exceptions.Component #x6c = StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUIFramework;
			string #Qic = #Phc.#3hc(107434937);
			if (true)
			{
				#X0d.#V0d(#6W, #R0d, #x6c, #Qic);
			}
			IBulkUpdateScope bulkUpdateScope = base.View.ModelVisualizationControl.TransparencySorter.BeginBulkUpdate();
			IBulkUpdateScope bulkUpdateScope2;
			if (!false)
			{
				bulkUpdateScope2 = bulkUpdateScope;
			}
			try
			{
				IEnumerator<NodeModel> enumerator = #6W.GetEnumerator();
				IEnumerator<NodeModel> enumerator2;
				if (-1 != 0)
				{
					enumerator2 = enumerator;
				}
				try
				{
					while (enumerator2.MoveNext())
					{
						NodeModel nodeModel = enumerator2.Current;
						NodeModel nodeModel2;
						if (!false)
						{
							nodeModel2 = nodeModel;
						}
						this.#m.Add(nodeModel2.Location);
					}
				}
				finally
				{
					if (enumerator2 != null)
					{
						enumerator2.Dispose();
					}
				}
				#S0c #S0c = this.DrawingResultsManager;
				VisibilityLayer #0Xc = this.NodesVisibilityLayer;
				IPointsDrawingResult #YQc = this.#l;
				HashSet<StructurePoint.CoreAssets.Infrastructure.Data.Point> #fYc = this.#m;
				if (!false)
				{
					#S0c.#eYc(#0Xc, #YQc, #fYc);
				}
			}
			finally
			{
				if (bulkUpdateScope2 != null)
				{
					bulkUpdateScope2.Dispose();
				}
			}
		}

		// Token: 0x0600696A RID: 26986 RVA: 0x00199C14 File Offset: 0x00197E14
		public void #d0c()
		{
			if (8 != 0 && 5 != 0)
			{
				IPointsDrawingResult pointsDrawingResult = this.#k;
				Color pointColor = this.SettingsManager.VisualizationDefaultCustomNodeColor;
				if (-1 != 0)
				{
					pointsDrawingResult.PointColor = pointColor;
				}
				if (2 != 0)
				{
					IPointsDrawingResult pointsDrawingResult2 = this.#l;
					Color pointColor2 = this.SettingsManager.VisualizationSelectedCustomNodeColor;
					if (2 != 0)
					{
						pointsDrawingResult2.PointColor = pointColor2;
					}
				}
			}
		}

		// Token: 0x0600696B RID: 26987 RVA: 0x00199C64 File Offset: 0x00197E64
		public void #e0c(IEnumerable<LinearObject> #iEc)
		{
			do
			{
				string #R0d = #Phc.#3hc(107416450);
				StructurePoint.CoreAssets.Infrastructure.Exceptions.Component #x6c = StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUIFramework;
				string #Qic = #Phc.#3hc(107434852);
				if (!false)
				{
					#X0d.#V0d(#iEc, #R0d, #x6c, #Qic);
				}
			}
			while (false);
			#S0c #S0c = this.DrawingResultsManager;
			VisibilityLayer #0Xc = this.LinearObjectsVisibilityLayer;
			IMultilineDrawingResult #6Xc = this.#n;
			IPointsDrawingResult #7Xc = this.#o;
			if (!false)
			{
				#S0c.#5Xc(#0Xc, #6Xc, #7Xc, #iEc);
			}
		}

		// Token: 0x0600696C RID: 26988 RVA: 0x00199CC4 File Offset: 0x00197EC4
		public void #f0c(LinearObject #NNc)
		{
			string #R0d = #Phc.#3hc(107440028);
			StructurePoint.CoreAssets.Infrastructure.Exceptions.Component #x6c = StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUIFramework;
			string #Qic = #Phc.#3hc(107434799);
			if (7 != 0)
			{
				#X0d.#V0d(#NNc, #R0d, #x6c, #Qic);
			}
			this.#r.Add(#NNc);
			#S0c #S0c = this.DrawingResultsManager;
			VisibilityLayer #0Xc = this.LinearObjectsVisibilityLayer;
			IMultilineDrawingResult #YQc = this.#q;
			HashSet<LinearObject> #aYc = this.#r;
			if (!false)
			{
				#S0c.#9Xc(#0Xc, #YQc, #aYc);
			}
		}

		// Token: 0x0600696D RID: 26989 RVA: 0x00199D2C File Offset: 0x00197F2C
		public void #g0c(LinearObject #NNc)
		{
			string #R0d = #Phc.#3hc(107440028);
			StructurePoint.CoreAssets.Infrastructure.Exceptions.Component #x6c = StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUIFramework;
			string #Qic = #Phc.#3hc(107434778);
			if (7 != 0)
			{
				#X0d.#V0d(#NNc, #R0d, #x6c, #Qic);
			}
			this.#r.Remove(#NNc);
			#S0c #S0c = this.DrawingResultsManager;
			VisibilityLayer #0Xc = this.LinearObjectsVisibilityLayer;
			IMultilineDrawingResult #YQc = this.#q;
			HashSet<LinearObject> #aYc = this.#r;
			if (!false)
			{
				#S0c.#9Xc(#0Xc, #YQc, #aYc);
			}
		}

		// Token: 0x0600696E RID: 26990 RVA: 0x00199D94 File Offset: 0x00197F94
		public void #h0c(IEnumerable<LinearObject> #iEc)
		{
			string #R0d = #Phc.#3hc(107416450);
			StructurePoint.CoreAssets.Infrastructure.Exceptions.Component #x6c = StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUIFramework;
			string #Qic = #Phc.#3hc(107434181);
			if (!false)
			{
				#X0d.#V0d(#iEc, #R0d, #x6c, #Qic);
			}
			IBulkUpdateScope bulkUpdateScope = base.View.ModelVisualizationControl.TransparencySorter.BeginBulkUpdate();
			IBulkUpdateScope bulkUpdateScope2;
			if (!false)
			{
				bulkUpdateScope2 = bulkUpdateScope;
			}
			try
			{
				IEnumerator<LinearObject> enumerator = #iEc.GetEnumerator();
				IEnumerator<LinearObject> enumerator2;
				if (8 != 0)
				{
					enumerator2 = enumerator;
				}
				try
				{
					for (;;)
					{
						IL_60:
						bool flag = enumerator2.MoveNext();
						while (flag)
						{
							LinearObject linearObject = enumerator2.Current;
							LinearObject item;
							if (7 != 0)
							{
								item = linearObject;
							}
							flag = this.#r.Remove(item);
							if (!false)
							{
								goto IL_60;
							}
						}
						break;
					}
				}
				finally
				{
					if (enumerator2 != null)
					{
						enumerator2.Dispose();
					}
				}
				#S0c #S0c = this.DrawingResultsManager;
				VisibilityLayer #0Xc = this.LinearObjectsVisibilityLayer;
				IMultilineDrawingResult #YQc = this.#q;
				HashSet<LinearObject> #aYc = this.#r;
				if (!false)
				{
					#S0c.#9Xc(#0Xc, #YQc, #aYc);
				}
			}
			finally
			{
				if (bulkUpdateScope2 != null)
				{
					bulkUpdateScope2.Dispose();
				}
			}
		}

		// Token: 0x0600696F RID: 26991 RVA: 0x00199E7C File Offset: 0x0019807C
		public void #i0c(IEnumerable<LinearObject> #iEc)
		{
			string #R0d = #Phc.#3hc(107416450);
			StructurePoint.CoreAssets.Infrastructure.Exceptions.Component #x6c = StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUIFramework;
			string #Qic = #Phc.#3hc(107434160);
			if (!false)
			{
				#X0d.#V0d(#iEc, #R0d, #x6c, #Qic);
			}
			IBulkUpdateScope bulkUpdateScope = base.View.ModelVisualizationControl.TransparencySorter.BeginBulkUpdate();
			IBulkUpdateScope bulkUpdateScope2;
			if (!false)
			{
				bulkUpdateScope2 = bulkUpdateScope;
			}
			try
			{
				IEnumerator<LinearObject> enumerator = #iEc.GetEnumerator();
				IEnumerator<LinearObject> enumerator2;
				if (8 != 0)
				{
					enumerator2 = enumerator;
				}
				try
				{
					for (;;)
					{
						IL_60:
						bool flag = enumerator2.MoveNext();
						while (flag)
						{
							LinearObject linearObject = enumerator2.Current;
							LinearObject item;
							if (7 != 0)
							{
								item = linearObject;
							}
							flag = this.#r.Add(item);
							if (!false)
							{
								goto IL_60;
							}
						}
						break;
					}
				}
				finally
				{
					if (enumerator2 != null)
					{
						enumerator2.Dispose();
					}
				}
				#S0c #S0c = this.DrawingResultsManager;
				VisibilityLayer #0Xc = this.NodesVisibilityLayer;
				IPointsDrawingResult #YQc = this.#l;
				HashSet<StructurePoint.CoreAssets.Infrastructure.Data.Point> #fYc = this.#m;
				if (!false)
				{
					#S0c.#eYc(#0Xc, #YQc, #fYc);
				}
			}
			finally
			{
				if (bulkUpdateScope2 != null)
				{
					bulkUpdateScope2.Dispose();
				}
			}
		}

		// Token: 0x06006970 RID: 26992 RVA: 0x00199F64 File Offset: 0x00198164
		public void #j0c(Point3D #k0c, BoundingBoxData #Prc)
		{
			string #R0d = #Phc.#3hc(107460169);
			StructurePoint.CoreAssets.Infrastructure.Exceptions.Component #x6c = StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUIFramework;
			string #Qic = #Phc.#3hc(107434107);
			if (!false)
			{
				#X0d.#V0d(#Prc, #R0d, #x6c, #Qic);
			}
			SegmentData segmentData = #Dpc.#xpc(#k0c, #Prc);
			SegmentData segmentData2;
			if (!false)
			{
				segmentData2 = segmentData;
			}
			SegmentData segmentData3 = #Dpc.#zpc(#k0c, #Prc);
			SegmentData segmentData4;
			if (!false)
			{
				segmentData4 = segmentData3;
			}
			if (4 != 0)
			{
				List<LinearObject> list = new List<LinearObject>();
				list.Add(new LinearObject(this.UndoManager, this.AssignmentsFactory, segmentData2.StartPoint, segmentData2.EndPoint));
				LinearObject item = new LinearObject(this.UndoManager, this.AssignmentsFactory, segmentData4.StartPoint, segmentData4.EndPoint);
				if (6 != 0)
				{
					list.Add(item);
				}
				List<LinearObject> list2;
				if (!false)
				{
					list2 = list;
				}
				#S0c #S0c = this.DrawingResultsManager;
				VisibilityLayer #0Xc = this.OrthogonalFencesVisibilityLayer;
				IDashedMultilineDrawingResult #6Xc = this.#p;
				IEnumerable<LinearObject> #iEc = list2;
				if (5 != 0)
				{
					#S0c.#8Xc(#0Xc, #6Xc, #iEc);
				}
			}
		}

		// Token: 0x06006971 RID: 26993 RVA: 0x00053B6F File Offset: 0x00051D6F
		public void #l0c()
		{
			#S0c #S0c = this.DrawingResultsManager;
			VisibilityLayer #0Xc = this.OrthogonalFencesVisibilityLayer;
			IDashedMultilineDrawingResult #6Xc = this.#p;
			IEnumerable<LinearObject> #iEc = new List<LinearObject>();
			if (4 != 0)
			{
				#S0c.#8Xc(#0Xc, #6Xc, #iEc);
			}
		}

		// Token: 0x06006972 RID: 26994 RVA: 0x0019A040 File Offset: 0x00198240
		public void #m0c(IList<GridLineDefinitionModel> #ooc, bool #JS, bool #GZc)
		{
			bool flag = true;
			if (!false)
			{
				#GZc = flag;
			}
			if ((#GZc || !#ooc.Any<GridLineDefinitionModel>() || #JS) && 8 != 0)
			{
				this.#B0c(#JS);
			}
			this.#y = AnnotationsHelper.#TJc(base.View.ModelVisualizationControl.EditorWorkspaceSize.Width, base.View.ModelVisualizationControl.EditorWorkspaceSize.Height);
			VisibilityLayer visibilityLayer = #JS ? this.GridVisibilityLayer : this.GridLineAnnotationsVisibilityLayer;
			VisibilityLayer visibilityLayer2;
			if (true)
			{
				visibilityLayer2 = visibilityLayer;
			}
			HashSet<IAnnotationDrawingResult> hashSet;
			if (!#JS)
			{
				hashSet = this.#s;
			}
			else
			{
				if (6 == 0)
				{
					goto IL_BA;
				}
				hashSet = this.#v;
			}
			HashSet<IAnnotationDrawingResult> hashSet2;
			if (-1 != 0)
			{
				hashSet2 = hashSet;
			}
			List<Tuple<Point3D, Point3D>> list = new List<Tuple<Point3D, Point3D>>();
			List<Tuple<Point3D, Point3D>> list2;
			if (8 != 0)
			{
				list2 = list;
			}
			List<Tuple<Point3D, Point3D>> list3 = new List<Tuple<Point3D, Point3D>>();
			List<Tuple<Point3D, Point3D>> list4;
			if (!false)
			{
				list4 = list3;
			}
			List<GridLineDefinitionModel> list5 = new List<GridLineDefinitionModel>();
			List<IAnnotationDrawingResult> list6 = new List<IAnnotationDrawingResult>();
			List<Point3D> list7 = new List<Point3D>();
			IL_BA:
			using (HashSet<IAnnotationDrawingResult>.Enumerator enumerator = hashSet2.GetEnumerator())
			{
				for (;;)
				{
					bool flag3;
					bool flag2 = flag3 = enumerator.MoveNext();
					ModelEditorViewModel.#Obd #Obd;
					double #OJc;
					if (8 != 0)
					{
						if (!flag2)
						{
							break;
						}
						#Obd = new ModelEditorViewModel.#Obd();
						#Obd.#a = enumerator.Current;
						GridLineDefinitionModel #a = #ooc.FirstOrDefault(new Func<GridLineDefinitionModel, bool>(#Obd.#Nbd));
						if (#a == null)
						{
							list6.Add(#Obd.#a);
							continue;
						}
						#OJc = AnnotationsHelper.#SJc(#a);
						flag3 = #JS;
					}
					StructurePoint.CoreAssets.Infrastructure.Data.Point #NJc;
					if (flag3)
					{
						#NJc = PointsConverter.#vsc(this.#s.First(new Func<IAnnotationDrawingResult, bool>(#Qbd.#Pbd)).Position);
					}
					else
					{
						#NJc = AnnotationsHelper.#QJc(#Qbd.#a, #OJc, this.#y, list7);
					}
					if (!false)
					{
						Tuple<Point3D, Point3D> item = AnnotationsHelper.#MJc(#Qbd.#a, #NJc, #OJc, this.#y);
						#Obd.#a.BeginInit();
						#Obd.#a.Position = new Point3D(#NJc.X, #NJc.Y, 0.016);
						#Obd.#a.SetAnnotationRadius(this.#y);
						#Obd.#a.EndInit();
						list5.Add(#Qbd.#a);
						list2.Add(item);
					}
					list7.Add(#Obd.#a.Position);
				}
			}
			foreach (IAnnotationDrawingResult annotationDrawingResult in list6)
			{
				hashSet2.Remove(annotationDrawingResult);
				visibilityLayer2.Remove(annotationDrawingResult);
			}
			List<GridLineDefinitionModel>.Enumerator enumerator3 = AnnotationsHelper.#WJc(#ooc, list5).GetEnumerator();
			try
			{
				while (enumerator3.MoveNext())
				{
					GridLineDefinitionModel gridLineDefinitionModel;
					if (5 != 0)
					{
						gridLineDefinitionModel = enumerator3.Current;
					}
					if (gridLineDefinitionModel.IsDarker)
					{
						list4.Add(this.#A0c(gridLineDefinitionModel, #JS));
					}
					else
					{
						list2.Add(this.#A0c(gridLineDefinitionModel, #JS));
					}
				}
			}
			finally
			{
				if (4 != 0)
				{
					((IDisposable)enumerator3).Dispose();
				}
			}
			this.#z0c(list2, list4);
			this.#D0c();
		}

		// Token: 0x06006973 RID: 26995 RVA: 0x00053B96 File Offset: 0x00051D96
		private void #n0c(object #Ge, PropertyChangedEventArgs #He)
		{
			if (6 != 0)
			{
				this.#DZc();
			}
		}

		// Token: 0x06006974 RID: 26996 RVA: 0x00053BA4 File Offset: 0x00051DA4
		private void #o0c(object #Ge, PropertyChangedEventArgs #He)
		{
			if (6 != 0)
			{
				this.#D0c();
			}
		}

		// Token: 0x06006975 RID: 26997 RVA: 0x00053BB2 File Offset: 0x00051DB2
		private void #p0c(object #Ge, PropertyChangedEventArgs #He)
		{
			if (6 != 0)
			{
				this.#H0c();
			}
		}

		// Token: 0x06006976 RID: 26998 RVA: 0x00053BB2 File Offset: 0x00051DB2
		private void #q0c(object #Ge, CameraDistanceChangedEventArgs #He)
		{
			if (6 != 0)
			{
				this.#H0c();
			}
		}

		// Token: 0x06006977 RID: 26999 RVA: 0x00053BC0 File Offset: 0x00051DC0
		private void #r0c(object #Ge, RoutedEventArgs #He)
		{
			bool suspendEvents = base.View.ModelVisualizationControl.SuspendEvents;
			if (7 != 0)
			{
				this.SuspendEvents = suspendEvents;
			}
		}

		// Token: 0x06006978 RID: 27000 RVA: 0x0019A394 File Offset: 0x00198594
		private void #s0c(ShapeDataModel #XDc)
		{
			int key;
			IPointsDrawingResult pointsDrawingResult;
			if (3 != 0)
			{
				string #R0d = #Phc.#3hc(107435029);
				StructurePoint.CoreAssets.Infrastructure.Exceptions.Component #x6c = StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUIFramework;
				string #Qic = #Phc.#3hc(107434022);
				if (7 != 0)
				{
					#X0d.#V0d(#XDc, #R0d, #x6c, #Qic);
				}
				int hashCode = #XDc.GetHashCode();
				if (5 != 0)
				{
					key = hashCode;
				}
				ShapeDataModel shapeDataModel;
				this.#h.TryGetValue(key, out shapeDataModel);
				if (3 == 0)
				{
					return;
				}
				if (shapeDataModel != null)
				{
					ShapeDataModel #XDc2 = shapeDataModel;
					if (!false)
					{
						this.#t0c(#XDc2);
					}
					if (7 == 0)
					{
						goto IL_6C;
					}
					this.#h.Remove(key);
				}
				IL_56:
				this.#i.TryGetValue(key, out pointsDrawingResult);
				if (8 == 0)
				{
					goto IL_56;
				}
			}
			if (pointsDrawingResult == null)
			{
				return;
			}
			IL_6C:
			VisibilityLayer visibilityLayer = this.ShapesVisibilityLayer;
			IPointsDrawingResult pointsDrawingResult2 = pointsDrawingResult;
			if (-1 != 0)
			{
				visibilityLayer.Remove(pointsDrawingResult2);
			}
			this.#i.Remove(key);
		}

		// Token: 0x06006979 RID: 27001 RVA: 0x0019A444 File Offset: 0x00198644
		private void #t0c(ShapeDataModel #XDc)
		{
			int hashCode = #XDc.GetHashCode();
			int num;
			if (!false)
			{
				num = hashCode;
			}
			IPolygonsDrawingResult polygonsDrawingResult = this.#g.#F1d(num);
			IPolygonsDrawingResult polygonsDrawingResult2;
			if (true)
			{
				polygonsDrawingResult2 = polygonsDrawingResult;
			}
			for (;;)
			{
				if (polygonsDrawingResult2 != null)
				{
					if (false)
					{
						continue;
					}
					VisibilityLayer visibilityLayer = this.ShapesVisibilityLayer;
					IPolygonsDrawingResult polygonsDrawingResult3 = polygonsDrawingResult2;
					if (false)
					{
						goto IL_2C;
					}
					visibilityLayer.Remove(polygonsDrawingResult3);
					goto IL_2C;
				}
				IL_39:
				if (5 == 0)
				{
					continue;
				}
				if (!false)
				{
					this.#s0c(#XDc);
				}
				if (2 != 0)
				{
					break;
				}
				IL_2C:
				this.#g.Remove(num);
				goto IL_39;
			}
		}

		// Token: 0x0600697A RID: 27002 RVA: 0x0019A4AC File Offset: 0x001986AC
		private void #u0c(ShapeDataModel #XDc)
		{
			if (!false)
			{
				int num;
				if (!false)
				{
					int hashCode = #XDc.GetHashCode();
					if (!false)
					{
						num = hashCode;
					}
				}
				if (7 != 0)
				{
					IPolygonsDrawingResult polygonsDrawingResult = this.#j.#F1d(num);
					IPolygonsDrawingResult polygonsDrawingResult2;
					if (3 != 0)
					{
						polygonsDrawingResult2 = polygonsDrawingResult;
					}
					if (polygonsDrawingResult2 == null)
					{
						return;
					}
					VisibilityLayer visibilityLayer = this.AdditionalFiguresVisibilityLayer;
					IPolygonsDrawingResult polygonsDrawingResult3 = polygonsDrawingResult2;
					if (-1 != 0)
					{
						visibilityLayer.Remove(polygonsDrawingResult3);
					}
				}
				this.#j.Remove(num);
			}
		}

		// Token: 0x0600697B RID: 27003 RVA: 0x0019A508 File Offset: 0x00198708
		private void #v0c()
		{
			#S0c #S0c = this.DrawingResultsManager;
			VisibilityLayer #0Xc = this.GridVisibilityLayer;
			IMultilineDrawingResult #YQc = this.#e;
			HashSet<GridLineDefinitionModel> #4Xc = this.#f;
			if (3 != 0)
			{
				#S0c.#3Xc(#0Xc, #YQc, #4Xc);
			}
			if (this.#f.Any<GridLineDefinitionModel>())
			{
				IList<GridLineDefinitionModel> #ooc = this.#f.ToList<GridLineDefinitionModel>();
				bool #JS = true;
				bool #GZc = false;
				if (8 != 0)
				{
					this.#m0c(#ooc, #JS, #GZc);
				}
				return;
			}
			bool #JS2 = true;
			if (4 != 0)
			{
				this.#B0c(#JS2);
			}
		}

		// Token: 0x0600697C RID: 27004 RVA: 0x0019A574 File Offset: 0x00198774
		private void #w0c(IModelEditorControl #Smb)
		{
			do
			{
				VisibilityLayer visibilityLayer = this.#x0c(#Smb, null);
				if (true)
				{
					this.GridVisibilityLayer = visibilityLayer;
				}
				VisibilityLayer visibilityLayer2 = this.#x0c(#Smb, null);
				if (4 != 0)
				{
					this.ShapesVisibilityLayer = visibilityLayer2;
				}
				VisibilityLayer visibilityLayer3 = this.#x0c(#Smb, null);
				if (!false)
				{
					this.AdditionalFiguresVisibilityLayer = visibilityLayer3;
				}
				VisibilityLayer visibilityLayer4 = this.#x0c(#Smb, null);
				if (6 != 0)
				{
					this.NodesVisibilityLayer = visibilityLayer4;
				}
				VisibilityLayer visibilityLayer5 = this.#x0c(#Smb, null);
				if (7 != 0)
				{
					this.LinearObjectsVisibilityLayer = visibilityLayer5;
				}
				VisibilityLayer visibilityLayer6 = this.#x0c(#Smb, null);
				if (6 != 0)
				{
					this.OrthogonalFencesVisibilityLayer = visibilityLayer6;
				}
				this.OrthogonalFencesVisibilityLayer.PropertyChanged += this.#p0c;
			}
			while (false);
			this.GridLineAnnotationsVisibilityLayer = this.#x0c(#Smb, this.GridVisibilityLayer);
			this.GridLineAnnotationsVisibilityLayer.PropertyChanged += this.#o0c;
			this.GridVisibilityLayer.AddDependentLayer(this.GridLineAnnotationsVisibilityLayer);
			this.NodeNumbersVisibilityLayer = this.#x0c(#Smb, this.GridVisibilityLayer);
			this.ElementNumbersVisibilityLayer = this.#x0c(#Smb, this.GridVisibilityLayer);
		}

		// Token: 0x0600697D RID: 27005 RVA: 0x00053BDF File Offset: 0x00051DDF
		private VisibilityLayer #x0c(IModelEditorControl #Smb, VisibilityLayer #y0c)
		{
			VisibilityLayer visibilityLayer = new VisibilityLayer(#Smb, #y0c);
			PropertyChangedEventHandler value = new PropertyChangedEventHandler(this.#n0c);
			if (4 != 0)
			{
				visibilityLayer.PropertyChanged += value;
			}
			return visibilityLayer;
		}

		// Token: 0x0600697E RID: 27006 RVA: 0x0019A6A4 File Offset: 0x001988A4
		private void #z0c(IList<Tuple<Point3D, Point3D>> #pYc, IList<Tuple<Point3D, Point3D>> #qYc)
		{
			IMultilineDrawingResult multilineDrawingResult = this.#t;
			IMultilineDrawingResult multilineDrawingResult2;
			if (3 != 0)
			{
				multilineDrawingResult2 = multilineDrawingResult;
			}
			IMultilineDrawingResult multilineDrawingResult3 = this.#u;
			IMultilineDrawingResult multilineDrawingResult4;
			if (3 != 0)
			{
				multilineDrawingResult4 = multilineDrawingResult3;
			}
			VisibilityLayer visibilityLayer2;
			for (;;)
			{
				VisibilityLayer visibilityLayer = this.GridLineAnnotationsVisibilityLayer;
				if (!false)
				{
					visibilityLayer2 = visibilityLayer;
				}
				if (7 != 0 && !#pYc.Any<Tuple<Point3D, Point3D>>())
				{
					if (!false)
					{
						break;
					}
				}
				else
				{
					#S0c #S0c = this.DrawingResultsManager;
					bool #JS = false;
					IMultilineDrawingResult #YQc = multilineDrawingResult2;
					IMultilineDrawingResult #rYc = multilineDrawingResult4;
					VisibilityLayer #0Xc = visibilityLayer2;
					if (!false)
					{
						#S0c.#oYc(#pYc, #qYc, #JS, #YQc, #rYc, #0Xc);
					}
				}
				if (!false)
				{
					goto Block_4;
				}
			}
			VisibilityLayer visibilityLayer3 = visibilityLayer2;
			IMultilineDrawingResult multilineDrawingResult5 = multilineDrawingResult2;
			if (-1 != 0)
			{
				visibilityLayer3.Remove(multilineDrawingResult5);
			}
			return;
			Block_4:
			IModelEditorControl modelVisualizationControl = base.View.ModelVisualizationControl;
			IMultilineDrawingResult annotationConnectors = this.#t;
			if (5 != 0)
			{
				modelVisualizationControl.AnnotationConnectors = annotationConnectors;
			}
			base.View.ModelVisualizationControl.DarkerAnnotationConnectors = this.#u;
		}

		// Token: 0x0600697F RID: 27007 RVA: 0x0019A754 File Offset: 0x00198954
		private Tuple<Point3D, Point3D> #A0c(GridLineDefinitionModel #bsc, bool #JS)
		{
			if (!string.IsNullOrEmpty(#bsc.Label))
			{
				VisibilityLayer visibilityLayer;
				if (!#JS)
				{
					if (false || false)
					{
						goto IL_0D;
					}
					visibilityLayer = this.GridLineAnnotationsVisibilityLayer;
				}
				else
				{
					visibilityLayer = this.GridVisibilityLayer;
				}
				VisibilityLayer #0Xc;
				if (6 != 0)
				{
					#0Xc = visibilityLayer;
				}
				return this.DrawingResultsManager.#sYc(#bsc, #JS, #0Xc, this.#y, this.#s, this.#v);
			}
			IL_0D:
			return null;
		}

		// Token: 0x06006980 RID: 27008 RVA: 0x0019A7B0 File Offset: 0x001989B0
		private void #B0c(bool #JS)
		{
			HashSet<IAnnotationDrawingResult>.Enumerator enumerator2;
			while (#JS)
			{
				HashSet<IAnnotationDrawingResult>.Enumerator enumerator = this.#v.GetEnumerator();
				if (!false)
				{
					enumerator2 = enumerator;
				}
				try
				{
					while (enumerator2.MoveNext())
					{
						IAnnotationDrawingResult annotationDrawingResult = enumerator2.Current;
						IAnnotationDrawingResult annotationDrawingResult2;
						if (!false)
						{
							annotationDrawingResult2 = annotationDrawingResult;
						}
						VisibilityLayer visibilityLayer = this.GridVisibilityLayer;
						IAnnotationDrawingResult annotationDrawingResult3 = annotationDrawingResult2;
						if (!false)
						{
							visibilityLayer.Remove(annotationDrawingResult3);
						}
					}
				}
				finally
				{
					if (8 != 0)
					{
						((IDisposable)enumerator2).Dispose();
					}
				}
				HashSet<IAnnotationDrawingResult> hashSet = this.#v;
				if (4 != 0)
				{
					hashSet.Clear();
				}
				if (false)
				{
					do
					{
						IL_C0:
						this.GridLineAnnotationsVisibilityLayer.Remove(this.#t);
						this.#s.Clear();
					}
					while (3 == 0);
					return;
				}
				VisibilityLayer visibilityLayer2 = this.GridVisibilityLayer;
				IMultilineDrawingResult multilineDrawingResult = this.#w;
				if (!false)
				{
					visibilityLayer2.Remove(multilineDrawingResult);
				}
				if (!false)
				{
					return;
				}
			}
			HashSet<IAnnotationDrawingResult>.Enumerator enumerator3 = this.#s.GetEnumerator();
			if (3 != 0)
			{
				enumerator2 = enumerator3;
			}
			try
			{
				while (enumerator2.MoveNext())
				{
					IAnnotationDrawingResult annotationDrawingResult4 = enumerator2.Current;
					this.GridLineAnnotationsVisibilityLayer.Remove(annotationDrawingResult4);
				}
			}
			finally
			{
				((IDisposable)enumerator2).Dispose();
			}
			goto IL_C0;
		}

		// Token: 0x06006981 RID: 27009 RVA: 0x0019A8D8 File Offset: 0x00198AD8
		private bool #C0c(IList<GridLineDefinitionModel> #atc)
		{
			for (;;)
			{
				IL_00:
				int num = #atc.Count;
				int count = this.#d.Count;
				IL_11:
				while (num == count || false)
				{
					int num2 = 0;
					int num3;
					if (7 != 0)
					{
						num3 = num2;
					}
					for (;;)
					{
						int num4 = num = num3;
						int num5 = count = #atc.Count;
						if (4 == 0)
						{
							goto IL_11;
						}
						if (num4 >= num5)
						{
							return false;
						}
						if (#atc[num3].CalculatedHashCode != this.#d[num3])
						{
							break;
						}
						int num6 = num3 + 1;
						if (!false)
						{
							num3 = num6;
						}
					}
					if (!false)
					{
						goto Block_4;
					}
					goto IL_00;
				}
				break;
			}
			int result;
			int num7 = result = 1;
			if (num7 != 0)
			{
				return num7 != 0;
			}
			return result != 0;
			Block_4:
			result = 1;
			return result != 0;
		}

		// Token: 0x06006982 RID: 27010 RVA: 0x0019A940 File Offset: 0x00198B40
		private void #D0c()
		{
			BoundingBoxData boundingBoxData2;
			if (-1 != 0)
			{
				bool flag2;
				bool flag = flag2 = this.#s.Any<IAnnotationDrawingResult>();
				if (!false)
				{
					if (!flag)
					{
						goto IL_1B;
					}
					flag2 = this.AreGridLineAnnotationsVisible;
				}
				if (flag2)
				{
					BoundingBoxData boundingBoxData = AnnotationsHelper.#YJc(this.#s, base.View.ModelVisualizationControl.EditorWorkspaceSize, this.#y);
					if (6 != 0)
					{
						boundingBoxData2 = boundingBoxData;
					}
					if (!base.View.ModelVisualizationControl.EditorWorkspaceWithAnnotationsSize.#e(boundingBoxData2))
					{
						goto IL_79;
					}
					return;
				}
				IL_1B:
				IModelEditorControl modelVisualizationControl = base.View.ModelVisualizationControl;
				BoundingBoxData editorWorkspaceSize = base.View.ModelVisualizationControl.EditorWorkspaceSize;
				if (2 != 0)
				{
					modelVisualizationControl.EditorWorkspaceWithAnnotationsSize = editorWorkspaceSize;
				}
				return;
			}
			IL_79:
			IModelEditorControl modelVisualizationControl2 = base.View.ModelVisualizationControl;
			BoundingBoxData editorWorkspaceWithAnnotationsSize = boundingBoxData2;
			if (8 != 0)
			{
				modelVisualizationControl2.EditorWorkspaceWithAnnotationsSize = editorWorkspaceWithAnnotationsSize;
			}
		}

		// Token: 0x06006983 RID: 27011 RVA: 0x0019A9E8 File Offset: 0x00198BE8
		private Tuple<PolygonsDrawingData, IPolygonsDrawingResult> #E0c(ShapeDataModel #XDc, double #hYc, double #iYc, double #jYc, Color? #kYc, Color? #lYc)
		{
			int hashCode = #XDc.GetHashCode();
			int num;
			if (!false)
			{
				num = hashCode;
			}
			IPolygonsDrawingResult polygonsDrawingResult = this.#g.#F1d(num);
			IPolygonsDrawingResult polygonsDrawingResult2;
			if (4 != 0)
			{
				polygonsDrawingResult2 = polygonsDrawingResult;
			}
			if (7 != 0)
			{
				this.#8ob(#XDc);
			}
			if (polygonsDrawingResult2 == null)
			{
				IPolygonsDrawingResult polygonsDrawingResult3 = this.DrawingResultsFactory.CreatePolygonsDrawingResult();
				if (-1 != 0)
				{
					polygonsDrawingResult2 = polygonsDrawingResult3;
				}
				Dictionary<int, IPolygonsDrawingResult> dictionary = this.#g;
				int key = num;
				IPolygonsDrawingResult value = polygonsDrawingResult2;
				if (true)
				{
					dictionary.Add(key, value);
				}
			}
			return new Tuple<PolygonsDrawingData, IPolygonsDrawingResult>(this.DrawingResultsManager.#gYc(#XDc, #hYc, #iYc, #jYc, #kYc, #lYc), polygonsDrawingResult2);
		}

		// Token: 0x06006984 RID: 27012 RVA: 0x0019AA68 File Offset: 0x00198C68
		private Tuple<PolygonsDrawingData, IPolygonsDrawingResult> #F0c(ShapeDataModel #XDc, double #hYc, double #iYc, double #jYc, Color? #kYc, Color? #lYc)
		{
			int hashCode = #XDc.GetHashCode();
			int num;
			if (!false)
			{
				num = hashCode;
			}
			IPolygonsDrawingResult polygonsDrawingResult = this.#g.#F1d(num);
			IPolygonsDrawingResult polygonsDrawingResult2;
			if (4 != 0)
			{
				polygonsDrawingResult2 = polygonsDrawingResult;
			}
			if (7 != 0)
			{
				this.#8ob(#XDc);
			}
			if (polygonsDrawingResult2 == null)
			{
				IPolygonsDrawingResult polygonsDrawingResult3 = this.DrawingResultsFactory.CreatePolygonsDrawingResult();
				if (-1 != 0)
				{
					polygonsDrawingResult2 = polygonsDrawingResult3;
				}
				Dictionary<int, IPolygonsDrawingResult> dictionary = this.#g;
				int key = num;
				IPolygonsDrawingResult value = polygonsDrawingResult2;
				if (true)
				{
					dictionary.Add(key, value);
				}
			}
			return new Tuple<PolygonsDrawingData, IPolygonsDrawingResult>(this.DrawingResultsManager.#mYc(#XDc, #hYc, #iYc, #jYc, #kYc, #lYc), polygonsDrawingResult2);
		}

		// Token: 0x06006985 RID: 27013 RVA: 0x0019AAE8 File Offset: 0x00198CE8
		private Tuple<PolygonsDrawingData, IPolygonsDrawingResult> #G0c(ShapeDataModel #XDc, double #hYc, double #iYc, double #jYc, Color? #kYc, Color? #lYc)
		{
			int hashCode = #XDc.GetHashCode();
			int num;
			if (!false)
			{
				num = hashCode;
			}
			IPolygonsDrawingResult polygonsDrawingResult = this.#j.#F1d(num);
			IPolygonsDrawingResult polygonsDrawingResult2;
			if (4 != 0)
			{
				polygonsDrawingResult2 = polygonsDrawingResult;
			}
			if (7 != 0)
			{
				this.#YZc(#XDc);
			}
			if (polygonsDrawingResult2 == null)
			{
				IPolygonsDrawingResult polygonsDrawingResult3 = this.DrawingResultsFactory.CreatePolygonsDrawingResult();
				if (-1 != 0)
				{
					polygonsDrawingResult2 = polygonsDrawingResult3;
				}
				Dictionary<int, IPolygonsDrawingResult> dictionary = this.#j;
				int key = num;
				IPolygonsDrawingResult value = polygonsDrawingResult2;
				if (true)
				{
					dictionary.Add(key, value);
				}
			}
			return new Tuple<PolygonsDrawingData, IPolygonsDrawingResult>(this.DrawingResultsManager.#nYc(#XDc, #hYc, #iYc, #jYc, #kYc, #lYc), polygonsDrawingResult2);
		}

		// Token: 0x06006986 RID: 27014 RVA: 0x0019AB68 File Offset: 0x00198D68
		private void #H0c()
		{
			if (this.OrthogonalFencesVisibilityLayer.IsVisible)
			{
				double num2;
				if (!false)
				{
					double num = 1.0 / base.View.ModelVisualizationControl.CalculateViewScale();
					if (!false)
					{
						num2 = num;
					}
				}
				if (!false)
				{
					IDashedMultilineDrawingResult dashedMultilineDrawingResult = this.#p;
					double segmentLength = 2.25 * num2;
					if (!false)
					{
						dashedMultilineDrawingResult.SegmentLength = segmentLength;
					}
					if (!false)
					{
						return;
					}
				}
			}
		}

		// Token: 0x06006987 RID: 27015 RVA: 0x0019ABCC File Offset: 0x00198DCC
		private void #I0c(ShapeDataModel #XDc, bool #2Zc, Color #lYc)
		{
			string #R0d = #Phc.#3hc(107435029);
			StructurePoint.CoreAssets.Infrastructure.Exceptions.Component #x6c = StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUIFramework;
			string #Qic = #Phc.#3hc(107435329);
			if (!false)
			{
				#X0d.#V0d(#XDc, #R0d, #x6c, #Qic);
			}
			int hashCode = #XDc.GetHashCode();
			int num;
			if (-1 != 0)
			{
				num = hashCode;
			}
			if (true)
			{
				this.#5Zc(#XDc);
			}
			ShapeDataModel shapeDataModel = new ShapeDataModel(this.UndoManager, #XDc, this.AssignmentsFactory, false);
			ShapeDataModel shapeDataModel2;
			if (!false)
			{
				shapeDataModel2 = shapeDataModel;
			}
			if (!#2Zc)
			{
				Color transparent = Colors.Transparent;
			}
			ShapeDataModel #XDc2 = shapeDataModel2;
			double #hYc = 0.0171;
			double #iYc = 0.0191;
			double #jYc = 0.0211;
			Color? #kYc = new Color?(this.SettingsManager.VisualizationSelectedShapeEdgeColor);
			Color? #lYc2 = new Color?(#lYc);
			if (7 != 0)
			{
				this.#QZc(#XDc2, #hYc, #iYc, #jYc, #kYc, #lYc2);
			}
			Dictionary<int, ShapeDataModel> dictionary = this.#h;
			int key = num;
			ShapeDataModel value = shapeDataModel2;
			if (7 != 0)
			{
				dictionary.Add(key, value);
			}
		}

		// Token: 0x04002B1B RID: 11035
		private readonly #R2c #a;

		// Token: 0x04002B1C RID: 11036
		private readonly IMultilineDrawingResult #b;

		// Token: 0x04002B1D RID: 11037
		private readonly IMultilineDrawingResult #c;

		// Token: 0x04002B1E RID: 11038
		private readonly List<int> #d = new List<int>();

		// Token: 0x04002B1F RID: 11039
		private readonly IMultilineDrawingResult #e;

		// Token: 0x04002B20 RID: 11040
		private readonly HashSet<GridLineDefinitionModel> #f;

		// Token: 0x04002B21 RID: 11041
		private readonly Dictionary<int, IPolygonsDrawingResult> #g = new Dictionary<int, IPolygonsDrawingResult>();

		// Token: 0x04002B22 RID: 11042
		private readonly Dictionary<int, ShapeDataModel> #h = new Dictionary<int, ShapeDataModel>();

		// Token: 0x04002B23 RID: 11043
		private readonly Dictionary<int, IPointsDrawingResult> #i = new Dictionary<int, IPointsDrawingResult>();

		// Token: 0x04002B24 RID: 11044
		private readonly Dictionary<int, IPolygonsDrawingResult> #j = new Dictionary<int, IPolygonsDrawingResult>();

		// Token: 0x04002B25 RID: 11045
		private readonly IPointsDrawingResult #k;

		// Token: 0x04002B26 RID: 11046
		private readonly IPointsDrawingResult #l;

		// Token: 0x04002B27 RID: 11047
		private readonly HashSet<StructurePoint.CoreAssets.Infrastructure.Data.Point> #m;

		// Token: 0x04002B28 RID: 11048
		private readonly IMultilineDrawingResult #n;

		// Token: 0x04002B29 RID: 11049
		private readonly IPointsDrawingResult #o;

		// Token: 0x04002B2A RID: 11050
		private readonly IDashedMultilineDrawingResult #p;

		// Token: 0x04002B2B RID: 11051
		private readonly IMultilineDrawingResult #q;

		// Token: 0x04002B2C RID: 11052
		private readonly HashSet<LinearObject> #r;

		// Token: 0x04002B2D RID: 11053
		private readonly HashSet<IAnnotationDrawingResult> #s;

		// Token: 0x04002B2E RID: 11054
		private readonly IMultilineDrawingResult #t;

		// Token: 0x04002B2F RID: 11055
		private readonly IMultilineDrawingResult #u;

		// Token: 0x04002B30 RID: 11056
		private readonly HashSet<IAnnotationDrawingResult> #v;

		// Token: 0x04002B31 RID: 11057
		private readonly IMultilineDrawingResult #w;

		// Token: 0x04002B32 RID: 11058
		private #k8c<ITreeItemData> #x = new CustomObservableCollection<ITreeItemData>();

		// Token: 0x04002B33 RID: 11059
		private double #y;

		// Token: 0x04002B34 RID: 11060
		private Visibility #z;

		// Token: 0x04002B35 RID: 11061
		private ToolsPanelPosition #A;

		// Token: 0x04002B36 RID: 11062
		private bool #B;

		// Token: 0x04002B37 RID: 11063
		private double #C;

		// Token: 0x04002B38 RID: 11064
		private double #D;

		// Token: 0x04002B39 RID: 11065
		private bool #E = true;

		// Token: 0x04002B3A RID: 11066
		private bool #F;

		// Token: 0x04002B3B RID: 11067
		private bool #G;

		// Token: 0x04002B3C RID: 11068
		[CompilerGenerated]
		private #S0c #H;

		// Token: 0x04002B3D RID: 11069
		[CompilerGenerated]
		private #6Gc #I;

		// Token: 0x04002B3E RID: 11070
		[CompilerGenerated]
		private #bDc #J;

		// Token: 0x04002B3F RID: 11071
		[CompilerGenerated]
		private IDrawingResultsFactory #K;

		// Token: 0x04002B40 RID: 11072
		[CompilerGenerated]
		private IPolygonsDrawingEngine #L;

		// Token: 0x04002B41 RID: 11073
		[CompilerGenerated]
		private #1Wc #M;

		// Token: 0x04002B42 RID: 11074
		[CompilerGenerated]
		private VisibilityLayer #N;

		// Token: 0x04002B43 RID: 11075
		[CompilerGenerated]
		private VisibilityLayer #O;

		// Token: 0x04002B44 RID: 11076
		[CompilerGenerated]
		private VisibilityLayer #P;

		// Token: 0x04002B45 RID: 11077
		[CompilerGenerated]
		private VisibilityLayer #Q;

		// Token: 0x04002B46 RID: 11078
		[CompilerGenerated]
		private VisibilityLayer #R;

		// Token: 0x04002B47 RID: 11079
		[CompilerGenerated]
		private VisibilityLayer #S;

		// Token: 0x04002B48 RID: 11080
		[CompilerGenerated]
		private VisibilityLayer #T;

		// Token: 0x04002B49 RID: 11081
		[CompilerGenerated]
		private EventHandler #U;

		// Token: 0x04002B4A RID: 11082
		[CompilerGenerated]
		private ObservableCollection<ICheckBoxData> #V;

		// Token: 0x04002B4B RID: 11083
		[CompilerGenerated]
		private Visibility #W;

		// Token: 0x04002B4C RID: 11084
		[CompilerGenerated]
		private ObservableCollection<object> #X;

		// Token: 0x04002B4D RID: 11085
		[CompilerGenerated]
		private VisibilityLayer #Y;

		// Token: 0x04002B4E RID: 11086
		[CompilerGenerated]
		private VisibilityLayer #Z;

		// Token: 0x04002B4F RID: 11087
		[CompilerGenerated]
		private EventHandler<#XXc> #0;

		// Token: 0x02000CA7 RID: 3239
		[CompilerGenerated]
		private sealed class #Kbd
		{
			// Token: 0x0600698D RID: 27021 RVA: 0x00053C15 File Offset: 0x00051E15
			internal void #Jbd()
			{
				#U0c #U0c = this.#a.View;
				StructurePoint.CoreAssets.Infrastructure.Data.Point position = this.#b;
				if (!false)
				{
					#U0c.ShowContextMenu(position);
				}
				ModelEditorViewModel modelEditorViewModel = this.#a;
				bool #f = true;
				if (!false)
				{
					modelEditorViewModel.IsContextMenuOpen = #f;
				}
				this.#a.#E = true;
			}

			// Token: 0x04002B53 RID: 11091
			public ModelEditorViewModel #a;

			// Token: 0x04002B54 RID: 11092
			public StructurePoint.CoreAssets.Infrastructure.Data.Point #b;
		}

		// Token: 0x02000CA8 RID: 3240
		[CompilerGenerated]
		private sealed class #Obd
		{
			// Token: 0x0600698F RID: 27023 RVA: 0x00053C53 File Offset: 0x00051E53
			internal bool #Nbd(GridLineDefinitionModel #c9c)
			{
				return #c9c.Label == this.#a.Text;
			}

			// Token: 0x04002B55 RID: 11093
			public IAnnotationDrawingResult #a;
		}

		// Token: 0x02000CA9 RID: 3241
		[CompilerGenerated]
		private sealed class #Qbd
		{
			// Token: 0x06006991 RID: 27025 RVA: 0x00053C6B File Offset: 0x00051E6B
			internal bool #Pbd(IAnnotationDrawingResult #Rf)
			{
				return #Rf.Text == this.#a.Label;
			}

			// Token: 0x04002B56 RID: 11094
			public GridLineDefinitionModel #a;
		}
	}
}
