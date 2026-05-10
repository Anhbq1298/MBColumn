using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Media3D;
using #7hc;
using Ab3d.Utilities;
using Ab3d.Visuals;
using HelixToolkit.Wpf;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor.ViewCubeControl.API;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor.ViewCubeControl
{
	// Token: 0x02000958 RID: 2392
	internal sealed class ViewCubeVisualsHelperRegular : ViewCubeVisualsHelper, IViewCubeVisualsHelper
	{
		// Token: 0x06004E7E RID: 20094 RVA: 0x00041BDC File Offset: 0x0003FDDC
		public ViewCubeVisualsHelperRegular()
		{
			this.<ViewCubeSize>k__BackingField = new Size(20.0, 20.0);
			base..ctor();
			this.CreateViewCubeBox();
		}

		// Token: 0x170016D0 RID: 5840
		// (get) Token: 0x06004E7F RID: 20095 RVA: 0x00041C07 File Offset: 0x0003FE07
		public Size ViewCubeSize { get; }

		// Token: 0x170016D1 RID: 5841
		// (get) Token: 0x06004E80 RID: 20096 RVA: 0x00041C13 File Offset: 0x0003FE13
		public double CameraDistance
		{
			get
			{
				return 75.0;
			}
		}

		// Token: 0x170016D2 RID: 5842
		// (get) Token: 0x06004E81 RID: 20097 RVA: 0x00041C1E File Offset: 0x0003FE1E
		public override string MainDirButtons
		{
			get
			{
				return string.Format(CultureInfo.InvariantCulture, #Phc.#3hc(107467883), new object[]
				{
					base.AssemblyName
				});
			}
		}

		// Token: 0x170016D3 RID: 5843
		// (get) Token: 0x06004E82 RID: 20098 RVA: 0x00041C4F File Offset: 0x0003FE4F
		public override string MainDirTextures
		{
			get
			{
				return string.Format(CultureInfo.InvariantCulture, #Phc.#3hc(107467806), new object[]
				{
					base.AssemblyName
				});
			}
		}

		// Token: 0x06004E83 RID: 20099 RVA: 0x00153B2C File Offset: 0x00151D2C
		public IEnumerable<PlaneVisual3D> CreateFrontTopEdge(MouseEventHandlers mouseEventHandlers, EventManager3D eventManager)
		{
			PlaneVisual3D planeVisual3D = new PlaneVisual3D
			{
				CenterPosition = new Point3D(0.0, 7.5, 10.0 + base.Offset),
				Size = new Size(10.0, 5.0),
				Normal = new Vector3D(0.0, 0.0, 1.0),
				HeightDirection = new Vector3D(0.0, 1.0, 0.0),
				Material = base.TransparentMaterial
			};
			PlaneVisual3D planeVisual3D2 = new PlaneVisual3D
			{
				CenterPosition = new Point3D(0.0, 10.0 + base.Offset, 7.5),
				Size = new Size(10.0, 5.0),
				Normal = new Vector3D(0.0, 1.0, 0.0),
				HeightDirection = new Vector3D(0.0, 0.0, 1.0),
				Material = base.TransparentMaterial
			};
			base.SetupMouseEventHandlers(planeVisual3D, mouseEventHandlers, eventManager);
			base.SetupMouseEventHandlers(planeVisual3D2, mouseEventHandlers, eventManager);
			return new PlaneVisual3D[]
			{
				planeVisual3D,
				planeVisual3D2
			};
		}

		// Token: 0x06004E84 RID: 20100 RVA: 0x00153CC8 File Offset: 0x00151EC8
		public IEnumerable<PlaneVisual3D> CreateBackTopEdge(MouseEventHandlers mouseEventHandlers, EventManager3D eventManager)
		{
			PlaneVisual3D planeVisual3D = new PlaneVisual3D
			{
				CenterPosition = new Point3D(0.0, 7.5, -10.0 - base.Offset),
				Size = new Size(10.0, 5.0),
				Normal = new Vector3D(0.0, 0.0, -1.0),
				HeightDirection = new Vector3D(0.0, 1.0, 0.0),
				Material = base.TransparentMaterial
			};
			PlaneVisual3D planeVisual3D2 = new PlaneVisual3D
			{
				CenterPosition = new Point3D(0.0, 10.0 + base.Offset, -7.5),
				Size = new Size(10.0, 5.0),
				Normal = new Vector3D(0.0, 1.0, 0.0),
				HeightDirection = new Vector3D(0.0, 0.0, 1.0),
				Material = base.TransparentMaterial
			};
			base.SetupMouseEventHandlers(planeVisual3D, mouseEventHandlers, eventManager);
			base.SetupMouseEventHandlers(planeVisual3D2, mouseEventHandlers, eventManager);
			return new PlaneVisual3D[]
			{
				planeVisual3D,
				planeVisual3D2
			};
		}

		// Token: 0x06004E85 RID: 20101 RVA: 0x00153E64 File Offset: 0x00152064
		public IEnumerable<PlaneVisual3D> CreateBackBottomEdge(MouseEventHandlers mouseEventHandlers, EventManager3D eventManager)
		{
			PlaneVisual3D planeVisual3D = new PlaneVisual3D
			{
				CenterPosition = new Point3D(0.0, -7.5, -10.0 - base.Offset),
				Size = new Size(10.0, 5.0),
				Normal = new Vector3D(0.0, 0.0, -1.0),
				HeightDirection = new Vector3D(0.0, 1.0, 0.0),
				Material = base.TransparentMaterial
			};
			PlaneVisual3D planeVisual3D2 = new PlaneVisual3D
			{
				CenterPosition = new Point3D(0.0, -10.0 - base.Offset, -7.5),
				Size = new Size(10.0, 5.0),
				Normal = new Vector3D(0.0, -1.0, 0.0),
				HeightDirection = new Vector3D(0.0, 0.0, 1.0),
				Material = base.TransparentMaterial
			};
			base.SetupMouseEventHandlers(planeVisual3D, mouseEventHandlers, eventManager);
			base.SetupMouseEventHandlers(planeVisual3D2, mouseEventHandlers, eventManager);
			return new PlaneVisual3D[]
			{
				planeVisual3D,
				planeVisual3D2
			};
		}

		// Token: 0x06004E86 RID: 20102 RVA: 0x00154000 File Offset: 0x00152200
		public IEnumerable<PlaneVisual3D> CreateFrontBottomEdge(MouseEventHandlers mouseEventHandlers, EventManager3D eventManager)
		{
			PlaneVisual3D planeVisual3D = new PlaneVisual3D
			{
				CenterPosition = new Point3D(0.0, -7.5, 10.0 + base.Offset),
				Size = new Size(10.0, 5.0),
				Normal = new Vector3D(0.0, 0.0, 1.0),
				HeightDirection = new Vector3D(0.0, 1.0, 0.0),
				Material = base.TransparentMaterial
			};
			PlaneVisual3D planeVisual3D2 = new PlaneVisual3D
			{
				CenterPosition = new Point3D(0.0, -10.0 - base.Offset, 7.5),
				Size = new Size(10.0, 5.0),
				Normal = new Vector3D(0.0, -1.0, 0.0),
				HeightDirection = new Vector3D(0.0, 0.0, 1.0),
				Material = base.TransparentMaterial
			};
			base.SetupMouseEventHandlers(planeVisual3D, mouseEventHandlers, eventManager);
			base.SetupMouseEventHandlers(planeVisual3D2, mouseEventHandlers, eventManager);
			return new PlaneVisual3D[]
			{
				planeVisual3D,
				planeVisual3D2
			};
		}

		// Token: 0x06004E87 RID: 20103 RVA: 0x0015419C File Offset: 0x0015239C
		public IEnumerable<PlaneVisual3D> CreateFrontLeftEdge(MouseEventHandlers mouseEventHandlers, EventManager3D eventManager)
		{
			PlaneVisual3D planeVisual3D = new PlaneVisual3D
			{
				CenterPosition = new Point3D(-7.5, 0.0, 10.0 + base.Offset),
				Size = new Size(5.0, 10.0),
				Normal = new Vector3D(0.0, 0.0, 1.0),
				HeightDirection = new Vector3D(0.0, 1.0, 0.0),
				Material = base.TransparentMaterial
			};
			PlaneVisual3D planeVisual3D2 = new PlaneVisual3D
			{
				CenterPosition = new Point3D(-10.0 - base.Offset, 0.0, 7.5),
				Size = new Size(5.0, 10.0),
				Normal = new Vector3D(-1.0, 0.0, 0.0),
				HeightDirection = new Vector3D(0.0, 1.0, 0.0),
				Material = base.TransparentMaterial
			};
			base.SetupMouseEventHandlers(planeVisual3D, mouseEventHandlers, eventManager);
			base.SetupMouseEventHandlers(planeVisual3D2, mouseEventHandlers, eventManager);
			return new PlaneVisual3D[]
			{
				planeVisual3D,
				planeVisual3D2
			};
		}

		// Token: 0x06004E88 RID: 20104 RVA: 0x00154338 File Offset: 0x00152538
		public IEnumerable<PlaneVisual3D> CreateBackLeftEdge(MouseEventHandlers mouseEventHandlers, EventManager3D eventManager)
		{
			PlaneVisual3D planeVisual3D = new PlaneVisual3D
			{
				CenterPosition = new Point3D(-7.5, 0.0, -10.0 - base.Offset),
				Size = new Size(5.0, 10.0),
				Normal = new Vector3D(0.0, 0.0, -1.0),
				HeightDirection = new Vector3D(0.0, 1.0, 0.0),
				Material = base.TransparentMaterial
			};
			PlaneVisual3D planeVisual3D2 = new PlaneVisual3D
			{
				CenterPosition = new Point3D(-10.0 - base.Offset, 0.0, -7.5),
				Size = new Size(5.0, 10.0),
				Normal = new Vector3D(-1.0, 0.0, 0.0),
				HeightDirection = new Vector3D(0.0, 1.0, 0.0),
				Material = base.TransparentMaterial
			};
			base.SetupMouseEventHandlers(planeVisual3D, mouseEventHandlers, eventManager);
			base.SetupMouseEventHandlers(planeVisual3D2, mouseEventHandlers, eventManager);
			return new PlaneVisual3D[]
			{
				planeVisual3D,
				planeVisual3D2
			};
		}

		// Token: 0x06004E89 RID: 20105 RVA: 0x001544D4 File Offset: 0x001526D4
		public IEnumerable<PlaneVisual3D> CreateBackRightEdge(MouseEventHandlers mouseEventHandlers, EventManager3D eventManager)
		{
			PlaneVisual3D planeVisual3D = new PlaneVisual3D
			{
				CenterPosition = new Point3D(7.5, 0.0, -10.0 - base.Offset),
				Size = new Size(5.0, 10.0),
				Normal = new Vector3D(0.0, 0.0, -1.0),
				HeightDirection = new Vector3D(0.0, 1.0, 0.0),
				Material = base.TransparentMaterial
			};
			PlaneVisual3D planeVisual3D2 = new PlaneVisual3D
			{
				CenterPosition = new Point3D(10.0 + base.Offset, 0.0, -7.5),
				Size = new Size(5.0, 10.0),
				Normal = new Vector3D(1.0, 0.0, 0.0),
				HeightDirection = new Vector3D(0.0, 1.0, 0.0),
				Material = base.TransparentMaterial
			};
			base.SetupMouseEventHandlers(planeVisual3D, mouseEventHandlers, eventManager);
			base.SetupMouseEventHandlers(planeVisual3D2, mouseEventHandlers, eventManager);
			return new PlaneVisual3D[]
			{
				planeVisual3D,
				planeVisual3D2
			};
		}

		// Token: 0x06004E8A RID: 20106 RVA: 0x00154670 File Offset: 0x00152870
		public IEnumerable<PlaneVisual3D> CreateFrontRightEdge(MouseEventHandlers mouseEventHandlers, EventManager3D eventManager)
		{
			PlaneVisual3D planeVisual3D = new PlaneVisual3D
			{
				CenterPosition = new Point3D(7.5, 0.0, 10.0 + base.Offset),
				Size = new Size(5.0, 10.0),
				Normal = new Vector3D(0.0, 0.0, 1.0),
				HeightDirection = new Vector3D(0.0, 1.0, 0.0),
				Material = base.TransparentMaterial
			};
			PlaneVisual3D planeVisual3D2 = new PlaneVisual3D
			{
				CenterPosition = new Point3D(10.0 + base.Offset, 0.0, 7.5),
				Size = new Size(5.0, 10.0),
				Normal = new Vector3D(1.0, 0.0, 0.0),
				HeightDirection = new Vector3D(0.0, 1.0, 0.0),
				Material = base.TransparentMaterial
			};
			base.SetupMouseEventHandlers(planeVisual3D, mouseEventHandlers, eventManager);
			base.SetupMouseEventHandlers(planeVisual3D2, mouseEventHandlers, eventManager);
			return new PlaneVisual3D[]
			{
				planeVisual3D,
				planeVisual3D2
			};
		}

		// Token: 0x06004E8B RID: 20107 RVA: 0x0015480C File Offset: 0x00152A0C
		public IEnumerable<PlaneVisual3D> CreateTopLeftEdge(MouseEventHandlers mouseEventHandlers, EventManager3D eventManager)
		{
			PlaneVisual3D planeVisual3D = new PlaneVisual3D
			{
				CenterPosition = new Point3D(-7.5, 10.0 + base.Offset, 0.0),
				Size = new Size(5.0, 10.0),
				Normal = new Vector3D(0.0, 1.0, 0.0),
				HeightDirection = new Vector3D(0.0, 0.0, 1.0),
				Material = base.TransparentMaterial
			};
			PlaneVisual3D planeVisual3D2 = new PlaneVisual3D
			{
				CenterPosition = new Point3D(-10.0 - base.Offset, 7.5, 0.0),
				Size = new Size(10.0, 5.0),
				Normal = new Vector3D(-1.0, 0.0, 0.0),
				HeightDirection = new Vector3D(0.0, 1.0, 0.0),
				Material = base.TransparentMaterial
			};
			base.SetupMouseEventHandlers(planeVisual3D, mouseEventHandlers, eventManager);
			base.SetupMouseEventHandlers(planeVisual3D2, mouseEventHandlers, eventManager);
			return new PlaneVisual3D[]
			{
				planeVisual3D,
				planeVisual3D2
			};
		}

		// Token: 0x06004E8C RID: 20108 RVA: 0x001549A8 File Offset: 0x00152BA8
		public IEnumerable<PlaneVisual3D> CreateTopRightEdge(MouseEventHandlers mouseEventHandlers, EventManager3D eventManager)
		{
			PlaneVisual3D planeVisual3D = new PlaneVisual3D
			{
				CenterPosition = new Point3D(7.5, 10.0 + base.Offset, 0.0),
				Size = new Size(5.0, 10.0),
				Normal = new Vector3D(0.0, 1.0, 0.0),
				HeightDirection = new Vector3D(0.0, 0.0, 1.0),
				Material = base.TransparentMaterial
			};
			PlaneVisual3D planeVisual3D2 = new PlaneVisual3D
			{
				CenterPosition = new Point3D(10.0 + base.Offset, 7.5, 0.0),
				Size = new Size(10.0, 5.0),
				Normal = new Vector3D(1.0, 0.0, 0.0),
				HeightDirection = new Vector3D(0.0, 1.0, 0.0),
				Material = base.TransparentMaterial
			};
			base.SetupMouseEventHandlers(planeVisual3D, mouseEventHandlers, eventManager);
			base.SetupMouseEventHandlers(planeVisual3D2, mouseEventHandlers, eventManager);
			return new PlaneVisual3D[]
			{
				planeVisual3D,
				planeVisual3D2
			};
		}

		// Token: 0x06004E8D RID: 20109 RVA: 0x00154B44 File Offset: 0x00152D44
		public IEnumerable<PlaneVisual3D> CreateBottomRightEdge(MouseEventHandlers mouseEventHandlers, EventManager3D eventManager)
		{
			PlaneVisual3D planeVisual3D = new PlaneVisual3D
			{
				CenterPosition = new Point3D(7.5, -10.0 - base.Offset, 0.0),
				Size = new Size(5.0, 10.0),
				Normal = new Vector3D(0.0, -1.0, 0.0),
				HeightDirection = new Vector3D(0.0, 0.0, 1.0),
				Material = base.TransparentMaterial
			};
			PlaneVisual3D planeVisual3D2 = new PlaneVisual3D
			{
				CenterPosition = new Point3D(10.0 + base.Offset, -7.5, 0.0),
				Size = new Size(10.0, 5.0),
				Normal = new Vector3D(1.0, 0.0, 0.0),
				HeightDirection = new Vector3D(0.0, 1.0, 0.0),
				Material = base.TransparentMaterial
			};
			base.SetupMouseEventHandlers(planeVisual3D, mouseEventHandlers, eventManager);
			base.SetupMouseEventHandlers(planeVisual3D2, mouseEventHandlers, eventManager);
			return new PlaneVisual3D[]
			{
				planeVisual3D,
				planeVisual3D2
			};
		}

		// Token: 0x06004E8E RID: 20110 RVA: 0x00154CE0 File Offset: 0x00152EE0
		public IEnumerable<PlaneVisual3D> CreateBottomLeftEdge(MouseEventHandlers mouseEventHandlers, EventManager3D eventManager)
		{
			PlaneVisual3D planeVisual3D = new PlaneVisual3D
			{
				CenterPosition = new Point3D(-7.5, -10.0 - base.Offset, 0.0),
				Size = new Size(5.0, 10.0),
				Normal = new Vector3D(0.0, -1.0, 0.0),
				HeightDirection = new Vector3D(0.0, 0.0, 1.0),
				Material = base.TransparentMaterial
			};
			PlaneVisual3D planeVisual3D2 = new PlaneVisual3D
			{
				CenterPosition = new Point3D(-10.0 - base.Offset, -7.5, 0.0),
				Size = new Size(10.0, 5.0),
				Normal = new Vector3D(-1.0, 0.0, 0.0),
				HeightDirection = new Vector3D(0.0, 1.0, 0.0),
				Material = base.TransparentMaterial
			};
			base.SetupMouseEventHandlers(planeVisual3D, mouseEventHandlers, eventManager);
			base.SetupMouseEventHandlers(planeVisual3D2, mouseEventHandlers, eventManager);
			return new PlaneVisual3D[]
			{
				planeVisual3D,
				planeVisual3D2
			};
		}

		// Token: 0x06004E8F RID: 20111 RVA: 0x00154E7C File Offset: 0x0015307C
		public IEnumerable<PlaneVisual3D> CreateFrontTopLeftVertex(MouseEventHandlers mouseEventHandlers, EventManager3D eventManager)
		{
			PlaneVisual3D planeVisual3D = new PlaneVisual3D
			{
				CenterPosition = new Point3D(-7.5, 7.5, 10.0 + base.Offset),
				Size = new Size(5.0, 5.0),
				Normal = new Vector3D(0.0, 0.0, 1.0),
				HeightDirection = new Vector3D(0.0, 1.0, 0.0),
				Material = base.TransparentMaterial
			};
			PlaneVisual3D planeVisual3D2 = new PlaneVisual3D
			{
				CenterPosition = new Point3D(-7.5, 10.0 + base.Offset, 7.5),
				Size = new Size(5.0, 5.0),
				Normal = new Vector3D(0.0, 1.0, 0.0),
				HeightDirection = new Vector3D(0.0, 0.0, 1.0),
				Material = base.TransparentMaterial
			};
			PlaneVisual3D planeVisual3D3 = new PlaneVisual3D
			{
				CenterPosition = new Point3D(-10.0 - base.Offset, 7.5, 7.5),
				Size = new Size(5.0, 5.0),
				Normal = new Vector3D(-1.0, 0.0, 0.0),
				HeightDirection = new Vector3D(0.0, 1.0, 0.0),
				Material = base.TransparentMaterial
			};
			base.SetupMouseEventHandlers(planeVisual3D, mouseEventHandlers, eventManager);
			base.SetupMouseEventHandlers(planeVisual3D2, mouseEventHandlers, eventManager);
			base.SetupMouseEventHandlers(planeVisual3D3, mouseEventHandlers, eventManager);
			return new PlaneVisual3D[]
			{
				planeVisual3D,
				planeVisual3D2,
				planeVisual3D3
			};
		}

		// Token: 0x06004E90 RID: 20112 RVA: 0x001550CC File Offset: 0x001532CC
		public IEnumerable<PlaneVisual3D> CreateBackTopLeftVertex(MouseEventHandlers mouseEventHandlers, EventManager3D eventManager)
		{
			PlaneVisual3D planeVisual3D = new PlaneVisual3D
			{
				CenterPosition = new Point3D(-7.5, 7.5, -10.0 - base.Offset),
				Size = new Size(5.0, 5.0),
				Normal = new Vector3D(0.0, 0.0, -1.0),
				HeightDirection = new Vector3D(0.0, 1.0, 0.0),
				Material = base.TransparentMaterial
			};
			PlaneVisual3D planeVisual3D2 = new PlaneVisual3D
			{
				CenterPosition = new Point3D(-7.5, 10.0 + base.Offset, -7.5),
				Size = new Size(5.0, 5.0),
				Normal = new Vector3D(0.0, 1.0, 0.0),
				HeightDirection = new Vector3D(0.0, 0.0, 1.0),
				Material = base.TransparentMaterial
			};
			PlaneVisual3D planeVisual3D3 = new PlaneVisual3D
			{
				CenterPosition = new Point3D(-10.0 - base.Offset, 7.5, -7.5),
				Size = new Size(5.0, 5.0),
				Normal = new Vector3D(-1.0, 0.0, 0.0),
				HeightDirection = new Vector3D(0.0, 1.0, 0.0),
				Material = base.TransparentMaterial
			};
			base.SetupMouseEventHandlers(planeVisual3D, mouseEventHandlers, eventManager);
			base.SetupMouseEventHandlers(planeVisual3D2, mouseEventHandlers, eventManager);
			base.SetupMouseEventHandlers(planeVisual3D3, mouseEventHandlers, eventManager);
			return new PlaneVisual3D[]
			{
				planeVisual3D,
				planeVisual3D2,
				planeVisual3D3
			};
		}

		// Token: 0x06004E91 RID: 20113 RVA: 0x0015531C File Offset: 0x0015351C
		public IEnumerable<PlaneVisual3D> CreateBackTopRightVertex(MouseEventHandlers mouseEventHandlers, EventManager3D eventManager)
		{
			PlaneVisual3D planeVisual3D = new PlaneVisual3D
			{
				CenterPosition = new Point3D(7.5, 7.5, -10.0 - base.Offset),
				Size = new Size(5.0, 5.0),
				Normal = new Vector3D(0.0, 0.0, -1.0),
				HeightDirection = new Vector3D(0.0, 1.0, 0.0),
				Material = base.TransparentMaterial
			};
			PlaneVisual3D planeVisual3D2 = new PlaneVisual3D
			{
				CenterPosition = new Point3D(7.5, 10.0 + base.Offset, -7.5),
				Size = new Size(5.0, 5.0),
				Normal = new Vector3D(0.0, 1.0, 0.0),
				HeightDirection = new Vector3D(0.0, 0.0, 1.0),
				Material = base.TransparentMaterial
			};
			PlaneVisual3D planeVisual3D3 = new PlaneVisual3D
			{
				CenterPosition = new Point3D(10.0 + base.Offset, 7.5, -7.5),
				Size = new Size(5.0, 5.0),
				Normal = new Vector3D(1.0, 0.0, 0.0),
				HeightDirection = new Vector3D(0.0, 1.0, 0.0),
				Material = base.TransparentMaterial
			};
			base.SetupMouseEventHandlers(planeVisual3D, mouseEventHandlers, eventManager);
			base.SetupMouseEventHandlers(planeVisual3D2, mouseEventHandlers, eventManager);
			base.SetupMouseEventHandlers(planeVisual3D3, mouseEventHandlers, eventManager);
			return new PlaneVisual3D[]
			{
				planeVisual3D,
				planeVisual3D2,
				planeVisual3D3
			};
		}

		// Token: 0x06004E92 RID: 20114 RVA: 0x0015556C File Offset: 0x0015376C
		public IEnumerable<PlaneVisual3D> CreateFrontTopRightVertex(MouseEventHandlers mouseEventHandlers, EventManager3D eventManager)
		{
			PlaneVisual3D planeVisual3D = new PlaneVisual3D
			{
				CenterPosition = new Point3D(7.5, 7.5, 10.0 + base.Offset),
				Size = new Size(5.0, 5.0),
				Normal = new Vector3D(0.0, 0.0, 1.0),
				HeightDirection = new Vector3D(0.0, 1.0, 0.0),
				Material = base.TransparentMaterial
			};
			PlaneVisual3D planeVisual3D2 = new PlaneVisual3D
			{
				CenterPosition = new Point3D(7.5, 10.0 + base.Offset, 7.5),
				Size = new Size(5.0, 5.0),
				Normal = new Vector3D(0.0, 1.0, 0.0),
				HeightDirection = new Vector3D(0.0, 0.0, 1.0),
				Material = base.TransparentMaterial
			};
			PlaneVisual3D planeVisual3D3 = new PlaneVisual3D
			{
				CenterPosition = new Point3D(10.0 + base.Offset, 7.5, 7.5),
				Size = new Size(5.0, 5.0),
				Normal = new Vector3D(1.0, 0.0, 0.0),
				HeightDirection = new Vector3D(0.0, 1.0, 0.0),
				Material = base.TransparentMaterial
			};
			base.SetupMouseEventHandlers(planeVisual3D, mouseEventHandlers, eventManager);
			base.SetupMouseEventHandlers(planeVisual3D2, mouseEventHandlers, eventManager);
			base.SetupMouseEventHandlers(planeVisual3D3, mouseEventHandlers, eventManager);
			return new PlaneVisual3D[]
			{
				planeVisual3D,
				planeVisual3D2,
				planeVisual3D3
			};
		}

		// Token: 0x06004E93 RID: 20115 RVA: 0x001557BC File Offset: 0x001539BC
		public IEnumerable<PlaneVisual3D> CreateFrontBottomLeftVertex(MouseEventHandlers mouseEventHandlers, EventManager3D eventManager)
		{
			PlaneVisual3D planeVisual3D = new PlaneVisual3D
			{
				CenterPosition = new Point3D(-7.5, -7.5, 10.0 + base.Offset),
				Size = new Size(5.0, 5.0),
				Normal = new Vector3D(0.0, 0.0, 1.0),
				HeightDirection = new Vector3D(0.0, 1.0, 0.0),
				Material = base.TransparentMaterial
			};
			PlaneVisual3D planeVisual3D2 = new PlaneVisual3D
			{
				CenterPosition = new Point3D(-7.5, -10.0 - base.Offset, 7.5),
				Size = new Size(5.0, 5.0),
				Normal = new Vector3D(0.0, -1.0, 0.0),
				HeightDirection = new Vector3D(0.0, 0.0, 1.0),
				Material = base.TransparentMaterial
			};
			PlaneVisual3D planeVisual3D3 = new PlaneVisual3D
			{
				CenterPosition = new Point3D(-10.0 - base.Offset, -7.5, 7.5),
				Size = new Size(5.0, 5.0),
				Normal = new Vector3D(-1.0, 0.0, 0.0),
				HeightDirection = new Vector3D(0.0, 1.0, 0.0),
				Material = base.TransparentMaterial
			};
			base.SetupMouseEventHandlers(planeVisual3D, mouseEventHandlers, eventManager);
			base.SetupMouseEventHandlers(planeVisual3D2, mouseEventHandlers, eventManager);
			base.SetupMouseEventHandlers(planeVisual3D3, mouseEventHandlers, eventManager);
			return new PlaneVisual3D[]
			{
				planeVisual3D,
				planeVisual3D2,
				planeVisual3D3
			};
		}

		// Token: 0x06004E94 RID: 20116 RVA: 0x00155A0C File Offset: 0x00153C0C
		public IEnumerable<PlaneVisual3D> CreateBackBottomLeftVertex(MouseEventHandlers mouseEventHandlers, EventManager3D eventManager)
		{
			PlaneVisual3D planeVisual3D = new PlaneVisual3D
			{
				CenterPosition = new Point3D(-7.5, -7.5, -10.0 - base.Offset),
				Size = new Size(5.0, 5.0),
				Normal = new Vector3D(0.0, 0.0, -1.0),
				HeightDirection = new Vector3D(0.0, 1.0, 0.0),
				Material = base.TransparentMaterial
			};
			PlaneVisual3D planeVisual3D2 = new PlaneVisual3D
			{
				CenterPosition = new Point3D(-7.5, -10.0 - base.Offset, -7.5),
				Size = new Size(5.0, 5.0),
				Normal = new Vector3D(0.0, -1.0, 0.0),
				HeightDirection = new Vector3D(0.0, 0.0, 1.0),
				Material = base.TransparentMaterial
			};
			PlaneVisual3D planeVisual3D3 = new PlaneVisual3D
			{
				CenterPosition = new Point3D(-10.0 - base.Offset, -7.5, -7.5),
				Size = new Size(5.0, 5.0),
				Normal = new Vector3D(-1.0, 0.0, 0.0),
				HeightDirection = new Vector3D(0.0, 1.0, 0.0),
				Material = base.TransparentMaterial
			};
			base.SetupMouseEventHandlers(planeVisual3D, mouseEventHandlers, eventManager);
			base.SetupMouseEventHandlers(planeVisual3D2, mouseEventHandlers, eventManager);
			base.SetupMouseEventHandlers(planeVisual3D3, mouseEventHandlers, eventManager);
			return new PlaneVisual3D[]
			{
				planeVisual3D,
				planeVisual3D2,
				planeVisual3D3
			};
		}

		// Token: 0x06004E95 RID: 20117 RVA: 0x00155C5C File Offset: 0x00153E5C
		public IEnumerable<PlaneVisual3D> CreateBackBottomRightVertex(MouseEventHandlers mouseEventHandlers, EventManager3D eventManager)
		{
			PlaneVisual3D planeVisual3D = new PlaneVisual3D
			{
				CenterPosition = new Point3D(7.5, -7.5, -10.0 - base.Offset),
				Size = new Size(5.0, 5.0),
				Normal = new Vector3D(0.0, 0.0, -1.0),
				HeightDirection = new Vector3D(0.0, 1.0, 0.0),
				Material = base.TransparentMaterial
			};
			PlaneVisual3D planeVisual3D2 = new PlaneVisual3D
			{
				CenterPosition = new Point3D(7.5, -10.0 - base.Offset, -7.5),
				Size = new Size(5.0, 5.0),
				Normal = new Vector3D(0.0, -1.0, 0.0),
				HeightDirection = new Vector3D(0.0, 0.0, 1.0),
				Material = base.TransparentMaterial
			};
			PlaneVisual3D planeVisual3D3 = new PlaneVisual3D
			{
				CenterPosition = new Point3D(10.0 + base.Offset, -7.5, -7.5),
				Size = new Size(5.0, 5.0),
				Normal = new Vector3D(1.0, 0.0, 0.0),
				HeightDirection = new Vector3D(0.0, 1.0, 0.0),
				Material = base.TransparentMaterial
			};
			base.SetupMouseEventHandlers(planeVisual3D, mouseEventHandlers, eventManager);
			base.SetupMouseEventHandlers(planeVisual3D2, mouseEventHandlers, eventManager);
			base.SetupMouseEventHandlers(planeVisual3D3, mouseEventHandlers, eventManager);
			return new PlaneVisual3D[]
			{
				planeVisual3D,
				planeVisual3D2,
				planeVisual3D3
			};
		}

		// Token: 0x06004E96 RID: 20118 RVA: 0x00155EAC File Offset: 0x001540AC
		public IEnumerable<PlaneVisual3D> CreateFrontBottomRightVertex(MouseEventHandlers mouseEventHandlers, EventManager3D eventManager)
		{
			PlaneVisual3D planeVisual3D = new PlaneVisual3D
			{
				CenterPosition = new Point3D(7.5, -7.5, 10.0 + base.Offset),
				Size = new Size(5.0, 5.0),
				Normal = new Vector3D(0.0, 0.0, 1.0),
				HeightDirection = new Vector3D(0.0, 1.0, 0.0),
				Material = base.TransparentMaterial
			};
			PlaneVisual3D planeVisual3D2 = new PlaneVisual3D
			{
				CenterPosition = new Point3D(7.5, -10.0 - base.Offset, 7.5),
				Size = new Size(5.0, 5.0),
				Normal = new Vector3D(0.0, -1.0, 0.0),
				HeightDirection = new Vector3D(0.0, 0.0, 1.0),
				Material = base.TransparentMaterial
			};
			PlaneVisual3D planeVisual3D3 = new PlaneVisual3D
			{
				CenterPosition = new Point3D(10.0 + base.Offset, -7.5, 7.5),
				Size = new Size(5.0, 5.0),
				Normal = new Vector3D(1.0, 0.0, 0.0),
				HeightDirection = new Vector3D(0.0, 1.0, 0.0),
				Material = base.TransparentMaterial
			};
			base.SetupMouseEventHandlers(planeVisual3D, mouseEventHandlers, eventManager);
			base.SetupMouseEventHandlers(planeVisual3D2, mouseEventHandlers, eventManager);
			base.SetupMouseEventHandlers(planeVisual3D3, mouseEventHandlers, eventManager);
			return new PlaneVisual3D[]
			{
				planeVisual3D,
				planeVisual3D2,
				planeVisual3D3
			};
		}

		// Token: 0x06004E97 RID: 20119 RVA: 0x001560FC File Offset: 0x001542FC
		public PlaneVisual3D CreateFrontPlane(MouseEventHandlers mouseEventHandlers, EventManager3D eventManager)
		{
			PlaneVisual3D planeVisual3D = new PlaneVisual3D
			{
				CenterPosition = new Point3D(0.0, 0.0, 10.0 + base.Offset),
				Size = new Size(10.0, 10.0),
				Normal = new Vector3D(0.0, 0.0, 1.0),
				HeightDirection = new Vector3D(0.0, 1.0, 0.0),
				Material = base.TransparentMaterial
			};
			base.SetupMouseEventHandlers(planeVisual3D, mouseEventHandlers, eventManager);
			return planeVisual3D;
		}

		// Token: 0x06004E98 RID: 20120 RVA: 0x001561DC File Offset: 0x001543DC
		public PlaneVisual3D CreateTopPlane(MouseEventHandlers mouseEventHandlers, EventManager3D eventManager)
		{
			PlaneVisual3D planeVisual3D = new PlaneVisual3D
			{
				CenterPosition = new Point3D(0.0, 10.0 + base.Offset, 0.0),
				Size = new Size(10.0, 10.0),
				Normal = new Vector3D(0.0, 1.0, 0.0),
				HeightDirection = new Vector3D(0.0, 0.0, 1.0),
				Material = base.TransparentMaterial
			};
			base.SetupMouseEventHandlers(planeVisual3D, mouseEventHandlers, eventManager);
			return planeVisual3D;
		}

		// Token: 0x06004E99 RID: 20121 RVA: 0x001562BC File Offset: 0x001544BC
		public PlaneVisual3D CreateBackPlane(MouseEventHandlers mouseEventHandlers, EventManager3D eventManager)
		{
			PlaneVisual3D planeVisual3D = new PlaneVisual3D
			{
				CenterPosition = new Point3D(0.0, 0.0, -10.0 - base.Offset),
				Size = new Size(10.0, 10.0),
				Normal = new Vector3D(0.0, 0.0, -1.0),
				HeightDirection = new Vector3D(0.0, 1.0, 0.0),
				Material = base.TransparentMaterial
			};
			base.SetupMouseEventHandlers(planeVisual3D, mouseEventHandlers, eventManager);
			return planeVisual3D;
		}

		// Token: 0x06004E9A RID: 20122 RVA: 0x0015639C File Offset: 0x0015459C
		public PlaneVisual3D CreateBottomPlane(MouseEventHandlers mouseEventHandlers, EventManager3D eventManager)
		{
			PlaneVisual3D planeVisual3D = new PlaneVisual3D
			{
				CenterPosition = new Point3D(0.0, -10.0 - base.Offset, 0.0),
				Size = new Size(10.0, 10.0),
				Normal = new Vector3D(0.0, -1.0, 0.0),
				HeightDirection = new Vector3D(0.0, 0.0, 1.0),
				Material = base.TransparentMaterial
			};
			base.SetupMouseEventHandlers(planeVisual3D, mouseEventHandlers, eventManager);
			return planeVisual3D;
		}

		// Token: 0x06004E9B RID: 20123 RVA: 0x0015647C File Offset: 0x0015467C
		public PlaneVisual3D CreateLeftPlane(MouseEventHandlers mouseEventHandlers, EventManager3D eventManager)
		{
			PlaneVisual3D planeVisual3D = new PlaneVisual3D
			{
				CenterPosition = new Point3D(-10.0 - base.Offset, 0.0, 0.0),
				Size = new Size(10.0, 10.0),
				Normal = new Vector3D(-1.0, 0.0, 0.0),
				HeightDirection = new Vector3D(0.0, 1.0, 0.0),
				Material = base.TransparentMaterial
			};
			base.SetupMouseEventHandlers(planeVisual3D, mouseEventHandlers, eventManager);
			return planeVisual3D;
		}

		// Token: 0x06004E9C RID: 20124 RVA: 0x0015655C File Offset: 0x0015475C
		public PlaneVisual3D CreateRightPlane(MouseEventHandlers mouseEventHandlers, EventManager3D eventManager)
		{
			PlaneVisual3D planeVisual3D = new PlaneVisual3D
			{
				CenterPosition = new Point3D(10.0 + base.Offset, 0.0, 0.0),
				Size = new Size(10.0, 10.0),
				Normal = new Vector3D(1.0, 0.0, 0.0),
				HeightDirection = new Vector3D(0.0, 1.0, 0.0),
				Material = base.TransparentMaterial
			};
			base.SetupMouseEventHandlers(planeVisual3D, mouseEventHandlers, eventManager);
			return planeVisual3D;
		}

		// Token: 0x06004E9D RID: 20125 RVA: 0x0015663C File Offset: 0x0015483C
		public void CreateViewCubeBox()
		{
			base.MySetupViewCubeTextures();
			base.ViewCube.CenterPosition = new Point3D(0.0, 0.0, 0.0);
			base.ViewCube.Size = new Size3D(20.0, 20.0, 20.0);
		}

		// Token: 0x06004E9E RID: 20126 RVA: 0x001566B4 File Offset: 0x001548B4
		public void CreateAxisArrows(NewViewCubeControl viewCube)
		{
			viewCube.AxisXArrow.StartPosition = new Point3D(-10.0, -10.0, -10.0);
			viewCube.AxisXArrow.EndPosition = new Point3D(20.0, -10.0, -10.0);
			viewCube.AxisXArrow.ArrowRadius = 0.7;
			viewCube.AxisXArrow.Radius = 0.3;
			viewCube.AxisXArrow.Material = new DiffuseMaterial(base.AxisXColor);
			viewCube.AxisYArrow.StartPosition = new Point3D(-10.0, -10.0, -10.0);
			viewCube.AxisYArrow.EndPosition = new Point3D(-10.0, 20.0, -10.0);
			viewCube.AxisYArrow.ArrowRadius = 0.7;
			viewCube.AxisYArrow.Radius = 0.3;
			viewCube.AxisYArrow.Material = new DiffuseMaterial(base.AxisYColor);
			viewCube.AxisZArrow.StartPosition = new Point3D(-10.0, -10.0, -10.0);
			viewCube.AxisZArrow.EndPosition = new Point3D(-10.0, -10.0, 20.0);
			viewCube.AxisZArrow.ArrowRadius = 0.7;
			viewCube.AxisZArrow.Radius = 0.3;
			viewCube.AxisZArrow.Material = new DiffuseMaterial(base.AxisZColor);
		}

		// Token: 0x06004E9F RID: 20127 RVA: 0x0015689C File Offset: 0x00154A9C
		public void CreateAxisLabels(NewViewCubeControl viewCube)
		{
			viewCube.AxisXLabelVisual.SetName(#Phc.#3hc(107468707));
			viewCube.AxisXLabelVisual.Text = #Phc.#3hc(107408964);
			viewCube.AxisXLabelVisual.Position = new Point3D(23.0, -10.0, -10.0);
			viewCube.AxisXLabelVisual.Foreground = base.AxisXColor;
			viewCube.AxisXLabelVisual.Background = base.AxisLabelBackground;
			viewCube.AxisYLabelVisual.SetName(#Phc.#3hc(107468722));
			viewCube.AxisYLabelVisual.Text = #Phc.#3hc(107408991);
			viewCube.AxisYLabelVisual.Position = new Point3D(-10.0, 23.0, -10.0);
			viewCube.AxisYLabelVisual.Foreground = base.AxisYColor;
			viewCube.AxisYLabelVisual.Background = base.AxisLabelBackground;
			viewCube.AxisZLabelVisual.SetName(#Phc.#3hc(107468673));
			viewCube.AxisZLabelVisual.Text = #Phc.#3hc(107397860);
			viewCube.AxisZLabelVisual.Position = new Point3D(-10.0, -10.0, 23.0);
			viewCube.AxisZLabelVisual.Foreground = base.AxisZColor;
			viewCube.AxisZLabelVisual.Background = base.AxisLabelBackground;
		}

		// Token: 0x06004EA0 RID: 20128 RVA: 0x00156A2C File Offset: 0x00154C2C
		public void ArrangeButtonsOnCanvas(NewViewCubeControl viewCube)
		{
			double num = 150.0;
			viewCube.Width = num;
			viewCube.Height = num;
			viewCube.MinWidth = num;
			viewCube.MinHeight = num;
			viewCube.MaxWidth = num;
			viewCube.MaxHeight = num;
			viewCube.ButtonsCanvas.Height = num;
			Canvas.SetRight(viewCube.CounterClockwiseButton, 45.0);
			Canvas.SetTop(viewCube.CounterClockwiseButton, 30.0);
			viewCube.CounterClockwiseButton.Width = 15.0;
			viewCube.CounterClockwiseButton.Height = 15.0;
			Canvas.SetRight(viewCube.ClockwiseButton, 30.0);
			Canvas.SetTop(viewCube.ClockwiseButton, 45.0);
			viewCube.ClockwiseButton.Width = 15.0;
			viewCube.ClockwiseButton.Height = 15.0;
			Canvas.SetLeft(viewCube.UpButton, 68.5);
			Canvas.SetTop(viewCube.UpButton, 30.0);
			viewCube.UpButton.Width = 15.0;
			viewCube.UpButton.Height = 15.0;
			Canvas.SetRight(viewCube.RightButton, 30.0);
			Canvas.SetTop(viewCube.RightButton, 68.5);
			viewCube.RightButton.Width = 15.0;
			viewCube.RightButton.Height = 15.0;
			Canvas.SetLeft(viewCube.DownButton, 68.5);
			Canvas.SetBottom(viewCube.DownButton, 30.0);
			viewCube.DownButton.Width = 15.0;
			viewCube.DownButton.Height = 15.0;
			Canvas.SetLeft(viewCube.LeftButton, 30.0);
			Canvas.SetTop(viewCube.LeftButton, 68.5);
			viewCube.LeftButton.Width = 15.0;
			viewCube.LeftButton.Height = 15.0;
		}
	}
}
