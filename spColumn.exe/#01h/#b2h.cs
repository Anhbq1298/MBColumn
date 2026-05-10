using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using #7hc;
using #t2h;
using #UYd;
using StructurePoint.CoreAssets.DataExchange.DXF.Legacy;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace #01h
{
	// Token: 0x02000793 RID: 1939
	internal sealed class #b2h
	{
		// Token: 0x06003E44 RID: 15940 RVA: 0x001202A0 File Offset: 0x0011E4A0
		private #b2h()
		{
			this.Polylines = new List<#42h>();
			this.Circles = new List<#u2h>();
			this.Lines = new List<#S2h>();
			this.Texts = new List<#b3h>();
			this.Arcs = new List<#s2h>();
			this.LwPolylines = new List<#32h>();
			this.Inserts = new List<#L2h>();
		}

		// Token: 0x06003E45 RID: 15941 RVA: 0x0012058C File Offset: 0x0011E78C
		public #b2h(List<List<#Z1h>> #c2h) : this()
		{
			#X0d.#V0d(#c2h, #Phc.#3hc(107373621), Component.DataExchange, #Phc.#3hc(107373576));
			List<List<#Z1h>> list = new List<List<#Z1h>>();
			for (int i = 0; i < #c2h.Count; i++)
			{
				List<#Z1h> list2 = #c2h[i];
				string #fme = list2[0].#W1h();
				#r2h #r2h = this.#a2h(#fme);
				if (#r2h <= #r2h.#j)
				{
					switch (#r2h)
					{
					case #r2h.#a:
						list.Clear();
						do
						{
							list.Add(#c2h[i]);
							#fme = #c2h[++i][0].#W1h();
						}
						while (DxfHelper.#ntb(#fme, #Phc.#3hc(107373673), 6) != 0);
						this.Polylines.Add(new #42h(list));
						break;
					case #r2h.#b:
						this.Arcs.Add(new #s2h(list2));
						break;
					case #r2h.#c:
						this.Circles.Add(new #u2h(list2));
						break;
					case #r2h.#d:
						this.Lines.Add(new #S2h(list2));
						break;
					default:
						if (#r2h == #r2h.#j)
						{
							this.Inserts.Add(new #L2h(list2));
						}
						break;
					}
				}
				else if (#r2h != #r2h.#l)
				{
					if (#r2h == #r2h.#v)
					{
						this.LwPolylines.Add(new #32h(list2));
					}
				}
				else
				{
					this.Texts.Add(new #b3h(list2));
				}
			}
		}

		// Token: 0x170012E6 RID: 4838
		// (get) Token: 0x06003E46 RID: 15942 RVA: 0x000351D5 File Offset: 0x000333D5
		// (set) Token: 0x06003E47 RID: 15943 RVA: 0x000351DD File Offset: 0x000333DD
		public List<#42h> Polylines { get; private set; }

		// Token: 0x170012E7 RID: 4839
		// (get) Token: 0x06003E48 RID: 15944 RVA: 0x000351E6 File Offset: 0x000333E6
		// (set) Token: 0x06003E49 RID: 15945 RVA: 0x000351EE File Offset: 0x000333EE
		public List<#u2h> Circles { get; private set; }

		// Token: 0x170012E8 RID: 4840
		// (get) Token: 0x06003E4A RID: 15946 RVA: 0x000351F7 File Offset: 0x000333F7
		// (set) Token: 0x06003E4B RID: 15947 RVA: 0x000351FF File Offset: 0x000333FF
		public List<#S2h> Lines { get; private set; }

		// Token: 0x170012E9 RID: 4841
		// (get) Token: 0x06003E4C RID: 15948 RVA: 0x00035208 File Offset: 0x00033408
		// (set) Token: 0x06003E4D RID: 15949 RVA: 0x00035210 File Offset: 0x00033410
		public List<#b3h> Texts { get; private set; }

		// Token: 0x170012EA RID: 4842
		// (get) Token: 0x06003E4E RID: 15950 RVA: 0x00035219 File Offset: 0x00033419
		// (set) Token: 0x06003E4F RID: 15951 RVA: 0x00035221 File Offset: 0x00033421
		public List<#s2h> Arcs { get; private set; }

		// Token: 0x170012EB RID: 4843
		// (get) Token: 0x06003E50 RID: 15952 RVA: 0x0003522A File Offset: 0x0003342A
		// (set) Token: 0x06003E51 RID: 15953 RVA: 0x00035232 File Offset: 0x00033432
		public List<#32h> LwPolylines { get; private set; }

		// Token: 0x170012EC RID: 4844
		// (get) Token: 0x06003E52 RID: 15954 RVA: 0x0003523B File Offset: 0x0003343B
		// (set) Token: 0x06003E53 RID: 15955 RVA: 0x00035243 File Offset: 0x00033443
		public List<#L2h> Inserts { get; private set; }

		// Token: 0x06003E54 RID: 15956 RVA: 0x001206F8 File Offset: 0x0011E8F8
		public #r2h #a2h(string #f)
		{
			Dictionary<string, #r2h>.Enumerator enumerator = this.#a.GetEnumerator();
			Dictionary<string, #r2h>.Enumerator enumerator2;
			if (7 != 0)
			{
				enumerator2 = enumerator;
			}
			try
			{
				KeyValuePair<string, #r2h> keyValuePair2;
				while (4 != 0)
				{
					while (!false)
					{
						int num;
						bool flag = (num = (enumerator2.MoveNext() ? 1 : 0)) != 0;
						do
						{
							if (3 != 0)
							{
								if (!flag)
								{
									goto Block_6;
								}
								KeyValuePair<string, #r2h> keyValuePair = enumerator2.Current;
								if (4 != 0)
								{
									keyValuePair2 = keyValuePair;
								}
								flag = ((num = DxfHelper.#ntb(#f, keyValuePair2.Key, keyValuePair2.Key.Length)) != 0);
							}
						}
						while (false);
						if (num == 0)
						{
							goto IL_3D;
						}
						continue;
						Block_6:
						return #r2h.#K;
					}
				}
				IL_3D:
				#r2h value = keyValuePair2.Value;
				#r2h result;
				if (!false)
				{
					result = value;
				}
				return result;
			}
			finally
			{
				((IDisposable)enumerator2).Dispose();
			}
			return #r2h.#K;
		}

		// Token: 0x04001C3A RID: 7226
		private readonly Dictionary<string, #r2h> #a = new Dictionary<string, #r2h>
		{
			{
				#Phc.#3hc(107374517),
				#r2h.#a
			},
			{
				#Phc.#3hc(107374472),
				#r2h.#b
			},
			{
				#Phc.#3hc(107374467),
				#r2h.#c
			},
			{
				#Phc.#3hc(107374490),
				#r2h.#d
			},
			{
				#Phc.#3hc(107374481),
				#r2h.#e
			},
			{
				#Phc.#3hc(107374440),
				#r2h.#f
			},
			{
				#Phc.#3hc(107374463),
				#r2h.#g
			},
			{
				#Phc.#3hc(107374458),
				#r2h.#h
			},
			{
				#Phc.#3hc(107374413),
				#r2h.#i
			},
			{
				#Phc.#3hc(107374400),
				#r2h.#j
			},
			{
				#Phc.#3hc(107374423),
				#r2h.#k
			},
			{
				#Phc.#3hc(107374382),
				#r2h.#l
			},
			{
				#Phc.#3hc(107374373),
				#r2h.#m
			},
			{
				#Phc.#3hc(107374392),
				#r2h.#n
			},
			{
				#Phc.#3hc(107374367),
				#r2h.#o
			},
			{
				#Phc.#3hc(107373802),
				#r2h.#p
			},
			{
				#Phc.#3hc(107373793),
				#r2h.#q
			},
			{
				#Phc.#3hc(107373816),
				#r2h.#r
			},
			{
				#Phc.#3hc(107373775),
				#r2h.#s
			},
			{
				#Phc.#3hc(107373766),
				#r2h.#t
			},
			{
				#Phc.#3hc(107373789),
				#r2h.#u
			},
			{
				#Phc.#3hc(107373780),
				#r2h.#v
			},
			{
				#Phc.#3hc(107373731),
				#r2h.#w
			},
			{
				#Phc.#3hc(107373754),
				#r2h.#x
			},
			{
				#Phc.#3hc(107373745),
				#r2h.#y
			},
			{
				#Phc.#3hc(107373700),
				#r2h.#z
			},
			{
				#Phc.#3hc(107373723),
				#r2h.#A
			},
			{
				#Phc.#3hc(107373714),
				#r2h.#B
			},
			{
				#Phc.#3hc(107373673),
				#r2h.#C
			},
			{
				#Phc.#3hc(107373664),
				#r2h.#D
			},
			{
				#Phc.#3hc(107373687),
				#r2h.#E
			},
			{
				#Phc.#3hc(107373646),
				#r2h.#F
			},
			{
				#Phc.#3hc(107373637),
				#r2h.#G
			},
			{
				#Phc.#3hc(107373656),
				#r2h.#H
			},
			{
				#Phc.#3hc(107373615),
				#r2h.#I
			},
			{
				#Phc.#3hc(107373602),
				#r2h.#J
			}
		};

		// Token: 0x04001C3B RID: 7227
		[CompilerGenerated]
		private List<#42h> #b;

		// Token: 0x04001C3C RID: 7228
		[CompilerGenerated]
		private List<#u2h> #c;

		// Token: 0x04001C3D RID: 7229
		[CompilerGenerated]
		private List<#S2h> #d;

		// Token: 0x04001C3E RID: 7230
		[CompilerGenerated]
		private List<#b3h> #e;

		// Token: 0x04001C3F RID: 7231
		[CompilerGenerated]
		private List<#s2h> #f;

		// Token: 0x04001C40 RID: 7232
		[CompilerGenerated]
		private List<#32h> #g;

		// Token: 0x04001C41 RID: 7233
		[CompilerGenerated]
		private List<#L2h> #h;
	}
}
