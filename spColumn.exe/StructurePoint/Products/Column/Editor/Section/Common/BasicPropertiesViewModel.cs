using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using #04;
using #12e;
using #5Ve;
using #7hc;
using #9I;
using #aHb;
using #eU;
using #gCc;
using #gMe;
using #hZe;
using #lH;
using #qJ;
using #y6e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Communication;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.NewCapacityRatio;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.Validation;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.CoreAssets.Logger;
using StructurePoint.Products.Column.Model.Entities;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.Viewports.API;
using Telerik.Windows.Controls;
using Telerik.Windows.Data;

namespace StructurePoint.Products.Column.Editor.Section.Common
{
	// Token: 0x0200061B RID: 1563
	internal sealed class BasicPropertiesViewModel : #TH, INotifyPropertyChanged, #fIb
	{
		// Token: 0x060034F0 RID: 13552 RVA: 0x00106A58 File Offset: 0x00104C58
		public BasicPropertiesViewModel(IExtendedServices services, #qW designEngineService, #8I solverViewModel, #zJ designEngineAvailabilityChecker)
		{
			this.#m = services;
			this.#w = designEngineService;
			this.#h = solverViewModel;
			this.#s = new DelegateCommand(new Action<object>(this.#YIb), new Predicate<object>(this.#KIb));
			this.#t = new DelegateCommand(new Action<object>(this.#TIb), new Predicate<object>(this.#NIb));
			this.#u = new DelegateCommand(new Action<object>(this.#UIb), new Predicate<object>(this.#MIb));
			this.#o = new DelegateCommand(new Action<object>(this.#SIb), new Predicate<object>(this.#PIb));
			this.#p = new DelegateCommand(new Action<object>(this.#RIb), new Predicate<object>(this.#OIb));
			this.#v = new DelegateCommand(new Action<object>(this.#IIb), new Predicate<object>(this.#JIb));
			this.#n = new DelegateCommand(new Action<object>(this.#GIb), new Predicate<object>(this.#HIb));
			designEngineAvailabilityChecker.StateChanged += this.#0g;
			designEngineService.PropertyChanged += this.#DIb;
			services.UndoManager.CompositeActionCompleted += this.#Lh;
			services.UndoManager.UndoStackChanged += this.#1g;
			services.MessageBus.SolveCompleted += this.#Ch;
			services.Project.ModelChanging += this.#5Eb;
			services.GuiController.PropertyChanged += this.#wk;
		}

		// Token: 0x17001086 RID: 4230
		// (get) Token: 0x060034F1 RID: 13553 RVA: 0x0000A816 File Offset: 0x00008A16
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x17001087 RID: 4231
		// (get) Token: 0x060034F2 RID: 13554 RVA: 0x0002E661 File Offset: 0x0002C861
		public IExtendedServices Services { get; }

		// Token: 0x17001088 RID: 4232
		// (get) Token: 0x060034F3 RID: 13555 RVA: 0x0002E66D File Offset: 0x0002C86D
		// (set) Token: 0x060034F4 RID: 13556 RVA: 0x00106C20 File Offset: 0x00104E20
		public bool IsRunningDesignTrace
		{
			get
			{
				return this.#k;
			}
			set
			{
				if (this.#k != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107352764));
					this.#k = value;
					this.#vh();
					base.RaisePropertyChanged(#Phc.#3hc(107352764));
				}
			}
		}

		// Token: 0x17001089 RID: 4233
		// (get) Token: 0x060034F5 RID: 13557 RVA: 0x0002E679 File Offset: 0x0002C879
		// (set) Token: 0x060034F6 RID: 13558 RVA: 0x00106C70 File Offset: 0x00104E70
		public bool IsDesignTracePopupOpen
		{
			get
			{
				return this.#l;
			}
			set
			{
				foreach (IModelEditorViewport modelEditorViewport in this.Services.ViewportsManager.Viewports.OfType<IModelEditorViewport>())
				{
					modelEditorViewport.Editor.SupportBeginMouseMove = !value;
				}
				if (this.#l != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107352735));
					this.#l = value;
					this.#vh();
					base.RaisePropertyChanged(#Phc.#3hc(107352735));
				}
			}
		}

		// Token: 0x1700108A RID: 4234
		// (get) Token: 0x060034F7 RID: 13559 RVA: 0x0002E685 File Offset: 0x0002C885
		public DelegateCommand StopDesignTraceCommand { get; }

		// Token: 0x1700108B RID: 4235
		// (get) Token: 0x060034F8 RID: 13560 RVA: 0x0002E691 File Offset: 0x0002C891
		public DelegateCommand PreviousStepCommand { get; }

		// Token: 0x1700108C RID: 4236
		// (get) Token: 0x060034F9 RID: 13561 RVA: 0x0002E69D File Offset: 0x0002C89D
		public DelegateCommand FirstStepCommand { get; }

		// Token: 0x1700108D RID: 4237
		// (get) Token: 0x060034FA RID: 13562 RVA: 0x0002E6A9 File Offset: 0x0002C8A9
		public RadObservableCollection<DesignTraceMessage> DesignTraceMessages { get; }

		// Token: 0x1700108E RID: 4238
		// (get) Token: 0x060034FB RID: 13563 RVA: 0x0002E6B5 File Offset: 0x0002C8B5
		// (set) Token: 0x060034FC RID: 13564 RVA: 0x0002E6C1 File Offset: 0x0002C8C1
		public bool IsActive { get; private set; }

		// Token: 0x1700108F RID: 4239
		// (get) Token: 0x060034FD RID: 13565 RVA: 0x0002E6D2 File Offset: 0x0002C8D2
		// (set) Token: 0x060034FE RID: 13566 RVA: 0x0002E6DE File Offset: 0x0002C8DE
		public string MinClearBarSpacing
		{
			get
			{
				return this.#b;
			}
			set
			{
				this.SetProperty<string>(ref this.#b, value, #Phc.#3hc(107352702));
			}
		}

		// Token: 0x17001090 RID: 4240
		// (get) Token: 0x060034FF RID: 13567 RVA: 0x0002E704 File Offset: 0x0002C904
		// (set) Token: 0x06003500 RID: 13568 RVA: 0x0002E710 File Offset: 0x0002C910
		public string GrossArea
		{
			get
			{
				return this.#c;
			}
			set
			{
				this.SetProperty<string>(ref this.#c, value, #Phc.#3hc(107352645));
			}
		}

		// Token: 0x17001091 RID: 4241
		// (get) Token: 0x06003501 RID: 13569 RVA: 0x0002E736 File Offset: 0x0002C936
		// (set) Token: 0x06003502 RID: 13570 RVA: 0x0002E742 File Offset: 0x0002C942
		public string TotalAs
		{
			get
			{
				return this.#d;
			}
			set
			{
				this.SetProperty<string>(ref this.#d, value, #Phc.#3hc(107352664));
			}
		}

		// Token: 0x17001092 RID: 4242
		// (get) Token: 0x06003503 RID: 13571 RVA: 0x0002E768 File Offset: 0x0002C968
		// (set) Token: 0x06003504 RID: 13572 RVA: 0x0002E774 File Offset: 0x0002C974
		public string Rho
		{
			get
			{
				return this.#e;
			}
			set
			{
				this.SetProperty<string>(ref this.#e, value, #Phc.#3hc(107352619));
			}
		}

		// Token: 0x17001093 RID: 4243
		// (get) Token: 0x06003505 RID: 13573 RVA: 0x0002E79A File Offset: 0x0002C99A
		// (set) Token: 0x06003506 RID: 13574 RVA: 0x0002E7A6 File Offset: 0x0002C9A6
		public string MaxCapacityRatio
		{
			get
			{
				return this.#f;
			}
			set
			{
				this.SetProperty<string>(ref this.#f, value, #Phc.#3hc(107352614));
			}
		}

		// Token: 0x17001094 RID: 4244
		// (get) Token: 0x06003507 RID: 13575 RVA: 0x0002E7CC File Offset: 0x0002C9CC
		// (set) Token: 0x06003508 RID: 13576 RVA: 0x0002E7D8 File Offset: 0x0002C9D8
		public bool IsCapacityRatioExceeded
		{
			get
			{
				return this.#g;
			}
			set
			{
				this.SetProperty<bool>(ref this.#g, value, #Phc.#3hc(107352589));
			}
		}

		// Token: 0x17001095 RID: 4245
		// (get) Token: 0x06003509 RID: 13577 RVA: 0x0002E7FE File Offset: 0x0002C9FE
		// (set) Token: 0x0600350A RID: 13578 RVA: 0x0002E80A File Offset: 0x0002CA0A
		public bool IsAreaOfSteelExceeded
		{
			get
			{
				return this.#a;
			}
			set
			{
				this.SetProperty<bool>(ref this.#a, value, #Phc.#3hc(107353068));
			}
		}

		// Token: 0x17001096 RID: 4246
		// (get) Token: 0x0600350B RID: 13579 RVA: 0x0002E830 File Offset: 0x0002CA30
		// (set) Token: 0x0600350C RID: 13580 RVA: 0x0002E83C File Offset: 0x0002CA3C
		public bool IsMinClearRebarSpacingExceeded
		{
			get
			{
				return this.#i;
			}
			set
			{
				this.SetProperty<bool>(ref this.#i, value, #Phc.#3hc(107353039));
			}
		}

		// Token: 0x17001097 RID: 4247
		// (get) Token: 0x0600350D RID: 13581 RVA: 0x00106D28 File Offset: 0x00104F28
		public bool DesignTrace
		{
			get
			{
				return this.Services.Project.Model.Options.ProblemType == ProblemType.Design && this.DesignEngineService.DesignEngine != null && this.DesignEngineService.TraceResults.Any<#4Ve>();
			}
		}

		// Token: 0x17001098 RID: 4248
		// (get) Token: 0x0600350E RID: 13582 RVA: 0x0002E862 File Offset: 0x0002CA62
		public #oW Project
		{
			get
			{
				return this.Services.Project;
			}
		}

		// Token: 0x17001099 RID: 4249
		// (get) Token: 0x0600350F RID: 13583 RVA: 0x0002E87B File Offset: 0x0002CA7B
		public DelegateCommand ExecuteCommand { get; }

		// Token: 0x1700109A RID: 4250
		// (get) Token: 0x06003510 RID: 13584 RVA: 0x0002E887 File Offset: 0x0002CA87
		public DelegateCommand LastStepCommand { get; }

		// Token: 0x1700109B RID: 4251
		// (get) Token: 0x06003511 RID: 13585 RVA: 0x0002E893 File Offset: 0x0002CA93
		public DelegateCommand NextStepCommand { get; }

		// Token: 0x1700109C RID: 4252
		// (get) Token: 0x06003512 RID: 13586 RVA: 0x0002E89F File Offset: 0x0002CA9F
		public DelegateCommand RunDesignTraceCommand { get; }

		// Token: 0x1700109D RID: 4253
		// (get) Token: 0x06003513 RID: 13587 RVA: 0x0002E8AB File Offset: 0x0002CAAB
		// (set) Token: 0x06003514 RID: 13588 RVA: 0x0002E8B7 File Offset: 0x0002CAB7
		public bool IsEnabled
		{
			get
			{
				return this.#j;
			}
			private set
			{
				if (this.#j != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107408148));
					this.#j = value;
					base.RaisePropertyChanged(#Phc.#3hc(107408148));
				}
			}
		}

		// Token: 0x1700109E RID: 4254
		// (get) Token: 0x06003515 RID: 13589 RVA: 0x0002E8F5 File Offset: 0x0002CAF5
		private int StepIndex
		{
			get
			{
				return this.DesignEngineService.CurrentTraceStepIndex;
			}
		}

		// Token: 0x1700109F RID: 4255
		// (get) Token: 0x06003516 RID: 13590 RVA: 0x0002E90E File Offset: 0x0002CB0E
		private int StepsCount
		{
			get
			{
				return this.DesignEngineService.TraceResults.Count;
			}
		}

		// Token: 0x170010A0 RID: 4256
		// (get) Token: 0x06003517 RID: 13591 RVA: 0x0002E92C File Offset: 0x0002CB2C
		private int MaxStepIndex
		{
			get
			{
				return this.StepsCount - 1;
			}
		}

		// Token: 0x170010A1 RID: 4257
		// (get) Token: 0x06003518 RID: 13592 RVA: 0x00106D80 File Offset: 0x00104F80
		public bool IsCapacityRatioEnabled
		{
			get
			{
				LoadType loadType = (this.Project.Model.Options.ProblemType == ProblemType.Design) ? this.Project.Model.Options.DesignLoad : this.Project.Model.Options.InvestigationLoad;
				return loadType != LoadType.Undefined && loadType != LoadType.NoLoads && ((loadType == LoadType.Service && this.Project.Model.ServiceLoads.Any<ServiceLoad>()) || (loadType == LoadType.Factored && this.Project.Model.FactoredLoads.Any<FactoredLoad>()));
			}
		}

		// Token: 0x170010A2 RID: 4258
		// (get) Token: 0x06003519 RID: 13593 RVA: 0x0002E93E File Offset: 0x0002CB3E
		public #qW DesignEngineService { get; }

		// Token: 0x170010A3 RID: 4259
		// (get) Token: 0x0600351A RID: 13594 RVA: 0x0002E94A File Offset: 0x0002CB4A
		// (set) Token: 0x0600351B RID: 13595 RVA: 0x0002E956 File Offset: 0x0002CB56
		public bool ArePropertiesEnabled
		{
			get
			{
				return this.#x;
			}
			set
			{
				this.SetProperty<bool>(ref this.#x, value, #Phc.#3hc(107352998));
			}
		}

		// Token: 0x0600351C RID: 13596 RVA: 0x0002E97C File Offset: 0x0002CB7C
		public void #eIb()
		{
			if (this.#JIb(null))
			{
				this.#IIb(null);
			}
		}

		// Token: 0x0600351D RID: 13597 RVA: 0x0002E99A File Offset: 0x0002CB9A
		public void #5b()
		{
			this.IsActive = true;
			if (this.IsRunningDesignTrace)
			{
				this.IsDesignTracePopupOpen = true;
			}
			this.#vh();
		}

		// Token: 0x0600351E RID: 13598 RVA: 0x0002E9C4 File Offset: 0x0002CBC4
		public void #0kb()
		{
			this.IsActive = false;
			this.IsDesignTracePopupOpen = false;
		}

		// Token: 0x0600351F RID: 13599 RVA: 0x00106E34 File Offset: 0x00105034
		public void #dIb()
		{
			#4Ve #4Ve = this.DesignEngineService.CurrentTraceStep;
			bool flag = this.DesignTrace && #4Ve != null;
			if (flag)
			{
				this.#dIb(#4Ve.GeometryProperties, false, #4Ve);
				string text;
				if (#4Ve.CapacityRatio != null)
				{
					float? num = #4Ve.CapacityRatio;
					float num2 = #iTe.MinCapacityRatio;
					if (num.GetValueOrDefault() > num2 & num != null)
					{
						text = #4Ve.CapacityRatio.Value.ToString(#Phc.#3hc(107408811));
						goto IL_8D;
					}
				}
				text = Strings.StringTripleHyphen;
				IL_8D:
				this.MaxCapacityRatio = text;
				bool flag2;
				if (#4Ve.CapacityRatio == null || #4Ve.IsFinalDesign)
				{
					flag2 = #4Ve.Messages.Any(new Func<Message, bool>(BasicPropertiesViewModel.<>c.<>9.#P0h));
				}
				else
				{
					flag2 = true;
				}
				this.IsCapacityRatioExceeded = flag2;
				if (#4Ve.CapacityRatio == null && #4Ve == this.DesignEngineService.TraceResults.Last<#4Ve>())
				{
					this.#EIb();
				}
				this.#LIb();
				this.IsEnabled = true;
				return;
			}
			if (this.DesignEngineService.DesignEngine != null)
			{
				this.IsEnabled = true;
				this.#dIb(this.DesignEngineService.DesignEngine.GeometryProperties, false, this.DesignEngineService.TraceResults.LastOrDefault<#4Ve>());
				this.#EIb();
				return;
			}
			if (this.Project.Model.Options.ProblemType != ProblemType.Investigation || (this.Project.Model.Options.SectionType != SectionType.Irregular && this.Project.Model.Options.SectionType != SectionType.IrregularTemplate))
			{
				try
				{
					if (this.Project.Model.Options.ProblemType == ProblemType.Design)
					{
						this.#CIb();
						this.IsEnabled = true;
					}
					else if (this.Project.Model.Options.ProblemType == ProblemType.Investigation)
					{
						#x0e #VIb = this.DesignEngineService.#BQ();
						this.#dIb(#VIb, true, null);
						this.IsEnabled = true;
					}
				}
				catch (Exception exception)
				{
					this.Services.Logger.Log(LoggingLevel.Warning, exception);
					this.#CIb();
					this.IsEnabled = false;
				}
				return;
			}
			IrregularSectionValidator irregularSectionValidator = new IrregularSectionValidator(this.Project.Model.#BY());
			ColumnStorageModel instance = this.Project.Model.#CY();
			if (irregularSectionValidator.Validate(instance).IsValid)
			{
				#x0e #VIb2 = this.DesignEngineService.#BQ();
				this.#dIb(#VIb2, true, null);
				this.IsEnabled = true;
				return;
			}
			this.#CIb();
			this.IsEnabled = false;
		}

		// Token: 0x06003520 RID: 13600 RVA: 0x001070F4 File Offset: 0x001052F4
		public void #CIb()
		{
			string stringTripleHyphen = Strings.StringTripleHyphen;
			this.MinClearBarSpacing = stringTripleHyphen;
			this.GrossArea = stringTripleHyphen;
			this.TotalAs = stringTripleHyphen;
			this.Rho = stringTripleHyphen;
			this.MaxCapacityRatio = stringTripleHyphen;
			this.IsCapacityRatioExceeded = false;
			this.IsAreaOfSteelExceeded = false;
			this.IsMinClearRebarSpacingExceeded = false;
			base.RaisePropertyChanged(#Phc.#3hc(107352969));
		}

		// Token: 0x06003521 RID: 13601 RVA: 0x0002E9E0 File Offset: 0x0002CBE0
		private void #wk(object #Ge, PropertyChangedEventArgs #He)
		{
			if (this.Services.GuiController.IsBackstageOpen)
			{
				this.IsDesignTracePopupOpen = false;
				return;
			}
			if (this.IsRunningDesignTrace)
			{
				this.IsDesignTracePopupOpen = true;
			}
		}

		// Token: 0x06003522 RID: 13602 RVA: 0x0002EA17 File Offset: 0x0002CC17
		private void #5Eb(object #Ge, #7V #He)
		{
			this.StopDesignTraceCommand.Execute(null);
		}

		// Token: 0x06003523 RID: 13603 RVA: 0x0002EA31 File Offset: 0x0002CC31
		private void #Ch(object #Ge, #fW #He)
		{
			if (!#He.SilentNotification)
			{
				this.#GIb(null);
			}
		}

		// Token: 0x06003524 RID: 13604 RVA: 0x0002EA4E File Offset: 0x0002CC4E
		private void #1g(object #Ge, #JCc #He)
		{
			if (this.IsActive)
			{
				this.#vh();
			}
		}

		// Token: 0x06003525 RID: 13605 RVA: 0x0002EA6A File Offset: 0x0002CC6A
		private void #Lh(object #Ge, EventArgs #He)
		{
			if (this.IsActive)
			{
				this.#dIb();
				this.#vh();
				this.#GIb(null);
				return;
			}
			this.#FIb();
		}

		// Token: 0x06003526 RID: 13606 RVA: 0x0010715C File Offset: 0x0010535C
		private void #DIb(object #Ge, PropertyChangedEventArgs #He)
		{
			BasicPropertiesViewModel.#EVd #EVd = new BasicPropertiesViewModel.#EVd();
			#EVd.#a = this;
			#EVd.#b = #He;
			if (!this.IsActive || this.DesignEngineService.IsExecuting)
			{
				return;
			}
			if (Application.Current.Dispatcher.CheckAccess())
			{
				this.#vh();
				if (#EVd.#b.PropertyName == #Phc.#3hc(107401546))
				{
					this.#QIb();
					return;
				}
			}
			else
			{
				LayoutHelper.BeginInvokeOnApplicationThread(new Action(#EVd.#Mbc));
			}
		}

		// Token: 0x06003527 RID: 13607 RVA: 0x0002EA9A File Offset: 0x0002CC9A
		private void #0g(object #Ge, EventArgs #He)
		{
			if (!this.IsActive)
			{
				return;
			}
			this.#dIb();
			this.#vh();
		}

		// Token: 0x06003528 RID: 13608 RVA: 0x001071FC File Offset: 0x001053FC
		private void #EIb()
		{
			#l4e #l4e = this.DesignEngineService.DesignEngine.OutputModel;
			string text = #l4e.CapacityData.OverallCapacity;
			if (string.IsNullOrWhiteSpace(text))
			{
				this.MaxCapacityRatio = Strings.StringTripleHyphen;
				this.IsCapacityRatioExceeded = false;
			}
			else
			{
				bool #2pb = this.Project.Model.Options.ProblemType == ProblemType.Design;
				float #3pb = this.Project.Model.DesignToRequiredRatio;
				bool flag = CapacityRatioHelper.#pAe(text, (#x6e)this.Project.Model.Options.SectionCapacityMethod, #2pb, #3pb);
				this.MaxCapacityRatio = text;
				this.IsCapacityRatioExceeded = flag;
			}
			this.#LIb();
		}

		// Token: 0x06003529 RID: 13609 RVA: 0x0002EABD File Offset: 0x0002CCBD
		private void #FIb()
		{
			if (this.IsRunningDesignTrace)
			{
				this.Services.Renderer.#9f(false, false);
			}
			this.IsRunningDesignTrace = false;
			this.IsDesignTracePopupOpen = false;
		}

		// Token: 0x0600352A RID: 13610 RVA: 0x0002EAF3 File Offset: 0x0002CCF3
		private void #GIb(object #Sb)
		{
			if (this.IsRunningDesignTrace)
			{
				this.LastStepCommand.Execute(null);
			}
			this.IsRunningDesignTrace = false;
			this.IsDesignTracePopupOpen = false;
		}

		// Token: 0x0600352B RID: 13611 RVA: 0x00003375 File Offset: 0x00001575
		private bool #HIb(object #Sb)
		{
			return true;
		}

		// Token: 0x0600352C RID: 13612 RVA: 0x001072C0 File Offset: 0x001054C0
		private void #IIb(object #Sb)
		{
			try
			{
				if ((this.DesignEngineService.DesignEngine != null && this.DesignEngineService.TraceResults.Any<#4Ve>()) || this.#h.#od(true))
				{
					if (this.DesignEngineService.TraceResults.Any<#4Ve>())
					{
						this.DesignEngineService.#zQ();
						this.IsRunningDesignTrace = true;
						this.IsDesignTracePopupOpen = true;
					}
				}
			}
			catch (Exception #ob)
			{
				this.Services.ErrorsHandler.#1Pb(Strings.StringCouldNotRunDesignTrace.#z2d(), #ob);
			}
		}

		// Token: 0x0600352D RID: 13613 RVA: 0x0002EB23 File Offset: 0x0002CD23
		private bool #JIb(object #Sb)
		{
			return !this.IsRunningDesignTrace;
		}

		// Token: 0x0600352E RID: 13614 RVA: 0x0002EB36 File Offset: 0x0002CD36
		private bool #KIb(object #Vg)
		{
			return this.IsCapacityRatioEnabled;
		}

		// Token: 0x0600352F RID: 13615 RVA: 0x00107364 File Offset: 0x00105564
		private void #LIb()
		{
			if (this.IsCapacityRatioExceeded && (string.IsNullOrWhiteSpace(this.MaxCapacityRatio) || string.Equals(this.MaxCapacityRatio, Strings.StringTripleHyphen)))
			{
				float num = this.Project.Model.DesignToRequiredRatio;
				this.MaxCapacityRatio = #Phc.#3hc(107352984) + num.ToString(#Phc.#3hc(107408811), CultureInfo.InvariantCulture);
			}
		}

		// Token: 0x06003530 RID: 13616 RVA: 0x001073E0 File Offset: 0x001055E0
		private void #vh()
		{
			Ignore.#14d<Exception>(new Action(this.FirstStepCommand.InvalidateCanExecute), null);
			Ignore.#14d<Exception>(new Action(this.LastStepCommand.InvalidateCanExecute), null);
			Ignore.#14d<Exception>(new Action(this.PreviousStepCommand.InvalidateCanExecute), null);
			Ignore.#14d<Exception>(new Action(this.NextStepCommand.InvalidateCanExecute), null);
			Ignore.#14d<Exception>(new Action(this.ExecuteCommand.InvalidateCanExecute), null);
			Ignore.#14d<Exception>(new Action(this.StopDesignTraceCommand.InvalidateCanExecute), null);
			Ignore.#14d<Exception>(new Action(this.RunDesignTraceCommand.InvalidateCanExecute), null);
			base.RaisePropertyChanged(#Phc.#3hc(107352979));
		}

		// Token: 0x06003531 RID: 13617 RVA: 0x0002EB46 File Offset: 0x0002CD46
		private bool #MIb(object #Vg)
		{
			return this.DesignTrace && (this.DesignEngineService.CurrentTraceStep == null || this.StepIndex < this.MaxStepIndex);
		}

		// Token: 0x06003532 RID: 13618 RVA: 0x0002EB7B File Offset: 0x0002CD7B
		private bool #NIb(object #Vg)
		{
			return this.DesignTrace && this.StepIndex < this.MaxStepIndex && this.StepIndex >= 0;
		}

		// Token: 0x06003533 RID: 13619 RVA: 0x0002EBAD File Offset: 0x0002CDAD
		private bool #OIb(object #Sb)
		{
			return this.DesignTrace && this.StepIndex > 0;
		}

		// Token: 0x06003534 RID: 13620 RVA: 0x0002EBAD File Offset: 0x0002CDAD
		private bool #PIb(object #Sb)
		{
			return this.DesignTrace && this.StepIndex > 0;
		}

		// Token: 0x06003535 RID: 13621 RVA: 0x001074C4 File Offset: 0x001056C4
		private void #QIb()
		{
			if (!false)
			{
				this.#vh();
			}
			this.#dIb();
			this.Services.Renderer.#9f(false, false);
			this.Services.MessageBus.#OV(new #jW());
			this.Services.Commands.#cg();
			this.DesignTraceMessages.Clear();
			#4Ve #4Ve = this.DesignEngineService.CurrentTraceStep;
			if (#4Ve != null)
			{
				bool flag = this.DesignEngineService.CurrentTraceStepIndex == this.DesignEngineService.TraceResults.Count - 1;
				if (flag)
				{
					this.DesignTraceMessages.AddRange(this.DesignEngineService.DesignEngine.OutputModel.Messages.Select(new Func<Message, DesignTraceMessage>(BasicPropertiesViewModel.<>c.<>9.#Q0h)).Where(new Func<DesignTraceMessage, bool>(BasicPropertiesViewModel.<>c.<>9.#R0h)));
				}
				else
				{
					this.DesignTraceMessages.AddRange(#4Ve.Messages.Select(new Func<Message, DesignTraceMessage>(BasicPropertiesViewModel.<>c.<>9.#S0h)).Where(new Func<DesignTraceMessage, bool>(BasicPropertiesViewModel.<>c.<>9.#T0h)));
				}
				if (flag)
				{
					DesignEngine designEngine = this.DesignEngineService.DesignEngine;
					bool? flag2;
					if (designEngine == null)
					{
						flag2 = null;
					}
					else
					{
						#l4e #l4e = designEngine.OutputModel;
						flag2 = ((#l4e != null) ? new bool?(#l4e.SolveCompleted) : null);
					}
					bool? flag3 = flag2;
					if (flag3.GetValueOrDefault())
					{
						if (!this.DesignEngineService.DesignEngine.OutputModel.Messages.Any(new Func<Message, bool>(BasicPropertiesViewModel.<>c.<>9.#U0h)))
						{
							this.DesignTraceMessages.Add(new DesignTraceMessage(Strings.StringFinalDesign + #Phc.#3hc(107352946)));
						}
					}
				}
			}
		}

		// Token: 0x06003536 RID: 13622 RVA: 0x0002EBCE File Offset: 0x0002CDCE
		private void #RIb(object #Sb)
		{
			this.DesignEngineService.#uQ();
		}

		// Token: 0x06003537 RID: 13623 RVA: 0x0002EBE7 File Offset: 0x0002CDE7
		private void #SIb(object #Sb)
		{
			this.DesignEngineService.#vQ();
		}

		// Token: 0x06003538 RID: 13624 RVA: 0x0002EC00 File Offset: 0x0002CE00
		private void #TIb(object #Sb)
		{
			this.DesignEngineService.#tQ();
		}

		// Token: 0x06003539 RID: 13625 RVA: 0x001076E0 File Offset: 0x001058E0
		private void #UIb(object #Sb)
		{
			if (this.DesignEngineService.DesignEngine == null)
			{
				if (this.#h.#od(true))
				{
					this.DesignEngineService.#yQ();
					return;
				}
			}
			else
			{
				this.DesignEngineService.#wQ();
			}
		}

		// Token: 0x0600353A RID: 13626 RVA: 0x0010772C File Offset: 0x0010592C
		private void #dIb(#x0e #VIb, bool #WIb, #4Ve #XIb = null)
		{
			#M5 #M = this.Project.Model.Units.Section;
			this.MinClearBarSpacing = ((#VIb.Space < 0f) ? #Phc.#3hc(107352909) : #M.MinClearBarSpacing.UnitValueFormatter.CreateDisplayValue((double)#VIb.Space));
			this.GrossArea = #M.GrossArea.UnitValueFormatter.CreateDisplayValue((double)#VIb.Ag);
			this.TotalAs = #M.TotalAs.UnitValueFormatter.CreateDisplayValue((double)#VIb.AreaOfSteel);
			this.Rho = #M.Rho.UnitValueFormatter.CreateDisplayValue((double)#VIb.Rho);
			if (#WIb)
			{
				this.MaxCapacityRatio = Strings.StringHyphen;
				this.IsCapacityRatioExceeded = false;
			}
			if (this.Project.Model.Options.ProblemType == ProblemType.Design)
			{
				bool flag;
				if (#VIb.Space >= this.Project.Model.MinRebarClearSpacing)
				{
					if (#XIb != null)
					{
						flag = #XIb.Messages.Any(new Func<Message, bool>(BasicPropertiesViewModel.<>c.<>9.#V0h));
					}
					else
					{
						flag = false;
					}
				}
				else
				{
					flag = true;
				}
				this.IsMinClearRebarSpacingExceeded = flag;
				this.IsAreaOfSteelExceeded = ((double)#VIb.Rho > (double)this.Project.Model.ReinforcementRatios.MaxReinforcementRatio * 100.0 || (double)#VIb.Rho < (double)this.Project.Model.ReinforcementRatios.MinReinforcementRatio * 100.0);
			}
			else
			{
				this.IsMinClearRebarSpacingExceeded = false;
				this.IsAreaOfSteelExceeded = false;
			}
			base.RaisePropertyChanged(#Phc.#3hc(107352969));
		}

		// Token: 0x0600353B RID: 13627 RVA: 0x001078F8 File Offset: 0x00105AF8
		private void #YIb(object #Sb)
		{
			try
			{
				bool flag = false;
				if (!false)
				{
					this.ArePropertiesEnabled = flag;
				}
				this.#h.#od(true);
				this.#dIb();
			}
			finally
			{
				this.ArePropertiesEnabled = true;
			}
		}

		// Token: 0x040015E9 RID: 5609
		private bool #a;

		// Token: 0x040015EA RID: 5610
		private string #b;

		// Token: 0x040015EB RID: 5611
		private string #c;

		// Token: 0x040015EC RID: 5612
		private string #d;

		// Token: 0x040015ED RID: 5613
		private string #e;

		// Token: 0x040015EE RID: 5614
		private string #f;

		// Token: 0x040015EF RID: 5615
		private bool #g;

		// Token: 0x040015F0 RID: 5616
		private readonly #8I #h;

		// Token: 0x040015F1 RID: 5617
		private bool #i;

		// Token: 0x040015F2 RID: 5618
		private bool #j;

		// Token: 0x040015F3 RID: 5619
		private bool #k;

		// Token: 0x040015F4 RID: 5620
		private bool #l;

		// Token: 0x040015F5 RID: 5621
		[CompilerGenerated]
		private readonly IExtendedServices #m;

		// Token: 0x040015F6 RID: 5622
		[CompilerGenerated]
		private readonly DelegateCommand #n;

		// Token: 0x040015F7 RID: 5623
		[CompilerGenerated]
		private readonly DelegateCommand #o;

		// Token: 0x040015F8 RID: 5624
		[CompilerGenerated]
		private readonly DelegateCommand #p;

		// Token: 0x040015F9 RID: 5625
		[CompilerGenerated]
		private readonly RadObservableCollection<DesignTraceMessage> #q = new RadObservableCollection<DesignTraceMessage>();

		// Token: 0x040015FA RID: 5626
		[CompilerGenerated]
		private bool #r;

		// Token: 0x040015FB RID: 5627
		[CompilerGenerated]
		private readonly DelegateCommand #s;

		// Token: 0x040015FC RID: 5628
		[CompilerGenerated]
		private readonly DelegateCommand #t;

		// Token: 0x040015FD RID: 5629
		[CompilerGenerated]
		private readonly DelegateCommand #u;

		// Token: 0x040015FE RID: 5630
		[CompilerGenerated]
		private readonly DelegateCommand #v;

		// Token: 0x040015FF RID: 5631
		[CompilerGenerated]
		private readonly #qW #w;

		// Token: 0x04001600 RID: 5632
		private bool #x = true;

		// Token: 0x0200061D RID: 1565
		[CompilerGenerated]
		private sealed class #EVd
		{
			// Token: 0x06003546 RID: 13638 RVA: 0x00107948 File Offset: 0x00105B48
			internal void #Mbc()
			{
				BasicPropertiesViewModel basicPropertiesViewModel = this.#a;
				if (!false)
				{
					basicPropertiesViewModel.#vh();
				}
				if (this.#b.PropertyName == #Phc.#3hc(107401546))
				{
					this.#a.#QIb();
				}
			}

			// Token: 0x04001609 RID: 5641
			public BasicPropertiesViewModel #a;

			// Token: 0x0400160A RID: 5642
			public PropertyChangedEventArgs #b;
		}
	}
}
