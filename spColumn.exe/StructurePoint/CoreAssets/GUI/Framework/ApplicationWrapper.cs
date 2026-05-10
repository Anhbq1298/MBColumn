using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using #7hc;
using #ezc;
using #UYd;
using StructurePoint.CoreAssets.GUI.FailureSurfaceVisualization;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace StructurePoint.CoreAssets.GUI.Framework
{
	// Token: 0x02000B3D RID: 2877
	public sealed class ApplicationWrapper : #FBc
	{
		// Token: 0x06005E0D RID: 24077 RVA: 0x001767B4 File Offset: 0x001749B4
		private ApplicationWrapper()
		{
			ApplicationWrapper.#xTb #xTb = new ApplicationWrapper.#xTb();
			base..ctor();
			#xTb.#a = this;
			this.#c = new HashSet<string>();
			if (Application.Current != null)
			{
				this.#d = Application.Current;
				return;
			}
			#xTb.#b = new ManualResetEvent(false);
			Thread thread = new Thread(new ParameterizedThreadStart(#xTb.#O7b));
			thread.SetApartmentState(ApartmentState.STA);
			thread.IsBackground = false;
			thread.Start();
			#xTb.#b.WaitOne();
		}

		// Token: 0x17001AC5 RID: 6853
		// (get) Token: 0x06005E0E RID: 24078 RVA: 0x00176830 File Offset: 0x00174A30
		[DebuggerHidden]
		public static ApplicationWrapper Instance
		{
			get
			{
				if (ApplicationWrapper.#b == null)
				{
					object obj = ApplicationWrapper.#a;
					object obj2;
					if (5 != 0)
					{
						obj2 = obj;
					}
					bool flag = false;
					bool flag2;
					if (4 != 0)
					{
						flag2 = flag;
						goto IL_17;
					}
					try
					{
						do
						{
							IL_17:
							object obj3 = obj2;
							if (8 != 0)
							{
								Monitor.Enter(obj3, ref flag2);
							}
						}
						while (-1 == 0);
						if (ApplicationWrapper.#b == null)
						{
							ApplicationWrapper.#b = new ApplicationWrapper();
						}
					}
					finally
					{
						while (4 != 0 && flag2)
						{
							if (!false)
							{
								Monitor.Exit(obj2);
								break;
							}
						}
					}
				}
				return ApplicationWrapper.#b;
			}
		}

		// Token: 0x06005E0F RID: 24079 RVA: 0x001768AC File Offset: 0x00174AAC
		public void #8zc(IEnumerable<string> #9zc)
		{
			ApplicationWrapper.#92b #92b = new ApplicationWrapper.#92b();
			ApplicationWrapper.#92b #92b2;
			if (2 != 0)
			{
				#92b2 = #92b;
			}
			#92b2.#a = #9zc;
			for (;;)
			{
				IL_10:
				#92b2.#b = this;
				while (false || #92b2.#a != null)
				{
					Action #nd = new Action(#92b2.#r8c);
					if (5 != 0)
					{
						this.#hAc(#nd);
					}
					if (false)
					{
						goto IL_10;
					}
					if (!false)
					{
						return;
					}
				}
				break;
			}
			throw new ArgumentNullException(#Phc.#3hc(107419949));
		}

		// Token: 0x06005E10 RID: 24080 RVA: 0x00176910 File Offset: 0x00174B10
		public void #aAc()
		{
			if (-1 != 0)
			{
				List<Uri>.Enumerator enumerator = this.#d.Resources.MergedDictionaries.Select(new Func<ResourceDictionary, Uri>(ApplicationWrapper.<>c.<>9.#s8c)).ToList<Uri>().GetEnumerator();
				List<Uri>.Enumerator enumerator2;
				if (!false)
				{
					enumerator2 = enumerator;
				}
				try
				{
					if (!false)
					{
						while (enumerator2.MoveNext())
						{
							Uri uri = enumerator2.Current;
							Uri uri2;
							if (!false)
							{
								uri2 = uri;
							}
							Collection<ResourceDictionary> mergedDictionaries = this.#d.Resources.MergedDictionaries;
							ResourceDictionary resourceDictionary = new ResourceDictionary();
							Uri source = uri2;
							if (!false)
							{
								resourceDictionary.Source = source;
							}
							if (7 != 0)
							{
								mergedDictionaries.Add(resourceDictionary);
							}
						}
					}
				}
				finally
				{
					if (3 != 0)
					{
						((IDisposable)enumerator2).Dispose();
					}
				}
			}
		}

		// Token: 0x06005E11 RID: 24081 RVA: 0x001769DC File Offset: 0x00174BDC
		public void #bAc(Uri #cAc)
		{
			string text = #cAc.ToString();
			string item;
			if (2 != 0)
			{
				item = text;
			}
			bool flag = this.#c.Contains(item);
			for (;;)
			{
				ResourceDictionary resourceDictionary2;
				if (flag)
				{
					if (-1 != 0)
					{
						break;
					}
				}
				else
				{
					ResourceDictionary resourceDictionary = new ResourceDictionary();
					if (!false)
					{
						resourceDictionary2 = resourceDictionary;
					}
				}
				if (8 != 0)
				{
					ResourceDictionary resourceDictionary3 = resourceDictionary2;
					if (3 != 0)
					{
						resourceDictionary3.Source = #cAc;
					}
					Collection<ResourceDictionary> mergedDictionaries = this.#d.Resources.MergedDictionaries;
					ResourceDictionary item2 = resourceDictionary2;
					if (2 != 0)
					{
						mergedDictionaries.Add(item2);
					}
				}
				flag = this.#c.Add(item);
				if (4 != 0)
				{
					return;
				}
			}
		}

		// Token: 0x06005E12 RID: 24082 RVA: 0x00176A54 File Offset: 0x00174C54
		public void #dAc(Uri #cAc)
		{
			ApplicationWrapper.#oWb #oWb2;
			for (;;)
			{
				ApplicationWrapper.#oWb #oWb = new ApplicationWrapper.#oWb();
				if (!false)
				{
					#oWb2 = #oWb;
				}
				if (5 != 0)
				{
					#oWb2.#a = this;
					#oWb2.#b = #cAc;
					if (3 == 0)
					{
						return;
					}
					if (!false)
					{
						break;
					}
				}
			}
			Dispatcher dispatcher = this.#d.Dispatcher;
			Action callback = new Action(#oWb2.#t8c);
			if (5 != 0)
			{
				dispatcher.Invoke(callback);
			}
		}

		// Token: 0x06005E13 RID: 24083 RVA: 0x00176AA8 File Offset: 0x00174CA8
		public Task #eAc(Uri #cAc)
		{
			ApplicationWrapper.#21b #21b2;
			for (;;)
			{
				ApplicationWrapper.#21b #21b = new ApplicationWrapper.#21b();
				if (5 != 0)
				{
					#21b2 = #21b;
				}
				for (;;)
				{
					#21b2.#a = this;
					if (false)
					{
						break;
					}
					#21b2.#b = #cAc;
					for (;;)
					{
						object #Rf = #21b2.#b;
						string #R0d = #Phc.#3hc(107419940);
						Component #x6c = Component.GUIFramework;
						string #Qic = #Phc.#3hc(107419967);
						if (7 != 0)
						{
							#X0d.#V0d(#Rf, #R0d, #x6c, #Qic);
						}
						if (3 == 0)
						{
							break;
						}
						if (!false)
						{
							goto Block_2;
						}
					}
				}
			}
			Block_2:
			return this.#jAc(new Action(#21b2.#u8c));
		}

		// Token: 0x06005E14 RID: 24084 RVA: 0x0004E558 File Offset: 0x0004C758
		public Task #fAc(Action #nd)
		{
			if (true)
			{
				string #R0d = #Phc.#3hc(107351365);
				Component #x6c = Component.GUIFramework;
				string #Qic = #Phc.#3hc(107419370);
				if (3 != 0)
				{
					#X0d.#V0d(#nd, #R0d, #x6c, #Qic);
				}
			}
			return this.#jAc(#nd);
		}

		// Token: 0x06005E15 RID: 24085 RVA: 0x00176B14 File Offset: 0x00174D14
		public Thread #gAc(Action #nd)
		{
			string #R0d = #Phc.#3hc(107351365);
			Component #x6c = Component.GUIFramework;
			string #Qic = #Phc.#3hc(107419349);
			if (!false)
			{
				#X0d.#V0d(#nd, #R0d, #x6c, #Qic);
			}
			Thread thread = new Thread(new ThreadStart(#nd.Invoke));
			thread.SetApartmentState(ApartmentState.STA);
			thread.Start();
			return thread;
		}

		// Token: 0x06005E16 RID: 24086 RVA: 0x0004E589 File Offset: 0x0004C789
		public void #hAc(Action #nd)
		{
			Dispatcher dispatcher = this.#d.Dispatcher;
			if (!false)
			{
				dispatcher.Invoke(#nd);
			}
		}

		// Token: 0x06005E17 RID: 24087 RVA: 0x0004E5A3 File Offset: 0x0004C7A3
		public void #iAc()
		{
			Dispatcher dispatcher = this.#d.Dispatcher;
			Action callback = new Action(this.#d.Shutdown);
			if (4 != 0)
			{
				dispatcher.Invoke(callback);
			}
		}

		// Token: 0x06005E18 RID: 24088 RVA: 0x0004E5CD File Offset: 0x0004C7CD
		private Task #jAc(Action #nd)
		{
			return this.#d.Dispatcher.BeginInvoke(#nd, new object[0]).Task;
		}

		// Token: 0x04002702 RID: 9986
		private static readonly object #a = new object();

		// Token: 0x04002703 RID: 9987
		private static volatile ApplicationWrapper #b;

		// Token: 0x04002704 RID: 9988
		private readonly HashSet<string> #c;

		// Token: 0x04002705 RID: 9989
		private Application #d;

		// Token: 0x02000B3F RID: 2879
		[CompilerGenerated]
		private sealed class #oWb
		{
			// Token: 0x06005E1E RID: 24094 RVA: 0x0004E60B File Offset: 0x0004C80B
			internal void #t8c()
			{
				ApplicationWrapper applicationWrapper = this.#a;
				Uri #cAc = this.#b;
				if (!false)
				{
					applicationWrapper.#bAc(#cAc);
				}
			}

			// Token: 0x04002708 RID: 9992
			public ApplicationWrapper #a;

			// Token: 0x04002709 RID: 9993
			public Uri #b;
		}

		// Token: 0x02000B40 RID: 2880
		[CompilerGenerated]
		private sealed class #21b
		{
			// Token: 0x06005E20 RID: 24096 RVA: 0x0004E625 File Offset: 0x0004C825
			internal void #u8c()
			{
				ApplicationWrapper applicationWrapper = this.#a;
				Uri #cAc = this.#b;
				if (!false)
				{
					applicationWrapper.#bAc(#cAc);
				}
			}

			// Token: 0x0400270A RID: 9994
			public ApplicationWrapper #a;

			// Token: 0x0400270B RID: 9995
			public Uri #b;
		}

		// Token: 0x02000B41 RID: 2881
		[CompilerGenerated]
		private sealed class #xTb
		{
			// Token: 0x06005E22 RID: 24098 RVA: 0x00176B64 File Offset: 0x00174D64
			internal void #O7b(object #M9b)
			{
				try
				{
					this.#a.#d = new ApplicationWrapperApp();
					if (!false)
					{
						Application #d = this.#a.#d;
						ShutdownMode shutdownMode = ShutdownMode.OnExplicitShutdown;
						if (!false)
						{
							#d.ShutdownMode = shutdownMode;
						}
					}
					this.#b.Set();
					do
					{
						this.#a.#d.Run();
					}
					while (false);
				}
				catch (Exception value)
				{
					Console.WriteLine(value);
					throw;
				}
			}

			// Token: 0x0400270C RID: 9996
			public ApplicationWrapper #a;

			// Token: 0x0400270D RID: 9997
			public ManualResetEvent #b;
		}

		// Token: 0x02000B42 RID: 2882
		[CompilerGenerated]
		private sealed class #92b
		{
			// Token: 0x06005E24 RID: 24100 RVA: 0x00176BD8 File Offset: 0x00174DD8
			internal void #r8c()
			{
				IEnumerator<string> enumerator = this.#a.GetEnumerator();
				IEnumerator<string> enumerator2;
				if (!false)
				{
					enumerator2 = enumerator;
				}
				try
				{
					while (enumerator2.MoveNext())
					{
						string text = enumerator2.Current;
						string uriString;
						if (!false)
						{
							uriString = text;
						}
						ApplicationWrapper applicationWrapper = this.#b;
						Uri #cAc = new Uri(uriString, UriKind.RelativeOrAbsolute);
						if (!false)
						{
							applicationWrapper.#bAc(#cAc);
						}
					}
				}
				finally
				{
					for (;;)
					{
						if (enumerator2 != null)
						{
							goto IL_44;
						}
						IL_4D:
						if (!true)
						{
							continue;
						}
						if (!false)
						{
							break;
						}
						IL_44:
						if (-1 != 0)
						{
							enumerator2.Dispose();
							goto IL_4D;
						}
						goto IL_4D;
					}
				}
			}

			// Token: 0x0400270E RID: 9998
			public IEnumerable<string> #a;

			// Token: 0x0400270F RID: 9999
			public ApplicationWrapper #b;
		}
	}
}
