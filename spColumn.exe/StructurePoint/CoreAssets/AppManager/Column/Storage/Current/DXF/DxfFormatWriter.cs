using System;
using System.IO;
using System.Linq;
using System.Windows.Media;
using #7hc;
using netDxf;
using netDxf.Entities;
using netDxf.Tables;
using netDxf.Units;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.Units;

namespace StructurePoint.CoreAssets.AppManager.Column.Storage.Current.DXF
{
	// Token: 0x020010F3 RID: 4339
	public sealed class DxfFormatWriter
	{
		// Token: 0x0600932F RID: 37679 RVA: 0x001F40E0 File Offset: 0x001F22E0
		public void #npb(Stream #gp, ColumnStorageModel #Od)
		{
			DxfDocument dxfDocument = new DxfDocument();
			dxfDocument.DrawingVariables.InsUnits = DxfFormatWriter.#gFb(#Od.Options.Unit);
			this.#M6(dxfDocument, #Od);
			this.#HWi(dxfDocument, #Od);
			dxfDocument.Save(#gp);
		}

		// Token: 0x06009330 RID: 37680 RVA: 0x00075FDD File Offset: 0x000741DD
		private static Layer #GWi(string #wy, Color #BR)
		{
			return new Layer(#wy)
			{
				Color = new AciColor(#BR.R, #BR.G, #BR.B)
			};
		}

		// Token: 0x06009331 RID: 37681 RVA: 0x00076005 File Offset: 0x00074205
		private static DrawingUnits #gFb(UnitSystem #Qg)
		{
			if (#Qg == UnitSystem.USCustomary)
			{
				return DrawingUnits.Inches;
			}
			if (#Qg != UnitSystem.SIMetric)
			{
				throw new ArgumentOutOfRangeException(#Phc.#3hc(107289939), #Qg, null);
			}
			return DrawingUnits.Millimeters;
		}

		// Token: 0x06009332 RID: 37682 RVA: 0x001F4128 File Offset: 0x001F2328
		private void #HWi(DxfDocument #bFd, ColumnStorageModel #Od)
		{
			Layer layer = DxfFormatWriter.#GWi(#Phc.#3hc(107348240), this.#a);
			#bFd.Layers.Add(layer);
			foreach (ReinforcementBar reinforcementBar in #Od.ReinforcementBars)
			{
				if ((double)reinforcementBar.Area > 0.001)
				{
					double radius = CircleHelper.#wmc((double)reinforcementBar.Area);
					#bFd.Entities.Add(new Circle(new Vector2((double)reinforcementBar.X, (double)reinforcementBar.Y), radius)
					{
						Layer = layer
					});
				}
			}
		}

		// Token: 0x06009333 RID: 37683 RVA: 0x001F41E4 File Offset: 0x001F23E4
		private void #M6(DxfDocument #bFd, ColumnStorageModel #Od)
		{
			Layer layer = DxfFormatWriter.#GWi(#Phc.#3hc(107348230), this.#b);
			Layer layer2 = DxfFormatWriter.#GWi(#Phc.#3hc(107348253), this.#c);
			#bFd.Layers.Add(layer);
			#bFd.Layers.Add(layer2);
			foreach (SectionPolygon sectionPolygon in #Od.Polygons)
			{
				Layer layer3 = (sectionPolygon.Application == PolygonApplication.Solid) ? layer : layer2;
				if (sectionPolygon.FigureType == PolygonFigureType.Circle && sectionPolygon.CircleRadius != null && sectionPolygon.CircleCenter != null)
				{
					#bFd.Entities.Add(new Circle(new Vector2((double)sectionPolygon.CircleCenter.X, (double)sectionPolygon.CircleCenter.Y), sectionPolygon.CircleRadius.Value)
					{
						Layer = layer3
					});
				}
				else
				{
					#bFd.Entities.Add(new Polyline2D(sectionPolygon.Points.Take(sectionPolygon.Points.Count - 1).Select(new Func<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point, Vector2>(DxfFormatWriter.<>c.<>9.#7Wi)), true)
					{
						Layer = layer3
					});
				}
			}
		}

		// Token: 0x04003E9B RID: 16027
		private readonly Color #a = Color.FromRgb(0, 0, byte.MaxValue);

		// Token: 0x04003E9C RID: 16028
		private readonly Color #b = Color.FromRgb(byte.MaxValue, 0, 0);

		// Token: 0x04003E9D RID: 16029
		private readonly Color #c = Color.FromRgb(0, byte.MaxValue, 0);
	}
}
