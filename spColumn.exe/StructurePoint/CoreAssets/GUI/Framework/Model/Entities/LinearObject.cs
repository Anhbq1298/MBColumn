using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using #7hc;
using #8Cc;
using #NWc;
using #TCc;
using #UYd;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace StructurePoint.CoreAssets.GUI.Framework.Model.Entities
{
	// Token: 0x02000C98 RID: 3224
	public sealed class LinearObject : #5Cc
	{
		// Token: 0x0600685B RID: 26715 RVA: 0x00053179 File Offset: 0x00051379
		public LinearObject(#bDc undoManager, #1Wc assignmentsFactory) : base(undoManager)
		{
			this.#c = assignmentsFactory;
			if (this.#c != null)
			{
				this.Assignments = this.#c.#0Wc(base.UndoManager, this);
			}
		}

		// Token: 0x0600685C RID: 26716 RVA: 0x000531A9 File Offset: 0x000513A9
		public LinearObject(#bDc undoManager, #1Wc assignmentsFactory, Point startPoint, Point endPoint) : this(undoManager, assignmentsFactory)
		{
			this.#FXc(startPoint, endPoint);
		}

		// Token: 0x0600685D RID: 26717 RVA: 0x000531BC File Offset: 0x000513BC
		public bool #lwc(Point #doc)
		{
			if (!false)
			{
				int num = PointsConverter.#uC(#doc, this.#b) ? 1 : 0;
				while (num != 0 && 3 != 0)
				{
					int num2 = num = 1;
					if (num2 != 0)
					{
						return num2 != 0;
					}
				}
			}
			return PointsConverter.#uC(#doc, this.#a);
		}

		// Token: 0x0600685E RID: 26718 RVA: 0x00195A8C File Offset: 0x00193C8C
		[SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "To be implemented.")]
		public void #EXc(LinearObject #NNc)
		{
			string #R0d = #Phc.#3hc(107440028);
			Component #x6c = Component.GUIFramework;
			string #Qic = #Phc.#3hc(107439101);
			if (5 != 0)
			{
				#X0d.#V0d(#NNc, #R0d, #x6c, #Qic);
			}
			this.#b = #NNc.StartPoint;
			this.#a = #NNc.EndPoint;
			SegmentData #f = new SegmentData(this.#b, this.#a);
			if (!false)
			{
				this.Segment = #f;
			}
			if (this.Assignments != null)
			{
				#3Wc #3Wc = this.Assignments;
				#3Wc #2Wc = #NNc.Assignments;
				if (!false)
				{
					#3Wc.#mg(#2Wc);
				}
			}
		}

		// Token: 0x0600685F RID: 26719 RVA: 0x000531E3 File Offset: 0x000513E3
		protected void #FXc(Point #Suc, Point #Mzb)
		{
			if (!false)
			{
				this.#b = #Suc;
			}
			do
			{
				this.#a = #Mzb;
				SegmentData #f = new SegmentData(#Suc, #Mzb);
				if (!false)
				{
					this.Segment = #f;
				}
			}
			while (false);
		}

		// Token: 0x17001CE8 RID: 7400
		// (get) Token: 0x06006860 RID: 26720 RVA: 0x0005320D File Offset: 0x0005140D
		// (set) Token: 0x06006861 RID: 26721 RVA: 0x00053215 File Offset: 0x00051415
		public #3Wc Assignments { get; private set; }

		// Token: 0x17001CE9 RID: 7401
		// (get) Token: 0x06006862 RID: 26722 RVA: 0x0005321E File Offset: 0x0005141E
		// (set) Token: 0x06006863 RID: 26723 RVA: 0x00053226 File Offset: 0x00051426
		public SegmentData Segment { get; private set; }

		// Token: 0x17001CEA RID: 7402
		// (get) Token: 0x06006864 RID: 26724 RVA: 0x0005322F File Offset: 0x0005142F
		// (set) Token: 0x06006865 RID: 26725 RVA: 0x00195B14 File Offset: 0x00193D14
		public Point StartPoint
		{
			get
			{
				return this.#b;
			}
			set
			{
				Point point = this.#b;
				Point point2;
				if (-1 != 0)
				{
					point2 = point;
				}
				if (Point.#F3d(point2, value))
				{
					object #Zr = point2;
					object #0r = value;
					string #em = #Phc.#3hc(107453294);
					if (true)
					{
						base.#OCc(#Zr, #0r, #em);
					}
					this.#b = value;
					if (2 != 0)
					{
						SegmentData #f = new SegmentData(this.#b, this.#a);
						if (!false)
						{
							this.Segment = #f;
						}
					}
					object #Zr2 = point2;
					object #0r2 = value;
					string #em2 = #Phc.#3hc(107453294);
					if (-1 != 0)
					{
						base.#PCc(#Zr2, #0r2, #em2);
					}
				}
			}
		}

		// Token: 0x17001CEB RID: 7403
		// (get) Token: 0x06006866 RID: 26726 RVA: 0x00053237 File Offset: 0x00051437
		// (set) Token: 0x06006867 RID: 26727 RVA: 0x00195BAC File Offset: 0x00193DAC
		public Point EndPoint
		{
			get
			{
				return this.#a;
			}
			set
			{
				Point point = this.#a;
				Point point2;
				if (-1 != 0)
				{
					point2 = point;
				}
				if (Point.#F3d(point2, value))
				{
					object #Zr = point2;
					object #0r = value;
					string #em = #Phc.#3hc(107453309);
					if (true)
					{
						base.#OCc(#Zr, #0r, #em);
					}
					this.#a = value;
					if (2 != 0)
					{
						SegmentData #f = new SegmentData(this.#b, this.#a);
						if (!false)
						{
							this.Segment = #f;
						}
					}
					object #Zr2 = point2;
					object #0r2 = value;
					string #em2 = #Phc.#3hc(107453309);
					if (-1 != 0)
					{
						base.#PCc(#Zr2, #0r2, #em2);
					}
				}
			}
		}

		// Token: 0x04002AE7 RID: 10983
		private Point #a;

		// Token: 0x04002AE8 RID: 10984
		private Point #b;

		// Token: 0x04002AE9 RID: 10985
		private readonly #1Wc #c;

		// Token: 0x04002AEA RID: 10986
		[CompilerGenerated]
		private #3Wc #d;

		// Token: 0x04002AEB RID: 10987
		[CompilerGenerated]
		private SegmentData #e;
	}
}
