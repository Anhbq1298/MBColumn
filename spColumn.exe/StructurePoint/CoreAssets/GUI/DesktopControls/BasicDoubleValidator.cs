using System;
using System.Globalization;
using System.Windows.Controls;
using StructurePoint.CoreAssets.Localizer;

namespace StructurePoint.CoreAssets.GUI.DesktopControls
{
	// Token: 0x0200089B RID: 2203
	public sealed class BasicDoubleValidator : ValidationRule
	{
		// Token: 0x1700143D RID: 5181
		// (get) Token: 0x0600456B RID: 17771 RVA: 0x00039E83 File Offset: 0x00038083
		// (set) Token: 0x0600456C RID: 17772 RVA: 0x00039E8F File Offset: 0x0003808F
		public bool Nullable { get; set; }

		// Token: 0x1700143E RID: 5182
		// (get) Token: 0x0600456D RID: 17773 RVA: 0x00039EA0 File Offset: 0x000380A0
		// (set) Token: 0x0600456E RID: 17774 RVA: 0x00039EAC File Offset: 0x000380AC
		public bool AllowNegative { get; set; }

		// Token: 0x0600456F RID: 17775 RVA: 0x0013CECC File Offset: 0x0013B0CC
		public override ValidationResult Validate(object value, CultureInfo cultureInfo)
		{
			string text = (string)value;
			if (string.IsNullOrEmpty(text))
			{
				if (!this.Nullable)
				{
					return new ValidationResult(false, Strings.StringPleaseEnterAValue);
				}
				return new ValidationResult(true, null);
			}
			else
			{
				double num;
				if (!double.TryParse(text, out num))
				{
					return new ValidationResult(false, Strings.StringTheInputStringWasNotInCorrectFormat);
				}
				if (num < 0.0 && !this.AllowNegative)
				{
					return new ValidationResult(false, Strings.StringThisPropertyMustBeAPositiveNumber);
				}
				return new ValidationResult(true, null);
			}
		}
	}
}
