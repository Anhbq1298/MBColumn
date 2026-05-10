using System;
using #7hc;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor
{
	// Token: 0x02000934 RID: 2356
	public sealed class LinearEquation : NotifyPropertyChangedObjectBase
	{
		// Token: 0x1700165C RID: 5724
		// (get) Token: 0x06004CDE RID: 19678 RVA: 0x00040752 File Offset: 0x0003E952
		// (set) Token: 0x06004CDF RID: 19679 RVA: 0x0004075E File Offset: 0x0003E95E
		public double HeightOfFunction
		{
			get
			{
				return this.heightOfFunction;
			}
			private set
			{
				if (this.heightOfFunction != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107469840));
					this.heightOfFunction = value;
					base.RaisePropertyChanged(#Phc.#3hc(107469840));
				}
			}
		}

		// Token: 0x1700165D RID: 5725
		// (get) Token: 0x06004CE0 RID: 19680 RVA: 0x0004079C File Offset: 0x0003E99C
		// (set) Token: 0x06004CE1 RID: 19681 RVA: 0x000407A8 File Offset: 0x0003E9A8
		public double SlopeOfFunction
		{
			get
			{
				return this.slopeOfFunction;
			}
			private set
			{
				if (this.slopeOfFunction != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107470327));
					this.slopeOfFunction = value;
					base.RaisePropertyChanged(#Phc.#3hc(107470327));
				}
			}
		}

		// Token: 0x1700165E RID: 5726
		// (get) Token: 0x06004CE2 RID: 19682 RVA: 0x000407E6 File Offset: 0x0003E9E6
		public static double FunctionMinValue
		{
			get
			{
				return 24.0;
			}
		}

		// Token: 0x1700165F RID: 5727
		// (get) Token: 0x06004CE3 RID: 19683 RVA: 0x000407F1 File Offset: 0x0003E9F1
		public static double FunctionAverageValue
		{
			get
			{
				return 1200000.0;
			}
		}

		// Token: 0x17001660 RID: 5728
		// (get) Token: 0x06004CE4 RID: 19684 RVA: 0x000407FC File Offset: 0x0003E9FC
		public static double FunctionMaxValue
		{
			get
			{
				return 2400000.0;
			}
		}

		// Token: 0x17001661 RID: 5729
		// (get) Token: 0x06004CE5 RID: 19685 RVA: 0x00040807 File Offset: 0x0003EA07
		// (set) Token: 0x06004CE6 RID: 19686 RVA: 0x00040813 File Offset: 0x0003EA13
		public double MinArgument
		{
			get
			{
				return this.minArgument;
			}
			private set
			{
				if (this.MinArgument != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107470274));
					this.minArgument = value;
					base.RaisePropertyChanged(#Phc.#3hc(107470274));
				}
			}
		}

		// Token: 0x17001662 RID: 5730
		// (get) Token: 0x06004CE7 RID: 19687 RVA: 0x00040851 File Offset: 0x0003EA51
		// (set) Token: 0x06004CE8 RID: 19688 RVA: 0x0004085D File Offset: 0x0003EA5D
		public double AverageArgument { get; private set; }

		// Token: 0x17001663 RID: 5731
		// (get) Token: 0x06004CE9 RID: 19689 RVA: 0x0004086E File Offset: 0x0003EA6E
		// (set) Token: 0x06004CEA RID: 19690 RVA: 0x0004087A File Offset: 0x0003EA7A
		public double MaxArgument { get; private set; }

		// Token: 0x06004CEB RID: 19691 RVA: 0x0014D8C0 File Offset: 0x0014BAC0
		public LinearEquation()
		{
			this.HeightOfFunction = 0.0;
			this.SlopeOfFunction = 0.0;
			this.MinArgument = 0.1;
			this.AverageArgument = 5.0;
			this.MaxArgument = 10.0;
			this.UpdateEquation();
		}

		// Token: 0x06004CEC RID: 19692 RVA: 0x0014D924 File Offset: 0x0014BB24
		public double CalculateFunctionValue(double argument)
		{
			double num = argument / LinearEquation.FunctionMaxValue;
			num = this.MaxArgument - num;
			num = Math.Max(num, this.MinArgument);
			return Math.Min(num, this.MaxArgument);
		}

		// Token: 0x06004CED RID: 19693 RVA: 0x0004088B File Offset: 0x0003EA8B
		public double CalculateFunctionArgument(double value)
		{
			value = this.MaxArgument - value;
			return Math.Min(Math.Max(value * LinearEquation.FunctionMaxValue, LinearEquation.FunctionMinValue), LinearEquation.FunctionMaxValue);
		}

		// Token: 0x06004CEE RID: 19694 RVA: 0x0014D96C File Offset: 0x0014BB6C
		public void UpdateEquation()
		{
			this.SlopeOfFunction = (LinearEquation.FunctionMaxValue - LinearEquation.FunctionMinValue) / (this.MaxArgument - this.MinArgument);
			this.HeightOfFunction = LinearEquation.FunctionAverageValue - this.SlopeOfFunction * this.AverageArgument;
		}

		// Token: 0x040021E9 RID: 8681
		private double heightOfFunction;

		// Token: 0x040021EA RID: 8682
		private double slopeOfFunction;

		// Token: 0x040021EB RID: 8683
		private double minArgument;
	}
}
