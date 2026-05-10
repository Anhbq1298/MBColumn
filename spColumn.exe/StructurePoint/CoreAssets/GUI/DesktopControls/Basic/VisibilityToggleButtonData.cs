using System;
using System.ComponentModel;
using System.Linq.Expressions;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Infrastructure.Helpers;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Basic
{
	// Token: 0x02000AD1 RID: 2769
	public sealed class VisibilityToggleButtonData : ToggleButtonData
	{
		// Token: 0x06005A21 RID: 23073 RVA: 0x0016E20C File Offset: 0x0016C40C
		public VisibilityToggleButtonData(VisibilityLayer visibilityLayer)
		{
			#X0d.#V0d(visibilityLayer, #Phc.#3hc(107426291), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.DesktopControls, #Phc.#3hc(107424408));
			this.visibilityLayer = visibilityLayer;
			if (visibilityLayer.ParentVisibilityLayer != null)
			{
				visibilityLayer.ParentVisibilityLayer.PropertyChanged += this.VisibilityLayer_PropertyChanged;
			}
		}

		// Token: 0x06005A22 RID: 23074 RVA: 0x0016E260 File Offset: 0x0016C460
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

		// Token: 0x06005A23 RID: 23075 RVA: 0x0004AE4F File Offset: 0x0004904F
		protected override void OnIsCheckedChanged(bool oldValue, bool newValue)
		{
			base.OnIsCheckedChanged(oldValue, newValue);
			this.visibilityLayer.IsVisible = newValue;
		}

		// Token: 0x0400259B RID: 9627
		private readonly VisibilityLayer visibilityLayer;
	}
}
