using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using #3wb;
using #5Z;
using #7hc;
using #cMb;
using #eU;
using #hg;
using StructurePoint.Products.Column.Core.API;

namespace #Pxb
{
	// Token: 0x020004C4 RID: 1220
	internal sealed class #Txb : #6Nb, INotifyPropertyChanged, #Oxb, #DNb
	{
		// Token: 0x06002CA4 RID: 11428 RVA: 0x0002810E File Offset: 0x0002630E
		public #Txb(#jg #ib, #UV #ms, #2wb #UP, #oW #xn, IEditorService #wj) : base(#ib, #ms)
		{
			this.#a = #UP;
			this.#b = #xn;
			this.#c = #wj;
		}

		// Token: 0x17000EFC RID: 3836
		// (get) Token: 0x06002CA5 RID: 11429 RVA: 0x00028136 File Offset: 0x00026336
		// (set) Token: 0x06002CA6 RID: 11430 RVA: 0x000EC58C File Offset: 0x000EA78C
		public bool MirrorHorizontal
		{
			get
			{
				return this.#d;
			}
			set
			{
				if (this.#d != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107356248));
					this.#d = value;
					this.#Qxb(false);
					base.RaisePropertyChanged(#Phc.#3hc(107356248));
				}
			}
		}

		// Token: 0x17000EFD RID: 3837
		// (get) Token: 0x06002CA7 RID: 11431 RVA: 0x00028142 File Offset: 0x00026342
		// (set) Token: 0x06002CA8 RID: 11432 RVA: 0x000EC5DC File Offset: 0x000EA7DC
		public bool MirrorVertical
		{
			get
			{
				return this.#e;
			}
			set
			{
				if (this.#e != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107356223));
					this.#e = value;
					this.#Qxb(false);
					base.RaisePropertyChanged(#Phc.#3hc(107356223));
				}
			}
		}

		// Token: 0x17000EFE RID: 3838
		// (get) Token: 0x06002CA9 RID: 11433 RVA: 0x0002814E File Offset: 0x0002634E
		// (set) Token: 0x06002CAA RID: 11434 RVA: 0x000EC62C File Offset: 0x000EA82C
		public bool RotateLeft
		{
			get
			{
				return this.#f;
			}
			set
			{
				if (this.#f != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107356170));
					this.#f = value;
					this.#Qxb(false);
					base.RaisePropertyChanged(#Phc.#3hc(107356170));
				}
			}
		}

		// Token: 0x17000EFF RID: 3839
		// (get) Token: 0x06002CAB RID: 11435 RVA: 0x0002815A File Offset: 0x0002635A
		// (set) Token: 0x06002CAC RID: 11436 RVA: 0x000EC67C File Offset: 0x000EA87C
		public bool RotateRight
		{
			get
			{
				return this.#g;
			}
			set
			{
				if (this.#g != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107356185));
					this.#g = value;
					this.#Qxb(false);
					base.RaisePropertyChanged(#Phc.#3hc(107356185));
				}
			}
		}

		// Token: 0x17000F00 RID: 3840
		// (get) Token: 0x06002CAD RID: 11437 RVA: 0x00028166 File Offset: 0x00026366
		// (set) Token: 0x06002CAE RID: 11438 RVA: 0x000EC6CC File Offset: 0x000EA8CC
		public bool Rotate45Deg
		{
			get
			{
				return this.#h;
			}
			set
			{
				if (this.#h != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107356648));
					this.#h = value;
					this.#Qxb(false);
					base.RaisePropertyChanged(#Phc.#3hc(107356648));
				}
			}
		}

		// Token: 0x17000F01 RID: 3841
		// (get) Token: 0x06002CAF RID: 11439 RVA: 0x00028172 File Offset: 0x00026372
		// (set) Token: 0x06002CB0 RID: 11440 RVA: 0x000EC71C File Offset: 0x000EA91C
		public bool ShowColoredZones
		{
			get
			{
				return this.#i;
			}
			set
			{
				if (this.#i != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107356663));
					this.#i = value;
					this.#Qxb(true);
					base.RaisePropertyChanged(#Phc.#3hc(107356663));
				}
			}
		}

		// Token: 0x17000F02 RID: 3842
		// (get) Token: 0x06002CB1 RID: 11441 RVA: 0x0002817E File Offset: 0x0002637E
		// (set) Token: 0x06002CB2 RID: 11442 RVA: 0x000EC76C File Offset: 0x000EA96C
		public bool ShowParameters
		{
			get
			{
				return this.#j;
			}
			set
			{
				if (this.#j != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107356638));
					this.#j = value;
					this.#Qxb(true);
					base.RaisePropertyChanged(#Phc.#3hc(107356638));
				}
			}
		}

		// Token: 0x06002CB3 RID: 11443 RVA: 0x0002818A File Offset: 0x0002638A
		public override void #5b()
		{
			this.#Rxb();
			base.#5b();
		}

		// Token: 0x06002CB4 RID: 11444 RVA: 0x000281A4 File Offset: 0x000263A4
		private void #Qxb(bool #ag = false)
		{
			this.#c.#0Pb(new Action(this.#Sxb));
			this.#a.#1wb(#ag, true);
		}

		// Token: 0x06002CB5 RID: 11445 RVA: 0x000EC7BC File Offset: 0x000EA9BC
		private void #Rxb()
		{
			#K0 #K = this.#b.Model.TemplateData.Options;
			this.#d = #K.MirrorHorizontal;
			base.RaisePropertyChanged(#Phc.#3hc(107356248));
			this.#e = #K.MirrorVertical;
			base.RaisePropertyChanged(#Phc.#3hc(107356585));
			this.#f = #K.RotateLeft;
			base.RaisePropertyChanged(#Phc.#3hc(107356170));
			this.#g = #K.RotateRight;
			base.RaisePropertyChanged(#Phc.#3hc(107356185));
			this.#h = #K.Rotate45Deg;
			base.RaisePropertyChanged(#Phc.#3hc(107356648));
			this.#i = #K.ShowColoredZones;
			base.RaisePropertyChanged(#Phc.#3hc(107356663));
		}

		// Token: 0x06002CB6 RID: 11446 RVA: 0x000EC8A8 File Offset: 0x000EAAA8
		[CompilerGenerated]
		private void #Sxb()
		{
			#K0 #K = this.#b.Model.TemplateData.Options;
			#K.RotateLeft = this.RotateLeft;
			#K.RotateRight = this.RotateRight;
			#K.MirrorHorizontal = this.MirrorHorizontal;
			#K.MirrorVertical = this.MirrorVertical;
			#K.Rotate45Deg = this.Rotate45Deg;
			#K.ShowColoredZones = this.ShowColoredZones;
			#K.ShowParameters = this.ShowParameters;
		}

		// Token: 0x040011E6 RID: 4582
		private readonly #2wb #a;

		// Token: 0x040011E7 RID: 4583
		private readonly #oW #b;

		// Token: 0x040011E8 RID: 4584
		private readonly IEditorService #c;

		// Token: 0x040011E9 RID: 4585
		private bool #d;

		// Token: 0x040011EA RID: 4586
		private bool #e;

		// Token: 0x040011EB RID: 4587
		private bool #f;

		// Token: 0x040011EC RID: 4588
		private bool #g;

		// Token: 0x040011ED RID: 4589
		private bool #h;

		// Token: 0x040011EE RID: 4590
		private bool #i = true;

		// Token: 0x040011EF RID: 4591
		private bool #j;
	}
}
