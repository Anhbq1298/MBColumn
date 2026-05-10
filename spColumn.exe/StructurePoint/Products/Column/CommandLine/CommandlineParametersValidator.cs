using System;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using #7hc;
using Alphaleonis.Win32.Filesystem;
using FluentValidation;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;

namespace StructurePoint.Products.Column.CommandLine
{
	// Token: 0x020006D2 RID: 1746
	internal sealed class CommandlineParametersValidator : AbstractValidator<CommandLineParameters>
	{
		// Token: 0x06003A2A RID: 14890 RVA: 0x00113BF8 File Offset: 0x00111DF8
		public CommandlineParametersValidator()
		{
			ParameterExpression parameterExpression = Expression.Parameter(typeof(CommandLineParameters), #Phc.#3hc(107395311));
			base.RuleFor<string>(Expression.Lambda<Func<CommandLineParameters, string>>(Expression.Property(parameterExpression, methodof(CommandLineParameters.#82())), new ParameterExpression[]
			{
				parameterExpression
			})).Must(new Func<CommandLineParameters, string, bool>(CommandlineParametersValidator.<>c.<>9.#98e)).WithMessage(Strings.StringInvalidColumnType.#z2d());
			parameterExpression = Expression.Parameter(typeof(CommandLineParameters), #Phc.#3hc(107347970));
			base.RuleFor<float?>(Expression.Lambda<Func<CommandLineParameters, float?>>(Expression.Property(parameterExpression, methodof(CommandLineParameters.#pUi())), new ParameterExpression[]
			{
				parameterExpression
			})).GreaterThan(0f).When(new Func<CommandLineParameters, bool>(CommandlineParametersValidator.<>c.<>9.#b9e), ApplyConditionTo.AllValidators).WithMessage(Strings.StringTheDiagramInterpolationConvergenceEpsilonMustBeGraterThan000.#z2d());
			parameterExpression = Expression.Parameter(typeof(CommandLineParameters), #Phc.#3hc(107347970));
			base.RuleFor<float?>(Expression.Lambda<Func<CommandLineParameters, float?>>(Expression.Property(parameterExpression, methodof(CommandLineParameters.#pUi())), new ParameterExpression[]
			{
				parameterExpression
			})).LessThanOrEqualTo(100f).When(new Func<CommandLineParameters, bool>(CommandlineParametersValidator.<>c.<>9.#c9e), ApplyConditionTo.AllValidators).WithMessage(Strings.StringTheDiagramInterpolationConvergenceEpsilonMustBeSmallerOrEqualTo10000.#z2d());
			parameterExpression = Expression.Parameter(typeof(CommandLineParameters), #Phc.#3hc(107395311));
			base.RuleFor<string>(Expression.Lambda<Func<CommandLineParameters, string>>(Expression.Property(parameterExpression, methodof(CommandLineParameters.#aSb())), new ParameterExpression[]
			{
				parameterExpression
			})).Must(new Func<string, bool>(CommandlineParametersValidator.<>c.<>9.#x9e)).When(new Func<CommandLineParameters, bool>(CommandlineParametersValidator.<>c.<>9.#e9e), ApplyConditionTo.AllValidators).WithMessage(new Func<CommandLineParameters, string>(CommandlineParametersValidator.<>c.<>9.#f9e));
			parameterExpression = Expression.Parameter(typeof(CommandLineParameters), #Phc.#3hc(107395311));
			IRuleBuilder<CommandLineParameters, string> ruleBuilder = base.RuleFor<string>(Expression.Lambda<Func<CommandLineParameters, string>>(Expression.Property(parameterExpression, methodof(CommandLineParameters.#aSb())), new ParameterExpression[]
			{
				parameterExpression
			}));
			Func<string, bool> predicate;
			if ((predicate = CommandlineParametersValidator.#2Ui.#a) == null)
			{
				predicate = (CommandlineParametersValidator.#2Ui.#a = new Func<string, bool>(CommandlineParametersValidator.#X1c));
			}
			ruleBuilder.Must(predicate).When(new Func<CommandLineParameters, bool>(CommandlineParametersValidator.<>c.<>9.#y9e), ApplyConditionTo.AllValidators).WithMessage(Strings.StringInputFolderDoesNotExist.#z2d());
			parameterExpression = Expression.Parameter(typeof(CommandLineParameters), #Phc.#3hc(107395311));
			base.RuleFor<string>(Expression.Lambda<Func<CommandLineParameters, string>>(Expression.Property(parameterExpression, methodof(CommandLineParameters.#aSb())), new ParameterExpression[]
			{
				parameterExpression
			})).Must(new Func<string, bool>(CommandlineParametersValidator.<>c.<>9.#t9e)).When(new Func<CommandLineParameters, bool>(CommandlineParametersValidator.<>c.<>9.#U9e), ApplyConditionTo.AllValidators).WithMessage(Strings.StringInBatchModeInputPathMustBeAFolderPath.#z2d());
			parameterExpression = Expression.Parameter(typeof(CommandLineParameters), #Phc.#3hc(107395311));
			base.RuleFor<string>(Expression.Lambda<Func<CommandLineParameters, string>>(Expression.Property(parameterExpression, methodof(CommandLineParameters.#aSb())), new ParameterExpression[]
			{
				parameterExpression
			})).Must(new Func<string, bool>(CommandlineParametersValidator.<>c.<>9.#VAg)).When(new Func<CommandLineParameters, bool>(CommandlineParametersValidator.<>c.<>9.#q9e), ApplyConditionTo.AllValidators).WithMessage(new Func<CommandLineParameters, string>(CommandlineParametersValidator.<>c.<>9.#WAg));
			parameterExpression = Expression.Parameter(typeof(CommandLineParameters), #Phc.#3hc(107395311));
			IRuleBuilder<CommandLineParameters, string> ruleBuilder2 = base.RuleFor<string>(Expression.Lambda<Func<CommandLineParameters, string>>(Expression.Property(parameterExpression, methodof(CommandLineParameters.#aSb())), new ParameterExpression[]
			{
				parameterExpression
			}));
			Func<string, bool> predicate2;
			if ((predicate2 = CommandlineParametersValidator.#2Ui.#b) == null)
			{
				predicate2 = (CommandlineParametersValidator.#2Ui.#b = new Func<string, bool>(CommandlineParametersValidator.#V1c));
			}
			ruleBuilder2.Must(predicate2).When(new Func<CommandLineParameters, bool>(CommandlineParametersValidator.<>c.<>9.#A9e), ApplyConditionTo.AllValidators).WithMessage(Strings.StringInputFileDoesNotExist.#z2d());
			parameterExpression = Expression.Parameter(typeof(CommandLineParameters), #Phc.#3hc(107395311));
			base.RuleFor<string>(Expression.Lambda<Func<CommandLineParameters, string>>(Expression.Property(parameterExpression, methodof(CommandLineParameters.#aSb())), new ParameterExpression[]
			{
				parameterExpression
			})).Must(new Func<string, bool>(CommandlineParametersValidator.<>c.<>9.#ZAg)).When(new Func<CommandLineParameters, bool>(CommandlineParametersValidator.<>c.<>9.#0Ag), ApplyConditionTo.AllValidators).WithMessage(Strings.StringInputPathMustBeAFilePath.#z2d());
			parameterExpression = Expression.Parameter(typeof(CommandLineParameters), #Phc.#3hc(107395311));
			base.RuleFor<string>(Expression.Lambda<Func<CommandLineParameters, string>>(Expression.Property(parameterExpression, methodof(CommandLineParameters.#cSb())), new ParameterExpression[]
			{
				parameterExpression
			})).Must(new Func<string, bool>(CommandlineParametersValidator.<>c.<>9.#1Ag)).When(new Func<CommandLineParameters, bool>(CommandlineParametersValidator.<>c.<>9.#2Ag), ApplyConditionTo.AllValidators).WithMessage(new Func<CommandLineParameters, string>(CommandlineParametersValidator.<>c.<>9.#3Ag));
			parameterExpression = Expression.Parameter(typeof(CommandLineParameters), #Phc.#3hc(107395311));
			base.RuleFor<string>(Expression.Lambda<Func<CommandLineParameters, string>>(Expression.Property(parameterExpression, methodof(CommandLineParameters.#cSb())), new ParameterExpression[]
			{
				parameterExpression
			})).Must(new Func<string, bool>(CommandlineParametersValidator.<>c.<>9.#dNh)).When(new Func<CommandLineParameters, bool>(CommandlineParametersValidator.<>c.<>9.#4Ag), ApplyConditionTo.AllValidators).WithMessage(new Func<CommandLineParameters, string>(CommandlineParametersValidator.<>c.<>9.#5Ag));
			parameterExpression = Expression.Parameter(typeof(CommandLineParameters), #Phc.#3hc(107395311));
			base.RuleFor<string>(Expression.Lambda<Func<CommandLineParameters, string>>(Expression.Property(parameterExpression, methodof(CommandLineParameters.#cSb())), new ParameterExpression[]
			{
				parameterExpression
			})).Must(new Func<string, bool>(CommandlineParametersValidator.<>c.<>9.#6Ag)).When(new Func<CommandLineParameters, bool>(CommandlineParametersValidator.<>c.<>9.#7Ag), ApplyConditionTo.AllValidators).WithMessage(Strings.StringOutputMustBeAFilePathFolderPathProvided.#z2d());
		}

		// Token: 0x06003A2B RID: 14891 RVA: 0x0011435C File Offset: 0x0011255C
		private static bool #V1c(string #So)
		{
			bool result;
			try
			{
				result = File.Exists(#So);
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06003A2C RID: 14892 RVA: 0x00114394 File Offset: 0x00112594
		private static bool #X1c(string #So)
		{
			bool result;
			try
			{
				result = Directory.Exists(#So);
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06003A2D RID: 14893 RVA: 0x001143CC File Offset: 0x001125CC
		private static bool #tUi(string #So, bool #Nxb, out string #nzb)
		{
			#nzb = null;
			bool result;
			try
			{
				if (#Nxb)
				{
					new DirectoryInfo(#So);
				}
				else
				{
					new FileInfo(#So);
				}
				result = true;
			}
			catch (ArgumentException ex)
			{
				#nzb = ex.Message.Split(new string[]
				{
					Environment.NewLine
				}, StringSplitOptions.RemoveEmptyEntries).FirstOrDefault<string>();
				result = false;
			}
			catch (Exception ex2)
			{
				#nzb = ex2.Message;
				result = false;
			}
			return result;
		}

		// Token: 0x020006D3 RID: 1747
		[CompilerGenerated]
		private static class #2Ui
		{
			// Token: 0x040018B4 RID: 6324
			public static Func<string, bool> #a;

			// Token: 0x040018B5 RID: 6325
			public static Func<string, bool> #b;
		}
	}
}
