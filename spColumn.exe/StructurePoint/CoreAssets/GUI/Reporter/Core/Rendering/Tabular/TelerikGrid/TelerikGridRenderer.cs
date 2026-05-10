using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using #5Fd;
using #7hc;
using #Jrd;
using #o1d;
using #Qcd;
using #Ted;
using Aspose.Words;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor.Drawing;
using StructurePoint.CoreAssets.GUI.Framework.Collections;
using StructurePoint.CoreAssets.Infrastructure;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;

namespace StructurePoint.CoreAssets.GUI.Reporter.Core.Rendering.Tabular.TelerikGrid
{
	// Token: 0x02000D2A RID: 3370
	public sealed class TelerikGridRenderer
	{
		// Token: 0x06006ED3 RID: 28371 RVA: 0x001A50AC File Offset: 0x001A32AC
		public TelerikGridRenderer(RadGridView gridView, #7Fd deformatter, Color? headerLessLabelColumnColor = null)
		{
			if (deformatter == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107254045));
			}
			this.#u = deformatter;
			if (gridView == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107465689));
			}
			this.#c = gridView;
			if (headerLessLabelColumnColor != null)
			{
				this.#d = new SolidColorBrush(headerLessLabelColumnColor.Value);
				this.#d.Freeze();
			}
			this.#c.ItemsSource = this.#e;
			this.DefaultRowBackground = Brushes.White;
			this.Margin = 70.0;
			this.ReferenceHeaderLessTableWidth = 650.0;
			this.ReferenceTableWidth = 850.0;
			this.ColumnWidthFactor = 0.6;
			this.MinCalculateColumnWidth = 40.0;
			this.EnableBoldHeaders = true;
			this.IsGridSortable = true;
		}

		// Token: 0x140001A2 RID: 418
		// (add) Token: 0x06006ED4 RID: 28372 RVA: 0x001A51E0 File Offset: 0x001A33E0
		// (remove) Token: 0x06006ED5 RID: 28373 RVA: 0x001A5224 File Offset: 0x001A3424
		public event EventHandler<#Yhd> RowRendered
		{
			[CompilerGenerated]
			add
			{
				EventHandler<#Yhd> eventHandler = this.#t;
				EventHandler<#Yhd> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#Yhd> value2 = (EventHandler<#Yhd>)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#Yhd>>(ref this.#t, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<#Yhd> eventHandler = this.#t;
				EventHandler<#Yhd> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#Yhd> value2 = (EventHandler<#Yhd>)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#Yhd>>(ref this.#t, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x17001F28 RID: 7976
		// (get) Token: 0x06006ED6 RID: 28374 RVA: 0x000595E2 File Offset: 0x000577E2
		public #7Fd Deformatter { get; }

		// Token: 0x17001F29 RID: 7977
		// (get) Token: 0x06006ED7 RID: 28375 RVA: 0x000595EE File Offset: 0x000577EE
		// (set) Token: 0x06006ED8 RID: 28376 RVA: 0x000595FA File Offset: 0x000577FA
		public Brush HeaderBackgroundBrush { get; set; }

		// Token: 0x17001F2A RID: 7978
		// (get) Token: 0x06006ED9 RID: 28377 RVA: 0x0005960B File Offset: 0x0005780B
		// (set) Token: 0x06006EDA RID: 28378 RVA: 0x00059617 File Offset: 0x00057817
		public Brush DefaultRowBackground { get; set; }

		// Token: 0x17001F2B RID: 7979
		// (get) Token: 0x06006EDB RID: 28379 RVA: 0x00059628 File Offset: 0x00057828
		// (set) Token: 0x06006EDC RID: 28380 RVA: 0x00059634 File Offset: 0x00057834
		public Brush HeaderBorderBrush { get; set; }

		// Token: 0x17001F2C RID: 7980
		// (get) Token: 0x06006EDD RID: 28381 RVA: 0x00059645 File Offset: 0x00057845
		// (set) Token: 0x06006EDE RID: 28382 RVA: 0x00059651 File Offset: 0x00057851
		public bool ExpandLastColumn { get; set; }

		// Token: 0x17001F2D RID: 7981
		// (get) Token: 0x06006EDF RID: 28383 RVA: 0x00059662 File Offset: 0x00057862
		// (set) Token: 0x06006EE0 RID: 28384 RVA: 0x0005966E File Offset: 0x0005786E
		public double? LastColumnMinWidth { get; set; }

		// Token: 0x17001F2E RID: 7982
		// (get) Token: 0x06006EE1 RID: 28385 RVA: 0x0005967F File Offset: 0x0005787F
		// (set) Token: 0x06006EE2 RID: 28386 RVA: 0x0005968B File Offset: 0x0005788B
		public bool UseCompactHeaderStyles { get; set; }

		// Token: 0x17001F2F RID: 7983
		// (get) Token: 0x06006EE3 RID: 28387 RVA: 0x0005969C File Offset: 0x0005789C
		// (set) Token: 0x06006EE4 RID: 28388 RVA: 0x000596A8 File Offset: 0x000578A8
		public bool DisableScrollbarInvalidation { get; set; }

		// Token: 0x17001F30 RID: 7984
		// (get) Token: 0x06006EE5 RID: 28389 RVA: 0x000596B9 File Offset: 0x000578B9
		// (set) Token: 0x06006EE6 RID: 28390 RVA: 0x000596C5 File Offset: 0x000578C5
		public double Margin { get; set; }

		// Token: 0x17001F31 RID: 7985
		// (get) Token: 0x06006EE7 RID: 28391 RVA: 0x000596D6 File Offset: 0x000578D6
		// (set) Token: 0x06006EE8 RID: 28392 RVA: 0x000596E2 File Offset: 0x000578E2
		public double MinCalculateColumnWidth { get; set; }

		// Token: 0x17001F32 RID: 7986
		// (get) Token: 0x06006EE9 RID: 28393 RVA: 0x000596F3 File Offset: 0x000578F3
		// (set) Token: 0x06006EEA RID: 28394 RVA: 0x000596FF File Offset: 0x000578FF
		public double ReferenceHeaderLessTableWidth { get; set; }

		// Token: 0x17001F33 RID: 7987
		// (get) Token: 0x06006EEB RID: 28395 RVA: 0x00059710 File Offset: 0x00057910
		// (set) Token: 0x06006EEC RID: 28396 RVA: 0x0005971C File Offset: 0x0005791C
		public double ReferenceTableWidth { get; set; }

		// Token: 0x17001F34 RID: 7988
		// (get) Token: 0x06006EED RID: 28397 RVA: 0x0005972D File Offset: 0x0005792D
		// (set) Token: 0x06006EEE RID: 28398 RVA: 0x00059739 File Offset: 0x00057939
		public double ColumnWidthFactor { get; set; }

		// Token: 0x17001F35 RID: 7989
		// (get) Token: 0x06006EEF RID: 28399 RVA: 0x0005974A File Offset: 0x0005794A
		// (set) Token: 0x06006EF0 RID: 28400 RVA: 0x00059756 File Offset: 0x00057956
		public #ogd SortValuePreprocessor { get; set; }

		// Token: 0x17001F36 RID: 7990
		// (get) Token: 0x06006EF1 RID: 28401 RVA: 0x00059767 File Offset: 0x00057967
		// (set) Token: 0x06006EF2 RID: 28402 RVA: 0x00059773 File Offset: 0x00057973
		public bool EnableBoldHeaders { get; set; }

		// Token: 0x17001F37 RID: 7991
		// (get) Token: 0x06006EF3 RID: 28403 RVA: 0x00059784 File Offset: 0x00057984
		// (set) Token: 0x06006EF4 RID: 28404 RVA: 0x00059790 File Offset: 0x00057990
		public bool IsGridSortable { get; set; }

		// Token: 0x17001F38 RID: 7992
		// (get) Token: 0x06006EF5 RID: 28405 RVA: 0x000597A1 File Offset: 0x000579A1
		// (set) Token: 0x06006EF6 RID: 28406 RVA: 0x000597AD File Offset: 0x000579AD
		public #Igd RenderMode { get; set; }

		// Token: 0x17001F39 RID: 7993
		// (get) Token: 0x06006EF7 RID: 28407 RVA: 0x000597BE File Offset: 0x000579BE
		// (set) Token: 0x06006EF8 RID: 28408 RVA: 0x000597CA File Offset: 0x000579CA
		public bool ReuseRows { get; set; }

		// Token: 0x17001F3A RID: 7994
		// (get) Token: 0x06006EF9 RID: 28409 RVA: 0x000597DB File Offset: 0x000579DB
		// (set) Token: 0x06006EFA RID: 28410 RVA: 0x000597E7 File Offset: 0x000579E7
		public Thickness CompactHeaderCellPadding { get; set; }

		// Token: 0x06006EFB RID: 28411 RVA: 0x000597F8 File Offset: 0x000579F8
		public void #ehd()
		{
			this.#e.#z7c(true);
			this.#f.Clear();
			this.#f.Capacity = 10;
		}

		// Token: 0x06006EFC RID: 28412 RVA: 0x001A5268 File Offset: 0x001A3468
		protected GridDataRowCore #73c(int #fhd)
		{
			switch (#fhd)
			{
			case 0:
			case 1:
			case 2:
				return new #FBd();
			case 3:
				return new #GBd();
			case 4:
				return new #HBd();
			case 5:
				return new #IBd();
			case 6:
				return new #JBd();
			case 7:
				return new #KBd();
			case 8:
				return new #LBd();
			case 9:
				return new #MBd();
			case 10:
				return new #zBd();
			case 11:
				return new #ABd();
			case 12:
				return new #BBd();
			case 13:
				return new #CBd();
			case 14:
				return new #DBd();
			case 15:
				return new #EBd();
			default:
				if (#fhd <= 30)
				{
					return new #xBd();
				}
				if (#fhd <= 50)
				{
					return new #yBd();
				}
				if (#fhd <= 100)
				{
					return new #Ird();
				}
				if (#fhd <= 200)
				{
					return new #wBd();
				}
				throw new InvalidOperationException(\u0015.\u009A(#Phc.#3hc(107252268), #fhd).#z2d());
			}
		}

		// Token: 0x06006EFD RID: 28413 RVA: 0x001A5384 File Offset: 0x001A3584
		public void #ghd(#Wfd #Pc)
		{
			if (#Pc == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107395311));
			}
			this.#j = #Pc;
			if (this.RenderMode == #Igd.#a || this.RenderMode == #Igd.#c)
			{
				this.#mhd();
				this.#ohd(#Pc);
			}
			if (#Pc.HeaderRowCount > 0)
			{
				this.#uhd(#Pc);
				return;
			}
			this.#i = true;
			this.#shd(#Pc);
		}

		// Token: 0x06006EFE RID: 28414 RVA: 0x001A53F8 File Offset: 0x001A35F8
		public void #hhd()
		{
			#fgd #fgd = this.#b.LastOrDefault<#fgd>();
			if (#fgd == null)
			{
				return;
			}
			for (int i = 0; i < #fgd.Columns.Count; i++)
			{
				TelerikGridColumnHeaderData telerikGridColumnHeaderData = #fgd.Columns[i];
				if (telerikGridColumnHeaderData.Column != null)
				{
					GridViewLength gridViewLength = this.#qhd(this.#j, i);
					\u009E\u0002.~\u0016\u0006(telerikGridColumnHeaderData.Column, gridViewLength);
					if (!this.ExpandLastColumn || i != #fgd.Columns.Count - 1)
					{
						\u009F\u0002.~\u0017\u0006(telerikGridColumnHeaderData.Column, gridViewLength.Value);
					}
				}
			}
			if (this.LastColumnMinWidth != null && #fgd.Columns.Count > 0)
			{
				\u009F\u0002.~\u0018\u0006(#fgd.Columns[#fgd.Columns.Count - 1].Column, this.LastColumnMinWidth.Value);
			}
			this.#nhd();
		}

		// Token: 0x06006EFF RID: 28415 RVA: 0x001A550C File Offset: 0x001A370C
		public void #ihd(double #jhd)
		{
			if (#jhd <= 0.0)
			{
				if (!false)
				{
					this.#lhd();
				}
				return;
			}
			this.#h = #jhd;
			if (!this.#b.Any<#fgd>())
			{
				return;
			}
			#fgd #fgd = this.#b.Last<#fgd>();
			for (int i = 0; i < #fgd.Columns.Count; i++)
			{
				TelerikGridColumnHeaderData telerikGridColumnHeaderData = #fgd.Columns[i];
				if (telerikGridColumnHeaderData.Column != null)
				{
					if (this.ExpandLastColumn && i == #fgd.Columns.Count - 1)
					{
						\u009E\u0002.~\u0016\u0006(telerikGridColumnHeaderData.Column, new GridViewLength(1.0, GridViewLengthUnitType.Star));
					}
					else
					{
						GridViewLength gridViewLength = this.#qhd(this.#j, i);
						double num = this.#rhd(this.#j, telerikGridColumnHeaderData.WidthPercentage).Value;
						num = \u0011\u0002.\u008B\u0004(21.0, num);
						num = \u0011\u0002.\u008A\u0004(gridViewLength.Value - 1.0, num);
						\u0007.~\u0013(telerikGridColumnHeaderData.Column);
						\u009F\u0002.~\u0018\u0006(telerikGridColumnHeaderData.Column, \u0011\u0002.\u008B\u0004(num * 0.75, 20.0));
						\u009F\u0002.~\u0017\u0006(telerikGridColumnHeaderData.Column, gridViewLength.Value);
						\u009E\u0002.~\u0016\u0006(telerikGridColumnHeaderData.Column, \u0001\u0003.\u0097\u0006(num));
						\u0007.~\u0014(telerikGridColumnHeaderData.Column);
					}
				}
			}
			if (this.LastColumnMinWidth != null && #fgd.Columns.Count > 0)
			{
				\u009F\u0002.~\u0018\u0006(#fgd.Columns[#fgd.Columns.Count - 1].Column, this.LastColumnMinWidth.Value);
			}
			this.#nhd();
		}

		// Token: 0x06006F00 RID: 28416 RVA: 0x0005982A File Offset: 0x00057A2A
		protected void #khd(#Yhd #He)
		{
			EventHandler<#Yhd> eventHandler = this.#t;
			if (eventHandler == null)
			{
				return;
			}
			eventHandler(this, #He);
		}

		// Token: 0x06006F01 RID: 28417 RVA: 0x001A571C File Offset: 0x001A391C
		private void #lhd()
		{
			#Wfd #Wfd = this.#j;
			#Wfd #Wfd2;
			if (6 != 0)
			{
				#Wfd2 = #Wfd;
			}
			if (this.#b.Any<#fgd>() && #Wfd2 != null)
			{
				#fgd #fgd = this.#b.Last<#fgd>();
				for (int i = 0; i < #fgd.Columns.Count; i++)
				{
					TelerikGridColumnHeaderData telerikGridColumnHeaderData = #fgd.Columns[i];
					if (telerikGridColumnHeaderData.Column != null)
					{
						GridViewLength gridViewLength = this.#qhd(#Wfd2, i);
						\u009F\u0002.~\u0018\u0006(telerikGridColumnHeaderData.Column, 20.0);
						if (!this.ExpandLastColumn || i != #fgd.Columns.Count - 1)
						{
							\u009F\u0002.~\u0017\u0006(telerikGridColumnHeaderData.Column, gridViewLength.Value);
						}
					}
				}
			}
		}

		// Token: 0x06006F02 RID: 28418 RVA: 0x001A57F4 File Offset: 0x001A39F4
		private void #mhd()
		{
			if ((this.HeaderBackgroundBrush != null || this.HeaderBorderBrush != null) && !this.#k)
			{
				this.#k = true;
				System.Windows.Style basedOn = GridStyleHelper.#2fd(#Phc.#3hc(107252251));
				System.Windows.Style style = new System.Windows.Style(\u001E.\u000F\u0002(typeof(GridViewHeaderRow).TypeHandle), basedOn);
				if (this.HeaderBackgroundBrush != null)
				{
					\u009A\u0002.~\u0011\u0006(style).Add(new Setter(Control.BackgroundProperty, this.HeaderBackgroundBrush));
				}
				if (this.HeaderBorderBrush != null)
				{
					\u009A\u0002.~\u0011\u0006(style).Add(new Setter(Control.BorderBrushProperty, this.HeaderBorderBrush));
				}
				\u0002\u0003.~\u0098\u0006(this.#c, style);
				this.#l = GridStyleHelper.LeftColumnGroupStyle.#Yfd();
				this.#m = GridStyleHelper.CenterColumnGroupStyle.#Yfd();
				this.#n = GridStyleHelper.RightColumnGroupStyle.#Yfd();
				this.#o = GridStyleHelper.LeftRegularColumnGroupStyle.#Yfd();
				this.#p = GridStyleHelper.CenterRegularColumnGroupStyle.#Yfd();
				this.#q = GridStyleHelper.RightRegularColumnGroupStyle.#Yfd();
				this.#r = GridStyleHelper.BoldHeaderCellStyle.#Yfd();
				this.#s = GridStyleHelper.ThinHeaderCellStyle.#Yfd();
				if (this.HeaderBackgroundBrush != null)
				{
					this.#l = GridStyleHelper.#Zfd(this.#l, this.HeaderBackgroundBrush);
					this.#m = GridStyleHelper.#Zfd(this.#m, this.HeaderBackgroundBrush);
					this.#n = GridStyleHelper.#Zfd(this.#n, this.HeaderBackgroundBrush);
					this.#o = GridStyleHelper.#Zfd(this.#o, this.HeaderBackgroundBrush);
					this.#p = GridStyleHelper.#Zfd(this.#p, this.HeaderBackgroundBrush);
					this.#q = GridStyleHelper.#Zfd(this.#q, this.HeaderBackgroundBrush);
					this.#r = GridStyleHelper.#Zfd(this.#r, this.HeaderBackgroundBrush);
					this.#s = GridStyleHelper.#Zfd(this.#s, this.HeaderBackgroundBrush);
				}
				if (this.HeaderBorderBrush != null)
				{
					this.#l = GridStyleHelper.#1fd(this.#l, this.HeaderBorderBrush);
					this.#m = GridStyleHelper.#1fd(this.#m, this.HeaderBorderBrush);
					this.#n = GridStyleHelper.#1fd(this.#n, this.HeaderBorderBrush);
					this.#o = GridStyleHelper.#1fd(this.#o, this.HeaderBorderBrush);
					this.#p = GridStyleHelper.#1fd(this.#p, this.HeaderBorderBrush);
					this.#q = GridStyleHelper.#1fd(this.#q, this.HeaderBorderBrush);
					this.#r = GridStyleHelper.#1fd(this.#r, this.HeaderBorderBrush);
					this.#s = GridStyleHelper.#1fd(this.#s, this.HeaderBorderBrush);
				}
				if (this.UseCompactHeaderStyles)
				{
					this.#l = GridStyleHelper.#I3h(this.#l, this.CompactHeaderCellPadding);
					this.#m = GridStyleHelper.#I3h(this.#m, this.CompactHeaderCellPadding);
					this.#n = GridStyleHelper.#I3h(this.#n, this.CompactHeaderCellPadding);
					this.#o = GridStyleHelper.#I3h(this.#o, this.CompactHeaderCellPadding);
					this.#p = GridStyleHelper.#I3h(this.#p, this.CompactHeaderCellPadding);
					this.#q = GridStyleHelper.#I3h(this.#q, this.CompactHeaderCellPadding);
				}
			}
		}

		// Token: 0x06006F03 RID: 28419 RVA: 0x0005984A File Offset: 0x00057A4A
		private void #nhd()
		{
			if (this.DisableScrollbarInvalidation)
			{
				return;
			}
			if (this.#g.#YXd())
			{
				LayoutHelper.BeginInvokeOnApplicationThread(new Action(this.#P3h));
			}
		}

		// Token: 0x06006F04 RID: 28420 RVA: 0x001A5B68 File Offset: 0x001A3D68
		private void #ohd(#Wfd #Pc)
		{
			TelerikGridRenderer.#Fzf #Fzf = new TelerikGridRenderer.#Fzf();
			#Fzf.#a = #Pc;
			bool flag;
			if (((this.#b.Count == 1 && #Fzf.#a.HeaderRowCount == 0) || this.#b.Count == #Fzf.#a.HeaderRowCount) && #Fzf.#a.ColumnsCount == \u0003\u0003.~\u009C\u0006(this.#c).Count && #Fzf.#a.Rows.Count >= this.#b.Count)
			{
				flag = this.#b.Select(new Func<#fgd, int, bool>(#Fzf.#OUd)).All(new Func<bool, bool>(TelerikGridRenderer.<>c.<>9.#T3h));
			}
			else
			{
				flag = false;
			}
			bool flag2 = flag;
			bool flag3 = true;
			if (flag2 && #Fzf.#a.HeaderRowCount > 0)
			{
				for (int i = 0; i < this.#b.Count; i++)
				{
					for (int j = 0; j < this.#b[i].Columns.Count; j++)
					{
						if (!\u0006.\u0008(this.#b[i].Columns[j].Header, #Fzf.#a.Rows[i].Cells[j].Value, StringComparison.Ordinal))
						{
							flag3 = false;
							break;
						}
					}
				}
			}
			if (!flag2 || !flag3)
			{
				\u0003\u0003.~\u009C\u0006(this.#c).Clear();
				\u0004\u0003.~\u009D\u0006(this.#c).Clear();
				\u0005\u0003.~\u009F\u0006(this.#c).Clear();
				this.#b.Clear();
			}
		}

		// Token: 0x06006F05 RID: 28421 RVA: 0x001A5D48 File Offset: 0x001A3F48
		private void #phd()
		{
			if (\u0003\u0003.~\u009C\u0006(this.#c).Count > 0)
			{
				return;
			}
			\u0003\u0003.~\u009C\u0006(this.#c).Clear();
			\u0004\u0003.~\u009D\u0006(this.#c).Clear();
			\u0095.~\u001B\u0003(this.#c, !this.#i);
			if (this.#b.Count > 1)
			{
				List<GridViewColumnGroup> list = this.#b[0].Columns.Where(new Func<TelerikGridColumnHeaderData, bool>(TelerikGridRenderer.<>c.<>9.#U3h)).Select(new Func<TelerikGridColumnHeaderData, GridViewColumnGroup>(TelerikGridRenderer.<>c.<>9.#V3h)).ToList<GridViewColumnGroup>();
				\u0004\u0003.~\u009D\u0006(this.#c).#pR(new ICollection<GridViewColumnGroup>[]
				{
					list
				});
			}
			#fgd #fgd = this.#b.LastOrDefault<#fgd>();
			if (#fgd != null)
			{
				List<GridViewDataColumn> list2 = #fgd.Columns.Select(new Func<TelerikGridColumnHeaderData, GridViewDataColumn>(TelerikGridRenderer.<>c.<>9.#W3h)).Where(new Func<GridViewDataColumn, bool>(TelerikGridRenderer.<>c.<>9.#X3h)).ToList<GridViewDataColumn>();
				\u0006\u0003.~\u0001\u0007(\u0003\u0003.~\u009C\u0006(this.#c), list2);
			}
			this.#hhd();
		}

		// Token: 0x06006F06 RID: 28422 RVA: 0x001A5EE0 File Offset: 0x001A40E0
		private GridViewLength #qhd(#Wfd #Pc, int #4jb)
		{
			if (this.ExpandLastColumn && #4jb == #Pc.ColumnsCount - 1)
			{
				return new GridViewLength(1.0, GridViewLengthUnitType.Star);
			}
			double num;
			if (#Pc.PixelWidths != null)
			{
				num = \u0006\u0002.\u0014\u0004((double)this.#j.PixelWidths[#4jb] * 1.2);
			}
			else
			{
				TelerikGridRenderer.#BWb #BWb = new TelerikGridRenderer.#BWb();
				#BWb.#a = \u008B\u0002.\u0089\u0005(#Pc.ColumnWidths);
				List<double> list = #Pc.ColumnWidths.Select(new Func<double, double>(#BWb.#UUd)).ToList<double>();
				double num2 = ((#Pc.HeaderRowCount > 0 || #Pc.ForcePreferredWidth) ? #Pc.PreferredWidth : 50.0) / 100.0;
				num = Math.Ceiling(list[#4jb] * this.ReferenceTableWidth * num2 * 1.2);
			}
			if (#4jb <= 0 && #Pc.HeaderRowCount > 1)
			{
				num = \u0011\u0002.\u008B\u0004(num, this.MinCalculateColumnWidth);
			}
			return new GridViewLength(num, GridViewLengthUnitType.Pixel);
		}

		// Token: 0x06006F07 RID: 28423 RVA: 0x001A6008 File Offset: 0x001A4208
		private GridViewLength #rhd(#Wfd #Pc, double #rPc)
		{
			if (!this.#i)
			{
				return new GridViewLength(\u0006\u0002.\u0013\u0004((this.#h - this.Margin) * #rPc), GridViewLengthUnitType.Pixel);
			}
			if (#Pc.WidthType == #rdd.#b)
			{
				return new GridViewLength(\u0006\u0002.\u0013\u0004((this.#h - this.Margin) * #rPc * this.ColumnWidthFactor), GridViewLengthUnitType.Pixel);
			}
			return new GridViewLength(\u0006\u0002.\u0013\u0004(\u0011\u0002.\u008B\u0004(this.ReferenceHeaderLessTableWidth, (this.#h - this.Margin) * #Pc.PreferredWidth / 100.0) * #rPc), GridViewLengthUnitType.Pixel);
		}

		// Token: 0x06006F08 RID: 28424 RVA: 0x00059880 File Offset: 0x00057A80
		private void #shd(#Wfd #Pc)
		{
			if (this.RenderMode == #Igd.#a || this.RenderMode == #Igd.#c)
			{
				this.#thd(#Pc);
				this.#phd();
			}
			this.#vhd(#Pc);
		}

		// Token: 0x06006F09 RID: 28425 RVA: 0x001A60CC File Offset: 0x001A42CC
		private void #thd(#Wfd #Pc)
		{
			if (this.#b.Any<#fgd>())
			{
				return;
			}
			this.#mhd();
			#fgd #fgd = new #fgd();
			#EGd #EGd = #Pc.Rows.FirstOrDefault<#EGd>();
			double num = \u008B\u0002.\u0089\u0005(#Pc.ColumnWidths);
			for (int i = 0; i < #Pc.ColumnsCount; i++)
			{
				string text = GridDataRowCore.#3ed(i);
				double num2 = #Pc.ColumnWidths[i] / num;
				#BGd #BGd = (#EGd != null) ? #EGd.#DGd(i) : new #BGd();
				GridViewLength width = this.#qhd(#Pc, i);
				TelerikGridColumnHeaderData telerikGridColumnHeaderData = new TelerikGridColumnHeaderData
				{
					ItemName = text,
					Column = new GridViewDataColumn
					{
						Header = text,
						Name = text,
						Width = width,
						TextAlignment = this.#zhd(#BGd.Alignment),
						HeaderTextAlignment = this.#zhd(#BGd.Alignment),
						DataMemberBinding = new Binding(text),
						ValidatesOnDataErrors = GridViewValidationMode.None,
						MinWidth = 20.0,
						IsSortable = this.IsGridSortable
					},
					Header = text,
					WidthPercentage = num2,
					StartIndex = i,
					EndIndex = i
				};
				if (this.#d != null && i == 0)
				{
					\u0002\u0003.~\u0099\u0006(telerikGridColumnHeaderData.Column, GridStyleHelper.FirstHeaderlessCellStyle);
				}
				#fgd.Columns.Add(telerikGridColumnHeaderData);
			}
			this.#b.Add(#fgd);
		}

		// Token: 0x06006F0A RID: 28426 RVA: 0x000598B3 File Offset: 0x00057AB3
		private void #uhd(#Wfd #Pc)
		{
			if (this.RenderMode == #Igd.#a || this.RenderMode == #Igd.#c)
			{
				this.#V3c(#Pc);
				this.#phd();
			}
			this.#vhd(#Pc);
		}

		// Token: 0x06006F0B RID: 28427 RVA: 0x001A6258 File Offset: 0x001A4458
		private void #vhd(#Wfd #Pc, IList<GridDataRowCore> #En)
		{
			TelerikGridRenderer.#aFg #aFg = new TelerikGridRenderer.#aFg();
			SolidColorBrush solidColorBrush = new SolidColorBrush(this.#j.CriticalItemsOptions.HighlightColor);
			solidColorBrush.Freeze();
			int num = 0;
			for (int i = #Pc.HeaderRowCount; i < #Pc.Rows.Count; i++)
			{
				GridDataRowCore gridDataRowCore = this.#73c(#Pc.ColumnsCount);
				gridDataRowCore.RowIndex = num;
				gridDataRowCore.EnablePropertyChanged = true;
				num++;
				#EGd #EGd = #Pc.Rows[i];
				if (#EGd.Cells.Count > 0)
				{
					for (int j = 0; j < #Pc.ColumnsCount; j++)
					{
						#BGd #BGd = #EGd.#DGd(j);
						gridDataRowCore.#mfd(j, string.Intern((#BGd != null) ? #BGd.Value : string.Empty));
					}
					#En.Add(gridDataRowCore);
				}
			}
			new #tgd(#En, this.#c, this.SortValuePreprocessor).#sgd(#Pc.ColumnsCount);
			for (int k = 0; k < #En.Count; k++)
			{
				GridDataRowCore #Zhd = #En[k];
				this.#khd(new #Yhd(#Zhd, #Pc, k));
			}
			#0ed #0ed = this.#j.CriticalItemsOptions;
			int num2 = 0;
			#aFg.#a = false;
			for (int l = #Pc.HeaderRowCount; l < #Pc.Rows.Count; l++)
			{
				#EGd #EGd2 = #Pc.Rows[l];
				if (#EGd2.Cells.Count > 0)
				{
					GridDataRowCore gridDataRowCore2 = #En[num2++];
					gridDataRowCore2.Background = this.DefaultRowBackground;
					for (int m = 0; m < #Pc.ColumnsCount; m++)
					{
						#BGd #BGd2 = #EGd2.#DGd(m);
						if (#BGd2 != null && !this.#i && #0ed.Highlight)
						{
							#kgd #kgd = #0ed.Checker.#Spb(gridDataRowCore2, l, #Pc.ColumnsCount, #BGd2);
							#aFg.#a = (#aFg.#a || (#kgd != null && #kgd.Highlight && #kgd.Mode == #ggd.#b));
							gridDataRowCore2.#xfd(#kgd, solidColorBrush, m);
						}
						else if (m == 0 && this.#i && this.#d != null)
						{
							gridDataRowCore2.#ofd(m, this.#d);
							#aFg.#a = true;
						}
						else if (this.#i && #0ed.Highlight && #0ed.Checker.SupportsHeaderlessTables)
						{
							#kgd #kgd2 = #0ed.Checker.#Spb(gridDataRowCore2, l, #Pc.ColumnsCount, #BGd2);
							#aFg.#a = (#aFg.#a || (#kgd2 != null && #kgd2.Highlight && #kgd2.Mode == #ggd.#b));
							gridDataRowCore2.#xfd(#kgd2, solidColorBrush, m);
							break;
						}
					}
				}
			}
			#En.#I1d(new Action<GridDataRowCore>(#aFg.#VUd));
		}

		// Token: 0x06006F0C RID: 28428 RVA: 0x001A6554 File Offset: 0x001A4754
		private void #whd(#Wfd #Pc)
		{
			int num = 0;
			while (num < #Pc.ColumnsCount && num < \u0003\u0003.~\u009C\u0006(this.#c).Count)
			{
				\u0007\u0003.~\u0003\u0007(\u0003\u0003.~\u009C\u0006(this.#c)[num], GridDataRowCore.#2ed(num));
				num++;
			}
		}

		// Token: 0x06006F0D RID: 28429 RVA: 0x001A65BC File Offset: 0x001A47BC
		private bool #xhd(IList<GridDataRowCore> #yhd, IList<GridDataRowCore> #h4c)
		{
			if (#yhd.Count != #h4c.Count)
			{
				return false;
			}
			if (#yhd.Count <= 0)
			{
				return false;
			}
			if (#yhd[0].GetType() != #h4c[0].GetType())
			{
				return false;
			}
			int count = this.#c.Columns.Count;
			for (int i = 0; i < #yhd.Count; i++)
			{
				GridDataRowCore gridDataRowCore = #yhd[i];
				GridDataRowCore gridDataRowCore2 = #h4c[i];
				for (int j = 0; j < count; j++)
				{
					string a = gridDataRowCore.#nfd(j);
					string b = gridDataRowCore2.#nfd(j);
					if (!string.Equals(a, b, StringComparison.Ordinal))
					{
						gridDataRowCore.#mfd(j, b);
						gridDataRowCore.#1gc(#8ed.#3ed(j));
						gridDataRowCore.#kfd(j, gridDataRowCore2.#lfd(j));
						gridDataRowCore.#1gc(#8ed.#2ed(j));
						gridDataRowCore.#ofd(j, gridDataRowCore2.#qfd(new int?(j)));
						gridDataRowCore.#1gc(#8ed.#4ed(j));
					}
				}
				gridDataRowCore.Background = gridDataRowCore2.Background;
			}
			return true;
		}

		// Token: 0x06006F0E RID: 28430 RVA: 0x001A66F0 File Offset: 0x001A48F0
		private void #vhd(#Wfd #Pc)
		{
			switch (this.RenderMode)
			{
			case #Igd.#a:
				this.#f.Clear();
				this.#f.EnsureTotalCapacity(#Pc.Rows.Count);
				this.#vhd(#Pc, this.#f);
				if (this.ReuseRows && this.#xhd(this.#e, this.#f))
				{
					this.#whd(#Pc);
					return;
				}
				this.#e.#NBc();
				this.#e.Clear();
				this.#e.#x7c(#Pc.Rows.Count + 1);
				this.#e.#pR(this.#f);
				this.#whd(#Pc);
				this.#e.#OBc();
				\u0007.~\u0015(this.#c);
				\u0007.~\u0016(this.#c);
				return;
			case #Igd.#b:
				this.#f.Clear();
				this.#f.EnsureTotalCapacity(#Pc.Rows.Count);
				this.#vhd(#Pc, this.#f);
				return;
			case #Igd.#c:
			{
				this.#e.#NBc();
				this.#e.Clear();
				this.#e.#x7c(this.#f.Count);
				this.#e.#G7c(this.#f);
				this.#f.Clear();
				this.#f.Capacity = 1;
				this.#whd(#Pc);
				#Pc.Rows.Clear();
				List<#EGd> list = #Pc.Rows as List<#EGd>;
				if (list != null)
				{
					list.Capacity = 1;
				}
				this.#e.#OBc();
				\u0007.~\u0015(this.#c);
				\u0007.~\u0016(this.#c);
				return;
			}
			default:
				throw new ArgumentOutOfRangeException();
			}
		}

		// Token: 0x06006F0F RID: 28431 RVA: 0x001A68E0 File Offset: 0x001A4AE0
		private TextAlignment #zhd(ParagraphAlignment #rT)
		{
			switch (#rT)
			{
			case ParagraphAlignment.Left:
				return TextAlignment.Left;
			case ParagraphAlignment.Center:
				return TextAlignment.Center;
			case ParagraphAlignment.Right:
				return TextAlignment.Right;
			case ParagraphAlignment.Justify:
				return TextAlignment.Justify;
			case ParagraphAlignment.Distributed:
			case ParagraphAlignment.ArabicMediumKashida:
			case ParagraphAlignment.ArabicHighKashida:
			case ParagraphAlignment.ArabicLowKashida:
			case ParagraphAlignment.ThaiDistributed:
				throw new NotSupportedException(#Phc.#3hc(107252730));
			}
			throw new ArgumentOutOfRangeException(#Phc.#3hc(107252649), #rT, null);
		}

		// Token: 0x06006F10 RID: 28432 RVA: 0x001A6958 File Offset: 0x001A4B58
		private System.Windows.Style #Ahd(ParagraphAlignment #Bhd)
		{
			switch (#Bhd)
			{
			case ParagraphAlignment.Left:
				return (this.EnableBoldHeaders ? this.#l : this.#o) ?? GridStyleHelper.LeftColumnGroupStyle;
			case ParagraphAlignment.Center:
				return (this.EnableBoldHeaders ? this.#m : this.#p) ?? GridStyleHelper.CenterColumnGroupStyle;
			case ParagraphAlignment.Right:
				return (this.EnableBoldHeaders ? this.#n : this.#q) ?? GridStyleHelper.RightColumnGroupStyle;
			case ParagraphAlignment.Justify:
			case ParagraphAlignment.Distributed:
			case ParagraphAlignment.ArabicMediumKashida:
			case ParagraphAlignment.ArabicHighKashida:
			case ParagraphAlignment.ArabicLowKashida:
			case ParagraphAlignment.ThaiDistributed:
				throw new NotSupportedException(#Phc.#3hc(107252730));
			}
			throw new ArgumentOutOfRangeException(#Phc.#3hc(107252668), #Bhd, null);
		}

		// Token: 0x06006F11 RID: 28433 RVA: 0x001A6A3C File Offset: 0x001A4C3C
		private void #V3c(#Wfd #Pc)
		{
			if (this.#b.Any<#fgd>())
			{
				return;
			}
			#fgd #fgd = null;
			double num = \u008B\u0002.\u0089\u0005(#Pc.ColumnWidths);
			int num2 = 0;
			while (num2 < #Pc.HeaderRowCount && num2 < #Pc.Rows.Count)
			{
				#fgd #fgd2 = new #fgd();
				this.#b.Add(#fgd2);
				bool flag = num2 == #Pc.HeaderRowCount - 1;
				#EGd #EGd = #Pc.Rows[num2];
				if (#EGd.Cells.Count > 0)
				{
					for (int i = 0; i < #EGd.Cells.Count; i++)
					{
						#BGd #BGd = #EGd.Cells[i];
						if (flag)
						{
							string text = GridDataRowCore.#3ed(i);
							double num3 = #Pc.ColumnWidths[i] / num;
							GridViewLength width = this.#qhd(#Pc, i);
							bool flag2 = this.EnableBoldHeaders && num2 < this.#j.NumberOfBoldHeaderRows;
							System.Windows.Style style = flag2 ? this.#r : this.#s;
							if (style == null)
							{
								style = (flag2 ? GridStyleHelper.BoldHeaderCellStyle : GridStyleHelper.ThinHeaderCellStyle);
							}
							TelerikGridColumnHeaderData telerikGridColumnHeaderData = new TelerikGridColumnHeaderData
							{
								ItemName = text,
								Column = new GridViewDataColumn
								{
									Header = #BGd.Value,
									Name = text,
									Width = width,
									TextAlignment = this.#zhd(#BGd.Alignment),
									HeaderTextAlignment = this.#zhd(#BGd.Alignment),
									DataMemberBinding = new Binding(text),
									ValidatesOnDataErrors = GridViewValidationMode.None,
									MinWidth = 20.0,
									HeaderCellStyle = style,
									IsSortable = this.IsGridSortable
								},
								Header = #BGd.Value,
								WidthPercentage = num3,
								StartIndex = #BGd.CellIndex,
								EndIndex = #BGd.CellIndex + #BGd.Merge - 1
							};
							if (#fgd != null)
							{
								TelerikGridColumnHeaderData telerikGridColumnHeaderData2 = #fgd.#egd(#BGd.CellIndex);
								if (telerikGridColumnHeaderData2 != null && telerikGridColumnHeaderData2.Group != null)
								{
									\u0007\u0003.~\u0004\u0007(telerikGridColumnHeaderData.Column, \u007F.~\u0015\u0002(telerikGridColumnHeaderData2.Group));
								}
							}
							#fgd2.Columns.Add(telerikGridColumnHeaderData);
						}
						else
						{
							string name = \u0005.\u0007(#Phc.#3hc(107252611), num2, i);
							TelerikGridColumnHeaderData telerikGridColumnHeaderData3 = new TelerikGridColumnHeaderData
							{
								ItemName = name,
								Group = new GridViewColumnGroup
								{
									Header = #BGd.Value,
									Name = name,
									HeaderStyle = this.#Ahd(#BGd.Alignment)
								},
								Header = #BGd.Value,
								StartIndex = #BGd.CellIndex,
								EndIndex = #BGd.CellIndex + #BGd.Merge - 1
							};
							if (#fgd != null)
							{
								TelerikGridColumnHeaderData telerikGridColumnHeaderData4 = #fgd.#egd(#BGd.CellIndex);
								if (telerikGridColumnHeaderData4 != null && telerikGridColumnHeaderData4.Group != null)
								{
									\u0004\u0003.~\u009E\u0006(telerikGridColumnHeaderData4.Group).Add(telerikGridColumnHeaderData3.Group);
								}
							}
							#fgd2.Columns.Add(telerikGridColumnHeaderData3);
						}
					}
					#fgd = #fgd2;
				}
				num2++;
			}
		}

		// Token: 0x06006F12 RID: 28434 RVA: 0x001A6D8C File Offset: 0x001A4F8C
		[CompilerGenerated]
		private void #P3h()
		{
			try
			{
				\u0010\u0003.\u0017\u0007(this.#c, ScrollBarVisibility.Disabled);
				\u0010\u0003.\u0017\u0007(this.#c, ScrollBarVisibility.Auto);
			}
			catch (Exception value)
			{
				Console.WriteLine(value);
			}
			finally
			{
				this.#g.#ZXd();
			}
		}

		// Token: 0x04002C9A RID: 11418
		private const double #a = 20.0;

		// Token: 0x04002C9B RID: 11419
		private readonly List<#fgd> #b = new List<#fgd>();

		// Token: 0x04002C9C RID: 11420
		private readonly RadGridView #c;

		// Token: 0x04002C9D RID: 11421
		private readonly SolidColorBrush #d;

		// Token: 0x04002C9E RID: 11422
		private readonly CustomObservableCollection<GridDataRowCore> #e = new CustomObservableCollection<GridDataRowCore>();

		// Token: 0x04002C9F RID: 11423
		private readonly List<GridDataRowCore> #f = new List<GridDataRowCore>();

		// Token: 0x04002CA0 RID: 11424
		private readonly NonBlockingLock #g = new NonBlockingLock();

		// Token: 0x04002CA1 RID: 11425
		private double #h = 400.0;

		// Token: 0x04002CA2 RID: 11426
		private bool #i;

		// Token: 0x04002CA3 RID: 11427
		private #Wfd #j;

		// Token: 0x04002CA4 RID: 11428
		private bool #k;

		// Token: 0x04002CA5 RID: 11429
		private System.Windows.Style #l;

		// Token: 0x04002CA6 RID: 11430
		private System.Windows.Style #m;

		// Token: 0x04002CA7 RID: 11431
		private System.Windows.Style #n;

		// Token: 0x04002CA8 RID: 11432
		private System.Windows.Style #o;

		// Token: 0x04002CA9 RID: 11433
		private System.Windows.Style #p;

		// Token: 0x04002CAA RID: 11434
		private System.Windows.Style #q;

		// Token: 0x04002CAB RID: 11435
		private System.Windows.Style #r;

		// Token: 0x04002CAC RID: 11436
		private System.Windows.Style #s;

		// Token: 0x04002CAD RID: 11437
		[CompilerGenerated]
		private EventHandler<#Yhd> #t;

		// Token: 0x04002CAE RID: 11438
		[CompilerGenerated]
		private readonly #7Fd #u;

		// Token: 0x04002CAF RID: 11439
		[CompilerGenerated]
		private Brush #v;

		// Token: 0x04002CB0 RID: 11440
		[CompilerGenerated]
		private Brush #w;

		// Token: 0x04002CB1 RID: 11441
		[CompilerGenerated]
		private Brush #x;

		// Token: 0x04002CB2 RID: 11442
		[CompilerGenerated]
		private bool #y;

		// Token: 0x04002CB3 RID: 11443
		[CompilerGenerated]
		private double? #z;

		// Token: 0x04002CB4 RID: 11444
		[CompilerGenerated]
		private bool #A;

		// Token: 0x04002CB5 RID: 11445
		[CompilerGenerated]
		private bool #B;

		// Token: 0x04002CB6 RID: 11446
		[CompilerGenerated]
		private double #C;

		// Token: 0x04002CB7 RID: 11447
		[CompilerGenerated]
		private double #D;

		// Token: 0x04002CB8 RID: 11448
		[CompilerGenerated]
		private double #E;

		// Token: 0x04002CB9 RID: 11449
		[CompilerGenerated]
		private double #F;

		// Token: 0x04002CBA RID: 11450
		[CompilerGenerated]
		private double #G;

		// Token: 0x04002CBB RID: 11451
		[CompilerGenerated]
		private #ogd #H;

		// Token: 0x04002CBC RID: 11452
		[CompilerGenerated]
		private bool #I;

		// Token: 0x04002CBD RID: 11453
		[CompilerGenerated]
		private bool #J;

		// Token: 0x04002CBE RID: 11454
		[CompilerGenerated]
		private #Igd #K;

		// Token: 0x04002CBF RID: 11455
		[CompilerGenerated]
		private bool #L;

		// Token: 0x04002CC0 RID: 11456
		[CompilerGenerated]
		private Thickness #M = new Thickness(2.0);

		// Token: 0x02000D2C RID: 3372
		[CompilerGenerated]
		private sealed class #Fzf
		{
			// Token: 0x06006F1B RID: 28443 RVA: 0x00059929 File Offset: 0x00057B29
			internal bool #OUd(#fgd #Rf, int #4jb)
			{
				return #Rf.Columns.Count == this.#a.Rows[#4jb].Cells.Count;
			}

			// Token: 0x04002CC7 RID: 11463
			public #Wfd #a;
		}

		// Token: 0x02000D2D RID: 3373
		[CompilerGenerated]
		private sealed class #BWb
		{
			// Token: 0x06006F1D RID: 28445 RVA: 0x0005995F File Offset: 0x00057B5F
			internal double #UUd(double #Rf)
			{
				return #Rf / this.#a;
			}

			// Token: 0x04002CC8 RID: 11464
			public double #a;
		}

		// Token: 0x02000D2E RID: 3374
		[CompilerGenerated]
		private sealed class #aFg
		{
			// Token: 0x06006F1F RID: 28447 RVA: 0x00059971 File Offset: 0x00057B71
			internal void #VUd(GridDataRowCore #Rf)
			{
				#Rf.AnyRowHasCustomBackground = this.#a;
			}

			// Token: 0x04002CC9 RID: 11465
			public bool #a;
		}
	}
}
