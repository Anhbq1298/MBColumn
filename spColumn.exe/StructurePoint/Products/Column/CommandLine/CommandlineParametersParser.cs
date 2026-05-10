using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using #7hc;
using #UYd;
using Fclp;
using FluentValidation.Results;
using StructurePoint.CoreAssets.AppManager.Column.Core;
using StructurePoint.CoreAssets.AppManager.Column.Storage.Legacy;

namespace StructurePoint.Products.Column.CommandLine
{
	// Token: 0x020006CD RID: 1741
	internal static class CommandlineParametersParser
	{
		// Token: 0x06003A17 RID: 14871 RVA: 0x001133DC File Offset: 0x001115DC
		public static bool #4Sb(string[] #Lg)
		{
			CommandlineParametersParser.#wbc #wbc = new CommandlineParametersParser.#wbc();
			#wbc.#a = #Lg;
			if (#wbc.#a.Length == 1)
			{
				return CommandlineParametersParser.#a.Any(new Func<string, bool>(#wbc.#idc));
			}
			return #wbc.#a.Any(new Func<string, bool>(CommandlineParametersParser.<>c.<>9.#mdc));
		}

		// Token: 0x06003A18 RID: 14872 RVA: 0x0003277F File Offset: 0x0003097F
		public static bool #5Sb(string[] #Lg)
		{
			return #Lg.Any(new Func<string, bool>(CommandlineParametersParser.<>c.<>9.#ndc));
		}

		// Token: 0x06003A19 RID: 14873 RVA: 0x00113450 File Offset: 0x00111650
		public static bool #1vb(string[] #Lg, out CommandLineParameters #Pc)
		{
			CommandlineParametersParser.#xTb #xTb = new CommandlineParametersParser.#xTb();
			#xTb.#a = new CommandLineParameters();
			FluentCommandLineParser<CommandLineParameters> fluentCommandLineParser = new FluentCommandLineParser<CommandLineParameters>();
			FluentCommandLineParser<CommandLineParameters> fluentCommandLineParser2 = fluentCommandLineParser;
			ParameterExpression parameterExpression = Expression.Parameter(typeof(CommandLineParameters), #Phc.#3hc(107398878));
			fluentCommandLineParser2.Setup<string>(Expression.Lambda<Func<CommandLineParameters, string>>(Expression.Property(parameterExpression, methodof(CommandLineParameters.#aSb())), new ParameterExpression[]
			{
				parameterExpression
			})).As('i', #Phc.#3hc(107350220)).Required().Callback(new Action<string>(#xTb.#odc));
			FluentCommandLineParser<CommandLineParameters> fluentCommandLineParser3 = fluentCommandLineParser;
			parameterExpression = Expression.Parameter(typeof(CommandLineParameters), #Phc.#3hc(107398878));
			fluentCommandLineParser3.Setup<string>(Expression.Lambda<Func<CommandLineParameters, string>>(Expression.Property(parameterExpression, methodof(CommandLineParameters.#cSb())), new ParameterExpression[]
			{
				parameterExpression
			})).As('o', #Phc.#3hc(107350211)).Callback(new Action<string>(#xTb.#pdc));
			FluentCommandLineParser<CommandLineParameters> fluentCommandLineParser4 = fluentCommandLineParser;
			parameterExpression = Expression.Parameter(typeof(CommandLineParameters), #Phc.#3hc(107398878));
			fluentCommandLineParser4.Setup<bool>(Expression.Lambda<Func<CommandLineParameters, bool>>(Expression.Property(parameterExpression, methodof(CommandLineParameters.#JSb())), new ParameterExpression[]
			{
				parameterExpression
			})).As('t', #Phc.#3hc(107350234)).Callback(new Action<bool>(#xTb.#qdc));
			ICommandLineParserResult commandLineParserResult = fluentCommandLineParser.Parse(#Lg);
			string text = null;
			#xTb.#a.LateralLoadsCompatibilityMode = LateralLoadsCompatibilityMode.ConsiderAsWindLoads;
			foreach (KeyValuePair<string, string> keyValuePair in commandLineParserResult.AdditionalOptionsFound)
			{
				if (string.Equals(keyValuePair.Key, #Phc.#3hc(107350225), StringComparison.OrdinalIgnoreCase))
				{
					#xTb.#a.PdfReportPath = keyValuePair.Value;
					#xTb.#a.PdfReportRequested = true;
				}
				else if (string.Equals(keyValuePair.Key, #Phc.#3hc(107350184), StringComparison.OrdinalIgnoreCase))
				{
					#xTb.#a.WordReportPath = keyValuePair.Value;
					#xTb.#a.WordReportRequested = true;
				}
				else if (string.Equals(keyValuePair.Key, #Phc.#3hc(107350207), StringComparison.OrdinalIgnoreCase))
				{
					#xTb.#a.ExcelReportPath = keyValuePair.Value;
					#xTb.#a.ExcelReportRequested = true;
				}
				else if (string.Equals(keyValuePair.Key, #Phc.#3hc(107350198), StringComparison.OrdinalIgnoreCase))
				{
					#xTb.#a.CsvReportPath = keyValuePair.Value;
					#xTb.#a.CsvReportRequested = true;
				}
				else if (string.Equals(keyValuePair.Key, #Phc.#3hc(107350271), StringComparison.OrdinalIgnoreCase))
				{
					#xTb.#a.CtiPath = keyValuePair.Value;
					#xTb.#a.CtiRequested = true;
				}
				else if (string.Equals(keyValuePair.Key, #Phc.#3hc(107350261), StringComparison.OrdinalIgnoreCase))
				{
					#xTb.#a.ColumnType = #Phc.#3hc(107350261);
				}
				else if (string.Equals(keyValuePair.Key, #Phc.#3hc(107350157), StringComparison.OrdinalIgnoreCase))
				{
					#xTb.#a.IncludeNominalDiagram = true;
				}
				else if (string.Equals(keyValuePair.Key, #Phc.#3hc(107413479), StringComparison.OrdinalIgnoreCase))
				{
					#xTb.#a.ExportTxtDiagram = true;
					#xTb.#a.TxtDiagramPath = keyValuePair.Value;
					#xTb.#a.TxtDiagramPathSpecified = !string.IsNullOrWhiteSpace(keyValuePair.Value);
				}
				else if (string.Equals(keyValuePair.Key, #Phc.#3hc(107408483), StringComparison.OrdinalIgnoreCase))
				{
					#xTb.#a.ExportCsvDiagram = true;
					#xTb.#a.CsvDiagramPath = keyValuePair.Value;
					#xTb.#a.CsvDiagramPathSpecified = !string.IsNullOrWhiteSpace(keyValuePair.Value);
				}
				else if (string.Equals(keyValuePair.Key, #Phc.#3hc(107350266), StringComparison.OrdinalIgnoreCase))
				{
					#xTb.#a.ExportDxf = true;
					#xTb.#a.DxfPath = keyValuePair.Value;
				}
				else if (string.Equals(keyValuePair.Key, #Phc.#3hc(107350152), StringComparison.OrdinalIgnoreCase))
				{
					#xTb.#a.LateralLoadsCompatibilityMode = LateralLoadsCompatibilityMode.ConsiderAsEarthquakeLoads;
				}
				else if (string.Equals(keyValuePair.Key, #Phc.#3hc(107350147), StringComparison.Ordinal))
				{
					#xTb.#a.RemoveDuplicateLoads = true;
				}
				else if (string.Equals(keyValuePair.Key, #Phc.#3hc(107350174), StringComparison.OrdinalIgnoreCase))
				{
					#xTb.#a.DiagramInterpolationConvergenceEpsilon = new float?(float.Parse(keyValuePair.Value, NumberStyles.Float, CultureInfo.InvariantCulture));
				}
				else if (string.Equals(keyValuePair.Key, #Phc.#3hc(107350165), StringComparison.OrdinalIgnoreCase))
				{
					#xTb.#a.Batch = true;
				}
				else
				{
					text = keyValuePair.Key;
				}
			}
			bool flag = CommandlineParametersParser.#4Sb(#Lg) || commandLineParserResult.HelpCalled;
			bool flag2 = commandLineParserResult.HasErrors || !string.IsNullOrWhiteSpace(text);
			ValidationResult validationResult = (!flag2) ? new CommandlineParametersValidator().Validate(#xTb.#a) : new ValidationResult();
			if (flag2 || flag || !validationResult.IsValid)
			{
				CommandlineParametersParser.#8Sb(flag ? null : commandLineParserResult, text, validationResult);
			}
			#Pc = #xTb.#a;
			return !flag2 && validationResult.IsValid;
		}

		// Token: 0x06003A1A RID: 14874 RVA: 0x000327AE File Offset: 0x000309AE
		public static void #6Sb()
		{
			#TYd.#pn(ColumnGlobalInfo.LongName, false);
			#TYd.#pn(ColumnGlobalInfo.Copyright, false);
		}

		// Token: 0x06003A1B RID: 14875 RVA: 0x001139EC File Offset: 0x00111BEC
		public static void #7Sb()
		{
			bool #f = #TYd.Active;
			if (!#TYd.Active)
			{
				#TYd.Active = true;
			}
			#TYd.#pn(CommandlineParametersParser.#b, false);
			#TYd.Active = #f;
		}

		// Token: 0x06003A1C RID: 14876 RVA: 0x00113A2C File Offset: 0x00111C2C
		private static void #8Sb(ICommandLineParserResult #PE, string #aTb, ValidationResult #ORb)
		{
			if ((#PE != null && #PE.HasErrors) || !string.IsNullOrWhiteSpace(#aTb) || !#ORb.IsValid)
			{
				if (!string.IsNullOrWhiteSpace((#PE != null) ? #PE.ErrorText : null))
				{
					#TYd.#pn(null, true);
					#TYd.#qn(#PE.ErrorText, false);
				}
				if (!string.IsNullOrWhiteSpace(#aTb))
				{
					#TYd.#pn(null, true);
					#TYd.#qn(#Phc.#3hc(107350124) + #aTb, false);
				}
				if (!#ORb.IsValid)
				{
					#TYd.#pn(null, true);
					foreach (ValidationFailure validationFailure in #ORb.Errors)
					{
						#TYd.#qn(validationFailure.ErrorMessage, true);
					}
				}
			}
		}

		// Token: 0x040018AC RID: 6316
		private static readonly List<string> #a = new List<string>
		{
			#Phc.#3hc(107350099),
			#Phc.#3hc(107350058),
			#Phc.#3hc(107350049),
			#Phc.#3hc(107350072),
			#Phc.#3hc(107350067),
			#Phc.#3hc(107350030),
			#Phc.#3hc(107350025)
		};

		// Token: 0x040018AD RID: 6317
		private static readonly string #b = #Phc.#3hc(107350020);

		// Token: 0x020006CF RID: 1743
		[CompilerGenerated]
		private sealed class #wbc
		{
			// Token: 0x06003A23 RID: 14883 RVA: 0x00032816 File Offset: 0x00030A16
			internal bool #idc(string #Rf)
			{
				string text = this.#a[0];
				return string.Equals(#Rf, (text != null) ? text.Trim() : null, StringComparison.OrdinalIgnoreCase);
			}

			// Token: 0x040018B1 RID: 6321
			public string[] #a;
		}

		// Token: 0x020006D0 RID: 1744
		[CompilerGenerated]
		private sealed class #ldc
		{
			// Token: 0x06003A25 RID: 14885 RVA: 0x0003283F File Offset: 0x00030A3F
			internal bool #jdc(string #kdc)
			{
				string text = this.#a;
				return string.Equals(#kdc, (text != null) ? text.Trim() : null, StringComparison.OrdinalIgnoreCase);
			}

			// Token: 0x040018B2 RID: 6322
			public string #a;
		}

		// Token: 0x020006D1 RID: 1745
		[CompilerGenerated]
		private sealed class #xTb
		{
			// Token: 0x06003A27 RID: 14887 RVA: 0x00032866 File Offset: 0x00030A66
			internal void #odc(string #f)
			{
				this.#a.InputPath = #f;
			}

			// Token: 0x06003A28 RID: 14888 RVA: 0x00032880 File Offset: 0x00030A80
			internal void #pdc(string #f)
			{
				this.#a.OutputPath = #f;
			}

			// Token: 0x06003A29 RID: 14889 RVA: 0x0003289A File Offset: 0x00030A9A
			internal void #qdc(bool #f)
			{
				this.#a.TestMode = #f;
			}

			// Token: 0x040018B3 RID: 6323
			public CommandLineParameters #a;
		}
	}
}
