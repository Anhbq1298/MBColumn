using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using #54d;
using #7hc;
using #ezc;
using #m6c;
using #UYd;
using #v1c;
using StructurePoint.CoreAssets.GUI.DesktopControls;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;

namespace #LQc
{
	// Token: 0x02000C3F RID: 3135
	internal sealed class #0Rc : #iSc
	{
		// Token: 0x0600659B RID: 26011 RVA: 0x0018F0C4 File Offset: 0x0018D2C4
		public #0Rc(#cSc #1Rc, #v2c #my, #8Sc #ls, #xAc #6x)
		{
			#X0d.#V0d(#1Rc, #Phc.#3hc(107442625), Component.GUIFramework, #Phc.#3hc(107442592));
			this.#a = #1Rc;
			this.#b = #my;
			this.#c = #ls;
			this.#d = #6x;
		}

		// Token: 0x0600659C RID: 26012 RVA: 0x0018F128 File Offset: 0x0018D328
		private void #URc(object #Ge, ExecutedRoutedEventArgs #VRc)
		{
			FrameworkElement frameworkElement = #Ge as FrameworkElement;
			FrameworkElement frameworkElement2;
			if (-1 != 0)
			{
				frameworkElement2 = frameworkElement;
			}
			if (2 == 0)
			{
				goto IL_29;
			}
			if (frameworkElement2 == null)
			{
				return;
			}
			IL_11:
			#r6c #r6c = #l6c.#h6c(frameworkElement2);
			#r6c #r6c2;
			if (!false)
			{
				#r6c2 = #r6c;
			}
			if (#r6c2 == null)
			{
				return;
			}
			IL_1F:
			HelpID helpID;
			if ((helpID = #r6c2.HelpID) != null)
			{
				goto IL_2F;
			}
			IL_29:
			helpID = #r6c2.ParentHelpID;
			IL_2F:
			HelpID helpID2;
			if (!false)
			{
				helpID2 = helpID;
			}
			if (helpID2 == null)
			{
				bool flag = #44d.#g;
				return;
			}
			if (false)
			{
				goto IL_11;
			}
			HelpID #PRc = helpID2;
			if (!false)
			{
				this.#WRc(#PRc);
			}
			if (5 != 0)
			{
				return;
			}
			goto IL_1F;
		}

		// Token: 0x0600659D RID: 26013 RVA: 0x0018F190 File Offset: 0x0018D390
		public void #WRc(HelpID #PRc)
		{
			do
			{
				string #R0d = #Phc.#3hc(107443034);
				Component #x6c = Component.GUIFramework;
				string #Qic = #Phc.#3hc(107442539);
				if (6 != 0)
				{
					#X0d.#V0d(#PRc, #R0d, #x6c, #Qic);
				}
			}
			while (false);
			int num;
			bool flag = ((!this.#f) ? (num = 0) : (num = (this.#YRc(#PRc) ? 1 : 0))) != 0;
			if (false)
			{
				goto IL_7C;
			}
			bool flag2;
			if (!false)
			{
				flag2 = (num != 0);
			}
			if (flag2)
			{
				bool flag3 = #44d.#g;
			}
			while (!flag2)
			{
				if (!false)
				{
					bool flag4 = this.#g && this.#ZRc(#PRc);
					if (-1 != 0)
					{
						flag2 = flag4;
					}
					if (flag2)
					{
						bool flag5 = #44d.#g;
						break;
					}
					break;
				}
			}
			if (flag2)
			{
				goto IL_8F;
			}
			IL_6E:
			if (this.#h)
			{
				flag = this.#XRc();
			}
			else
			{
				flag = false;
			}
			IL_7C:
			if (!false)
			{
				flag2 = flag;
			}
			if (5 == 0)
			{
				goto IL_6E;
			}
			if (flag2)
			{
				bool flag6 = #44d.#g;
			}
			IL_8F:
			if (!flag2)
			{
				this.#c.#od(Strings.StringCouldNotLoadManualFile.#z2d(), MessageBoxButton.OK, MessageBoxImage.Hand, MessageBoxResult.OK, MessageBoxOptions.None);
			}
		}

		// Token: 0x0600659E RID: 26014 RVA: 0x0018F260 File Offset: 0x0018D460
		public void #eb(#8Rc #AQ)
		{
			if (#AQ != null)
			{
				this.#f = #AQ.AllowLocalHelp;
				this.#g = #AQ.AllowWebBrowserHelp;
				this.#h = #AQ.FallbackToShellExecute;
			}
			if (!this.#e)
			{
				this.#e = true;
				Type typeFromHandle = typeof(UIElement);
				CommandBinding commandBinding = new CommandBinding(ApplicationCommands.Help, new ExecutedRoutedEventHandler(this.#URc));
				if (8 != 0)
				{
					CommandManager.RegisterClassCommandBinding(typeFromHandle, commandBinding);
				}
			}
		}

		// Token: 0x0600659F RID: 26015 RVA: 0x0018F2D0 File Offset: 0x0018D4D0
		private bool #XRc()
		{
			string text = this.#a.#aSc();
			string text2;
			if (2 != 0)
			{
				text2 = text;
			}
			int result;
			for (;;)
			{
				bool flag = (result = (this.#b.#V1c(text2) ? 1 : 0)) != 0;
				if (-1 == 0)
				{
					return result != 0;
				}
				if (!flag)
				{
					break;
				}
				if (8 != 0)
				{
					ProcessStartInfo processStartInfo = new ProcessStartInfo();
					processStartInfo.FileName = text2;
					processStartInfo.UseShellExecute = true;
					string verb = #Phc.#3hc(107442518);
					if (!false)
					{
						processStartInfo.Verb = verb;
					}
					Process.Start(processStartInfo);
				}
				if (4 != 0)
				{
					return true;
				}
			}
			result = 0;
			return result != 0;
		}

		// Token: 0x060065A0 RID: 26016 RVA: 0x0018F33C File Offset: 0x0018D53C
		private bool #YRc(HelpID #PRc)
		{
			string text2;
			if (!false)
			{
				string text = this.#b.#71c(#Phc.#3hc(107442477));
				if (!false)
				{
					text2 = text;
				}
				if (!this.#b.#V1c(text2))
				{
					return false;
				}
			}
			string text3 = this.#a.#aSc();
			string text4;
			if (!false)
			{
				text4 = text3;
			}
			int result;
			if (!this.#b.#V1c(text4))
			{
				result = 0;
			}
			else
			{
				string text5;
				if (#TRc.#NRc(text2, #PRc, text4, out text5))
				{
					ProcessStartInfo processStartInfo = new ProcessStartInfo();
					processStartInfo.FileName = text2;
					string arguments = text5;
					if (!false)
					{
						processStartInfo.Arguments = arguments;
					}
					Process.Start(processStartInfo);
					return true;
				}
				int num = result = 0;
				if (num == 0)
				{
					return num != 0;
				}
			}
			return result != 0;
		}

		// Token: 0x060065A1 RID: 26017 RVA: 0x0018F3CC File Offset: 0x0018D5CC
		private bool #ZRc(HelpID #PRc)
		{
			string text = this.#b.#F1c();
			string text2;
			if (3 != 0)
			{
				text2 = text;
			}
			if (!this.#b.#V1c(text2))
			{
				return false;
			}
			ProcessStartInfo processStartInfo = new ProcessStartInfo();
			processStartInfo.FileName = text2;
			string arguments = this.#a.#9Rc(#PRc);
			if (8 != 0)
			{
				processStartInfo.Arguments = arguments;
			}
			Process.Start(processStartInfo);
			return true;
		}

		// Token: 0x040029B8 RID: 10680
		private readonly #cSc #a;

		// Token: 0x040029B9 RID: 10681
		private readonly #v2c #b;

		// Token: 0x040029BA RID: 10682
		private readonly #8Sc #c;

		// Token: 0x040029BB RID: 10683
		private readonly #xAc #d;

		// Token: 0x040029BC RID: 10684
		private bool #e;

		// Token: 0x040029BD RID: 10685
		private bool #f = true;

		// Token: 0x040029BE RID: 10686
		private bool #g = true;

		// Token: 0x040029BF RID: 10687
		private bool #h = true;
	}
}
