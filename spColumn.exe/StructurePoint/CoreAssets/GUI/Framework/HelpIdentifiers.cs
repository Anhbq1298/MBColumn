using System;
using System.Diagnostics.CodeAnalysis;
using #7hc;
using #m6c;
using StructurePoint.CoreAssets.GUI.DesktopControls;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace StructurePoint.CoreAssets.GUI.Framework
{
	// Token: 0x02000B38 RID: 2872
	internal sealed class HelpIdentifiers : #w6c<HelpIdentifiers>
	{
		// Token: 0x06005DDA RID: 24026 RVA: 0x0004E399 File Offset: 0x0004C599
		private HelpIdentifiers() : base(Component.GUIFramework)
		{
		}

		// Token: 0x17001AAD RID: 6829
		// (get) Token: 0x06005DDB RID: 24027 RVA: 0x0004E3A3 File Offset: 0x0004C5A3
		public static HelpID ToolInsertCustomNode
		{
			get
			{
				return #w6c<HelpIdentifiers>.#s6c(#Phc.#3hc(107420223));
			}
		}

		// Token: 0x17001AAE RID: 6830
		// (get) Token: 0x06005DDC RID: 24028 RVA: 0x0004E3B4 File Offset: 0x0004C5B4
		public static HelpID ToolInsertNodeOnEdge
		{
			get
			{
				return #w6c<HelpIdentifiers>.#s6c(#Phc.#3hc(107420162));
			}
		}

		// Token: 0x17001AAF RID: 6831
		// (get) Token: 0x06005DDD RID: 24029 RVA: 0x0004E3C5 File Offset: 0x0004C5C5
		public static HelpID ToolDrawCircleOnDiameter
		{
			get
			{
				return #w6c<HelpIdentifiers>.#s6c(#Phc.#3hc(107420645));
			}
		}

		// Token: 0x17001AB0 RID: 6832
		// (get) Token: 0x06005DDE RID: 24030 RVA: 0x0004E3D6 File Offset: 0x0004C5D6
		public static HelpID ToolDrawCircleWithTangentPoints
		{
			get
			{
				return #w6c<HelpIdentifiers>.#s6c(#Phc.#3hc(107420612));
			}
		}

		// Token: 0x17001AB1 RID: 6833
		// (get) Token: 0x06005DDF RID: 24031 RVA: 0x0004E3E7 File Offset: 0x0004C5E7
		public static HelpID ToolDrawCircle
		{
			get
			{
				return #w6c<HelpIdentifiers>.#s6c(#Phc.#3hc(107420599));
			}
		}

		// Token: 0x17001AB2 RID: 6834
		// (get) Token: 0x06005DE0 RID: 24032 RVA: 0x0004E3F8 File Offset: 0x0004C5F8
		public static HelpID ToolDrawLinearObject
		{
			get
			{
				return #w6c<HelpIdentifiers>.#s6c(#Phc.#3hc(107420546));
			}
		}

		// Token: 0x17001AB3 RID: 6835
		// (get) Token: 0x06005DE1 RID: 24033 RVA: 0x0004E409 File Offset: 0x0004C609
		public static HelpID ToolDrawPolygon
		{
			get
			{
				return #w6c<HelpIdentifiers>.#s6c(#Phc.#3hc(107420517));
			}
		}

		// Token: 0x17001AB4 RID: 6836
		// (get) Token: 0x06005DE2 RID: 24034 RVA: 0x0004E41A File Offset: 0x0004C61A
		public static HelpID ToolDrawRectangle
		{
			get
			{
				return #w6c<HelpIdentifiers>.#s6c(#Phc.#3hc(107420528));
			}
		}

		// Token: 0x17001AB5 RID: 6837
		// (get) Token: 0x06005DE3 RID: 24035 RVA: 0x0004E42B File Offset: 0x0004C62B
		public static HelpID ToolFillGridWithShape
		{
			get
			{
				return #w6c<HelpIdentifiers>.#s6c(#Phc.#3hc(107420503));
			}
		}

		// Token: 0x17001AB6 RID: 6838
		// (get) Token: 0x06005DE4 RID: 24036 RVA: 0x0004E43C File Offset: 0x0004C63C
		public static HelpID ToolCircleGrouping
		{
			get
			{
				return #w6c<HelpIdentifiers>.#s6c(#Phc.#3hc(107420474));
			}
		}

		// Token: 0x17001AB7 RID: 6839
		// (get) Token: 0x06005DE5 RID: 24037 RVA: 0x0004E44D File Offset: 0x0004C64D
		public static HelpID ToolModifyNode
		{
			get
			{
				return #w6c<HelpIdentifiers>.#s6c(#Phc.#3hc(107420417));
			}
		}

		// Token: 0x17001AB8 RID: 6840
		// (get) Token: 0x06005DE6 RID: 24038 RVA: 0x0004E45E File Offset: 0x0004C65E
		public static HelpID ToolModifyShape
		{
			get
			{
				return #w6c<HelpIdentifiers>.#s6c(#Phc.#3hc(107419884));
			}
		}

		// Token: 0x17001AB9 RID: 6841
		// (get) Token: 0x06005DE7 RID: 24039 RVA: 0x0004E46F File Offset: 0x0004C66F
		public static HelpID ToolSplitPolygon
		{
			get
			{
				return #w6c<HelpIdentifiers>.#s6c(#Phc.#3hc(107419895));
			}
		}

		// Token: 0x17001ABA RID: 6842
		// (get) Token: 0x06005DE8 RID: 24040 RVA: 0x0004E480 File Offset: 0x0004C680
		public static HelpID ToolInsertDiagonalGridLine
		{
			get
			{
				return #w6c<HelpIdentifiers>.#s6c(#Phc.#3hc(107419870));
			}
		}

		// Token: 0x17001ABB RID: 6843
		// (get) Token: 0x06005DE9 RID: 24041 RVA: 0x0004E491 File Offset: 0x0004C691
		public static HelpID ToolInsertHorizontalGridLine
		{
			get
			{
				return #w6c<HelpIdentifiers>.#s6c(#Phc.#3hc(107419833));
			}
		}

		// Token: 0x17001ABC RID: 6844
		// (get) Token: 0x06005DEA RID: 24042 RVA: 0x0004E4A2 File Offset: 0x0004C6A2
		public static HelpID ToolInsertVerticalGridLine
		{
			get
			{
				return #w6c<HelpIdentifiers>.#s6c(#Phc.#3hc(107419792));
			}
		}

		// Token: 0x17001ABD RID: 6845
		// (get) Token: 0x06005DEB RID: 24043 RVA: 0x0004E4B3 File Offset: 0x0004C6B3
		public static HelpID ToolModifyGridLine
		{
			get
			{
				return #w6c<HelpIdentifiers>.#s6c(#Phc.#3hc(107419723));
			}
		}

		// Token: 0x17001ABE RID: 6846
		// (get) Token: 0x06005DEC RID: 24044 RVA: 0x0004E4C4 File Offset: 0x0004C6C4
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		public static HelpID LocalPreciseInput
		{
			get
			{
				return #w6c<HelpIdentifiers>.#s6c(#Phc.#3hc(107419730));
			}
		}

		// Token: 0x17001ABF RID: 6847
		// (get) Token: 0x06005DED RID: 24045 RVA: 0x0004E4D5 File Offset: 0x0004C6D5
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		public static HelpID GlobalPreciseInput
		{
			get
			{
				return #w6c<HelpIdentifiers>.#s6c(#Phc.#3hc(107419705));
			}
		}

		// Token: 0x17001AC0 RID: 6848
		// (get) Token: 0x06005DEE RID: 24046 RVA: 0x0004E4E6 File Offset: 0x0004C6E6
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		public static HelpID PolarPreciseInput
		{
			get
			{
				return #w6c<HelpIdentifiers>.#s6c(#Phc.#3hc(107419648));
			}
		}
	}
}
