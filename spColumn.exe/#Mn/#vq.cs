using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using #12e;
using #7hc;
using #9I;
using #eU;
using #ezc;
using #IDc;
using #nib;
using #Oze;
using #qJ;
using #RJb;
using #xBe;
using #Xc;
using StructurePoint.CoreAssets.AppManager.Column.Engineer;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.Infrastructure;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.Products.Column.Editor.Diagrams;
using StructurePoint.Products.Column.Services.API;

namespace #Mn
{
	// Token: 0x02000127 RID: 295
	internal sealed class #vq : #aJ
	{
		// Token: 0x060009BA RID: 2490 RVA: 0x00097998 File Offset: 0x00095B98
		public #vq(#8I #wq, #zBe #xq, #vd #mj, #BLb #fj, #mAe #6c, ICoreServices #0c, #zJ #yq, #qW #1c, #rBc #zq, #xAc #Aq, #sib #Bq)
		{
			this.#a = #wq;
			this.#b = #xq;
			this.#c = #mj;
			this.#d = #fj;
			this.#e = #0c;
			this.#g = #yq;
			this.#f = #1c;
			this.#h = #zq;
			this.#i = #Aq;
			this.#j = #Bq;
			this.#l = #6c;
			this.#j.RequestClose += this.#pq;
		}

		// Token: 0x170003FF RID: 1023
		// (get) Token: 0x060009BB RID: 2491 RVA: 0x0000D73E File Offset: 0x0000B93E
		public #mAe Context { get; }

		// Token: 0x060009BC RID: 2492 RVA: 0x0000D74A File Offset: 0x0000B94A
		public void #oq()
		{
			if (this.#k.#YXd())
			{
				LayoutHelper.BeginInvokeOnApplicationThread(new Action(this.#uq));
			}
		}

		// Token: 0x060009BD RID: 2493 RVA: 0x0000D777 File Offset: 0x0000B977
		private void #pq(object #Ge, EventArgs #He)
		{
			this.#sq();
		}

		// Token: 0x060009BE RID: 2494 RVA: 0x00097A24 File Offset: 0x00095C24
		private void #qq()
		{
			IReadOnlyList<#DBe> readOnlyList = this.#rq();
			if (!readOnlyList.Any<#DBe>())
			{
				return;
			}
			if (!this.#tq())
			{
				this.#a.#od(true);
			}
			#qW #qW = this.#f;
			bool flag;
			if (#qW == null)
			{
				flag = true;
			}
			else
			{
				DesignEngine designEngine = #qW.DesignEngine;
				bool? flag2;
				if (designEngine == null)
				{
					flag2 = null;
				}
				else
				{
					#l4e #l4e = designEngine.OutputModel;
					flag2 = ((#l4e != null) ? new bool?(#l4e.SolveCompleted) : null);
				}
				bool? flag3 = flag2;
				bool flag4 = true;
				flag = !(flag3.GetValueOrDefault() == flag4 & flag3 != null);
			}
			if (flag)
			{
				return;
			}
			foreach (#DBe #jAe in readOnlyList)
			{
				this.Context.#iAe(#jAe);
			}
			this.Context.IsActive = true;
			this.#d.#YKb(new DiagramsScopeActivationParameters());
			this.#c.#kd();
			this.#e.MessageBus.#RV();
			this.#j.#cg();
		}

		// Token: 0x060009BF RID: 2495 RVA: 0x00097B58 File Offset: 0x00095D58
		private IReadOnlyList<#DBe> #rq()
		{
			IReadOnlyList<#DBe> result;
			try
			{
				ConsideredAxis consideredAxis = this.#e.Project.Model.Options.ConsideredAxis;
				IReadOnlyList<#DBe> readOnlyList = (consideredAxis == ConsideredAxis.Both) ? this.#b.#ZAe() : this.#b.#YAe();
				foreach (#DBe #DBe in readOnlyList)
				{
					if (#DBe.RunAxis != consideredAxis)
					{
						throw new InvalidDataException(Strings.StringCannotSuperimposeImportedDiagramHasDifferentRunAxis);
					}
				}
				result = readOnlyList;
			}
			catch (InvalidDataException ex)
			{
				string #SSc = this.#e.DialogService.#5Sc(Strings.StringImportOperationAborted, ex.Message.#A2d());
				this.#e.DialogService.#qn(this.#e.DialogService.ActiveWindow, #SSc);
				result = new List<#DBe>();
			}
			catch (Exception #ob)
			{
				this.#h.#bzc(#ob, #Phc.#3hc(107413378), new #3Hc(this.#i.ApplicationName));
				result = new List<#DBe>();
			}
			return result;
		}

		// Token: 0x060009C0 RID: 2496 RVA: 0x00097CA4 File Offset: 0x00095EA4
		private void #sq()
		{
			this.Context.#yl();
			this.#d.#YKb(new DiagramsScopeActivationParameters());
			this.#c.#kd();
			this.#e.MessageBus.#RV();
		}

		// Token: 0x060009C1 RID: 2497 RVA: 0x0000D787 File Offset: 0x0000B987
		private bool #tq()
		{
			this.#g.#KA();
			return this.#g.State == #tJ.#b;
		}

		// Token: 0x060009C2 RID: 2498 RVA: 0x00097CF4 File Offset: 0x00095EF4
		[CompilerGenerated]
		private void #uq()
		{
			try
			{
				if (this.Context.IsActive)
				{
					this.#sq();
				}
				else
				{
					this.#qq();
				}
			}
			finally
			{
				this.#k.#ZXd();
			}
		}

		// Token: 0x0400036E RID: 878
		private readonly #8I #a;

		// Token: 0x0400036F RID: 879
		private readonly #zBe #b;

		// Token: 0x04000370 RID: 880
		private readonly #vd #c;

		// Token: 0x04000371 RID: 881
		private readonly #BLb #d;

		// Token: 0x04000372 RID: 882
		private readonly ICoreServices #e;

		// Token: 0x04000373 RID: 883
		private readonly #qW #f;

		// Token: 0x04000374 RID: 884
		private readonly #zJ #g;

		// Token: 0x04000375 RID: 885
		private readonly #rBc #h;

		// Token: 0x04000376 RID: 886
		private readonly #xAc #i;

		// Token: 0x04000377 RID: 887
		private readonly #sib #j;

		// Token: 0x04000378 RID: 888
		private readonly NonBlockingLock #k = new NonBlockingLock();

		// Token: 0x04000379 RID: 889
		[CompilerGenerated]
		private readonly #mAe #l;
	}
}
