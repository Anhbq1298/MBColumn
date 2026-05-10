using System;
using System.Collections.Generic;
using System.IO;
using #coe;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.CoreAssets.Units;

namespace #wje
{
	// Token: 0x020010B1 RID: 4273
	internal sealed class #yje
	{
		// Token: 0x060091D8 RID: 37336 RVA: 0x001ED874 File Offset: 0x001EBA74
		public Stream #y0d(#boe #2ie)
		{
			MemoryStream memoryStream = new MemoryStream();
			BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			binaryWriter.Write((short)#2ie.Unit);
			binaryWriter.Write((short)#2ie.Bars.Count);
			foreach (StandardBar standardBar in #2ie.Bars)
			{
				binaryWriter.Write((short)standardBar.Size);
				binaryWriter.Write(standardBar.Diameter);
				binaryWriter.Write(standardBar.Area);
				binaryWriter.Write(standardBar.Weight);
			}
			memoryStream.Position = 0L;
			return memoryStream;
		}

		// Token: 0x060091D9 RID: 37337 RVA: 0x001ED928 File Offset: 0x001EBB28
		public #boe #xje(Stream #gp)
		{
			#boe result;
			try
			{
				#gp.Position = 0L;
				BinaryReader binaryReader = new BinaryReader(#gp);
				UnitSystem #f;
				List<StandardBar> list;
				try
				{
					#f = (UnitSystem)binaryReader.ReadInt16();
					short num = binaryReader.ReadInt16();
					list = new List<StandardBar>();
					for (int i = 0; i < (int)num; i++)
					{
						int size = (int)binaryReader.ReadInt16();
						float diameter = binaryReader.ReadSingle();
						float area = binaryReader.ReadSingle();
						float weight = binaryReader.ReadSingle();
						StandardBar item = new StandardBar(size, diameter, area, weight);
						list.Add(item);
					}
				}
				catch (EndOfStreamException)
				{
					throw new #ooe(Strings.StringInvalidFile.#z2d());
				}
				if (#gp.Position < #gp.Length)
				{
					throw new #ooe(Strings.StringInvalidFile.#z2d());
				}
				result = new #boe
				{
					Unit = #f,
					Bars = list
				};
			}
			catch (Exception)
			{
				throw;
			}
			return result;
		}
	}
}
