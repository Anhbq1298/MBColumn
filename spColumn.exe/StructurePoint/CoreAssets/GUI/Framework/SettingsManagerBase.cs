using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using System.Xml.Linq;
using #45d;
using #7hc;
using #cYd;
using #UYd;
using #x5d;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.CoreAssets.Logger;

namespace StructurePoint.CoreAssets.GUI.Framework
{
	// Token: 0x02000293 RID: 659
	public class SettingsManagerBase : NotifyPropertyChangedObjectBase
	{
		// Token: 0x06001549 RID: 5449 RVA: 0x000B2538 File Offset: 0x000B0738
		public SettingsManagerBase(ILogger logger, #55d applicationSettingsProvider, #55d userSettingsProvider)
		{
			#X0d.#V0d(logger, #Phc.#3hc(107408919), Component.GUIFramework, #Phc.#3hc(107418775));
			#X0d.#V0d(userSettingsProvider, #Phc.#3hc(107418690), Component.GUIFramework, #Phc.#3hc(107418661));
			this.Logger = logger;
			this.ApplicationSettingProvider = applicationSettingsProvider;
			this.UserSettingProvider = userSettingsProvider;
			this.ColorConverter = new ColorConverter();
		}

		// Token: 0x1700079B RID: 1947
		// (get) Token: 0x0600154A RID: 5450 RVA: 0x00016981 File Offset: 0x00014B81
		// (set) Token: 0x0600154B RID: 5451 RVA: 0x00016989 File Offset: 0x00014B89
		private protected ILogger Logger { protected get; private set; }

		// Token: 0x1700079C RID: 1948
		// (get) Token: 0x0600154C RID: 5452 RVA: 0x00016992 File Offset: 0x00014B92
		// (set) Token: 0x0600154D RID: 5453 RVA: 0x0001699A File Offset: 0x00014B9A
		private protected ColorConverter ColorConverter { protected get; private set; }

		// Token: 0x1700079D RID: 1949
		// (get) Token: 0x0600154E RID: 5454 RVA: 0x000169A3 File Offset: 0x00014BA3
		// (set) Token: 0x0600154F RID: 5455 RVA: 0x000169AB File Offset: 0x00014BAB
		public #55d UserSettingProvider { get; private set; }

		// Token: 0x1700079E RID: 1950
		// (get) Token: 0x06001550 RID: 5456 RVA: 0x000169B4 File Offset: 0x00014BB4
		// (set) Token: 0x06001551 RID: 5457 RVA: 0x000169BC File Offset: 0x00014BBC
		public #55d ApplicationSettingProvider { get; private set; }

		// Token: 0x06001552 RID: 5458 RVA: 0x000B25A4 File Offset: 0x000B07A4
		[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
		public bool #DAc()
		{
			bool result;
			do
			{
				if (8 != 0)
				{
					List<PropertyInfo> list = base.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public).Where(new Func<PropertyInfo, bool>(SettingsManagerBase.<>c.<>9.#y8c)).ToList<PropertyInfo>();
					bool flag = true;
					if (!false)
					{
						result = flag;
					}
					List<PropertyInfo>.Enumerator enumerator = list.GetEnumerator();
					List<PropertyInfo>.Enumerator enumerator2;
					if (!false)
					{
						enumerator2 = enumerator;
					}
					try
					{
						while (!false && enumerator2.MoveNext())
						{
							PropertyInfo propertyInfo = enumerator2.Current;
							PropertyInfo propertyInfo2;
							if (!false)
							{
								propertyInfo2 = propertyInfo;
							}
							try
							{
								propertyInfo2.GetValue(this, null);
							}
							catch (Exception exception)
							{
								result = false;
								this.Logger.Log(LoggingLevel.Warning, exception);
							}
						}
					}
					finally
					{
						if (!false)
						{
							((IDisposable)enumerator2).Dispose();
						}
					}
				}
			}
			while (5 == 0);
			return result;
		}

		// Token: 0x06001553 RID: 5459 RVA: 0x000B2674 File Offset: 0x000B0874
		[SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "3#")]
		protected void #EAc<#Fu>(string #6cc, string #FAc, #Fu #7cc, out #Fu #f)
		{
			do
			{
				if (2 != 0 && !this.#VAc<#Fu>(#6cc, #7cc, this.UserSettingProvider, out #f))
				{
					this.#VAc<#Fu>(#FAc, #7cc, this.ApplicationSettingProvider, out #f);
					if (5 == 0)
					{
						continue;
					}
					#Fu #f2 = #f;
					#55d #JAc = this.UserSettingProvider;
					if (!false)
					{
						this.#WAc<#Fu>(#6cc, #f2, #JAc);
					}
				}
			}
			while (false);
		}

		// Token: 0x06001554 RID: 5460 RVA: 0x000B26CC File Offset: 0x000B08CC
		[SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "3#")]
		protected void #GAc(string #6cc, string #FAc, bool #7cc, out bool #f)
		{
			do
			{
				if (2 != 0 && !this.#OAc(#6cc, #7cc, this.UserSettingProvider, out #f))
				{
					this.#OAc(#FAc, #7cc, this.ApplicationSettingProvider, out #f);
					if (5 == 0)
					{
						continue;
					}
					bool #f2 = #f;
					#55d #JAc = this.UserSettingProvider;
					if (!false)
					{
						this.#NAc(#6cc, #f2, #JAc);
					}
				}
			}
			while (false);
		}

		// Token: 0x06001555 RID: 5461 RVA: 0x000B2720 File Offset: 0x000B0920
		[SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "3#")]
		protected void #HAc(string #6cc, string #FAc, string #7cc, out string #f)
		{
			do
			{
				if (2 != 0 && !this.#IAc(#6cc, string.Empty, this.UserSettingProvider, out #f))
				{
					this.#IAc(#FAc, #7cc, this.ApplicationSettingProvider, out #f);
					if (5 == 0)
					{
						continue;
					}
					string #f2 = #f;
					#55d #wx = this.UserSettingProvider;
					if (!false)
					{
						this.#LAc(#6cc, #f2, #wx);
					}
				}
			}
			while (false);
		}

		// Token: 0x06001556 RID: 5462 RVA: 0x000B2778 File Offset: 0x000B0978
		[SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "3#")]
		protected bool #IAc(string #6cc, string #7cc, #55d #wx, out string #f)
		{
			bool result;
			try
			{
				bool flag = #wx.#5cc(#6cc, #7cc, out #f);
				if (2 != 0)
				{
					result = flag;
				}
			}
			catch (#w5d #Uic)
			{
				#w5d exception = new #w5d(string.Format(CultureInfo.CurrentCulture, Strings.StringCannotReadTheSettingX, new object[]
				{
					#6cc
				}).#z2d(true) + Strings.StringUsedTheDefaultValue.#z2d(), #Phc.#3hc(107418640), Component.GUIFramework, #IYd.#b, #Uic);
				this.Logger.Log(LoggingLevel.Error, exception);
				#f = #7cc;
				result = false;
			}
			return result;
		}

		// Token: 0x06001557 RID: 5463 RVA: 0x000B2804 File Offset: 0x000B0A04
		protected string #IAc(#55d #JAc, string #7cc, [CallerMemberName] string #6cc = null)
		{
			string result;
			this.#IAc(#6cc, #7cc, #JAc, out result);
			return result;
		}

		// Token: 0x06001558 RID: 5464 RVA: 0x000B2820 File Offset: 0x000B0A20
		protected #Fu #KAc<#Fu>(#55d #JAc, #Fu #7cc, [CallerMemberName] string #6cc = null)
		{
			#Fu result;
			this.#KAc<#Fu>(#6cc, #7cc, #JAc, out result);
			return result;
		}

		// Token: 0x06001559 RID: 5465 RVA: 0x000B283C File Offset: 0x000B0A3C
		protected bool #KAc<#Fu>(string #6cc, #Fu #7cc, #55d #wx, out #Fu #f)
		{
			bool result2;
			try
			{
				string text = null;
				if (!false)
				{
					string text2 = text;
				}
				int num2;
				int num = num2 = 107381628;
				bool flag2;
				bool flag3;
				if (num != 0)
				{
					string text3 = #Phc.#3hc(num);
					string text4;
					if (!false)
					{
						text4 = text3;
					}
					if (#7cc != null)
					{
						List<Type> list = new List<Type>();
						Type typeFromHandle = typeof(!!0);
						if (5 != 0)
						{
							list.Add(typeFromHandle);
						}
						string text5 = #F0d.#y0d<#Fu>(#7cc, list);
						if (!false)
						{
							text4 = text5;
						}
						string text6 = new XCData(text4).ToString();
						if (!false)
						{
							text4 = text6;
						}
					}
					string text2;
					bool flag = #wx.#5cc(#6cc, text4, out text2);
					if (-1 != 0)
					{
						flag2 = flag;
					}
					if (flag2)
					{
						text2 = text2.Replace(#Phc.#3hc(107419099), null).Replace(#Phc.#3hc(107419054), null);
						if (text2.Equals(#Phc.#3hc(107381628)))
						{
							#f = #7cc;
							num2 = 0;
							goto IL_AF;
						}
						#f = #F0d.#C0d<#Fu>(text2, new List<Type>
						{
							typeof(!!0)
						});
					}
					else
					{
						#f = #7cc;
					}
					flag3 = flag2;
					goto IL_E4;
				}
				IL_AF:
				flag2 = (num2 != 0);
				bool result = flag3 = flag2;
				if (!false)
				{
					return result;
				}
				IL_E4:
				result2 = flag3;
			}
			catch (Exception exception)
			{
				if (false)
				{
					goto IL_12C;
				}
				this.Logger.Log(LoggingLevel.Error, exception);
				#f = #7cc;
				IL_12A:
				result2 = false;
				IL_12C:
				if (false)
				{
					goto IL_12A;
				}
			}
			return result2;
		}

		// Token: 0x0600155A RID: 5466 RVA: 0x000169C5 File Offset: 0x00014BC5
		protected void #LAc(#55d #JAc, string #f, [CallerMemberName] string #6cc = null)
		{
			if (!false)
			{
				this.#LAc(#6cc, #f, #JAc);
			}
		}

		// Token: 0x0600155B RID: 5467 RVA: 0x000169D9 File Offset: 0x00014BD9
		protected void #MAc<#Fu>(#55d #JAc, #Fu #f, [CallerMemberName] string #6cc = null)
		{
			if (!false)
			{
				this.#MAc<#Fu>(#6cc, #f, #JAc);
			}
		}

		// Token: 0x0600155C RID: 5468 RVA: 0x000B2998 File Offset: 0x000B0B98
		[SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "2")]
		protected void #LAc(string #6cc, string #f, #55d #wx)
		{
			try
			{
				if (!false)
				{
					#wx.#zl(#6cc, #f);
				}
			}
			catch (#w5d #Uic)
			{
				#w5d exception = new #w5d(string.Format(CultureInfo.CurrentCulture, Strings.StringCannotSetTheValueForSettingY.#z2d(), new object[]
				{
					#6cc
				}), #Phc.#3hc(107419049), Component.GUIFramework, #IYd.#b, #Uic);
				do
				{
					this.Logger.Log(LoggingLevel.Error, exception);
				}
				while (3 == 0);
			}
		}

		// Token: 0x0600155D RID: 5469 RVA: 0x000B2A10 File Offset: 0x000B0C10
		protected void #MAc<#Fu>(string #6cc, #Fu #f, #55d #wx)
		{
			try
			{
				List<Type> list = new List<Type>();
				Type typeFromHandle = typeof(!!0);
				if (4 != 0)
				{
					list.Add(typeFromHandle);
				}
				string text = new XCData(#F0d.#y0d<#Fu>(#f, list)).ToString();
				string text2;
				if (!false)
				{
					text2 = text;
				}
				string #f2 = text2;
				if (!false)
				{
					this.#LAc(#6cc, #f2, #wx);
				}
			}
			catch (Exception exception)
			{
				this.Logger.Log(LoggingLevel.Error, exception);
			}
		}

		// Token: 0x0600155E RID: 5470 RVA: 0x000B2A84 File Offset: 0x000B0C84
		[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
		protected void #NAc(string #6cc, bool #f, #55d #JAc)
		{
			try
			{
				string text2;
				if (!false && -1 != 0)
				{
					string text = #f.ToString(CultureInfo.InvariantCulture);
					if (!false)
					{
						text2 = text;
					}
				}
				string #f2 = text2;
				if (7 != 0)
				{
					this.#LAc(#6cc, #f2, #JAc);
				}
			}
			catch (Exception #Uic)
			{
				#w5d exception = new #w5d(string.Format(CultureInfo.CurrentCulture, Strings.StringCannotSetTheValueForSettingY.#z2d(), new object[]
				{
					#6cc
				}), #Phc.#3hc(107419028), Component.GUIFramework, #IYd.#b, #Uic);
				this.Logger.Log(LoggingLevel.Error, exception);
			}
		}

		// Token: 0x0600155F RID: 5471 RVA: 0x000169ED File Offset: 0x00014BED
		protected void #NAc(#55d #JAc, bool #f, [CallerMemberName] string #6cc = null)
		{
			if (!false)
			{
				this.#NAc(#6cc, #f, #JAc);
			}
		}

		// Token: 0x06001560 RID: 5472 RVA: 0x000B2B14 File Offset: 0x000B0D14
		protected bool #OAc(#55d #JAc, bool #7cc, [CallerMemberName] string #6cc = null)
		{
			bool result;
			this.#OAc(#6cc, #7cc, #JAc, out result);
			return result;
		}

		// Token: 0x06001561 RID: 5473 RVA: 0x000B2B30 File Offset: 0x000B0D30
		[SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "3#")]
		[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
		protected bool #OAc(string #6cc, bool #7cc, #55d #JAc, out bool #PAc)
		{
			bool result;
			try
			{
				if (!true)
				{
					goto IL_1F;
				}
				string text = #7cc.ToString(CultureInfo.InvariantCulture);
				string #7cc2;
				if (!false)
				{
					#7cc2 = text;
				}
				IL_13:
				string value;
				this.#IAc(#6cc, #7cc2, #JAc, out value);
				IL_1E:
				IL_1F:
				if (false)
				{
					goto IL_13;
				}
				if (bool.TryParse(value, out #PAc))
				{
					int num = 1;
					if (num == 0 || num == 0)
					{
						goto IL_1E;
					}
					if (!false)
					{
						result = (num != 0);
					}
				}
				else
				{
					#PAc = #7cc;
					bool flag = false;
					if (4 != 0)
					{
						result = flag;
					}
				}
			}
			catch (Exception #Uic)
			{
				#w5d exception = new #w5d(string.Format(CultureInfo.CurrentCulture, Strings.StringCannotReadTheSettingX, new object[]
				{
					#6cc
				}).#z2d(true) + Strings.StringUsedTheDefaultValue.#z2d(), #Phc.#3hc(107418975), Component.GUIFramework, #IYd.#b, #Uic);
				this.Logger.Log(LoggingLevel.Error, exception);
				#PAc = #7cc;
				result = false;
			}
			return result;
		}

		// Token: 0x06001562 RID: 5474 RVA: 0x000B2BF8 File Offset: 0x000B0DF8
		[SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "3#")]
		[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
		protected bool #QAc(string #6cc, Color #7cc, #55d #JAc, out Color #BR)
		{
			bool result;
			try
			{
				bool flag2;
				object obj2;
				if (!false)
				{
					string text = this.ColorConverter.ConvertToString(#7cc);
					string #7cc2;
					if (7 != 0)
					{
						#7cc2 = text;
					}
					string value;
					do
					{
						bool flag = this.#IAc(#6cc, #7cc2, #JAc, out value);
						if (2 != 0)
						{
							flag2 = flag;
						}
					}
					while (5 == 0);
					object obj = ColorConverter.ConvertFromString(value);
					if (!false)
					{
						obj2 = obj;
					}
				}
				if (obj2 != null)
				{
					#BR = (Color)obj2;
				}
				else
				{
					#BR = #7cc;
					bool flag3 = false;
					if (7 != 0)
					{
						flag2 = flag3;
					}
				}
				bool flag4 = flag2;
				if (!false)
				{
					result = flag4;
				}
			}
			catch (Exception #Uic)
			{
				#w5d exception = new #w5d(string.Format(CultureInfo.CurrentCulture, Strings.StringCannotReadTheSettingX, new object[]
				{
					#6cc
				}).#z2d(true) + Strings.StringUsedTheDefaultValue.#z2d(), #Phc.#3hc(107418890), Component.GUIFramework, #IYd.#b, #Uic);
				this.Logger.Log(LoggingLevel.Error, exception);
				#BR = #7cc;
				result = false;
			}
			return result;
		}

		// Token: 0x06001563 RID: 5475 RVA: 0x000B2CE4 File Offset: 0x000B0EE4
		protected Color #QAc(#55d #JAc, Color #7cc, [CallerMemberName] string #6cc = null)
		{
			Color result;
			this.#QAc(#6cc, #7cc, #JAc, out result);
			return result;
		}

		// Token: 0x06001564 RID: 5476 RVA: 0x00016A01 File Offset: 0x00014C01
		protected void #RAc(#55d #JAc, Color #f, [CallerMemberName] string #6cc = null)
		{
			if (!false)
			{
				this.#RAc(#6cc, #f, #JAc);
			}
		}

		// Token: 0x06001565 RID: 5477 RVA: 0x000B2D00 File Offset: 0x000B0F00
		[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
		protected void #RAc(string #6cc, Color #f, #55d #JAc)
		{
			try
			{
				string text = this.ColorConverter.ConvertToString(#f);
				string text2;
				if (!false)
				{
					text2 = text;
				}
				string #f2 = text2;
				if (-1 != 0)
				{
					this.#LAc(#6cc, #f2, #JAc);
				}
			}
			catch (Exception #Uic)
			{
				#w5d exception = new #w5d(string.Format(CultureInfo.CurrentCulture, Strings.StringCannotSetTheValueForSettingY.#z2d(), new object[]
				{
					#6cc
				}), #Phc.#3hc(107418357), Component.GUIFramework, #IYd.#b, #Uic);
				this.Logger.Log(LoggingLevel.Error, exception);
			}
		}

		// Token: 0x06001566 RID: 5478 RVA: 0x000B2D8C File Offset: 0x000B0F8C
		[SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "3#")]
		[SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "2")]
		[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
		protected bool #SAc(string #6cc, double #7cc, #55d #JAc, out double #f)
		{
			bool result;
			try
			{
				if (!false && 4 != 0)
				{
					string s;
					bool flag = #JAc.#5cc(#6cc, #7cc.ToString(CultureInfo.InvariantCulture), out s);
					#f = double.Parse(s, CultureInfo.InvariantCulture);
					if (7 != 0)
					{
						result = flag;
					}
				}
			}
			catch (Exception #Uic)
			{
				#w5d exception = new #w5d(string.Format(CultureInfo.CurrentCulture, Strings.StringSetting0HasAnInvalidValue.#z2d(), new object[]
				{
					#6cc
				}), #Phc.#3hc(107418272), Component.GUIFramework, #IYd.#b, #Uic);
				this.Logger.Log(LoggingLevel.Error, exception);
				#f = #7cc;
				result = false;
			}
			return result;
		}

		// Token: 0x06001567 RID: 5479 RVA: 0x000B2E28 File Offset: 0x000B1028
		protected double #SAc(#55d #JAc, double #7cc, [CallerMemberName] string #6cc = null)
		{
			double result;
			this.#SAc(#6cc, #7cc, #JAc, out result);
			return result;
		}

		// Token: 0x06001568 RID: 5480 RVA: 0x00016A15 File Offset: 0x00014C15
		protected void #TAc(#55d #JAc, double #f, [CallerMemberName] string #6cc = null)
		{
			if (!false)
			{
				this.#TAc(#6cc, #f, #JAc);
			}
		}

		// Token: 0x06001569 RID: 5481 RVA: 0x000B2E44 File Offset: 0x000B1044
		[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
		protected void #TAc(string #6cc, double #f, #55d #JAc)
		{
			try
			{
				string text2;
				if (!false && -1 != 0)
				{
					string text = #f.ToString(CultureInfo.InvariantCulture);
					if (!false)
					{
						text2 = text;
					}
				}
				string #f2 = text2;
				if (7 != 0)
				{
					this.#LAc(#6cc, #f2, #JAc);
				}
			}
			catch (Exception #Uic)
			{
				#w5d exception = new #w5d(string.Format(CultureInfo.CurrentCulture, Strings.StringCannotSetTheValueForSettingY.#z2d(), new object[]
				{
					#6cc
				}), #Phc.#3hc(107418219), Component.GUIFramework, #IYd.#b, #Uic);
				this.Logger.Log(LoggingLevel.Error, exception);
			}
		}

		// Token: 0x0600156A RID: 5482 RVA: 0x000B2ED4 File Offset: 0x000B10D4
		[SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "3#")]
		[SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "2")]
		[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
		protected bool #Gic(string #6cc, int #7cc, #55d #JAc, out int #f)
		{
			bool result;
			try
			{
				if (!false && 4 != 0)
				{
					string s;
					bool flag = #JAc.#5cc(#6cc, #7cc.ToString(CultureInfo.InvariantCulture), out s);
					#f = int.Parse(s, CultureInfo.InvariantCulture);
					if (7 != 0)
					{
						result = flag;
					}
				}
			}
			catch (Exception #Uic)
			{
				#w5d exception = new #w5d(string.Format(CultureInfo.CurrentCulture, Strings.StringSetting0HasAnInvalidValue.#z2d(), new object[]
				{
					#6cc
				}), #Phc.#3hc(107418198), Component.GUIFramework, #IYd.#b, #Uic);
				this.Logger.Log(LoggingLevel.Error, exception);
				#f = #7cc;
				result = false;
			}
			return result;
		}

		// Token: 0x0600156B RID: 5483 RVA: 0x000B2F70 File Offset: 0x000B1170
		protected int #Gic(#55d #JAc, int #7cc, [CallerMemberName] string #6cc = null)
		{
			int result;
			this.#Gic(#6cc, #7cc, #JAc, out result);
			return result;
		}

		// Token: 0x0600156C RID: 5484 RVA: 0x00016A29 File Offset: 0x00014C29
		protected void #UAc(#55d #JAc, int #f, [CallerMemberName] string #6cc = null)
		{
			if (!false)
			{
				this.#UAc(#6cc, #f, #JAc);
			}
		}

		// Token: 0x0600156D RID: 5485 RVA: 0x000B2F8C File Offset: 0x000B118C
		[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
		protected void #UAc(string #6cc, int #f, #55d #JAc)
		{
			try
			{
				string text2;
				if (!false && -1 != 0)
				{
					string text = #f.ToString(CultureInfo.InvariantCulture);
					if (!false)
					{
						text2 = text;
					}
				}
				string #f2 = text2;
				if (7 != 0)
				{
					this.#LAc(#6cc, #f2, #JAc);
				}
			}
			catch (Exception #Uic)
			{
				#w5d exception = new #w5d(string.Format(CultureInfo.CurrentCulture, Strings.StringCannotSetTheValueForSettingY.#z2d(), new object[]
				{
					#6cc
				}), #Phc.#3hc(107418113), Component.GUIFramework, #IYd.#b, #Uic);
				this.Logger.Log(LoggingLevel.Error, exception);
			}
		}

		// Token: 0x0600156E RID: 5486 RVA: 0x000B301C File Offset: 0x000B121C
		[SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "3#")]
		[SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "2")]
		[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
		protected bool #VAc<#Fu>(string #6cc, #Fu #7cc, #55d #JAc, out #Fu #f)
		{
			bool result;
			try
			{
				string value;
				bool flag = #JAc.#5cc(#6cc, #7cc.ToString(), out value);
				#f = (!!0)((object)Enum.Parse(typeof(!!0), value));
				if (5 != 0)
				{
					result = flag;
				}
			}
			catch (Exception #Uic)
			{
				#w5d exception = new #w5d(string.Format(CultureInfo.CurrentCulture, Strings.StringSetting0HasAnInvalidValue.#z2d(), new object[]
				{
					#6cc
				}), #Phc.#3hc(107418572), Component.GUIFramework, #IYd.#b, #Uic);
				this.Logger.Log(LoggingLevel.Error, exception);
				#f = #7cc;
				result = false;
			}
			return result;
		}

		// Token: 0x0600156F RID: 5487 RVA: 0x000B30C4 File Offset: 0x000B12C4
		protected #Fu #VAc<#Fu>(#55d #JAc, #Fu #7cc, [CallerMemberName] string #6cc = null)
		{
			#Fu result;
			this.#VAc<#Fu>(#6cc, #7cc, #JAc, out result);
			return result;
		}

		// Token: 0x06001570 RID: 5488 RVA: 0x00016A3D File Offset: 0x00014C3D
		protected void #WAc<#Fu>(#55d #JAc, #Fu #f, [CallerMemberName] string #6cc = null)
		{
			if (!false)
			{
				this.#WAc<#Fu>(#6cc, #f, #JAc);
			}
		}

		// Token: 0x06001571 RID: 5489 RVA: 0x000B30E0 File Offset: 0x000B12E0
		[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
		protected void #WAc<#Fu>(string #6cc, #Fu #f, #55d #JAc)
		{
			try
			{
				string text2;
				if (!false && -1 != 0)
				{
					string text = #f.ToString();
					if (!false)
					{
						text2 = text;
					}
				}
				string #f2 = text2;
				if (7 != 0)
				{
					this.#LAc(#6cc, #f2, #JAc);
				}
			}
			catch (Exception #Uic)
			{
				#w5d exception = new #w5d(string.Format(CultureInfo.CurrentCulture, Strings.StringCannotSetTheValueForSettingY.#z2d(), new object[]
				{
					#6cc
				}), #Phc.#3hc(107418551), Component.GUIFramework, #IYd.#b, #Uic);
				this.Logger.Log(LoggingLevel.Error, exception);
			}
		}

		// Token: 0x06001572 RID: 5490 RVA: 0x00016A51 File Offset: 0x00014C51
		protected void #XAc<#Fu>(#Fu #f, [CallerMemberName] string #6cc = null)
		{
			if (8 != 0)
			{
				base.RaisePropertyChanging(#6cc);
			}
			#55d #JAc = this.UserSettingProvider;
			if (!false)
			{
				this.#WAc<#Fu>(#JAc, #f, #6cc);
			}
			if (!false)
			{
				base.RaisePropertyChanged(#6cc);
			}
		}

		// Token: 0x06001573 RID: 5491 RVA: 0x00016A86 File Offset: 0x00014C86
		protected #ZAc #YAc<#ZAc>(#ZAc #7cc, [CallerMemberName] string #6cc = null)
		{
			return this.#VAc<#ZAc>(this.UserSettingProvider, #7cc, #6cc);
		}

		// Token: 0x06001574 RID: 5492 RVA: 0x00016A96 File Offset: 0x00014C96
		protected void #0Ac(bool #f, [CallerMemberName] string #6cc = null)
		{
			if (8 != 0)
			{
				base.RaisePropertyChanging(#6cc);
			}
			#55d #JAc = this.UserSettingProvider;
			if (!false)
			{
				this.#NAc(#JAc, #f, #6cc);
			}
			if (!false)
			{
				base.RaisePropertyChanged(#6cc);
			}
		}

		// Token: 0x06001575 RID: 5493 RVA: 0x00016ACB File Offset: 0x00014CCB
		protected bool #1Ac(bool #7cc, [CallerMemberName] string #6cc = null)
		{
			return this.#OAc(this.UserSettingProvider, #7cc, #6cc);
		}

		// Token: 0x06001576 RID: 5494 RVA: 0x00016ADB File Offset: 0x00014CDB
		protected int #2Ac(int #7cc, [CallerMemberName] string #6cc = null)
		{
			return this.#Gic(this.UserSettingProvider, #7cc, #6cc);
		}

		// Token: 0x06001577 RID: 5495 RVA: 0x00016AEB File Offset: 0x00014CEB
		protected void #3Ac(int #f, [CallerMemberName] string #6cc = null)
		{
			#55d #JAc = this.UserSettingProvider;
			if (7 != 0)
			{
				this.#UAc(#JAc, #f, #6cc);
			}
		}

		// Token: 0x06001578 RID: 5496 RVA: 0x00016B04 File Offset: 0x00014D04
		protected double #4Ac(double #7cc, [CallerMemberName] string #6cc = null)
		{
			return this.#SAc(this.UserSettingProvider, #7cc, #6cc);
		}

		// Token: 0x06001579 RID: 5497 RVA: 0x00016B14 File Offset: 0x00014D14
		protected void #5Ac(double #f, [CallerMemberName] string #6cc = null)
		{
			#55d #JAc = this.UserSettingProvider;
			if (7 != 0)
			{
				this.#TAc(#JAc, #f, #6cc);
			}
		}

		// Token: 0x0600157A RID: 5498 RVA: 0x00016B2D File Offset: 0x00014D2D
		protected void #6Ac(string #f, [CallerMemberName] string #6cc = null)
		{
			if (8 != 0)
			{
				base.RaisePropertyChanging(#6cc);
			}
			#55d #JAc = this.UserSettingProvider;
			if (!false)
			{
				this.#LAc(#JAc, #f, #6cc);
			}
			if (!false)
			{
				base.RaisePropertyChanged(#6cc);
			}
		}

		// Token: 0x0600157B RID: 5499 RVA: 0x00016B62 File Offset: 0x00014D62
		protected void #7Ac<#Fu>(#Fu #f, [CallerMemberName] string #6cc = null)
		{
			if (8 != 0)
			{
				base.RaisePropertyChanging(#6cc);
			}
			#55d #JAc = this.UserSettingProvider;
			if (!false)
			{
				this.#MAc<#Fu>(#JAc, #f, #6cc);
			}
			if (!false)
			{
				base.RaisePropertyChanged(#6cc);
			}
		}

		// Token: 0x0600157C RID: 5500 RVA: 0x00016B97 File Offset: 0x00014D97
		protected #Fu #8Ac<#Fu>(#Fu #7cc, [CallerMemberName] string #6cc = null)
		{
			return this.#KAc<#Fu>(this.UserSettingProvider, #7cc, #6cc);
		}

		// Token: 0x0600157D RID: 5501 RVA: 0x00016BA7 File Offset: 0x00014DA7
		protected string #9Ac(string #7cc, [CallerMemberName] string #6cc = null)
		{
			return this.#IAc(this.UserSettingProvider, #7cc, #6cc);
		}

		// Token: 0x0600157E RID: 5502 RVA: 0x00016BB7 File Offset: 0x00014DB7
		protected Color #aBc(Color #7cc, [CallerMemberName] string #6cc = null)
		{
			return this.#QAc(this.UserSettingProvider, #7cc, #6cc);
		}

		// Token: 0x0600157F RID: 5503 RVA: 0x00016BC7 File Offset: 0x00014DC7
		protected void #bBc(Color #f, [CallerMemberName] string #6cc = null)
		{
			#55d #JAc = this.UserSettingProvider;
			if (7 != 0)
			{
				this.#RAc(#JAc, #f, #6cc);
			}
		}

		// Token: 0x06001580 RID: 5504 RVA: 0x000B3170 File Offset: 0x000B1370
		protected void #cBc<#Zoc>(List<#Zoc> #f, [CallerMemberName] string #6cc = null)
		{
			if (4 != 0)
			{
				base.RaisePropertyChanging(#6cc);
			}
			try
			{
				string #f2 = #F0d.#y0d<List<#Zoc>>(#f, new List<Type>());
				#55d #wx = this.UserSettingProvider;
				if (2 != 0)
				{
					this.#LAc(#6cc, #f2, #wx);
				}
			}
			catch (Exception exception)
			{
				if (!false)
				{
					this.Logger.Log(LoggingLevel.Error, exception);
				}
			}
			do
			{
				if (7 != 0)
				{
					base.RaisePropertyChanged(#6cc);
				}
			}
			while (2 == 0);
		}

		// Token: 0x06001581 RID: 5505 RVA: 0x000B31E4 File Offset: 0x000B13E4
		protected List<#Zoc> #dBc<#Zoc>(List<#Zoc> #7cc, [CallerMemberName] string #6cc = null)
		{
			List<#Zoc> result;
			try
			{
				string text;
				for (;;)
				{
					IL_00:
					this.#IAc(#6cc, string.Empty, this.UserSettingProvider, out text);
					while (string.IsNullOrWhiteSpace(text))
					{
						if (false)
						{
							goto IL_00;
						}
						if (!false)
						{
							goto Block_3;
						}
					}
					break;
				}
				List<#Zoc> list;
				if ((list = #F0d.#C0d<List<#Zoc>>(text, new List<Type>())) != null)
				{
					goto IL_3A;
				}
				IL_2C:
				list = #7cc;
				goto IL_3A;
				Block_3:
				list = new List<!!0>();
				IL_3A:
				if (!false)
				{
					result = list;
				}
				if (false)
				{
					goto IL_2C;
				}
			}
			catch (Exception exception)
			{
				this.Logger.Log(LoggingLevel.Error, exception);
				result = #7cc;
			}
			return result;
		}

		// Token: 0x040008A3 RID: 2211
		[CompilerGenerated]
		private ILogger #a;

		// Token: 0x040008A4 RID: 2212
		[CompilerGenerated]
		private ColorConverter #b;

		// Token: 0x040008A5 RID: 2213
		[CompilerGenerated]
		private #55d #c;

		// Token: 0x040008A6 RID: 2214
		[CompilerGenerated]
		private #55d #d;
	}
}
