using System;
using System.Runtime.CompilerServices;
using #7Tc;
using #NWc;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.GUI.Framework.PreciseInput;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace #bJc
{
	// Token: 0x02000B97 RID: 2967
	internal sealed class #GJc
	{
		// Token: 0x0600615C RID: 24924 RVA: 0x0017CB4C File Offset: 0x0017AD4C
		public #GJc()
		{
			this.EnableXCoordinate = true;
			this.EnableYCoordinate = true;
			this.CloseAfterInsert = false;
			this.IsInsertButtonEnabled = true;
			this.IsLocalSystemEnabled = true;
			this.IsGlobalSystemEnabled = true;
			this.IsPolarSystemEnabled = true;
			this.IsInitialCoordinate = false;
			this.MoveMode = MoveMode.FreeDefault;
			this.EnabledPreciseInputSwitches = EnabledPreciseInputSwitches.All;
		}

		// Token: 0x17001BBC RID: 7100
		// (get) Token: 0x0600615D RID: 24925 RVA: 0x0004FD3C File Offset: 0x0004DF3C
		// (set) Token: 0x0600615E RID: 24926 RVA: 0x0004FD44 File Offset: 0x0004DF44
		public BoundingBoxData WorkspaceSize { get; set; }

		// Token: 0x17001BBD RID: 7101
		// (get) Token: 0x0600615F RID: 24927 RVA: 0x0004FD4D File Offset: 0x0004DF4D
		// (set) Token: 0x06006160 RID: 24928 RVA: 0x0004FD55 File Offset: 0x0004DF55
		public object OwnerControl { get; set; }

		// Token: 0x17001BBE RID: 7102
		// (get) Token: 0x06006161 RID: 24929 RVA: 0x0004FD5E File Offset: 0x0004DF5E
		// (set) Token: 0x06006162 RID: 24930 RVA: 0x0004FD66 File Offset: 0x0004DF66
		public #9Tc CoordinateValidator { get; set; }

		// Token: 0x17001BBF RID: 7103
		// (get) Token: 0x06006163 RID: 24931 RVA: 0x0004FD6F File Offset: 0x0004DF6F
		// (set) Token: 0x06006164 RID: 24932 RVA: 0x0004FD77 File Offset: 0x0004DF77
		public Point3D? VisualCoordinate { get; set; }

		// Token: 0x17001BC0 RID: 7104
		// (get) Token: 0x06006165 RID: 24933 RVA: 0x0004FD80 File Offset: 0x0004DF80
		// (set) Token: 0x06006166 RID: 24934 RVA: 0x0004FD88 File Offset: 0x0004DF88
		public bool EnableXCoordinate { get; set; }

		// Token: 0x17001BC1 RID: 7105
		// (get) Token: 0x06006167 RID: 24935 RVA: 0x0004FD91 File Offset: 0x0004DF91
		// (set) Token: 0x06006168 RID: 24936 RVA: 0x0004FD99 File Offset: 0x0004DF99
		public bool EnableYCoordinate { get; set; }

		// Token: 0x17001BC2 RID: 7106
		// (get) Token: 0x06006169 RID: 24937 RVA: 0x0004FDA2 File Offset: 0x0004DFA2
		// (set) Token: 0x0600616A RID: 24938 RVA: 0x0004FDAA File Offset: 0x0004DFAA
		public bool ResetCurrentValues { get; set; }

		// Token: 0x17001BC3 RID: 7107
		// (get) Token: 0x0600616B RID: 24939 RVA: 0x0004FDB3 File Offset: 0x0004DFB3
		// (set) Token: 0x0600616C RID: 24940 RVA: 0x0004FDBB File Offset: 0x0004DFBB
		public string Message { get; set; }

		// Token: 0x17001BC4 RID: 7108
		// (get) Token: 0x0600616D RID: 24941 RVA: 0x0004FDC4 File Offset: 0x0004DFC4
		// (set) Token: 0x0600616E RID: 24942 RVA: 0x0004FDCC File Offset: 0x0004DFCC
		public bool CloseAfterInsert { get; set; }

		// Token: 0x17001BC5 RID: 7109
		// (get) Token: 0x0600616F RID: 24943 RVA: 0x0004FDD5 File Offset: 0x0004DFD5
		// (set) Token: 0x06006170 RID: 24944 RVA: 0x0004FDDD File Offset: 0x0004DFDD
		public bool IsInsertButtonEnabled { get; set; }

		// Token: 0x17001BC6 RID: 7110
		// (get) Token: 0x06006171 RID: 24945 RVA: 0x0004FDE6 File Offset: 0x0004DFE6
		// (set) Token: 0x06006172 RID: 24946 RVA: 0x0004FDEE File Offset: 0x0004DFEE
		public bool IsLocalSystemEnabled { get; set; }

		// Token: 0x17001BC7 RID: 7111
		// (get) Token: 0x06006173 RID: 24947 RVA: 0x0004FDF7 File Offset: 0x0004DFF7
		// (set) Token: 0x06006174 RID: 24948 RVA: 0x0004FDFF File Offset: 0x0004DFFF
		public bool IsGlobalSystemEnabled { get; set; }

		// Token: 0x17001BC8 RID: 7112
		// (get) Token: 0x06006175 RID: 24949 RVA: 0x0004FE08 File Offset: 0x0004E008
		// (set) Token: 0x06006176 RID: 24950 RVA: 0x0004FE10 File Offset: 0x0004E010
		public bool IsPolarSystemEnabled { get; set; }

		// Token: 0x17001BC9 RID: 7113
		// (get) Token: 0x06006177 RID: 24951 RVA: 0x0004FE19 File Offset: 0x0004E019
		// (set) Token: 0x06006178 RID: 24952 RVA: 0x0004FE21 File Offset: 0x0004E021
		public bool IsInitialCoordinate { get; set; }

		// Token: 0x17001BCA RID: 7114
		// (get) Token: 0x06006179 RID: 24953 RVA: 0x0004FE2A File Offset: 0x0004E02A
		// (set) Token: 0x0600617A RID: 24954 RVA: 0x0004FE32 File Offset: 0x0004E032
		public Point? RelativeCoordinate { get; set; }

		// Token: 0x17001BCB RID: 7115
		// (get) Token: 0x0600617B RID: 24955 RVA: 0x0004FE3B File Offset: 0x0004E03B
		// (set) Token: 0x0600617C RID: 24956 RVA: 0x0004FE43 File Offset: 0x0004E043
		public double? Angle { get; set; }

		// Token: 0x17001BCC RID: 7116
		// (get) Token: 0x0600617D RID: 24957 RVA: 0x0004FE4C File Offset: 0x0004E04C
		// (set) Token: 0x0600617E RID: 24958 RVA: 0x0004FE54 File Offset: 0x0004E054
		public MoveMode MoveMode { get; set; }

		// Token: 0x17001BCD RID: 7117
		// (get) Token: 0x0600617F RID: 24959 RVA: 0x0004FE5D File Offset: 0x0004E05D
		// (set) Token: 0x06006180 RID: 24960 RVA: 0x0004FE65 File Offset: 0x0004E065
		public EnabledPreciseInputSwitches EnabledPreciseInputSwitches { get; set; }

		// Token: 0x17001BCE RID: 7118
		// (get) Token: 0x06006181 RID: 24961 RVA: 0x0004FE6E File Offset: 0x0004E06E
		// (set) Token: 0x06006182 RID: 24962 RVA: 0x0004FE76 File Offset: 0x0004E076
		public #oW ProjectContext { get; set; }

		// Token: 0x040027D8 RID: 10200
		[CompilerGenerated]
		private BoundingBoxData #a;

		// Token: 0x040027D9 RID: 10201
		[CompilerGenerated]
		private object #b;

		// Token: 0x040027DA RID: 10202
		[CompilerGenerated]
		private #9Tc #c;

		// Token: 0x040027DB RID: 10203
		[CompilerGenerated]
		private Point3D? #d;

		// Token: 0x040027DC RID: 10204
		[CompilerGenerated]
		private bool #e;

		// Token: 0x040027DD RID: 10205
		[CompilerGenerated]
		private bool #f;

		// Token: 0x040027DE RID: 10206
		[CompilerGenerated]
		private bool #g;

		// Token: 0x040027DF RID: 10207
		[CompilerGenerated]
		private string #h;

		// Token: 0x040027E0 RID: 10208
		[CompilerGenerated]
		private bool #i;

		// Token: 0x040027E1 RID: 10209
		[CompilerGenerated]
		private bool #j;

		// Token: 0x040027E2 RID: 10210
		[CompilerGenerated]
		private bool #k;

		// Token: 0x040027E3 RID: 10211
		[CompilerGenerated]
		private bool #l;

		// Token: 0x040027E4 RID: 10212
		[CompilerGenerated]
		private bool #m;

		// Token: 0x040027E5 RID: 10213
		[CompilerGenerated]
		private bool #n;

		// Token: 0x040027E6 RID: 10214
		[CompilerGenerated]
		private Point? #o;

		// Token: 0x040027E7 RID: 10215
		[CompilerGenerated]
		private double? #p;

		// Token: 0x040027E8 RID: 10216
		[CompilerGenerated]
		private MoveMode #q;

		// Token: 0x040027E9 RID: 10217
		[CompilerGenerated]
		private EnabledPreciseInputSwitches #r;

		// Token: 0x040027EA RID: 10218
		[CompilerGenerated]
		private #oW #s;
	}
}
