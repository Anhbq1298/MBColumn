using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using #7hc;
using #HI;
using #N6c;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.Products.Column.Services.API;
using Telerik.Windows.Data;

namespace StructurePoint.Products.Column.ViewModels.Items
{
	// Token: 0x020000F4 RID: 244
	internal sealed class RecentProjectsManager : NotifyPropertyChangedObjectBase, #JI
	{
		// Token: 0x060007CE RID: 1998 RVA: 0x0000BF36 File Offset: 0x0000A136
		public RecentProjectsManager(ISettingsManager settingsManager)
		{
			if (settingsManager == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107381742));
			}
			this.#b = settingsManager;
		}

		// Token: 0x1700034B RID: 843
		// (get) Token: 0x060007CF RID: 1999 RVA: 0x0000BF64 File Offset: 0x0000A164
		public RadObservableCollection<RecentDocumentListEntry> RecentProjects { get; }

		// Token: 0x060007D0 RID: 2000 RVA: 0x00091FF4 File Offset: 0x000901F4
		public void #F7c(RecentDocumentListEntry #G7d)
		{
			this.RecentProjects.Remove(#G7d);
			List<string> #f = this.RecentProjects.Select(new Func<RecentDocumentListEntry, string>(RecentProjectsManager.<>c.<>9.#3Wh)).ToList<string>();
			this.#b.RecentProjects = #f;
		}

		// Token: 0x060007D1 RID: 2001 RVA: 0x00092058 File Offset: 0x00090258
		public void #xl(string #vl)
		{
			RecentProjectsManager.#92b #92b = new RecentProjectsManager.#92b();
			#92b.#a = #vl;
			if (string.IsNullOrWhiteSpace(#92b.#a))
			{
				return;
			}
			this.RecentProjects.#L6c(this.RecentProjects.Where(new Func<RecentDocumentListEntry, bool>(#92b.#1Ub)).ToList<RecentDocumentListEntry>());
			RecentDocumentListEntry recentDocumentListEntry = RecentDocumentListEntry.#ul(#92b.#a);
			if (recentDocumentListEntry != null)
			{
				this.RecentProjects.Insert(0, recentDocumentListEntry);
			}
			this.#Al(this.RecentProjects);
			this.#zl();
		}

		// Token: 0x060007D2 RID: 2002 RVA: 0x000920F4 File Offset: 0x000902F4
		public void #eb()
		{
			this.RecentProjects.Clear();
			List<string> list = this.#b.RecentProjects;
			List<string> list2 = (list != null) ? list.ToList<string>() : null;
			if (list2 == null)
			{
				return;
			}
			IEnumerable<string> source = list2;
			Func<string, RecentDocumentListEntry> selector;
			if ((selector = RecentProjectsManager.#2Ui.#a) == null)
			{
				selector = (RecentProjectsManager.#2Ui.#a = new Func<string, RecentDocumentListEntry>(RecentDocumentListEntry.#ul));
			}
			List<RecentDocumentListEntry> list3 = source.Select(selector).Where(new Func<RecentDocumentListEntry, bool>(RecentProjectsManager.<>c.<>9.#4Wh)).ToList<RecentDocumentListEntry>();
			if (this.#Al(list3))
			{
				this.#zl();
			}
			this.RecentProjects.AddRange(list3);
		}

		// Token: 0x060007D3 RID: 2003 RVA: 0x0000BF70 File Offset: 0x0000A170
		public void #yl()
		{
			this.RecentProjects.Clear();
			this.#b.RecentProjects = new List<string>();
		}

		// Token: 0x060007D4 RID: 2004 RVA: 0x000921AC File Offset: 0x000903AC
		private void #zl()
		{
			List<string> #f = this.RecentProjects.Select(new Func<RecentDocumentListEntry, string>(RecentProjectsManager.<>c.<>9.#5Wh)).ToList<string>();
			this.#b.RecentProjects = #f;
		}

		// Token: 0x060007D5 RID: 2005 RVA: 0x00092204 File Offset: 0x00090404
		private bool #Al(IList<RecentDocumentListEntry> #Bl)
		{
			bool result = false;
			while (#Bl.Count > 100)
			{
				#Bl.RemoveAt(#Bl.Count - 1);
				result = true;
			}
			return result;
		}

		// Token: 0x04000230 RID: 560
		private const int #a = 100;

		// Token: 0x04000231 RID: 561
		private readonly ISettingsManager #b;

		// Token: 0x04000232 RID: 562
		[CompilerGenerated]
		private readonly RadObservableCollection<RecentDocumentListEntry> #c = new RadObservableCollection<RecentDocumentListEntry>();

		// Token: 0x020000F5 RID: 245
		[CompilerGenerated]
		private static class #2Ui
		{
			// Token: 0x04000233 RID: 563
			public static Func<string, RecentDocumentListEntry> #a;
		}

		// Token: 0x020000F7 RID: 247
		[CompilerGenerated]
		private sealed class #92b
		{
			// Token: 0x060007DC RID: 2012 RVA: 0x0000BFC3 File Offset: 0x0000A1C3
			internal bool #1Ub(RecentDocumentListEntry #Rf)
			{
				return string.Equals(#Rf.FullPath, this.#a, StringComparison.OrdinalIgnoreCase);
			}

			// Token: 0x04000238 RID: 568
			public string #a;
		}
	}
}
