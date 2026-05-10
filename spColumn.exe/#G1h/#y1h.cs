using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;
using #2ic;
using #7hc;
using #cYd;
using #o1d;
using #Pic;
using #UYd;
using #Vjc;
using netDxf;
using netDxf.Entities;
using netDxf.Header;
using netDxf.Tables;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;

namespace #G1h
{
	// Token: 0x0200078D RID: 1933
	[SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling")]
	[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "DXF")]
	internal sealed class #y1h : IDisposable, #Gjc
	{
		// Token: 0x06003E10 RID: 15888 RVA: 0x0011D2E0 File Offset: 0x0011B4E0
		public #y1h(string #4Hc)
		{
			#X0d.#W0d(#4Hc, #Phc.#3hc(107377058), Component.DataExchange, #Phc.#3hc(107377077));
			try
			{
				this.#a = new FileStream(#4Hc, FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read);
			}
			catch (UnauthorizedAccessException #Uic)
			{
				throw new #Oic(Strings.StringImportFileProcessAborted.#z2d(), #Phc.#3hc(107376992), Component.DataExchange, #IYd.#b, #JYd.#A, #Uic);
			}
			catch (IOException #Uic2)
			{
				throw new #Oic(Strings.StringImportFileProcessAborted.#z2d(), #Phc.#3hc(107376939), Component.DataExchange, #IYd.#b, #JYd.#A, #Uic2);
			}
			catch (Exception #Uic3)
			{
				throw new #Oic(Strings.StringImportFileProcessAborted.#z2d(), #Phc.#3hc(107376918), Component.DataExchange, #IYd.#a, #Uic3);
			}
		}

		// Token: 0x06003E11 RID: 15889 RVA: 0x0011D3E8 File Offset: 0x0011B5E8
		public #y1h(Stream #Gfb)
		{
			#X0d.#V0d(#Gfb, #Phc.#3hc(107376321), Component.DataExchange, #Phc.#3hc(107376344));
			this.#a = #Gfb;
			this.#a.Seek(0L, SeekOrigin.Begin);
		}

		// Token: 0x06003E12 RID: 15890 RVA: 0x0011D464 File Offset: 0x0011B664
		public string #Fjc()
		{
			string result;
			try
			{
				bool flag;
				DxfVersion dxfVersion = DxfDocument.CheckDxfFileVersion(this.#a, out flag);
				DxfVersion dxfVersion2;
				if (-1 != 0)
				{
					dxfVersion2 = dxfVersion;
				}
				string text = dxfVersion2.ToString();
				if (!false)
				{
					result = text;
				}
			}
			catch (ArgumentException #Uic)
			{
				throw new #Oic(Strings.StringImportFileProcessAborted.#z2d(), #Phc.#3hc(107376259), Component.DataExchange, #IYd.#b, #JYd.#A, #Uic);
			}
			catch (IndexOutOfRangeException #Uic2)
			{
				throw new #Oic(Strings.StringImportFileProcessAborted.#z2d(), #Phc.#3hc(107376206), Component.DataExchange, #IYd.#b, #JYd.#A, #Uic2);
			}
			catch (Exception #Uic3)
			{
				throw new #Oic(Strings.StringImportFileProcessAborted.#z2d(), #Phc.#3hc(107376185), Component.DataExchange, #IYd.#a, #Uic3);
			}
			return result;
		}

		// Token: 0x06003E13 RID: 15891 RVA: 0x0011D534 File Offset: 0x0011B734
		public string #Ejc()
		{
			StringBuilder stringBuilder2;
			if (4 != 0)
			{
				StringBuilder stringBuilder = new StringBuilder();
				if (!false)
				{
					stringBuilder2 = stringBuilder;
				}
				List<DxfVersion>.Enumerator enumerator = this.#b.GetEnumerator();
				List<DxfVersion>.Enumerator enumerator2;
				if (!false)
				{
					enumerator2 = enumerator;
					goto IL_24;
				}
				try
				{
					for (;;)
					{
						IL_24:
						while (enumerator2.MoveNext())
						{
							DxfVersion dxfVersion = enumerator2.Current;
							DxfVersion dxfVersion2;
							if (4 != 0)
							{
								dxfVersion2 = dxfVersion;
							}
							if (!false)
							{
								stringBuilder2.Append(dxfVersion2.ToString());
								stringBuilder2.Append(#Phc.#3hc(107376612));
							}
						}
						break;
					}
				}
				finally
				{
					if (!false)
					{
						((IDisposable)enumerator2).Dispose();
					}
				}
				stringBuilder2.Remove(stringBuilder2.Length - 2, 2);
			}
			stringBuilder2.Append(#Phc.#3hc(107356879));
			return stringBuilder2.ToString();
		}

		// Token: 0x06003E14 RID: 15892 RVA: 0x0011D5FC File Offset: 0x0011B7FC
		[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
		public bool #Djc()
		{
			bool flag = false;
			bool result;
			if (!false)
			{
				result = flag;
			}
			try
			{
				bool flag2;
				DxfVersion dxfVersion = DxfDocument.CheckDxfFileVersion(this.#a, out flag2);
				DxfVersion item;
				if (8 != 0)
				{
					item = dxfVersion;
				}
				int num;
				bool flag3 = (num = (this.#b.Contains(item) ? 1 : 0)) != 0;
				if (!false)
				{
					if (!flag3)
					{
						goto IL_2F;
					}
					num = 1;
				}
				if (7 != 0)
				{
					result = (num != 0);
				}
				IL_2F:;
			}
			catch (ArgumentException #Uic)
			{
				throw new #Oic(Strings.StringDXFFileVersionCouldNotBeRead.#z2d(), #Phc.#3hc(107376639), Component.DataExchange, #IYd.#b, #JYd.#A, #Uic);
			}
			catch (IndexOutOfRangeException #Uic2)
			{
				throw new #Oic(Strings.StringDXFFileVersionCouldNotBeRead.#z2d(), #Phc.#3hc(107376554), Component.DataExchange, #IYd.#b, #JYd.#A, #Uic2);
			}
			catch (Exception #Uic3)
			{
				throw new #Oic(Strings.StringDXFFileVersionCouldNotBeRead.#z2d(), #Phc.#3hc(107376533), Component.DataExchange, #IYd.#a, #JYd.#A, #Uic3);
			}
			return result;
		}

		// Token: 0x06003E15 RID: 15893 RVA: 0x00035063 File Offset: 0x00033263
		public #Qjc #Cjc(#Tjc #yf)
		{
			return this.#50h(#yf);
		}

		// Token: 0x06003E16 RID: 15894 RVA: 0x0011D6E4 File Offset: 0x0011B8E4
		[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "DXF")]
		internal #kkc #50h(#Tjc #yf)
		{
			#kkc #kkc = new #kkc();
			#kkc #kkc2;
			if (!false)
			{
				#kkc2 = #kkc;
			}
			DxfDocument dxfDocument2;
			try
			{
				this.#a.#i2d();
				DxfDocument dxfDocument = DxfDocument.Load(this.#a);
				if (!false)
				{
					dxfDocument2 = dxfDocument;
				}
			}
			catch (Exception #Uic)
			{
				throw new #Oic(Strings.StringImportFileProcessAborted.#z2d(), #Phc.#3hc(107376448), Component.DataExchange, #IYd.#a, #Uic);
			}
			if (dxfDocument2 == null)
			{
				throw new #Oic(Strings.StringImportFileProcessAborted.#z2d(), #Phc.#3hc(107376395), Component.DataExchange, #IYd.#b, #JYd.#A, null);
			}
			IEnumerator<Layer> enumerator = dxfDocument2.Layers.GetEnumerator();
			IEnumerator<Layer> enumerator2;
			if (5 != 0)
			{
				enumerator2 = enumerator;
			}
			try
			{
				while (enumerator2.MoveNext())
				{
					Layer #rR = enumerator2.Current;
					#kkc #Od = #kkc2;
					if (!false)
					{
						#y1h.#e1h(#rR, #Od, #yf);
					}
				}
			}
			finally
			{
				if (enumerator2 != null)
				{
					enumerator2.Dispose();
				}
			}
			List<EntityObject>.Enumerator enumerator3 = #y1h.#m1h(dxfDocument2).GetEnumerator();
			List<EntityObject>.Enumerator enumerator4;
			if (6 != 0)
			{
				enumerator4 = enumerator3;
			}
			try
			{
				while (enumerator4.MoveNext())
				{
					EntityObject #8Y = enumerator4.Current;
					#kkc #mSc = #kkc2;
					#mkc #70h = new #mkc(0.0, 0.0, 0.0, new #fkc(string.Empty));
					#9jc #oue = null;
					if (true)
					{
						#y1h.#60h(#8Y, #mSc, #70h, #oue, #yf);
					}
				}
			}
			finally
			{
				((IDisposable)enumerator4).Dispose();
			}
			#kkc2.DrawingUnit = #C1h.#A1h(dxfDocument2.DrawingVariables.InsUnits);
			return #kkc2;
		}

		// Token: 0x06003E17 RID: 15895 RVA: 0x0003506C File Offset: 0x0003326C
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

		// Token: 0x06003E18 RID: 15896 RVA: 0x0011D864 File Offset: 0x0011BA64
		internal static void #60h(EntityObject #8Y, #kkc #mSc, #mkc #70h, #9jc #oue, #Tjc #yf)
		{
			EntityType type = #8Y.Type;
			EntityType entityType;
			if (6 != 0)
			{
				entityType = type;
			}
			switch (entityType)
			{
			case EntityType.Arc:
				if (4 != 0)
				{
					#y1h.#80h(#8Y, #mSc, #70h, #oue, #yf);
				}
				return;
			case EntityType.Circle:
				if (!false)
				{
					#y1h.#90h(#8Y, #mSc, #70h, #yf);
				}
				return;
			case EntityType.Dimension:
				if (5 != 0)
				{
					#y1h.#a1h(#8Y, #mSc, #70h, #yf);
				}
				return;
			case EntityType.Ellipse:
				if (6 != 0)
				{
					#y1h.#b1h(#8Y, #mSc, #70h, #yf);
				}
				break;
			case EntityType.Face3D:
			case EntityType.Image:
			case EntityType.Leader:
			case EntityType.Mesh:
			case EntityType.MLine:
			case EntityType.PolyfaceMesh:
			case EntityType.PolygonMesh:
			case EntityType.Ray:
			case EntityType.Shape:
			case EntityType.Spline:
				goto IL_127;
			case EntityType.Hatch:
				if (!false)
				{
					#y1h.#c1h(#8Y, #mSc, #70h, #yf);
				}
				return;
			case EntityType.Insert:
				#y1h.#d1h(#8Y, #mSc, #70h, #yf);
				if (!false)
				{
					return;
				}
				break;
			case EntityType.Line:
				#y1h.#f1h(#8Y, #mSc, #70h, #oue, #yf);
				return;
			case EntityType.MText:
				do
				{
					#y1h.#h1h(#8Y, #mSc, #70h, #oue, #yf);
				}
				while (false);
				return;
			case EntityType.Point:
				#y1h.#i1h(#8Y, #mSc, #70h, #yf);
				return;
			case EntityType.Polyline2D:
				#y1h.#8Vi(#8Y, #mSc, #70h, #yf);
				return;
			case EntityType.Polyline3D:
				#y1h.#9Vi(#8Y, #mSc, #70h, #yf);
				return;
			case EntityType.Solid:
				#y1h.#k1h(#8Y, #mSc, #70h, #oue, #yf);
				return;
			case EntityType.Text:
				#y1h.#l1h(#8Y, #mSc, #70h, #yf);
				return;
			default:
				goto IL_127;
			}
			return;
			IL_127:
			#yf.#Rjc(Strings.StringDxfFileContainsUnsupportedEntityX.#D2d(new object[]
			{
				#8Y.Type
			}).#z2d(true), new #Oic(Strings.StringTheDataExchangeRaisedAnException.#z2d(), #Phc.#3hc(107375862), Component.DataExchange, #IYd.#b, #JYd.#C));
		}

		// Token: 0x06003E19 RID: 15897 RVA: 0x0011DA20 File Offset: 0x0011BC20
		[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
		internal static void #80h(EntityObject #8Y, #kkc #mSc, #mkc #70h, #9jc #oue, #Tjc #yf)
		{
			try
			{
				Arc arc = (Arc)#8Y;
				Arc arc2;
				if (4 != 0)
				{
					arc2 = arc;
				}
				#fkc #fkc = new #fkc(arc2.Layer.Name, new #3jc(arc2.Layer.Color.R, arc2.Layer.Color.G, arc2.Layer.Color.B));
				#fkc #rR;
				if (!false)
				{
					#rR = #fkc;
				}
				#Ujc item;
				do
				{
					Vector3 center = arc2.Center;
					Vector3 vector;
					if (5 != 0)
					{
						vector = center;
					}
					double #9o = vector.X + #70h.X;
					Vector3 center2 = arc2.Center;
					if (-1 != 0)
					{
						vector = center2;
					}
					double #7W = vector.Y + #70h.Y;
					Vector3 center3 = arc2.Center;
					if (!false)
					{
						vector = center3;
					}
					#Ujc #Ujc = new #Ujc(new #mkc(#9o, #7W, vector.Z + #70h.Z, #rR), arc2.Radius, arc2.StartAngle, arc2.EndAngle, #rR);
					if (7 != 0)
					{
						item = #Ujc;
					}
				}
				while (false);
				if (#oue == null)
				{
					#mSc.Arcs.Add(item);
				}
				else
				{
					#oue.Arcs.Add(item);
				}
			}
			catch (InvalidCastException #Uic)
			{
				#yf.#Rjc(Strings.StringFailedToReadArcEntity.#z2d(), new #Oic(Strings.StringTheDataExchangeRaisedAnException.#z2d(), #Phc.#3hc(107375777), Component.DataExchange, #IYd.#b, #JYd.#B, #Uic));
			}
			catch (Exception #Uic2)
			{
				#yf.#Rjc(Strings.StringFailedToReadArcEntity.#z2d(), new #Oic(Strings.StringTheDataExchangeRaisedAnException.#z2d(), #Phc.#3hc(107375724), Component.DataExchange, #IYd.#a, #Uic2));
			}
		}

		// Token: 0x06003E1A RID: 15898 RVA: 0x0011DBDC File Offset: 0x0011BDDC
		[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
		internal static void #90h(EntityObject #8Y, #kkc #Od, #mkc #70h, #Tjc #yf)
		{
			try
			{
				string #R0d = #Phc.#3hc(107375703);
				Component #x6c = Component.DataExchange;
				string #Qic = #Phc.#3hc(107375662);
				if (!false)
				{
					#X0d.#V0d(#8Y, #R0d, #x6c, #Qic);
				}
				Circle circle = (Circle)#8Y;
				Circle circle2;
				if (!false)
				{
					circle2 = circle;
				}
				#fkc #fkc = new #fkc(circle2.Layer.Name, new #3jc(circle2.Layer.Color.R, circle2.Layer.Color.G, circle2.Layer.Color.B));
				#fkc #rR;
				if (3 != 0)
				{
					#rR = #fkc;
				}
				Vector3 center = circle2.Center;
				Vector3 vector;
				if (!false)
				{
					vector = center;
				}
				double #9o = vector.X + #70h.X;
				Vector3 center2 = circle2.Center;
				if (2 != 0)
				{
					vector = center2;
				}
				double #7W = vector.Y + #70h.Y;
				Vector3 center3 = circle2.Center;
				if (6 != 0)
				{
					vector = center3;
				}
				#Zjc item = new #Zjc(new #mkc(#9o, #7W, vector.Z + #70h.Z, #rR), circle2.Radius, #rR);
				#Od.Circles.Add(item);
			}
			catch (InvalidCastException #Uic)
			{
				do
				{
					#yf.#Rjc(Strings.StringFailedToReadCircleEntity.#z2d(), new #Oic(Strings.StringTheDataExchangeRaisedAnException.#z2d(), #Phc.#3hc(107375641), Component.DataExchange, #IYd.#b, #JYd.#B, #Uic));
				}
				while (false);
			}
			catch (Exception #Uic2)
			{
				#yf.#Rjc(Strings.StringFailedToReadCircleEntity.#z2d(), new #Oic(Strings.StringTheDataExchangeRaisedAnException.#z2d(), #Phc.#3hc(107376068), Component.DataExchange, #IYd.#a, #Uic2));
			}
		}

		// Token: 0x06003E1B RID: 15899 RVA: 0x0011DD90 File Offset: 0x0011BF90
		[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
		internal static void #a1h(EntityObject #8Y, #kkc #Od, #mkc #70h, #Tjc #yf)
		{
			try
			{
				Dimension dimension = (Dimension)#8Y;
				#9jc #9jc = new #9jc();
				#9jc #9jc2;
				if (5 != 0)
				{
					#9jc2 = #9jc;
				}
				IEnumerator<EntityObject> enumerator = dimension.Block.Entities.GetEnumerator();
				IEnumerator<EntityObject> enumerator2;
				if (-1 != 0)
				{
					enumerator2 = enumerator;
				}
				try
				{
					while (enumerator2.MoveNext())
					{
						EntityObject #8Y2 = enumerator2.Current;
						#9jc #oue = #9jc2;
						if (6 != 0)
						{
							#y1h.#60h(#8Y2, #Od, #70h, #oue, #yf);
						}
					}
				}
				finally
				{
					if (enumerator2 != null)
					{
						enumerator2.Dispose();
					}
				}
			}
			catch (InvalidCastException #Uic)
			{
				if (4 != 0)
				{
					#yf.#Rjc(Strings.StringFailedToReadDimensionEntity.#z2d(), new #Oic(Strings.StringTheDataExchangeRaisedAnException.#z2d(), #Phc.#3hc(107376015), Component.DataExchange, #IYd.#b, #JYd.#B, #Uic));
				}
			}
			catch (Exception #Uic2)
			{
				do
				{
					#yf.#Rjc(Strings.StringFailedToReadDimensionEntity.#z2d(), new #Oic(Strings.StringTheDataExchangeRaisedAnException.#z2d(), #Phc.#3hc(107375994), Component.DataExchange, #IYd.#a, #Uic2));
				}
				while (4 == 0);
			}
		}

		// Token: 0x06003E1C RID: 15900 RVA: 0x0011DE8C File Offset: 0x0011C08C
		[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
		internal static void #b1h(EntityObject #8Y, #kkc #Od, #mkc #70h, #Tjc #yf)
		{
			try
			{
				Ellipse ellipse = (Ellipse)#8Y;
				Ellipse ellipse2;
				if (6 != 0)
				{
					ellipse2 = ellipse;
				}
				#fkc #fkc = new #fkc(ellipse2.Layer.Name, new #3jc(ellipse2.Layer.Color.R, ellipse2.Layer.Color.G, ellipse2.Layer.Color.B));
				#fkc #rR;
				if (!false)
				{
					#rR = #fkc;
				}
				Vector3 center = ellipse2.Center;
				Vector3 vector;
				if (-1 != 0)
				{
					vector = center;
				}
				double #9o;
				double num = #9o = vector.X;
				if (!false)
				{
					#9o = num + #70h.X;
				}
				Vector3 center2 = ellipse2.Center;
				if (8 != 0)
				{
					vector = center2;
				}
				double num2 = vector.Y;
				double #7W;
				do
				{
					#7W = (num2 += #70h.Y);
				}
				while (8 == 0);
				Vector3 center3 = ellipse2.Center;
				if (!false)
				{
					vector = center3;
				}
				#akc #akc = new #akc(new #mkc(#9o, #7W, vector.Z + #70h.Z, #rR), ellipse2.MajorAxis / 2.0, ellipse2.MinorAxis / 2.0, ellipse2.Rotation, ellipse2.StartAngle, ellipse2.EndAngle, #rR);
				#akc item;
				if (!false)
				{
					item = #akc;
				}
				do
				{
					#Od.Ellipses.Add(item);
				}
				while (false);
			}
			catch (InvalidCastException #Uic)
			{
				#yf.#Rjc(Strings.StringFailedToReadEllipseEntity.#z2d(), new #Oic(Strings.StringTheDataExchangeRaisedAnException.#z2d(), #Phc.#3hc(107375909), Component.DataExchange, #IYd.#b, #JYd.#B, #Uic));
			}
			catch (Exception #Uic2)
			{
				if (8 != 0)
				{
					#yf.#Rjc(Strings.StringFailedToReadEllipseEntity.#z2d(), new #Oic(Strings.StringTheDataExchangeRaisedAnException.#z2d(), #Phc.#3hc(107375888), Component.DataExchange, #IYd.#a, #Uic2));
				}
			}
		}

		// Token: 0x06003E1D RID: 15901 RVA: 0x0011E060 File Offset: 0x0011C260
		[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
		internal static void #c1h(EntityObject #8Y, #kkc #Od, #mkc #70h, #Tjc #yf)
		{
			try
			{
				#ekc item;
				if (!false)
				{
					Hatch hatch = (Hatch)#8Y;
					Hatch hatch2;
					if (true)
					{
						hatch2 = hatch;
					}
					#fkc #fkc = new #fkc(hatch2.Layer.Name, new #3jc(hatch2.Layer.Color.R, hatch2.Layer.Color.G, hatch2.Layer.Color.B));
					#fkc #rR;
					if (!false)
					{
						#rR = #fkc;
					}
					List<#mkc> list = new List<#mkc>();
					List<#mkc> list2;
					if (!false)
					{
						list2 = list;
					}
					IEnumerator<HatchBoundaryPath> enumerator = hatch2.BoundaryPaths.GetEnumerator();
					IEnumerator<HatchBoundaryPath> enumerator2;
					if (7 != 0)
					{
						enumerator2 = enumerator;
					}
					try
					{
						while (enumerator2.MoveNext())
						{
							HatchBoundaryPath hatchBoundaryPath = enumerator2.Current;
							IEnumerator<HatchBoundaryPath.Edge> enumerator3 = hatchBoundaryPath.Edges.GetEnumerator();
							IEnumerator<HatchBoundaryPath.Edge> enumerator4;
							if (-1 != 0)
							{
								enumerator4 = enumerator3;
							}
							try
							{
								while (enumerator4.MoveNext())
								{
									HatchBoundaryPath.Edge edge = enumerator4.Current;
									Line line = (Line)edge.ConvertTo();
									Line line2;
									if (6 != 0)
									{
										line2 = line;
									}
									list2.Add(new #mkc(line2.StartPoint.X + #70h.X, line2.StartPoint.Y + #70h.Y, line2.StartPoint.Z + #70h.Z, #rR));
									list2.Add(new #mkc(line2.EndPoint.X + #70h.X, line2.EndPoint.Y + #70h.Y, line2.EndPoint.Z + #70h.Z, #rR));
								}
							}
							finally
							{
								if (enumerator4 != null)
								{
									enumerator4.Dispose();
								}
							}
						}
					}
					finally
					{
						if (enumerator2 != null)
						{
							enumerator2.Dispose();
						}
					}
					item = new #ekc(list2, #rR);
				}
				#Od.Hatches.Add(item);
			}
			catch (InvalidCastException #Uic)
			{
				#yf.#Rjc(Strings.StringFailedToReadHatchEntity.#z2d(), new #Oic(Strings.StringTheDataExchangeRaisedAnException.#z2d(), #Phc.#3hc(107375323), Component.DataExchange, #IYd.#b, #JYd.#B, #Uic));
			}
			catch (Exception #Uic2)
			{
				#yf.#Rjc(Strings.StringFailedToReadHatchEntity.#z2d(), new #Oic(Strings.StringTheDataExchangeRaisedAnException.#z2d(), #Phc.#3hc(107375238), Component.DataExchange, #IYd.#a, #Uic2));
			}
		}

		// Token: 0x06003E1E RID: 15902 RVA: 0x0011E308 File Offset: 0x0011C508
		[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
		internal static void #d1h(EntityObject #8Y, #kkc #Od, #mkc #70h, #Tjc #yf)
		{
			try
			{
				Insert insert = (Insert)#8Y;
				Insert insert2;
				if (8 != 0)
				{
					insert2 = insert;
				}
				Vector3 position = insert2.Position;
				Vector3 vector;
				if (!false)
				{
					vector = position;
				}
				double #9o = vector.X + #70h.X;
				Vector3 position2 = insert2.Position;
				if (2 != 0)
				{
					vector = position2;
				}
				double #7W = vector.Y + #70h.Y;
				Vector3 position3 = insert2.Position;
				if (-1 != 0)
				{
					vector = position3;
				}
				#mkc #mkc = new #mkc(#9o, #7W, vector.Z + #70h.Z, new #fkc(string.Empty));
				#mkc #70h2;
				if (true)
				{
					#70h2 = #mkc;
				}
				IEnumerator<EntityObject> enumerator = insert2.Block.Entities.GetEnumerator();
				IEnumerator<EntityObject> enumerator2;
				if (!false)
				{
					enumerator2 = enumerator;
				}
				try
				{
					while (enumerator2.MoveNext())
					{
						EntityObject #8Y2 = enumerator2.Current;
						#y1h.#60h(#8Y2, #Od, #70h2, null, #yf);
					}
				}
				finally
				{
					if (enumerator2 != null)
					{
						enumerator2.Dispose();
					}
				}
			}
			catch (InvalidCastException #Uic)
			{
				#yf.#Rjc(Strings.StringFailedToReadInsertEntity.#z2d(), new #Oic(Strings.StringTheDataExchangeRaisedAnException.#z2d(), #Phc.#3hc(107375217), Component.DataExchange, #IYd.#b, #JYd.#B, #Uic));
			}
			catch (Exception #Uic2)
			{
				#yf.#Rjc(Strings.StringFailedToReadInsertEntity.#z2d(), new #Oic(Strings.StringTheDataExchangeRaisedAnException.#z2d(), #Phc.#3hc(107375164), Component.DataExchange, #IYd.#a, #Uic2));
			}
		}

		// Token: 0x06003E1F RID: 15903 RVA: 0x0011E474 File Offset: 0x0011C674
		[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
		internal static void #e1h(Layer #rR, #kkc #Od, #Tjc #yf)
		{
			try
			{
				#fkc #fkc2;
				if (!false)
				{
					#fkc #fkc = new #fkc(#rR.Name, new #3jc(#rR.Color.R, #rR.Color.G, #rR.Color.B));
					if (6 != 0)
					{
						#fkc2 = #fkc;
					}
				}
				List<#jjc> list = #Od.Layers;
				#jjc item = #fkc2;
				if (8 != 0)
				{
					list.Add(item);
				}
			}
			catch (InvalidCastException #Uic)
			{
				#yf.#Rjc(Strings.StringFailedToReadLayerEntity.#z2d(), new #Oic(Strings.StringTheDataExchangeRaisedAnException.#z2d(), #Phc.#3hc(107375323), Component.DataExchange, #IYd.#b, #JYd.#B, #Uic));
			}
			catch (Exception #Uic2)
			{
				#yf.#Rjc(Strings.StringFailedToReadLayerEntity.#z2d(), new #Oic(Strings.StringTheDataExchangeRaisedAnException.#z2d(), #Phc.#3hc(107375591), Component.DataExchange, #IYd.#a, #Uic2));
			}
		}

		// Token: 0x06003E20 RID: 15904 RVA: 0x0011E554 File Offset: 0x0011C754
		[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
		internal static void #f1h(EntityObject #8Y, #kkc #Od, #mkc #70h, #9jc #oue, #Tjc #yf)
		{
			try
			{
				Line line = (Line)#8Y;
				Line line2;
				if (5 != 0)
				{
					line2 = line;
				}
				#fkc #fkc = new #fkc(line2.Layer.Name, new #3jc(line2.Layer.Color.R, line2.Layer.Color.G, line2.Layer.Color.B));
				#fkc #rR;
				if (!false)
				{
					#rR = #fkc;
				}
				Vector3 startPoint = line2.StartPoint;
				Vector3 vector;
				if (!false)
				{
					vector = startPoint;
				}
				double #9o = vector.X + #70h.X;
				if (!false)
				{
					Vector3 startPoint2 = line2.StartPoint;
					if (true)
					{
						vector = startPoint2;
					}
				}
				double #7W = vector.Y + #70h.Y;
				Vector3 startPoint3 = line2.StartPoint;
				if (!false)
				{
					vector = startPoint3;
				}
				#mkc #Xrb = new #mkc(#9o, #7W, vector.Z + #70h.Z, #rR);
				Vector3 endPoint = line2.EndPoint;
				if (7 != 0)
				{
					vector = endPoint;
				}
				double #9o2 = vector.X + #70h.X;
				vector = line2.EndPoint;
				double #7W2 = vector.Y + #70h.Y;
				vector = line2.EndPoint;
				#gkc item = new #gkc(#Xrb, new #mkc(#9o2, #7W2, vector.Z + #70h.Z, #rR), #rR);
				if (#oue == null)
				{
					#Od.Lines.Add(item);
				}
				else
				{
					#oue.Lines.Add(item);
				}
			}
			catch (InvalidCastException #Uic)
			{
				#yf.#Rjc(Strings.StringFailedToReadLineEntity.#z2d(), new #Oic(Strings.StringTheDataExchangeRaisedAnException.#z2d(), #Phc.#3hc(107375570), Component.DataExchange, #IYd.#b, #JYd.#B, #Uic));
			}
			catch (Exception #Uic2)
			{
				#yf.#Rjc(Strings.StringFailedToReadLineEntity.#z2d(), new #Oic(Strings.StringTheDataExchangeRaisedAnException.#z2d(), #Phc.#3hc(107375517), Component.DataExchange, #IYd.#a, #Uic2));
			}
		}

		// Token: 0x06003E21 RID: 15905 RVA: 0x0011E74C File Offset: 0x0011C94C
		[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
		internal static void #8Vi(EntityObject #8Y, #kkc #Od, #mkc #70h, #Tjc #yf)
		{
			try
			{
				Polyline2D polyline2D = (Polyline2D)#8Y;
				Polyline2D polyline2D2;
				if (!false)
				{
					polyline2D2 = polyline2D;
				}
				#fkc #fkc = new #fkc(polyline2D2.Layer.Name, new #3jc(polyline2D2.Layer.Color.R, polyline2D2.Layer.Color.G, polyline2D2.Layer.Color.B));
				#fkc #fkc2;
				if (6 != 0)
				{
					#fkc2 = #fkc;
				}
				List<#Jkc> list = new List<#Jkc>();
				List<#Jkc> list2;
				if (!false)
				{
					list2 = list;
				}
				int num = 0;
				int i;
				if (!false)
				{
					i = num;
				}
				while (i < polyline2D2.Vertexes.Count)
				{
					Polyline2DVertex polyline2DVertex = polyline2D2.Vertexes[i];
					Polyline2DVertex polyline2DVertex2;
					if (!false)
					{
						polyline2DVertex2 = polyline2DVertex;
					}
					if (polyline2DVertex2 != null)
					{
						if (polyline2DVertex2.Bulge == 0.0)
						{
							List<#Jkc> list3 = list2;
							Vector2 position = polyline2DVertex2.Position;
							Vector2 vector;
							if (!false)
							{
								vector = position;
							}
							double #9o = vector.X + #70h.X;
							vector = polyline2DVertex2.Position;
							list3.Add(new #Jkc(new #mkc(#9o, vector.Y + #70h.Y, 0.0 + #70h.Z, #fkc2)));
						}
						else
						{
							List<#Jkc> list4 = list2;
							Vector2 vector = polyline2DVertex2.Position;
							double #9o2 = vector.X + #70h.X;
							vector = polyline2DVertex2.Position;
							list4.Add(new #Jkc(new #mkc(#9o2, vector.Y + #70h.Y, 0.0 + #70h.Z, #fkc2), #y1h.#o1h(polyline2D2.Vertexes[i], polyline2D2.Vertexes[i + 1], #fkc2)));
						}
					}
					i++;
				}
				#skc item = new #skc(list2, polyline2D2.IsClosed, #fkc2);
				#Od.Polylines.Add(item);
			}
			catch (InvalidCastException #Uic)
			{
				#yf.#Rjc(Strings.StringFailedToReadLighweightPolylineEntity.#z2d(), new #Oic(Strings.StringTheDataExchangeRaisedAnException.#z2d(), #Phc.#3hc(107375432), Component.DataExchange, #IYd.#b, #JYd.#B, #Uic));
			}
			catch (Exception #Uic2)
			{
				#yf.#Rjc(Strings.StringFailedToReadLighweightPolylineEntity.#z2d(), new #Oic(Strings.StringTheDataExchangeRaisedAnException.#z2d(), #Phc.#3hc(107375411), Component.DataExchange, #IYd.#a, #Uic2));
			}
		}

		// Token: 0x06003E22 RID: 15906 RVA: 0x0011E9BC File Offset: 0x0011CBBC
		[SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "multi")]
		[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
		internal static void #h1h(EntityObject #8Y, #kkc #Od, #mkc #70h, #9jc #oue, #Tjc #yf)
		{
			try
			{
				MText mtext = (MText)#8Y;
				MText mtext2;
				if (4 != 0)
				{
					mtext2 = mtext;
				}
				#lkc item;
				do
				{
					#fkc #fkc = new #fkc(mtext2.Layer.Name, new #3jc(mtext2.Layer.Color.R, mtext2.Layer.Color.G, mtext2.Layer.Color.B));
					#fkc #rR;
					if (!false)
					{
						#rR = #fkc;
					}
					string value = mtext2.Value;
					Vector3 position = mtext2.Position;
					Vector3 vector;
					if (5 != 0)
					{
						vector = position;
					}
					double #9o = vector.X + #70h.X;
					Vector3 position2 = mtext2.Position;
					if (-1 != 0)
					{
						vector = position2;
					}
					double #7W = vector.Y + #70h.Y;
					Vector3 position3 = mtext2.Position;
					if (!false)
					{
						vector = position3;
					}
					#lkc #lkc = new #lkc(value, new #mkc(#9o, #7W, vector.Z + #70h.Z, #rR), mtext2.Height, mtext2.Rotation, #rR);
					if (7 != 0)
					{
						item = #lkc;
					}
				}
				while (false);
				if (#oue == null)
				{
					#Od.MultiTexts.Add(item);
				}
				else
				{
					#oue.MultiTexts.Add(item);
				}
			}
			catch (InvalidCastException #Uic)
			{
				#yf.#Rjc(Strings.StringFailedToReadMultiTextEntity.#z2d(), new #Oic(Strings.StringTheDataExchangeRaisedAnException.#z2d(), #Phc.#3hc(107374846), Component.DataExchange, #IYd.#b, #JYd.#B, #Uic));
			}
			catch (Exception #Uic2)
			{
				#yf.#Rjc(Strings.StringFailedToReadMultiTextEntity.#z2d(), new #Oic(Strings.StringTheDataExchangeRaisedAnException.#z2d(), #Phc.#3hc(107374761), Component.DataExchange, #IYd.#a, #Uic2));
			}
		}

		// Token: 0x06003E23 RID: 15907 RVA: 0x0011EB78 File Offset: 0x0011CD78
		[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
		internal static void #i1h(EntityObject #8Y, #kkc #Od, #mkc #70h, #Tjc #yf)
		{
			try
			{
				Point point = (Point)#8Y;
				Point point2;
				if (!false)
				{
					point2 = point;
				}
				#fkc #fkc = new #fkc(point2.Layer.Name, new #3jc(point2.Layer.Color.R, point2.Layer.Color.G, point2.Layer.Color.B));
				#fkc #rR;
				if (-1 != 0)
				{
					#rR = #fkc;
				}
				Vector3 position = point2.Position;
				Vector3 vector;
				if (7 != 0)
				{
					vector = position;
				}
				double #9o = vector.X + #70h.X;
				Vector3 position2 = point2.Position;
				if (2 != 0)
				{
					vector = position2;
				}
				double #7W = vector.Y + #70h.Y;
				Vector3 position3 = point2.Position;
				if (!false)
				{
					vector = position3;
				}
				#mkc #mkc = new #mkc(#9o, #7W, vector.Z + #70h.Z, #rR);
				#mkc item;
				if (7 != 0)
				{
					item = #mkc;
				}
				#Od.Points.Add(item);
			}
			catch (InvalidCastException #Uic)
			{
				#yf.#Rjc(Strings.StringFailedToReadPointEntity.#z2d(), new #Oic(Strings.StringTheDataExchangeRaisedAnException.#z2d(), #Phc.#3hc(107374740), Component.DataExchange, #IYd.#b, #JYd.#B, #Uic));
			}
			catch (Exception #Uic2)
			{
				#yf.#Rjc(Strings.StringFailedToReadPointEntity.#z2d(), new #Oic(Strings.StringTheDataExchangeRaisedAnException.#z2d(), #Phc.#3hc(107374687), Component.DataExchange, #IYd.#a, #Uic2));
			}
		}

		// Token: 0x06003E24 RID: 15908 RVA: 0x0011ECD8 File Offset: 0x0011CED8
		[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
		internal static void #9Vi(EntityObject #8Y, #kkc #Od, #mkc #70h, #Tjc #yf)
		{
			try
			{
				Polyline3D polyline3D = (Polyline3D)#8Y;
				Polyline3D polyline3D2;
				if (8 != 0)
				{
					polyline3D2 = polyline3D;
				}
				#fkc #fkc = new #fkc(polyline3D2.Layer.Name, new #3jc(polyline3D2.Layer.Color.R, polyline3D2.Layer.Color.G, polyline3D2.Layer.Color.B));
				#fkc #rR;
				if (!false)
				{
					#rR = #fkc;
				}
				List<#Jkc> list = new List<#Jkc>();
				List<#Jkc> list2;
				if (true)
				{
					list2 = list;
				}
				int num = 0;
				int i;
				if (!false)
				{
					i = num;
				}
				while (i < polyline3D2.Vertexes.Count)
				{
					Vector3 vector = polyline3D2.Vertexes[i];
					Vector3 vector2;
					if (4 != 0)
					{
						vector2 = vector;
					}
					List<#Jkc> list3 = list2;
					#Jkc item = new #Jkc(new #mkc(vector2.X + #70h.X, vector2.Y + #70h.Y, 0.0 + #70h.Z, #rR));
					if (!false)
					{
						list3.Add(item);
					}
					i++;
				}
				#skc item2 = new #skc(list2, polyline3D2.IsClosed, #rR);
				#Od.Polylines.Add(item2);
			}
			catch (InvalidCastException #Uic)
			{
				#yf.#Rjc(Strings.StringFailedToReadPolylineEntity.#z2d(), new #Oic(Strings.StringTheDataExchangeRaisedAnException.#z2d(), #Phc.#3hc(107374602), Component.DataExchange, #IYd.#b, #JYd.#B, #Uic));
			}
			catch (Exception #Uic2)
			{
				#yf.#Rjc(Strings.StringFailedToReadPolylineEntity.#z2d(), new #Oic(Strings.StringTheDataExchangeRaisedAnException.#z2d(), #Phc.#3hc(107375093), Component.DataExchange, #IYd.#a, #Uic2));
			}
		}

		// Token: 0x06003E25 RID: 15909 RVA: 0x0011EEA0 File Offset: 0x0011D0A0
		[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
		internal static void #k1h(EntityObject #8Y, #kkc #Od, #mkc #70h, #9jc #oue, #Tjc #yf)
		{
			try
			{
				#Bkc item;
				if (!false)
				{
					Solid solid = (Solid)#8Y;
					Solid solid2;
					if (!false)
					{
						solid2 = solid;
					}
					#fkc #fkc = new #fkc(solid2.Layer.Name, new #3jc(solid2.Layer.Color.R, solid2.Layer.Color.G, solid2.Layer.Color.B));
					#fkc #rR;
					if (5 != 0)
					{
						#rR = #fkc;
					}
					if (-1 == 0)
					{
						goto IL_1A1;
					}
					Vector2 firstVertex = solid2.FirstVertex;
					Vector2 vector;
					if (7 != 0)
					{
						vector = firstVertex;
					}
					double #9o = vector.X + #70h.X;
					Vector2 firstVertex2 = solid2.FirstVertex;
					if (!false)
					{
						vector = firstVertex2;
					}
					#mkc #mcb = new #mkc(#9o, vector.Y + #70h.Y, 0.0 + #70h.Z, #rR);
					Vector2 secondVertex = solid2.SecondVertex;
					if (!false)
					{
						vector = secondVertex;
					}
					double #9o2 = vector.X + #70h.X;
					Vector2 secondVertex2 = solid2.SecondVertex;
					if (!false)
					{
						vector = secondVertex2;
					}
					#mkc #ncb = new #mkc(#9o2, vector.Y + #70h.Y, 0.0 + #70h.Z, #rR);
					vector = solid2.ThirdVertex;
					double #9o3 = vector.X + #70h.X;
					vector = solid2.ThirdVertex;
					#mkc #Ckc = new #mkc(#9o3, vector.Y + #70h.Y, 0.0 + #70h.Z, #rR);
					vector = solid2.FourthVertex;
					double #9o4 = vector.X + #70h.X;
					vector = solid2.FourthVertex;
					item = new #Bkc(#mcb, #ncb, #Ckc, new #mkc(#9o4, vector.Y + #70h.Y, 0.0 + #70h.Z, #rR), #rR);
				}
				if (#oue == null)
				{
					#Od.Solids.Add(item);
				}
				else
				{
					#oue.Solids.Add(item);
				}
				IL_1A1:;
			}
			catch (InvalidCastException #Uic)
			{
				#yf.#Rjc(Strings.StringFailedToReadSolidEntity.#z2d(), new #Oic(Strings.StringTheDataExchangeRaisedAnException.#z2d(), #Phc.#3hc(107375008), Component.DataExchange, #IYd.#b, #JYd.#B, #Uic));
			}
			catch (Exception #Uic2)
			{
				#yf.#Rjc(Strings.StringFailedToReadSolidEntity.#z2d(), new #Oic(Strings.StringTheDataExchangeRaisedAnException.#z2d(), #Phc.#3hc(107374955), Component.DataExchange, #IYd.#a, #Uic2));
			}
		}

		// Token: 0x06003E26 RID: 15910 RVA: 0x0011F118 File Offset: 0x0011D318
		[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
		internal static void #l1h(EntityObject #8Y, #kkc #Od, #mkc #70h, #Tjc #yf)
		{
			try
			{
				Text text = (Text)#8Y;
				Text text2;
				if (!false)
				{
					text2 = text;
				}
				#fkc #fkc = new #fkc(text2.Layer.Name, new #3jc(text2.Layer.Color.R, text2.Layer.Color.G, text2.Layer.Color.B));
				#fkc #rR;
				if (true)
				{
					#rR = #fkc;
				}
				string value = text2.Value;
				Vector3 position = text2.Position;
				Vector3 vector;
				if (!false)
				{
					vector = position;
				}
				double #9o = vector.X + #70h.X;
				Vector3 position2 = text2.Position;
				if (7 != 0)
				{
					vector = position2;
				}
				double #7W = vector.Y + #70h.Y;
				Vector3 position3 = text2.Position;
				if (-1 != 0)
				{
					vector = position3;
				}
				#Ikc #Ikc = new #Ikc(value, new #mkc(#9o, #7W, vector.Z + #70h.Z, #rR), string.IsNullOrWhiteSpace(text2.Style.FontFamilyName) ? text2.Style.Name : text2.Style.FontFamilyName, text2.Height, text2.Rotation, #rR);
				#Ikc item;
				if (3 != 0)
				{
					item = #Ikc;
				}
				#Od.Texts.Add(item);
			}
			catch (InvalidCastException #Uic)
			{
				#yf.#Rjc(Strings.StringFailedToReadTextEntity.#z2d(), new #Oic(Strings.StringTheDataExchangeRaisedAnException.#z2d(), #Phc.#3hc(107374934), Component.DataExchange, #IYd.#b, #JYd.#B, #Uic));
			}
			catch (Exception #Uic2)
			{
				#yf.#Rjc(Strings.StringFailedToReadTextEntity.#z2d(), new #Oic(Strings.StringTheDataExchangeRaisedAnException.#z2d(), #Phc.#3hc(107374849), Component.DataExchange, #IYd.#a, #Uic2));
			}
		}

		// Token: 0x06003E27 RID: 15911 RVA: 0x0003509A File Offset: 0x0003329A
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

		// Token: 0x06003E28 RID: 15912 RVA: 0x0011F2E8 File Offset: 0x0011D4E8
		[SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
		private static List<EntityObject> #m1h(DxfDocument #bFd)
		{
			return Enumerable.Empty<EntityObject>().Union(#bFd.Entities.Arcs).Union(#bFd.Entities.Circles).Union(#bFd.Entities.Dimensions).Union(#bFd.Entities.Ellipses).Union(#bFd.Entities.Hatches).Union(#bFd.Entities.Inserts).Union(#bFd.Entities.Lines).Union(#bFd.Entities.Polylines2D).Union(#bFd.Entities.MTexts).Union(#bFd.Entities.Points).Union(#bFd.Entities.Polylines3D).Union(#bFd.Entities.Solids).Union(#bFd.Entities.Texts).ToList<EntityObject>();
		}

		// Token: 0x06003E29 RID: 15913 RVA: 0x0011F3D0 File Offset: 0x0011D5D0
		private static #Ujc #o1h(Polyline2DVertex #p1h, Polyline2DVertex #q1h, #fkc #r1h)
		{
			if (#p1h == null || #q1h == null || #r1h == null)
			{
				return null;
			}
			Vector2 position = #p1h.Position;
			Vector2 vector;
			if (7 != 0)
			{
				vector = position;
			}
			double x = vector.X;
			Vector2 position2 = #q1h.Position;
			if (!false)
			{
				vector = position2;
			}
			double num2;
			double num = num2 = x + vector.X;
			double num4;
			double num3 = num4 = 2.0;
			#mkc #mkc;
			double num18;
			double num19;
			double num27;
			if (3 != 0)
			{
				double num5 = num / num3;
				double num6;
				if (!false)
				{
					num6 = num5;
				}
				Vector2 position3 = #p1h.Position;
				if (!false)
				{
					vector = position3;
				}
				double y = vector.Y;
				Vector2 position4 = #q1h.Position;
				if (5 != 0)
				{
					vector = position4;
				}
				double num7 = y + vector.Y;
				double num8 = 2.0;
				double num13;
				double num16;
				double num17;
				double x3;
				do
				{
					double num9 = num7 / num8;
					double num10;
					if (!false)
					{
						num10 = num9;
					}
					if (3 == 0)
					{
						goto IL_255;
					}
					vector = #q1h.Position;
					double x2 = vector.X;
					vector = #q1h.Position;
					double y2 = vector.Y;
					if (Math.Abs(num10 - y2) > Math.Abs(num6 - x2))
					{
						vector = #p1h.Position;
						x2 = vector.X;
						vector = #p1h.Position;
						y2 = vector.Y;
					}
					double num11 = (num10 - y2) * #p1h.Bulge;
					double num12 = num13 = num6;
					if (false)
					{
						goto IL_26D;
					}
					double num14 = (num12 - x2) * #p1h.Bulge;
					#mkc = new #mkc(num6 + num11, num10 + num14, 0.0, #r1h);
					vector = #q1h.Position;
					double num15 = Math.Pow(vector.X, 2.0);
					vector = #q1h.Position;
					num16 = num15 + Math.Pow(vector.Y, 2.0);
					if (false)
					{
						goto IL_1E9;
					}
					vector = #p1h.Position;
					num17 = (num7 = Math.Pow(vector.X, 2.0));
					vector = #p1h.Position;
					x3 = (num8 = vector.Y);
				}
				while (4 == 0);
				num18 = (num17 + Math.Pow(x3, 2.0) - num16) / 2.0;
				num19 = (num16 - Math.Pow(#mkc.X, 2.0) - Math.Pow(#mkc.Y, 2.0)) / 2.0;
				vector = #p1h.Position;
				IL_1E9:
				double x4 = vector.X;
				vector = #q1h.Position;
				double num21;
				double num20 = num21 = x4 - vector.X;
				vector = #q1h.Position;
				double num23;
				double num22 = num23 = vector.Y;
				double num25;
				double num24 = num25 = #mkc.Y;
				if (!false)
				{
					num21 = num20 * (num22 - num24);
					vector = #q1h.Position;
					num23 = vector.X - #mkc.X;
					vector = #p1h.Position;
					num25 = vector.Y;
					vector = #q1h.Position;
				}
				double num26 = num21 - num23 * (num25 - vector.Y);
				IL_255:
				if (num26 == 0.0)
				{
					return null;
				}
				num13 = 1.0;
				IL_26D:
				num27 = num13 / num26;
				double num28 = num18;
				vector = #q1h.Position;
				double num29 = num28 * (vector.Y - #mkc.Y);
				double num30 = num19;
				vector = #p1h.Position;
				double y3 = vector.Y;
				vector = #q1h.Position;
				num2 = num29 - num30 * (y3 - vector.Y);
				num4 = num27;
			}
			double num31 = num2 * num4;
			double num32 = num19;
			vector = #p1h.Position;
			double x5 = vector.X;
			vector = #q1h.Position;
			double num33 = num32 * (x5 - vector.X);
			double num34 = num18;
			vector = #q1h.Position;
			double num35 = (num33 - num34 * (vector.X - #mkc.X)) * num27;
			vector = #q1h.Position;
			double num36 = Math.Pow(vector.X - num31, 2.0);
			vector = #q1h.Position;
			double #HS = Math.Sqrt(num36 + Math.Pow(vector.Y - num35, 2.0));
			#mkc #Wjc = new #mkc(num31, num35, 0.0, #r1h);
			double #t1h = num31;
			double #u1h = num35;
			vector = #p1h.Position;
			double x6 = vector.X;
			vector = #p1h.Position;
			double #Xjc = #y1h.#s1h(#t1h, #u1h, x6, vector.Y) * 180.0 / 3.141592653589793;
			double #t1h2 = num31;
			double #u1h2 = num35;
			vector = #q1h.Position;
			double x7 = vector.X;
			vector = #q1h.Position;
			double #Yjc = #y1h.#s1h(#t1h2, #u1h2, x7, vector.Y) * 180.0 / 3.141592653589793;
			if (#p1h.Bulge > 0.0)
			{
				#Xjc = #y1h.#x1h(#Xjc, #Yjc);
			}
			return new #Ujc(#Wjc, #HS, #Xjc, #Yjc, #r1h);
		}

		// Token: 0x06003E2A RID: 15914 RVA: 0x000350B6 File Offset: 0x000332B6
		private static double #s1h(double #t1h, double #u1h, double #v1h, double #w1h)
		{
			return Math.Atan2(#w1h - #u1h, #v1h - #t1h);
		}

		// Token: 0x06003E2B RID: 15915 RVA: 0x000350C3 File Offset: 0x000332C3
		private static double #x1h(double #Xjc, double #Yjc)
		{
			while (#Xjc > #Yjc)
			{
				double num = #Xjc - 360.0;
				if (!false)
				{
					#Xjc = num;
				}
			}
			return #Xjc;
		}

		// Token: 0x06003E2C RID: 15916 RVA: 0x0011F7F8 File Offset: 0x0011D9F8
		protected void #o7d()
		{
			try
			{
				bool #POb = false;
				if (!false)
				{
					this.#1(#POb);
				}
			}
			finally
			{
				base.Finalize();
			}
		}

		// Token: 0x04001C31 RID: 7217
		private Stream #a;

		// Token: 0x04001C32 RID: 7218
		private readonly List<DxfVersion> #b = new List<DxfVersion>
		{
			DxfVersion.AutoCad2000,
			DxfVersion.AutoCad2004,
			DxfVersion.AutoCad2007,
			DxfVersion.AutoCad2010,
			DxfVersion.AutoCad2013,
			DxfVersion.AutoCad2018
		};
	}
}
