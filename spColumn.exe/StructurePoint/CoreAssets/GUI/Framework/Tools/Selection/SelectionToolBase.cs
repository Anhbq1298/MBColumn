using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows.Media;
using #7hc;
using #bJc;
using #hLc;
using #hTb;
using #IDc;
using #o1d;
using #UYd;
using #v1c;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;
using StructurePoint.CoreAssets.GUI.Framework.Model.Entities;
using StructurePoint.CoreAssets.GUI.SharedResources.Icons.Tools;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Localizer;

namespace StructurePoint.CoreAssets.GUI.Framework.Tools.Selection
{
	// Token: 0x02000BA2 RID: 2978
	public abstract class SelectionToolBase : #YIc, INotifyPropertyChanged, IEditionToolData, #8Hc, #ULc
	{
		// Token: 0x060061BB RID: 25019 RVA: 0x0017E904 File Offset: 0x0017CB04
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		protected SelectionToolBase(#6Ic toolContext) : base(toolContext)
		{
			this.ClearSelectionOnToolDeactivation = true;
			this.DashedPlanarRectangleDrawingResult = base.ToolContext.DrawingResultsFactory.CreateDashedPlanarRectangleDrawingResult(true);
			base.Header = Strings.StringSelect;
			base.IconImage = base.ToolContext.ResourcesHelper.ImageFromResourceBitmap(ToolsIcons.Select);
			this.ActiveEntitiesSelectors = new HashSet<IEntitiesSelector>();
			this.ToolState = SelectionToolBase.#I9c.#a;
			this.#d = true;
			this.#e = true;
			this.Selectors = new List<IEntitiesSelector>
			{
				new #yLc(base.ProjectContext, base.ModelEditorViewModel, base.SnappingProvider, base.SettingsProvider),
				new #DLc(base.ProjectContext, base.ModelEditorViewModel, base.SnappingProvider, base.SettingsProvider),
				new NodesSelector(base.ProjectContext, base.ModelEditorViewModel, base.SnappingProvider, base.UndoManager, base.SettingsProvider),
				new #TLc(base.ProjectContext, base.ModelEditorViewModel, base.SnappingProvider, base.SettingsProvider)
			};
			this.#qMc(this.Selectors.Last<IEntitiesSelector>());
			this.ProcessSelectionEvents = true;
		}

		// Token: 0x17001BD1 RID: 7121
		// (get) Token: 0x060061BC RID: 25020 RVA: 0x0004FFAC File Offset: 0x0004E1AC
		// (set) Token: 0x060061BD RID: 25021 RVA: 0x0004FFB4 File Offset: 0x0004E1B4
		private protected Key PressedSpecialKey { protected get; private set; }

		// Token: 0x17001BD2 RID: 7122
		// (get) Token: 0x060061BE RID: 25022 RVA: 0x0004FFBD File Offset: 0x0004E1BD
		// (set) Token: 0x060061BF RID: 25023 RVA: 0x0004FFC5 File Offset: 0x0004E1C5
		public bool ProcessSelectionEvents { get; set; }

		// Token: 0x17001BD3 RID: 7123
		// (get) Token: 0x060061C0 RID: 25024 RVA: 0x0004FFCE File Offset: 0x0004E1CE
		// (set) Token: 0x060061C1 RID: 25025 RVA: 0x0004FFD6 File Offset: 0x0004E1D6
		protected IDashedPlanarRectangleDrawingResult DashedPlanarRectangleDrawingResult { get; set; }

		// Token: 0x17001BD4 RID: 7124
		// (get) Token: 0x060061C2 RID: 25026 RVA: 0x0004FFDF File Offset: 0x0004E1DF
		// (set) Token: 0x060061C3 RID: 25027 RVA: 0x0004FFE7 File Offset: 0x0004E1E7
		protected SelectionToolBase.#I9c ToolState { get; set; }

		// Token: 0x17001BD5 RID: 7125
		// (get) Token: 0x060061C4 RID: 25028 RVA: 0x0004FFF0 File Offset: 0x0004E1F0
		// (set) Token: 0x060061C5 RID: 25029 RVA: 0x0004FFF8 File Offset: 0x0004E1F8
		protected bool ClearSelectionOnToolDeactivation { get; set; }

		// Token: 0x17001BD6 RID: 7126
		// (get) Token: 0x060061C6 RID: 25030 RVA: 0x00050001 File Offset: 0x0004E201
		// (set) Token: 0x060061C7 RID: 25031 RVA: 0x00050009 File Offset: 0x0004E209
		protected bool IsSelectionRectangleStarted { get; set; }

		// Token: 0x17001BD7 RID: 7127
		// (get) Token: 0x060061C8 RID: 25032 RVA: 0x00050012 File Offset: 0x0004E212
		// (set) Token: 0x060061C9 RID: 25033 RVA: 0x0005001A File Offset: 0x0004E21A
		public Point3D? SelectedRectangleStartPoint { get; set; }

		// Token: 0x17001BD8 RID: 7128
		// (get) Token: 0x060061CA RID: 25034 RVA: 0x00050023 File Offset: 0x0004E223
		// (set) Token: 0x060061CB RID: 25035 RVA: 0x0005002B File Offset: 0x0004E22B
		public Point3D? SelectedRectangleEndPoint { get; set; }

		// Token: 0x17001BD9 RID: 7129
		// (get) Token: 0x060061CC RID: 25036 RVA: 0x00050034 File Offset: 0x0004E234
		// (set) Token: 0x060061CD RID: 25037 RVA: 0x0005003C File Offset: 0x0004E23C
		public Vector TranslationVector { get; set; }

		// Token: 0x17001BDA RID: 7130
		// (get) Token: 0x060061CE RID: 25038 RVA: 0x00050045 File Offset: 0x0004E245
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		public IEnumerable<object> SelectedObjects
		{
			get
			{
				return this.#b;
			}
		}

		// Token: 0x17001BDB RID: 7131
		// (get) Token: 0x060061CF RID: 25039 RVA: 0x0005004D File Offset: 0x0004E24D
		// (set) Token: 0x060061D0 RID: 25040 RVA: 0x0017EA48 File Offset: 0x0017CC48
		public bool EnableSelectionRectangle
		{
			get
			{
				return this.#e;
			}
			set
			{
				for (;;)
				{
					if (this.#e == value)
					{
						goto IL_36;
					}
					string propertyName = #Phc.#3hc(107414034);
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
						this.#e = value;
						string propertyName2 = #Phc.#3hc(107414034);
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

		// Token: 0x17001BDC RID: 7132
		// (get) Token: 0x060061D1 RID: 25041 RVA: 0x00050055 File Offset: 0x0004E255
		// (set) Token: 0x060061D2 RID: 25042 RVA: 0x0017EA9C File Offset: 0x0017CC9C
		public bool EnableExtendedSelectionMode
		{
			get
			{
				return this.#d;
			}
			set
			{
				for (;;)
				{
					if (this.#d == value)
					{
						goto IL_36;
					}
					string propertyName = #Phc.#3hc(107414513);
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
						this.#d = value;
						string propertyName2 = #Phc.#3hc(107414513);
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

		// Token: 0x17001BDD RID: 7133
		// (get) Token: 0x060061D3 RID: 25043 RVA: 0x0005005D File Offset: 0x0004E25D
		// (set) Token: 0x060061D4 RID: 25044 RVA: 0x00050065 File Offset: 0x0004E265
		public bool IsInExtendedSelectionMode
		{
			get
			{
				return this.#a;
			}
			set
			{
				if (value != this.#a)
				{
					this.#a = value;
				}
			}
		}

		// Token: 0x17001BDE RID: 7134
		// (get) Token: 0x060061D5 RID: 25045 RVA: 0x00050077 File Offset: 0x0004E277
		public bool IsSelectionRectangleDrawn
		{
			get
			{
				return this.IsSelectionRectangleStarted;
			}
		}

		// Token: 0x17001BDF RID: 7135
		// (get) Token: 0x060061D6 RID: 25046 RVA: 0x0005007F File Offset: 0x0004E27F
		// (set) Token: 0x060061D7 RID: 25047 RVA: 0x00050087 File Offset: 0x0004E287
		[SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		protected List<IEntitiesSelector> Selectors { get; set; }

		// Token: 0x17001BE0 RID: 7136
		// (get) Token: 0x060061D8 RID: 25048 RVA: 0x00050090 File Offset: 0x0004E290
		// (set) Token: 0x060061D9 RID: 25049 RVA: 0x00050098 File Offset: 0x0004E298
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		[SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		private HashSet<IEntitiesSelector> ActiveEntitiesSelectors { get; set; }

		// Token: 0x060061DA RID: 25050 RVA: 0x0017EAF0 File Offset: 0x0017CCF0
		protected void #oMc(params IEntitiesSelector[] #pMc)
		{
			int num2;
			if (4 != 0)
			{
				if (#pMc != null)
				{
					do
					{
						if (false)
						{
						}
						int num = 0;
						if (!false)
						{
							num2 = num;
						}
					}
					while (false);
					goto IL_43;
				}
				return;
			}
			IL_15:
			IEntitiesSelector entitiesSelector2;
			if (-1 != 0)
			{
				IEntitiesSelector entitiesSelector = #pMc[num2];
				if (7 != 0)
				{
					entitiesSelector2 = entitiesSelector;
				}
			}
			if (entitiesSelector2 == null)
			{
				goto IL_3C;
			}
			int num3 = this.Selectors.Contains(entitiesSelector2) ? 1 : 0;
			IL_2E:
			if (num3 == 0)
			{
				List<IEntitiesSelector> list = this.Selectors;
				IEntitiesSelector item = entitiesSelector2;
				if (4 != 0)
				{
					list.Add(item);
				}
			}
			IL_3C:
			int num4 = num2 + 1;
			if (!false)
			{
				num2 = num4;
			}
			IL_43:
			int num5 = num3 = num2;
			if (!true)
			{
				goto IL_2E;
			}
			if (num5 < #pMc.Length)
			{
				goto IL_15;
			}
		}

		// Token: 0x060061DB RID: 25051 RVA: 0x000500A1 File Offset: 0x0004E2A1
		protected bool #qMc(IEntitiesSelector #rMc)
		{
			while (#rMc != null)
			{
				bool flag = this.Selectors.Contains(#rMc);
				if (7 != 0)
				{
					if (!flag)
					{
						break;
					}
					if (7 == 0)
					{
						continue;
					}
					if (false)
					{
						break;
					}
					bool flag2 = true;
					if (!false)
					{
						#rMc.IsActive = flag2;
					}
					this.ActiveEntitiesSelectors.Add(#rMc);
				}
				return true;
			}
			return false;
		}

		// Token: 0x060061DC RID: 25052 RVA: 0x000500DB File Offset: 0x0004E2DB
		protected bool #sMc(IEntitiesSelector #rMc)
		{
			while (#rMc != null)
			{
				bool flag = this.Selectors.Contains(#rMc);
				if (7 != 0)
				{
					if (!flag)
					{
						break;
					}
					if (7 == 0)
					{
						continue;
					}
					if (false)
					{
						break;
					}
					bool flag2 = false;
					if (!false)
					{
						#rMc.IsActive = flag2;
					}
					this.ActiveEntitiesSelectors.Remove(#rMc);
				}
				return true;
			}
			return false;
		}

		// Token: 0x060061DD RID: 25053 RVA: 0x00050115 File Offset: 0x0004E315
		protected bool #qMc<#Fu>() where #Fu : IEntitiesSelector
		{
			return this.#qMc(this.Selectors.OfType<#Fu>().FirstOrDefault<#Fu>());
		}

		// Token: 0x060061DE RID: 25054 RVA: 0x00050132 File Offset: 0x0004E332
		public virtual void #iLc()
		{
			IList<object> #FOb = this.#b.ToList<object>();
			if (4 != 0)
			{
				this.#zMc(#FOb);
			}
			HashSet<object> hashSet = this.#b;
			if (4 != 0)
			{
				hashSet.Clear();
			}
		}

		// Token: 0x060061DF RID: 25055 RVA: 0x0017EB5C File Offset: 0x0017CD5C
		public virtual void #FDb()
		{
			HashSet<IEntitiesSelector> hashSet2;
			do
			{
				HashSet<IEntitiesSelector> hashSet = this.ActiveEntitiesSelectors;
				if (!false)
				{
					hashSet2 = hashSet;
				}
				if (hashSet2 == null)
				{
					return;
				}
			}
			while (!true);
			if (hashSet2.Count > 0)
			{
				HashSet<IEntitiesSelector>.Enumerator enumerator = hashSet2.GetEnumerator();
				HashSet<IEntitiesSelector>.Enumerator enumerator2;
				if (4 != 0)
				{
					enumerator2 = enumerator;
				}
				try
				{
					while (enumerator2.MoveNext())
					{
						IEntitiesSelector entitiesSelector = enumerator2.Current;
						IEnumerable<object> enumerable = entitiesSelector.#qLc();
						IEnumerable<object> enumerable2;
						if (3 != 0)
						{
							enumerable2 = enumerable;
						}
						if (enumerable2 != null)
						{
							IEnumerable<object> enumerable3 = enumerable2.Where(new Func<object, bool>(this.#b.Add));
							if (4 != 0)
							{
								enumerable2 = enumerable3;
							}
							IList<object> #FOb = enumerable2.ToList<object>();
							if (7 != 0)
							{
								this.#AMc(#FOb);
							}
							if (!false)
							{
								this.#BMc();
							}
						}
					}
				}
				finally
				{
					((IDisposable)enumerator2).Dispose();
				}
			}
		}

		// Token: 0x060061E0 RID: 25056 RVA: 0x0017EC20 File Offset: 0x0017CE20
		public bool #jLc(object #Rf, bool #kLc)
		{
			if (4 == 0)
			{
				goto IL_1B;
			}
			SelectionToolBase.#K9c #K9c = new SelectionToolBase.#K9c();
			SelectionToolBase.#K9c #K9c2;
			if (!false)
			{
				#K9c2 = #K9c;
			}
			IL_0C:
			if (false)
			{
				goto IL_55;
			}
			#K9c2.#a = #Rf;
			bool flag = false;
			bool flag2;
			if (!false)
			{
				flag2 = flag;
			}
			IL_1B:
			IEntitiesSelector entitiesSelector = this.Selectors.FirstOrDefault(new Func<IEntitiesSelector, bool>(#K9c2.#J9c));
			IEntitiesSelector entitiesSelector2;
			if (7 != 0)
			{
				entitiesSelector2 = entitiesSelector;
			}
			while (!false)
			{
				if (entitiesSelector2 != null)
				{
					IEntitiesSelector entitiesSelector3 = entitiesSelector2;
					object #Rf2 = #K9c2.#a;
					if (4 != 0)
					{
						entitiesSelector3.#ljb(#Rf2);
					}
					if (false)
					{
						continue;
					}
					bool flag3 = true;
					if (!false)
					{
						flag2 = flag3;
					}
				}
				if (flag2 && #kLc)
				{
					goto IL_55;
				}
				return flag2;
			}
			goto IL_0C;
			IL_55:
			ITransparencySorter transparencySorter = base.ModelEditorControl.TransparencySorter;
			if (!false)
			{
				transparencySorter.PerformTransparencySort();
			}
			return flag2;
		}

		// Token: 0x060061E1 RID: 25057 RVA: 0x0005015D File Offset: 0x0004E35D
		public void #tMc(object #Rf)
		{
			for (;;)
			{
				if (!this.#b.Contains(#Rf) && this.#jLc(#Rf, true))
				{
					goto IL_18;
				}
				IL_28:
				if (!false)
				{
					if (!false)
					{
						break;
					}
					continue;
				}
				IL_18:
				if (!false)
				{
					this.#b.Add(#Rf);
					goto IL_28;
				}
				goto IL_28;
			}
		}

		// Token: 0x060061E2 RID: 25058 RVA: 0x0005018D File Offset: 0x0004E38D
		public void #uMc(object #Rf)
		{
			if (this.#lLc(#Rf))
			{
				this.#b.Remove(#Rf);
			}
		}

		// Token: 0x060061E3 RID: 25059 RVA: 0x0017ECAC File Offset: 0x0017CEAC
		public bool #lLc(object #Rf)
		{
			SelectionToolBase.#QTb #QTb2;
			do
			{
				SelectionToolBase.#QTb #QTb = new SelectionToolBase.#QTb();
				if (4 != 0)
				{
					#QTb2 = #QTb;
				}
				#QTb2.#a = #Rf;
			}
			while (false);
			IEntitiesSelector entitiesSelector = this.Selectors.FirstOrDefault(new Func<IEntitiesSelector, bool>(#QTb2.#L9c));
			IEntitiesSelector entitiesSelector2;
			if (!false)
			{
				entitiesSelector2 = entitiesSelector;
			}
			if (entitiesSelector2 != null)
			{
				IEntitiesSelector entitiesSelector3 = entitiesSelector2;
				object #Rf2 = #QTb2.#a;
				if (!false)
				{
					entitiesSelector3.#rLc(#Rf2);
				}
				return true;
			}
			return false;
		}

		// Token: 0x060061E4 RID: 25060 RVA: 0x0017ED08 File Offset: 0x0017CF08
		protected virtual void #vMc()
		{
			Point3D? point3D2;
			for (;;)
			{
				Point3D? #Xrb = null;
				Point3D? point3D = this.SelectedRectangleStartPoint;
				if (3 != 0)
				{
					point3D2 = point3D;
				}
				while (this.IsSelectionRectangleStarted)
				{
					if (point3D2 == null)
					{
						return;
					}
					Point3D value = point3D2.Value;
					if (4 != 0)
					{
						#Xrb = new Point3D?(value);
					}
					if (!false)
					{
						break;
					}
				}
				Point3D? point3D3 = this.SelectedRectangleEndPoint;
				if (!false)
				{
					point3D2 = point3D3;
				}
				if (point3D2 != null)
				{
					goto IL_57;
				}
				if (!false)
				{
					return;
				}
			}
			return;
			IL_57:
			Point3D value2 = point3D2.Value;
			Point3D #Yrb;
			if (!false)
			{
				#Yrb = value2;
			}
			List<object> list = new List<object>();
			List<object> list2;
			if (7 != 0)
			{
				list2 = list;
			}
			if (this.ActiveEntitiesSelectors != null && this.ActiveEntitiesSelectors.Count > 0)
			{
				HashSet<IEntitiesSelector>.Enumerator enumerator = this.ActiveEntitiesSelectors.GetEnumerator();
				HashSet<IEntitiesSelector>.Enumerator enumerator2;
				if (!false)
				{
					enumerator2 = enumerator;
				}
				try
				{
					while (enumerator2.MoveNext())
					{
						IEntitiesSelector entitiesSelector = enumerator2.Current;
						Point3D? #Xrb;
						list2.AddRange(entitiesSelector.#wLc(this.EnableSelectionRectangle, #Xrb, #Yrb));
					}
				}
				finally
				{
					if (!false)
					{
						((IDisposable)enumerator2).Dispose();
					}
				}
			}
			this.#wMc(list2);
		}

		// Token: 0x060061E5 RID: 25061 RVA: 0x0017EE24 File Offset: 0x0017D024
		protected void #wMc(IReadOnlyList<object> #xMc)
		{
			object #Rf = #xMc;
			string #R0d = #Phc.#3hc(107414444);
			StructurePoint.CoreAssets.Infrastructure.Exceptions.Component #x6c = StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUIFramework;
			string #Qic = #Phc.#3hc(107414451);
			if (8 != 0)
			{
				#X0d.#V0d(#Rf, #R0d, #x6c, #Qic);
			}
			List<object> list = new List<object>();
			List<object> list2;
			if (true)
			{
				list2 = list;
			}
			IReadOnlyList<object> readOnlyList = this.#FMc(#xMc);
			if (!false)
			{
				#xMc = readOnlyList;
			}
			do
			{
				IEnumerator<object> enumerator = #xMc.GetEnumerator();
				IEnumerator<object> enumerator2;
				if (3 != 0)
				{
					enumerator2 = enumerator;
				}
				try
				{
					for (;;)
					{
						bool flag2;
						bool flag = flag2 = enumerator2.MoveNext();
						object obj2;
						if (5 != 0)
						{
							if (false)
							{
								goto IL_72;
							}
							if (!flag)
							{
								break;
							}
							object obj = enumerator2.Current;
							if (4 != 0)
							{
								obj2 = obj;
							}
							flag2 = this.#b.Add(obj2);
						}
						if (flag2)
						{
							List<object> list3 = list2;
							object item = obj2;
							if (!false)
							{
								list3.Add(item);
							}
							continue;
						}
						this.#lLc(obj2);
						IL_72:
						if (7 != 0)
						{
							this.#b.Remove(obj2);
						}
					}
				}
				finally
				{
					if (enumerator2 != null)
					{
						enumerator2.Dispose();
					}
				}
				if (!#xMc.Any<object>())
				{
					return;
				}
			}
			while (-1 == 0);
			this.#AMc(list2);
		}

		// Token: 0x060061E6 RID: 25062 RVA: 0x0017EF1C File Offset: 0x0017D11C
		[SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
		protected virtual Dictionary<IEntitiesSelector, List<object>> #yMc(IList<object> #FOb)
		{
			string #R0d = #Phc.#3hc(107414398);
			StructurePoint.CoreAssets.Infrastructure.Exceptions.Component #x6c = StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUIFramework;
			string #Qic = #Phc.#3hc(107414385);
			if (true)
			{
				#X0d.#V0d(#FOb, #R0d, #x6c, #Qic);
			}
			Dictionary<IEntitiesSelector, List<object>> dictionary = this.Selectors.ToDictionary(new Func<IEntitiesSelector, IEntitiesSelector>(SelectionToolBase.<>c.<>9.#O9c), new Func<IEntitiesSelector, List<object>>(SelectionToolBase.<>c.<>9.#P9c));
			Dictionary<IEntitiesSelector, List<object>> dictionary2;
			if (2 != 0)
			{
				dictionary2 = dictionary;
			}
			IEnumerator<object> enumerator = #FOb.GetEnumerator();
			IEnumerator<object> enumerator2;
			if (4 != 0)
			{
				enumerator2 = enumerator;
			}
			try
			{
				while (enumerator2.MoveNext() || false)
				{
					SelectionToolBase.#N9c #N9c = new SelectionToolBase.#N9c();
					SelectionToolBase.#N9c #N9c2;
					if (!false)
					{
						#N9c2 = #N9c;
					}
					#N9c2.#a = enumerator2.Current;
					IEntitiesSelector entitiesSelector = this.Selectors.FirstOrDefault(new Func<IEntitiesSelector, bool>(#N9c2.#M9c));
					IEntitiesSelector entitiesSelector2;
					if (3 != 0)
					{
						entitiesSelector2 = entitiesSelector;
					}
					if (entitiesSelector2 != null)
					{
						List<object> list = dictionary2[entitiesSelector2];
						object item = #N9c2.#a;
						if (4 != 0)
						{
							list.Add(item);
						}
					}
				}
			}
			finally
			{
				if (enumerator2 != null)
				{
					enumerator2.Dispose();
				}
			}
			return dictionary2;
		}

		// Token: 0x060061E7 RID: 25063 RVA: 0x0017F038 File Offset: 0x0017D238
		public void #zMc(IList<object> #FOb)
		{
			if (#FOb == null)
			{
				return;
			}
			Dictionary<IEntitiesSelector, List<object>>.Enumerator enumerator = this.#yMc(#FOb).GetEnumerator();
			Dictionary<IEntitiesSelector, List<object>>.Enumerator enumerator2;
			if (!false)
			{
				enumerator2 = enumerator;
			}
			try
			{
				while (enumerator2.MoveNext())
				{
					KeyValuePair<IEntitiesSelector, List<object>> keyValuePair = enumerator2.Current;
					KeyValuePair<IEntitiesSelector, List<object>> keyValuePair2;
					if (8 != 0)
					{
						keyValuePair2 = keyValuePair;
					}
					if (keyValuePair2.Value.Any<object>())
					{
						IEntitiesSelector key = keyValuePair2.Key;
						IEnumerable<object> value = keyValuePair2.Value;
						if (!false)
						{
							key.#rLc(value);
						}
					}
				}
			}
			finally
			{
				do
				{
					((IDisposable)enumerator2).Dispose();
				}
				while (3 == 0);
			}
		}

		// Token: 0x060061E8 RID: 25064 RVA: 0x0017F0C0 File Offset: 0x0017D2C0
		public void #AMc(IList<object> #FOb)
		{
			if (#FOb == null)
			{
				return;
			}
			Dictionary<IEntitiesSelector, List<object>>.Enumerator enumerator = this.#yMc(#FOb).GetEnumerator();
			Dictionary<IEntitiesSelector, List<object>>.Enumerator enumerator2;
			if (!false)
			{
				enumerator2 = enumerator;
			}
			try
			{
				while (enumerator2.MoveNext())
				{
					KeyValuePair<IEntitiesSelector, List<object>> keyValuePair = enumerator2.Current;
					KeyValuePair<IEntitiesSelector, List<object>> keyValuePair2;
					if (8 != 0)
					{
						keyValuePair2 = keyValuePair;
					}
					if (keyValuePair2.Value.Any<object>())
					{
						IEntitiesSelector key = keyValuePair2.Key;
						IEnumerable<object> value = keyValuePair2.Value;
						if (!false)
						{
							key.#uR(value);
						}
					}
				}
			}
			finally
			{
				do
				{
					((IDisposable)enumerator2).Dispose();
				}
				while (3 == 0);
			}
		}

		// Token: 0x060061E9 RID: 25065 RVA: 0x0017F148 File Offset: 0x0017D348
		public override void #5b()
		{
			if (!false)
			{
				base.#5b();
			}
			do
			{
				if (5 != 0)
				{
					this.#KMc();
				}
			}
			while (false);
			HashSet<Key> hashSet = this.#c;
			if (!false)
			{
				hashSet.Clear();
			}
			ISet<Key> #H1d = this.#c;
			IEnumerable<Key> #8f = #8Ib.#JJc(base.SettingsProvider.ExtendedSelectionKey);
			if (6 != 0)
			{
				#H1d.#pR(#8f);
			}
			ModelEditorControlEventType[] array = new ModelEditorControlEventType[4];
			RuntimeFieldHandle fldHandle = fieldof(#l8c.#c).FieldHandle;
			if (5 != 0)
			{
				RuntimeHelpers.InitializeArray(array, fldHandle);
			}
			if (7 != 0)
			{
				base.#FIc(array);
			}
		}

		// Token: 0x060061EA RID: 25066 RVA: 0x000501A5 File Offset: 0x0004E3A5
		public override void #0kb()
		{
			if (8 != 0)
			{
				base.#0kb();
			}
			ModelEditorControlEventType[] #MEc = null;
			if (!false)
			{
				base.#LEc(#MEc);
			}
			if (!false)
			{
				this.#1kb();
			}
			if (this.ClearSelectionOnToolDeactivation && !false)
			{
				this.#iLc();
			}
		}

		// Token: 0x060061EB RID: 25067 RVA: 0x000501E1 File Offset: 0x0004E3E1
		public override void #1kb()
		{
			for (;;)
			{
				if (!false && !false)
				{
					this.#EMc();
				}
				for (;;)
				{
					bool flag = false;
					if (!false)
					{
						this.IsInExtendedSelectionMode = flag;
					}
					if (false)
					{
						break;
					}
					bool isWorking = false;
					if (!false)
					{
						base.IsWorking = isWorking;
					}
					if (!false)
					{
						base.#1kb();
					}
					if (!false)
					{
						return;
					}
				}
			}
		}

		// Token: 0x060061EC RID: 25068 RVA: 0x0017F1C8 File Offset: 0x0017D3C8
		protected override void #3kb(MouseButtonEventArgs #4kb)
		{
			if (this.ToolState == SelectionToolBase.#I9c.#a)
			{
				Point3D? point3D = base.#HIc(#4kb);
				Point3D? point3D2;
				if (!false)
				{
					point3D2 = point3D;
				}
				if (!false)
				{
					if (point3D2 == null)
					{
						if (3 != 0)
						{
							return;
						}
						return;
					}
					else
					{
						if (false)
						{
							return;
						}
						Point3D value = point3D2.Value;
						if (!false)
						{
							this.#DMc(value);
						}
					}
				}
				return;
			}
		}

		// Token: 0x060061ED RID: 25069 RVA: 0x0017F214 File Offset: 0x0017D414
		protected override void #5kb(MouseButtonEventArgs #4kb)
		{
			if (this.ToolState != SelectionToolBase.#I9c.#a)
			{
				Point3D? point3D = base.#HIc(#4kb);
				Point3D? point3D2;
				if (!false)
				{
					point3D2 = point3D;
				}
				if (!false)
				{
					if (point3D2 == null)
					{
						if (3 != 0)
						{
							return;
						}
						return;
					}
					else
					{
						if (false)
						{
							return;
						}
						Point3D value = point3D2.Value;
						if (!false)
						{
							this.#DMc(value);
						}
					}
				}
				return;
			}
		}

		// Token: 0x060061EE RID: 25070 RVA: 0x00050220 File Offset: 0x0004E420
		protected virtual void #BMc()
		{
			do
			{
				if (!false)
				{
					#R2c #R2c = base.ToolContext.MouseAndKeyboardService;
					object #A2c = base.ToolContext.OwnerControl;
					object toolOptionsEditor = base.ToolOptionsEditor;
					if (!false)
					{
						#R2c.#z2c(#A2c, toolOptionsEditor);
					}
				}
				if (!false)
				{
					this.#1kb();
				}
			}
			while (false);
		}

		// Token: 0x060061EF RID: 25071 RVA: 0x00009E6A File Offset: 0x0000806A
		protected virtual void #CMc()
		{
		}

		// Token: 0x060061F0 RID: 25072 RVA: 0x0017F260 File Offset: 0x0017D460
		protected override void #HEc(Point3D #IEc, Point3D #Kzb)
		{
			if (false || (-1 != 0 && this.ToolState == SelectionToolBase.#I9c.#a))
			{
				return;
			}
			if (#YIc.#Dzb(this.SelectedRectangleStartPoint, #Kzb))
			{
				Point3D? point3D = new Point3D?(#Kzb);
				if (!false)
				{
					this.SelectedRectangleEndPoint = point3D;
				}
				bool flag = true;
				if (7 != 0)
				{
					this.IsSelectionRectangleStarted = flag;
				}
				IDashedPlanarRectangleDrawingResult dashedPlanarRectangleDrawingResult = this.DashedPlanarRectangleDrawingResult;
				Point3D endPoint = PointsConverter.#Csc(#Kzb, 0.032);
				if (!false)
				{
					dashedPlanarRectangleDrawingResult.EndPoint = endPoint;
				}
				IDashedPlanarRectangleDrawingResult #BIc = this.DashedPlanarRectangleDrawingResult;
				double #CIc = base.SettingsProvider.VisualizationSelectionRectangleDashLength;
				if (!false)
				{
					base.#AIc(#BIc, #CIc);
				}
				IModelEditorControl modelEditorControl = base.ModelEditorControl;
				IDrawingResult drawingResult = this.DashedPlanarRectangleDrawingResult;
				if (3 != 0)
				{
					modelEditorControl.AddToView(drawingResult);
				}
			}
		}

		// Token: 0x060061F1 RID: 25073 RVA: 0x0005025D File Offset: 0x0004E45D
		protected override void #JEc(CameraDistanceChangedEventArgs #KEc)
		{
			if (#KEc == null)
			{
				return;
			}
			if (4 != 0)
			{
				base.#JEc(#KEc);
			}
			if (4 != 0)
			{
				this.#KMc();
			}
		}

		// Token: 0x060061F2 RID: 25074 RVA: 0x0017F304 File Offset: 0x0017D504
		[SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0")]
		protected override void #GEc(KeyEventArgs #HA)
		{
			if (#HA != null)
			{
				if (this.ProcessSelectionEvents && #HA.Key == Key.A)
				{
					if (6 == 0)
					{
						return;
					}
					if (Keyboard.Modifiers == ModifierKeys.Control)
					{
						if (true)
						{
							this.#CMc();
						}
						if (8 != 0)
						{
							this.#FDb();
						}
						bool handled = true;
						if (true)
						{
							#HA.Handled = handled;
						}
						goto IL_90;
					}
				}
				if (!this.ProcessSelectionEvents || !this.#d)
				{
					goto IL_90;
				}
				IL_4D:
				if (!this.IsInExtendedSelectionMode)
				{
					if (5 != 0)
					{
						bool flag = this.#c.Contains(#HA.Key);
						if (!false)
						{
							this.IsInExtendedSelectionMode = flag;
						}
						if (!this.IsInExtendedSelectionMode)
						{
							goto IL_90;
						}
						if (5 == 0)
						{
							return;
						}
						Key key = #HA.Key;
						if (3 != 0)
						{
							this.PressedSpecialKey = key;
						}
					}
					bool handled2 = true;
					if (4 != 0)
					{
						#HA.Handled = handled2;
					}
				}
				IL_90:
				if (!#HA.Handled)
				{
					if (-1 == 0)
					{
						goto IL_4D;
					}
					base.#GEc(#HA);
				}
				return;
			}
		}

		// Token: 0x060061F3 RID: 25075 RVA: 0x0017F3E8 File Offset: 0x0017D5E8
		[SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0")]
		protected override void #2kb(KeyEventArgs #HA)
		{
			bool flag;
			if (!false)
			{
				flag = this.ProcessSelectionEvents;
				goto IL_09;
			}
			IL_0B:
			while (#HA != null)
			{
				if (this.IsInExtendedSelectionMode)
				{
					if (false)
					{
						continue;
					}
					if (#HA.Key == this.PressedSpecialKey)
					{
						bool flag2 = false;
						if (3 != 0)
						{
							this.IsInExtendedSelectionMode = flag2;
						}
						if (7 == 0)
						{
							goto IL_53;
						}
						bool flag3 = flag = #HA.Handled;
						if (false)
						{
							goto IL_09;
						}
						if (!flag3 && 6 != 0)
						{
							this.#BMc();
						}
					}
				}
				if (#HA.Handled || #HA.Key != Key.Escape)
				{
					break;
				}
				IL_53:
				if (false)
				{
					break;
				}
				this.#iLc();
				break;
			}
			goto IL_58;
			IL_09:
			if (flag)
			{
				goto IL_0B;
			}
			IL_58:
			if (true)
			{
				base.#2kb(#HA);
			}
		}

		// Token: 0x060061F4 RID: 25076 RVA: 0x0017F470 File Offset: 0x0017D670
		protected virtual void #DMc(Point3D #HAb)
		{
			while (this.ProcessSelectionEvents)
			{
				if (this.ToolState != SelectionToolBase.#I9c.#a)
				{
					if (this.ToolState == SelectionToolBase.#I9c.#b)
					{
						this.SelectedRectangleEndPoint = new Point3D?(#HAb);
						if (5 != 0)
						{
							this.#CMc();
							if (!this.IsInExtendedSelectionMode)
							{
								this.#iLc();
								if (!false)
								{
									this.#vMc();
									this.#BMc();
									return;
								}
								goto IL_89;
							}
						}
						this.#vMc();
						this.#EMc();
						if (3 != 0)
						{
							return;
						}
						goto IL_3C;
					}
					return;
				}
				if (false)
				{
					continue;
				}
				Point3D point3D;
				if (-1 != 0)
				{
					point3D = #HAb;
				}
				IDashedPlanarRectangleDrawingResult dashedPlanarRectangleDrawingResult = this.DashedPlanarRectangleDrawingResult;
				Point3D startPoint = PointsConverter.#Csc(point3D, 0.032);
				if (6 != 0)
				{
					dashedPlanarRectangleDrawingResult.StartPoint = startPoint;
				}
				IL_3C:
				IDashedPlanarRectangleDrawingResult dashedPlanarRectangleDrawingResult2 = this.DashedPlanarRectangleDrawingResult;
				Point3D endPoint = new Point3D(point3D.X, point3D.Y + 0.032, 0.032);
				if (!false)
				{
					dashedPlanarRectangleDrawingResult2.EndPoint = endPoint;
				}
				Point3D? point3D2 = new Point3D?(point3D);
				if (-1 != 0)
				{
					this.SelectedRectangleStartPoint = point3D2;
				}
				SelectionToolBase.#I9c #I9c = SelectionToolBase.#I9c.#b;
				if (!false)
				{
					this.ToolState = #I9c;
				}
				IL_89:
				bool isWorking = true;
				if (7 != 0)
				{
					base.IsWorking = isWorking;
				}
				return;
			}
		}

		// Token: 0x060061F5 RID: 25077 RVA: 0x0017F598 File Offset: 0x0017D798
		protected void #EMc()
		{
			do
			{
				IModelEditorControl modelEditorControl = base.ModelEditorControl;
				IDrawingResult drawingResult = this.DashedPlanarRectangleDrawingResult;
				if (4 != 0)
				{
					modelEditorControl.RemoveFromView(drawingResult);
				}
			}
			while (false);
			SelectionToolBase.#I9c #I9c = SelectionToolBase.#I9c.#a;
			if (!false)
			{
				this.ToolState = #I9c;
			}
			Point3D? point3D = null;
			if (!false)
			{
				this.SelectedRectangleEndPoint = point3D;
			}
			Point3D? point3D2 = null;
			if (!false)
			{
				this.SelectedRectangleStartPoint = point3D2;
			}
			bool flag = false;
			if (!false)
			{
				this.IsSelectionRectangleStarted = flag;
			}
		}

		// Token: 0x060061F6 RID: 25078 RVA: 0x0017F608 File Offset: 0x0017D808
		private IReadOnlyList<object> #FMc(IReadOnlyList<object> #GMc)
		{
			List<NodeModel> list = #GMc.OfType<NodeModel>().ToList<NodeModel>();
			List<NodeModel> list2;
			if (7 != 0)
			{
				list2 = list;
			}
			if (!list2.Any<NodeModel>())
			{
				return #GMc;
			}
			List<NodeModel> source = this.#b.OfType<NodeModel>().ToList<NodeModel>();
			List<Point> list3 = source.Select(new Func<NodeModel, Point>(SelectionToolBase.<>c.<>9.#Q9c)).OrderBy(new Func<Point, double>(SelectionToolBase.<>c.<>9.#R9c)).ThenBy(new Func<Point, double>(SelectionToolBase.<>c.<>9.#S9c)).ToList<Point>();
			List<Point> #BP;
			if (true)
			{
				#BP = list3;
			}
			Dictionary<Point, List<NodeModel>> dictionary = source.ToLookup(new Func<NodeModel, Point>(SelectionToolBase.<>c.<>9.#T9c), new Func<NodeModel, NodeModel>(SelectionToolBase.<>c.<>9.#U9c)).ToDictionary(new Func<IGrouping<Point, NodeModel>, Point>(SelectionToolBase.<>c.<>9.#V9c), new Func<IGrouping<Point, NodeModel>, List<NodeModel>>(SelectionToolBase.<>c.<>9.#W9c));
			Dictionary<Point, List<NodeModel>> dictionary2;
			if (6 != 0)
			{
				dictionary2 = dictionary;
			}
			List<NodeModel> list4 = new List<NodeModel>();
			List<NodeModel> list5;
			if (!false)
			{
				list5 = list4;
			}
			List<object> list6 = new List<object>();
			List<object> list7;
			if (5 != 0)
			{
				list7 = list6;
			}
			Dictionary<int, LinkedList<Point>> dictionary3 = new Dictionary<int, LinkedList<Point>>();
			Dictionary<int, LinkedList<Point>> #IMc;
			if (!false)
			{
				#IMc = dictionary3;
			}
			foreach (NodeModel nodeModel in list2)
			{
				SelectionToolBase.#RUb #RUb = new SelectionToolBase.#RUb();
				#RUb.#a = nodeModel.Location;
				Point? point = base.SnappingProvider.#bNb(#BP, #RUb.#a, 1.0);
				List<NodeModel> source2;
				bool flag;
				if (point != null && Point.#E3d(point.Value, #RUb.#a))
				{
					flag = dictionary2.TryGetValue(#RUb.#a, out source2);
				}
				else
				{
					bool flag2 = flag = SelectionToolBase.#HMc(#IMc, #RUb.#a);
					if (2 != 0)
					{
						if (flag2)
						{
							this.#b.Add(nodeModel);
							list5.Add(nodeModel);
							continue;
						}
						continue;
					}
				}
				if (flag)
				{
					NodeModel nodeModel2 = source2.FirstOrDefault(new Func<NodeModel, bool>(#RUb.#X9c));
					if (nodeModel2 != null)
					{
						this.#b.Remove(nodeModel2);
						list7.Add(nodeModel2);
					}
				}
			}
			if (list7.Any<object>())
			{
				this.#zMc(list7);
			}
			if (list2.Any<NodeModel>())
			{
				this.#AMc(list5.OfType<object>().ToList<object>());
			}
			return #GMc.Except(list2).ToList<object>();
		}

		// Token: 0x060061F7 RID: 25079 RVA: 0x0017F8C8 File Offset: 0x0017DAC8
		private static bool #HMc(Dictionary<int, LinkedList<Point>> #IMc, Point #JMc)
		{
			if (3 == 0)
			{
				goto IL_5A;
			}
			SelectionToolBase.#ZTb #ZTb = new SelectionToolBase.#ZTb();
			SelectionToolBase.#ZTb #ZTb2;
			if (7 != 0)
			{
				#ZTb2 = #ZTb;
			}
			#ZTb2.#a = #JMc;
			LinkedList<Point> linkedList;
			int num = #IMc.TryGetValue(#ZTb2.#a.GetHashCode(), out linkedList) ? 1 : 0;
			IL_2C:
			if (num != 0)
			{
				if (!linkedList.Any(new Func<Point, bool>(#ZTb2.#Y9c)))
				{
					linkedList.AddLast(#ZTb2.#a);
					return true;
				}
				return false;
			}
			else
			{
				LinkedList<Point> linkedList2 = new LinkedList<Point>();
				if (!false)
				{
					linkedList = linkedList2;
				}
			}
			IL_5A:
			linkedList.AddLast(#ZTb2.#a);
			int hashCode = #ZTb2.#a.GetHashCode();
			LinkedList<Point> value = linkedList;
			if (7 != 0)
			{
				#IMc[hashCode] = value;
			}
			int num2 = num = 1;
			if (num2 != 0)
			{
				return num2 != 0;
			}
			goto IL_2C;
		}

		// Token: 0x060061F8 RID: 25080 RVA: 0x0017F96C File Offset: 0x0017DB6C
		private void #KMc()
		{
			if (!false)
			{
				IDashedPlanarRectangleDrawingResult dashedPlanarRectangleDrawingResult = this.DashedPlanarRectangleDrawingResult;
				Color? lineColor = new Color?(base.SettingsProvider.VisualizationSelectionRectangleBorderColor);
				if (!false)
				{
					dashedPlanarRectangleDrawingResult.LineColor = lineColor;
				}
				IDashedPlanarRectangleDrawingResult dashedPlanarRectangleDrawingResult2 = this.DashedPlanarRectangleDrawingResult;
				double lineThickness = base.SettingsProvider.VisualizationSelectionRectangleBorderThickness;
				if (!false)
				{
					dashedPlanarRectangleDrawingResult2.LineThickness = lineThickness;
				}
				for (;;)
				{
					IDashedPlanarRectangleDrawingResult dashedPlanarRectangleDrawingResult3 = this.DashedPlanarRectangleDrawingResult;
					Color color = base.SettingsProvider.VisualizationSelectionRectangleFillColor;
					if (4 != 0)
					{
						dashedPlanarRectangleDrawingResult3.Color = color;
					}
					if (!false)
					{
						IDashedPlanarRectangleDrawingResult #BIc = this.DashedPlanarRectangleDrawingResult;
						double #CIc = base.SettingsProvider.VisualizationSelectionRectangleDashLength;
						if (3 == 0)
						{
							break;
						}
						base.#AIc(#BIc, #CIc);
						break;
					}
				}
			}
		}

		// Token: 0x04002828 RID: 10280
		private bool #a;

		// Token: 0x04002829 RID: 10281
		private readonly HashSet<object> #b = new HashSet<object>();

		// Token: 0x0400282A RID: 10282
		private readonly HashSet<Key> #c = new HashSet<Key>();

		// Token: 0x0400282B RID: 10283
		private bool #d;

		// Token: 0x0400282C RID: 10284
		private bool #e;

		// Token: 0x0400282D RID: 10285
		[CompilerGenerated]
		private Key #f;

		// Token: 0x0400282E RID: 10286
		[CompilerGenerated]
		private bool #g;

		// Token: 0x0400282F RID: 10287
		[CompilerGenerated]
		private IDashedPlanarRectangleDrawingResult #h;

		// Token: 0x04002830 RID: 10288
		[CompilerGenerated]
		private SelectionToolBase.#I9c #i;

		// Token: 0x04002831 RID: 10289
		[CompilerGenerated]
		private bool #j;

		// Token: 0x04002832 RID: 10290
		[CompilerGenerated]
		private bool #k;

		// Token: 0x04002833 RID: 10291
		[CompilerGenerated]
		private Point3D? #l;

		// Token: 0x04002834 RID: 10292
		[CompilerGenerated]
		private Point3D? #m;

		// Token: 0x04002835 RID: 10293
		[CompilerGenerated]
		private Vector #n;

		// Token: 0x04002836 RID: 10294
		[CompilerGenerated]
		private List<IEntitiesSelector> #o;

		// Token: 0x04002837 RID: 10295
		[CompilerGenerated]
		private HashSet<IEntitiesSelector> #p;

		// Token: 0x02000BA3 RID: 2979
		public enum #I9c
		{
			// Token: 0x04002839 RID: 10297
			#a,
			// Token: 0x0400283A RID: 10298
			#b,
			// Token: 0x0400283B RID: 10299
			#c
		}

		// Token: 0x02000BA5 RID: 2981
		[CompilerGenerated]
		private sealed class #K9c
		{
			// Token: 0x06006205 RID: 25093 RVA: 0x000502B2 File Offset: 0x0004E4B2
			internal bool #J9c(IEntitiesSelector #b3c)
			{
				return #b3c.#sLc(this.#a);
			}

			// Token: 0x04002846 RID: 10310
			public object #a;
		}

		// Token: 0x02000BA6 RID: 2982
		[CompilerGenerated]
		private sealed class #QTb
		{
			// Token: 0x06006207 RID: 25095 RVA: 0x000502C0 File Offset: 0x0004E4C0
			internal bool #L9c(IEntitiesSelector #b3c)
			{
				return #b3c.#sLc(this.#a);
			}

			// Token: 0x04002847 RID: 10311
			public object #a;
		}

		// Token: 0x02000BA7 RID: 2983
		[CompilerGenerated]
		private sealed class #N9c
		{
			// Token: 0x06006209 RID: 25097 RVA: 0x000502CE File Offset: 0x0004E4CE
			internal bool #M9c(IEntitiesSelector #b3c)
			{
				return #b3c.#sLc(this.#a);
			}

			// Token: 0x04002848 RID: 10312
			public object #a;
		}

		// Token: 0x02000BA8 RID: 2984
		[CompilerGenerated]
		private sealed class #RUb
		{
			// Token: 0x0600620B RID: 25099 RVA: 0x0017FA00 File Offset: 0x0017DC00
			internal bool #X9c(NodeModel #Rf)
			{
				Point point = #Rf.Location;
				Point point2;
				if (!false)
				{
					point2 = point;
				}
				return point2.#e(this.#a);
			}

			// Token: 0x04002849 RID: 10313
			public Point #a;
		}

		// Token: 0x02000BA9 RID: 2985
		[CompilerGenerated]
		private sealed class #ZTb
		{
			// Token: 0x0600620D RID: 25101 RVA: 0x000502DC File Offset: 0x0004E4DC
			internal bool #Y9c(Point #Rf)
			{
				return PointsConverter.#uC(#Rf, this.#a);
			}

			// Token: 0x0400284A RID: 10314
			public Point #a;
		}
	}
}
