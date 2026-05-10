using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using #7hc;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Units.Formatters;

namespace StructurePoint.CoreAssets.GUI.Framework.Controls
{
	// Token: 0x02000CE1 RID: 3297
	public sealed class ModelExtremeCoordinatesControl : UserControl, IComponentConnector
	{
		// Token: 0x06006BE0 RID: 27616 RVA: 0x00054B39 File Offset: 0x00052D39
		public ModelExtremeCoordinatesControl()
		{
			this.InitializeComponent();
		}

		// Token: 0x17001D96 RID: 7574
		// (get) Token: 0x06006BE1 RID: 27617 RVA: 0x00054B47 File Offset: 0x00052D47
		// (set) Token: 0x06006BE2 RID: 27618 RVA: 0x00054B59 File Offset: 0x00052D59
		public BoundingBoxData ModelBoundingBox
		{
			get
			{
				return (BoundingBoxData)base.GetValue(ModelExtremeCoordinatesControl.ModelBoundingBoxProperty);
			}
			set
			{
				DependencyProperty modelBoundingBoxProperty = ModelExtremeCoordinatesControl.ModelBoundingBoxProperty;
				if (2 != 0)
				{
					base.SetValue(modelBoundingBoxProperty, value);
				}
			}
		}

		// Token: 0x17001D97 RID: 7575
		// (get) Token: 0x06006BE3 RID: 27619 RVA: 0x00054B6F File Offset: 0x00052D6F
		// (set) Token: 0x06006BE4 RID: 27620 RVA: 0x00054B81 File Offset: 0x00052D81
		public IUnitValueFormatter DimensionUnitValueFormatter
		{
			get
			{
				return (IUnitValueFormatter)base.GetValue(ModelExtremeCoordinatesControl.DimensionUnitValueFormatterProperty);
			}
			set
			{
				DependencyProperty dimensionUnitValueFormatterProperty = ModelExtremeCoordinatesControl.DimensionUnitValueFormatterProperty;
				if (2 != 0)
				{
					base.SetValue(dimensionUnitValueFormatterProperty, value);
				}
			}
		}

		// Token: 0x17001D98 RID: 7576
		// (get) Token: 0x06006BE5 RID: 27621 RVA: 0x00054B97 File Offset: 0x00052D97
		// (set) Token: 0x06006BE6 RID: 27622 RVA: 0x00054BA9 File Offset: 0x00052DA9
		public string DimensionUnitSymbol
		{
			get
			{
				return (string)base.GetValue(ModelExtremeCoordinatesControl.DimensionUnitSymbolProperty);
			}
			set
			{
				DependencyProperty dimensionUnitSymbolProperty = ModelExtremeCoordinatesControl.DimensionUnitSymbolProperty;
				if (2 != 0)
				{
					base.SetValue(dimensionUnitSymbolProperty, value);
				}
			}
		}

		// Token: 0x06006BE7 RID: 27623 RVA: 0x001A0EC0 File Offset: 0x0019F0C0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			int num = this._contentLoaded ? 1 : 0;
			IL_06:
			while (num == 0)
			{
				do
				{
					this._contentLoaded = true;
					if (!false)
					{
						int num2 = num = 107265947;
						if (num2 == 0)
						{
							goto IL_06;
						}
						Uri uri = new Uri(#Phc.#3hc(num2), UriKind.Relative);
						Uri uri2;
						if (!false)
						{
							uri2 = uri;
						}
						Uri resourceLocator = uri2;
						if (!false)
						{
							Application.LoadComponent(this, resourceLocator);
						}
					}
				}
				while (-1 == 0);
				return;
			}
		}

		// Token: 0x06006BE8 RID: 27624 RVA: 0x00054BBF File Offset: 0x00052DBF
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
		[SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
		[SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04002BEF RID: 11247
		public static readonly DependencyProperty ModelBoundingBoxProperty = DependencyProperty.Register(#Phc.#3hc(107265826), typeof(BoundingBoxData), typeof(ModelExtremeCoordinatesControl), new PropertyMetadata(null));

		// Token: 0x04002BF0 RID: 11248
		public static readonly DependencyProperty DimensionUnitValueFormatterProperty = DependencyProperty.Register(#Phc.#3hc(107265801), typeof(IUnitValueFormatter), typeof(ModelExtremeCoordinatesControl), new PropertyMetadata(new FloatingPointUnitValueFormatter(3)));

		// Token: 0x04002BF1 RID: 11249
		public static readonly DependencyProperty DimensionUnitSymbolProperty = DependencyProperty.Register(#Phc.#3hc(107265252), typeof(string), typeof(ModelExtremeCoordinatesControl), new PropertyMetadata(#Phc.#3hc(107265223).#S2d()));

		// Token: 0x04002BF2 RID: 11250
		private bool _contentLoaded;
	}
}
