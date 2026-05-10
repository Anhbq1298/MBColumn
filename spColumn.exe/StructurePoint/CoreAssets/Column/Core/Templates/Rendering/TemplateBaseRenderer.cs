using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Graphics;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor;
using StructurePoint.CoreAssets.Infrastructure.Extensions;

namespace StructurePoint.CoreAssets.Column.Core.Templates.Rendering
{
	// Token: 0x02000856 RID: 2134
	public class TemplateBaseRenderer
	{
		// Token: 0x060043E7 RID: 17383 RVA: 0x00038C84 File Offset: 0x00036E84
		public TemplateBaseRenderer(EyeshotEditor editor)
		{
			this.Editor = editor;
		}

		// Token: 0x170013FF RID: 5119
		// (get) Token: 0x060043E8 RID: 17384 RVA: 0x00038C93 File Offset: 0x00036E93
		public EyeshotEditor Editor { get; }

		// Token: 0x060043E9 RID: 17385 RVA: 0x001398D8 File Offset: 0x00137AD8
		protected Material CreateOrUpdateMaterial(string name, Color color)
		{
			if (!this.Editor.Materials.Contains(name))
			{
				Material material = new Material(name, color);
				this.Editor.Materials.AddOrReplace(material);
				return material;
			}
			Material material2 = this.Editor.Materials[name];
			if (material2.Diffuse != color)
			{
				material2.Diffuse = color;
			}
			return material2;
		}

		// Token: 0x060043EA RID: 17386 RVA: 0x0013993C File Offset: 0x00137B3C
		public void AddRange<TEntity>(ISet<TEntity> entities, string layer) where TEntity : Entity
		{
			if (entities != null && entities.Any<TEntity>())
			{
				HashSet<Entity> hashSet = entities.OfType<Entity>().ToHashSet<Entity>();
				foreach (Entity item in this.Editor.Entities)
				{
					hashSet.Remove(item);
				}
				this.Editor.Entities.AddRange<Entity>(hashSet, layer);
			}
		}

		// Token: 0x060043EB RID: 17387 RVA: 0x00038C9B File Offset: 0x00036E9B
		public void ReAddRange<TEntity>(IList<TEntity> entities, string layer) where TEntity : Entity
		{
			this.Editor.Entities.#71d(entities);
			if (entities.Any<TEntity>() && this.LayerExists(layer))
			{
				this.Editor.Entities.AddRange<TEntity>(entities, layer);
			}
		}

		// Token: 0x060043EC RID: 17388 RVA: 0x0013993C File Offset: 0x00137B3C
		public void AddRange<TEntity>(IList<TEntity> entities, string layer) where TEntity : Entity
		{
			if (entities != null && entities.Any<TEntity>())
			{
				HashSet<Entity> hashSet = entities.OfType<Entity>().ToHashSet<Entity>();
				foreach (Entity item in this.Editor.Entities)
				{
					hashSet.Remove(item);
				}
				this.Editor.Entities.AddRange<Entity>(hashSet, layer);
			}
		}

		// Token: 0x060043ED RID: 17389 RVA: 0x00038CD1 File Offset: 0x00036ED1
		public bool LayerExists(string layerName)
		{
			return this.Editor.Layers.Contains(layerName);
		}

		// Token: 0x060043EE RID: 17390 RVA: 0x001399B8 File Offset: 0x00137BB8
		protected Layer RecreateLayer(string layerName)
		{
			if (this.Editor.Layers.Contains(layerName))
			{
				this.Editor.Layers.Remove(layerName);
			}
			this.Editor.Layers.Add(layerName);
			return this.Editor.Layers[layerName];
		}
	}
}
