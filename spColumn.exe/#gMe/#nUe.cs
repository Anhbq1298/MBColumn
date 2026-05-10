using System;
using #hZe;
using #y6e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Input;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.Geometry;

namespace #gMe
{
	// Token: 0x020012DE RID: 4830
	internal sealed class #nUe
	{
		// Token: 0x0600A16E RID: 41326 RVA: 0x0007E97E File Offset: 0x0007CB7E
		public #nUe(InputModel #hMe, RuntimeModel #iMe, DepthComputation #ZTe)
		{
			this.#b = #hMe;
			this.#c = #iMe;
			this.#a = #ZTe;
		}

		// Token: 0x0600A16F RID: 41327 RVA: 0x002279D4 File Offset: 0x00225BD4
		public void #Zub(float #Udb)
		{
			#Udb += 180f;
			if (this.#b.Options.SectionType != #G6e.#b)
			{
				#nUe.#mUe(#Udb, this.#c.Solids);
				#nUe.#mUe(#Udb, this.#c.Openings);
			}
			#nUe.#lUe(#Udb, this.#c.ReinforcementBars);
			#nUe.#kUe(#Udb, this.#c.GeometryProperties);
			this.#a.#gOe(#C6e.#d);
		}

		// Token: 0x0600A170 RID: 41328 RVA: 0x0007E99B File Offset: 0x0007CB9B
		private static void #kUe(float #Udb, #x0e #VIb)
		{
			#VIb.#r0e(#Udb);
		}

		// Token: 0x0600A171 RID: 41329 RVA: 0x0007E9A4 File Offset: 0x0007CBA4
		private static void #lUe(float #Udb, #K1e #JQe)
		{
			#JQe.#cBb(#Udb);
		}

		// Token: 0x0600A172 RID: 41330 RVA: 0x0007E9AD File Offset: 0x0007CBAD
		private static void #mUe(float #Udb, Figures #5Se)
		{
			#5Se.#x1e(#Udb);
		}

		// Token: 0x040046AA RID: 18090
		private readonly DepthComputation #a;

		// Token: 0x040046AB RID: 18091
		private readonly InputModel #b;

		// Token: 0x040046AC RID: 18092
		private readonly RuntimeModel #c;
	}
}
