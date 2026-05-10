using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Media.Media3D;
using #7hc;
using #u3d;
using Ab3d.Cameras;
using Ab3d.Common.Cameras;
using Ab3d.Utilities;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;
using StructurePoint.CoreAssets.GUI.DesktopControls.Ribbon;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Utils
{
	// Token: 0x020008E1 RID: 2273
	[CLSCompliant(false)]
	public sealed class CustomTargetPositionCamera : TargetPositionCamera
	{
		// Token: 0x060047FA RID: 18426 RVA: 0x00142C5C File Offset: 0x00140E5C
		[SuppressMessage("Microsoft.Performance", "CA1810:InitializeReferenceTypeStaticFieldsInline")]
		static CustomTargetPositionCamera()
		{
			BaseTargetPositionCamera.DistanceProperty.OverrideMetadata(typeof(CustomTargetPositionCamera), new FrameworkPropertyMetadata(100.0, FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(BaseCamera.CameraPropertyChanged), new CoerceValueCallback(CustomTargetPositionCamera.MyCameraDistanceCoerceValueCallback)));
			BaseCamera.CameraWidthProperty.OverrideMetadata(typeof(CustomTargetPositionCamera), new FrameworkPropertyMetadata(100.0, FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(BaseCamera.CameraWidthPropertyChanged), new CoerceValueCallback(CustomTargetPositionCamera.MyCameraWidthCoerceValueCallback)));
		}

		// Token: 0x060047FB RID: 18427 RVA: 0x0003CBBB File Offset: 0x0003ADBB
		public CustomTargetPositionCamera()
		{
			base.CameraChanged += this.CustomTargetPositionCamera_CameraChanged;
			base.CameraType = BaseCamera.CameraTypes.PerspectiveCamera;
			this.UpdateDependentValuesOnBoundValueChanged = true;
		}

		// Token: 0x060047FC RID: 18428 RVA: 0x00142FD8 File Offset: 0x001411D8
		private void CustomTargetPositionCamera_CameraChanged(object sender, CameraChangedRoutedEventArgs e)
		{
			if (this.UpdateDependentValuesOnBoundValueChanged && base.CameraType == BaseCamera.CameraTypes.PerspectiveCamera)
			{
				this.RecalculateDistanceScale();
				this.RecalculateDisplayScale();
			}
			else if (this.UpdateDependentValuesOnBoundValueChanged && base.CameraType == BaseCamera.CameraTypes.OrthographicCamera)
			{
				this.RecalculateCameraWidthScale();
			}
			this.OnDistanceOrAttitudeOrHeadingChanged();
		}

		// Token: 0x060047FD RID: 18429 RVA: 0x0014302C File Offset: 0x0014122C
		public void Reset(StructurePoint.CoreAssets.Infrastructure.Data.Point3D targetPosition)
		{
			this.BeginInit();
			base.Heading = 0.0;
			base.Attitude = 0.0;
			base.Distance = 300.0;
			base.Offset = new Vector3D(0.0, 0.0, 0.0);
			base.TargetPosition = targetPosition.Convert();
			this.EndInit();
			base.Refresh();
		}

		// Token: 0x060047FE RID: 18430 RVA: 0x001430BC File Offset: 0x001412BC
		public bool IsCameraInDefault2DPosition()
		{
			return base.Heading == 0.0 && base.Attitude == 0.0 && base.Bank == 0.0;
		}

		// Token: 0x060047FF RID: 18431 RVA: 0x0014310C File Offset: 0x0014130C
		[SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "2#")]
		public bool CreateMouseRay3D(StructurePoint.CoreAssets.Infrastructure.Data.Point point, out StructurePoint.CoreAssets.Infrastructure.Data.Point3D rayOrigin, out #c4d rayDirection)
		{
			System.Windows.Media.Media3D.Point3D point2;
			Vector3D vector;
			if (base.CreateMouseRay3D(point.Convert(), out point2, out vector))
			{
				rayOrigin = point2.Convert();
				rayDirection = vector.Convert();
				return true;
			}
			rayOrigin = default(StructurePoint.CoreAssets.Infrastructure.Data.Point3D);
			rayDirection = default(#c4d);
			return false;
		}

		// Token: 0x06004800 RID: 18432 RVA: 0x00143160 File Offset: 0x00141360
		protected override void SetCameraLookDirection(ProjectionCamera cameraToUpdate)
		{
			base.SetCameraLookDirection(cameraToUpdate);
			if (cameraToUpdate == null)
			{
				return;
			}
			Vector3D vector3D;
			Vector3D vector3D2;
			if (this.MainAxis == AxisName.Y)
			{
				CameraUtils.CalculateCameraDirections(base.Heading, base.Attitude, base.Bank, out vector3D, out vector3D2);
			}
			else
			{
				CustomTargetPositionCamera.MyCalculateCameraDirectionsForZAxis(base.Heading, base.Attitude, base.Bank, out vector3D, out vector3D2);
			}
			if (cameraToUpdate.LookDirection != vector3D)
			{
				cameraToUpdate.LookDirection = vector3D;
			}
			if (cameraToUpdate.UpDirection != vector3D2)
			{
				cameraToUpdate.UpDirection = vector3D2;
			}
		}

		// Token: 0x06004801 RID: 18433 RVA: 0x0003CBE3 File Offset: 0x0003ADE3
		public void RecalculateDistanceScale()
		{
			this.DistanceScale = Math.Round(ModelEditorParametersStorage.OneHundredPercentDistance / base.Distance, 2);
		}

		// Token: 0x06004802 RID: 18434 RVA: 0x0003CC09 File Offset: 0x0003AE09
		public void RecalculateDisplayScale()
		{
			this.DisplayScale = Math.Round(ModelEditorParametersStorage.OneHundredPercentDistance / base.Distance * 100.0);
		}

		// Token: 0x06004803 RID: 18435 RVA: 0x0003CC38 File Offset: 0x0003AE38
		public void RecalculateCameraWidthScale()
		{
			this.CameraWidthScale = Math.Round(this.ReferenceCameraWidth / base.CameraWidth, 2);
		}

		// Token: 0x06004804 RID: 18436 RVA: 0x0003CC5F File Offset: 0x0003AE5F
		public void RecalculateScale()
		{
			if (base.CameraType == BaseCamera.CameraTypes.PerspectiveCamera)
			{
				this.RecalculateDistanceScale();
				this.RecalculateDisplayScale();
				return;
			}
			this.RecalculateCameraWidthScale();
		}

		// Token: 0x06004805 RID: 18437 RVA: 0x00143200 File Offset: 0x00141400
		public void OnDistanceScaleChanged(SelectedValueChangedEventArgs<double> e)
		{
			EventHandler<SelectedValueChangedEventArgs<double>> distanceScaleChanged = this.DistanceScaleChanged;
			if (distanceScaleChanged != null)
			{
				distanceScaleChanged(this, e);
			}
		}

		// Token: 0x06004806 RID: 18438 RVA: 0x0014322C File Offset: 0x0014142C
		protected void OnCameraWidthScaleChanged(SelectedValueChangedEventArgs<double> e)
		{
			EventHandler<SelectedValueChangedEventArgs<double>> cameraWidthScaleChanged = this.CameraWidthScaleChanged;
			if (cameraWidthScaleChanged != null)
			{
				cameraWidthScaleChanged(this, e);
			}
		}

		// Token: 0x06004807 RID: 18439 RVA: 0x00143258 File Offset: 0x00141458
		protected void OnDistanceOrAttitudeOrHeadingChanged()
		{
			EventHandler distanceOrAttitudeOrHeadingChanged = this.DistanceOrAttitudeOrHeadingChanged;
			if (distanceOrAttitudeOrHeadingChanged != null)
			{
				distanceOrAttitudeOrHeadingChanged(this, new EventArgs());
			}
		}

		// Token: 0x140000E7 RID: 231
		// (add) Token: 0x06004808 RID: 18440 RVA: 0x00143288 File Offset: 0x00141488
		// (remove) Token: 0x06004809 RID: 18441 RVA: 0x001432CC File Offset: 0x001414CC
		public event EventHandler<SelectedValueChangedEventArgs<double>> DistanceScaleChanged;

		// Token: 0x140000E8 RID: 232
		// (add) Token: 0x0600480A RID: 18442 RVA: 0x00143310 File Offset: 0x00141510
		// (remove) Token: 0x0600480B RID: 18443 RVA: 0x00143354 File Offset: 0x00141554
		public event EventHandler<SelectedValueChangedEventArgs<double>> CameraWidthScaleChanged;

		// Token: 0x140000E9 RID: 233
		// (add) Token: 0x0600480C RID: 18444 RVA: 0x00143398 File Offset: 0x00141598
		// (remove) Token: 0x0600480D RID: 18445 RVA: 0x001433DC File Offset: 0x001415DC
		public event EventHandler DistanceOrAttitudeOrHeadingChanged;

		// Token: 0x17001510 RID: 5392
		// (get) Token: 0x0600480E RID: 18446 RVA: 0x0003CC88 File Offset: 0x0003AE88
		// (set) Token: 0x0600480F RID: 18447 RVA: 0x0003CCA2 File Offset: 0x0003AEA2
		public double MinDistance
		{
			get
			{
				return (double)base.GetValue(CustomTargetPositionCamera.MinDistanceProperty);
			}
			set
			{
				base.SetValue(CustomTargetPositionCamera.MinDistanceProperty, value);
			}
		}

		// Token: 0x17001511 RID: 5393
		// (get) Token: 0x06004810 RID: 18448 RVA: 0x0003CCC1 File Offset: 0x0003AEC1
		// (set) Token: 0x06004811 RID: 18449 RVA: 0x0003CCDB File Offset: 0x0003AEDB
		public double MaxDistance
		{
			get
			{
				return (double)base.GetValue(CustomTargetPositionCamera.MaxDistanceProperty);
			}
			set
			{
				base.SetValue(CustomTargetPositionCamera.MaxDistanceProperty, value);
			}
		}

		// Token: 0x17001512 RID: 5394
		// (get) Token: 0x06004812 RID: 18450 RVA: 0x0003CCFA File Offset: 0x0003AEFA
		// (set) Token: 0x06004813 RID: 18451 RVA: 0x0003CD14 File Offset: 0x0003AF14
		public double ReferenceDistance
		{
			get
			{
				return (double)base.GetValue(CustomTargetPositionCamera.ReferenceDistanceProperty);
			}
			set
			{
				base.SetValue(CustomTargetPositionCamera.ReferenceDistanceProperty, value);
			}
		}

		// Token: 0x17001513 RID: 5395
		// (get) Token: 0x06004814 RID: 18452 RVA: 0x0003CD33 File Offset: 0x0003AF33
		// (set) Token: 0x06004815 RID: 18453 RVA: 0x0003CD4D File Offset: 0x0003AF4D
		public double DistanceScale
		{
			get
			{
				return (double)base.GetValue(CustomTargetPositionCamera.DistanceScaleProperty);
			}
			protected set
			{
				double distanceScale = this.DistanceScale;
				base.SetValue(CustomTargetPositionCamera.DistanceScalePropertyKey, value);
			}
		}

		// Token: 0x17001514 RID: 5396
		// (get) Token: 0x06004816 RID: 18454 RVA: 0x0003CD75 File Offset: 0x0003AF75
		// (set) Token: 0x06004817 RID: 18455 RVA: 0x0003CD8F File Offset: 0x0003AF8F
		public double DisplayScale
		{
			get
			{
				return (double)base.GetValue(CustomTargetPositionCamera.DisplayScaleProperty);
			}
			protected set
			{
				base.SetValue(CustomTargetPositionCamera.DisplayScalePropertyKey, value);
			}
		}

		// Token: 0x17001515 RID: 5397
		// (get) Token: 0x06004818 RID: 18456 RVA: 0x0003CDAE File Offset: 0x0003AFAE
		// (set) Token: 0x06004819 RID: 18457 RVA: 0x0003CDC8 File Offset: 0x0003AFC8
		public double MinCameraWidth
		{
			get
			{
				return (double)base.GetValue(CustomTargetPositionCamera.MinCameraWidthProperty);
			}
			set
			{
				base.SetValue(CustomTargetPositionCamera.MinCameraWidthProperty, value);
			}
		}

		// Token: 0x17001516 RID: 5398
		// (get) Token: 0x0600481A RID: 18458 RVA: 0x0003CDE7 File Offset: 0x0003AFE7
		// (set) Token: 0x0600481B RID: 18459 RVA: 0x0003CE01 File Offset: 0x0003B001
		public double MaxCameraWidth
		{
			get
			{
				return (double)base.GetValue(CustomTargetPositionCamera.MaxCameraWidthProperty);
			}
			set
			{
				base.SetValue(CustomTargetPositionCamera.MaxCameraWidthProperty, value);
			}
		}

		// Token: 0x17001517 RID: 5399
		// (get) Token: 0x0600481C RID: 18460 RVA: 0x0003CE20 File Offset: 0x0003B020
		// (set) Token: 0x0600481D RID: 18461 RVA: 0x0003CE3A File Offset: 0x0003B03A
		public double ReferenceCameraWidth
		{
			get
			{
				return (double)base.GetValue(CustomTargetPositionCamera.ReferenceCameraWidthProperty);
			}
			set
			{
				base.SetValue(CustomTargetPositionCamera.ReferenceCameraWidthProperty, value);
			}
		}

		// Token: 0x17001518 RID: 5400
		// (get) Token: 0x0600481E RID: 18462 RVA: 0x0003CE59 File Offset: 0x0003B059
		// (set) Token: 0x0600481F RID: 18463 RVA: 0x0003CE73 File Offset: 0x0003B073
		public double CameraWidthScale
		{
			get
			{
				return (double)base.GetValue(CustomTargetPositionCamera.WidthScaleProperty);
			}
			protected set
			{
				double cameraWidthScale = this.CameraWidthScale;
				base.SetValue(CustomTargetPositionCamera.CameraWidthScalePropertyKey, value);
				if (cameraWidthScale != value)
				{
					this.OnCameraWidthScaleChanged(new SelectedValueChangedEventArgs<double>(value));
				}
			}
		}

		// Token: 0x17001519 RID: 5401
		// (get) Token: 0x06004820 RID: 18464 RVA: 0x0003CEA7 File Offset: 0x0003B0A7
		// (set) Token: 0x06004821 RID: 18465 RVA: 0x0003CEC1 File Offset: 0x0003B0C1
		public AxisName MainAxis
		{
			get
			{
				return (AxisName)base.GetValue(CustomTargetPositionCamera.MainAxisProperty);
			}
			set
			{
				base.SetValue(CustomTargetPositionCamera.MainAxisProperty, value);
			}
		}

		// Token: 0x1700151A RID: 5402
		// (get) Token: 0x06004822 RID: 18466 RVA: 0x0003CEE0 File Offset: 0x0003B0E0
		// (set) Token: 0x06004823 RID: 18467 RVA: 0x0003CEEC File Offset: 0x0003B0EC
		internal bool UpdateDependentValuesOnBoundValueChanged { get; set; }

		// Token: 0x06004824 RID: 18468 RVA: 0x00143420 File Offset: 0x00141620
		private static object MyCameraWidthCoerceValueCallback(DependencyObject dependencyObject, object baseValue)
		{
			CustomTargetPositionCamera customTargetPositionCamera = (CustomTargetPositionCamera)dependencyObject;
			if (customTargetPositionCamera.UpdateDependentValuesOnBoundValueChanged && customTargetPositionCamera.CameraType == BaseCamera.CameraTypes.OrthographicCamera)
			{
				if (customTargetPositionCamera.MinCameraWidth >= customTargetPositionCamera.MaxCameraWidth)
				{
					return baseValue;
				}
				double num = (double)baseValue;
				if (num < customTargetPositionCamera.MinCameraWidth)
				{
					return customTargetPositionCamera.MinCameraWidth;
				}
				if (num > customTargetPositionCamera.MaxCameraWidth)
				{
					return customTargetPositionCamera.MaxCameraWidth;
				}
			}
			return baseValue;
		}

		// Token: 0x06004825 RID: 18469 RVA: 0x00143494 File Offset: 0x00141694
		private static object MyCameraDistanceCoerceValueCallback(DependencyObject dependencyObject, object baseValue)
		{
			CustomTargetPositionCamera customTargetPositionCamera = (CustomTargetPositionCamera)dependencyObject;
			CustomTargetPositionCamera customTargetPositionCamera2;
			if (!false)
			{
				customTargetPositionCamera2 = customTargetPositionCamera;
			}
			if (customTargetPositionCamera2.UpdateDependentValuesOnBoundValueChanged && customTargetPositionCamera2.CameraType == BaseCamera.CameraTypes.PerspectiveCamera)
			{
				if (customTargetPositionCamera2.MinDistance >= customTargetPositionCamera2.MaxDistance)
				{
					return baseValue;
				}
				double num = (double)baseValue;
				if (num < customTargetPositionCamera2.MinDistance)
				{
					return customTargetPositionCamera2.MinDistance;
				}
				if (num > customTargetPositionCamera2.MaxDistance)
				{
					return customTargetPositionCamera2.MaxDistance;
				}
			}
			return baseValue;
		}

		// Token: 0x06004826 RID: 18470 RVA: 0x00143508 File Offset: 0x00141708
		private static void MyCalculateCameraDirectionsForZAxis(double heading, double attitude, double bank, out Vector3D lookDirection, out Vector3D cameraUpDirection)
		{
			double num = heading * 3.141592653589793 / 180.0;
			double num2 = -attitude * 3.141592653589793 / 180.0;
			double num3 = Math.Sin(num);
			double num4 = Math.Cos(num);
			double num5 = Math.Sin(num2);
			double num6 = Math.Cos(num2);
			lookDirection = new Vector3D(-num4 * num6, num6 * num3, -num5);
			cameraUpDirection = new Vector3D(-num5 * num4, num3 * num5, num6);
			if (bank != 0.0)
			{
				Matrix3D value = new RotateTransform3D(new AxisAngleRotation3D(lookDirection, bank)).Value;
				cameraUpDirection *= value;
			}
		}

		// Token: 0x06004827 RID: 18471 RVA: 0x001435E0 File Offset: 0x001417E0
		private static void MyOnMinDistanceChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
		{
			CustomTargetPositionCamera customTargetPositionCamera = (CustomTargetPositionCamera)sender;
			if (customTargetPositionCamera.UpdateDependentValuesOnBoundValueChanged)
			{
				customTargetPositionCamera.CoerceValue(BaseTargetPositionCamera.DistanceProperty);
				customTargetPositionCamera.RecalculateDistanceScale();
			}
		}

		// Token: 0x06004828 RID: 18472 RVA: 0x001435E0 File Offset: 0x001417E0
		private static void MyOnMaxDistanceChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
		{
			CustomTargetPositionCamera customTargetPositionCamera = (CustomTargetPositionCamera)sender;
			if (customTargetPositionCamera.UpdateDependentValuesOnBoundValueChanged)
			{
				customTargetPositionCamera.CoerceValue(BaseTargetPositionCamera.DistanceProperty);
				customTargetPositionCamera.RecalculateDistanceScale();
			}
		}

		// Token: 0x06004829 RID: 18473 RVA: 0x0014361C File Offset: 0x0014181C
		private static void MyOnReferenceDistanceChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
		{
			CustomTargetPositionCamera customTargetPositionCamera = (CustomTargetPositionCamera)sender;
			if (customTargetPositionCamera.UpdateDependentValuesOnBoundValueChanged)
			{
				customTargetPositionCamera.RecalculateDistanceScale();
			}
		}

		// Token: 0x0600482A RID: 18474 RVA: 0x0014364C File Offset: 0x0014184C
		private static void MyOnMinWidthChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
		{
			CustomTargetPositionCamera customTargetPositionCamera = (CustomTargetPositionCamera)sender;
			double num = (double)e.NewValue;
			if (customTargetPositionCamera.UpdateDependentValuesOnBoundValueChanged)
			{
				if (customTargetPositionCamera.CameraWidth < num)
				{
					customTargetPositionCamera.CameraWidth = num;
				}
				customTargetPositionCamera.RecalculateCameraWidthScale();
			}
		}

		// Token: 0x0600482B RID: 18475 RVA: 0x00143698 File Offset: 0x00141898
		private static void MyOnMaxWidthChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
		{
			CustomTargetPositionCamera customTargetPositionCamera = (CustomTargetPositionCamera)sender;
			double num = (double)e.NewValue;
			if (customTargetPositionCamera.UpdateDependentValuesOnBoundValueChanged)
			{
				if (customTargetPositionCamera.CameraWidth > num)
				{
					customTargetPositionCamera.CameraWidth = num;
				}
				customTargetPositionCamera.RecalculateCameraWidthScale();
			}
		}

		// Token: 0x0600482C RID: 18476 RVA: 0x001436E4 File Offset: 0x001418E4
		private static void MyOnReferenceWidthChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
		{
			CustomTargetPositionCamera customTargetPositionCamera = (CustomTargetPositionCamera)sender;
			if (customTargetPositionCamera.UpdateDependentValuesOnBoundValueChanged)
			{
				customTargetPositionCamera.RecalculateCameraWidthScale();
			}
		}

		// Token: 0x0600482D RID: 18477 RVA: 0x00143714 File Offset: 0x00141914
		private static void MyOnMainAxisChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
		{
			CustomTargetPositionCamera customTargetPositionCamera = (CustomTargetPositionCamera)sender;
			AxisName mainAxis = (AxisName)e.NewValue;
			customTargetPositionCamera.MainAxis = mainAxis;
		}

		// Token: 0x04002094 RID: 8340
		private static readonly DependencyPropertyKey DistanceScalePropertyKey = DependencyProperty.RegisterReadOnly(#Phc.#3hc(107450891), typeof(double), typeof(CustomTargetPositionCamera), new FrameworkPropertyMetadata(1.0, FrameworkPropertyMetadataOptions.None, null));

		// Token: 0x04002095 RID: 8341
		public static readonly DependencyProperty DistanceScaleProperty = CustomTargetPositionCamera.DistanceScalePropertyKey.DependencyProperty;

		// Token: 0x04002096 RID: 8342
		private static readonly DependencyPropertyKey DisplayScalePropertyKey = DependencyProperty.RegisterReadOnly(#Phc.#3hc(107450902), typeof(double), typeof(CustomTargetPositionCamera), new FrameworkPropertyMetadata(1.0, FrameworkPropertyMetadataOptions.None, null));

		// Token: 0x04002097 RID: 8343
		public static readonly DependencyProperty DisplayScaleProperty = CustomTargetPositionCamera.DisplayScalePropertyKey.DependencyProperty;

		// Token: 0x04002098 RID: 8344
		public static readonly DependencyProperty ReferenceDistanceProperty = DependencyProperty.Register(#Phc.#3hc(107451365), typeof(double), typeof(CustomTargetPositionCamera), new PropertyMetadata(164.12, new PropertyChangedCallback(CustomTargetPositionCamera.MyOnReferenceDistanceChanged)));

		// Token: 0x04002099 RID: 8345
		public static readonly DependencyProperty MaxDistanceProperty = DependencyProperty.Register(#Phc.#3hc(107451340), typeof(double), typeof(CustomTargetPositionCamera), new PropertyMetadata(1000.0, new PropertyChangedCallback(CustomTargetPositionCamera.MyOnMaxDistanceChanged)));

		// Token: 0x0400209A RID: 8346
		public static readonly DependencyProperty MinDistanceProperty = DependencyProperty.Register(#Phc.#3hc(107451355), typeof(double), typeof(CustomTargetPositionCamera), new PropertyMetadata(20.0, new PropertyChangedCallback(CustomTargetPositionCamera.MyOnMinDistanceChanged)));

		// Token: 0x0400209B RID: 8347
		private static readonly DependencyPropertyKey CameraWidthScalePropertyKey = DependencyProperty.RegisterReadOnly(#Phc.#3hc(107451306), typeof(double), typeof(CustomTargetPositionCamera), new FrameworkPropertyMetadata(1.0, FrameworkPropertyMetadataOptions.None, null));

		// Token: 0x0400209C RID: 8348
		public static readonly DependencyProperty WidthScaleProperty = CustomTargetPositionCamera.CameraWidthScalePropertyKey.DependencyProperty;

		// Token: 0x0400209D RID: 8349
		public static readonly DependencyProperty ReferenceCameraWidthProperty = DependencyProperty.Register(#Phc.#3hc(107451313), typeof(double), typeof(CustomTargetPositionCamera), new PropertyMetadata(164.12, new PropertyChangedCallback(CustomTargetPositionCamera.MyOnReferenceWidthChanged)));

		// Token: 0x0400209E RID: 8350
		public static readonly DependencyProperty MaxCameraWidthProperty = DependencyProperty.Register(#Phc.#3hc(107451284), typeof(double), typeof(CustomTargetPositionCamera), new PropertyMetadata(1000.0, new PropertyChangedCallback(CustomTargetPositionCamera.MyOnMaxWidthChanged)));

		// Token: 0x0400209F RID: 8351
		public static readonly DependencyProperty MinCameraWidthProperty = DependencyProperty.Register(#Phc.#3hc(107451263), typeof(double), typeof(CustomTargetPositionCamera), new PropertyMetadata(20.0, new PropertyChangedCallback(CustomTargetPositionCamera.MyOnMinWidthChanged)));

		// Token: 0x040020A0 RID: 8352
		public static readonly DependencyProperty MainAxisProperty = DependencyProperty.Register(#Phc.#3hc(107451210), typeof(AxisName), typeof(CustomTargetPositionCamera), new PropertyMetadata(AxisName.Y, new PropertyChangedCallback(CustomTargetPositionCamera.MyOnMainAxisChanged)));
	}
}
