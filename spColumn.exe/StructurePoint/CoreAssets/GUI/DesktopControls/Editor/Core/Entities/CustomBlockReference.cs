using System;
using System.Runtime.Serialization;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core.Entities
{
	// Token: 0x02000B1C RID: 2844
	public sealed class CustomBlockReference : BlockReference, IVisuallyOrderedEntity
	{
		// Token: 0x06005D25 RID: 23845 RVA: 0x0004DAD9 File Offset: 0x0004BCD9
		public CustomBlockReference(BlockReference another, params int[] entitiesToHide) : base(another)
		{
			this.EntitiesToHide = (entitiesToHide ?? new int[0]);
		}

		// Token: 0x06005D26 RID: 23846 RVA: 0x0004DAF3 File Offset: 0x0004BCF3
		public CustomBlockReference(double x, double y, double z, string blockName, double rotationAngleInRadians) : base(x, y, z, blockName, rotationAngleInRadians)
		{
		}

		// Token: 0x06005D27 RID: 23847 RVA: 0x0004DB02 File Offset: 0x0004BD02
		public CustomBlockReference(double x, double y, double z, string blockName, linearUnitsType globalUnits, BlockKeyedCollection blocks, double rotationAngleInRadians) : base(x, y, z, blockName, globalUnits, blocks, rotationAngleInRadians)
		{
		}

		// Token: 0x06005D28 RID: 23848 RVA: 0x00175568 File Offset: 0x00173768
		public CustomBlockReference(double x, double y, double z, string blockName, double sx, double sy, double sz, double rotationAngleInRadians) : base(x, y, z, blockName, sx, sy, sz, rotationAngleInRadians)
		{
		}

		// Token: 0x06005D29 RID: 23849 RVA: 0x0004DB15 File Offset: 0x0004BD15
		public CustomBlockReference(Point3D insPoint, string blockName, double rotationAngleInRadians) : base(insPoint, blockName, rotationAngleInRadians)
		{
		}

		// Token: 0x06005D2A RID: 23850 RVA: 0x0004DB20 File Offset: 0x0004BD20
		public CustomBlockReference(Point3D insPoint, string blockName, double sx, double sy, double sz, double rotationAngleInRadians) : base(insPoint, blockName, sx, sy, sz, rotationAngleInRadians)
		{
		}

		// Token: 0x06005D2B RID: 23851 RVA: 0x0004DB31 File Offset: 0x0004BD31
		public CustomBlockReference(string blockName) : base(blockName)
		{
		}

		// Token: 0x06005D2C RID: 23852 RVA: 0x0004DB3A File Offset: 0x0004BD3A
		public CustomBlockReference(Transformation t, string blockName) : base(t, blockName)
		{
		}

		// Token: 0x06005D2D RID: 23853 RVA: 0x0004DB44 File Offset: 0x0004BD44
		public CustomBlockReference(Transformation t, string blockName, linearUnitsType globalUnits, BlockKeyedCollection blocks) : base(t, blockName, globalUnits, blocks)
		{
		}

		// Token: 0x06005D2E RID: 23854 RVA: 0x0004DB51 File Offset: 0x0004BD51
		protected CustomBlockReference(BlockReference another) : base(another)
		{
		}

		// Token: 0x06005D2F RID: 23855 RVA: 0x0004DB5A File Offset: 0x0004BD5A
		public CustomBlockReference(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		// Token: 0x17001A88 RID: 6792
		// (get) Token: 0x06005D30 RID: 23856 RVA: 0x0004DB64 File Offset: 0x0004BD64
		public int[] EntitiesToHide { get; }

		// Token: 0x17001A89 RID: 6793
		// (get) Token: 0x06005D31 RID: 23857 RVA: 0x0004DB6C File Offset: 0x0004BD6C
		// (set) Token: 0x06005D32 RID: 23858 RVA: 0x0004DB74 File Offset: 0x0004BD74
		public double VisualOrder { get; set; }

		// Token: 0x06005D33 RID: 23859 RVA: 0x00175588 File Offset: 0x00173788
		protected override void Draw<T>(T myParams, devDept.Eyeshot.Environment.drawCallback<T> drawCall)
		{
			if (this.EntitiesToHide != null)
			{
				foreach (int num in this.EntitiesToHide)
				{
					if (num >= 0)
					{
						myParams.GfxParams.Blocks[base.BlockName].Entities[num].Visible = false;
					}
				}
			}
			base.Draw<T>(myParams, drawCall);
			if (this.EntitiesToHide != null)
			{
				foreach (int num2 in this.EntitiesToHide)
				{
					if (num2 >= 0)
					{
						myParams.GfxParams.Blocks[base.BlockName].Entities[num2].Visible = false;
					}
				}
			}
		}
	}
}
