using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.RibbonToolbar
{
	// Token: 0x020008F6 RID: 2294
	public class EditionToolDataAdapter : NotifyPropertyChangedObjectBase, IRibbonToolbarButton, IRibbonToolbarRadioButton
	{
		// Token: 0x0600490F RID: 18703 RVA: 0x00144828 File Offset: 0x00142A28
		public EditionToolDataAdapter(IEditionToolData editionToolData, Visibility textVisibility, ButtonTextPosition textPosition)
		{
			this.editionToolData = editionToolData;
			this.Size = ButtonImageSize.Medium;
			this.TextVisibility = textVisibility;
			this.TextPosition = textPosition;
			this.GroupName = #Phc.#3hc(107449885);
			this.editionToolData.PropertyChanged += this.EditionToolData_PropertyChanged;
		}

		// Token: 0x1700155E RID: 5470
		// (get) Token: 0x06004910 RID: 18704 RVA: 0x0003D590 File Offset: 0x0003B790
		public IEditionToolData EditionToolData
		{
			get
			{
				return this.editionToolData;
			}
		}

		// Token: 0x1700155F RID: 5471
		// (get) Token: 0x06004911 RID: 18705 RVA: 0x0003D59C File Offset: 0x0003B79C
		// (set) Token: 0x06004912 RID: 18706 RVA: 0x00144880 File Offset: 0x00142A80
		public virtual string Text
		{
			get
			{
				return this.editionToolData.Header;
			}
			set
			{
				if (this.editionToolData.Header != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107350927));
					this.editionToolData.Header = value;
					base.RaisePropertyChanged(#Phc.#3hc(107350927));
				}
			}
		}

		// Token: 0x17001560 RID: 5472
		// (get) Token: 0x06004913 RID: 18707 RVA: 0x0003D5B1 File Offset: 0x0003B7B1
		// (set) Token: 0x06004914 RID: 18708 RVA: 0x0003D5BD File Offset: 0x0003B7BD
		public Visibility TextVisibility
		{
			get
			{
				return this.textVisibility;
			}
			set
			{
				if (this.textVisibility != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107450348));
					this.textVisibility = value;
					base.RaisePropertyChanged(#Phc.#3hc(107450348));
				}
			}
		}

		// Token: 0x17001561 RID: 5473
		// (get) Token: 0x06004915 RID: 18709 RVA: 0x0003D5FB File Offset: 0x0003B7FB
		// (set) Token: 0x06004916 RID: 18710 RVA: 0x0003D607 File Offset: 0x0003B807
		public ButtonTextPosition TextPosition
		{
			get
			{
				return this.textPosition;
			}
			set
			{
				if (this.textPosition != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107450359));
					this.textPosition = value;
					base.RaisePropertyChanged(#Phc.#3hc(107450359));
				}
			}
		}

		// Token: 0x17001562 RID: 5474
		// (get) Token: 0x06004917 RID: 18711 RVA: 0x0003D645 File Offset: 0x0003B845
		// (set) Token: 0x06004918 RID: 18712 RVA: 0x0003D651 File Offset: 0x0003B851
		public ButtonImageSize Size
		{
			get
			{
				return this.size;
			}
			set
			{
				if (this.size != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107397811));
					this.size = value;
					base.RaisePropertyChanged(#Phc.#3hc(107397811));
				}
			}
		}

		// Token: 0x17001563 RID: 5475
		// (get) Token: 0x06004919 RID: 18713 RVA: 0x0003D68F File Offset: 0x0003B88F
		// (set) Token: 0x0600491A RID: 18714 RVA: 0x001448D8 File Offset: 0x00142AD8
		public Image MediumImage
		{
			get
			{
				return this.editionToolData.IconImage;
			}
			set
			{
				if (this.editionToolData.IconImage != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107450310));
					this.editionToolData.IconImage = value;
					base.RaisePropertyChanged(#Phc.#3hc(107450310));
				}
			}
		}

		// Token: 0x17001564 RID: 5476
		// (get) Token: 0x0600491B RID: 18715 RVA: 0x0003D6A4 File Offset: 0x0003B8A4
		// (set) Token: 0x0600491C RID: 18716 RVA: 0x0003D6B0 File Offset: 0x0003B8B0
		public Image LargeImage
		{
			get
			{
				return this.largeImage;
			}
			set
			{
				if (this.largeImage != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107453566));
					this.largeImage = value;
					base.RaisePropertyChanged(#Phc.#3hc(107453566));
				}
			}
		}

		// Token: 0x17001565 RID: 5477
		// (get) Token: 0x0600491D RID: 18717 RVA: 0x0003D6EE File Offset: 0x0003B8EE
		// (set) Token: 0x0600491E RID: 18718 RVA: 0x0003D6FA File Offset: 0x0003B8FA
		public ICommand Command
		{
			get
			{
				return this.command;
			}
			set
			{
				if (this.command != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107350928));
					this.command = value;
					base.RaisePropertyChanged(#Phc.#3hc(107350928));
				}
			}
		}

		// Token: 0x17001566 RID: 5478
		// (get) Token: 0x0600491F RID: 18719 RVA: 0x0003D738 File Offset: 0x0003B938
		// (set) Token: 0x06004920 RID: 18720 RVA: 0x0003D744 File Offset: 0x0003B944
		public object CommandParameter
		{
			get
			{
				return this.commandParameter;
			}
			set
			{
				if (this.commandParameter != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107350883));
					this.commandParameter = value;
					base.RaisePropertyChanged(#Phc.#3hc(107350883));
				}
			}
		}

		// Token: 0x17001567 RID: 5479
		// (get) Token: 0x06004921 RID: 18721 RVA: 0x0003D782 File Offset: 0x0003B982
		// (set) Token: 0x06004922 RID: 18722 RVA: 0x0014492C File Offset: 0x00142B2C
		public bool IsEnabled
		{
			get
			{
				return this.editionToolData.IsEnabled;
			}
			set
			{
				if (this.editionToolData.IsEnabled != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107408148));
					this.editionToolData.IsEnabled = value;
					base.RaisePropertyChanged(#Phc.#3hc(107408148));
				}
			}
		}

		// Token: 0x17001568 RID: 5480
		// (get) Token: 0x06004923 RID: 18723 RVA: 0x0003D797 File Offset: 0x0003B997
		// (set) Token: 0x06004924 RID: 18724 RVA: 0x00008FC0 File Offset: 0x000071C0
		public RichToolTipContent ToolTipContent
		{
			get
			{
				return this.editionToolData.ToolTipContent;
			}
			set
			{
				throw new NotSupportedException();
			}
		}

		// Token: 0x17001569 RID: 5481
		// (get) Token: 0x06004925 RID: 18725 RVA: 0x0003D7AC File Offset: 0x0003B9AC
		// (set) Token: 0x06004926 RID: 18726 RVA: 0x00144980 File Offset: 0x00142B80
		public bool IsChecked
		{
			get
			{
				return this.editionToolData.IsSelected;
			}
			set
			{
				if (this.editionToolData.IsSelected != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107407606));
					this.editionToolData.IsSelected = value;
					base.RaisePropertyChanged(#Phc.#3hc(107407606));
				}
			}
		}

		// Token: 0x1700156A RID: 5482
		// (get) Token: 0x06004927 RID: 18727 RVA: 0x0003D7C1 File Offset: 0x0003B9C1
		// (set) Token: 0x06004928 RID: 18728 RVA: 0x001449D4 File Offset: 0x00142BD4
		public string GroupName
		{
			get
			{
				return this.groupName;
			}
			set
			{
				if (this.groupName != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107453596));
					this.groupName = value;
					base.RaisePropertyChanged(#Phc.#3hc(107453596));
				}
			}
		}

		// Token: 0x1700156B RID: 5483
		// (get) Token: 0x06004929 RID: 18729 RVA: 0x0003D7CD File Offset: 0x0003B9CD
		// (set) Token: 0x0600492A RID: 18730 RVA: 0x0003D7D9 File Offset: 0x0003B9D9
		public Visibility Visibility
		{
			get
			{
				return this.visibility;
			}
			set
			{
				if (this.visibility != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107384000));
					this.visibility = value;
					base.RaisePropertyChanged(#Phc.#3hc(107384000));
				}
			}
		}

		// Token: 0x0600492B RID: 18731 RVA: 0x0003D817 File Offset: 0x0003BA17
		private static string MyGetToolPropertyName<T>(Expression<Func<IEditionToolData, T>> selector)
		{
			return #x0d<IEditionToolData>.#XYd<T>(selector).Name;
		}

		// Token: 0x0600492C RID: 18732 RVA: 0x0003D830 File Offset: 0x0003BA30
		private static string MyGetPropertyName<T>(Expression<Func<EditionToolDataAdapter, T>> selector)
		{
			return #x0d<EditionToolDataAdapter>.#XYd<T>(selector).Name;
		}

		// Token: 0x0600492D RID: 18733 RVA: 0x00144A24 File Offset: 0x00142C24
		private void EditionToolData_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e == null || string.IsNullOrEmpty(e.PropertyName))
			{
				return;
			}
			string propertyName = e.PropertyName;
			ParameterExpression parameterExpression = System.Linq.Expressions.Expression.Parameter(typeof(IEditionToolData), #Phc.#3hc(107398878));
			if (propertyName.Equals(EditionToolDataAdapter.MyGetToolPropertyName<bool>(System.Linq.Expressions.Expression.Lambda<Func<IEditionToolData, bool>>(System.Linq.Expressions.Expression.Property(parameterExpression, methodof(IEditionToolData.get_IsEnabled())), new ParameterExpression[]
			{
				parameterExpression
			}))))
			{
				parameterExpression = System.Linq.Expressions.Expression.Parameter(typeof(EditionToolDataAdapter), #Phc.#3hc(107398878));
				base.RaisePropertyChanged(EditionToolDataAdapter.MyGetPropertyName<bool>(System.Linq.Expressions.Expression.Lambda<Func<EditionToolDataAdapter, bool>>(System.Linq.Expressions.Expression.Property(parameterExpression, methodof(EditionToolDataAdapter.get_IsEnabled())), new ParameterExpression[]
				{
					parameterExpression
				})));
				return;
			}
			string propertyName2 = e.PropertyName;
			parameterExpression = System.Linq.Expressions.Expression.Parameter(typeof(IEditionToolData), #Phc.#3hc(107398878));
			if (propertyName2.Equals(EditionToolDataAdapter.MyGetToolPropertyName<bool>(System.Linq.Expressions.Expression.Lambda<Func<IEditionToolData, bool>>(System.Linq.Expressions.Expression.Property(parameterExpression, methodof(IEditionToolData.get_IsSelected())), new ParameterExpression[]
			{
				parameterExpression
			}))))
			{
				parameterExpression = System.Linq.Expressions.Expression.Parameter(typeof(EditionToolDataAdapter), #Phc.#3hc(107398878));
				base.RaisePropertyChanged(EditionToolDataAdapter.MyGetPropertyName<bool>(System.Linq.Expressions.Expression.Lambda<Func<EditionToolDataAdapter, bool>>(System.Linq.Expressions.Expression.Property(parameterExpression, methodof(EditionToolDataAdapter.get_IsChecked())), new ParameterExpression[]
				{
					parameterExpression
				})));
				return;
			}
			string propertyName3 = e.PropertyName;
			parameterExpression = System.Linq.Expressions.Expression.Parameter(typeof(IEditionToolData), #Phc.#3hc(107398878));
			if (propertyName3.Equals(EditionToolDataAdapter.MyGetToolPropertyName<RichToolTipContent>(System.Linq.Expressions.Expression.Lambda<Func<IEditionToolData, RichToolTipContent>>(System.Linq.Expressions.Expression.Property(parameterExpression, methodof(IEditionToolData.get_ToolTipContent())), new ParameterExpression[]
			{
				parameterExpression
			}))))
			{
				parameterExpression = System.Linq.Expressions.Expression.Parameter(typeof(EditionToolDataAdapter), #Phc.#3hc(107398878));
				base.RaisePropertyChanged(EditionToolDataAdapter.MyGetPropertyName<RichToolTipContent>(System.Linq.Expressions.Expression.Lambda<Func<EditionToolDataAdapter, RichToolTipContent>>(System.Linq.Expressions.Expression.Property(parameterExpression, methodof(EditionToolDataAdapter.get_ToolTipContent())), new ParameterExpression[]
				{
					parameterExpression
				})));
				return;
			}
			string propertyName4 = e.PropertyName;
			parameterExpression = System.Linq.Expressions.Expression.Parameter(typeof(IEditionToolData), #Phc.#3hc(107398878));
			if (propertyName4.Equals(EditionToolDataAdapter.MyGetToolPropertyName<string>(System.Linq.Expressions.Expression.Lambda<Func<IEditionToolData, string>>(System.Linq.Expressions.Expression.Property(parameterExpression, methodof(IEditionToolData.get_Header())), new ParameterExpression[]
			{
				parameterExpression
			}))))
			{
				parameterExpression = System.Linq.Expressions.Expression.Parameter(typeof(EditionToolDataAdapter), #Phc.#3hc(107398878));
				base.RaisePropertyChanged(EditionToolDataAdapter.MyGetPropertyName<string>(System.Linq.Expressions.Expression.Lambda<Func<EditionToolDataAdapter, string>>(System.Linq.Expressions.Expression.Property(parameterExpression, methodof(EditionToolDataAdapter.get_Text())), new ParameterExpression[]
				{
					parameterExpression
				})));
			}
		}

		// Token: 0x040020C9 RID: 8393
		private const string ConstGroupName = "ToolsGroup";

		// Token: 0x040020CA RID: 8394
		private readonly IEditionToolData editionToolData;

		// Token: 0x040020CB RID: 8395
		private ButtonImageSize size;

		// Token: 0x040020CC RID: 8396
		private Image largeImage;

		// Token: 0x040020CD RID: 8397
		private ICommand command;

		// Token: 0x040020CE RID: 8398
		private object commandParameter;

		// Token: 0x040020CF RID: 8399
		private Visibility textVisibility;

		// Token: 0x040020D0 RID: 8400
		private ButtonTextPosition textPosition;

		// Token: 0x040020D1 RID: 8401
		private string groupName;

		// Token: 0x040020D2 RID: 8402
		private Visibility visibility;
	}
}
