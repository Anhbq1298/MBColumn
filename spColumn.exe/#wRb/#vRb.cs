using System;
using #cYd;
using #LQc;
using #UYd;
using #v1c;
using #wQb;
using #Z;
using #ZPb;
using StructurePoint.CoreAssets.Column.Core.Core.Diagnostics;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.Products.Column.CommandLine;
using StructurePoint.Products.Column.Core.Application;

namespace #wRb
{
	// Token: 0x020006C6 RID: 1734
	internal sealed class #vRb
	{
		// Token: 0x060039C7 RID: 14791 RVA: 0x00112A2C File Offset: 0x00110C2C
		internal static void #uRb(string[] #Lg)
		{
			#KQc.#JQc();
			try
			{
				LastChanceLogger.LogsPath = #YPb.LogsPath;
				ColumnApplicationStartupHandler.#TQb();
				if (CommandlineParametersParser.#4Sb(#Lg))
				{
					CommandlineParametersParser.#7Sb();
					Console.WriteLine();
					Console.WriteLine(Strings.StringPressAnyKeyToContinue);
					Console.ReadKey();
				}
				else
				{
					#Llf.#eb(true);
					if (!#Llf.#gb())
					{
						#TYd.Active = true;
						#TYd.#qn(Strings.StringNoLicenseFound.#z2d(), true);
						#Llf.#2(2);
					}
					else
					{
						#E1c.#z1c(AppDomain.CurrentDomain.BaseDirectory);
						#TYd.Active = true;
						CommandlineParametersParser.#6Sb();
						CommandLineParameters #Pc;
						if (CommandlineParametersParser.#1vb(#Lg, out #Pc))
						{
							#SQb #SQb = new #SQb();
							#SQb.#eb(true);
							#bUi #bUi = #SQb.Resolve<#bUi>();
							#bUi.#3Ab(#Pc);
						}
					}
				}
			}
			catch (Exception ex)
			{
				string text = Strings.StringApplicationEncounteredAnErrorWhileAttemptingToGenerateResult.#z2d(true) + #sYd.#oYd(ex);
				#TYd.#qn(text, true);
				Logger.Error(text, ex);
			}
			finally
			{
				#Llf.#2(0);
			}
		}
	}
}
