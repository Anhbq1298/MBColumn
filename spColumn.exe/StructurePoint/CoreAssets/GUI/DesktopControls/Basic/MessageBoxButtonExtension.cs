using System;
using System.Windows;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Basic
{
	// Token: 0x02000AA0 RID: 2720
	internal static class MessageBoxButtonExtension
	{
		// Token: 0x060058CC RID: 22732 RVA: 0x0016AE6C File Offset: 0x0016906C
		public static MessageBoxResult ToMessageBoxResult(this MessageBoxButton buttons, MessageBoxResult defaultResult)
		{
			switch (buttons)
			{
			case MessageBoxButton.OK:
				return MessageBoxResult.OK;
			case MessageBoxButton.OKCancel:
				if (defaultResult != MessageBoxResult.Cancel)
				{
					return MessageBoxResult.OK;
				}
				return defaultResult;
			case MessageBoxButton.YesNoCancel:
				if (defaultResult != MessageBoxResult.No && defaultResult != MessageBoxResult.Cancel)
				{
					return MessageBoxResult.Yes;
				}
				return defaultResult;
			case MessageBoxButton.YesNo:
				if (defaultResult != MessageBoxResult.No)
				{
					return MessageBoxResult.Yes;
				}
				return defaultResult;
			}
			return MessageBoxResult.None;
		}

		// Token: 0x060058CD RID: 22733 RVA: 0x00049822 File Offset: 0x00047A22
		public static int ToDialogButtonId(this MessageBoxResult result, MessageBoxButton buttons)
		{
			if (buttons == MessageBoxButton.OK)
			{
				return 2;
			}
			return (int)result;
		}
	}
}
