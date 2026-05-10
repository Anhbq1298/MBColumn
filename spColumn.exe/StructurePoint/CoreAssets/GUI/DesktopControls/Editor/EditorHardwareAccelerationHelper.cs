using System;
using VMDetector;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Editor
{
	// Token: 0x02000ADF RID: 2783
	public static class EditorHardwareAccelerationHelper
	{
		// Token: 0x17001986 RID: 6534
		// (get) Token: 0x06005A8D RID: 23181 RVA: 0x0004B59D File Offset: 0x0004979D
		public static EditorHardwareAccelerationHelper.AccelerationChecker TopViewport { get; } = new EditorHardwareAccelerationHelper.AccelerationChecker();

		// Token: 0x17001987 RID: 6535
		// (get) Token: 0x06005A8E RID: 23182 RVA: 0x0004B5A4 File Offset: 0x000497A4
		public static EditorHardwareAccelerationHelper.AccelerationChecker BackgroundViewport { get; } = new EditorHardwareAccelerationHelper.AccelerationChecker();

		// Token: 0x06005A8F RID: 23183 RVA: 0x0016F354 File Offset: 0x0016D554
		public static bool RunsOnVirtualMachine()
		{
			try
			{
				return VirtualMachineDetector.Assert();
			}
			catch (Exception)
			{
			}
			return false;
		}

		// Token: 0x02000AE0 RID: 2784
		public sealed class AccelerationChecker
		{
			// Token: 0x17001988 RID: 6536
			// (get) Token: 0x06005A91 RID: 23185 RVA: 0x0004B5C1 File Offset: 0x000497C1
			// (set) Token: 0x06005A92 RID: 23186 RVA: 0x0004B5C9 File Offset: 0x000497C9
			public Func<bool> IsHardwareAccelerationEnabledProvider { get; set; } = () => true;

			// Token: 0x17001989 RID: 6537
			// (get) Token: 0x06005A93 RID: 23187 RVA: 0x0016F380 File Offset: 0x0016D580
			public bool IsHardwareAccelerationEnabled
			{
				get
				{
					if (!this.isHardwareAccelerationCached)
					{
						this.cachedIsHardwareAccelerationEnabled = (!EditorHardwareAccelerationHelper.RunsOnVirtualMachine() && this.IsHardwareAccelerationEnabledProvider());
						this.isHardwareAccelerationCached = true;
					}
					return this.cachedIsHardwareAccelerationEnabled;
				}
			}

			// Token: 0x040025D4 RID: 9684
			private bool cachedIsHardwareAccelerationEnabled;

			// Token: 0x040025D5 RID: 9685
			private bool isHardwareAccelerationCached;
		}
	}
}
