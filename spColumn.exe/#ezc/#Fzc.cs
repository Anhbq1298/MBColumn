using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Controls;
using StructurePoint.CoreAssets.GUI.Framework;

namespace #ezc
{
	// Token: 0x02000B3A RID: 2874
	internal interface #Fzc<out #fx> : INotifyPropertyChanged, #RBc<!0>, IViewModel where #fx : #QBc
	{
		// Token: 0x17001AC2 RID: 6850
		// (get) Token: 0x06005DF3 RID: 24051
		bool HasErrors { get; }

		// Token: 0x17001AC3 RID: 6851
		// (get) Token: 0x06005DF4 RID: 24052
		bool IsValid { get; }

		// Token: 0x06005DF5 RID: 24053
		void #zzc();

		// Token: 0x06005DF6 RID: 24054
		IEnumerable #Azc(string #em);

		// Token: 0x06005DF7 RID: 24055
		void #Bzc(ValidationErrorEventArgs #He);

		// Token: 0x06005DF8 RID: 24056
		bool #Czc(string #em);

		// Token: 0x06005DF9 RID: 24057
		void #2I();

		// Token: 0x1400016F RID: 367
		// (add) Token: 0x06005DFA RID: 24058
		// (remove) Token: 0x06005DFB RID: 24059
		event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
	}
}
