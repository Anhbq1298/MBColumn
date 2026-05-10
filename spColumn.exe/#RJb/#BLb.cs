using System;
using System.ComponentModel;
using #APb;
using StructurePoint.Products.Column.Editor.Diagrams;
using StructurePoint.Products.Column.Editor.Project;
using StructurePoint.Products.Column.Editor.Section;

namespace #RJb
{
	// Token: 0x02000673 RID: 1651
	internal interface #BLb : INotifyPropertyChanged
	{
		// Token: 0x140000D2 RID: 210
		// (add) Token: 0x0600378E RID: 14222
		// (remove) Token: 0x0600378F RID: 14223
		event EventHandler<#QJb> ActiveScopeChanged;

		// Token: 0x17001133 RID: 4403
		// (get) Token: 0x06003790 RID: 14224
		#zLb ActiveScope { get; }

		// Token: 0x17001134 RID: 4404
		// (get) Token: 0x06003791 RID: 14225
		#BPb Diagrams { get; }

		// Token: 0x17001135 RID: 4405
		// (get) Token: 0x06003792 RID: 14226
		#SPb Section { get; }

		// Token: 0x17001136 RID: 4406
		// (get) Token: 0x06003793 RID: 14227
		#KPb Project { get; }

		// Token: 0x06003794 RID: 14228
		void #XKb(ProjectScopeActivationParameters #Pc);

		// Token: 0x06003795 RID: 14229
		void #YKb(DiagramsScopeActivationParameters #Pc);

		// Token: 0x06003796 RID: 14230
		void #ZKb(SectionScopeActivationParameters #Pc);

		// Token: 0x06003797 RID: 14231
		void #WKb();
	}
}
