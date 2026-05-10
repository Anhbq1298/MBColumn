using System;
using System.Windows.Input;
using #7hc;
using #LQc;
using StructurePoint.CoreAssets.Column.Core.Core.Diagnostics;
using StructurePoint.CoreAssets.GUI.Framework.Services;
using StructurePoint.CoreAssets.GUI.SharedResources;

namespace StructurePoint.Products.Column.Resources
{
	// Token: 0x0200001E RID: 30
	internal sealed class ColumnResources : WpfResourcesHelper
	{
		// Token: 0x060000A7 RID: 167 RVA: 0x0000376C File Offset: 0x0000196C
		public static IGenericLoaderWindow CreateSplashScreen()
		{
			return new #dRc(typeof(ColumnResources).Assembly, #Phc.#3hc(107394727), Logger.Instance, true);
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x060000A8 RID: 168 RVA: 0x0000379E File Offset: 0x0000199E
		public static Uri Black_Arrow_Cursor_Uri
		{
			get
			{
				return WpfResourcesHelper.GetResourceUrl(ColumnResources.OwnerType, ColumnResources.RootType, #Phc.#3hc(107394686));
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x060000A9 RID: 169 RVA: 0x000037C1 File Offset: 0x000019C1
		public static Uri Black_Arrow_Add_Cursor_Uri
		{
			get
			{
				return WpfResourcesHelper.GetResourceUrl(ColumnResources.OwnerType, ColumnResources.RootType, #Phc.#3hc(107394633));
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x060000AA RID: 170 RVA: 0x000037E4 File Offset: 0x000019E4
		public static Uri Cross_Add_Cursor_Uri
		{
			get
			{
				return WpfResourcesHelper.GetResourceUrl(ColumnResources.OwnerType, ColumnResources.RootType, #Phc.#3hc(107394604));
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x060000AB RID: 171 RVA: 0x00003807 File Offset: 0x00001A07
		public static Cursor Black_Arrow_Cursor
		{
			get
			{
				return WpfResourcesHelper.GetCursor(ColumnResources.OwnerType, ColumnResources.RootType, #Phc.#3hc(107394686));
			}
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x060000AC RID: 172 RVA: 0x0000382A File Offset: 0x00001A2A
		public static Cursor Black_Arrow_Add_Cursor
		{
			get
			{
				return WpfResourcesHelper.GetCursor(ColumnResources.OwnerType, ColumnResources.RootType, #Phc.#3hc(107394633));
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x060000AD RID: 173 RVA: 0x0000384D File Offset: 0x00001A4D
		public static Cursor Cross_Add_Cursor
		{
			get
			{
				return WpfResourcesHelper.GetCursor(ColumnResources.OwnerType, ColumnResources.RootType, #Phc.#3hc(107394604));
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x060000AE RID: 174 RVA: 0x00003870 File Offset: 0x00001A70
		public static byte[] Black_Arrow_CursorData
		{
			get
			{
				return WpfResourcesHelper.GetResourceData(ColumnResources.OwnerType, ColumnResources.RootType, #Phc.#3hc(107394686));
			}
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x060000AF RID: 175 RVA: 0x00003893 File Offset: 0x00001A93
		public static byte[] Black_Arrow_Add_CursorData
		{
			get
			{
				return WpfResourcesHelper.GetResourceData(ColumnResources.OwnerType, ColumnResources.RootType, #Phc.#3hc(107394633));
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x060000B0 RID: 176 RVA: 0x000038B6 File Offset: 0x00001AB6
		public static byte[] Cross_Add_CursorData
		{
			get
			{
				return WpfResourcesHelper.GetResourceData(ColumnResources.OwnerType, ColumnResources.RootType, #Phc.#3hc(107394604));
			}
		}

		// Token: 0x0400003D RID: 61
		private static readonly Type RootType = typeof(App);

		// Token: 0x0400003E RID: 62
		private static readonly Type OwnerType = typeof(ColumnResources);
	}
}
