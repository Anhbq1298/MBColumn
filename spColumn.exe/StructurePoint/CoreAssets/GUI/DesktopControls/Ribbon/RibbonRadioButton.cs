using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using #7hc;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Ribbon
{
	// Token: 0x020008AC RID: 2220
	public sealed class RibbonRadioButton : RibbonButton
	{
		// Token: 0x060045F6 RID: 17910 RVA: 0x0003A7CC File Offset: 0x000389CC
		public RibbonRadioButton(Image image, string text, bool large, object desiredValue) : base(image, text, large, null, null, true)
		{
			this.desiredValue = desiredValue;
		}

		// Token: 0x17001476 RID: 5238
		// (get) Token: 0x060045F7 RID: 17911 RVA: 0x0003A7E2 File Offset: 0x000389E2
		// (set) Token: 0x060045F8 RID: 17912 RVA: 0x0003A7EE File Offset: 0x000389EE
		public bool IsChecked
		{
			get
			{
				return this.isChecked;
			}
			set
			{
				if (this.isChecked != value)
				{
					this.isChecked = value;
					base.RaisePropertyChanged(#Phc.#3hc(107407606));
					this.RaiseIsCheckedChanged();
				}
			}
		}

		// Token: 0x17001477 RID: 5239
		// (get) Token: 0x060045F9 RID: 17913 RVA: 0x0003A822 File Offset: 0x00038A22
		public object DesiredValue
		{
			get
			{
				return this.desiredValue;
			}
		}

		// Token: 0x17001478 RID: 5240
		// (get) Token: 0x060045FA RID: 17914 RVA: 0x0003A82E File Offset: 0x00038A2E
		// (set) Token: 0x060045FB RID: 17915 RVA: 0x0013D5C4 File Offset: 0x0013B7C4
		public string GroupName
		{
			get
			{
				return this.groupName;
			}
			set
			{
				if (this.groupName != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107453596));
					this.groupName = value;
					base.RaisePropertyChanged(#Phc.#3hc(107453596));
				}
			}
		}

		// Token: 0x140000E2 RID: 226
		// (add) Token: 0x060045FC RID: 17916 RVA: 0x0013D614 File Offset: 0x0013B814
		// (remove) Token: 0x060045FD RID: 17917 RVA: 0x0013D658 File Offset: 0x0013B858
		internal event EventHandler<IsCheckedChangedEventArgs<object>> IsCheckedChanged;

		// Token: 0x060045FE RID: 17918 RVA: 0x0003A83A File Offset: 0x00038A3A
		[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate")]
		protected void RaiseIsCheckedChanged()
		{
			if (this.IsCheckedChanged != null)
			{
				this.IsCheckedChanged(this, new IsCheckedChangedEventArgs<object>(this.isChecked, this.desiredValue));
			}
		}

		// Token: 0x04001FC1 RID: 8129
		private readonly object desiredValue;

		// Token: 0x04001FC2 RID: 8130
		private string groupName;

		// Token: 0x04001FC3 RID: 8131
		private bool isChecked;
	}
}
