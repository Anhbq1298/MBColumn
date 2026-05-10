using System;
using System.Runtime.CompilerServices;
using System.Windows;
using #7hc;
using #eU;
using #g7e;
using #y6e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Communication;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.CoreAssets.Units;
using StructurePoint.Products.Column.Model.Entities.Units;

namespace #Mn
{
	// Token: 0x02000121 RID: 289
	internal sealed class #yp
	{
		// Token: 0x06000970 RID: 2416 RVA: 0x0000D3AA File Offset: 0x0000B5AA
		public #yp(#oW #xn)
		{
			this.#a = #xn;
		}

		// Token: 0x170003F5 RID: 1013
		// (get) Token: 0x06000971 RID: 2417 RVA: 0x0000D3B9 File Offset: 0x0000B5B9
		private #oW Project { get; }

		// Token: 0x06000972 RID: 2418 RVA: 0x00096074 File Offset: 0x00094274
		public string #np(#k7e #op)
		{
			string text = string.IsNullOrWhiteSpace(#op.Message.DebugInfo) ? string.Empty : (Environment.NewLine + #op.Message.DebugInfo);
			return this.#qp(#op.Message.Code, #op.Parameters);
		}

		// Token: 0x06000973 RID: 2419 RVA: 0x000960D4 File Offset: 0x000942D4
		public string #pp(Message #5)
		{
			string str = string.IsNullOrWhiteSpace(#5.DebugInfo) ? string.Empty : (Environment.NewLine + #5.DebugInfo);
			return this.#qp(#5.Code, #5.Parameters) + str;
		}

		// Token: 0x06000974 RID: 2420 RVA: 0x0009612C File Offset: 0x0009432C
		public string #qp(#M6e #3, object[] #Pc)
		{
			if (#3 == #M6e.#b)
			{
				return this.#wp(#3, #Pc);
			}
			if (#3 == #M6e.#y)
			{
				return this.#xp(#3, #Pc);
			}
			string text = #j7e.#i7e(#3);
			if (string.IsNullOrWhiteSpace(text))
			{
				return string.Empty;
			}
			return string.Format(text, #Pc ?? new object[0]);
		}

		// Token: 0x06000975 RID: 2421 RVA: 0x00096188 File Offset: 0x00094388
		public string #rp(#w7e.#Nif #sp)
		{
			switch (#sp)
			{
			case #w7e.#Nif.#a:
				return string.Format(#Phc.#3hc(107413090), Strings.StringReinforcementRatioIsLessThan1P.#z2d(), Environment.NewLine, Strings.StringConsiderColumnAsArchitecturalQuestion);
			case #w7e.#Nif.#b:
				return string.Format(#Phc.#3hc(107413090), Strings.StringQuestionTypeContinueProcessingWhenBarsAreOutsideOfSection, Environment.NewLine, Strings.StringContinueAnywayQuestion);
			case #w7e.#Nif.#c:
				return Strings.StringQuestionTypeContinueProcessingWhenRhoIsGreaterThanEight;
			default:
				throw new ArgumentOutOfRangeException(#Phc.#3hc(107413105), #sp, null);
			}
		}

		// Token: 0x06000976 RID: 2422 RVA: 0x00096214 File Offset: 0x00094414
		public MessageBoxImage #tp(#k7e #He)
		{
			switch (#He.Message.Type)
			{
			case Message.EnumType.Error:
				return MessageBoxImage.Hand;
			case Message.EnumType.Warning:
				return MessageBoxImage.Exclamation;
			case Message.EnumType.Note:
				return MessageBoxImage.Asterisk;
			case Message.EnumType.DesignTrace:
				return MessageBoxImage.Question;
			default:
				return MessageBoxImage.None;
			}
		}

		// Token: 0x06000977 RID: 2423 RVA: 0x00096260 File Offset: 0x00094460
		public string #up(#q7e.#Mif? #vp)
		{
			if (#vp != null)
			{
				switch (#vp.GetValueOrDefault())
				{
				case #q7e.#Mif.#a:
					return Strings.StringRunningSolver;
				case #q7e.#Mif.#b:
					return Strings.StringDerivingInteractionDiagram;
				case #q7e.#Mif.#c:
					return Strings.StringComputingCapacity;
				}
			}
			return string.Empty;
		}

		// Token: 0x06000978 RID: 2424 RVA: 0x000962B8 File Offset: 0x000944B8
		private string #wp(#M6e #3, object[] #Pc)
		{
			ColumnUnit<ForcePerAreaUnit> columnUnit = this.Project.Model.Units.Definitions.ConcreteStrength;
			return string.Format(#j7e.#i7e(#3), new object[]
			{
				columnUnit.UnitValueFormatter.CreateDisplayValue(#Pc[0].ToString()),
				columnUnit.Symbol,
				columnUnit.UnitValueFormatter.CreateDisplayValue(#Pc[1].ToString()),
				columnUnit.UnitValueFormatter.CreateDisplayValue(#Pc[2].ToString())
			});
		}

		// Token: 0x06000979 RID: 2425 RVA: 0x00096350 File Offset: 0x00094550
		private string #xp(#M6e #3, object[] #Pc)
		{
			ColumnUnit<ForceUnit> columnUnit = this.Project.Model.Units.Loads.FactoredLoadPu;
			return string.Format(#j7e.#i7e(#3), columnUnit.UnitValueFormatter.CreateDisplayValue(#Pc[0].ToString()), columnUnit.Symbol);
		}

		// Token: 0x0400033E RID: 830
		[CompilerGenerated]
		private readonly #oW #a;
	}
}
