using System;
using System.Collections.Generic;
using System.Windows.Input;
using System.Windows.Media;
using #7hc;
using #IDc;
using #UYd;
using #YKc;
using StructurePoint.CoreAssets.GUI.DesktopControls.Utils;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace #bJc
{
	// Token: 0x02000B98 RID: 2968
	internal static class #8Ib
	{
		// Token: 0x06006183 RID: 24963 RVA: 0x0017CBA8 File Offset: 0x0017ADA8
		public static void #HJc(ISnapPointsMarker #IJc, #6Gc #JAc)
		{
			string #R0d = #Phc.#3hc(107415142);
			Component #x6c = Component.Geometry;
			string #Qic = #Phc.#3hc(107415117);
			if (5 != 0)
			{
				#X0d.#V0d(#IJc, #R0d, #x6c, #Qic);
			}
			string #R0d2 = #Phc.#3hc(107415096);
			Component #x6c2 = Component.Geometry;
			string #Qic2 = #Phc.#3hc(107415071);
			if (!false)
			{
				#X0d.#V0d(#JAc, #R0d2, #x6c2, #Qic2);
			}
			Color defaultSnapPointsColor = #JAc.SnapPointsMarkerDefaultVertexColor;
			if (!false)
			{
				#IJc.DefaultSnapPointsColor = defaultSnapPointsColor;
			}
			double defaultSnapPointsSize = #JAc.SnapPointsMarkerDefaultVertexSize;
			if (6 != 0)
			{
				#IJc.DefaultSnapPointsSize = defaultSnapPointsSize;
			}
			Color keyPointSnapPointColor = #JAc.SnapPointsMarkerKeyPointsVertexColor;
			if (!false)
			{
				#IJc.KeyPointSnapPointColor = keyPointSnapPointColor;
			}
			double keyPointSnapPointSize = #JAc.SnapPointsMarkerKeyPointsVertexSize;
			if (!false)
			{
				#IJc.KeyPointSnapPointSize = keyPointSnapPointSize;
			}
		}

		// Token: 0x06006184 RID: 24964 RVA: 0x0017CC4C File Offset: 0x0017AE4C
		public static IEnumerable<Key> #JJc(#fLc #KJc)
		{
			List<#fLc> list;
			#b0d.#vZd<#fLc>(#KJc, out list);
			List<Key> list3;
			if (!false)
			{
				List<Key> list2 = new List<Key>();
				if (true)
				{
					list3 = list2;
				}
			}
			List<#fLc>.Enumerator enumerator = list.GetEnumerator();
			List<#fLc>.Enumerator enumerator2;
			if (!false)
			{
				enumerator2 = enumerator;
			}
			try
			{
				while (enumerator2.MoveNext())
				{
					#fLc #fLc = enumerator2.Current;
					#fLc #fLc2;
					if (2 != 0)
					{
						#fLc2 = #fLc;
					}
					switch (#fLc2)
					{
					case #fLc.#a:
					case #fLc.#b | #fLc.#c:
					case #fLc.#b | #fLc.#d:
					case #fLc.#c | #fLc.#d:
					case #fLc.#b | #fLc.#c | #fLc.#d:
						break;
					case #fLc.#b:
					{
						List<Key> list4 = list3;
						Key item = Key.LeftShift;
						if (-1 != 0)
						{
							list4.Add(item);
						}
						if (false)
						{
							goto IL_BD;
						}
						break;
					}
					case #fLc.#c:
					{
						List<Key> list5 = list3;
						Key item2 = Key.RightShift;
						if (!false)
						{
							list5.Add(item2);
						}
						break;
					}
					case #fLc.#d:
						if (!false)
						{
							List<Key> list6 = list3;
							Key item3 = Key.LeftCtrl;
							if (!false)
							{
								list6.Add(item3);
							}
						}
						break;
					case #fLc.#e:
						if (!false)
						{
							list3.Add(Key.RightCtrl);
						}
						break;
					default:
						if (#fLc2 != #fLc.#f)
						{
							if (#fLc2 == #fLc.#g)
							{
								list3.Add(Key.RightAlt);
							}
						}
						else
						{
							list3.Add(Key.LeftAlt);
						}
						break;
					}
				}
				IL_BD:;
			}
			finally
			{
				((IDisposable)enumerator2).Dispose();
			}
			return list3;
		}
	}
}
