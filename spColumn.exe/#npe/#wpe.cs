using System;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;

namespace #npe
{
	// Token: 0x02001110 RID: 4368
	internal sealed class #wpe
	{
		// Token: 0x060093F7 RID: 37879 RVA: 0x001F8420 File Offset: 0x001F6620
		public static void #qpe(ColumnStorageModel #Od)
		{
			#Od.InvestigateInputFlag = 15;
			#Od.DesignInputFlag = 15;
			#Od.SlendernessInputFlag = 31;
			if (#Od.Options.InvestigationLoad == LoadType.Undefined)
			{
				#Od.InvestigateInputFlag &= -9;
			}
			if (#Od.Options.DesignLoad == LoadType.Undefined)
			{
				#Od.DesignInputFlag &= -9;
			}
		}

		// Token: 0x060093F8 RID: 37880 RVA: 0x00009E6A File Offset: 0x0000806A
		public static void #rpe(ColumnStorageModel #Od)
		{
		}

		// Token: 0x060093F9 RID: 37881 RVA: 0x001F8480 File Offset: 0x001F6680
		public static void #xkb(ColumnStorageModel #X)
		{
			#X.Options.DesignLoad = LoadType.Factored;
			#X.Options.InvestigationLoad = LoadType.NoLoads;
			#X.InvestigateInputFlag |= 8;
			#X.DesignInputFlag |= 8;
			#X.ProjectInfo.Project = string.Empty;
			#X.ProjectInfo.ColumnId = string.Empty;
			#X.ProjectInfo.Engineer = string.Empty;
			#wpe.#vpe(#X);
		}

		// Token: 0x060093FA RID: 37882 RVA: 0x001F84F8 File Offset: 0x001F66F8
		public static void #spe(ColumnStorageModel #Od)
		{
			if (#Od.Options.InvestigationLoad == LoadType.Controld || #Od.Options.InvestigationLoad == LoadType.Undefined)
			{
				#Od.Options.InvestigationLoad = LoadType.NoLoads;
				#Od.InvestigateInputFlag |= 8;
			}
			if (#Od.Options.DesignLoad == LoadType.Controld || #Od.Options.DesignLoad == LoadType.Undefined)
			{
				#Od.Options.DesignLoad = LoadType.NoLoads;
				#Od.DesignInputFlag |= 8;
			}
		}

		// Token: 0x060093FB RID: 37883 RVA: 0x00076564 File Offset: 0x00074764
		public static void #tpe(ColumnStorageModel #X)
		{
			#wpe.#vpe(#X);
		}

		// Token: 0x060093FC RID: 37884 RVA: 0x001F8574 File Offset: 0x001F6774
		private static void #vpe(ColumnStorageModel #X)
		{
			float minDimension = #X.ReductionFactors.MinDimension;
			#1pe.#vpe(#X.Options.Unit, #X.Options.Code, #X.Options.ConfinementType, #X.MaterialProperties.Precast, #X.ReductionFactors);
			#X.ReductionFactors.MinDimension = minDimension;
		}
	}
}
