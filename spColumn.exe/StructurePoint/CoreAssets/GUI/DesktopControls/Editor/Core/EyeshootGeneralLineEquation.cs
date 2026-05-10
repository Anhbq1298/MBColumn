using System;
using System.Diagnostics;
using #7hc;
using #Fmc;
using devDept.Geometry;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.Geometry.Misc;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core
{
	// Token: 0x02000AEE RID: 2798
	[DebuggerDisplay("{CoefficientA}*x + {CoefficientB}*y + {CoefficientC}")]
	public sealed class EyeshootGeneralLineEquation
	{
		// Token: 0x06005B4D RID: 23373 RVA: 0x0004C67D File Offset: 0x0004A87D
		public EyeshootGeneralLineEquation(double coefficientA, double coefficientB, double coefficientC)
		{
			this.CoefficientA = coefficientA;
			this.CoefficientB = coefficientB;
			this.CoefficientC = coefficientC;
			this.MyCreateCache();
		}

		// Token: 0x06005B4E RID: 23374 RVA: 0x0016F788 File Offset: 0x0016D988
		public EyeshootGeneralLineEquation(Point2D point1, Point2D point2)
		{
			this.CoefficientA = point1.Y - point2.Y;
			this.CoefficientB = point2.X - point1.X;
			this.CoefficientC = (point1.X - point2.X) * point1.Y + (point2.Y - point1.Y) * point1.X;
			this.MyCreateCache();
		}

		// Token: 0x06005B4F RID: 23375 RVA: 0x0016F7F8 File Offset: 0x0016D9F8
		public EyeshootGeneralLineEquation(Point2D location, double angle, bool roundZero)
		{
			double num = Math.Tan(GeometryHelper.#Qmc(angle));
			if (roundZero && #Emc.#Bmc(num))
			{
				num = 0.0;
			}
			double num2 = num;
			double num3 = -num * location.X + location.Y;
			this.CoefficientA = -num2;
			this.CoefficientB = 1.0;
			this.CoefficientC = -num3;
			this.MyCreateCache();
		}

		// Token: 0x17001A1B RID: 6683
		// (get) Token: 0x06005B50 RID: 23376 RVA: 0x0004C6A0 File Offset: 0x0004A8A0
		public double CoefficientA { get; }

		// Token: 0x17001A1C RID: 6684
		// (get) Token: 0x06005B51 RID: 23377 RVA: 0x0004C6A8 File Offset: 0x0004A8A8
		public double CoefficientB { get; }

		// Token: 0x17001A1D RID: 6685
		// (get) Token: 0x06005B52 RID: 23378 RVA: 0x0004C6B0 File Offset: 0x0004A8B0
		public double CoefficientC { get; }

		// Token: 0x17001A1E RID: 6686
		// (get) Token: 0x06005B53 RID: 23379 RVA: 0x0004C6B8 File Offset: 0x0004A8B8
		// (set) Token: 0x06005B54 RID: 23380 RVA: 0x0004C6C0 File Offset: 0x0004A8C0
		public double Tangent { get; private set; }

		// Token: 0x17001A1F RID: 6687
		// (get) Token: 0x06005B55 RID: 23381 RVA: 0x0004C6C9 File Offset: 0x0004A8C9
		public static EyeshootGeneralLineEquation XAxis { get; } = new EyeshootGeneralLineEquation(new Point2D(), 0.0, false);

		// Token: 0x17001A20 RID: 6688
		// (get) Token: 0x06005B56 RID: 23382 RVA: 0x0004C6D0 File Offset: 0x0004A8D0
		public static EyeshootGeneralLineEquation YAxis { get; } = new EyeshootGeneralLineEquation(new Point2D(), new Point2D(0.0, 1.0));

		// Token: 0x06005B57 RID: 23383 RVA: 0x0004C6D7 File Offset: 0x0004A8D7
		public double CalculateX(double yValue)
		{
			return -(this.CoefficientB * yValue + this.CoefficientC) / this.CoefficientA;
		}

		// Token: 0x06005B58 RID: 23384 RVA: 0x0004C6F0 File Offset: 0x0004A8F0
		public double CalculateY(double xValue)
		{
			return -(this.CoefficientA * xValue + this.CoefficientC) / this.CoefficientB;
		}

		// Token: 0x06005B59 RID: 23385 RVA: 0x0016F864 File Offset: 0x0016DA64
		public Point3D CalculateY2(double x)
		{
			double y = this.CalculateY(x);
			return new Point3D(x, y);
		}

		// Token: 0x06005B5A RID: 23386 RVA: 0x0016F880 File Offset: 0x0016DA80
		public Point2D Intersection(EyeshootGeneralLineEquation generalLineEquation)
		{
			if (generalLineEquation == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107422039));
			}
			double coefficientA = this.CoefficientA;
			double coefficientB = this.CoefficientB;
			double coefficientC = this.CoefficientC;
			double coefficientA2 = generalLineEquation.CoefficientA;
			double coefficientB2 = generalLineEquation.CoefficientB;
			double coefficientC2 = generalLineEquation.CoefficientC;
			double num = coefficientA * coefficientB2 - coefficientA2 * coefficientB;
			if (#Emc.#U3(num))
			{
				return null;
			}
			double num2 = -coefficientC * coefficientB2 - -coefficientC2 * coefficientB;
			double num3 = coefficientA * -coefficientC2 - coefficientA2 * -coefficientC;
			return new Point2D(num2 / num, num3 / num);
		}

		// Token: 0x06005B5B RID: 23387 RVA: 0x0016F908 File Offset: 0x0016DB08
		public EyeshootGeneralLineEquation Normal(Point2D point)
		{
			double num = -this.CoefficientB;
			double coefficientA = this.CoefficientA;
			double coefficientC = -(num * point.X + coefficientA * point.Y);
			return new EyeshootGeneralLineEquation(num, coefficientA, coefficientC);
		}

		// Token: 0x06005B5C RID: 23388 RVA: 0x0016F940 File Offset: 0x0016DB40
		public bool IsParallelTo(GeneralLineEquation other, bool roughComparison)
		{
			if (other == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107399401));
			}
			double #4gb = this.CoefficientA * other.CoefficientB;
			double #5gb = other.CoefficientA * this.CoefficientB;
			if (!roughComparison)
			{
				return #Emc.#zmc(#4gb, #5gb);
			}
			return #Emc.#Amc(#4gb, #5gb);
		}

		// Token: 0x06005B5D RID: 23389 RVA: 0x0004C709 File Offset: 0x0004A909
		public double Distance(Point2D point)
		{
			return Math.Abs(this.CoefficientA * point.X + this.CoefficientB * point.Y + this.CoefficientC) / this.squaredAB;
		}

		// Token: 0x06005B5E RID: 23390 RVA: 0x0004C739 File Offset: 0x0004A939
		public Vector2D NormalVector()
		{
			Vector2D vector2D = new Vector2D(this.CoefficientA, this.CoefficientB);
			vector2D.Normalize();
			return vector2D;
		}

		// Token: 0x06005B5F RID: 23391 RVA: 0x0016F990 File Offset: 0x0016DB90
		public bool IsCollinear(Point2D point, bool roughComparison)
		{
			double #4gb = this.CalculateY(point.X);
			if (!roughComparison)
			{
				return #Emc.#zmc(#4gb, point.Y);
			}
			return #Emc.#Amc(#4gb, point.Y);
		}

		// Token: 0x06005B60 RID: 23392 RVA: 0x0004C753 File Offset: 0x0004A953
		private void MyCreateCache()
		{
			this.squaredAB = Math.Sqrt(this.CoefficientA * this.CoefficientA + this.CoefficientB * this.CoefficientB);
			this.Tangent = this.CoefficientA / this.CoefficientB;
		}

		// Token: 0x040025F8 RID: 9720
		private double squaredAB;
	}
}
