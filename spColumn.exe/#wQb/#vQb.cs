using System;
using System.Windows;
using #Z;
using StructurePoint.CoreAssets.AppManager.Column.Core;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.Products.Column;
using StructurePoint.Products.Column.CommandLine;

namespace #wQb
{
	// Token: 0x020006BB RID: 1723
	internal static class #vQb
	{
		// Token: 0x06003935 RID: 14645 RVA: 0x001114C8 File Offset: 0x0010F6C8
		[STAThread]
		public static void #uQb(string[] #Lg)
		{
			try
			{
				if (#Lg.Length > 1 || CommandlineParametersParser.#4Sb(#Lg))
				{
					MessageBox.Show(Strings.StringCommandlineIsNotSupportedPleaseUseSpMatsCLIExe.#z2d(), ColumnGlobalInfo.ShortName, MessageBoxButton.OK, MessageBoxImage.Hand);
				}
				else
				{
					App app = new App();
					app.InitializeComponent();
					#Llf.#eb(false);
					app.Run();
				}
			}
			finally
			{
				#Llf.#db();
			}
		}
	}
}
