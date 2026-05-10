using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using #ezc;
using #LQc;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using Vanara.PInvoke;

namespace StructurePoint.CoreAssets.GUI.Framework.Services
{
	// Token: 0x02000C4C RID: 3148
	public sealed class DialogService : #8Sc
	{
		// Token: 0x060065E3 RID: 26083 RVA: 0x0005208A File Offset: 0x0005028A
		public DialogService(#xAc applicationInfoProvider)
		{
			this.#a = applicationInfoProvider;
			if (DialogService.Instance == null)
			{
				DialogService.Instance = this;
			}
			this.Enabled = true;
		}

		// Token: 0x17001C66 RID: 7270
		// (get) Token: 0x060065E4 RID: 26084 RVA: 0x000520AD File Offset: 0x000502AD
		// (set) Token: 0x060065E5 RID: 26085 RVA: 0x000520B4 File Offset: 0x000502B4
		public static #8Sc Instance { get; set; }

		// Token: 0x17001C67 RID: 7271
		// (get) Token: 0x060065E6 RID: 26086 RVA: 0x000520BC File Offset: 0x000502BC
		// (set) Token: 0x060065E7 RID: 26087 RVA: 0x000520C4 File Offset: 0x000502C4
		public bool Enabled { get; set; }

		// Token: 0x17001C68 RID: 7272
		// (get) Token: 0x060065E8 RID: 26088 RVA: 0x000520CD File Offset: 0x000502CD
		public bool IsAnyMessageBoxOpen
		{
			get
			{
				return Interlocked.CompareExchange(ref this.#b, 0, 0) != 0;
			}
		}

		// Token: 0x17001C69 RID: 7273
		// (get) Token: 0x060065E9 RID: 26089 RVA: 0x000520DF File Offset: 0x000502DF
		public Window MainWindow
		{
			get
			{
				Application application = Application.Current;
				if (application == null)
				{
					return null;
				}
				return application.MainWindow;
			}
		}

		// Token: 0x17001C6A RID: 7274
		// (get) Token: 0x060065EA RID: 26090 RVA: 0x0018FAD8 File Offset: 0x0018DCD8
		public Window ActiveWindow
		{
			get
			{
				DialogService.#rWb #rWb = new DialogService.#rWb();
				DialogService.#rWb #rWb2;
				if (!false)
				{
					#rWb2 = #rWb;
				}
				DialogService.#rWb #rWb3 = #rWb2;
				HWND activeWindow = User32.GetActiveWindow();
				HWND hwnd;
				if (4 != 0)
				{
					hwnd = activeWindow;
				}
				#rWb3.#a = hwnd.DangerousGetHandle();
				Window window = null;
				Window window2;
				if (!false)
				{
					window2 = window;
				}
				if (#rWb2.#a != IntPtr.Zero)
				{
					Window window3 = Application.Current.Windows.OfType<Window>().FirstOrDefault(new Func<Window, bool>(#rWb2.#Had));
					if (7 != 0)
					{
						window2 = window3;
					}
				}
				return window2 ?? this.MainWindow;
			}
		}

		// Token: 0x060065EB RID: 26091 RVA: 0x000520F1 File Offset: 0x000502F1
		public IntPtr #PSc()
		{
			return Process.GetCurrentProcess().MainWindowHandle;
		}

		// Token: 0x060065EC RID: 26092 RVA: 0x0018FB58 File Offset: 0x0018DD58
		public void #QSc()
		{
			Window window;
			if ((window = Application.Current.Windows.OfType<Window>().FirstOrDefault(new Func<Window, bool>(DialogService.<>c.<>9.#Iad))) == null)
			{
				window = Application.Current.MainWindow;
			}
			Window window2;
			if (!false)
			{
				window2 = window;
			}
			if (window2.IsValid())
			{
				Window #u0b = window2;
				if (!false)
				{
					this.#RSc(#u0b);
				}
			}
		}

		// Token: 0x060065ED RID: 26093 RVA: 0x000520FD File Offset: 0x000502FD
		public void #RSc(Window #u0b)
		{
			if (#u0b == null)
			{
				return;
			}
			IntPtr #Hzc = new WindowInteropHelper(#u0b).EnsureHandle();
			WindowState windowState = #u0b.WindowState;
			if (!false)
			{
				#0zc.#Gzc(#Hzc, windowState);
			}
		}

		// Token: 0x060065EE RID: 26094 RVA: 0x0018FBC4 File Offset: 0x0018DDC4
		public MessageBoxResult #od(string #SSc, string #MQc, MessageBoxButton #TSc, MessageBoxImage #USc, MessageBoxResult #VSc, MessageBoxOptions #mA)
		{
			DialogService.#uZb #uZb = new DialogService.#uZb();
			DialogService.#uZb #uZb2;
			if (8 != 0)
			{
				#uZb2 = #uZb;
			}
			do
			{
				#uZb2.#a = #SSc;
			}
			while (7 == 0);
			#uZb2.#b = #MQc;
			#uZb2.#c = #TSc;
			#uZb2.#d = #USc;
			#uZb2.#e = #VSc;
			#uZb2.#f = #mA;
			if (6 == 0)
			{
				goto IL_57;
			}
			int num = this.Enabled ? 1 : 0;
			IL_42:
			if (num != 0)
			{
				return this.#hAc(new Func<MessageBoxResult>(#uZb2.#15b));
			}
			IL_57:
			int num2 = num = 0;
			if (num2 == 0)
			{
				return (MessageBoxResult)num2;
			}
			goto IL_42;
		}

		// Token: 0x060065EF RID: 26095 RVA: 0x0018FC30 File Offset: 0x0018DE30
		public MessageBoxResult #od(Window #WSc, string #SSc, string #MQc, MessageBoxButton #TSc, MessageBoxImage #USc, MessageBoxResult #VSc, MessageBoxOptions #mA)
		{
			DialogService.#wWb #wWb = new DialogService.#wWb();
			DialogService.#wWb #wWb2;
			if (!false)
			{
				#wWb2 = #wWb;
			}
			#wWb2.#a = #WSc;
			#wWb2.#b = #MQc;
			#wWb2.#c = #SSc;
			#wWb2.#d = #TSc;
			#wWb2.#e = #USc;
			#wWb2.#f = #VSc;
			#wWb2.#g = #mA;
			if (false || !this.Enabled)
			{
				return MessageBoxResult.None;
			}
			if (#wWb2.#a.IsValid())
			{
				return this.#hAc(new Func<MessageBoxResult>(#wWb2.#15b));
			}
			return this.#hAc(new Func<MessageBoxResult>(#wWb2.#yad));
		}

		// Token: 0x060065F0 RID: 26096 RVA: 0x0018FCC0 File Offset: 0x0018DEC0
		public MessageBoxResult #od(string #SSc, MessageBoxButton #TSc, MessageBoxImage #USc, MessageBoxResult #VSc, MessageBoxOptions #mA)
		{
			string #MQc;
			do
			{
				if (5 != 0)
				{
					string text = this.#6Sc(#USc);
					if (!false)
					{
						#MQc = text;
					}
				}
			}
			while (6 == 0 || false);
			return this.#od(#SSc, #MQc, #TSc, #USc, #VSc, #mA);
		}

		// Token: 0x060065F1 RID: 26097 RVA: 0x0018FCF4 File Offset: 0x0018DEF4
		public MessageBoxResult #od(Window #WSc, string #SSc, MessageBoxButton #TSc, MessageBoxImage #USc, MessageBoxResult #VSc, MessageBoxOptions #mA)
		{
			string text = this.#6Sc(#USc);
			string #MQc;
			if (!false)
			{
				#MQc = text;
			}
			if (#WSc.IsValid())
			{
				return this.#od(#WSc, #SSc, #MQc, #TSc, #USc, #VSc, #mA);
			}
			return this.#od(#SSc, #MQc, #TSc, #USc, #VSc, #mA);
		}

		// Token: 0x060065F2 RID: 26098 RVA: 0x0018FD38 File Offset: 0x0018DF38
		public MessageBoxResult #od(string #SSc, MessageBoxButton #TSc, MessageBoxImage #USc)
		{
			DialogService.#ETb #ETb2;
			if (7 != 0)
			{
				if (false)
				{
					goto IL_24;
				}
				DialogService.#ETb #ETb = new DialogService.#ETb();
				if (5 != 0)
				{
					#ETb2 = #ETb;
				}
				#ETb2.#a = #SSc;
				#ETb2.#b = #TSc;
			}
			#ETb2.#c = #USc;
			IL_24:
			if (this.Enabled)
			{
				#ETb2.#d = this.#6Sc(#ETb2.#c);
				return this.#hAc(new Func<MessageBoxResult>(#ETb2.#15b));
			}
			return MessageBoxResult.None;
		}

		// Token: 0x060065F3 RID: 26099 RVA: 0x0018FD9C File Offset: 0x0018DF9C
		public MessageBoxResult #od(Window #WSc, string #SSc, MessageBoxButton #TSc, MessageBoxImage #USc)
		{
			DialogService.#9Vb #9Vb2;
			do
			{
				DialogService.#9Vb #9Vb = new DialogService.#9Vb();
				if (!false)
				{
					#9Vb2 = #9Vb;
				}
				#9Vb2.#a = #WSc;
				if (false)
				{
					goto IL_69;
				}
				#9Vb2.#b = #SSc;
				#9Vb2.#c = #TSc;
			}
			while (false);
			#9Vb2.#d = #USc;
			if (!this.Enabled)
			{
				return MessageBoxResult.None;
			}
			if (false)
			{
				goto IL_56;
			}
			#9Vb2.#e = this.#6Sc(#9Vb2.#d);
			IL_49:
			if (!#9Vb2.#a.IsValid())
			{
				goto IL_69;
			}
			IL_56:
			return this.#hAc(new Func<MessageBoxResult>(#9Vb2.#15b));
			IL_69:
			if (5 != 0)
			{
				return this.#hAc(new Func<MessageBoxResult>(#9Vb2.#yad));
			}
			goto IL_49;
		}

		// Token: 0x060065F4 RID: 26100 RVA: 0x0018FE30 File Offset: 0x0018E030
		public MessageBoxResult #od(string #Hkb, string #XSc, MessageBoxButton #TSc, MessageBoxImage #USc)
		{
			DialogService.#ZXb #ZXb = new DialogService.#ZXb();
			DialogService.#ZXb #ZXb2;
			if (-1 != 0)
			{
				#ZXb2 = #ZXb;
			}
			#ZXb2.#a = #TSc;
			#ZXb2.#b = #USc;
			if (!this.Enabled)
			{
				return MessageBoxResult.None;
			}
			if (string.IsNullOrEmpty(#XSc))
			{
				return this.#od(#Hkb, #ZXb2.#a, #ZXb2.#b);
			}
			#ZXb2.#c = #Hkb.#Tm().#G2d(true) + #XSc;
			#ZXb2.#d = this.#6Sc(#ZXb2.#b);
			return this.#hAc(new Func<MessageBoxResult>(#ZXb2.#15b));
		}

		// Token: 0x060065F5 RID: 26101 RVA: 0x0018FEBC File Offset: 0x0018E0BC
		public void #qn(string #SSc)
		{
			if (!false)
			{
				DialogService.#NTb #NTb2;
				if (!false)
				{
					DialogService.#NTb #NTb = new DialogService.#NTb();
					if (!false)
					{
						#NTb2 = #NTb;
					}
				}
				#NTb2.#a = #SSc;
				if (this.Enabled)
				{
					do
					{
						#NTb2.#b = this.#6Sc(MessageBoxImage.Hand);
					}
					while (2 == 0);
					this.#hAc(new Func<MessageBoxResult>(#NTb2.#Jad));
				}
			}
		}

		// Token: 0x060065F6 RID: 26102 RVA: 0x0018FF10 File Offset: 0x0018E110
		public void #qn(Window #WSc, string #SSc)
		{
			DialogService.#KTb #KTb2;
			do
			{
				DialogService.#KTb #KTb = new DialogService.#KTb();
				if (true)
				{
					#KTb2 = #KTb;
				}
				if (false)
				{
					goto IL_53;
				}
				#KTb2.#a = #WSc;
				#KTb2.#b = #SSc;
				if (#KTb2.#a.IsValid() || 2 == 0)
				{
					goto IL_3A;
				}
			}
			while (false);
			string #SSc2 = #KTb2.#b;
			if (!false)
			{
				this.#qn(#SSc2);
			}
			return;
			IL_3A:
			if (!false && !this.Enabled)
			{
				return;
			}
			#KTb2.#c = this.#6Sc(MessageBoxImage.Hand);
			IL_53:
			this.#hAc(new Func<MessageBoxResult>(#KTb2.#Jad));
		}

		// Token: 0x060065F7 RID: 26103 RVA: 0x0018FF90 File Offset: 0x0018E190
		public MessageBoxResult #od(TimeSpan #YSc, Window #jA, string #SSc, string #MQc, MessageBoxButton #TSc, MessageBoxImage #USc, MessageBoxResult #VSc, MessageBoxOptions #mA)
		{
			if (4 == 0)
			{
				goto IL_1D;
			}
			DialogService.#yZb #yZb = new DialogService.#yZb();
			DialogService.#yZb #yZb2;
			if (!false)
			{
				#yZb2 = #yZb;
			}
			IL_0C:
			if (false)
			{
				goto IL_4A;
			}
			#yZb2.#a = #YSc;
			#yZb2.#b = #jA;
			IL_1D:
			#yZb2.#c = #SSc;
			do
			{
				#yZb2.#d = #MQc;
				if (false)
				{
					goto IL_0C;
				}
				#yZb2.#e = #TSc;
				#yZb2.#f = #USc;
			}
			while (false);
			#yZb2.#g = #VSc;
			IL_4A:
			#yZb2.#h = #mA;
			return this.#hAc(new Func<MessageBoxResult>(#yZb2.#15b));
		}

		// Token: 0x060065F8 RID: 26104 RVA: 0x00190004 File Offset: 0x0018E204
		public MessageBoxResult #od(TimeSpan #YSc, string #SSc, string #MQc, MessageBoxButton #TSc, MessageBoxImage #USc, MessageBoxResult #VSc, MessageBoxOptions #mA)
		{
			DialogService.#o6b #o6b = new DialogService.#o6b();
			DialogService.#o6b #o6b2;
			if (8 != 0)
			{
				#o6b2 = #o6b;
			}
			#o6b2.#a = #YSc;
			#o6b2.#b = #SSc;
			#o6b2.#c = #MQc;
			#o6b2.#d = #TSc;
			#o6b2.#e = #USc;
			#o6b2.#f = #VSc;
			#o6b2.#g = #mA;
			return this.#hAc(new Func<MessageBoxResult>(#o6b2.#15b));
		}

		// Token: 0x060065F9 RID: 26105 RVA: 0x00190064 File Offset: 0x0018E264
		public void #ZSc(string #SSc)
		{
			if (!false)
			{
				DialogService.#cWb #cWb2;
				if (!false)
				{
					DialogService.#cWb #cWb = new DialogService.#cWb();
					if (!false)
					{
						#cWb2 = #cWb;
					}
				}
				#cWb2.#a = #SSc;
				if (this.Enabled)
				{
					do
					{
						#cWb2.#b = this.#6Sc(MessageBoxImage.Exclamation);
					}
					while (2 == 0);
					this.#hAc(new Func<MessageBoxResult>(#cWb2.#Kad));
				}
			}
		}

		// Token: 0x060065FA RID: 26106 RVA: 0x001900B8 File Offset: 0x0018E2B8
		public void #ZSc(Window #WSc, string #SSc)
		{
			DialogService.#AZb #AZb2;
			if (!false)
			{
				DialogService.#AZb #AZb = new DialogService.#AZb();
				if (3 != 0)
				{
					#AZb2 = #AZb;
				}
			}
			for (;;)
			{
				#AZb2.#a = #WSc;
				#AZb2.#b = #SSc;
				if (!false)
				{
					if (!this.Enabled)
					{
						return;
					}
					#AZb2.#c = this.#6Sc(MessageBoxImage.Exclamation);
					if (7 == 0)
					{
						goto IL_5A;
					}
					if (3 != 0)
					{
						break;
					}
				}
			}
			if (#AZb2.#a.IsValid())
			{
				this.#hAc(new Func<MessageBoxResult>(#AZb2.#Kad));
				return;
			}
			IL_5A:
			this.#hAc(new Func<MessageBoxResult>(#AZb2.#Lad));
		}

		// Token: 0x060065FB RID: 26107 RVA: 0x00190138 File Offset: 0x0018E338
		public MessageBoxResult #0Sc(Window #jA, string #5)
		{
			DialogService.#jac #jac2;
			if (-1 != 0)
			{
				DialogService.#jac #jac = new DialogService.#jac();
				if (!false)
				{
					#jac2 = #jac;
				}
				#jac2.#a = #jA;
				#jac2.#c = #5;
				int num;
				int result;
				bool flag = (result = (num = (this.Enabled ? 1 : 0))) != 0;
				if (7 != 0)
				{
					int num2;
					if (!false)
					{
						if (!flag)
						{
							return MessageBoxResult.Cancel;
						}
						#jac2.#b = this.#6Sc(MessageBoxImage.Exclamation);
						Window window = #jac2.#a;
						if (window != null)
						{
							num2 = (window.IsValid() ? 1 : 0);
							goto IL_4D;
						}
						num = 0;
					}
					if ((result = (num2 = num)) != 0)
					{
						return (MessageBoxResult)result;
					}
					IL_4D:
					if (num2 != 0)
					{
						goto IL_4F;
					}
					return this.#hAc(new Func<MessageBoxResult>(#jac2.#Nad));
				}
				return (MessageBoxResult)result;
			}
			IL_4F:
			return this.#hAc(new Func<MessageBoxResult>(#jac2.#Mad));
		}

		// Token: 0x060065FC RID: 26108 RVA: 0x001901C0 File Offset: 0x0018E3C0
		public MessageBoxResult #1Sc(Window #jA, string #MQc, string #5, MessageBoxButton #NQc, MessageBoxImage #Kl)
		{
			DialogService.#aVb #aVb2;
			if (7 != 0)
			{
				if (false)
				{
					goto IL_24;
				}
				DialogService.#aVb #aVb = new DialogService.#aVb();
				if (5 != 0)
				{
					#aVb2 = #aVb;
				}
				#aVb2.#a = #jA;
				#aVb2.#b = #MQc;
			}
			#aVb2.#c = #5;
			IL_24:
			#aVb2.#d = #NQc;
			#aVb2.#e = #Kl;
			if (this.Enabled)
			{
				return this.#hAc(new Func<MessageBoxResult>(#aVb2.#Oad));
			}
			return MessageBoxResult.None;
		}

		// Token: 0x060065FD RID: 26109 RVA: 0x00190220 File Offset: 0x0018E420
		public MessageBoxResult #1Sc(Window #jA, string #MQc, string #5, MessageBoxButton #NQc, MessageBoxImage #Kl, MessageBoxResult #VSc)
		{
			DialogService.#CZb #CZb = new DialogService.#CZb();
			DialogService.#CZb #CZb2;
			if (8 != 0)
			{
				#CZb2 = #CZb;
			}
			do
			{
				#CZb2.#a = #jA;
			}
			while (7 == 0);
			#CZb2.#b = #MQc;
			#CZb2.#c = #5;
			#CZb2.#d = #NQc;
			#CZb2.#e = #Kl;
			#CZb2.#f = #VSc;
			if (6 == 0)
			{
				goto IL_57;
			}
			int num = this.Enabled ? 1 : 0;
			IL_42:
			if (num != 0)
			{
				return this.#hAc(new Func<MessageBoxResult>(#CZb2.#Oad));
			}
			IL_57:
			int num2 = num = 0;
			if (num2 == 0)
			{
				return (MessageBoxResult)num2;
			}
			goto IL_42;
		}

		// Token: 0x060065FE RID: 26110 RVA: 0x0019028C File Offset: 0x0018E48C
		public void #2Sc(Window #jA, string #MQc, string #5, MessageBoxButton #NQc, MessageBoxImage #Kl)
		{
			DialogService.#p6b #p6b = new DialogService.#p6b();
			DialogService.#p6b #p6b2;
			if (8 != 0)
			{
				#p6b2 = #p6b;
			}
			#p6b2.#a = this;
			#p6b2.#b = #jA;
			#p6b2.#c = #MQc;
			#p6b2.#d = #5;
			#p6b2.#e = #NQc;
			#p6b2.#f = #Kl;
			if (this.Enabled)
			{
				LayoutHelper.BeginInvokeOnApplicationThread(new Action(#p6b2.#Pad));
			}
		}

		// Token: 0x060065FF RID: 26111 RVA: 0x001902EC File Offset: 0x0018E4EC
		public void #2Sc(Func<Window> #jA, string #MQc, string #5, MessageBoxButton #NQc, MessageBoxImage #Kl)
		{
			DialogService.#fWb #fWb = new DialogService.#fWb();
			DialogService.#fWb #fWb2;
			if (8 != 0)
			{
				#fWb2 = #fWb;
			}
			#fWb2.#a = this;
			#fWb2.#b = #jA;
			#fWb2.#c = #MQc;
			#fWb2.#d = #5;
			#fWb2.#e = #NQc;
			#fWb2.#f = #Kl;
			if (this.Enabled)
			{
				LayoutHelper.BeginInvokeOnApplicationThread(new Action(#fWb2.#Pad));
			}
		}

		// Token: 0x06006600 RID: 26112 RVA: 0x0019034C File Offset: 0x0018E54C
		public void #pn(Window #jA, string #MQc, string #5)
		{
			DialogService.#EZb #EZb2;
			int num;
			if (4 != 0)
			{
				DialogService.#EZb #EZb = new DialogService.#EZb();
				if (!false)
				{
					#EZb2 = #EZb;
				}
				if (4 == 0)
				{
					goto IL_46;
				}
				#EZb2.#a = #jA;
				if (6 != 0)
				{
					#EZb2.#b = #MQc;
					#EZb2.#c = #5;
					bool flag = (num = (this.Enabled ? 1 : 0)) != 0;
					if (7 == 0)
					{
						goto IL_3D;
					}
					if (!flag)
					{
						return;
					}
				}
				Window window = #EZb2.#a;
				if (window != null)
				{
					num = (window.IsValid() ? 1 : 0);
					goto IL_44;
				}
			}
			num = 0;
			IL_3D:
			IL_44:
			if (num == 0)
			{
				this.#hAc(new Func<MessageBoxResult>(#EZb2.#Sad));
				return;
			}
			IL_46:
			this.#hAc(new Func<MessageBoxResult>(#EZb2.#Rad));
		}

		// Token: 0x06006601 RID: 26113 RVA: 0x001903CC File Offset: 0x0018E5CC
		public void #pn(Window #jA, string #hvb)
		{
			DialogService.#R7b #R7b2;
			if (!false)
			{
				DialogService.#R7b #R7b = new DialogService.#R7b();
				if (3 != 0)
				{
					#R7b2 = #R7b;
				}
			}
			for (;;)
			{
				#R7b2.#a = #jA;
				#R7b2.#b = #hvb;
				if (!false)
				{
					if (!this.Enabled)
					{
						return;
					}
					#R7b2.#c = this.#6Sc(MessageBoxImage.Asterisk);
					if (7 == 0)
					{
						goto IL_5A;
					}
					if (3 != 0)
					{
						break;
					}
				}
			}
			if (#R7b2.#a.IsValid())
			{
				this.#hAc(new Func<MessageBoxResult>(#R7b2.#Rad));
				return;
			}
			IL_5A:
			this.#hAc(new Func<MessageBoxResult>(#R7b2.#Sad));
		}

		// Token: 0x06006602 RID: 26114 RVA: 0x00052120 File Offset: 0x00050320
		public void #pn(string #SSc)
		{
			if (this.Enabled)
			{
				Window #jA = null;
				if (!false)
				{
					this.#pn(#jA, #SSc);
				}
			}
		}

		// Token: 0x06006603 RID: 26115 RVA: 0x0019044C File Offset: 0x0018E64C
		public MessageBoxResult #3Sc(string #SSc, MessageBoxButton #4Sc, MessageBoxResult #VSc)
		{
			if (7 == 0)
			{
				goto IL_1D;
			}
			if (false)
			{
				goto IL_24;
			}
			DialogService.#0Ub #0Ub = new DialogService.#0Ub();
			DialogService.#0Ub #0Ub2;
			if (!false)
			{
				#0Ub2 = #0Ub;
			}
			#0Ub2.#a = #SSc;
			IL_16:
			#0Ub2.#b = #4Sc;
			IL_1D:
			#0Ub2.#c = #VSc;
			IL_24:
			if (this.Enabled)
			{
				#0Ub2.#d = this.#6Sc(MessageBoxImage.Question);
				return this.#hAc(new Func<MessageBoxResult>(#0Ub2.#Tad));
			}
			if (-1 != 0)
			{
				return #0Ub2.#c;
			}
			goto IL_16;
		}

		// Token: 0x06006604 RID: 26116 RVA: 0x001904B4 File Offset: 0x0018E6B4
		public MessageBoxResult #3Sc(Window #WSc, string #SSc, MessageBoxButton #4Sc, MessageBoxResult #VSc)
		{
			DialogService.#Jcc #Jcc2;
			do
			{
				DialogService.#Jcc #Jcc = new DialogService.#Jcc();
				if (!false)
				{
					#Jcc2 = #Jcc;
				}
				#Jcc2.#a = #WSc;
				if (false)
				{
					goto IL_65;
				}
				#Jcc2.#b = #SSc;
				#Jcc2.#c = #4Sc;
			}
			while (false);
			#Jcc2.#d = #VSc;
			if (!this.Enabled)
			{
				return #Jcc2.#d;
			}
			IL_34:
			if (!false)
			{
				#Jcc2.#e = this.#6Sc(MessageBoxImage.Question);
				if (!#Jcc2.#a.IsValid())
				{
					goto IL_65;
				}
			}
			return this.#hAc(new Func<MessageBoxResult>(#Jcc2.#Tad));
			IL_65:
			if (-1 != 0)
			{
				return this.#hAc(new Func<MessageBoxResult>(#Jcc2.#Uad));
			}
			goto IL_34;
		}

		// Token: 0x06006605 RID: 26117 RVA: 0x0005213A File Offset: 0x0005033A
		public string #5Sc(string #YE, string #Ukc)
		{
			return #YE.#A2d().#Tm().#Tm() + #Ukc;
		}

		// Token: 0x06006606 RID: 26118 RVA: 0x00052152 File Offset: 0x00050352
		public bool #ABf()
		{
			return !Keyboard.IsKeyDown(Key.Escape);
		}

		// Token: 0x06006607 RID: 26119 RVA: 0x00190548 File Offset: 0x0018E748
		private string #6Sc(MessageBoxImage #USc)
		{
			while (this.#a == null)
			{
				if (#USc != MessageBoxImage.Hand)
				{
					if (-1 == 0)
					{
						continue;
					}
					if (#USc != MessageBoxImage.Question)
					{
						if (#USc == MessageBoxImage.Exclamation)
						{
							return Strings.StringWarning;
						}
					}
					else
					{
						if (!false)
						{
							return Strings.StringQuestion;
						}
						break;
					}
				}
				else if (4 != 0)
				{
					return Strings.StringError;
				}
				return Strings.StringInformation;
			}
			return this.#a.ApplicationName;
		}

		// Token: 0x06006608 RID: 26120 RVA: 0x0019059C File Offset: 0x0018E79C
		private MessageBoxResult #hAc(Func<MessageBoxResult> #7Sc)
		{
			MessageBoxResult result;
			try
			{
				Interlocked.Increment(ref this.#b);
				MessageBoxResult messageBoxResult = #7Sc();
				if (!false)
				{
					result = messageBoxResult;
				}
			}
			finally
			{
				if (!false)
				{
					Interlocked.Decrement(ref this.#b);
				}
			}
			return result;
		}

		// Token: 0x040029CC RID: 10700
		private readonly #xAc #a;

		// Token: 0x040029CD RID: 10701
		private int #b;

		// Token: 0x040029CE RID: 10702
		[CompilerGenerated]
		private static #8Sc #c;

		// Token: 0x040029CF RID: 10703
		[CompilerGenerated]
		private bool #d;

		// Token: 0x02000C4E RID: 3150
		[CompilerGenerated]
		private sealed class #rWb
		{
			// Token: 0x0600660D RID: 26125 RVA: 0x00052172 File Offset: 0x00050372
			internal bool #Had(Window #u0b)
			{
				return new WindowInteropHelper(#u0b).Handle == this.#a;
			}

			// Token: 0x040029D2 RID: 10706
			public IntPtr #a;
		}

		// Token: 0x02000C4F RID: 3151
		[CompilerGenerated]
		private sealed class #uZb
		{
			// Token: 0x0600660F RID: 26127 RVA: 0x0005218A File Offset: 0x0005038A
			internal MessageBoxResult #15b()
			{
				return MessageBox.Show(this.#a, this.#b, this.#c, this.#d, this.#e, this.#f);
			}

			// Token: 0x040029D3 RID: 10707
			public string #a;

			// Token: 0x040029D4 RID: 10708
			public string #b;

			// Token: 0x040029D5 RID: 10709
			public MessageBoxButton #c;

			// Token: 0x040029D6 RID: 10710
			public MessageBoxImage #d;

			// Token: 0x040029D7 RID: 10711
			public MessageBoxResult #e;

			// Token: 0x040029D8 RID: 10712
			public MessageBoxOptions #f;
		}

		// Token: 0x02000C50 RID: 3152
		[CompilerGenerated]
		private sealed class #wWb
		{
			// Token: 0x06006611 RID: 26129 RVA: 0x000521B5 File Offset: 0x000503B5
			internal MessageBoxResult #15b()
			{
				return MessageBoxExt.#od(this.#a, this.#b, this.#c, this.#d, this.#e, this.#f, this.#g);
			}

			// Token: 0x06006612 RID: 26130 RVA: 0x000521E6 File Offset: 0x000503E6
			internal MessageBoxResult #yad()
			{
				return MessageBox.Show(this.#c, this.#b, this.#d, this.#e, this.#f, this.#g);
			}

			// Token: 0x040029D9 RID: 10713
			public Window #a;

			// Token: 0x040029DA RID: 10714
			public string #b;

			// Token: 0x040029DB RID: 10715
			public string #c;

			// Token: 0x040029DC RID: 10716
			public MessageBoxButton #d;

			// Token: 0x040029DD RID: 10717
			public MessageBoxImage #e;

			// Token: 0x040029DE RID: 10718
			public MessageBoxResult #f;

			// Token: 0x040029DF RID: 10719
			public MessageBoxOptions #g;
		}

		// Token: 0x02000C51 RID: 3153
		[CompilerGenerated]
		private sealed class #ETb
		{
			// Token: 0x06006614 RID: 26132 RVA: 0x00052211 File Offset: 0x00050411
			internal MessageBoxResult #15b()
			{
				return MessageBox.Show(this.#a, this.#d, this.#b, this.#c);
			}

			// Token: 0x040029E0 RID: 10720
			public string #a;

			// Token: 0x040029E1 RID: 10721
			public MessageBoxButton #b;

			// Token: 0x040029E2 RID: 10722
			public MessageBoxImage #c;

			// Token: 0x040029E3 RID: 10723
			public string #d;
		}

		// Token: 0x02000C52 RID: 3154
		[CompilerGenerated]
		private sealed class #9Vb
		{
			// Token: 0x06006616 RID: 26134 RVA: 0x00052230 File Offset: 0x00050430
			internal MessageBoxResult #15b()
			{
				return MessageBoxExt.#od(this.#a, this.#e, this.#b, this.#c, this.#d);
			}

			// Token: 0x06006617 RID: 26135 RVA: 0x00052255 File Offset: 0x00050455
			internal MessageBoxResult #yad()
			{
				return MessageBox.Show(this.#b, this.#e, this.#c, this.#d);
			}

			// Token: 0x040029E4 RID: 10724
			public Window #a;

			// Token: 0x040029E5 RID: 10725
			public string #b;

			// Token: 0x040029E6 RID: 10726
			public MessageBoxButton #c;

			// Token: 0x040029E7 RID: 10727
			public MessageBoxImage #d;

			// Token: 0x040029E8 RID: 10728
			public string #e;
		}

		// Token: 0x02000C53 RID: 3155
		[CompilerGenerated]
		private sealed class #ZXb
		{
			// Token: 0x06006619 RID: 26137 RVA: 0x00052274 File Offset: 0x00050474
			internal MessageBoxResult #15b()
			{
				return MessageBox.Show(this.#c, this.#d, this.#a, this.#b);
			}

			// Token: 0x040029E9 RID: 10729
			public MessageBoxButton #a;

			// Token: 0x040029EA RID: 10730
			public MessageBoxImage #b;

			// Token: 0x040029EB RID: 10731
			public string #c;

			// Token: 0x040029EC RID: 10732
			public string #d;
		}

		// Token: 0x02000C54 RID: 3156
		[CompilerGenerated]
		private sealed class #NTb
		{
			// Token: 0x0600661B RID: 26139 RVA: 0x00052293 File Offset: 0x00050493
			internal MessageBoxResult #Jad()
			{
				return MessageBox.Show(this.#a, this.#b, MessageBoxButton.OK, MessageBoxImage.Hand, MessageBoxResult.OK, MessageBoxOptions.None);
			}

			// Token: 0x040029ED RID: 10733
			public string #a;

			// Token: 0x040029EE RID: 10734
			public string #b;
		}

		// Token: 0x02000C55 RID: 3157
		[CompilerGenerated]
		private sealed class #KTb
		{
			// Token: 0x0600661D RID: 26141 RVA: 0x000522AB File Offset: 0x000504AB
			internal MessageBoxResult #Jad()
			{
				return MessageBoxExt.#od(this.#a, this.#c, this.#b, MessageBoxButton.OK, MessageBoxImage.Hand, MessageBoxResult.OK, MessageBoxOptions.None);
			}

			// Token: 0x040029EF RID: 10735
			public Window #a;

			// Token: 0x040029F0 RID: 10736
			public string #b;

			// Token: 0x040029F1 RID: 10737
			public string #c;
		}

		// Token: 0x02000C56 RID: 3158
		[CompilerGenerated]
		private sealed class #yZb
		{
			// Token: 0x0600661F RID: 26143 RVA: 0x000522C9 File Offset: 0x000504C9
			internal MessageBoxResult #15b()
			{
				return AutoClosingMessageBox.Show(this.#a, this.#b, this.#c, this.#d, this.#e, this.#f, this.#g, this.#h);
			}

			// Token: 0x040029F2 RID: 10738
			public TimeSpan #a;

			// Token: 0x040029F3 RID: 10739
			public Window #b;

			// Token: 0x040029F4 RID: 10740
			public string #c;

			// Token: 0x040029F5 RID: 10741
			public string #d;

			// Token: 0x040029F6 RID: 10742
			public MessageBoxButton #e;

			// Token: 0x040029F7 RID: 10743
			public MessageBoxImage #f;

			// Token: 0x040029F8 RID: 10744
			public MessageBoxResult #g;

			// Token: 0x040029F9 RID: 10745
			public MessageBoxOptions #h;
		}

		// Token: 0x02000C57 RID: 3159
		[CompilerGenerated]
		private sealed class #o6b
		{
			// Token: 0x06006621 RID: 26145 RVA: 0x00052300 File Offset: 0x00050500
			internal MessageBoxResult #15b()
			{
				return AutoClosingMessageBox.Show(this.#a, null, this.#b, this.#c, this.#d, this.#e, this.#f, this.#g);
			}

			// Token: 0x040029FA RID: 10746
			public TimeSpan #a;

			// Token: 0x040029FB RID: 10747
			public string #b;

			// Token: 0x040029FC RID: 10748
			public string #c;

			// Token: 0x040029FD RID: 10749
			public MessageBoxButton #d;

			// Token: 0x040029FE RID: 10750
			public MessageBoxImage #e;

			// Token: 0x040029FF RID: 10751
			public MessageBoxResult #f;

			// Token: 0x04002A00 RID: 10752
			public MessageBoxOptions #g;
		}

		// Token: 0x02000C58 RID: 3160
		[CompilerGenerated]
		private sealed class #cWb
		{
			// Token: 0x06006623 RID: 26147 RVA: 0x00052332 File Offset: 0x00050532
			internal MessageBoxResult #Kad()
			{
				return MessageBox.Show(this.#a, this.#b, MessageBoxButton.OK, MessageBoxImage.Exclamation, MessageBoxResult.OK, MessageBoxOptions.None);
			}

			// Token: 0x04002A01 RID: 10753
			public string #a;

			// Token: 0x04002A02 RID: 10754
			public string #b;
		}

		// Token: 0x02000C59 RID: 3161
		[CompilerGenerated]
		private sealed class #AZb
		{
			// Token: 0x06006625 RID: 26149 RVA: 0x0005234A File Offset: 0x0005054A
			internal MessageBoxResult #Kad()
			{
				return MessageBoxExt.#od(this.#a, this.#c, this.#b, MessageBoxButton.OK, MessageBoxImage.Exclamation, MessageBoxResult.OK, MessageBoxOptions.None);
			}

			// Token: 0x06006626 RID: 26150 RVA: 0x00052368 File Offset: 0x00050568
			internal MessageBoxResult #Lad()
			{
				return MessageBox.Show(this.#b, this.#c, MessageBoxButton.OK, MessageBoxImage.Exclamation, MessageBoxResult.OK, MessageBoxOptions.None);
			}

			// Token: 0x04002A03 RID: 10755
			public Window #a;

			// Token: 0x04002A04 RID: 10756
			public string #b;

			// Token: 0x04002A05 RID: 10757
			public string #c;
		}

		// Token: 0x02000C5A RID: 3162
		[CompilerGenerated]
		private sealed class #jac
		{
			// Token: 0x06006628 RID: 26152 RVA: 0x00052380 File Offset: 0x00050580
			internal MessageBoxResult #Mad()
			{
				return MessageBoxExt.#od(this.#a, this.#b, this.#c, MessageBoxButton.OKCancel, MessageBoxImage.Exclamation, MessageBoxResult.OK, MessageBoxOptions.None);
			}

			// Token: 0x06006629 RID: 26153 RVA: 0x0005239E File Offset: 0x0005059E
			internal MessageBoxResult #Nad()
			{
				return MessageBox.Show(this.#c, this.#b, MessageBoxButton.OKCancel, MessageBoxImage.Exclamation, MessageBoxResult.OK, MessageBoxOptions.None);
			}

			// Token: 0x04002A06 RID: 10758
			public Window #a;

			// Token: 0x04002A07 RID: 10759
			public string #b;

			// Token: 0x04002A08 RID: 10760
			public string #c;
		}

		// Token: 0x02000C5B RID: 3163
		[CompilerGenerated]
		private sealed class #aVb
		{
			// Token: 0x0600662B RID: 26155 RVA: 0x000523B6 File Offset: 0x000505B6
			internal MessageBoxResult #Oad()
			{
				return MessageBoxExt.#od(this.#a, this.#b, this.#c, this.#d, this.#e);
			}

			// Token: 0x04002A09 RID: 10761
			public Window #a;

			// Token: 0x04002A0A RID: 10762
			public string #b;

			// Token: 0x04002A0B RID: 10763
			public string #c;

			// Token: 0x04002A0C RID: 10764
			public MessageBoxButton #d;

			// Token: 0x04002A0D RID: 10765
			public MessageBoxImage #e;
		}

		// Token: 0x02000C5C RID: 3164
		[CompilerGenerated]
		private sealed class #CZb
		{
			// Token: 0x0600662D RID: 26157 RVA: 0x000523DB File Offset: 0x000505DB
			internal MessageBoxResult #Oad()
			{
				return MessageBoxExt.#od(this.#a, this.#b, this.#c, this.#d, this.#e, this.#f, MessageBoxOptions.None);
			}

			// Token: 0x04002A0E RID: 10766
			public Window #a;

			// Token: 0x04002A0F RID: 10767
			public string #b;

			// Token: 0x04002A10 RID: 10768
			public string #c;

			// Token: 0x04002A11 RID: 10769
			public MessageBoxButton #d;

			// Token: 0x04002A12 RID: 10770
			public MessageBoxImage #e;

			// Token: 0x04002A13 RID: 10771
			public MessageBoxResult #f;
		}

		// Token: 0x02000C5D RID: 3165
		[CompilerGenerated]
		private sealed class #p6b
		{
			// Token: 0x0600662F RID: 26159 RVA: 0x001905E8 File Offset: 0x0018E7E8
			internal void #Pad()
			{
				DialogService dialogService = this.#a;
				Func<MessageBoxResult> #7Sc;
				if ((#7Sc = this.#g) == null)
				{
					#7Sc = (this.#g = new Func<MessageBoxResult>(this.#Qad));
				}
				dialogService.#hAc(#7Sc);
			}

			// Token: 0x06006630 RID: 26160 RVA: 0x00052407 File Offset: 0x00050607
			internal MessageBoxResult #Qad()
			{
				return MessageBoxExt.#od(this.#b, this.#c, this.#d, this.#e, this.#f);
			}

			// Token: 0x04002A14 RID: 10772
			public DialogService #a;

			// Token: 0x04002A15 RID: 10773
			public Window #b;

			// Token: 0x04002A16 RID: 10774
			public string #c;

			// Token: 0x04002A17 RID: 10775
			public string #d;

			// Token: 0x04002A18 RID: 10776
			public MessageBoxButton #e;

			// Token: 0x04002A19 RID: 10777
			public MessageBoxImage #f;

			// Token: 0x04002A1A RID: 10778
			public Func<MessageBoxResult> #g;
		}

		// Token: 0x02000C5E RID: 3166
		[CompilerGenerated]
		private sealed class #fWb
		{
			// Token: 0x06006632 RID: 26162 RVA: 0x00190620 File Offset: 0x0018E820
			internal void #Pad()
			{
				DialogService dialogService = this.#a;
				Func<MessageBoxResult> #7Sc;
				if ((#7Sc = this.#g) == null)
				{
					#7Sc = (this.#g = new Func<MessageBoxResult>(this.#Qad));
				}
				dialogService.#hAc(#7Sc);
			}

			// Token: 0x06006633 RID: 26163 RVA: 0x0005242C File Offset: 0x0005062C
			internal MessageBoxResult #Qad()
			{
				return MessageBoxExt.#od(this.#b(), this.#c, this.#d, this.#e, this.#f);
			}

			// Token: 0x04002A1B RID: 10779
			public DialogService #a;

			// Token: 0x04002A1C RID: 10780
			public Func<Window> #b;

			// Token: 0x04002A1D RID: 10781
			public string #c;

			// Token: 0x04002A1E RID: 10782
			public string #d;

			// Token: 0x04002A1F RID: 10783
			public MessageBoxButton #e;

			// Token: 0x04002A20 RID: 10784
			public MessageBoxImage #f;

			// Token: 0x04002A21 RID: 10785
			public Func<MessageBoxResult> #g;
		}

		// Token: 0x02000C5F RID: 3167
		[CompilerGenerated]
		private sealed class #EZb
		{
			// Token: 0x06006635 RID: 26165 RVA: 0x00052456 File Offset: 0x00050656
			internal MessageBoxResult #Rad()
			{
				return MessageBoxExt.#od(this.#a, this.#b, this.#c, MessageBoxButton.OK, MessageBoxImage.Asterisk, MessageBoxResult.OK, MessageBoxOptions.None);
			}

			// Token: 0x06006636 RID: 26166 RVA: 0x00052474 File Offset: 0x00050674
			internal MessageBoxResult #Sad()
			{
				return MessageBox.Show(this.#c, this.#b, MessageBoxButton.OK, MessageBoxImage.Asterisk, MessageBoxResult.OK, MessageBoxOptions.None);
			}

			// Token: 0x04002A22 RID: 10786
			public Window #a;

			// Token: 0x04002A23 RID: 10787
			public string #b;

			// Token: 0x04002A24 RID: 10788
			public string #c;
		}

		// Token: 0x02000C60 RID: 3168
		[CompilerGenerated]
		private sealed class #R7b
		{
			// Token: 0x06006638 RID: 26168 RVA: 0x0005248C File Offset: 0x0005068C
			internal MessageBoxResult #Rad()
			{
				return MessageBoxExt.#od(this.#a, this.#c, this.#b, MessageBoxButton.OK, MessageBoxImage.Asterisk, MessageBoxResult.OK, MessageBoxOptions.None);
			}

			// Token: 0x06006639 RID: 26169 RVA: 0x000524AA File Offset: 0x000506AA
			internal MessageBoxResult #Sad()
			{
				return MessageBox.Show(this.#b, this.#c, MessageBoxButton.OK, MessageBoxImage.Asterisk, MessageBoxResult.OK, MessageBoxOptions.None);
			}

			// Token: 0x04002A25 RID: 10789
			public Window #a;

			// Token: 0x04002A26 RID: 10790
			public string #b;

			// Token: 0x04002A27 RID: 10791
			public string #c;
		}

		// Token: 0x02000C61 RID: 3169
		[CompilerGenerated]
		private sealed class #0Ub
		{
			// Token: 0x0600663B RID: 26171 RVA: 0x000524C2 File Offset: 0x000506C2
			internal MessageBoxResult #Tad()
			{
				return MessageBox.Show(this.#a, this.#d, this.#b, MessageBoxImage.Question, this.#c, MessageBoxOptions.None);
			}

			// Token: 0x04002A28 RID: 10792
			public string #a;

			// Token: 0x04002A29 RID: 10793
			public MessageBoxButton #b;

			// Token: 0x04002A2A RID: 10794
			public MessageBoxResult #c;

			// Token: 0x04002A2B RID: 10795
			public string #d;
		}

		// Token: 0x02000C62 RID: 3170
		[CompilerGenerated]
		private sealed class #Jcc
		{
			// Token: 0x0600663D RID: 26173 RVA: 0x000524E4 File Offset: 0x000506E4
			internal MessageBoxResult #Tad()
			{
				return MessageBoxExt.#od(this.#a, this.#e, this.#b, this.#c, MessageBoxImage.Question, this.#d, MessageBoxOptions.None);
			}

			// Token: 0x0600663E RID: 26174 RVA: 0x0005250C File Offset: 0x0005070C
			internal MessageBoxResult #Uad()
			{
				return MessageBox.Show(this.#b, this.#e, this.#c, MessageBoxImage.Question, this.#d, MessageBoxOptions.None);
			}

			// Token: 0x04002A2C RID: 10796
			public Window #a;

			// Token: 0x04002A2D RID: 10797
			public string #b;

			// Token: 0x04002A2E RID: 10798
			public MessageBoxButton #c;

			// Token: 0x04002A2F RID: 10799
			public MessageBoxResult #d;

			// Token: 0x04002A30 RID: 10800
			public string #e;
		}
	}
}
