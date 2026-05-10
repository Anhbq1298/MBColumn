using System;
using System.Globalization;
using System.IO;
using System.Text;
using #7hc;
using #Gke;
using StructurePoint.CoreAssets.AppManager.Column.Storage.Legacy;
using StructurePoint.CoreAssets.AppManager.Column.Storage.Legacy.Entities;

namespace #wje
{
	// Token: 0x020010B2 RID: 4274
	internal sealed class #Kje
	{
		// Token: 0x060091DB RID: 37339 RVA: 0x000755C0 File Offset: 0x000737C0
		public #Kje(#cke #AQ)
		{
			if (#AQ == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107378398));
			}
			this.#a = #AQ;
		}

		// Token: 0x060091DC RID: 37340 RVA: 0x000755E2 File Offset: 0x000737E2
		public #Kje() : this(new DefaultColFormatReaderConfiguration())
		{
		}

		// Token: 0x060091DD RID: 37341 RVA: 0x001EDA04 File Offset: 0x001EBC04
		public int #Cjc(Stream #gp, out #Hle #Od)
		{
			#Od = new #Hle();
			string text = string.Empty;
			string empty = string.Empty;
			float[] array = new float[6];
			#Od.EditFlag = 6;
			text = #Phc.#3hc(107290792);
			if (!#gp.#IAc(text.Length, ref empty))
			{
				return 7;
			}
			if (!string.Equals(empty, text))
			{
				return 6;
			}
			if (!#gp.#IAc(6, ref empty))
			{
				return 7;
			}
			float num = float.Parse(empty.#Ake(), CultureInfo.InvariantCulture);
			#Od.FileVersion = num;
			if (num < 2.099f && !#gp.#IAc(260, ref empty))
			{
				return 7;
			}
			Encoding @default = Encoding.Default;
			if (num < 3f)
			{
				if (!#gp.#IAc(24, @default, ref empty))
				{
					return 7;
				}
				#Od.Project = empty.#Ake();
				if (!#gp.#IAc(24, @default, ref empty))
				{
					return 7;
				}
				#Od.ColumnId = empty.#Ake();
				if (!#gp.#IAc(24, @default, ref empty))
				{
					return 7;
				}
				#Od.Engineer = empty.#Ake();
				if (!#gp.#IAc(9, ref empty))
				{
					return 7;
				}
				if (!#gp.#IAc(9, ref empty))
				{
					return 7;
				}
			}
			else
			{
				if (!#gp.#Eke(31, @default, ref empty))
				{
					return 7;
				}
				#Od.Project = empty;
				if (!#gp.#Eke(13, @default, ref empty))
				{
					return 7;
				}
				#Od.ColumnId = empty;
				if (!#gp.#Eke(7, @default, ref empty))
				{
					return 7;
				}
				#Od.Engineer = empty;
			}
			short num2;
			if (!#gp.#Cke(out num2, 0))
			{
				return 7;
			}
			#Od.InvInputFlag = num2;
			if (!#gp.#Cke(out num2, 0))
			{
				return 7;
			}
			#Od.DesInputFlag = num2;
			if (!#gp.#Cke(out num2, 0))
			{
				return 7;
			}
			#Od.SldInputFlag = num2;
			#Ole #Ole = default(#Ole);
			if (num < 2.099f)
			{
				if (!#gp.#Cke(out #Ole, 8))
				{
					return 7;
				}
				#Ole.#yu();
				#Ole.#v[0] = 1;
				#Ole.#v[1] = 1;
				#Ole.#x = 0;
			}
			else if (num < 2.21f)
			{
				if (!#gp.#Cke(out #Ole, 4))
				{
					return 7;
				}
				#Ole.#x = 0;
			}
			else if (num <= 3.61f)
			{
				if (!#gp.#Cke(out #Ole, 2))
				{
					return 7;
				}
			}
			else if (num == 3.62f)
			{
				#Ple #Ple;
				if (!#gp.#Cke(out #Ple, 0))
				{
					return 7;
				}
				#Ole.#yu();
				#Ole.#a = #Ple.#a;
				#Ole.#b = #Ple.#b;
				#Ole.#c = #Ple.#c;
				#Ole.#d = #Ple.#d;
				#Ole.#e = #Ple.#e;
				#Ole.#f = #Ple.#f;
				#Ole.#g = #Ple.#x;
				#Ole.#h = #Ple.#h;
				#Ole.#i = #Ple.#i;
				#Ole.#j = #Ple.#j;
				#Ole.#k = #Ple.#k;
				#Ole.#l = #Ple.#l;
				#Ole.#m[0] = #Ple.#m[0];
				#Ole.#m[1] = #Ple.#m[1];
				#Ole.#n[0] = #Ple.#n[0];
				#Ole.#n[1] = #Ple.#n[1];
				#Ole.#o = #Ple.#o;
				#Ole.#p = #Ple.#p;
				#Ole.#q = #Ple.#q;
				#Ole.#r = #Ple.#r;
				#Ole.#s = #Ple.#s;
				#Ole.#t = #Ple.#t;
				#Ole.#u = #Ple.#u;
				#Ole.#v[0] = #Ple.#v[0];
				#Ole.#v[1] = #Ple.#v[1];
				#Ole.#w = #Ple.#w;
				#Ole.#x = 0;
			}
			else if (num <= 6.5f)
			{
				if (!#gp.#Cke(out #Ole, 2))
				{
					return 7;
				}
			}
			else if (!#gp.#Cke(out #Ole, 0))
			{
				return 7;
			}
			#Ole.#yu();
			if (num < 2.2f)
			{
				for (short num3 = 0; num3 <= 1; num3 += 1)
				{
					short[] #n = #Ole.#n;
					short num4 = num3;
					#n[(int)num4] = #n[(int)num4] - 294;
					if (#Ole.#n[(int)num3] == 3)
					{
						#Ole.#n[(int)num3] = 1;
					}
					else if (#Ole.#n[(int)num3] == 1 || #Ole.#n[(int)num3] == 2)
					{
						short[] #n2 = #Ole.#n;
						short num5 = num3;
						#n2[(int)num5] = #n2[(int)num5] + 1;
					}
					short[] #m = #Ole.#m;
					short num6 = num3;
					#m[(int)num6] = #m[(int)num6] - 242;
				}
			}
			else if (num < 2.21f)
			{
				#Ole.#l -= 3;
				#Ole.#k -= 501;
			}
			else if (num < 3f)
			{
				#Ole.#h = 0;
				#Ole.#e = 0;
			}
			#Od.Options = #Ole;
			#Oke #Oke = default(#Oke);
			if (num < 3f)
			{
				if (!#gp.#Cke(out num2, 0))
				{
					return 7;
				}
				if (!#gp.#Cke(out num2, 0))
				{
					return 7;
				}
				#Oke.#c = 0;
				#Oke.#d = 1;
				if (!#gp.#Cke(out num2, 0))
				{
					return 7;
				}
				if (!#gp.#Cke(out num2, 0))
				{
					return 7;
				}
				#Oke.#b = 0;
				if (!#gp.#Cke(out num2, 0))
				{
					return 7;
				}
				float #c;
				if (!#gp.#Cke(out #c, 0))
				{
					return 7;
				}
				#Oke.#e = #c;
				if (!#gp.#Cke(out #c, 0))
				{
					return 7;
				}
				float #b;
				if (!#gp.#Cke(out #b, 0))
				{
					return 7;
				}
				#Oke.#f.#a = #c;
				#Oke.#f.#b = #b;
				if (!#gp.#Cke(out #c, 0))
				{
					return 7;
				}
				if (!#gp.#Cke(out #b, 0))
				{
					return 7;
				}
				#Oke.#g.#a = #c;
				#Oke.#g.#b = #b;
				if (!#gp.#Cke(out #c, 0))
				{
					return 7;
				}
				if (!#gp.#Cke(out #b, 0))
				{
					return 7;
				}
				if (!#gp.#Cke(out #c, 0))
				{
					return 7;
				}
				if (!#gp.#Cke(out #b, 0))
				{
					return 7;
				}
				if (!#gp.#Cke(out #c, 0))
				{
					return 7;
				}
				if (!#gp.#Cke(out #b, 0))
				{
					return 7;
				}
				#Oke.#h.#a = #c;
				#Oke.#h.#b = #b;
				#Oke.#i.#a = #Oke.#h.#a;
				#Oke.#i.#b = #Oke.#h.#b;
				#Oke.#a = 7;
			}
			else if (!#gp.#Cke(out #Oke, 0))
			{
				return 7;
			}
			#Od.IrreggularOptions = #Oke;
			#Sle #Sle = default(#Sle);
			if (num < 2.099f)
			{
				if (#Ole.#b == 0)
				{
					#Sle.#a = 3;
					#Sle.#b = 4;
					#Sle.#c = 10;
				}
				else
				{
					#Sle.#a = 10;
					#Sle.#b = 10;
					#Sle.#c = 55;
				}
			}
			else if (!#gp.#Cke(out #Sle, 0))
			{
				return 7;
			}
			#Od.Ties = #Sle;
			#Rle #f;
			if (!#gp.#Cke(out #f, 0))
			{
				return 7;
			}
			#Od.InvRein = #f;
			if (!#gp.#Cke(out #f, 0))
			{
				return 7;
			}
			#Od.DesRein = #f;
			if (#Od.Options.#n[0] != 3 && #Od.InvRein.#a[0] < 2)
			{
				#Od.Options.#n[0] = -1;
			}
			if (#Od.Options.#n[1] != 3 && #Od.DesRein.#a[0] < 3)
			{
				#Od.Options.#n[1] = -1;
			}
			float[] array2;
			if (!#gp.#Bke(2, out array2))
			{
				return 7;
			}
			#Od.InvDim = array2;
			if (!#gp.#Bke(6, out array2))
			{
				return 7;
			}
			#Od.DesDim = array2;
			#Jle #Jle = default(#Jle);
			if (num < 5f)
			{
				#Kle #Ile;
				if (!#gp.#Cke(out #Ile, 0))
				{
					return 7;
				}
				if (num < 4f)
				{
					#Jle.#h = 0;
				}
				#Jle.#mg(#Ile);
				#Jle.#k = #5je.#Lje(#Jle.#f, #Jle.#g, #Ole.#g3());
				#Jle.#i = #Kje.#Hje(#5je.#Pje(#Jle.#c, #Jle.#b, #Jle.#d, #Jle.#e, #Jle.#a, (int)#Ole.#c, #Ole.#b));
				#Jle.#j = #Kje.#Hje(#5je.#1je(#Jle.#g, #Jle.#k, #Jle.#f, (int)#Ole.#c, #Ole.#b));
			}
			else if (!#gp.#Cke(out #Jle, 0))
			{
				return 7;
			}
			#Od.MatProp = #Jle;
			#Qle #Qle = default(#Qle);
			float[] array3 = new float[4];
			if (num < 3f)
			{
				float #c;
				for (short num3 = 0; num3 < 7; num3 += 1)
				{
					if (!#gp.#Cke(out #c, 0))
					{
						return 7;
					}
				}
				if (!#gp.#Cke(out #Qle, 8))
				{
					return 7;
				}
				#c = #Qle.#c;
				#Qle.#c = #Qle.#a;
				#Qle.#a = #c;
				#Qle.#e = 0f;
				if (!#gp.#Bke(3, out array2))
				{
					return 7;
				}
				Array.Copy(array2, array3, 3);
				array3[3] = 0.9999f;
			}
			else if (num < 5.1f)
			{
				if (!#gp.#Cke(out #Qle, 4))
				{
					return 7;
				}
				if (!#gp.#Bke(4, out array2))
				{
					return 7;
				}
				Array.Copy(array2, array3, 4);
				#Qle.#e = 0f;
			}
			else
			{
				if (!#gp.#Cke(out #Qle, 0))
				{
					return 7;
				}
				if (!#gp.#Bke(4, out array2))
				{
					return 7;
				}
				Array.Copy(array2, array3, 4);
			}
			Array.Copy(array3, #Od.DesCrit, 4);
			#Ole = #Od.Options;
			if (num < 3.5f)
			{
				if (#Od.Options.#c < 0 || #Od.Options.#c > 1)
				{
					#Ole.#c = 0;
				}
				if (#Od.Options.#c == 0)
				{
					#Qle.#c = ((#Od.Options.#l == 0) ? 0.65f : 0.7f);
				}
				#Od.Options = #Ole;
			}
			for (short num3 = 0; num3 < #Ole.#r; num3 += 1)
			{
				FPOINT fpoint;
				if (!#gp.#Cke(out fpoint, 0))
				{
					return 7;
				}
				#Od.ExteriorPoints[(int)num3] = fpoint;
			}
			for (short num3 = 0; num3 < #Ole.#s; num3 += 1)
			{
				FPOINT fpoint;
				if (!#gp.#Cke(out fpoint, 0))
				{
					return 7;
				}
				#Od.InteriorPoints[(int)num3] = fpoint;
			}
			for (short num3 = 0; num3 < #Ole.#o; num3 += 1)
			{
				IRREG irreg;
				if (!#gp.#Cke(out irreg, 4))
				{
					return 7;
				}
				#Od.RfBars[(int)num3] = irreg;
			}
			for (short num3 = 0; num3 < #Ole.#p; num3 += 1)
			{
				LOADS loads;
				if (!#gp.#Cke(out loads, 0))
				{
					return 7;
				}
				#Od.FactLoads[(int)num3] = loads;
			}
			if (num < 3f)
			{
				for (short num3 = 0; num3 < 2; num3 += 1)
				{
					if (!#gp.#Cke(out num2, 0))
					{
						return 7;
					}
					#Od.SldDesCol[(int)num3].#d = (byte)num2;
					if (!#gp.#Cke(out num2, 0))
					{
						return 7;
					}
					if (!#gp.#Cke(out num2, 0))
					{
						return 7;
					}
					if (!#gp.#Cke(out num2, 0))
					{
						return 7;
					}
					#Od.SldDesCol[(int)num3].#f = num2;
				}
				for (short num3 = 0; num3 < 2; num3 += 1)
				{
					float #c;
					if (!#gp.#Cke(out #c, 0))
					{
						return 7;
					}
					#Od.SldDesCol[(int)num3].#a = #c;
					if (!#gp.#Cke(out #c, 0))
					{
						return 7;
					}
					#Od.SldDesCol[(int)num3].#b = #c;
					if (!#gp.#Cke(out #c, 0))
					{
						return 7;
					}
					#Od.SldDesCol[(int)num3].#c = #c;
				}
			}
			else
			{
				SLDDESCOL[] sourceArray;
				if (!#gp.#Bke(2, out sourceArray))
				{
					return 7;
				}
				Array.Copy(sourceArray, #Od.SldDesCol, #Od.SldDesCol.Length);
			}
			SLDABVBLWCOL[] sourceArray2;
			if (!#gp.#Bke(2, out sourceArray2))
			{
				return 7;
			}
			Array.Copy(sourceArray2, #Od.SldAbvBlwCol, #Od.SldAbvBlwCol.Length);
			SLDBEAM[] sourceArray3;
			if (!#gp.#Bke(2, out sourceArray3))
			{
				return 7;
			}
			Array.Copy(sourceArray3, #Od.SldBeam, #Od.SldBeam.Length);
			if (!#gp.#Bke(2, out array2))
			{
				return 7;
			}
			Array.Copy(array2, #Od.EI, #Od.EI.Length);
			if (num < 2.21f)
			{
				SLDDESCOL[] array4 = #Od.SldDesCol;
				float #c;
				if (!#gp.#Cke(out #c, 0))
				{
					return 7;
				}
				array4[0].#g = #c;
				array4[1].#g = array4[0].#g;
				if (!#gp.#Cke(out #c, 0))
				{
					return 7;
				}
				array4[0].#h = #c;
				array4[1].#h = array4[0].#h;
				#Od.SldOptFact = 0;
				#Od.Phi_Delta = 0.75f;
				#Od.CrackedI[0] = 0.35f;
				#Od.CrackedI[1] = 0.7f;
			}
			else if (num < 3f)
			{
				SLDDESCOL[] array5 = #Od.SldDesCol;
				if (!#gp.#Cke(out num2, 0))
				{
					return 7;
				}
				#Od.SldOptFact = num2;
				float #c;
				if (!#gp.#Cke(out #c, 0))
				{
					return 7;
				}
				if (!#gp.#Cke(out #c, 0))
				{
					return 7;
				}
				if (!#gp.#Cke(out #c, 0))
				{
					return 7;
				}
				if (#Od.SldOptFact == 0)
				{
					#Od.Phi_Delta = 0.75f;
				}
				else
				{
					#Od.Phi_Delta = #c;
				}
				if (!#gp.#Cke(out #c, 0))
				{
					return 7;
				}
				array5[0].#g = #c;
				array5[1].#g = array5[0].#g;
				if (!#gp.#Cke(out #c, 0))
				{
					return 7;
				}
				array5[0].#h = #c;
				array5[1].#h = array5[0].#h;
				#Od.CrackedI[0] = 0.35f;
				#Od.CrackedI[1] = 0.7f;
			}
			else
			{
				if (!#gp.#Cke(out num2, 0))
				{
					return 7;
				}
				#Od.SldOptFact = num2;
				float #c;
				if (!#gp.#Cke(out #c, 0))
				{
					return 7;
				}
				#Od.Phi_Delta = #c;
				if (#xke.#U3((int)#Od.SldOptFact))
				{
					#Od.Phi_Delta = 0.75f;
				}
				if (!#gp.#Bke(2, out array2))
				{
					return 7;
				}
				Array.Copy(array2, #Od.CrackedI, #Od.CrackedI.Length);
			}
			for (short num3 = 0; num3 < #Od.Options.#q; num3 += 1)
			{
				if (num < 3.5f)
				{
					if (!#gp.#Bke(15, out array2))
					{
						return 7;
					}
					Array.Copy(array2, #Od.ServLoads[(int)num3], array2.Length);
					for (int i = 15; i < 20; i++)
					{
						#Od.ServLoads[(int)num3][i] = 0f;
					}
				}
				else if (num <= 4f)
				{
					if (!#gp.#Bke(20, out array2))
					{
						return 7;
					}
					Array.Copy(array2, #Od.ServLoads[(int)num3], array2.Length);
				}
				else
				{
					if (!#gp.#Bke(25, out array2))
					{
						return 7;
					}
					Array.Copy(array2, #Od.ServLoads[(int)num3], array2.Length);
				}
			}
			if (num < 2.21f)
			{
				#Ole = #Od.Options;
				if (!#gp.#Bke(6, out array))
				{
					return 7;
				}
				#Ole.#w = 3;
				if (#Ole.#c == 0)
				{
					#Od.LoadFact[0][0] = array[0];
					#Od.LoadFact[0][1] = array[1];
					#Od.LoadFact[0][2] = 0f;
					#Od.LoadFact[1][0] = array[2] * array[0];
					#Od.LoadFact[1][1] = array[2] * array[1];
					#Od.LoadFact[1][2] = array[2] * array[3];
					#Od.LoadFact[2][0] = array[2] * array[0];
					#Od.LoadFact[2][1] = 0f;
					#Od.LoadFact[2][2] = array[2] * array[3];
				}
				else
				{
					#Od.LoadFact[0][0] = array[0];
					#Od.LoadFact[0][1] = array[1];
					#Od.LoadFact[0][2] = 0f;
					#Od.LoadFact[1][0] = array[0];
					#Od.LoadFact[1][1] = array[2] * array[1];
					#Od.LoadFact[1][2] = array[2] * array[3];
					#Od.LoadFact[2][0] = array[0];
					#Od.LoadFact[2][1] = 0f;
					#Od.LoadFact[2][2] = array[3];
				}
				#Od.BarGroupType = ((#Ole.#b == 0) ? 1 : 2);
				STNDBAR[] array6 = new STNDBAR[16];
				#Od.NumOfBars = #Kje.#Eje(#Ole, (int)#Od.BarGroupType, ref array6);
				Array.Copy(array6, #Od.Bar, array6.Length);
				#Od.Options = #Ole;
			}
			else if (num < 3f)
			{
				#Ole = #Od.Options;
				for (short num3 = 0; num3 < #Ole.#w; num3 += 1)
				{
					for (int j = 0; j < 3; j++)
					{
						if (!#gp.#Bke(6, out array2))
						{
							return 7;
						}
						#Kje.#Bje(#Od.LoadFact, array2, (int)num3, j, 5);
					}
				}
				if (!#gp.#Cke(out num2, 0))
				{
					return 7;
				}
				#Od.BarGroupType = num2;
				if (#Ole.#b == 0 && #Od.BarGroupType == 0)
				{
					#Od.BarGroupType = 1;
				}
				else if (#Ole.#b != 0 && #Od.BarGroupType == 0)
				{
					#Od.BarGroupType = 2;
				}
				else if (#Ole.#b != 0 && #Od.BarGroupType == 1)
				{
					#Od.BarGroupType = 3;
				}
				else
				{
					#Od.BarGroupType = 0;
				}
				if (#Od.BarGroupType != 0)
				{
					STNDBAR[] array7 = new STNDBAR[16];
					#Od.NumOfBars = #Kje.#Eje(#Ole, (int)#Od.BarGroupType, ref array7);
					Array.Copy(array7, #Od.Bar, array7.Length);
				}
				else
				{
					if (!#gp.#Cke(out num2, 0))
					{
						return 7;
					}
					#Od.NumOfBars = num2;
					for (short num3 = 0; num3 < #Od.NumOfBars; num3 += 1)
					{
						STNDBAR stndbar;
						if (!#gp.#Cke(out stndbar, 4))
						{
							return 7;
						}
						#Od.Bar[(int)num3] = stndbar;
						if (#Od.BarGroupType == 0)
						{
							#Od.Bar[(int)num3].#d = #Od.Bar[(int)num3].#c * ((#Ole.#b == 0) ? 3.4028f : 0.00783f);
						}
					}
				}
			}
			else
			{
				#Ole = #Od.Options;
				for (short num3 = 0; num3 < #Ole.#w; num3 += 1)
				{
					if (num < 3.5f)
					{
						if (!#gp.#Bke(3, out array2))
						{
							return 7;
						}
						Array.Copy(array2, #Od.LoadFact[(int)num3], array2.Length);
						#Od.LoadFact[(int)num3][3] = 0f;
						#Od.LoadFact[(int)num3][4] = 0f;
					}
					else if (num <= 4f)
					{
						if (!#gp.#Bke(4, out array2))
						{
							return 7;
						}
						Array.Copy(array2, #Od.LoadFact[(int)num3], array2.Length);
						#Od.LoadFact[(int)num3][4] = 0f;
					}
					else
					{
						if (!#gp.#Bke(5, out array2))
						{
							return 7;
						}
						Array.Copy(array2, #Od.LoadFact[(int)num3], array2.Length);
					}
				}
				if (!#gp.#Cke(out num2, 0))
				{
					return 7;
				}
				#Od.BarGroupType = num2;
				if (#Od.BarGroupType == 0)
				{
					if (!#gp.#Cke(out num2, 0))
					{
						return 7;
					}
					#Od.NumOfBars = num2;
					STNDBAR[] array8 = new STNDBAR[16];
					if (!#gp.#Bke((int)#Od.NumOfBars, out array8))
					{
						return 7;
					}
					Array.Copy(array8, #Od.Bar, array8.Length);
				}
				else
				{
					STNDBAR[] array9 = new STNDBAR[16];
					#Od.NumOfBars = #Kje.#Eje(#Ole, (int)#Od.BarGroupType, ref array9);
					Array.Copy(array9, #Od.Bar, array9.Length);
				}
			}
			if (num <= 4.2f)
			{
				#Od.SustFact[0] = 100f;
				#Od.SustFact[1] = 0f;
				#Od.SustFact[2] = 0f;
				#Od.SustFact[3] = 0f;
				#Od.SustFact[4] = 0f;
			}
			else
			{
				if (!#gp.#Bke(5, out array2))
				{
					return 7;
				}
				Array.Copy(array2, #Od.SustFact, array2.Length);
			}
			if (num < 3.5f)
			{
				#Ole = #Od.Options;
				if (#Ole.#w > 0 && #Ole.#q > 0 && this.#a.GetLateralLoadsCompatibilityMode() == LateralLoadsCompatibilityMode.ConsiderAsEarthquakeLoads)
				{
					for (short num3 = 0; num3 < #Ole.#w; num3 += 1)
					{
						#Od.LoadFact[(int)num3][3] = #Od.LoadFact[(int)num3][2];
						#Od.LoadFact[(int)num3][2] = 0f;
					}
					for (short num3 = 0; num3 < #Ole.#q; num3 += 1)
					{
						for (int k = 0; k < 5; k++)
						{
							#Od.ServLoads[(int)num3][15 + k] = #Od.ServLoads[(int)num3][10 + k];
							#Od.ServLoads[(int)num3][10 + k] = 0f;
						}
					}
				}
			}
			if (num < 3f)
			{
				#Sle.#a = (short)#Kje.#zje((int)#Sle.#a, #Od);
				#Sle.#b = (short)#Kje.#zje((int)#Sle.#b, #Od);
				#Sle.#c = (short)#Kje.#zje((int)#Sle.#c, #Od);
				for (short num3 = 0; num3 < 4; num3 += 1)
				{
					#Od.InvRein.#b[(int)num3] = (short)#Kje.#zje((int)#Od.InvRein.#b[(int)num3], #Od);
					#Od.DesRein.#b[(int)num3] = (short)#Kje.#zje((int)#Od.DesRein.#b[(int)num3], #Od);
				}
			}
			this.#Ije(#Od, num);
			#Od.RedFactors = #Qle;
			#Od.Ties = #Sle;
			return 0;
		}

		// Token: 0x060091DE RID: 37342 RVA: 0x001EEFBC File Offset: 0x001ED1BC
		private static int #zje(int #Aje, #Hle #Od)
		{
			if (#Aje == 0)
			{
				return 0;
			}
			int i;
			for (i = 0; i < (int)#Od.NumOfBars; i++)
			{
				if (#Aje <= (int)#Od.Bar[i].#a)
				{
					return i;
				}
			}
			return i;
		}

		// Token: 0x060091DF RID: 37343 RVA: 0x001EEFF8 File Offset: 0x001ED1F8
		private static void #Bje(float[][] #En, float[] #Qb, int #Ttb, int #Cje, int #Dje)
		{
			for (int i = 0; i < #Qb.Length; i++)
			{
				if (i == 0)
				{
					#En[#Ttb][#Cje] = #Qb[i];
				}
				else
				{
					#Cje++;
					if (#Cje >= #Dje)
					{
						#Cje = 0;
						#Ttb++;
					}
					#En[#Ttb][#Cje] = #Qb[i];
				}
			}
		}

		// Token: 0x060091E0 RID: 37344 RVA: 0x001EF03C File Offset: 0x001ED23C
		internal static short #Eje(#Ole #5Wd, int #Fje, ref STNDBAR[] #Gje)
		{
			STNDBAR[] array = new STNDBAR[16];
			float num = 1f;
			float num2 = 1f;
			int num3;
			switch (#Fje)
			{
			case 1:
				num3 = 11;
				array[0].#a = 3;
				array[1].#a = 4;
				array[2].#a = 5;
				array[3].#a = 6;
				array[4].#a = 7;
				array[5].#a = 8;
				array[6].#a = 9;
				array[7].#a = 10;
				array[8].#a = 11;
				array[9].#a = 14;
				array[10].#a = 18;
				array[0].#b = 0.375f;
				array[1].#b = 0.5f;
				array[2].#b = 0.625f;
				array[3].#b = 0.75f;
				array[4].#b = 0.875f;
				array[5].#b = 1f;
				array[6].#b = 1.128f;
				array[7].#b = 1.27f;
				array[8].#b = 1.41f;
				array[9].#b = 1.693f;
				array[10].#b = 2.257f;
				array[0].#c = 0.11f;
				array[1].#c = 0.2f;
				array[2].#c = 0.31f;
				array[3].#c = 0.44f;
				array[4].#c = 0.6f;
				array[5].#c = 0.79f;
				array[6].#c = 1f;
				array[7].#c = 1.27f;
				array[8].#c = 1.56f;
				array[9].#c = 2.25f;
				array[10].#c = 4f;
				array[0].#d = 0.376f;
				array[1].#d = 0.668f;
				array[2].#d = 1.043f;
				array[3].#d = 1.502f;
				array[4].#d = 2.044f;
				array[5].#d = 2.67f;
				array[6].#d = 3.4f;
				array[7].#d = 4.303f;
				array[8].#d = 5.313f;
				array[9].#d = 7.65f;
				array[10].#d = 13.6f;
				if (#5Wd.#b == 1)
				{
					num = 25.4f;
					num2 = 1.488164f;
				}
				break;
			case 2:
				num3 = 8;
				array[0].#a = 10;
				array[1].#a = 15;
				array[2].#a = 20;
				array[3].#a = 25;
				array[4].#a = 30;
				array[5].#a = 35;
				array[6].#a = 45;
				array[7].#a = 55;
				array[0].#b = 11.3f;
				array[1].#b = 16f;
				array[2].#b = 19.5f;
				array[3].#b = 25.2f;
				array[4].#b = 29.9f;
				array[5].#b = 35.7f;
				array[6].#b = 43.7f;
				array[7].#b = 56.4f;
				array[0].#c = 100f;
				array[1].#c = 200f;
				array[2].#c = 300f;
				array[3].#c = 500f;
				array[4].#c = 700f;
				array[5].#c = 1000f;
				array[6].#c = 1500f;
				array[7].#c = 2500f;
				array[0].#d = 0.785f;
				array[1].#d = 1.57f;
				array[2].#d = 2.356f;
				array[3].#d = 3.925f;
				array[4].#d = 5.495f;
				array[5].#d = 7.85f;
				array[6].#d = 11.775f;
				array[7].#d = 19.625f;
				if (#5Wd.#b == 0)
				{
					num = 0.03937f;
					num2 = 0.67197f;
				}
				break;
			case 3:
				num3 = 11;
				array[0].#a = 6;
				array[1].#a = 8;
				array[2].#a = 10;
				array[3].#a = 12;
				array[4].#a = 14;
				array[5].#a = 16;
				array[6].#a = 20;
				array[7].#a = 25;
				array[8].#a = 28;
				array[9].#a = 32;
				array[10].#a = 40;
				array[0].#b = 6f;
				array[1].#b = 8f;
				array[2].#b = 10f;
				array[3].#b = 12f;
				array[4].#b = 14f;
				array[5].#b = 16f;
				array[6].#b = 20f;
				array[7].#b = 25f;
				array[8].#b = 28f;
				array[9].#b = 32f;
				array[10].#b = 40f;
				array[0].#c = 28.3f;
				array[1].#c = 50.3f;
				array[2].#c = 78.5f;
				array[3].#c = 113f;
				array[4].#c = 154f;
				array[5].#c = 201f;
				array[6].#c = 314f;
				array[7].#c = 491f;
				array[8].#c = 616f;
				array[9].#c = 801f;
				array[10].#c = 1256f;
				array[0].#d = 0.222f;
				array[1].#d = 0.395f;
				array[2].#d = 0.617f;
				array[3].#d = 0.888f;
				array[4].#d = 1.208f;
				array[5].#d = 1.578f;
				array[6].#d = 2.466f;
				array[7].#d = 3.853f;
				array[8].#d = 4.836f;
				array[9].#d = 6.313f;
				array[10].#d = 9.865f;
				if (#5Wd.#b == 0)
				{
					num = 0.03937f;
					num2 = 0.67197f;
				}
				break;
			case 4:
				num3 = 11;
				array[0].#a = 10;
				array[1].#a = 13;
				array[2].#a = 16;
				array[3].#a = 19;
				array[4].#a = 22;
				array[5].#a = 25;
				array[6].#a = 29;
				array[7].#a = 32;
				array[8].#a = 36;
				array[9].#a = 43;
				array[10].#a = 57;
				array[0].#b = 9.5f;
				array[1].#b = 12.7f;
				array[2].#b = 15.9f;
				array[3].#b = 19.1f;
				array[4].#b = 22.2f;
				array[5].#b = 25.4f;
				array[6].#b = 28.7f;
				array[7].#b = 32.3f;
				array[8].#b = 35.8f;
				array[9].#b = 43f;
				array[10].#b = 57.3f;
				array[0].#c = 71f;
				array[1].#c = 129f;
				array[2].#c = 199f;
				array[3].#c = 284f;
				array[4].#c = 387f;
				array[5].#c = 510f;
				array[6].#c = 645f;
				array[7].#c = 819f;
				array[8].#c = 1006f;
				array[9].#c = 1452f;
				array[10].#c = 2581f;
				array[0].#d = 0.56f;
				array[1].#d = 0.994f;
				array[2].#d = 1.552f;
				array[3].#d = 2.235f;
				array[4].#d = 3.042f;
				array[5].#d = 3.973f;
				array[6].#d = 5.06f;
				array[7].#d = 6.404f;
				array[8].#d = 7.907f;
				array[9].#d = 11.38f;
				array[10].#d = 20.24f;
				if (#5Wd.#b == 0)
				{
					num = 0.03937f;
					num2 = 0.67197f;
				}
				break;
			default:
				return 0;
			}
			if (num != 1f && num2 != 1f)
			{
				for (int i = 0; i < num3; i++)
				{
					array[i].#b = #vje.#ssc(array[i].#b * num, 0.001f);
					array[i].#c = #vje.#ssc(array[i].#c * num * num, 0.001f);
					array[i].#d = #vje.#ssc(array[i].#d * num2, 0.001f);
				}
			}
			for (int i = 0; i < num3; i++)
			{
				#Gje[i].#a = array[i].#a;
				#Gje[i].#b = array[i].#b;
				#Gje[i].#c = array[i].#c;
				#Gje[i].#d = array[i].#d;
			}
			return (short)num3;
		}

		// Token: 0x060091E1 RID: 37345 RVA: 0x000755EF File Offset: 0x000737EF
		public static byte #Hje(bool #f)
		{
			return #f ? 1 : 0;
		}

		// Token: 0x060091E2 RID: 37346 RVA: 0x001EFD24 File Offset: 0x001EDF24
		private void #Ije(#Hle #Od, float #Jje)
		{
			if (#Jje <= 6f)
			{
				float num = #Od.DesCrit[3];
				if ((double)Math.Abs(num) < 0.001)
				{
					num = 1f;
				}
				float num2 = 1f / num;
				#Od.DesCrit[3] = (float)(Math.Floor((double)(num2 * 10000f)) / 10000.0);
			}
		}

		// Token: 0x04003D3D RID: 15677
		private readonly #cke #a;
	}
}
