using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using #7hc;
using #7Tc;
using #UYd;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.GUI.DesktopControls.Utils;
using StructurePoint.CoreAssets.GUI.Framework.IO;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.Framework.PreciseInput
{
	// Token: 0x02000C76 RID: 3190
	public sealed class PreciseInputControl : UserControl, IComponentConnector
	{
		// Token: 0x17001C7F RID: 7295
		// (get) Token: 0x060066B4 RID: 26292 RVA: 0x00052769 File Offset: 0x00050969
		// (set) Token: 0x060066B5 RID: 26293 RVA: 0x00052771 File Offset: 0x00050971
		internal PreciseInputControlDataContext PreciseDataContext { get; private set; }

		// Token: 0x060066B6 RID: 26294 RVA: 0x001910A0 File Offset: 0x0018F2A0
		public PreciseInputControl()
		{
			this.InitializeComponent();
			if (DesignerHelper.IsInRuntime)
			{
				this.InsertButton.Click += this.OkButton_Click;
				this.InsertAndCloseButton.Click += this.InsertAndCloseButton_Click;
				this.CancelButton.Click += this.CancelButton_Click;
				this.PreciseDataContext = new PreciseInputControlDataContext();
				base.DataContext = this.PreciseDataContext;
				this.PreciseDataContext.CoordinateChanged += this.PrecisePointInputControlDataContext_CoordinateChanged;
				this.XGlobalCoordinateTextBox.PreviewKeyDown += this.XGlobalCoordinateTextBox_PreviewKeyDown;
				this.YGlobalCoordinateTextBox.PreviewKeyDown += this.YGlobalCoordinateTextBox_PreviewKeyDown;
				this.XLocalCoordinateTextBox.PreviewKeyDown += this.XLocalCoordinateTextBox_PreviewKeyDown;
				this.YLocalCoordinateTextBox.PreviewKeyDown += this.YLocalCoordinateTextBox_PreviewKeyDown;
				this.RadiusCoordinateTextBox.PreviewKeyDown += this.RadiusCoordinateTextBox_PreviewKeyDown;
				this.AngleCoordinateTextBox.PreviewKeyDown += this.AngleCoordinateTextBox_PreviewKeyDown;
				base.KeyDown += this.PrecisePointInputControl_KeyDown;
				this.PreciseDataContext.PropertyChanged += this.PreciseDataContext_PropertyChanged;
			}
		}

		// Token: 0x14000186 RID: 390
		// (add) Token: 0x060066B7 RID: 26295 RVA: 0x001911EC File Offset: 0x0018F3EC
		// (remove) Token: 0x060066B8 RID: 26296 RVA: 0x00191244 File Offset: 0x0018F444
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

		// Token: 0x14000187 RID: 391
		// (add) Token: 0x060066B9 RID: 26297 RVA: 0x0019129C File Offset: 0x0018F49C
		// (remove) Token: 0x060066BA RID: 26298 RVA: 0x001912F4 File Offset: 0x0018F4F4
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

		// Token: 0x14000188 RID: 392
		// (add) Token: 0x060066BB RID: 26299 RVA: 0x0019134C File Offset: 0x0018F54C
		// (remove) Token: 0x060066BC RID: 26300 RVA: 0x001913A4 File Offset: 0x0018F5A4
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

		// Token: 0x060066BD RID: 26301 RVA: 0x001913FC File Offset: 0x0018F5FC
		private void PreciseDataContext_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			string propertyName = e.PropertyName;
			ParameterExpression parameterExpression = System.Linq.Expressions.Expression.Parameter(typeof(PreciseInputControlDataContext), #Phc.#3hc(107398878));
			ParameterExpression parameterExpression2;
			if (!false)
			{
				parameterExpression2 = parameterExpression;
			}
			if (propertyName == #x0d<PreciseInputControlDataContext>.#XYd<#8Tc>(System.Linq.Expressions.Expression.Lambda<Func<PreciseInputControlDataContext, #8Tc>>(System.Linq.Expressions.Expression.Property(parameterExpression2, methodof(PreciseInputControlDataContext.#MUc())), new ParameterExpression[]
			{
				parameterExpression2
			})).Name)
			{
				double seconds = 0.1;
				Action operation = new Action(this.MyUpdateFocus);
				if (4 != 0)
				{
					LayoutHelper.DelayOperation(seconds, operation);
				}
			}
		}

		// Token: 0x060066BE RID: 26302 RVA: 0x0005277A File Offset: 0x0005097A
		private void CancelButton_Click(object sender, RoutedEventArgs e)
		{
			if (6 != 0)
			{
				this.MyRaisePreciseInputCanceled();
			}
		}

		// Token: 0x060066BF RID: 26303 RVA: 0x00052788 File Offset: 0x00050988
		private void OkButton_Click(object sender, RoutedEventArgs e)
		{
			bool requestClose = false;
			if (!false)
			{
				this.TryCommitInput(requestClose);
			}
		}

		// Token: 0x060066C0 RID: 26304 RVA: 0x00052798 File Offset: 0x00050998
		private void InsertAndCloseButton_Click(object sender, RoutedEventArgs e)
		{
			bool requestClose = true;
			if (!false)
			{
				this.TryCommitInput(requestClose);
			}
		}

		// Token: 0x060066C1 RID: 26305 RVA: 0x000527A8 File Offset: 0x000509A8
		private void PrecisePointInputControlDataContext_CoordinateChanged(object sender, EventArgs e)
		{
			if (!false && this.PreciseDataContext.IsValid)
			{
				PreciseInputChangedEventArgs preciseInputChangedEventArgs = new PreciseInputChangedEventArgs(this.PreciseDataContext.ResultPoint);
				if (!false)
				{
					this.MyRaisePreciseInputChanged(preciseInputChangedEventArgs);
				}
				if (!false)
				{
					return;
				}
			}
		}

		// Token: 0x060066C2 RID: 26306 RVA: 0x00191488 File Offset: 0x0018F688
		private void YGlobalCoordinateTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
		{
			for (;;)
			{
				if (e.Key != Key.Up)
				{
					goto IL_2F;
				}
				IInputElement xglobalCoordinateTextBox = this.XGlobalCoordinateTextBox;
				if (5 != 0)
				{
					FocusManager.SetFocusedElement(this, xglobalCoordinateTextBox);
				}
				IL_16:
				if (3 != 0)
				{
					if (false)
					{
						continue;
					}
					this.XGlobalCoordinateTextBox.Focus();
					bool handled = true;
					if (!false)
					{
						e.Handled = handled;
					}
				}
				IL_2F:
				if (true)
				{
					break;
				}
				goto IL_16;
			}
		}

		// Token: 0x060066C3 RID: 26307 RVA: 0x001914D8 File Offset: 0x0018F6D8
		private void XGlobalCoordinateTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
		{
			for (;;)
			{
				if (e.Key != Key.Down)
				{
					goto IL_2F;
				}
				IInputElement yglobalCoordinateTextBox = this.YGlobalCoordinateTextBox;
				if (5 != 0)
				{
					FocusManager.SetFocusedElement(this, yglobalCoordinateTextBox);
				}
				IL_16:
				if (3 != 0)
				{
					if (false)
					{
						continue;
					}
					this.YGlobalCoordinateTextBox.Focus();
					bool handled = true;
					if (!false)
					{
						e.Handled = handled;
					}
				}
				IL_2F:
				if (true)
				{
					break;
				}
				goto IL_16;
			}
		}

		// Token: 0x060066C4 RID: 26308 RVA: 0x00191528 File Offset: 0x0018F728
		private void YLocalCoordinateTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
		{
			for (;;)
			{
				if (e.Key != Key.Up)
				{
					goto IL_2F;
				}
				IInputElement xlocalCoordinateTextBox = this.XLocalCoordinateTextBox;
				if (5 != 0)
				{
					FocusManager.SetFocusedElement(this, xlocalCoordinateTextBox);
				}
				IL_16:
				if (3 != 0)
				{
					if (false)
					{
						continue;
					}
					this.XLocalCoordinateTextBox.Focus();
					bool handled = true;
					if (!false)
					{
						e.Handled = handled;
					}
				}
				IL_2F:
				if (true)
				{
					break;
				}
				goto IL_16;
			}
		}

		// Token: 0x060066C5 RID: 26309 RVA: 0x00191578 File Offset: 0x0018F778
		private void XLocalCoordinateTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
		{
			for (;;)
			{
				if (e.Key != Key.Down)
				{
					goto IL_2F;
				}
				IInputElement ylocalCoordinateTextBox = this.YLocalCoordinateTextBox;
				if (5 != 0)
				{
					FocusManager.SetFocusedElement(this, ylocalCoordinateTextBox);
				}
				IL_16:
				if (3 != 0)
				{
					if (false)
					{
						continue;
					}
					this.YLocalCoordinateTextBox.Focus();
					bool handled = true;
					if (!false)
					{
						e.Handled = handled;
					}
				}
				IL_2F:
				if (true)
				{
					break;
				}
				goto IL_16;
			}
		}

		// Token: 0x060066C6 RID: 26310 RVA: 0x001915C8 File Offset: 0x0018F7C8
		private void AngleCoordinateTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
		{
			for (;;)
			{
				if (e.Key != Key.Down)
				{
					goto IL_2F;
				}
				IInputElement radiusCoordinateTextBox = this.RadiusCoordinateTextBox;
				if (5 != 0)
				{
					FocusManager.SetFocusedElement(this, radiusCoordinateTextBox);
				}
				IL_16:
				if (3 != 0)
				{
					if (false)
					{
						continue;
					}
					this.RadiusCoordinateTextBox.Focus();
					bool handled = true;
					if (!false)
					{
						e.Handled = handled;
					}
				}
				IL_2F:
				if (true)
				{
					break;
				}
				goto IL_16;
			}
		}

		// Token: 0x060066C7 RID: 26311 RVA: 0x00191618 File Offset: 0x0018F818
		private void RadiusCoordinateTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
		{
			for (;;)
			{
				if (e.Key != Key.Up)
				{
					goto IL_2F;
				}
				IInputElement angleCoordinateTextBox = this.AngleCoordinateTextBox;
				if (5 != 0)
				{
					FocusManager.SetFocusedElement(this, angleCoordinateTextBox);
				}
				IL_16:
				if (3 != 0)
				{
					if (false)
					{
						continue;
					}
					this.AngleCoordinateTextBox.Focus();
					bool handled = true;
					if (!false)
					{
						e.Handled = handled;
					}
				}
				IL_2F:
				if (true)
				{
					break;
				}
				goto IL_16;
			}
		}

		// Token: 0x060066C8 RID: 26312 RVA: 0x00191668 File Offset: 0x0018F868
		private void PrecisePointInputControl_KeyDown(object sender, KeyEventArgs e)
		{
			while (e.Key != Key.Escape)
			{
				if (e.Key == Key.Return)
				{
					bool requestClose = Keyboard.IsKeyDown(Key.RightCtrl) || Keyboard.IsKeyDown(Key.LeftCtrl);
					if (!false)
					{
						this.TryCommitInput(requestClose);
					}
					if (!false)
					{
						bool handled = true;
						if (!false)
						{
							e.Handled = handled;
						}
					}
					return;
				}
				if (e.Key == Key.G)
				{
					if (8 != 0)
					{
						PreciseInputControlDataContext preciseDataContext = this.PreciseDataContext;
						#8Tc #f = #8Tc.#a;
						if (5 != 0)
						{
							preciseDataContext.CoordinateType = #f;
						}
						bool handled2 = true;
						if (!false)
						{
							e.Handled = handled2;
						}
						return;
					}
				}
				else
				{
					if (e.Key != Key.L)
					{
						if (e.Key == Key.P)
						{
							this.PreciseDataContext.CoordinateType = #8Tc.#c;
							e.Handled = true;
						}
						return;
					}
					this.PreciseDataContext.CoordinateType = #8Tc.#b;
				}
				e.Handled = true;
				if (5 != 0)
				{
					return;
				}
			}
			if (7 != 0)
			{
				this.MyRaisePreciseInputCanceled();
			}
			bool handled3 = true;
			if (-1 != 0)
			{
				e.Handled = handled3;
			}
		}

		// Token: 0x060066C9 RID: 26313 RVA: 0x00191764 File Offset: 0x0018F964
		private void MyUpdateFocus()
		{
			TextBox textBox = null;
			TextBox textBox2;
			if (!false)
			{
				textBox2 = textBox;
			}
			#8Tc #8Tc = this.PreciseDataContext.CoordinateType;
			#8Tc #8Tc2;
			if (!false)
			{
				#8Tc2 = #8Tc;
			}
			if (true)
			{
				TextBox textBox3;
				switch (#8Tc2)
				{
				case #8Tc.#a:
					if (!this.PreciseDataContext.XGlobal.IsEnabled)
					{
						textBox3 = this.YGlobalCoordinateTextBox;
						goto IL_54;
					}
					goto IL_4B;
				case #8Tc.#b:
				{
					if (7 == 0)
					{
						goto IL_4B;
					}
					TextBox textBox4 = this.PreciseDataContext.XLocal.IsEnabled ? this.XLocalCoordinateTextBox : this.YLocalCoordinateTextBox;
					if (!false)
					{
						textBox2 = textBox4;
					}
					break;
				}
				case #8Tc.#c:
				{
					TextBox textBox5 = this.PreciseDataContext.Angle.IsEnabled ? this.AngleCoordinateTextBox : this.RadiusCoordinateTextBox;
					if (!false)
					{
						textBox2 = textBox5;
					}
					break;
				}
				}
				goto IL_2F;
				IL_4B:
				if (false)
				{
					goto IL_AA;
				}
				textBox3 = this.XGlobalCoordinateTextBox;
				IL_54:
				if (!false)
				{
					textBox2 = textBox3;
				}
			}
			IL_2F:
			IL_81:
			if (textBox2 == null)
			{
				return;
			}
			IL_AA:
			if (false)
			{
				goto IL_81;
			}
			textBox2.Focus();
			Keyboard.Focus(textBox2);
		}

		// Token: 0x060066CA RID: 26314 RVA: 0x00191844 File Offset: 0x0018FA44
		public void InitializeInput(PreciseInputParameters initializeInputParameters)
		{
			if (-1 != 0)
			{
				string #R0d = #Phc.#3hc(107441594);
				StructurePoint.CoreAssets.Infrastructure.Exceptions.Component #x6c = StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.DesktopControls;
				string #Qic = #Phc.#3hc(107441557);
				if (6 != 0)
				{
					#X0d.#V0d(initializeInputParameters, #R0d, #x6c, #Qic);
				}
				this.lastParameters = initializeInputParameters;
				PreciseInputControlDataContext preciseDataContext = this.PreciseDataContext;
				if (6 != 0)
				{
					preciseDataContext.#WUc(initializeInputParameters);
				}
				if (false || false)
				{
					return;
				}
				if (2 != 0)
				{
					this.MyUpdateFocus();
				}
			}
			object sender = null;
			EventArgs e = null;
			if (5 != 0)
			{
				this.PrecisePointInputControlDataContext_CoordinateChanged(sender, e);
			}
		}

		// Token: 0x060066CB RID: 26315 RVA: 0x001918B4 File Offset: 0x0018FAB4
		public void TryCommitInput(bool requestClose)
		{
			bool flag2;
			do
			{
				MouseAndKeyboardService mouseAndKeyboardService = new MouseAndKeyboardService();
				if (4 != 0)
				{
					mouseAndKeyboardService.#mNb();
				}
				PreciseInputControlDataContext preciseDataContext = this.PreciseDataContext;
				if (!false)
				{
					preciseDataContext.#cg();
				}
				bool flag = flag2 = this.PreciseDataContext.IsValid;
				if (false)
				{
					goto IL_28;
				}
				if (flag)
				{
					goto IL_27;
				}
			}
			while (2 == 0);
			return;
			IL_27:
			flag2 = requestClose;
			IL_28:
			bool requestClose2;
			if (!false)
			{
				requestClose2 = flag2;
			}
			do
			{
				if (this.lastParameters != null && this.lastParameters.CloseAfterInsert)
				{
					bool flag3 = true;
					if (!false)
					{
						requestClose2 = flag3;
					}
				}
				PreciseInputCompletedEventArgs preciseInputCompletedEventArgs = new PreciseInputCompletedEventArgs(this.PreciseDataContext.ResultPoint, requestClose2);
				if (!false)
				{
					this.MyRaisePreciseInputCompleted(preciseInputCompletedEventArgs);
				}
			}
			while (5 == 0);
		}

		// Token: 0x060066CC RID: 26316 RVA: 0x0019193C File Offset: 0x0018FB3C
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

		// Token: 0x060066CD RID: 26317 RVA: 0x00191970 File Offset: 0x0018FB70
		private void MyRaisePreciseInputChanged(PreciseInputChangedEventArgs preciseInputChangedEventArgs)
		{
			EventHandler<PreciseInputChangedEventArgs> preciseInputChanged = this.PreciseInputChanged;
			EventHandler<PreciseInputChangedEventArgs> eventHandler;
			if (!false)
			{
				eventHandler = preciseInputChanged;
			}
			if (eventHandler != null)
			{
				EventHandler<PreciseInputChangedEventArgs> eventHandler2 = eventHandler;
				if (!false)
				{
					eventHandler2(this, preciseInputChangedEventArgs);
				}
			}
		}

		// Token: 0x060066CE RID: 26318 RVA: 0x001919A0 File Offset: 0x0018FBA0
		private void MyRaisePreciseInputCompleted(PreciseInputCompletedEventArgs preciseInputCompletedEventArgs)
		{
			EventHandler<PreciseInputCompletedEventArgs> preciseInputCompleted = this.PreciseInputCompleted;
			EventHandler<PreciseInputCompletedEventArgs> eventHandler;
			if (!false)
			{
				eventHandler = preciseInputCompleted;
			}
			if (eventHandler != null)
			{
				EventHandler<PreciseInputCompletedEventArgs> eventHandler2 = eventHandler;
				if (!false)
				{
					eventHandler2(this, preciseInputCompletedEventArgs);
				}
			}
		}

		// Token: 0x060066CF RID: 26319 RVA: 0x001919D0 File Offset: 0x0018FBD0
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
						int num2 = num = 107441472;
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

		// Token: 0x060066D0 RID: 26320 RVA: 0x00191A1C File Offset: 0x0018FC1C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
		[SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
		[SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				this.TabControl = (RadTabControl)target;
				return;
			case 2:
				this.GlobalTab = (RadTabItem)target;
				return;
			case 3:
				break;
			case 4:
				this.YGlobalCoordinateTextBox = (UnitValueTextBox)target;
				return;
			case 5:
				this.LocalTab = (RadTabItem)target;
				return;
			case 6:
				this.XLocalCoordinateTextBox = (UnitValueTextBox)target;
				return;
			case 7:
				do
				{
					this.YLocalCoordinateTextBox = (UnitValueTextBox)target;
				}
				while (false);
				return;
			case 8:
				this.PolarTab = (RadTabItem)target;
				return;
			case 9:
				this.AngleCoordinateTextBox = (CustomTextBox)target;
				return;
			case 10:
				this.RadiusCoordinateTextBox = (UnitValueTextBox)target;
				return;
			case 11:
				this.InsertButton = (RadButton)target;
				if (8 != 0)
				{
					return;
				}
				break;
			case 12:
				this.InsertAndCloseButton = (RadButton)target;
				if (5 != 0)
				{
					return;
				}
				return;
			case 13:
				this.CancelButton = (RadButton)target;
				return;
			default:
				if (!false)
				{
					this._contentLoaded = true;
					return;
				}
				return;
			}
			this.XGlobalCoordinateTextBox = (UnitValueTextBox)target;
		}

		// Token: 0x04002A54 RID: 10836
		private PreciseInputParameters lastParameters;

		// Token: 0x04002A58 RID: 10840
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal RadTabControl TabControl;

		// Token: 0x04002A59 RID: 10841
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal RadTabItem GlobalTab;

		// Token: 0x04002A5A RID: 10842
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal UnitValueTextBox XGlobalCoordinateTextBox;

		// Token: 0x04002A5B RID: 10843
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal UnitValueTextBox YGlobalCoordinateTextBox;

		// Token: 0x04002A5C RID: 10844
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal RadTabItem LocalTab;

		// Token: 0x04002A5D RID: 10845
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal UnitValueTextBox XLocalCoordinateTextBox;

		// Token: 0x04002A5E RID: 10846
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal UnitValueTextBox YLocalCoordinateTextBox;

		// Token: 0x04002A5F RID: 10847
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal RadTabItem PolarTab;

		// Token: 0x04002A60 RID: 10848
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal CustomTextBox AngleCoordinateTextBox;

		// Token: 0x04002A61 RID: 10849
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal UnitValueTextBox RadiusCoordinateTextBox;

		// Token: 0x04002A62 RID: 10850
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal RadButton InsertButton;

		// Token: 0x04002A63 RID: 10851
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal RadButton InsertAndCloseButton;

		// Token: 0x04002A64 RID: 10852
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal RadButton CancelButton;

		// Token: 0x04002A65 RID: 10853
		private bool _contentLoaded;
	}
}
