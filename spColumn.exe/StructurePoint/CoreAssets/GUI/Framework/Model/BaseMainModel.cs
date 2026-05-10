using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using #7hc;
using #8Cc;
using #ezc;
using #Fmc;
using #N6c;
using #NWc;
using #TCc;
using #UYd;
using Microsoft.Practices.ObjectBuilder2;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.GUI.Framework.Collections;
using StructurePoint.CoreAssets.GUI.Framework.Model.Entities;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Infrastructure.Extensions;

namespace StructurePoint.CoreAssets.GUI.Framework.Model
{
	// Token: 0x02000C7C RID: 3196
	public abstract class BaseMainModel : #3Cc, #PBc, #WWc
	{
		// Token: 0x06006781 RID: 26497 RVA: 0x00194248 File Offset: 0x00192448
		protected BaseMainModel(#bDc undoManager) : base(undoManager)
		{
			base.UndoEnabled = false;
			this.#a = new CustomObservableCollection<ShapeDataModel>();
			this.#a.CollectionChanged += this.#HVc;
			this.#QCc<ShapeDataModel>(this.#a);
			this.#b = new CustomObservableCollection<GridLineDefinitionModel>();
			this.#QCc<GridLineDefinitionModel>(this.#b);
			this.#c = new Dictionary<SegmentData, GridLineDefinitionModel>();
			this.#d = new CustomObservableCollection<NodeModel>();
			this.#QCc<NodeModel>(this.#d);
			this.#e = new CustomObservableCollection<LinearObject>();
			this.#QCc<LinearObject>(this.#e);
			base.UndoEnabled = true;
		}

		// Token: 0x06006782 RID: 26498 RVA: 0x00052C81 File Offset: 0x00050E81
		private void #HVc(object #Ge, NotifyCollectionChangedEventArgs #He)
		{
			if (6 != 0)
			{
				this.#KVc();
			}
		}

		// Token: 0x1400018F RID: 399
		// (add) Token: 0x06006783 RID: 26499 RVA: 0x001942E8 File Offset: 0x001924E8
		// (remove) Token: 0x06006784 RID: 26500 RVA: 0x00194340 File Offset: 0x00192540
		public event EventHandler ShapesChanged
		{
			[CompilerGenerated]
			add
			{
				if (!false)
				{
					EventHandler eventHandler2;
					if (!false)
					{
						EventHandler eventHandler = this.#f;
						if (!false)
						{
							eventHandler2 = eventHandler;
						}
					}
					EventHandler eventHandler4;
					do
					{
						if (7 != 0)
						{
							EventHandler eventHandler3 = eventHandler2;
							if (3 != 0)
							{
								eventHandler4 = eventHandler3;
							}
							EventHandler eventHandler5 = (EventHandler)Delegate.Combine(eventHandler4, value);
							EventHandler value2;
							if (-1 != 0)
							{
								value2 = eventHandler5;
							}
							EventHandler eventHandler6 = Interlocked.CompareExchange<EventHandler>(ref this.#f, value2, eventHandler4);
							if (6 != 0)
							{
								eventHandler2 = eventHandler6;
							}
						}
					}
					while (eventHandler2 != eventHandler4);
				}
			}
			[CompilerGenerated]
			remove
			{
				if (!false)
				{
					EventHandler eventHandler2;
					if (!false)
					{
						EventHandler eventHandler = this.#f;
						if (!false)
						{
							eventHandler2 = eventHandler;
						}
					}
					EventHandler eventHandler4;
					do
					{
						if (7 != 0)
						{
							EventHandler eventHandler3 = eventHandler2;
							if (3 != 0)
							{
								eventHandler4 = eventHandler3;
							}
							EventHandler eventHandler5 = (EventHandler)Delegate.Remove(eventHandler4, value);
							EventHandler value2;
							if (-1 != 0)
							{
								value2 = eventHandler5;
							}
							EventHandler eventHandler6 = Interlocked.CompareExchange<EventHandler>(ref this.#f, value2, eventHandler4);
							if (6 != 0)
							{
								eventHandler2 = eventHandler6;
							}
						}
					}
					while (eventHandler2 != eventHandler4);
				}
			}
		}

		// Token: 0x06006785 RID: 26501 RVA: 0x00052C8F File Offset: 0x00050E8F
		public void #KVc()
		{
			if (6 != 0)
			{
				this.#LVc();
			}
		}

		// Token: 0x06006786 RID: 26502 RVA: 0x00194398 File Offset: 0x00192598
		protected virtual void #LVc()
		{
			EventHandler eventHandler = this.#f;
			EventHandler eventHandler2;
			if (!false)
			{
				eventHandler2 = eventHandler;
			}
			if (eventHandler2 != null)
			{
				EventHandler eventHandler3 = eventHandler2;
				EventArgs empty = EventArgs.Empty;
				if (!false)
				{
					eventHandler3(this, empty);
				}
			}
		}

		// Token: 0x17001CBF RID: 7359
		// (get) Token: 0x06006787 RID: 26503 RVA: 0x00052C9D File Offset: 0x00050E9D
		public #k8c<ShapeDataModel> Shapes
		{
			get
			{
				return this.#a;
			}
		}

		// Token: 0x17001CC0 RID: 7360
		// (get) Token: 0x06006788 RID: 26504 RVA: 0x00052CA5 File Offset: 0x00050EA5
		public #k8c<NodeModel> Nodes
		{
			get
			{
				return this.#d;
			}
		}

		// Token: 0x17001CC1 RID: 7361
		// (get) Token: 0x06006789 RID: 26505 RVA: 0x00052CAD File Offset: 0x00050EAD
		public #k8c<LinearObject> LinearObjects
		{
			get
			{
				return this.#e;
			}
		}

		// Token: 0x17001CC2 RID: 7362
		// (get) Token: 0x0600678A RID: 26506
		public abstract BoundingBoxData WorkspaceBoundingBoxData { get; }

		// Token: 0x17001CC3 RID: 7363
		// (get) Token: 0x0600678B RID: 26507 RVA: 0x00052CB5 File Offset: 0x00050EB5
		public #k8c<GridLineDefinitionModel> GridLines
		{
			get
			{
				return this.#b;
			}
		}

		// Token: 0x0600678C RID: 26508 RVA: 0x00052CBD File Offset: 0x00050EBD
		public virtual void #yl()
		{
			if (4 != 0)
			{
				this.#OVc();
			}
			if (4 != 0)
			{
				this.#QVc();
			}
			if (3 != 0)
			{
				this.#PVc();
			}
			if (!false)
			{
				this.#RVc();
			}
		}

		// Token: 0x0600678D RID: 26509 RVA: 0x001943CC File Offset: 0x001925CC
		public virtual void #OVc()
		{
			for (;;)
			{
				IEnumerable<ShapeDataModel> sequence = this.#a;
				Action<ShapeDataModel> action = new Action<ShapeDataModel>(BaseMainModel.<>c.<>9.#Yad);
				if (!false)
				{
					sequence.ForEach(action);
				}
				while (!false)
				{
					Collection<ShapeDataModel> collection = this.#a;
					if (!false)
					{
						collection.Clear();
					}
					if (!false)
					{
						if (!false)
						{
							return;
						}
						break;
					}
				}
			}
		}

		// Token: 0x0600678E RID: 26510 RVA: 0x00194424 File Offset: 0x00192624
		public virtual void #PVc()
		{
			for (;;)
			{
				IEnumerable<LinearObject> sequence = this.#e;
				Action<LinearObject> action = new Action<LinearObject>(BaseMainModel.<>c.<>9.#Zad);
				if (!false)
				{
					sequence.ForEach(action);
				}
				while (!false)
				{
					Collection<LinearObject> collection = this.#e;
					if (!false)
					{
						collection.Clear();
					}
					if (!false)
					{
						if (!false)
						{
							return;
						}
						break;
					}
				}
			}
		}

		// Token: 0x0600678F RID: 26511 RVA: 0x0019447C File Offset: 0x0019267C
		public virtual void #QVc()
		{
			do
			{
				IEnumerable<GridLineDefinitionModel> sequence = this.#b;
				Action<GridLineDefinitionModel> action = new Action<GridLineDefinitionModel>(BaseMainModel.<>c.<>9.#0ad);
				if (!false)
				{
					sequence.ForEach(action);
				}
				if (!false)
				{
					Collection<GridLineDefinitionModel> collection = this.#b;
					if (!false)
					{
						collection.Clear();
					}
				}
				Dictionary<SegmentData, GridLineDefinitionModel> dictionary = this.#c;
				if (!false)
				{
					dictionary.Clear();
				}
			}
			while (false);
		}

		// Token: 0x06006790 RID: 26512 RVA: 0x001944E4 File Offset: 0x001926E4
		public void #RVc()
		{
			for (;;)
			{
				IEnumerable<NodeModel> sequence = this.#d;
				Action<NodeModel> action = new Action<NodeModel>(BaseMainModel.<>c.<>9.#1ad);
				if (!false)
				{
					sequence.ForEach(action);
				}
				while (!false)
				{
					Collection<NodeModel> collection = this.#d;
					if (!false)
					{
						collection.Clear();
					}
					if (!false)
					{
						if (!false)
						{
							return;
						}
						break;
					}
				}
			}
		}

		// Token: 0x06006791 RID: 26513 RVA: 0x00052CEF File Offset: 0x00050EEF
		public void #SVc(NodeModel #uXb)
		{
			for (;;)
			{
				string #R0d = #Phc.#3hc(107440306);
				Component #x6c = Component.GUI;
				string #Qic = #Phc.#3hc(107440265);
				if (!false)
				{
					#X0d.#V0d(#uXb, #R0d, #x6c, #Qic);
				}
				if (!false)
				{
					Collection<NodeModel> collection = this.#d;
					if (4 != 0)
					{
						collection.Add(#uXb);
					}
					if (!false)
					{
						break;
					}
				}
			}
		}

		// Token: 0x06006792 RID: 26514 RVA: 0x0019453C File Offset: 0x0019273C
		public void #TVc(IEnumerable<NodeModel> #UVc)
		{
			string #R0d = #Phc.#3hc(107440244);
			Component #x6c = Component.GUI;
			string #Qic = #Phc.#3hc(107440199);
			if (5 != 0)
			{
				#X0d.#V0d(#UVc, #R0d, #x6c, #Qic);
			}
			do
			{
				if (!false)
				{
					CustomObservableCollection<NodeModel> #Du = this.#d;
					Action<NodeModel> #nd = new Action<NodeModel>(this.#SVc);
					if (!false)
					{
						BaseMainModel.#8Vc<NodeModel>(#Du, #nd, #UVc);
					}
				}
			}
			while (false || !true);
		}

		// Token: 0x06006793 RID: 26515 RVA: 0x00052D2E File Offset: 0x00050F2E
		public void #VVc(NodeModel #SNc)
		{
			string #R0d = #Phc.#3hc(107440306);
			Component #x6c = Component.GUI;
			string #Qic = #Phc.#3hc(107440178);
			if (!false)
			{
				#X0d.#V0d(#SNc, #R0d, #x6c, #Qic);
			}
			if (!false)
			{
				#SNc.UnsubscribeAllEvents();
			}
			this.#d.Remove(#SNc);
		}

		// Token: 0x06006794 RID: 26516 RVA: 0x00194598 File Offset: 0x00192798
		public void #jEc(IEnumerable<NodeModel> #WVc)
		{
			string #R0d = #Phc.#3hc(107440637);
			Component #x6c = Component.GUI;
			string #Qic = #Phc.#3hc(107440584);
			if (5 != 0)
			{
				#X0d.#V0d(#WVc, #R0d, #x6c, #Qic);
			}
			do
			{
				if (!false)
				{
					CustomObservableCollection<NodeModel> #Du = this.#d;
					Action<NodeModel> #nd = new Action<NodeModel>(this.#VVc);
					if (!false)
					{
						BaseMainModel.#8Vc<NodeModel>(#Du, #nd, #WVc);
					}
				}
			}
			while (false || !true);
		}

		// Token: 0x06006795 RID: 26517 RVA: 0x001945F4 File Offset: 0x001927F4
		public bool #XVc(Point #Ng)
		{
			BaseMainModel.#cWb #cWb = new BaseMainModel.#cWb();
			BaseMainModel.#cWb #cWb2;
			if (!false)
			{
				#cWb2 = #cWb;
			}
			#cWb2.#a = #Ng;
			return this.#d.Any(new Func<NodeModel, bool>(#cWb2.#9ad));
		}

		// Token: 0x06006796 RID: 26518 RVA: 0x0019462C File Offset: 0x0019282C
		public void #YVc(GridLineDefinitionModel #bsc)
		{
			do
			{
				string #R0d = #Phc.#3hc(107364483);
				Component #x6c = Component.GUIFramework;
				string #Qic = #Phc.#3hc(107440563);
				if (8 != 0)
				{
					#X0d.#V0d(#bsc, #R0d, #x6c, #Qic);
				}
			}
			while (7 == 0);
			if (!false)
			{
				Collection<GridLineDefinitionModel> collection = this.#b;
				if (!false)
				{
					collection.Add(#bsc);
				}
				Dictionary<SegmentData, GridLineDefinitionModel> dictionary = this.#c;
				SegmentData key = #bsc.GridLineData.LineSegment;
				if (6 != 0)
				{
					dictionary.Add(key, #bsc);
				}
			}
		}

		// Token: 0x06006797 RID: 26519 RVA: 0x00194698 File Offset: 0x00192898
		public void #ZVc(GridLineDefinitionModel #bsc, int #4jb)
		{
			string #R0d = #Phc.#3hc(107364483);
			Component #x6c = Component.GUIFramework;
			string #Qic = #Phc.#3hc(107440510);
			if (-1 != 0)
			{
				#X0d.#V0d(#bsc, #R0d, #x6c, #Qic);
			}
			Collection<GridLineDefinitionModel> collection = this.#b;
			if (!false)
			{
				collection.Insert(#4jb, #bsc);
			}
			Dictionary<SegmentData, GridLineDefinitionModel> dictionary = this.#c;
			SegmentData key = #bsc.GridLineData.LineSegment;
			if (5 != 0)
			{
				dictionary.Add(key, #bsc);
			}
		}

		// Token: 0x06006798 RID: 26520 RVA: 0x00194700 File Offset: 0x00192900
		public void #0Vc(IEnumerable<GridLineDefinitionModel> #ooc)
		{
			string #R0d = #Phc.#3hc(107460456);
			Component #x6c = Component.GUI;
			string #Qic = #Phc.#3hc(107440425);
			if (5 != 0)
			{
				#X0d.#V0d(#ooc, #R0d, #x6c, #Qic);
			}
			do
			{
				if (!false)
				{
					CustomObservableCollection<GridLineDefinitionModel> #Du = this.#b;
					Action<GridLineDefinitionModel> #nd = new Action<GridLineDefinitionModel>(this.#YVc);
					if (!false)
					{
						BaseMainModel.#8Vc<GridLineDefinitionModel>(#Du, #nd, #ooc);
					}
				}
			}
			while (false || !true);
		}

		// Token: 0x06006799 RID: 26521 RVA: 0x0019475C File Offset: 0x0019295C
		public void #1Vc(GridLineDefinitionModel #bsc)
		{
			string #R0d = #Phc.#3hc(107364483);
			Component #x6c = Component.GUIFramework;
			string #Qic = #Phc.#3hc(107440404);
			if (7 != 0)
			{
				#X0d.#V0d(#bsc, #R0d, #x6c, #Qic);
			}
			if (!false)
			{
				#bsc.UnsubscribeAllEvents();
			}
			this.#b.Remove(#bsc);
			this.#c.Remove(#bsc.GridLineData.LineSegment);
		}

		// Token: 0x0600679A RID: 26522 RVA: 0x001947C0 File Offset: 0x001929C0
		public bool #2Vc(GridLineDefinitionModel #bsc)
		{
			if (false)
			{
				goto IL_38;
			}
			BaseMainModel.#p6b #p6b2;
			if (!false)
			{
				BaseMainModel.#p6b #p6b = new BaseMainModel.#p6b();
				if (!false)
				{
					#p6b2 = #p6b;
				}
			}
			#p6b2.#a = #bsc;
			IL_16:
			object #Rf = #p6b2.#a;
			string #R0d = #Phc.#3hc(107364483);
			Component #x6c = Component.GUI;
			string #Qic = #Phc.#3hc(107439839);
			if (3 != 0)
			{
				#X0d.#V0d(#Rf, #R0d, #x6c, #Qic);
			}
			IL_38:
			if (2 != 0)
			{
				return this.#b.Any(new Func<GridLineDefinitionModel, bool>(#p6b2.#abd));
			}
			goto IL_16;
		}

		// Token: 0x0600679B RID: 26523 RVA: 0x0019482C File Offset: 0x00192A2C
		public GridLineDefinitionModel #3Vc(SegmentData #PP)
		{
			BaseMainModel.#fWb #fWb2;
			if (7 != 0 && !false)
			{
				BaseMainModel.#fWb #fWb = new BaseMainModel.#fWb();
				if (5 != 0)
				{
					#fWb2 = #fWb;
				}
				#fWb2.#a = #PP;
			}
			object #Rf = #fWb2.#a;
			string #R0d = #Phc.#3hc(107368915);
			Component #x6c = Component.GUI;
			string #Qic = #Phc.#3hc(107439754);
			if (!false)
			{
				#X0d.#V0d(#Rf, #R0d, #x6c, #Qic);
			}
			return this.#c.#F1d(#fWb2.#a) ?? this.GridLines.FirstOrDefault(new Func<GridLineDefinitionModel, bool>(#fWb2.#bbd));
		}

		// Token: 0x0600679C RID: 26524 RVA: 0x00052D6D File Offset: 0x00050F6D
		public void #4Vc(GridLineDefinitionModel #bsc, int #4jb)
		{
			string #R0d = #Phc.#3hc(107364483);
			Component #x6c = Component.GUI;
			string #Qic = #Phc.#3hc(107439733);
			if (8 != 0)
			{
				#X0d.#V0d(#bsc, #R0d, #x6c, #Qic);
			}
			CustomObservableCollection<GridLineDefinitionModel> customObservableCollection = this.#b;
			if (!false)
			{
				customObservableCollection.#V6c(#4jb, #bsc);
			}
		}

		// Token: 0x0600679D RID: 26525 RVA: 0x001948A8 File Offset: 0x00192AA8
		public void #5Vc(GridLineDefinitionModel #6Vc, GridLineDefinitionModel #7Vc)
		{
			string #R0d = #Phc.#3hc(107439648);
			Component #x6c = Component.GUIFramework;
			string #Qic = #Phc.#3hc(107439619);
			if (!false)
			{
				#X0d.#V0d(#6Vc, #R0d, #x6c, #Qic);
			}
			string #R0d2 = #Phc.#3hc(107440078);
			Component #x6c2 = Component.GUIFramework;
			string #Qic2 = #Phc.#3hc(107440081);
			if (-1 != 0)
			{
				#X0d.#V0d(#7Vc, #R0d2, #x6c2, #Qic2);
			}
			if (3 != 0)
			{
				#7Vc.UnsubscribeAllEvents();
			}
			int num = this.#b.#C7c(#7Vc);
			int num2;
			if (4 != 0)
			{
				num2 = num;
			}
			Collection<GridLineDefinitionModel> collection = this.#b;
			int index = num2;
			if (!false)
			{
				collection[index] = #6Vc;
			}
			this.#c.Remove(#7Vc.GridLineData.LineSegment);
			Dictionary<SegmentData, GridLineDefinitionModel> dictionary = this.#c;
			SegmentData key = #6Vc.GridLineData.LineSegment;
			if (!false)
			{
				dictionary.Add(key, #6Vc);
			}
		}

		// Token: 0x0600679E RID: 26526 RVA: 0x0019496C File Offset: 0x00192B6C
		protected static void #8Vc<#Fu>(CustomObservableCollection<#Fu> #Du, Action<#Fu> #nd, IEnumerable<#Fu> #8f)
		{
			if (#Du == null || #nd == null || #8f == null)
			{
				return;
			}
			ICollection<!!0> collection;
			if ((collection = (#8f as ICollection<!!0>)) == null)
			{
				collection = #8f.ToArray<#Fu>();
			}
			ICollection<#Fu> collection2;
			if (!false)
			{
				collection2 = collection;
			}
			if (!collection2.Any<#Fu>())
			{
				return;
			}
			#07c #07c = new #07c(#Du);
			#07c #07c2;
			if (3 != 0)
			{
				#07c2 = #07c;
			}
			try
			{
				foreach (#Fu #Fu in collection2)
				{
					#Fu #Fu2;
					if (!false)
					{
						#Fu2 = #Fu;
					}
					if (!false)
					{
						!!0 obj = #Fu2;
						if (6 != 0)
						{
							#nd(obj);
						}
					}
				}
			}
			finally
			{
				do
				{
					if (!true || #07c2 != null)
					{
						if (8 == 0)
						{
							continue;
						}
						((IDisposable)#07c2).Dispose();
					}
				}
				while (5 == 0);
			}
		}

		// Token: 0x0600679F RID: 26527 RVA: 0x00052DA8 File Offset: 0x00050FA8
		public void #9Vc(LinearObject #NNc)
		{
			for (;;)
			{
				string #R0d = #Phc.#3hc(107440028);
				Component #x6c = Component.GUI;
				string #Qic = #Phc.#3hc(107439979);
				if (!false)
				{
					#X0d.#V0d(#NNc, #R0d, #x6c, #Qic);
				}
				if (!false)
				{
					Collection<LinearObject> collection = this.#e;
					if (4 != 0)
					{
						collection.Add(#NNc);
					}
					if (!false)
					{
						break;
					}
				}
			}
		}

		// Token: 0x060067A0 RID: 26528 RVA: 0x00052DE7 File Offset: 0x00050FE7
		public void #aWc(LinearObject #NNc)
		{
			string #R0d = #Phc.#3hc(107440028);
			Component #x6c = Component.GUI;
			string #Qic = #Phc.#3hc(107439958);
			if (!false)
			{
				#X0d.#V0d(#NNc, #R0d, #x6c, #Qic);
			}
			if (!false)
			{
				#NNc.UnsubscribeAllEvents();
			}
			this.#e.Remove(#NNc);
		}

		// Token: 0x060067A1 RID: 26529 RVA: 0x00194A20 File Offset: 0x00192C20
		public void #bWc(IEnumerable<LinearObject> #iEc)
		{
			string #R0d = #Phc.#3hc(107416450);
			Component #x6c = Component.GUI;
			string #Qic = #Phc.#3hc(107439873);
			if (5 != 0)
			{
				#X0d.#V0d(#iEc, #R0d, #x6c, #Qic);
			}
			do
			{
				if (!false)
				{
					CustomObservableCollection<LinearObject> #Du = this.#e;
					Action<LinearObject> #nd = new Action<LinearObject>(this.#9Vc);
					if (!false)
					{
						BaseMainModel.#8Vc<LinearObject>(#Du, #nd, #iEc);
					}
				}
			}
			while (false || !true);
		}

		// Token: 0x060067A2 RID: 26530 RVA: 0x00194A7C File Offset: 0x00192C7C
		public bool #cWc(Point #mcb, Point #ncb)
		{
			BaseMainModel.#HZb #HZb2;
			do
			{
				BaseMainModel.#HZb #HZb = new BaseMainModel.#HZb();
				if (!false)
				{
					#HZb2 = #HZb;
				}
				#HZb2.#a = #mcb;
				#HZb2.#b = #ncb;
			}
			while (false);
			return this.#e.Any(new Func<LinearObject, bool>(#HZb2.#cbd));
		}

		// Token: 0x060067A3 RID: 26531 RVA: 0x00052E26 File Offset: 0x00051026
		public void #dWc(ShapeDataModel #eWc)
		{
			for (;;)
			{
				string #R0d = #Phc.#3hc(107439308);
				Component #x6c = Component.GUI;
				string #Qic = #Phc.#3hc(107439327);
				if (!false)
				{
					#X0d.#V0d(#eWc, #R0d, #x6c, #Qic);
				}
				if (!false)
				{
					Collection<ShapeDataModel> collection = this.#a;
					if (4 != 0)
					{
						collection.Add(#eWc);
					}
					if (!false)
					{
						break;
					}
				}
			}
		}

		// Token: 0x060067A4 RID: 26532 RVA: 0x00194AC0 File Offset: 0x00192CC0
		public void #fWc(IEnumerable<ShapeDataModel> #gWc)
		{
			string #R0d = #Phc.#3hc(107439242);
			Component #x6c = Component.GUI;
			string #Qic = #Phc.#3hc(107439261);
			if (5 != 0)
			{
				#X0d.#V0d(#gWc, #R0d, #x6c, #Qic);
			}
			do
			{
				if (!false)
				{
					CustomObservableCollection<ShapeDataModel> #Du = this.#a;
					Action<ShapeDataModel> #nd = new Action<ShapeDataModel>(this.#dWc);
					if (!false)
					{
						BaseMainModel.#8Vc<ShapeDataModel>(#Du, #nd, #gWc);
					}
				}
			}
			while (false || !true);
		}

		// Token: 0x060067A5 RID: 26533 RVA: 0x00052E65 File Offset: 0x00051065
		public void #hWc(ShapeDataModel #6lc)
		{
			string #R0d = #Phc.#3hc(107371211);
			Component #x6c = Component.GUI;
			string #Qic = #Phc.#3hc(107439176);
			if (!false)
			{
				#X0d.#V0d(#6lc, #R0d, #x6c, #Qic);
			}
			if (!false)
			{
				#6lc.#kib();
			}
			this.#a.Remove(#6lc);
		}

		// Token: 0x060067A6 RID: 26534 RVA: 0x00194B1C File Offset: 0x00192D1C
		public int #iWc(Point #doc)
		{
			BaseMainModel.#09b #09b = new BaseMainModel.#09b();
			BaseMainModel.#09b #09b2;
			if (!false)
			{
				#09b2 = #09b;
			}
			#09b2.#a = #doc;
			return this.Shapes.Count(new Func<ShapeDataModel, bool>(#09b2.#dbd));
		}

		// Token: 0x060067A7 RID: 26535 RVA: 0x00194B54 File Offset: 0x00192D54
		public IList<SegmentData> #jWc(Point #Ng)
		{
			BaseMainModel.#0Zb #0Zb = new BaseMainModel.#0Zb();
			BaseMainModel.#0Zb #0Zb2;
			if (!false)
			{
				#0Zb2 = #0Zb;
			}
			#0Zb2.#a = #Ng;
			return this.#a.SelectMany(new Func<ShapeDataModel, IEnumerable<SegmentData>>(#0Zb2.#hbd)).Union(this.LinearObjects.Where(new Func<LinearObject, bool>(#0Zb2.#kbd)).Select(new Func<LinearObject, SegmentData>(BaseMainModel.<>c.<>9.#2ad))).ToList<SegmentData>();
		}

		// Token: 0x060067A8 RID: 26536 RVA: 0x00194BD0 File Offset: 0x00192DD0
		public virtual BoundingBoxData #kWc()
		{
			IList<SnappingPointData> list = this.#lWc();
			IList<SnappingPointData> list2;
			if (!false)
			{
				list2 = list;
			}
			if (list2.Count < 1)
			{
				return null;
			}
			return new BoundingBoxData(list2.Select(new Func<SnappingPointData, Point>(BaseMainModel.<>c.<>9.#3ad)).ToList<Point>());
		}

		// Token: 0x060067A9 RID: 26537 RVA: 0x00194C24 File Offset: 0x00192E24
		public virtual IList<SnappingPointData> #lWc()
		{
			return this.#a.SelectMany(new Func<ShapeDataModel, IEnumerable<Point>>(BaseMainModel.<>c.<>9.#4ad)).Select(new Func<Point, SnappingPointData>(BaseMainModel.<>c.<>9.#5ad)).Union(this.#d.Where(new Func<NodeModel, bool>(BaseMainModel.<>c.<>9.#6ad)).Select(new Func<NodeModel, SnappingPointData>(BaseMainModel.<>c.<>9.#7ad))).Union(this.#e.SelectMany(new Func<LinearObject, IEnumerable<SnappingPointData>>(BaseMainModel.<>c.<>9.#8ad))).ToList<SnappingPointData>();
		}

		// Token: 0x060067AA RID: 26538 RVA: 0x00194D08 File Offset: 0x00192F08
		public virtual IList<SnappingSegmentData> #mWc()
		{
			List<SnappingSegmentData> list2;
			if (4 != 0)
			{
				List<SnappingSegmentData> list = new List<SnappingSegmentData>(100);
				if (!false)
				{
					list2 = list;
				}
				IEnumerator<LinearObject> enumerator = this.#e.GetEnumerator();
				IEnumerator<LinearObject> enumerator2;
				if (6 != 0)
				{
					enumerator2 = enumerator;
				}
				try
				{
					for (;;)
					{
						LinearObject linearObject2;
						if (!enumerator2.MoveNext())
						{
							if (2 != 0)
							{
								break;
							}
						}
						else
						{
							LinearObject linearObject = enumerator2.Current;
							if (!false)
							{
								linearObject2 = linearObject;
							}
						}
						List<SnappingSegmentData> list3 = list2;
						SnappingSegmentData snappingSegmentData = new SnappingSegmentData(linearObject2.Segment, #juc.#d);
						object obj = linearObject2;
						if (!false)
						{
							snappingSegmentData.SourceObject = obj;
						}
						if (true)
						{
							list3.Add(snappingSegmentData);
						}
					}
				}
				finally
				{
					if (!false && enumerator2 != null && !false)
					{
						enumerator2.Dispose();
					}
				}
			}
			IList<SnappingSegmentData> #En = list2;
			IEnumerable<ShapeData> #6Y = this.#a.OfType<ShapeData>().ToList<ShapeData>();
			if (!false)
			{
				#Fpc.#Epc(#En, #6Y);
			}
			return list2;
		}

		// Token: 0x060067AB RID: 26539 RVA: 0x00052EA4 File Offset: 0x000510A4
		public virtual IList<SnappingPointData> #nWc()
		{
			return new List<SnappingPointData>();
		}

		// Token: 0x060067AC RID: 26540 RVA: 0x00052EA4 File Offset: 0x000510A4
		public virtual IList<SnappingPointData> #oWc()
		{
			return new List<SnappingPointData>();
		}

		// Token: 0x060067AD RID: 26541 RVA: 0x00194DC4 File Offset: 0x00192FC4
		public virtual void #NBc()
		{
			if (8 != 0 && 5 != 0)
			{
				CustomObservableCollection<GridLineDefinitionModel> customObservableCollection = this.#b;
				if (-1 != 0)
				{
					customObservableCollection.#NBc();
				}
				CustomObservableCollection<ShapeDataModel> customObservableCollection2 = this.#a;
				if (2 != 0)
				{
					customObservableCollection2.#NBc();
				}
				if (2 != 0)
				{
					CustomObservableCollection<NodeModel> customObservableCollection3 = this.#d;
					if (-1 != 0)
					{
						customObservableCollection3.#NBc();
					}
				}
				CustomObservableCollection<LinearObject> customObservableCollection4 = this.#e;
				if (4 != 0)
				{
					customObservableCollection4.#NBc();
				}
			}
		}

		// Token: 0x060067AE RID: 26542 RVA: 0x00194E20 File Offset: 0x00193020
		public virtual void #OBc()
		{
			if (8 != 0 && 5 != 0)
			{
				CustomObservableCollection<GridLineDefinitionModel> customObservableCollection = this.#b;
				if (-1 != 0)
				{
					customObservableCollection.#OBc();
				}
				CustomObservableCollection<ShapeDataModel> customObservableCollection2 = this.#a;
				if (2 != 0)
				{
					customObservableCollection2.#OBc();
				}
				if (2 != 0)
				{
					CustomObservableCollection<NodeModel> customObservableCollection3 = this.#d;
					if (-1 != 0)
					{
						customObservableCollection3.#OBc();
					}
				}
				CustomObservableCollection<LinearObject> customObservableCollection4 = this.#e;
				if (4 != 0)
				{
					customObservableCollection4.#OBc();
				}
			}
		}

		// Token: 0x04002AAC RID: 10924
		private readonly CustomObservableCollection<ShapeDataModel> #a;

		// Token: 0x04002AAD RID: 10925
		private readonly CustomObservableCollection<GridLineDefinitionModel> #b;

		// Token: 0x04002AAE RID: 10926
		private readonly Dictionary<SegmentData, GridLineDefinitionModel> #c;

		// Token: 0x04002AAF RID: 10927
		private readonly CustomObservableCollection<NodeModel> #d;

		// Token: 0x04002AB0 RID: 10928
		private readonly CustomObservableCollection<LinearObject> #e;

		// Token: 0x04002AB1 RID: 10929
		[CompilerGenerated]
		private EventHandler #f;

		// Token: 0x02000C7E RID: 3198
		[CompilerGenerated]
		private sealed class #cWb
		{
			// Token: 0x060067BD RID: 26557 RVA: 0x00052F2B File Offset: 0x0005112B
			internal bool #9ad(NodeModel #uXb)
			{
				return PointsConverter.#uC(#uXb.Location, this.#a);
			}

			// Token: 0x04002ABE RID: 10942
			public Point #a;
		}

		// Token: 0x02000C7F RID: 3199
		[CompilerGenerated]
		private sealed class #p6b
		{
			// Token: 0x060067BF RID: 26559 RVA: 0x00052F3E File Offset: 0x0005113E
			internal bool #abd(GridLineDefinitionModel #Rf)
			{
				while (!true || #Rf != this.#a || false)
				{
					if (!false)
					{
						return this.#a.#J2(#Rf);
					}
				}
				return false;
			}

			// Token: 0x04002ABF RID: 10943
			public GridLineDefinitionModel #a;
		}

		// Token: 0x02000C80 RID: 3200
		[CompilerGenerated]
		private sealed class #fWb
		{
			// Token: 0x060067C1 RID: 26561 RVA: 0x00052F60 File Offset: 0x00051160
			internal bool #bbd(GridLineDefinitionModel #Rf)
			{
				return #Qsc.#Psc(#Rf.GridLineData.LineSegment, this.#a);
			}

			// Token: 0x04002AC0 RID: 10944
			public SegmentData #a;
		}

		// Token: 0x02000C81 RID: 3201
		[CompilerGenerated]
		private sealed class #HZb
		{
			// Token: 0x060067C3 RID: 26563 RVA: 0x00194E7C File Offset: 0x0019307C
			internal bool #cbd(LinearObject #Rf)
			{
				if (7 == 0)
				{
					goto IL_2C;
				}
				if (false)
				{
					goto IL_3F;
				}
				if (!PointsConverter.#uC(#Rf.StartPoint, this.#a))
				{
					goto IL_2C;
				}
				int num = PointsConverter.#uC(#Rf.EndPoint, this.#b) ? 1 : 0;
				IL_2A:
				if (num != 0)
				{
					return true;
				}
				IL_2C:
				if (!PointsConverter.#uC(#Rf.StartPoint, this.#b))
				{
					int num2 = num = 0;
					if (num2 == 0)
					{
						return num2 != 0;
					}
					goto IL_2A;
				}
				IL_3F:
				return PointsConverter.#uC(#Rf.EndPoint, this.#a);
			}

			// Token: 0x04002AC1 RID: 10945
			public Point #a;

			// Token: 0x04002AC2 RID: 10946
			public Point #b;
		}

		// Token: 0x02000C82 RID: 3202
		[CompilerGenerated]
		private sealed class #09b
		{
			// Token: 0x060067C5 RID: 26565 RVA: 0x00194EE0 File Offset: 0x001930E0
			internal bool #dbd(ShapeDataModel #Rf)
			{
				IEnumerable<PolygonData> source = #Rf.Polygons;
				Func<PolygonData, bool> predicate;
				if ((predicate = this.#c) == null)
				{
					predicate = (this.#c = new Func<PolygonData, bool>(this.#ebd));
				}
				return source.Any(predicate);
			}

			// Token: 0x060067C6 RID: 26566 RVA: 0x00194F18 File Offset: 0x00193118
			internal bool #ebd(PolygonData #JP)
			{
				IEnumerable<Point> source = #JP.Points2D;
				Func<Point, bool> predicate;
				if ((predicate = this.#b) == null)
				{
					predicate = (this.#b = new Func<Point, bool>(this.#fbd));
				}
				return source.Any(predicate);
			}

			// Token: 0x060067C7 RID: 26567 RVA: 0x00052F78 File Offset: 0x00051178
			internal bool #fbd(Point #gbd)
			{
				return PointsConverter.#uC(#gbd, this.#a);
			}

			// Token: 0x04002AC3 RID: 10947
			public Point #a;

			// Token: 0x04002AC4 RID: 10948
			public Func<Point, bool> #b;

			// Token: 0x04002AC5 RID: 10949
			public Func<PolygonData, bool> #c;
		}

		// Token: 0x02000C83 RID: 3203
		[CompilerGenerated]
		private sealed class #0Zb
		{
			// Token: 0x060067C9 RID: 26569 RVA: 0x00194F50 File Offset: 0x00193150
			internal IEnumerable<SegmentData> #hbd(ShapeDataModel #rP)
			{
				IEnumerable<PolygonData> source = #rP.Polygons;
				Func<PolygonData, IEnumerable<SegmentData>> selector;
				if ((selector = this.#c) == null)
				{
					selector = (this.#c = new Func<PolygonData, IEnumerable<SegmentData>>(this.#ibd));
				}
				return source.SelectMany(selector);
			}

			// Token: 0x060067CA RID: 26570 RVA: 0x00194F88 File Offset: 0x00193188
			internal IEnumerable<SegmentData> #ibd(PolygonData #JP)
			{
				IEnumerable<SegmentData> source = #JP.Segments;
				Func<SegmentData, bool> predicate;
				if ((predicate = this.#b) == null)
				{
					predicate = (this.#b = new Func<SegmentData, bool>(this.#jbd));
				}
				return source.Where(predicate);
			}

			// Token: 0x060067CB RID: 26571 RVA: 0x00052F86 File Offset: 0x00051186
			internal bool #jbd(SegmentData #PP)
			{
				return #jsc.#Src(#PP, this.#a);
			}

			// Token: 0x060067CC RID: 26572 RVA: 0x00052F94 File Offset: 0x00051194
			internal bool #kbd(LinearObject #Rf)
			{
				return #jsc.#Src(#Rf.Segment, this.#a);
			}

			// Token: 0x04002AC6 RID: 10950
			public Point #a;

			// Token: 0x04002AC7 RID: 10951
			public Func<SegmentData, bool> #b;

			// Token: 0x04002AC8 RID: 10952
			public Func<PolygonData, IEnumerable<SegmentData>> #c;
		}
	}
}
