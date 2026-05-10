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
	// Token: 0x02000951 RID: 2385
	internal sealed class ViewCubeVisualsHelperSmall : ViewCubeVisualsHelper, IViewCubeVisualsHelper
	{
		// Token: 0x06004DB4 RID: 19892 RVA: 0x00041467 File Offset: 0x0003F667
		public ViewCubeVisualsHelperSmall()
		{
			this.<ViewCubeSize>k__BackingField = new Size(13.0, 13.0);
			this.CreateViewCubeBox();
		}

		// Token: 0x1700169F RID: 5791
		// (get) Token: 0x06004DB5 RID: 19893 RVA: 0x00041492 File Offset: 0x0003F692
		public Size ViewCubeSize { get; }

		// Token: 0x170016A0 RID: 5792
		// (get) Token: 0x06004DB6 RID: 19894 RVA: 0x0004149E File Offset: 0x0003F69E
		public double CameraDistance
		{
			get
			{
				return 50.0;
			}
		}

		// Token: 0x170016A1 RID: 5793
		// (get) Token: 0x06004DB7 RID: 19895 RVA: 0x000414A9 File Offset: 0x0003F6A9
		public override string MainDirButtons
		{
			get
			{
				return string.Format(CultureInfo.InvariantCulture, #Phc.#3hc(107468441), new object[]
				{
					base.AssemblyName
				});
			}
		}

		// Token: 0x170016A2 RID: 5794
		// (get) Token: 0x06004DB8 RID: 19896 RVA: 0x000414DA File Offset: 0x0003F6DA
		public override string MainDirTextures
		{
			get
			{
				return string.Format(CultureInfo.InvariantCulture, #Phc.#3hc(107468336), new object[]
				{
					base.AssemblyName
				});
			}
		}

		// Token: 0x06004DB9 RID: 19897 RVA: 0x0014F200 File Offset: 0x0014D400
		public IEnumerable<PlaneVisual3D> CreateFrontTopEdge(MouseEventHandlers mouseEventHandlers, EventManager3D eventManager)
		{
			PlaneVisual3D planeVisual3D = new PlaneVisual3D
			{
				CenterPosition = new Point3D(0.0, 4.875, (10.0 + base.Offset) * 0.65),
				Size = new Size(6.5, 3.25),
				Normal = new Vector3D(0.0, 0.0, 1.0),
				HeightDirection = new Vector3D(0.0, 1.0, 0.0),
				Material = base.TransparentMaterial
			};
			PlaneVisual3D planeVisual3D2 = new PlaneVisual3D
			{
				CenterPosition = new Point3D(0.0, (10.0 + base.Offset) * 0.65, 4.875),
				Size = new Size(6.5, 3.25),
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

		// Token: 0x06004DBA RID: 19898 RVA: 0x0014F3B0 File Offset: 0x0014D5B0
		public IEnumerable<PlaneVisual3D> CreateBackTopEdge(MouseEventHandlers mouseEventHandlers, EventManager3D eventManager)
		{
			PlaneVisual3D planeVisual3D = new PlaneVisual3D
			{
				CenterPosition = new Point3D(0.0, 4.875, (-10.0 - base.Offset) * 0.65),
				Size = new Size(6.5, 3.25),
				Normal = new Vector3D(0.0, 0.0, -1.0),
				HeightDirection = new Vector3D(0.0, 1.0, 0.0),
				Material = base.TransparentMaterial
			};
			PlaneVisual3D planeVisual3D2 = new PlaneVisual3D
			{
				CenterPosition = new Point3D(0.0, (10.0 + base.Offset) * 0.65, -4.875),
				Size = new Size(6.5, 3.25),
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

		// Token: 0x06004DBB RID: 19899 RVA: 0x0014F560 File Offset: 0x0014D760
		public IEnumerable<PlaneVisual3D> CreateBackBottomEdge(MouseEventHandlers mouseEventHandlers, EventManager3D eventManager)
		{
			PlaneVisual3D planeVisual3D = new PlaneVisual3D
			{
				CenterPosition = new Point3D(0.0, -4.875, (-10.0 - base.Offset) * 0.65),
				Size = new Size(6.5, 3.25),
				Normal = new Vector3D(0.0, 0.0, -1.0),
				HeightDirection = new Vector3D(0.0, 1.0, 0.0),
				Material = base.TransparentMaterial
			};
			PlaneVisual3D planeVisual3D2 = new PlaneVisual3D
			{
				CenterPosition = new Point3D(0.0, (-10.0 - base.Offset) * 0.65, -4.875),
				Size = new Size(6.5, 3.25),
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

		// Token: 0x06004DBC RID: 19900 RVA: 0x0014F710 File Offset: 0x0014D910
		public IEnumerable<PlaneVisual3D> CreateFrontBottomEdge(MouseEventHandlers mouseEventHandlers, EventManager3D eventManager)
		{
			PlaneVisual3D planeVisual3D = new PlaneVisual3D
			{
				CenterPosition = new Point3D(0.0, -4.875, (10.0 + base.Offset) * 0.65),
				Size = new Size(6.5, 3.25),
				Normal = new Vector3D(0.0, 0.0, 1.0),
				HeightDirection = new Vector3D(0.0, 1.0, 0.0),
				Material = base.TransparentMaterial
			};
			PlaneVisual3D planeVisual3D2 = new PlaneVisual3D
			{
				CenterPosition = new Point3D(0.0, (-10.0 - base.Offset) * 0.65, 4.875),
				Size = new Size(6.5, 3.25),
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

		// Token: 0x06004DBD RID: 19901 RVA: 0x0014F8C0 File Offset: 0x0014DAC0
		public IEnumerable<PlaneVisual3D> CreateFrontLeftEdge(MouseEventHandlers mouseEventHandlers, EventManager3D eventManager)
		{
			PlaneVisual3D planeVisual3D = new PlaneVisual3D
			{
				CenterPosition = new Point3D(-4.875, 0.0, (10.0 + base.Offset) * 0.65),
				Size = new Size(3.25, 6.5),
				Normal = new Vector3D(0.0, 0.0, 1.0),
				HeightDirection = new Vector3D(0.0, 1.0, 0.0),
				Material = base.TransparentMaterial
			};
			PlaneVisual3D planeVisual3D2 = new PlaneVisual3D
			{
				CenterPosition = new Point3D((-10.0 - base.Offset) * 0.65, 0.0, 4.875),
				Size = new Size(3.25, 6.5),
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

		// Token: 0x06004DBE RID: 19902 RVA: 0x0014FA70 File Offset: 0x0014DC70
		public IEnumerable<PlaneVisual3D> CreateBackLeftEdge(MouseEventHandlers mouseEventHandlers, EventManager3D eventManager)
		{
			PlaneVisual3D planeVisual3D = new PlaneVisual3D
			{
				CenterPosition = new Point3D(-4.875, 0.0, (-10.0 - base.Offset) * 0.65),
				Size = new Size(3.25, 6.5),
				Normal = new Vector3D(0.0, 0.0, -1.0),
				HeightDirection = new Vector3D(0.0, 1.0, 0.0),
				Material = base.TransparentMaterial
			};
			PlaneVisual3D planeVisual3D2 = new PlaneVisual3D
			{
				CenterPosition = new Point3D((-10.0 - base.Offset) * 0.65, 0.0, -4.875),
				Size = new Size(3.25, 6.5),
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

		// Token: 0x06004DBF RID: 19903 RVA: 0x0014FC20 File Offset: 0x0014DE20
		public IEnumerable<PlaneVisual3D> CreateBackRightEdge(MouseEventHandlers mouseEventHandlers, EventManager3D eventManager)
		{
			PlaneVisual3D planeVisual3D = new PlaneVisual3D
			{
				CenterPosition = new Point3D(4.875, 0.0, (-10.0 - base.Offset) * 0.65),
				Size = new Size(3.25, 6.5),
				Normal = new Vector3D(0.0, 0.0, -1.0),
				HeightDirection = new Vector3D(0.0, 1.0, 0.0),
				Material = base.TransparentMaterial
			};
			PlaneVisual3D planeVisual3D2 = new PlaneVisual3D
			{
				CenterPosition = new Point3D((10.0 + base.Offset) * 0.65, 0.0, -4.875),
				Size = new Size(3.25, 6.5),
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

		// Token: 0x06004DC0 RID: 19904 RVA: 0x0014FDD0 File Offset: 0x0014DFD0
		public IEnumerable<PlaneVisual3D> CreateFrontRightEdge(MouseEventHandlers mouseEventHandlers, EventManager3D eventManager)
		{
			PlaneVisual3D planeVisual3D = new PlaneVisual3D
			{
				CenterPosition = new Point3D(4.875, 0.0, (10.0 + base.Offset) * 0.65),
				Size = new Size(3.25, 6.5),
				Normal = new Vector3D(0.0, 0.0, 1.0),
				HeightDirection = new Vector3D(0.0, 1.0, 0.0),
				Material = base.TransparentMaterial
			};
			PlaneVisual3D planeVisual3D2 = new PlaneVisual3D
			{
				CenterPosition = new Point3D((10.0 + base.Offset) * 0.65, 0.0, 4.875),
				Size = new Size(3.25, 6.5),
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

		// Token: 0x06004DC1 RID: 19905 RVA: 0x0014FF80 File Offset: 0x0014E180
		public IEnumerable<PlaneVisual3D> CreateTopLeftEdge(MouseEventHandlers mouseEventHandlers, EventManager3D eventManager)
		{
			PlaneVisual3D planeVisual3D = new PlaneVisual3D
			{
				CenterPosition = new Point3D(-4.875, (10.0 + base.Offset) * 0.65, 0.0),
				Size = new Size(3.25, 6.5),
				Normal = new Vector3D(0.0, 1.0, 0.0),
				HeightDirection = new Vector3D(0.0, 0.0, 1.0),
				Material = base.TransparentMaterial
			};
			PlaneVisual3D planeVisual3D2 = new PlaneVisual3D
			{
				CenterPosition = new Point3D((-10.0 - base.Offset) * 0.65, 4.875, 0.0),
				Size = new Size(6.5, 3.25),
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

		// Token: 0x06004DC2 RID: 19906 RVA: 0x00150130 File Offset: 0x0014E330
		public IEnumerable<PlaneVisual3D> CreateTopRightEdge(MouseEventHandlers mouseEventHandlers, EventManager3D eventManager)
		{
			PlaneVisual3D planeVisual3D = new PlaneVisual3D
			{
				CenterPosition = new Point3D(4.875, (10.0 + base.Offset) * 0.65, 0.0),
				Size = new Size(3.25, 6.5),
				Normal = new Vector3D(0.0, 1.0, 0.0),
				HeightDirection = new Vector3D(0.0, 0.0, 1.0),
				Material = base.TransparentMaterial
			};
			PlaneVisual3D planeVisual3D2 = new PlaneVisual3D
			{
				CenterPosition = new Point3D((10.0 + base.Offset) * 0.65, 4.875, 0.0),
				Size = new Size(6.5, 3.25),
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

		// Token: 0x06004DC3 RID: 19907 RVA: 0x001502E0 File Offset: 0x0014E4E0
		public IEnumerable<PlaneVisual3D> CreateBottomRightEdge(MouseEventHandlers mouseEventHandlers, EventManager3D eventManager)
		{
			PlaneVisual3D planeVisual3D = new PlaneVisual3D
			{
				CenterPosition = new Point3D(4.875, (-10.0 - base.Offset) * 0.65, 0.0),
				Size = new Size(3.25, 6.5),
				Normal = new Vector3D(0.0, -1.0, 0.0),
				HeightDirection = new Vector3D(0.0, 0.0, 1.0),
				Material = base.TransparentMaterial
			};
			PlaneVisual3D planeVisual3D2 = new PlaneVisual3D
			{
				CenterPosition = new Point3D((10.0 + base.Offset) * 0.65, -4.875, 0.0),
				Size = new Size(6.5, 3.25),
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

		// Token: 0x06004DC4 RID: 19908 RVA: 0x00150490 File Offset: 0x0014E690
		public IEnumerable<PlaneVisual3D> CreateBottomLeftEdge(MouseEventHandlers mouseEventHandlers, EventManager3D eventManager)
		{
			PlaneVisual3D planeVisual3D = new PlaneVisual3D
			{
				CenterPosition = new Point3D(-4.875, (-10.0 - base.Offset) * 0.65, 0.0),
				Size = new Size(3.25, 6.5),
				Normal = new Vector3D(0.0, -1.0, 0.0),
				HeightDirection = new Vector3D(0.0, 0.0, 1.0),
				Material = base.TransparentMaterial
			};
			PlaneVisual3D planeVisual3D2 = new PlaneVisual3D
			{
				CenterPosition = new Point3D((-10.0 - base.Offset) * 0.65, -4.875, 0.0),
				Size = new Size(6.5, 3.25),
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

		// Token: 0x06004DC5 RID: 19909 RVA: 0x00150640 File Offset: 0x0014E840
		public IEnumerable<PlaneVisual3D> CreateFrontTopLeftVertex(MouseEventHandlers mouseEventHandlers, EventManager3D eventManager)
		{
			PlaneVisual3D planeVisual3D = new PlaneVisual3D
			{
				CenterPosition = new Point3D(-4.875, 4.875, (10.0 + base.Offset) * 0.65),
				Size = new Size(3.25, 3.25),
				Normal = new Vector3D(0.0, 0.0, 1.0),
				HeightDirection = new Vector3D(0.0, 1.0, 0.0),
				Material = base.TransparentMaterial
			};
			PlaneVisual3D planeVisual3D2 = new PlaneVisual3D
			{
				CenterPosition = new Point3D(-4.875, (10.0 + base.Offset) * 0.65, 4.875),
				Size = new Size(3.25, 3.25),
				Normal = new Vector3D(0.0, 1.0, 0.0),
				HeightDirection = new Vector3D(0.0, 0.0, 1.0),
				Material = base.TransparentMaterial
			};
			PlaneVisual3D planeVisual3D3 = new PlaneVisual3D
			{
				CenterPosition = new Point3D((-10.0 - base.Offset) * 0.65, 4.875, 4.875),
				Size = new Size(3.25, 3.25),
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

		// Token: 0x06004DC6 RID: 19910 RVA: 0x001508B0 File Offset: 0x0014EAB0
		public IEnumerable<PlaneVisual3D> CreateBackTopLeftVertex(MouseEventHandlers mouseEventHandlers, EventManager3D eventManager)
		{
			PlaneVisual3D planeVisual3D = new PlaneVisual3D
			{
				CenterPosition = new Point3D(-4.875, 4.875, (-10.0 - base.Offset) * 0.65),
				Size = new Size(3.25, 3.25),
				Normal = new Vector3D(0.0, 0.0, -1.0),
				HeightDirection = new Vector3D(0.0, 1.0, 0.0),
				Material = base.TransparentMaterial
			};
			PlaneVisual3D planeVisual3D2 = new PlaneVisual3D
			{
				CenterPosition = new Point3D(-4.875, (10.0 + base.Offset) * 0.65, -4.875),
				Size = new Size(3.25, 3.25),
				Normal = new Vector3D(0.0, 1.0, 0.0),
				HeightDirection = new Vector3D(0.0, 0.0, 1.0),
				Material = base.TransparentMaterial
			};
			PlaneVisual3D planeVisual3D3 = new PlaneVisual3D
			{
				CenterPosition = new Point3D((-10.0 - base.Offset) * 0.65, 4.875, -4.875),
				Size = new Size(3.25, 3.25),
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

		// Token: 0x06004DC7 RID: 19911 RVA: 0x00150B20 File Offset: 0x0014ED20
		public IEnumerable<PlaneVisual3D> CreateBackTopRightVertex(MouseEventHandlers mouseEventHandlers, EventManager3D eventManager)
		{
			PlaneVisual3D planeVisual3D = new PlaneVisual3D
			{
				CenterPosition = new Point3D(4.875, 4.875, (-10.0 - base.Offset) * 0.65),
				Size = new Size(3.25, 3.25),
				Normal = new Vector3D(0.0, 0.0, -1.0),
				HeightDirection = new Vector3D(0.0, 1.0, 0.0),
				Material = base.TransparentMaterial
			};
			PlaneVisual3D planeVisual3D2 = new PlaneVisual3D
			{
				CenterPosition = new Point3D(4.875, (10.0 + base.Offset) * 0.65, -4.875),
				Size = new Size(3.25, 3.25),
				Normal = new Vector3D(0.0, 1.0, 0.0),
				HeightDirection = new Vector3D(0.0, 0.0, 1.0),
				Material = base.TransparentMaterial
			};
			PlaneVisual3D planeVisual3D3 = new PlaneVisual3D
			{
				CenterPosition = new Point3D((10.0 + base.Offset) * 0.65, 4.875, -4.875),
				Size = new Size(3.25, 3.25),
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

		// Token: 0x06004DC8 RID: 19912 RVA: 0x00150D90 File Offset: 0x0014EF90
		public IEnumerable<PlaneVisual3D> CreateFrontTopRightVertex(MouseEventHandlers mouseEventHandlers, EventManager3D eventManager)
		{
			PlaneVisual3D planeVisual3D = new PlaneVisual3D
			{
				CenterPosition = new Point3D(4.875, 4.875, (10.0 + base.Offset) * 0.65),
				Size = new Size(3.25, 3.25),
				Normal = new Vector3D(0.0, 0.0, 1.0),
				HeightDirection = new Vector3D(0.0, 1.0, 0.0),
				Material = base.TransparentMaterial
			};
			PlaneVisual3D planeVisual3D2 = new PlaneVisual3D
			{
				CenterPosition = new Point3D(4.875, (10.0 + base.Offset) * 0.65, 4.875),
				Size = new Size(3.25, 3.25),
				Normal = new Vector3D(0.0, 1.0, 0.0),
				HeightDirection = new Vector3D(0.0, 0.0, 1.0),
				Material = base.TransparentMaterial
			};
			PlaneVisual3D planeVisual3D3 = new PlaneVisual3D
			{
				CenterPosition = new Point3D((10.0 + base.Offset) * 0.65, 4.875, 4.875),
				Size = new Size(3.25, 3.25),
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

		// Token: 0x06004DC9 RID: 19913 RVA: 0x00151000 File Offset: 0x0014F200
		public IEnumerable<PlaneVisual3D> CreateFrontBottomLeftVertex(MouseEventHandlers mouseEventHandlers, EventManager3D eventManager)
		{
			PlaneVisual3D planeVisual3D = new PlaneVisual3D
			{
				CenterPosition = new Point3D(-4.875, -4.875, (10.0 + base.Offset) * 0.65),
				Size = new Size(3.25, 3.25),
				Normal = new Vector3D(0.0, 0.0, 1.0),
				HeightDirection = new Vector3D(0.0, 1.0, 0.0),
				Material = base.TransparentMaterial
			};
			PlaneVisual3D planeVisual3D2 = new PlaneVisual3D
			{
				CenterPosition = new Point3D(-4.875, (-10.0 - base.Offset) * 0.65, 4.875),
				Size = new Size(3.25, 3.25),
				Normal = new Vector3D(0.0, -1.0, 0.0),
				HeightDirection = new Vector3D(0.0, 0.0, 1.0),
				Material = base.TransparentMaterial
			};
			PlaneVisual3D planeVisual3D3 = new PlaneVisual3D
			{
				CenterPosition = new Point3D((-10.0 - base.Offset) * 0.65, -4.875, 4.875),
				Size = new Size(3.25, 3.25),
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

		// Token: 0x06004DCA RID: 19914 RVA: 0x00151270 File Offset: 0x0014F470
		public IEnumerable<PlaneVisual3D> CreateBackBottomLeftVertex(MouseEventHandlers mouseEventHandlers, EventManager3D eventManager)
		{
			PlaneVisual3D planeVisual3D = new PlaneVisual3D
			{
				CenterPosition = new Point3D(-4.875, -4.875, (-10.0 - base.Offset) * 0.65),
				Size = new Size(3.25, 3.25),
				Normal = new Vector3D(0.0, 0.0, -1.0),
				HeightDirection = new Vector3D(0.0, 1.0, 0.0),
				Material = base.TransparentMaterial
			};
			PlaneVisual3D planeVisual3D2 = new PlaneVisual3D
			{
				CenterPosition = new Point3D(-4.875, (-10.0 - base.Offset) * 0.65, -4.875),
				Size = new Size(3.25, 3.25),
				Normal = new Vector3D(0.0, -1.0, 0.0),
				HeightDirection = new Vector3D(0.0, 0.0, 1.0),
				Material = base.TransparentMaterial
			};
			PlaneVisual3D planeVisual3D3 = new PlaneVisual3D
			{
				CenterPosition = new Point3D((-10.0 - base.Offset) * 0.65, -4.875, -4.875),
				Size = new Size(3.25, 3.25),
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

		// Token: 0x06004DCB RID: 19915 RVA: 0x001514E0 File Offset: 0x0014F6E0
		public IEnumerable<PlaneVisual3D> CreateBackBottomRightVertex(MouseEventHandlers mouseEventHandlers, EventManager3D eventManager)
		{
			PlaneVisual3D planeVisual3D = new PlaneVisual3D
			{
				CenterPosition = new Point3D(4.875, -4.875, (-10.0 - base.Offset) * 0.65),
				Size = new Size(3.25, 3.25),
				Normal = new Vector3D(0.0, 0.0, -1.0),
				HeightDirection = new Vector3D(0.0, 1.0, 0.0),
				Material = base.TransparentMaterial
			};
			PlaneVisual3D planeVisual3D2 = new PlaneVisual3D
			{
				CenterPosition = new Point3D(4.875, (-10.0 - base.Offset) * 0.65, -4.875),
				Size = new Size(3.25, 3.25),
				Normal = new Vector3D(0.0, -1.0, 0.0),
				HeightDirection = new Vector3D(0.0, 0.0, 1.0),
				Material = base.TransparentMaterial
			};
			PlaneVisual3D planeVisual3D3 = new PlaneVisual3D
			{
				CenterPosition = new Point3D((10.0 + base.Offset) * 0.65, -4.875, -4.875),
				Size = new Size(3.25, 3.25),
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

		// Token: 0x06004DCC RID: 19916 RVA: 0x00151750 File Offset: 0x0014F950
		public IEnumerable<PlaneVisual3D> CreateFrontBottomRightVertex(MouseEventHandlers mouseEventHandlers, EventManager3D eventManager)
		{
			PlaneVisual3D planeVisual3D = new PlaneVisual3D
			{
				CenterPosition = new Point3D(4.875, -4.875, (10.0 + base.Offset) * 0.65),
				Size = new Size(3.25, 3.25),
				Normal = new Vector3D(0.0, 0.0, 1.0),
				HeightDirection = new Vector3D(0.0, 1.0, 0.0),
				Material = base.TransparentMaterial
			};
			PlaneVisual3D planeVisual3D2 = new PlaneVisual3D
			{
				CenterPosition = new Point3D(4.875, (-10.0 - base.Offset) * 0.65, 4.875),
				Size = new Size(3.25, 3.25),
				Normal = new Vector3D(0.0, -1.0, 0.0),
				HeightDirection = new Vector3D(0.0, 0.0, 1.0),
				Material = base.TransparentMaterial
			};
			PlaneVisual3D planeVisual3D3 = new PlaneVisual3D
			{
				CenterPosition = new Point3D((10.0 + base.Offset) * 0.65, -4.875, 4.875),
				Size = new Size(3.25, 3.25),
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

		// Token: 0x06004DCD RID: 19917 RVA: 0x001519C0 File Offset: 0x0014FBC0
		public PlaneVisual3D CreateFrontPlane(MouseEventHandlers mouseEventHandlers, EventManager3D eventManager)
		{
			PlaneVisual3D planeVisual3D = new PlaneVisual3D
			{
				CenterPosition = new Point3D(0.0, 0.0, (10.0 + base.Offset) * 0.65),
				Size = new Size(6.5, 6.5),
				Normal = new Vector3D(0.0, 0.0, 1.0),
				HeightDirection = new Vector3D(0.0, 1.0, 0.0),
				Material = base.TransparentMaterial
			};
			base.SetupMouseEventHandlers(planeVisual3D, mouseEventHandlers, eventManager);
			return planeVisual3D;
		}

		// Token: 0x06004DCE RID: 19918 RVA: 0x00151AA8 File Offset: 0x0014FCA8
		public PlaneVisual3D CreateTopPlane(MouseEventHandlers mouseEventHandlers, EventManager3D eventManager)
		{
			PlaneVisual3D planeVisual3D = new PlaneVisual3D
			{
				CenterPosition = new Point3D(0.0, (10.0 + base.Offset) * 0.65, 0.0),
				Size = new Size(6.5, 6.5),
				Normal = new Vector3D(0.0, 1.0, 0.0),
				HeightDirection = new Vector3D(0.0, 0.0, 1.0),
				Material = base.TransparentMaterial
			};
			base.SetupMouseEventHandlers(planeVisual3D, mouseEventHandlers, eventManager);
			return planeVisual3D;
		}

		// Token: 0x06004DCF RID: 19919 RVA: 0x00151B90 File Offset: 0x0014FD90
		public PlaneVisual3D CreateBackPlane(MouseEventHandlers mouseEventHandlers, EventManager3D eventManager)
		{
			PlaneVisual3D planeVisual3D = new PlaneVisual3D
			{
				CenterPosition = new Point3D(0.0, 0.0, (-10.0 - base.Offset) * 0.65),
				Size = new Size(6.5, 6.5),
				Normal = new Vector3D(0.0, 0.0, -1.0),
				HeightDirection = new Vector3D(0.0, 1.0, 0.0),
				Material = base.TransparentMaterial
			};
			base.SetupMouseEventHandlers(planeVisual3D, mouseEventHandlers, eventManager);
			return planeVisual3D;
		}

		// Token: 0x06004DD0 RID: 19920 RVA: 0x00151C78 File Offset: 0x0014FE78
		public PlaneVisual3D CreateBottomPlane(MouseEventHandlers mouseEventHandlers, EventManager3D eventManager)
		{
			PlaneVisual3D planeVisual3D = new PlaneVisual3D
			{
				CenterPosition = new Point3D(0.0, (-10.0 - base.Offset) * 0.65, 0.0),
				Size = new Size(6.5, 6.5),
				Normal = new Vector3D(0.0, -1.0, 0.0),
				HeightDirection = new Vector3D(0.0, 0.0, 1.0),
				Material = base.TransparentMaterial
			};
			base.SetupMouseEventHandlers(planeVisual3D, mouseEventHandlers, eventManager);
			return planeVisual3D;
		}

		// Token: 0x06004DD1 RID: 19921 RVA: 0x00151D60 File Offset: 0x0014FF60
		public PlaneVisual3D CreateLeftPlane(MouseEventHandlers mouseEventHandlers, EventManager3D eventManager)
		{
			PlaneVisual3D planeVisual3D = new PlaneVisual3D
			{
				CenterPosition = new Point3D((-10.0 - base.Offset) * 0.65, 0.0, 0.0),
				Size = new Size(6.5, 6.5),
				Normal = new Vector3D(-1.0, 0.0, 0.0),
				HeightDirection = new Vector3D(0.0, 1.0, 0.0),
				Material = base.TransparentMaterial
			};
			base.SetupMouseEventHandlers(planeVisual3D, mouseEventHandlers, eventManager);
			return planeVisual3D;
		}

		// Token: 0x06004DD2 RID: 19922 RVA: 0x00151E48 File Offset: 0x00150048
		public PlaneVisual3D CreateRightPlane(MouseEventHandlers mouseEventHandlers, EventManager3D eventManager)
		{
			PlaneVisual3D planeVisual3D = new PlaneVisual3D
			{
				CenterPosition = new Point3D((10.0 + base.Offset) * 0.65, 0.0, 0.0),
				Size = new Size(6.5, 6.5),
				Normal = new Vector3D(1.0, 0.0, 0.0),
				HeightDirection = new Vector3D(0.0, 1.0, 0.0),
				Material = base.TransparentMaterial
			};
			base.SetupMouseEventHandlers(planeVisual3D, mouseEventHandlers, eventManager);
			return planeVisual3D;
		}

		// Token: 0x06004DD3 RID: 19923 RVA: 0x00151F30 File Offset: 0x00150130
		public void CreateViewCubeBox()
		{
			base.MySetupViewCubeTextures();
			base.ViewCube.CenterPosition = new Point3D(0.0, 0.0, 0.0);
			base.ViewCube.Size = new Size3D(13.0, 13.0, 13.0);
		}

		// Token: 0x06004DD4 RID: 19924 RVA: 0x00151FA8 File Offset: 0x001501A8
		public void CreateAxisArrows(NewViewCubeControl viewCube)
		{
			viewCube.AxisXArrow.StartPosition = new Point3D(-6.5, -6.5, -6.5);
			viewCube.AxisXArrow.EndPosition = new Point3D(13.0, -6.5, -6.5);
			viewCube.AxisXArrow.ArrowRadius = 0.45499999999999996;
			viewCube.AxisXArrow.Radius = 0.195;
			viewCube.AxisXArrow.Material = new DiffuseMaterial(base.AxisXColor);
			viewCube.AxisYArrow.StartPosition = new Point3D(-6.5, -6.5, -6.5);
			viewCube.AxisYArrow.EndPosition = new Point3D(-6.5, 13.0, -6.5);
			viewCube.AxisYArrow.ArrowRadius = 0.45499999999999996;
			viewCube.AxisYArrow.Radius = 0.195;
			viewCube.AxisYArrow.Material = new DiffuseMaterial(base.AxisYColor);
			viewCube.AxisZArrow.StartPosition = new Point3D(-6.5, -6.5, -6.5);
			viewCube.AxisZArrow.EndPosition = new Point3D(-6.5, -6.5, 13.0);
			viewCube.AxisZArrow.ArrowRadius = 0.45499999999999996;
			viewCube.AxisZArrow.Radius = 0.195;
			viewCube.AxisZArrow.Material = new DiffuseMaterial(base.AxisZColor);
		}

		// Token: 0x06004DD5 RID: 19925 RVA: 0x00152190 File Offset: 0x00150390
		public void CreateAxisLabels(NewViewCubeControl viewCube)
		{
			viewCube.AxisXLabelVisual.SetName(#Phc.#3hc(107468707));
			viewCube.AxisXLabelVisual.Text = #Phc.#3hc(107408964);
			viewCube.AxisXLabelVisual.Position = new Point3D(14.950000000000001, -6.5, -6.5);
			viewCube.AxisXLabelVisual.Foreground = base.AxisXColor;
			viewCube.AxisXLabelVisual.Background = base.AxisLabelBackground;
			viewCube.AxisYLabelVisual.SetName(#Phc.#3hc(107468722));
			viewCube.AxisYLabelVisual.Text = #Phc.#3hc(107408991);
			viewCube.AxisYLabelVisual.Position = new Point3D(-6.5, 14.950000000000001, -6.5);
			viewCube.AxisYLabelVisual.Foreground = base.AxisYColor;
			viewCube.AxisYLabelVisual.Background = base.AxisLabelBackground;
			viewCube.AxisZLabelVisual.SetName(#Phc.#3hc(107468673));
			viewCube.AxisZLabelVisual.Text = #Phc.#3hc(107397860);
			viewCube.AxisZLabelVisual.Position = new Point3D(-6.5, -6.5, 14.950000000000001);
			viewCube.AxisZLabelVisual.Foreground = base.AxisZColor;
			viewCube.AxisZLabelVisual.Background = base.AxisLabelBackground;
			viewCube.AxisXLabelVisual.FontSize = 10.0;
			viewCube.AxisYLabelVisual.FontSize = 10.0;
			viewCube.AxisZLabelVisual.FontSize = 10.0;
		}

		// Token: 0x06004DD6 RID: 19926 RVA: 0x0015235C File Offset: 0x0015055C
		public void ArrangeButtonsOnCanvas(NewViewCubeControl viewCube)
		{
			double num = 97.5;
			double num2;
			if (true)
			{
				num2 = num;
			}
			viewCube.Width = num2;
			viewCube.Height = num2;
			viewCube.MinWidth = num2;
			viewCube.MinHeight = num2;
			viewCube.MaxWidth = num2;
			viewCube.MaxHeight = num2;
			viewCube.ButtonsCanvas.Height = num2;
			viewCube.ButtonsCanvas.Width = num2;
			Canvas.SetRight(viewCube.CounterClockwiseButton, 29.25);
			Canvas.SetTop(viewCube.CounterClockwiseButton, 19.5);
			viewCube.CounterClockwiseButton.Width = 9.75;
			viewCube.CounterClockwiseButton.Height = 9.75;
			Canvas.SetRight(viewCube.ClockwiseButton, 19.5);
			Canvas.SetTop(viewCube.ClockwiseButton, 29.25);
			viewCube.ClockwiseButton.Width = 9.75;
			viewCube.ClockwiseButton.Height = 9.75;
			Canvas.SetLeft(viewCube.UpButton, 44.525);
			Canvas.SetTop(viewCube.UpButton, 19.5);
			viewCube.UpButton.Width = 9.75;
			viewCube.UpButton.Height = 9.75;
			Canvas.SetRight(viewCube.RightButton, 19.5);
			Canvas.SetTop(viewCube.RightButton, 44.525);
			viewCube.RightButton.Width = 9.75;
			viewCube.RightButton.Height = 9.75;
			Canvas.SetLeft(viewCube.DownButton, 44.525);
			Canvas.SetBottom(viewCube.DownButton, 19.5);
			viewCube.DownButton.Width = 9.75;
			viewCube.DownButton.Height = 9.75;
			Canvas.SetLeft(viewCube.LeftButton, 19.5);
			Canvas.SetTop(viewCube.LeftButton, 44.525);
			viewCube.LeftButton.Width = 9.75;
			viewCube.LeftButton.Height = 9.75;
		}

		// Token: 0x0400226F RID: 8815
		private const double SizeFactor = 0.65;
	}
}
