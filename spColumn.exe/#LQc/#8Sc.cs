using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows;

namespace #LQc
{
	// Token: 0x02000C63 RID: 3171
	internal interface #8Sc
	{
		// Token: 0x17001C6B RID: 7275
		// (get) Token: 0x0600663F RID: 26175
		// (set) Token: 0x06006640 RID: 26176
		bool Enabled { get; set; }

		// Token: 0x17001C6C RID: 7276
		// (get) Token: 0x06006641 RID: 26177
		Window MainWindow { get; }

		// Token: 0x17001C6D RID: 7277
		// (get) Token: 0x06006642 RID: 26178
		Window ActiveWindow { get; }

		// Token: 0x17001C6E RID: 7278
		// (get) Token: 0x06006643 RID: 26179
		bool IsAnyMessageBoxOpen { get; }

		// Token: 0x06006644 RID: 26180
		[SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
		IntPtr #PSc();

		// Token: 0x06006645 RID: 26181
		MessageBoxResult #od(string #SSc, string #MQc, MessageBoxButton #TSc, MessageBoxImage #USc, MessageBoxResult #VSc, MessageBoxOptions #mA);

		// Token: 0x06006646 RID: 26182
		MessageBoxResult #od(Window #WSc, string #SSc, string #MQc, MessageBoxButton #TSc, MessageBoxImage #USc, MessageBoxResult #VSc, MessageBoxOptions #mA);

		// Token: 0x06006647 RID: 26183
		MessageBoxResult #od(string #SSc, MessageBoxButton #TSc, MessageBoxImage #USc, MessageBoxResult #VSc, MessageBoxOptions #mA);

		// Token: 0x06006648 RID: 26184
		MessageBoxResult #od(string #SSc, MessageBoxButton #TSc, MessageBoxImage #USc);

		// Token: 0x06006649 RID: 26185
		MessageBoxResult #od(string #Hkb, string #XSc, MessageBoxButton #TSc, MessageBoxImage #USc);

		// Token: 0x0600664A RID: 26186
		[SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords", MessageId = "Error")]
		void #qn(string #SSc);

		// Token: 0x0600664B RID: 26187
		void #ZSc(string #SSc);

		// Token: 0x0600664C RID: 26188
		void #ZSc(Window #WSc, string #SSc);

		// Token: 0x0600664D RID: 26189
		MessageBoxResult #0Sc(Window #jA, string #5);

		// Token: 0x0600664E RID: 26190
		void #pn(string #SSc);

		// Token: 0x0600664F RID: 26191
		MessageBoxResult #3Sc(string #SSc, MessageBoxButton #4Sc, MessageBoxResult #VSc);

		// Token: 0x06006650 RID: 26192
		void #qn(Window #WSc, string #SSc);

		// Token: 0x06006651 RID: 26193
		MessageBoxResult #od(TimeSpan #YSc, string #SSc, string #MQc, MessageBoxButton #TSc, MessageBoxImage #USc, MessageBoxResult #VSc, MessageBoxOptions #mA);

		// Token: 0x06006652 RID: 26194
		MessageBoxResult #od(TimeSpan #YSc, Window #jA, string #SSc, string #MQc, MessageBoxButton #TSc, MessageBoxImage #USc, MessageBoxResult #VSc, MessageBoxOptions #mA);

		// Token: 0x06006653 RID: 26195
		void #QSc();

		// Token: 0x06006654 RID: 26196
		void #RSc(Window #u0b);

		// Token: 0x06006655 RID: 26197
		MessageBoxResult #od(Window #WSc, string #SSc, MessageBoxButton #TSc, MessageBoxImage #USc, MessageBoxResult #VSc, MessageBoxOptions #mA);

		// Token: 0x06006656 RID: 26198
		MessageBoxResult #od(Window #WSc, string #SSc, MessageBoxButton #TSc, MessageBoxImage #USc);

		// Token: 0x06006657 RID: 26199
		MessageBoxResult #3Sc(Window #WSc, string #SSc, MessageBoxButton #4Sc, MessageBoxResult #VSc);

		// Token: 0x06006658 RID: 26200
		void #pn(Window #jA, string #hvb);

		// Token: 0x06006659 RID: 26201
		void #pn(Window #jA, string #MQc, string #5);

		// Token: 0x0600665A RID: 26202
		MessageBoxResult #1Sc(Window #jA, string #MQc, string #5, MessageBoxButton #NQc, MessageBoxImage #Kl);

		// Token: 0x0600665B RID: 26203
		MessageBoxResult #1Sc(Window #jA, string #MQc, string #5, MessageBoxButton #NQc, MessageBoxImage #Kl, MessageBoxResult #VSc);

		// Token: 0x0600665C RID: 26204
		void #2Sc(Window #jA, string #MQc, string #5, MessageBoxButton #NQc, MessageBoxImage #Kl);

		// Token: 0x0600665D RID: 26205
		void #2Sc(Func<Window> #jA, string #MQc, string #5, MessageBoxButton #NQc, MessageBoxImage #Kl);

		// Token: 0x0600665E RID: 26206
		string #5Sc(string #YE, string #Ukc);

		// Token: 0x0600665F RID: 26207
		bool #ABf();
	}
}
