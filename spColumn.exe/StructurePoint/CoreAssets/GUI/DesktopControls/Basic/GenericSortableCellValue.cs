using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Basic
{
	// Token: 0x02000A9C RID: 2716
	public sealed class GenericSortableCellValue : INotifyPropertyChanged, IComparable<GenericSortableCellValue>
	{
		// Token: 0x060058AD RID: 22701 RVA: 0x00049534 File Offset: 0x00047734
		public GenericSortableCellValue(string value)
		{
			this.type = (string.IsNullOrWhiteSpace(value) ? GenericSortableCellValue.ValueType.Null : GenericSortableCellValue.ValueType.String);
			this.stringValue = value;
		}

		// Token: 0x060058AE RID: 22702 RVA: 0x00049555 File Offset: 0x00047755
		public GenericSortableCellValue(double? value)
		{
			this.numericValue = value;
			this.type = ((value != null) ? GenericSortableCellValue.ValueType.Numeric : GenericSortableCellValue.ValueType.Null);
		}

		// Token: 0x1400015C RID: 348
		// (add) Token: 0x060058AF RID: 22703 RVA: 0x0016AAB0 File Offset: 0x00168CB0
		// (remove) Token: 0x060058B0 RID: 22704 RVA: 0x0016AAF4 File Offset: 0x00168CF4
		public event PropertyChangedEventHandler PropertyChanged;

		// Token: 0x060058B1 RID: 22705 RVA: 0x0016AB38 File Offset: 0x00168D38
		public static GenericSortableCellValue Parse(string value)
		{
			if (string.IsNullOrWhiteSpace(value))
			{
				return new GenericSortableCellValue(value);
			}
			double value2;
			if (double.TryParse(value, NumberStyles.Any, CultureInfo.CurrentCulture, out value2))
			{
				return new GenericSortableCellValue(new double?(value2));
			}
			if (double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out value2))
			{
				return new GenericSortableCellValue(new double?(value2));
			}
			return new GenericSortableCellValue(value);
		}

		// Token: 0x060058B2 RID: 22706 RVA: 0x0016ABA8 File Offset: 0x00168DA8
		public int CompareTo(GenericSortableCellValue other)
		{
			if (this == other)
			{
				return 0;
			}
			if (other == null)
			{
				return 1;
			}
			int num = ((int)this.type).CompareTo((int)other.type);
			if (num != 0)
			{
				return num;
			}
			switch (this.type)
			{
			case GenericSortableCellValue.ValueType.Null:
				return 0;
			case GenericSortableCellValue.ValueType.String:
				return string.Compare(this.stringValue, other.stringValue, StringComparison.OrdinalIgnoreCase);
			case GenericSortableCellValue.ValueType.Numeric:
				return Nullable.Compare<double>(this.numericValue, other.numericValue);
			default:
				throw new ArgumentOutOfRangeException();
			}
		}

		// Token: 0x060058B3 RID: 22707 RVA: 0x00049577 File Offset: 0x00047777
		protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
			if (propertyChanged == null)
			{
				return;
			}
			propertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}

		// Token: 0x04002510 RID: 9488
		private readonly GenericSortableCellValue.ValueType type;

		// Token: 0x04002511 RID: 9489
		private readonly string stringValue;

		// Token: 0x04002512 RID: 9490
		private readonly double? numericValue;

		// Token: 0x02000A9D RID: 2717
		private enum ValueType
		{
			// Token: 0x04002515 RID: 9493
			Null,
			// Token: 0x04002516 RID: 9494
			String,
			// Token: 0x04002517 RID: 9495
			Numeric
		}
	}
}
