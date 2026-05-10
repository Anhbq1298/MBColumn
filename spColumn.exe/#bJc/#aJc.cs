using System;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.GUI.Framework.PreciseInput;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Units.Formatters;

namespace #bJc
{
	// Token: 0x02000B96 RID: 2966
	internal static class #aJc
	{
		// Token: 0x0600615A RID: 24922 RVA: 0x0017C8E8 File Offset: 0x0017AAE8
		public static PreciseInputParameters #7Ic(#GJc #8Ic)
		{
			Point? #f;
			IUnitValueFormatter #f2;
			if (!false)
			{
				string #R0d = #Phc.#3hc(107415244);
				Component #x6c = Component.GUIFramework;
				string #Qic = #Phc.#3hc(107415227);
				if (6 != 0)
				{
					#X0d.#V0d(#8Ic, #R0d, #x6c, #Qic);
				}
				Point3D? point3D = #8Ic.VisualCoordinate;
				Point3D? point3D2;
				if (!false)
				{
					point3D2 = point3D;
				}
				Point value;
				if (point3D2 == null)
				{
					value = default(Point);
				}
				else
				{
					Point3D? point3D3 = #8Ic.VisualCoordinate;
					if (!false)
					{
						point3D2 = point3D3;
					}
					value = PointsConverter.#vsc(point3D2.Value);
				}
				if (5 != 0)
				{
					#f = new Point?(value);
				}
				IUnitValueFormatter unitValueFormatter = (#8Ic.ProjectContext != null) ? #8Ic.ProjectContext.GeometryDimensionUnitValueFormatter : null;
				if (7 != 0)
				{
					#f2 = unitValueFormatter;
				}
			}
			string text = (#8Ic.ProjectContext != null) ? #8Ic.ProjectContext.GeometryDimensionUnitSymbol : null;
			string #f3;
			if (!false)
			{
				#f3 = text;
			}
			string #f4 = (#8Ic.ProjectContext != null) ? #8Ic.ProjectContext.AngleUnitSymbol : null;
			return new PreciseInputParameters
			{
				OwnerControl = #8Ic.OwnerControl,
				MinX = new double?(#8Ic.WorkspaceSize.MinX),
				MinY = new double?(#8Ic.WorkspaceSize.MinY),
				MaxX = new double?(#8Ic.WorkspaceSize.MaxX),
				MaxY = new double?(#8Ic.WorkspaceSize.MaxY),
				ValidationProvider = #8Ic.CoordinateValidator,
				Coordinate = #f,
				EnableXCoordinate = #8Ic.EnableXCoordinate,
				EnableYCoordinate = #8Ic.EnableYCoordinate,
				ResetCurrentValues = #8Ic.ResetCurrentValues,
				Message = #8Ic.Message,
				IsGlobalEnabled = #8Ic.IsGlobalSystemEnabled,
				IsLocalEnabled = #8Ic.IsLocalSystemEnabled,
				IsPolarEnabled = #8Ic.IsPolarSystemEnabled,
				CloseAfterInsert = #8Ic.CloseAfterInsert,
				IsInsertButtonEnabled = #8Ic.IsInsertButtonEnabled,
				IsInitialCoordinate = #8Ic.IsInitialCoordinate,
				RelativeCoordinate = #8Ic.RelativeCoordinate,
				ConstantAngle = #8Ic.Angle,
				MoveMode = #8Ic.MoveMode,
				LengthUnitValueFormatter = #f2,
				LengthUnitSymbol = #f3,
				AngleUnitSymbol = #f4,
				EnabledPreciseInputSwitches = #8Ic.EnabledPreciseInputSwitches
			};
		}

		// Token: 0x0600615B RID: 24923 RVA: 0x0017CB1C File Offset: 0x0017AD1C
		public static Point3D? #9Ic(PreciseInputChangedEventArgs #gIc)
		{
			Point3D? result;
			if (true)
			{
				if (#gIc != null)
				{
					return new Point3D?(PointsConverter.#vsc(#gIc.Point));
				}
				result = null;
			}
			return result;
		}
	}
}
