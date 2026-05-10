using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Shell;
using #7hc;
using #eU;
using #f5d;
using #HI;
using #wQb;
using #Z;
using #ZPb;
using StructurePoint.CoreAssets.AppManager.Column.Core;
using StructurePoint.CoreAssets.Column.Core.Core.Diagnostics;
using StructurePoint.CoreAssets.GUI.Framework.Services;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.CoreAssets.Logger;
using StructurePoint.Products.Column.Resources;
using Telerik.Windows.Controls.Animation;

namespace StructurePoint.Products.Column.Core.Application
{
	// Token: 0x020006BF RID: 1727
	internal sealed class ColumnApplicationStartupHandler : IDisposable
	{
		// Token: 0x06003950 RID: 14672 RVA: 0x00111FA0 File Offset: 0x001101A0
		public static void #TQb()
		{
			try
			{
				#t5d #t5d = new #t5d();
				#t5d #t5d2;
				if (2 != 0)
				{
					#t5d2 = #t5d;
				}
				string path = #YPb.LogsPath;
				List<AppenderConfigurationBase> #a5d = new List<AppenderConfigurationBase>
				{
					new FileAppenderConfiguration(Path.Combine(path, #Phc.#3hc(107350658)), new LoggingLevel[]
					{
						LoggingLevel.Fatal,
						LoggingLevel.Error,
						LoggingLevel.Warning,
						LoggingLevel.Notification,
						LoggingLevel.Debug
					})
				};
				#t5d2.#94d(#a5d);
				#j5d logProvider = new #j5d();
				Logger.Configure(logProvider);
			}
			catch (Exception exception)
			{
				Logger.Error(#Phc.#3hc(107350673), exception);
			}
		}

		// Token: 0x06003951 RID: 14673 RVA: 0x00112038 File Offset: 0x00110238
		internal void #UQb(string #4Hc)
		{
			if (!#Llf.#gb())
			{
				return;
			}
			bool isGlobalAnimationEnabled = false;
			if (!false)
			{
				AnimationManager.IsGlobalAnimationEnabled = isGlobalAnimationEnabled;
			}
			IGenericLoaderWindow genericLoaderWindow = ColumnResources.CreateSplashScreen();
			genericLoaderWindow.#od();
			this.#a.#eb(false);
			#II #II = this.#a.Resolve<#II>();
			#II.#od(genericLoaderWindow);
			if (!string.IsNullOrWhiteSpace(#4Hc))
			{
				#vU #vU = this.#a.Resolve<#vU>();
				bool? flag = #vU.#kF(#4Hc, false);
				bool? flag2 = flag;
				bool flag3 = false;
				if (flag2.GetValueOrDefault() == flag3 & flag2 != null)
				{
					MessageBox.Show(Strings.StringFileCouldNotBeOpened.#z2d(), ColumnGlobalInfo.ShortName, MessageBoxButton.OK, MessageBoxImage.Hand);
					return;
				}
				if (flag.GetValueOrDefault())
				{
					JumpList.AddToRecentCategory(#4Hc);
				}
			}
		}

		// Token: 0x06003952 RID: 14674 RVA: 0x00031BD9 File Offset: 0x0002FDD9
		public void #1()
		{
			#SQb #SQb = this.#a;
			if (#SQb == null)
			{
				return;
			}
			#SQb.Dispose();
		}

		// Token: 0x0400180F RID: 6159
		private readonly #SQb #a = new #SQb();
	}
}
