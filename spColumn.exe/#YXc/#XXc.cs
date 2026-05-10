using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using #N6c;
using StructurePoint.CoreAssets.GUI.DesktopControls.Tree;
using StructurePoint.CoreAssets.GUI.Framework.Collections;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace #YXc
{
	// Token: 0x02000C9D RID: 3229
	internal sealed class #XXc : CancelEventArgs
	{
		// Token: 0x0600689B RID: 26779 RVA: 0x000534D9 File Offset: 0x000516D9
		public #XXc(Point #0bb)
		{
			this.#a = new CustomObservableCollection<ITreeItemData>();
			this.Position = #0bb;
		}

		// Token: 0x17001CF5 RID: 7413
		// (get) Token: 0x0600689C RID: 26780 RVA: 0x000534F3 File Offset: 0x000516F3
		// (set) Token: 0x0600689D RID: 26781 RVA: 0x000534FB File Offset: 0x000516FB
		public Point Position { get; private set; }

		// Token: 0x17001CF6 RID: 7414
		// (get) Token: 0x0600689E RID: 26782 RVA: 0x00053504 File Offset: 0x00051704
		[SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public #k8c<ITreeItemData> ItemsSource
		{
			get
			{
				return this.#a;
			}
		}

		// Token: 0x0600689F RID: 26783 RVA: 0x0005350C File Offset: 0x0005170C
		public void #VXc()
		{
			Collection<ITreeItemData> collection = this.#a;
			if (!false)
			{
				collection.Clear();
			}
		}

		// Token: 0x060068A0 RID: 26784 RVA: 0x0005351F File Offset: 0x0005171F
		public void #WXc(IEnumerable<ITreeItemData> #8f)
		{
			CustomObservableCollection<ITreeItemData> customObservableCollection = this.#a;
			if (2 != 0)
			{
				customObservableCollection.#pR(#8f);
			}
		}

		// Token: 0x04002AFB RID: 11003
		private CustomObservableCollection<ITreeItemData> #a;

		// Token: 0x04002AFC RID: 11004
		[CompilerGenerated]
		private Point #b;
	}
}
