using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using #6re;
using #7hc;
using #eU;
using #RJb;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Graphics;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.Products.Column.Editor.Core;
using StructurePoint.Products.Column.Model;
using StructurePoint.Products.Column.Services.API;

namespace #hR
{
	// Token: 0x020002E4 RID: 740
	internal abstract class #ER
	{
		// Token: 0x06001982 RID: 6530 RVA: 0x000B86A4 File Offset: 0x000B68A4
		protected #ER(#oW #Yc, #cLb #FR)
		{
			if (#Yc == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107383985));
			}
			this.#g = #Yc;
			if (#FR == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107400784));
			}
			this.#h = #FR;
		}

		// Token: 0x1700096F RID: 2415
		// (get) Token: 0x06001983 RID: 6531 RVA: 0x0001975C File Offset: 0x0001795C
		protected #oW ProjectContext { get; }

		// Token: 0x17000970 RID: 2416
		// (get) Token: 0x06001984 RID: 6532 RVA: 0x00019768 File Offset: 0x00017968
		protected #cLb EditorContext { get; }

		// Token: 0x17000971 RID: 2417
		// (get) Token: 0x06001985 RID: 6533 RVA: 0x00019774 File Offset: 0x00017974
		protected ColumnEditor Editor
		{
			get
			{
				return (ColumnEditor)this.EditorContext.Editor;
			}
		}

		// Token: 0x17000972 RID: 2418
		// (get) Token: 0x06001986 RID: 6534 RVA: 0x00019792 File Offset: 0x00017992
		protected ColumnModel Model
		{
			get
			{
				return this.ProjectContext.Model;
			}
		}

		// Token: 0x17000973 RID: 2419
		// (get) Token: 0x06001987 RID: 6535 RVA: 0x000197AB File Offset: 0x000179AB
		protected #8Jb Options
		{
			get
			{
				return this.EditorContext.RenderOptions;
			}
		}

		// Token: 0x17000974 RID: 2420
		// (get) Token: 0x06001988 RID: 6536 RVA: 0x000197C4 File Offset: 0x000179C4
		protected #aMb ViewportOptions
		{
			get
			{
				return this.EditorContext.ViewportOptions;
			}
		}

		// Token: 0x17000975 RID: 2421
		// (get) Token: 0x06001989 RID: 6537 RVA: 0x000197DD File Offset: 0x000179DD
		protected ISettingsManager Settings
		{
			get
			{
				return this.EditorContext.Settings;
			}
		}

		// Token: 0x17000976 RID: 2422
		// (get) Token: 0x0600198A RID: 6538 RVA: 0x000197F6 File Offset: 0x000179F6
		protected #yse ReporterSettings
		{
			get
			{
				return this.EditorContext.ReporterSettings;
			}
		}

		// Token: 0x17000977 RID: 2423
		// (get) Token: 0x0600198B RID: 6539 RVA: 0x0001980F File Offset: 0x00017A0F
		// (set) Token: 0x0600198C RID: 6540 RVA: 0x0001981B File Offset: 0x00017A1B
		private protected bool IsOffline { protected get; private set; }

		// Token: 0x0600198D RID: 6541 RVA: 0x0001982C File Offset: 0x00017A2C
		protected void #8Uh()
		{
			this.IsOffline = true;
			this.Editor.Blocks.TakeOffline();
		}

		// Token: 0x0600198E RID: 6542 RVA: 0x00019851 File Offset: 0x00017A51
		protected void #9Uh()
		{
			this.IsOffline = false;
			this.Editor.Blocks.BringOnline();
		}

		// Token: 0x0600198F RID: 6543 RVA: 0x000B86F8 File Offset: 0x000B68F8
		public void #pR<#sR>(ISet<#sR> #qR, string #rR) where #sR : Entity
		{
			if (#qR != null && #qR.Any<#sR>())
			{
				HashSet<Entity> hashSet = #qR.OfType<Entity>().ToHashSet<Entity>();
				foreach (Entity item in this.Editor.Entities)
				{
					hashSet.Remove(item);
				}
				this.Editor.Entities.AddRange<Entity>(hashSet, #rR);
			}
		}

		// Token: 0x06001990 RID: 6544 RVA: 0x000B8780 File Offset: 0x000B6980
		public void #tR<#sR>(IList<#sR> #qR, string #rR) where #sR : Entity
		{
			this.Editor.Entities.#71d(#qR);
			if (#qR.Any<#sR>() && this.#xR(#rR))
			{
				this.Editor.Entities.AddRange<#sR>(#qR, #rR);
			}
		}

		// Token: 0x06001991 RID: 6545 RVA: 0x000B86F8 File Offset: 0x000B68F8
		public void #pR<#sR>(IList<#sR> #qR, string #rR) where #sR : Entity
		{
			if (#qR != null && #qR.Any<#sR>())
			{
				HashSet<Entity> hashSet = #qR.OfType<Entity>().ToHashSet<Entity>();
				foreach (Entity item in this.Editor.Entities)
				{
					hashSet.Remove(item);
				}
				this.Editor.Entities.AddRange<Entity>(hashSet, #rR);
			}
		}

		// Token: 0x06001992 RID: 6546 RVA: 0x000B87D0 File Offset: 0x000B69D0
		protected bool #uR<#Fu>(List<#Fu> #vR, IEnumerable<#Fu> #wR)
		{
			IList<!!0> list;
			if ((list = (#wR as IList<!!0>)) == null)
			{
				list = ((#wR != null) ? #wR.ToList<#Fu>() : null);
			}
			IList<#Fu> list2 = list;
			bool flag = #vR.Any<#Fu>();
			#vR.Clear();
			if (list2 != null)
			{
				#vR.AddRange(list2);
			}
			return flag || #vR.Any<#Fu>();
		}

		// Token: 0x06001993 RID: 6547 RVA: 0x00019876 File Offset: 0x00017A76
		public bool #xR(string #yR)
		{
			return this.Editor.Layers.Contains(#yR);
		}

		// Token: 0x06001994 RID: 6548 RVA: 0x000B8824 File Offset: 0x000B6A24
		protected Layer #zR(string #yR)
		{
			if (this.Editor.Layers.Contains(#yR))
			{
				this.Editor.Layers.Remove(#yR);
			}
			this.Editor.Layers.Add(#yR);
			return this.Editor.Layers[#yR];
		}

		// Token: 0x06001995 RID: 6549 RVA: 0x00019895 File Offset: 0x00017A95
		protected internal static Color #AR(Color #BR)
		{
			return Color.FromArgb(255, (int)#BR.R, (int)#BR.G, (int)#BR.B);
		}

		// Token: 0x06001996 RID: 6550 RVA: 0x000B8884 File Offset: 0x000B6A84
		protected Material #CR(string #wy, Color #BR)
		{
			if (!this.Editor.Materials.Contains(#wy))
			{
				Material material = new Material(#wy, #BR);
				this.Editor.Materials.AddOrReplace(material);
				return material;
			}
			Material material2 = this.Editor.Materials[#wy];
			if (material2.Diffuse != #BR)
			{
				material2.Diffuse = #BR;
			}
			return material2;
		}

		// Token: 0x06001997 RID: 6551 RVA: 0x000B88F4 File Offset: 0x000B6AF4
		protected string #DR(Color #BR)
		{
			string text = string.Format(#Phc.#3hc(107400763), new object[]
			{
				#BR.A,
				#BR.R,
				#BR.G,
				#BR.B
			});
			Material material;
			if (!this.#f.TryGetValue(text, out material) && !this.Editor.Materials.TryGetValue(text, out material))
			{
				Material material2 = new Material(text, #BR, #BR, #BR, 1f);
				this.Editor.Materials.AddOrReplace(material2);
				this.#f[text] = material2;
			}
			return text;
		}

		// Token: 0x040009BF RID: 2495
		public static readonly string #a = #Phc.#3hc(107400722);

		// Token: 0x040009C0 RID: 2496
		public static readonly string #b = #Phc.#3hc(107401209);

		// Token: 0x040009C1 RID: 2497
		public static readonly string #c = #Phc.#3hc(107401156);

		// Token: 0x040009C2 RID: 2498
		public static readonly string #d = #Phc.#3hc(107401171);

		// Token: 0x040009C3 RID: 2499
		public static readonly string #e = #Phc.#3hc(107401122);

		// Token: 0x040009C4 RID: 2500
		private readonly Dictionary<string, Material> #f = new Dictionary<string, Material>();

		// Token: 0x040009C5 RID: 2501
		[CompilerGenerated]
		private readonly #oW #g;

		// Token: 0x040009C6 RID: 2502
		[CompilerGenerated]
		private readonly #cLb #h;

		// Token: 0x040009C7 RID: 2503
		[CompilerGenerated]
		private bool #i;
	}
}
