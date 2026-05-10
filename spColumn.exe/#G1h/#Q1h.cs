using System;
using System.Collections.Generic;
using System.IO;
using #2ic;
using #7hc;
using #cYd;
using #Pic;
using #UYd;
using netDxf;
using netDxf.Collections;
using netDxf.Entities;
using netDxf.Header;
using netDxf.Tables;
using netDxf.Units;
using StructurePoint.CoreAssets.DataExchange.ExternFormat;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;

namespace #G1h
{
	// Token: 0x0200078E RID: 1934
	internal sealed class #Q1h : IDisposable, #Bjc
	{
		// Token: 0x06003E2D RID: 15917 RVA: 0x0011F82C File Offset: 0x0011DA2C
		public #Q1h(string #So)
		{
			try
			{
				this.#a = new FileStream(#So, FileMode.Create, FileAccess.Write, FileShare.None);
			}
			catch (UnauthorizedAccessException #Uic)
			{
				throw new #Oic(Strings.StringExportFileProcessAborted.#z2d(), #Phc.#3hc(107374284), Component.DataExchange, #IYd.#b, #JYd.#A, #Uic);
			}
			catch (IOException #Uic2)
			{
				throw new #Oic(Strings.StringExportFileProcessAborted.#z2d(), #Phc.#3hc(107374263), Component.DataExchange, #IYd.#b, #JYd.#A, #Uic2);
			}
			catch (Exception #Uic3)
			{
				throw new #Oic(Strings.StringExportFileProcessAborted.#z2d(), #Phc.#3hc(107374178), Component.DataExchange, #IYd.#a, #Uic3);
			}
		}

		// Token: 0x06003E2E RID: 15918 RVA: 0x0011F8E4 File Offset: 0x0011DAE4
		public bool? #npb(#Qjc #Ajc)
		{
			string #R0d = #Phc.#3hc(107374125);
			Component #x6c = Component.DataExchange;
			string #Qic = #Phc.#3hc(107374128);
			if (8 != 0)
			{
				#X0d.#V0d(#Ajc, #R0d, #x6c, #Qic);
			}
			DxfDocument dxfDocument2;
			if (-1 != 0)
			{
				DxfDocument dxfDocument = new DxfDocument();
				if (!false)
				{
					dxfDocument2 = dxfDocument;
				}
			}
			HeaderVariables drawingVariables = dxfDocument2.DrawingVariables;
			DrawingUnits insUnits = #Q1h.#Ene(#Ajc.DrawingUnit);
			if (true)
			{
				drawingVariables.InsUnits = insUnits;
			}
			List<#ljc> #lAc = #Ajc.PolygonPolylines;
			DxfDocument #fne = dxfDocument2;
			if (5 != 0)
			{
				#Q1h.#L1h(#lAc, #fne);
			}
			List<ILine> #Usb = #Ajc.Lines;
			DxfDocument #fne2 = dxfDocument2;
			if (6 != 0)
			{
				#Q1h.#M1h(#Usb, #fne2);
			}
			List<IPoint> #BP = #Ajc.Points;
			DxfDocument #fne3 = dxfDocument2;
			if (3 != 0)
			{
				#Q1h.#npc(#BP, #fne3);
			}
			#Q1h.#N1h(#Ajc.XLines, dxfDocument2);
			#Q1h.#P1h(#Ajc.Circles, dxfDocument2);
			try
			{
				do
				{
					if (!false)
					{
						dxfDocument2.Save(this.#a);
					}
				}
				while (5 == 0 || 6 == 0);
			}
			catch (Exception #Uic)
			{
				throw new #Oic(Strings.StringExportFileProcessAborted.#z2d(), #Phc.#3hc(107374587), Component.DataExchange, #IYd.#a, #Uic);
			}
			return new bool?(true);
		}

		// Token: 0x06003E2F RID: 15919 RVA: 0x000350DF File Offset: 0x000332DF
		protected void #1(bool #POb)
		{
			for (;;)
			{
				if (!false)
				{
					if (#POb)
					{
						goto IL_06;
					}
					goto IL_22;
				}
				IL_0E:
				Stream stream = this.#a;
				if (!false)
				{
					stream.Dispose();
				}
				if (7 != 0)
				{
					this.#a = null;
					goto IL_22;
				}
				continue;
				IL_06:
				if (this.#a != null)
				{
					goto IL_0E;
				}
				IL_22:
				if (!false)
				{
					break;
				}
				goto IL_06;
			}
		}

		// Token: 0x06003E30 RID: 15920 RVA: 0x0011FA04 File Offset: 0x0011DC04
		private static DrawingUnits #Ene(ExternDrawingUnit #Fne)
		{
			for (;;)
			{
				switch (#Fne)
				{
				case ExternDrawingUnit.UnitLess:
					return DrawingUnits.Unitless;
				case ExternDrawingUnit.Inches:
					goto IL_5E;
				case ExternDrawingUnit.Feet:
					return DrawingUnits.Feet;
				case ExternDrawingUnit.Miles:
					return DrawingUnits.Miles;
				case ExternDrawingUnit.Millimeters:
					return DrawingUnits.Millimeters;
				case ExternDrawingUnit.Centimeters:
					return DrawingUnits.Centimeters;
				case ExternDrawingUnit.Meters:
					return DrawingUnits.Meters;
				case ExternDrawingUnit.Kilometers:
					return DrawingUnits.Kilometers;
				case ExternDrawingUnit.MicroInches:
					return DrawingUnits.Microinches;
				case ExternDrawingUnit.Mils:
					goto IL_71;
				case ExternDrawingUnit.Yards:
					return DrawingUnits.Yards;
				case ExternDrawingUnit.Angstroms:
					return DrawingUnits.Angstroms;
				case ExternDrawingUnit.Nanometers:
					return DrawingUnits.Nanometers;
				case ExternDrawingUnit.Microns:
					return DrawingUnits.Microns;
				case ExternDrawingUnit.Decimeters:
					goto IL_83;
				case ExternDrawingUnit.Decameters:
					return DrawingUnits.Decameters;
				case ExternDrawingUnit.Hectometers:
					if (!false)
					{
						return DrawingUnits.Hectometers;
					}
					continue;
				case ExternDrawingUnit.GigaMeters:
					return DrawingUnits.Gigameters;
				case ExternDrawingUnit.AstronomicalUnits:
					return DrawingUnits.AstronomicalUnits;
				case ExternDrawingUnit.LightYears:
					return DrawingUnits.LightYears;
				case ExternDrawingUnit.Parsecs:
					return DrawingUnits.Parsecs;
				}
				break;
			}
			int num2;
			int num = num2 = 107374502;
			if (num != 0)
			{
				throw new ArgumentOutOfRangeException(#Phc.#3hc(num), #Fne, null);
			}
			goto IL_5F;
			IL_5E:
			num2 = 1;
			IL_5F:
			int result;
			int num3 = result = num2;
			if (num3 != 0)
			{
				return (DrawingUnits)num3;
			}
			return (DrawingUnits)result;
			IL_71:
			if (-1 != 0)
			{
				return DrawingUnits.Mils;
			}
			return DrawingUnits.Microinches;
			IL_83:
			result = 14;
			return (DrawingUnits)result;
		}

		// Token: 0x06003E31 RID: 15921 RVA: 0x0003510D File Offset: 0x0003330D
		private static Layer #Dne(#jjc #rR)
		{
			Layer layer = new Layer(#rR.Name);
			AciColor color = new AciColor(#rR.Color.R, #rR.Color.G, #rR.Color.B);
			if (4 != 0)
			{
				layer.Color = color;
			}
			return layer;
		}

		// Token: 0x06003E32 RID: 15922 RVA: 0x0011FAC8 File Offset: 0x0011DCC8
		private static void #L1h(List<#ljc> #lAc, DxfDocument #fne)
		{
			List<#ljc>.Enumerator enumerator = #lAc.GetEnumerator();
			List<#ljc>.Enumerator enumerator2;
			if (4 != 0)
			{
				enumerator2 = enumerator;
			}
			try
			{
				while (enumerator2.MoveNext())
				{
					#ljc #ljc2;
					List<Polyline2DVertex> list2;
					if (3 != 0)
					{
						#ljc #ljc = enumerator2.Current;
						if (!false)
						{
							#ljc2 = #ljc;
						}
						if (#ljc2.Layer == null)
						{
							continue;
						}
						List<Polyline2DVertex> list = new List<Polyline2DVertex>();
						if (8 != 0)
						{
							list2 = list;
						}
					}
					List<IVertex>.Enumerator enumerator3 = #ljc2.Vertexes.GetEnumerator();
					List<IVertex>.Enumerator enumerator4;
					if (!false)
					{
						enumerator4 = enumerator3;
					}
					try
					{
						while ((6 == 0 || enumerator4.MoveNext()) && 4 != 0)
						{
							IVertex vertex = enumerator4.Current;
							IVertex vertex2;
							if (!false)
							{
								vertex2 = vertex;
							}
							List<Polyline2DVertex> list3 = list2;
							Polyline2DVertex item = new Polyline2DVertex(vertex2.Point.X, vertex2.Point.Y);
							if (3 != 0)
							{
								list3.Add(item);
							}
						}
					}
					finally
					{
						((IDisposable)enumerator4).Dispose();
					}
					Polyline2D polyline2D = new Polyline2D(list2, #ljc2.IsClosed);
					polyline2D.Layer = #Q1h.#Dne(#ljc2.Layer);
					#fne.Entities.Add(polyline2D);
				}
			}
			finally
			{
				do
				{
					((IDisposable)enumerator2).Dispose();
				}
				while (false);
			}
		}

		// Token: 0x06003E33 RID: 15923 RVA: 0x0011FBFC File Offset: 0x0011DDFC
		private static void #M1h(List<ILine> #Usb, DxfDocument #fne)
		{
			if (#Usb.Count > 0 && #Usb[0].Layer != null)
			{
				List<ILine>.Enumerator enumerator = #Usb.GetEnumerator();
				List<ILine>.Enumerator enumerator2;
				if (!false)
				{
					enumerator2 = enumerator;
				}
				try
				{
					while (enumerator2.MoveNext())
					{
						ILine line = enumerator2.Current;
						ILine line2;
						if (4 != 0)
						{
							line2 = line;
						}
						Line line3 = new Line(new Vector2(line2.StartPoint.X, line2.StartPoint.Y), new Vector2(line2.EndPoint.X, line2.EndPoint.Y));
						Line line4;
						if (6 != 0)
						{
							line4 = line3;
						}
						EntityObject entityObject = line4;
						Layer layer = #Q1h.#Dne(line2.Layer);
						if (4 != 0)
						{
							entityObject.Layer = layer;
						}
						DrawingEntities entities = #fne.Entities;
						EntityObject entity = line4;
						if (4 != 0)
						{
							entities.Add(entity);
						}
					}
				}
				finally
				{
					((IDisposable)enumerator2).Dispose();
				}
			}
		}

		// Token: 0x06003E34 RID: 15924 RVA: 0x0011FCE0 File Offset: 0x0011DEE0
		private static void #npc(List<IPoint> #BP, DxfDocument #fne)
		{
			if (#BP.Count > 0 && #BP[0].Layer != null)
			{
				List<IPoint>.Enumerator enumerator = #BP.GetEnumerator();
				List<IPoint>.Enumerator enumerator2;
				if (2 != 0)
				{
					enumerator2 = enumerator;
				}
				try
				{
					while (enumerator2.MoveNext())
					{
						IPoint point = enumerator2.Current;
						IPoint point2;
						if (!false)
						{
							point2 = point;
						}
						Point point3 = new Point(point2.X, point2.Y, point2.Z);
						Point point4;
						if (6 != 0)
						{
							point4 = point3;
						}
						EntityObject entityObject = point4;
						Layer layer = #Q1h.#Dne(point2.Layer);
						if (2 != 0)
						{
							entityObject.Layer = layer;
						}
						DrawingEntities entities = #fne.Entities;
						EntityObject entity = point4;
						if (!false)
						{
							entities.Add(entity);
						}
					}
				}
				finally
				{
					((IDisposable)enumerator2).Dispose();
				}
			}
		}

		// Token: 0x06003E35 RID: 15925 RVA: 0x0011FD9C File Offset: 0x0011DF9C
		private static void #N1h(List<#yjc> #O1h, DxfDocument #fne)
		{
			if (#O1h.Count > 0 && #O1h[0].Layer != null)
			{
				List<#yjc>.Enumerator enumerator = #O1h.GetEnumerator();
				List<#yjc>.Enumerator enumerator2;
				if (!false)
				{
					enumerator2 = enumerator;
				}
				try
				{
					while (enumerator2.MoveNext())
					{
						#yjc #yjc = enumerator2.Current;
						#yjc #yjc2;
						if (4 != 0)
						{
							#yjc2 = #yjc;
						}
						XLine xline = new XLine(new Vector2(#yjc2.Origin.X, #yjc2.Origin.Y), new Vector2(#yjc2.Direction.X, #yjc2.Direction.Y));
						XLine xline2;
						if (6 != 0)
						{
							xline2 = xline;
						}
						EntityObject entityObject = xline2;
						Layer layer = #Q1h.#Dne(#yjc2.Layer);
						if (4 != 0)
						{
							entityObject.Layer = layer;
						}
						DrawingEntities entities = #fne.Entities;
						EntityObject entity = xline2;
						if (4 != 0)
						{
							entities.Add(entity);
						}
					}
				}
				finally
				{
					((IDisposable)enumerator2).Dispose();
				}
			}
		}

		// Token: 0x06003E36 RID: 15926 RVA: 0x0011FE80 File Offset: 0x0011E080
		private static void #P1h(List<#tjc> #mAc, DxfDocument #fne)
		{
			if (#mAc.Count > 0 && #mAc[0].Layer != null)
			{
				List<#tjc>.Enumerator enumerator = #mAc.GetEnumerator();
				List<#tjc>.Enumerator enumerator2;
				if (7 != 0)
				{
					enumerator2 = enumerator;
				}
				try
				{
					while (enumerator2.MoveNext())
					{
						#tjc #tjc = enumerator2.Current;
						#tjc #tjc2;
						if (3 != 0)
						{
							#tjc2 = #tjc;
						}
						Circle circle2;
						do
						{
							Circle circle = new Circle(new Vector3(#tjc2.CenterPoint.X, #tjc2.CenterPoint.Y, #tjc2.CenterPoint.Z), #tjc2.Radius);
							if (3 != 0)
							{
								circle2 = circle;
							}
						}
						while (-1 == 0);
						EntityObject entityObject = circle2;
						Layer layer = #Q1h.#Dne(#tjc2.Layer);
						if (!false)
						{
							entityObject.Layer = layer;
						}
						DrawingEntities entities = #fne.Entities;
						EntityObject entity = circle2;
						if (!false)
						{
							entities.Add(entity);
						}
					}
				}
				finally
				{
					do
					{
						if (7 != 0 && 8 != 0)
						{
							((IDisposable)enumerator2).Dispose();
						}
					}
					while (false);
				}
			}
		}

		// Token: 0x06003E37 RID: 15927 RVA: 0x0003514D File Offset: 0x0003334D
		public void #1()
		{
			bool #POb = true;
			if (!false)
			{
				this.#1(#POb);
			}
			if (!false)
			{
				GC.SuppressFinalize(this);
			}
		}

		// Token: 0x04001C33 RID: 7219
		private Stream #a;
	}
}
