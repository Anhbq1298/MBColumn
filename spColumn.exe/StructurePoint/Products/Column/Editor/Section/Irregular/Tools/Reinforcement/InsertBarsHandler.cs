using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using #eU;
using #LFb;
using #LQc;
using #NDb;
using devDept.Geometry;
using StructurePoint.CoreAssets.AppManager.Column.Core;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.Infrastructure;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.Products.Column.Core.API;
using StructurePoint.Products.Column.Model.Entities;

namespace StructurePoint.Products.Column.Editor.Section.Irregular.Tools.Reinforcement
{
	// Token: 0x0200059E RID: 1438
	internal sealed class InsertBarsHandler : #nFb
	{
		// Token: 0x06003263 RID: 12899 RVA: 0x0002C9A1 File Offset: 0x0002ABA1
		public InsertBarsHandler(#1Fb limits, IEditorService editorService, #oW project, #8Sc dialogService, #iW windowLocator)
		{
			this.#a = limits;
			this.#b = editorService;
			this.#c = project;
			this.#d = dialogService;
			this.#e = windowLocator;
		}

		// Token: 0x06003264 RID: 12900 RVA: 0x0002C9D9 File Offset: 0x0002ABD9
		public bool #sEb(Point3D #0bb, double #wCb)
		{
			return this.#0Db(new List<Point3D>
			{
				#0bb
			}, #wCb);
		}

		// Token: 0x06003265 RID: 12901 RVA: 0x000FFAC8 File Offset: 0x000FDCC8
		public bool #0Db(IList<Point3D> #Hob, double #wCb)
		{
			InsertBarsHandler.#W9b #W9b = new InsertBarsHandler.#W9b();
			#W9b.#a = this;
			if (this.#f.#YXd())
			{
				try
				{
					#Hob = InsertBarsHandler.#oFb(#Hob, 0.001);
					if (!#Hob.Any<Point3D>() || #wCb < 0.001)
					{
						this.#f.#ZXd();
						return false;
					}
					#W9b.#b = this.#c.Model.ReinforcementBars.ToHashSet<ReinforcementBar>();
					List<ReinforcementBar> list = this.#c.Model.ReinforcementBars.ToList<ReinforcementBar>();
					double #qFb = CircleHelper.#wmc(#wCb);
					foreach (Point3D point3D in #Hob)
					{
						for (int i = list.Count - 1; i >= 0; i--)
						{
							ReinforcementBar reinforcementBar = list[i];
							double #rFb = CircleHelper.#wmc((double)reinforcementBar.Area);
							if (this.#pFb(point3D, #qFb, reinforcementBar.Point, #rFb))
							{
								list.RemoveAt(i);
								#W9b.#b.Remove(reinforcementBar);
							}
						}
						#W9b.#b.Add(new ReinforcementBar((float)#wCb, (float)point3D.X, (float)point3D.Y, 0f));
						if (#W9b.#b.Count > this.#a.Limits.TotalBars)
						{
							break;
						}
					}
					if (#W9b.#b.Count <= this.#a.Limits.TotalBars)
					{
						this.#b.#0Pb(new Action(#W9b.#R9b));
						this.#f.#ZXd();
						return true;
					}
					#W9b.#c = Strings.StringCannotAddMoreThanXBars.#D2d(new object[]
					{
						this.#a.Limits.TotalBars
					}).#z2d();
					LayoutHelper.BeginInvokeOnApplicationThread(new Action(#W9b.#S9b));
				}
				catch (Exception)
				{
					this.#f.#ZXd();
					throw;
				}
				return false;
			}
			return false;
		}

		// Token: 0x06003266 RID: 12902 RVA: 0x000FFD20 File Offset: 0x000FDF20
		private static IList<Point3D> #oFb(IList<Point3D> #Hob, double #8W)
		{
			InsertBarsHandler.#s0b #s0b = new InsertBarsHandler.#s0b();
			#s0b.#a = #8W;
			#Hob = #Hob.ToList<Point3D>();
			for (int i = #Hob.Count - 1; i >= 0; i--)
			{
				Point3D point3D = #Hob[i];
				if (double.IsNaN(point3D.X) || double.IsNaN(point3D.Y) || double.IsInfinity(point3D.X) || double.IsInfinity(point3D.Y))
				{
					#Hob.RemoveAt(i);
				}
			}
			#Hob = #Hob.Distinct<Point3D>().ToList<Point3D>();
			foreach (Point3D point3D2 in #Hob)
			{
				point3D2.X = Math.Round(point3D2.X, 4);
				point3D2.Y = Math.Round(point3D2.Y, 4);
			}
			List<Point3D> list = #Hob.OrderBy(new Func<Point3D, double>(InsertBarsHandler.<>c.<>9.#N0h)).ThenBy(new Func<Point3D, double>(InsertBarsHandler.<>c.<>9.#O0h)).ToList<Point3D>();
			list.#31d(new Func<Point3D, Point3D, bool>(#s0b.#T9b));
			return list;
		}

		// Token: 0x06003267 RID: 12903 RVA: 0x0002C9FA File Offset: 0x0002ABFA
		private bool #pFb(Point3D #mcb, double #qFb, Point3D #ncb, double #rFb)
		{
			return #mcb.DistanceTo(#ncb) < #qFb + #rFb;
		}

		// Token: 0x04001475 RID: 5237
		private readonly #1Fb #a;

		// Token: 0x04001476 RID: 5238
		private readonly IEditorService #b;

		// Token: 0x04001477 RID: 5239
		private readonly #oW #c;

		// Token: 0x04001478 RID: 5240
		private readonly #8Sc #d;

		// Token: 0x04001479 RID: 5241
		private readonly #iW #e;

		// Token: 0x0400147A RID: 5242
		private NonBlockingLock #f = new NonBlockingLock();

		// Token: 0x020005A0 RID: 1440
		[CompilerGenerated]
		private sealed class #W9b
		{
			// Token: 0x0600326D RID: 12909 RVA: 0x000FFE88 File Offset: 0x000FE088
			internal void #R9b()
			{
				this.#a.#c.Model.ReinforcementBars.Clear();
				this.#a.#c.Model.ReinforcementBars.AddRange(this.#b);
			}

			// Token: 0x0600326E RID: 12910 RVA: 0x000FFEDC File Offset: 0x000FE0DC
			internal void #S9b()
			{
				this.#a.#d.#od(this.#a.#e.#6(), this.#c, ColumnGlobalInfo.ShortName, MessageBoxButton.OK, MessageBoxImage.Hand, MessageBoxResult.OK, MessageBoxOptions.None);
				this.#a.#f.#ZXd();
			}

			// Token: 0x0400147E RID: 5246
			public InsertBarsHandler #a;

			// Token: 0x0400147F RID: 5247
			public HashSet<ReinforcementBar> #b;

			// Token: 0x04001480 RID: 5248
			public string #c;
		}

		// Token: 0x020005A1 RID: 1441
		[CompilerGenerated]
		private sealed class #s0b
		{
			// Token: 0x06003270 RID: 12912 RVA: 0x000FFF38 File Offset: 0x000FE138
			internal bool #T9b(Point3D #U9b, Point3D #V9b)
			{
				return Math.Abs(#U9b.X - #V9b.X) < this.#a && Math.Abs(#U9b.Y - #V9b.Y) < this.#a;
			}

			// Token: 0x04001481 RID: 5249
			public double #a;
		}
	}
}
