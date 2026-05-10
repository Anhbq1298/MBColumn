using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Threading;
using #4vc;
using #7hc;
using #7Tc;
using #Fmc;
using #UYd;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.Geometry.Misc;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Units.Formatters;

namespace StructurePoint.CoreAssets.GUI.Framework.PreciseInput
{
	// Token: 0x02000C78 RID: 3192
	public sealed class PreciseInputControlDataContext : NotifyPropertyChangedObjectBase
	{
		// Token: 0x060066D3 RID: 26323 RVA: 0x00191B28 File Offset: 0x0018FD28
		public PreciseInputControlDataContext()
		{
			this.XGlobal = new #GVc();
			this.YGlobal = new #GVc();
			this.XLocal = new #GVc();
			this.YLocal = new #GVc();
			this.Angle = new #GVc();
			this.Radius = new #GVc();
			this.EnabledPreciseInputSwitches = EnabledPreciseInputSwitches.All;
			this.#m = new Dictionary<#8Tc, IList<#GVc>>();
			this.#m[#8Tc.#a] = new List<#GVc>
			{
				this.XGlobal,
				this.YGlobal
			};
			this.#m[#8Tc.#b] = new List<#GVc>
			{
				this.XLocal,
				this.YLocal
			};
			this.#m[#8Tc.#c] = new List<#GVc>
			{
				this.Radius,
				this.Angle
			};
			this.#l = new List<#GVc>
			{
				this.XGlobal,
				this.YGlobal,
				this.XLocal,
				this.YLocal,
				this.Angle,
				this.Radius
			};
			foreach (#GVc #GVc in this.#l)
			{
				#GVc.PropertyChanged += this.#VUc;
			}
			this.#a = new PreciseInputParameters();
		}

		// Token: 0x17001C80 RID: 7296
		// (get) Token: 0x060066D4 RID: 26324 RVA: 0x000527E7 File Offset: 0x000509E7
		// (set) Token: 0x060066D5 RID: 26325 RVA: 0x00191CBC File Offset: 0x0018FEBC
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		public string LengthUnitValueSymbol
		{
			get
			{
				return this.#t;
			}
			set
			{
				if (this.#t != value)
				{
					string propertyName = #Phc.#3hc(107441427);
					if (!false)
					{
						base.RaisePropertyChanging(propertyName);
					}
					this.#t = value;
					string propertyName2 = #Phc.#3hc(107441427);
					if (!false)
					{
						base.RaisePropertyChanged(propertyName2);
					}
				}
			}
		}

		// Token: 0x17001C81 RID: 7297
		// (get) Token: 0x060066D6 RID: 26326 RVA: 0x000527EF File Offset: 0x000509EF
		// (set) Token: 0x060066D7 RID: 26327 RVA: 0x00191D0C File Offset: 0x0018FF0C
		public EnabledPreciseInputSwitches EnabledPreciseInputSwitches
		{
			get
			{
				return this.#n;
			}
			set
			{
				for (;;)
				{
					if (this.#n == value)
					{
						goto IL_36;
					}
					string propertyName = #Phc.#3hc(107440886);
					if (5 != 0)
					{
						base.RaisePropertyChanging(propertyName);
					}
					IL_19:
					if (3 != 0)
					{
						if (false)
						{
							continue;
						}
						this.#n = value;
						string propertyName2 = #Phc.#3hc(107440886);
						if (!false)
						{
							base.RaisePropertyChanged(propertyName2);
						}
					}
					IL_36:
					if (true)
					{
						break;
					}
					goto IL_19;
				}
			}
		}

		// Token: 0x17001C82 RID: 7298
		// (get) Token: 0x060066D8 RID: 26328 RVA: 0x000527F7 File Offset: 0x000509F7
		// (set) Token: 0x060066D9 RID: 26329 RVA: 0x00191D60 File Offset: 0x0018FF60
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		public string AngleUnitSymbol
		{
			get
			{
				return this.#u;
			}
			set
			{
				if (this.#u != value)
				{
					string propertyName = #Phc.#3hc(107440849);
					if (!false)
					{
						base.RaisePropertyChanging(propertyName);
					}
					this.#u = value;
					string propertyName2 = #Phc.#3hc(107440849);
					if (!false)
					{
						base.RaisePropertyChanged(propertyName2);
					}
				}
			}
		}

		// Token: 0x17001C83 RID: 7299
		// (get) Token: 0x060066DA RID: 26330 RVA: 0x000527FF File Offset: 0x000509FF
		// (set) Token: 0x060066DB RID: 26331 RVA: 0x00191DB0 File Offset: 0x0018FFB0
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		public IUnitValueFormatter LengthUnitValueFormatter
		{
			get
			{
				return this.#s;
			}
			set
			{
				for (;;)
				{
					if (this.#s == value)
					{
						goto IL_36;
					}
					string propertyName = #Phc.#3hc(107440828);
					if (5 != 0)
					{
						base.RaisePropertyChanging(propertyName);
					}
					IL_19:
					if (3 != 0)
					{
						if (false)
						{
							continue;
						}
						this.#s = value;
						string propertyName2 = #Phc.#3hc(107440828);
						if (!false)
						{
							base.RaisePropertyChanged(propertyName2);
						}
					}
					IL_36:
					if (true)
					{
						break;
					}
					goto IL_19;
				}
			}
		}

		// Token: 0x17001C84 RID: 7300
		// (get) Token: 0x060066DC RID: 26332 RVA: 0x00052807 File Offset: 0x00050A07
		// (set) Token: 0x060066DD RID: 26333 RVA: 0x00191E04 File Offset: 0x00190004
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		public bool IsInsertButtonEnabled
		{
			get
			{
				return this.#i;
			}
			set
			{
				for (;;)
				{
					if (this.#i == value)
					{
						goto IL_36;
					}
					string propertyName = #Phc.#3hc(107440795);
					if (5 != 0)
					{
						base.RaisePropertyChanging(propertyName);
					}
					IL_19:
					if (3 != 0)
					{
						if (false)
						{
							continue;
						}
						this.#i = value;
						string propertyName2 = #Phc.#3hc(107440795);
						if (!false)
						{
							base.RaisePropertyChanged(propertyName2);
						}
					}
					IL_36:
					if (true)
					{
						break;
					}
					goto IL_19;
				}
			}
		}

		// Token: 0x17001C85 RID: 7301
		// (get) Token: 0x060066DE RID: 26334 RVA: 0x0005280F File Offset: 0x00050A0F
		public Point ResultPoint
		{
			get
			{
				return this.#6Uc();
			}
		}

		// Token: 0x17001C86 RID: 7302
		// (get) Token: 0x060066DF RID: 26335 RVA: 0x00052817 File Offset: 0x00050A17
		public Point GlobalPoint
		{
			get
			{
				return new Point(this.XGlobal.CalculatedValue, this.YGlobal.CalculatedValue);
			}
		}

		// Token: 0x17001C87 RID: 7303
		// (get) Token: 0x060066E0 RID: 26336 RVA: 0x00052834 File Offset: 0x00050A34
		public Point LocalPoint
		{
			get
			{
				return new Point(this.XLocal.CalculatedValue, this.YLocal.CalculatedValue);
			}
		}

		// Token: 0x17001C88 RID: 7304
		// (get) Token: 0x060066E1 RID: 26337 RVA: 0x00191E58 File Offset: 0x00190058
		public Point PolarPoint
		{
			get
			{
				Point point = #6Tc.#2Tc(this.RelativeCoordinate, this.Radius.CalculatedValue, this.Angle.CalculatedValue);
				Point result;
				if (!false)
				{
					result = point;
				}
				double num = result.X;
				Point point2 = this.RelativeCoordinate;
				Point point3;
				if (4 != 0)
				{
					point3 = point2;
				}
				double num2 = num - point3.X;
				if (!false)
				{
					result.X = num2;
				}
				double num3 = result.Y;
				Point point4 = this.RelativeCoordinate;
				if (!false)
				{
					point3 = point4;
				}
				double num4 = num3 - point3.Y;
				if (!false)
				{
					result.Y = num4;
				}
				return result;
			}
		}

		// Token: 0x17001C89 RID: 7305
		// (get) Token: 0x060066E2 RID: 26338 RVA: 0x00052851 File Offset: 0x00050A51
		// (set) Token: 0x060066E3 RID: 26339 RVA: 0x00191EE0 File Offset: 0x001900E0
		public Point StartCoordinate
		{
			get
			{
				return this.#e;
			}
			set
			{
				if (Point.#F3d(this.#e, value))
				{
					string propertyName = #Phc.#3hc(107440766);
					if (!false)
					{
						base.RaisePropertyChanging(propertyName);
					}
					this.#e = value;
					string propertyName2 = #Phc.#3hc(107440766);
					if (!false)
					{
						base.RaisePropertyChanged(propertyName2);
					}
				}
			}
		}

		// Token: 0x17001C8A RID: 7306
		// (get) Token: 0x060066E4 RID: 26340 RVA: 0x00052859 File Offset: 0x00050A59
		// (set) Token: 0x060066E5 RID: 26341 RVA: 0x00191F30 File Offset: 0x00190130
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "It is used in xaml.")]
		public Point RelativeCoordinate
		{
			get
			{
				return this.#b;
			}
			set
			{
				if (Point.#F3d(this.#b, value))
				{
					string propertyName = #Phc.#3hc(107440713);
					if (!false)
					{
						base.RaisePropertyChanging(propertyName);
					}
					this.#b = value;
					string propertyName2 = #Phc.#3hc(107440713);
					if (!false)
					{
						base.RaisePropertyChanged(propertyName2);
					}
				}
			}
		}

		// Token: 0x17001C8B RID: 7307
		// (get) Token: 0x060066E6 RID: 26342 RVA: 0x00052861 File Offset: 0x00050A61
		// (set) Token: 0x060066E7 RID: 26343 RVA: 0x00052869 File Offset: 0x00050A69
		public #GVc XGlobal { get; private set; }

		// Token: 0x17001C8C RID: 7308
		// (get) Token: 0x060066E8 RID: 26344 RVA: 0x00052872 File Offset: 0x00050A72
		// (set) Token: 0x060066E9 RID: 26345 RVA: 0x0005287A File Offset: 0x00050A7A
		public #GVc YGlobal { get; private set; }

		// Token: 0x17001C8D RID: 7309
		// (get) Token: 0x060066EA RID: 26346 RVA: 0x00052883 File Offset: 0x00050A83
		// (set) Token: 0x060066EB RID: 26347 RVA: 0x0005288B File Offset: 0x00050A8B
		public #GVc XLocal { get; private set; }

		// Token: 0x17001C8E RID: 7310
		// (get) Token: 0x060066EC RID: 26348 RVA: 0x00052894 File Offset: 0x00050A94
		// (set) Token: 0x060066ED RID: 26349 RVA: 0x0005289C File Offset: 0x00050A9C
		public #GVc YLocal { get; private set; }

		// Token: 0x17001C8F RID: 7311
		// (get) Token: 0x060066EE RID: 26350 RVA: 0x000528A5 File Offset: 0x00050AA5
		// (set) Token: 0x060066EF RID: 26351 RVA: 0x000528AD File Offset: 0x00050AAD
		public #GVc Radius { get; private set; }

		// Token: 0x17001C90 RID: 7312
		// (get) Token: 0x060066F0 RID: 26352 RVA: 0x000528B6 File Offset: 0x00050AB6
		// (set) Token: 0x060066F1 RID: 26353 RVA: 0x000528BE File Offset: 0x00050ABE
		public #GVc Angle { get; private set; }

		// Token: 0x17001C91 RID: 7313
		// (get) Token: 0x060066F2 RID: 26354 RVA: 0x000528C7 File Offset: 0x00050AC7
		// (set) Token: 0x060066F3 RID: 26355 RVA: 0x00191F80 File Offset: 0x00190180
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		public bool IsGlobalEnabled
		{
			get
			{
				return this.#f;
			}
			set
			{
				for (;;)
				{
					if (this.#f == value)
					{
						goto IL_36;
					}
					string propertyName = #Phc.#3hc(107440720);
					if (5 != 0)
					{
						base.RaisePropertyChanging(propertyName);
					}
					IL_19:
					if (3 != 0)
					{
						if (false)
						{
							continue;
						}
						this.#f = value;
						string propertyName2 = #Phc.#3hc(107440720);
						if (!false)
						{
							base.RaisePropertyChanged(propertyName2);
						}
					}
					IL_36:
					if (true)
					{
						break;
					}
					goto IL_19;
				}
			}
		}

		// Token: 0x17001C92 RID: 7314
		// (get) Token: 0x060066F4 RID: 26356 RVA: 0x000528CF File Offset: 0x00050ACF
		// (set) Token: 0x060066F5 RID: 26357 RVA: 0x00191FD4 File Offset: 0x001901D4
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		public bool IsLocalEnabled
		{
			get
			{
				return this.#g;
			}
			set
			{
				for (;;)
				{
					if (this.#g == value)
					{
						goto IL_36;
					}
					string propertyName = #Phc.#3hc(107440699);
					if (5 != 0)
					{
						base.RaisePropertyChanging(propertyName);
					}
					IL_19:
					if (3 != 0)
					{
						if (false)
						{
							continue;
						}
						this.#g = value;
						string propertyName2 = #Phc.#3hc(107440699);
						if (!false)
						{
							base.RaisePropertyChanged(propertyName2);
						}
					}
					IL_36:
					if (true)
					{
						break;
					}
					goto IL_19;
				}
			}
		}

		// Token: 0x17001C93 RID: 7315
		// (get) Token: 0x060066F6 RID: 26358 RVA: 0x000528D7 File Offset: 0x00050AD7
		// (set) Token: 0x060066F7 RID: 26359 RVA: 0x00192028 File Offset: 0x00190228
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		public bool IsPolarEnabled
		{
			get
			{
				return this.#h;
			}
			set
			{
				for (;;)
				{
					if (this.#h == value)
					{
						goto IL_36;
					}
					string propertyName = #Phc.#3hc(107440646);
					if (5 != 0)
					{
						base.RaisePropertyChanging(propertyName);
					}
					IL_19:
					if (3 != 0)
					{
						if (false)
						{
							continue;
						}
						this.#h = value;
						string propertyName2 = #Phc.#3hc(107440646);
						if (!false)
						{
							base.RaisePropertyChanged(propertyName2);
						}
					}
					IL_36:
					if (true)
					{
						break;
					}
					goto IL_19;
				}
			}
		}

		// Token: 0x17001C94 RID: 7316
		// (get) Token: 0x060066F8 RID: 26360 RVA: 0x000528DF File Offset: 0x00050ADF
		// (set) Token: 0x060066F9 RID: 26361 RVA: 0x0019207C File Offset: 0x0019027C
		public #8Tc CoordinateType
		{
			get
			{
				return this.#c;
			}
			set
			{
				if (this.#c != value)
				{
					string propertyName = #Phc.#3hc(107440657);
					if (!false)
					{
						base.RaisePropertyChanging(propertyName);
					}
					#8Tc #8Tc = this.#c;
					#8Tc #8Tc2;
					if (8 != 0)
					{
						#8Tc2 = #8Tc;
					}
					this.#c = value;
					string propertyName2 = #Phc.#3hc(107440657);
					if (!false)
					{
						base.RaisePropertyChanged(propertyName2);
					}
					#8Tc #9Uc = #8Tc2;
					if (3 != 0)
					{
						this.#8Uc(#9Uc, value);
					}
				}
			}
		}

		// Token: 0x17001C95 RID: 7317
		// (get) Token: 0x060066FA RID: 26362 RVA: 0x000528E7 File Offset: 0x00050AE7
		// (set) Token: 0x060066FB RID: 26363 RVA: 0x001920E4 File Offset: 0x001902E4
		public bool IsValid
		{
			get
			{
				return this.#d;
			}
			set
			{
				for (;;)
				{
					if (this.#d == value)
					{
						goto IL_36;
					}
					string propertyName = #Phc.#3hc(107441148);
					if (5 != 0)
					{
						base.RaisePropertyChanging(propertyName);
					}
					IL_19:
					if (3 != 0)
					{
						if (false)
						{
							continue;
						}
						this.#d = value;
						string propertyName2 = #Phc.#3hc(107441148);
						if (!false)
						{
							base.RaisePropertyChanged(propertyName2);
						}
					}
					IL_36:
					if (true)
					{
						break;
					}
					goto IL_19;
				}
			}
		}

		// Token: 0x17001C96 RID: 7318
		// (get) Token: 0x060066FC RID: 26364 RVA: 0x000528EF File Offset: 0x00050AEF
		// (set) Token: 0x060066FD RID: 26365 RVA: 0x00192138 File Offset: 0x00190338
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		public string Message
		{
			get
			{
				return this.#k;
			}
			set
			{
				if (this.#k != value)
				{
					string propertyName = #Phc.#3hc(107383983);
					if (!false)
					{
						base.RaisePropertyChanging(propertyName);
					}
					this.#k = value;
					string propertyName2 = #Phc.#3hc(107383983);
					if (!false)
					{
						base.RaisePropertyChanged(propertyName2);
					}
				}
			}
		}

		// Token: 0x17001C97 RID: 7319
		// (get) Token: 0x060066FE RID: 26366 RVA: 0x000528F7 File Offset: 0x00050AF7
		// (set) Token: 0x060066FF RID: 26367 RVA: 0x00192188 File Offset: 0x00190388
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used in XAML.")]
		public bool IsMoveAlongLineButtonEnabled
		{
			get
			{
				return this.#o;
			}
			set
			{
				for (;;)
				{
					if (this.#o == value)
					{
						goto IL_36;
					}
					string propertyName = #Phc.#3hc(107441103);
					if (5 != 0)
					{
						base.RaisePropertyChanging(propertyName);
					}
					IL_19:
					if (3 != 0)
					{
						if (false)
						{
							continue;
						}
						this.#o = value;
						string propertyName2 = #Phc.#3hc(107441103);
						if (!false)
						{
							base.RaisePropertyChanged(propertyName2);
						}
					}
					IL_36:
					if (true)
					{
						break;
					}
					goto IL_19;
				}
			}
		}

		// Token: 0x17001C98 RID: 7320
		// (get) Token: 0x06006700 RID: 26368 RVA: 0x000528FF File Offset: 0x00050AFF
		// (set) Token: 0x06006701 RID: 26369 RVA: 0x001921DC File Offset: 0x001903DC
		public bool EnableMovingAlongLine
		{
			get
			{
				return this.#q;
			}
			set
			{
				if (this.#q != value)
				{
					if (!value)
					{
						do
						{
							bool flag = false;
							if (3 != 0)
							{
								this.IsMoveAlongLineButtonEnabled = flag;
							}
							#GVc #GVc = this.XGlobal;
							bool flag2 = this.#a.EnableXCoordinate;
							if (6 != 0)
							{
								#GVc.IsEnabled = flag2;
							}
						}
						while (false);
						#GVc #GVc2 = this.YGlobal;
						bool flag3 = this.#a.EnableYCoordinate;
						if (8 != 0)
						{
							#GVc2.IsEnabled = flag3;
						}
						#GVc #GVc3 = this.XLocal;
						bool flag4 = this.#a.EnableXCoordinate;
						if (5 != 0)
						{
							#GVc3.IsEnabled = flag4;
						}
						#GVc #GVc4 = this.YLocal;
						bool flag5 = this.#a.EnableYCoordinate;
						if (3 != 0)
						{
							#GVc4.IsEnabled = flag5;
						}
						#GVc #GVc5 = this.Angle;
						bool flag6 = true;
						if (2 != 0)
						{
							#GVc5.IsEnabled = flag6;
						}
					}
					base.RaisePropertyChanging(#Phc.#3hc(107441062));
					this.#q = value;
					base.RaisePropertyChanged(#Phc.#3hc(107441062));
				}
			}
		}

		// Token: 0x17001C99 RID: 7321
		// (get) Token: 0x06006702 RID: 26370 RVA: 0x00052907 File Offset: 0x00050B07
		// (set) Token: 0x06006703 RID: 26371 RVA: 0x001922C8 File Offset: 0x001904C8
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used in XAML.")]
		public MoveMode MoveMode
		{
			get
			{
				return this.#r;
			}
			set
			{
				if (this.#r != value)
				{
					string propertyName = #Phc.#3hc(107441033);
					if (-1 != 0)
					{
						base.RaisePropertyChanging(propertyName);
					}
					this.#r = value;
					PreciseInputParameters #XUc = this.#a;
					if (!false)
					{
						this.#2Uc(#XUc);
					}
					string propertyName2 = #Phc.#3hc(107441033);
					if (5 != 0)
					{
						base.RaisePropertyChanged(propertyName2);
					}
				}
			}
		}

		// Token: 0x17001C9A RID: 7322
		// (get) Token: 0x06006704 RID: 26372 RVA: 0x00192328 File Offset: 0x00190528
		private bool IsMoveAlongLineAllowed
		{
			get
			{
				if (5 == 0 || this.MoveMode == MoveMode.FreeDefault)
				{
					goto IL_26;
				}
				double? num = this.#a.ConstantAngle;
				double? num2;
				if (-1 != 0)
				{
					num2 = num;
				}
				IL_1B:
				if (!false)
				{
					return num2 != null;
				}
				IL_26:
				if (5 != 0)
				{
					return false;
				}
				goto IL_1B;
			}
		}

		// Token: 0x17001C9B RID: 7323
		// (get) Token: 0x06006705 RID: 26373 RVA: 0x0005290F File Offset: 0x00050B0F
		private bool PerformMoveAlongLine
		{
			get
			{
				return this.IsMoveAlongLineAllowed && this.EnableMovingAlongLine;
			}
		}

		// Token: 0x17001C9C RID: 7324
		// (get) Token: 0x06006706 RID: 26374 RVA: 0x00192364 File Offset: 0x00190564
		[SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
		private static Point DefaultInitialPoint
		{
			get
			{
				return default(Point);
			}
		}

		// Token: 0x06006707 RID: 26375 RVA: 0x0019237C File Offset: 0x0019057C
		private void #VUc(object #Ge, PropertyChangedEventArgs #He)
		{
			if (!this.#p)
			{
				return;
			}
			this.#p = false;
			try
			{
				for (;;)
				{
					#GVc #GVc = #Ge as #GVc;
					#GVc #GVc2;
					if (!false)
					{
						#GVc2 = #GVc;
					}
					if (!false)
					{
						if (#GVc2 != null)
						{
							if (false)
							{
								goto IL_2B;
							}
							this.#4Uc();
							goto IL_2B;
						}
						IL_33:
						IEnumerator<#GVc> enumerator = this.#l.GetEnumerator();
						IEnumerator<#GVc> enumerator2;
						if (!false)
						{
							enumerator2 = enumerator;
						}
						try
						{
							while (enumerator2.MoveNext())
							{
								#GVc #GVc3 = enumerator2.Current;
								bool #zVc = true;
								if (5 != 0)
								{
									#GVc3.#AVc(#zVc);
								}
							}
						}
						finally
						{
							if (enumerator2 != null)
							{
								enumerator2.Dispose();
							}
						}
						bool flag = true;
						if (!false)
						{
							this.IsValid = flag;
						}
						this.#YUc();
						if (false)
						{
							continue;
						}
						if (5 != 0 && !false)
						{
							break;
						}
						IL_2B:
						#GVc #GVc4 = #GVc2;
						if (false)
						{
							goto IL_33;
						}
						#GVc4.#CVc();
						goto IL_33;
					}
				}
			}
			finally
			{
				this.#p = true;
			}
		}

		// Token: 0x06006708 RID: 26376 RVA: 0x00052921 File Offset: 0x00050B21
		public void #cg()
		{
			if (6 != 0)
			{
				this.#3Uc();
			}
		}

		// Token: 0x06006709 RID: 26377 RVA: 0x0019245C File Offset: 0x0019065C
		public void #WUc(PreciseInputParameters #XUc)
		{
			string #R0d = #Phc.#3hc(107441052);
			StructurePoint.CoreAssets.Infrastructure.Exceptions.Component #x6c = StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.DesktopControls;
			string #Qic = #Phc.#3hc(107441015);
			if (!false)
			{
				#X0d.#V0d(#XUc, #R0d, #x6c, #Qic);
			}
			this.#a = #XUc;
			EnabledPreciseInputSwitches enabledPreciseInputSwitches = #XUc.EnabledPreciseInputSwitches;
			if (!false)
			{
				this.EnabledPreciseInputSwitches = enabledPreciseInputSwitches;
			}
			bool flag = #XUc.IsInsertButtonEnabled;
			if (5 != 0)
			{
				this.IsInsertButtonEnabled = flag;
			}
			string text = #XUc.Message;
			if (!false)
			{
				this.Message = text;
			}
			this.#j = #XUc.IsInitialCoordinate;
			IUnitValueFormatter unitValueFormatter = #XUc.LengthUnitValueFormatter;
			if (8 != 0)
			{
				this.LengthUnitValueFormatter = unitValueFormatter;
			}
			string text2 = #XUc.LengthUnitSymbol;
			if (-1 != 0)
			{
				this.LengthUnitValueSymbol = text2;
			}
			this.AngleUnitSymbol = #XUc.AngleUnitSymbol;
			this.#1Uc(#XUc);
			if (#XUc.Coordinate != null)
			{
				this.StartCoordinate = #XUc.Coordinate.Value;
				this.XGlobal.#BVc(this.StartCoordinate.X);
				this.YGlobal.#BVc(this.StartCoordinate.Y);
			}
			if (this.#j)
			{
				Point point = #XUc.RelativeCoordinate ?? PreciseInputControlDataContext.DefaultInitialPoint;
				this.RelativeCoordinate = point;
				this.XLocal.#BVc(this.XGlobal.CalculatedValue - this.RelativeCoordinate.X);
				this.YLocal.#BVc(this.YGlobal.CalculatedValue - this.RelativeCoordinate.Y);
				if (#XUc.ConstantAngle != null)
				{
					this.Angle.#BVc(#XUc.ConstantAngle.Value);
					this.Radius.#BVc(0.0);
					this.XLocal.#BVc(0.0);
					this.YLocal.#BVc(0.0);
				}
				else
				{
					this.Angle.#BVc(#6Tc.#0Tc(point.X, point.Y, this.StartCoordinate.X, this.StartCoordinate.Y));
					this.Radius.#BVc(#6Tc.#1Tc(point.X, point.Y, this.StartCoordinate.X, this.StartCoordinate.Y));
				}
			}
			else
			{
				this.XLocal.#BVc(PreciseInputControlDataContext.DefaultInitialPoint.X);
				this.YLocal.#BVc(PreciseInputControlDataContext.DefaultInitialPoint.Y);
				this.Radius.#BVc(0.0);
				this.Angle.#BVc(0.0);
				this.RelativeCoordinate = this.StartCoordinate;
			}
			this.IsValid = true;
			if (#XUc.CoordinateType != null)
			{
				this.CoordinateType = #XUc.CoordinateType.Value;
			}
			if ((!this.#h && this.#c == #8Tc.#c) || (!this.#g && this.#c == #8Tc.#b))
			{
				this.CoordinateType = #8Tc.#a;
			}
			this.#r = #XUc.MoveMode;
			this.#2Uc(#XUc);
			base.RaisePropertyChanged(null);
		}

		// Token: 0x0600670A RID: 26378 RVA: 0x001927BC File Offset: 0x001909BC
		private void #YUc()
		{
			EventHandler eventHandler = this.#B;
			EventHandler eventHandler2;
			if (!false)
			{
				eventHandler2 = eventHandler;
			}
			if (eventHandler2 != null)
			{
				EventHandler eventHandler3 = eventHandler2;
				EventArgs e = new EventArgs();
				if (!false)
				{
					eventHandler3(this, e);
				}
			}
		}

		// Token: 0x14000189 RID: 393
		// (add) Token: 0x0600670B RID: 26379 RVA: 0x001927F0 File Offset: 0x001909F0
		// (remove) Token: 0x0600670C RID: 26380 RVA: 0x00192848 File Offset: 0x00190A48
		public event EventHandler CoordinateChanged
		{
			[CompilerGenerated]
			add
			{
				if (!false)
				{
					EventHandler eventHandler2;
					if (!false)
					{
						EventHandler eventHandler = this.#B;
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
							EventHandler eventHandler6 = Interlocked.CompareExchange<EventHandler>(ref this.#B, value2, eventHandler4);
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
						EventHandler eventHandler = this.#B;
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
							EventHandler eventHandler6 = Interlocked.CompareExchange<EventHandler>(ref this.#B, value2, eventHandler4);
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

		// Token: 0x0600670D RID: 26381 RVA: 0x001928A0 File Offset: 0x00190AA0
		private void #1Uc(PreciseInputParameters #XUc)
		{
			if (#XUc.ResetCurrentValues)
			{
				bool flag = true;
				if (5 != 0)
				{
					this.IsValid = flag;
				}
				Point point = default(Point);
				Point point2 = point;
				if (!false)
				{
					this.StartCoordinate = point2;
				}
				#GVc #GVc = this.XGlobal;
				Point point3 = PreciseInputControlDataContext.DefaultInitialPoint;
				if (!false)
				{
					point = point3;
				}
				double num = point.X;
				if (6 != 0)
				{
					#GVc.#BVc(num);
				}
				#GVc #GVc2 = this.YGlobal;
				Point point4 = PreciseInputControlDataContext.DefaultInitialPoint;
				if (!false)
				{
					point = point4;
				}
				double num2 = point.Y;
				if (!false)
				{
					#GVc2.#BVc(num2);
				}
				this.RelativeCoordinate = default(Point);
			}
		}

		// Token: 0x0600670E RID: 26382 RVA: 0x00192934 File Offset: 0x00190B34
		private void #2Uc(PreciseInputParameters #XUc)
		{
			bool flag = #XUc.IsGlobalEnabled;
			if (true)
			{
				this.IsGlobalEnabled = flag;
			}
			do
			{
				bool flag2 = #XUc.IsLocalEnabled;
				if (!false)
				{
					this.IsLocalEnabled = flag2;
				}
				bool flag3 = #XUc.IsPolarEnabled;
				if (!false)
				{
					this.IsPolarEnabled = flag3;
				}
				MoveMode moveMode = this.MoveMode;
				MoveMode moveMode2;
				if (6 != 0)
				{
					moveMode2 = moveMode;
				}
				bool flag5;
				bool flag7;
				if (7 != 0)
				{
					bool flag4 = moveMode2 == MoveMode.FreeDefault || moveMode2 == MoveMode.X;
					if (6 != 0)
					{
						flag5 = flag4;
					}
					bool flag6 = moveMode2 == MoveMode.FreeDefault || moveMode2 == MoveMode.Y;
					if (true)
					{
						flag7 = flag6;
					}
					this.XLocal.IsEnabled = (#XUc.EnableXCoordinate && flag5);
					this.YLocal.IsEnabled = (#XUc.EnableYCoordinate && flag7);
				}
				this.XGlobal.IsEnabled = (#XUc.EnableXCoordinate && flag5);
				this.YGlobal.IsEnabled = (#XUc.EnableYCoordinate && flag7);
				this.Angle.IsEnabled = (#XUc.MoveMode == MoveMode.FreeDefault);
				this.IsMoveAlongLineButtonEnabled = (#XUc.MoveMode != MoveMode.FreeDefault);
				this.EnableMovingAlongLine = (#XUc.MoveMode != MoveMode.FreeDefault);
			}
			while (false);
		}

		// Token: 0x0600670F RID: 26383 RVA: 0x00192A5C File Offset: 0x00190C5C
		private void #3Uc()
		{
			bool flag = true;
			if (3 != 0)
			{
				this.IsValid = flag;
			}
			do
			{
				if (4 != 0)
				{
					this.#4Uc();
				}
				IEnumerator<#GVc> enumerator = this.#m[this.CoordinateType].GetEnumerator();
				IEnumerator<#GVc> enumerator2;
				if (true)
				{
					enumerator2 = enumerator;
				}
				try
				{
					while (enumerator2.MoveNext())
					{
						#GVc #GVc = enumerator2.Current;
						#GVc #GVc2;
						if (!false)
						{
							#GVc2 = #GVc;
						}
						#GVc #GVc3 = #GVc2;
						bool #zVc = true;
						if (4 != 0)
						{
							#GVc3.#AVc(#zVc);
						}
						string text = #GVc2.#IH();
						string text2;
						if (6 != 0)
						{
							text2 = text;
						}
						if (text2 != null)
						{
							#GVc2.#yVc(text2, true);
							this.IsValid = false;
						}
					}
				}
				finally
				{
					if (enumerator2 != null)
					{
						enumerator2.Dispose();
					}
				}
				#9Tc #9Tc = this.#a.ValidationProvider;
				if (!this.IsValid || #9Tc == null)
				{
					return;
				}
				string text3 = #9Tc.#vNc(#ivc.#a, this.ResultPoint);
				if (string.IsNullOrEmpty(text3))
				{
					text3 = #9Tc.#vNc(#ivc.#b, this.ResultPoint);
				}
				if (text3 == null)
				{
					return;
				}
				using (IEnumerator<#GVc> enumerator2 = this.#m[this.CoordinateType].GetEnumerator())
				{
					for (;;)
					{
						while (enumerator2.MoveNext())
						{
							if (!false)
							{
								enumerator2.Current.#yVc(text3, true);
							}
						}
						break;
					}
				}
			}
			while (3 == 0);
			this.IsValid = false;
		}

		// Token: 0x06006710 RID: 26384 RVA: 0x00192BAC File Offset: 0x00190DAC
		private void #4Uc()
		{
			if (false)
			{
				goto IL_A0;
			}
			double? num = this.#a.MinX;
			double? num2;
			if (!false)
			{
				num2 = num;
			}
			bool flag = num2 != null;
			IL_1F:
			if (flag)
			{
				#GVc #GVc = this.XGlobal;
				double? num3 = this.#a.MinX;
				if (!false)
				{
					num2 = num3;
				}
				double? num4 = new double?(num2.Value);
				if (8 != 0)
				{
					#GVc.Min = num4;
				}
			}
			double? num5 = this.#a.MinY;
			if (3 != 0)
			{
				num2 = num5;
			}
			if (num2 != null)
			{
				#GVc #GVc2 = this.YGlobal;
				double? num6 = this.#a.MinY;
				if (!false)
				{
					num2 = num6;
				}
				double? num7 = new double?(num2.Value);
				if (8 != 0)
				{
					#GVc2.Min = num7;
				}
			}
			num2 = this.#a.MaxX;
			IL_A0:
			bool flag3;
			bool flag2 = flag = (flag3 = (num2 != null));
			if (!false)
			{
				if (flag2)
				{
					if (false)
					{
						goto IL_23C;
					}
					#GVc #GVc3 = this.XGlobal;
					num2 = this.#a.MaxX;
					#GVc3.Max = new double?(num2.Value);
				}
				num2 = this.#a.MaxY;
				if (8 == 0)
				{
					goto IL_176;
				}
				if (num2 != null)
				{
					#GVc #GVc4 = this.YGlobal;
					num2 = this.#a.MaxY;
					#GVc4.Max = new double?(num2.Value);
				}
				num2 = this.XGlobal.Min;
				flag3 = (flag = (num2 != null));
			}
			if (false)
			{
				goto IL_1F;
			}
			if (flag3)
			{
				#GVc #GVc5 = this.XLocal;
				num2 = this.XGlobal.Min;
				double num8 = this.RelativeCoordinate.X;
				#GVc5.Min = num2 - num8;
			}
			IL_176:
			num2 = this.XGlobal.Max;
			if (num2 != null)
			{
				#GVc #GVc6 = this.XLocal;
				num2 = this.XGlobal.Max;
				double num8 = this.RelativeCoordinate.X;
				#GVc6.Max = num2 - num8;
			}
			num2 = this.YGlobal.Min;
			if (num2 != null)
			{
				#GVc #GVc7 = this.YLocal;
				num2 = this.YGlobal.Min;
				double num8 = this.RelativeCoordinate.Y;
				#GVc7.Min = num2 - num8;
			}
			num2 = this.YGlobal.Max;
			IL_23C:
			if (num2 != null)
			{
				#GVc #GVc8 = this.YLocal;
				num2 = this.YGlobal.Max;
				double num8 = this.RelativeCoordinate.Y;
				#GVc8.Max = num2 - num8;
			}
			this.#5Uc();
		}

		// Token: 0x06006711 RID: 26385 RVA: 0x00192E78 File Offset: 0x00191078
		private void #5Uc()
		{
			#GVc #GVc = this.Radius;
			double? num = new double?(0.0);
			if (7 != 0)
			{
				#GVc.Min = num;
			}
			double? num2 = this.#a.MinX;
			double? num3;
			if (8 != 0)
			{
				num3 = num2;
			}
			if (num3 != null)
			{
				double? num4 = this.#a.MaxX;
				if (!false)
				{
					num3 = num4;
				}
				if (num3 != null)
				{
					if (!false)
					{
						double? num5 = this.#a.MinY;
						if (!false)
						{
							num3 = num5;
						}
						if (num3 == null)
						{
							return;
						}
					}
					double? num6 = this.#a.MaxY;
					if (5 != 0)
					{
						num3 = num6;
					}
					if (num3 != null)
					{
						while (this.PerformMoveAlongLine)
						{
							double? num7 = this.#a.ConstantAngle;
							if (5 != 0)
							{
								num3 = num7;
							}
							if (num3 == null)
							{
								break;
							}
							if (6 != 0)
							{
								num3 = this.#a.ConstantAngle;
								double value = num3.Value;
								Point #tEb = this.RelativeCoordinate;
								double #Udb = value;
								num3 = this.#a.MinX;
								double value2 = num3.Value;
								num3 = this.#a.MaxX;
								double value3 = num3.Value;
								num3 = this.#a.MinY;
								double value4 = num3.Value;
								num3 = this.#a.MaxY;
								#ewc #ewc = new #ewc(#tEb, #Udb, new BoundingBoxData(value2, value3, value4, num3.Value));
								double num8 = GeometryHelper.#lcb(this.RelativeCoordinate, #ewc.LineSegment.StartPoint);
								double num9 = GeometryHelper.#lcb(this.RelativeCoordinate, #ewc.LineSegment.EndPoint);
								if (value <= 90.0 || (value > 180.0 && value < 270.0))
								{
									this.Radius.Max = new double?(num9);
									this.Radius.Min = new double?(-num8);
									return;
								}
								this.Radius.Max = new double?(num8);
								this.Radius.Min = new double?(-num9);
								return;
							}
						}
						#GVc #GVc2 = this.Radius;
						Point #Xrb = this.RelativeCoordinate;
						double #Udb2 = this.Angle.CalculatedValue;
						num3 = this.#a.MinX;
						double value5 = num3.Value;
						num3 = this.#a.MaxX;
						double value6 = num3.Value;
						num3 = this.#a.MinY;
						double value7 = num3.Value;
						num3 = this.#a.MaxY;
						#GVc2.Max = #6Tc.#VTc(#Xrb, #Udb2, value5, value6, value7, num3.Value);
						#GVc #GVc3 = this.Radius;
						num3 = this.Radius.Max;
						#GVc3.Min = -num3;
					}
				}
			}
		}

		// Token: 0x06006712 RID: 26386 RVA: 0x0005292F File Offset: 0x00050B2F
		private Point #6Uc()
		{
			return this.#6Uc(this.CoordinateType);
		}

		// Token: 0x06006713 RID: 26387 RVA: 0x00193128 File Offset: 0x00191328
		private Point #6Uc(#8Tc #7Uc)
		{
			Point result;
			double? num2;
			bool flag2;
			for (;;)
			{
				Point point = this.GlobalPoint;
				if (!false)
				{
					result = point;
				}
				for (;;)
				{
					IL_0D:
					if (#7Uc == #8Tc.#a)
					{
						Point point2 = this.GlobalPoint;
						if (true)
						{
							result = point2;
						}
					}
					else
					{
						if (-1 == 0)
						{
							break;
						}
						if (#7Uc == #8Tc.#b)
						{
							Point point3 = #6Tc.#TTc(this.LocalPoint, this.RelativeCoordinate);
							if (7 != 0)
							{
								result = point3;
							}
						}
						else if (#7Uc == #8Tc.#c)
						{
							Point point4 = #6Tc.#TTc(this.PolarPoint, this.RelativeCoordinate);
							if (5 != 0)
							{
								result = point4;
							}
						}
					}
					bool flag = this.PerformMoveAlongLine;
					while (flag)
					{
						if (8 != 0)
						{
							if (6 == 0)
							{
								goto IL_0D;
							}
							if (#7Uc == #8Tc.#c)
							{
								break;
							}
						}
						double? num = this.#a.ConstantAngle;
						if (!false)
						{
							num2 = num;
						}
						flag2 = (flag = (num2 != null));
						if (!false)
						{
							goto Block_7;
						}
					}
					return result;
				}
			}
			Block_7:
			if (flag2)
			{
				Point location = this.RelativeCoordinate;
				double? num3 = this.#a.ConstantAngle;
				if (!false)
				{
					num2 = num3;
				}
				GeneralLineEquation generalLineEquation = new GeneralLineEquation(location, num2.Value, false);
				if (this.MoveMode == MoveMode.X)
				{
					result = new Point(result.X, generalLineEquation.#nlc(result.X));
				}
				if (this.MoveMode == MoveMode.Y)
				{
					result = new Point(generalLineEquation.#llc(result.Y), result.Y);
				}
			}
			return result;
		}

		// Token: 0x06006714 RID: 26388 RVA: 0x00193258 File Offset: 0x00191458
		private void #8Uc(#8Tc #9Uc, #8Tc #4T)
		{
			if (false)
			{
				goto IL_16;
			}
			if (#9Uc != #8Tc.#a)
			{
				goto IL_0F;
			}
			IL_06:
			if (#4T == #8Tc.#b && !false)
			{
				this.#fVc();
			}
			IL_0F:
			if (#9Uc != #8Tc.#a || #4T != #8Tc.#c)
			{
				goto IL_1B;
			}
			IL_16:
			if (!false)
			{
				this.#eVc();
			}
			IL_1B:
			if (#9Uc != #8Tc.#b || #4T != #8Tc.#a)
			{
				goto IL_27;
			}
			IL_22:
			if (!false)
			{
				this.#hVc();
			}
			IL_27:
			if (#9Uc == #8Tc.#b && #4T == #8Tc.#c && !false)
			{
				this.#gVc();
			}
			if (#9Uc == #8Tc.#c && #4T == #8Tc.#a && 5 != 0)
			{
				this.#dVc();
			}
			if (#9Uc == #8Tc.#c)
			{
				if (false)
				{
					goto IL_06;
				}
				if (5 == 0 || false)
				{
					goto IL_22;
				}
				if (#4T == #8Tc.#b && !false)
				{
					this.#cVc();
				}
			}
		}

		// Token: 0x06006715 RID: 26389 RVA: 0x001932E8 File Offset: 0x001914E8
		private void #aVc(Point #bVc, Point #Nmc)
		{
			double num2;
			double num4;
			double num6;
			double #bnc;
			double? num9;
			for (;;)
			{
				double num = #Nmc.X;
				if (3 != 0)
				{
					num2 = num;
				}
				double num3 = #Nmc.Y;
				if (!false)
				{
					num4 = num3;
				}
				double num5 = #bVc.X;
				if (!false)
				{
					num6 = num5;
				}
				double num7 = #bVc.Y;
				if (8 != 0)
				{
					#bnc = num7;
				}
				double? num8 = this.#a.ConstantAngle;
				if (2 != 0)
				{
					num9 = num8;
				}
				if (!true)
				{
					return;
				}
				if (num9 == null)
				{
					break;
				}
				if (!false)
				{
					goto Block_2;
				}
			}
			double #8mc = num2;
			double #9mc = num4;
			IL_58:
			double #anc = num6;
			IL_59:
			double num10 = #6Tc.#0Tc(#8mc, #9mc, #anc, #bnc);
			goto IL_7A;
			Block_2:
			double? num11 = this.#a.ConstantAngle;
			if (!false)
			{
				num9 = num11;
			}
			num10 = num9.Value;
			IL_7A:
			double #Udb = num10;
			double #8mc2 = #8mc = num2;
			double #9mc2 = #9mc = num4;
			if (3 == 0)
			{
				goto IL_58;
			}
			double #anc2 = #anc = num6;
			if (false)
			{
				goto IL_59;
			}
			double num12 = #6Tc.#1Tc(#8mc2, #9mc2, #anc2, #bnc);
			if (!PointsConverter.#uC(#6Tc.#2Tc(#Nmc, num12, #Udb), #bVc))
			{
				num12 = -num12;
			}
			this.Angle.#BVc(#Udb);
			this.Radius.#BVc(num12);
		}

		// Token: 0x06006716 RID: 26390 RVA: 0x001933D8 File Offset: 0x001915D8
		private void #cVc()
		{
			Point point2;
			if (!false && -1 != 0)
			{
				Point point = this.#6Uc(#8Tc.#c);
				if (!false)
				{
					point2 = point;
				}
			}
			#GVc #GVc = this.Radius;
			double num = 0.0;
			if (7 != 0)
			{
				#GVc.#BVc(num);
			}
			#GVc #GVc2 = this.Angle;
			double num2 = 0.0;
			if (!false)
			{
				#GVc2.#BVc(num2);
			}
			#GVc #GVc3 = this.XLocal;
			double num3 = point2.X;
			Point point3 = this.RelativeCoordinate;
			Point point4;
			if (!false)
			{
				point4 = point3;
			}
			double num4 = num3 - point4.X;
			if (3 != 0)
			{
				#GVc3.#BVc(num4);
			}
			#GVc #GVc4 = this.YLocal;
			double num5 = point2.Y;
			Point point5 = this.RelativeCoordinate;
			if (!false)
			{
				point4 = point5;
			}
			#GVc4.#BVc(num5 - point4.Y);
		}

		// Token: 0x06006717 RID: 26391 RVA: 0x00193488 File Offset: 0x00191688
		private void #dVc()
		{
			Point point = #6Tc.#2Tc(this.RelativeCoordinate, this.Radius.CalculatedValue, this.Angle.CalculatedValue);
			Point point2;
			if (8 != 0)
			{
				point2 = point;
			}
			#GVc #GVc = this.XGlobal;
			double num = point2.X;
			if (!false)
			{
				#GVc.#BVc(num);
			}
			#GVc #GVc2 = this.YGlobal;
			double num2 = point2.Y;
			if (!false)
			{
				#GVc2.#BVc(num2);
			}
			#GVc #GVc3 = this.Radius;
			double num3 = 0.0;
			if (!false)
			{
				#GVc3.#BVc(num3);
			}
			#GVc #GVc4 = this.Angle;
			double num4 = 0.0;
			if (!false)
			{
				#GVc4.#BVc(num4);
			}
		}

		// Token: 0x06006718 RID: 26392 RVA: 0x00193528 File Offset: 0x00191728
		private void #eVc()
		{
			Point #bVc = this.#6Uc(#8Tc.#a);
			Point #Nmc = this.RelativeCoordinate;
			if (4 != 0)
			{
				this.#aVc(#bVc, #Nmc);
			}
			#GVc #GVc = this.XGlobal;
			Point point = this.StartCoordinate;
			Point point2;
			if (!false)
			{
				point2 = point;
			}
			double num = point2.X;
			if (!false)
			{
				#GVc.#BVc(num);
			}
			#GVc #GVc2 = this.YGlobal;
			Point point3 = this.StartCoordinate;
			if (!false)
			{
				point2 = point3;
			}
			double num2 = point2.Y;
			if (8 != 0)
			{
				#GVc2.#BVc(num2);
			}
		}

		// Token: 0x06006719 RID: 26393 RVA: 0x0019359C File Offset: 0x0019179C
		private void #fVc()
		{
			Point point = this.#6Uc(#8Tc.#a);
			Point point2;
			if (!false)
			{
				point2 = point;
			}
			#GVc #GVc = this.XLocal;
			double num = point2.X - this.#b.X;
			if (-1 != 0)
			{
				#GVc.#BVc(num);
			}
			#GVc #GVc2 = this.YLocal;
			double num2 = point2.Y - this.#b.Y;
			if (!false)
			{
				#GVc2.#BVc(num2);
			}
			#GVc #GVc3 = this.XGlobal;
			Point point3 = this.StartCoordinate;
			Point point4;
			if (8 != 0)
			{
				point4 = point3;
			}
			double num3 = point4.X;
			if (6 != 0)
			{
				#GVc3.#BVc(num3);
			}
			#GVc #GVc4 = this.YGlobal;
			Point point5 = this.StartCoordinate;
			if (3 != 0)
			{
				point4 = point5;
			}
			#GVc4.#BVc(point4.Y);
		}

		// Token: 0x0600671A RID: 26394 RVA: 0x0019364C File Offset: 0x0019184C
		private void #gVc()
		{
			do
			{
				if (2 != 0)
				{
					Point point = this.#6Uc(#8Tc.#b);
					Point point2;
					if (!false)
					{
						point2 = point;
					}
					Point #bVc = point2;
					Point #Nmc = this.#b;
					if (!false)
					{
						this.#aVc(#bVc, #Nmc);
					}
					#GVc #GVc = this.XLocal;
					Point point3 = PreciseInputControlDataContext.DefaultInitialPoint;
					Point point4;
					if (-1 != 0)
					{
						point4 = point3;
					}
					double num = point4.X;
					if (!false)
					{
						#GVc.#BVc(num);
					}
					if (5 == 0)
					{
						continue;
					}
					#GVc #GVc2 = this.YLocal;
					Point point5 = PreciseInputControlDataContext.DefaultInitialPoint;
					if (!false)
					{
						point4 = point5;
					}
					double num2 = point4.Y;
					if (-1 != 0)
					{
						#GVc2.#BVc(num2);
					}
				}
			}
			while (false);
		}

		// Token: 0x0600671B RID: 26395 RVA: 0x001936D0 File Offset: 0x001918D0
		private void #hVc()
		{
			do
			{
				if (!false && -1 != 0)
				{
					#GVc #GVc = this.XGlobal;
					double num = this.XLocal.CalculatedValue + this.#b.X;
					if (!false)
					{
						#GVc.#BVc(num);
					}
				}
			}
			while (false);
			#GVc #GVc2 = this.YGlobal;
			double num2 = this.YLocal.CalculatedValue + this.#b.Y;
			if (!false)
			{
				#GVc2.#BVc(num2);
			}
			#GVc #GVc3 = this.XLocal;
			Point point = PreciseInputControlDataContext.DefaultInitialPoint;
			Point point2;
			if (3 != 0)
			{
				point2 = point;
			}
			double num3 = point2.X;
			if (!false)
			{
				#GVc3.#BVc(num3);
			}
			#GVc #GVc4 = this.YLocal;
			Point point3 = PreciseInputControlDataContext.DefaultInitialPoint;
			if (-1 != 0)
			{
				point2 = point3;
			}
			double num4 = point2.Y;
			if (3 != 0)
			{
				#GVc4.#BVc(num4);
			}
		}

		// Token: 0x04002A67 RID: 10855
		private PreciseInputParameters #a;

		// Token: 0x04002A68 RID: 10856
		private Point #b;

		// Token: 0x04002A69 RID: 10857
		private #8Tc #c;

		// Token: 0x04002A6A RID: 10858
		private bool #d;

		// Token: 0x04002A6B RID: 10859
		private Point #e;

		// Token: 0x04002A6C RID: 10860
		private bool #f;

		// Token: 0x04002A6D RID: 10861
		private bool #g;

		// Token: 0x04002A6E RID: 10862
		private bool #h;

		// Token: 0x04002A6F RID: 10863
		private bool #i;

		// Token: 0x04002A70 RID: 10864
		private bool #j;

		// Token: 0x04002A71 RID: 10865
		private string #k;

		// Token: 0x04002A72 RID: 10866
		private readonly IEnumerable<#GVc> #l;

		// Token: 0x04002A73 RID: 10867
		private readonly IDictionary<#8Tc, IList<#GVc>> #m;

		// Token: 0x04002A74 RID: 10868
		private EnabledPreciseInputSwitches #n;

		// Token: 0x04002A75 RID: 10869
		private bool #o;

		// Token: 0x04002A76 RID: 10870
		private bool #p = true;

		// Token: 0x04002A77 RID: 10871
		private bool #q;

		// Token: 0x04002A78 RID: 10872
		private MoveMode #r;

		// Token: 0x04002A79 RID: 10873
		private IUnitValueFormatter #s;

		// Token: 0x04002A7A RID: 10874
		private string #t;

		// Token: 0x04002A7B RID: 10875
		private string #u;

		// Token: 0x04002A7C RID: 10876
		[CompilerGenerated]
		private #GVc #v;

		// Token: 0x04002A7D RID: 10877
		[CompilerGenerated]
		private #GVc #w;

		// Token: 0x04002A7E RID: 10878
		[CompilerGenerated]
		private #GVc #x;

		// Token: 0x04002A7F RID: 10879
		[CompilerGenerated]
		private #GVc #y;

		// Token: 0x04002A80 RID: 10880
		[CompilerGenerated]
		private #GVc #z;

		// Token: 0x04002A81 RID: 10881
		[CompilerGenerated]
		private #GVc #A;

		// Token: 0x04002A82 RID: 10882
		[CompilerGenerated]
		private EventHandler #B;
	}
}
