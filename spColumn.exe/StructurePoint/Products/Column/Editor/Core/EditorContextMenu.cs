using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using #7hc;
using #RJb;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.GUI.DesktopControls.Menu;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.Products.Column.Resources.Images;
using Telerik.Windows.Controls;
using Telerik.Windows.Data;

namespace StructurePoint.Products.Column.Editor.Core
{
	// Token: 0x0200066B RID: 1643
	internal sealed class EditorContextMenu : #dLb
	{
		// Token: 0x0600374B RID: 14155 RVA: 0x0010CBEC File Offset: 0x0010ADEC
		public EditorContextMenu()
		{
			this.<ContextMenuItems>k__BackingField = new RadObservableCollection<RadMenuItem>();
			base..ctor();
			if (Application.Current != null)
			{
				this.Initialize();
				this.contextMenu.ContextMenuOpening += this.ContextMenu_ContextMenuOpening;
				this.contextMenu.Closed += this.ContextMenu_Closed;
			}
		}

		// Token: 0x1700112B RID: 4395
		// (get) Token: 0x0600374C RID: 14156 RVA: 0x000301F5 File Offset: 0x0002E3F5
		public RadObservableCollection<RadMenuItem> ContextMenuItems { get; }

		// Token: 0x1700112C RID: 4396
		// (get) Token: 0x0600374D RID: 14157 RVA: 0x00030201 File Offset: 0x0002E401
		public static ContextMenuItemData UndoItemData { get; } = new ContextMenuItemData(#Phc.#3hc(107351723), #Phc.#3hc(107351714));

		// Token: 0x1700112D RID: 4397
		// (get) Token: 0x0600374E RID: 14158 RVA: 0x00030208 File Offset: 0x0002E408
		public static ContextMenuItemData AddToReportItemData { get; } = new ContextMenuItemData(#Phc.#3hc(107383426), #Phc.#3hc(107351733));

		// Token: 0x1700112E RID: 4398
		// (get) Token: 0x0600374F RID: 14159 RVA: 0x0003020F File Offset: 0x0002E40F
		public static ContextMenuItemData PrintExportItemData { get; } = new ContextMenuItemData(#Phc.#3hc(107351688), #Phc.#3hc(107351699));

		// Token: 0x06003750 RID: 14160 RVA: 0x00030216 File Offset: 0x0002E416
		public void SetupContextMenu(ColumnEditor editor)
		{
			this.EnableContextMenu();
			RadContextMenu.SetContextMenu(editor, this.contextMenu);
			this.contextMenu.EventName = #Phc.#3hc(107352364);
		}

		// Token: 0x06003751 RID: 14161 RVA: 0x0010CC5C File Offset: 0x0010AE5C
		public void SetupSelectScopeMenu(bool shouldShowArrange)
		{
			RadMenuItem item2 = this.ContextMenuItems.FirstOrDefault((RadMenuItem item) => item.Tag != null && item.Tag.Equals(EditorContextMenuCommands.#i));
			int num = this.ContextMenuItems.IndexOf(item2);
			if (num < 0)
			{
				return;
			}
			for (int i = num + 1; i < this.ContextMenuItems.Count; i++)
			{
				RadMenuItem radMenuItem = this.ContextMenuItems[i];
				radMenuItem.Visibility = (shouldShowArrange ? Visibility.Visible : Visibility.Collapsed);
			}
		}

		// Token: 0x06003752 RID: 14162 RVA: 0x0003024B File Offset: 0x0002E44B
		public void EnableContextMenu()
		{
			this.contextMenu.Visibility = Visibility.Visible;
		}

		// Token: 0x06003753 RID: 14163 RVA: 0x00030261 File Offset: 0x0002E461
		public void DisableContextMenu()
		{
			this.contextMenu.Visibility = Visibility.Collapsed;
		}

		// Token: 0x06003754 RID: 14164 RVA: 0x00030277 File Offset: 0x0002E477
		public void ResetContextMenu()
		{
			this.contextMenu.IsOpen = false;
			this.UpdateSelectCheckState(false);
		}

		// Token: 0x06003755 RID: 14165 RVA: 0x0010CCF0 File Offset: 0x0010AEF0
		public void UpdateSelectCheckState(bool selectChecked)
		{
			RadMenuItem radMenuItem = this.ContextMenuItems.FirstOrDefault((RadMenuItem item) => item.Tag != null && item.Tag.Equals(EditorContextMenuCommands.#a));
			if (radMenuItem != null)
			{
				radMenuItem.IsChecked = selectChecked;
			}
			Visibility visibility = selectChecked ? Visibility.Visible : Visibility.Collapsed;
			foreach (RadMenuItem radMenuItem2 in this.ContextMenuItems.Skip(4))
			{
				radMenuItem2.Visibility = visibility;
			}
		}

		// Token: 0x06003756 RID: 14166 RVA: 0x0010CD98 File Offset: 0x0010AF98
		public void SetupCommand(EditorContextMenuCommands command, Action<object> action, Predicate<object> predicate)
		{
			RadMenuItem radMenuItem = this.ContextMenuItems.FirstOrDefault((RadMenuItem item) => item.Tag != null && item.Tag.Equals(command)) ?? this.moreSelectCommands.FirstOrDefault((RadMenuItem item) => item.Tag != null && item.Tag.Equals(command));
			if (radMenuItem != null)
			{
				radMenuItem.Command = new DelegateCommand(action, predicate);
			}
		}

		// Token: 0x06003757 RID: 14167 RVA: 0x0010CE04 File Offset: 0x0010B004
		public bool MenuHasJustClosed()
		{
			return (DateTime.Now - this.lastMenuCloseDateTime).TotalMilliseconds < 250.0;
		}

		// Token: 0x06003758 RID: 14168 RVA: 0x0010CE40 File Offset: 0x0010B040
		public void ChangeSectionType(SectionType type)
		{
			int count = this.ContextMenuItems.Count;
			if (type == SectionType.Irregular)
			{
				this.ContextMenuItems.#mbb(0, delegate(RadMenuItem x)
				{
					x.Visibility = Visibility.Visible;
				});
				this.ContextMenuItems[count - 2].Visibility = Visibility.Collapsed;
				this.ContextMenuItems[count - 1].Visibility = Visibility.Collapsed;
				return;
			}
			this.ContextMenuItems.#mbb(0, delegate(RadMenuItem x)
			{
				x.Visibility = Visibility.Collapsed;
			});
			this.EnableVisibility(EditorContextMenuCommands.#b);
			this.EnableVisibility(EditorContextMenuCommands.#c);
			this.ContextMenuItems[count - 2].Visibility = Visibility.Visible;
			this.ContextMenuItems[count - 1].Visibility = Visibility.Visible;
		}

		// Token: 0x06003759 RID: 14169 RVA: 0x00030298 File Offset: 0x0002E498
		private void ContextMenu_Closed(object sender, RoutedEventArgs e)
		{
			this.lastMenuCloseDateTime = DateTime.Now;
		}

		// Token: 0x0600375A RID: 14170 RVA: 0x000302AD File Offset: 0x0002E4AD
		private void ContextMenu_ContextMenuOpening(object sender, ContextMenuEventArgs e)
		{
			this.InvalidateCommands();
		}

		// Token: 0x0600375B RID: 14171 RVA: 0x0010CF30 File Offset: 0x0010B130
		private void EnableVisibility(EditorContextMenuCommands menuCommand)
		{
			RadMenuItem radMenuItem = this.ContextMenuItems.SingleOrDefault((RadMenuItem x) => x.Tag != null && x.Tag.Equals(menuCommand));
			if (radMenuItem != null)
			{
				radMenuItem.Visibility = Visibility.Visible;
			}
		}

		// Token: 0x0600375C RID: 14172 RVA: 0x000302BD File Offset: 0x0002E4BD
		private void Initialize()
		{
			this.SetupContextMenuItems();
			this.contextMenu = new RadContextMenu
			{
				ItemsSource = this.ContextMenuItems
			};
		}

		// Token: 0x0600375D RID: 14173 RVA: 0x0010CF78 File Offset: 0x0010B178
		private void SetupContextMenuItems()
		{
			this.ContextMenuItems.Add(this.NewItem(EditorContextMenuCommands.#a, ColumnImages.Select_24X24, new ContextMenuItemData(Strings.StringSelect)));
			this.ContextMenuItems.Add(new RadMenuItem
			{
				IsSeparator = true
			});
			this.ContextMenuItems.Add(this.NewItem(EditorContextMenuCommands.#b, ColumnImages.Undo_24X24, EditorContextMenu.UndoItemData));
			this.ContextMenuItems.Add(this.NewItem(EditorContextMenuCommands.#c, ColumnImages.Redo_24X24, new ContextMenuItemData(#Phc.#3hc(107352335), #Phc.#3hc(107352326))));
			this.ContextMenuItems.Add(new RadMenuItem
			{
				IsSeparator = true
			});
			this.SetupSelectCommands();
		}

		// Token: 0x0600375E RID: 14174 RVA: 0x0010D044 File Offset: 0x0010B244
		private void SetupSelectCommands()
		{
			this.ContextMenuItems.Add(this.NewItem(EditorContextMenuCommands.#s, ColumnImages.Delete_24X24, new ContextMenuItemData(Strings.StringDelete)));
			this.ContextMenuItems.Add(this.NewItem(EditorContextMenuCommands.#j, ColumnImages.Move_24X24, new ContextMenuItemData(Strings.StringMove)));
			this.ContextMenuItems.Add(this.NewItem(EditorContextMenuCommands.#m, ColumnImages.Rotate_24X24, new ContextMenuItemData(Strings.StringRotate)));
			this.ContextMenuItems.Add(this.NewItem(EditorContextMenuCommands.#l, ColumnImages.Mirror_24X24, new ContextMenuItemData(Strings.StringMirror)));
			this.ContextMenuItems.Add(this.NewItem(EditorContextMenuCommands.#k, ColumnImages.Copy_24X24, new ContextMenuItemData(Strings.StringDuplicate)));
			this.ContextMenuItems.Add(new RadMenuItem
			{
				Header = new ContextMenuItemData(Strings.StringMore, null),
				HorizontalContentAlignment = HorizontalAlignment.Stretch,
				MinHeight = 30.0,
				HeaderTemplate = (DataTemplate)Application.Current.FindResource(#Phc.#3hc(107352345)),
				Template = (ControlTemplate)Application.Current.FindResource(#Phc.#3hc(107351792))
			});
			this.ContextMenuItems.Last<RadMenuItem>().ItemsSource = this.moreSelectCommands;
			this.moreSelectCommands.Add(this.NewItem(EditorContextMenuCommands.#n, ColumnImages.Merge_24X24, new ContextMenuItemData(Strings.StringShapesMerge)));
			this.moreSelectCommands.Add(this.NewItem(EditorContextMenuCommands.#o, ColumnImages.Offset_24X24, new ContextMenuItemData(Strings.StringShapesOffset)));
			this.moreSelectCommands.Add(this.NewItem(EditorContextMenuCommands.#p, ColumnImages.Split_24X24, new ContextMenuItemData(Strings.StringShapesSplit)));
			this.moreSelectCommands.Add(new RadMenuItem
			{
				IsSeparator = true
			});
			this.moreSelectCommands.Add(this.NewItem(EditorContextMenuCommands.#q, ColumnImages.AlignVertical_24X24, new ContextMenuItemData(Strings.StringAlignVertical)));
			this.moreSelectCommands.Add(this.NewItem(EditorContextMenuCommands.#r, ColumnImages.AlignHorizontal_24X24, new ContextMenuItemData(Strings.StringAlignHorizontal)));
			this.ContextMenuItems.Add(new RadMenuItem
			{
				IsSeparator = true
			});
			this.ContextMenuItems.Add(this.NewItem(EditorContextMenuCommands.#u, ColumnImages.SendToIrregular_24X24, new ContextMenuItemData(Strings.StringSendToIrregularSection)));
		}

		// Token: 0x0600375F RID: 14175 RVA: 0x0010D2A0 File Offset: 0x0010B4A0
		private void InvalidateCommands()
		{
			foreach (RadMenuItem radMenuItem in this.ContextMenuItems)
			{
				DelegateCommand delegateCommand = (DelegateCommand)radMenuItem.Command;
				if (delegateCommand != null)
				{
					delegateCommand.InvalidateCanExecute();
				}
			}
			foreach (RadMenuItem radMenuItem2 in this.moreSelectCommands)
			{
				DelegateCommand delegateCommand2 = (DelegateCommand)radMenuItem2.Command;
				if (delegateCommand2 != null)
				{
					delegateCommand2.InvalidateCanExecute();
				}
			}
		}

		// Token: 0x06003760 RID: 14176 RVA: 0x0010D364 File Offset: 0x0010B564
		private RadMenuItem NewItem(EditorContextMenuCommands command, ImageSource image, ContextMenuItemData header)
		{
			RadMenuItem radMenuItem = new RadMenuItem
			{
				Header = header,
				MinHeight = 30.0,
				Tag = command,
				HorizontalContentAlignment = HorizontalAlignment.Stretch,
				HeaderTemplate = (DataTemplate)Application.Current.FindResource(#Phc.#3hc(107352345)),
				Template = (ControlTemplate)Application.Current.FindResource(#Phc.#3hc(107351792))
			};
			if (image != null)
			{
				double num = 24.0;
				radMenuItem.Icon = new Image
				{
					Source = image,
					UseLayoutRounding = true,
					Width = num,
					Height = num
				};
			}
			else
			{
				radMenuItem.IconColumnWidth = 0.0;
			}
			return radMenuItem;
		}

		// Token: 0x04001710 RID: 5904
		private const double minHeight = 30.0;

		// Token: 0x04001711 RID: 5905
		private RadContextMenu contextMenu;

		// Token: 0x04001712 RID: 5906
		private DateTime lastMenuCloseDateTime = DateTime.MinValue;

		// Token: 0x04001713 RID: 5907
		private readonly ObservableCollection<RadMenuItem> moreSelectCommands = new ObservableCollection<RadMenuItem>();
	}
}
