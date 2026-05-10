using System;
using System.Collections.Generic;
using System.Linq;
using #7hc;
using #Fmc;
using #NWc;
using #UYd;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.GUI.Framework.Model.Entities;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace StructurePoint.CoreAssets.GUI.Framework.Services
{
	// Token: 0x02000C45 RID: 3141
	public sealed class DefaultSnappingPointsUpdater : #PWc
	{
		// Token: 0x060065B6 RID: 26038 RVA: 0x0018F568 File Offset: 0x0018D768
		public void #lSc(#Qrc #NDc, #WWc #mSc)
		{
			string #R0d = #Phc.#3hc(107417084);
			Component #x6c = Component.GUI;
			string #Qic = #Phc.#3hc(107441844);
			if (-1 != 0)
			{
				#X0d.#V0d(#NDc, #R0d, #x6c, #Qic);
			}
			string #R0d2 = #Phc.#3hc(107441791);
			Component #x6c2 = Component.GUI;
			string #Qic2 = #Phc.#3hc(107441778);
			if (!false)
			{
				#X0d.#V0d(#mSc, #R0d2, #x6c2, #Qic2);
			}
			bool #zrc = false;
			if (4 != 0)
			{
				#NDc.#yl(#zrc);
			}
			IEnumerable<SnappingPointData> #Brc = #mSc.#lWc();
			if (!false)
			{
				#NDc.#Arc(#Brc);
			}
			IEnumerable<SnappingSegmentData> #IP = #mSc.#mWc().Select(new Func<SnappingSegmentData, SnappingSegmentData>(DefaultSnappingPointsUpdater.<>c.<>9.#Fad));
			if (!false)
			{
				#NDc.#Crc(#IP);
			}
			IEnumerable<SnappingPointData> #Frc = #mSc.#nWc();
			if (!false)
			{
				#NDc.#Erc(#Frc);
			}
			#NDc.#Grc(#mSc.#oWc());
		}

		// Token: 0x060065B7 RID: 26039 RVA: 0x0018F638 File Offset: 0x0018D838
		public void #NIc(#Qrc #NDc, IEnumerable<GridLineDefinitionModel> #atc)
		{
			GridLineDefinitionModel[] array;
			for (;;)
			{
				if (3 != 0)
				{
					string #R0d = #Phc.#3hc(107441725);
					Component #x6c = Component.Geometry;
					string #Qic = #Phc.#3hc(107441668);
					if (5 != 0)
					{
						#X0d.#V0d(#NDc, #R0d, #x6c, #Qic);
					}
				}
				while (8 != 0)
				{
					string #R0d2 = #Phc.#3hc(107460456);
					Component #x6c2 = Component.Geometry;
					string #Qic2 = #Phc.#3hc(107442127);
					if (5 != 0)
					{
						#X0d.#V0d(#atc, #R0d2, #x6c2, #Qic2);
					}
					if ((array = (#atc as GridLineDefinitionModel[])) != null)
					{
						goto IL_56;
					}
					if (2 != 0)
					{
						goto Block_3;
					}
				}
			}
			Block_3:
			if (3 == 0)
			{
				return;
			}
			array = #atc.ToArray<GridLineDefinitionModel>();
			IL_56:
			GridLineDefinitionModel[] source;
			if (!false)
			{
				source = array;
			}
			IEnumerable<SnappingSegmentData> #IP = source.Select(new Func<GridLineDefinitionModel, SnappingSegmentData>(DefaultSnappingPointsUpdater.<>c.<>9.#Gad));
			if (!false)
			{
				#NDc.#Drc(#IP);
			}
		}
	}
}
