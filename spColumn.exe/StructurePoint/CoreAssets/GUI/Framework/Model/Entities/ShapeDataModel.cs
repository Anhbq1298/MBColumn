using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using #7hc;
using #8Cc;
using #jDc;
using #klc;
using #NWc;
using #UYd;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.GUI.Framework.Collections;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace StructurePoint.CoreAssets.GUI.Framework.Model.Entities
{
	// Token: 0x02000C9C RID: 3228
	public sealed class ShapeDataModel : ShapeData, INotifyPropertyChanged, INotifyPropertyChanging, #9Cc
	{
		// Token: 0x06006878 RID: 26744 RVA: 0x00195FC0 File Offset: 0x001941C0
		public ShapeDataModel(#bDc undoManager, PolygonData polygon, #1Wc assignmentsFactory) : base(polygon)
		{
			#X0d.#V0d(undoManager, #Phc.#3hc(107404911), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUIFramework, #Phc.#3hc(107438865));
			this.UndoManager = undoManager;
			this.AssignmentsFactory = assignmentsFactory;
			this.#RXc(null);
			this.#SXc<PolygonData>(this.#a);
			this.UndoEnabled = true;
		}

		// Token: 0x06006879 RID: 26745 RVA: 0x00196024 File Offset: 0x00194224
		public ShapeDataModel(#bDc undoManager, PolygonData polygon, #1Wc assignmentsFactory, #jlc determineRelationships) : base(polygon, determineRelationships)
		{
			#X0d.#V0d(undoManager, #Phc.#3hc(107404911), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUIFramework, #Phc.#3hc(107438865));
			this.UndoManager = undoManager;
			this.AssignmentsFactory = assignmentsFactory;
			this.#RXc(null);
			this.#SXc<PolygonData>(this.#a);
			this.UndoEnabled = true;
		}

		// Token: 0x0600687A RID: 26746 RVA: 0x0019608C File Offset: 0x0019428C
		public ShapeDataModel(#bDc undoManager, IEnumerable<PolygonData> polygons, #1Wc assignmentsFactory) : base(polygons)
		{
			#X0d.#V0d(undoManager, #Phc.#3hc(107404911), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUIFramework, #Phc.#3hc(107438300));
			this.UndoManager = undoManager;
			this.AssignmentsFactory = assignmentsFactory;
			this.#RXc(null);
			this.#SXc<PolygonData>(this.#a);
			this.UndoEnabled = true;
		}

		// Token: 0x0600687B RID: 26747 RVA: 0x001960F0 File Offset: 0x001942F0
		public ShapeDataModel(#bDc undoManager, IEnumerable<PolygonData> polygons, #1Wc assignmentsFactory, #jlc determineRelationships) : base(polygons, determineRelationships)
		{
			#X0d.#V0d(undoManager, #Phc.#3hc(107404911), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUIFramework, #Phc.#3hc(107438300));
			this.UndoManager = undoManager;
			this.AssignmentsFactory = assignmentsFactory;
			this.#RXc(null);
			this.#SXc<PolygonData>(this.#a);
			this.UndoEnabled = true;
		}

		// Token: 0x0600687C RID: 26748 RVA: 0x00196158 File Offset: 0x00194358
		public ShapeDataModel(#bDc undoManager, ShapeData shape, #1Wc assignmentsFactory) : base(shape)
		{
			#X0d.#V0d(undoManager, #Phc.#3hc(107404911), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUIFramework, #Phc.#3hc(107438215));
			#X0d.#V0d(shape, #Phc.#3hc(107371527), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUIFramework, #Phc.#3hc(107438194));
			this.UndoManager = undoManager;
			this.AssignmentsFactory = assignmentsFactory;
			this.#RXc(null);
			this.#SXc<PolygonData>(this.#a);
			this.UndoEnabled = true;
		}

		// Token: 0x0600687D RID: 26749 RVA: 0x001961D8 File Offset: 0x001943D8
		public ShapeDataModel(#bDc undoManager, ShapeData shape, #1Wc assignmentsFactory, #jlc determineRelationships) : base(shape, determineRelationships)
		{
			#X0d.#V0d(undoManager, #Phc.#3hc(107404911), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUIFramework, #Phc.#3hc(107438215));
			#X0d.#V0d(shape, #Phc.#3hc(107371527), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUIFramework, #Phc.#3hc(107438194));
			this.UndoManager = undoManager;
			this.AssignmentsFactory = assignmentsFactory;
			this.#RXc(null);
			this.#SXc<PolygonData>(this.#a);
			this.UndoEnabled = true;
		}

		// Token: 0x0600687E RID: 26750 RVA: 0x00053321 File Offset: 0x00051521
		public ShapeDataModel(#bDc undoManager, ShapeDataModel shape, #1Wc assignmentsFactory) : this(undoManager, shape, assignmentsFactory)
		{
			#X0d.#V0d(shape, #Phc.#3hc(107371527), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUIFramework, #Phc.#3hc(107438141));
			this.#RXc(shape.Assignments);
		}

		// Token: 0x0600687F RID: 26751 RVA: 0x00053354 File Offset: 0x00051554
		public ShapeDataModel(#bDc undoManager, ShapeDataModel shape, #1Wc assignmentsFactory, #jlc determineRelationships) : this(undoManager, shape, assignmentsFactory, determineRelationships)
		{
			#X0d.#V0d(shape, #Phc.#3hc(107371527), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUIFramework, #Phc.#3hc(107438141));
			this.#RXc(shape.Assignments);
		}

		// Token: 0x06006880 RID: 26752 RVA: 0x00053389 File Offset: 0x00051589
		public ShapeDataModel(#bDc undoManager, ShapeDataModel shape, #1Wc assignmentsFactory, bool undoEnabled) : this(undoManager, shape, assignmentsFactory)
		{
			#X0d.#V0d(shape, #Phc.#3hc(107371527), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUIFramework, #Phc.#3hc(107438568));
			this.UndoEnabled = undoEnabled;
			this.#RXc(shape.Assignments);
		}

		// Token: 0x06006881 RID: 26753 RVA: 0x000533C4 File Offset: 0x000515C4
		public ShapeDataModel(#bDc undoManager, ShapeDataModel shape, #1Wc assignmentsFactory, bool undoEnabled, #jlc enableDetermineRelationships) : this(undoManager, shape, assignmentsFactory, enableDetermineRelationships)
		{
			#X0d.#V0d(shape, #Phc.#3hc(107371527), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUIFramework, #Phc.#3hc(107438568));
			this.UndoEnabled = undoEnabled;
			this.#RXc(shape.Assignments);
		}

		// Token: 0x06006882 RID: 26754 RVA: 0x00053401 File Offset: 0x00051601
		public void #kib()
		{
			this.#g = null;
			this.#f = null;
		}

		// Token: 0x06006883 RID: 26755 RVA: 0x0019625C File Offset: 0x0019445C
		public override void #pR(IEnumerable<PolygonData> #9wc)
		{
			for (;;)
			{
				IList<PolygonData> list;
				if (false || (list = (#9wc as IList<PolygonData>)) == null)
				{
					goto IL_0D;
				}
				IL_13:
				IList<PolygonData> list2;
				if (!false)
				{
					list2 = list;
				}
				if (7 == 0)
				{
					continue;
				}
				IEnumerable<PolygonData> #9wc2 = list2;
				if (!false)
				{
					base.#pR(#9wc2);
				}
				if (!false)
				{
					break;
				}
				IL_0D:
				list = #9wc.ToList<PolygonData>();
				goto IL_13;
			}
		}

		// Token: 0x06006884 RID: 26756 RVA: 0x00196298 File Offset: 0x00194498
		[SuppressMessage("Microsoft.Naming", "CA1725:ParameterNamesShouldMatchBaseDeclaration", MessageId = "1#")]
		public override void #axc(int #4jb, PolygonData #JP)
		{
			string #R0d = #Phc.#3hc(107399958);
			StructurePoint.CoreAssets.Infrastructure.Exceptions.Component #x6c = StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUIFramework;
			string #Qic = #Phc.#3hc(107438547);
			if (3 != 0)
			{
				#X0d.#V0d(#JP, #R0d, #x6c, #Qic);
			}
			if (#4jb >= 0 && #4jb < this.#a.Count)
			{
				Collection<PolygonData> collection = this.#a;
				if (8 != 0)
				{
					collection[#4jb] = #JP;
				}
			}
			if (4 != 0)
			{
				base.#axc(#4jb, #JP);
			}
		}

		// Token: 0x06006885 RID: 26757 RVA: 0x00196304 File Offset: 0x00194504
		public void #axc(int #4jb, PolygonData #JP, bool #bxc)
		{
			string #R0d = #Phc.#3hc(107399958);
			StructurePoint.CoreAssets.Infrastructure.Exceptions.Component #x6c = StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUIFramework;
			string #Qic = #Phc.#3hc(107438494);
			if (!false)
			{
				#X0d.#V0d(#JP, #R0d, #x6c, #Qic);
			}
			bool flag = #4jb != 0;
			int num = #4jb;
			for (;;)
			{
				if (8 != 0)
				{
					if (num < 0 || #4jb >= this.#a.Count)
					{
						goto IL_41;
					}
					Collection<PolygonData> collection = this.#a;
					if (-1 == 0)
					{
						goto IL_41;
					}
					collection[#4jb] = #JP;
					goto IL_41;
				}
				IL_4B:
				if (false)
				{
					continue;
				}
				if (flag && !false)
				{
					base.#ixc();
				}
				if (!false)
				{
					break;
				}
				IL_41:
				if (!false)
				{
					base.#axc(#4jb, #JP);
				}
				flag = #bxc;
				num = (#bxc ? 1 : 0);
				goto IL_4B;
			}
		}

		// Token: 0x06006886 RID: 26758 RVA: 0x00196388 File Offset: 0x00194588
		public override void #pR(IEnumerable<PolygonData> #9wc, bool #bxc)
		{
			IList<PolygonData> list;
			if (false || -1 == 0 || (list = (#9wc as IList<PolygonData>)) == null)
			{
				list = #9wc.ToList<PolygonData>();
			}
			IList<PolygonData> list2;
			if (!false)
			{
				list2 = list;
			}
			IEnumerable<PolygonData> #9wc2 = list2;
			if (7 != 0)
			{
				base.#pR(#9wc2, #bxc);
			}
			if (!#bxc)
			{
				IEnumerator<PolygonData> enumerator = list2.GetEnumerator();
				IEnumerator<PolygonData> enumerator2;
				if (!false)
				{
					enumerator2 = enumerator;
				}
				try
				{
					while (enumerator2.MoveNext())
					{
						PolygonData polygonData = enumerator2.Current;
						PolygonData polygonData2;
						if (!false)
						{
							polygonData2 = polygonData;
						}
						Collection<PolygonData> collection = this.#a;
						PolygonData item = polygonData2;
						if (3 != 0)
						{
							collection.Add(item);
						}
					}
				}
				finally
				{
					if (enumerator2 != null)
					{
						enumerator2.Dispose();
					}
				}
			}
		}

		// Token: 0x06006887 RID: 26759 RVA: 0x00053411 File Offset: 0x00051611
		public override void #yl()
		{
			if (!false)
			{
				base.#yl();
			}
			Collection<PolygonData> collection = this.#a;
			if (!false)
			{
				collection.Clear();
			}
		}

		// Token: 0x06006888 RID: 26760 RVA: 0x00196418 File Offset: 0x00194618
		public bool #e(ShapeDataModel #QXc)
		{
			do
			{
				if (#QXc != null)
				{
					int num = this.#a.Count;
					while (num == #QXc.#a.Count)
					{
						if (this.Assignments != null)
						{
							goto IL_28;
						}
						goto IL_40;
						IL_73:
						if (false)
						{
							continue;
						}
						if (false)
						{
							goto IL_7D;
						}
						int num3;
						int num2 = num3;
						goto IL_7D;
						IL_28:
						bool flag = (num = (num3 = (this.Assignments.#e(#QXc.Assignments) ? 1 : 0))) != 0;
						if (false)
						{
							goto IL_73;
						}
						if (!flag)
						{
							return false;
						}
						goto IL_40;
						IL_7D:
						if (num2 >= base.PolygonsCount)
						{
							return true;
						}
						PolygonData polygonData = this.#a[num2];
						PolygonData polygonData2 = #QXc.#a[num2];
						PolygonData #iwc;
						if (true)
						{
							#iwc = polygonData2;
						}
						if (!polygonData.#e(#iwc))
						{
							return false;
						}
						num3 = (num = num2 + 1);
						goto IL_73;
						IL_40:
						if (!false)
						{
							int num4 = 0;
							if (7 != 0)
							{
								num2 = num4;
							}
							goto IL_7D;
						}
						goto IL_28;
					}
				}
			}
			while (false);
			return false;
		}

		// Token: 0x06006889 RID: 26761 RVA: 0x00053430 File Offset: 0x00051630
		public void #EXc(ShapeDataModel #mXc)
		{
			if (this.Assignments != null)
			{
				#8Wc #8Wc = this.Assignments;
				#8Wc #7Wc = (#mXc != null) ? #mXc.Assignments : null;
				if (8 != 0)
				{
					#8Wc.#mg(#7Wc);
				}
			}
		}

		// Token: 0x17001CF1 RID: 7409
		// (get) Token: 0x0600688A RID: 26762 RVA: 0x00053458 File Offset: 0x00051658
		// (set) Token: 0x0600688B RID: 26763 RVA: 0x00053460 File Offset: 0x00051660
		private protected #bDc UndoManager { protected get; private set; }

		// Token: 0x17001CF2 RID: 7410
		// (get) Token: 0x0600688C RID: 26764 RVA: 0x00053469 File Offset: 0x00051669
		// (set) Token: 0x0600688D RID: 26765 RVA: 0x00053471 File Offset: 0x00051671
		private protected #1Wc AssignmentsFactory { protected get; private set; }

		// Token: 0x17001CF3 RID: 7411
		// (get) Token: 0x0600688E RID: 26766 RVA: 0x0005347A File Offset: 0x0005167A
		// (set) Token: 0x0600688F RID: 26767 RVA: 0x00053482 File Offset: 0x00051682
		public #8Wc Assignments { get; protected set; }

		// Token: 0x17001CF4 RID: 7412
		// (get) Token: 0x06006890 RID: 26768 RVA: 0x0005348B File Offset: 0x0005168B
		// (set) Token: 0x06006891 RID: 26769 RVA: 0x00053493 File Offset: 0x00051693
		public bool UndoEnabled { get; set; }

		// Token: 0x06006892 RID: 26770 RVA: 0x001964B8 File Offset: 0x001946B8
		private void #RXc(#8Wc #7Wc)
		{
			if (this.AssignmentsFactory != null)
			{
				#8Wc #8Wc = this.AssignmentsFactory.#XWc(this.UndoManager, this);
				if (8 != 0)
				{
					this.Assignments = #8Wc;
				}
				if (this.Assignments != null && #7Wc != null)
				{
					#9Cc #9Cc = this.Assignments;
					bool flag = false;
					if (!false)
					{
						#9Cc.UndoEnabled = flag;
					}
					#8Wc #8Wc2 = this.Assignments;
					if (!false)
					{
						#8Wc2.#mg(#7Wc);
					}
					#9Cc #9Cc2 = this.Assignments;
					bool flag2 = true;
					if (!false)
					{
						#9Cc2.UndoEnabled = flag2;
					}
				}
			}
		}

		// Token: 0x06006893 RID: 26771 RVA: 0x0005349C File Offset: 0x0005169C
		private void #SXc<#Fu>(CustomObservableCollection<#Fu> #Du)
		{
			for (;;)
			{
				if (!false)
				{
					NotifyCollectionChangedEventHandler notifyCollectionChangedEventHandler = new NotifyCollectionChangedEventHandler(this.#XCc);
					if (!false)
					{
						#Du.CollectionChanging -= notifyCollectionChangedEventHandler;
					}
				}
				if (!false)
				{
					NotifyCollectionChangedEventHandler notifyCollectionChangedEventHandler2 = new NotifyCollectionChangedEventHandler(this.#XCc);
					if (!false)
					{
						#Du.CollectionChanging += notifyCollectionChangedEventHandler2;
					}
					if (!false)
					{
						break;
					}
				}
			}
		}

		// Token: 0x06006894 RID: 26772 RVA: 0x00196530 File Offset: 0x00194730
		private void #XCc(object #Ge, NotifyCollectionChangedEventArgs #He)
		{
			if (this.UndoManager.CanPushMementoActions && this.UndoEnabled)
			{
				#cDc #cDc = this.UndoManager.Owner.#oi();
				#cDc #qi;
				if (!false)
				{
					#qi = #cDc;
				}
				#xDc #xDc = new #xDc(this.UndoManager.Owner, #qi);
				#xDc #xDc2;
				if (8 != 0)
				{
					#xDc2 = #xDc;
				}
				#bDc #bDc = this.UndoManager;
				#qDc #nd = #xDc2;
				if (!false)
				{
					#bDc.#xCc(#nd);
				}
			}
		}

		// Token: 0x14000192 RID: 402
		// (add) Token: 0x06006895 RID: 26773 RVA: 0x00196594 File Offset: 0x00194794
		// (remove) Token: 0x06006896 RID: 26774 RVA: 0x001965EC File Offset: 0x001947EC
		public event PropertyChangingEventHandler PropertyChanging
		{
			[CompilerGenerated]
			add
			{
				if (!false)
				{
					PropertyChangingEventHandler propertyChangingEventHandler2;
					if (!false)
					{
						PropertyChangingEventHandler propertyChangingEventHandler = this.#f;
						if (!false)
						{
							propertyChangingEventHandler2 = propertyChangingEventHandler;
						}
					}
					PropertyChangingEventHandler propertyChangingEventHandler4;
					do
					{
						if (7 != 0)
						{
							PropertyChangingEventHandler propertyChangingEventHandler3 = propertyChangingEventHandler2;
							if (3 != 0)
							{
								propertyChangingEventHandler4 = propertyChangingEventHandler3;
							}
							PropertyChangingEventHandler propertyChangingEventHandler5 = (PropertyChangingEventHandler)Delegate.Combine(propertyChangingEventHandler4, value);
							PropertyChangingEventHandler value2;
							if (-1 != 0)
							{
								value2 = propertyChangingEventHandler5;
							}
							PropertyChangingEventHandler propertyChangingEventHandler6 = Interlocked.CompareExchange<PropertyChangingEventHandler>(ref this.#f, value2, propertyChangingEventHandler4);
							if (6 != 0)
							{
								propertyChangingEventHandler2 = propertyChangingEventHandler6;
							}
						}
					}
					while (propertyChangingEventHandler2 != propertyChangingEventHandler4);
				}
			}
			[CompilerGenerated]
			remove
			{
				if (!false)
				{
					PropertyChangingEventHandler propertyChangingEventHandler2;
					if (!false)
					{
						PropertyChangingEventHandler propertyChangingEventHandler = this.#f;
						if (!false)
						{
							propertyChangingEventHandler2 = propertyChangingEventHandler;
						}
					}
					PropertyChangingEventHandler propertyChangingEventHandler4;
					do
					{
						if (7 != 0)
						{
							PropertyChangingEventHandler propertyChangingEventHandler3 = propertyChangingEventHandler2;
							if (3 != 0)
							{
								propertyChangingEventHandler4 = propertyChangingEventHandler3;
							}
							PropertyChangingEventHandler propertyChangingEventHandler5 = (PropertyChangingEventHandler)Delegate.Remove(propertyChangingEventHandler4, value);
							PropertyChangingEventHandler value2;
							if (-1 != 0)
							{
								value2 = propertyChangingEventHandler5;
							}
							PropertyChangingEventHandler propertyChangingEventHandler6 = Interlocked.CompareExchange<PropertyChangingEventHandler>(ref this.#f, value2, propertyChangingEventHandler4);
							if (6 != 0)
							{
								propertyChangingEventHandler2 = propertyChangingEventHandler6;
							}
						}
					}
					while (propertyChangingEventHandler2 != propertyChangingEventHandler4);
				}
			}
		}

		// Token: 0x14000193 RID: 403
		// (add) Token: 0x06006897 RID: 26775 RVA: 0x00196644 File Offset: 0x00194844
		// (remove) Token: 0x06006898 RID: 26776 RVA: 0x0019669C File Offset: 0x0019489C
		public event PropertyChangedEventHandler PropertyChanged
		{
			[CompilerGenerated]
			add
			{
				if (!false)
				{
					PropertyChangedEventHandler propertyChangedEventHandler2;
					if (!false)
					{
						PropertyChangedEventHandler propertyChangedEventHandler = this.#g;
						if (!false)
						{
							propertyChangedEventHandler2 = propertyChangedEventHandler;
						}
					}
					PropertyChangedEventHandler propertyChangedEventHandler4;
					do
					{
						if (7 != 0)
						{
							PropertyChangedEventHandler propertyChangedEventHandler3 = propertyChangedEventHandler2;
							if (3 != 0)
							{
								propertyChangedEventHandler4 = propertyChangedEventHandler3;
							}
							PropertyChangedEventHandler propertyChangedEventHandler5 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler4, value);
							PropertyChangedEventHandler value2;
							if (-1 != 0)
							{
								value2 = propertyChangedEventHandler5;
							}
							PropertyChangedEventHandler propertyChangedEventHandler6 = Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this.#g, value2, propertyChangedEventHandler4);
							if (6 != 0)
							{
								propertyChangedEventHandler2 = propertyChangedEventHandler6;
							}
						}
					}
					while (propertyChangedEventHandler2 != propertyChangedEventHandler4);
				}
			}
			[CompilerGenerated]
			remove
			{
				if (!false)
				{
					PropertyChangedEventHandler propertyChangedEventHandler2;
					if (!false)
					{
						PropertyChangedEventHandler propertyChangedEventHandler = this.#g;
						if (!false)
						{
							propertyChangedEventHandler2 = propertyChangedEventHandler;
						}
					}
					PropertyChangedEventHandler propertyChangedEventHandler4;
					do
					{
						if (7 != 0)
						{
							PropertyChangedEventHandler propertyChangedEventHandler3 = propertyChangedEventHandler2;
							if (3 != 0)
							{
								propertyChangedEventHandler4 = propertyChangedEventHandler3;
							}
							PropertyChangedEventHandler propertyChangedEventHandler5 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler4, value);
							PropertyChangedEventHandler value2;
							if (-1 != 0)
							{
								value2 = propertyChangedEventHandler5;
							}
							PropertyChangedEventHandler propertyChangedEventHandler6 = Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this.#g, value2, propertyChangedEventHandler4);
							if (6 != 0)
							{
								propertyChangedEventHandler2 = propertyChangedEventHandler6;
							}
						}
					}
					while (propertyChangedEventHandler2 != propertyChangedEventHandler4);
				}
			}
		}

		// Token: 0x06006899 RID: 26777 RVA: 0x001966F4 File Offset: 0x001948F4
		protected void #TXc(PropertyChangingEventArgs #He)
		{
			PropertyChangingEventHandler propertyChangingEventHandler = this.#f;
			PropertyChangingEventHandler propertyChangingEventHandler2;
			if (!false)
			{
				propertyChangingEventHandler2 = propertyChangingEventHandler;
			}
			if (propertyChangingEventHandler2 != null)
			{
				PropertyChangingEventHandler propertyChangingEventHandler3 = propertyChangingEventHandler2;
				if (!false)
				{
					propertyChangingEventHandler3(this, #He);
				}
			}
		}

		// Token: 0x0600689A RID: 26778 RVA: 0x00196724 File Offset: 0x00194924
		protected void #Fkb(PropertyChangedEventArgs #He)
		{
			PropertyChangedEventHandler propertyChangedEventHandler = this.#g;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			if (!false)
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
			}
			if (propertyChangedEventHandler2 != null)
			{
				PropertyChangedEventHandler propertyChangedEventHandler3 = propertyChangedEventHandler2;
				if (!false)
				{
					propertyChangedEventHandler3(this, #He);
				}
			}
		}

		// Token: 0x04002AF4 RID: 10996
		private readonly CustomObservableCollection<PolygonData> #a = new CustomObservableCollection<PolygonData>();

		// Token: 0x04002AF5 RID: 10997
		[CompilerGenerated]
		private #bDc #b;

		// Token: 0x04002AF6 RID: 10998
		[CompilerGenerated]
		private #1Wc #c;

		// Token: 0x04002AF7 RID: 10999
		[CompilerGenerated]
		private #8Wc #d;

		// Token: 0x04002AF8 RID: 11000
		[CompilerGenerated]
		private bool #e;

		// Token: 0x04002AF9 RID: 11001
		[CompilerGenerated]
		private PropertyChangingEventHandler #f;

		// Token: 0x04002AFA RID: 11002
		[CompilerGenerated]
		private PropertyChangedEventHandler #g;
	}
}
