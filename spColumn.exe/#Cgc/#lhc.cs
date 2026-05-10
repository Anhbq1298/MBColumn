using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Media;
using #7hc;
using #Yfc;
using StructurePoint.CoreAssets.Licensing.UI;
using StructurePoint.CoreAssets.Licensing.UI.Views;
using Telerik.Windows.Controls;

namespace #Cgc
{
	// Token: 0x0200072E RID: 1838
	internal sealed class #lhc : INotifyPropertyChanged
	{
		// Token: 0x06003C63 RID: 15459 RVA: 0x00119754 File Offset: 0x00117954
		public #lhc(#dgc #AQ, #Ggc #u0b)
		{
			if (#AQ == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107378398));
			}
			this.#a = #AQ;
			if (#u0b == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107378032));
			}
			this.#b = #u0b;
			double height = this.#a.ProductData.Image.Height;
			this.#m = (!#AQ.ProductData.IsTrialExhausted && #AQ.ProductData.TrialTotalDays > 0);
			this.Messages.#Agc(#AQ);
			this.#j = new DelegateCommand(new Action<object>(this.#ghc), new Predicate<object>(this.#hhc));
			this.#k = new DelegateCommand(new Action<object>(this.#ehc));
			this.#l = new DelegateCommand(new Action<object>(this.#fhc));
			this.#n = new DelegateCommand(new Action<object>(this.#4gc), new Predicate<object>(this.#5gc));
			this.#o = new DelegateCommand(new Action<object>(this.#6gc));
			this.#q = new DelegateCommand(new Action<object>(this.#dhc));
			this.#p = new DelegateCommand(new Action<object>(this.#9gc), new Predicate<object>(this.#chc));
			this.#r = new DelegateCommand(new Action<object>(this.#ihc));
			this.#s = new DelegateCommand(new Action<object>(this.#3gc));
			this.#b.Closing += this.#2gc;
		}

		// Token: 0x140000DB RID: 219
		// (add) Token: 0x06003C64 RID: 15460 RVA: 0x001198F8 File Offset: 0x00117AF8
		// (remove) Token: 0x06003C65 RID: 15461 RVA: 0x00119960 File Offset: 0x00117B60
		public event PropertyChangedEventHandler PropertyChanged
		{
			[CompilerGenerated]
			add
			{
				PropertyChangedEventHandler propertyChangedEventHandler = this.#h;
				for (;;)
				{
					PropertyChangedEventHandler propertyChangedEventHandler2 = propertyChangedEventHandler;
					for (;;)
					{
						PropertyChangedEventHandler propertyChangedEventHandler3 = (PropertyChangedEventHandler)\u008D.\u0097\u0002(propertyChangedEventHandler2, value);
						PropertyChangedEventHandler value2;
						if (4 != 0)
						{
							value2 = propertyChangedEventHandler3;
						}
						propertyChangedEventHandler = Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this.#h, value2, propertyChangedEventHandler2);
						if (propertyChangedEventHandler != propertyChangedEventHandler2)
						{
							break;
						}
						if (!false && !false)
						{
							return;
						}
					}
				}
			}
			[CompilerGenerated]
			remove
			{
				PropertyChangedEventHandler propertyChangedEventHandler = this.#h;
				for (;;)
				{
					PropertyChangedEventHandler propertyChangedEventHandler2 = propertyChangedEventHandler;
					for (;;)
					{
						PropertyChangedEventHandler propertyChangedEventHandler3 = (PropertyChangedEventHandler)\u008D.\u0098\u0002(propertyChangedEventHandler2, value);
						PropertyChangedEventHandler value2;
						if (4 != 0)
						{
							value2 = propertyChangedEventHandler3;
						}
						propertyChangedEventHandler = Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this.#h, value2, propertyChangedEventHandler2);
						if (propertyChangedEventHandler != propertyChangedEventHandler2)
						{
							break;
						}
						if (!false && !false)
						{
							return;
						}
					}
				}
			}
		}

		// Token: 0x1700124C RID: 4684
		// (get) Token: 0x06003C66 RID: 15462 RVA: 0x00034268 File Offset: 0x00032468
		public #Bgc Messages { get; }

		// Token: 0x1700124D RID: 4685
		// (get) Token: 0x06003C67 RID: 15463 RVA: 0x00034274 File Offset: 0x00032474
		public DelegateCommand StartOrContinueTrialCommand { get; }

		// Token: 0x1700124E RID: 4686
		// (get) Token: 0x06003C68 RID: 15464 RVA: 0x00034280 File Offset: 0x00032480
		public DelegateCommand RequestLicenseCommand { get; }

		// Token: 0x1700124F RID: 4687
		// (get) Token: 0x06003C69 RID: 15465 RVA: 0x0003428C File Offset: 0x0003248C
		public DelegateCommand ActivateLicenseCommand { get; }

		// Token: 0x17001250 RID: 4688
		// (get) Token: 0x06003C6A RID: 15466 RVA: 0x00034298 File Offset: 0x00032498
		public bool IsTrialAllowed { get; }

		// Token: 0x17001251 RID: 4689
		// (get) Token: 0x06003C6B RID: 15467 RVA: 0x000342A4 File Offset: 0x000324A4
		public ImageSource Image
		{
			get
			{
				return this.#a.ProductData.Image;
			}
		}

		// Token: 0x17001252 RID: 4690
		// (get) Token: 0x06003C6C RID: 15468 RVA: 0x000342C2 File Offset: 0x000324C2
		public string FullProductName
		{
			get
			{
				return this.#a.ProductData.FullName;
			}
		}

		// Token: 0x17001253 RID: 4691
		// (get) Token: 0x06003C6D RID: 15469 RVA: 0x000342E0 File Offset: 0x000324E0
		public string Copyright
		{
			get
			{
				return this.#a.ProductData.Copyright;
			}
		}

		// Token: 0x17001254 RID: 4692
		// (get) Token: 0x06003C6E RID: 15470 RVA: 0x000342FE File Offset: 0x000324FE
		// (set) Token: 0x06003C6F RID: 15471 RVA: 0x001199C8 File Offset: 0x00117BC8
		public WizardStep CurrentStep
		{
			get
			{
				return this.#c;
			}
			set
			{
				for (;;)
				{
					if (this.#c == value)
					{
						goto IL_22;
					}
					IL_0B:
					this.#c = value;
					if (false)
					{
						continue;
					}
					this.#1gc(#Phc.#3hc(107377991));
					IL_22:
					if (!false)
					{
						break;
					}
					goto IL_0B;
				}
			}
		}

		// Token: 0x17001255 RID: 4693
		// (get) Token: 0x06003C70 RID: 15472 RVA: 0x0003430A File Offset: 0x0003250A
		public DelegateCommand QuitCommand { get; }

		// Token: 0x17001256 RID: 4694
		// (get) Token: 0x06003C71 RID: 15473 RVA: 0x00034316 File Offset: 0x00032516
		public DelegateCommand GoToNextStepCommand { get; }

		// Token: 0x17001257 RID: 4695
		// (get) Token: 0x06003C72 RID: 15474 RVA: 0x00034322 File Offset: 0x00032522
		public DelegateCommand ActivateCommand { get; }

		// Token: 0x17001258 RID: 4696
		// (get) Token: 0x06003C73 RID: 15475 RVA: 0x0003432E File Offset: 0x0003252E
		public DelegateCommand GoToPreviousStepCommand { get; }

		// Token: 0x17001259 RID: 4697
		// (get) Token: 0x06003C74 RID: 15476 RVA: 0x0003433A File Offset: 0x0003253A
		public DelegateCommand OpenLicenseRequestFormCommand { get; }

		// Token: 0x1700125A RID: 4698
		// (get) Token: 0x06003C75 RID: 15477 RVA: 0x00034346 File Offset: 0x00032546
		// (set) Token: 0x06003C76 RID: 15478 RVA: 0x00119A18 File Offset: 0x00117C18
		public LicenseType SelectedLicenseType
		{
			get
			{
				return this.#e;
			}
			set
			{
				if (4 != 0 && this.#e != value)
				{
					do
					{
						this.#e = value;
						if (false)
						{
							return;
						}
						this.#vh();
					}
					while (3 == 0);
					this.#1gc(#Phc.#3hc(107378006));
				}
			}
		}

		// Token: 0x1700125B RID: 4699
		// (get) Token: 0x06003C77 RID: 15479 RVA: 0x00034352 File Offset: 0x00032552
		// (set) Token: 0x06003C78 RID: 15480 RVA: 0x00119A78 File Offset: 0x00117C78
		public string StandaloneLicenseCode
		{
			get
			{
				return this.#f;
			}
			set
			{
				for (;;)
				{
					if (-1 == 0)
					{
						goto IL_22;
					}
					if (\u0093.\u0015\u0003(this.#f, value))
					{
						this.#f = value;
						this.#vh();
						goto IL_22;
					}
					IL_30:
					if (!false)
					{
						if (false)
						{
							continue;
						}
						if (5 != 0)
						{
							break;
						}
					}
					IL_22:
					this.#1gc(#Phc.#3hc(107377977));
					goto IL_30;
				}
			}
		}

		// Token: 0x1700125C RID: 4700
		// (get) Token: 0x06003C79 RID: 15481 RVA: 0x0003435E File Offset: 0x0003255E
		// (set) Token: 0x06003C7A RID: 15482 RVA: 0x00119AE8 File Offset: 0x00117CE8
		public string NetworkLicenseCode
		{
			get
			{
				return this.#g;
			}
			set
			{
				for (;;)
				{
					if (-1 == 0)
					{
						goto IL_22;
					}
					if (\u0093.\u0015\u0003(this.#g, value))
					{
						this.#g = value;
						this.#vh();
						goto IL_22;
					}
					IL_30:
					if (!false)
					{
						if (false)
						{
							continue;
						}
						if (5 != 0)
						{
							break;
						}
					}
					IL_22:
					this.#1gc(#Phc.#3hc(107377948));
					goto IL_30;
				}
			}
		}

		// Token: 0x1700125D RID: 4701
		// (get) Token: 0x06003C7B RID: 15483 RVA: 0x0003436A File Offset: 0x0003256A
		public DelegateCommand OpenContactFormCommand { get; }

		// Token: 0x06003C7C RID: 15484 RVA: 0x00034376 File Offset: 0x00032576
		private void #1gc([CallerMemberName] string #em = null)
		{
			for (;;)
			{
				if (!false)
				{
					PropertyChangedEventHandler propertyChangedEventHandler = this.#h;
					if (propertyChangedEventHandler != null)
					{
						propertyChangedEventHandler(this, new PropertyChangedEventArgs(#em));
						goto IL_1D;
					}
				}
				if (false)
				{
					continue;
				}
				if (5 != 0)
				{
					break;
				}
				IL_1D:
				if (!false)
				{
					return;
				}
			}
		}

		// Token: 0x06003C7D RID: 15485 RVA: 0x00119B58 File Offset: 0x00117D58
		private void #2gc(object #Ge, CancelEventArgs #He)
		{
			bool flag;
			for (;;)
			{
				bool flag2;
				flag = (flag2 = this.#d);
				for (;;)
				{
					if (!false)
					{
						if (flag2)
						{
							return;
						}
						if (4 == 0)
						{
							break;
						}
						flag = (flag2 = (\u0094.\u0018\u0003((Window)this.#b, Strings.StringAreSureYouWantToExit, this.Messages.WindowTitle, MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes) == MessageBoxResult.Yes));
					}
					if (4 != 0)
					{
						goto Block_3;
					}
				}
			}
			Block_3:
			bool flag3 = flag;
			\u0095.~\u0019\u0003(#He, !flag3);
		}

		// Token: 0x06003C7E RID: 15486 RVA: 0x000343AF File Offset: 0x000325AF
		private void #3gc(object #Sb)
		{
			this.#jhc(this.#a.ProductData.ContactFormUrl);
		}

		// Token: 0x06003C7F RID: 15487 RVA: 0x00119BD8 File Offset: 0x00117DD8
		private void #4gc(object #Sb)
		{
			while (-1 != 0 && \u0094.\u0018\u0003((Window)this.#b, Strings.StringAreSureYouWantToExit, this.Messages.WindowTitle, MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes) == MessageBoxResult.Yes && !false && !false)
			{
				if (-1 != 0)
				{
					this.#d = true;
					this.#b.#Fgc();
					break;
				}
			}
		}

		// Token: 0x06003C80 RID: 15488 RVA: 0x00003375 File Offset: 0x00001575
		private bool #5gc(object #Sb)
		{
			return true;
		}

		// Token: 0x06003C81 RID: 15489 RVA: 0x000343DB File Offset: 0x000325DB
		private void #6gc(object #Sb)
		{
			if (4 != 0 && this.CurrentStep == WizardStep.LicenseTypeSelect)
			{
				this.CurrentStep = ((this.SelectedLicenseType == LicenseType.Network) ? WizardStep.NetworkActivation : WizardStep.StandaloneActivation);
			}
		}

		// Token: 0x06003C82 RID: 15490 RVA: 0x00119C54 File Offset: 0x00117E54
		private bool #gb(Func<string, #Xfc> #7gc, string #tb)
		{
			bool result;
			try
			{
				for (;;)
				{
					#Xfc #PE = #7gc(#tb);
					if (!false)
					{
						result = this.#8gc(#PE);
						if (6 != 0)
						{
							break;
						}
					}
				}
				goto IL_5E;
			}
			catch (Exception #ob)
			{
				do
				{
					this.#khc(Strings.StringAnErrorOccurredWhileActivatingTheSoftware + #Phc.#3hc(107356879), #ob);
				}
				while (false);
			}
			IL_59:
			if (!false)
			{
				return false;
			}
			IL_5E:
			if (-1 != 0)
			{
				return result;
			}
			goto IL_59;
		}

		// Token: 0x06003C83 RID: 15491 RVA: 0x00119CD8 File Offset: 0x00117ED8
		private bool #8gc(#Xfc #PE)
		{
			uint? num = #PE.ErrorCode;
			uint num2 = 0U;
			if (!(num.GetValueOrDefault() == num2 & num != null))
			{
				string text = \u0019.\u0002\u0002(Strings.StringFailedToActivateTheSoftware, #Phc.#3hc(107356879));
				if (!\u0003.\u0004(#PE.ErrorMessage))
				{
					text = \u0010.\u0092(text, \u008E.\u0099\u0002(), #PE.ErrorMessage);
				}
				num = #PE.ErrorCode;
				if (num != null)
				{
					\u008F u000F_u = \u008F.\u000F\u0003;
					string[] array = new string[5];
					array[0] = text;
					array[1] = \u008E.\u0099\u0002();
					array[2] = Strings.StringErrorCode;
					array[3] = #Phc.#3hc(107383615);
					int num3 = 4;
					num = #PE.ErrorCode;
					array[num3] = num.ToString();
					text = u000F_u(array);
				}
				\u0096.\u008F\u0003((Window)this.#b, text, this.#a.ProductData.ActivationHeader, MessageBoxButton.OK, MessageBoxImage.Hand);
				return false;
			}
			return true;
		}

		// Token: 0x06003C84 RID: 15492 RVA: 0x00119E34 File Offset: 0x00118034
		private void #9gc(object #Sb)
		{
			Func<string, #Xfc> #7gc = (this.SelectedLicenseType == LicenseType.Network) ? this.#a.ActivateNetworkLicenseCallback : this.#a.ActivateLocalLicenseCallback;
			string #tb = (this.SelectedLicenseType == LicenseType.Network) ? this.NetworkLicenseCode : this.StandaloneLicenseCode;
			if (this.#gb(#7gc, #tb))
			{
				this.#ahc(true);
			}
		}

		// Token: 0x06003C85 RID: 15493 RVA: 0x00119EB0 File Offset: 0x001180B0
		private void #ahc(bool #bhc)
		{
			for (;;)
			{
				if (!false)
				{
					this.#d = true;
				}
				for (;;)
				{
					this.#b.DialogResult = new bool?(#bhc);
					if (7 == 0)
					{
						break;
					}
					if (8 != 0)
					{
						#Ggc #Ggc = this.#b;
						if (!false)
						{
							#Ggc.#Fgc();
						}
						if (!false)
						{
							return;
						}
					}
				}
			}
		}

		// Token: 0x06003C86 RID: 15494 RVA: 0x00119F0C File Offset: 0x0011810C
		private bool #chc(object #Sb)
		{
			int num;
			while (!false)
			{
				if (this.CurrentStep != WizardStep.StandaloneActivation || \u0003.\u0004(this.StandaloneLicenseCode))
				{
					IL_17:
					if (this.CurrentStep != WizardStep.NetworkActivation)
					{
						break;
					}
				}
				else
				{
					if (!true)
					{
						continue;
					}
					if (!false)
					{
						return true;
					}
				}
				num = (\u0003.\u0004(this.NetworkLicenseCode) ? 1 : 0);
				IL_2C:
				return num == 0;
			}
			if (-1 == 0)
			{
				goto IL_17;
			}
			int num2 = num = 0;
			if (num2 == 0)
			{
				return num2 != 0;
			}
			goto IL_2C;
		}

		// Token: 0x06003C87 RID: 15495 RVA: 0x00119F88 File Offset: 0x00118188
		private void #dhc(object #Sb)
		{
			if (7 == 0)
			{
				goto IL_1A;
			}
			if (false)
			{
				return;
			}
			if (this.CurrentStep != WizardStep.LicenseRequest)
			{
				if (this.CurrentStep == WizardStep.LicenseTypeSelect)
				{
					goto IL_1A;
				}
				if (!false)
				{
					if (3 == 0)
					{
						goto IL_1A;
					}
					if (this.CurrentStep == WizardStep.NetworkActivation || this.CurrentStep == WizardStep.StandaloneActivation)
					{
						this.CurrentStep = WizardStep.LicenseTypeSelect;
					}
				}
				return;
			}
			IL_0D:
			this.CurrentStep = WizardStep.WelcomeScreen;
			return;
			IL_1A:
			if (6 == 0)
			{
				goto IL_0D;
			}
			this.CurrentStep = WizardStep.WelcomeScreen;
		}

		// Token: 0x06003C88 RID: 15496 RVA: 0x00034414 File Offset: 0x00032614
		private void #ehc(object #Sb)
		{
			this.CurrentStep = WizardStep.LicenseRequest;
		}

		// Token: 0x06003C89 RID: 15497 RVA: 0x00034425 File Offset: 0x00032625
		private void #fhc(object #Sb)
		{
			this.CurrentStep = WizardStep.LicenseTypeSelect;
		}

		// Token: 0x06003C8A RID: 15498 RVA: 0x0011A004 File Offset: 0x00118204
		private void #ghc(object #Sb)
		{
			try
			{
				if (this.#8gc(this.#a.ActivateTrialCallback()))
				{
					this.#ahc(true);
				}
			}
			catch (Exception #ob)
			{
				this.#khc(\u0019.\u0002\u0002(Strings.StringAnErrorOccurredWhileInitializingTrialLicense, #Phc.#3hc(107356879)), #ob);
			}
		}

		// Token: 0x06003C8B RID: 15499 RVA: 0x00034436 File Offset: 0x00032636
		private bool #hhc(object #Sb)
		{
			return this.IsTrialAllowed;
		}

		// Token: 0x06003C8C RID: 15500 RVA: 0x00034446 File Offset: 0x00032646
		private void #ihc(object #Sb)
		{
			this.#jhc(this.#a.ProductData.LicenseRequestUrl);
		}

		// Token: 0x06003C8D RID: 15501 RVA: 0x0011A084 File Offset: 0x00118284
		private void #jhc(string #Jl)
		{
			try
			{
				if (!\u0003.\u0004(#Jl))
				{
					\u0097.\u0090\u0003(#Jl);
				}
			}
			catch (Exception #ob)
			{
				if (true)
				{
					this.#khc(\u0019.\u0002\u0002(\u0015.\u009A(Strings.StringFailedToOpenURL0, #Jl), #Phc.#3hc(107356879)), #ob);
				}
			}
		}

		// Token: 0x06003C8E RID: 15502 RVA: 0x0011A100 File Offset: 0x00118300
		private void #khc(string #5, Exception #ob)
		{
			Action<string, Exception> action = this.#a.LogError;
			if (action == null)
			{
				if (6 == 0)
				{
					return;
				}
			}
			else
			{
				action(#5, #ob);
			}
			\u0096.\u008F\u0003((Window)this.#b, #5, this.#a.ProductData.ActivationHeader, MessageBoxButton.OK, MessageBoxImage.Hand);
		}

		// Token: 0x06003C8F RID: 15503 RVA: 0x0011A178 File Offset: 0x00118378
		private void #vh()
		{
			if (4 != 0)
			{
				\u0007.~\u000F(this.StartOrContinueTrialCommand);
				goto IL_17;
			}
			do
			{
				IL_5F:
				\u0007.~\u000F(this.GoToPreviousStepCommand);
			}
			while (false);
			\u0007.~\u000F(this.ActivateCommand);
			\u0007.~\u000F(this.OpenLicenseRequestFormCommand);
			if (!false)
			{
				\u0007.~\u000F(this.OpenContactFormCommand);
				return;
			}
			IL_17:
			\u0007.~\u000F(this.RequestLicenseCommand);
			\u0007.~\u000F(this.ActivateLicenseCommand);
			\u0007.~\u000F(this.QuitCommand);
			\u0007.~\u000F(this.GoToNextStepCommand);
			goto IL_5F;
		}

		// Token: 0x04001B53 RID: 6995
		private readonly #dgc #a;

		// Token: 0x04001B54 RID: 6996
		private readonly #Ggc #b;

		// Token: 0x04001B55 RID: 6997
		private WizardStep #c;

		// Token: 0x04001B56 RID: 6998
		private bool #d;

		// Token: 0x04001B57 RID: 6999
		private LicenseType #e;

		// Token: 0x04001B58 RID: 7000
		private string #f;

		// Token: 0x04001B59 RID: 7001
		private string #g;

		// Token: 0x04001B5A RID: 7002
		[CompilerGenerated]
		private PropertyChangedEventHandler #h;

		// Token: 0x04001B5B RID: 7003
		[CompilerGenerated]
		private readonly #Bgc #i = new #Bgc();

		// Token: 0x04001B5C RID: 7004
		[CompilerGenerated]
		private readonly DelegateCommand #j;

		// Token: 0x04001B5D RID: 7005
		[CompilerGenerated]
		private readonly DelegateCommand #k;

		// Token: 0x04001B5E RID: 7006
		[CompilerGenerated]
		private readonly DelegateCommand #l;

		// Token: 0x04001B5F RID: 7007
		[CompilerGenerated]
		private readonly bool #m;

		// Token: 0x04001B60 RID: 7008
		[CompilerGenerated]
		private readonly DelegateCommand #n;

		// Token: 0x04001B61 RID: 7009
		[CompilerGenerated]
		private readonly DelegateCommand #o;

		// Token: 0x04001B62 RID: 7010
		[CompilerGenerated]
		private readonly DelegateCommand #p;

		// Token: 0x04001B63 RID: 7011
		[CompilerGenerated]
		private readonly DelegateCommand #q;

		// Token: 0x04001B64 RID: 7012
		[CompilerGenerated]
		private readonly DelegateCommand #r;

		// Token: 0x04001B65 RID: 7013
		[CompilerGenerated]
		private readonly DelegateCommand #s;
	}
}
