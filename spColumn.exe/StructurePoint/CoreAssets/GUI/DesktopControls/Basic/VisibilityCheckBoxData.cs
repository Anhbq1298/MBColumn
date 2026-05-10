using System;
using System.ComponentModel;
using System.Linq.Expressions;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Infrastructure.Helpers;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Basic
{
	// Token: 0x02000AB8 RID: 2744
	public sealed class VisibilityCheckBoxData : CheckBoxData
	{
		// Token: 0x06005987 RID: 22919 RVA: 0x0016D0A0 File Offset: 0x0016B2A0
		public VisibilityCheckBoxData(VisibilityLayer visibilityLayer)
		{
			#X0d.#V0d(visibilityLayer, #Phc.#3hc(107426291), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.DesktopControls, #Phc.#3hc(107426270));
			this.visibilityLayer = visibilityLayer;
			if (visibilityLayer.ParentVisibilityLayer != null)
			{
				visibilityLayer.ParentVisibilityLayer.PropertyChanged += this.VisibilityLayer_PropertyChanged;
			}
		}

		// Token: 0x06005988 RID: 22920 RVA: 0x0016D0F4 File Offset: 0x0016B2F4
		private void VisibilityLayer_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			string propertyName = e.PropertyName;
			VisibilityLayer #Rf = this.visibilityLayer;
			ParameterExpression parameterExpression = Expression.Parameter(typeof(VisibilityLayer), #Phc.#3hc(107398878));
			if (propertyName == #Rf.#h0d(Expression.Lambda<Func<VisibilityLayer, bool>>(Expression.Property(parameterExpression, methodof(VisibilityLayer.get_IsVisible())), new ParameterExpression[]
			{
				parameterExpression
			})))
			{
				base.IsEnabled = this.visibilityLayer.IsParentLayerVisible;
			}
		}

		// Token: 0x06005989 RID: 22921 RVA: 0x0004A505 File Offset: 0x00048705
		protected override void OnIsCheckedChanged(bool oldValue, bool newValue)
		{
			base.OnIsCheckedChanged(oldValue, newValue);
			this.visibilityLayer.IsVisible = newValue;
		}

		// Token: 0x04002564 RID: 9572
		private readonly VisibilityLayer visibilityLayer;
	}
}
