using System;
using System.Linq;
using System.Windows.Media.Media3D;
using #7hc;
using #UYd;
using Ab3d.Common.EventManager3D;
using Ab3d.Utilities;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor
{
	// Token: 0x0200093E RID: 2366
	public sealed class EventSource : IEventSource
	{
		// Token: 0x06004D49 RID: 19785 RVA: 0x0014E884 File Offset: 0x0014CA84
		public EventSource(IDrawingResult drawingResult)
		{
			#X0d.#V0d(drawingResult, #Phc.#3hc(107474044), Component.FailureSurfaceVisualization, #Phc.#3hc(107469714));
			this.drawingResult = drawingResult;
			Visual3D visual3D = drawingResult.RetrieveDisplayedObjects().OfType<Visual3D>().FirstOrDefault<Visual3D>();
			if (visual3D != null)
			{
				this.visualEventSource3D = new VisualEventSource3D(visual3D);
				this.visualEventSource3D.MouseEnter += this.VisualEventSource3D_MouseEnter;
				this.visualEventSource3D.MouseLeave += this.VisualEventSource3D_MouseLeave;
				this.visualEventSource3D.MouseClick += this.VisualEventSource3D_MouseClick;
				this.visualEventSource3D.MouseMove += this.VisualEventSource3D_MouseMove;
			}
		}

		// Token: 0x06004D4A RID: 19786 RVA: 0x00040DD7 File Offset: 0x0003EFD7
		private void VisualEventSource3D_MouseClick(object sender, MouseButton3DEventArgs e)
		{
			this.OnMouseClick(new MouseButtonEventArgs3D(e.CurrentMousePosition.Convert(), e.FinalPointHit.Convert(), this.drawingResult, e.MouseData));
		}

		// Token: 0x06004D4B RID: 19787 RVA: 0x0014E938 File Offset: 0x0014CB38
		private void VisualEventSource3D_MouseLeave(object sender, Mouse3DEventArgs e)
		{
			StructurePoint.CoreAssets.Infrastructure.Data.Point3D? hitMousePosition = null;
			try
			{
				hitMousePosition = new StructurePoint.CoreAssets.Infrastructure.Data.Point3D?(e.FinalPointHit.Convert());
			}
			catch (NullReferenceException)
			{
			}
			this.OnMouseLeave(new MouseEventArgs3D(e.CurrentMousePosition.Convert(), hitMousePosition, this.drawingResult));
		}

		// Token: 0x06004D4C RID: 19788 RVA: 0x00040E12 File Offset: 0x0003F012
		private void VisualEventSource3D_MouseEnter(object sender, Mouse3DEventArgs e)
		{
			this.OnMouseEnter(new MouseEventArgs3D(e.CurrentMousePosition.Convert(), new StructurePoint.CoreAssets.Infrastructure.Data.Point3D?(e.FinalPointHit.Convert()), this.drawingResult));
		}

		// Token: 0x06004D4D RID: 19789 RVA: 0x00040E4C File Offset: 0x0003F04C
		private void VisualEventSource3D_MouseMove(object sender, Mouse3DEventArgs e)
		{
			this.OnMouseMove(new MouseEventArgs3D(e.CurrentMousePosition.Convert(), new StructurePoint.CoreAssets.Infrastructure.Data.Point3D?(e.FinalPointHit.Convert()), this.drawingResult));
		}

		// Token: 0x06004D4E RID: 19790 RVA: 0x00040E86 File Offset: 0x0003F086
		public object RetrieveEventSource()
		{
			return this.visualEventSource3D;
		}

		// Token: 0x06004D4F RID: 19791 RVA: 0x0014E99C File Offset: 0x0014CB9C
		public void Release()
		{
			if (this.visualEventSource3D != null)
			{
				this.visualEventSource3D.MouseEnter -= this.VisualEventSource3D_MouseEnter;
				this.visualEventSource3D.MouseLeave -= this.VisualEventSource3D_MouseLeave;
				this.visualEventSource3D.MouseClick -= this.VisualEventSource3D_MouseClick;
				this.visualEventSource3D.MouseMove -= this.VisualEventSource3D_MouseMove;
				this.visualEventSource3D.TargetVisual3D = null;
			}
			this.visualEventSource3D = null;
			this.MouseClick = null;
			this.MouseEnter = null;
			this.MouseLeave = null;
			this.MouseMove = null;
			this.drawingResult = null;
		}

		// Token: 0x17001672 RID: 5746
		// (get) Token: 0x06004D50 RID: 19792 RVA: 0x00040E92 File Offset: 0x0003F092
		public IDrawingResult DrawingResult
		{
			get
			{
				return this.drawingResult;
			}
		}

		// Token: 0x14000122 RID: 290
		// (add) Token: 0x06004D51 RID: 19793 RVA: 0x0014EA64 File Offset: 0x0014CC64
		// (remove) Token: 0x06004D52 RID: 19794 RVA: 0x0014EAA8 File Offset: 0x0014CCA8
		public event EventHandler<MouseEventArgs3D> MouseEnter;

		// Token: 0x14000123 RID: 291
		// (add) Token: 0x06004D53 RID: 19795 RVA: 0x0014EAEC File Offset: 0x0014CCEC
		// (remove) Token: 0x06004D54 RID: 19796 RVA: 0x0014EB30 File Offset: 0x0014CD30
		public event EventHandler<MouseEventArgs3D> MouseLeave;

		// Token: 0x14000124 RID: 292
		// (add) Token: 0x06004D55 RID: 19797 RVA: 0x0014EB74 File Offset: 0x0014CD74
		// (remove) Token: 0x06004D56 RID: 19798 RVA: 0x0014EBB8 File Offset: 0x0014CDB8
		public event EventHandler<MouseButtonEventArgs3D> MouseClick;

		// Token: 0x14000125 RID: 293
		// (add) Token: 0x06004D57 RID: 19799 RVA: 0x0014EBFC File Offset: 0x0014CDFC
		// (remove) Token: 0x06004D58 RID: 19800 RVA: 0x0014EC40 File Offset: 0x0014CE40
		public event EventHandler<MouseEventArgs3D> MouseMove;

		// Token: 0x06004D59 RID: 19801 RVA: 0x0014EC84 File Offset: 0x0014CE84
		protected void OnMouseEnter(MouseEventArgs3D e)
		{
			EventHandler<MouseEventArgs3D> mouseEnter = this.MouseEnter;
			if (mouseEnter != null)
			{
				mouseEnter(this, e);
			}
		}

		// Token: 0x06004D5A RID: 19802 RVA: 0x0014ECB0 File Offset: 0x0014CEB0
		protected void OnMouseLeave(MouseEventArgs3D e)
		{
			EventHandler<MouseEventArgs3D> mouseLeave = this.MouseLeave;
			if (mouseLeave != null)
			{
				mouseLeave(this, e);
			}
		}

		// Token: 0x06004D5B RID: 19803 RVA: 0x0014ECDC File Offset: 0x0014CEDC
		protected void OnMouseClick(MouseButtonEventArgs3D e)
		{
			EventHandler<MouseButtonEventArgs3D> mouseClick = this.MouseClick;
			if (mouseClick != null)
			{
				mouseClick(this, e);
			}
		}

		// Token: 0x06004D5C RID: 19804 RVA: 0x0014ED08 File Offset: 0x0014CF08
		protected void OnMouseMove(MouseEventArgs3D e)
		{
			EventHandler<MouseEventArgs3D> mouseMove = this.MouseMove;
			if (mouseMove != null)
			{
				mouseMove(this, e);
			}
		}

		// Token: 0x0400220B RID: 8715
		private VisualEventSource3D visualEventSource3D;

		// Token: 0x0400220C RID: 8716
		private IDrawingResult drawingResult;
	}
}
