using System;
using System.Linq.Expressions;
using System.Windows.Controls;
using System.Windows.Input;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.RibbonToolbar
{
	// Token: 0x02000901 RID: 2305
	public sealed class ToggleButtonDataAdapter : RibbonToolbarButton, IRibbonToolbarButton, IRibbonToolbarToggleButton
	{
		// Token: 0x06004979 RID: 18809 RVA: 0x0003DFC7 File Offset: 0x0003C1C7
		public ToggleButtonDataAdapter(IToggleButtonData toggleButtonData, Image mediumImage, string text, ICommand command) : base(mediumImage, text, command)
		{
			this.toggleButtonData = toggleButtonData;
			base.Command = command;
			base.Text = text;
			base.TextPosition = ButtonTextPosition.Bottom;
			this.toggleButtonData.IsCheckedChanged += this.ToggleButtonData_IsCheckedChanged;
		}

		// Token: 0x0600497A RID: 18810 RVA: 0x00144F8C File Offset: 0x0014318C
		private void ToggleButtonData_IsCheckedChanged(object sender, EventArgs e)
		{
			ParameterExpression parameterExpression = Expression.Parameter(typeof(IRibbonToolbarToggleButton), #Phc.#3hc(107398878));
			base.RaisePropertyChanged(#x0d<IRibbonToolbarToggleButton>.#XYd<bool>(Expression.Lambda<Func<IRibbonToolbarToggleButton, bool>>(Expression.Property(parameterExpression, methodof(IRibbonToolbarToggleButton.get_IsChecked())), new ParameterExpression[]
			{
				parameterExpression
			})).Name);
		}

		// Token: 0x17001588 RID: 5512
		// (get) Token: 0x0600497B RID: 18811 RVA: 0x0003E007 File Offset: 0x0003C207
		// (set) Token: 0x0600497C RID: 18812 RVA: 0x00144FF4 File Offset: 0x001431F4
		public bool IsChecked
		{
			get
			{
				return this.toggleButtonData.IsChecked;
			}
			set
			{
				if (this.toggleButtonData.IsChecked != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107407606));
					this.toggleButtonData.IsChecked = value;
					base.RaisePropertyChanged(#Phc.#3hc(107407606));
				}
			}
		}

		// Token: 0x040020EF RID: 8431
		private IToggleButtonData toggleButtonData;
	}
}
