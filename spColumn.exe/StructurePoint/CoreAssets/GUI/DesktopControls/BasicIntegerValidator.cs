using System;
using System.Globalization;
using System.Windows.Controls;
using StructurePoint.CoreAssets.Localizer;

namespace StructurePoint.CoreAssets.GUI.DesktopControls
{
	// Token: 0x0200089C RID: 2204
	public sealed class BasicIntegerValidator : ValidationRule
	{
		// Token: 0x1700143F RID: 5183
		// (get) Token: 0x06004571 RID: 17777 RVA: 0x00039EC5 File Offset: 0x000380C5
		// (set) Token: 0x06004572 RID: 17778 RVA: 0x00039ED1 File Offset: 0x000380D1
		public bool Nullable { get; set; }

		// Token: 0x17001440 RID: 5184
		// (get) Token: 0x06004573 RID: 17779 RVA: 0x00039EE2 File Offset: 0x000380E2
		// (set) Token: 0x06004574 RID: 17780 RVA: 0x00039EEE File Offset: 0x000380EE
		public bool AllowNegative { get; set; }

		// Token: 0x06004575 RID: 17781 RVA: 0x0013CF58 File Offset: 0x0013B158
		public override ValidationResult Validate(object value, CultureInfo cultureInfo)
		{
			string text = (string)value;
			int num;
			if (string.IsNullOrEmpty(text))
			{
				if (!this.Nullable)
				{
					return new ValidationResult(false, Strings.StringPleaseEnterAValue);
				}
				return new ValidationResult(true, null);
			}
			else if (!int.TryParse(text, out num))
			{
				double num2;
				if (double.TryParse(text, out num2))
				{
					return new ValidationResult(false, Strings.StringPleaseEnterAWholeNumberNoDecimals);
				}
				return new ValidationResult(false, Strings.StringTheInputStringWasNotInCorrectFormat);
			}
			else
			{
				if (num < 0 && !this.AllowNegative)
				{
					return new ValidationResult(false, Strings.StringThisPropertyMustBeAPositiveNumber);
				}
				return new ValidationResult(true, null);
			}
		}
	}
}
