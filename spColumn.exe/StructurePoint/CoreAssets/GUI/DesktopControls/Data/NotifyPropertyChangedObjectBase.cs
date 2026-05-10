using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using StructurePoint.CoreAssets.Infrastructure.Helpers;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Data
{
	// Token: 0x020000A1 RID: 161
	[Serializable]
	public abstract class NotifyPropertyChangedObjectBase : INotifyPropertyChanged, INotifyPropertyChanging
	{
		// Token: 0x14000015 RID: 21
		// (add) Token: 0x06000520 RID: 1312 RVA: 0x0008A3F4 File Offset: 0x000885F4
		// (remove) Token: 0x06000521 RID: 1313 RVA: 0x0008A438 File Offset: 0x00088638
		[NonSerialized]
		public event PropertyChangedEventHandler PropertyChanged;

		// Token: 0x14000016 RID: 22
		// (add) Token: 0x06000522 RID: 1314 RVA: 0x0008A47C File Offset: 0x0008867C
		// (remove) Token: 0x06000523 RID: 1315 RVA: 0x0008A4C0 File Offset: 0x000886C0
		[NonSerialized]
		public event PropertyChangingEventHandler PropertyChanging;

		// Token: 0x06000524 RID: 1316 RVA: 0x00009E3D File Offset: 0x0000803D
		public virtual void UnsubscribeAllEvents()
		{
			this.PropertyChanged = null;
			this.PropertyChanging = null;
		}

		// Token: 0x06000525 RID: 1317 RVA: 0x00009E55 File Offset: 0x00008055
		public virtual void RefreshAllProperties()
		{
			this.RaisePropertyChanged(string.Empty);
		}

		// Token: 0x06000526 RID: 1318 RVA: 0x0008A504 File Offset: 0x00088704
		public void RefreshInterfaceProperties<T>()
		{
			foreach (string propertyName in ReflectionHelper.#r0d<T>(true))
			{
				this.RaisePropertyChanged(propertyName);
			}
		}

		// Token: 0x06000527 RID: 1319 RVA: 0x00009E6A File Offset: 0x0000806A
		protected virtual void OnPropertyChanged(string propertyName)
		{
		}

		// Token: 0x06000528 RID: 1320 RVA: 0x00009E6C File Offset: 0x0000806C
		protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
		{
			if (!false)
			{
				this.OnPropertyChanged(propertyName);
			}
			PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
			if (propertyChanged == null)
			{
				return;
			}
			propertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}

		// Token: 0x06000529 RID: 1321 RVA: 0x0008A560 File Offset: 0x00088760
		protected void RaisePropertyChanged<TValue>(Expression<Func<TValue>> expression)
		{
			string propertyName = (expression != null) ? ReflectionHelper.#M4c<TValue>(expression) : null;
			this.RaisePropertyChanged(propertyName);
		}

		// Token: 0x0600052A RID: 1322 RVA: 0x0008A590 File Offset: 0x00088790
		protected void RaisePropertyChanging<TValue>(Expression<Func<TValue>> expression)
		{
			string propertyName = (expression != null) ? ReflectionHelper.#M4c<TValue>(expression) : null;
			this.RaisePropertyChanging(propertyName);
		}

		// Token: 0x0600052B RID: 1323 RVA: 0x00009E9B File Offset: 0x0000809B
		protected void RaisePropertyChanging([CallerMemberName] string propertyName = null)
		{
			PropertyChangingEventHandler propertyChanging = this.PropertyChanging;
			if (propertyChanging == null)
			{
				return;
			}
			propertyChanging(this, new PropertyChangingEventArgs(propertyName));
		}

		// Token: 0x0600052C RID: 1324 RVA: 0x00009EC0 File Offset: 0x000080C0
		protected virtual bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
		{
			bool flag = !EqualityComparer<!!0>.Default.Equals(field, value);
			if (flag)
			{
				this.RaisePropertyChanging(propertyName);
				field = value;
				this.RaisePropertyChanged(propertyName);
			}
			return flag;
		}
	}
}
