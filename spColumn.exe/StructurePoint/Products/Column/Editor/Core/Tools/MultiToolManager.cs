using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using #cMb;
using devDept.Eyeshot;
using devDept.Geometry;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core;
using StructurePoint.Products.Column.Editor.Section.Irregular.Tools.Select.Core;

namespace StructurePoint.Products.Column.Editor.Core.Tools
{
	// Token: 0x02000680 RID: 1664
	internal sealed class MultiToolManager : #uNb
	{
		// Token: 0x06003803 RID: 14339 RVA: 0x00030A04 File Offset: 0x0002EC04
		public MultiToolManager(IMultiToolChild primary, params IMultiToolChild[] children)
		{
			this.#a.AddRange(children);
			this.#a.Add(primary);
		}

		// Token: 0x06003804 RID: 14340 RVA: 0x00030A2F File Offset: 0x0002EC2F
		public void #2B()
		{
			this.#HNb(new Action<IMultiToolChild>(MultiToolManager.<>c.<>9.#rcc), false, false, false);
		}

		// Token: 0x06003805 RID: 14341 RVA: 0x00030A61 File Offset: 0x0002EC61
		public void #3B()
		{
			this.#HNb(new Action<IMultiToolChild>(MultiToolManager.<>c.<>9.#scc), false, false, false);
		}

		// Token: 0x06003806 RID: 14342 RVA: 0x00030A93 File Offset: 0x0002EC93
		public void #ENb()
		{
			this.#HNb(new Action<IMultiToolChild>(MultiToolManager.<>c.<>9.#tcc), false, false, false);
		}

		// Token: 0x17001157 RID: 4439
		// (get) Token: 0x06003807 RID: 14343 RVA: 0x00030AC5 File Offset: 0x0002ECC5
		public IView ParametersView { get; }

		// Token: 0x06003808 RID: 14344 RVA: 0x00030AD1 File Offset: 0x0002ECD1
		public void #1kb()
		{
			this.#HNb(new Action<IMultiToolChild>(MultiToolManager.<>c.<>9.#ucc), false, false, false);
		}

		// Token: 0x06003809 RID: 14345 RVA: 0x0010F120 File Offset: 0x0010D320
		public void HandleMouseUp(MouseButtonEventArgs args, Point screenPosition, Point3D planePosition)
		{
			MultiToolManager.#s0b #s0b = new MultiToolManager.#s0b();
			#s0b.#a = args;
			#s0b.#b = screenPosition;
			#s0b.#c = planePosition;
			this.#HNb(new Action<IMultiToolChild>(#s0b.#ycc), false, true, false);
		}

		// Token: 0x0600380A RID: 14346 RVA: 0x0010F16C File Offset: 0x0010D36C
		public void HandleMouseDown(MouseButtonEventArgs args, Point screenPosition, Point3D planePosition)
		{
			MultiToolManager.#oWb #oWb = new MultiToolManager.#oWb();
			#oWb.#a = args;
			#oWb.#b = screenPosition;
			#oWb.#c = planePosition;
			bool #JNb = #oWb.#a.ChangedButton == System.Windows.Input.MouseButton.Right;
			this.#HNb(new Action<IMultiToolChild>(#oWb.#Q9b), false, #JNb, false);
		}

		// Token: 0x0600380B RID: 14347 RVA: 0x0010F1C4 File Offset: 0x0010D3C4
		public void HandleMouseMove(MouseEventArgs args, Point screenPosition, Point3D planePosition)
		{
			MultiToolManager.#21b #21b = new MultiToolManager.#21b();
			#21b.#a = args;
			#21b.#b = screenPosition;
			#21b.#c = planePosition;
			this.#HNb(new Action<IMultiToolChild>(#21b.#zcc), false, false, false);
		}

		// Token: 0x0600380C RID: 14348 RVA: 0x0010F210 File Offset: 0x0010D410
		public void HandleDrawOverlay(devDept.Eyeshot.Environment.DrawSceneParams data, Point screenPosition, Point3D planePosition)
		{
			MultiToolManager.#iZb #iZb = new MultiToolManager.#iZb();
			#iZb.#a = data;
			#iZb.#b = screenPosition;
			#iZb.#c = planePosition;
			this.#HNb(new Action<IMultiToolChild>(#iZb.#Acc), true, false, true);
		}

		// Token: 0x0600380D RID: 14349 RVA: 0x0010F25C File Offset: 0x0010D45C
		public void HandleKeyDown(KeyEventArgs args)
		{
			MultiToolManager.#BUb #BUb = new MultiToolManager.#BUb();
			MultiToolManager.#BUb #BUb2;
			if (!false)
			{
				#BUb2 = #BUb;
			}
			#BUb2.#a = args;
			this.#HNb(new Action<IMultiToolChild>(#BUb2.#Bcc), false, false, false);
		}

		// Token: 0x0600380E RID: 14350 RVA: 0x0010F29C File Offset: 0x0010D49C
		public void HandleKeyUp(KeyEventArgs args)
		{
			MultiToolManager.#61b #61b = new MultiToolManager.#61b();
			MultiToolManager.#61b #61b2;
			if (!false)
			{
				#61b2 = #61b;
			}
			#61b2.#a = args;
			this.#HNb(new Action<IMultiToolChild>(#61b2.#Ccc), false, true, false);
		}

		// Token: 0x0600380F RID: 14351 RVA: 0x0010F2DC File Offset: 0x0010D4DC
		public void HandleDynamicInputCoordinateChange(DynamicInputCoordinateEventArgs args)
		{
			MultiToolManager.#8Ub #8Ub = new MultiToolManager.#8Ub();
			MultiToolManager.#8Ub #8Ub2;
			if (!false)
			{
				#8Ub2 = #8Ub;
			}
			#8Ub2.#a = args;
			this.#HNb(new Action<IMultiToolChild>(#8Ub2.#Dcc), false, true, false);
		}

		// Token: 0x06003810 RID: 14352 RVA: 0x0010F31C File Offset: 0x0010D51C
		public void HandleDynamicInputCoordinateCommited(DynamicInputCoordinateEventArgs args)
		{
			MultiToolManager.#rWb #rWb = new MultiToolManager.#rWb();
			MultiToolManager.#rWb #rWb2;
			if (!false)
			{
				#rWb2 = #rWb;
			}
			#rWb2.#a = args;
			this.#HNb(new Action<IMultiToolChild>(#rWb2.#Ecc), false, true, false);
		}

		// Token: 0x06003811 RID: 14353 RVA: 0x0010F35C File Offset: 0x0010D55C
		public void HandleDynamicInputCoordinateValidation(DynamicInputValueValidationEventArgs args)
		{
			MultiToolManager.#DUb #DUb = new MultiToolManager.#DUb();
			MultiToolManager.#DUb #DUb2;
			if (!false)
			{
				#DUb2 = #DUb;
			}
			#DUb2.#a = args;
			this.#HNb(new Action<IMultiToolChild>(#DUb2.#Fcc), false, true, false);
		}

		// Token: 0x06003812 RID: 14354 RVA: 0x0010F39C File Offset: 0x0010D59C
		public void HandleDynamicInputCoordinateSnapRequested(DynamicInputCoordinateSnapEventArgs args)
		{
			MultiToolManager.#i9b #i9b = new MultiToolManager.#i9b();
			MultiToolManager.#i9b #i9b2;
			if (!false)
			{
				#i9b2 = #i9b;
			}
			#i9b2.#a = args;
			this.#HNb(new Action<IMultiToolChild>(#i9b2.#Gcc), false, true, false);
		}

		// Token: 0x06003813 RID: 14355 RVA: 0x00030B03 File Offset: 0x0002ED03
		public void #FNb()
		{
			this.#a.ForEach(new Action<IMultiToolChild>(MultiToolManager.<>c.<>9.#vcc));
		}

		// Token: 0x06003814 RID: 14356 RVA: 0x00030B37 File Offset: 0x0002ED37
		public bool #GNb()
		{
			return this.#a.Any(new Func<IMultiToolChild, bool>(MultiToolManager.<>c.<>9.#wcc));
		}

		// Token: 0x06003815 RID: 14357 RVA: 0x0010F3DC File Offset: 0x0010D5DC
		private void #HNb(Action<IMultiToolChild> #nd, bool #INb = false, bool #JNb = false, bool #KNb = false)
		{
			List<IMultiToolChild> list = this.#a.OrderByDescending(new Func<IMultiToolChild, bool>(MultiToolManager.<>c.<>9.#xcc)).ToList<IMultiToolChild>();
			if (#KNb)
			{
				list.Reverse();
			}
			foreach (IMultiToolChild multiToolChild in list)
			{
				bool flag = multiToolChild is SelectObjectsToolImpl;
				bool flag2 = multiToolChild.IsWorking || flag;
				if (!#JNb || flag2)
				{
					#nd(multiToolChild);
					if (!#INb)
					{
						bool flag3 = flag2 != multiToolChild.IsWorking;
						if (multiToolChild.IsWorking || flag3)
						{
							if (flag3)
							{
								this.#FNb();
								break;
							}
							break;
						}
					}
				}
			}
		}

		// Token: 0x04001776 RID: 6006
		private readonly List<IMultiToolChild> #a = new List<IMultiToolChild>();

		// Token: 0x04001777 RID: 6007
		[CompilerGenerated]
		private readonly IView #b;

		// Token: 0x02000682 RID: 1666
		[CompilerGenerated]
		private sealed class #oWb
		{
			// Token: 0x06003820 RID: 14368 RVA: 0x00030BDB File Offset: 0x0002EDDB
			internal void #Q9b(IMultiToolChild #Ph)
			{
				#Ph.HandleMouseDown(this.#a, this.#b, this.#c);
			}

			// Token: 0x04001780 RID: 6016
			public MouseButtonEventArgs #a;

			// Token: 0x04001781 RID: 6017
			public Point #b;

			// Token: 0x04001782 RID: 6018
			public Point3D #c;
		}

		// Token: 0x02000683 RID: 1667
		[CompilerGenerated]
		private sealed class #21b
		{
			// Token: 0x06003822 RID: 14370 RVA: 0x00030C01 File Offset: 0x0002EE01
			internal void #zcc(IMultiToolChild #Ph)
			{
				#Ph.HandleMouseMove(this.#a, this.#b, this.#c);
			}

			// Token: 0x04001783 RID: 6019
			public MouseEventArgs #a;

			// Token: 0x04001784 RID: 6020
			public Point #b;

			// Token: 0x04001785 RID: 6021
			public Point3D #c;
		}

		// Token: 0x02000684 RID: 1668
		[CompilerGenerated]
		private sealed class #iZb
		{
			// Token: 0x06003824 RID: 14372 RVA: 0x00030C27 File Offset: 0x0002EE27
			internal void #Acc(IMultiToolChild #Ph)
			{
				#Ph.HandleDrawOverlay(this.#a, this.#b, this.#c);
			}

			// Token: 0x04001786 RID: 6022
			public devDept.Eyeshot.Environment.DrawSceneParams #a;

			// Token: 0x04001787 RID: 6023
			public Point #b;

			// Token: 0x04001788 RID: 6024
			public Point3D #c;
		}

		// Token: 0x02000685 RID: 1669
		[CompilerGenerated]
		private sealed class #BUb
		{
			// Token: 0x06003826 RID: 14374 RVA: 0x00030C4D File Offset: 0x0002EE4D
			internal void #Bcc(IMultiToolChild #Ph)
			{
				#Ph.HandleKeyDown(this.#a);
			}

			// Token: 0x04001789 RID: 6025
			public KeyEventArgs #a;
		}

		// Token: 0x02000686 RID: 1670
		[CompilerGenerated]
		private sealed class #61b
		{
			// Token: 0x06003828 RID: 14376 RVA: 0x00030C67 File Offset: 0x0002EE67
			internal void #Ccc(IMultiToolChild #Ph)
			{
				#Ph.HandleKeyUp(this.#a);
			}

			// Token: 0x0400178A RID: 6026
			public KeyEventArgs #a;
		}

		// Token: 0x02000687 RID: 1671
		[CompilerGenerated]
		private sealed class #8Ub
		{
			// Token: 0x0600382A RID: 14378 RVA: 0x00030C81 File Offset: 0x0002EE81
			internal void #Dcc(IMultiToolChild #Ph)
			{
				#Ph.HandleDynamicInputCoordinateChange(this.#a);
			}

			// Token: 0x0400178B RID: 6027
			public DynamicInputCoordinateEventArgs #a;
		}

		// Token: 0x02000688 RID: 1672
		[CompilerGenerated]
		private sealed class #rWb
		{
			// Token: 0x0600382C RID: 14380 RVA: 0x00030C9B File Offset: 0x0002EE9B
			internal void #Ecc(IMultiToolChild #Ph)
			{
				#Ph.HandleDynamicInputCoordinateCommited(this.#a);
			}

			// Token: 0x0400178C RID: 6028
			public DynamicInputCoordinateEventArgs #a;
		}

		// Token: 0x02000689 RID: 1673
		[CompilerGenerated]
		private sealed class #DUb
		{
			// Token: 0x0600382E RID: 14382 RVA: 0x00030CB5 File Offset: 0x0002EEB5
			internal void #Fcc(IMultiToolChild #Ph)
			{
				#Ph.HandleDynamicInputCoordinateValidation(this.#a);
			}

			// Token: 0x0400178D RID: 6029
			public DynamicInputValueValidationEventArgs #a;
		}

		// Token: 0x0200068A RID: 1674
		[CompilerGenerated]
		private sealed class #i9b
		{
			// Token: 0x06003830 RID: 14384 RVA: 0x00030CCF File Offset: 0x0002EECF
			internal void #Gcc(IMultiToolChild #Ph)
			{
				#Ph.HandleDynamicInputCoordinateSnapRequested(this.#a);
			}

			// Token: 0x0400178E RID: 6030
			public DynamicInputCoordinateSnapEventArgs #a;
		}

		// Token: 0x0200068B RID: 1675
		[CompilerGenerated]
		private sealed class #s0b
		{
			// Token: 0x06003832 RID: 14386 RVA: 0x00030CE9 File Offset: 0x0002EEE9
			internal void #ycc(IMultiToolChild #Ph)
			{
				#Ph.HandleMouseUp(this.#a, this.#b, this.#c);
			}

			// Token: 0x0400178F RID: 6031
			public MouseButtonEventArgs #a;

			// Token: 0x04001790 RID: 6032
			public Point #b;

			// Token: 0x04001791 RID: 6033
			public Point3D #c;
		}
	}
}
