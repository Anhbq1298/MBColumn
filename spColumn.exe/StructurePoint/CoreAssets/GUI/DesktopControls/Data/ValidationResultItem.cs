using System;
using #7hc;
using StructurePoint.CoreAssets.Localizer;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Data
{
	// Token: 0x020009F2 RID: 2546
	public sealed class ValidationResultItem : NotifyPropertyChangedObjectBase
	{
		// Token: 0x06005373 RID: 21363 RVA: 0x0004516F File Offset: 0x0004336F
		public ValidationResultItem(ValidationResultItemType type, string message, string title)
		{
			this.type = type;
			this.message = message;
			this.title = title;
		}

		// Token: 0x06005374 RID: 21364 RVA: 0x0004518C File Offset: 0x0004338C
		public ValidationResultItem(ValidationResultItemType type, string message)
		{
			this.type = type;
			this.message = message;
		}

		// Token: 0x06005375 RID: 21365 RVA: 0x0000C5B9 File Offset: 0x0000A7B9
		public ValidationResultItem()
		{
		}

		// Token: 0x170017CD RID: 6093
		// (get) Token: 0x06005376 RID: 21366 RVA: 0x000451A2 File Offset: 0x000433A2
		// (set) Token: 0x06005377 RID: 21367 RVA: 0x00164318 File Offset: 0x00162518
		public ValidationResultItemType Type
		{
			get
			{
				return this.type;
			}
			set
			{
				this.SetProperty<ValidationResultItemType>(ref this.type, value, #Phc.#3hc(107462703));
				switch (value)
				{
				case ValidationResultItemType.Error:
					this.TypeString = Strings.StringError;
					return;
				case ValidationResultItemType.Warning:
					this.TypeString = Strings.StringWarning;
					return;
				case ValidationResultItemType.Info:
					this.TypeString = Strings.StringInfo;
					return;
				default:
					this.TypeString = string.Empty;
					return;
				}
			}
		}

		// Token: 0x170017CE RID: 6094
		// (get) Token: 0x06005378 RID: 21368 RVA: 0x000451AE File Offset: 0x000433AE
		// (set) Token: 0x06005379 RID: 21369 RVA: 0x000451BA File Offset: 0x000433BA
		public string TypeString
		{
			get
			{
				return this.typeString;
			}
			private set
			{
				this.SetProperty<string>(ref this.typeString, value, #Phc.#3hc(107462694));
			}
		}

		// Token: 0x170017CF RID: 6095
		// (get) Token: 0x0600537A RID: 21370 RVA: 0x000451E0 File Offset: 0x000433E0
		// (set) Token: 0x0600537B RID: 21371 RVA: 0x000451EC File Offset: 0x000433EC
		public string Message
		{
			get
			{
				return this.message;
			}
			set
			{
				this.SetProperty<string>(ref this.message, value, #Phc.#3hc(107383983));
			}
		}

		// Token: 0x170017D0 RID: 6096
		// (get) Token: 0x0600537C RID: 21372 RVA: 0x00045212 File Offset: 0x00043412
		// (set) Token: 0x0600537D RID: 21373 RVA: 0x0004521E File Offset: 0x0004341E
		public string Title
		{
			get
			{
				return this.title;
			}
			set
			{
				this.SetProperty<string>(ref this.title, value, #Phc.#3hc(107408142));
			}
		}

		// Token: 0x04002424 RID: 9252
		private ValidationResultItemType type;

		// Token: 0x04002425 RID: 9253
		private string message;

		// Token: 0x04002426 RID: 9254
		private string title;

		// Token: 0x04002427 RID: 9255
		private string typeString;
	}
}
