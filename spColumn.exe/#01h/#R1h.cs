using System;
using System.Globalization;
using System.IO;
using #2ic;
using #7hc;
using #cYd;
using #Pic;
using #UYd;
using StructurePoint.CoreAssets.DataExchange.ExternFormat;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;

namespace #01h
{
	// Token: 0x02000798 RID: 1944
	internal sealed class #R1h : IDisposable, #Bjc
	{
		// Token: 0x06003E72 RID: 15986 RVA: 0x00120FE0 File Offset: 0x0011F1E0
		public #R1h(string #So)
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

		// Token: 0x06003E73 RID: 15987 RVA: 0x00121098 File Offset: 0x0011F298
		public bool? #npb(#Qjc #Ajc)
		{
			string #R0d = #Phc.#3hc(107374125);
			Component #x6c = Component.DataExchange;
			string #Qic = #Phc.#3hc(107373084);
			if (!false)
			{
				#X0d.#V0d(#Ajc, #R0d, #x6c, #Qic);
			}
			StreamWriter streamWriter = new StreamWriter(this.#a);
			StreamWriter streamWriter2;
			if (8 != 0)
			{
				streamWriter2 = streamWriter;
			}
			try
			{
				if (#Ajc.DrawingUnit == ExternDrawingUnit.MicroInches || #Ajc.DrawingUnit == ExternDrawingUnit.Inches || #Ajc.DrawingUnit == ExternDrawingUnit.Feet || #Ajc.DrawingUnit == ExternDrawingUnit.Yards || #Ajc.DrawingUnit == ExternDrawingUnit.Miles)
				{
					TextWriter textWriter = streamWriter2;
					string value = #Phc.#3hc(107373511);
					if (!false)
					{
						textWriter.Write(value);
					}
				}
				else if (#Ajc.DrawingUnit == ExternDrawingUnit.Nanometers || #Ajc.DrawingUnit == ExternDrawingUnit.Millimeters || #Ajc.DrawingUnit == ExternDrawingUnit.Centimeters || #Ajc.DrawingUnit == ExternDrawingUnit.Decimeters || #Ajc.DrawingUnit == ExternDrawingUnit.Meters || #Ajc.DrawingUnit == ExternDrawingUnit.Kilometers || #Ajc.DrawingUnit == ExternDrawingUnit.GigaMeters)
				{
					TextWriter textWriter2 = streamWriter2;
					string value2 = #Phc.#3hc(107373450);
					if (!false)
					{
						textWriter2.Write(value2);
					}
				}
				TextWriter textWriter3 = streamWriter2;
				string value3 = #Phc.#3hc(107373389);
				if (8 != 0)
				{
					textWriter3.Write(value3);
				}
				if (#Ajc.PolygonPolylines.Count <= 0)
				{
					goto IL_1A8;
				}
				IL_EF:
				if (!#Ajc.PolygonPolylines[0].IsOpening)
				{
					TextWriter textWriter4 = streamWriter2;
					string value4 = #Phc.#3hc(107373392);
					if (!false)
					{
						textWriter4.Write(value4);
					}
					foreach (IVertex vertex in #Ajc.PolygonPolylines[0].Vertexes)
					{
						streamWriter2.Write(string.Format(CultureInfo.CurrentCulture, #Phc.#3hc(107373323), new object[]
						{
							vertex.Point.X,
							vertex.Point.Y
						}));
					}
					streamWriter2.Write(#Phc.#3hc(107372794));
				}
				IL_1A8:
				if (false)
				{
					goto IL_EF;
				}
				if (#Ajc.PolygonPolylines.Count > 1 && #Ajc.PolygonPolylines[1].IsOpening)
				{
					streamWriter2.Write(#Phc.#3hc(107373392));
					foreach (IVertex vertex2 in #Ajc.PolygonPolylines[1].Vertexes)
					{
						streamWriter2.Write(string.Format(CultureInfo.CurrentCulture, #Phc.#3hc(107373323), new object[]
						{
							vertex2.Point.X,
							vertex2.Point.Y
						}));
					}
					streamWriter2.Write(#Phc.#3hc(107372794));
				}
				for (int i = 0; i < #Ajc.Circles.Count; i++)
				{
					streamWriter2.Write(#Phc.#3hc(107372741));
					streamWriter2.Write(string.Format(CultureInfo.CurrentCulture, #Phc.#3hc(107372752), new object[]
					{
						#Ajc.Circles[i].CenterPoint.X,
						#Ajc.Circles[i].CenterPoint.Y,
						#Ajc.Circles[i].Radius
					}));
				}
				streamWriter2.Write(#Phc.#3hc(107372675));
			}
			finally
			{
				if (streamWriter2 != null)
				{
					((IDisposable)streamWriter2).Dispose();
				}
			}
			return new bool?(true);
		}

		// Token: 0x06003E74 RID: 15988 RVA: 0x00035405 File Offset: 0x00033605
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

		// Token: 0x06003E75 RID: 15989 RVA: 0x00035433 File Offset: 0x00033633
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

		// Token: 0x04001C49 RID: 7241
		private Stream #a;
	}
}
