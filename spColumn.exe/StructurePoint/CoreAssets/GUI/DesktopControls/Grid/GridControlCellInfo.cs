using System;
using System.Collections;
using System.Globalization;
using System.Reflection;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Infrastructure.Helpers;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Grid
{
	// Token: 0x020009CA RID: 2506
	public sealed class GridControlCellInfo
	{
		// Token: 0x0600518C RID: 20876 RVA: 0x00043C9A File Offset: 0x00041E9A
		internal GridControlCellInfo(GridViewCellInfo gridGridViewCellInfo)
		{
			#X0d.#V0d(gridGridViewCellInfo, #Phc.#3hc(107465182), Component.DesktopControls, #Phc.#3hc(107465125));
			this.GridViewCellInfo = gridGridViewCellInfo;
		}

		// Token: 0x17001763 RID: 5987
		// (get) Token: 0x0600518D RID: 20877 RVA: 0x00043CC4 File Offset: 0x00041EC4
		// (set) Token: 0x0600518E RID: 20878 RVA: 0x00043CD0 File Offset: 0x00041ED0
		public GridViewCellInfo GridViewCellInfo { get; private set; }

		// Token: 0x17001764 RID: 5988
		// (get) Token: 0x0600518F RID: 20879 RVA: 0x00043CE1 File Offset: 0x00041EE1
		public IGridControlColumn Column
		{
			get
			{
				return this.GridViewCellInfo.Column as IGridControlColumn;
			}
		}

		// Token: 0x17001765 RID: 5989
		// (get) Token: 0x06005190 RID: 20880 RVA: 0x00043CFF File Offset: 0x00041EFF
		public object Item
		{
			get
			{
				return this.GridViewCellInfo.Item;
			}
		}

		// Token: 0x06005191 RID: 20881 RVA: 0x0015FEF8 File Offset: 0x0015E0F8
		public string ExtractCellText()
		{
			object obj = this.ExtractCellValue();
			if (obj != null)
			{
				return obj.ToString();
			}
			return string.Empty;
		}

		// Token: 0x06005192 RID: 20882 RVA: 0x0015FF28 File Offset: 0x0015E128
		public object ExtractCellValue()
		{
			string path = this.Column.DataMemberBinding.Path.Path;
			if (GridControlCellInfo.MyIsBindingToCollection(path))
			{
				string name = GridControlCellInfo.MyGetPropertyNameOfCollectionBindingPath(path);
				int index = GridControlCellInfo.MyGetIndexOfCollectionBindingPath(path);
				string name2 = GridControlCellInfo.MyGetNestedPropertyNameOfCollectionBindingPath(path);
				PropertyInfo property = this.Item.GetType().GetProperty(name);
				IList list = property.GetValue(this.Item, null) as IList;
				return property.PropertyType.GetGenericArguments()[0].GetProperty(name2).GetValue(list[index], null);
			}
			return ReflectionHelper.#E(this.Item, path);
		}

		// Token: 0x06005193 RID: 20883 RVA: 0x0015FFD8 File Offset: 0x0015E1D8
		public PropertyInfo ExtractCellPropertyInfo()
		{
			string path = this.Column.DataMemberBinding.Path.Path;
			if (GridControlCellInfo.MyIsBindingToCollection(path))
			{
				string name = GridControlCellInfo.MyGetPropertyNameOfCollectionBindingPath(path);
				string name2 = GridControlCellInfo.MyGetNestedPropertyNameOfCollectionBindingPath(path);
				return this.Item.GetType().GetProperty(name).PropertyType.GetGenericArguments()[0].GetProperty(name2);
			}
			return ReflectionHelper.#n0d(this.Item, path);
		}

		// Token: 0x06005194 RID: 20884 RVA: 0x00160050 File Offset: 0x0015E250
		public void SetCellValue(object newValue)
		{
			string path = this.Column.DataMemberBinding.Path.Path;
			if (GridControlCellInfo.MyIsBindingToCollection(path))
			{
				string name = GridControlCellInfo.MyGetPropertyNameOfCollectionBindingPath(path);
				int index = GridControlCellInfo.MyGetIndexOfCollectionBindingPath(path);
				string name2 = GridControlCellInfo.MyGetNestedPropertyNameOfCollectionBindingPath(path);
				PropertyInfo property = this.Item.GetType().GetProperty(name);
				IList list = property.GetValue(this.Item, null) as IList;
				property.PropertyType.GetGenericArguments()[0].GetProperty(name2).SetValue(list[index], newValue);
				return;
			}
			ReflectionHelper.#H(this.Item, path, newValue);
		}

		// Token: 0x06005195 RID: 20885 RVA: 0x00043D18 File Offset: 0x00041F18
		private static bool MyIsBindingToCollection(string bindingPath)
		{
			return bindingPath.Contains(#Phc.#3hc(107465104));
		}

		// Token: 0x06005196 RID: 20886 RVA: 0x00043D3B File Offset: 0x00041F3B
		private static string MyGetPropertyNameOfCollectionBindingPath(string bindingPath)
		{
			return bindingPath.Split(new char[]
			{
				'['
			})[0];
		}

		// Token: 0x06005197 RID: 20887 RVA: 0x00043D58 File Offset: 0x00041F58
		private static int MyGetIndexOfCollectionBindingPath(string bindingPath)
		{
			return int.Parse(bindingPath.Split(new char[]
			{
				'[',
				']'
			})[1], NumberStyles.Any, CultureInfo.InvariantCulture);
		}

		// Token: 0x06005198 RID: 20888 RVA: 0x00043D8D File Offset: 0x00041F8D
		private static string MyGetNestedPropertyNameOfCollectionBindingPath(string bindingPath)
		{
			string[] array = bindingPath.Split(new char[]
			{
				'.'
			});
			return array[array.Length - 1];
		}
	}
}
