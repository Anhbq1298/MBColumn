using System;
using System.Collections.Generic;
using #12e;
using #gMe;
using #hZe;
using #IWe;
using #MYe;
using #y6e;
using #z5e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Input;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Output;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;

namespace #X7e
{
	// Token: 0x02001395 RID: 5013
	internal interface #38e
	{
		// Token: 0x0600A7DD RID: 42973
		float #Y7e(float #Z7e, float #07e, float #17e, float #27e, float #37e);

		// Token: 0x0600A7DE RID: 42974
		float #WSe(float #47e, float #57e, #B6e #c8, float #67e);

		// Token: 0x0600A7DF RID: 42975
		#vZe #77e(float #Qje, float #87e, #x0e #VIb, #Fce #Vne, float #97e, InputModel #a8e, bool #NSe);

		// Token: 0x0600A7E0 RID: 42976
		bool #y7e(bool #uQe, float[] #0Ne);

		// Token: 0x0600A7E1 RID: 42977
		int #A7e(float #TRe);

		// Token: 0x0600A7E2 RID: 42978
		float #b8e(float #OQe, float #c8e, #Fce #Vne, float #MSe, bool #NSe, InputModel #a8e);

		// Token: 0x0600A7E3 RID: 42979
		float #d8e(float #MSe);

		// Token: 0x0600A7E4 RID: 42980
		#L6e #B7e(#L6e #PE);

		// Token: 0x0600A7E5 RID: 42981
		float #dYe(float #e8e, float #2je, float #USe, float #f8e);

		// Token: 0x0600A7E6 RID: 42982
		float #g8e(float #Qje, float #57e);

		// Token: 0x0600A7E7 RID: 42983
		float #h8e(float #ivb, float #i8e, bool #uQe, float #TRe, InputModel #a8e);

		// Token: 0x0600A7E8 RID: 42984
		bool #C7e(float #Tdb, float #IPe, #X3 #Nwb, InputModel #hMe, ref float #D7e, ref int #ri);

		// Token: 0x0600A7E9 RID: 42985
		float #E7e(float #mRe, float[] #eRe, float #gRe);

		// Token: 0x0600A7EA RID: 42986
		float #j8e(InputModel #hMe, RuntimeModel #iMe, float #k8e, float #l8e);

		// Token: 0x0600A7EB RID: 42987
		void #m8e(float #USe, ref float #n8e, ref float #o8e);

		// Token: 0x0600A7EC RID: 42988
		float #p8e(float #Qje, float #57e);

		// Token: 0x0600A7ED RID: 42989
		bool #q8e(#K2 #OQ);

		// Token: 0x0600A7EE RID: 42990
		float #r8e();

		// Token: 0x0600A7EF RID: 42991
		bool #F7e();

		// Token: 0x0600A7F0 RID: 42992
		#rXe #J7e(#l4e #Kwe, RuntimeModel #iMe);

		// Token: 0x0600A7F1 RID: 42993
		float #0je();

		// Token: 0x0600A7F2 RID: 42994
		float #Wje(#D6e #6jb, float #3Q);

		// Token: 0x0600A7F3 RID: 42995
		float #Xje(#D6e #6jb, float #3Q);

		// Token: 0x0600A7F4 RID: 42996
		float #Zje(#D6e #6jb, float #3Q);

		// Token: 0x0600A7F5 RID: 42997
		float #Lje(float #Mje, float #qLe);

		// Token: 0x0600A7F6 RID: 42998
		NaNullableFloat #K7e(float #L7e, ref FactoredMoment.#wif #M7e);

		// Token: 0x0600A7F7 RID: 42999
		float? #s8e(float #e8e, float #2je, float #USe, float #f8e);

		// Token: 0x0600A7F8 RID: 43000
		void #t8e(#i5e #u8e, float #MSe, InputModel #hMe, bool #NSe);

		// Token: 0x0600A7F9 RID: 43001
		void #v8e(#l4e #Kwe, #S0e #Rfb, int #4jb, #u3e.#zif #XXe, LoadsExt #ivb, float #c8e, #Fce #Vne);

		// Token: 0x0600A7FA RID: 43002
		void #w8e(#l4e #Kwe, #S0e #Rfb, int #4jb, #u3e.#zif #XXe, LoadsExt #ivb, float #c8e, #Fce #Vne);

		// Token: 0x0600A7FB RID: 43003
		void #x8e(#l4e #Kwe, #S0e #WXe, int #4jb, float #FYe, #u3e.#zif #XXe, LoadsExt #ivb, float #y8e, float #z8e, float #c8e, #Fce #Vne);

		// Token: 0x0600A7FC RID: 43004
		void #A8e(#S0e #WXe, int #4jb, float #FYe, #u3e.#zif #XXe, LoadsExt #ivb, float #lYe, #l4e #Kwe, float #c8e, #Fce #Vne);

		// Token: 0x0600A7FD RID: 43005
		void #B8e(List<ControlPoint.#uif> #QLb);

		// Token: 0x0600A7FE RID: 43006
		void #C8e(ControlPoint #c4e, float #c8e, #Fce #Vne);

		// Token: 0x0600A7FF RID: 43007
		bool #N7e(int #O7e, int #P7e, int #Q7e, #Lce[][] #R7e, int #S7e);

		// Token: 0x0600A800 RID: 43008
		NaNullableFloat #T7e(int #Lpb, #Lce #jdd, bool #U7e);

		// Token: 0x0600A801 RID: 43009
		bool #G7e(bool #H7e, int #I7e);

		// Token: 0x0600A802 RID: 43010
		#2Ye #D8e(#l4e #Od);

		// Token: 0x0600A803 RID: 43011
		#2Ye #E8e(#l4e #Od);

		// Token: 0x0600A804 RID: 43012
		#2Ye #F8e();

		// Token: 0x0600A805 RID: 43013
		#u3e.#yif? #G8e();

		// Token: 0x0600A806 RID: 43014
		#u3e.#yif? #H8e();

		// Token: 0x0600A807 RID: 43015
		#u3e.#yif? #I8e();

		// Token: 0x0600A808 RID: 43016
		#u3e.#Aif? #J8e();

		// Token: 0x0600A809 RID: 43017
		#u3e.#Aif? #K8e();

		// Token: 0x0600A80A RID: 43018
		#u3e.#Aif #L8e();

		// Token: 0x0600A80B RID: 43019
		#u3e.#Aif #M8e();

		// Token: 0x0600A80C RID: 43020
		#u3e.#yif #N8e();

		// Token: 0x0600A80D RID: 43021
		#u3e.#yif #O8e();

		// Token: 0x0600A80E RID: 43022
		#u3e.#yif #P8e();

		// Token: 0x0600A80F RID: 43023
		float #G2(#K2 #Nwb);

		// Token: 0x0600A810 RID: 43024
		float #QRe(float #ivb, float #sQe, float #tQe, float #wQe);

		// Token: 0x0600A811 RID: 43025
		bool #Q8e(RuntimeModel #iMe, #fMe #wMe, #K2 #OQ, float #Udb);

		// Token: 0x0600A812 RID: 43026
		float #R8e(#G6e #jce, float[] #S8e, float #l8e);

		// Token: 0x0600A813 RID: 43027
		float #WWi();
	}
}
