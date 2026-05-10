using System;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using #7hc;
using #ezc;
using StructurePoint.CoreAssets.GUI.DesktopControls;
using StructurePoint.CoreAssets.GUI.DesktopControls.RibbonToolbar;
using StructurePoint.CoreAssets.Logger;

namespace #iTc
{
	// Token: 0x02000C6C RID: 3180
	internal abstract class #OTc : #CBc<#nTc>
	{
		// Token: 0x0600667C RID: 26236 RVA: 0x001907E8 File Offset: 0x0018E9E8
		protected #OTc(#GBc #2x, #nTc #Ee, ILogger #3x, #hTc #hB, #kTc #PTc, #lTc #ng) : base(#2x, #Ee, #3x)
		{
			this.Commands = #hB;
			this.#a = #PTc;
			this.SettingsManager = #ng;
			base.View.SetViewModel(this);
			this.Commands.UpdateRibbonToolbarCommand.SetCommand(new Action<object>(this.#JTc));
			this.Commands.IncreaseRibbonToolbarSizeCommand.SetCommand(new Action(this.#LTc), new Func<bool>(this.#KTc));
			this.Commands.DecreaseRibbonToolbarSizeCommand.SetCommand(new Action(this.#NTc), new Func<bool>(this.#MTc));
		}

		// Token: 0x17001C77 RID: 7287
		// (get) Token: 0x0600667D RID: 26237 RVA: 0x00052612 File Offset: 0x00050812
		// (set) Token: 0x0600667E RID: 26238 RVA: 0x0005261A File Offset: 0x0005081A
		private protected RibbonToolbarType CurrentRibbonToolbarType { protected get; private set; }

		// Token: 0x17001C78 RID: 7288
		// (get) Token: 0x0600667F RID: 26239 RVA: 0x00052623 File Offset: 0x00050823
		// (set) Token: 0x06006680 RID: 26240 RVA: 0x0005262B File Offset: 0x0005082B
		private protected #hTc Commands { protected get; private set; }

		// Token: 0x17001C79 RID: 7289
		// (get) Token: 0x06006681 RID: 26241 RVA: 0x00052634 File Offset: 0x00050834
		// (set) Token: 0x06006682 RID: 26242 RVA: 0x0005263C File Offset: 0x0005083C
		private protected #lTc SettingsManager { protected get; private set; }

		// Token: 0x17001C7A RID: 7290
		// (get) Token: 0x06006683 RID: 26243 RVA: 0x00052645 File Offset: 0x00050845
		// (set) Token: 0x06006684 RID: 26244 RVA: 0x00190890 File Offset: 0x0018EA90
		public Orientation CurrentRibbonToolbarOrientation
		{
			get
			{
				return this.#b;
			}
			set
			{
				for (;;)
				{
					if (this.#b == value)
					{
						goto IL_36;
					}
					string propertyName = #Phc.#3hc(107441233);
					if (5 != 0)
					{
						base.RaisePropertyChanging(propertyName);
					}
					IL_19:
					if (3 != 0)
					{
						if (false)
						{
							continue;
						}
						this.#b = value;
						string propertyName2 = #Phc.#3hc(107441233);
						if (!false)
						{
							base.RaisePropertyChanged(propertyName2);
						}
					}
					IL_36:
					if (true)
					{
						break;
					}
					goto IL_19;
				}
			}
		}

		// Token: 0x06006685 RID: 26245 RVA: 0x001908E4 File Offset: 0x0018EAE4
		protected virtual void #ITc(RibbonToolbarType #C)
		{
			IRibbonToolbarController ribbonToolbarController = this.#a.#jTc(#C);
			IRibbonToolbarController ribbonToolbarController2;
			if (!false)
			{
				ribbonToolbarController2 = ribbonToolbarController;
			}
			IRibbonToolbarControl ribbonToolbarControl = base.View.RibbonToolbarControl;
			IRibbonToolbarController controller = ribbonToolbarController2;
			if (!false)
			{
				ribbonToolbarControl.Controller = controller;
			}
			if (7 != 0)
			{
				this.CurrentRibbonToolbarType = #C;
			}
			Orientation orientation = ribbonToolbarController2.Orientation;
			if (6 != 0)
			{
				this.CurrentRibbonToolbarOrientation = orientation;
			}
			IDelegateCommand delegateCommand = this.Commands.IncreaseRibbonToolbarSizeCommand;
			if (!false)
			{
				delegateCommand.InvalidateCanExecute();
			}
			IDelegateCommand delegateCommand2 = this.Commands.DecreaseRibbonToolbarSizeCommand;
			if (2 != 0)
			{
				delegateCommand2.InvalidateCanExecute();
			}
		}

		// Token: 0x06006686 RID: 26246 RVA: 0x0019096C File Offset: 0x0018EB6C
		private void #JTc(object #Sb)
		{
			RibbonToolbarType? ribbonToolbarType = #Sb as RibbonToolbarType?;
			RibbonToolbarType? ribbonToolbarType2;
			if (3 != 0)
			{
				ribbonToolbarType2 = ribbonToolbarType;
			}
			if (6 != 0)
			{
				if (ribbonToolbarType2 == null || ribbonToolbarType2.Value == this.CurrentRibbonToolbarType)
				{
					return;
				}
				if (!false)
				{
					#lTc #lTc = this.SettingsManager;
					RibbonToolbarType value = ribbonToolbarType2.Value;
					if (!false)
					{
						#lTc.RibbonToolbarType = value;
					}
					RibbonToolbarType value2 = ribbonToolbarType2.Value;
					if (true)
					{
						this.#ITc(value2);
					}
				}
			}
		}

		// Token: 0x06006687 RID: 26247 RVA: 0x0005264D File Offset: 0x0005084D
		private bool #KTc()
		{
			int result;
			while ((!false && this.CurrentRibbonToolbarType == RibbonToolbarType.LargeHorizontal) || this.CurrentRibbonToolbarType == RibbonToolbarType.MediumVertical)
			{
				if (7 != 0)
				{
					result = 0;
					return result != 0;
				}
			}
			int num = result = 1;
			if (num != 0)
			{
				return num != 0;
			}
			return result != 0;
		}

		// Token: 0x06006688 RID: 26248 RVA: 0x001909D8 File Offset: 0x0018EBD8
		private void #LTc()
		{
			RibbonToolbarType? ribbonToolbarType;
			for (;;)
			{
				ribbonToolbarType = null;
				RibbonToolbarType ribbonToolbarType2 = this.CurrentRibbonToolbarType;
				RibbonToolbarType ribbonToolbarType3;
				if (7 != 0)
				{
					ribbonToolbarType3 = ribbonToolbarType2;
				}
				switch (ribbonToolbarType3)
				{
				case RibbonToolbarType.SmallHorizontal:
				{
					RibbonToolbarType value = RibbonToolbarType.MediumHorizontal;
					if (4 != 0)
					{
						ribbonToolbarType = new RibbonToolbarType?(value);
					}
					break;
				}
				case RibbonToolbarType.SmallVertical:
					goto IL_43;
				case RibbonToolbarType.MediumHorizontal:
				{
					if (2 == 0)
					{
						goto IL_43;
					}
					if (false)
					{
						continue;
					}
					RibbonToolbarType value2 = RibbonToolbarType.LargeHorizontal;
					if (!false)
					{
						ribbonToolbarType = new RibbonToolbarType?(value2);
					}
					if (false)
					{
						return;
					}
					break;
				}
				}
				IL_4B:
				if (ribbonToolbarType == null)
				{
					return;
				}
				if (3 != 0)
				{
					break;
				}
				continue;
				IL_43:
				RibbonToolbarType value3 = RibbonToolbarType.MediumVertical;
				if (false)
				{
					goto IL_4B;
				}
				ribbonToolbarType = new RibbonToolbarType?(value3);
				goto IL_4B;
			}
			#lTc #lTc = this.SettingsManager;
			RibbonToolbarType value4 = ribbonToolbarType.Value;
			if (!false)
			{
				#lTc.RibbonToolbarType = value4;
			}
			RibbonToolbarType value5 = ribbonToolbarType.Value;
			if (!false)
			{
				this.#ITc(value5);
			}
		}

		// Token: 0x06006689 RID: 26249 RVA: 0x0005266D File Offset: 0x0005086D
		private bool #MTc()
		{
			return true && (false || this.CurrentRibbonToolbarType != RibbonToolbarType.SmallHorizontal) && this.CurrentRibbonToolbarType != RibbonToolbarType.SmallVertical && !false;
		}

		// Token: 0x0600668A RID: 26250 RVA: 0x00190A84 File Offset: 0x0018EC84
		private void #NTc()
		{
			RibbonToolbarType? ribbonToolbarType = null;
			RibbonToolbarType ribbonToolbarType2 = this.CurrentRibbonToolbarType;
			RibbonToolbarType ribbonToolbarType3;
			if (-1 != 0)
			{
				ribbonToolbarType3 = ribbonToolbarType2;
			}
			switch (ribbonToolbarType3)
			{
			case RibbonToolbarType.MediumHorizontal:
			{
				RibbonToolbarType value = RibbonToolbarType.SmallHorizontal;
				if (!false)
				{
					ribbonToolbarType = new RibbonToolbarType?(value);
				}
				break;
			}
			case RibbonToolbarType.MediumVertical:
			{
				if (2 == 0)
				{
					goto IL_50;
				}
				RibbonToolbarType value2 = RibbonToolbarType.SmallVertical;
				if (-1 != 0)
				{
					ribbonToolbarType = new RibbonToolbarType?(value2);
				}
				break;
			}
			case RibbonToolbarType.LargeHorizontal:
			{
				RibbonToolbarType value3 = RibbonToolbarType.MediumHorizontal;
				if (true)
				{
					ribbonToolbarType = new RibbonToolbarType?(value3);
				}
				break;
			}
			}
			if (ribbonToolbarType == null)
			{
				return;
			}
			IL_50:
			#lTc #lTc = this.SettingsManager;
			RibbonToolbarType value4 = ribbonToolbarType.Value;
			if (!false)
			{
				#lTc.RibbonToolbarType = value4;
			}
			RibbonToolbarType value5 = ribbonToolbarType.Value;
			if (true)
			{
				this.#ITc(value5);
			}
		}

		// Token: 0x04002A3B RID: 10811
		private readonly #kTc #a;

		// Token: 0x04002A3C RID: 10812
		private Orientation #b;

		// Token: 0x04002A3D RID: 10813
		[CompilerGenerated]
		private RibbonToolbarType #c;

		// Token: 0x04002A3E RID: 10814
		[CompilerGenerated]
		private #hTc #d;

		// Token: 0x04002A3F RID: 10815
		[CompilerGenerated]
		private #lTc #e;
	}
}
