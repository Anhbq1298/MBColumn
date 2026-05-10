using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using #7hc;
using #7Tc;
using #UYd;
using StructurePoint.CoreAssets.GUI.DesktopControls.Utils;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Localizer;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Animation;

namespace StructurePoint.CoreAssets.GUI.Framework.PreciseInput
{
	// Token: 0x02000C7A RID: 3194
	public sealed class PreciseInputProvider : RadWindow, IComponentConnector, #jUc
	{
		// Token: 0x0600674F RID: 26447 RVA: 0x00193784 File Offset: 0x00191984
		public PreciseInputProvider()
		{
			this.InitializeComponent();
			if (DesignerHelper.IsInRuntime)
			{
				AnimationManager.SetIsAnimationEnabled(this, false);
				base.Header = Strings.StringPreciseInput;
				this.PrecisePointInputControl.PreciseInputCanceled += this.PrecisePointInputControl_PreciseInputCanceled;
				this.PrecisePointInputControl.PreciseInputChanged += this.PrecisePointInputControl_PreciseInputChanged;
				this.PrecisePointInputControl.PreciseInputCompleted += this.PrecisePointInputControl_PreciseInputCompleted;
				base.Closed += this.PreciseInputPointsProvider_Closed;
				base.KeyDown += this.PrecisePointInputControl_KeyDown;
			}
		}

		// Token: 0x06006750 RID: 26448 RVA: 0x00052AF6 File Offset: 0x00050CF6
		private void PreciseInputPointsProvider_Closed(object sender, WindowClosedEventArgs e)
		{
			if (6 != 0)
			{
				this.MyRaisePreciseInputClosed();
			}
		}

		// Token: 0x06006751 RID: 26449 RVA: 0x00052B04 File Offset: 0x00050D04
		private void PrecisePointInputControl_PreciseInputCompleted(object sender, PreciseInputCompletedEventArgs e)
		{
			if (4 != 0)
			{
				this.MyRaisePreciseInputCompleted(e);
			}
			if (e.RequestClose && 4 != 0)
			{
				base.Close();
			}
		}

		// Token: 0x06006752 RID: 26450 RVA: 0x00052B28 File Offset: 0x00050D28
		private void PrecisePointInputControl_PreciseInputChanged(object sender, PreciseInputChangedEventArgs e)
		{
			if (!false)
			{
				this.MyRaisePreciseInputChanged(e);
			}
		}

		// Token: 0x06006753 RID: 26451 RVA: 0x00052B38 File Offset: 0x00050D38
		private void PrecisePointInputControl_PreciseInputCanceled(object sender, EventArgs e)
		{
			if (2 != 0)
			{
				this.MyRaisePreciseInputCanceled();
			}
			if (5 != 0)
			{
				base.Close();
			}
		}

		// Token: 0x06006754 RID: 26452 RVA: 0x00193820 File Offset: 0x00191A20
		private void PrecisePointInputControl_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key != Key.Escape)
			{
				if (e.Key == Key.Return)
				{
					PreciseInputControl precisePointInputControl = this.PrecisePointInputControl;
					bool requestClose = Keyboard.IsKeyDown(Key.RightCtrl) || Keyboard.IsKeyDown(Key.LeftCtrl);
					if (false)
					{
						goto IL_5E;
					}
					precisePointInputControl.TryCommitInput(requestClose);
					goto IL_5E;
				}
				else
				{
					if (e.Key == Key.G)
					{
						PreciseInputControlDataContext preciseDataContext = this.PrecisePointInputControl.PreciseDataContext;
						#8Tc #f = #8Tc.#a;
						if (!false)
						{
							preciseDataContext.CoordinateType = #f;
						}
						e.Handled = true;
						return;
					}
					if (e.Key == Key.L)
					{
						this.PrecisePointInputControl.PreciseDataContext.CoordinateType = #8Tc.#b;
						e.Handled = true;
						return;
					}
					if (6 != 0)
					{
						if (e.Key == Key.P)
						{
							goto IL_C2;
						}
						return;
					}
				}
			}
			if (false)
			{
				return;
			}
			if (8 != 0)
			{
				this.MyRaisePreciseInputCanceled();
			}
			if (!false)
			{
				base.Close();
			}
			if (!false)
			{
				if (4 != 0)
				{
					bool handled = true;
					if (4 != 0)
					{
						e.Handled = handled;
					}
					return;
				}
				goto IL_C2;
			}
			IL_5E:
			bool handled2 = true;
			if (5 != 0)
			{
				e.Handled = handled2;
			}
			return;
			IL_C2:
			this.PrecisePointInputControl.PreciseDataContext.CoordinateType = #8Tc.#c;
			e.Handled = true;
		}

		// Token: 0x1400018A RID: 394
		// (add) Token: 0x06006755 RID: 26453 RVA: 0x00193944 File Offset: 0x00191B44
		// (remove) Token: 0x06006756 RID: 26454 RVA: 0x0019399C File Offset: 0x00191B9C
		public event EventHandler PreciseInputCanceled
		{
			[CompilerGenerated]
			add
			{
				if (!false)
				{
					EventHandler eventHandler;
					if (!false)
					{
						EventHandler preciseInputCanceled = this.PreciseInputCanceled;
						if (!false)
						{
							eventHandler = preciseInputCanceled;
						}
					}
					EventHandler eventHandler3;
					do
					{
						if (7 != 0)
						{
							EventHandler eventHandler2 = eventHandler;
							if (3 != 0)
							{
								eventHandler3 = eventHandler2;
							}
							EventHandler eventHandler4 = (EventHandler)Delegate.Combine(eventHandler3, value);
							EventHandler value2;
							if (-1 != 0)
							{
								value2 = eventHandler4;
							}
							EventHandler eventHandler5 = Interlocked.CompareExchange<EventHandler>(ref this.PreciseInputCanceled, value2, eventHandler3);
							if (6 != 0)
							{
								eventHandler = eventHandler5;
							}
						}
					}
					while (eventHandler != eventHandler3);
				}
			}
			[CompilerGenerated]
			remove
			{
				if (!false)
				{
					EventHandler eventHandler;
					if (!false)
					{
						EventHandler preciseInputCanceled = this.PreciseInputCanceled;
						if (!false)
						{
							eventHandler = preciseInputCanceled;
						}
					}
					EventHandler eventHandler3;
					do
					{
						if (7 != 0)
						{
							EventHandler eventHandler2 = eventHandler;
							if (3 != 0)
							{
								eventHandler3 = eventHandler2;
							}
							EventHandler eventHandler4 = (EventHandler)Delegate.Remove(eventHandler3, value);
							EventHandler value2;
							if (-1 != 0)
							{
								value2 = eventHandler4;
							}
							EventHandler eventHandler5 = Interlocked.CompareExchange<EventHandler>(ref this.PreciseInputCanceled, value2, eventHandler3);
							if (6 != 0)
							{
								eventHandler = eventHandler5;
							}
						}
					}
					while (eventHandler != eventHandler3);
				}
			}
		}

		// Token: 0x1400018B RID: 395
		// (add) Token: 0x06006757 RID: 26455 RVA: 0x001939F4 File Offset: 0x00191BF4
		// (remove) Token: 0x06006758 RID: 26456 RVA: 0x00193A4C File Offset: 0x00191C4C
		public event EventHandler<PreciseInputChangedEventArgs> PreciseInputChanged
		{
			[CompilerGenerated]
			add
			{
				if (!false)
				{
					EventHandler<PreciseInputChangedEventArgs> eventHandler;
					if (!false)
					{
						EventHandler<PreciseInputChangedEventArgs> preciseInputChanged = this.PreciseInputChanged;
						if (!false)
						{
							eventHandler = preciseInputChanged;
						}
					}
					EventHandler<PreciseInputChangedEventArgs> eventHandler3;
					do
					{
						if (7 != 0)
						{
							EventHandler<PreciseInputChangedEventArgs> eventHandler2 = eventHandler;
							if (3 != 0)
							{
								eventHandler3 = eventHandler2;
							}
							EventHandler<PreciseInputChangedEventArgs> eventHandler4 = (EventHandler<PreciseInputChangedEventArgs>)Delegate.Combine(eventHandler3, value);
							EventHandler<PreciseInputChangedEventArgs> value2;
							if (-1 != 0)
							{
								value2 = eventHandler4;
							}
							EventHandler<PreciseInputChangedEventArgs> eventHandler5 = Interlocked.CompareExchange<EventHandler<PreciseInputChangedEventArgs>>(ref this.PreciseInputChanged, value2, eventHandler3);
							if (6 != 0)
							{
								eventHandler = eventHandler5;
							}
						}
					}
					while (eventHandler != eventHandler3);
				}
			}
			[CompilerGenerated]
			remove
			{
				if (!false)
				{
					EventHandler<PreciseInputChangedEventArgs> eventHandler;
					if (!false)
					{
						EventHandler<PreciseInputChangedEventArgs> preciseInputChanged = this.PreciseInputChanged;
						if (!false)
						{
							eventHandler = preciseInputChanged;
						}
					}
					EventHandler<PreciseInputChangedEventArgs> eventHandler3;
					do
					{
						if (7 != 0)
						{
							EventHandler<PreciseInputChangedEventArgs> eventHandler2 = eventHandler;
							if (3 != 0)
							{
								eventHandler3 = eventHandler2;
							}
							EventHandler<PreciseInputChangedEventArgs> eventHandler4 = (EventHandler<PreciseInputChangedEventArgs>)Delegate.Remove(eventHandler3, value);
							EventHandler<PreciseInputChangedEventArgs> value2;
							if (-1 != 0)
							{
								value2 = eventHandler4;
							}
							EventHandler<PreciseInputChangedEventArgs> eventHandler5 = Interlocked.CompareExchange<EventHandler<PreciseInputChangedEventArgs>>(ref this.PreciseInputChanged, value2, eventHandler3);
							if (6 != 0)
							{
								eventHandler = eventHandler5;
							}
						}
					}
					while (eventHandler != eventHandler3);
				}
			}
		}

		// Token: 0x1400018C RID: 396
		// (add) Token: 0x06006759 RID: 26457 RVA: 0x00193AA4 File Offset: 0x00191CA4
		// (remove) Token: 0x0600675A RID: 26458 RVA: 0x00193AFC File Offset: 0x00191CFC
		public event EventHandler<PreciseInputCompletedEventArgs> PreciseInputCompleted
		{
			[CompilerGenerated]
			add
			{
				if (!false)
				{
					EventHandler<PreciseInputCompletedEventArgs> eventHandler;
					if (!false)
					{
						EventHandler<PreciseInputCompletedEventArgs> preciseInputCompleted = this.PreciseInputCompleted;
						if (!false)
						{
							eventHandler = preciseInputCompleted;
						}
					}
					EventHandler<PreciseInputCompletedEventArgs> eventHandler3;
					do
					{
						if (7 != 0)
						{
							EventHandler<PreciseInputCompletedEventArgs> eventHandler2 = eventHandler;
							if (3 != 0)
							{
								eventHandler3 = eventHandler2;
							}
							EventHandler<PreciseInputCompletedEventArgs> eventHandler4 = (EventHandler<PreciseInputCompletedEventArgs>)Delegate.Combine(eventHandler3, value);
							EventHandler<PreciseInputCompletedEventArgs> value2;
							if (-1 != 0)
							{
								value2 = eventHandler4;
							}
							EventHandler<PreciseInputCompletedEventArgs> eventHandler5 = Interlocked.CompareExchange<EventHandler<PreciseInputCompletedEventArgs>>(ref this.PreciseInputCompleted, value2, eventHandler3);
							if (6 != 0)
							{
								eventHandler = eventHandler5;
							}
						}
					}
					while (eventHandler != eventHandler3);
				}
			}
			[CompilerGenerated]
			remove
			{
				if (!false)
				{
					EventHandler<PreciseInputCompletedEventArgs> eventHandler;
					if (!false)
					{
						EventHandler<PreciseInputCompletedEventArgs> preciseInputCompleted = this.PreciseInputCompleted;
						if (!false)
						{
							eventHandler = preciseInputCompleted;
						}
					}
					EventHandler<PreciseInputCompletedEventArgs> eventHandler3;
					do
					{
						if (7 != 0)
						{
							EventHandler<PreciseInputCompletedEventArgs> eventHandler2 = eventHandler;
							if (3 != 0)
							{
								eventHandler3 = eventHandler2;
							}
							EventHandler<PreciseInputCompletedEventArgs> eventHandler4 = (EventHandler<PreciseInputCompletedEventArgs>)Delegate.Remove(eventHandler3, value);
							EventHandler<PreciseInputCompletedEventArgs> value2;
							if (-1 != 0)
							{
								value2 = eventHandler4;
							}
							EventHandler<PreciseInputCompletedEventArgs> eventHandler5 = Interlocked.CompareExchange<EventHandler<PreciseInputCompletedEventArgs>>(ref this.PreciseInputCompleted, value2, eventHandler3);
							if (6 != 0)
							{
								eventHandler = eventHandler5;
							}
						}
					}
					while (eventHandler != eventHandler3);
				}
			}
		}

		// Token: 0x1400018D RID: 397
		// (add) Token: 0x0600675B RID: 26459 RVA: 0x00193B54 File Offset: 0x00191D54
		// (remove) Token: 0x0600675C RID: 26460 RVA: 0x00193BAC File Offset: 0x00191DAC
		public event EventHandler PreciseInputClosed
		{
			[CompilerGenerated]
			add
			{
				if (!false)
				{
					EventHandler eventHandler;
					if (!false)
					{
						EventHandler preciseInputClosed = this.PreciseInputClosed;
						if (!false)
						{
							eventHandler = preciseInputClosed;
						}
					}
					EventHandler eventHandler3;
					do
					{
						if (7 != 0)
						{
							EventHandler eventHandler2 = eventHandler;
							if (3 != 0)
							{
								eventHandler3 = eventHandler2;
							}
							EventHandler eventHandler4 = (EventHandler)Delegate.Combine(eventHandler3, value);
							EventHandler value2;
							if (-1 != 0)
							{
								value2 = eventHandler4;
							}
							EventHandler eventHandler5 = Interlocked.CompareExchange<EventHandler>(ref this.PreciseInputClosed, value2, eventHandler3);
							if (6 != 0)
							{
								eventHandler = eventHandler5;
							}
						}
					}
					while (eventHandler != eventHandler3);
				}
			}
			[CompilerGenerated]
			remove
			{
				if (!false)
				{
					EventHandler eventHandler;
					if (!false)
					{
						EventHandler preciseInputClosed = this.PreciseInputClosed;
						if (!false)
						{
							eventHandler = preciseInputClosed;
						}
					}
					EventHandler eventHandler3;
					do
					{
						if (7 != 0)
						{
							EventHandler eventHandler2 = eventHandler;
							if (3 != 0)
							{
								eventHandler3 = eventHandler2;
							}
							EventHandler eventHandler4 = (EventHandler)Delegate.Remove(eventHandler3, value);
							EventHandler value2;
							if (-1 != 0)
							{
								value2 = eventHandler4;
							}
							EventHandler eventHandler5 = Interlocked.CompareExchange<EventHandler>(ref this.PreciseInputClosed, value2, eventHandler3);
							if (6 != 0)
							{
								eventHandler = eventHandler5;
							}
						}
					}
					while (eventHandler != eventHandler3);
				}
			}
		}

		// Token: 0x0600675D RID: 26461 RVA: 0x00193C04 File Offset: 0x00191E04
		public void Show(PreciseInputParameters initializeInputParameters)
		{
			string #R0d = #Phc.#3hc(107441594);
			StructurePoint.CoreAssets.Infrastructure.Exceptions.Component #x6c = StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.DesktopControls;
			string #Qic = #Phc.#3hc(107440930);
			if (7 != 0)
			{
				#X0d.#V0d(initializeInputParameters, #R0d, #x6c, #Qic);
			}
			PreciseInputControl precisePointInputControl = this.PrecisePointInputControl;
			if (!false)
			{
				precisePointInputControl.InitializeInput(initializeInputParameters);
			}
			ContentControl owner = initializeInputParameters.OwnerControl as ContentControl;
			if (!false)
			{
				base.Owner = owner;
			}
			WindowStartupLocation windowStartupLocation = WindowStartupLocation.CenterOwner;
			if (5 != 0)
			{
				base.WindowStartupLocation = windowStartupLocation;
			}
			if (!false)
			{
				base.ShowDialog();
			}
		}

		// Token: 0x0600675E RID: 26462 RVA: 0x00052B52 File Offset: 0x00050D52
		public void Update(PreciseInputParameters initializeInputParameters)
		{
			PreciseInputControl precisePointInputControl = this.PrecisePointInputControl;
			if (2 != 0)
			{
				precisePointInputControl.InitializeInput(initializeInputParameters);
			}
		}

		// Token: 0x17001CB6 RID: 7350
		// (get) Token: 0x0600675F RID: 26463 RVA: 0x00052B67 File Offset: 0x00050D67
		// (set) Token: 0x06006760 RID: 26464 RVA: 0x00052B6F File Offset: 0x00050D6F
		public bool IsPreciseInputEnabled { get; set; }

		// Token: 0x17001CB7 RID: 7351
		// (get) Token: 0x06006761 RID: 26465 RVA: 0x00052B78 File Offset: 0x00050D78
		public bool IsOpened
		{
			get
			{
				return base.IsOpen;
			}
		}

		// Token: 0x06006762 RID: 26466 RVA: 0x00193C7C File Offset: 0x00191E7C
		private void MyRaisePreciseInputClosed()
		{
			EventHandler preciseInputClosed = this.PreciseInputClosed;
			EventHandler eventHandler;
			if (!false)
			{
				eventHandler = preciseInputClosed;
			}
			if (eventHandler != null)
			{
				EventHandler eventHandler2 = eventHandler;
				EventArgs empty = EventArgs.Empty;
				if (!false)
				{
					eventHandler2(this, empty);
				}
			}
		}

		// Token: 0x06006763 RID: 26467 RVA: 0x00193CB0 File Offset: 0x00191EB0
		private void MyRaisePreciseInputCanceled()
		{
			EventHandler preciseInputCanceled = this.PreciseInputCanceled;
			EventHandler eventHandler;
			if (!false)
			{
				eventHandler = preciseInputCanceled;
			}
			if (eventHandler != null)
			{
				EventHandler eventHandler2 = eventHandler;
				EventArgs empty = EventArgs.Empty;
				if (!false)
				{
					eventHandler2(this, empty);
				}
			}
		}

		// Token: 0x06006764 RID: 26468 RVA: 0x00193CE4 File Offset: 0x00191EE4
		private void MyRaisePreciseInputChanged(PreciseInputChangedEventArgs preciseInputChangedEventArgs)
		{
			if (4 != 0)
			{
				if (!this.IsPreciseInputEnabled)
				{
					return;
				}
				EventHandler<PreciseInputChangedEventArgs> eventHandler;
				do
				{
					EventHandler<PreciseInputChangedEventArgs> preciseInputChanged = this.PreciseInputChanged;
					if (6 != 0)
					{
						eventHandler = preciseInputChanged;
					}
					if (!false && eventHandler == null)
					{
						return;
					}
				}
				while (3 == 0);
				EventHandler<PreciseInputChangedEventArgs> eventHandler2 = eventHandler;
				if (!false)
				{
					eventHandler2(this, preciseInputChangedEventArgs);
				}
			}
		}

		// Token: 0x06006765 RID: 26469 RVA: 0x00193D24 File Offset: 0x00191F24
		private void MyRaisePreciseInputCompleted(PreciseInputCompletedEventArgs preciseInputCompletedEventArgs)
		{
			if (4 != 0)
			{
				if (!this.IsPreciseInputEnabled)
				{
					return;
				}
				EventHandler<PreciseInputCompletedEventArgs> eventHandler;
				do
				{
					EventHandler<PreciseInputCompletedEventArgs> preciseInputCompleted = this.PreciseInputCompleted;
					if (6 != 0)
					{
						eventHandler = preciseInputCompleted;
					}
					if (!false && eventHandler == null)
					{
						return;
					}
				}
				while (3 == 0);
				EventHandler<PreciseInputCompletedEventArgs> eventHandler2 = eventHandler;
				if (!false)
				{
					eventHandler2(this, preciseInputCompletedEventArgs);
				}
			}
		}

		// Token: 0x06006766 RID: 26470 RVA: 0x00193D64 File Offset: 0x00191F64
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
						int num2 = num = 107440365;
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

		// Token: 0x06006767 RID: 26471 RVA: 0x0003813E File Offset: 0x0003633E
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06006768 RID: 26472 RVA: 0x00052B80 File Offset: 0x00050D80
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
				this.PrecisePointInputControl = (PreciseInputControl)target;
			}
			while (false);
		}

		// Token: 0x04002AA1 RID: 10913
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal PreciseInputControl PrecisePointInputControl;

		// Token: 0x04002AA2 RID: 10914
		private bool _contentLoaded;
	}
}
