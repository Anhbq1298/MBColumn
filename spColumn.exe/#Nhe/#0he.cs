using System;
using System.Runtime.CompilerServices;
using StructurePoint.CoreAssets.AppManager.Column.Templates;

namespace #Nhe
{
	// Token: 0x02001097 RID: 4247
	internal sealed class #0he
	{
		// Token: 0x060090F4 RID: 37108 RVA: 0x00074DE5 File Offset: 0x00072FE5
		public #0he(double #1he)
		{
			this.DoubleValue = #1he;
		}

		// Token: 0x060090F5 RID: 37109 RVA: 0x00074DF4 File Offset: 0x00072FF4
		public #0he(int #2he)
		{
			this.IntegerValue = #2he;
		}

		// Token: 0x060090F6 RID: 37110 RVA: 0x00074E03 File Offset: 0x00073003
		public #0he(string #3he)
		{
			this.StringValue = #3he;
		}

		// Token: 0x060090F7 RID: 37111 RVA: 0x00074E12 File Offset: 0x00073012
		public #0he(bool #4he)
		{
			this.BoolValue = #4he;
		}

		// Token: 0x17002A20 RID: 10784
		// (get) Token: 0x060090F8 RID: 37112 RVA: 0x00074E21 File Offset: 0x00073021
		// (set) Token: 0x060090F9 RID: 37113 RVA: 0x00074E29 File Offset: 0x00073029
		public bool BoolValue { get; set; }

		// Token: 0x17002A21 RID: 10785
		// (get) Token: 0x060090FA RID: 37114 RVA: 0x00074E32 File Offset: 0x00073032
		// (set) Token: 0x060090FB RID: 37115 RVA: 0x00074E3A File Offset: 0x0007303A
		public double DoubleValue { get; set; }

		// Token: 0x17002A22 RID: 10786
		// (get) Token: 0x060090FC RID: 37116 RVA: 0x00074E43 File Offset: 0x00073043
		// (set) Token: 0x060090FD RID: 37117 RVA: 0x00074E4B File Offset: 0x0007304B
		public int IntegerValue { get; set; }

		// Token: 0x17002A23 RID: 10787
		// (get) Token: 0x060090FE RID: 37118 RVA: 0x00074E54 File Offset: 0x00073054
		// (set) Token: 0x060090FF RID: 37119 RVA: 0x00074E5C File Offset: 0x0007305C
		public string StringValue { get; set; }

		// Token: 0x06009100 RID: 37120 RVA: 0x001EB354 File Offset: 0x001E9554
		public object #Yhe(TemplateParameterType #Zhe)
		{
			switch (#Zhe)
			{
			case TemplateParameterType.Integer:
			case TemplateParameterType.IntegerList:
				return this.IntegerValue;
			case TemplateParameterType.Double:
			case TemplateParameterType.DoubleList:
				return this.DoubleValue;
			case TemplateParameterType.Boolean:
				return this.BoolValue;
			case TemplateParameterType.BarSize:
				return this.IntegerValue;
			case TemplateParameterType.List:
				return this.StringValue;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}

		// Token: 0x04003CEA RID: 15594
		[CompilerGenerated]
		private bool #a;

		// Token: 0x04003CEB RID: 15595
		[CompilerGenerated]
		private double #b;

		// Token: 0x04003CEC RID: 15596
		[CompilerGenerated]
		private int #c;

		// Token: 0x04003CED RID: 15597
		[CompilerGenerated]
		private string #d;
	}
}
