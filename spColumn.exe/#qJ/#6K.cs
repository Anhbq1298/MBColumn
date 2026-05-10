using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Shell;
using #0be;
using #7hc;
using #8Cc;
using #c1d;
using #coe;
using #cYd;
using #eU;
using #ezc;
using #HI;
using #IDc;
using #Jie;
using #LQc;
using #RJb;
using #v1c;
using #x5d;
using FluentValidation.Results;
using StructurePoint.CoreAssets.AppManager.Column.Storage.Legacy;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.Validation;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.CoreAssets.Logger;
using StructurePoint.Products.Column.Editor.Project;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.ViewModels.Items;

namespace #qJ
{
	// Token: 0x020002A8 RID: 680
	internal sealed class #6K : NotifyPropertyChangedObjectBase, #vU
	{
		// Token: 0x06001637 RID: 5687 RVA: 0x000B38FC File Offset: 0x000B1AFC
		public #6K(ICoreServices #0c, #JI #Uk, #9V #RA, #XV #ej, #xU #7K, #BLb #fj)
		{
			this.#a = #Uk;
			if (#0c == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107407561));
			}
			this.#q = #0c;
			this.#b = this.Services.Project;
			this.#c = this.Services.UndoManager;
			this.#d = #RA;
			this.#e = this.Services.FileSystem;
			this.#f = this.Services.ErrorsHandler;
			this.#g = #ej;
			this.#h = this.Services.DialogService;
			this.#i = #7K;
			this.#j = this.Services.Notifications;
			this.#k = this.Services.Logger;
			this.#m = this.Services.ApplicationInfo;
			if (#fj == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107382952));
			}
			this.#l = #fj;
			this.#n = Strings.StringUntitled;
			this.Services.MessageBus.LoadProjectRequested += this.#OK;
		}

		// Token: 0x14000036 RID: 54
		// (add) Token: 0x06001638 RID: 5688 RVA: 0x000B3A14 File Offset: 0x000B1C14
		// (remove) Token: 0x06001639 RID: 5689 RVA: 0x000B3A58 File Offset: 0x000B1C58
		public event EventHandler LoadingProject
		{
			[CompilerGenerated]
			add
			{
				EventHandler eventHandler = this.#p;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#p, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler eventHandler = this.#p;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#p, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x170007FB RID: 2043
		// (get) Token: 0x0600163A RID: 5690 RVA: 0x0001705A File Offset: 0x0001525A
		public ICoreServices Services { get; }

		// Token: 0x170007FC RID: 2044
		// (get) Token: 0x0600163B RID: 5691 RVA: 0x00017066 File Offset: 0x00015266
		private Window OwnerWindow
		{
			get
			{
				return this.Services.WindowLocator.#VP() as Window;
			}
		}

		// Token: 0x170007FD RID: 2045
		// (get) Token: 0x0600163C RID: 5692 RVA: 0x00017089 File Offset: 0x00015289
		public bool IsProjectLoaded
		{
			get
			{
				return !string.IsNullOrEmpty(this.CurrentlyLoadedFilePath);
			}
		}

		// Token: 0x170007FE RID: 2046
		// (get) Token: 0x0600163D RID: 5693 RVA: 0x000170A5 File Offset: 0x000152A5
		// (set) Token: 0x0600163E RID: 5694 RVA: 0x000B3A9C File Offset: 0x000B1C9C
		public string CurrentProject
		{
			get
			{
				return this.#n;
			}
			private set
			{
				if (this.#n != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107405792));
					this.#n = value;
					base.RaisePropertyChanged(#Phc.#3hc(107405792));
				}
			}
		}

		// Token: 0x170007FF RID: 2047
		// (get) Token: 0x0600163F RID: 5695 RVA: 0x000170B1 File Offset: 0x000152B1
		// (set) Token: 0x06001640 RID: 5696 RVA: 0x000B3AEC File Offset: 0x000B1CEC
		public string CurrentlyLoadedFilePath
		{
			get
			{
				return this.#o;
			}
			private set
			{
				this.#o = value;
				this.#b.LoadedFilePath = value;
				if (string.IsNullOrWhiteSpace(value))
				{
					this.CurrentProject = Strings.StringUntitled;
					return;
				}
				this.CurrentProject = Path.GetFileName(value);
			}
		}

		// Token: 0x06001641 RID: 5697 RVA: 0x000B3B38 File Offset: 0x000B1D38
		public bool? #kF(string #So, bool #xK)
		{
			bool? result = null;
			#3Hc #3Hc = new #3Hc(Strings.StringStorage, #So);
			bool flag = false;
			bool flag2 = false;
			try
			{
				if (#xK)
				{
					result = this.#WK();
					if (!result.GetValueOrDefault())
					{
						return result;
					}
				}
				if (this.#e.#V1c(#So))
				{
					result = this.#HK(#So, #3Hc);
					flag2 = (result.GetValueOrDefault() && !#b1d.#70d(#So));
				}
				else
				{
					result = new bool?(false);
				}
				if (result.GetValueOrDefault())
				{
					this.Services.GuiController.IsBackstageOpen = false;
					this.#a.#xl(#So);
				}
			}
			catch (UnauthorizedAccessException exception)
			{
				this.Services.Logger.Log(LoggingLevel.Warning, exception);
				this.Services.DialogService.#qn(this.OwnerWindow, Strings.StringAccessToTheFileXIsDenied.#D2d(new object[]
				{
					#So
				}).#z2d());
				flag = true;
				flag2 = false;
			}
			catch (Exception #ob)
			{
				this.CurrentlyLoadedFilePath = null;
				this.#f.#bzc(#ob, #Phc.#3hc(107405771), #3Hc);
				flag = true;
			}
			finally
			{
				this.CurrentlyLoadedFilePath = (flag2 ? #So : null);
				this.#b.LoadedFilePath = (result.GetValueOrDefault() ? #So : null);
				if (!flag && !flag2)
				{
					this.CurrentProject = (string.IsNullOrWhiteSpace(#So) ? Strings.StringUntitled : (this.CurrentProject = Path.GetFileName(#So)));
				}
			}
			if (result != null && result.Value)
			{
				this.#4K();
			}
			return result;
		}

		// Token: 0x06001642 RID: 5698 RVA: 0x000B3CFC File Offset: 0x000B1EFC
		public bool? #yK(string #zK)
		{
			#3Hc #3Hc = new #3Hc(Strings.StringStorage);
			bool? result;
			try
			{
				bool? flag = this.#WK();
				if (!flag.GetValueOrDefault())
				{
					result = flag;
				}
				else
				{
					List<#L1c> #m2c = new List<#L1c>
					{
						new #L1c(Strings.StringAllSpColumnFiles, #b1d.AllProjectExtensions),
						new #L1c(Strings.StringSpColumnInputFiles, #b1d.CurrentExtension),
						new #L1c(Strings.StringCol_UPPER, #b1d.LegacyExtension),
						new #L1c(Strings.StringCti_UPPER, #b1d.LegacyTextExtension)
					};
					string #Ao = this.#0K(#zK);
					string text = this.#e.#S1c(new #12c(#m2c, #b1d.CurrentExtension, #Ao));
					#3Hc.FilePath = text;
					if (!string.IsNullOrEmpty(text))
					{
						result = this.#kF(text, false);
					}
					else
					{
						result = null;
					}
				}
			}
			catch (Exception #ob)
			{
				this.#f.#bzc(#ob, #Phc.#3hc(107405750), #3Hc);
				result = new bool?(false);
			}
			return result;
		}

		// Token: 0x06001643 RID: 5699 RVA: 0x000170BD File Offset: 0x000152BD
		public bool? #AK()
		{
			return this.#RK(false);
		}

		// Token: 0x06001644 RID: 5700 RVA: 0x000170CE File Offset: 0x000152CE
		public bool? #BK()
		{
			return this.#RK(true);
		}

		// Token: 0x06001645 RID: 5701 RVA: 0x000170DF File Offset: 0x000152DF
		public void #CK()
		{
			this.#c.#yl();
			this.#g.#yJ();
		}

		// Token: 0x06001646 RID: 5702 RVA: 0x000B3E28 File Offset: 0x000B2028
		public bool? #DK(Action #EK = null)
		{
			bool? result;
			try
			{
				if (this.#g.HasChanges)
				{
					string #SSc = Strings.StringTheProjectHasBeenModifiedAndNotSaved.#z2d(true) + Strings.StringWouldYouLikeToSaveTheProjectFirst.#J2d();
					MessageBoxResult messageBoxResult = this.#h.#od(this.OwnerWindow, #SSc, this.#m.ApplicationName, MessageBoxButton.YesNoCancel, MessageBoxImage.Question, MessageBoxResult.Yes, MessageBoxOptions.None);
					if (messageBoxResult == MessageBoxResult.Cancel)
					{
						result = null;
						return result;
					}
					if (messageBoxResult != MessageBoxResult.Yes)
					{
						if (messageBoxResult != MessageBoxResult.No)
						{
						}
					}
					else if (!this.#AK().GetValueOrDefault())
					{
						return new bool?(false);
					}
				}
				this.#c.IsEnabled = false;
				this.#CK();
				this.CurrentProject = null;
				this.CurrentlyLoadedFilePath = null;
				this.#g.#yJ();
				ColumnStorageModel #YK = this.#i.#4N();
				this.#GK();
				this.#XK(#YK, true, #EK);
				result = new bool?(true);
			}
			catch (Exception #ob)
			{
				this.#f.#bzc(#ob, #Phc.#3hc(107405665), new #3Hc(Strings.StringStorage));
				result = new bool?(false);
			}
			finally
			{
				this.#c.IsEnabled = true;
			}
			return result;
		}

		// Token: 0x06001647 RID: 5703 RVA: 0x00017103 File Offset: 0x00015303
		public bool? #FK()
		{
			return this.#WK();
		}

		// Token: 0x06001648 RID: 5704 RVA: 0x00017113 File Offset: 0x00015313
		protected void #GK()
		{
			EventHandler eventHandler = this.#p;
			if (eventHandler == null)
			{
				return;
			}
			eventHandler(this, EventArgs.Empty);
		}

		// Token: 0x06001649 RID: 5705 RVA: 0x000B3F98 File Offset: 0x000B2198
		internal bool? #HK(string #So, #3Hc #IK)
		{
			bool value = false;
			try
			{
				this.#c.IsEnabled = false;
				#9oe #9oe = this.#PK(#So, new #ape());
				if (#9oe != null && #9oe.IsValid && #9oe.Model.Options.SectionType == SectionType.IrregularTemplate)
				{
					string #SSc = this.#h.#5Sc(Strings.StringCannotLoadTheSelectedProject.#z2d(), Strings.StringTemplateSectionsAreNotSupportedInThisSpColumnVersion.#z2d());
					this.#h.#qn(this.#h.ActiveWindow, #SSc);
					return new bool?(false);
				}
				if (#9oe != null && #9oe.IsValid && !#9oe.Canceled)
				{
					IList<ValidationFailure> list = BarSizesValidator.#NRb(#9oe.Model);
					if (list.Any<ValidationFailure>())
					{
						string #Ukc = #Zbe.#Ybe(list, #9oe.Model.CreateContext());
						string #SSc2 = this.#h.#5Sc(Strings.StringProjectCannotBeLoaded.#z2d(), #Ukc);
						this.#h.#qn(this.#h.ActiveWindow, #SSc2);
						return new bool?(false);
					}
					this.#GK();
					#9oe.Model.ReAssignShapeId();
					this.#XK(#9oe.Model, false, null);
					this.#c.#yl();
					this.#g.#yJ();
					if (#b1d.#70d(#So))
					{
						this.#c.#uCc();
						this.#c.#vCc();
					}
					value = true;
				}
				else
				{
					if (!string.IsNullOrWhiteSpace((#9oe != null) ? #9oe.ErrorMessage : null))
					{
						string #SSc3 = this.#h.#5Sc(Strings.StringProjectCannotBeLoaded.#z2d(), #9oe.ErrorMessage.#A2d());
						this.#h.#qn(this.OwnerWindow, #SSc3);
					}
					this.CurrentlyLoadedFilePath = null;
					this.#XK(null, false, null);
				}
			}
			catch (FileLoadException ex)
			{
				this.CurrentlyLoadedFilePath = null;
				this.#XK(null, false, null);
				this.#k.Log(LoggingLevel.Error, ex);
				string text = this.#h.#5Sc(Strings.StringProjectCannotBeLoaded.#z2d(), #sYd.#oYd(ex).#A2d());
				this.#j.#2Ic(#IK, text);
				this.#h.#qn(this.OwnerWindow, text);
			}
			catch (#y5d #y5d)
			{
				this.CurrentlyLoadedFilePath = null;
				this.#XK(null, false, null);
				string text2 = this.#h.#5Sc(Strings.StringProjectCannotBeLoaded.#z2d(), #sYd.#nYd(#y5d).#A2d());
				this.#k.Log(LoggingLevel.Error, #y5d);
				this.#j.#2Ic(#IK, text2);
				this.#h.#qn(this.OwnerWindow, text2);
			}
			catch (#goe #goe)
			{
				this.CurrentlyLoadedFilePath = null;
				this.#XK(null, false, null);
				string #SSc4 = this.#h.#5Sc(Strings.StringProjectCannotBeLoaded.#z2d(), #goe.Message.#A2d());
				this.#h.#qn(this.OwnerWindow, #SSc4);
			}
			catch (Exception #ob)
			{
				this.CurrentlyLoadedFilePath = null;
				this.#XK(null, false, null);
				this.#f.#bzc(#ob, #Phc.#3hc(107405612), #IK);
			}
			finally
			{
				this.#c.IsEnabled = true;
			}
			return new bool?(value);
		}

		// Token: 0x0600164A RID: 5706 RVA: 0x000B4350 File Offset: 0x000B2550
		private void #JK(object #Ge, #Mie #He)
		{
			string #SSc = string.Concat(new string[]
			{
				Strings.StringOldFileVersionDetected.#z2d(),
				Environment.NewLine,
				Strings.StringDoYouWantToConsiderLateralLoadsAsEarthquakeLoads.#J2d(),
				Environment.NewLine,
				Strings.StringByClickingNoLateralLoadsWillBeConsideredAsWindLoads
			});
			MessageBoxResult messageBoxResult = this.#h.#3Sc(this.OwnerWindow, #SSc, MessageBoxButton.YesNo, MessageBoxResult.Yes);
			#He.CompatibilityMode = ((messageBoxResult == MessageBoxResult.Yes) ? LateralLoadsCompatibilityMode.ConsiderAsEarthquakeLoads : LateralLoadsCompatibilityMode.ConsiderAsWindLoads);
		}

		// Token: 0x0600164B RID: 5707 RVA: 0x000B43CC File Offset: 0x000B25CC
		private void #KK(object #Ge, EventArgs #He)
		{
			string text = Strings.StringTheInputProjectNotSupported.#z2d(true) + Environment.NewLine;
			text += Strings.StringTheInputProjectHasBeenCreatedWithANewerVersionOfSpColumnWithDisabledBackwardAndForwardCompatibilityMode.#z2d();
			this.#j.#2Ic(this.#QK(), text);
			this.#h.#od(this.OwnerWindow, text, this.#m.ApplicationName, MessageBoxButton.OK, MessageBoxImage.Hand, MessageBoxResult.OK, MessageBoxOptions.None);
		}

		// Token: 0x0600164C RID: 5708 RVA: 0x000B4444 File Offset: 0x000B2644
		private void #LK(object #Ge, EventArgs #He)
		{
			string text = Strings.StringTheInputProjectNotSupported.#z2d(true) + Environment.NewLine;
			text += Strings.StringNoValidInputDataFound.#z2d();
			this.#j.#2Ic(this.#QK(), text);
			this.#h.#od(this.OwnerWindow, text, this.#m.ApplicationName, MessageBoxButton.OK, MessageBoxImage.Hand, MessageBoxResult.OK, MessageBoxOptions.None);
		}

		// Token: 0x0600164D RID: 5709 RVA: 0x000B44BC File Offset: 0x000B26BC
		private void #MK(object #Ge, EventArgs #He)
		{
			string text = Strings.StringTheInputProjectHasBeenCreatedWithANewerVersionOfSpColumnAndMayContainFeaturesNotAvailableInThisVersionOfSpColumn.#z2d();
			this.#j.#0Ic(this.#QK(), text);
			this.#h.#od(this.OwnerWindow, text, this.#m.ApplicationName, MessageBoxButton.OK, MessageBoxImage.Asterisk, MessageBoxResult.OK, MessageBoxOptions.None);
		}

		// Token: 0x0600164E RID: 5710 RVA: 0x000B4518 File Offset: 0x000B2718
		private void #NK(object #Ge, #foe #He)
		{
			string text = Strings.StringTheSelectedInputProjectHasBeenCreatedWithANewerVersionOfSpColumn.#z2d(true);
			text += Strings.StringWouldYouLikeToOverwriteTheExistingFile.#J2d();
			MessageBoxResult messageBoxResult = this.#h.#od(this.OwnerWindow, text, this.#m.ApplicationName, MessageBoxButton.YesNoCancel, MessageBoxImage.Question, MessageBoxResult.No, MessageBoxOptions.None);
			if (messageBoxResult == MessageBoxResult.Cancel)
			{
				#He.Action = #doe.#c;
				return;
			}
			if (messageBoxResult == MessageBoxResult.Yes)
			{
				#He.Action = #doe.#a;
				return;
			}
			if (messageBoxResult != MessageBoxResult.No)
			{
				return;
			}
			List<#L1c> #m2c = new List<#L1c>
			{
				new #L1c(#Phc.#3hc(107405591), #b1d.CurrentExtension)
			};
			string value = this.#e.#11c(new #62c(#m2c, #b1d.CurrentExtension, this.#2K(this.CurrentlyLoadedFilePath))
			{
				CreateBackupOfExistingFile = true
			});
			if (string.IsNullOrWhiteSpace(value))
			{
				#He.Action = #doe.#c;
				return;
			}
			#He.Action = #doe.#b;
			#He.FileName = value;
		}

		// Token: 0x0600164F RID: 5711 RVA: 0x000B4608 File Offset: 0x000B2808
		private void #OK(object #Ge, #3V #He)
		{
			if (#He.IsFilePath)
			{
				if (!this.#e.#V1c(#He.Path))
				{
					this.#h.#od(this.OwnerWindow, Strings.StringTheFileCannotBeFound.#z2d(true) + Strings.StringItIsPossibleItWasMovedRenamedOrDeleted.#z2d(), this.#m.ApplicationName, MessageBoxButton.OK, MessageBoxImage.Exclamation, MessageBoxResult.OK, MessageBoxOptions.None);
					return;
				}
				if (this.#kF(#He.Path, true).GetValueOrDefault())
				{
					JumpList.AddToRecentCategory(#He.Path);
					return;
				}
			}
			else
			{
				this.#yK(#He.Path);
			}
		}

		// Token: 0x06001650 RID: 5712 RVA: 0x000B46BC File Offset: 0x000B28BC
		private #9oe #PK(string #So, #ape #mA)
		{
			#9oe result;
			try
			{
				this.Services.Storage.OnOverwriteOfInputProjectCreatedWithNewerApplicationVersion += this.#NK;
				this.Services.Storage.OnOpenInputFileWithNewerFileVersions += this.#MK;
				this.Services.Storage.OnUnsupportedInputFileNoDataFound += this.#LK;
				this.Services.Storage.OnUnsupportedInputProjectCreatedWithNewerApplication += this.#KK;
				this.Services.Storage.OnLateralLoadsCompatibilityModeRequested += this.#JK;
				result = this.Services.Storage.#Cjc(#So, #mA);
			}
			finally
			{
				this.Services.Storage.OnOverwriteOfInputProjectCreatedWithNewerApplicationVersion -= this.#NK;
				this.Services.Storage.OnOpenInputFileWithNewerFileVersions -= this.#MK;
				this.Services.Storage.OnUnsupportedInputFileNoDataFound -= this.#LK;
				this.Services.Storage.OnUnsupportedInputProjectCreatedWithNewerApplication -= this.#KK;
				this.Services.Storage.OnLateralLoadsCompatibilityModeRequested -= this.#JK;
			}
			return result;
		}

		// Token: 0x06001651 RID: 5713 RVA: 0x00017137 File Offset: 0x00015337
		private #3Hc #QK()
		{
			return new #3Hc(Strings.StringStorage, this.CurrentlyLoadedFilePath);
		}

		// Token: 0x06001652 RID: 5714 RVA: 0x000B482C File Offset: 0x000B2A2C
		private void #YUh(string #Rtf)
		{
			if (this.#e.#V1c(#Rtf))
			{
				string #G = #Rtf + #Phc.#3hc(107405050);
				this.#e.#u3h(#Rtf, #G);
			}
		}

		// Token: 0x06001653 RID: 5715 RVA: 0x000B4874 File Offset: 0x000B2A74
		private bool? #RK(bool #SK)
		{
			bool flag = false;
			#3Hc #Ic = this.#QK();
			bool value = false;
			try
			{
				string text = this.CurrentlyLoadedFilePath;
				string #VK = string.IsNullOrEmpty(text) ? (this.#TK() ?? Strings.StringUntitled) : Path.GetFileNameWithoutExtension(text);
				if (!string.IsNullOrEmpty(text))
				{
					flag = true;
				}
				flag = (flag && !#SK);
				if (string.IsNullOrWhiteSpace(text) || #SK)
				{
					this.#UK(ref text, #VK);
				}
				if (string.IsNullOrWhiteSpace(text))
				{
					return null;
				}
				this.#YUh(text);
				ColumnStorageModel #Od = this.#d.#Pb(this.#b.Model);
				this.Services.Storage.#zl(#Od, text, new #3oe
				{
					EnableCompatibilityMode = true
				});
				this.#g.#DO();
				this.CurrentlyLoadedFilePath = text;
				this.Services.GuiController.IsBackstageOpen = false;
				this.#a.#xl(text);
				this.#b.LoadedFilePath = text;
				value = true;
			}
			catch (#bYd)
			{
			}
			catch (Exception #ob)
			{
				if (!flag)
				{
					this.CurrentlyLoadedFilePath = null;
				}
				this.#f.#bzc(#ob, #Phc.#3hc(107405041), #Ic);
			}
			return new bool?(value);
		}

		// Token: 0x06001654 RID: 5716 RVA: 0x00017155 File Offset: 0x00015355
		private string #TK()
		{
			if (string.IsNullOrEmpty(this.CurrentProject))
			{
				return null;
			}
			return Path.GetFileNameWithoutExtension(this.CurrentProject);
		}

		// Token: 0x06001655 RID: 5717 RVA: 0x000B49E0 File Offset: 0x000B2BE0
		private void #UK(ref string #2o, string #VK)
		{
			List<#L1c> #m2c = new List<#L1c>
			{
				new #L1c(#Phc.#3hc(107405591), #b1d.CurrentExtension),
				new #L1c(#Phc.#3hc(107404988), #b1d.LegacyTextExtension)
			};
			string #zK = this.#2K(#2o);
			#62c #21c = new #62c(#m2c, #b1d.CurrentExtension, #zK)
			{
				InitialFileName = #VK,
				CreateBackupOfExistingFile = true
			};
			#2o = this.#e.#11c(#21c);
		}

		// Token: 0x06001656 RID: 5718 RVA: 0x000B4A68 File Offset: 0x000B2C68
		private bool? #WK()
		{
			if (this.#g.HasChanges)
			{
				string #SSc = Strings.StringTheProjectHasBeenModifiedAndNotSaved.#z2d(true) + Strings.StringWouldYouLikeToSaveTheProjectFirst.#J2d();
				MessageBoxResult messageBoxResult = this.#h.#od(this.OwnerWindow, #SSc, this.#m.ApplicationName, MessageBoxButton.YesNoCancel, MessageBoxImage.Question, MessageBoxResult.Yes, MessageBoxOptions.None);
				if (messageBoxResult == MessageBoxResult.Cancel)
				{
					return null;
				}
				if (messageBoxResult != MessageBoxResult.Yes)
				{
					if (messageBoxResult != MessageBoxResult.No)
					{
					}
				}
				else if (!this.#AK().GetValueOrDefault())
				{
					return new bool?(false);
				}
			}
			return new bool?(true);
		}

		// Token: 0x06001657 RID: 5719 RVA: 0x000B4B14 File Offset: 0x000B2D14
		private void #XK(ColumnStorageModel #YK, bool #ZK, Action #yf = null)
		{
			#6K.#yUb #yUb = new #6K.#yUb();
			#yUb.#a = this;
			#yUb.#b = #YK;
			#yUb.#c = #ZK;
			#yUb.#d = #yf;
			LayoutHelper.BeginInvokeOnApplicationThread(new Action(#yUb.#a0b));
		}

		// Token: 0x06001658 RID: 5720 RVA: 0x000B4B64 File Offset: 0x000B2D64
		private string #0K(string #1K)
		{
			if (string.IsNullOrEmpty(#1K) || !this.#e.#X1c(#1K))
			{
				RecentDocumentListEntry recentDocumentListEntry = this.#a.RecentProjects.FirstOrDefault(new Func<RecentDocumentListEntry, bool>(this.#ZUh));
				#1K = ((recentDocumentListEntry != null) ? recentDocumentListEntry.DirectoryPath : null);
			}
			return #1K;
		}

		// Token: 0x06001659 RID: 5721 RVA: 0x000B4BC0 File Offset: 0x000B2DC0
		private string #2K(string #3K)
		{
			string #1K = null;
			if (!string.IsNullOrEmpty(#3K))
			{
				#1K = Path.GetDirectoryName(#3K);
			}
			return this.#0K(#1K);
		}

		// Token: 0x0600165A RID: 5722 RVA: 0x0001717D File Offset: 0x0001537D
		private void #4K()
		{
			this.#l.#XKb(ProjectScopeActivationParameters.Default);
		}

		// Token: 0x0600165B RID: 5723 RVA: 0x0001719B File Offset: 0x0001539B
		[CompilerGenerated]
		private bool #ZUh(RecentDocumentListEntry #Rf)
		{
			return this.#e.#X1c(#Rf.DirectoryPath);
		}

		// Token: 0x040008E8 RID: 2280
		private readonly #JI #a;

		// Token: 0x040008E9 RID: 2281
		private readonly #oW #b;

		// Token: 0x040008EA RID: 2282
		private readonly #bDc #c;

		// Token: 0x040008EB RID: 2283
		private readonly #9V #d;

		// Token: 0x040008EC RID: 2284
		private readonly #v2c #e;

		// Token: 0x040008ED RID: 2285
		private readonly #rBc #f;

		// Token: 0x040008EE RID: 2286
		private readonly #XV #g;

		// Token: 0x040008EF RID: 2287
		private readonly #8Sc #h;

		// Token: 0x040008F0 RID: 2288
		private readonly #xU #i;

		// Token: 0x040008F1 RID: 2289
		private readonly #5Ic #j;

		// Token: 0x040008F2 RID: 2290
		private readonly ILogger #k;

		// Token: 0x040008F3 RID: 2291
		private readonly #BLb #l;

		// Token: 0x040008F4 RID: 2292
		private readonly #xAc #m;

		// Token: 0x040008F5 RID: 2293
		private string #n;

		// Token: 0x040008F6 RID: 2294
		private string #o;

		// Token: 0x040008F7 RID: 2295
		[CompilerGenerated]
		private EventHandler #p;

		// Token: 0x040008F8 RID: 2296
		[CompilerGenerated]
		private readonly ICoreServices #q;

		// Token: 0x020002A9 RID: 681
		[CompilerGenerated]
		private sealed class #yUb
		{
			// Token: 0x0600165D RID: 5725 RVA: 0x000B4BF4 File Offset: 0x000B2DF4
			internal void #a0b()
			{
				this.#a.#4K();
				this.#a.Services.MessageBus.#zV(this.#b, this.#c, false);
				Action action = this.#d;
				if (action == null)
				{
					return;
				}
				action();
			}

			// Token: 0x040008F9 RID: 2297
			public #6K #a;

			// Token: 0x040008FA RID: 2298
			public ColumnStorageModel #b;

			// Token: 0x040008FB RID: 2299
			public bool #c;

			// Token: 0x040008FC RID: 2300
			public Action #d;
		}
	}
}
