using System;
using System.Runtime.CompilerServices;
using #7hc;
using #9pe;
using #EZ;
using #xZ;
using StructurePoint.Products.Column.Model.Entities;

namespace StructurePoint.Products.Column.Editor.Section.Irregular.Tools.Reinforcement
{
	// Token: 0x02000570 RID: 1392
	[#zZ(typeof(#KZ))]
	internal sealed class IrregularBar : ValidatableBaseEntity, #nqe, #mqe
	{
		// Token: 0x06003170 RID: 12656 RVA: 0x000131A7 File Offset: 0x000113A7
		public IrregularBar()
		{
		}

		// Token: 0x06003171 RID: 12657 RVA: 0x0002BD4E File Offset: 0x00029F4E
		public IrregularBar(Action<IrregularBar> commitCallback)
		{
			this.CommitCallback = commitCallback;
		}

		// Token: 0x06003172 RID: 12658 RVA: 0x0002BD5D File Offset: 0x00029F5D
		public IrregularBar(ReinforcementBar reinforcementBar, Action<IrregularBar> commitCallback) : this(commitCallback)
		{
			this.OriginalBar = reinforcementBar;
			this.#a = reinforcementBar.Area;
			this.#b = reinforcementBar.X;
			this.#c = reinforcementBar.Y;
			this.#d = reinforcementBar.Z;
		}

		// Token: 0x17000FD9 RID: 4057
		// (get) Token: 0x06003173 RID: 12659 RVA: 0x0002BD9D File Offset: 0x00029F9D
		// (set) Token: 0x06003174 RID: 12660 RVA: 0x0002BDA9 File Offset: 0x00029FA9
		public ReinforcementBar OriginalBar { get; set; }

		// Token: 0x17000FDA RID: 4058
		// (get) Token: 0x06003175 RID: 12661 RVA: 0x0002BDBA File Offset: 0x00029FBA
		// (set) Token: 0x06003176 RID: 12662 RVA: 0x000FC604 File Offset: 0x000FA804
		public float Area
		{
			get
			{
				return this.#a;
			}
			set
			{
				bool flag = base.#Z0<float>(ref this.#a, value, #Phc.#3hc(107397869));
				if (flag && base.IsValid)
				{
					this.#TDb();
				}
			}
		}

		// Token: 0x17000FDB RID: 4059
		// (get) Token: 0x06003177 RID: 12663 RVA: 0x0002BDC6 File Offset: 0x00029FC6
		// (set) Token: 0x06003178 RID: 12664 RVA: 0x000FC648 File Offset: 0x000FA848
		public float X
		{
			get
			{
				return this.#b;
			}
			set
			{
				bool flag = base.#Z0<float>(ref this.#b, value, #Phc.#3hc(107408964));
				if (flag && base.IsValid)
				{
					this.#TDb();
				}
			}
		}

		// Token: 0x17000FDC RID: 4060
		// (get) Token: 0x06003179 RID: 12665 RVA: 0x0002BDD2 File Offset: 0x00029FD2
		// (set) Token: 0x0600317A RID: 12666 RVA: 0x000FC68C File Offset: 0x000FA88C
		public float Y
		{
			get
			{
				return this.#c;
			}
			set
			{
				bool flag = base.#Z0<float>(ref this.#c, value, #Phc.#3hc(107408991));
				if (flag && base.IsValid)
				{
					this.#TDb();
				}
			}
		}

		// Token: 0x17000FDD RID: 4061
		// (get) Token: 0x0600317B RID: 12667 RVA: 0x0002BDDE File Offset: 0x00029FDE
		// (set) Token: 0x0600317C RID: 12668 RVA: 0x000FC6D0 File Offset: 0x000FA8D0
		public float Z
		{
			get
			{
				return this.#d;
			}
			set
			{
				bool flag = base.#Z0<float>(ref this.#d, value, #Phc.#3hc(107397860));
				if (flag && base.IsValid)
				{
					this.#TDb();
				}
			}
		}

		// Token: 0x17000FDE RID: 4062
		// (get) Token: 0x0600317D RID: 12669 RVA: 0x0002BDEA File Offset: 0x00029FEA
		// (set) Token: 0x0600317E RID: 12670 RVA: 0x0002BDF6 File Offset: 0x00029FF6
		public Action<IrregularBar> CommitCallback { get; set; }

		// Token: 0x0600317F RID: 12671 RVA: 0x0002BE07 File Offset: 0x0002A007
		public ReinforcementBar #SDb()
		{
			return new ReinforcementBar(this.Area, this.X, this.Y, this.Z);
		}

		// Token: 0x06003180 RID: 12672 RVA: 0x000FC714 File Offset: 0x000FA914
		public void #IH()
		{
			base.#dm(#Phc.#3hc(107397869));
			base.#dm(#Phc.#3hc(107408964));
			base.#dm(#Phc.#3hc(107408991));
		}

		// Token: 0x06003181 RID: 12673 RVA: 0x0002BE32 File Offset: 0x0002A032
		private void #TDb()
		{
			Action<IrregularBar> action = this.CommitCallback;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x0400141A RID: 5146
		private float #a;

		// Token: 0x0400141B RID: 5147
		private float #b;

		// Token: 0x0400141C RID: 5148
		private float #c;

		// Token: 0x0400141D RID: 5149
		private float #d;

		// Token: 0x0400141E RID: 5150
		[CompilerGenerated]
		private ReinforcementBar #e;

		// Token: 0x0400141F RID: 5151
		[CompilerGenerated]
		private Action<IrregularBar> #f;
	}
}
