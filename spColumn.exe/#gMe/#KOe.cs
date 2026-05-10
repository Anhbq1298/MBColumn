using System;

namespace #gMe
{
	// Token: 0x020012B2 RID: 4786
	internal static class #KOe
	{
		// Token: 0x0600A037 RID: 41015 RVA: 0x00220EF4 File Offset: 0x0021F0F4
		public static double #DOe(double #EOe, double #FOe, double #xOe, double #yOe)
		{
			double num = #EOe / #FOe;
			double num2 = 0.5 * num;
			return 0.25 * #xOe * #yOe * num * num * Math.Tan(num) + 0.5 * (#xOe + #yOe) * (Math.Tan(num) - num) + Math.Tan(num) * Math.Tan(num2) / num2 - Math.Tan(num);
		}

		// Token: 0x0600A038 RID: 41016 RVA: 0x00220F58 File Offset: 0x0021F158
		public static double #GOe(double #EOe, double #FOe, double #xOe, double #yOe)
		{
			double num = #EOe / #FOe;
			double num2 = 0.5 * num;
			return 0.25 * #xOe * #yOe * num * num * Math.Tan(num) / Math.Tan(num2) + 0.5 * (#xOe + #yOe) * (Math.Tan(num) - num) / Math.Tan(num2) + Math.Tan(num) / num2 - Math.Tan(num) / Math.Tan(num2);
		}

		// Token: 0x0600A039 RID: 41017 RVA: 0x00220FCC File Offset: 0x0021F1CC
		public static double #HOe(double #EOe, double #FOe, double #xOe, double #yOe)
		{
			double num = #EOe / #FOe;
			double num2 = 0.5 * num;
			return 0.25 * #xOe * #yOe * num * num + 0.5 * (#xOe + #yOe) * (1.0 - num / Math.Tan(num)) + Math.Tan(num2) / num2 - 1.0;
		}

		// Token: 0x0600A03A RID: 41018 RVA: 0x00221030 File Offset: 0x0021F230
		public static double #IOe(double #EOe, double #FOe, double #xOe, double #yOe)
		{
			double num = #EOe / #FOe;
			return (num * num * #xOe * #yOe / 36.0 - 1.0) * Math.Tan(num) - (#xOe + #yOe) * num / 6.0;
		}

		// Token: 0x0600A03B RID: 41019 RVA: 0x00221074 File Offset: 0x0021F274
		public static double #JOe(double #EOe, double #FOe, double #xOe, double #yOe)
		{
			double num = #EOe * #FOe;
			return (#xOe * #yOe * num * num - 36.0) / (6.0 * (#xOe + #yOe)) - num / Math.Tan(num);
		}
	}
}
