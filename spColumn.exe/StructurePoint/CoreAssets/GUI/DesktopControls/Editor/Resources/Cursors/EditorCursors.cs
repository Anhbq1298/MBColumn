using System;
using System.Windows.Input;
using #7hc;
using StructurePoint.CoreAssets.GUI.SharedResources;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Resources.Cursors
{
	// Token: 0x02000AEB RID: 2795
	public sealed class EditorCursors : WpfResourcesHelper
	{
		// Token: 0x17001A0D RID: 6669
		// (get) Token: 0x06005B33 RID: 23347 RVA: 0x0004C4E2 File Offset: 0x0004A6E2
		public static Uri Magnify_Cursor_Uri
		{
			get
			{
				return WpfResourcesHelper.GetResourceUrl(EditorCursors.OwnerType, EditorCursors.RootType, #Phc.#3hc(107422091));
			}
		}

		// Token: 0x17001A0E RID: 6670
		// (get) Token: 0x06005B34 RID: 23348 RVA: 0x0004C4FD File Offset: 0x0004A6FD
		public static Uri Pan_Cursor_Uri
		{
			get
			{
				return WpfResourcesHelper.GetResourceUrl(EditorCursors.OwnerType, EditorCursors.RootType, #Phc.#3hc(107422106));
			}
		}

		// Token: 0x17001A0F RID: 6671
		// (get) Token: 0x06005B35 RID: 23349 RVA: 0x0004C518 File Offset: 0x0004A718
		public static Uri Rectangle_Cursor_Uri
		{
			get
			{
				return WpfResourcesHelper.GetResourceUrl(EditorCursors.OwnerType, EditorCursors.RootType, #Phc.#3hc(107422053));
			}
		}

		// Token: 0x17001A10 RID: 6672
		// (get) Token: 0x06005B36 RID: 23350 RVA: 0x0004C533 File Offset: 0x0004A733
		public static Uri Rotate3D_Cursor_Uri
		{
			get
			{
				return WpfResourcesHelper.GetResourceUrl(EditorCursors.OwnerType, EditorCursors.RootType, #Phc.#3hc(107422024));
			}
		}

		// Token: 0x17001A11 RID: 6673
		// (get) Token: 0x06005B37 RID: 23351 RVA: 0x0004C54E File Offset: 0x0004A74E
		public static Cursor Magnify_Cursor
		{
			get
			{
				return WpfResourcesHelper.GetCursor(EditorCursors.OwnerType, EditorCursors.RootType, #Phc.#3hc(107422091));
			}
		}

		// Token: 0x17001A12 RID: 6674
		// (get) Token: 0x06005B38 RID: 23352 RVA: 0x0004C569 File Offset: 0x0004A769
		public static Cursor Pan_Cursor
		{
			get
			{
				return WpfResourcesHelper.GetCursor(EditorCursors.OwnerType, EditorCursors.RootType, #Phc.#3hc(107422106));
			}
		}

		// Token: 0x17001A13 RID: 6675
		// (get) Token: 0x06005B39 RID: 23353 RVA: 0x0004C584 File Offset: 0x0004A784
		public static Cursor Rectangle_Cursor
		{
			get
			{
				return WpfResourcesHelper.GetCursor(EditorCursors.OwnerType, EditorCursors.RootType, #Phc.#3hc(107422053));
			}
		}

		// Token: 0x17001A14 RID: 6676
		// (get) Token: 0x06005B3A RID: 23354 RVA: 0x0004C59F File Offset: 0x0004A79F
		public static Cursor Rotate3D_Cursor
		{
			get
			{
				return WpfResourcesHelper.GetCursor(EditorCursors.OwnerType, EditorCursors.RootType, #Phc.#3hc(107422024));
			}
		}

		// Token: 0x17001A15 RID: 6677
		// (get) Token: 0x06005B3B RID: 23355 RVA: 0x0004C5BA File Offset: 0x0004A7BA
		public static byte[] Magnify_CursorData
		{
			get
			{
				return WpfResourcesHelper.GetResourceData(EditorCursors.OwnerType, EditorCursors.RootType, #Phc.#3hc(107422091));
			}
		}

		// Token: 0x17001A16 RID: 6678
		// (get) Token: 0x06005B3C RID: 23356 RVA: 0x0004C5D5 File Offset: 0x0004A7D5
		public static byte[] Pan_CursorData
		{
			get
			{
				return WpfResourcesHelper.GetResourceData(EditorCursors.OwnerType, EditorCursors.RootType, #Phc.#3hc(107422106));
			}
		}

		// Token: 0x17001A17 RID: 6679
		// (get) Token: 0x06005B3D RID: 23357 RVA: 0x0004C5F0 File Offset: 0x0004A7F0
		public static byte[] Rectangle_CursorData
		{
			get
			{
				return WpfResourcesHelper.GetResourceData(EditorCursors.OwnerType, EditorCursors.RootType, #Phc.#3hc(107422053));
			}
		}

		// Token: 0x17001A18 RID: 6680
		// (get) Token: 0x06005B3E RID: 23358 RVA: 0x0004C60B File Offset: 0x0004A80B
		public static byte[] Rotate3D_CursorData
		{
			get
			{
				return WpfResourcesHelper.GetResourceData(EditorCursors.OwnerType, EditorCursors.RootType, #Phc.#3hc(107422024));
			}
		}

		// Token: 0x040025F4 RID: 9716
		private static readonly Type RootType = typeof(EyeshotEditor);

		// Token: 0x040025F5 RID: 9717
		private static readonly Type OwnerType = typeof(EditorCursors);
	}
}
