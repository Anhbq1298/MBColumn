using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace StructurePoint.CoreAssets.GUI.Framework.Services
{
	// Token: 0x02000C2C RID: 3116
	public abstract class MarkerServiceBase<T> where T : IDrawingResult
	{
		// Token: 0x0600652D RID: 25901 RVA: 0x00051B18 File Offset: 0x0004FD18
		protected MarkerServiceBase()
		{
			this.#d = Colors.Navy;
		}

		// Token: 0x17001C45 RID: 7237
		// (get) Token: 0x0600652E RID: 25902 RVA: 0x00051B36 File Offset: 0x0004FD36
		// (set) Token: 0x0600652F RID: 25903 RVA: 0x00051B3E File Offset: 0x0004FD3E
		private protected IModelEditorControl ModelEditorControl { protected get; private set; }

		// Token: 0x17001C46 RID: 7238
		// (get) Token: 0x06006530 RID: 25904 RVA: 0x00051B47 File Offset: 0x0004FD47
		protected IDrawingResultsFactory DrawingResultsFactory
		{
			get
			{
				return this.#a;
			}
		}

		// Token: 0x17001C47 RID: 7239
		// (get) Token: 0x06006531 RID: 25905 RVA: 0x00051B4F File Offset: 0x0004FD4F
		// (set) Token: 0x06006532 RID: 25906 RVA: 0x00051B57 File Offset: 0x0004FD57
		public Color MarkerColor
		{
			get
			{
				return this.#d;
			}
			set
			{
				for (;;)
				{
					if (!false && !(this.#d != value))
					{
						goto IL_20;
					}
					IL_11:
					if (false)
					{
						continue;
					}
					this.#d = value;
					if (!false)
					{
						this.#vRc();
					}
					IL_20:
					if (!false)
					{
						break;
					}
					goto IL_11;
				}
			}
		}

		// Token: 0x06006533 RID: 25907
		protected abstract T #4Qc();

		// Token: 0x06006534 RID: 25908
		protected abstract void #5Qc(T #YQc, Point3D #0bb);

		// Token: 0x06006535 RID: 25909
		protected abstract void #6Qc(T #7Qc);

		// Token: 0x06006536 RID: 25910 RVA: 0x0018DB90 File Offset: 0x0018BD90
		public void #QQc(IModelEditorControl #RQc, IDrawingResultsFactory #SQc)
		{
			string #R0d = #Phc.#3hc(107444019);
			Component #x6c = Component.GUIFramework;
			string #Qic = #Phc.#3hc(107442702);
			if (!false)
			{
				#X0d.#V0d(#RQc, #R0d, #x6c, #Qic);
			}
			string #R0d2 = #Phc.#3hc(107443393);
			Component #x6c2 = Component.GUIFramework;
			string #Qic2 = #Phc.#3hc(107443193);
			if (4 != 0)
			{
				#X0d.#V0d(#SQc, #R0d2, #x6c2, #Qic2);
			}
			if (!false)
			{
				this.ModelEditorControl = #RQc;
			}
			this.#a = #SQc;
			this.#b = true;
			IModelEditorControl modelEditorControl = this.ModelEditorControl;
			EventHandler value = new EventHandler(this.#QEc);
			if (7 != 0)
			{
				modelEditorControl.CameraChanged += value;
			}
		}

		// Token: 0x06006537 RID: 25911 RVA: 0x0018DC24 File Offset: 0x0018BE24
		public void #qRc(Point3D #0bb)
		{
			if (!this.#b)
			{
				return;
			}
			T t = this.#4Qc();
			T t2;
			if (!false)
			{
				t2 = t;
			}
			IModelEditorControl modelEditorControl = this.ModelEditorControl;
			IDrawingResult drawingResult = t2;
			if (8 != 0)
			{
				modelEditorControl.AddToView(drawingResult);
			}
			!0 #YQc = t2;
			if (!false)
			{
				this.#5Qc(#YQc, #0bb);
			}
			ICollection<KeyValuePair<Point3D, !0>> collection = this.#c;
			KeyValuePair<Point3D, !0> item = new KeyValuePair<Point3D, !0>(#0bb, t2);
			if (3 != 0)
			{
				collection.Add(item);
			}
		}

		// Token: 0x06006538 RID: 25912 RVA: 0x0018DC88 File Offset: 0x0018BE88
		public void #rRc(Point3D #YBb, Point3D #sRc)
		{
			MarkerServiceBase<T>.#uZb #uZb2;
			if (!false)
			{
				MarkerServiceBase<T>.#uZb #uZb = new MarkerServiceBase<!0>.#uZb();
				if (3 != 0)
				{
					#uZb2 = #uZb;
				}
			}
			for (;;)
			{
				#uZb2.#a = #sRc;
				if (!this.#b)
				{
					if (!false)
					{
						break;
					}
				}
				else if (!false)
				{
					goto Block_4;
				}
			}
			return;
			Block_4:
			KeyValuePair<Point3D, T> keyValuePair = this.#c.FirstOrDefault(new Func<KeyValuePair<Point3D, !0>, bool>(#uZb2.#Cad));
			KeyValuePair<Point3D, T> item;
			if (6 != 0)
			{
				item = keyValuePair;
			}
			if (7 != 0)
			{
				this.#c.Remove(item);
				!0 value = item.Value;
				if (!false)
				{
					this.#5Qc(value, #YBb);
				}
			}
			ICollection<KeyValuePair<Point3D, !0>> collection = this.#c;
			KeyValuePair<Point3D, !0> item2 = new KeyValuePair<Point3D, !0>(#YBb, item.Value);
			if (true)
			{
				collection.Add(item2);
			}
		}

		// Token: 0x06006539 RID: 25913 RVA: 0x0018DD20 File Offset: 0x0018BF20
		public void #tRc(Point3D #0bb)
		{
			MarkerServiceBase<T>.#wWb #wWb = new MarkerServiceBase<!0>.#wWb();
			MarkerServiceBase<T>.#wWb #wWb2;
			if (!false)
			{
				#wWb2 = #wWb;
			}
			#wWb2.#a = #0bb;
			if (!this.#b)
			{
				return;
			}
			KeyValuePair<Point3D, T> keyValuePair = this.#c.FirstOrDefault(new Func<KeyValuePair<Point3D, !0>, bool>(#wWb2.#Dad));
			KeyValuePair<Point3D, T> item;
			if (4 != 0)
			{
				item = keyValuePair;
			}
			this.#c.Remove(item);
			if (item.Value != null)
			{
				IModelEditorControl modelEditorControl = this.ModelEditorControl;
				IDrawingResult drawingResult = item.Value;
				if (!false)
				{
					modelEditorControl.RemoveFromView(drawingResult);
				}
			}
		}

		// Token: 0x0600653A RID: 25914 RVA: 0x0018DDA0 File Offset: 0x0018BFA0
		public void #yl()
		{
			IEnumerable<IDrawingResult> enumerable = (IEnumerable<IDrawingResult>)this.#c.Select(new Func<KeyValuePair<Point3D, !0>, !0>(MarkerServiceBase<!0>.<>c.<>9.#Ead));
			IEnumerable<IDrawingResult> enumerable2;
			if (7 != 0)
			{
				enumerable2 = enumerable;
			}
			IModelEditorControl modelEditorControl = this.ModelEditorControl;
			IEnumerable<IDrawingResult> drawingResults = enumerable2;
			if (!false)
			{
				modelEditorControl.RemoveFromView(drawingResults);
			}
			ICollection<KeyValuePair<Point3D, !0>> collection = this.#c;
			if (!false)
			{
				collection.Clear();
			}
		}

		// Token: 0x0600653B RID: 25915 RVA: 0x00051B83 File Offset: 0x0004FD83
		private void #QEc(object #Ge, EventArgs #He)
		{
			if (this.#b && !false)
			{
				this.#uRc();
			}
		}

		// Token: 0x0600653C RID: 25916 RVA: 0x00051B99 File Offset: 0x0004FD99
		private double #oRc()
		{
			if (4 != 0 && this.#e == null)
			{
				this.#e = new double?(this.ModelEditorControl.CalculateViewScale());
			}
			return this.#e.Value;
		}

		// Token: 0x0600653D RID: 25917 RVA: 0x0018DE08 File Offset: 0x0018C008
		private void #uRc()
		{
			IEnumerator<KeyValuePair<Point3D, T>> enumerator = this.#c.GetEnumerator();
			IEnumerator<KeyValuePair<Point3D, T>> enumerator2;
			if (!false)
			{
				enumerator2 = enumerator;
			}
			try
			{
				while (enumerator2.MoveNext())
				{
					KeyValuePair<Point3D, T> keyValuePair = enumerator2.Current;
					KeyValuePair<Point3D, T> keyValuePair2;
					if (!false)
					{
						keyValuePair2 = keyValuePair;
					}
					!0 value = keyValuePair2.Value;
					Point3D key = keyValuePair2.Key;
					if (!false)
					{
						this.#5Qc(value, key);
					}
				}
			}
			finally
			{
				for (;;)
				{
					if (enumerator2 != null)
					{
						goto IL_47;
					}
					IL_50:
					if (!true)
					{
						continue;
					}
					if (!false)
					{
						break;
					}
					IL_47:
					if (-1 != 0)
					{
						enumerator2.Dispose();
						goto IL_50;
					}
					goto IL_50;
				}
			}
		}

		// Token: 0x0600653E RID: 25918 RVA: 0x0018DE80 File Offset: 0x0018C080
		private void #vRc()
		{
			IEnumerator<KeyValuePair<Point3D, T>> enumerator = this.#c.GetEnumerator();
			IEnumerator<KeyValuePair<Point3D, T>> enumerator2;
			if (!false)
			{
				enumerator2 = enumerator;
			}
			try
			{
				while (enumerator2.MoveNext() && !false)
				{
					KeyValuePair<Point3D, T> keyValuePair = enumerator2.Current;
					KeyValuePair<Point3D, T> keyValuePair2;
					if (2 != 0)
					{
						keyValuePair2 = keyValuePair;
					}
					if (-1 == 0 || keyValuePair2.Value != null)
					{
						!0 value = keyValuePair2.Value;
						if (!false)
						{
							this.#6Qc(value);
						}
					}
				}
			}
			finally
			{
				do
				{
					if (enumerator2 != null)
					{
						enumerator2.Dispose();
					}
				}
				while (4 == 0);
			}
		}

		// Token: 0x04002989 RID: 10633
		private IDrawingResultsFactory #a;

		// Token: 0x0400298A RID: 10634
		private bool #b;

		// Token: 0x0400298B RID: 10635
		private IList<KeyValuePair<Point3D, T>> #c = new List<KeyValuePair<Point3D, !0>>();

		// Token: 0x0400298C RID: 10636
		private Color #d;

		// Token: 0x0400298D RID: 10637
		private double? #e;

		// Token: 0x0400298E RID: 10638
		[CompilerGenerated]
		private IModelEditorControl #f;

		// Token: 0x02000C2E RID: 3118
		[CompilerGenerated]
		private sealed class #uZb
		{
			// Token: 0x06006543 RID: 25923 RVA: 0x00051BE1 File Offset: 0x0004FDE1
			internal bool #Cad(KeyValuePair<Point3D, #Fu> #Rf)
			{
				return Point3D.#E3d(#Rf.Key, this.#a);
			}

			// Token: 0x04002991 RID: 10641
			public Point3D #a;
		}

		// Token: 0x02000C2F RID: 3119
		[CompilerGenerated]
		private sealed class #wWb
		{
			// Token: 0x06006545 RID: 25925 RVA: 0x00051BF5 File Offset: 0x0004FDF5
			internal bool #Dad(KeyValuePair<Point3D, #Fu> #Rf)
			{
				return Point3D.#E3d(#Rf.Key, this.#a);
			}

			// Token: 0x04002992 RID: 10642
			public Point3D #a;
		}
	}
}
