using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using #7hc;
using Microsoft.VisualBasic;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Basic
{
	// Token: 0x02000AC5 RID: 2757
	public static class WpfGridHelper
	{
		// Token: 0x060059C6 RID: 22982 RVA: 0x0004A8E0 File Offset: 0x00048AE0
		public static string GetGridColumns(Grid control)
		{
			return Convert.ToString(control.GetValue(WpfGridHelper.GridColumnsProperty));
		}

		// Token: 0x060059C7 RID: 22983 RVA: 0x0004A8FE File Offset: 0x00048AFE
		public static void SetGridColumns(Grid control, string value)
		{
			control.SetValue(WpfGridHelper.GridColumnsProperty, value);
		}

		// Token: 0x060059C8 RID: 22984 RVA: 0x0004A918 File Offset: 0x00048B18
		private static void GridColumnsPropertyChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			Grid grid = sender as Grid;
			if (grid == null)
			{
				throw new Exception(#Phc.#3hc(107425603));
			}
			WpfGridHelper.DefineGridColumns(grid);
		}

		// Token: 0x060059C9 RID: 22985 RVA: 0x0016DB68 File Offset: 0x0016BD68
		private static void DefineGridColumns(Grid This)
		{
			string[] array = WpfGridHelper.GetGridColumns(This).Split(new char[]
			{
				Convert.ToChar(#Phc.#3hc(107408397))
			});
			This.ColumnDefinitions.Clear();
			foreach (string text in array)
			{
				string a = text.Trim().ToLower();
				if (!(a == #Phc.#3hc(107425018)))
				{
					if (!(a == #Phc.#3hc(107425009)))
					{
						if (Regex.IsMatch(text, #Phc.#3hc(107424972)))
						{
							This.ColumnDefinitions.Add(new ColumnDefinition
							{
								Width = new GridLength((double)Convert.ToInt32(text.Substring(0, text.IndexOf(Convert.ToChar(#Phc.#3hc(107425009))))), GridUnitType.Star)
							});
						}
						else
						{
							if (!Information.IsNumeric(text))
							{
								throw new Exception(#Phc.#3hc(107424991) + Environment.NewLine + Environment.NewLine + #Phc.#3hc(107424817));
							}
							This.ColumnDefinitions.Add(new ColumnDefinition
							{
								Width = new GridLength(Convert.ToDouble(text), GridUnitType.Pixel)
							});
						}
					}
					else
					{
						This.ColumnDefinitions.Add(new ColumnDefinition
						{
							Width = new GridLength(1.0, GridUnitType.Star)
						});
					}
				}
				else
				{
					This.ColumnDefinitions.Add(new ColumnDefinition
					{
						Width = new GridLength(1.0, GridUnitType.Auto)
					});
				}
			}
		}

		// Token: 0x0400257D RID: 9597
		public static DependencyProperty GridColumnsProperty = DependencyProperty.RegisterAttached(#Phc.#3hc(107425167), typeof(string), typeof(WpfGridHelper), new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.AffectsArrange, new PropertyChangedCallback(WpfGridHelper.GridColumnsPropertyChanged)));
	}
}
