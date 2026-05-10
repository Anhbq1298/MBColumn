using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using #7hc;
using #bne;
using #c1d;
using #coe;
using #cYd;
using #Gke;
using #Ine;
using #J5d;
using #Jie;
using #Lme;
using #npe;
using #wje;
using #x5d;
using #xKe;
using Alphaleonis.Win32.Filesystem;
using StructurePoint.CoreAssets.AppManager.Column.Storage.Current;
using StructurePoint.CoreAssets.AppManager.Column.Storage.Current.DXF;
using StructurePoint.CoreAssets.AppManager.Column.Storage.ImportExport;
using StructurePoint.CoreAssets.AppManager.Column.Storage.Legacy;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.CoreAssets.Storage;
using StructurePoint.CoreAssets.Storage.File.Input;

namespace StructurePoint.CoreAssets.AppManager.Column.Storage
{
	// Token: 0x020010AC RID: 4268
	public sealed class StorageProvider : #x5d.#z5d, #Ioe
	{
		// Token: 0x06009186 RID: 37254 RVA: 0x000753A2 File Offset: 0x000735A2
		public StorageProvider()
		{
			this.#a.Add(new #Kme());
		}

		// Token: 0x140001AF RID: 431
		// (add) Token: 0x06009187 RID: 37255 RVA: 0x001ECF0C File Offset: 0x001EB10C
		// (remove) Token: 0x06009188 RID: 37256 RVA: 0x001ECF44 File Offset: 0x001EB144
		public event EventHandler OnUnsupportedInputProjectCreatedWithNewerApplication
		{
			[CompilerGenerated]
			add
			{
				EventHandler eventHandler = this.#b;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#b, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler eventHandler = this.#b;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#b, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x140001B0 RID: 432
		// (add) Token: 0x06009189 RID: 37257 RVA: 0x001ECF7C File Offset: 0x001EB17C
		// (remove) Token: 0x0600918A RID: 37258 RVA: 0x001ECFB4 File Offset: 0x001EB1B4
		public event EventHandler OnUnsupportedInputFileNoDataFound
		{
			[CompilerGenerated]
			add
			{
				EventHandler eventHandler = this.#c;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#c, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler eventHandler = this.#c;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#c, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x140001B1 RID: 433
		// (add) Token: 0x0600918B RID: 37259 RVA: 0x001ECFEC File Offset: 0x001EB1EC
		// (remove) Token: 0x0600918C RID: 37260 RVA: 0x001ED024 File Offset: 0x001EB224
		public event EventHandler OnOpenInputFileWithNewerFileVersions
		{
			[CompilerGenerated]
			add
			{
				EventHandler eventHandler = this.#d;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#d, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler eventHandler = this.#d;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#d, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x140001B2 RID: 434
		// (add) Token: 0x0600918D RID: 37261 RVA: 0x001ED05C File Offset: 0x001EB25C
		// (remove) Token: 0x0600918E RID: 37262 RVA: 0x001ED094 File Offset: 0x001EB294
		public event EventHandler<#foe> OnOverwriteOfInputProjectCreatedWithNewerApplicationVersion
		{
			[CompilerGenerated]
			add
			{
				EventHandler<#foe> eventHandler = this.#e;
				EventHandler<#foe> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#foe> value2 = (EventHandler<#foe>)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#foe>>(ref this.#e, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<#foe> eventHandler = this.#e;
				EventHandler<#foe> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#foe> value2 = (EventHandler<#foe>)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#foe>>(ref this.#e, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x140001B3 RID: 435
		// (add) Token: 0x0600918F RID: 37263 RVA: 0x001ED0CC File Offset: 0x001EB2CC
		// (remove) Token: 0x06009190 RID: 37264 RVA: 0x001ED104 File Offset: 0x001EB304
		public event EventHandler<#Mie> OnLateralLoadsCompatibilityModeRequested
		{
			[CompilerGenerated]
			add
			{
				EventHandler<#Mie> eventHandler = this.#f;
				EventHandler<#Mie> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#Mie> value2 = (EventHandler<#Mie>)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#Mie>>(ref this.#f, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<#Mie> eventHandler = this.#f;
				EventHandler<#Mie> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#Mie> value2 = (EventHandler<#Mie>)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#Mie>>(ref this.#f, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x17002A5C RID: 10844
		// (get) Token: 0x06009191 RID: 37265 RVA: 0x000753D3 File Offset: 0x000735D3
		// (set) Token: 0x06009192 RID: 37266 RVA: 0x000753DB File Offset: 0x000735DB
		public Version DefaultInputFileVersion { get; set; } = new Version(1, 0, 0);

		// Token: 0x06009193 RID: 37267 RVA: 0x000753E4 File Offset: 0x000735E4
		public #boe #0ie(Stream #gp)
		{
			return new #yje().#xje(#gp);
		}

		// Token: 0x06009194 RID: 37268 RVA: 0x000753F1 File Offset: 0x000735F1
		public void #1ie(Stream #gp, #boe #2ie)
		{
			new #yje().#y0d(#2ie).CopyTo(#gp);
		}

		// Token: 0x06009195 RID: 37269 RVA: 0x00075404 File Offset: 0x00073604
		public #Xoe #3ie(Stream #gp, SectionImportExportType #8Q)
		{
			return new #ZLe().#GD(#gp, #8Q);
		}

		// Token: 0x06009196 RID: 37270 RVA: 0x00075412 File Offset: 0x00073612
		public void #4ie(ColumnStorageModel #Od, Stream #gp, SectionImportExportType #8Q)
		{
			new #ZLe().#xRb(#gp, #Od, #8Q);
		}

		// Token: 0x06009197 RID: 37271 RVA: 0x001ED13C File Offset: 0x001EB33C
		public #9oe #Cjc(string #So, #ape #mA)
		{
			if (#So == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107226730));
			}
			#9oe result;
			using (Stream stream = this.#U1c(#So))
			{
				#Hoe? #Hoe = this.#kje(#So);
				if (#Hoe == null)
				{
					throw new NotSupportedException(Strings.StringTheSpecifiedFormatIsNotSupported.#z2d());
				}
				result = this.#Cjc(stream, #mA, #Hoe.Value);
			}
			return result;
		}

		// Token: 0x06009198 RID: 37272 RVA: 0x001ED1B4 File Offset: 0x001EB3B4
		public #9oe #Cjc(Stream #gp, #ape #mA, #Hoe #cA)
		{
			if (#gp == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107377314));
			}
			switch (#cA)
			{
			case #Hoe.#a:
				return this.#9ie(#gp);
			case #Hoe.#b:
				return this.#gje(#gp);
			case #Hoe.#c:
				return this.#hje(#gp);
			default:
				throw new NotSupportedException(Strings.StringTheSpecifiedFormatIsNotSupported.#z2d());
			}
		}

		// Token: 0x06009199 RID: 37273 RVA: 0x00075421 File Offset: 0x00073621
		public void #zl(ColumnStorageModel #Od, Stream #gp, #3oe #mA, #Hoe #cA)
		{
			if (#cA == #Hoe.#a)
			{
				this.#ije(#Od, #gp, #mA);
				return;
			}
			if (#cA != #Hoe.#c)
			{
				throw new NotSupportedException(Strings.StringTheSpecifiedFormatIsNotSupported.#z2d());
			}
			this.#jje(#Od, #gp);
		}

		// Token: 0x0600919A RID: 37274 RVA: 0x00075450 File Offset: 0x00073650
		public void #5ie(ColumnStorageModel #Od, Stream #gp)
		{
			new DxfFormatWriter().#npb(#gp, #Od);
		}

		// Token: 0x0600919B RID: 37275 RVA: 0x0007545E File Offset: 0x0007365E
		public #Uoe #6ie(Stream #gp, #dai #mA)
		{
			return new DxfFormatReader().#Cjc(#gp, #mA);
		}

		// Token: 0x0600919C RID: 37276 RVA: 0x0007546C File Offset: 0x0007366C
		public List<FactoredLoad> #ZE(Stream #gp)
		{
			return new #2me(#gp).#ZE();
		}

		// Token: 0x0600919D RID: 37277 RVA: 0x00075479 File Offset: 0x00073679
		public List<ServiceLoad> #7ie(Stream #gp)
		{
			return new #2me(#gp).#7ie();
		}

		// Token: 0x0600919E RID: 37278 RVA: 0x00075486 File Offset: 0x00073686
		public void #8ie(ColumnStorageModel #Od, LoadType #GB, Stream #gp)
		{
			new LoadsExporter(#Od, #GB, #gp).#xRb();
		}

		// Token: 0x0600919F RID: 37279 RVA: 0x001ED210 File Offset: 0x001EB410
		public void #zl(ColumnStorageModel #Od, string #So, #3oe #mA)
		{
			using (Stream stream = this.#T1c(#So))
			{
				#Hoe? #Hoe = this.#kje(#So);
				if (#Hoe == null)
				{
					throw new NotSupportedException(Strings.StringTheSpecifiedFormatIsNotSupported.#z2d());
				}
				this.#zl(#Od, stream, #mA, #Hoe.Value);
			}
		}

		// Token: 0x060091A0 RID: 37280 RVA: 0x001ED274 File Offset: 0x001EB474
		public #9oe #9ie(Stream #gp)
		{
			StorageProvider.#aVb #aVb = new StorageProvider.#aVb();
			#aVb.#a = this;
			#S5d #S5d = new FileInputStorageProvider(#gp).#V5d(this);
			#aVb.#b = #S5d.Entries.Where(new Func<IStorageEntry, bool>(#aVb.#Xaf)).OrderByDescending(new Func<IStorageEntry, Version>(StorageProvider.<>c.<>9.#1af)).FirstOrDefault<IStorageEntry>();
			if (#aVb.#b == null)
			{
				if (#S5d.Entries.Any(new Func<IStorageEntry, bool>(#aVb.#Yaf)))
				{
					this.#aje();
				}
				else
				{
					this.#bje();
				}
				return #9oe.#4oe();
			}
			if (#S5d.Entries.Any(new Func<IStorageEntry, bool>(#aVb.#Zaf)))
			{
				this.#cje();
			}
			ColumnStorageModel columnStorageModel = this.#a.First(new Func<#Goe, bool>(#aVb.#0af)).#Cjc(#S5d);
			this.#fje(columnStorageModel);
			#9oe #9oe = new #9oe(columnStorageModel, true);
			if (columnStorageModel != null)
			{
				#9oe.OriginalLoadType = columnStorageModel.Options.ActiveLoad;
				#wpe.#spe(columnStorageModel);
				this.#Z9h(columnStorageModel);
			}
			return #9oe;
		}

		// Token: 0x060091A1 RID: 37281 RVA: 0x00075495 File Offset: 0x00073695
		protected void #aje()
		{
			EventHandler eventHandler = this.#b;
			if (eventHandler == null)
			{
				return;
			}
			eventHandler(this, EventArgs.Empty);
		}

		// Token: 0x060091A2 RID: 37282 RVA: 0x000754AD File Offset: 0x000736AD
		protected void #bje()
		{
			EventHandler eventHandler = this.#c;
			if (eventHandler == null)
			{
				return;
			}
			eventHandler(this, EventArgs.Empty);
		}

		// Token: 0x060091A3 RID: 37283 RVA: 0x000754C5 File Offset: 0x000736C5
		protected void #cje()
		{
			EventHandler eventHandler = this.#d;
			if (eventHandler == null)
			{
				return;
			}
			eventHandler(this, EventArgs.Empty);
		}

		// Token: 0x060091A4 RID: 37284 RVA: 0x000754DD File Offset: 0x000736DD
		protected void #dje(#foe #He)
		{
			EventHandler<#foe> eventHandler = this.#e;
			if (eventHandler == null)
			{
				return;
			}
			eventHandler(this, #He);
		}

		// Token: 0x060091A5 RID: 37285 RVA: 0x000754F1 File Offset: 0x000736F1
		protected void #eje(#Mie #He)
		{
			EventHandler<#Mie> eventHandler = this.#f;
			if (eventHandler == null)
			{
				return;
			}
			eventHandler(this, #He);
		}

		// Token: 0x060091A6 RID: 37286 RVA: 0x001ED384 File Offset: 0x001EB584
		private void #Z9h(ColumnStorageModel #Od)
		{
			if (!string.IsNullOrEmpty(#Od.ProjectInfo.Project) && #Od.ProjectInfo.Project.Length > 128)
			{
				#Od.ProjectInfo.Project = #Od.ProjectInfo.Project.Substring(0, 128);
			}
			if (!string.IsNullOrEmpty(#Od.ProjectInfo.ColumnId) && #Od.ProjectInfo.ColumnId.Length > 128)
			{
				#Od.ProjectInfo.ColumnId = #Od.ProjectInfo.ColumnId.Substring(0, 128);
			}
			if (!string.IsNullOrEmpty(#Od.ProjectInfo.Engineer) && #Od.ProjectInfo.Engineer.Length > 128)
			{
				#Od.ProjectInfo.Engineer = #Od.ProjectInfo.Engineer.Substring(0, 128);
			}
		}

		// Token: 0x060091A7 RID: 37287 RVA: 0x00075505 File Offset: 0x00073705
		private void #fje(ColumnStorageModel #Od)
		{
			new #rLe().#NQ(#Od.MaterialProperties, #Od.Options.Unit, #Od.Options.Code);
		}

		// Token: 0x060091A8 RID: 37288 RVA: 0x00054050 File Offset: 0x00052250
		private Stream #T1c(string #So)
		{
			return Alphaleonis.Win32.Filesystem.File.Open(#So, FileMode.Create, FileAccess.ReadWrite, FileShare.None);
		}

		// Token: 0x060091A9 RID: 37289 RVA: 0x001ED470 File Offset: 0x001EB670
		private #9oe #gje(Stream #gp)
		{
			#Hle mainModel;
			bool flag = new #Kje(new DefaultColFormatReaderConfiguration
			{
				GetLateralLoadsCompatibilityMode = new Func<LateralLoadsCompatibilityMode>(this.#oje)
			}).#Cjc(#gp, out mainModel) == 0;
			ColumnStorageModel columnStorageModel = flag ? new ColumnStorageModel(mainModel) : new ColumnStorageModel();
			#9oe #9oe = new #9oe(columnStorageModel, flag);
			if (flag)
			{
				#9oe.OriginalLoadType = columnStorageModel.Options.ActiveLoad;
				#wpe.#spe(columnStorageModel);
				#wpe.#tpe(columnStorageModel);
				#Wpe.#tpe(columnStorageModel);
				#wpe.#rpe(columnStorageModel);
				this.#Z9h(columnStorageModel);
			}
			this.#fje(columnStorageModel);
			return #9oe;
		}

		// Token: 0x060091AA RID: 37290 RVA: 0x001ED4FC File Offset: 0x001EB6FC
		private #9oe #hje(Stream #gp)
		{
			#9oe #9oe = new #Iie().#Cjc(#gp);
			if (#9oe.Model != null)
			{
				this.#fje(#9oe.Model);
				this.#Z9h(#9oe.Model);
			}
			return #9oe;
		}

		// Token: 0x060091AB RID: 37291 RVA: 0x001ED538 File Offset: 0x001EB738
		private void #ije(ColumnStorageModel #Od, Stream #gp, #3oe #mA)
		{
			using (FileInputStorageProvider fileInputStorageProvider = new FileInputStorageProvider(#gp))
			{
				#Z5d #Z5d;
				if (this.#lje(fileInputStorageProvider, out #Z5d))
				{
					try
					{
						#Z5d #Z5d2 = #Z5d;
						string #wy = #Phc.#3hc(107290817);
						Assembly entryAssembly = Assembly.GetEntryAssembly();
						string #K5d;
						if (entryAssembly == null)
						{
							#K5d = null;
						}
						else
						{
							Version version = entryAssembly.GetName().Version;
							#K5d = ((version != null) ? version.ToString(3) : null);
						}
						#S5d #Y5d = #Z5d2.#T5d(new #I5d(#wy, #K5d, DateTime.Now, DateTime.Now, EncryptionMethod.None));
						foreach (#Goe #Goe in (#mA.EnableCompatibilityMode ? this.#a : this.#a.Where(new Func<#Goe, bool>(this.#09h)).ToList<#Goe>()))
						{
							#Goe.#npb(#Y5d, #Od);
						}
						#Z5d.#X5d(#Y5d, this);
					}
					finally
					{
						if (#Z5d != fileInputStorageProvider)
						{
							#Z5d.Dispose();
						}
					}
				}
			}
		}

		// Token: 0x060091AC RID: 37292 RVA: 0x0007552D File Offset: 0x0007372D
		private void #jje(ColumnStorageModel #Od, Stream #gp)
		{
			new #aoe(#Od).#npb(#gp);
		}

		// Token: 0x060091AD RID: 37293 RVA: 0x0007553B File Offset: 0x0007373B
		private Stream #U1c(string #So)
		{
			return Alphaleonis.Win32.Filesystem.File.Open(#So, FileMode.Open, FileAccess.Read, FileShare.Read);
		}

		// Token: 0x060091AE RID: 37294 RVA: 0x001ED644 File Offset: 0x001EB844
		private #Hoe? #kje(string #So)
		{
			if (#b1d.#80d(#So))
			{
				return new #Hoe?(#Hoe.#b);
			}
			if (#b1d.#90d(#So))
			{
				return new #Hoe?(#Hoe.#c);
			}
			if (#b1d.#a1d(#So))
			{
				return new #Hoe?(#Hoe.#a);
			}
			return null;
		}

		// Token: 0x060091AF RID: 37295 RVA: 0x001ED688 File Offset: 0x001EB888
		private bool #lje(#Z5d #mje, out #Z5d #nje)
		{
			#nje = null;
			try
			{
				if (#mje.#V5d(null).Entries.Any(new Func<IStorageEntry, bool>(this.#19h)))
				{
					#foe #foe = new #foe();
					this.#dje(#foe);
					switch (#foe.Action)
					{
					case #doe.#a:
						#nje = #mje;
						return true;
					case #doe.#b:
						#nje = new FileInputStorageProvider(#foe.FileName);
						return true;
					case #doe.#c:
						return false;
					default:
						throw new ArgumentOutOfRangeException();
					}
				}
			}
			catch (#y5d #y5d)
			{
				if (#y5d.ErrorType != #IYd.#b)
				{
					throw;
				}
			}
			#nje = #mje;
			return true;
		}

		// Token: 0x060091B0 RID: 37296 RVA: 0x001ED728 File Offset: 0x001EB928
		private LateralLoadsCompatibilityMode #oje()
		{
			#Mie #Mie = new #Mie(LateralLoadsCompatibilityMode.ConsiderAsWindLoads);
			this.#eje(#Mie);
			return #Mie.CompatibilityMode;
		}

		// Token: 0x060091B1 RID: 37297 RVA: 0x00075546 File Offset: 0x00073746
		[CompilerGenerated]
		private bool #09h(#Goe #Rf)
		{
			return #Rf.SupportedVersion == this.DefaultInputFileVersion;
		}

		// Token: 0x060091B2 RID: 37298 RVA: 0x00075559 File Offset: 0x00073759
		[CompilerGenerated]
		private bool #19h(IStorageEntry #Rf)
		{
			return #Rf.Version > this.DefaultInputFileVersion;
		}

		// Token: 0x04003D32 RID: 15666
		private readonly List<#Goe> #a = new List<#Goe>();

		// Token: 0x04003D33 RID: 15667
		[CompilerGenerated]
		private EventHandler #b;

		// Token: 0x04003D34 RID: 15668
		[CompilerGenerated]
		private EventHandler #c;

		// Token: 0x04003D35 RID: 15669
		[CompilerGenerated]
		private EventHandler #d;

		// Token: 0x04003D36 RID: 15670
		[CompilerGenerated]
		private EventHandler<#foe> #e;

		// Token: 0x04003D37 RID: 15671
		[CompilerGenerated]
		private EventHandler<#Mie> #f;

		// Token: 0x04003D38 RID: 15672
		[CompilerGenerated]
		private Version #g;

		// Token: 0x020010AE RID: 4270
		[CompilerGenerated]
		private sealed class #aVb
		{
			// Token: 0x060091B7 RID: 37303 RVA: 0x00075578 File Offset: 0x00073778
			internal bool #Xaf(IStorageEntry #Rf)
			{
				return #Rf.Version <= this.#a.DefaultInputFileVersion;
			}

			// Token: 0x060091B8 RID: 37304 RVA: 0x00075590 File Offset: 0x00073790
			internal bool #Yaf(IStorageEntry #Rf)
			{
				return #Rf.Version > this.#a.DefaultInputFileVersion;
			}

			// Token: 0x060091B9 RID: 37305 RVA: 0x00075590 File Offset: 0x00073790
			internal bool #Zaf(IStorageEntry #Rf)
			{
				return #Rf.Version > this.#a.DefaultInputFileVersion;
			}

			// Token: 0x060091BA RID: 37306 RVA: 0x000755A8 File Offset: 0x000737A8
			internal bool #0af(#Goe #Rf)
			{
				return #Rf.SupportedVersion == this.#b.Version;
			}

			// Token: 0x04003D3B RID: 15675
			public StorageProvider #a;

			// Token: 0x04003D3C RID: 15676
			public IStorageEntry #b;
		}
	}
}
