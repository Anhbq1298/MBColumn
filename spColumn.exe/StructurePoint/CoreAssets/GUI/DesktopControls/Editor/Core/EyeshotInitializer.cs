using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using #7hc;
using devDept.Diagnostic;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using StructurePoint.CoreAssets.Logger;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core
{
	// Token: 0x02000AEF RID: 2799
	public sealed class EyeshotInitializer
	{
		// Token: 0x17001A21 RID: 6689
		// (get) Token: 0x06005B61 RID: 23393 RVA: 0x0004C78E File Offset: 0x0004A98E
		public static EyeshotInitializer Instance { get; } = new EyeshotInitializer();

		// Token: 0x06005B62 RID: 23394 RVA: 0x0004C795 File Offset: 0x0004A995
		public void Register(string name, Action initializer)
		{
			if (name == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107422010));
			}
			Dictionary<string, Action> dictionary = this.actions;
			if (initializer == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107422001));
			}
			dictionary[name] = initializer;
		}

		// Token: 0x06005B63 RID: 23395 RVA: 0x0016F9C8 File Offset: 0x0016DBC8
		public void StartInitialize(ILogger logger)
		{
			this.activeLogger = logger;
			NativeMethods.MM_BeginPeriod(1U);
			string name = #Phc.#3hc(107421952);
			Action initializer;
			if ((initializer = EyeshotInitializer.<>O.<0>__InitializeEyeshot) == null)
			{
				initializer = (EyeshotInitializer.<>O.<0>__InitializeEyeshot = new Action(EyeshotInitializer.InitializeEyeshot));
			}
			this.Register(name, initializer);
			string name2 = #Phc.#3hc(107421415);
			Action initializer2;
			if ((initializer2 = EyeshotInitializer.<>O.<1>__InitializeAccelerationHelper) == null)
			{
				initializer2 = (EyeshotInitializer.<>O.<1>__InitializeAccelerationHelper = new Action(EyeshotInitializer.InitializeAccelerationHelper));
			}
			this.Register(name2, initializer2);
			this.tasks = new Task[this.actions.Count];
			List<KeyValuePair<string, Action>> list = this.actions.ToList<KeyValuePair<string, Action>>();
			for (int i = 0; i < list.Count; i++)
			{
				KeyValuePair<string, Action> action = list[i];
				this.tasks[i] = Task.Factory.StartNew(delegate()
				{
					this.Run(action.Value, action.Key);
				});
			}
			this.InitializeControl();
		}

		// Token: 0x06005B64 RID: 23396 RVA: 0x0016FAAC File Offset: 0x0016DCAC
		public void WaitForInitializers()
		{
			if (this.waitCompleted)
			{
				return;
			}
			Task.WaitAll(this.tasks);
			Ignore.#14d<Exception>(delegate()
			{
				Thread thread = this.thread;
				if (thread == null)
				{
					return;
				}
				thread.Join();
			}, null);
			ILogger logger = this.activeLogger;
			if (logger != null)
			{
				logger.Log(LoggingLevel.Debug, () => string.Join(Environment.NewLine, this.benchmarks));
			}
			this.waitCompleted = true;
		}

		// Token: 0x06005B65 RID: 23397 RVA: 0x0016FB08 File Offset: 0x0016DD08
		private static void InitializeEyeshot()
		{
			List<string> values = new List<string>();
			Ignore.#14d<Exception>(delegate()
			{
				values.Add(MachineInfo.ProcessorName);
			}, null);
			Ignore.#14d<Exception>(delegate()
			{
				values.Add(MachineInfo.Model);
			}, null);
			Ignore.#14d<Exception>(delegate()
			{
				values.Add(MachineInfo.OsName);
			}, null);
			Ignore.#14d<Exception>(delegate()
			{
				values.Add(MachineInfo.OsArchitecture);
			}, null);
			if (values.Count <= 0)
			{
				throw new InvalidOperationException();
			}
		}

		// Token: 0x06005B66 RID: 23398 RVA: 0x0004C7CB File Offset: 0x0004A9CB
		private static void InitializeAccelerationHelper()
		{
			EditorHardwareAccelerationHelper.RunsOnVirtualMachine();
		}

		// Token: 0x06005B67 RID: 23399 RVA: 0x0004C7D3 File Offset: 0x0004A9D3
		private void InitializeControl()
		{
			this.thread = new Thread(delegate(object _)
			{
				try
				{
					Task.WaitAll(this.tasks);
					this.Run(delegate
					{
						EyeshotEditor eyeshotEditor = new EyeshotEditor(false);
						eyeshotEditor.InitBatchImageExport(new System.Windows.Size(500.0, 500.0));
						eyeshotEditor.Entities.Add(new devDept.Eyeshot.Entities.Point(new Point3D()));
						eyeshotEditor.Invalidate();
						eyeshotEditor.ExportToPng(new System.Drawing.Size(500, 500), null, true);
						eyeshotEditor.Dispose();
					}, #Phc.#3hc(107421382));
				}
				catch
				{
				}
			});
			this.thread.SetApartmentState(ApartmentState.STA);
			this.thread.Start();
		}

		// Token: 0x06005B68 RID: 23400 RVA: 0x0016FB84 File Offset: 0x0016DD84
		private void Run(Action action, string name)
		{
			Stopwatch stopwatch = Stopwatch.StartNew();
			try
			{
				action();
			}
			catch (Exception)
			{
			}
			finally
			{
				stopwatch.Stop();
			}
		}

		// Token: 0x040025FF RID: 9727
		private Task[] tasks = new Task[0];

		// Token: 0x04002600 RID: 9728
		private ILogger activeLogger;

		// Token: 0x04002601 RID: 9729
		private Thread thread;

		// Token: 0x04002602 RID: 9730
		private readonly Dictionary<string, Action> actions = new Dictionary<string, Action>();

		// Token: 0x04002603 RID: 9731
		private readonly ConcurrentBag<string> benchmarks = new ConcurrentBag<string>();

		// Token: 0x04002604 RID: 9732
		private bool waitCompleted;

		// Token: 0x02000AF0 RID: 2800
		[CompilerGenerated]
		private static class <>O
		{
			// Token: 0x04002606 RID: 9734
			public static Action <0>__InitializeEyeshot;

			// Token: 0x04002607 RID: 9735
			public static Action <1>__InitializeAccelerationHelper;
		}
	}
}
