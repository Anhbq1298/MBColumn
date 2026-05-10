using System;
using System.Diagnostics.CodeAnalysis;
using #7hc;
using #Fmc;
using #T0c;
using #UYd;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.Utils;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace #LQc
{
	// Token: 0x02000C48 RID: 3144
	internal sealed class #nSc : SnapPointsMarker
	{
		// Token: 0x060065BF RID: 26047 RVA: 0x0018F744 File Offset: 0x0018D944
		[SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0", Justification = "Not possible for a parameter used in a initialization list.")]
		public #nSc(#U0c #oSc, IDrawingResultsFactory #Tmb, #GSc #pSc) : base(#oSc.ModelVisualizationControl, #Tmb)
		{
			#X0d.#V0d(#pSc, #Phc.#3hc(107442106), Component.GUI, #Phc.#3hc(107442077));
			#X0d.#V0d(#oSc, #Phc.#3hc(107441992), Component.GUI, #Phc.#3hc(107442003));
			this.#a = #pSc;
			base.SnapPointZOffset = 0.035;
		}

		// Token: 0x060065C0 RID: 26048 RVA: 0x00051FA9 File Offset: 0x000501A9
		public override void Mark(Point3D? point)
		{
			Position position = this.#a.SnappedMousePosition;
			if (4 != 0)
			{
				position.Update(point);
			}
			if (4 != 0)
			{
				base.Mark(point);
			}
		}

		// Token: 0x060065C1 RID: 26049 RVA: 0x0018F7AC File Offset: 0x0018D9AC
		public override void Mark(#Atc snapToPointResult)
		{
			Point3D? point3D;
			if (snapToPointResult == null)
			{
				point3D = null;
			}
			else
			{
				if (false)
				{
					goto IL_56;
				}
				point3D = new Point3D?(snapToPointResult.Point);
			}
			Point3D? point3D2;
			if (6 != 0)
			{
				point3D2 = point3D;
			}
			IL_20:
			Position position = this.#a.SnappedMousePosition;
			Point3D? point3D3 = point3D2;
			if (true)
			{
				position.Update(point3D3);
			}
			if (false)
			{
				goto IL_56;
			}
			bool flag;
			if (snapToPointResult == null || !snapToPointResult.SnappingPerformed)
			{
				flag = false;
				goto IL_5A;
			}
			IL_42:
			if (snapToPointResult.SnapToPointOrigin != #huc.#f)
			{
				flag = (snapToPointResult.SnapToPointOrigin == #huc.#a);
				goto IL_5A;
			}
			IL_56:
			flag = true;
			IL_5A:
			bool flag2;
			if (4 != 0)
			{
				flag2 = flag;
			}
			if (flag2 && snapToPointResult != null)
			{
				#GSc #GSc = this.#a;
				string #f = snapToPointResult.SnapPointOriginInfo;
				if (!false)
				{
					#GSc.SnappedObjectInfo = #f;
				}
			}
			if (2 == 0)
			{
				goto IL_42;
			}
			#GSc #GSc2 = this.#a;
			bool #f2 = flag2;
			if (!false)
			{
				#GSc2.ShowSnappedObjectInfo = #f2;
			}
			if (3 != 0)
			{
				base.Mark(snapToPointResult);
			}
			if (8 != 0)
			{
				return;
			}
			goto IL_20;
		}

		// Token: 0x060065C2 RID: 26050 RVA: 0x0018F874 File Offset: 0x0018DA74
		public override void Mark(#fuc snapToEdgeResult)
		{
			Point? point;
			if (!false)
			{
				if (-1 == 0)
				{
					goto IL_11;
				}
				if (snapToEdgeResult != null)
				{
					point = new Point?(snapToEdgeResult.Point);
					goto IL_1F;
				}
			}
			IL_09:
			Point? point2 = null;
			IL_11:
			point = point2;
			IL_1F:
			Point? point3;
			if (!false)
			{
				point3 = point;
			}
			if (!false)
			{
				Position position = this.#a.SnappedMousePosition;
				Point? point4 = point3;
				if (!false)
				{
					position.Update(point4);
				}
				bool flag;
				if (snapToEdgeResult != null)
				{
					flag = (snapToEdgeResult.SnapToEdgeOrigin == #iuc.#b);
					goto IL_46;
				}
				IL_45:
				flag = false;
				IL_46:
				if (flag)
				{
					if (false)
					{
						goto IL_45;
					}
					if (snapToEdgeResult != null)
					{
						#GSc #GSc = this.#a;
						string #f = snapToEdgeResult.SnapToEdgeOriginInfo;
						if (3 != 0)
						{
							#GSc.SnappedObjectInfo = #f;
						}
					}
				}
				if (!false)
				{
					base.Mark(snapToEdgeResult);
				}
				return;
			}
			goto IL_09;
		}

		// Token: 0x040029C7 RID: 10695
		private readonly #GSc #a;
	}
}
