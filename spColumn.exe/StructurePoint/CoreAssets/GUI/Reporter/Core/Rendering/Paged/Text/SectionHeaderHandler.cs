using System;
using System.Collections.Generic;
using System.Linq;
using #5Fd;
using #7hc;
using Aspose.Words;

namespace StructurePoint.CoreAssets.GUI.Reporter.Core.Rendering.Paged.Text
{
	// Token: 0x02000D89 RID: 3465
	public sealed class SectionHeaderHandler
	{
		// Token: 0x06007D71 RID: 32113 RVA: 0x001B9D4C File Offset: 0x001B7F4C
		public #JGd #KGd(StyleIdentifier #t6c, string #Ae = null)
		{
			this.#NGd(#t6c, #Ae);
			return new #JGd
			{
				HeaderPath = this.#LGd(),
				Number = this.#MGd(),
				Level = this.#a.Count,
				Header = this.#b.Peek()
			};
		}

		// Token: 0x06007D72 RID: 32114 RVA: 0x00065FD2 File Offset: 0x000641D2
		public void #yJ()
		{
			this.#a.Clear();
			this.#b.Clear();
			this.#c.Clear();
		}

		// Token: 0x06007D73 RID: 32115 RVA: 0x001B9DAC File Offset: 0x001B7FAC
		private string #LGd()
		{
			List<string> list = this.#b.Where(new Func<string, bool>(SectionHeaderHandler.<>c.<>9.#4Ud)).ToList<string>();
			list.Reverse();
			return \u0003\u0005.\u0096\u000E(#Phc.#3hc(107382888), list);
		}

		// Token: 0x06007D74 RID: 32116 RVA: 0x001B9E10 File Offset: 0x001B8010
		private string #MGd()
		{
			List<int> list = this.#a.ToList<int>();
			list.Reverse();
			return \u0019.\u0002\u0002(string.Join<int>(#Phc.#3hc(107356879), list), #Phc.#3hc(107281548));
		}

		// Token: 0x06007D75 RID: 32117 RVA: 0x001B9E60 File Offset: 0x001B8060
		private void #NGd(StyleIdentifier #t6c, string #Ae)
		{
			if (!this.#c.Any<StyleIdentifier>())
			{
				for (int i = this.#d; i <= (int)#t6c; i++)
				{
					this.#a.Push(1);
					this.#b.Push((i == (int)#t6c) ? #Ae : string.Empty);
					this.#c.Push((StyleIdentifier)i);
				}
				return;
			}
			StyleIdentifier styleIdentifier = this.#c.Peek();
			if (#t6c == styleIdentifier)
			{
				this.#b.Pop();
				this.#b.Push(#Ae);
				this.#a.Push(this.#a.Pop() + 1);
				return;
			}
			if (#t6c > styleIdentifier)
			{
				for (int j = (int)(styleIdentifier + 1); j <= (int)#t6c; j++)
				{
					this.#a.Push(1);
					this.#c.Push((StyleIdentifier)j);
					this.#b.Push((j == (int)#t6c) ? #Ae : string.Empty);
				}
				return;
			}
			int num = (int)styleIdentifier;
			if (#t6c + 1 == (StyleIdentifier)num)
			{
				this.#a.Pop();
				this.#c.Pop();
				this.#b.Pop();
			}
			else
			{
				while (#t6c < (StyleIdentifier)(num - 1))
				{
					this.#a.Pop();
					num = (int)this.#c.Pop();
					this.#b.Pop();
				}
			}
			this.#b.Pop();
			this.#b.Push(#Ae);
			this.#a.Push(this.#a.Pop() + 1);
		}

		// Token: 0x0400335B RID: 13147
		private readonly Stack<int> #a = new Stack<int>();

		// Token: 0x0400335C RID: 13148
		private readonly Stack<string> #b = new Stack<string>();

		// Token: 0x0400335D RID: 13149
		private readonly Stack<StyleIdentifier> #c = new Stack<StyleIdentifier>();

		// Token: 0x0400335E RID: 13150
		private readonly int #d = 1;
	}
}
