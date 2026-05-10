using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using #3Qb;
using #6re;
using #7hc;
using #BTd;
using #eU;
using #ezc;
using #hPd;
using #Hte;
using #kB;
using #LQc;
using #pXd;
using #qPd;
using #sUd;
using #uLd;
using #v1c;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Model;
using StructurePoint.CoreAssets.GUI.DesktopControls;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Presentation.Views;
using StructurePoint.CoreAssets.Logger;
using StructurePoint.Products.Column.Services.API;

namespace #Xx
{
	// Token: 0x020001D4 RID: 468
	internal sealed class #gB : #nB
	{
		// Token: 0x0600105F RID: 4191 RVA: 0x000A6694 File Offset: 0x000A4894
		public #gB(#uUd #qy, ILogger #3x, #v2c #my, #8Sc #ls, #yse #tA, #vUd #hB, #rW #Hj, #tUd #5x, #ATd #ry, #xAc #6x, ICommandFactory #iB, #lB #oj, #qW #1c, #jB #yq, #oW #xn, ISettingsManager #ng, #iW #ss)
		{
			if (#6x == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107408977));
			}
			this.#r = #6x;
			if (#qy == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107408944));
			}
			this.#a = #qy;
			if (#3x == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107408919));
			}
			this.#b = #3x;
			if (#my == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107409390));
			}
			this.#c = #my;
			if (#ls == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107409397));
			}
			this.#d = #ls;
			if (#tA == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107409344));
			}
			this.#e = #tA;
			if (#hB == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107409319));
			}
			this.#f = #hB;
			if (#Hj == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107409338));
			}
			this.#g = #Hj;
			if (#5x == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107409281));
			}
			this.#h = #5x;
			if (#ry == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107409256));
			}
			this.#i = #ry;
			if (#iB == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107409227));
			}
			this.#j = #iB;
			if (#oj == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107409238));
			}
			this.#k = #oj;
			this.#l = #1c;
			this.#m = #xn;
			this.#n = #ng;
			this.#o = #ss;
			this.#p = #yq.#EA();
			this.#q = #yq.#EA();
			#yq.IsEnabled = true;
			this.#s.#sy<#xAc>(#6x);
			this.#s.#sy<ICommandFactory>(#iB);
			this.#t = new Lazy<#mB>(new Func<#mB>(this.#cB), LazyThreadSafetyMode.ExecutionAndPublication);
			this.#u = new Lazy<#oB>(new Func<#oB>(this.#bB), LazyThreadSafetyMode.ExecutionAndPublication);
			this.#v = new Lazy<#Wx>(new Func<#Wx>(this.#aB), LazyThreadSafetyMode.ExecutionAndPublication);
		}

		// Token: 0x06001060 RID: 4192 RVA: 0x0001294F File Offset: 0x00010B4F
		public #kPd #4h(#gPd #Pc)
		{
			return this.#v.Value.#0(new #Gte(), #Pc);
		}

		// Token: 0x06001061 RID: 4193 RVA: 0x000A68B0 File Offset: 0x000A4AB0
		public void #VA()
		{
			if (this.#t.Value.#WLd())
			{
				return;
			}
			this.#k.#LA(false, true);
			#mB value = this.#t.Value;
			if (value.View.Visibility <= Visibility.Visible && value.#TLd() && !this.#9A())
			{
				value.#QLd();
				return;
			}
			this.#7A();
			value.#od(null);
		}

		// Token: 0x06001062 RID: 4194 RVA: 0x00012973 File Offset: 0x00010B73
		public void #WA()
		{
			this.#k.#LA(false, true);
			this.#u.Value.#od(null);
		}

		// Token: 0x06001063 RID: 4195 RVA: 0x000A692C File Offset: 0x000A4B2C
		public void #XA(bool #YA = false)
		{
			if (!this.#u.IsValueCreated && !this.#t.IsValueCreated)
			{
				return;
			}
			if (this.#t.Value.#WLd())
			{
				return;
			}
			if (#YA)
			{
				this.#k.#LA(true, true);
			}
			this.#u.Value.#od(null);
			this.#t.Value.#od(null);
		}

		// Token: 0x06001064 RID: 4196 RVA: 0x000A69A8 File Offset: 0x000A4BA8
		public void #ZA()
		{
			if (!this.#t.IsValueCreated)
			{
				return;
			}
			if (this.#t.Value.#WLd())
			{
				return;
			}
			this.#k.#LA(true, true);
			this.#t.Value.#od(null);
		}

		// Token: 0x06001065 RID: 4197 RVA: 0x000129A0 File Offset: 0x00010BA0
		public void #0A()
		{
			if (this.#u.IsValueCreated)
			{
				Ignore.#14d<Exception>(new Action(this.#dB), null);
			}
		}

		// Token: 0x06001066 RID: 4198 RVA: 0x000129CE File Offset: 0x00010BCE
		public void #1A()
		{
			if (this.#t.IsValueCreated)
			{
				Ignore.#14d<Exception>(new Action(this.#eB), null);
			}
		}

		// Token: 0x06001067 RID: 4199 RVA: 0x000129FC File Offset: 0x00010BFC
		public void #2A()
		{
			this.#0A();
			this.#1A();
		}

		// Token: 0x06001068 RID: 4200 RVA: 0x000A6A04 File Offset: 0x000A4C04
		public void #3A()
		{
			if (this.#t.IsValueCreated)
			{
				this.#t.Value.#jy();
			}
			if (this.#u.IsValueCreated)
			{
				this.#u.Value.#jy();
			}
		}

		// Token: 0x06001069 RID: 4201 RVA: 0x00012A16 File Offset: 0x00010C16
		private void #4A(object #Ge, EventArgs #He)
		{
			LayoutHelper.BeginInvokeOnApplicationThread(new Action(this.#VA));
		}

		// Token: 0x0600106A RID: 4202 RVA: 0x00012A2F File Offset: 0x00010C2F
		private void #5A(object #Ge, EventArgs #He)
		{
			this.#7A();
		}

		// Token: 0x0600106B RID: 4203 RVA: 0x00012A3F File Offset: 0x00010C3F
		private void #6A(object #Ge, EventArgs #He)
		{
			LayoutHelper.BeginInvokeOnApplicationThread(new Action(this.#WA));
		}

		// Token: 0x0600106C RID: 4204 RVA: 0x00012A58 File Offset: 0x00010C58
		private void #7A()
		{
			this.#w.Clear();
			this.#w.AddRange(this.#k.Screenshots);
			this.#8A();
		}

		// Token: 0x0600106D RID: 4205 RVA: 0x000A6A58 File Offset: 0x000A4C58
		private void #8A()
		{
			this.#x = this.#e.#jJ();
			this.#y = this.#e.#hJ();
			this.#z = this.#n.#ZN();
		}

		// Token: 0x0600106E RID: 4206 RVA: 0x000A6AA4 File Offset: 0x000A4CA4
		private bool #9A()
		{
			return this.#w.Count != this.#k.Screenshots.Count || !this.#w.All(new Func<ReporterImage, bool>(this.#fB)) || (this.#x == null || !#IXd.#ntb<#5re>(this.#x, this.#e.#jJ())) || (this.#y == null || !#IXd.#ntb<#xse>(this.#y, this.#e.#hJ())) || (this.#z == null || !#IXd.#ntb<#qRb>(this.#z, this.#n.#ZN()));
		}

		// Token: 0x0600106F RID: 4207 RVA: 0x000A6B70 File Offset: 0x000A4D70
		private #Wx #aB()
		{
			return new #1x(this.#s, new GraphicalReporterWindow(), this.#b, this.#e, this.#c, this.#h, this.#d, this.#m, this.#r);
		}

		// Token: 0x06001070 RID: 4208 RVA: 0x000A6BC8 File Offset: 0x000A4DC8
		private #oB #bB()
		{
			#xOd #sA = new #xOd(this.#s, this.#a, new ResultsSettingsWindow(), this.#b, this.#e);
			#rA #rA = new #rA(this.#s, new ResultsMainWindow(), this.#b, this.#c, #sA, this.#h, this.#g, this.#e, this.#a, this.#d, this.#q, this.#o);
			#rA.OutdatedReportRebuildRequested += this.#6A;
			return #rA;
		}

		// Token: 0x06001071 RID: 4209 RVA: 0x000A6C68 File Offset: 0x000A4E68
		private #mB #cB()
		{
			#uPd #py = new #ANd(this.#s, new ReporterSettingsWindow(), this.#b, this.#e, this.#a, this.#j);
			#LNd #oy = new #LNd(this.#s, new OptionsPanelView(), this.#b, this.#g);
			#ly #ly = new #ly(this.#s, this.#b, this.#d, this.#c, this.#h, this.#g, this.#f, this.#e, new ReporterMainWindow(), #oy, #py, this.#a, this.#i, this.#p, this.#l);
			#ly.OutdatedReportRebuildRequested += this.#4A;
			#ly.ReportGenerated += this.#5A;
			return #ly;
		}

		// Token: 0x06001072 RID: 4210 RVA: 0x00012A8D File Offset: 0x00010C8D
		[CompilerGenerated]
		private void #dB()
		{
			this.#u.Value.View.#Fgc();
		}

		// Token: 0x06001073 RID: 4211 RVA: 0x00012AB0 File Offset: 0x00010CB0
		[CompilerGenerated]
		private void #eB()
		{
			this.#t.Value.View.#Fgc();
		}

		// Token: 0x06001074 RID: 4212 RVA: 0x00012AD3 File Offset: 0x00010CD3
		[CompilerGenerated]
		private bool #fB(ReporterImage #Rf)
		{
			return this.#k.Screenshots.Contains(#Rf);
		}

		// Token: 0x04000669 RID: 1641
		private readonly #uUd #a;

		// Token: 0x0400066A RID: 1642
		private readonly ILogger #b;

		// Token: 0x0400066B RID: 1643
		private readonly #v2c #c;

		// Token: 0x0400066C RID: 1644
		private readonly #8Sc #d;

		// Token: 0x0400066D RID: 1645
		private readonly #yse #e;

		// Token: 0x0400066E RID: 1646
		private readonly #vUd #f;

		// Token: 0x0400066F RID: 1647
		private readonly #rW #g;

		// Token: 0x04000670 RID: 1648
		private readonly #tUd #h;

		// Token: 0x04000671 RID: 1649
		private readonly #ATd #i;

		// Token: 0x04000672 RID: 1650
		private readonly ICommandFactory #j;

		// Token: 0x04000673 RID: 1651
		private readonly #lB #k;

		// Token: 0x04000674 RID: 1652
		private readonly #qW #l;

		// Token: 0x04000675 RID: 1653
		private readonly #oW #m;

		// Token: 0x04000676 RID: 1654
		private readonly ISettingsManager #n;

		// Token: 0x04000677 RID: 1655
		private readonly #iW #o;

		// Token: 0x04000678 RID: 1656
		private readonly #jB #p;

		// Token: 0x04000679 RID: 1657
		private readonly #jB #q;

		// Token: 0x0400067A RID: 1658
		private readonly #xAc #r;

		// Token: 0x0400067B RID: 1659
		private readonly #xy #s = new #xy();

		// Token: 0x0400067C RID: 1660
		private readonly Lazy<#mB> #t;

		// Token: 0x0400067D RID: 1661
		private readonly Lazy<#oB> #u;

		// Token: 0x0400067E RID: 1662
		private readonly Lazy<#Wx> #v;

		// Token: 0x0400067F RID: 1663
		private readonly List<ReporterImage> #w = new List<ReporterImage>();

		// Token: 0x04000680 RID: 1664
		private #5re #x;

		// Token: 0x04000681 RID: 1665
		private #xse #y;

		// Token: 0x04000682 RID: 1666
		private #qRb #z;
	}
}
