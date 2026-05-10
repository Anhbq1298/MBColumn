using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;
using #7hc;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor.ViewControlsPanel;
using StructurePoint.CoreAssets.GUI.DesktopControls.Utils;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor
{
	// Token: 0x02000931 RID: 2353
	internal sealed class ZoomPanel : UserControl, IComponentConnector
	{
		// Token: 0x06004C9E RID: 19614 RVA: 0x0014CEAC File Offset: 0x0014B0AC
		public ZoomPanel()
		{
			this.InitializeComponent();
			this.Equation = new LinearEquation();
			this.MinusButton.Click += this.MinusButton_Click;
			this.PlusButton.Click += this.PlusButton_Click;
			this.OnCameraTypePropertyChanged();
			BindingHelper.SetBinding<DoubleCollection>(new BindingHelperParametersContainer<DoubleCollection>
			{
				Target = this.ScaleSlider,
				TargetProperty = RadSlider.TicksProperty,
				Source = this,
				PropertyExpression = (() => this.SliderTicks),
				BindingMode = BindingMode.OneWay
			}, false);
		}

		// Token: 0x1400011E RID: 286
		// (add) Token: 0x06004C9F RID: 19615 RVA: 0x0014CF6C File Offset: 0x0014B16C
		// (remove) Token: 0x06004CA0 RID: 19616 RVA: 0x0014CFB0 File Offset: 0x0014B1B0
		public event EventHandler LargeCameraDistanceChange;

		// Token: 0x06004CA1 RID: 19617 RVA: 0x0014CFF4 File Offset: 0x0014B1F4
		protected void OnLargeCameraDistanceChange()
		{
			EventHandler largeCameraDistanceChange = this.LargeCameraDistanceChange;
			if (largeCameraDistanceChange != null)
			{
				largeCameraDistanceChange(this, EventArgs.Empty);
			}
		}

		// Token: 0x06004CA2 RID: 19618 RVA: 0x0014D024 File Offset: 0x0014B224
		public void PlusButton_Click(object sender, RoutedEventArgs e)
		{
			CameraType cameraType = this.CameraType;
			if (cameraType != CameraType.Perspective)
			{
				if (cameraType != CameraType.Orthographic)
				{
					throw new InvalidOperationException(#Phc.#3hc(107403566));
				}
				this.MyProcessPlusButtonClickForOrtographicCamera();
			}
			else
			{
				this.MyProcessPlusButtonClickForPerspectiveCamera();
			}
			this.OnLargeCameraDistanceChange();
		}

		// Token: 0x06004CA3 RID: 19619 RVA: 0x0014D074 File Offset: 0x0014B274
		public void MinusButton_Click(object sender, RoutedEventArgs e)
		{
			CameraType cameraType = this.CameraType;
			if (cameraType != CameraType.Perspective)
			{
				if (cameraType != CameraType.Orthographic)
				{
					throw new InvalidOperationException(#Phc.#3hc(107403566));
				}
				this.MyProcessMinusButtonClickForOrtographicCamera();
			}
			else
			{
				this.MyProcessMinusButtonClickForPerspectiveCamera();
			}
			this.OnLargeCameraDistanceChange();
		}

		// Token: 0x06004CA4 RID: 19620 RVA: 0x000402AC File Offset: 0x0003E4AC
		[SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1108:BlockStatementsMustNotContainEmbeddedComments", Justification = "Reviewed. Suppression is OK here.")]
		[SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1407:ArithmeticExpressionsMustDeclarePrecedence", Justification = "Reviewed. Suppression is OK here.")]
		private void MyProcessMinusButtonClickForPerspectiveCamera()
		{
			this.Distance = (this.Distance / ModelEditorParametersStorage.OneHundredPercentDistance + 0.1) * ModelEditorParametersStorage.OneHundredPercentDistance;
		}

		// Token: 0x06004CA5 RID: 19621 RVA: 0x000402DC File Offset: 0x0003E4DC
		[SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1108:BlockStatementsMustNotContainEmbeddedComments", Justification = "Reviewed. Suppression is OK here.")]
		[SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1407:ArithmeticExpressionsMustDeclarePrecedence", Justification = "Reviewed. Suppression is OK here.")]
		private void MyProcessPlusButtonClickForPerspectiveCamera()
		{
			this.Distance = (this.Distance / ModelEditorParametersStorage.OneHundredPercentDistance - 0.1) * ModelEditorParametersStorage.OneHundredPercentDistance;
		}

		// Token: 0x06004CA6 RID: 19622 RVA: 0x0004030C File Offset: 0x0003E50C
		private void MyProcessMinusButtonClickForOrtographicCamera()
		{
			this.CameraWidth = (this.CameraWidth / this.ReferenceCameraWidth + 0.1) * this.ReferenceCameraWidth;
		}

		// Token: 0x06004CA7 RID: 19623 RVA: 0x0004033E File Offset: 0x0003E53E
		private void MyProcessPlusButtonClickForOrtographicCamera()
		{
			this.CameraWidth = (this.CameraWidth / this.ReferenceCameraWidth - 0.1) * this.ReferenceCameraWidth;
		}

		// Token: 0x1700164E RID: 5710
		// (get) Token: 0x06004CA8 RID: 19624 RVA: 0x00040370 File Offset: 0x0003E570
		// (set) Token: 0x06004CA9 RID: 19625 RVA: 0x0004038A File Offset: 0x0003E58A
		public double CameraWidthScale
		{
			get
			{
				return (double)base.GetValue(ZoomPanel.CameraWidthScaleProperty);
			}
			set
			{
				base.SetValue(ZoomPanel.CameraWidthScaleProperty, value);
			}
		}

		// Token: 0x1700164F RID: 5711
		// (get) Token: 0x06004CAA RID: 19626 RVA: 0x000403A9 File Offset: 0x0003E5A9
		// (set) Token: 0x06004CAB RID: 19627 RVA: 0x000403C3 File Offset: 0x0003E5C3
		public CameraType CameraType
		{
			get
			{
				return (CameraType)base.GetValue(ZoomPanel.CameraTypeProperty);
			}
			set
			{
				base.SetValue(ZoomPanel.CameraTypeProperty, value);
			}
		}

		// Token: 0x06004CAC RID: 19628 RVA: 0x000403E2 File Offset: 0x0003E5E2
		private static void CameraTypePropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
		{
			((ZoomPanel)dependencyObject).OnCameraTypePropertyChanged();
		}

		// Token: 0x06004CAD RID: 19629 RVA: 0x0014D0C4 File Offset: 0x0014B2C4
		protected internal void OnCameraTypePropertyChanged()
		{
			BindingHelper.ClearBinding(this.ScaleSlider, RangeBase.MinimumProperty);
			BindingHelper.ClearBinding(this.ScaleSlider, RangeBase.MaximumProperty);
			BindingHelper.ClearBinding(this.ScaleSlider, RangeBase.ValueProperty);
			BindingHelper.ClearBinding(this.ScaleSliderValueLabel, TextBlock.TextProperty);
			if (this.CameraType == CameraType.Perspective)
			{
				BindingHelper.SetBinding<double>(new BindingHelperParametersContainer<double>
				{
					Target = this.ScaleSlider,
					TargetProperty = RangeBase.MinimumProperty,
					Source = this.Equation,
					PropertyExpression = (() => this.Equation.MinArgument),
					BindingMode = BindingMode.OneWay,
					FallbackValue = 0.0
				}, false);
				BindingHelper.SetBinding<double>(new BindingHelperParametersContainer<double>
				{
					Target = this.ScaleSlider,
					TargetProperty = RangeBase.MaximumProperty,
					Source = this.Equation,
					PropertyExpression = (() => this.Equation.MaxArgument),
					BindingMode = BindingMode.OneWay,
					FallbackValue = 1.0
				}, false);
				BindingHelper.SetBinding<double>(new BindingHelperParametersContainer<double>
				{
					Target = this.ScaleSlider,
					TargetProperty = RangeBase.ValueProperty,
					Source = this,
					PropertyExpression = (() => this.Distance),
					BindingMode = BindingMode.TwoWay,
					FallbackValue = 0.5,
					Converter = new SliderToDisplayConverter(),
					ConverterParameter = this.Equation
				}, true);
				BindingHelper.SetBinding<double>(new BindingHelperParametersContainer<double>
				{
					Target = this.ScaleSliderValueLabel,
					TargetProperty = TextBlock.TextProperty,
					Source = this,
					PropertyExpression = (() => this.DistanceScale),
					BindingMode = BindingMode.OneWay,
					Format = #Phc.#3hc(107470600)
				}, false);
				return;
			}
			if (this.CameraType == CameraType.Orthographic)
			{
				BindingHelper.SetBinding<double>(new BindingHelperParametersContainer<double>
				{
					Target = this.ScaleSlider,
					TargetProperty = RangeBase.MinimumProperty,
					Source = this.Equation,
					PropertyExpression = (() => this.Equation.MinArgument),
					BindingMode = BindingMode.OneWay,
					FallbackValue = 0.0
				}, false);
				BindingHelper.SetBinding<double>(new BindingHelperParametersContainer<double>
				{
					Target = this.ScaleSlider,
					TargetProperty = RangeBase.MaximumProperty,
					Source = this.Equation,
					PropertyExpression = (() => this.Equation.MaxArgument),
					BindingMode = BindingMode.OneWay,
					FallbackValue = 1.0
				}, false);
				BindingHelper.SetBinding<double>(new BindingHelperParametersContainer<double>
				{
					Target = this.ScaleSlider,
					TargetProperty = RangeBase.ValueProperty,
					Source = this,
					PropertyExpression = (() => this.CameraWidth),
					BindingMode = BindingMode.TwoWay,
					FallbackValue = 0.5,
					Converter = new SliderToDisplayConverter(),
					ConverterParameter = this.Equation
				}, true);
				BindingHelper.SetBinding<double>(new BindingHelperParametersContainer<double>
				{
					Target = this.ScaleSliderValueLabel,
					TargetProperty = TextBlock.TextProperty,
					Source = this,
					PropertyExpression = (() => this.CameraWidthScale),
					BindingMode = BindingMode.OneWay,
					Format = #Phc.#3hc(107470623)
				}, false);
			}
		}

		// Token: 0x17001650 RID: 5712
		// (get) Token: 0x06004CAE RID: 19630 RVA: 0x000403F7 File Offset: 0x0003E5F7
		// (set) Token: 0x06004CAF RID: 19631 RVA: 0x00040411 File Offset: 0x0003E611
		public double ReferenceCameraWidth
		{
			get
			{
				return (double)base.GetValue(ZoomPanel.ReferenceCameraWidthProperty);
			}
			set
			{
				base.SetValue(ZoomPanel.ReferenceCameraWidthProperty, value);
			}
		}

		// Token: 0x17001651 RID: 5713
		// (get) Token: 0x06004CB0 RID: 19632 RVA: 0x00040430 File Offset: 0x0003E630
		// (set) Token: 0x06004CB1 RID: 19633 RVA: 0x0004044A File Offset: 0x0003E64A
		public double CameraWidth
		{
			get
			{
				return (double)base.GetValue(ZoomPanel.CameraWidthProperty);
			}
			set
			{
				base.SetValue(ZoomPanel.CameraWidthProperty, value);
			}
		}

		// Token: 0x17001652 RID: 5714
		// (get) Token: 0x06004CB2 RID: 19634 RVA: 0x00040469 File Offset: 0x0003E669
		// (set) Token: 0x06004CB3 RID: 19635 RVA: 0x00040483 File Offset: 0x0003E683
		public double DistanceScale
		{
			get
			{
				return (double)base.GetValue(ZoomPanel.DistanceScaleProperty);
			}
			set
			{
				base.SetValue(ZoomPanel.DistanceScaleProperty, value);
			}
		}

		// Token: 0x17001653 RID: 5715
		// (get) Token: 0x06004CB4 RID: 19636 RVA: 0x000404A2 File Offset: 0x0003E6A2
		// (set) Token: 0x06004CB5 RID: 19637 RVA: 0x000404BC File Offset: 0x0003E6BC
		public double ReferenceDistance
		{
			get
			{
				return (double)base.GetValue(ZoomPanel.ReferenceDistanceProperty);
			}
			set
			{
				base.SetValue(ZoomPanel.ReferenceDistanceProperty, value);
			}
		}

		// Token: 0x17001654 RID: 5716
		// (get) Token: 0x06004CB6 RID: 19638 RVA: 0x000404DB File Offset: 0x0003E6DB
		// (set) Token: 0x06004CB7 RID: 19639 RVA: 0x000404F5 File Offset: 0x0003E6F5
		public double Distance
		{
			get
			{
				return (double)base.GetValue(ZoomPanel.DistanceProperty);
			}
			set
			{
				base.SetValue(ZoomPanel.DistanceProperty, value);
			}
		}

		// Token: 0x17001655 RID: 5717
		// (get) Token: 0x06004CB8 RID: 19640 RVA: 0x00040514 File Offset: 0x0003E714
		// (set) Token: 0x06004CB9 RID: 19641 RVA: 0x00040520 File Offset: 0x0003E720
		public LinearEquation Equation { get; private set; }

		// Token: 0x17001656 RID: 5718
		// (get) Token: 0x06004CBA RID: 19642 RVA: 0x00040531 File Offset: 0x0003E731
		// (set) Token: 0x06004CBB RID: 19643 RVA: 0x0004054B File Offset: 0x0003E74B
		public DoubleCollection SliderTicks
		{
			get
			{
				return (DoubleCollection)base.GetValue(ZoomPanel.SliderTicksProperty);
			}
			set
			{
				base.SetValue(ZoomPanel.SliderTicksProperty, value);
			}
		}

		// Token: 0x06004CBC RID: 19644 RVA: 0x0014D5AC File Offset: 0x0014B7AC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107470618), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06004CBD RID: 19645 RVA: 0x0014D5F0 File Offset: 0x0014B7F0
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
				this.MinusButton = (RadButton)target;
				return;
			case 2:
				this.ScaleSlider = (RadSlider)target;
				return;
			case 3:
				this.PlusButton = (RadButton)target;
				return;
			case 4:
				this.ScaleSliderValueLabel = (TextBlock)target;
				return;
			default:
				this._contentLoaded = true;
				return;
			}
		}

		// Token: 0x040021D5 RID: 8661
		private const double CnstScaleEpsilon = 0.001;

		// Token: 0x040021D7 RID: 8663
		public static readonly DependencyProperty CameraWidthScaleProperty = DependencyProperty.Register(#Phc.#3hc(107451306), typeof(double), typeof(ZoomPanel), new FrameworkPropertyMetadata(1.0));

		// Token: 0x040021D8 RID: 8664
		public static readonly DependencyProperty CameraTypeProperty = DependencyProperty.Register(#Phc.#3hc(107403566), typeof(CameraType), typeof(ZoomPanel), new FrameworkPropertyMetadata(CameraType.Perspective, new PropertyChangedCallback(ZoomPanel.CameraTypePropertyChanged)));

		// Token: 0x040021D9 RID: 8665
		public static readonly DependencyProperty ReferenceCameraWidthProperty = DependencyProperty.Register(#Phc.#3hc(107451313), typeof(double), typeof(ZoomPanel), new FrameworkPropertyMetadata(1.0));

		// Token: 0x040021DA RID: 8666
		public static readonly DependencyProperty CameraWidthProperty = DependencyProperty.Register(#Phc.#3hc(107471609), typeof(double), typeof(ZoomPanel), new FrameworkPropertyMetadata(0.0));

		// Token: 0x040021DB RID: 8667
		public static readonly DependencyProperty DistanceScaleProperty = DependencyProperty.Register(#Phc.#3hc(107450891), typeof(double), typeof(ZoomPanel), new FrameworkPropertyMetadata(0.0));

		// Token: 0x040021DC RID: 8668
		public static readonly DependencyProperty ReferenceDistanceProperty = DependencyProperty.Register(#Phc.#3hc(107451365), typeof(double), typeof(ZoomPanel), new FrameworkPropertyMetadata(100.0));

		// Token: 0x040021DD RID: 8669
		public static readonly DependencyProperty DistanceProperty = DependencyProperty.Register(#Phc.#3hc(107469997), typeof(double), typeof(ZoomPanel), new FrameworkPropertyMetadata(100.0));

		// Token: 0x040021DF RID: 8671
		public static readonly DependencyProperty SliderTicksProperty = DependencyProperty.Register(#Phc.#3hc(107469984), typeof(DoubleCollection), typeof(ZoomPanel), new FrameworkPropertyMetadata(new DoubleCollection(new double[]
		{
			0.5
		})));

		// Token: 0x040021E0 RID: 8672
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal RadButton MinusButton;

		// Token: 0x040021E1 RID: 8673
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal RadSlider ScaleSlider;

		// Token: 0x040021E2 RID: 8674
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal RadButton PlusButton;

		// Token: 0x040021E3 RID: 8675
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal TextBlock ScaleSliderValueLabel;

		// Token: 0x040021E4 RID: 8676
		private bool _contentLoaded;
	}
}
