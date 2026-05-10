using System;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using #7hc;
using #cYd;
using #J5d;
using #UYd;
using #x5d;
using Newtonsoft.Json;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;

namespace #coe
{
	// Token: 0x020010DA RID: 4314
	internal abstract class #0oe : #Goe
	{
		// Token: 0x17002A88 RID: 10888
		// (get) Token: 0x060092AC RID: 37548
		public abstract Version SupportedVersion { get; }

		// Token: 0x060092AD RID: 37549 RVA: 0x001F23CC File Offset: 0x001F05CC
		public static void #y0d<#Fu>(#Fu #Gfb, Stream #B0d) where #Fu : class
		{
			try
			{
				#F0d.#y0d<#Fu>(#Gfb, #B0d);
			}
			catch (Exception #Uic)
			{
				throw new #y5d(Strings.StringCouldNotWriteTheXMLData.#z2d(), #Phc.#3hc(107289544), Component.AppManager, #IYd.#b, #JYd.#f, #Uic);
			}
		}

		// Token: 0x060092AE RID: 37550 RVA: 0x001F2418 File Offset: 0x001F0618
		public static void #Yoe<#Fu>(#Fu #Gfb, Stream #B0d)
		{
			try
			{
				JsonSerializer jsonSerializer = JsonSerializer.Create(new JsonSerializerSettings());
				using (StreamWriter streamWriter = new StreamWriter(#B0d, Encoding.UTF8, 4096, true))
				{
					jsonSerializer.Serialize(streamWriter, #Gfb);
				}
			}
			catch (Exception #Uic)
			{
				throw new #y5d(Strings.StringCouldNotWriteTheXMLData.#z2d(), #Phc.#3hc(107289523), Component.AppManager, #IYd.#b, #JYd.#f, #Uic);
			}
		}

		// Token: 0x060092AF RID: 37551 RVA: 0x001F24A0 File Offset: 0x001F06A0
		public static #Fu #Zoe<#Fu>(Stream #D0d) where #Fu : class
		{
			#Fu result;
			try
			{
				JsonSerializer jsonSerializer = JsonSerializer.Create(new JsonSerializerSettings());
				using (JsonTextReader jsonTextReader = new JsonTextReader(new StreamReader(#D0d, Encoding.UTF8, false, 4096, true)))
				{
					result = jsonSerializer.Deserialize<#Fu>(jsonTextReader);
				}
			}
			catch (SerializationException #Uic)
			{
				throw new #y5d(Strings.StringCouldNotReadTheXMLData.#z2d(), #Phc.#3hc(107289470), Component.AppManager, #IYd.#b, #JYd.#g, #Uic);
			}
			return result;
		}

		// Token: 0x060092B0 RID: 37552 RVA: 0x001F2528 File Offset: 0x001F0728
		public static #Fu #C0d<#Fu>(Stream #D0d) where #Fu : class
		{
			#Fu result;
			try
			{
				result = #F0d.#C0d<#Fu>(#D0d);
			}
			catch (SerializationException #Uic)
			{
				throw new #y5d(Strings.StringCouldNotReadTheXMLData.#z2d(), #Phc.#3hc(107289385), Component.AppManager, #IYd.#b, #JYd.#g, #Uic);
			}
			return result;
		}

		// Token: 0x060092B1 RID: 37553
		public abstract void #npb(#S5d #Y5d, ColumnStorageModel #Od);

		// Token: 0x060092B2 RID: 37554
		public abstract ColumnStorageModel #Cjc(#S5d #Y5d);

		// Token: 0x04003E64 RID: 15972
		protected const string #a = "/";
	}
}
