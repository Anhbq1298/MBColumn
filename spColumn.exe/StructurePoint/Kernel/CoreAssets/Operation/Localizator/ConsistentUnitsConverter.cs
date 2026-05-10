using System;
using #7hc;

namespace StructurePoint.Kernel.CoreAssets.Operation.Localizator
{
	// Token: 0x02000F09 RID: 3849
	public sealed class ConsistentUnitsConverter
	{
		// Token: 0x06008928 RID: 35112 RVA: 0x001D4114 File Offset: 0x001D2314
		private void SetupUnits(ForceUnit forceUnitIn, LengthUnit lengthUnitIn, ForceUnit forceUnitOut, LengthUnit lengthUnitOut)
		{
			this.ForceUnitIn = forceUnitIn;
			this.LengthUnitIn = lengthUnitIn;
			this.ForceUnitOut = forceUnitOut;
			this.LengthUnitOut = lengthUnitOut;
			this.ForceConversionFactor = UnitConverter.GetForceConversionFactor(forceUnitIn, forceUnitOut);
			this.LengthConversionFactor = UnitConverter.GetLengthConversionFactor(lengthUnitIn, lengthUnitOut);
			this.AreaConversionFactor = this.LengthConversionFactor * this.LengthConversionFactor;
			this.VolumeConversionFactor = this.AreaConversionFactor * this.LengthConversionFactor;
			this.MomentConversionFactor = this.ForceConversionFactor * this.LengthConversionFactor;
			this.ForcePerLengthConversionFactor = this.ForceConversionFactor / this.LengthConversionFactor;
			this.PressureConversionFactor = this.ForceConversionFactor / this.AreaConversionFactor;
			this.ForcePerVolumeConversionFactor = this.ForceConversionFactor / this.VolumeConversionFactor;
			this.MomentOfInertiaConversionFactor = this.AreaConversionFactor * this.AreaConversionFactor;
		}

		// Token: 0x06008929 RID: 35113 RVA: 0x0006FB98 File Offset: 0x0006DD98
		public ConsistentUnitsConverter(ForceUnit forceUnitIn, LengthUnit lengthUnitIn, ForceUnit forceUnitOut, LengthUnit lengthUnitOut)
		{
			this.SetupUnits(forceUnitIn, lengthUnitIn, forceUnitOut, lengthUnitOut);
		}

		// Token: 0x0600892A RID: 35114 RVA: 0x0006FBAB File Offset: 0x0006DDAB
		public ConsistentUnitsConverter(MomentUnit unitsIn, MomentUnit unitsOut)
		{
			this.SetupUnits(UnitConverter.GetForceUnit(unitsIn), UnitConverter.GetLengthUnit(unitsIn), UnitConverter.GetForceUnit(unitsOut), UnitConverter.GetLengthUnit(unitsOut));
		}

		// Token: 0x1700287A RID: 10362
		// (get) Token: 0x0600892B RID: 35115 RVA: 0x0006FBD1 File Offset: 0x0006DDD1
		// (set) Token: 0x0600892C RID: 35116 RVA: 0x0006FBD9 File Offset: 0x0006DDD9
		public ForceUnit ForceUnitIn { get; private set; }

		// Token: 0x1700287B RID: 10363
		// (get) Token: 0x0600892D RID: 35117 RVA: 0x0006FBE2 File Offset: 0x0006DDE2
		// (set) Token: 0x0600892E RID: 35118 RVA: 0x0006FBEA File Offset: 0x0006DDEA
		public LengthUnit LengthUnitIn { get; private set; }

		// Token: 0x1700287C RID: 10364
		// (get) Token: 0x0600892F RID: 35119 RVA: 0x0006FBF3 File Offset: 0x0006DDF3
		// (set) Token: 0x06008930 RID: 35120 RVA: 0x0006FBFB File Offset: 0x0006DDFB
		public ForceUnit ForceUnitOut { get; private set; }

		// Token: 0x1700287D RID: 10365
		// (get) Token: 0x06008931 RID: 35121 RVA: 0x0006FC04 File Offset: 0x0006DE04
		// (set) Token: 0x06008932 RID: 35122 RVA: 0x0006FC0C File Offset: 0x0006DE0C
		public LengthUnit LengthUnitOut { get; private set; }

		// Token: 0x06008933 RID: 35123 RVA: 0x0006FC15 File Offset: 0x0006DE15
		public string ForceUnitSymbolOut()
		{
			return UnitConverter.GetUnitSymbol(this.ForceUnitOut);
		}

		// Token: 0x06008934 RID: 35124 RVA: 0x0006FC22 File Offset: 0x0006DE22
		public string LengthUnitSymbolOut()
		{
			return UnitConverter.GetUnitSymbol(this.LengthUnitOut);
		}

		// Token: 0x06008935 RID: 35125 RVA: 0x0006FC2F File Offset: 0x0006DE2F
		public string AreaUnitSymbolOut()
		{
			return UnitConverter.GetUnitSymbol(this.LengthUnitOut) + #Phc.#3hc(107360074);
		}

		// Token: 0x06008936 RID: 35126 RVA: 0x0006FC4B File Offset: 0x0006DE4B
		public string VolumeUnitSymbolOut()
		{
			return UnitConverter.GetUnitSymbol(this.LengthUnitOut) + #Phc.#3hc(107421522);
		}

		// Token: 0x06008937 RID: 35127 RVA: 0x001D41E0 File Offset: 0x001D23E0
		public string MomentUnitSymbolOut()
		{
			MomentUnit momentUnit;
			if (UnitConverter.TryGetMomentUnit(this.LengthUnitOut, this.ForceUnitOut, out momentUnit))
			{
				return UnitConverter.GetUnitSymbol(momentUnit);
			}
			return this.ForceUnitSymbolOut() + #Phc.#3hc(107408434) + this.LengthUnitSymbolOut();
		}

		// Token: 0x06008938 RID: 35128 RVA: 0x001D4224 File Offset: 0x001D2424
		public string ForcePerLengthSymbolOut()
		{
			MomentUnit momentUnit;
			ForcePerLengthUnit forcePerLengthUnit;
			if (UnitConverter.TryGetMomentUnit(this.LengthUnitOut, this.ForceUnitOut, out momentUnit) && UnitConverter.TryGetForcePerLengthUnit(momentUnit, out forcePerLengthUnit))
			{
				return UnitConverter.GetUnitSymbol(forcePerLengthUnit);
			}
			return this.ForceUnitSymbolOut() + #Phc.#3hc(107224088) + this.LengthUnitSymbolOut();
		}

		// Token: 0x06008939 RID: 35129 RVA: 0x001D4274 File Offset: 0x001D2474
		public string PressureUnitSymbolOut()
		{
			MomentUnit momentUnit;
			PressureUnit pressureUnit;
			if (UnitConverter.TryGetMomentUnit(this.LengthUnitOut, this.ForceUnitOut, out momentUnit) && UnitConverter.TryGetPressureUnit(momentUnit, out pressureUnit))
			{
				return UnitConverter.GetUnitSymbol(pressureUnit);
			}
			return this.ForceUnitSymbolOut() + #Phc.#3hc(107224088) + this.LengthUnitSymbolOut() + #Phc.#3hc(107360074);
		}

		// Token: 0x0600893A RID: 35130 RVA: 0x001D42CC File Offset: 0x001D24CC
		public string ForcePerVolumeUnitSymbolOut()
		{
			MomentUnit momentUnit;
			ForcePerVolumeUnit forcePerVolumeUnit;
			if (UnitConverter.TryGetMomentUnit(this.LengthUnitOut, this.ForceUnitOut, out momentUnit) && UnitConverter.TryGetForcePerVolumehUnit(momentUnit, out forcePerVolumeUnit))
			{
				return UnitConverter.GetUnitSymbol(forcePerVolumeUnit);
			}
			return this.ForceUnitSymbolOut() + #Phc.#3hc(107224088) + this.LengthUnitSymbolOut() + #Phc.#3hc(107421522);
		}

		// Token: 0x0600893B RID: 35131 RVA: 0x0006FC67 File Offset: 0x0006DE67
		public string MomentOfInertiaUnitSymbolOut()
		{
			return this.LengthUnitSymbolOut() + #Phc.#3hc(107421485);
		}

		// Token: 0x1700287E RID: 10366
		// (get) Token: 0x0600893C RID: 35132 RVA: 0x0006FC7E File Offset: 0x0006DE7E
		// (set) Token: 0x0600893D RID: 35133 RVA: 0x0006FC86 File Offset: 0x0006DE86
		public double ForceConversionFactor { get; private set; }

		// Token: 0x1700287F RID: 10367
		// (get) Token: 0x0600893E RID: 35134 RVA: 0x0006FC8F File Offset: 0x0006DE8F
		// (set) Token: 0x0600893F RID: 35135 RVA: 0x0006FC97 File Offset: 0x0006DE97
		public double LengthConversionFactor { get; private set; }

		// Token: 0x17002880 RID: 10368
		// (get) Token: 0x06008940 RID: 35136 RVA: 0x0006FCA0 File Offset: 0x0006DEA0
		// (set) Token: 0x06008941 RID: 35137 RVA: 0x0006FCA8 File Offset: 0x0006DEA8
		public double AreaConversionFactor { get; private set; }

		// Token: 0x17002881 RID: 10369
		// (get) Token: 0x06008942 RID: 35138 RVA: 0x0006FCB1 File Offset: 0x0006DEB1
		// (set) Token: 0x06008943 RID: 35139 RVA: 0x0006FCB9 File Offset: 0x0006DEB9
		public double VolumeConversionFactor { get; private set; }

		// Token: 0x17002882 RID: 10370
		// (get) Token: 0x06008944 RID: 35140 RVA: 0x0006FCC2 File Offset: 0x0006DEC2
		// (set) Token: 0x06008945 RID: 35141 RVA: 0x0006FCCA File Offset: 0x0006DECA
		public double MomentConversionFactor { get; private set; }

		// Token: 0x17002883 RID: 10371
		// (get) Token: 0x06008946 RID: 35142 RVA: 0x0006FCD3 File Offset: 0x0006DED3
		// (set) Token: 0x06008947 RID: 35143 RVA: 0x0006FCDB File Offset: 0x0006DEDB
		public double ForcePerLengthConversionFactor { get; private set; }

		// Token: 0x17002884 RID: 10372
		// (get) Token: 0x06008948 RID: 35144 RVA: 0x0006FCE4 File Offset: 0x0006DEE4
		// (set) Token: 0x06008949 RID: 35145 RVA: 0x0006FCEC File Offset: 0x0006DEEC
		public double PressureConversionFactor { get; private set; }

		// Token: 0x17002885 RID: 10373
		// (get) Token: 0x0600894A RID: 35146 RVA: 0x0006FCF5 File Offset: 0x0006DEF5
		// (set) Token: 0x0600894B RID: 35147 RVA: 0x0006FCFD File Offset: 0x0006DEFD
		public double ForcePerVolumeConversionFactor { get; private set; }

		// Token: 0x17002886 RID: 10374
		// (get) Token: 0x0600894C RID: 35148 RVA: 0x0006FD06 File Offset: 0x0006DF06
		// (set) Token: 0x0600894D RID: 35149 RVA: 0x0006FD0E File Offset: 0x0006DF0E
		public double MomentOfInertiaConversionFactor { get; private set; }

		// Token: 0x0600894E RID: 35150 RVA: 0x0006FD17 File Offset: 0x0006DF17
		public double ConvertForce(double forceIn)
		{
			return forceIn * this.ForceConversionFactor;
		}

		// Token: 0x0600894F RID: 35151 RVA: 0x0006FD21 File Offset: 0x0006DF21
		public double ConvertLength(double lengthIn)
		{
			return lengthIn * this.LengthConversionFactor;
		}

		// Token: 0x06008950 RID: 35152 RVA: 0x0006FD2B File Offset: 0x0006DF2B
		public double ConvertArea(double areaIn)
		{
			return areaIn * this.AreaConversionFactor;
		}

		// Token: 0x06008951 RID: 35153 RVA: 0x0006FD35 File Offset: 0x0006DF35
		public double ConvertVolume(double volumeIn)
		{
			return volumeIn * this.VolumeConversionFactor;
		}

		// Token: 0x06008952 RID: 35154 RVA: 0x0006FD3F File Offset: 0x0006DF3F
		public double ConvertMoment(double momentIn)
		{
			return momentIn * this.MomentConversionFactor;
		}

		// Token: 0x06008953 RID: 35155 RVA: 0x0006FD49 File Offset: 0x0006DF49
		public double ConvertForcePerLength(double forcePerLengthIn)
		{
			return forcePerLengthIn * this.ForcePerLengthConversionFactor;
		}

		// Token: 0x06008954 RID: 35156 RVA: 0x0006FD53 File Offset: 0x0006DF53
		public double ConvertPressure(double pressureIn)
		{
			return pressureIn * this.PressureConversionFactor;
		}

		// Token: 0x06008955 RID: 35157 RVA: 0x0006FD5D File Offset: 0x0006DF5D
		public double ConvertForcePerVolume(double forcePerVolumeIn)
		{
			return forcePerVolumeIn * this.ForcePerVolumeConversionFactor;
		}

		// Token: 0x06008956 RID: 35158 RVA: 0x0006FD67 File Offset: 0x0006DF67
		public double ConvertMomentOfInertia(double momentOfInertiaIn)
		{
			return momentOfInertiaIn * this.MomentOfInertiaConversionFactor;
		}
	}
}
