using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using #3wb;
using #6yb;
using #7hc;
using #aHb;
using #APb;
using #bnb;
using #eU;
using #IW;
using #Pxb;
using #qPb;
using #RJb;
using #ryb;
using #Swb;
using #zW;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.Templates.Storage;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.Products.Column.Core.API;
using StructurePoint.Products.Column.Editor.Core;
using StructurePoint.Products.Column.Editor.Section;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.Viewports.API;
using Telerik.Windows.Controls;

namespace #cwb
{
	// Token: 0x0200049A RID: 1178
	internal sealed class #Fwb : #GLb<#TPb>, INotifyPropertyChanged, IViewModel, IViewModel<#TPb>, #UPb, #yLb, #xLb
	{
		// Token: 0x06002BCA RID: 11210 RVA: 0x000EA3D4 File Offset: 0x000E85D4
		public #Fwb(Lazy<#TPb> #Ee, IExtendedServices #0c, #QPb #Gwb, #OPb #Hwb, #PPb #Iwb, #IPb #Jwb, #5yb #hwb, #qyb #Kwb, #WPb #Lwb, #dLb #Zc, #DW #xj, #5wb #gwb, #Oxb #Mwb, #7wb #Xk, #KW #Cj, IEditorService #wj, #2wb #yj, #Rwb #Zk, #fIb #Nwb, #sPb #vLb)
		{
			#Fwb.#ETb #ETb = new #Fwb.#ETb();
			#ETb.#b = #xj;
			base..ctor(#Ee, #0c);
			#ETb.#a = this;
			this.#c = #0c;
			this.#d = #Gwb;
			this.#e = #Hwb;
			this.#f = #Iwb;
			this.#g = #Jwb;
			this.#h = #hwb;
			this.#i = #Kwb;
			this.#j = #Lwb;
			this.#k = #Zc;
			this.#l = #gwb;
			this.#m = #Mwb;
			this.#n = #Xk;
			this.#o = #Cj;
			this.#p = #wj;
			this.#q = #yj;
			this.#r = #Zk;
			this.#s = #Nwb;
			this.#t = #vLb;
			this.#z = new DelegateCommand(new Action<object>(this.#vwb), new Predicate<object>(this.#swb));
			this.#y = new DelegateCommand(new Action<object>(this.#4Vh));
			this.#A = new DelegateCommand(new Action<object>(#ETb.#O7b), new Predicate<object>(#ETb.#P7b));
			#0c.MessageBus.DefinitionChangesCommitted += this.#owb;
			#0c.MessageBus.UnitSystemChanged += this.#EO;
			#0c.MessageBus.SectionImportActivateIrregularSectionView += this.#pwb;
			#0c.Project.ModelChanged += this.#cl;
			#0c.MessageBus.TrySelectTemplateRequested += this.#nwb;
			#0c.Commands.ChangeSectionType.SetCommand(new Action<object>(this.#vwb), new Predicate<object>(this.#swb));
			#0c.Commands.StartDesignTrace.SetCommand(new Action<object>(this.#rwb), new Predicate<object>(this.#qwb));
		}

		// Token: 0x17000ECA RID: 3786
		// (get) Token: 0x06002BCB RID: 11211 RVA: 0x000277EB File Offset: 0x000259EB
		public DelegateCommand GoToRegularSectionCommand { get; }

		// Token: 0x17000ECB RID: 3787
		// (get) Token: 0x06002BCC RID: 11212 RVA: 0x000277F7 File Offset: 0x000259F7
		// (set) Token: 0x06002BCD RID: 11213 RVA: 0x00027803 File Offset: 0x00025A03
		public SectionType SectionType
		{
			get
			{
				return this.#a;
			}
			set
			{
				this.SetProperty<SectionType>(ref this.#a, value, null);
				this.#x.Add(value);
			}
		}

		// Token: 0x17000ECC RID: 3788
		// (get) Token: 0x06002BCE RID: 11214 RVA: 0x0002782D File Offset: 0x00025A2D
		// (set) Token: 0x06002BCF RID: 11215 RVA: 0x00027839 File Offset: 0x00025A39
		public IView SectionTypeView
		{
			get
			{
				return this.#b;
			}
			set
			{
				this.SetProperty<IView>(ref this.#b, value, null);
			}
		}

		// Token: 0x17000ECD RID: 3789
		// (get) Token: 0x06002BD0 RID: 11216 RVA: 0x00027856 File Offset: 0x00025A56
		public DelegateCommand ChangeSectionTypeCommand { get; }

		// Token: 0x17000ECE RID: 3790
		// (get) Token: 0x06002BD1 RID: 11217 RVA: 0x00027862 File Offset: 0x00025A62
		public DelegateCommand SendToIrregularSectionCommand { get; }

		// Token: 0x17000ECF RID: 3791
		// (get) Token: 0x06002BD2 RID: 11218 RVA: 0x0002786E File Offset: 0x00025A6E
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x17000ED0 RID: 3792
		// (get) Token: 0x06002BD3 RID: 11219 RVA: 0x0002787E File Offset: 0x00025A7E
		// (set) Token: 0x06002BD4 RID: 11220 RVA: 0x0002788A File Offset: 0x00025A8A
		public bool EnableGoToRegularMode
		{
			get
			{
				return this.#w;
			}
			set
			{
				this.SetProperty<bool>(ref this.#w, value, null);
			}
		}

		// Token: 0x06002BD5 RID: 11221 RVA: 0x000EA5B8 File Offset: 0x000E87B8
		public bool #2Vh()
		{
			if (this.SectionType == SectionType.Irregular && this.#i.EditIrregularReinforcementBars.IsSelected)
			{
				return this.#i.#9Vh();
			}
			if (this.SectionType == SectionType.Irregular)
			{
				return this.#h.HasErrors;
			}
			if (this.SectionType == SectionType.IrregularTemplate)
			{
				return this.#l.HasErrors;
			}
			if (this.SectionType == SectionType.Rectangle)
			{
				if (base.Project.Model.Options.ProblemType != ProblemType.Investigation)
				{
					return this.#f.HasErrors;
				}
				return this.#d.HasErrors;
			}
			else
			{
				if (this.SectionType != SectionType.Circle)
				{
					return false;
				}
				if (base.Project.Model.Options.ProblemType != ProblemType.Investigation)
				{
					return this.#g.HasErrors;
				}
				return this.#e.HasErrors;
			}
		}

		// Token: 0x06002BD6 RID: 11222 RVA: 0x000EA6A4 File Offset: 0x000E88A4
		protected override bool SetProperty<T>(ref T field, T value, string propertyName = null)
		{
			bool result = base.SetProperty<T>(ref field, value, propertyName);
			this.#vh();
			return result;
		}

		// Token: 0x06002BD7 RID: 11223 RVA: 0x000EA6D0 File Offset: 0x000E88D0
		public void #5b()
		{
			this.#u = true;
			SectionType sectionType = this.SectionType;
			this.SectionType = base.Project.Model.Options.SectionType;
			this.#vh();
			this.#3Vh();
			this.#t.#vBf();
			this.#i.#pyb();
			bool flag;
			if (!this.#xwb(this.SectionType, out flag, false))
			{
				this.SectionType = sectionType;
				base.RaisePropertyChanged(#Phc.#3hc(107398573));
				return;
			}
			IModelEditorViewport modelEditorViewport = this.#c.ViewportsManager.ActiveViewport as IModelEditorViewport;
			if (modelEditorViewport != null)
			{
				modelEditorViewport.Editor.EmptyTextureCache();
			}
			this.#c.GuiController.EditorStatusBar.#5b(#Fnb.#e);
			this.#c.Settings.RuntimeSettings.DrawDrawingGrid = true;
			this.#c.Settings.RuntimeSettings.DrawSnappingGrid = true;
			this.#c.Renderer.#cg();
			base.Project.#2O();
		}

		// Token: 0x06002BD8 RID: 11224 RVA: 0x000EA7F0 File Offset: 0x000E89F0
		public void #0kb()
		{
			this.#c.GuiController.EditorStatusBar.#5b(#Fnb.#a);
			this.#i.#0kb();
			this.#u = false;
			this.#uwb();
			this.#c.Settings.RuntimeSettings.DrawDrawingGrid = false;
			this.#c.Settings.RuntimeSettings.DrawSnappingGrid = false;
			this.#c.Renderer.#cg();
		}

		// Token: 0x06002BD9 RID: 11225 RVA: 0x000278A7 File Offset: 0x00025AA7
		public void #mwb()
		{
			this.#i.#CNb();
		}

		// Token: 0x06002BDA RID: 11226 RVA: 0x000278BC File Offset: 0x00025ABC
		protected override void #vh()
		{
			this.ChangeSectionTypeCommand.InvalidateCanExecute();
			this.SendToIrregularSectionCommand.InvalidateCanExecute();
			base.#vh();
		}

		// Token: 0x06002BDB RID: 11227 RVA: 0x000EA874 File Offset: 0x000E8A74
		private void #nwb(object #Ge, EventArgs #He)
		{
			#Fwb.#l0b #l0b = new #Fwb.#l0b();
			#l0b.#a = this;
			if (this.SectionType != SectionType.IrregularTemplate)
			{
				bool flag = base.Project.Model.#IY();
				bool flag2;
				this.#xwb(SectionType.IrregularTemplate, out flag2, true);
				if (flag && base.Project.Model.Options.SectionType == SectionType.IrregularTemplate)
				{
					this.#l.NewPatternCommand.Execute(null);
					return;
				}
			}
			else
			{
				if (!this.#n.#6wb(out #l0b.#b) || #l0b.#b == null)
				{
					return;
				}
				this.#p.#0Pb(new Action(#l0b.#Q7b));
			}
		}

		// Token: 0x06002BDC RID: 11228 RVA: 0x000278E6 File Offset: 0x00025AE6
		private void #cl(object #Ge, #7V #He)
		{
			this.#B = null;
			HashSet<SectionType> hashSet = this.#x;
			if (!false)
			{
				hashSet.Clear();
			}
			if (this.#u)
			{
				this.#0kb();
				this.#5b();
			}
		}

		// Token: 0x06002BDD RID: 11229 RVA: 0x0002791C File Offset: 0x00025B1C
		private void #EO(object #Ge, EventArgs #He)
		{
			this.#B = null;
			this.#x.Clear();
			this.#twb();
		}

		// Token: 0x06002BDE RID: 11230 RVA: 0x00027942 File Offset: 0x00025B42
		private void #owb(object #Ge, EventArgs #He)
		{
			this.#twb();
		}

		// Token: 0x06002BDF RID: 11231 RVA: 0x000EA934 File Offset: 0x000E8B34
		private void #pwb(object #Ge, EventArgs #He)
		{
			if (base.Project.Model.Options.SectionType != SectionType.Irregular)
			{
				bool flag;
				this.#xwb(SectionType.Irregular, out flag, true);
			}
			this.#5b();
			this.#c.Commands.ActivateScopeWithParameters.Execute(new SectionScopeActivationParameters());
		}

		// Token: 0x06002BE0 RID: 11232 RVA: 0x000EA990 File Offset: 0x000E8B90
		private void #3Vh()
		{
			this.EnableGoToRegularMode = (base.Project.Model.Options.SectionType == SectionType.Irregular && (base.Project.Model.Options.PreviousSectionType == SectionType.Rectangle || base.Project.Model.Options.PreviousSectionType == SectionType.Circle || base.Project.Model.Options.PreviousSectionType == SectionType.Undefined || base.Project.Model.Options.PreviousSectionType == SectionType.Irregular));
		}

		// Token: 0x06002BE1 RID: 11233 RVA: 0x000EAA40 File Offset: 0x000E8C40
		private void #4Vh(object #Sb)
		{
			SectionType sectionType = base.Project.Model.Options.PreviousSectionType;
			if (sectionType == SectionType.Irregular || sectionType == SectionType.Undefined)
			{
				sectionType = SectionType.Rectangle;
			}
			if ((sectionType == SectionType.Circle || sectionType == SectionType.Rectangle) && sectionType != base.Project.Model.Options.SectionType)
			{
				bool flag;
				this.#xwb(sectionType, out flag, true);
				if (!flag)
				{
					this.#c.Renderer.#bg();
				}
			}
		}

		// Token: 0x06002BE2 RID: 11234 RVA: 0x00027952 File Offset: 0x00025B52
		private bool #qwb(object #Vg)
		{
			return base.Project.Model.Options.ProblemType == ProblemType.Design;
		}

		// Token: 0x06002BE3 RID: 11235 RVA: 0x00027978 File Offset: 0x00025B78
		private void #rwb(object #Vg)
		{
			if (this.#qwb(null))
			{
				LayoutHelper.BeginInvokeOnApplicationThread(new Action(this.#7Vh));
			}
		}

		// Token: 0x06002BE4 RID: 11236 RVA: 0x000EAAB8 File Offset: 0x000E8CB8
		private bool #swb(object #Vg)
		{
			if (#Vg is SectionType)
			{
				SectionType sectionType = (SectionType)#Vg;
				if (sectionType <= SectionType.Circle)
				{
					return true;
				}
				if (sectionType - SectionType.Irregular <= 1)
				{
					return base.Project.Model.Options.ProblemType == ProblemType.Investigation;
				}
			}
			return false;
		}

		// Token: 0x06002BE5 RID: 11237 RVA: 0x000EAB08 File Offset: 0x000E8D08
		private void #twb()
		{
			this.#e.#twb();
			this.#d.#twb();
			this.#f.#twb();
			this.#g.#twb();
			this.#h.#twb();
			this.#l.#twb();
			this.#c.Renderer.#9f(false, false);
		}

		// Token: 0x06002BE6 RID: 11238 RVA: 0x000EAB78 File Offset: 0x000E8D78
		private void #uwb()
		{
			this.#d.#0kb();
			this.#e.#0kb();
			this.#h.#0kb();
			this.#f.#0kb();
			this.#g.#0kb();
			this.#l.#0kb();
		}

		// Token: 0x06002BE7 RID: 11239 RVA: 0x000EABD4 File Offset: 0x000E8DD4
		private void #vwb(object #Sb)
		{
			if (#Sb is SectionType)
			{
				SectionType #C = (SectionType)#Sb;
				bool flag;
				this.#xwb(#C, out flag, true);
				if (!flag)
				{
					this.#c.Renderer.#bg();
				}
			}
		}

		// Token: 0x06002BE8 RID: 11240 RVA: 0x000EAC1C File Offset: 0x000E8E1C
		private void #wwb()
		{
			int hashCode = base.Project.Model.GetHashCode();
			int? num = this.#v;
			int num2 = hashCode;
			if (num.GetValueOrDefault() == num2 & num != null)
			{
				this.#c.MouseAndKeyboard.#F2c(base.View, true);
			}
			this.#v = new int?(hashCode);
		}

		// Token: 0x06002BE9 RID: 11241 RVA: 0x000EAC88 File Offset: 0x000E8E88
		private bool #xwb(SectionType #C, out bool #5Vh, bool #6Vh = true)
		{
			#5Vh = false;
			if (#6Vh)
			{
				this.#wwb();
			}
			bool flag = #C.#Pai();
			bool flag2 = this.SectionType.#Pai();
			CameraSettings cameraSettings = null;
			if (flag != flag2)
			{
				cameraSettings = this.#B;
				IModelEditorViewport modelEditorViewport = this.#c.ViewportsManager.ActiveViewport as IModelEditorViewport;
				CameraSettings cameraSettings2;
				if (modelEditorViewport == null)
				{
					cameraSettings2 = null;
				}
				else
				{
					ColumnEditor columnEditor = modelEditorViewport.Editor;
					cameraSettings2 = ((columnEditor != null) ? columnEditor.GetCurrentCameraSettings() : null);
				}
				this.#B = cameraSettings2;
			}
			this.#uwb();
			ProblemType problemType = base.Project.Model.Options.ProblemType;
			if (problemType == ProblemType.Design)
			{
				this.#zwb(#C);
			}
			else if (!this.#ywb(#C))
			{
				base.RaisePropertyChanged(#Phc.#3hc(107398573));
				return false;
			}
			List<SectionType> list = this.#x.ToList<SectionType>();
			this.SectionType = #C;
			this.#i.#CNb();
			this.#i.#CNb();
			if (this.#a == SectionType.Irregular)
			{
				this.#j.#0kb();
				this.#m.#0kb();
			}
			else if (this.#a == SectionType.IrregularTemplate)
			{
				this.#j.#0kb();
				this.#i.#0kb();
				if (this.#m.IsActive)
				{
					this.#m.#0kb();
				}
				this.#m.#5b();
			}
			else
			{
				this.#i.#0kb();
				if (this.#j.IsActive)
				{
					this.#j.#0kb();
				}
				this.#j.#5b();
			}
			this.#Awb();
			this.#i.#pyb();
			this.#k.ChangeSectionType(#C);
			base.Project.#2O();
			this.#c.MessageBus.#sV();
			this.#3Vh();
			if (cameraSettings != null)
			{
				IModelEditorViewport modelEditorViewport2 = this.#c.ViewportsManager.ActiveViewport as IModelEditorViewport;
				if (modelEditorViewport2 != null && list.Contains(#C))
				{
					#5Vh = true;
					modelEditorViewport2.Editor.RestoreCameraSettings(cameraSettings);
				}
			}
			return true;
		}

		// Token: 0x06002BEA RID: 11242 RVA: 0x000EAE90 File Offset: 0x000E9090
		private bool #ywb(SectionType #C)
		{
			switch (#C)
			{
			case SectionType.Rectangle:
				this.#d.#5b();
				break;
			case SectionType.Circle:
				this.#e.#5b();
				break;
			case SectionType.Irregular:
				this.#h.#5b();
				break;
			case SectionType.IrregularTemplate:
				return this.#l.#5b();
			}
			return true;
		}

		// Token: 0x06002BEB RID: 11243 RVA: 0x000279A1 File Offset: 0x00025BA1
		private void #zwb(SectionType #C)
		{
			if (#C == SectionType.Rectangle)
			{
				this.#f.#5b();
				return;
			}
			if (#C != SectionType.Circle)
			{
				return;
			}
			this.#g.#5b();
		}

		// Token: 0x06002BEC RID: 11244 RVA: 0x000279CE File Offset: 0x00025BCE
		private void #Awb()
		{
			this.SectionTypeView = this.#Bwb(this.SectionType);
		}

		// Token: 0x06002BED RID: 11245 RVA: 0x000279EE File Offset: 0x00025BEE
		private IView #Bwb(SectionType #C)
		{
			if (base.Services.Project.Model.Options.ProblemType == ProblemType.Investigation)
			{
				return this.#Cwb(#C);
			}
			return this.#Dwb(#C);
		}

		// Token: 0x06002BEE RID: 11246 RVA: 0x000EAEF8 File Offset: 0x000E90F8
		private IView #Cwb(SectionType #C)
		{
			switch (#C)
			{
			case SectionType.Rectangle:
				return this.#d.View;
			case SectionType.Circle:
				return this.#e.View;
			case SectionType.Irregular:
				return this.#h.View;
			case SectionType.IrregularTemplate:
				return this.#l.View;
			default:
				return null;
			}
		}

		// Token: 0x06002BEF RID: 11247 RVA: 0x000EAF5C File Offset: 0x000E915C
		private IView #Dwb(SectionType #C)
		{
			switch (#C)
			{
			case SectionType.Rectangle:
				return this.#f.View;
			case SectionType.Circle:
				return this.#g.View;
			case SectionType.Irregular:
				return this.#h.View;
			default:
				return null;
			}
		}

		// Token: 0x06002BF0 RID: 11248 RVA: 0x00027A27 File Offset: 0x00025C27
		[CompilerGenerated]
		private void #7Vh()
		{
			this.#c.Commands.ActivateScopeWithParameters.Execute(new SectionScopeActivationParameters());
			LayoutHelper.BeginInvokeOnApplicationThread(new Action(this.#s.#eIb));
		}

		// Token: 0x0400117C RID: 4476
		private SectionType #a;

		// Token: 0x0400117D RID: 4477
		private IView #b;

		// Token: 0x0400117E RID: 4478
		private readonly IExtendedServices #c;

		// Token: 0x0400117F RID: 4479
		private readonly #QPb #d;

		// Token: 0x04001180 RID: 4480
		private readonly #OPb #e;

		// Token: 0x04001181 RID: 4481
		private readonly #PPb #f;

		// Token: 0x04001182 RID: 4482
		private readonly #IPb #g;

		// Token: 0x04001183 RID: 4483
		private readonly #5yb #h;

		// Token: 0x04001184 RID: 4484
		private readonly #qyb #i;

		// Token: 0x04001185 RID: 4485
		private readonly #WPb #j;

		// Token: 0x04001186 RID: 4486
		private readonly #dLb #k;

		// Token: 0x04001187 RID: 4487
		private readonly #5wb #l;

		// Token: 0x04001188 RID: 4488
		private readonly #Oxb #m;

		// Token: 0x04001189 RID: 4489
		private readonly #7wb #n;

		// Token: 0x0400118A RID: 4490
		private readonly #KW #o;

		// Token: 0x0400118B RID: 4491
		private readonly IEditorService #p;

		// Token: 0x0400118C RID: 4492
		private readonly #2wb #q;

		// Token: 0x0400118D RID: 4493
		private readonly #Rwb #r;

		// Token: 0x0400118E RID: 4494
		private readonly #fIb #s;

		// Token: 0x0400118F RID: 4495
		private readonly #sPb #t;

		// Token: 0x04001190 RID: 4496
		private bool #u;

		// Token: 0x04001191 RID: 4497
		private int? #v;

		// Token: 0x04001192 RID: 4498
		private bool #w;

		// Token: 0x04001193 RID: 4499
		private readonly HashSet<SectionType> #x = new HashSet<SectionType>();

		// Token: 0x04001194 RID: 4500
		[CompilerGenerated]
		private readonly DelegateCommand #y;

		// Token: 0x04001195 RID: 4501
		[CompilerGenerated]
		private readonly DelegateCommand #z;

		// Token: 0x04001196 RID: 4502
		[CompilerGenerated]
		private readonly DelegateCommand #A;

		// Token: 0x04001197 RID: 4503
		private CameraSettings #B;

		// Token: 0x0200049B RID: 1179
		[CompilerGenerated]
		private sealed class #ETb
		{
			// Token: 0x06002BF2 RID: 11250 RVA: 0x000EAFB0 File Offset: 0x000E91B0
			internal void #O7b(object #Hi)
			{
				#Fwb.#ODg #ODg = new #Fwb.#ODg();
				#ODg.#b = this;
				if (this.#a.Services.MouseAndKeyboard.#N2c(this.#a.View as DependencyObject, false, true))
				{
					string #SSc = this.#a.DialogService.#5Sc(Strings.StringCannotConvertRegularSectionToIrregular.#z2d(), Strings.StringPleaseFixTheErrorsInTheLeftPanel.#z2d());
					this.#a.DialogService.#qn(this.#a.DialogService.ActiveWindow, #SSc);
					return;
				}
				#ODg.#a = this.#a.#B;
				this.#a.#B = null;
				this.#b.#BW(new Action<bool>(#ODg.#g9e));
			}

			// Token: 0x06002BF3 RID: 11251 RVA: 0x00027A67 File Offset: 0x00025C67
			internal bool #P7b(object #Hi)
			{
				return this.#b.#CW();
			}

			// Token: 0x04001198 RID: 4504
			public #Fwb #a;

			// Token: 0x04001199 RID: 4505
			public #DW #b;
		}

		// Token: 0x0200049C RID: 1180
		[CompilerGenerated]
		private sealed class #ODg
		{
			// Token: 0x06002BF5 RID: 11253 RVA: 0x000EB08C File Offset: 0x000E928C
			internal void #g9e(bool #hW)
			{
				#Fwb #Fwb = this.#b.#a;
				CameraSettings #B;
				if (!#hW)
				{
					#B = this.#a;
				}
				else
				{
					#Fwb #Fwb2 = this.#b.#a;
					IModelEditorViewport modelEditorViewport = this.#b.#a.#c.ViewportsManager.ActiveViewport as IModelEditorViewport;
					#B = (#Fwb2.#B = ((modelEditorViewport != null) ? modelEditorViewport.Editor.GetCurrentCameraSettings() : null));
				}
				#Fwb.#B = #B;
			}

			// Token: 0x0400119A RID: 4506
			public CameraSettings #a;

			// Token: 0x0400119B RID: 4507
			public #Fwb.#ETb #b;
		}

		// Token: 0x0200049D RID: 1181
		[CompilerGenerated]
		private sealed class #l0b
		{
			// Token: 0x06002BF7 RID: 11255 RVA: 0x000EB104 File Offset: 0x000E9304
			internal void #Q7b()
			{
				this.#a.Project.Model.Options.ProblemType = ProblemType.Investigation;
				this.#a.Project.Model.Options.SectionType = SectionType.IrregularTemplate;
				this.#a.Project.Model.Options.InvestigationReinforcement = ReinforcementType.Irregular;
				this.#a.#o.#5T();
				this.#a.#r.#Owb(this.#b);
				this.#a.#q.#0wb(true);
			}

			// Token: 0x0400119C RID: 4508
			public #Fwb #a;

			// Token: 0x0400119D RID: 4509
			public SectionTemplateDefinition #b;
		}
	}
}
