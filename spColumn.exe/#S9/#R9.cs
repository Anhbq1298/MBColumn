using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using #7hc;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams.DTO;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Settings;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;

namespace #S9
{
	// Token: 0x020003C8 RID: 968
	internal sealed class #R9 : NotifyPropertyChangedObjectBase, INotifyPropertyChanged, #tbb
	{
		// Token: 0x17000B8A RID: 2954
		// (get) Token: 0x06002125 RID: 8485 RVA: 0x000204C4 File Offset: 0x0001E6C4
		// (set) Token: 0x06002126 RID: 8486 RVA: 0x000204D0 File Offset: 0x0001E6D0
		public bool IsDiagram3DIsHorizontalShowPlaneEnabled
		{
			get
			{
				return this.#z;
			}
			set
			{
				if (this.#z != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107397372));
					this.#z = value;
					base.RaisePropertyChanged(#Phc.#3hc(107397372));
				}
			}
		}

		// Token: 0x17000B8B RID: 2955
		// (get) Token: 0x06002127 RID: 8487 RVA: 0x0002050E File Offset: 0x0001E70E
		// (set) Token: 0x06002128 RID: 8488 RVA: 0x0002051A File Offset: 0x0001E71A
		public bool IsDiagram3DIsHorizontalCutEnabled
		{
			get
			{
				return this.#A;
			}
			set
			{
				if (this.#A != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107397287));
					this.#A = value;
					base.RaisePropertyChanged(#Phc.#3hc(107397287));
				}
			}
		}

		// Token: 0x17000B8C RID: 2956
		// (get) Token: 0x06002129 RID: 8489 RVA: 0x00020558 File Offset: 0x0001E758
		// (set) Token: 0x0600212A RID: 8490 RVA: 0x00020564 File Offset: 0x0001E764
		public bool IsDiagram3DIsHorizontalFlipEnabled
		{
			get
			{
				return this.#B;
			}
			set
			{
				if (this.#B != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107397274));
					this.#B = value;
					base.RaisePropertyChanged(#Phc.#3hc(107397274));
				}
			}
		}

		// Token: 0x17000B8D RID: 2957
		// (get) Token: 0x0600212B RID: 8491 RVA: 0x000205A2 File Offset: 0x0001E7A2
		// (set) Token: 0x0600212C RID: 8492 RVA: 0x000205AE File Offset: 0x0001E7AE
		public bool IsDiagram3DIsVerticalFlipEnabled
		{
			get
			{
				return this.#x;
			}
			set
			{
				if (this.#x != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107397193));
					this.#x = value;
					base.RaisePropertyChanged(#Phc.#3hc(107397193));
				}
			}
		}

		// Token: 0x17000B8E RID: 2958
		// (get) Token: 0x0600212D RID: 8493 RVA: 0x000205EC File Offset: 0x0001E7EC
		// (set) Token: 0x0600212E RID: 8494 RVA: 0x000205F8 File Offset: 0x0001E7F8
		public bool IsDiagram3DIsVerticalCutEnabled
		{
			get
			{
				return this.#w;
			}
			set
			{
				if (this.#w != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107397180));
					this.#w = value;
					base.RaisePropertyChanged(#Phc.#3hc(107397180));
				}
			}
		}

		// Token: 0x17000B8F RID: 2959
		// (get) Token: 0x0600212F RID: 8495 RVA: 0x00020636 File Offset: 0x0001E836
		// (set) Token: 0x06002130 RID: 8496 RVA: 0x00020642 File Offset: 0x0001E842
		public bool IsDiagram3DIsVerticalShowPlaneEnabled
		{
			get
			{
				return this.#y;
			}
			set
			{
				if (this.#y != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107397615));
					this.#y = value;
					base.RaisePropertyChanged(#Phc.#3hc(107397615));
				}
			}
		}

		// Token: 0x17000B90 RID: 2960
		// (get) Token: 0x06002131 RID: 8497 RVA: 0x00020680 File Offset: 0x0001E880
		// (set) Token: 0x06002132 RID: 8498 RVA: 0x0002068C File Offset: 0x0001E88C
		public bool IsDiagramPMEnabled
		{
			get
			{
				return this.#k;
			}
			set
			{
				if (this.#k != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107397594));
					this.#k = value;
					base.RaisePropertyChanged(#Phc.#3hc(107397594));
				}
			}
		}

		// Token: 0x17000B91 RID: 2961
		// (get) Token: 0x06002133 RID: 8499 RVA: 0x000206CA File Offset: 0x0001E8CA
		// (set) Token: 0x06002134 RID: 8500 RVA: 0x000206D6 File Offset: 0x0001E8D6
		public bool IsDiagram3DHorizontalEnabled
		{
			get
			{
				return this.#l;
			}
			set
			{
				if (this.#l != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107397537));
					this.#l = value;
					base.RaisePropertyChanged(#Phc.#3hc(107397537));
				}
			}
		}

		// Token: 0x17000B92 RID: 2962
		// (get) Token: 0x06002135 RID: 8501 RVA: 0x00020714 File Offset: 0x0001E914
		// (set) Token: 0x06002136 RID: 8502 RVA: 0x00020720 File Offset: 0x0001E920
		public bool IsDiagram3DVerticalEnabled
		{
			get
			{
				return this.#m;
			}
			set
			{
				if (this.#m != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107397528));
					this.#m = value;
					base.RaisePropertyChanged(#Phc.#3hc(107397528));
				}
			}
		}

		// Token: 0x17000B93 RID: 2963
		// (get) Token: 0x06002137 RID: 8503 RVA: 0x0002075E File Offset: 0x0001E95E
		// (set) Token: 0x06002138 RID: 8504 RVA: 0x0002076A File Offset: 0x0001E96A
		public bool IsBiaxialActive
		{
			get
			{
				return this.#i;
			}
			set
			{
				if (this.#i != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107397491));
					this.#i = value;
					base.RaisePropertyChanged(#Phc.#3hc(107397491));
				}
			}
		}

		// Token: 0x17000B94 RID: 2964
		// (get) Token: 0x06002139 RID: 8505 RVA: 0x000207A8 File Offset: 0x0001E9A8
		// (set) Token: 0x0600213A RID: 8506 RVA: 0x000207B4 File Offset: 0x0001E9B4
		public bool IsReportSourceValid
		{
			get
			{
				return this.#j;
			}
			set
			{
				if (this.#j != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107397470));
					this.#j = value;
					base.RaisePropertyChanged(#Phc.#3hc(107397470));
				}
			}
		}

		// Token: 0x17000B95 RID: 2965
		// (get) Token: 0x0600213B RID: 8507 RVA: 0x000207F2 File Offset: 0x0001E9F2
		// (set) Token: 0x0600213C RID: 8508 RVA: 0x000207FE File Offset: 0x0001E9FE
		public bool IsDiagramMMChecked
		{
			get
			{
				return this.#a;
			}
			set
			{
				if (this.#a != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107397409));
					this.#a = value;
					base.RaisePropertyChanged(#Phc.#3hc(107397409));
				}
			}
		}

		// Token: 0x17000B96 RID: 2966
		// (get) Token: 0x0600213D RID: 8509 RVA: 0x0002083C File Offset: 0x0001EA3C
		// (set) Token: 0x0600213E RID: 8510 RVA: 0x00020848 File Offset: 0x0001EA48
		public bool IsDiagramMMEnabled
		{
			get
			{
				return this.#b;
			}
			set
			{
				if (this.#b != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107397384));
					this.#b = value;
					base.RaisePropertyChanged(#Phc.#3hc(107397384));
				}
			}
		}

		// Token: 0x17000B97 RID: 2967
		// (get) Token: 0x0600213F RID: 8511 RVA: 0x00020886 File Offset: 0x0001EA86
		// (set) Token: 0x06002140 RID: 8512 RVA: 0x00020892 File Offset: 0x0001EA92
		public bool IsDiagramPMChecked
		{
			get
			{
				return this.#c;
			}
			set
			{
				if (this.#c != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107364079));
					this.#c = value;
					base.RaisePropertyChanged(#Phc.#3hc(107364079));
				}
			}
		}

		// Token: 0x17000B98 RID: 2968
		// (get) Token: 0x06002141 RID: 8513 RVA: 0x000208D0 File Offset: 0x0001EAD0
		// (set) Token: 0x06002142 RID: 8514 RVA: 0x000208DC File Offset: 0x0001EADC
		public bool IsDiagramPMPlusChecked
		{
			get
			{
				return this.#d;
			}
			set
			{
				if (this.#d != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107364086));
					this.#d = value;
					base.RaisePropertyChanged(#Phc.#3hc(107364086));
				}
			}
		}

		// Token: 0x17000B99 RID: 2969
		// (get) Token: 0x06002143 RID: 8515 RVA: 0x0002091A File Offset: 0x0001EB1A
		// (set) Token: 0x06002144 RID: 8516 RVA: 0x00020926 File Offset: 0x0001EB26
		public bool IsDiagramPMMinusChecked
		{
			get
			{
				return this.#e;
			}
			set
			{
				if (this.#e != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107364053));
					this.#e = value;
					base.RaisePropertyChanged(#Phc.#3hc(107364053));
				}
			}
		}

		// Token: 0x17000B9A RID: 2970
		// (get) Token: 0x06002145 RID: 8517 RVA: 0x00020964 File Offset: 0x0001EB64
		// (set) Token: 0x06002146 RID: 8518 RVA: 0x00020970 File Offset: 0x0001EB70
		public bool IsDiagramPMGroupChecked
		{
			get
			{
				return this.#f;
			}
			set
			{
				if (this.#f != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107364020));
					this.#f = value;
					base.RaisePropertyChanged(#Phc.#3hc(107364020));
				}
			}
		}

		// Token: 0x17000B9B RID: 2971
		// (get) Token: 0x06002147 RID: 8519 RVA: 0x000209AE File Offset: 0x0001EBAE
		// (set) Token: 0x06002148 RID: 8520 RVA: 0x000209BA File Offset: 0x0001EBBA
		public bool IsDiagram3DHorizontalChecked
		{
			get
			{
				return this.#g;
			}
			set
			{
				if (this.#g != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107363987));
					this.#g = value;
					base.RaisePropertyChanged(#Phc.#3hc(107363987));
				}
			}
		}

		// Token: 0x17000B9C RID: 2972
		// (get) Token: 0x06002149 RID: 8521 RVA: 0x000209F8 File Offset: 0x0001EBF8
		// (set) Token: 0x0600214A RID: 8522 RVA: 0x00020A04 File Offset: 0x0001EC04
		public bool IsDiagram3DVerticalChecked
		{
			get
			{
				return this.#h;
			}
			set
			{
				if (this.#h != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107363914));
					this.#h = value;
					base.RaisePropertyChanged(#Phc.#3hc(107363914));
				}
			}
		}

		// Token: 0x17000B9D RID: 2973
		// (get) Token: 0x0600214B RID: 8523 RVA: 0x00020A42 File Offset: 0x0001EC42
		// (set) Token: 0x0600214C RID: 8524 RVA: 0x00020A4E File Offset: 0x0001EC4E
		public bool IsDiagram3DFlipCommandEnabled
		{
			get
			{
				return this.#n;
			}
			set
			{
				if (this.#n != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107363877));
					this.#n = value;
					base.RaisePropertyChanged(#Phc.#3hc(107363877));
				}
			}
		}

		// Token: 0x17000B9E RID: 2974
		// (get) Token: 0x0600214D RID: 8525 RVA: 0x00020A8C File Offset: 0x0001EC8C
		// (set) Token: 0x0600214E RID: 8526 RVA: 0x00020A98 File Offset: 0x0001EC98
		public bool IsExportDiagramCommandEnabled
		{
			get
			{
				return this.#o;
			}
			set
			{
				if (this.#o != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107363868));
					this.#o = value;
					base.RaisePropertyChanged(#Phc.#3hc(107363868));
				}
			}
		}

		// Token: 0x17000B9F RID: 2975
		// (get) Token: 0x0600214F RID: 8527 RVA: 0x00020AD6 File Offset: 0x0001ECD6
		// (set) Token: 0x06002150 RID: 8528 RVA: 0x00020AE2 File Offset: 0x0001ECE2
		public bool IsChangeCutTypeCommandEnabled
		{
			get
			{
				return this.#p;
			}
			set
			{
				if (this.#p != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107364339));
					this.#p = value;
					base.RaisePropertyChanged(#Phc.#3hc(107364339));
				}
			}
		}

		// Token: 0x17000BA0 RID: 2976
		// (get) Token: 0x06002151 RID: 8529 RVA: 0x00020B20 File Offset: 0x0001ED20
		// (set) Token: 0x06002152 RID: 8530 RVA: 0x00020B2C File Offset: 0x0001ED2C
		public bool IsChangeDiagram2DTypeCommandEnabled
		{
			get
			{
				return this.#q;
			}
			set
			{
				if (this.#q != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107364266));
					this.#q = value;
					base.RaisePropertyChanged(#Phc.#3hc(107364266));
				}
			}
		}

		// Token: 0x17000BA1 RID: 2977
		// (get) Token: 0x06002153 RID: 8531 RVA: 0x00020B6A File Offset: 0x0001ED6A
		// (set) Token: 0x06002154 RID: 8532 RVA: 0x00020B76 File Offset: 0x0001ED76
		public bool IsCutCommandEnabled
		{
			get
			{
				return this.#r;
			}
			set
			{
				if (this.#r != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107364249));
					this.#r = value;
					base.RaisePropertyChanged(#Phc.#3hc(107364249));
				}
			}
		}

		// Token: 0x17000BA2 RID: 2978
		// (get) Token: 0x06002155 RID: 8533 RVA: 0x00020BB4 File Offset: 0x0001EDB4
		// (set) Token: 0x06002156 RID: 8534 RVA: 0x00020BC0 File Offset: 0x0001EDC0
		public bool IsChangePresenterTypeCommandEnabled
		{
			get
			{
				return this.#s;
			}
			set
			{
				if (this.#s != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107364220));
					this.#s = value;
					base.RaisePropertyChanged(#Phc.#3hc(107364220));
				}
			}
		}

		// Token: 0x17000BA3 RID: 2979
		// (get) Token: 0x06002157 RID: 8535 RVA: 0x00020BFE File Offset: 0x0001EDFE
		// (set) Token: 0x06002158 RID: 8536 RVA: 0x00020C0A File Offset: 0x0001EE0A
		public bool IsChangeViewControlsVisibilityCommandEnabled
		{
			get
			{
				return this.#t;
			}
			set
			{
				if (this.#t != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107364139));
					this.#t = value;
					base.RaisePropertyChanged(#Phc.#3hc(107364139));
				}
			}
		}

		// Token: 0x17000BA4 RID: 2980
		// (get) Token: 0x06002159 RID: 8537 RVA: 0x00020C48 File Offset: 0x0001EE48
		// (set) Token: 0x0600215A RID: 8538 RVA: 0x00020C54 File Offset: 0x0001EE54
		public bool IsShowPlaneCommandEnabled
		{
			get
			{
				return this.#u;
			}
			set
			{
				if (this.#u != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107363566));
					this.#u = value;
					base.RaisePropertyChanged(#Phc.#3hc(107363566));
				}
			}
		}

		// Token: 0x17000BA5 RID: 2981
		// (get) Token: 0x0600215B RID: 8539 RVA: 0x00020C92 File Offset: 0x0001EE92
		// (set) Token: 0x0600215C RID: 8540 RVA: 0x00020C9E File Offset: 0x0001EE9E
		public bool IsActivateDiagramCommandEnabled
		{
			get
			{
				return this.#v;
			}
			set
			{
				if (this.#v != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107363529));
					this.#v = value;
					base.RaisePropertyChanged(#Phc.#3hc(107363529));
				}
			}
		}

		// Token: 0x17000BA6 RID: 2982
		// (get) Token: 0x0600215D RID: 8541 RVA: 0x00020CDC File Offset: 0x0001EEDC
		// (set) Token: 0x0600215E RID: 8542 RVA: 0x00020CE8 File Offset: 0x0001EEE8
		public double CurrentAxialLoad { get; set; }

		// Token: 0x17000BA7 RID: 2983
		// (get) Token: 0x0600215F RID: 8543 RVA: 0x00020CF9 File Offset: 0x0001EEF9
		// (set) Token: 0x06002160 RID: 8544 RVA: 0x00020D05 File Offset: 0x0001EF05
		public double CurrentAngle { get; set; }

		// Token: 0x17000BA8 RID: 2984
		// (get) Token: 0x06002161 RID: 8545 RVA: 0x00020D16 File Offset: 0x0001EF16
		// (set) Token: 0x06002162 RID: 8546 RVA: 0x00020D22 File Offset: 0x0001EF22
		public bool IsLoadingData { get; set; }

		// Token: 0x17000BA9 RID: 2985
		// (get) Token: 0x06002163 RID: 8547 RVA: 0x00020D33 File Offset: 0x0001EF33
		public List<SelectedLoadData> SelectedLoads { get; }

		// Token: 0x17000BAA RID: 2986
		// (get) Token: 0x06002164 RID: 8548 RVA: 0x00020D3F File Offset: 0x0001EF3F
		public List<Diagram2DType> OpenedDiagramTypes { get; }

		// Token: 0x06002165 RID: 8549 RVA: 0x00020D4B File Offset: 0x0001EF4B
		public void #Q9()
		{
			base.RaisePropertyChanged(null);
		}

		// Token: 0x04000D4B RID: 3403
		private bool #a;

		// Token: 0x04000D4C RID: 3404
		private bool #b;

		// Token: 0x04000D4D RID: 3405
		private bool #c;

		// Token: 0x04000D4E RID: 3406
		private bool #d;

		// Token: 0x04000D4F RID: 3407
		private bool #e;

		// Token: 0x04000D50 RID: 3408
		private bool #f;

		// Token: 0x04000D51 RID: 3409
		private bool #g;

		// Token: 0x04000D52 RID: 3410
		private bool #h;

		// Token: 0x04000D53 RID: 3411
		private bool #i;

		// Token: 0x04000D54 RID: 3412
		private bool #j;

		// Token: 0x04000D55 RID: 3413
		private bool #k;

		// Token: 0x04000D56 RID: 3414
		private bool #l;

		// Token: 0x04000D57 RID: 3415
		private bool #m;

		// Token: 0x04000D58 RID: 3416
		private bool #n;

		// Token: 0x04000D59 RID: 3417
		private bool #o;

		// Token: 0x04000D5A RID: 3418
		private bool #p;

		// Token: 0x04000D5B RID: 3419
		private bool #q;

		// Token: 0x04000D5C RID: 3420
		private bool #r;

		// Token: 0x04000D5D RID: 3421
		private bool #s;

		// Token: 0x04000D5E RID: 3422
		private bool #t;

		// Token: 0x04000D5F RID: 3423
		private bool #u;

		// Token: 0x04000D60 RID: 3424
		private bool #v;

		// Token: 0x04000D61 RID: 3425
		private bool #w;

		// Token: 0x04000D62 RID: 3426
		private bool #x;

		// Token: 0x04000D63 RID: 3427
		private bool #y;

		// Token: 0x04000D64 RID: 3428
		private bool #z;

		// Token: 0x04000D65 RID: 3429
		private bool #A;

		// Token: 0x04000D66 RID: 3430
		private bool #B;

		// Token: 0x04000D67 RID: 3431
		[CompilerGenerated]
		private double #C;

		// Token: 0x04000D68 RID: 3432
		[CompilerGenerated]
		private double #D;

		// Token: 0x04000D69 RID: 3433
		[CompilerGenerated]
		private bool #E;

		// Token: 0x04000D6A RID: 3434
		[CompilerGenerated]
		private readonly List<SelectedLoadData> #F = new List<SelectedLoadData>();

		// Token: 0x04000D6B RID: 3435
		[CompilerGenerated]
		private readonly List<Diagram2DType> #G = new List<Diagram2DType>();
	}
}
