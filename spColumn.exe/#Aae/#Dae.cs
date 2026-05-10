using System;
using #7hc;

namespace #Aae
{
	// Token: 0x02000FB3 RID: 4019
	internal sealed class #Dae : #zae
	{
		// Token: 0x06008BCF RID: 35791 RVA: 0x00071BB4 File Offset: 0x0006FDB4
		public #Dae(int #8W) : base(#8W, null)
		{
		}

		// Token: 0x06008BD0 RID: 35792 RVA: 0x001DD804 File Offset: 0x001DBA04
		public override string CreateDisplayValue(double value)
		{
			string text = base.CreateDisplayValue(value);
			if (string.IsNullOrWhiteSpace(text) || (!text.Contains(#Phc.#3hc(107356879)) && !text.Contains(#Phc.#3hc(107408397))))
			{
				return text;
			}
			text = text.TrimEnd(new char[]
			{
				'0'
			});
			if (text.EndsWith(#Phc.#3hc(107356879)) || text.EndsWith(#Phc.#3hc(107408397)))
			{
				text = text.Replace(#Phc.#3hc(107408397), #Phc.#3hc(107381628)).Replace(#Phc.#3hc(107356879), #Phc.#3hc(107381628));
			}
			return text;
		}
	}
}
