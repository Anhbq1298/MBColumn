using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using #7hc;
using devDept.Geometry;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.Localizer;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core
{
	// Token: 0x02000B14 RID: 2836
	internal sealed class DynamicInputWindowViewModel : NotifyPropertyChangedObjectWithValidation
	{
		// Token: 0x1400016D RID: 365
		// (add) Token: 0x06005CE2 RID: 23778 RVA: 0x001749F0 File Offset: 0x00172BF0
		// (remove) Token: 0x06005CE3 RID: 23779 RVA: 0x00174A28 File Offset: 0x00172C28
		public event EventHandler<DynamicInputValueValidationEventArgs> ValidatingCoordinate;

		// Token: 0x1400016E RID: 366
		// (add) Token: 0x06005CE4 RID: 23780 RVA: 0x00174A60 File Offset: 0x00172C60
		// (remove) Token: 0x06005CE5 RID: 23781 RVA: 0x00174A98 File Offset: 0x00172C98
		public event EventHandler<DynamicInputCoordinateEventArgs> CoordinateChanged;

		// Token: 0x17001A7D RID: 6781
		// (get) Token: 0x06005CE6 RID: 23782 RVA: 0x0004D7C6 File Offset: 0x0004B9C6
		// (set) Token: 0x06005CE7 RID: 23783 RVA: 0x0004D7CE File Offset: 0x0004B9CE
		public DynamicInputProviderConfiguration Config { get; set; }

		// Token: 0x17001A7E RID: 6782
		// (get) Token: 0x06005CE8 RID: 23784 RVA: 0x0004D7D7 File Offset: 0x0004B9D7
		// (set) Token: 0x06005CE9 RID: 23785 RVA: 0x0004D7DF File Offset: 0x0004B9DF
		public double ParsedCoordinateX
		{
			get
			{
				return this.parsedCoordinateX;
			}
			private set
			{
				if (this.parsedCoordinateX != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107420779));
					this.parsedCoordinateX = value;
					base.RaisePropertyChanged(#Phc.#3hc(107420779));
				}
			}
		}

		// Token: 0x17001A7F RID: 6783
		// (get) Token: 0x06005CEA RID: 23786 RVA: 0x0004D811 File Offset: 0x0004BA11
		// (set) Token: 0x06005CEB RID: 23787 RVA: 0x0004D819 File Offset: 0x0004BA19
		public double ParsedCoordinateY
		{
			get
			{
				return this.parsedCoordinateY;
			}
			private set
			{
				if (this.parsedCoordinateY != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107420786));
					this.parsedCoordinateY = value;
					base.RaisePropertyChanged(#Phc.#3hc(107420786));
				}
			}
		}

		// Token: 0x17001A80 RID: 6784
		// (get) Token: 0x06005CEC RID: 23788 RVA: 0x0004D84B File Offset: 0x0004BA4B
		// (set) Token: 0x06005CED RID: 23789 RVA: 0x00174AD0 File Offset: 0x00172CD0
		public string CoordinateX
		{
			get
			{
				return this.coordinateX;
			}
			set
			{
				if (this.coordinateX != value)
				{
					this.coordinateX = value;
					double? num;
					if (this.ValidateProperty(value, out num, #Phc.#3hc(107429863), false) && num != null)
					{
						this.ParsedCoordinateX = num.Value;
					}
					this.RaiseCoordinateChangedIfNeeded(new DynamicInputCoordinateType?(DynamicInputCoordinateType.CoordinateX));
					base.RaisePropertyChanged(#Phc.#3hc(107429863));
				}
			}
		}

		// Token: 0x17001A81 RID: 6785
		// (get) Token: 0x06005CEE RID: 23790 RVA: 0x0004D853 File Offset: 0x0004BA53
		// (set) Token: 0x06005CEF RID: 23791 RVA: 0x00174B3C File Offset: 0x00172D3C
		public string CoordinateY
		{
			get
			{
				return this.coordinateY;
			}
			set
			{
				if (this.coordinateY != value)
				{
					this.coordinateY = value;
					double? num;
					if (this.ValidateProperty(value, out num, #Phc.#3hc(107429385), false) && num != null)
					{
						this.ParsedCoordinateY = num.Value;
					}
					this.RaiseCoordinateChangedIfNeeded(new DynamicInputCoordinateType?(DynamicInputCoordinateType.CoordinateY));
					base.RaisePropertyChanged(#Phc.#3hc(107429385));
				}
			}
		}

		// Token: 0x17001A82 RID: 6786
		// (get) Token: 0x06005CF0 RID: 23792 RVA: 0x0004D85B File Offset: 0x0004BA5B
		// (set) Token: 0x06005CF1 RID: 23793 RVA: 0x0004D863 File Offset: 0x0004BA63
		public bool PreventCoordinateChangedFiring { get; set; }

		// Token: 0x06005CF2 RID: 23794 RVA: 0x00174BA8 File Offset: 0x00172DA8
		public DynamicInputCoordinateEventArgs ToArgs(Point3D point)
		{
			if (point == null)
			{
				return null;
			}
			switch (this.Config.Mode)
			{
			case DynamicInputMode.Regular:
				return new DynamicInputCoordinateEventArgs(point);
			case DynamicInputMode.Relative:
			case DynamicInputMode.RelativeRectangle:
			case DynamicInputMode.RelativeRadius:
				if (this.Config.LastInputPoint == null)
				{
					return null;
				}
				return new DynamicInputCoordinateEventArgs(this.Config.LastInputPoint + point, new Vector3D(Point3D.Origin, point));
			case DynamicInputMode.Angle:
			case DynamicInputMode.RelativeAngle:
				return new DynamicInputCoordinateEventArgs(point.X);
			case DynamicInputMode.Offset:
				return new DynamicInputCoordinateEventArgs(point.X, DynamicInputMode.Offset);
			default:
				throw new ArgumentOutOfRangeException();
			}
		}

		// Token: 0x06005CF3 RID: 23795 RVA: 0x00174C4C File Offset: 0x00172E4C
		public Point3D GetFinalPoint(DynamicInputCoordinateType? inputToValidate)
		{
			this.ValidateAll(inputToValidate, false);
			double? num = this.Config.XValue.EnabledAndVisible ? this.ParseCoordinate(this.CoordinateX) : new double?(0.0);
			double? num2 = this.Config.YValue.EnabledAndVisible ? this.ParseCoordinate(this.CoordinateY) : new double?(0.0);
			if (num != null && num2 != null)
			{
				return new Point3D(num.Value, num2.Value);
			}
			return null;
		}

		// Token: 0x06005CF4 RID: 23796 RVA: 0x00174CE8 File Offset: 0x00172EE8
		public void ValidateAll(DynamicInputCoordinateType? coordinate, bool ignoreCustomRules = false)
		{
			if (coordinate.GetValueOrDefault(DynamicInputCoordinateType.CoordinateX) == DynamicInputCoordinateType.CoordinateX)
			{
				double? num;
				this.ValidateProperty(this.CoordinateX, out num, #Phc.#3hc(107429863), ignoreCustomRules);
			}
			if (coordinate.GetValueOrDefault(DynamicInputCoordinateType.CoordinateY) == DynamicInputCoordinateType.CoordinateY)
			{
				double? num;
				this.ValidateProperty(this.CoordinateY, out num, #Phc.#3hc(107429385), ignoreCustomRules);
			}
		}

		// Token: 0x06005CF5 RID: 23797 RVA: 0x00174D40 File Offset: 0x00172F40
		protected bool ValidateProperty(string value, out double? parsed, [CallerMemberName] string propertyName = null, bool ignoreCustomRules = false)
		{
			parsed = null;
			if ((propertyName == #Phc.#3hc(107429863) && !this.Config.XValue.EnabledAndVisible) || (propertyName == #Phc.#3hc(107429385) && !this.Config.YValue.EnabledAndVisible))
			{
				base.RemoveError(propertyName);
				return true;
			}
			if (string.IsNullOrWhiteSpace(value))
			{
				this.AddError(propertyName, Strings.StringValueShouldNotBeEmpty);
				return false;
			}
			parsed = this.ParseCoordinate(value);
			if (parsed == null)
			{
				this.AddError(propertyName, Strings.StringValueHasInvalidFormat);
				return false;
			}
			DynamicInputCoordinateType coordinateType = (propertyName == #Phc.#3hc(107429863)) ? DynamicInputCoordinateType.CoordinateX : DynamicInputCoordinateType.CoordinateY;
			double? num = this.ParseCoordinate(this.CoordinateX);
			double? num2 = this.ParseCoordinate(this.CoordinateY);
			DynamicInputValueValidationEventArgs dynamicInputValueValidationEventArgs = new DynamicInputValueValidationEventArgs(coordinateType, this.CoordinateX, this.CoordinateY, num, num2);
			if (!ignoreCustomRules)
			{
				this.OnValidatingCoordinate(dynamicInputValueValidationEventArgs);
			}
			if (!string.IsNullOrWhiteSpace(dynamicInputValueValidationEventArgs.ErrorMessage))
			{
				this.AddError(propertyName, dynamicInputValueValidationEventArgs.ErrorMessage);
				return false;
			}
			base.RemoveError(propertyName);
			return true;
		}

		// Token: 0x06005CF6 RID: 23798 RVA: 0x0004D86C File Offset: 0x0004BA6C
		protected void OnValidatingCoordinate(DynamicInputValueValidationEventArgs e)
		{
			EventHandler<DynamicInputValueValidationEventArgs> validatingCoordinate = this.ValidatingCoordinate;
			if (validatingCoordinate == null)
			{
				return;
			}
			validatingCoordinate(this, e);
		}

		// Token: 0x06005CF7 RID: 23799 RVA: 0x0004D880 File Offset: 0x0004BA80
		protected void OnCoordinateChanged(DynamicInputCoordinateEventArgs e)
		{
			EventHandler<DynamicInputCoordinateEventArgs> coordinateChanged = this.CoordinateChanged;
			if (coordinateChanged == null)
			{
				return;
			}
			coordinateChanged(this, e);
		}

		// Token: 0x06005CF8 RID: 23800 RVA: 0x00174E54 File Offset: 0x00173054
		internal void RaiseCoordinateChangedIfNeeded(DynamicInputCoordinateType? coordinateToValidate)
		{
			if (!this.HasErrors)
			{
				Point3D finalPoint = this.GetFinalPoint(coordinateToValidate);
				if (finalPoint != null && !this.PreventCoordinateChangedFiring)
				{
					this.OnCoordinateChanged(this.ToArgs(finalPoint));
				}
			}
		}

		// Token: 0x06005CF9 RID: 23801 RVA: 0x00174E90 File Offset: 0x00173090
		private double? ParseCoordinate(string value)
		{
			value = ((value != null) ? value.Trim() : null);
			if (string.Equals(value, #Phc.#3hc(107421455)) || string.Equals(value, #Phc.#3hc(107408434)) || string.Equals(value, #Phc.#3hc(107356879)))
			{
				return new double?(0.0);
			}
			double value2;
			if (double.TryParse(value, NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite | NumberStyles.AllowLeadingSign | NumberStyles.AllowParentheses | NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands | NumberStyles.AllowExponent | NumberStyles.AllowCurrencySymbol, CultureInfo.CurrentCulture, out value2))
			{
				return new double?(value2);
			}
			if (double.TryParse(value, NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite | NumberStyles.AllowLeadingSign | NumberStyles.AllowParentheses | NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands | NumberStyles.AllowExponent | NumberStyles.AllowCurrencySymbol, CultureInfo.CurrentUICulture, out value2))
			{
				return new double?(value2);
			}
			return null;
		}

		// Token: 0x040026B4 RID: 9908
		private string coordinateX;

		// Token: 0x040026B5 RID: 9909
		private string coordinateY;

		// Token: 0x040026B6 RID: 9910
		private double parsedCoordinateX;

		// Token: 0x040026BA RID: 9914
		private double parsedCoordinateY;
	}
}
