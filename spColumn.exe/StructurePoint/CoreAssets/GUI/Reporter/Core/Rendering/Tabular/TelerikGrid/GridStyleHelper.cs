using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using #7hc;
using StructurePoint.CoreAssets.Infrastructure.Extensions;

namespace StructurePoint.CoreAssets.GUI.Reporter.Core.Rendering.Tabular.TelerikGrid
{
	// Token: 0x02000D1F RID: 3359
	public static class GridStyleHelper
	{
		// Token: 0x17001F10 RID: 7952
		// (get) Token: 0x06006E97 RID: 28311 RVA: 0x000591AE File Offset: 0x000573AE
		public static Style LeftRegularColumnGroupStyle
		{
			get
			{
				return \u0099\u0002.~\u0010\u0006(\u0098\u0002.\u000F\u0006(), #Phc.#3hc(107253190)) as Style;
			}
		}

		// Token: 0x17001F11 RID: 7953
		// (get) Token: 0x06006E98 RID: 28312 RVA: 0x000591DF File Offset: 0x000573DF
		public static Style RightRegularColumnGroupStyle
		{
			get
			{
				return \u0099\u0002.~\u0010\u0006(\u0098\u0002.\u000F\u0006(), #Phc.#3hc(107253173)) as Style;
			}
		}

		// Token: 0x17001F12 RID: 7954
		// (get) Token: 0x06006E99 RID: 28313 RVA: 0x00059210 File Offset: 0x00057410
		public static Style CenterRegularColumnGroupStyle
		{
			get
			{
				return \u0099\u0002.~\u0010\u0006(\u0098\u0002.\u000F\u0006(), #Phc.#3hc(107253092)) as Style;
			}
		}

		// Token: 0x17001F13 RID: 7955
		// (get) Token: 0x06006E9A RID: 28314 RVA: 0x00059241 File Offset: 0x00057441
		public static Style LeftColumnGroupStyle
		{
			get
			{
				return \u0099\u0002.~\u0010\u0006(\u0098\u0002.\u000F\u0006(), #Phc.#3hc(107253075)) as Style;
			}
		}

		// Token: 0x17001F14 RID: 7956
		// (get) Token: 0x06006E9B RID: 28315 RVA: 0x00059272 File Offset: 0x00057472
		public static Style RightColumnGroupStyle
		{
			get
			{
				return \u0099\u0002.~\u0010\u0006(\u0098\u0002.\u000F\u0006(), #Phc.#3hc(107253006)) as Style;
			}
		}

		// Token: 0x17001F15 RID: 7957
		// (get) Token: 0x06006E9C RID: 28316 RVA: 0x000592A3 File Offset: 0x000574A3
		public static Style CenterColumnGroupStyle
		{
			get
			{
				return \u0099\u0002.~\u0010\u0006(\u0098\u0002.\u000F\u0006(), #Phc.#3hc(107252453)) as Style;
			}
		}

		// Token: 0x17001F16 RID: 7958
		// (get) Token: 0x06006E9D RID: 28317 RVA: 0x000592D4 File Offset: 0x000574D4
		public static Style BoldHeaderCellStyle
		{
			get
			{
				return \u0099\u0002.~\u0010\u0006(\u0098\u0002.\u000F\u0006(), #Phc.#3hc(107252444)) as Style;
			}
		}

		// Token: 0x17001F17 RID: 7959
		// (get) Token: 0x06006E9E RID: 28318 RVA: 0x00059305 File Offset: 0x00057505
		public static Style ThinHeaderCellStyle
		{
			get
			{
				return \u0099\u0002.~\u0010\u0006(\u0098\u0002.\u000F\u0006(), #Phc.#3hc(107252411)) as Style;
			}
		}

		// Token: 0x17001F18 RID: 7960
		// (get) Token: 0x06006E9F RID: 28319 RVA: 0x00059336 File Offset: 0x00057536
		public static Style FirstHeaderlessCellStyle
		{
			get
			{
				return \u0099\u0002.~\u0010\u0006(\u0098\u0002.\u000F\u0006(), #Phc.#3hc(107252374)) as Style;
			}
		}

		// Token: 0x06006EA0 RID: 28320 RVA: 0x00059367 File Offset: 0x00057567
		public static Style #Yfd(this Style #4cd)
		{
			return new Style(\u0084.~\u0087\u0002(#4cd), #4cd);
		}

		// Token: 0x06006EA1 RID: 28321 RVA: 0x001A4D70 File Offset: 0x001A2F70
		public static Style #I3h(Style #4cd, Thickness #sFd)
		{
			SetterBase setterBase = \u009A\u0002.~\u0011\u0006(#4cd).FirstOrDefault(new Func<SetterBase, bool>(GridStyleHelper.<>c.<>9.#Q3h));
			if (setterBase != null)
			{
				\u009A\u0002.~\u0011\u0006(#4cd).Remove(setterBase);
			}
			\u009A\u0002.~\u0011\u0006(#4cd).Add(new Setter(Control.PaddingProperty, #sFd));
			return #4cd;
		}

		// Token: 0x06006EA2 RID: 28322 RVA: 0x001A4DF0 File Offset: 0x001A2FF0
		public static Style #Zfd(Style #4cd, Brush #0fd)
		{
			SetterBase setterBase = \u009A\u0002.~\u0011\u0006(#4cd).FirstOrDefault(new Func<SetterBase, bool>(GridStyleHelper.<>c.<>9.#R3h));
			if (setterBase != null)
			{
				\u009A\u0002.~\u0011\u0006(#4cd).Remove(setterBase);
			}
			\u009A\u0002.~\u0011\u0006(#4cd).Add(new Setter(Control.BackgroundProperty, #0fd));
			return #4cd;
		}

		// Token: 0x06006EA3 RID: 28323 RVA: 0x001A4E6C File Offset: 0x001A306C
		public static Style #1fd(Style #4cd, Brush #0fd)
		{
			SetterBase setterBase = \u009A\u0002.~\u0011\u0006(#4cd).FirstOrDefault(new Func<SetterBase, bool>(GridStyleHelper.<>c.<>9.#S3h));
			if (setterBase != null)
			{
				\u009A\u0002.~\u0011\u0006(#4cd).Remove(setterBase);
			}
			\u009A\u0002.~\u0011\u0006(#4cd).Add(new Setter(Control.BorderBrushProperty, #0fd));
			return #4cd;
		}

		// Token: 0x06006EA4 RID: 28324 RVA: 0x001A4EE8 File Offset: 0x001A30E8
		public static Style #2fd(string #6cc)
		{
			Style style = \u0099\u0002.~\u0010\u0006(\u0098\u0002.\u000F\u0006(), #6cc) as Style;
			if (style == null)
			{
				throw new ApplicationException(\u0015.\u009A(#Phc.#3hc(107252297).#z2d(), #6cc));
			}
			return style;
		}

		// Token: 0x06006EA5 RID: 28325 RVA: 0x00059386 File Offset: 0x00057586
		public static void #cgd(DependencyObject #eub, HorizontalAlignment #f)
		{
			\u009B\u0002.~\u0012\u0006(#eub, GridStyleHelper.HorizontalAlignmentProperty, #f);
		}

		// Token: 0x06006EA6 RID: 28326 RVA: 0x000593AA File Offset: 0x000575AA
		public static HorizontalAlignment #dgd(DependencyObject #eub)
		{
			return (HorizontalAlignment)\u009C\u0002.~\u0013\u0006(#eub, GridStyleHelper.HorizontalAlignmentProperty);
		}

		// Token: 0x04002C7F RID: 11391
		public static readonly DependencyProperty HorizontalAlignmentProperty = \u009D\u0002.\u0014\u0006(#Phc.#3hc(107470830), \u001E.\u000F\u0002(typeof(HorizontalAlignment).TypeHandle), \u001E.\u000F\u0002(typeof(GridStyleHelper).TypeHandle), new PropertyMetadata(HorizontalAlignment.Left));
	}
}
