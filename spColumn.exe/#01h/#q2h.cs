using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using #2ic;
using #7hc;
using #cYd;
using #Pic;
using #t2h;
using #UYd;
using #Vjc;
using StructurePoint.CoreAssets.DataExchange.DXF.Legacy;
using StructurePoint.CoreAssets.DataExchange.ExternFormat;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;

namespace #01h
{
	// Token: 0x02000796 RID: 1942
	internal sealed class #q2h : IDisposable, #Gjc
	{
		// Token: 0x06003E62 RID: 15970 RVA: 0x00120D6C File Offset: 0x0011EF6C
		public #q2h(string #So)
		{
			try
			{
				this.#a = File.OpenText(#So);
			}
			catch (UnauthorizedAccessException #Uic)
			{
				throw new #Oic(Strings.StringImportFileProcessAborted.#z2d(), #Phc.#3hc(107373294), Component.DataExchange, #IYd.#b, #JYd.#A, #Uic);
			}
			catch (IOException #Uic2)
			{
				throw new #Oic(Strings.StringImportFileProcessAborted.#z2d(), #Phc.#3hc(107373273), Component.DataExchange, #IYd.#b, #JYd.#A, #Uic2);
			}
			catch (Exception #Uic3)
			{
				throw new #Oic(Strings.StringImportFileProcessAborted.#z2d(), #Phc.#3hc(107373188), Component.DataExchange, #IYd.#a, #Uic3);
			}
		}

		// Token: 0x06003E63 RID: 15971 RVA: 0x000352B7 File Offset: 0x000334B7
		internal #q2h(StreamReader #blc)
		{
			#X0d.#V0d(#blc, #Phc.#3hc(107373135), Component.DataExchange, #Phc.#3hc(107373150));
			this.#a = #blc;
		}

		// Token: 0x06003E64 RID: 15972 RVA: 0x000352ED File Offset: 0x000334ED
		protected void #1(bool #POb)
		{
			if (this.#a != null)
			{
				TextReader textReader = this.#a;
				if (7 != 0)
				{
					textReader.Dispose();
				}
			}
		}

		// Token: 0x06003E65 RID: 15973 RVA: 0x00035308 File Offset: 0x00033508
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

		// Token: 0x06003E66 RID: 15974 RVA: 0x00120E2C File Offset: 0x0011F02C
		public #Qjc #Cjc(#Tjc #yf)
		{
			#q2h.#ITb #ITb = new #q2h.#ITb();
			#q2h.#ITb #ITb2;
			if (!false)
			{
				#ITb2 = #ITb;
			}
			#ITb2.#a = this;
			#ITb2.#b = new #kkc();
			List<List<#Z1h>> list = DxfHelper.#g2h(this.#a);
			#b2h #b2h = new #b2h(DxfHelper.#h2h(list[4], 0));
			#b2h #b2h2;
			if (-1 != 0)
			{
				#b2h2 = #b2h;
			}
			List<#tjc> list2 = #ITb2.#b.Circles;
			IEnumerable<#tjc> collection = #b2h2.Circles.Select(new Func<#u2h, #Zjc>(#ITb2.#q3h));
			if (!false)
			{
				list2.AddRange(collection);
			}
			List<#pjc> list3 = #ITb2.#b.Polylines;
			IEnumerable<#pjc> collection2 = #b2h2.Polylines.Select(new Func<#42h, #skc>(this.#lpc));
			if (5 != 0)
			{
				list3.AddRange(collection2);
			}
			List<#pjc> list4 = #ITb2.#b.Polylines;
			IEnumerable<#pjc> collection3 = #b2h2.LwPolylines.Select(new Func<#32h, #skc>(this.#lpc));
			if (!false)
			{
				list4.AddRange(collection3);
			}
			List<#fkc> list5 = this.#b.Values.ToList<#fkc>();
			Action<#fkc> action = new Action<#fkc>(#ITb2.#r3h);
			if (!false)
			{
				list5.ForEach(action);
			}
			#k3h #k3h = new #8mg(DxfHelper.#h2h(list[0], 9)).#z2h(#Phc.#3hc(107373065));
			#ITb2.#b.DrawingUnit = (ExternDrawingUnit)((#k3h != null) ? #k3h.IntValue : 0);
			return #ITb2.#b;
		}

		// Token: 0x06003E67 RID: 15975 RVA: 0x00003375 File Offset: 0x00001575
		public bool #Djc()
		{
			return true;
		}

		// Token: 0x06003E68 RID: 15976 RVA: 0x0001233F File Offset: 0x0001053F
		public string #Ejc()
		{
			return null;
		}

		// Token: 0x06003E69 RID: 15977 RVA: 0x0001233F File Offset: 0x0001053F
		public string #Fjc()
		{
			return null;
		}

		// Token: 0x06003E6A RID: 15978 RVA: 0x00035324 File Offset: 0x00033524
		private #skc #lpc(#32h #tAc)
		{
			return new #skc(#tAc.Points.Select(new Func<#n3h, #Jkc>(this.#n2h)).ToList<#Jkc>(), #tAc.IsClosed, this.#p2h(#tAc.Layer));
		}

		// Token: 0x06003E6B RID: 15979 RVA: 0x00035359 File Offset: 0x00033559
		private #skc #lpc(#42h #tAc)
		{
			return new #skc(#tAc.Points.Select(new Func<#n3h, #Jkc>(this.#n2h)).ToList<#Jkc>(), #tAc.IsClosed, this.#p2h(#tAc.Layer));
		}

		// Token: 0x06003E6C RID: 15980 RVA: 0x0003538E File Offset: 0x0003358E
		private #Jkc #n2h(#y2h #8Y)
		{
			return new #Jkc(this.#o2h(#8Y));
		}

		// Token: 0x06003E6D RID: 15981 RVA: 0x0003539C File Offset: 0x0003359C
		private #mkc #o2h(#y2h #8Y)
		{
			return new #mkc(#8Y.X, #8Y.Y, #8Y.Z, this.#p2h(#8Y.Layer));
		}

		// Token: 0x06003E6E RID: 15982 RVA: 0x00120F8C File Offset: 0x0011F18C
		private #fkc #p2h(string #wy)
		{
			#fkc #fkc;
			if (!false && (false || !this.#b.TryGetValue(#wy, out #fkc)))
			{
				#fkc #fkc2 = new #fkc(#wy, new #3jc(0, 0, 0));
				if (!false)
				{
					#fkc = #fkc2;
				}
				if (2 != 0)
				{
					Dictionary<string, #fkc> dictionary = this.#b;
					#fkc value = #fkc;
					if (3 != 0)
					{
						dictionary.Add(#wy, value);
					}
				}
			}
			return #fkc;
		}

		// Token: 0x04001C45 RID: 7237
		private readonly StreamReader #a;

		// Token: 0x04001C46 RID: 7238
		private readonly Dictionary<string, #fkc> #b = new Dictionary<string, #fkc>();

		// Token: 0x02000797 RID: 1943
		[CompilerGenerated]
		private sealed class #ITb
		{
			// Token: 0x06003E70 RID: 15984 RVA: 0x000353C1 File Offset: 0x000335C1
			internal #Zjc #q3h(#u2h #Rf)
			{
				return new #Zjc(this.#a.#o2h(#Rf), #Rf.Radius, this.#a.#p2h(#Rf.Layer));
			}

			// Token: 0x06003E71 RID: 15985 RVA: 0x000353EB File Offset: 0x000335EB
			internal void #r3h(#fkc #Rf)
			{
				List<#jjc> list = this.#b.Layers;
				if (!false)
				{
					list.Add(#Rf);
				}
			}

			// Token: 0x04001C47 RID: 7239
			public #q2h #a;

			// Token: 0x04001C48 RID: 7240
			public #kkc #b;
		}
	}
}
