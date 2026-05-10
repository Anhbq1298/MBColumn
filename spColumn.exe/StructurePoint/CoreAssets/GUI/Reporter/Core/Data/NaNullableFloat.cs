using System;
using System.Diagnostics;
using #7hc;

namespace StructurePoint.CoreAssets.GUI.Reporter.Core.Data
{
	// Token: 0x02000E24 RID: 3620
	[DebuggerDisplay("NA: {IsNa}, Value: {Value}")]
	[Serializable]
	public sealed class NaNullableFloat
	{
		// Token: 0x06008209 RID: 33289 RVA: 0x00069E05 File Offset: 0x00068005
		public NaNullableFloat(float? value)
		{
			this.IsNa = false;
			this.Value = value;
		}

		// Token: 0x0600820A RID: 33290 RVA: 0x00069E2B File Offset: 0x0006802B
		public NaNullableFloat(float? value, string defaultFloatFormat)
		{
			this.IsNa = false;
			this.Value = value;
			this.DefaultFloatFormat = defaultFloatFormat;
		}

		// Token: 0x0600820B RID: 33291 RVA: 0x00069E58 File Offset: 0x00068058
		public NaNullableFloat()
		{
			this.IsNa = true;
		}

		// Token: 0x170026D1 RID: 9937
		// (get) Token: 0x0600820C RID: 33292 RVA: 0x00069E77 File Offset: 0x00068077
		// (set) Token: 0x0600820D RID: 33293 RVA: 0x00069E83 File Offset: 0x00068083
		public bool IsNa { get; private set; }

		// Token: 0x170026D2 RID: 9938
		// (get) Token: 0x0600820E RID: 33294 RVA: 0x00069E94 File Offset: 0x00068094
		// (set) Token: 0x0600820F RID: 33295 RVA: 0x00069EA0 File Offset: 0x000680A0
		public float? Value { get; private set; }

		// Token: 0x06008210 RID: 33296 RVA: 0x00069EB1 File Offset: 0x000680B1
		public static NaNullableFloat #FSd()
		{
			return new NaNullableFloat();
		}

		// Token: 0x06008211 RID: 33297 RVA: 0x00069EBC File Offset: 0x000680BC
		public string #Qhc()
		{
			return this.#Qhc(this.DefaultFloatFormat);
		}

		// Token: 0x06008212 RID: 33298 RVA: 0x001C36FC File Offset: 0x001C18FC
		public string #Qhc(string #GSd)
		{
			if (#GSd == null)
			{
				#GSd = this.DefaultFloatFormat;
			}
			if (this.IsNa)
			{
				return #Phc.#3hc(107253318);
			}
			if (this.Value == null)
			{
				return string.Empty;
			}
			return this.Value.Value.ToString(#GSd, \u0097\u0002.\u000E\u0006());
		}

		// Token: 0x04003558 RID: 13656
		private const string NaLabel = "(N/A)";

		// Token: 0x04003559 RID: 13657
		public readonly string DefaultFloatFormat = #Phc.#3hc(107408811);
	}
}
