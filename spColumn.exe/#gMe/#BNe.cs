using System;
using System.Linq;
using #hZe;
using #wUe;
using #y6e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Input;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.Geometry;

namespace #gMe
{
	// Token: 0x0200129F RID: 4767
	internal sealed class #BNe
	{
		// Token: 0x06009FB5 RID: 40885 RVA: 0x0007D808 File Offset: 0x0007BA08
		public #BNe(InputModel #hMe, RuntimeModel #iMe)
		{
			this.#a = #hMe;
			this.#b = #iMe;
		}

		// Token: 0x17002DF9 RID: 11769
		// (get) Token: 0x06009FB6 RID: 40886 RVA: 0x0007D81E File Offset: 0x0007BA1E
		private #G6e SectionType
		{
			get
			{
				return this.#a.Options.SectionType;
			}
		}

		// Token: 0x17002DFA RID: 11770
		// (get) Token: 0x06009FB7 RID: 40887 RVA: 0x0007D830 File Offset: 0x0007BA30
		private Figures Solids
		{
			get
			{
				return this.#b.Solids;
			}
		}

		// Token: 0x17002DFB RID: 11771
		// (get) Token: 0x06009FB8 RID: 40888 RVA: 0x0007D83D File Offset: 0x0007BA3D
		private Figures Openings
		{
			get
			{
				return this.#b.Openings;
			}
		}

		// Token: 0x17002DFC RID: 11772
		// (get) Token: 0x06009FB9 RID: 40889 RVA: 0x0007D84A File Offset: 0x0007BA4A
		private float[] SectionDimensions
		{
			get
			{
				return this.#b.SectionDimensionsForInvestigate;
			}
		}

		// Token: 0x17002DFD RID: 11773
		// (get) Token: 0x06009FBA RID: 40890 RVA: 0x0007D857 File Offset: 0x0007BA57
		private #x0e GeometryProperties
		{
			get
			{
				return this.#b.GeometryProperties;
			}
		}

		// Token: 0x06009FBB RID: 40891 RVA: 0x0007D864 File Offset: 0x0007BA64
		public void #bpb(#G6e #jce)
		{
			if (#jce == #G6e.#b)
			{
				this.SectionDimensions[1] = 0f;
			}
			else if (#jce == #G6e.#a)
			{
				this.#ANe();
			}
			this.#bpb();
		}

		// Token: 0x06009FBC RID: 40892 RVA: 0x0021E3E0 File Offset: 0x0021C5E0
		public void #bpb()
		{
			this.GeometryProperties.Ag = 0f;
			bool flag = #xke.#dke(this.SectionDimensions[0]);
			bool flag2 = #xke.#dke(this.SectionDimensions[1]);
			if (this.SectionType == #G6e.#a && flag && flag2)
			{
				this.GeometryProperties.#t0e();
				#BNe.#vNe(this.GeometryProperties, this.SectionDimensions);
			}
			else if (this.SectionType == #G6e.#b && flag)
			{
				this.GeometryProperties.#t0e();
				#BNe.#wNe(this.GeometryProperties, this.SectionDimensions);
			}
			else if (this.Solids.#X2e())
			{
				#BNe.#xNe(this.GeometryProperties, this.Solids, this.Openings);
			}
			if (this.GeometryProperties.Ag > 0f)
			{
				this.GeometryProperties.#zPe();
			}
		}

		// Token: 0x06009FBD RID: 40893 RVA: 0x0021E4B4 File Offset: 0x0021C6B4
		private static void #vNe(#x0e #Nwb, float[] #Q6)
		{
			#Nwb.Ag = #Q6[0] * #Q6[1];
			#Nwb.SecondMomentOfInertia[0] = #Q6[0] * #Q6[1] * #Q6[1] * #Q6[1] / 12f;
			#Nwb.SecondMomentOfInertia[1] = #Q6[1] * #Q6[0] * #Q6[0] * #Q6[0] / 12f;
		}

		// Token: 0x06009FBE RID: 40894 RVA: 0x0021E508 File Offset: 0x0021C708
		private static void #wNe(#x0e #Nwb, float[] #Q6)
		{
			#Nwb.Ag = 0.7853982f * #Q6[0] * #Q6[0];
			#Nwb.SecondMomentOfInertia[0] = 3.1415927f * #Q6[0] * #Q6[0] * #Q6[0] * #Q6[0] / 64f;
			#Nwb.SecondMomentOfInertia[1] = #Nwb.SecondMomentOfInertia[0];
		}

		// Token: 0x06009FBF RID: 40895 RVA: 0x0021E55C File Offset: 0x0021C75C
		private static void #xNe(#x0e #yNe, Figures #BAb, Figures #CAb)
		{
			#yNe.#t0e();
			for (int i = 0; i < #BAb.SectionFigures.Count; i++)
			{
				Points points = #BAb.SectionFigures[i];
				if (!points.IsEmpty)
				{
					#x0e #u0e = #BNe.#czb(points);
					#yNe.#vzc(#u0e);
				}
			}
			for (int j = 0; j < #CAb.SectionFigures.Count; j++)
			{
				Points points2 = #CAb.SectionFigures[j];
				if (!points2.IsEmpty)
				{
					#x0e #w0e = #BNe.#czb(points2);
					#yNe.#v0e(#w0e);
				}
			}
		}

		// Token: 0x06009FC0 RID: 40896 RVA: 0x0021E5E8 File Offset: 0x0021C7E8
		private static #x0e #czb(Points #BP)
		{
			bool flag = #BP.InitialPoints[#BP.NumberOfPoints - 1].X != #BP.InitialPoints[0].X;
			bool flag2 = #BP.InitialPoints[#BP.NumberOfPoints - 1].Y != #BP.InitialPoints[0].Y;
			if (flag || flag2)
			{
				#BP.InitialPoints[#BP.NumberOfPoints] = new Point(#BP.InitialPoints[0].X, #BP.InitialPoints[0].Y);
				int num = #BP.NumberOfPoints;
				#BP.NumberOfPoints = num + 1;
			}
			return #BNe.#czb(#BP.InitialPoints, #BP.TransformedPoints, #BP.NumberOfPoints);
		}

		// Token: 0x06009FC1 RID: 40897 RVA: 0x0021E6B8 File Offset: 0x0021C8B8
		private static #x0e #czb(Point[] #BP, Point[] #zNe, int #kNe)
		{
			#x0e #x0e = new #x0e();
			float[] array = #x0e.Ybar;
			float[] array2 = #x0e.SecondMomentOfInertia;
			for (int i = 0; i < #kNe - 1; i++)
			{
				Point point = #BP[i];
				Point point2 = #zNe[i];
				Point point3 = #BP[i + 1];
				Point point4 = #zNe[i + 1];
				#x0e.Ag += #JNe.#CNe(point.X, point.Y, point3.X, point3.Y);
				array[0] += #JNe.#INe(point.Y, point.X, point3.Y, point3.X);
				array[1] += #JNe.#INe(point.X, point.Y, point3.X, point3.Y);
				array[2] += #JNe.#INe(point2.X, point2.Y, point4.X, point4.Y);
				array2[0] -= #JNe.#HNe(point.Y, point.X, point3.Y, point3.X);
				array2[1] += #JNe.#HNe(point.X, point.Y, point3.X, point3.Y);
			}
			if (#xke.#U3(#x0e.Ag))
			{
				#x0e.Ybar[0] = 0f;
				#x0e.Ybar[1] = 0f;
				#x0e.Ybar[2] = 0f;
			}
			else
			{
				#x0e.Ybar[0] = #x0e.Ybar[0] / #x0e.Ag;
				#x0e.Ybar[1] = -#x0e.Ybar[1] / #x0e.Ag;
				#x0e.Ybar[2] = -#x0e.Ybar[2] / #x0e.Ag;
			}
			#x0e.SecondMomentOfInertia[0] -= #x0e.Ag * #x0e.Ybar[1] * #x0e.Ybar[1];
			#x0e.SecondMomentOfInertia[1] -= #x0e.Ag * #x0e.Ybar[0] * #x0e.Ybar[0];
			#x0e.Ag = #xke.#hke(#x0e.Ag);
			#x0e.SecondMomentOfInertia[0] = #xke.#hke(#x0e.SecondMomentOfInertia[0]);
			#x0e.SecondMomentOfInertia[1] = #xke.#hke(#x0e.SecondMomentOfInertia[1]);
			return #x0e;
		}

		// Token: 0x06009FC2 RID: 40898 RVA: 0x0021E928 File Offset: 0x0021CB28
		private void #ANe()
		{
			Points points = this.Solids.SectionFigures.First<Points>();
			Point[] array = points.InitialPoints;
			array[0] = new Point(-this.SectionDimensions[0] / 2f, -this.SectionDimensions[1] / 2f);
			array[1] = new Point(-array[0].X, array[0].Y);
			array[2] = new Point(array[1].X, -array[1].Y);
			array[3] = new Point(-array[2].X, array[2].Y);
			array[4] = new Point(array[0].X, array[0].Y);
			points.NumberOfPoints = 5;
			this.Openings.#yl();
		}

		// Token: 0x040045B9 RID: 17849
		private readonly InputModel #a;

		// Token: 0x040045BA RID: 17850
		private readonly RuntimeModel #b;
	}
}
