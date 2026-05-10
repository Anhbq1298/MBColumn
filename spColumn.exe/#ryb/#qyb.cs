using System;
using System.ComponentModel;
using #cMb;
using #LFb;
using Telerik.Windows.Controls;

namespace #ryb
{
	// Token: 0x020004CA RID: 1226
	internal interface #qyb : INotifyPropertyChanged, #DNb
	{
		// Token: 0x17000F0C RID: 3852
		// (get) Token: 0x06002CEE RID: 11502
		#cOb SelectWrapper { get; }

		// Token: 0x17000F0D RID: 3853
		// (get) Token: 0x06002CEF RID: 11503
		#cOb MeasureWrapper { get; }

		// Token: 0x17000F0E RID: 3854
		// (get) Token: 0x06002CF0 RID: 11504
		#cOb MoveWrapper { get; }

		// Token: 0x17000F0F RID: 3855
		// (get) Token: 0x06002CF1 RID: 11505
		#cOb MirrorWrapper { get; }

		// Token: 0x17000F10 RID: 3856
		// (get) Token: 0x06002CF2 RID: 11506
		#cOb CopyWrapper { get; }

		// Token: 0x17000F11 RID: 3857
		// (get) Token: 0x06002CF3 RID: 11507
		#cOb RotateWrapper { get; }

		// Token: 0x17000F12 RID: 3858
		// (get) Token: 0x06002CF4 RID: 11508
		#cOb OffsetWrapper { get; }

		// Token: 0x17000F13 RID: 3859
		// (get) Token: 0x06002CF5 RID: 11509
		#cOb MergeWrapper { get; }

		// Token: 0x17000F14 RID: 3860
		// (get) Token: 0x06002CF6 RID: 11510
		#cOb SplitWrapper { get; }

		// Token: 0x17000F15 RID: 3861
		// (get) Token: 0x06002CF7 RID: 11511
		#cOb AlignVerticallyWrapper { get; }

		// Token: 0x17000F16 RID: 3862
		// (get) Token: 0x06002CF8 RID: 11512
		#cOb AlignHorizontallyWrapper { get; }

		// Token: 0x17000F17 RID: 3863
		// (get) Token: 0x06002CF9 RID: 11513
		DelegateCommand DeleteCommand { get; }

		// Token: 0x17000F18 RID: 3864
		// (get) Token: 0x06002CFA RID: 11514
		#cOb DeleteWrapper { get; }

		// Token: 0x17000F19 RID: 3865
		// (get) Token: 0x06002CFB RID: 11515
		#cOb AddArcSlabWraper { get; }

		// Token: 0x17000F1A RID: 3866
		// (get) Token: 0x06002CFC RID: 11516
		#cOb AddRectangleSlabWrapper { get; }

		// Token: 0x17000F1B RID: 3867
		// (get) Token: 0x06002CFD RID: 11517
		#cOb AddCircleSlabWrapper { get; }

		// Token: 0x17000F1C RID: 3868
		// (get) Token: 0x06002CFE RID: 11518
		#cOb AddPolygonSlabWrapper { get; }

		// Token: 0x17000F1D RID: 3869
		// (get) Token: 0x06002CFF RID: 11519
		#RFb CircleTool { get; }

		// Token: 0x17000F1E RID: 3870
		// (get) Token: 0x06002D00 RID: 11520
		#cOb AddSingleReinforcementBar { get; }

		// Token: 0x17000F1F RID: 3871
		// (get) Token: 0x06002D01 RID: 11521
		#cOb AddGridReinforcementBar { get; }

		// Token: 0x17000F20 RID: 3872
		// (get) Token: 0x06002D02 RID: 11522
		#cOb AddArcReinforcementBar { get; }

		// Token: 0x17000F21 RID: 3873
		// (get) Token: 0x06002D03 RID: 11523
		#cOb AddLineReinforcementBar { get; }

		// Token: 0x17000F22 RID: 3874
		// (get) Token: 0x06002D04 RID: 11524
		#cOb AddCircleReinforcementBar { get; }

		// Token: 0x17000F23 RID: 3875
		// (get) Token: 0x06002D05 RID: 11525
		#cOb AddRectReinforcementBar { get; }

		// Token: 0x17000F24 RID: 3876
		// (get) Token: 0x06002D06 RID: 11526
		#cOb EditIrregularReinforcementBars { get; }

		// Token: 0x06002D07 RID: 11527
		void #pyb();

		// Token: 0x06002D08 RID: 11528
		bool #9Vh();
	}
}
