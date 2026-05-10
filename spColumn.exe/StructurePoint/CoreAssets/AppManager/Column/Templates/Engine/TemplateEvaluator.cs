using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using #6he;
using #7hc;
using #Gfe;
using devDept.Geometry;
using Jint;
using Jint.Native;
using Jint.Native.Object;
using StructurePoint.CoreAssets.AppManager.Column.Helpers;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.AppManager.Column.Templates.Engine.DTO;
using StructurePoint.CoreAssets.AppManager.Column.Templates.Engine.Helpers;
using StructurePoint.CoreAssets.AppManager.Column.Templates.Engine.Runtime;
using StructurePoint.CoreAssets.AppManager.Column.Templates.Storage;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Units;

namespace StructurePoint.CoreAssets.AppManager.Column.Templates.Engine
{
	// Token: 0x02001085 RID: 4229
	internal sealed class TemplateEvaluator
	{
		// Token: 0x0600906F RID: 36975 RVA: 0x001E8A44 File Offset: 0x001E6C44
		public TemplateEvaluator(StandardBarsProvider barsProvider, Func<UnitSystem> unitSystemFactory)
		{
			this.#d = barsProvider;
			this.#e = unitSystemFactory;
			this.#b = new Engine(new Action<Jint.Options>(TemplateEvaluator.<>c.<>9.#uWb));
		}

		// Token: 0x06009070 RID: 36976 RVA: 0x001E8AA0 File Offset: 0x001E6CA0
		public bool #KA(string #3)
		{
			this.#eb();
			this.#b.Execute(#3);
			JsBoolean jsBoolean = this.#b.GetCompletionValue() as JsBoolean;
			return jsBoolean != null && jsBoolean.AsBoolean();
		}

		// Token: 0x06009071 RID: 36977 RVA: 0x00074A99 File Offset: 0x00072C99
		public bool #KA(CodeItem #3)
		{
			return string.IsNullOrWhiteSpace((#3 != null) ? #3.Code : null) || this.#KA(#3.Code);
		}

		// Token: 0x06009072 RID: 36978 RVA: 0x00074ABC File Offset: 0x00072CBC
		public void #Mge(string #6cc, object #f)
		{
			this.#b.SetValue(#6cc, #f);
		}

		// Token: 0x06009073 RID: 36979 RVA: 0x001E8ADC File Offset: 0x001E6CDC
		public #Lge #oge()
		{
			#Lge #Lge = new #Lge();
			this.#hhe(#Lge);
			this.#ihe(#Lge);
			return #Lge;
		}

		// Token: 0x06009074 RID: 36980 RVA: 0x001E8B00 File Offset: 0x001E6D00
		public #Lge #Nge()
		{
			#Lge #Lge = new #Lge();
			this.#che(#Lge);
			this.#dhe(#Lge);
			this.#bhe(#Lge);
			this.#hhe(#Lge);
			this.#ihe(#Lge);
			this.#5ge(#Lge);
			this.#ahe(#Lge);
			this.#4ge(#Lge);
			return #Lge;
		}

		// Token: 0x06009075 RID: 36981 RVA: 0x001E8B4C File Offset: 0x001E6D4C
		public #Lge #0(CodeItem #3)
		{
			string source = #Phc.#3hc(107244695) + #3.Code + #Phc.#3hc(107244690);
			this.#b.Execute(source);
			return this.#Nge();
		}

		// Token: 0x06009076 RID: 36982 RVA: 0x001E8B8C File Offset: 0x001E6D8C
		public void #eb()
		{
			ObjectInstance value = new ObjectInstance(this.#b);
			this.#b.SetValue(#Phc.#3hc(107399786), value);
			this.#1ge();
			this.#0(this.#c);
		}

		// Token: 0x06009077 RID: 36983 RVA: 0x00074AD1 File Offset: 0x00072CD1
		private void #0(string #3)
		{
			this.#b.Execute(#3);
		}

		// Token: 0x06009078 RID: 36984 RVA: 0x001E8BD4 File Offset: 0x001E6DD4
		private void #nb(string #Oge, string #5)
		{
			this.#b.Execute(string.Concat(new string[]
			{
				#Phc.#3hc(107244653),
				#Oge,
				#Phc.#3hc(107244668),
				#5,
				#Phc.#3hc(107244659)
			}));
		}

		// Token: 0x06009079 RID: 36985 RVA: 0x001E8C28 File Offset: 0x001E6E28
		private bool #Pge()
		{
			#Lge #Lge = new #Lge();
			this.#che(#Lge);
			if (!#Lge.Polygons.Any<SectionPolygon>())
			{
				return true;
			}
			List<SectionPolygon> list;
			if (new ShapesMergeHelper(#Lge.Polygons, new Action<string>(this.#phe)).#2Le(out list))
			{
				this.#b.Execute(#Phc.#3hc(107244622));
				foreach (SectionPolygon sectionPolygon in list)
				{
					string text = string.Join(#Phc.#3hc(107376612), sectionPolygon.Points.Select(new Func<Point, string>(TemplateEvaluator.<>c.<>9.#Eaf)));
					string text2 = (sectionPolygon.Application == PolygonApplication.Opening) ? #Phc.#3hc(107244629) : #Phc.#3hc(107373687);
					string text3 = sectionPolygon.Id.ToString(CultureInfo.InvariantCulture);
					this.#b.Execute(string.Concat(new string[]
					{
						#Phc.#3hc(107244584),
						text3,
						#Phc.#3hc(107376612),
						text2,
						#Phc.#3hc(107376612),
						text,
						#Phc.#3hc(107244559)
					}));
				}
				return true;
			}
			return false;
		}

		// Token: 0x0600907A RID: 36986 RVA: 0x001E8D9C File Offset: 0x001E6F9C
		private int? #Qge(string #Rge)
		{
			SectionPolygon sectionPolygon = this.#TMc((#Rge != null) ? #Rge.Trim() : null);
			if (sectionPolygon == null)
			{
				this.#nb(#Phc.#3hc(107244554), (#Phc.#3hc(107244561) + #Rge + #Phc.#3hc(107245052)).#z2d());
				return null;
			}
			return new int?(sectionPolygon.Points.Count);
		}

		// Token: 0x0600907B RID: 36987 RVA: 0x001E8E08 File Offset: 0x001E7008
		private ReinforcementPatternInterop.MyPoint #Sge(string #Rge, int #Tge)
		{
			SectionPolygon sectionPolygon = this.#TMc((#Rge != null) ? #Rge.Trim() : null);
			if (sectionPolygon == null)
			{
				this.#nb(#Phc.#3hc(107245003), (#Phc.#3hc(107244561) + #Rge + #Phc.#3hc(107245052)).#z2d());
				return null;
			}
			Point point = sectionPolygon.Points.ElementAtOrDefault(#Tge);
			if (point == null)
			{
				this.#nb(#Phc.#3hc(107245003), string.Format(#Phc.#3hc(107245014), #Tge).#z2d());
				return null;
			}
			return new ReinforcementPatternInterop.MyPoint((double)point.X, (double)point.Y);
		}

		// Token: 0x0600907C RID: 36988 RVA: 0x001E8EAC File Offset: 0x001E70AC
		private void #Uge()
		{
			#Lge #Lge = new #Lge();
			this.#che(#Lge);
			if (!#Lge.Polygons.Any<SectionPolygon>())
			{
				return;
			}
			List<SectionPolygon> #BAb = #Lge.Polygons.Where(new Func<SectionPolygon, bool>(TemplateEvaluator.<>c.<>9.#Faf)).ToList<SectionPolygon>();
			List<SectionPolygon> #CAb = #Lge.Polygons.Where(new Func<SectionPolygon, bool>(TemplateEvaluator.<>c.<>9.#Gaf)).ToList<SectionPolygon>();
			Point3D point3D = SectionGeometryHelper.#gxc(#BAb, #CAb);
			if (point3D == null)
			{
				return;
			}
			point3D.X = -1.0 * point3D.X;
			point3D.Y = -1.0 * point3D.Y;
			this.#b.Execute(string.Concat(new string[]
			{
				#Phc.#3hc(107244937),
				point3D.X.ToString(CultureInfo.InvariantCulture),
				#Phc.#3hc(107376612),
				point3D.Y.ToString(CultureInfo.InvariantCulture),
				#Phc.#3hc(107244559)
			}));
		}

		// Token: 0x0600907D RID: 36989 RVA: 0x001E8FD4 File Offset: 0x001E71D4
		private double? #Vge(string #Wge, double #SGd, bool #Xge)
		{
			int? num = StandardBarsProvider.#vCb(#Wge);
			if (num == null)
			{
				this.#nb(#Phc.#3hc(107244952), (#Phc.#3hc(107244927) + #Wge + #Phc.#3hc(107244874)).#z2d());
				return null;
			}
			StandardBar standardBar = this.#d.#whe(num.Value);
			if (standardBar == null || standardBar.Area <= 0f)
			{
				this.#nb(#Phc.#3hc(107244952), (#Phc.#3hc(107244927) + #Wge + #Phc.#3hc(107244874)).#z2d());
				return null;
			}
			if (#Xge)
			{
				double num2 = CircleHelper.#wmc((double)standardBar.Area);
				return new double?(#SGd + num2);
			}
			return new double?(#SGd);
		}

		// Token: 0x0600907E RID: 36990 RVA: 0x001E90A8 File Offset: 0x001E72A8
		private ReinforcementPatternInterop.MyPoint #Yge(string #Rge, int #Tge, double #SGd)
		{
			TemplateEvaluator.#AZb #AZb = new TemplateEvaluator.#AZb();
			SectionPolygon sectionPolygon = this.#TMc((#Rge != null) ? #Rge.Trim() : null);
			if (sectionPolygon == null)
			{
				this.#nb(#Phc.#3hc(107244889), (#Phc.#3hc(107244561) + #Rge + #Phc.#3hc(107245052)).#z2d());
				return null;
			}
			Point point = sectionPolygon.Points.ElementAtOrDefault(#Tge);
			if (point == null)
			{
				this.#nb(#Phc.#3hc(107244889), string.Format(#Phc.#3hc(107245014), #Tge).#z2d());
				return null;
			}
			#AZb.#a = new Point3D((double)point.X, (double)point.Y);
			bool #vP = sectionPolygon.Application == PolygonApplication.Solid;
			var <>f__AnonymousType = ReinforcementPatternHelper.#qP(sectionPolygon, #SGd, #vP).Select(new Func<Point3D, <>f__AnonymousType1<double, Point3D>>(#AZb.#Raf)).OrderBy(new Func<<>f__AnonymousType1<double, Point3D>, double>(TemplateEvaluator.<>c.<>9.#Haf)).FirstOrDefault();
			if (<>f__AnonymousType == null)
			{
				return null;
			}
			return new ReinforcementPatternInterop.MyPoint(<>f__AnonymousType.Point.X, <>f__AnonymousType.Point.Y);
		}

		// Token: 0x0600907F RID: 36991 RVA: 0x001E91C8 File Offset: 0x001E73C8
		private string #Zge(string #Wge, double #NP, int[] #0ge)
		{
			List<string> list = #0ge.Where(new Func<int, bool>(TemplateEvaluator.<>c.<>9.#Iaf)).Select(new Func<int, string>(TemplateEvaluator.<>c.<>9.#Jaf)).ToList<string>();
			string str = string.Empty;
			if (list.Count == 1)
			{
				str = list[0];
			}
			else if (list.Count > 0)
			{
				str = #Phc.#3hc(107413142) + string.Join(#Phc.#3hc(107244840), list) + #Phc.#3hc(107382694);
			}
			#Wge = (((#Wge != null) ? #Wge.Trim() : null) ?? string.Empty);
			if (string.Equals(#Wge, #Phc.#3hc(107426661), StringComparison.Ordinal))
			{
				#Wge = string.Empty;
			}
			else if (!#Wge.StartsWith(#Phc.#3hc(107378801)))
			{
				#Wge = #Phc.#3hc(107378801) + #Wge;
			}
			string format = (this.#e() == UnitSystem.SIMetric) ? #Phc.#3hc(107383605) : #Phc.#3hc(107362056);
			if (#NP != 0.0)
			{
				return str + #Wge + #Phc.#3hc(107224244) + #NP.ToString(format, CultureInfo.CurrentCulture);
			}
			return str + #Wge;
		}

		// Token: 0x06009080 RID: 36992 RVA: 0x001E9320 File Offset: 0x001E7520
		private void #1ge()
		{
			if (this.#q)
			{
				return;
			}
			this.#q = true;
			this.#b.SetValue(#Phc.#3hc(107244835), new Func<double, double, double, double, double, ReinforcementPatternInterop.MyPoint[]>(ReinforcementPatternInterop.#Ufe));
			this.#b.SetValue(#Phc.#3hc(107244822), new Func<double, double, double, double, double, ReinforcementPatternInterop.MyPoint[]>(ReinforcementPatternInterop.#Vfe));
			this.#b.SetValue(#Phc.#3hc(107244233), new Func<double, double, double, double, double, ReinforcementPatternInterop.MyPoint[]>(ReinforcementPatternInterop.#Wfe));
			this.#b.SetValue(#Phc.#3hc(107244220), new Func<double, double, double, double, double, ReinforcementPatternInterop.MyPoint[]>(ReinforcementPatternInterop.#cge));
			this.#b.SetValue(#Phc.#3hc(107244143), new Func<double, double, double, double, double, double, ReinforcementPatternInterop.MyPoint[]>(ReinforcementPatternInterop.#dge));
			this.#b.SetValue(#Phc.#3hc(107244102), new Func<double, double, double, double, double, double, ReinforcementPatternInterop.MyPoint[]>(ReinforcementPatternInterop.#gge));
			this.#b.SetValue(#Phc.#3hc(107244089), new Func<double, double, double, double, double, double, bool, ReinforcementPatternInterop.MyPoint[]>(ReinforcementPatternInterop.#jge));
			this.#b.SetValue(#Phc.#3hc(107244048), new Func<double, double, double, double, double, double, bool, ReinforcementPatternInterop.MyPoint[]>(ReinforcementPatternInterop.#kge));
			this.#b.SetValue(#Phc.#3hc(107244483), new Func<double, double, double, double, double, double, ReinforcementPatternInterop.MyPoint[]>(ReinforcementPatternInterop.#lge));
			this.#b.SetValue(#Phc.#3hc(107244474), new Func<double, double, double, double, double, double, ReinforcementPatternInterop.MyPoint[]>(ReinforcementPatternInterop.#mge));
			this.#b.SetValue(#Phc.#3hc(107244433), new Func<int, int, double, double, double, int, double, double, bool, bool, bool, ReinforcementPatternInterop.MyPoint[]>(ReinforcementPatternInterop.#Xfe));
			this.#b.SetValue(#Phc.#3hc(107244408), new Func<int, double, double, double, double, double, double, double, bool, bool, ReinforcementPatternInterop.MyPoint[]>(ReinforcementPatternInterop.#8fe));
			this.#b.SetValue(#Phc.#3hc(107244379), new Func<double, double, double, double, double, ReinforcementPatternInterop.MyPoint[]>(ReinforcementPatternInterop.#nge));
			this.#b.SetValue(#Phc.#3hc(107244350), new Func<int, int, double, double, double, double, bool, bool, bool, bool, bool, ReinforcementPatternInterop.MyPoint[]>(ReinforcementPatternInterop.#Mfe));
			this.#b.SetValue(#Phc.#3hc(107244289), new Func<string, int, double, ReinforcementPatternInterop.MyPoint>(this.#Yge));
			this.#b.SetValue(#Phc.#3hc(107243748), new Func<string, int, ReinforcementPatternInterop.MyPoint>(this.#Sge));
			this.#b.SetValue(#Phc.#3hc(107243719), new Func<string, int?>(this.#Qge));
			this.#b.SetValue(#Phc.#3hc(107243710), new Func<bool>(this.#Pge));
			this.#b.SetValue(#Phc.#3hc(107244952), new Func<string, double, bool, double?>(this.#Vge));
			this.#b.SetValue(#Phc.#3hc(107243661), new Action(this.#Uge));
			this.#b.SetValue(#Phc.#3hc(107243672), new Func<string, double, int[], string>(this.#Zge));
			foreach (string source in new List<string>
			{
				#Phc.#3hc(107243647),
				#Phc.#3hc(107241133),
				#Phc.#3hc(107240503),
				#Phc.#3hc(107325873),
				#Phc.#3hc(107324871),
				#Phc.#3hc(107323661),
				#Phc.#3hc(107320327),
				#Phc.#3hc(107340613),
				#Phc.#3hc(107338567),
				#Phc.#3hc(107336913),
				#Phc.#3hc(107335627)
			})
			{
				this.#b.Execute(source);
			}
		}

		// Token: 0x06009081 RID: 36993 RVA: 0x001E976C File Offset: 0x001E796C
		public EvaluatedReinforcementBar #2ge(JsValue #f)
		{
			if (this.#ohe(#f) || !#f.IsObject())
			{
				return null;
			}
			return new EvaluatedReinforcementBar
			{
				X = this.#wpb(#f, #Phc.#3hc(107380695), true),
				Y = this.#wpb(#f, #Phc.#3hc(107427359), true),
				BarSize = this.#Qhc(#f, #Phc.#3hc(107334229), false),
				Area = this.#lhe(#f, #Phc.#3hc(107370266)),
				Color = (int)((long)this.#wpb(#f, #Phc.#3hc(107418837), true))
			};
		}

		// Token: 0x06009082 RID: 36994 RVA: 0x001E980C File Offset: 0x001E7A0C
		private #Lfe #3ge(JsValue #f)
		{
			if (this.#ohe(#f) || !#f.IsObject())
			{
				return null;
			}
			return new #Lfe
			{
				StartPoint = new Point(this.#wpb(#f, #Phc.#3hc(107334188), true), this.#wpb(#f, #Phc.#3hc(107334179), true)),
				EndPoint = new Point(this.#wpb(#f, #Phc.#3hc(107334202), true), this.#wpb(#f, #Phc.#3hc(107334193), true)),
				Order = (int)this.#wpb(#f, #Phc.#3hc(107334152), true),
				Text = this.#Qhc(#f, #Phc.#3hc(107453475), true),
				Side = (#Ffe)this.#wpb(#f, #Phc.#3hc(107334175), true)
			};
		}

		// Token: 0x06009083 RID: 36995 RVA: 0x001E98DC File Offset: 0x001E7ADC
		private void #4ge(#Lge #PE)
		{
			JsValue value = this.#b.GetValue(#Phc.#3hc(107399786));
			if (this.#ohe(value))
			{
				return;
			}
			#PE.DimTexts.AddRange(this.#mhe<#Lfe>(value, new Func<JsValue, #Lfe>(this.#3ge), new string[]
			{
				#Phc.#3hc(107334166)
			}));
		}

		// Token: 0x06009084 RID: 36996 RVA: 0x001E993C File Offset: 0x001E7B3C
		private void #5ge(#Lge #PE)
		{
			JsValue value = this.#b.GetValue(#Phc.#3hc(107399786));
			if (this.#ohe(value))
			{
				return;
			}
			#PE.Dimensions.AddRange(this.#mhe<DimensionData>(value, new Func<JsValue, DimensionData>(this.#7ge), new string[]
			{
				#Phc.#3hc(107334633)
			}));
		}

		// Token: 0x06009085 RID: 36997 RVA: 0x001E999C File Offset: 0x001E7B9C
		private DimensionStep #6ge(JsValue #f)
		{
			if (this.#ohe(#f))
			{
				return null;
			}
			double? num = this.#lhe(#f, null);
			if (num == null)
			{
				return new DimensionStep
				{
					Value = this.#wpb(#f, #Phc.#3hc(107386484), true),
					Text = this.#Qhc(#f, #Phc.#3hc(107453475), false)
				};
			}
			return new DimensionStep
			{
				Value = num.Value
			};
		}

		// Token: 0x06009086 RID: 36998 RVA: 0x001E9A10 File Offset: 0x001E7C10
		private DimensionData #7ge(JsValue #f)
		{
			if (this.#ohe(#f) || !#f.IsObject())
			{
				return null;
			}
			DimensionData dimensionData = new DimensionData
			{
				Start = new Point(this.#wpb(#f, #Phc.#3hc(107334188), true), this.#wpb(#f, #Phc.#3hc(107334179), true)),
				Orientation = new Point(this.#wpb(#f, #Phc.#3hc(107334648), true), this.#wpb(#f, #Phc.#3hc(107334599), true)),
				Order = Math.Min(Math.Max(this.#wpb(#f, #Phc.#3hc(107334152), true), 1.0), 10.0)
			};
			dimensionData.Steps.AddRange(this.#mhe<DimensionStep>(#f, new Func<JsValue, DimensionStep>(this.#6ge), new string[]
			{
				#Phc.#3hc(107334614)
			}).Where(new Func<DimensionStep, bool>(TemplateEvaluator.<>c.<>9.#Kaf)));
			return dimensionData;
		}

		// Token: 0x06009087 RID: 36999 RVA: 0x001E9B20 File Offset: 0x001E7D20
		private LeaderWithText #8ge(JsValue #f)
		{
			if (this.#ohe(#f) || !#f.IsObject())
			{
				return null;
			}
			return new LeaderWithText
			{
				LeaderType1 = (#Gge)this.#wpb(#f, #Phc.#3hc(107334573), true),
				LeaderType2 = (#Gge)this.#wpb(#f, #Phc.#3hc(107334588), true),
				BasePoint = new Point(this.#wpb(#f, #Phc.#3hc(107334539), true), this.#wpb(#f, #Phc.#3hc(107334530), true)),
				TargetPoint = new Point(this.#wpb(#f, #Phc.#3hc(107334553), true), this.#wpb(#f, #Phc.#3hc(107334544), true)),
				GroupName = this.#Qhc(#f, #Phc.#3hc(107454447), true),
				Line1 = this.#Qhc(#f, #Phc.#3hc(107334503), true),
				Line2 = this.#Qhc(#f, #Phc.#3hc(107334526), true),
				Order = (int)this.#wpb(#f, #Phc.#3hc(107334152), true)
			};
		}

		// Token: 0x06009088 RID: 37000 RVA: 0x001E9C38 File Offset: 0x001E7E38
		private SectionPolygon #TMc(string #4jb)
		{
			this.#b.Execute(#Phc.#3hc(107334517) + #4jb + #Phc.#3hc(107244559));
			JsValue completionValue = this.#b.GetCompletionValue();
			return this.#fhe(completionValue);
		}

		// Token: 0x06009089 RID: 37001 RVA: 0x001E9C80 File Offset: 0x001E7E80
		private #5he #9ge(JsValue #f)
		{
			if (this.#ohe(#f) || !#f.IsObject())
			{
				return null;
			}
			return new #5he
			{
				Text = this.#Qhc(#f, #Phc.#3hc(107453475), true),
				Alignment = (#7he)this.#wpb(#f, #Phc.#3hc(107252649), true),
				Start = new Point(this.#wpb(#f, #Phc.#3hc(107334188), true), this.#wpb(#f, #Phc.#3hc(107334179), true)),
				End = new Point(this.#wpb(#f, #Phc.#3hc(107334202), true), this.#wpb(#f, #Phc.#3hc(107334193), true))
			};
		}

		// Token: 0x0600908A RID: 37002 RVA: 0x001E9D34 File Offset: 0x001E7F34
		private void #ahe(#Lge #PE)
		{
			JsValue value = this.#b.GetValue(#Phc.#3hc(107399786));
			if (this.#ohe(value))
			{
				return;
			}
			#PE.ShapeLabels.AddRange(this.#mhe<#5he>(value, new Func<JsValue, #5he>(this.#9ge), new string[]
			{
				#Phc.#3hc(107334468)
			}));
		}

		// Token: 0x0600908B RID: 37003 RVA: 0x001E9D94 File Offset: 0x001E7F94
		private void #bhe(#Lge #PE)
		{
			JsValue value = this.#b.GetValue(#Phc.#3hc(107399786));
			if (this.#ohe(value))
			{
				return;
			}
			#PE.Texts.AddRange(this.#mhe<LeaderWithText>(value, new Func<JsValue, LeaderWithText>(this.#8ge), new string[]
			{
				#Phc.#3hc(107334483)
			}).Where(new Func<LeaderWithText, bool>(TemplateEvaluator.<>c.<>9.#Laf)));
		}

		// Token: 0x0600908C RID: 37004 RVA: 0x001E9E18 File Offset: 0x001E8018
		private void #che(#Lge #PE)
		{
			JsValue value = this.#b.GetValue(#Phc.#3hc(107399786));
			if (this.#ohe(value))
			{
				return;
			}
			#PE.Polygons.AddRange(this.#mhe<SectionPolygon>(value, new Func<JsValue, SectionPolygon>(this.#fhe), new string[]
			{
				#Phc.#3hc(107372113)
			}).Where(new Func<SectionPolygon, bool>(TemplateEvaluator.<>c.<>9.#Maf)));
			#PE.ColoredZones.AddRange(this.#mhe<SectionPolygon>(value, new Func<JsValue, SectionPolygon>(this.#fhe), new string[]
			{
				#Phc.#3hc(107334438)
			}).Where(new Func<SectionPolygon, bool>(TemplateEvaluator.<>c.<>9.#Naf)));
		}

		// Token: 0x0600908D RID: 37005 RVA: 0x001E9EF0 File Offset: 0x001E80F0
		private void #dhe(#Lge #PE)
		{
			JsValue value = this.#b.GetValue(#Phc.#3hc(107399786));
			if (this.#ohe(value))
			{
				return;
			}
			#PE.Bars.AddRange(this.#mhe<EvaluatedReinforcementBar>(value, new Func<JsValue, EvaluatedReinforcementBar>(this.#2ge), new string[]
			{
				#Phc.#3hc(107334453)
			}).Where(new Func<EvaluatedReinforcementBar, bool>(TemplateEvaluator.<>c.<>9.#Oaf)));
		}

		// Token: 0x0600908E RID: 37006 RVA: 0x00074AE0 File Offset: 0x00072CE0
		private Point #ehe(JsValue #f)
		{
			if (this.#ohe(#f) || !#f.IsObject())
			{
				return null;
			}
			return new Point(this.#wpb(#f, #Phc.#3hc(107380695), true), this.#wpb(#f, #Phc.#3hc(107427359), true));
		}

		// Token: 0x0600908F RID: 37007 RVA: 0x001E9F74 File Offset: 0x001E8174
		private SectionPolygon #fhe(JsValue #f)
		{
			if (this.#ohe(#f) || !#f.IsObject())
			{
				return null;
			}
			SectionPolygon sectionPolygon = new SectionPolygon
			{
				Id = (int)this.#wpb(#f, #Phc.#3hc(107334412), false),
				Application = (this.#jhe(#f, #Phc.#3hc(107334407), false) ? PolygonApplication.Opening : PolygonApplication.Solid),
				FigureType = PolygonFigureType.Irregural
			};
			sectionPolygon.Points.AddRange(this.#mhe<Point>(#f, new Func<JsValue, Point>(this.#ehe), new string[]
			{
				#Phc.#3hc(107358670)
			}));
			return sectionPolygon;
		}

		// Token: 0x06009090 RID: 37008 RVA: 0x001EA00C File Offset: 0x001E820C
		private TemplateMessage #ghe(JsValue #f)
		{
			if (this.#ohe(#f) || !#f.IsObject())
			{
				return null;
			}
			return new TemplateMessage
			{
				Function = this.#Qhc(#f, #Phc.#3hc(107334426), false),
				Message = this.#Qhc(#f, #Phc.#3hc(107415909), false)
			};
		}

		// Token: 0x06009091 RID: 37009 RVA: 0x001EA064 File Offset: 0x001E8264
		private void #hhe(#Lge #PE)
		{
			JsValue value = this.#b.GetValue(#Phc.#3hc(107399786));
			if (this.#ohe(value))
			{
				return;
			}
			#PE.DebugMesages.AddRange(this.#mhe<TemplateMessage>(value, new Func<JsValue, TemplateMessage>(this.#ghe), new string[]
			{
				#Phc.#3hc(107333869)
			}).Where(new Func<TemplateMessage, bool>(TemplateEvaluator.<>c.<>9.#Paf)));
		}

		// Token: 0x06009092 RID: 37010 RVA: 0x001EA0E8 File Offset: 0x001E82E8
		private void #ihe(#Lge #PE)
		{
			JsValue value = this.#b.GetValue(#Phc.#3hc(107399786));
			if (this.#ohe(value))
			{
				return;
			}
			#PE.Errors.AddRange(this.#mhe<TemplateMessage>(value, new Func<JsValue, TemplateMessage>(this.#ghe), new string[]
			{
				#Phc.#3hc(107333880)
			}).Where(new Func<TemplateMessage, bool>(TemplateEvaluator.<>c.<>9.#Qaf)));
		}

		// Token: 0x06009093 RID: 37011 RVA: 0x001EA16C File Offset: 0x001E836C
		private bool #jhe(JsValue #f, string #z8c, bool #khe = true)
		{
			#f = this.#E(#f, #z8c, #khe);
			if (!this.#ohe(#f) && #f.IsBoolean())
			{
				return #f.AsBoolean();
			}
			if (#khe)
			{
				throw new TemplateEvaluatorException(#Phc.#3hc(107333827) + #z8c + #Phc.#3hc(107348305));
			}
			return false;
		}

		// Token: 0x06009094 RID: 37012 RVA: 0x001EA1C4 File Offset: 0x001E83C4
		private JsValue #E(JsValue #f, string #z8c, bool #khe = true)
		{
			if (!this.#ohe(#f) && #f.IsObject())
			{
				return #f.AsObject().Get(#z8c);
			}
			if (#khe)
			{
				throw new TemplateEvaluatorException((#Phc.#3hc(107416733) + #z8c + #Phc.#3hc(107244874)).#z2d());
			}
			return JsValue.Null;
		}

		// Token: 0x06009095 RID: 37013 RVA: 0x001EA224 File Offset: 0x001E8424
		private double #wpb(JsValue #f, string #z8c, bool #khe = true)
		{
			if (!string.IsNullOrWhiteSpace(#z8c))
			{
				#f = this.#E(#f, #z8c, #khe);
			}
			if (!this.#ohe(#f) && #f.IsNumber())
			{
				return #f.AsNumber();
			}
			if (#khe)
			{
				throw new TemplateEvaluatorException(#Phc.#3hc(107333810) + #z8c + #Phc.#3hc(107348305));
			}
			return 0.0;
		}

		// Token: 0x06009096 RID: 37014 RVA: 0x001EA28C File Offset: 0x001E848C
		private double? #lhe(JsValue #f, string #z8c)
		{
			if (!string.IsNullOrWhiteSpace(#z8c))
			{
				#f = this.#E(#f, #z8c, false);
			}
			if (!this.#ohe(#f) && #f.IsNumber())
			{
				return new double?(#f.AsNumber());
			}
			return null;
		}

		// Token: 0x06009097 RID: 37015 RVA: 0x001EA2D8 File Offset: 0x001E84D8
		private string #Qhc(JsValue #f, string #z8c, bool #khe = true)
		{
			#f = this.#E(#f, #z8c, #khe);
			if (!this.#ohe(#f))
			{
				if (#f.IsString())
				{
					return #f.AsString();
				}
				return #f.ToString();
			}
			else
			{
				if (#khe)
				{
					throw new TemplateEvaluatorException(#Phc.#3hc(107333729) + #z8c + #Phc.#3hc(107348305));
				}
				return null;
			}
		}

		// Token: 0x06009098 RID: 37016 RVA: 0x001EA338 File Offset: 0x001E8538
		private IList<#Fu> #mhe<#Fu>(JsValue #f, Func<JsValue, #Fu> #nhe, params string[] #So)
		{
			foreach (string value in #So)
			{
				if (!this.#ohe(#f) && #f.IsObject())
				{
					#f = #f.AsObject().Get(value);
				}
			}
			List<#Fu> list = new List<!!0>();
			if (!this.#ohe(#f) && #f.IsArray())
			{
				foreach (JsValue arg in #f.AsArray())
				{
					list.Add(#nhe(arg));
				}
			}
			return list;
		}

		// Token: 0x06009099 RID: 37017 RVA: 0x00074B1E File Offset: 0x00072D1E
		private bool #ohe(JsValue #f)
		{
			return #f == null || #f is JsNull || #f is JsUndefined;
		}

		// Token: 0x0600909A RID: 37018 RVA: 0x00074B3C File Offset: 0x00072D3C
		[CompilerGenerated]
		private void #phe(string #5)
		{
			this.#nb(#Phc.#3hc(107243710), #5);
		}

		// Token: 0x04003CAB RID: 15531
		private const string #a = "model";

		// Token: 0x04003CAC RID: 15532
		private readonly Engine #b;

		// Token: 0x04003CAD RID: 15533
		private readonly string #c = #Phc.#3hc(107245553);

		// Token: 0x04003CAE RID: 15534
		private readonly StandardBarsProvider #d;

		// Token: 0x04003CAF RID: 15535
		private readonly Func<UnitSystem> #e;

		// Token: 0x04003CB0 RID: 15536
		private const string #f = "\r\nvar baseX = 0.0;\r\nvar baseY = 0.0;\r\n\r\nconst OPENING = 0;\r\nconst SOLID = 1;\r\nconst COLORED_ZONE = 2;\r\n\r\nconst BY_SPACING = 0;\r\nconst BY_NUMBER = 1;\r\n\r\nconst LEADER_REGULAR = 0;\r\nconst LEADER_VERTICAL = 1;\r\nconst LEADER_HORIZONTAL = 2;\r\n\r\nconst ALIGN_CENTER = 0;\r\nconst ALIGN_LEFT = 1;\r\nconst ALIGN_RIGHT = 2;\r\n\r\nconst TO_RIGHT = 0;\r\nconst TO_LEFT = 1;\r\nconst TO_TOP = 2;\r\nconst TO_BOTTOM = 3;\r\n\r\nconst BLUE = 0xFF0000FF;\r\nconst BLACK = 0xFF000000;\r\n\r\nconst DIM_TOP = 0;\r\nconst DIM_BOTTOM = 1;\r\n";

		// Token: 0x04003CB1 RID: 15537
		private const string #g = "\r\nfunction Point(x, y){\r\n\tthis.x = x || 0;\r\n\tthis.y = y || 0;\r\n};\r\nPoint.prototype.x = null;\r\nPoint.prototype.y = null;\r\nPoint.prototype.add = function(v){\r\n\treturn new Point(this.x + v.x, this.y + v.y);\r\n};\r\nPoint.prototype.clone = function(){\r\n\treturn new Point(this.x, this.y);\r\n};\r\nPoint.prototype.degreesTo = function(v){\r\n\tvar dx = this.x - v.x;\r\n\tvar dy = this.y - v.y;\r\n\tvar angle = Math.atan2(dy, dx); // radians\r\n\treturn angle * (180 / Math.PI); // degrees\r\n};\r\nPoint.prototype.distance = function(v){\r\n\tvar x = this.x - v.x;\r\n\tvar y = this.y - v.y;\r\n\treturn Math.sqrt(x * x + y * y);\r\n};\r\nPoint.prototype.equals = function(toCompare){\r\n\treturn this.x == toCompare.x && this.y == toCompare.y;\r\n};\r\nPoint.prototype.interpolate = function(v, f){\r\n\treturn new Point( v.x + (this.x - v.x) * f, v.y + (this.y - v.y) * f );\r\n};\r\nPoint.prototype.length = function(){\r\n\treturn Math.sqrt(this.x * this.x + this.y * this.y);\r\n};\r\nPoint.prototype.normalize = function(thickness){\r\n\tvar l = this.length();\r\n\tthis.x = this.x / l * thickness;\r\n\tthis.y = this.y / l * thickness;\r\n};\r\nPoint.prototype.orbit = function(origin, arcWidth, arcHeight, degrees){\r\n\tvar radians = degrees * (Math.PI / 180);\r\n\tthis.x = origin.x + arcWidth * Math.cos(radians);\r\n\tthis.y = origin.y + arcHeight * Math.sin(radians);\r\n};\r\nPoint.prototype.offset = function(dx, dy){\r\n\tthis.x += dx;\r\n\tthis.y += dy;\r\n};\r\n\r\nPoint.prototype.subtract = function(v){\r\n\treturn new Point(this.x - v.x, this.y - v.y);\r\n};\r\n\r\n    Point.interpolate = function(pt1, pt2, f)\r\n    {\r\n    return pt1.interpolate(pt2, f);\r\n    };\r\n    Point.polar = function(len, angle)\r\n    {\r\n    return new Point(len * Math.cos(angle), len * Math.sin(angle));\r\n    };\r\n    Point.distance = function(pt1, pt2)\r\n    {\r\n    var x = pt1.x - pt2.x;\r\n    var y = pt1.y - pt2.y;\r\n        return Math.sqrt(x * x + y * y);\r\n    };\r\n";

		// Token: 0x04003CB2 RID: 15538
		private const string #h = "\r\nfunction apply_base_to_point(point)\r\n{\r\n    point.x = point.x + baseX;\r\n    point.y = point.y + baseY;\r\n\r\n    return point;\r\n}\r\n\r\nfunction apply_base_to_x(value)\r\n{\r\n    return value + baseX;\r\n}\r\n\r\nfunction apply_base_to_y(value)\r\n{\r\n    return value + baseY;\r\n}\r\n\r\n\r\nfunction apply_base_to_points(points)\r\n{\r\n    for (var i = 0; i < points.length; i++)\r\n    {\r\n        point = points[i];\r\n\r\n        point.x = point.x + baseX;\r\n        point.y = point.y + baseY;\r\n\r\n        points[i] = point;\r\n    }    \r\n\r\n    return points;\r\n}\r\n\r\nfunction Internal_FromInteropPoints(interopPoints, keepFirst, keepLast)\r\n{\r\n    var startIndex = keepFirst? 0 : 1;\r\n    var endIndex = keepLast? interopPoints.length : interopPoints.length - 1;\r\n\r\n    var points = [];\r\n\r\n    for (var index = startIndex; index < endIndex; index++)\r\n    {\r\n        points.push({ x: interopPoints[index].x, y: interopPoints[index].y });\r\n    }\r\n\r\n    return points;    \r\n}\r\n\r\nfunction Internal_PointsToBars(points, size)\r\n{\r\n    var bars = [];\r\n\r\n    for (var index = 0; index < points.length; index++)\r\n    {\r\n        bars.push({ x: points[index].x, y: points[index].y, size: size, color: barsColor });        \r\n    }\r\n\r\n    return bars;\r\n}\r\n\r\nfunction SetBase(basePoint)\r\n{\r\n    if (!ValidatePoint('SetBase', 'basePoint', basePoint)) return false;\r\n    baseX = basePoint.x;\r\n    baseY = basePoint.y;\r\n\r\n    return 0;\r\n}\r\n\r\nfunction ResetBase()\r\n{\r\n    baseX = 0.0;\r\n    baseY = 0.0;\r\n}\r\n\r\nfunction AddShape(id, type, points)\r\n{\r\n    if (type == COLORED_ZONE)\r\n    {\r\n        model.coloredZones.push({\r\n            id: id,\r\n            isOpening: false,\r\n            points: points\r\n        });\r\n\r\n    } else\r\n    {\r\n        model.shapes.push({\r\n            id: id,\r\n            isOpening: type == OPENING,\r\n            points: points\r\n        });\r\n    }    \r\n}\r\n\r\nfunction LogError(fun, message)\r\n{\r\n    model.errorMessages.push({function: fun, message: message});\r\n}\r\n\r\nfunction LogDebug(message)\r\n{\r\n    model.debugMessages.push({function:\"\", message: message});\r\n}\r\n\r\nfunction ERROR(message)\r\n{\r\n    LogError('', message);\r\n}\r\n\r\nfunction DEBUG(message)\r\n{\r\n    LogDebug(message);\r\n}\r\n\r\n\r\nfunction Internal_AddShape(id, type, ...coordinates)\r\n{\r\n    var coords =  [...coordinates];\r\n    var points = [];\r\n\r\n    for (var index = 0; index < coords.length; index += 2)\r\n    {\r\n        points.push({ x: coords[index], y: coords[index + 1] });\r\n    }\r\n\r\n    AddShape(id, type, points);\r\n}\r\n\r\nfunction isNumeric(num){\r\n\r\n    return typeof num==='number' && !isNaN(num);\r\n}\r\n\r\nfunction ValidateBarPlacement(fun, value)\r\n{\r\n    if (value != BY_SPACING && value != BY_NUMBER)\r\n    {   \r\n        LogError(fun, 'Bars placement must be BY_NUMER or BY_SPACING');\r\n        return false;\r\n    }\r\n\r\n    return true;\r\n}\r\n\r\nfunction ValidateAlignment(fun, value)\r\n{\r\n    if (value != ALIGN_CENTER && value != ALIGN_LEFT && value != ALIGN_RIGHT)\r\n    {   \r\n        LogError(fun, 'Alignment must be ALIGN_CENTER, ALIGN_LEFT or ALIGN_RIGHT');\r\n        return false;\r\n    }\r\n\r\n    return true;\r\n}\r\n\r\nfunction ValidatedBarPlacementValue(fun, placementType, value)\r\n{\r\n    if (placementType == BY_SPACING)\r\n    {\r\n        if (!isNumeric(value))\r\n        {\r\n            LogError(fun, 'Bar spacing must be a valid number.');\r\n            return false;\r\n        }\r\n    }\r\n    else if (placementType == BY_NUMBER)\r\n    {\r\n        if (!isNumeric(value))\r\n        {\r\n            LogError(fun, 'Bar number must be a valid number.');\r\n            return false;\r\n        }\r\n    }\r\n\r\n    return true;\r\n}\r\n\r\nfunction ValidateShapeType(fun, value)\r\n{\r\n    if (value != OPENING && value != SOLID && value != COLORED_ZONE)\r\n    {\r\n        LogError(fun, 'Shape type must be SOLID, OPENING or COLORED_ZONE.');\r\n        return false;\r\n    }\r\n\r\n    return true;\r\n}\r\n\r\nfunction ValidateShapeId(fun, value)\r\n{\r\n    if (!isNumeric(value))\r\n    {\r\n        LogError(fun, 'Shape ID must be a valid number.');\r\n        return false;\r\n    }\r\n\r\n    return true;\r\n}\r\n\r\nfunction ValidateCoordinate(fun, name, value)\r\n{\r\n    if (!isNumeric(value))\r\n    {   \r\n        LogError(fun, name + ' must be a valid number.');\r\n        return false;\r\n    }\r\n\r\n    return true;\r\n}\r\n\r\nfunction ValidatePoint(fun, name, point)\r\n{\r\n    if (point == undefined || point == null)\r\n    {\r\n        LogError(fun, name + ' must be a valid point.')\r\n        return false;\r\n    }\r\n\r\n    if (!ValidateCoordinate(fun, name + '.x', point.x)) return false;\r\n    if (!ValidateCoordinate(fun, name + '.y', point.y)) return false;\r\n\r\n    return true;\r\n}\r\n\r\nfunction ValidateRange(fun, name, value, min, max, includeMin, includeMax)\r\n{\r\n    if (!isNumeric(value))\r\n    {   \r\n        LogError(fun, name + ' must be a valid number.');\r\n        return false;\r\n    }\r\n    \r\n    if (isNumeric(min))\r\n    {\r\n        if (includeMin && value < min)\r\n        {\r\n            LogError(fun, name + ' must be greater or equal to ' + min);\r\n            return false;\r\n        }\r\n\r\n        if (!includeMin && value <= min)\r\n        {\r\n            LogError(fun, name + ' must be greater than ' + min);\r\n            return false;\r\n        }\r\n    }\r\n\r\n\r\n    if (isNumeric(max))\r\n    {\r\n        if (includeMax && value > max)\r\n        {\r\n            LogError(fun, name + ' must be smaller or equal to ' + max);\r\n            return false;\r\n        }\r\n\r\n        if (!includeMax && value >= max)\r\n        {   \r\n            LogError(fun, name + 'must be smaller than ' + max);\r\n            return false;\r\n        }\r\n    }\r\n\r\n\r\n    return true;\r\n}\r\n\r\nfunction ValidateWallBarDirection(fun, name, value)\r\n{\r\n    if (value != TO_RIGHT && value != TO_LEFT && value != TO_BOTTOM && value != TO_TOP)\r\n    {\r\n        LogError(fun, name + ' must be equal to TO_RIGHT, TO_LEFT, TO_TOP or TO_BOTTOM');\r\n        return false;\r\n    }\r\n\r\n    return true;\r\n}\r\n\r\nfunction ValidateLeaderType(fun, type)\r\n{\r\n    if (type != LEADER_REGULAR && type != LEADER_HORIZONTAL && type != LEADER_VERTICAL)\r\n    {\r\n        LogError(fun, 'Leader type must be LEADER_REGULAR or LEADER_HORIZONTAL or LEADER_VERTICAL');\r\n        return false;\r\n    }\r\n\r\n    return true;\r\n}\r\n\r\nfunction ValidateDimensionSide(fun, name, value)\r\n{\r\n    if (value != DIM_TOP && value != DIM_BOTTOM)\r\n    {\r\n        LogError(fun, name + ' must be DIM_BOTTOM or DIM_TOP');    \r\n        return false;\r\n    }\r\n\r\n    return true;\r\n}\r\n\r\nfunction ValidatePointsArray(fun, coords)\r\n{\r\n    if (coords == null || coords.length < 1)\r\n    {\r\n        LogError(fun, 'At least one point must be specified.');\r\n        return false;\r\n    }\r\n \r\n    for (var i = 0; i < coords.length; i++)\r\n    {\r\n        if (!ValidatePoint(fun, 'points', coords[i])) return false;        \r\n    }\r\n\r\n    return true;\r\n}\r\n\r\n\r\nfunction ValidateCoordinatesArray(fun, coords)\r\n{\r\n    if (coords == null || coords.length < 2)\r\n    {\r\n        LogError(fun, 'At least one coordinate must be specified.');\r\n        return false;\r\n    }\r\n\r\n    if (coords.length % 2 != 0)\r\n    {\r\n        LogError(fun, 'Number of coordinate values must be and even nmber.');\r\n        return false;\r\n    }\r\n\r\n    for (var i = 0; i < coords.length; i += 2)\r\n    {\r\n        if (!isNumeric(coords[i]))\r\n        {\r\n            LogError(fun, 'Coordinate - X must be a valid number.');\r\n            return false;\r\n        }\r\n\r\n        if (!isNumeric(coords[i + 1]))\r\n        {\r\n            LogError(fun, 'Coordinate - Y must be a valid number.');\r\n            return false;\r\n        }\r\n    }\r\n\r\n    return true;\r\n}\r\n\r\n\r\nfunction FindShape(id)\r\n{\r\n    for (var index = 0; index < model.shapes.length; index++)\r\n    {\r\n        var shape = model.shapes[index];\r\n\r\n        if (id.toString() == shape.id.toString())\r\n        {\r\n            return shape;\r\n        }\r\n    }\r\n\r\n    return null;\r\n}\r\n\r\nfunction Distance(x1, y1, x2, y2)\r\n{\r\n    return Math.sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));\r\n}\r\n\r\nfunction DistancePoint(p1, p2)\r\n{\r\n    return Math.sqrt((p2.x - p1.x) * (p2.x - p1.x) + (p2.y - p1.y) * (p2.y - p1.y));\r\n}\r\n\r\nfunction Translate(x, y)\r\n{\r\n    if (!ValidateCoordinate('Translate', 'X', x)) return false;    \r\n    if (!ValidateCoordinate('Translate', 'Y', y)) return false;    \r\n\r\n    for (var i = 0;  i < model.shapes.length;i++)\r\n    {\r\n        var shape = model.shapes[i];\r\n\r\n        for (var j = 0; j < shape.points.length; j++)\r\n        {\r\n            shape.points[j] = {\r\n                x: shape.points[j].x + x,\r\n                y: shape.points[j].y + y,\r\n            }\r\n        }\r\n    }\r\n\r\n    for (var i = 0;  i < model.coloredZones.length;i++)\r\n    {\r\n        var shape = model.coloredZones[i];\r\n\r\n        for (var j = 0; j < shape.points.length; j++)\r\n        {\r\n            shape.points[j] = {\r\n                x: shape.points[j].x + x,\r\n                y: shape.points[j].y + y,\r\n            }\r\n        }\r\n    }\r\n\r\n\r\n    for (var i = 0;  i < model.bars.length;i++)\r\n    {\r\n        model.bars[i].x += x;\r\n        model.bars[i].y += y;        \r\n    }\r\n\r\n    for (var i = 0; i< model.dimensions.length; i++)    \r\n    {\r\n        model.dimensions[i].startX += x;\r\n        model.dimensions[i].orientationX += x;\r\n\r\n        model.dimensions[i].startY += y;\r\n        model.dimensions[i].orientationY += y;\r\n    }\r\n\r\n    for (var i = 0; i< model.shapeLabels.length; i++)    \r\n    {\r\n        model.shapeLabels[i].startX += x;\r\n        model.shapeLabels[i].endX += x;\r\n\r\n        model.shapeLabels[i].startY += y;\r\n        model.shapeLabels[i].endY += y;\r\n    }\r\n\r\n    for (var i = 0; i< model.leaders.length; i++)    \r\n    {\r\n        model.leaders[i].baseX += x;\r\n        model.leaders[i].landX += x;\r\n\r\n        model.leaders[i].baseY += y;\r\n        model.leaders[i].landY += y;\r\n    }\r\n\r\n    for (var i = 0; i< model.dimTexts.length; i++)\r\n    {\r\n        model.dimTexts[i].startX += x;\r\n        model.dimTexts[i].endX += x;\r\n\r\n        model.dimTexts[i].startY += y;\r\n        model.dimTexts[i].endY += y;\r\n    }\r\n}\r\n\r\nfunction SetBarColor(color)\r\n{\r\n   barsColor = color;\r\n}\r\n\r\nfunction Internal_ApplyBarsColor(bars)\r\n{\r\n    for (var i = 0; i < bars.length; i++)\r\n    {\r\n        bars[i].color = barsColor;\r\n    }\r\n}\r\n";

		// Token: 0x04003CB3 RID: 15539
		private const string #i = "\r\nfunction AddRectangleShape(id, type, start, end)\r\n{\r\n    if (!ValidateShapeType('AddRectangleShape', type)) return false;\r\n    if (!ValidateShapeId('AddRectangleShape', id)) return false;\r\n    if (!ValidatePoint('AddRectangleShape', 'startPoint', start)) return false;\r\n    if (!ValidatePoint('AddRectangleShape', 'endPoint', end)) return false;\r\n\r\n    var points = [];\r\n   \r\n    points.push({ x: start.x, y: start.y });\r\n    points.push({ x: end.x, y: start.y });\r\n    points.push({ x: end.x, y: end.y });\r\n    points.push({ x: start.x, y: end.y });\r\n\r\n    // Point at [0];\r\n    points.push({ x: start.x, y: start.y });\r\n\r\n    points = apply_base_to_points(points);\r\n\r\n    AddShape(id, type, points);\r\n\r\n    return true;\r\n}";

		// Token: 0x04003CB4 RID: 15540
		private const string #j = "\r\nfunction AddCircleShape(id, type, centerPoint, radius)\r\n{\r\n    if (!ValidateShapeType('AddCircleShape', type)) return false;\r\n    if (!ValidateShapeId('AddCircleShape', id)) return false;    \r\n    if (!ValidateCoordinate('AddCircleShape', 'Radius', radius)) return false;    \r\n    if (!ValidatePoint('AddCircleShape', 'centerPoint', centerPoint)) return false;\r\n    \r\n    var count = 40;\r\n    var points = [];\r\n\r\n    var angle = 2.0 * Math.PI / count;\r\n\r\n    for  (var index = count - 1; index >= 0; index--)\r\n    {\r\n        var coordinateX = centerPoint.x + radius * Math.cos(index * angle);\r\n        var coordinateY = centerPoint.y + radius * Math.sin(index * angle);\r\n        \r\n        points.push({ x: coordinateX, y: coordinateY });\r\n    }\r\n\r\n    points.push({ x: points[0].x, y: points[0].y });\r\n\r\n    points = apply_base_to_points(points);\r\n    AddShape(id, type, points);\r\n\r\n    return true;\r\n}";

		// Token: 0x04003CB5 RID: 15541
		private const string #k = "\r\nfunction AddRegularPolygonShape(id, type, center, radius, noOfSides)\r\n{\r\n    if (!ValidateShapeType('AddRegularPolygonShape', type)) return false;\r\n    if (!ValidateShapeId('AddRegularPolygonShape', id)) return false;    \r\n    if (!ValidateCoordinate('AddRegularPolygonShape', 'Radius', radius)) return false;    \r\n    if (!ValidatePoint('AddRegularPolygonShape', 'centerPoint', center)) return false;\r\n    if (!ValidateCoordinate('AddRegularPolygonShape', 'NoOfSides', noOfSides)) return false;    \r\n    if (noOfSides < 3)\r\n    {\r\n        LogError(fun, 'NoOfSides must be greater or equalt to 3.');   \r\n        return false;\r\n    }\r\n\r\n    var count = noOfSides;\r\n    var points = [];\r\n\r\n    var angle = 2.0 * Math.PI / count;\r\n\r\n    for  (var index = count - 1; index >= 0; index--)\r\n    {\r\n        var coordinateX = center.x + radius * Math.cos(index * angle);\r\n        var coordinateY = center.y + radius * Math.sin(index * angle);\r\n        \r\n        points.push({ x: coordinateX, y: coordinateY });\r\n    }\r\n\r\n    points.push({ x: points[0].x, y: points[0].y });\r\n\r\n    points = apply_base_to_points(points);\r\n    AddShape(id, type, points);\r\n\r\n    return true;\r\n}\r\n\r\nfunction AddPolygonShape(id, type, start, ...coordinates)\r\n{\r\n    if (!ValidateShapeType('AddPolygonShape', type)) return false;\r\n    if (!ValidateShapeId('AddPolygonShape', id)) return false;\r\n    if (!ValidatePoint('AddPolygonShape', 'startPoint', start)) return false;\r\n   \r\n    var coords =  [...coordinates];\r\n\r\n    if (!ValidateCoordinatesArray('AddPolygonShape', coords)) return false;\r\n  \r\n    var points = [];\r\n\r\n    points.push({ x: start.x, y: start.y });\r\n\r\n    var currentX = start.x;\r\n    var currentY = start.y;\r\n        \r\n    for (var index = 0; index < coords.length; index += 2)\r\n    {\r\n        var x = coords[index];\r\n        var y = coords[index + 1];\r\n\r\n        currentX += x;\r\n        currentY += y;\r\n\r\n        points.push({ x: currentX, y: currentY });\r\n    }\r\n\r\n    points.push({ x: start.x, y: start.y });\r\n     \r\n\r\n    points = apply_base_to_points(points);\r\n    AddShape(id, type, points);\r\n\r\n    return true;\r\n}\r\n";

		// Token: 0x04003CB6 RID: 15542
		private const string #l = "\r\nfunction AddSectorShape(id, type, center, start, angle)\r\n{\r\n    if (!ValidateShapeType('AddSectorShape', type)) return false;\r\n    if (!ValidatePoint('AddPolygonShape', 'centerPoint', center)) return false;\r\n    if (!ValidatePoint('AddPolygonShape', 'startPoint', start)) return false;\r\n    if (!ValidateCoordinate('AddSectorShape', 'Angle', angle)) return false;\r\n    \r\n    var points = Interop_GetArcShape(center.x, center.y, start.x, start.y, angle);\r\n    points = apply_base_to_points(points);\r\n    AddShape(id, type, points);\r\n\r\n    return true;\r\n}\r\n\r\nfunction GetBarCenter(shapeId, vertexId, cover)\r\n{\r\n    if (!ValidateCoordinate('GetBarCenter', 'ShapeId', shapeId)) return false;\r\n    if (!ValidateCoordinate('GetBarCenter', 'VertexId', vertexId)) return false;\r\n    if (!ValidateCoordinate('GetBarCenter', 'Cover', cover)) return false;    \r\n\r\n    var point = Interop_GetBarCenter(shapeId, vertexId - 1, cover);\r\n\r\n    return point != null? { x: point.x, y: point.y } : null;\r\n}\r\n\r\nfunction GetShapeVertex(shapeId, vertexId)\r\n{\r\n    if (!ValidateCoordinate('GetShapeVertex', 'ShapeId', shapeId)) return null;\r\n    if (!ValidateCoordinate('GetShapeVertex', 'VertexId', vertexId)) return null;\r\n\r\n    var point = Interop_GetShapePoint(shapeId, vertexId - 1);\r\n\r\n    return point != null? { x: point.x, y: point.y } : null;\r\n}\r\n\r\nfunction GetNoOfShapeVertices(shapeId)\r\n{\r\n    if (!ValidateCoordinate('Interop_GetNoOfShapeVertices', 'ShapeId', shapeId)) return null;\r\n\r\n    return Interop_GetNoOfShapeVertices(shapeId);\r\n}\r\n";

		// Token: 0x04003CB7 RID: 15543
		private const string #m = "\r\nfunction AddSingleBar(size, insertPoint)\r\n{\r\n    if (!ValidatePoint('AddSingleBar', 'insertPoint', insertPoint)) return -1;\r\n\r\n    var myBars = { size: size, x: insertPoint.x, y: insertPoint.y, color: barsColor };\r\n    myBars = apply_base_to_point(myBars);\r\n    model.bars.push(myBars);\r\n\r\n    return 1;\r\n}\r\n\r\nfunction AddLinearBar(size, layoutType, value, startPoint, endPoint, keepFirst, keepLast)\r\n{\r\n    if (!ValidateBarPlacement('AddLinearBar', layoutType)) return -1;\r\n    if (!ValidatedBarPlacementValue('AddLinearBar', layoutType, value)) return -1;\r\n    if (!ValidatePoint('AddLinearBar', 'startPoint', startPoint)) return -1;\r\n    if (!ValidatePoint('AddLinearBar', 'endPoint', endPoint)) return -1;\r\n\r\n    var interopPoints = layoutType == BY_SPACING ? Interop_GetLinearPatternBySpacing(startPoint.x, startPoint.y, endPoint.x, endPoint.y, value) : Interop_GetLinearPatternByNumber(startPoint.x, startPoint.y, endPoint.x, endPoint.y, value);\r\n\r\n    var points = Internal_FromInteropPoints(interopPoints, keepFirst, keepLast);\r\n    points = apply_base_to_points(points);\r\n\r\n    var bars = Internal_PointsToBars(points, size);\r\n    Internal_ApplyBarsColor(bars);\r\n\r\n    model.bars.push(...bars);\r\n\r\n    return bars.length;\r\n}\r\n\r\nfunction AddMultiLineBar(size, layoutType, value, startPoint, ...coordinates)\r\n{\r\n    if (!ValidateBarPlacement('AddMultiLineBar', layoutType)) return -1;\r\n    if (!ValidatedBarPlacementValue('AddMultiLineBar', layoutType, value)) return -1;\r\n    if (!ValidatePoint('AddMultiLineBar', 'startPoint', startPoint)) return -1;\r\n        \r\n    var coords =  [...coordinates];\r\n    if (!ValidateCoordinatesArray('AddMultiLineBar', coords)) return -1;\r\n\r\n    var currentX = startPoint.x;\r\n    var currentY = startPoint.y;\r\n\r\n    var count = 0;\r\n\r\n    for (var index = 0; index < coords.length; index += 2)\r\n    {\r\n        var x = coords[index];\r\n        var y = coords[index + 1];\r\n\r\n        var previousX = currentX;\r\n        var previousY = currentY;\r\n\r\n        currentX += x;\r\n        currentY += y;\r\n\r\n        var isLast = index + 2 >= coords.length;\r\n\r\n        count += AddLinearBar(size, layoutType, value, new Point(previousX, previousY), new Point(currentX, currentY), true, isLast);\r\n    }\r\n\r\n    return count;\r\n}\r\n\r\nfunction AddCircleBar(size, layoutType, value, centerPoint, startPoint)\r\n{\r\n    if (!ValidateBarPlacement('AddCircleBar', layoutType)) return -1;\r\n    if (!ValidatedBarPlacementValue('AddCircleBar', layoutType, value)) return -1;\r\n    if (!ValidatePoint('AddGridBar', 'CenterPoint', centerPoint)) return -1;\r\n    if (!ValidatePoint('AddGridBar', 'StartPoint', startPoint)) return -1;\r\n\r\n    var interopPoints = layoutType == BY_SPACING ? Interop_GetCirclePatternBySpacing(centerPoint.x, centerPoint.y, startPoint.x, startPoint.y, value) \r\n                                                 : Interop_GetCirclePatternByNumber(centerPoint.x, centerPoint.y, startPoint.x, startPoint.y, value);\r\n\r\n    var points = Internal_FromInteropPoints(interopPoints, true, true);\r\n    points = apply_base_to_points(points);\r\n\r\n    var bars = Internal_PointsToBars(points, size);\r\n    Internal_ApplyBarsColor(bars);\r\n\r\n    model.bars.push(...bars);\r\n\r\n    return bars.length;\r\n}\r\n\r\nfunction AddGridBar(size, layoutType, valueX, valueY, startPoint, endPoint, isFilled)\r\n{\r\n    if (!ValidateBarPlacement('AddGridBar', layoutType)) return -1;\r\n    if (!ValidatedBarPlacementValue('AddGridBar', layoutType, valueX)) return -1;\r\n    if (!ValidatedBarPlacementValue('AddGridBar', layoutType, valueY)) return -1;\r\n    if (!ValidatePoint('AddGridBar', 'StartPoint', startPoint)) return -1;\r\n    if (!ValidatePoint('AddGridBar', 'EndPoint', endPoint)) return -1;\r\n\r\n    isFilled = (typeof isFilled !== 'undefined') ?  isFilled : true;\r\n\r\n    var interopPoints = layoutType == BY_SPACING ? Interop_GetGridPatternBySpacing(startPoint.x, startPoint.y, endPoint.x, endPoint.y, valueX, valueY, isFilled) :\r\n                                                   Interop_GetGridPatternByNumber(startPoint.x, startPoint.y, endPoint.x, endPoint.y, valueX, valueY, isFilled);\r\n\r\n    var points = Internal_FromInteropPoints(interopPoints, true, true);\r\n    points = apply_base_to_points(points);\r\n\r\n    var bars = Internal_PointsToBars(points, size);\r\n    Internal_ApplyBarsColor(bars);\r\n\r\n    model.bars.push(...bars);\r\n\r\n    return bars.length;\r\n}\r\n\r\nfunction AddRectBar(size, layoutType, valueX, valueY, startPoint, endPoint)\r\n{\r\n    if (!ValidateBarPlacement('AddRectBar', layoutType)) return -1;    \r\n    if (!ValidatedBarPlacementValue('AddRectBar', layoutType, valueX)) return -1;  \r\n    if (!ValidatedBarPlacementValue('AddRectBar', layoutType, valueY)) return -1;\r\n    if (!ValidatePoint('AddRectBar', 'StartPoint', startPoint)) return -1;\r\n    if (!ValidatePoint('AddRectBar', 'EndPoint', endPoint)) return -1;\r\n\r\n    var interopPoints = layoutType == BY_SPACING ? Interop_GetRectPatternBySpacing(startPoint.x, startPoint.y, endPoint.x, endPoint.y, valueX, valueY) :\r\n                                                   Interop_GetRectPatternByNumber(startPoint.x, startPoint.y, endPoint.x, endPoint.y, valueX, valueY);\r\n\r\n    var points = Internal_FromInteropPoints(interopPoints, true, true);\r\n    points = apply_base_to_points(points);\r\n\r\n    var bars = Internal_PointsToBars(points, size);\r\n    Internal_ApplyBarsColor(bars);\r\n\r\n    model.bars.push(...bars);\r\n\r\n    return bars.length;\r\n}\r\n\r\nfunction AddArcBar(size, layoutType, value, centerPoint, startPoint, angle, keepFirst, keepLast)\r\n{\r\n    if (!ValidateBarPlacement('AddArcBar', layoutType)) return -1;    \r\n    if (!ValidatedBarPlacementValue('AddArcBar', layoutType, value)) return -1;    \r\n    if (!ValidatePoint('AddArcBar', 'StartPoint', startPoint)) return -1;    \r\n    if (!ValidatePoint('AddArcBar', 'CenterPoint', centerPoint)) return -1;    \r\n\r\n    var interopPoints = layoutType == BY_SPACING ? Interop_GetArcPatternBySpacing(centerPoint.x, centerPoint.y, startPoint.x, startPoint.y, angle, value) :\r\n                                                   Interop_GetArcPatternByNumber(centerPoint.x, centerPoint.y, startPoint.x, startPoint.y, angle, value);\r\n\r\n    var points = Internal_FromInteropPoints(interopPoints, keepFirst, keepLast);\r\n    points = apply_base_to_points(points);\r\n\r\n    var bars = Internal_PointsToBars(points, size);\r\n    Internal_ApplyBarsColor(bars);\r\n\r\n    model.bars.push(...bars);\r\n\r\n    return bars.length;\r\n}\r\n\r\nfunction BarText(barSize, spacing, ...barValues)\r\n{    \r\n    if (!ValidateCoordinate('BarText', 'spacing', spacing)) return false;\r\n\r\n    var values = [...barValues];\r\n\r\n    return Internal_BarText(barSize, spacing, values);\r\n}\r\n\r\nfunction AddWallBar(size, noOfLayers, noOfRows, rawSpacing, startPoint, direction, sidePoint, keepFirst, keepLast, isFilled)\r\n{\r\n    if (!ValidateRange('AddWallBar', 'noOfLayers', noOfLayers, 1, null, true, true)) return -1;\r\n    if (!ValidateRange('AddWallBar', 'noOfRows', noOfRows, 1, null, true, true)) return -1;\r\n    if (!ValidatedBarPlacementValue('AddWallBar', BY_SPACING, rawSpacing)) return -1;    \r\n    if (!ValidatePoint('AddWallBar', 'startPoint', startPoint)) return -1;\r\n    if (!ValidatePoint('AddWallBar', 'sidePoint', sidePoint)) return -1;\r\n    if (!ValidateWallBarDirection('AddWallBar', 'direction', direction)) return -1;\r\n\r\n    isFilled = (typeof isFilled !== 'undefined') ?  isFilled : true;\r\n\r\n    var points = Interop_GetWallBar(noOfLayers, noOfRows, rawSpacing, startPoint.x, startPoint.y, direction, sidePoint.x, sidePoint.y, keepFirst, keepLast, isFilled);\r\n    points = apply_base_to_points(points);\r\n\r\n    var bars = Internal_PointsToBars(points, size);\r\n    Internal_ApplyBarsColor(bars);\r\n\r\n    model.bars.push(...bars);\r\n\r\n    return bars.length;\r\n}\r\n\r\nfunction AddFieldBar(size, noOfLayers, rowSpacing, startPoint, endPoint, sidePoint, keepFirst, keepLast)\r\n{\r\n    if (!ValidateRange('AddFieldBar', 'noOfLayers', noOfLayers, 1, null, true, true)) return -1;\r\n    if (!ValidatedBarPlacementValue('AddFieldBar', BY_SPACING, rowSpacing)) return -1;    \r\n    if (!ValidatePoint('AddFieldBar', 'startPoint', startPoint)) return -1;\r\n    if (!ValidatePoint('AddFieldBar', 'endPoint', endPoint)) return -1;\r\n    if (!ValidatePoint('AddFieldBar', 'sidePoint', sidePoint)) return -1;\r\n\r\n    //isFilled = (typeof isFilled !== 'undefined') ?  isFilled : true;\r\n\r\n    var points = Interop_GetFieldBar(noOfLayers, rowSpacing, startPoint.x, startPoint.y, endPoint.x, endPoint.y, sidePoint.x, sidePoint.y, keepFirst, keepLast);\r\n    points = apply_base_to_points(points);\r\n\r\n    var bars = Internal_PointsToBars(points, size);\r\n    Internal_ApplyBarsColor(bars);\r\n\r\n    model.bars.push(...bars);\r\n\r\n    return bars.length;\r\n}\r\n\r\nfunction POINT(x, y)\r\n{\r\n    if (!ValidateCoordinate('POINT', 'x', x)) return null;\r\n    if (!ValidateCoordinate('POINT', 'y', y)) return null;\r\n\r\n    return new Point(x,y);\r\n}\r\n\r\nfunction AddCornerBar(size, noOfRows, noOfColumns, startPoint, endPoint, isFilled, keepLeft, keepRight, keepTop, keepBottom)\r\n{\r\n    if (!ValidateRange('AddCornerBar', 'noOfRows', noOfRows, 1, null, true, true)) return -1;\r\n    if (!ValidateRange('AddCornerBar', 'noOfColumns', noOfColumns, 1, null, true, true)) return -1;\r\n    if (!ValidatePoint('AddCornerBar', 'startPoint', startPoint)) return -1;\r\n    if (!ValidatePoint('AddCornerBar', 'endPoint', endPoint)) return -1;\r\n\r\n    var points = Interop_GetCornerbar(noOfRows, noOfColumns, startPoint.x, startPoint.y, endPoint.x, endPoint.y, isFilled, keepLeft, keepRight, keepTop, keepBottom);\r\n    points = apply_base_to_points(points);\r\n\r\n    var bars = Internal_PointsToBars(points, size);\r\n    Internal_ApplyBarsColor(bars);\r\n\r\n    model.bars.push(...bars);\r\n\r\n    return bars.length;\r\n}\r\n";

		// Token: 0x04003CB8 RID: 15544
		private const string #n = "\r\nfunction AddLeader(basePoint, landPoint, leaderType1, leaderType2, line1, line2, groupName, order)\r\n{\r\n    if (!ValidatePoint('AddLeader', 'basePoint', basePoint)) return false;\r\n    if (!ValidatePoint('AddLeader', 'landPoint', landPoint)) return false;\r\n\r\n    if (!ValidateLeaderType('AddLeader', leaderType1)) return false;\r\n    if (!ValidateLeaderType('AddLeader', leaderType2)) return false;\r\n    if (!ValidateCoordinate('AddLeader', 'Order', order)) return false;    \r\n\r\n    basePoint = apply_base_to_point(basePoint);\r\n    landPoint = apply_base_to_point(landPoint);\r\n\r\n    model.leaders.push({\r\n    baseX: basePoint.x,\r\n    baseY: basePoint.y,\r\n    landX: landPoint.x,\r\n    landY: landPoint.y,\r\n    leaderType1: leaderType1,\r\n    leaderType2: leaderType2,\r\n    line1: line1,\r\n    line2: line2,\r\n    groupName: groupName,\r\n    order: order\r\n});\r\n\r\n    return true;\r\n}\r\n";

		// Token: 0x04003CB9 RID: 15545
		private const string #o = "\r\nfunction AddDimension(startPoint, orientationPoint, order, ...stops)\r\n{\r\n    if (!ValidatePoint('AddDimension', 'startPoint', startPoint)) return false;\r\n    if (!ValidatePoint('AddDimension', 'orientationPoint', orientationPoint)) return false;\r\n    if (!ValidateCoordinate('AddDimension', 'Order', order)) return false;    \r\n    \r\n    var stopsArray = [...stops];\r\n\r\n    startPoint = apply_base_to_point(startPoint);\r\n    orientationPoint = apply_base_to_point(orientationPoint);\r\n\r\n    model.dimensions.push({\r\n    startX: startPoint.x,\r\n    startY: startPoint.y,\r\n    orientationX: orientationPoint.x,\r\n    orientationY: orientationPoint.y,\r\n    order: order\r\n    stops: stopsArray\r\n});\r\n\r\n    return true;\r\n}\r\n\r\nfunction AddShapeLabel(startPoint, endPoint, alignment, text)\r\n{\r\n    if (!ValidatePoint('AddShapeLabel', 'startPoint', startPoint)) return false;\r\n    if (!ValidatePoint('AddShapeLabel', 'endPoint', endPoint)) return false;\r\n    if (!ValidateAlignment('AddShapeLabel', alignment)) return false;    \r\n\r\n    startPoint = apply_base_to_point(startPoint);\r\n    endPoint = apply_base_to_point(endPoint);\r\n\r\n    model.shapeLabels.push({\r\n    startX: startPoint.x,\r\n    startY: startPoint.y,\r\n    endX: endPoint.x,\r\n    endY: endPoint.y,\r\n    alignment: alignment,\r\n    text: text\r\n});\r\n\r\n    return true;\r\n}\r\n";

		// Token: 0x04003CBA RID: 15546
		private const string #p = "\r\nfunction AddDimText(text, startPoint, endPoint, side, order)\r\n{\r\n    if (!ValidatePoint('AddDimText', 'startPoint', startPoint)) return false;\r\n    if (!ValidatePoint('AddDimText', 'endPoint', endPoint)) return false;\r\n    if (!ValidateCoordinate('AddDimText', 'Order', order)) return false;    \r\n    if (!ValidateDimensionSide('AddDimText', 'Side', side)) return false;\r\n\r\n    startPoint = apply_base_to_point(startPoint);\r\n    endPoint = apply_base_to_point(endPoint);\r\n\r\n    model.dimTexts.push({\r\n    text: text,\r\n    startX: startPoint.x,\r\n    startY: startPoint.y,\r\n    endX: endPoint.x,\r\n    endY: endPoint.y,\r\n    side: side,\r\n    order: order\r\n});\r\n\r\n    return true;\r\n}\r\n\r\n";

		// Token: 0x04003CBB RID: 15547
		private bool #q;

		// Token: 0x02001087 RID: 4231
		[CompilerGenerated]
		private sealed class #AZb
		{
			// Token: 0x060090AC RID: 37036 RVA: 0x00074B9C File Offset: 0x00072D9C
			internal <>f__AnonymousType1<double, Point3D> #Raf(Point3D #Rf)
			{
				return new
				{
					Distance = #Rf.DistanceTo(this.#a),
					Point = #Rf
				};
			}

			// Token: 0x04003CCB RID: 15563
			public Point3D #a;
		}
	}
}
