using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using #7hc;
using #ezc;
using #J6d;
using #v1c;
using Alphaleonis.Win32.Filesystem;
using Microsoft.Win32;
using Ookii.Dialogs.Wpf;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using Vanara.PInvoke;

namespace StructurePoint.CoreAssets.GUI.Framework.IO
{
	// Token: 0x02000CBE RID: 3262
	public sealed class FileSystemService : #v2c
	{
		// Token: 0x06006A6A RID: 27242 RVA: 0x0019CD88 File Offset: 0x0019AF88
		public void #u3h(string #Ic, string #G)
		{
			if (string.IsNullOrWhiteSpace(#Ic))
			{
				throw new ArgumentNullException(#Phc.#3hc(107457469));
			}
			if (string.IsNullOrWhiteSpace(#G))
			{
				throw new ArgumentNullException(#Phc.#3hc(107451578));
			}
			if (string.Equals(#Ic, #G, StringComparison.OrdinalIgnoreCase))
			{
				throw new ArgumentException(#Phc.#3hc(107430577).#z2d());
			}
			if (!Alphaleonis.Win32.Filesystem.File.Exists(#Ic))
			{
				throw new ArgumentException(#Phc.#3hc(107430500).#z2d());
			}
			if (Alphaleonis.Win32.Filesystem.File.Exists(#G))
			{
				Alphaleonis.Win32.Filesystem.FileInfo fileInfo = new Alphaleonis.Win32.Filesystem.FileInfo(#G);
				Alphaleonis.Win32.Filesystem.FileInfo fileInfo2;
				if (2 != 0)
				{
					fileInfo2 = fileInfo;
				}
				if (fileInfo2.IsReadOnly)
				{
					Alphaleonis.Win32.Filesystem.FileInfo fileInfo3 = fileInfo2;
					bool isReadOnly = false;
					if (!false)
					{
						fileInfo3.IsReadOnly = isReadOnly;
					}
				}
				if (5 != 0)
				{
					Alphaleonis.Win32.Filesystem.File.Delete(#G);
				}
			}
			bool overwrite = true;
			if (6 != 0)
			{
				Alphaleonis.Win32.Filesystem.File.Copy(#Ic, #G, overwrite);
			}
			DateTime now = DateTime.Now;
			DateTime dateTime;
			if (!false)
			{
				dateTime = now;
			}
			DateTime creationTime = dateTime;
			DateTime lastAccessTime = dateTime;
			DateTime lastWriteTime = dateTime;
			if (!false)
			{
				Alphaleonis.Win32.Filesystem.File.SetTimestamps(#G, creationTime, lastAccessTime, lastWriteTime);
			}
		}

		// Token: 0x06006A6B RID: 27243 RVA: 0x0019CE68 File Offset: 0x0019B068
		public string #M1c(string #2o, string #N1c = "")
		{
			int num = string.IsNullOrWhiteSpace(#2o) ? 1 : 0;
			IL_06:
			while (num == 0)
			{
				char[] invalidFileNameChars = Alphaleonis.Win32.Filesystem.Path.GetInvalidFileNameChars();
				char[] array;
				if (!false)
				{
					array = invalidFileNameChars;
				}
				int num2 = 0;
				int num3;
				if (8 != 0)
				{
					num3 = num2;
				}
				for (;;)
				{
					int num4 = num3;
					int num5 = array.Length;
					int num6;
					do
					{
						num6 = (num5 = num5);
					}
					while (false);
					if (num4 >= num6)
					{
						break;
					}
					char c = array[num3];
					char c2;
					if (4 != 0)
					{
						c2 = c;
					}
					string text = #2o.Replace(c2.ToString(), #N1c);
					if (8 != 0)
					{
						#2o = text;
					}
					if (7 != 0)
					{
						int num7 = num = num3;
						if (8 == 0)
						{
							goto IL_06;
						}
						int num8 = num7 + 1;
						if (2 != 0)
						{
							num3 = num8;
						}
					}
				}
				return #2o;
			}
			return #2o;
		}

		// Token: 0x06006A6C RID: 27244 RVA: 0x0019CED0 File Offset: 0x0019B0D0
		public string #O1c(string #So, string #P1c)
		{
			if (string.IsNullOrWhiteSpace(#So))
			{
				return #P1c;
			}
			bool flag3;
			for (;;)
			{
				bool flag;
				if (!string.IsNullOrWhiteSpace(#So))
				{
					flag = Alphaleonis.Win32.Filesystem.Directory.Exists(#So);
					goto IL_33;
				}
				goto IL_35;
				IL_14:
				string text;
				bool flag2 = flag = (flag3 = string.Equals(#So, text));
				if (8 == 0)
				{
					goto IL_3E;
				}
				if (flag2)
				{
					goto IL_35;
				}
				string text2 = text;
				if (false)
				{
					continue;
				}
				#So = text2;
				continue;
				IL_33:
				if (!flag)
				{
					string directoryName = Alphaleonis.Win32.Filesystem.Path.GetDirectoryName(#So);
					if (-1 == 0)
					{
						goto IL_14;
					}
					text = directoryName;
					goto IL_14;
				}
				IL_35:
				if (false)
				{
					goto IL_14;
				}
				flag3 = (flag = string.IsNullOrWhiteSpace(#So));
				IL_3E:
				if (!false)
				{
					break;
				}
				goto IL_33;
			}
			if (flag3 || !Alphaleonis.Win32.Filesystem.Directory.Exists(#So))
			{
				return #P1c;
			}
			return #So;
		}

		// Token: 0x06006A6D RID: 27245 RVA: 0x0019CF34 File Offset: 0x0019B134
		public string[] #Q1c(#12c #R1c)
		{
			if (#R1c == null || false)
			{
				throw new ArgumentNullException(#Phc.#3hc(107430471));
			}
			Microsoft.Win32.OpenFileDialog openFileDialog = this.#r2c(#R1c, true);
			Microsoft.Win32.OpenFileDialog openFileDialog2;
			if (7 != 0)
			{
				openFileDialog2 = openFileDialog;
			}
			Window window;
			if ((window = (#R1c.Owner as Window)) == null)
			{
				window = this.#q2c();
			}
			Window owner;
			if (5 != 0)
			{
				owner = window;
			}
			bool? flag = openFileDialog2.ShowDialog(owner);
			bool? flag2;
			if (3 != 0)
			{
				flag2 = flag;
			}
			if (flag2.GetValueOrDefault())
			{
				return openFileDialog2.FileNames;
			}
			return null;
		}

		// Token: 0x06006A6E RID: 27246 RVA: 0x0019CFA4 File Offset: 0x0019B1A4
		public string #S1c(#12c #R1c)
		{
			if (#R1c == null || false)
			{
				throw new ArgumentNullException(#Phc.#3hc(107430471));
			}
			Microsoft.Win32.OpenFileDialog openFileDialog = this.#r2c(#R1c, false);
			Microsoft.Win32.OpenFileDialog openFileDialog2;
			if (7 != 0)
			{
				openFileDialog2 = openFileDialog;
			}
			Window window;
			if ((window = (#R1c.Owner as Window)) == null)
			{
				window = this.#q2c();
			}
			Window owner;
			if (5 != 0)
			{
				owner = window;
			}
			bool? flag = openFileDialog2.ShowDialog(owner);
			bool? flag2;
			if (3 != 0)
			{
				flag2 = flag;
			}
			if (flag2.GetValueOrDefault())
			{
				return openFileDialog2.FileName;
			}
			return null;
		}

		// Token: 0x06006A6F RID: 27247 RVA: 0x00054050 File Offset: 0x00052250
		public Stream #T1c(string #So)
		{
			return Alphaleonis.Win32.Filesystem.File.Open(#So, FileMode.Create, FileAccess.ReadWrite, FileShare.None);
		}

		// Token: 0x06006A70 RID: 27248 RVA: 0x0005405B File Offset: 0x0005225B
		public Stream #U1c(string #So)
		{
			return Alphaleonis.Win32.Filesystem.File.Open(#So, FileMode.Open, FileAccess.Read, FileShare.Read, 65536);
		}

		// Token: 0x06006A71 RID: 27249 RVA: 0x0019D014 File Offset: 0x0019B214
		public bool #V1c(string #So)
		{
			bool result;
			try
			{
				bool flag = Alphaleonis.Win32.Filesystem.File.Exists(#So);
				if (!false)
				{
					result = flag;
				}
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06006A72 RID: 27250 RVA: 0x0005406B File Offset: 0x0005226B
		public bool #W1c(string #So)
		{
			for (;;)
			{
				if (this.#V1c(#So))
				{
					if (!false)
					{
						bool ignoreReadOnly = true;
						if (false)
						{
							break;
						}
						Alphaleonis.Win32.Filesystem.File.Delete(#So, ignoreReadOnly);
						break;
					}
				}
				else
				{
					if (!false)
					{
						return false;
					}
					break;
				}
			}
			return true;
		}

		// Token: 0x06006A73 RID: 27251 RVA: 0x0019D048 File Offset: 0x0019B248
		public bool #X1c(string #So)
		{
			bool result;
			try
			{
				bool flag = Alphaleonis.Win32.Filesystem.Directory.Exists(#So);
				if (!false)
				{
					result = flag;
				}
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06006A74 RID: 27252 RVA: 0x0019D07C File Offset: 0x0019B27C
		public string #Y1c(Window #WSc, Environment.SpecialFolder #Z1c = Environment.SpecialFolder.MyComputer, string #Ao = null)
		{
			if (!false)
			{
				VistaFolderBrowserDialog vistaFolderBrowserDialog = new VistaFolderBrowserDialog();
				if (6 != 0)
				{
					vistaFolderBrowserDialog.RootFolder = #Z1c;
				}
				VistaFolderBrowserDialog vistaFolderBrowserDialog2;
				if (6 != 0)
				{
					vistaFolderBrowserDialog2 = vistaFolderBrowserDialog;
				}
				if (8 != 0 && !string.IsNullOrWhiteSpace(#Ao) && this.#X1c(#Ao))
				{
					VistaFolderBrowserDialog vistaFolderBrowserDialog3 = vistaFolderBrowserDialog2;
					if (4 != 0)
					{
						vistaFolderBrowserDialog3.SelectedPath = #Ao;
					}
				}
				bool? flag = vistaFolderBrowserDialog2.ShowDialog(#WSc);
				bool? flag2;
				if (!false)
				{
					flag2 = flag;
				}
				while (flag2.GetValueOrDefault())
				{
					if (2 != 0)
					{
						return vistaFolderBrowserDialog2.SelectedPath;
					}
				}
			}
			return string.Empty;
		}

		// Token: 0x06006A75 RID: 27253 RVA: 0x0019D0F0 File Offset: 0x0019B2F0
		public string #01c(Environment.SpecialFolder #Z1c = Environment.SpecialFolder.MyComputer, string #Ao = null)
		{
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
			if (4 != 0)
			{
				folderBrowserDialog.RootFolder = #Z1c;
			}
			FolderBrowserDialog folderBrowserDialog2;
			if (!false)
			{
				folderBrowserDialog2 = folderBrowserDialog;
			}
			if (!string.IsNullOrWhiteSpace(#Ao) && this.#X1c(#Ao))
			{
				FolderBrowserDialog folderBrowserDialog3 = folderBrowserDialog2;
				if (!false)
				{
					folderBrowserDialog3.SelectedPath = #Ao;
				}
			}
			if (folderBrowserDialog2.ShowDialog() == DialogResult.OK)
			{
				return folderBrowserDialog2.SelectedPath;
			}
			return string.Empty;
		}

		// Token: 0x06006A76 RID: 27254 RVA: 0x0019D14C File Offset: 0x0019B34C
		public string #11c(#62c #21c, out #L1c #31c)
		{
			if (#21c == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107430442));
			}
			#31c = null;
			Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
			saveFileDialog.CheckPathExists = true;
			saveFileDialog.OverwritePrompt = true;
			saveFileDialog.DefaultExt = #Phc.#3hc(107356879) + #21c.DefaultExtension;
			saveFileDialog.Filter = FileSystemService.#l2c(#21c.FileExtensionFilters);
			saveFileDialog.AddExtension = true;
			int filterIndex = #21c.FilterIndex + 1;
			if (2 != 0)
			{
				saveFileDialog.FilterIndex = filterIndex;
			}
			Microsoft.Win32.SaveFileDialog saveFileDialog2;
			if (!false)
			{
				saveFileDialog2 = saveFileDialog;
			}
			if (this.#X1c(#21c.InitialDirectory))
			{
				Microsoft.Win32.FileDialog fileDialog = saveFileDialog2;
				string initialDirectory = #21c.InitialDirectory;
				if (!false)
				{
					fileDialog.InitialDirectory = initialDirectory;
				}
			}
			if (!string.IsNullOrWhiteSpace(#21c.InitialFileName))
			{
				Microsoft.Win32.FileDialog fileDialog2 = saveFileDialog2;
				string fileName = #21c.InitialFileName;
				if (!false)
				{
					fileDialog2.FileName = fileName;
				}
			}
			Window window;
			if ((window = (#21c.Owner as Window)) == null)
			{
				window = this.#q2c();
			}
			Window owner;
			if (2 != 0)
			{
				owner = window;
			}
			bool? flag = saveFileDialog2.ShowDialog(owner);
			bool? flag2;
			if (5 != 0)
			{
				flag2 = flag;
			}
			if (flag2.GetValueOrDefault())
			{
				#31c = #21c.FileExtensionFilters.ElementAtOrDefault(saveFileDialog2.FilterIndex - 1);
				string text = saveFileDialog2.FileName;
				if (#31c != null && !string.IsNullOrWhiteSpace(text) && !text.EndsWith(#31c.Extension, StringComparison.OrdinalIgnoreCase))
				{
					text = text + #Phc.#3hc(107356879) + #31c.Extension;
				}
				if (Alphaleonis.Win32.Filesystem.File.Exists(text))
				{
					Alphaleonis.Win32.Filesystem.File.Delete(text);
				}
				return text;
			}
			return null;
		}

		// Token: 0x06006A77 RID: 27255 RVA: 0x00054090 File Offset: 0x00052290
		public void #41c(string #So, IEnumerable<string> #Usb, Encoding #51c)
		{
			if (2 != 0)
			{
				Alphaleonis.Win32.Filesystem.File.WriteAllLines(#So, #Usb, #51c);
			}
		}

		// Token: 0x06006A78 RID: 27256 RVA: 0x000540A2 File Offset: 0x000522A2
		public void #61c(string #Jl)
		{
			if (6 != 0)
			{
				#G1c.#jhc(#Jl);
			}
		}

		// Token: 0x06006A79 RID: 27257 RVA: 0x0019D2CC File Offset: 0x0019B4CC
		public string #11c(#62c #21c)
		{
			FileSystemService.#8Ub #8Ub;
			#8Ub.#a = this;
			#8Ub.#b = #21c;
			if (#8Ub.#b == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107430442));
			}
			Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
			saveFileDialog.CheckPathExists = true;
			saveFileDialog.OverwritePrompt = true;
			saveFileDialog.DefaultExt = #Phc.#3hc(107356879) + #8Ub.#b.DefaultExtension;
			saveFileDialog.Filter = FileSystemService.#l2c(#8Ub.#b.FileExtensionFilters);
			saveFileDialog.AddExtension = true;
			int filterIndex = #8Ub.#b.FilterIndex;
			if (4 != 0)
			{
				saveFileDialog.FilterIndex = filterIndex;
			}
			Microsoft.Win32.SaveFileDialog saveFileDialog2;
			if (6 != 0)
			{
				saveFileDialog2 = saveFileDialog;
			}
			if (this.#X1c(#8Ub.#b.InitialDirectory))
			{
				Microsoft.Win32.FileDialog fileDialog = saveFileDialog2;
				string initialDirectory = #8Ub.#b.InitialDirectory;
				if (!false)
				{
					fileDialog.InitialDirectory = initialDirectory;
				}
			}
			if (!string.IsNullOrWhiteSpace(#8Ub.#b.InitialFileName))
			{
				Microsoft.Win32.FileDialog fileDialog2 = saveFileDialog2;
				string fileName = #8Ub.#b.InitialFileName;
				if (5 != 0)
				{
					fileDialog2.FileName = fileName;
				}
			}
			string result;
			if (!false)
			{
				try
				{
					string text;
					while (this.#v3h(saveFileDialog2, out text, ref #8Ub))
					{
						if (true)
						{
							string text2 = text;
							if (!false)
							{
								result = text2;
							}
							return result;
						}
					}
				}
				catch (PathTooLongException)
				{
					saveFileDialog2.InitialDirectory = string.Empty;
					if (!false)
					{
						saveFileDialog2.FileName = string.Empty;
					}
					do
					{
						string text3;
						this.#v3h(saveFileDialog2, out text3, ref #8Ub);
						result = text3;
					}
					while (false);
					return result;
				}
				catch (ArgumentException)
				{
					string result2;
					do
					{
						saveFileDialog2.InitialDirectory = string.Empty;
						saveFileDialog2.FileName = string.Empty;
						this.#v3h(saveFileDialog2, out result2, ref #8Ub);
					}
					while (3 == 0);
					return result2;
				}
				return null;
			}
			return result;
		}

		// Token: 0x06006A7A RID: 27258 RVA: 0x000540B0 File Offset: 0x000522B0
		public string #F1c()
		{
			return #G1c.#F1c();
		}

		// Token: 0x06006A7B RID: 27259 RVA: 0x000540B7 File Offset: 0x000522B7
		public string #71c(string #In)
		{
			return #0zc.#Rzc(ShlwApi.ASSOCSTR.ASSOCSTR_EXECUTABLE, #In);
		}

		// Token: 0x06006A7C RID: 27260 RVA: 0x0019D478 File Offset: 0x0019B678
		public string #81c(string #91c)
		{
			string text2;
			do
			{
				string text = #jzc.#hzc();
				if (8 != 0)
				{
					text2 = text;
				}
				if (!string.IsNullOrWhiteSpace(text2))
				{
					if (7 == 0)
					{
						continue;
					}
					if (!false)
					{
						goto Block_2;
					}
				}
			}
			while (3 == 0);
			return #91c;
			Block_2:
			return Alphaleonis.Win32.Filesystem.Path.Combine(new string[]
			{
				text2,
				#91c
			});
		}

		// Token: 0x06006A7D RID: 27261 RVA: 0x000540C0 File Offset: 0x000522C0
		public string[] #Ro(string #So, string #a2c, SearchOption #b2c)
		{
			return Alphaleonis.Win32.Filesystem.Directory.GetFiles(#So, #a2c, #b2c);
		}

		// Token: 0x06006A7E RID: 27262 RVA: 0x000540CA File Offset: 0x000522CA
		public byte[] #c2c(string #So)
		{
			return Alphaleonis.Win32.Filesystem.File.ReadAllBytes(#So);
		}

		// Token: 0x06006A7F RID: 27263 RVA: 0x000540D2 File Offset: 0x000522D2
		public void #d2c(string #So, byte[] #Gfb)
		{
			if (!false)
			{
				Alphaleonis.Win32.Filesystem.File.WriteAllBytes(#So, #Gfb);
			}
		}

		// Token: 0x06006A80 RID: 27264 RVA: 0x000540E2 File Offset: 0x000522E2
		public string[] #e2c(string #So)
		{
			return Alphaleonis.Win32.Filesystem.Directory.GetDirectories(#So);
		}

		// Token: 0x06006A81 RID: 27265 RVA: 0x000540EA File Offset: 0x000522EA
		public string #f2c(string #So)
		{
			return Alphaleonis.Win32.Filesystem.File.ReadAllText(#So);
		}

		// Token: 0x06006A82 RID: 27266 RVA: 0x0019D4B8 File Offset: 0x0019B6B8
		public void #g2c(string #h2c, string #i2c, bool #j2c)
		{
			if (false)
			{
				goto IL_0C;
			}
			MoveOptions moveOptions = #j2c ? MoveOptions.ReplaceExisting : MoveOptions.None;
			if (6 == 0)
			{
				goto IL_0D;
			}
			if (#j2c)
			{
				goto IL_0C;
			}
			IL_09:
			moveOptions = MoveOptions.None;
			goto IL_0D;
			IL_0C:
			moveOptions = MoveOptions.ReplaceExisting;
			IL_0D:
			MoveOptions moveOptions2;
			if (4 != 0)
			{
				moveOptions2 = moveOptions;
			}
			Alphaleonis.Win32.Filesystem.File.Move(#h2c, #i2c, moveOptions2);
			if (!false)
			{
				return;
			}
			goto IL_09;
		}

		// Token: 0x06006A83 RID: 27267 RVA: 0x000540F2 File Offset: 0x000522F2
		public void #k2c(string #So)
		{
			if (6 != 0)
			{
				#Z6d.#k2c(#So);
			}
		}

		// Token: 0x06006A84 RID: 27268 RVA: 0x0019D4E8 File Offset: 0x0019B6E8
		private static string #l2c(IEnumerable<#L1c> #m2c)
		{
			#L1c[] array2;
			if (7 != 0 && !false)
			{
				#L1c[] array;
				if ((array = (#m2c as #L1c[])) == null)
				{
					array = #m2c.ToArray<#L1c>();
				}
				if (5 != 0)
				{
					array2 = array;
				}
			}
			if (!array2.Any<#L1c>())
			{
				return null;
			}
			string separator = #Phc.#3hc(107430413);
			IEnumerable<#L1c> source = array2;
			Func<#L1c, string> selector;
			if ((selector = FileSystemService.#2Ui.#a) == null)
			{
				selector = (FileSystemService.#2Ui.#a = new Func<#L1c, string>(FileSystemService.#n2c));
			}
			return string.Join(separator, source.Select(selector));
		}

		// Token: 0x06006A85 RID: 27269 RVA: 0x00054100 File Offset: 0x00052300
		private static string #n2c(#L1c #o2c)
		{
			return #Phc.#3hc(107430408).#D2d(new object[]
			{
				#o2c.Label,
				FileSystemService.#p2c(#o2c.Extension)
			});
		}

		// Token: 0x06006A86 RID: 27270 RVA: 0x0005412E File Offset: 0x0005232E
		private static string #p2c(string #In)
		{
			return #Phc.#3hc(107430419) + #In;
		}

		// Token: 0x06006A87 RID: 27271 RVA: 0x0019D54C File Offset: 0x0019B74C
		private Window #q2c()
		{
			Window result;
			try
			{
				Window window;
				if ((window = System.Windows.Application.Current.Windows.OfType<Window>().FirstOrDefault(new Func<Window, bool>(FileSystemService.<>c.<>9.#D3h))) == null)
				{
					window = System.Windows.Application.Current.MainWindow;
				}
				if (!false)
				{
					result = window;
				}
			}
			catch (Exception)
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06006A88 RID: 27272 RVA: 0x0019D5BC File Offset: 0x0019B7BC
		private Microsoft.Win32.OpenFileDialog #r2c(#12c #R1c, bool #s2c = false)
		{
			Microsoft.Win32.OpenFileDialog openFileDialog2;
			for (;;)
			{
				if (!false)
				{
					Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
					openFileDialog.CheckFileExists = true;
					openFileDialog.CheckPathExists = true;
					if (!false)
					{
						openFileDialog.Multiselect = #s2c;
					}
					if (3 != 0)
					{
						openFileDialog2 = openFileDialog;
					}
				}
				if (!this.#X1c(#R1c.InitialPath))
				{
					goto IL_41;
				}
				IL_2F:
				if (7 == 0)
				{
					goto IL_5F;
				}
				if (3 == 0)
				{
					continue;
				}
				Microsoft.Win32.FileDialog fileDialog = openFileDialog2;
				string initialDirectory = #R1c.InitialPath;
				if (6 != 0)
				{
					fileDialog.InitialDirectory = initialDirectory;
				}
				IL_41:
				if (!false)
				{
					break;
				}
				goto IL_2F;
			}
			Microsoft.Win32.FileDialog fileDialog2 = openFileDialog2;
			string defaultExt = #Phc.#3hc(107356879) + #R1c.DefaultExtension;
			if (!false)
			{
				fileDialog2.DefaultExt = defaultExt;
			}
			IL_5F:
			Microsoft.Win32.FileDialog fileDialog3 = openFileDialog2;
			string filter = FileSystemService.#l2c(#R1c.FileExtensionFilters);
			if (!false)
			{
				fileDialog3.Filter = filter;
			}
			return openFileDialog2;
		}

		// Token: 0x06006A8A RID: 27274 RVA: 0x0019D65C File Offset: 0x0019B85C
		[CompilerGenerated]
		private bool #v3h(Microsoft.Win32.FileDialog #u2c, out string #2o, ref FileSystemService.#8Ub A_3)
		{
			#2o = null;
			bool? flag = #u2c.ShowDialog(this.#q2c());
			bool? flag2;
			if (!false)
			{
				flag2 = flag;
			}
			if (flag2.GetValueOrDefault())
			{
				if (Alphaleonis.Win32.Filesystem.File.Exists(#u2c.FileName))
				{
					if (A_3.#b.CreateBackupOfExistingFile)
					{
						string text = #u2c.FileName + #Phc.#3hc(107405050);
						string text2;
						if (-1 != 0)
						{
							text2 = text;
						}
						string fileName = #u2c.FileName;
						string #G = text2;
						if (3 != 0)
						{
							this.#u3h(fileName, #G);
						}
					}
					string fileName2 = #u2c.FileName;
					if (4 != 0)
					{
						Alphaleonis.Win32.Filesystem.File.Delete(fileName2);
					}
				}
				#2o = #u2c.FileName;
				return true;
			}
			return false;
		}

		// Token: 0x02000CBF RID: 3263
		[CompilerGenerated]
		private static class #2Ui
		{
			// Token: 0x04002B90 RID: 11152
			public static Func<#L1c, string> #a;
		}

		// Token: 0x02000CC1 RID: 3265
		[CompilerGenerated]
		[StructLayout(LayoutKind.Auto)]
		private struct #8Ub
		{
			// Token: 0x04002B93 RID: 11155
			public FileSystemService #a;

			// Token: 0x04002B94 RID: 11156
			public #62c #b;
		}
	}
}
