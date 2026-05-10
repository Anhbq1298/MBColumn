using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Media3D;
using #54d;
using #7hc;
using Ab3d.Cameras;
using StructurePoint.CoreAssets.GUI.DesktopControls.Utils;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor.ViewCubeControl.CameraPositionSetters
{
	// Token: 0x02000960 RID: 2400
	internal abstract class CameraPositionSetterBase
	{
		// Token: 0x06004EE9 RID: 20201 RVA: 0x0004202E File Offset: 0x0004022E
		protected CameraPositionSetterBase(CustomTargetPositionCamera mainTargetPositionCamera, Viewport3D mainViewport, RadSlider mainScaleSlider, CustomTargetPositionCamera viewCubeTargetPositionCamera, LinearEquation equationForSlider)
		{
			this.<MainTargetPositionCamera>k__BackingField = mainTargetPositionCamera;
			this.<MainViewport>k__BackingField = mainViewport;
			this.<MainScaleSlider>k__BackingField = mainScaleSlider;
			this.<ViewCubeTargetPositionCamera>k__BackingField = viewCubeTargetPositionCamera;
			this.<EquationForSlider>k__BackingField = equationForSlider;
			this.UpdateSliderUponMainCameraUpdate = true;
			this.BaseDistanceCalculationCamera = mainTargetPositionCamera;
		}

		// Token: 0x170016D7 RID: 5847
		// (get) Token: 0x06004EEA RID: 20202 RVA: 0x00042069 File Offset: 0x00040269
		protected CustomTargetPositionCamera MainTargetPositionCamera { get; }

		// Token: 0x170016D8 RID: 5848
		// (get) Token: 0x06004EEB RID: 20203 RVA: 0x00042075 File Offset: 0x00040275
		protected Viewport3D MainViewport { get; }

		// Token: 0x170016D9 RID: 5849
		// (get) Token: 0x06004EEC RID: 20204 RVA: 0x00042081 File Offset: 0x00040281
		protected RadSlider MainScaleSlider { get; }

		// Token: 0x170016DA RID: 5850
		// (get) Token: 0x06004EED RID: 20205 RVA: 0x0004208D File Offset: 0x0004028D
		protected CustomTargetPositionCamera ViewCubeTargetPositionCamera { get; }

		// Token: 0x170016DB RID: 5851
		// (get) Token: 0x06004EEE RID: 20206 RVA: 0x00042099 File Offset: 0x00040299
		protected LinearEquation EquationForSlider { get; }

		// Token: 0x170016DC RID: 5852
		// (get) Token: 0x06004EEF RID: 20207 RVA: 0x000420A5 File Offset: 0x000402A5
		// (set) Token: 0x06004EF0 RID: 20208 RVA: 0x000420B1 File Offset: 0x000402B1
		public bool UpdateSliderUponMainCameraUpdate { get; set; }

		// Token: 0x170016DD RID: 5853
		// (get) Token: 0x06004EF1 RID: 20209 RVA: 0x000420C2 File Offset: 0x000402C2
		// (set) Token: 0x06004EF2 RID: 20210 RVA: 0x000420CE File Offset: 0x000402CE
		public CustomTargetPositionCamera BaseDistanceCalculationCamera
		{
			get
			{
				return this.baseDistanceCalculationCamera;
			}
			private set
			{
				if (value == null)
				{
					throw new ArgumentNullException(#Phc.#3hc(107386484));
				}
				this.baseDistanceCalculationCamera = value;
			}
		}

		// Token: 0x06004EF3 RID: 20211
		internal abstract void SetMainCameraPosition(Rect3D mainRect, Duration animationDuration);

		// Token: 0x06004EF4 RID: 20212
		internal abstract void SetViewCubeCameraPosition(Duration animationDuration);

		// Token: 0x06004EF5 RID: 20213 RVA: 0x001571D4 File Offset: 0x001553D4
		internal void SetMainCameraPosition(double attitudeValue, double bankValue, double headingValue, Rect3D mainRect, Duration animationDuration)
		{
			double attitude = this.MainTargetPositionCamera.Attitude;
			double bank = this.MainTargetPositionCamera.Bank;
			double heading = this.MainTargetPositionCamera.Heading;
			double distance = this.MainTargetPositionCamera.Distance;
			double cameraWidth = this.MainTargetPositionCamera.CameraWidth;
			Point3D targetPosition = this.MainTargetPositionCamera.TargetPosition;
			Vector3D offset = this.MainTargetPositionCamera.Offset;
			Point3D targetValue = mainRect.CalculateCenter();
			this.PrepareCameraForCalculations(mainRect);
			double num = this.CalculateCameraDistanceToCoverAllObjects(CameraPositionSetterBase.MyUpscaleRect(mainRect));
			if (double.IsNaN(num))
			{
				return;
			}
			if (!this.UpdateSliderUponMainCameraUpdate)
			{
				BaseCamera.CameraTypes cameraType = this.MainTargetPositionCamera.CameraType;
				if (cameraType != BaseCamera.CameraTypes.PerspectiveCamera)
				{
					if (cameraType == BaseCamera.CameraTypes.OrthographicCamera)
					{
						num = Math.Min(this.MainTargetPositionCamera.MaxWidth, num);
						num = Math.Max(this.MainTargetPositionCamera.MinWidth, num);
					}
				}
				else
				{
					num = Math.Min(this.MainTargetPositionCamera.MaxDistance, num);
					num = Math.Max(this.MainTargetPositionCamera.MinDistance, num);
				}
			}
			bool #e = #44d.#e;
			List<Tuple<DependencyProperty, AnimationTimeline>> list = new List<Tuple<DependencyProperty, AnimationTimeline>>();
			list.Add(CameraPositionSetterBase.MyCreateDoubleAnimation(this.MainTargetPositionCamera, SphericalCamera.AttitudeProperty, attitude, attitudeValue, animationDuration, null));
			list.Add(CameraPositionSetterBase.MyCreateDoubleAnimation(this.MainTargetPositionCamera, SphericalCamera.BankProperty, bank, bankValue, animationDuration, null));
			list.Add(CameraPositionSetterBase.MyCreateDoubleAnimation(this.MainTargetPositionCamera, SphericalCamera.HeadingProperty, heading, headingValue, animationDuration, null));
			list.Add(CameraPositionSetterBase.MyCreatePointAnimation(this.MainTargetPositionCamera, BaseTargetPositionCamera.TargetPositionProperty, targetPosition, targetValue, animationDuration));
			list.Add(CameraPositionSetterBase.MyCreateDoubleAnimation(this.MainTargetPositionCamera, BaseTargetPositionCamera.DistanceProperty, distance, num, animationDuration, new Action(this.MainTargetPositionCamera.RecalculateScale)));
			if (this.MainTargetPositionCamera.CameraType == BaseCamera.CameraTypes.OrthographicCamera)
			{
				list.Add(CameraPositionSetterBase.MyCreateDoubleAnimation(this.MainTargetPositionCamera, BaseCamera.CameraWidthProperty, cameraWidth, num, animationDuration, new Action(this.MainTargetPositionCamera.RecalculateScale)));
			}
			list.Add(CameraPositionSetterBase.MyCreateVectorAnimation(this.MainTargetPositionCamera, BaseCamera.OffsetProperty, offset, new Vector3D(0.0, 0.0, 0.0), animationDuration));
			CameraPositionSetterBase.MyExecuteAnimations(this.MainTargetPositionCamera, list);
			if (this.UpdateSliderUponMainCameraUpdate)
			{
				this.UpdateSlider(num);
			}
		}

		// Token: 0x06004EF6 RID: 20214 RVA: 0x000420F6 File Offset: 0x000402F6
		internal void UpdateSlider(double reference)
		{
			if (this.MainTargetPositionCamera.CameraType == BaseCamera.CameraTypes.PerspectiveCamera)
			{
				this.UpdateDistanceScaleSlider();
				return;
			}
			this.UpdateWidthScaleSlider(reference);
		}

		// Token: 0x06004EF7 RID: 20215 RVA: 0x00157434 File Offset: 0x00155634
		internal void SetMainCameraPositionUpdateOnlySlider(Rect3D mainRect)
		{
			double num = this.CalculateCameraDistanceToCoverAllObjects(CameraPositionSetterBase.MyUpscaleRect(mainRect));
			if (double.IsNaN(num))
			{
				return;
			}
			this.UpdateSlider(num);
		}

		// Token: 0x06004EF8 RID: 20216 RVA: 0x0015746C File Offset: 0x0015566C
		internal virtual void SetViewCubeCameraPosition(double attitudeValue, double bankValue, double headingValue, Duration animationDuration)
		{
			double attitude = this.ViewCubeTargetPositionCamera.Attitude;
			double bank = this.ViewCubeTargetPositionCamera.Bank;
			double heading = this.ViewCubeTargetPositionCamera.Heading;
			this.ViewCubeTargetPositionCamera.Distance = (double)((this.ViewCubeTargetPositionCamera.Distance <= 55.0) ? 50 : 75);
			this.ViewCubeTargetPositionCamera.TargetPosition = default(Point3D);
			List<Tuple<DependencyProperty, AnimationTimeline>> list = new List<Tuple<DependencyProperty, AnimationTimeline>>();
			list.Add(CameraPositionSetterBase.MyCreateDoubleAnimation(this.ViewCubeTargetPositionCamera, SphericalCamera.AttitudeProperty, attitude, attitudeValue, animationDuration, null));
			list.Add(CameraPositionSetterBase.MyCreateDoubleAnimation(this.ViewCubeTargetPositionCamera, SphericalCamera.BankProperty, bank, bankValue, animationDuration, null));
			list.Add(CameraPositionSetterBase.MyCreateDoubleAnimation(this.ViewCubeTargetPositionCamera, SphericalCamera.HeadingProperty, heading, headingValue, animationDuration, null));
			CameraPositionSetterBase.MyExecuteAnimations(this.ViewCubeTargetPositionCamera, list);
		}

		// Token: 0x06004EF9 RID: 20217 RVA: 0x0015755C File Offset: 0x0015575C
		public double CalculateCameraDistanceToCoverAllObjects(Rect3D mainRect)
		{
			Matrix3D matrix;
			Matrix3D matrix3D;
			this.BaseDistanceCalculationCamera.GetCameraMatrixes(out matrix, out matrix3D);
			matrix.OffsetX = 0.0;
			matrix.OffsetY = 0.0;
			matrix.OffsetZ = 0.0;
			Rect3D rect3D = new MatrixTransform3D(matrix).TransformBounds(mainRect);
			double num = rect3D.SizeX / rect3D.SizeY;
			double num2 = this.MainViewport.ActualWidth / this.MainViewport.ActualHeight;
			double num3;
			if (num >= num2)
			{
				num3 = rect3D.SizeX;
			}
			else
			{
				num3 = rect3D.SizeX * (num2 / num);
			}
			return num3 / (2.0 * Math.Tan(this.BaseDistanceCalculationCamera.FieldOfView / 360.0 * 3.141592653589793)) + rect3D.SizeZ / 2.0;
		}

		// Token: 0x06004EFA RID: 20218 RVA: 0x00157660 File Offset: 0x00155860
		protected void PrepareCameraForCalculations(Rect3D mainEditorWorkspaceSize)
		{
			this.BaseDistanceCalculationCamera.BeginInit();
			this.BaseDistanceCalculationCamera.Attitude = 0.0;
			this.BaseDistanceCalculationCamera.Bank = 0.0;
			this.BaseDistanceCalculationCamera.Heading = 0.0;
			this.BaseDistanceCalculationCamera.Offset = new Vector3D(0.0, 0.0, 0.0);
			this.BaseDistanceCalculationCamera.TargetPosition = mainEditorWorkspaceSize.CalculateCenter();
			this.BaseDistanceCalculationCamera.EndInit();
			this.BaseDistanceCalculationCamera.Refresh();
		}

		// Token: 0x06004EFB RID: 20219 RVA: 0x00157724 File Offset: 0x00155924
		protected void UpdateDistanceScaleSlider()
		{
			bool updateDependentValuesOnBoundValueChanged = this.MainTargetPositionCamera.UpdateDependentValuesOnBoundValueChanged;
			try
			{
				this.MainTargetPositionCamera.UpdateDependentValuesOnBoundValueChanged = false;
				double num = 240.0;
				this.MainTargetPositionCamera.ReferenceDistance = num;
				this.MainTargetPositionCamera.MaxDistance = num * 10000.0;
				this.MainTargetPositionCamera.MinDistance = num / 10.0;
				this.MainScaleSlider.Ticks = new DoubleCollection(new double[]
				{
					this.EquationForSlider.AverageArgument
				});
			}
			finally
			{
				this.MainTargetPositionCamera.UpdateDependentValuesOnBoundValueChanged = updateDependentValuesOnBoundValueChanged;
			}
		}

		// Token: 0x06004EFC RID: 20220 RVA: 0x001577EC File Offset: 0x001559EC
		protected void UpdateWidthScaleSlider(double newReference)
		{
			bool updateDependentValuesOnBoundValueChanged = this.MainTargetPositionCamera.UpdateDependentValuesOnBoundValueChanged;
			try
			{
				this.MainTargetPositionCamera.UpdateDependentValuesOnBoundValueChanged = false;
				this.MainTargetPositionCamera.ReferenceCameraWidth = newReference;
				this.MainTargetPositionCamera.MaxCameraWidth = this.MainTargetPositionCamera.ReferenceCameraWidth * ModelEditorConfiguration.CameraReferenceWidthMultiplier;
				this.MainTargetPositionCamera.MinCameraWidth = this.MainTargetPositionCamera.ReferenceCameraWidth / ModelEditorConfiguration.CameraReferenceWidthMultiplier;
				this.MainScaleSlider.Ticks = new DoubleCollection(new double[]
				{
					0.5
				});
			}
			finally
			{
				this.MainTargetPositionCamera.UpdateDependentValuesOnBoundValueChanged = updateDependentValuesOnBoundValueChanged;
			}
		}

		// Token: 0x06004EFD RID: 20221 RVA: 0x001578B4 File Offset: 0x00155AB4
		private static void MyExecuteAnimations(CustomTargetPositionCamera targetCamera, IEnumerable<Tuple<DependencyProperty, AnimationTimeline>> animations)
		{
			foreach (Tuple<DependencyProperty, AnimationTimeline> tuple in (from item in animations
			where item != null && item.Item1 != null && item.Item2 != null
			select item).ToList<Tuple<DependencyProperty, AnimationTimeline>>())
			{
				targetCamera.BeginAnimation(tuple.Item1, tuple.Item2, HandoffBehavior.SnapshotAndReplace);
			}
		}

		// Token: 0x06004EFE RID: 20222 RVA: 0x00157944 File Offset: 0x00155B44
		private static Tuple<DependencyProperty, AnimationTimeline> MyCreateDoubleAnimation(CustomTargetPositionCamera targetCamera, DependencyProperty property, double startValue, double targetValue, Duration duration, Action completed = null)
		{
			CameraPositionSetterBase.<>c__DisplayClass35_0 CS$<>8__locals1 = new CameraPositionSetterBase.<>c__DisplayClass35_0();
			CameraPositionSetterBase.<>c__DisplayClass35_0 CS$<>8__locals2;
			if (!false)
			{
				CS$<>8__locals2 = CS$<>8__locals1;
			}
			CS$<>8__locals2.targetCamera = targetCamera;
			CS$<>8__locals2.property = property;
			CS$<>8__locals2.targetValue = targetValue;
			CS$<>8__locals2.completed = completed;
			CS$<>8__locals2.doubleAnimation = new DoubleAnimation(startValue, CS$<>8__locals2.targetValue, duration);
			CS$<>8__locals2.doubleAnimation.FillBehavior = FillBehavior.Stop;
			CS$<>8__locals2.doubleAnimation.Completed += CS$<>8__locals2.<MyCreateDoubleAnimation>g__DoubleAnimationAttitudeHandler|0;
			return new Tuple<DependencyProperty, AnimationTimeline>(CS$<>8__locals2.property, CS$<>8__locals2.doubleAnimation);
		}

		// Token: 0x06004EFF RID: 20223 RVA: 0x001579CC File Offset: 0x00155BCC
		private static Tuple<DependencyProperty, AnimationTimeline> MyCreateVectorAnimation(CustomTargetPositionCamera targetCamera, DependencyProperty property, Vector3D startValue, Vector3D targetValue, Duration duration)
		{
			CameraPositionSetterBase.<>c__DisplayClass36_0 CS$<>8__locals1 = new CameraPositionSetterBase.<>c__DisplayClass36_0();
			CS$<>8__locals1.targetCamera = targetCamera;
			CS$<>8__locals1.property = property;
			CS$<>8__locals1.targetValue = targetValue;
			CS$<>8__locals1.vectorAnimation = new Vector3DAnimation(startValue, CS$<>8__locals1.targetValue, duration);
			CS$<>8__locals1.vectorAnimation.FillBehavior = FillBehavior.Stop;
			CS$<>8__locals1.vectorAnimation.Completed += CS$<>8__locals1.<MyCreateVectorAnimation>g__VectorAnimationAttitudeHandler|0;
			return new Tuple<DependencyProperty, AnimationTimeline>(CS$<>8__locals1.property, CS$<>8__locals1.vectorAnimation);
		}

		// Token: 0x06004F00 RID: 20224 RVA: 0x00157A48 File Offset: 0x00155C48
		private static Tuple<DependencyProperty, AnimationTimeline> MyCreatePointAnimation(CustomTargetPositionCamera targetCamera, DependencyProperty property, Point3D startValue, Point3D targetValue, Duration duration)
		{
			CameraPositionSetterBase.<>c__DisplayClass37_0 CS$<>8__locals1 = new CameraPositionSetterBase.<>c__DisplayClass37_0();
			CS$<>8__locals1.targetCamera = targetCamera;
			CS$<>8__locals1.property = property;
			CS$<>8__locals1.targetValue = targetValue;
			CS$<>8__locals1.pointAnimation = new Point3DAnimation(startValue, CS$<>8__locals1.targetValue, duration);
			CS$<>8__locals1.pointAnimation.FillBehavior = FillBehavior.Stop;
			CS$<>8__locals1.pointAnimation.Completed += CS$<>8__locals1.<MyCreatePointAnimation>g__PointAnimationAttitudeHandler|0;
			return new Tuple<DependencyProperty, AnimationTimeline>(CS$<>8__locals1.property, CS$<>8__locals1.pointAnimation);
		}

		// Token: 0x06004F01 RID: 20225 RVA: 0x00157AC4 File Offset: 0x00155CC4
		private static Rect3D MyUpscaleRect(Rect3D rect)
		{
			Point3D location = rect.Location;
			double x = location.X - rect.SizeX * 0.025;
			location = rect.Location;
			double y = location.Y - rect.SizeY * 0.025;
			location = rect.Location;
			double z = location.Z - rect.SizeZ * 0.025;
			return new Rect3D(x, y, z, rect.SizeX + rect.SizeX * 0.025 * 2.0, rect.SizeY + rect.SizeY * 0.025 * 2.0, rect.SizeZ + rect.SizeZ * 0.025 * 2.0);
		}

		// Token: 0x040022A4 RID: 8868
		private CustomTargetPositionCamera baseDistanceCalculationCamera;
	}
}
