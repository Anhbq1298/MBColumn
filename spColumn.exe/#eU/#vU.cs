using System;

namespace #eU
{
	// Token: 0x020002AA RID: 682
	internal interface #vU
	{
		// Token: 0x14000037 RID: 55
		// (add) Token: 0x0600165E RID: 5726
		// (remove) Token: 0x0600165F RID: 5727
		event EventHandler LoadingProject;

		// Token: 0x17000800 RID: 2048
		// (get) Token: 0x06001660 RID: 5728
		bool IsProjectLoaded { get; }

		// Token: 0x17000801 RID: 2049
		// (get) Token: 0x06001661 RID: 5729
		string CurrentProject { get; }

		// Token: 0x17000802 RID: 2050
		// (get) Token: 0x06001662 RID: 5730
		string CurrentlyLoadedFilePath { get; }

		// Token: 0x06001663 RID: 5731
		bool? #kF(string #So, bool #xK);

		// Token: 0x06001664 RID: 5732
		bool? #yK(string #zK);

		// Token: 0x06001665 RID: 5733
		bool? #AK();

		// Token: 0x06001666 RID: 5734
		bool? #BK();

		// Token: 0x06001667 RID: 5735
		bool? #DK(Action #EK = null);

		// Token: 0x06001668 RID: 5736
		bool? #FK();

		// Token: 0x06001669 RID: 5737
		void #CK();
	}
}
