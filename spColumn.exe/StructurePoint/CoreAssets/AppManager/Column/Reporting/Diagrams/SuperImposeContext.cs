using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using #7hc;
using #oFe;
using #Oze;
using #xBe;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.Framework.Collections;
using Svg;

namespace StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams
{
	// Token: 0x0200120A RID: 4618
	public sealed class SuperImposeContext : NotifyPropertyChangedObjectBase, #mAe
	{
		// Token: 0x17002CDB RID: 11483
		// (get) Token: 0x06009ABD RID: 39613 RVA: 0x0007A750 File Offset: 0x00078950
		// (set) Token: 0x06009ABE RID: 39614 RVA: 0x0007A758 File Offset: 0x00078958
		public bool IsActive
		{
			get
			{
				return this.#b;
			}
			set
			{
				this.SetProperty<bool>(ref this.#b, value, #Phc.#3hc(107362485));
			}
		}

		// Token: 0x17002CDC RID: 11484
		// (get) Token: 0x06009ABF RID: 39615 RVA: 0x0007A772 File Offset: 0x00078972
		// (set) Token: 0x06009AC0 RID: 39616 RVA: 0x0007A77A File Offset: 0x0007897A
		public bool KeepDiagramsAfterExecution
		{
			get
			{
				return this.#c;
			}
			set
			{
				this.SetProperty<bool>(ref this.#c, value, #Phc.#3hc(107283089));
			}
		}

		// Token: 0x17002CDD RID: 11485
		// (get) Token: 0x06009AC1 RID: 39617 RVA: 0x0007A794 File Offset: 0x00078994
		public bool CanAddDiagram
		{
			get
			{
				return this.Diagrams.Count < 4;
			}
		}

		// Token: 0x17002CDE RID: 11486
		// (get) Token: 0x06009AC2 RID: 39618 RVA: 0x0007A7A4 File Offset: 0x000789A4
		public CustomObservableCollection<SuperImposeDiagram> Diagrams { get; } = new CustomObservableCollection<SuperImposeDiagram>();

		// Token: 0x17002CDF RID: 11487
		// (get) Token: 0x06009AC3 RID: 39619 RVA: 0x0007A7AC File Offset: 0x000789AC
		public #dAe InterpolatedCache { get; } = new #dAe();

		// Token: 0x17002CE0 RID: 11488
		// (get) Token: 0x06009AC4 RID: 39620 RVA: 0x0007A7B4 File Offset: 0x000789B4
		protected static List<Color> Colors { get; } = new List<Color>
		{
			Color.FromRgb(byte.MaxValue, 0, 0),
			Color.FromRgb(51, 0, byte.MaxValue),
			Color.FromRgb(0, 176, 80),
			Color.FromRgb(byte.MaxValue, 0, 153)
		};

		// Token: 0x17002CE1 RID: 11489
		// (get) Token: 0x06009AC5 RID: 39621 RVA: 0x0007A7BB File Offset: 0x000789BB
		protected static List<SvgUnitCollection> LineTypes { get; } = new List<SvgUnitCollection>
		{
			#1Ge.#ul(new SvgUnit[]
			{
				2f,
				2f
			}),
			#1Ge.#ul(new SvgUnit[]
			{
				5f,
				2f
			}),
			#1Ge.#ul(new SvgUnit[]
			{
				4f,
				2f,
				1f,
				2f
			}),
			#1Ge.#ul(new SvgUnit[]
			{
				5f,
				2f,
				3f,
				2f
			})
		};

		// Token: 0x06009AC6 RID: 39622 RVA: 0x0020E3DC File Offset: 0x0020C5DC
		public void #iAe(#DBe #jAe)
		{
			Color #BR = this.#DAe();
			SvgUnitCollection #GAe = this.#EAe();
			this.#FAe(#jAe, #BR, #GAe);
		}

		// Token: 0x06009AC7 RID: 39623 RVA: 0x0007A7C2 File Offset: 0x000789C2
		public void #kAe(SuperImposeDiagram #lAe)
		{
			if (this.Diagrams.Contains(#lAe))
			{
				this.Diagrams.Remove(#lAe);
			}
		}

		// Token: 0x06009AC8 RID: 39624 RVA: 0x0007A7DF File Offset: 0x000789DF
		public void #yl()
		{
			this.InterpolatedCache.#yl();
			this.Diagrams.Clear();
			this.IsActive = false;
		}

		// Token: 0x06009AC9 RID: 39625 RVA: 0x0020E400 File Offset: 0x0020C600
		public #mAe #Yfd()
		{
			IEnumerable<SuperImposeDiagram> #8f = this.Diagrams.Select(new Func<SuperImposeDiagram, SuperImposeDiagram>(SuperImposeContext.<>c.<>9.#tdf));
			SuperImposeContext superImposeContext = new SuperImposeContext();
			superImposeContext.Diagrams.#pR(#8f);
			superImposeContext.IsActive = this.IsActive;
			return superImposeContext;
		}

		// Token: 0x06009ACA RID: 39626 RVA: 0x0020E458 File Offset: 0x0020C658
		public bool #e(#mAe #L0)
		{
			if (this.IsActive != #L0.IsActive)
			{
				return false;
			}
			if (this.Diagrams.Count != #L0.Diagrams.Count)
			{
				return false;
			}
			for (int i = 0; i < this.Diagrams.Count; i++)
			{
				SuperImposeDiagram superImposeDiagram = this.Diagrams[i];
				SuperImposeDiagram other = #L0.Diagrams[i];
				if (!superImposeDiagram.Equals(other))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06009ACB RID: 39627 RVA: 0x0020E4CC File Offset: 0x0020C6CC
		private Color #DAe()
		{
			IEnumerable<Color> second = this.Diagrams.Select(new Func<SuperImposeDiagram, Color>(SuperImposeContext.<>c.<>9.#udf));
			return SuperImposeContext.Colors.Except(second).FirstOrDefault<Color>();
		}

		// Token: 0x06009ACC RID: 39628 RVA: 0x0020E514 File Offset: 0x0020C714
		private SvgUnitCollection #EAe()
		{
			IEnumerable<SvgUnitCollection> second = this.Diagrams.Select(new Func<SuperImposeDiagram, SvgUnitCollection>(SuperImposeContext.<>c.<>9.#vdf));
			return SuperImposeContext.LineTypes.Except(second).FirstOrDefault<SvgUnitCollection>();
		}

		// Token: 0x06009ACD RID: 39629 RVA: 0x0007A7FE File Offset: 0x000789FE
		private void #FAe(#DBe #Gfb, Color #BR, SvgUnitCollection #GAe)
		{
			if (#Gfb.RunAxis == ConsideredAxis.Both)
			{
				this.#HAe(#Gfb, #Gfb.FilePath, #BR, #GAe);
				return;
			}
			this.#IAe(#Gfb, #Gfb.FilePath, #BR, #GAe);
		}

		// Token: 0x06009ACE RID: 39630 RVA: 0x0020E55C File Offset: 0x0020C75C
		private void #HAe(#DBe #Gfb, string #4Hc, Color #BR, SvgUnitCollection #GAe)
		{
			if (!this.CanAddDiagram)
			{
				return;
			}
			SuperImposeDiagram item = new SuperImposeDiagram
			{
				Label = Path.GetFileNameWithoutExtension(#4Hc),
				BiCurves = #Gfb.BiCurves,
				Color = #BR,
				LineType = #GAe,
				IsEnabled = true,
				FilePath = #4Hc
			};
			this.Diagrams.Add(item);
		}

		// Token: 0x06009ACF RID: 39631 RVA: 0x0020E5BC File Offset: 0x0020C7BC
		private void #IAe(#DBe #Gfb, string #4Hc, Color #BR, SvgUnitCollection #GAe)
		{
			if (!this.CanAddDiagram)
			{
				return;
			}
			SuperImposeDiagram item = new SuperImposeDiagram
			{
				Label = Path.GetFileNameWithoutExtension(#4Hc),
				UniCurve = #Gfb.UniCurve,
				Color = #BR,
				LineType = #GAe,
				IsEnabled = true,
				FilePath = #4Hc
			};
			this.Diagrams.Add(item);
		}

		// Token: 0x0400429F RID: 17055
		public const int #a = 4;

		// Token: 0x040042A0 RID: 17056
		private bool #b;

		// Token: 0x040042A1 RID: 17057
		private bool #c = true;

		// Token: 0x040042A2 RID: 17058
		[CompilerGenerated]
		private readonly CustomObservableCollection<SuperImposeDiagram> #d;

		// Token: 0x040042A3 RID: 17059
		[CompilerGenerated]
		private readonly #dAe #e;

		// Token: 0x040042A4 RID: 17060
		[CompilerGenerated]
		private static readonly List<Color> #f;

		// Token: 0x040042A5 RID: 17061
		[CompilerGenerated]
		private static readonly List<SvgUnitCollection> #g;
	}
}
