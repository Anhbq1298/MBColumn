using System;
using System.Windows.Controls;
using System.Windows.Media.Media3D;
using #7hc;
using #UYd;
using Ab3d.Cameras;
using Ab3d.Utilities;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor
{
	// Token: 0x02000933 RID: 2355
	internal sealed class TransparencySorter : ITransparencySorter
	{
		// Token: 0x17001659 RID: 5721
		// (get) Token: 0x06004CCD RID: 19661 RVA: 0x00040565 File Offset: 0x0003E765
		// (set) Token: 0x06004CCE RID: 19662 RVA: 0x00040571 File Offset: 0x0003E771
		public bool IsSortingOnCameraChange { get; private set; }

		// Token: 0x1700165A RID: 5722
		// (get) Token: 0x06004CCF RID: 19663 RVA: 0x00040582 File Offset: 0x0003E782
		// (set) Token: 0x06004CD0 RID: 19664 RVA: 0x00040597 File Offset: 0x0003E797
		public CustomSortingModeType CustomSortingMode
		{
			get
			{
				return this.transparencySorter.CustomSortingMode;
			}
			set
			{
				this.transparencySorter.CustomSortingMode = value;
			}
		}

		// Token: 0x06004CD1 RID: 19665 RVA: 0x000405B1 File Offset: 0x0003E7B1
		internal TransparencySorter(Viewport3D viewport, TargetPositionCamera camera)
		{
			this.viewport = viewport;
			this.transparencySorter = new CustomTransparencySorter(viewport, camera);
			this.AreManualOperationsEnabled = true;
		}

		// Token: 0x06004CD2 RID: 19666 RVA: 0x000405D4 File Offset: 0x0003E7D4
		public IBulkUpdateScope BeginBulkUpdate()
		{
			return new BulkUpdateScope(this);
		}

		// Token: 0x06004CD3 RID: 19667 RVA: 0x000405E4 File Offset: 0x0003E7E4
		public void PerformTransparencySort()
		{
			if (this.AreManualOperationsEnabled)
			{
				this.transparencySorter.Sort();
			}
		}

		// Token: 0x06004CD4 RID: 19668 RVA: 0x00040606 File Offset: 0x0003E806
		public void PerformSimpleTransparencySort()
		{
			if (this.AreManualOperationsEnabled)
			{
				TransparencySorter.SimpleSort(this.viewport);
			}
		}

		// Token: 0x06004CD5 RID: 19669 RVA: 0x0014D870 File Offset: 0x0014BA70
		public void AddExcludedVisual(IDrawingResult drawingResult)
		{
			#X0d.#V0d(drawingResult, #Phc.#3hc(107474044), Component.DesktopControls, #Phc.#3hc(107469967));
			this.transparencySorter.ExcludedVisuals.Add((Visual3D)drawingResult.RetrieveDisplayedObject());
		}

		// Token: 0x06004CD6 RID: 19670 RVA: 0x00040628 File Offset: 0x0003E828
		public void AddAlwaysOnTopVisual(IDrawingResult drawingResult)
		{
			#X0d.#V0d(drawingResult, #Phc.#3hc(107474044), Component.DesktopControls, #Phc.#3hc(107469946));
			this.transparencySorter.AddAlwaysOnTopVisual((Visual3D)drawingResult.RetrieveDisplayedObject());
		}

		// Token: 0x06004CD7 RID: 19671 RVA: 0x00040667 File Offset: 0x0003E867
		public void RemoveAlwaysOnTopVisual(IDrawingResult drawingResult)
		{
			#X0d.#V0d(drawingResult, #Phc.#3hc(107474044), Component.DesktopControls, #Phc.#3hc(107469861));
			this.transparencySorter.RemoveAlwaysOnTopVisual((Visual3D)drawingResult.RetrieveDisplayedObject());
		}

		// Token: 0x06004CD8 RID: 19672 RVA: 0x000406A6 File Offset: 0x0003E8A6
		public void ConfigureTransparencySorting(double angle, CustomSortingModeType customSortingMode)
		{
			this.transparencySorter.CameraAngleChange = angle;
			this.CustomSortingMode = customSortingMode;
		}

		// Token: 0x06004CD9 RID: 19673 RVA: 0x000406C7 File Offset: 0x0003E8C7
		public void StartTransparencySorting()
		{
			this.IsSortingOnCameraChange = true;
			this.transparencySorter.StartSortingOnCameraChanged();
		}

		// Token: 0x06004CDA RID: 19674 RVA: 0x000406E7 File Offset: 0x0003E8E7
		public void RecollectTransparentModels()
		{
			if (this.AreManualOperationsEnabled)
			{
				this.transparencySorter.RecollectTransparentModels();
			}
		}

		// Token: 0x06004CDB RID: 19675 RVA: 0x00040708 File Offset: 0x0003E908
		public void Refresh()
		{
			if (this.AreManualOperationsEnabled)
			{
				this.transparencySorter.RecollectTransparentModels();
				this.transparencySorter.Sort();
			}
		}

		// Token: 0x1700165B RID: 5723
		// (get) Token: 0x06004CDC RID: 19676 RVA: 0x00040735 File Offset: 0x0003E935
		// (set) Token: 0x06004CDD RID: 19677 RVA: 0x00040741 File Offset: 0x0003E941
		public bool AreManualOperationsEnabled { get; set; }

		// Token: 0x040021E5 RID: 8677
		private readonly CustomTransparencySorter transparencySorter;

		// Token: 0x040021E6 RID: 8678
		private readonly Viewport3D viewport;
	}
}
