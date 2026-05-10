using System;
using System.ComponentModel;
using #45d;
using #sUd;

namespace #6re
{
	// Token: 0x02000296 RID: 662
	internal interface #yse : INotifyPropertyChanged, #wUd
	{
		// Token: 0x170007AF RID: 1967
		// (get) Token: 0x060015AA RID: 5546
		#55d UserSettingProvider { get; }

		// Token: 0x170007B0 RID: 1968
		// (get) Token: 0x060015AB RID: 5547
		#55d ApplicationSettingProvider { get; }

		// Token: 0x170007B1 RID: 1969
		// (get) Token: 0x060015AC RID: 5548
		// (set) Token: 0x060015AD RID: 5549
		bool ShowNominal { get; set; }

		// Token: 0x170007B2 RID: 1970
		// (get) Token: 0x060015AE RID: 5550
		// (set) Token: 0x060015AF RID: 5551
		bool ShowFactored { get; set; }

		// Token: 0x060015B0 RID: 5552
		void #gJ(#xse #ng);

		// Token: 0x060015B1 RID: 5553
		#xse #hJ();

		// Token: 0x060015B2 RID: 5554
		void #iJ(#5re #ng);

		// Token: 0x060015B3 RID: 5555
		#5re #jJ();

		// Token: 0x060015B4 RID: 5556
		#Gse #kJ();

		// Token: 0x060015B5 RID: 5557
		void #lJ(#Gse #mJ);
	}
}
