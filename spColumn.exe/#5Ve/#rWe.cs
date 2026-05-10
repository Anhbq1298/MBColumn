using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;
using #12e;
using #7hc;
using #wUe;
using #xKe;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Communication;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Enums;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Input;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Output;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;

namespace #5Ve
{
	// Token: 0x020012F8 RID: 4856
	internal sealed class #rWe
	{
		// Token: 0x0600A25C RID: 41564 RVA: 0x00229C04 File Offset: 0x00227E04
		public #rWe(#l4e #Kwe, InputModel #hMe)
		{
			this.#g = #Kwe;
			this.#h = #hMe;
			this.#j = new XElement(#Phc.#3hc(107470833));
			this.#d = this.#j.#3Le(#Phc.#3hc(107313576));
			this.#k = this.#j.#3Le(#Phc.#3hc(107313555));
			this.#n = this.#j.#3Le(#Phc.#3hc(107313474));
			this.#b = this.#j.#3Le(#Phc.#3hc(107313493));
			this.#a = this.#j.#3Le(#Phc.#3hc(107313440));
			this.#c = this.#j.#3Le(#Phc.#3hc(107313423));
			this.#e = this.#j.#3Le(#Phc.#3hc(107313434));
			this.#i = this.#j.#3Le(#Phc.#3hc(107312869));
			this.#f = this.#j.#3Le(#Phc.#3hc(107312844));
			this.#m = this.#j.#3Le(#Phc.#3hc(107312863));
			this.#l = this.#j.#3Le(#Phc.#3hc(107312826));
		}

		// Token: 0x0600A25D RID: 41565 RVA: 0x0007EFF1 File Offset: 0x0007D1F1
		public string #7Ve()
		{
			this.#dWe();
			return this.#j.ToString();
		}

		// Token: 0x17002EA7 RID: 11943
		// (get) Token: 0x0600A25E RID: 41566 RVA: 0x0007F004 File Offset: 0x0007D204
		public XElement RootElement
		{
			get
			{
				return this.#j;
			}
		}

		// Token: 0x0600A25F RID: 41567 RVA: 0x00229D68 File Offset: 0x00227F68
		private static void #9Ve(IEnumerable<#Z3e> #yP, XElement #aWe)
		{
			foreach (#Z3e #Z3e in #yP.Take(1))
			{
				foreach (Point point in #Z3e.Points)
				{
					XElement #4r = #aWe.#3Le(#Phc.#3hc(107248377));
					#rWe.#dGd(#4r, #Phc.#3hc(107408964), point.X);
					#rWe.#dGd(#4r, #Phc.#3hc(107408991), point.Y);
				}
			}
		}

		// Token: 0x0600A260 RID: 41568 RVA: 0x0007F00C File Offset: 0x0007D20C
		private static void #dGd(XElement #4r, string #Aad, string #f, bool #bWe = false)
		{
			if (#f == null)
			{
				#rWe.#cWe(#4r, #Aad);
				return;
			}
			if (#bWe)
			{
				#4r.#3Le(#Aad).Add(new XCData(#f));
				return;
			}
			#4r.#3Le(#Aad).SetValue(#f);
		}

		// Token: 0x0600A261 RID: 41569 RVA: 0x0007F03C File Offset: 0x0007D23C
		private static void #cWe(XElement #4r, string #Aad)
		{
			#4r.#3Le(#Aad);
		}

		// Token: 0x0600A262 RID: 41570 RVA: 0x0007F046 File Offset: 0x0007D246
		private static void #dGd(XElement #4r, string #Aad, float? #f)
		{
			if (#f == null)
			{
				#rWe.#cWe(#4r, #Aad);
			}
			if (#f != null)
			{
				#rWe.#dGd(#4r, #Aad, #f.Value);
			}
		}

		// Token: 0x0600A263 RID: 41571 RVA: 0x0007F06F File Offset: 0x0007D26F
		private static void #dGd(XElement #4r, string #Aad, float #f)
		{
			#rWe.#dGd(#4r, #Aad, #rWe.#qp(#f), false);
		}

		// Token: 0x0600A264 RID: 41572 RVA: 0x0007F07F File Offset: 0x0007D27F
		private static string #qp(float #f)
		{
			return #f.ToString(string.Empty, CultureInfo.InvariantCulture);
		}

		// Token: 0x0600A265 RID: 41573 RVA: 0x00229E28 File Offset: 0x00228028
		private void #dWe()
		{
			this.#eWe();
			this.#lWe();
			this.#mWe();
			this.#nWe();
			this.#Nne();
			this.#kWe();
			this.#iWe();
			this.#jWe();
			this.#gWe();
			this.#hWe();
			this.#oWe();
			this.#pWe();
			this.#qWe();
		}

		// Token: 0x0600A266 RID: 41574 RVA: 0x00229E84 File Offset: 0x00228084
		private void #eWe()
		{
			#i5e #i5e = this.#g.Variables;
			this.#fWe(#Phc.#3hc(107312761), (#i5e.ConcreteType == #r4e.#a) ? #Phc.#3hc(107312723) : #Phc.#3hc(107312708));
			this.#fWe(#Phc.#3hc(107312678), (#i5e.SteelType == #s4e.#a) ? #Phc.#3hc(107312723) : #Phc.#3hc(107312708));
			this.#fWe(#Phc.#3hc(107312693), #i5e.ConcreteFcp);
			this.#fWe(#Phc.#3hc(107312644), #i5e.SteelFy);
			this.#fWe(#Phc.#3hc(107312663), #i5e.ConcreteEc);
			this.#fWe(#Phc.#3hc(107313126), #i5e.SteelEs);
			this.#fWe(#Phc.#3hc(107313145), #i5e.ConcreteFc);
			this.#fWe(#Phc.#3hc(107313096), #i5e.SteelEpsYt);
			this.#fWe(#Phc.#3hc(107313111), #i5e.ConcreteEpsU);
			this.#fWe(#Phc.#3hc(107313058), #i5e.ConcreteBeta1);
			this.#fWe(#Phc.#3hc(107313037), #i5e.SectionPropAg);
			this.#fWe(#Phc.#3hc(107313048), #i5e.SectionPropIx);
			this.#fWe(#Phc.#3hc(107312995), #i5e.SectionPropIy);
			this.#fWe(#Phc.#3hc(107312974), #i5e.SectionPropRx);
			this.#fWe(#Phc.#3hc(107312985), #i5e.SectionPropRy);
			this.#fWe(#Phc.#3hc(107312932), #i5e.SectionPropX0);
			this.#fWe(#Phc.#3hc(107312911), #i5e.SectionPropY0);
			this.#fWe(#Phc.#3hc(107312922), #i5e.RedFactPhiA);
			this.#fWe(#Phc.#3hc(107312357), #i5e.RedFactPhiB);
			this.#fWe(#Phc.#3hc(107312368), #i5e.RedFactPhiC);
			this.#fWe(#Phc.#3hc(107312347), #i5e.RedFactRho);
			if (this.#h.Options.ReinforcementType[(int)this.#h.Options.ProblemType] == ReinforcementType.Irregular)
			{
				this.#fWe(#Phc.#3hc(107312298), #i5e.SectionPropTotalSteelArea);
				this.#fWe(#Phc.#3hc(107312257), #i5e.SectionPropRho);
			}
			else
			{
				this.#fWe(#Phc.#3hc(107312298), null);
				this.#fWe(#Phc.#3hc(107312257), null);
			}
			this.#fWe(#Phc.#3hc(107312232), #i5e.Pmax);
			this.#fWe(#Phc.#3hc(107312255), #i5e.Pmin);
		}

		// Token: 0x0600A267 RID: 41575 RVA: 0x0007F092 File Offset: 0x0007D292
		private void #fWe(string #wy, float? #f)
		{
			if (#f == null)
			{
				return;
			}
			this.#fWe(#wy, #f.Value);
		}

		// Token: 0x0600A268 RID: 41576 RVA: 0x0007F0AC File Offset: 0x0007D2AC
		private void #fWe(string #wy, float #f)
		{
			XElement #4r = this.#n.#3Le(#Phc.#3hc(107312246));
			#rWe.#dGd(#4r, #Phc.#3hc(107312201), #wy, false);
			#rWe.#dGd(#4r, #Phc.#3hc(107312192), #f);
		}

		// Token: 0x0600A269 RID: 41577 RVA: 0x0007F0E5 File Offset: 0x0007D2E5
		private void #fWe(string #wy, string #f)
		{
			XElement #4r = this.#n.#3Le(#Phc.#3hc(107312246));
			#rWe.#dGd(#4r, #Phc.#3hc(107312201), #wy, false);
			#rWe.#dGd(#4r, #Phc.#3hc(107312192), #f, false);
		}

		// Token: 0x0600A26A RID: 41578 RVA: 0x0022A14C File Offset: 0x0022834C
		private void #gWe()
		{
			foreach (UniaxialServiceLoad uniaxialServiceLoad in this.#g.UniaxialServiceLoads)
			{
				XElement #4r = this.#k.#3Le(#Phc.#3hc(107312215));
				string #Aad = #Phc.#3hc(107312186);
				int? num = uniaxialServiceLoad.Index;
				#rWe.#dGd(#4r, #Aad, (num != null) ? new float?((float)num.GetValueOrDefault()) : null);
				string #Aad2 = #Phc.#3hc(107312177);
				num = uniaxialServiceLoad.ServiceLoadIndex;
				#rWe.#dGd(#4r, #Aad2, (num != null) ? new float?((float)num.GetValueOrDefault()) : null);
				string #Aad3 = #Phc.#3hc(107312140);
				num = uniaxialServiceLoad.LoadCombinationIndex;
				#rWe.#dGd(#4r, #Aad3, (num != null) ? new float?((float)num.GetValueOrDefault()) : null);
				#rWe.#dGd(#4r, #Phc.#3hc(107312135), uniaxialServiceLoad.AppLoad);
				#rWe.#dGd(#4r, #Phc.#3hc(107312130), uniaxialServiceLoad.AppMoment);
				#rWe.#dGd(#4r, #Phc.#3hc(107312157), uniaxialServiceLoad.UltimateMoment);
				#rWe.#dGd(#4r, #Phc.#3hc(107312152), uniaxialServiceLoad.Usf);
				#rWe.#dGd(#4r, #Phc.#3hc(107312147), uniaxialServiceLoad.Nadepth);
				#rWe.#dGd(#4r, #Phc.#3hc(107312614), uniaxialServiceLoad.Dt);
				#rWe.#dGd(#4r, #Phc.#3hc(107312609), uniaxialServiceLoad.Eps);
				#rWe.#dGd(#4r, #Phc.#3hc(107312636), uniaxialServiceLoad.Phi);
				#rWe.#dGd(#4r, #Phc.#3hc(107312631), uniaxialServiceLoad.#t3e(), false);
				#rWe.#dGd(#4r, #Phc.#3hc(107291531), uniaxialServiceLoad.#62e(), true);
			}
		}

		// Token: 0x0600A26B RID: 41579 RVA: 0x0022A344 File Offset: 0x00228544
		private void #hWe()
		{
			foreach (BiaxialServiceLoad biaxialServiceLoad in this.#g.BiaxialServiceLoads)
			{
				XElement #4r = this.#k.#3Le(#Phc.#3hc(107312586));
				string #Aad = #Phc.#3hc(107312186);
				int? num = biaxialServiceLoad.Index;
				#rWe.#dGd(#4r, #Aad, (num != null) ? new float?((float)num.GetValueOrDefault()) : null);
				string #Aad2 = #Phc.#3hc(107312177);
				num = biaxialServiceLoad.ServiceLoadIndex;
				#rWe.#dGd(#4r, #Aad2, (num != null) ? new float?((float)num.GetValueOrDefault()) : null);
				string #Aad3 = #Phc.#3hc(107312140);
				num = biaxialServiceLoad.LoadCombinationIndex;
				#rWe.#dGd(#4r, #Aad3, (num != null) ? new float?((float)num.GetValueOrDefault()) : null);
				#rWe.#dGd(#4r, #Phc.#3hc(107312135), biaxialServiceLoad.AppLoad);
				#rWe.#dGd(#4r, #Phc.#3hc(107312593), biaxialServiceLoad.FactLoad2);
				#rWe.#dGd(#4r, #Phc.#3hc(107312556), biaxialServiceLoad.FactLoad3);
				#rWe.#dGd(#4r, #Phc.#3hc(107312551), biaxialServiceLoad.UltimateMomentX);
				#rWe.#dGd(#4r, #Phc.#3hc(107312546), biaxialServiceLoad.UltimateMomentY);
				#rWe.#dGd(#4r, #Phc.#3hc(107312152), biaxialServiceLoad.Usf);
				#rWe.#dGd(#4r, #Phc.#3hc(107312147), biaxialServiceLoad.Nadepth);
				#rWe.#dGd(#4r, #Phc.#3hc(107312614), biaxialServiceLoad.Dt);
				#rWe.#dGd(#4r, #Phc.#3hc(107312609), biaxialServiceLoad.Eps);
				#rWe.#dGd(#4r, #Phc.#3hc(107312636), biaxialServiceLoad.Phi);
				#rWe.#dGd(#4r, #Phc.#3hc(107312631), biaxialServiceLoad.#t3e(), false);
				#rWe.#dGd(#4r, #Phc.#3hc(107291531), biaxialServiceLoad.#62e(), true);
			}
		}

		// Token: 0x0600A26C RID: 41580 RVA: 0x0022A568 File Offset: 0x00228768
		private void #iWe()
		{
			foreach (UniaxialFactoredLoad uniaxialFactoredLoad in this.#g.UniaxialFactoredLoads)
			{
				XElement #4r = this.#d.#3Le(#Phc.#3hc(107312573));
				string #Aad = #Phc.#3hc(107312186);
				int? num = uniaxialFactoredLoad.Index;
				#rWe.#dGd(#4r, #Aad, (num != null) ? new float?((float)num.GetValueOrDefault()) : null);
				#rWe.#dGd(#4r, #Phc.#3hc(107312135), uniaxialFactoredLoad.AppLoad);
				#rWe.#dGd(#4r, #Phc.#3hc(107312130), uniaxialFactoredLoad.AppMoment);
				#rWe.#dGd(#4r, #Phc.#3hc(107312157), uniaxialFactoredLoad.UltimateMoment);
				#rWe.#dGd(#4r, #Phc.#3hc(107312152), uniaxialFactoredLoad.Usf);
				#rWe.#dGd(#4r, #Phc.#3hc(107312147), uniaxialFactoredLoad.Nadepth);
				#rWe.#dGd(#4r, #Phc.#3hc(107312614), uniaxialFactoredLoad.Dt);
				#rWe.#dGd(#4r, #Phc.#3hc(107312609), uniaxialFactoredLoad.Eps);
				#rWe.#dGd(#4r, #Phc.#3hc(107312636), uniaxialFactoredLoad.Phi);
				#rWe.#dGd(#4r, #Phc.#3hc(107312631), uniaxialFactoredLoad.#t3e(), false);
				#rWe.#dGd(#4r, #Phc.#3hc(107291531), uniaxialFactoredLoad.#62e(), true);
			}
		}

		// Token: 0x0600A26D RID: 41581 RVA: 0x0022A6F0 File Offset: 0x002288F0
		private void #jWe()
		{
			foreach (BiaxialFactoredLoad biaxialFactoredLoad in this.#g.BiaxialFactoredLoads)
			{
				XElement #4r = this.#d.#3Le(#Phc.#3hc(107312512));
				string #Aad = #Phc.#3hc(107312186);
				int? num = biaxialFactoredLoad.Index;
				#rWe.#dGd(#4r, #Aad, (num != null) ? new float?((float)num.GetValueOrDefault()) : null);
				#rWe.#dGd(#4r, #Phc.#3hc(107312135), biaxialFactoredLoad.AppLoad);
				#rWe.#dGd(#4r, #Phc.#3hc(107312593), biaxialFactoredLoad.FactLoad1);
				#rWe.#dGd(#4r, #Phc.#3hc(107312556), biaxialFactoredLoad.FactLoad2);
				#rWe.#dGd(#4r, #Phc.#3hc(107312551), biaxialFactoredLoad.UltimateMomentX);
				#rWe.#dGd(#4r, #Phc.#3hc(107312546), biaxialFactoredLoad.UltimateMomentY);
				#rWe.#dGd(#4r, #Phc.#3hc(107312152), biaxialFactoredLoad.Usf);
				#rWe.#dGd(#4r, #Phc.#3hc(107312147), biaxialFactoredLoad.Nadepth);
				#rWe.#dGd(#4r, #Phc.#3hc(107312614), biaxialFactoredLoad.Dt);
				#rWe.#dGd(#4r, #Phc.#3hc(107312609), biaxialFactoredLoad.Eps);
				#rWe.#dGd(#4r, #Phc.#3hc(107312636), biaxialFactoredLoad.Phi);
				#rWe.#dGd(#4r, #Phc.#3hc(107312631), biaxialFactoredLoad.#t3e(), false);
				#rWe.#dGd(#4r, #Phc.#3hc(107291531), biaxialFactoredLoad.#62e(), true);
			}
		}

		// Token: 0x0600A26E RID: 41582 RVA: 0x0022A8A4 File Offset: 0x00228AA4
		private void #kWe()
		{
			foreach (#Jce #Jce in this.#g.AxialLoads)
			{
				XElement #4r = this.#a.#3Le(#Phc.#3hc(107398869));
				string #Aad = #Phc.#3hc(107312186);
				int? num = #Jce.Index;
				#rWe.#dGd(#4r, #Aad, (num != null) ? new float?((float)num.GetValueOrDefault()) : null);
				#rWe.#dGd(#4r, #Phc.#3hc(107359852), #Jce.P);
				#rWe.#dGd(#4r, #Phc.#3hc(107312483), #Jce.Rm);
				#rWe.#dGd(#4r, #Phc.#3hc(107408077), #Jce.C);
				#rWe.#dGd(#4r, #Phc.#3hc(107312614), #Jce.Dt);
				#rWe.#dGd(#4r, #Phc.#3hc(107312609), #Jce.Eps);
				#rWe.#dGd(#4r, #Phc.#3hc(107312636), #Jce.Phi);
			}
		}

		// Token: 0x0600A26F RID: 41583 RVA: 0x0022A9C8 File Offset: 0x00228BC8
		private void #lWe()
		{
			foreach (ControlPoint controlPoint in this.#g.ControlPoints)
			{
				XElement #4r = this.#b.#3Le(#Phc.#3hc(107312510));
				#rWe.#dGd(#4r, #Phc.#3hc(107312201), controlPoint.Label, false);
				#rWe.#dGd(#4r, #Phc.#3hc(107359852), controlPoint.P);
				#rWe.#dGd(#4r, #Phc.#3hc(107312461), controlPoint.Xm);
				#rWe.#dGd(#4r, #Phc.#3hc(107312456), controlPoint.Ym);
				#rWe.#dGd(#4r, #Phc.#3hc(107408077), controlPoint.C);
				#rWe.#dGd(#4r, #Phc.#3hc(107312614), controlPoint.Dt);
				#rWe.#dGd(#4r, #Phc.#3hc(107312609), controlPoint.Eps);
				#rWe.#dGd(#4r, #Phc.#3hc(107312636), controlPoint.Phi);
			}
		}

		// Token: 0x0600A270 RID: 41584 RVA: 0x0007F11F File Offset: 0x0007D31F
		private void #mWe()
		{
			#rWe.#9Ve(this.#g.Solids, this.#c);
		}

		// Token: 0x0600A271 RID: 41585 RVA: 0x0007F137 File Offset: 0x0007D337
		private void #nWe()
		{
			#rWe.#9Ve(this.#g.Openings, this.#e);
		}

		// Token: 0x0600A272 RID: 41586 RVA: 0x0022AAE0 File Offset: 0x00228CE0
		private void #Nne()
		{
			foreach (ReinforcementBar reinforcementBar in this.#g.ReinforcementBars)
			{
				XElement #4r = this.#i.#3Le(#Phc.#3hc(107353632));
				#rWe.#dGd(#4r, #Phc.#3hc(107408964), reinforcementBar.X);
				#rWe.#dGd(#4r, #Phc.#3hc(107408991), reinforcementBar.Y);
				#rWe.#dGd(#4r, #Phc.#3hc(107397860), reinforcementBar.Z);
				#rWe.#dGd(#4r, #Phc.#3hc(107397869), reinforcementBar.Area);
			}
		}

		// Token: 0x0600A273 RID: 41587 RVA: 0x0022AB98 File Offset: 0x00228D98
		private void #oWe()
		{
			foreach (MomentMagnificationFactor momentMagnificationFactor in this.#g.MomentMagnificationFactors)
			{
				XElement #4r = this.#m.#3Le(#Phc.#3hc(107283372));
				#rWe.#dGd(#4r, #Phc.#3hc(107312451), (momentMagnificationFactor.MomentAxis == MomentMagnificationFactor.Axis.X) ? #Phc.#3hc(107408964) : #Phc.#3hc(107408991), false);
				#rWe.#dGd(#4r, #Phc.#3hc(107312474), (float)momentMagnificationFactor.Load);
				#rWe.#dGd(#4r, #Phc.#3hc(107312465), (float)momentMagnificationFactor.Combination);
				#rWe.#dGd(#4r, #Phc.#3hc(107312416), momentMagnificationFactor.SumPu.#Qhc(string.Empty), false);
				#rWe.#dGd(#4r, #Phc.#3hc(107312439), momentMagnificationFactor.Pc.#Qhc(string.Empty), false);
				#rWe.#dGd(#4r, #Phc.#3hc(107312434), momentMagnificationFactor.SumPc.#Qhc(string.Empty), false);
				#rWe.#dGd(#4r, #Phc.#3hc(107312393), momentMagnificationFactor.BetaDs.#Qhc(string.Empty), false);
				#rWe.#dGd(#4r, #Phc.#3hc(107312384), momentMagnificationFactor.DeltaS.#Qhc(#Phc.#3hc(107383600)), false);
				#rWe.#dGd(#4r, #Phc.#3hc(107312407), momentMagnificationFactor.Pu.ToString(string.Empty, CultureInfo.InvariantCulture), false);
				#rWe.#dGd(#4r, #Phc.#3hc(107312402), momentMagnificationFactor.KluR.#Qhc(#Phc.#3hc(107408811)), false);
				#rWe.#dGd(#4r, #Phc.#3hc(107311849), momentMagnificationFactor.PcLength.#Qhc(), false);
				#rWe.#dGd(#4r, #Phc.#3hc(107311868), momentMagnificationFactor.BetaD.#Qhc(), false);
				#rWe.#dGd(#4r, #Phc.#3hc(107311859), momentMagnificationFactor.Cm.#Qhc(#Phc.#3hc(107383600)), false);
				#rWe.#dGd(#4r, #Phc.#3hc(107311822), momentMagnificationFactor.Delta.#Qhc(#Phc.#3hc(107383600)), false);
				#rWe.#dGd(#4r, #Phc.#3hc(107311813), momentMagnificationFactor.#Y3e(), false);
			}
		}

		// Token: 0x0600A274 RID: 41588 RVA: 0x0022ADFC File Offset: 0x00228FFC
		private void #pWe()
		{
			foreach (FactoredMoment factoredMoment in this.#g.FactoredMoments)
			{
				XElement #4r = this.#l.#3Le(#Phc.#3hc(107311836));
				#rWe.#dGd(#4r, #Phc.#3hc(107312451), (factoredMoment.MomentAxis == FactoredMoment.Axis.X) ? #Phc.#3hc(107408964) : #Phc.#3hc(107408991), false);
				string #Aad = #Phc.#3hc(107312474);
				int? num = factoredMoment.Load;
				#rWe.#dGd(#4r, #Aad, (num != null) ? new float?((float)num.GetValueOrDefault()) : null);
				string #Aad2 = #Phc.#3hc(107312465);
				num = factoredMoment.Combination;
				#rWe.#dGd(#4r, #Aad2, (num != null) ? new float?((float)num.GetValueOrDefault()) : null);
				#rWe.#dGd(#4r, #Phc.#3hc(107311783), factoredMoment.Mns.#h(#Phc.#3hc(107408811), CultureInfo.InvariantCulture), false);
				#rWe.#dGd(#4r, #Phc.#3hc(107311778), factoredMoment.Ms.#Qhc(), false);
				#rWe.#dGd(#4r, #Phc.#3hc(107311805), factoredMoment.Mu.#h(#Phc.#3hc(107408811), CultureInfo.InvariantCulture), false);
				#rWe.#dGd(#4r, #Phc.#3hc(107311800), factoredMoment.MMin.#Qhc(), false);
				#rWe.#dGd(#4r, #Phc.#3hc(107311759), factoredMoment.Mi.#Qhc(), false);
				#rWe.#dGd(#4r, #Phc.#3hc(107311746), factoredMoment.Mi.#Qhc(), false);
				#rWe.#dGd(#4r, #Phc.#3hc(107311773), factoredMoment.Mc.#Qhc(), false);
				#rWe.#dGd(#4r, #Phc.#3hc(107311768), factoredMoment.Ratio.#Qhc(), false);
				#rWe.#dGd(#4r, #Phc.#3hc(107311813), factoredMoment.#q3e(), false);
			}
		}

		// Token: 0x0600A275 RID: 41589 RVA: 0x0022B024 File Offset: 0x00229224
		private void #qWe()
		{
			foreach (Message message in this.#g.Messages)
			{
				XElement #4r = this.#f.#3Le(#Phc.#3hc(107383983));
				#rWe.#dGd(#4r, #Phc.#3hc(107311727), message.#T6e(), false);
				#rWe.#dGd(#4r, #Phc.#3hc(107311718), message.#U6e(), false);
				#rWe.#dGd(#4r, #Phc.#3hc(107311741), null);
			}
		}

		// Token: 0x04004711 RID: 18193
		private readonly XElement #a;

		// Token: 0x04004712 RID: 18194
		private readonly XElement #b;

		// Token: 0x04004713 RID: 18195
		private readonly XElement #c;

		// Token: 0x04004714 RID: 18196
		private readonly XElement #d;

		// Token: 0x04004715 RID: 18197
		private readonly XElement #e;

		// Token: 0x04004716 RID: 18198
		private readonly XElement #f;

		// Token: 0x04004717 RID: 18199
		private readonly #l4e #g;

		// Token: 0x04004718 RID: 18200
		private readonly InputModel #h;

		// Token: 0x04004719 RID: 18201
		private readonly XElement #i;

		// Token: 0x0400471A RID: 18202
		private readonly XElement #j;

		// Token: 0x0400471B RID: 18203
		private readonly XElement #k;

		// Token: 0x0400471C RID: 18204
		private readonly XElement #l;

		// Token: 0x0400471D RID: 18205
		private readonly XElement #m;

		// Token: 0x0400471E RID: 18206
		private readonly XElement #n;
	}
}
