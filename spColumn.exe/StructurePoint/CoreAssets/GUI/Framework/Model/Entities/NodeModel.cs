using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using #7hc;
using #8Cc;
using #kXc;
using #NWc;
using #TCc;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Infrastructure.Extensions;

namespace StructurePoint.CoreAssets.GUI.Framework.Model.Entities
{
	// Token: 0x02000C9A RID: 3226
	[DebuggerDisplay("Location: {Location} | Type: {NodeType}")]
	public sealed class NodeModel : #3Cc
	{
		// Token: 0x06006868 RID: 26728 RVA: 0x0005323F File Offset: 0x0005143F
		public NodeModel(#bDc undoManager, #1Wc assignmentsFactory, Point location, #IXc nodeType) : base(undoManager)
		{
			this.#a = location;
			this.#b = nodeType;
			if (assignmentsFactory != null)
			{
				this.Assignments = assignmentsFactory.#ZWc(base.UndoManager, this);
			}
		}

		// Token: 0x17001CEC RID: 7404
		// (get) Token: 0x06006869 RID: 26729 RVA: 0x0005326D File Offset: 0x0005146D
		// (set) Token: 0x0600686A RID: 26730 RVA: 0x00053275 File Offset: 0x00051475
		public #6Wc Assignments { get; private set; }

		// Token: 0x17001CED RID: 7405
		// (get) Token: 0x0600686B RID: 26731 RVA: 0x0005327E File Offset: 0x0005147E
		// (set) Token: 0x0600686C RID: 26732 RVA: 0x00195C44 File Offset: 0x00193E44
		public #IXc NodeType
		{
			get
			{
				return this.#b;
			}
			set
			{
				#IXc #IXc = this.#b;
				#IXc #IXc2;
				if (!false)
				{
					#IXc2 = #IXc;
				}
				if (#IXc2 != value)
				{
					object #Zr = #IXc2;
					object #0r = value;
					string #em = #Phc.#3hc(107439016);
					if (!false)
					{
						this.#OCc(#Zr, #0r, #em);
					}
					this.#b = value;
					object #Zr2 = #IXc2;
					object #0r2 = value;
					string #em2 = #Phc.#3hc(107439016);
					if (7 != 0)
					{
						this.#PCc(#Zr2, #0r2, #em2);
					}
				}
			}
		}

		// Token: 0x17001CEE RID: 7406
		// (get) Token: 0x0600686D RID: 26733 RVA: 0x00053286 File Offset: 0x00051486
		// (set) Token: 0x0600686E RID: 26734 RVA: 0x00195CB4 File Offset: 0x00193EB4
		public Point Location
		{
			get
			{
				return this.#a;
			}
			set
			{
				if (Point.#F3d(this.#a, value))
				{
					Point point = this.#a;
					Point point2;
					if (2 != 0)
					{
						point2 = point;
					}
					object #Zr = point2;
					object #0r = value;
					string #em = #Phc.#3hc(107439035);
					if (!false)
					{
						this.#OCc(#Zr, #0r, #em);
					}
					this.#a = value;
					object #Zr2 = point2;
					object #0r2 = value;
					string #em2 = #Phc.#3hc(107439035);
					if (5 != 0)
					{
						this.#PCc(#Zr2, #0r2, #em2);
					}
					string propertyName = #Phc.#3hc(107439035);
					if (6 != 0)
					{
						base.RaisePropertyChanged(propertyName);
					}
					Expression<Func<double>> expression = () => this.#LXc;
					if (!false)
					{
						base.RaisePropertyChanged<double>(expression);
					}
					Expression<Func<double>> expression2 = () => this.#NXc;
					if (!false)
					{
						base.RaisePropertyChanged<double>(expression2);
					}
				}
			}
		}

		// Token: 0x17001CEF RID: 7407
		// (get) Token: 0x0600686F RID: 26735 RVA: 0x00195DD8 File Offset: 0x00193FD8
		// (set) Token: 0x06006870 RID: 26736 RVA: 0x00195DFC File Offset: 0x00193FFC
		public double LocationX
		{
			get
			{
				Point point = this.Location;
				Point point2;
				if (!false)
				{
					point2 = point;
				}
				return point2.X;
			}
			set
			{
				for (;;)
				{
					Point point = this.Location;
					Point point2;
					if (!false)
					{
						point2 = point;
					}
					if (4 == 0 || point2.X != value)
					{
						string propertyName = #Phc.#3hc(107438990);
						if (3 != 0)
						{
							base.RaisePropertyChanging(propertyName);
						}
						Point point3 = this.Location;
						if (!false)
						{
							point2 = point3;
						}
						Point #f = new Point(value, point2.Y);
						if (false)
						{
							goto IL_44;
						}
						this.Location = #f;
						goto IL_44;
					}
					IL_54:
					if (false)
					{
						continue;
					}
					if (!false)
					{
						break;
					}
					IL_44:
					string propertyName2 = #Phc.#3hc(107438990);
					if (false)
					{
						goto IL_54;
					}
					base.RaisePropertyChanged(propertyName2);
					goto IL_54;
				}
			}
		}

		// Token: 0x17001CF0 RID: 7408
		// (get) Token: 0x06006871 RID: 26737 RVA: 0x00195E80 File Offset: 0x00194080
		// (set) Token: 0x06006872 RID: 26738 RVA: 0x00195EA4 File Offset: 0x001940A4
		public double LocationY
		{
			get
			{
				Point point = this.Location;
				Point point2;
				if (!false)
				{
					point2 = point;
				}
				return point2.Y;
			}
			set
			{
				for (;;)
				{
					Point point = this.Location;
					Point point2;
					if (!false)
					{
						point2 = point;
					}
					if (4 == 0 || point2.Y != value)
					{
						string propertyName = #Phc.#3hc(107438977);
						if (3 != 0)
						{
							base.RaisePropertyChanging(propertyName);
						}
						Point point3 = this.Location;
						if (!false)
						{
							point2 = point3;
						}
						Point #f = new Point(point2.X, value);
						if (false)
						{
							goto IL_44;
						}
						this.Location = #f;
						goto IL_44;
					}
					IL_54:
					if (false)
					{
						continue;
					}
					if (!false)
					{
						break;
					}
					IL_44:
					string propertyName2 = #Phc.#3hc(107438977);
					if (false)
					{
						goto IL_54;
					}
					base.RaisePropertyChanged(propertyName2);
					goto IL_54;
				}
			}
		}

		// Token: 0x06006873 RID: 26739 RVA: 0x00195F28 File Offset: 0x00194128
		public static IList<NodeModel> #PXc(IList<Point> #BP, #bDc #DJ, #1Wc #2Nc)
		{
			NodeModel.#HUb #HUb = new NodeModel.#HUb();
			NodeModel.#HUb #HUb2;
			if (!false)
			{
				#HUb2 = #HUb;
			}
			do
			{
				#HUb2.#a = #DJ;
			}
			while (7 == 0);
			#HUb2.#b = #2Nc;
			string #R0d = #Phc.#3hc(107358670);
			Component #x6c = Component.GUIFramework;
			string #Qic = #Phc.#3hc(107438996);
			if (!false)
			{
				#X0d.#V0d(#BP, #R0d, #x6c, #Qic);
			}
			object #Rf = #HUb2.#a;
			string #R0d2 = #Phc.#3hc(107404911);
			Component #x6c2 = Component.GUIFramework;
			string #Qic2 = #Phc.#3hc(107438943);
			if (8 != 0)
			{
				#X0d.#V0d(#Rf, #R0d2, #x6c2, #Qic2);
			}
			return #BP.Distinct<Point>().Select(new Func<Point, NodeModel>(#HUb2.#nbd)).ToList<NodeModel>();
		}

		// Token: 0x06006874 RID: 26740 RVA: 0x0005328E File Offset: 0x0005148E
		public NodeModel #EA()
		{
			NodeModel nodeModel = new NodeModel(base.UndoManager, null, this.#a, this.#b);
			#6Wc #f = (this.Assignments != null) ? this.Assignments.#EA() : null;
			if (!false)
			{
				nodeModel.Assignments = #f;
			}
			return nodeModel;
		}

		// Token: 0x06006875 RID: 26741 RVA: 0x000532CB File Offset: 0x000514CB
		public string #h()
		{
			return #Phc.#3hc(107438858).#D2d(new object[]
			{
				this.LocationX,
				this.LocationY
			});
		}

		// Token: 0x04002AEF RID: 10991
		private Point #a;

		// Token: 0x04002AF0 RID: 10992
		private #IXc #b;

		// Token: 0x04002AF1 RID: 10993
		[CompilerGenerated]
		private #6Wc #c;

		// Token: 0x02000C9B RID: 3227
		[CompilerGenerated]
		private sealed class #HUb
		{
			// Token: 0x06006877 RID: 26743 RVA: 0x000532FE File Offset: 0x000514FE
			internal NodeModel #nbd(Point #Rf)
			{
				NodeModel nodeModel = new NodeModel(this.#a, this.#b, #Rf, #IXc.#b);
				bool #f = false;
				if (true)
				{
					nodeModel.UndoEnabled = #f;
				}
				return nodeModel;
			}

			// Token: 0x04002AF2 RID: 10994
			public #bDc #a;

			// Token: 0x04002AF3 RID: 10995
			public #1Wc #b;
		}
	}
}
