using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;

namespace #LQc
{
	// Token: 0x02000C65 RID: 3173
	internal sealed class #gTc : #fTc
	{
		// Token: 0x06006663 RID: 26211 RVA: 0x0005252E File Offset: 0x0005072E
		public void #9Sc(double #aTc, Action #bTc)
		{
			if (#bTc == null)
			{
				return;
			}
			if (7 != 0)
			{
				LayoutHelper.DelayOperation(#aTc, #bTc);
			}
		}

		// Token: 0x06006664 RID: 26212 RVA: 0x00052542 File Offset: 0x00050742
		public string #cTc(string #So, int #dTc)
		{
			return LayoutHelper.CompactPath(#So, #dTc);
		}

		// Token: 0x06006665 RID: 26213 RVA: 0x00190658 File Offset: 0x0018E858
		public bool #eTc<#Fu>(string #wy)
		{
			#gTc<#Fu>.#Xad #Xad2;
			for (;;)
			{
				#gTc<#Fu>.#Xad #Xad = new #gTc<!!0>.#Xad();
				if (7 != 0)
				{
					#Xad2 = #Xad;
				}
				while (!false)
				{
					#Xad2.#b = #wy;
					if (4 != 0)
					{
						goto Block_1;
					}
				}
			}
			Block_1:
			#Xad2.#a = false;
			Application.Current.Dispatcher.Invoke<bool>(new Func<bool>(#Xad2.#Vad));
			return #Xad2.#a;
		}

		// Token: 0x02000C66 RID: 3174
		[CompilerGenerated]
		private sealed class #Xad<#Fu>
		{
			// Token: 0x06006668 RID: 26216 RVA: 0x001906A8 File Offset: 0x0018E8A8
			internal bool #Vad()
			{
				bool flag;
				if (!string.IsNullOrWhiteSpace(this.#b))
				{
					IEnumerable<Window> source = Application.Current.Windows.OfType<Window>();
					Func<Window, bool> predicate;
					if ((predicate = this.#c) == null)
					{
						predicate = (this.#c = new Func<Window, bool>(this.#Wad));
					}
					flag = source.Where(predicate).OfType<#Fu>().Any<#Fu>();
				}
				else
				{
					flag = Application.Current.Windows.OfType<#Fu>().Any<#Fu>();
				}
				return this.#a = flag;
			}

			// Token: 0x06006669 RID: 26217 RVA: 0x0005254B File Offset: 0x0005074B
			internal bool #Wad(Window #u0b)
			{
				return string.Equals(#u0b.Name, this.#b);
			}

			// Token: 0x04002A31 RID: 10801
			public bool #a;

			// Token: 0x04002A32 RID: 10802
			public string #b;

			// Token: 0x04002A33 RID: 10803
			public Func<Window, bool> #c;
		}
	}
}
