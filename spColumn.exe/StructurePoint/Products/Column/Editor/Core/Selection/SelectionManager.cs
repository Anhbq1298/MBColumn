using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using #7hc;
using #gOb;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.Products.Column.Model.Entities;
using Telerik.Windows.Controls;

namespace StructurePoint.Products.Column.Editor.Core.Selection
{
	// Token: 0x0200069B RID: 1691
	[DebuggerDisplay("{GetDesription()}")]
	internal sealed class SelectionManager : NotifyPropertyChangedObjectBase, IDisposable
	{
		// Token: 0x06003899 RID: 14489 RVA: 0x0010FE14 File Offset: 0x0010E014
		public SelectionManager(ObjectsSelector selector)
		{
			this.#c = selector;
			this.#f = new SelectionState(this);
			this.#b = new List<IObjectsSelectionManager>
			{
				this.Bars,
				this.Shapes
			};
			this.#g = new DelegateCommand(new Action<object>(this.#ePb));
		}

		// Token: 0x140000D5 RID: 213
		// (add) Token: 0x0600389A RID: 14490 RVA: 0x0010FE8C File Offset: 0x0010E08C
		// (remove) Token: 0x0600389B RID: 14491 RVA: 0x0010FED0 File Offset: 0x0010E0D0
		public event EventHandler AnySelectionCleared
		{
			[CompilerGenerated]
			add
			{
				EventHandler eventHandler = this.#a;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#a, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler eventHandler = this.#a;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#a, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x17001172 RID: 4466
		// (get) Token: 0x0600389C RID: 14492 RVA: 0x0003145F File Offset: 0x0002F65F
		public IReadOnlyList<IObjectsSelectionManager> Managers { get; }

		// Token: 0x17001173 RID: 4467
		// (get) Token: 0x0600389D RID: 14493 RVA: 0x0003146B File Offset: 0x0002F66B
		public ObjectsSelector Selector { get; }

		// Token: 0x17001174 RID: 4468
		// (get) Token: 0x0600389E RID: 14494 RVA: 0x00031477 File Offset: 0x0002F677
		public #QOb<ReinforcementBar> Bars { get; }

		// Token: 0x17001175 RID: 4469
		// (get) Token: 0x0600389F RID: 14495 RVA: 0x00031483 File Offset: 0x0002F683
		public ShapesSelectionManager Shapes { get; }

		// Token: 0x17001176 RID: 4470
		// (get) Token: 0x060038A0 RID: 14496 RVA: 0x0003148F File Offset: 0x0002F68F
		public SelectionState State { get; }

		// Token: 0x17001177 RID: 4471
		// (get) Token: 0x060038A1 RID: 14497 RVA: 0x0003149B File Offset: 0x0002F69B
		public DelegateCommand RemoveFromSelectionCommand { get; }

		// Token: 0x060038A2 RID: 14498 RVA: 0x0010FF14 File Offset: 0x0010E114
		public BoundingBoxData #5Ob()
		{
			List<Point> list = this.Shapes.SelectedObjects.SelectMany(new Func<ShapeModel, IEnumerable<Point>>(SelectionManager.<>c.<>9.#Xcc)).ToList<Point>();
			list.AddRange(this.Bars.SelectedObjects.Select(new Func<ReinforcementBar, Point>(SelectionManager.<>c.<>9.#Zcc)));
			if (list.Count > 1)
			{
				return new BoundingBoxData(list);
			}
			return null;
		}

		// Token: 0x060038A3 RID: 14499 RVA: 0x000314A7 File Offset: 0x0002F6A7
		public HashSet<ReinforcementBar> #6Ob()
		{
			return this.Bars.SelectedObjects.ToHashSet<ReinforcementBar>();
		}

		// Token: 0x060038A4 RID: 14500 RVA: 0x000314C5 File Offset: 0x0002F6C5
		public void #7Ob()
		{
			this.Bars.LastSelectedObjects.Clear();
			this.Shapes.LastSelectedObjects.Clear();
		}

		// Token: 0x060038A5 RID: 14501 RVA: 0x0010FFB8 File Offset: 0x0010E1B8
		public void #CDb()
		{
			this.#7Ob();
			this.Bars.LastSelectedObjects.#pR(this.Bars.SelectedObjects);
			this.Shapes.LastSelectedObjects.#pR(this.Shapes.SelectedObjects);
		}

		// Token: 0x060038A6 RID: 14502 RVA: 0x000314F3 File Offset: 0x0002F6F3
		public void #8Ob()
		{
			this.Bars.#HOb(this.Bars.LastSelectedObjects);
			this.Shapes.#HOb(this.Shapes.LastSelectedObjects);
		}

		// Token: 0x060038A7 RID: 14503 RVA: 0x00110010 File Offset: 0x0010E210
		public bool #sOb()
		{
			bool result = this.#jAb();
			foreach (IObjectsSelectionManager objectsSelectionManager in this.Managers)
			{
				objectsSelectionManager.#sOb();
			}
			return result;
		}

		// Token: 0x060038A8 RID: 14504 RVA: 0x00110070 File Offset: 0x0010E270
		public void #9Ob()
		{
			foreach (IObjectsSelectionManager objectsSelectionManager in this.Managers)
			{
				objectsSelectionManager.#tOb();
			}
		}

		// Token: 0x060038A9 RID: 14505 RVA: 0x001100C8 File Offset: 0x0010E2C8
		public #oOb #FDb()
		{
			this.#sOb();
			#oOb #oOb = this.Selector.#FDb();
			this.#uR(#oOb);
			return #oOb;
		}

		// Token: 0x060038AA RID: 14506 RVA: 0x0003152D File Offset: 0x0002F72D
		public bool #jAb()
		{
			return this.Bars.Any || this.Shapes.Any;
		}

		// Token: 0x060038AB RID: 14507 RVA: 0x00031555 File Offset: 0x0002F755
		public bool #aPb()
		{
			return this.Bars.#IOb() != null || this.Shapes.#IOb() != null;
		}

		// Token: 0x060038AC RID: 14508 RVA: 0x001100FC File Offset: 0x0010E2FC
		public void #EDb(bool #vOb, bool #wOb)
		{
			foreach (IObjectsSelectionManager objectsSelectionManager in this.Managers)
			{
				objectsSelectionManager.#EDb(#vOb, #wOb);
			}
		}

		// Token: 0x060038AD RID: 14509 RVA: 0x00110158 File Offset: 0x0010E358
		public void #uR(#oOb #RBb)
		{
			if (#RBb == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107351095));
			}
			this.Bars.#HOb(#RBb.Bars);
			this.Shapes.#HOb(#RBb.Shapes);
		}

		// Token: 0x060038AE RID: 14510 RVA: 0x00031580 File Offset: 0x0002F780
		public void #bPb()
		{
			this.#9Ob();
			this.Bars.#LOb(this.Bars.SelectedObjects);
			this.Shapes.#LOb(this.Shapes.SelectedObjects);
		}

		// Token: 0x060038AF RID: 14511 RVA: 0x001101A8 File Offset: 0x0010E3A8
		public void #cPb(#oOb #RBb)
		{
			if (#RBb == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107351095));
			}
			this.Bars.#LOb(#RBb.Bars);
			this.Shapes.#LOb(#RBb.Shapes);
		}

		// Token: 0x060038B0 RID: 14512 RVA: 0x001101F8 File Offset: 0x0010E3F8
		public void #dPb()
		{
			if (!this.Selector.IncludeReinforcement)
			{
				this.Bars.#sOb();
			}
			if (!this.Selector.IncludeShapes)
			{
				this.Shapes.#sOb();
			}
			this.#fPb();
		}

		// Token: 0x060038B1 RID: 14513 RVA: 0x000315C0 File Offset: 0x0002F7C0
		protected void #1(bool #POb)
		{
			if (#POb)
			{
				this.#a = null;
				this.Bars.#1();
				this.Shapes.#1();
			}
		}

		// Token: 0x060038B2 RID: 14514 RVA: 0x000315EE File Offset: 0x0002F7EE
		public void #1()
		{
			this.#1(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x060038B3 RID: 14515 RVA: 0x00110248 File Offset: 0x0010E448
		private void #ePb(object #Sb)
		{
			SelectionObjectType selectionObjectType = (SelectionObjectType)#Sb;
			if (selectionObjectType != SelectionObjectType.Bars)
			{
				if (selectionObjectType != SelectionObjectType.Shapes)
				{
					return;
				}
				this.Shapes.#sOb();
			}
			else
			{
				this.Bars.#sOb();
			}
			this.State.#cg();
			EventHandler eventHandler = this.#a;
			if (eventHandler == null)
			{
				return;
			}
			eventHandler(this, EventArgs.Empty);
		}

		// Token: 0x060038B4 RID: 14516 RVA: 0x001102AC File Offset: 0x0010E4AC
		private void #fPb()
		{
			HashSet<ReinforcementBar> #6W = this.Selector.Project.Model.ReinforcementBars.ToHashSet<ReinforcementBar>();
			this.#dPb(#6W, this.Bars);
			HashSet<ShapeModel> #6W2 = this.Selector.Project.Model.Shapes.ToHashSet<ShapeModel>();
			this.#dPb(#6W2, this.Shapes);
		}

		// Token: 0x060038B5 RID: 14517 RVA: 0x00110318 File Offset: 0x0010E518
		private void #dPb(HashSet<ShapeModel> #6W, #QOb<ShapeModel> #RBb)
		{
			List<ShapeModel> list = new List<ShapeModel>();
			foreach (ShapeModel item in #RBb.SelectedObjects)
			{
				if (!#6W.Contains(item))
				{
					list.Add(item);
				}
			}
			#RBb.#EOb(list);
		}

		// Token: 0x060038B6 RID: 14518 RVA: 0x00110388 File Offset: 0x0010E588
		private void #dPb(HashSet<ReinforcementBar> #6W, #QOb<ReinforcementBar> #RBb)
		{
			List<ReinforcementBar> list = new List<ReinforcementBar>();
			foreach (ReinforcementBar item in #RBb.SelectedObjects)
			{
				if (!#6W.Contains(item))
				{
					list.Add(item);
				}
			}
			#RBb.#EOb(list);
		}

		// Token: 0x060038B7 RID: 14519 RVA: 0x001103F8 File Offset: 0x0010E5F8
		private string #OOb()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine(Strings.StringBars.#u2d(true) + this.Bars.#OOb());
			stringBuilder.AppendLine(Strings.StringShapes.#u2d(true) + this.Shapes.#OOb());
			return stringBuilder.ToString();
		}

		// Token: 0x040017B6 RID: 6070
		[CompilerGenerated]
		private EventHandler #a;

		// Token: 0x040017B7 RID: 6071
		[CompilerGenerated]
		private readonly IReadOnlyList<IObjectsSelectionManager> #b;

		// Token: 0x040017B8 RID: 6072
		[CompilerGenerated]
		private readonly ObjectsSelector #c;

		// Token: 0x040017B9 RID: 6073
		[CompilerGenerated]
		private readonly #QOb<ReinforcementBar> #d = new #QOb<ReinforcementBar>();

		// Token: 0x040017BA RID: 6074
		[CompilerGenerated]
		private readonly ShapesSelectionManager #e = new ShapesSelectionManager();

		// Token: 0x040017BB RID: 6075
		[CompilerGenerated]
		private readonly SelectionState #f;

		// Token: 0x040017BC RID: 6076
		[CompilerGenerated]
		private readonly DelegateCommand #g;
	}
}
