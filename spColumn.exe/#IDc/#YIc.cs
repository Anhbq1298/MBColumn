using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using #7hc;
using #7Tc;
using #8Cc;
using #cYd;
using #EWc;
using #ezc;
using #Fmc;
using #NWc;
using #T0c;
using #UYd;
using #YKc;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;
using StructurePoint.CoreAssets.GUI.DesktopControls.Utils;
using StructurePoint.CoreAssets.GUI.Framework.Model.Entities;
using StructurePoint.CoreAssets.GUI.Framework.Model.Infrastructure;
using StructurePoint.CoreAssets.GUI.Framework.PreciseInput;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.CoreAssets.Logger;

namespace #IDc
{
	// Token: 0x02000B73 RID: 2931
	internal abstract class #YIc : #3Ec, INotifyPropertyChanged, IEditionToolData, #8Hc
	{
		// Token: 0x06005F71 RID: 24433 RVA: 0x00178F70 File Offset: 0x00177170
		[SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0")]
		protected #YIc(#6Ic #JDc) : base(#JDc.ModelEditorControl)
		{
			#X0d.#V0d(#JDc, #Phc.#3hc(107415858), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUIFramework, #Phc.#3hc(107415809));
			this.ModelEditorControl = #JDc.ModelEditorControl;
			this.NotificationService = #JDc.NotificationService;
			this.SnappingProvider = #JDc.SnappingProvider;
			this.ToolContext = #JDc;
			this.ToolOperationsHelper = #JDc.ToolOperationsHelper;
			this.SnapPointsMarker = #JDc.SnapPointsMarker;
			this.UndoManager = #JDc.UndoManager;
			this.ErrorsHandlingService = #JDc.ErrorsHandlingService;
			this.ProjectContext = #JDc.ProjectContext;
			this.SettingsProvider = #JDc.SettingsProvider;
			this.ModelEditorViewModel = #JDc.ModelEditorViewModel;
			base.IsEnabled = true;
			base.IsWorking = false;
			this.PreciseInputProvider = #JDc.PreciseInputProvider;
			this.PreciseInputProvider.PreciseInputChanged += this.#WIc;
			this.PreciseInputProvider.PreciseInputCompleted += this.#VIc;
			this.PreciseInputProvider.PreciseInputClosed += this.#UIc;
			this.#b = new DispatcherTimer(TimeSpan.FromMilliseconds(250.0), DispatcherPriority.Background, new EventHandler(this.#TIc), Dispatcher.CurrentDispatcher);
			this.#b.IsEnabled = false;
		}

		// Token: 0x1400017A RID: 378
		// (add) Token: 0x06005F72 RID: 24434 RVA: 0x001790BC File Offset: 0x001772BC
		// (remove) Token: 0x06005F73 RID: 24435 RVA: 0x00179114 File Offset: 0x00177314
		public event EventHandler Canceled
		{
			[CompilerGenerated]
			add
			{
				if (!false)
				{
					EventHandler eventHandler2;
					if (!false)
					{
						EventHandler eventHandler = this.#d;
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
							EventHandler eventHandler6 = Interlocked.CompareExchange<EventHandler>(ref this.#d, value2, eventHandler4);
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
						EventHandler eventHandler = this.#d;
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
							EventHandler eventHandler6 = Interlocked.CompareExchange<EventHandler>(ref this.#d, value2, eventHandler4);
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

		// Token: 0x06005F74 RID: 24436 RVA: 0x0017916C File Offset: 0x0017736C
		protected virtual void #bIc()
		{
			EventHandler eventHandler = this.#d;
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

		// Token: 0x06005F75 RID: 24437 RVA: 0x00009E6A File Offset: 0x0000806A
		protected virtual void #cIc()
		{
		}

		// Token: 0x06005F76 RID: 24438 RVA: 0x00009E6A File Offset: 0x0000806A
		protected virtual void #dIc()
		{
		}

		// Token: 0x06005F77 RID: 24439 RVA: 0x0004F27D File Offset: 0x0004D47D
		protected virtual void #eIc()
		{
			if (this.SettingsProvider.IsOrthogonalModeEnabled)
			{
				bool flag = false;
				if (!false)
				{
					this.IsOrthoModeKeyDown = flag;
				}
			}
		}

		// Token: 0x06005F78 RID: 24440 RVA: 0x00009E6A File Offset: 0x0000806A
		protected virtual void #fIc(PreciseInputChangedEventArgs #gIc)
		{
		}

		// Token: 0x06005F79 RID: 24441 RVA: 0x00009E6A File Offset: 0x0000806A
		protected virtual void #hIc()
		{
		}

		// Token: 0x06005F7A RID: 24442 RVA: 0x00009E6A File Offset: 0x0000806A
		protected virtual void #iIc(PreciseInputCompletedEventArgs #jIc)
		{
		}

		// Token: 0x17001B15 RID: 6933
		// (get) Token: 0x06005F7B RID: 24443 RVA: 0x0004F29A File Offset: 0x0004D49A
		// (set) Token: 0x06005F7C RID: 24444 RVA: 0x0004F2A2 File Offset: 0x0004D4A2
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		public #V0c ModelEditorViewModel { get; private set; }

		// Token: 0x17001B16 RID: 6934
		// (get) Token: 0x06005F7D RID: 24445 RVA: 0x0004F2AB File Offset: 0x0004D4AB
		// (set) Token: 0x06005F7E RID: 24446 RVA: 0x0004F2B3 File Offset: 0x0004D4B3
		public #oW ProjectContext { get; private set; }

		// Token: 0x17001B17 RID: 6935
		// (get) Token: 0x06005F7F RID: 24447 RVA: 0x0004F2BC File Offset: 0x0004D4BC
		// (set) Token: 0x06005F80 RID: 24448 RVA: 0x0004F2C4 File Offset: 0x0004D4C4
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		public ISnapPointsMarker SnapPointsMarker { get; private set; }

		// Token: 0x17001B18 RID: 6936
		// (get) Token: 0x06005F81 RID: 24449 RVA: 0x001791A0 File Offset: 0x001773A0
		public #3Hc ToolInfo
		{
			get
			{
				#3Hc #3Hc2;
				do
				{
					#3Hc #3Hc = new #3Hc();
					if (6 != 0)
					{
						#3Hc2 = #3Hc;
					}
					#3Hc #3Hc3 = #3Hc2;
					string text = string.IsNullOrEmpty(base.Header) ? Strings.StringTool : #Phc.#3hc(107420723).#D2d(new object[]
					{
						base.Header,
						Strings.StringTool
					});
					if (!false)
					{
						#3Hc3.CallerInfo = text;
					}
				}
				while (2 == 0);
				return #3Hc2;
			}
		}

		// Token: 0x17001B19 RID: 6937
		// (get) Token: 0x06005F82 RID: 24450 RVA: 0x0004F2CD File Offset: 0x0004D4CD
		// (set) Token: 0x06005F83 RID: 24451 RVA: 0x0004F2D5 File Offset: 0x0004D4D5
		public #jUc PreciseInputProvider { get; private set; }

		// Token: 0x17001B1A RID: 6938
		// (get) Token: 0x06005F84 RID: 24452 RVA: 0x0004F2DE File Offset: 0x0004D4DE
		// (set) Token: 0x06005F85 RID: 24453 RVA: 0x0004F2EB File Offset: 0x0004D4EB
		public bool IsPreciseInputEnabled
		{
			get
			{
				return this.PreciseInputProvider.IsPreciseInputEnabled;
			}
			set
			{
				#jUc #jUc = this.PreciseInputProvider;
				if (2 != 0)
				{
					#jUc.IsPreciseInputEnabled = value;
				}
			}
		}

		// Token: 0x17001B1B RID: 6939
		// (get) Token: 0x06005F86 RID: 24454 RVA: 0x0004F300 File Offset: 0x0004D500
		public #WWc StructuralModel
		{
			get
			{
				return this.ProjectContext.MainModel;
			}
		}

		// Token: 0x17001B1C RID: 6940
		// (get) Token: 0x06005F87 RID: 24455 RVA: 0x0004F30D File Offset: 0x0004D50D
		// (set) Token: 0x06005F88 RID: 24456 RVA: 0x0004F315 File Offset: 0x0004D515
		public #bDc UndoManager { get; protected set; }

		// Token: 0x17001B1D RID: 6941
		// (get) Token: 0x06005F89 RID: 24457 RVA: 0x0004F31E File Offset: 0x0004D51E
		// (set) Token: 0x06005F8A RID: 24458 RVA: 0x0004F326 File Offset: 0x0004D526
		public #rBc ErrorsHandlingService { get; protected set; }

		// Token: 0x17001B1E RID: 6942
		// (get) Token: 0x06005F8B RID: 24459 RVA: 0x0004F32F File Offset: 0x0004D52F
		// (set) Token: 0x06005F8C RID: 24460 RVA: 0x0004F337 File Offset: 0x0004D537
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		private protected #6Kc ToolOperationsHelper { protected get; private set; }

		// Token: 0x17001B1F RID: 6943
		// (get) Token: 0x06005F8D RID: 24461 RVA: 0x0004F340 File Offset: 0x0004D540
		// (set) Token: 0x06005F8E RID: 24462 RVA: 0x0004F348 File Offset: 0x0004D548
		private protected #6Gc SettingsProvider { protected get; private set; }

		// Token: 0x17001B20 RID: 6944
		// (get) Token: 0x06005F8F RID: 24463 RVA: 0x0004F351 File Offset: 0x0004D551
		// (set) Token: 0x06005F90 RID: 24464 RVA: 0x0004F359 File Offset: 0x0004D559
		private protected #6Ic ToolContext { protected get; private set; }

		// Token: 0x17001B21 RID: 6945
		// (get) Token: 0x06005F91 RID: 24465 RVA: 0x0004F362 File Offset: 0x0004D562
		// (set) Token: 0x06005F92 RID: 24466 RVA: 0x0004F36A File Offset: 0x0004D56A
		private protected IModelEditorControl ModelEditorControl { protected get; private set; }

		// Token: 0x17001B22 RID: 6946
		// (get) Token: 0x06005F93 RID: 24467 RVA: 0x0004F373 File Offset: 0x0004D573
		// (set) Token: 0x06005F94 RID: 24468 RVA: 0x0004F37B File Offset: 0x0004D57B
		private protected #Qrc SnappingProvider { protected get; private set; }

		// Token: 0x17001B23 RID: 6947
		// (get) Token: 0x06005F95 RID: 24469 RVA: 0x0004F384 File Offset: 0x0004D584
		// (set) Token: 0x06005F96 RID: 24470 RVA: 0x0004F38C File Offset: 0x0004D58C
		private protected #5Ic NotificationService { protected get; private set; }

		// Token: 0x17001B24 RID: 6948
		// (get) Token: 0x06005F97 RID: 24471 RVA: 0x0004F395 File Offset: 0x0004D595
		// (set) Token: 0x06005F98 RID: 24472 RVA: 0x0004F39D File Offset: 0x0004D59D
		protected Point3D? LastMousePosition { get; set; }

		// Token: 0x17001B25 RID: 6949
		// (get) Token: 0x06005F99 RID: 24473 RVA: 0x0004F3A6 File Offset: 0x0004D5A6
		// (set) Token: 0x06005F9A RID: 24474 RVA: 0x00179204 File Offset: 0x00177404
		protected Point3D? LastHandledPoint
		{
			get
			{
				return this.#a;
			}
			set
			{
				Point3D? point3D = this.#a;
				Point3D? point3D2;
				if (8 != 0)
				{
					point3D2 = point3D;
				}
				Point3D? point3D3;
				do
				{
					if (4 != 0)
					{
						point3D3 = value;
					}
				}
				while (7 == 0);
				if (point3D2 != null == (point3D3 != null) && (point3D2 == null || !Point3D.#F3d(point3D2.GetValueOrDefault(), point3D3.GetValueOrDefault())))
				{
					goto IL_59;
				}
				IL_46:
				Point3D? point3D4 = this.#a;
				if (8 != 0)
				{
					this.LastButOneHandledPoint = point3D4;
				}
				this.#a = value;
				IL_59:
				if (true)
				{
					return;
				}
				goto IL_46;
			}
		}

		// Token: 0x17001B26 RID: 6950
		// (get) Token: 0x06005F9B RID: 24475 RVA: 0x0004F3AE File Offset: 0x0004D5AE
		// (set) Token: 0x06005F9C RID: 24476 RVA: 0x0004F3B6 File Offset: 0x0004D5B6
		private protected Point3D? LastButOneHandledPoint { protected get; private set; }

		// Token: 0x17001B27 RID: 6951
		// (get) Token: 0x06005F9D RID: 24477 RVA: 0x0004F3BF File Offset: 0x0004D5BF
		protected bool IsOrthogonalModeEnabled
		{
			get
			{
				return this.SettingsProvider.IsOrthogonalModeEnabled || this.IsOrthoModeKeyDown;
			}
		}

		// Token: 0x17001B28 RID: 6952
		// (get) Token: 0x06005F9E RID: 24478 RVA: 0x0004F3D6 File Offset: 0x0004D5D6
		// (set) Token: 0x06005F9F RID: 24479 RVA: 0x0004F3DE File Offset: 0x0004D5DE
		private bool IsOrthoModeKeyDown
		{
			get
			{
				return this.#c;
			}
			set
			{
				for (;;)
				{
					if (this.#c == value)
					{
						goto IL_1F;
					}
					IL_09:
					this.#c = value;
					if (false)
					{
						continue;
					}
					DispatcherTimer dispatcherTimer = this.#b;
					if (!false)
					{
						dispatcherTimer.IsEnabled = value;
					}
					IL_1F:
					if (!false)
					{
						break;
					}
					goto IL_09;
				}
			}
		}

		// Token: 0x17001B29 RID: 6953
		// (get) Token: 0x06005FA0 RID: 24480 RVA: 0x0004F409 File Offset: 0x0004D609
		// (set) Token: 0x06005FA1 RID: 24481 RVA: 0x0004F411 File Offset: 0x0004D611
		private protected bool ModelValidationExceptionOccurred { protected get; private set; }

		// Token: 0x06005FA2 RID: 24482 RVA: 0x0017927C File Offset: 0x0017747C
		public override void #5b()
		{
			do
			{
				if (-1 != 0)
				{
					bool flag = false;
					if (!false)
					{
						this.IsOrthoModeKeyDown = flag;
					}
					if (!false)
					{
						base.#5b();
					}
					#6Gc #6Gc = this.SettingsProvider;
					EventHandler eventHandler = new EventHandler(this.#XIc);
					if (!false)
					{
						#6Gc.OrthogonalModeEnabledChanged += eventHandler;
					}
				}
				do
				{
					EventArgs #He = new EventArgs();
					if (!false)
					{
						this.#XIc(this, #He);
					}
				}
				while (false);
			}
			while (false);
		}

		// Token: 0x06005FA3 RID: 24483 RVA: 0x001792E0 File Offset: 0x001774E0
		public override void #0kb()
		{
			bool flag = false;
			if (4 != 0)
			{
				this.IsOrthoModeKeyDown = flag;
			}
			ISnapPointsMarker snapPointsMarker = this.SnapPointsMarker;
			Point3D? point = new Point3D?(new Point3D(0.0, 0.0, 0.0));
			if (!false)
			{
				snapPointsMarker.Mark(point);
			}
			ISnapPointsMarker snapPointsMarker2 = this.SnapPointsMarker;
			#Atc snapToPointResult = null;
			if (!false)
			{
				snapPointsMarker2.Mark(snapToPointResult);
			}
			if (!false)
			{
				base.#0kb();
			}
			#6Gc #6Gc = this.SettingsProvider;
			EventHandler eventHandler = new EventHandler(this.#XIc);
			if (8 != 0)
			{
				#6Gc.OrthogonalModeEnabledChanged -= eventHandler;
			}
		}

		// Token: 0x06005FA4 RID: 24484 RVA: 0x00179370 File Offset: 0x00177570
		public virtual void #1kb()
		{
			if (!false)
			{
				Point3D? point3D = null;
				if (!false)
				{
					this.LastHandledPoint = point3D;
				}
			}
			bool flag = false;
			if (3 != 0)
			{
				this.ModelValidationExceptionOccurred = flag;
			}
			do
			{
				string propertyName = null;
				if (-1 != 0)
				{
					base.RaisePropertyChanged(propertyName);
				}
				bool flag2 = false;
				if (6 != 0)
				{
					this.IsOrthoModeKeyDown = flag2;
				}
				if (!false)
				{
					bool isWorking = false;
					if (-1 != 0)
					{
						base.IsWorking = isWorking;
					}
				}
			}
			while (false);
			if (!false)
			{
				this.#bIc();
			}
		}

		// Token: 0x06005FA5 RID: 24485 RVA: 0x0004F41A File Offset: 0x0004D61A
		public virtual void #fzb(Point3D #HAb, bool #gzb)
		{
			Point3D? point3D = new Point3D?(#HAb);
			if (2 != 0)
			{
				this.LastHandledPoint = point3D;
			}
		}

		// Token: 0x06005FA6 RID: 24486 RVA: 0x001793E0 File Offset: 0x001775E0
		protected virtual void #zIc()
		{
			#SJ #SJ = this.ToolContext.MainModelValidator.#LWc();
			#SJ #SJ2;
			if (!false)
			{
				#SJ2 = #SJ;
			}
			if (#SJ2 != null && #SJ2.Result != #IWc.#a)
			{
				throw new ModelValidationException(#SJ2.Description);
			}
		}

		// Token: 0x06005FA7 RID: 24487 RVA: 0x0017941C File Offset: 0x0017761C
		protected static bool #Dzb(Point3D? #Xrb, Point3D #Yrb)
		{
			if (4 == 0)
			{
				goto IL_1C;
			}
			int result;
			bool flag = (result = ((#Xrb != null) ? 1 : 0)) != 0;
			if (3 == 0)
			{
				return result != 0;
			}
			if (flag)
			{
				Point3D value = #Xrb.Value;
				if (false)
				{
					goto IL_1C;
				}
				Point3D #ncb = value;
				goto IL_1C;
			}
			IL_0F:
			result = 0;
			return result != 0;
			IL_1C:
			if (!false)
			{
				Point3D #ncb;
				return GeometryHelper.#lcb(#Yrb, #ncb) > 0.0;
			}
			goto IL_0F;
		}

		// Token: 0x06005FA8 RID: 24488 RVA: 0x0004F42F File Offset: 0x0004D62F
		public void #AIc(IDashedPlanarRectangleDrawingResult #BIc, double #CIc)
		{
			double #RIc = 1.0 / this.ModelEditorControl.CalculateViewScale();
			if (4 != 0)
			{
				#YIc.#QIc(#BIc, #CIc, #RIc);
			}
		}

		// Token: 0x06005FA9 RID: 24489 RVA: 0x00179460 File Offset: 0x00177660
		protected override void #2kb(KeyEventArgs #HA)
		{
			if (#HA == null)
			{
				return;
			}
			if (#HA.Key == Key.Escape)
			{
				if (!false)
				{
					this.#1kb();
				}
			}
			else if (this.IsPreciseInputEnabled && #HA.Key == Key.System && #HA.SystemKey == Key.F10)
			{
				if (4 != 0)
				{
					this.#GIc();
				}
				bool handled = true;
				if (!false)
				{
					#HA.Handled = handled;
				}
			}
			if (7 != 0)
			{
				this.#DIc(#HA);
			}
		}

		// Token: 0x06005FAA RID: 24490 RVA: 0x001794D0 File Offset: 0x001776D0
		protected void #DIc(KeyEventArgs #HA)
		{
			while (#HA != null)
			{
				if (!this.SettingsProvider.IsOrthogonalModeEnabled)
				{
					goto IL_11;
				}
				goto IL_34;
				IL_25:
				bool flag = false;
				if (6 != 0)
				{
					this.IsOrthoModeKeyDown = flag;
				}
				if (false)
				{
					continue;
				}
				if (2 == 0)
				{
					goto IL_34;
				}
				this.#dIc();
				goto IL_34;
				IL_11:
				if (#HA.Key == Key.LeftShift)
				{
					goto IL_25;
				}
				IL_1B:
				if (#HA.Key == Key.RightShift)
				{
					goto IL_25;
				}
				IL_34:
				if (false)
				{
					goto IL_11;
				}
				if (!false)
				{
					return;
				}
				goto IL_1B;
			}
		}

		// Token: 0x06005FAB RID: 24491 RVA: 0x0004F455 File Offset: 0x0004D655
		protected override void #GEc(KeyEventArgs #HA)
		{
			if (!false)
			{
				base.#GEc(#HA);
			}
			if (#HA == null)
			{
				return;
			}
			if (!false)
			{
				this.#EIc(#HA);
			}
		}

		// Token: 0x06005FAC RID: 24492 RVA: 0x00179528 File Offset: 0x00177728
		protected void #EIc(KeyEventArgs #HA)
		{
			while (#HA != null)
			{
				if (!this.SettingsProvider.IsOrthogonalModeEnabled)
				{
					goto IL_11;
				}
				goto IL_34;
				IL_25:
				bool flag = true;
				if (6 != 0)
				{
					this.IsOrthoModeKeyDown = flag;
				}
				if (false)
				{
					continue;
				}
				if (2 == 0)
				{
					goto IL_34;
				}
				this.#cIc();
				goto IL_34;
				IL_11:
				if (#HA.Key == Key.LeftShift)
				{
					goto IL_25;
				}
				IL_1B:
				if (#HA.Key == Key.RightShift)
				{
					goto IL_25;
				}
				IL_34:
				if (false)
				{
					goto IL_11;
				}
				if (!false)
				{
					return;
				}
				goto IL_1B;
			}
		}

		// Token: 0x06005FAD RID: 24493 RVA: 0x0004F477 File Offset: 0x0004D677
		protected override void #HEc(Point3D #IEc, Point3D #Kzb)
		{
			Point3D? point3D = new Point3D?(#Kzb);
			if (2 != 0)
			{
				this.LastMousePosition = point3D;
			}
		}

		// Token: 0x06005FAE RID: 24494 RVA: 0x0004F48C File Offset: 0x0004D68C
		protected void #FIc(params ModelEditorControlEventType[] #MEc)
		{
			IModelEditorControl modelEditorControl = this.ModelEditorControl;
			if (2 != 0)
			{
				modelEditorControl.RegisterEvents(#MEc);
			}
		}

		// Token: 0x06005FAF RID: 24495 RVA: 0x00009E6A File Offset: 0x0000806A
		protected virtual void #GIc()
		{
		}

		// Token: 0x06005FB0 RID: 24496 RVA: 0x00179580 File Offset: 0x00177780
		protected Point3D? #HIc(MouseEventArgs #FEc)
		{
			StructurePoint.CoreAssets.Infrastructure.Data.Point editorPosition = this.ModelEditorControl.GetEditorPosition(#FEc);
			StructurePoint.CoreAssets.Infrastructure.Data.Point mousePosition;
			if (2 != 0)
			{
				mousePosition = editorPosition;
			}
			Point3D value;
			if (!this.ModelEditorControl.GetMousePositionOnXYPlane(mousePosition, out value))
			{
				return null;
			}
			return new Point3D?(value);
		}

		// Token: 0x06005FB1 RID: 24497 RVA: 0x001795C0 File Offset: 0x001777C0
		protected StructurePoint.CoreAssets.Infrastructure.Data.Point? #IIc()
		{
			Point3D? point3D = this.LastHandledPoint;
			Point3D? point3D2;
			if (!false)
			{
				point3D2 = point3D;
			}
			StructurePoint.CoreAssets.Infrastructure.Data.Point? point;
			StructurePoint.CoreAssets.Infrastructure.Data.Point? point2;
			if (point3D2 == null)
			{
				point = null;
				point2 = point;
			}
			else
			{
				Point3D? point3D3 = this.LastHandledPoint;
				if (!false)
				{
					point3D2 = point3D3;
				}
				point2 = new StructurePoint.CoreAssets.Infrastructure.Data.Point?(PointsConverter.#vsc(point3D2.Value));
			}
			StructurePoint.CoreAssets.Infrastructure.Data.Point? point3;
			if (-1 != 0)
			{
				point3 = point2;
			}
			if (!this.PreciseInputProvider.IsOpened)
			{
				goto IL_A8;
			}
			StructurePoint.CoreAssets.Infrastructure.Data.Point? point4 = point3;
			if (-1 != 0)
			{
				point = point4;
			}
			bool flag = point != null;
			IL_62:
			StructurePoint.CoreAssets.Infrastructure.Data.Point? point5;
			if (!flag)
			{
				Point3D? point3D4 = this.LastButOneHandledPoint;
				if (!false)
				{
					point3D2 = point3D4;
				}
				if (point3D2 == null)
				{
					point5 = null;
					goto IL_A7;
				}
				Point3D? point3D5 = this.LastButOneHandledPoint;
				if (!false)
				{
					point3D2 = point3D5;
				}
				point5 = new StructurePoint.CoreAssets.Infrastructure.Data.Point?(PointsConverter.#vsc(point3D2.Value));
				goto IL_A7;
			}
			IL_A6:
			point5 = point;
			IL_A7:
			point3 = point5;
			IL_A8:
			if (point3 != null)
			{
				return point3;
			}
			#Atc #Atc;
			Point3D #HAb;
			if (-1 != 0)
			{
				Point3D? point3D6 = this.LastMousePosition;
				bool flag2 = flag = this.PreciseInputProvider.IsOpened;
				if (!false)
				{
					if (!flag2)
					{
						if (8 == 0)
						{
							goto IL_A6;
						}
						if (false)
						{
							goto IL_11D;
						}
						if (point3D6 != null)
						{
							#Atc = this.SnappingProvider.#bNb(this.#JIc(), point3D6.Value);
							if (#Atc == null)
							{
								#HAb = point3D6.Value;
								goto IL_10A;
							}
							goto IL_103;
						}
					}
					StructurePoint.CoreAssets.Infrastructure.Data.Point value = default(StructurePoint.CoreAssets.Infrastructure.Data.Point);
					IL_11D:
					return new StructurePoint.CoreAssets.Infrastructure.Data.Point?(value);
				}
				goto IL_62;
			}
			IL_103:
			#HAb = #Atc.Point;
			IL_10A:
			return new StructurePoint.CoreAssets.Infrastructure.Data.Point?(PointsConverter.#vsc(#HAb));
		}

		// Token: 0x06005FB2 RID: 24498 RVA: 0x00179718 File Offset: 0x00177918
		[SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
		protected virtual #hvc #JIc()
		{
			if (this.ProjectContext.SnappingModes != #hvc.#a)
			{
				if (this.ToolContext.ToolsConfiguration.UseCustomSnappingModeForPreciseInputInitialAndRelativePointsSelection)
				{
					return this.ToolContext.ToolsConfiguration.CustomSnappingModeForPreciseInputInitialAndRelativePointsSelection;
				}
				if (5 != 0)
				{
					return this.ProjectContext.SnappingModes;
				}
			}
			return this.ProjectContext.SnappingModes;
		}

		// Token: 0x06005FB3 RID: 24499 RVA: 0x00179770 File Offset: 0x00177970
		protected virtual Point3D? #KIc()
		{
			Point3D? point3D = null;
			if (this.PreciseInputProvider.IsOpened)
			{
				Point3D? point3D2 = this.LastHandledPoint;
				if (true)
				{
					point3D = point3D2;
				}
				Point3D? point3D3 = point3D;
				Point3D? point3D4;
				if (2 != 0)
				{
					point3D4 = point3D3;
				}
				Point3D? point3D5;
				if (point3D4 == null)
				{
					if (false)
					{
						goto IL_7B;
					}
					point3D5 = this.LastButOneHandledPoint;
				}
				else
				{
					point3D5 = point3D4;
				}
				if (true)
				{
					point3D = point3D5;
				}
			}
			if (point3D != null)
			{
				goto IL_88;
			}
			Point3D? point3D6 = this.LastMousePosition;
			if (!false)
			{
				point3D = point3D6;
			}
			if (point3D == null)
			{
				goto IL_88;
			}
			#Atc #Atc = this.SnappingProvider.#bNb(this.#JIc(), point3D.Value);
			#Atc #Atc2;
			if (!false)
			{
				#Atc2 = #Atc;
			}
			if (#Atc2 == null)
			{
				goto IL_88;
			}
			IL_7B:
			Point3D value = #Atc2.Point;
			if (8 != 0)
			{
				point3D = new Point3D?(value);
			}
			IL_88:
			return new Point3D?(point3D.GetValueOrDefault());
		}

		// Token: 0x06005FB4 RID: 24500 RVA: 0x0004F4A1 File Offset: 0x0004D6A1
		protected void #AIc(ICrossIndicatorDrawingResult #LIc)
		{
			if (!true || (!false && #LIc != null))
			{
				double #RIc = 1.0 / this.ModelEditorControl.CalculateViewScale();
				if (!false)
				{
					#YIc.#QIc(#LIc, #RIc);
				}
				if (!false)
				{
					return;
				}
			}
		}

		// Token: 0x06005FB5 RID: 24501 RVA: 0x0004F4D2 File Offset: 0x0004D6D2
		protected void #MIc()
		{
			do
			{
				if (true && !false)
				{
					#PWc #PWc = this.ToolContext.SnappingPointsUpdater;
					#Qrc #NDc = this.SnappingProvider;
					#WWc #mSc = this.ToolContext.ProjectContext.MainModel;
					if (!false)
					{
						#PWc.#lSc(#NDc, #mSc);
					}
				}
			}
			while (false);
		}

		// Token: 0x06005FB6 RID: 24502 RVA: 0x0004F50B File Offset: 0x0004D70B
		protected void #NIc()
		{
			do
			{
				if (!false)
				{
					#PWc #PWc = this.ToolContext.SnappingPointsUpdater;
					#Qrc #NDc = this.SnappingProvider;
					IEnumerable<GridLineDefinitionModel> #atc = this.ToolContext.ProjectContext.MainModel.GridLines;
					if (!false)
					{
						#PWc.#NIc(#NDc, #atc);
					}
				}
			}
			while (false);
		}

		// Token: 0x06005FB7 RID: 24503 RVA: 0x00179830 File Offset: 0x00177A30
		protected void #2Pb(#vYd #3Pb)
		{
			#YIc.#a9c #a9c = new #YIc.#a9c();
			#YIc.#a9c #a9c2;
			if (!false)
			{
				#a9c2 = #a9c;
			}
			do
			{
				#bDc #bDc = this.UndoManager;
				bool #ACc = false;
				if (!false)
				{
					#bDc.#yCc(#ACc);
				}
				#a9c2.#a = Strings.StringTheGeometryOperationResultIsNotValid.#z2d(true) + Strings.StringOperationHasBeenCanceled.#z2d();
			}
			while (false);
			#5Ic #5Ic = this.ToolContext.NotificationService;
			#3Hc #Ic = this.ToolInfo;
			string # = #a9c2.#a;
			if (!false)
			{
				#5Ic.#1Ic(#Ic, #);
			}
			ILogger logger = this.ToolContext.Logger;
			LoggingLevel level = LoggingLevel.Error;
			Func<string> messageProvider = new Func<string>(#a9c2.#98c);
			if (-1 != 0)
			{
				logger.Log(level, messageProvider, #3Pb);
			}
		}

		// Token: 0x06005FB8 RID: 24504 RVA: 0x001798CC File Offset: 0x00177ACC
		[SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
		protected void #OIc(ModelValidationException #PIc)
		{
			if (#PIc != null && !false)
			{
				#bDc #bDc = this.UndoManager;
				bool #ACc = false;
				if (!false)
				{
					#bDc.#yCc(#ACc);
				}
				do
				{
					bool flag = true;
					if (!false)
					{
						this.ModelValidationExceptionOccurred = flag;
					}
				}
				while (false);
				this.ToolContext.DialogService.#od(#PIc.Message, MessageBoxButton.OK, MessageBoxImage.Hand, MessageBoxResult.OK, MessageBoxOptions.None);
				return;
			}
		}

		// Token: 0x06005FB9 RID: 24505 RVA: 0x0004F546 File Offset: 0x0004D746
		private static void #QIc(ICrossIndicatorDrawingResult #LIc, double #RIc)
		{
			if (#LIc != null && !false)
			{
				#LIc.Scale = #RIc;
			}
		}

		// Token: 0x06005FBA RID: 24506 RVA: 0x0004F559 File Offset: 0x0004D759
		private static void #QIc(IDashedPlanarRectangleDrawingResult #SIc, double #CIc, double #RIc)
		{
			if (#SIc != null)
			{
				double segmentLength = #CIc * #RIc;
				if (!false)
				{
					#SIc.SegmentLength = segmentLength;
				}
			}
		}

		// Token: 0x06005FBB RID: 24507 RVA: 0x00179920 File Offset: 0x00177B20
		private void #TIc(object #Ge, EventArgs #HA)
		{
			if (this.SettingsProvider.IsOrthogonalModeEnabled || Keyboard.IsKeyDown(Key.LeftShift))
			{
				goto IL_31;
			}
			IL_16:
			if (!false)
			{
				int num2;
				int num = num2 = 117;
				if (num != 0)
				{
					num2 = (Keyboard.IsKeyDown((Key)num) ? 1 : 0);
				}
				if (num2 == 0)
				{
					bool flag = false;
					if (!false)
					{
						this.IsOrthoModeKeyDown = flag;
					}
					if (!false)
					{
						this.#dIc();
					}
				}
			}
			IL_31:
			if (-1 != 0)
			{
				return;
			}
			goto IL_16;
		}

		// Token: 0x06005FBC RID: 24508 RVA: 0x0004F56E File Offset: 0x0004D76E
		private void #UIc(object #Ge, EventArgs #He)
		{
			if (base.IsActive && !false)
			{
				this.#hIc();
			}
		}

		// Token: 0x06005FBD RID: 24509 RVA: 0x0004F584 File Offset: 0x0004D784
		private void #VIc(object #Ge, PreciseInputCompletedEventArgs #He)
		{
			if (base.IsActive && this.IsPreciseInputEnabled && !false)
			{
				this.#iIc(#He);
			}
		}

		// Token: 0x06005FBE RID: 24510 RVA: 0x0004F5A4 File Offset: 0x0004D7A4
		private void #WIc(object #Ge, PreciseInputChangedEventArgs #He)
		{
			if (base.IsActive && this.IsPreciseInputEnabled && !false)
			{
				this.#fIc(#He);
			}
		}

		// Token: 0x06005FBF RID: 24511 RVA: 0x0004F5C4 File Offset: 0x0004D7C4
		private void #XIc(object #Ge, EventArgs #He)
		{
			if (base.IsActive && !false)
			{
				this.#eIc();
			}
		}

		// Token: 0x0400276D RID: 10093
		private Point3D? #a;

		// Token: 0x0400276E RID: 10094
		private readonly DispatcherTimer #b;

		// Token: 0x0400276F RID: 10095
		private bool #c;

		// Token: 0x04002770 RID: 10096
		[CompilerGenerated]
		private EventHandler #d;

		// Token: 0x04002771 RID: 10097
		[CompilerGenerated]
		private #V0c #e;

		// Token: 0x04002772 RID: 10098
		[CompilerGenerated]
		private #oW #f;

		// Token: 0x04002773 RID: 10099
		[CompilerGenerated]
		private ISnapPointsMarker #g;

		// Token: 0x04002774 RID: 10100
		[CompilerGenerated]
		private #jUc #h;

		// Token: 0x04002775 RID: 10101
		[CompilerGenerated]
		private #bDc #i;

		// Token: 0x04002776 RID: 10102
		[CompilerGenerated]
		private #rBc #j;

		// Token: 0x04002777 RID: 10103
		[CompilerGenerated]
		private #6Kc #k;

		// Token: 0x04002778 RID: 10104
		[CompilerGenerated]
		private #6Gc #l;

		// Token: 0x04002779 RID: 10105
		[CompilerGenerated]
		private #6Ic #m;

		// Token: 0x0400277A RID: 10106
		[CompilerGenerated]
		private IModelEditorControl #n;

		// Token: 0x0400277B RID: 10107
		[CompilerGenerated]
		private #Qrc #o;

		// Token: 0x0400277C RID: 10108
		[CompilerGenerated]
		private #5Ic #p;

		// Token: 0x0400277D RID: 10109
		[CompilerGenerated]
		private Point3D? #q;

		// Token: 0x0400277E RID: 10110
		[CompilerGenerated]
		private Point3D? #r;

		// Token: 0x0400277F RID: 10111
		[CompilerGenerated]
		private bool #s;

		// Token: 0x02000B74 RID: 2932
		[CompilerGenerated]
		private sealed class #a9c
		{
			// Token: 0x06005FC1 RID: 24513 RVA: 0x0004F5DA File Offset: 0x0004D7DA
			internal string #98c()
			{
				return this.#a;
			}

			// Token: 0x04002780 RID: 10112
			public string #a;
		}
	}
}
