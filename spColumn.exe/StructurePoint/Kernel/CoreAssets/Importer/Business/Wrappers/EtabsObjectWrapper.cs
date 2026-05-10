using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting;
using System.Threading;
using System.Threading.Tasks;
using #23i;
using #7hc;
using #w1i;
using #x1i;
using ETABSv1;
using StructurePoint.Kernel.CoreAssets.Importer.Core;

namespace StructurePoint.Kernel.CoreAssets.Importer.Business.Wrappers
{
	// Token: 0x02000E94 RID: 3732
	internal sealed class EtabsObjectWrapper : cOAPI, #13i, #53i
	{
		// Token: 0x170027FB RID: 10235
		// (get) Token: 0x0600857E RID: 34174 RVA: 0x0006CB93 File Offset: 0x0006AD93
		#33i #53i.SapModel
		{
			get
			{
				return this.#d;
			}
		}

		// Token: 0x170027FC RID: 10236
		// (get) Token: 0x0600857F RID: 34175 RVA: 0x0006CB9B File Offset: 0x0006AD9B
		cSapModel cOAPI.SapModel
		{
			get
			{
				throw new InvalidOperationException(#Phc.#3hc(107228913));
			}
		}

		// Token: 0x06008580 RID: 34176 RVA: 0x0006CBAC File Offset: 0x0006ADAC
		private EtabsObjectWrapper(cOAPI etabsObject, #13i etabsConnection)
		{
			this.#c = etabsObject;
			this.#b = etabsConnection;
			this.#d = new EtabsModelWrapper(this, this.#c.SapModel);
		}

		// Token: 0x170027FD RID: 10237
		// (get) Token: 0x06008581 RID: 34177 RVA: 0x0006CBD9 File Offset: 0x0006ADD9
		// (set) Token: 0x06008582 RID: 34178 RVA: 0x0006CBE1 File Offset: 0x0006ADE1
		public bool Disconnected { get; private set; }

		// Token: 0x06008583 RID: 34179 RVA: 0x0006CBEA File Offset: 0x0006ADEA
		public static #53i #N3i(string #N6h, #13i #O3i)
		{
			return new EtabsObjectWrapper(EtabsObjectWrapper.#Y3i(#N6h), #O3i);
		}

		// Token: 0x06008584 RID: 34180 RVA: 0x001CB53C File Offset: 0x001C973C
		public int #Q3i(bool #l7i)
		{
			EtabsObjectWrapper.#61b #61b = new EtabsObjectWrapper.#61b();
			#61b.#a = #l7i;
			return this.#K3i<int>(new Func<cOAPI, int>(#61b.#O5i));
		}

		// Token: 0x06008585 RID: 34181 RVA: 0x0006CBF8 File Offset: 0x0006ADF8
		public double #S3i()
		{
			return this.#K3i<double>(new Func<cOAPI, double>(EtabsObjectWrapper.<>c.<>9.#u7i));
		}

		// Token: 0x06008586 RID: 34182 RVA: 0x0006CC1F File Offset: 0x0006AE1F
		public int #qd()
		{
			return this.#K3i<int>(new Func<cOAPI, int>(EtabsObjectWrapper.<>c.<>9.#v7i));
		}

		// Token: 0x06008587 RID: 34183 RVA: 0x0006CC46 File Offset: 0x0006AE46
		public int #T3i()
		{
			return this.#K3i<int>(new Func<cOAPI, int>(EtabsObjectWrapper.<>c.<>9.#w7i));
		}

		// Token: 0x06008588 RID: 34184 RVA: 0x0006CC6D File Offset: 0x0006AE6D
		public bool #U3i()
		{
			return this.#K3i<bool>(new Func<cOAPI, bool>(EtabsObjectWrapper.<>c.<>9.#x7i));
		}

		// Token: 0x06008589 RID: 34185 RVA: 0x0006CC94 File Offset: 0x0006AE94
		public int #V3i()
		{
			return this.#K3i<int>(new Func<cOAPI, int>(EtabsObjectWrapper.<>c.<>9.#y7i));
		}

		// Token: 0x0600858A RID: 34186 RVA: 0x0006CCBB File Offset: 0x0006AEBB
		public int #W3i()
		{
			return this.#K3i<int>(new Func<cOAPI, int>(EtabsObjectWrapper.<>c.<>9.#z7i));
		}

		// Token: 0x0600858B RID: 34187 RVA: 0x0006CCE2 File Offset: 0x0006AEE2
		public int #X3i()
		{
			return this.#K3i<int>(new Func<cOAPI, int>(EtabsObjectWrapper.<>c.<>9.#A7i));
		}

		// Token: 0x0600858C RID: 34188 RVA: 0x001CB568 File Offset: 0x001C9768
		public void #i2i(bool #j2i)
		{
			if (!this.Disconnected)
			{
				Logger.#DSi(string.Format(#Phc.#3hc(107228892), Environment.NewLine, #j2i).#Q1i(#Phc.#3hc(107464305), 1, true));
				this.Disconnected = true;
				this.#d.#i2i(false);
				if (#j2i)
				{
					this.#b.#i2i(true);
				}
			}
		}

		// Token: 0x0600858D RID: 34189 RVA: 0x001CB5D0 File Offset: 0x001C97D0
		private static cOAPI #Y3i(string #N6h)
		{
			if (!string.IsNullOrEmpty(#N6h) && !File.Exists(#N6h))
			{
				throw new #C6h(string.Format(#Ab.SpImporterExceptionFailedToConnectEtabs_ExeNotFound, #N6h), #z6h.#b);
			}
			cHelper #03i;
			try
			{
				Logger.#DSi(#Phc.#3hc(107228827));
				#03i = new Helper();
			}
			catch (Exception #Uic)
			{
				throw new #C6h(#Ab.SpImporterExceptionFailedToConnectEtabs_HelperObj, #z6h.#b, #Uic);
			}
			cOAPI cOAPI;
			if (string.IsNullOrEmpty(#N6h))
			{
				cOAPI = EtabsObjectWrapper.#n7i(#03i);
				if (cOAPI == null)
				{
					Logger.#ZSc(#Phc.#3hc(107228798));
					#N6h = EtabsObjectWrapper.#m7i();
					if (File.Exists(#N6h))
					{
						cOAPI = EtabsObjectWrapper.#Z3i(#N6h, #03i);
					}
					else
					{
						Logger.#ZSc(#Phc.#3hc(107228713));
					}
				}
			}
			else
			{
				cOAPI = EtabsObjectWrapper.#Z3i(#N6h, #03i);
			}
			if (cOAPI == null)
			{
				Logger.#qn(#Phc.#3hc(107228676));
				throw new #C6h(#Ab.SpImporterExceptionFailedToConnectEtabs_ObjProg, #z6h.#b);
			}
			try
			{
				double oapiversionNumber = cOAPI.GetOAPIVersionNumber();
				Logger.#pn(string.Format(#Phc.#3hc(107229159), oapiversionNumber));
			}
			catch (Exception #Uic2)
			{
				Logger.#qn(#Phc.#3hc(107229122));
				throw new #C6h(#Ab.SpImporterExceptionFailedToConnectEtabs_ObjProg, #z6h.#b, #Uic2);
			}
			Logger.#DSi(#Phc.#3hc(107229113));
			return cOAPI;
		}

		// Token: 0x0600858E RID: 34190 RVA: 0x0006CD09 File Offset: 0x0006AF09
		private static string #m7i()
		{
			Logger.#DSi(#Phc.#3hc(107229032));
			return EtabsPathFinder.#i7i();
		}

		// Token: 0x0600858F RID: 34191 RVA: 0x001CB708 File Offset: 0x001C9908
		private static cOAPI #n7i(cHelper #03i)
		{
			cOAPI result;
			try
			{
				Logger.#DSi(#Phc.#3hc(107229015));
				result = #03i.CreateObjectProgID(EtabsObjectWrapper.#a);
			}
			catch (Exception #Uic)
			{
				throw new #C6h(#Ab.SpImporterExceptionFailedToConnectEtabs_ObjProg, #z6h.#b, #Uic);
			}
			return result;
		}

		// Token: 0x06008590 RID: 34192 RVA: 0x001CB754 File Offset: 0x001C9954
		private static cOAPI #Z3i(string #N6h, cHelper #03i)
		{
			EtabsObjectWrapper.#ZXb #ZXb = new EtabsObjectWrapper.#ZXb();
			#ZXb.#b = #03i;
			#ZXb.#c = #N6h;
			#ZXb.#a = null;
			cOAPI result;
			try
			{
				Logger.#DSi(#Phc.#3hc(107228958));
				CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
				Task<cOAPI> task = Task.Run<cOAPI>(new Func<cOAPI>(#ZXb.#P5i), cancellationTokenSource.Token);
				try
				{
					if (!task.Wait(TimeSpan.FromSeconds(30.0)))
					{
						cancellationTokenSource.Cancel();
						Logger.#ZSc((#Phc.#3hc(107228353) + Environment.NewLine + #Phc.#3hc(107228308) + #ZXb.#c).#Q1i(#Phc.#3hc(107464305), 1, true));
						throw new #C6h(string.Format(#Ab.SpImporterExceptionFailedToConnectEtabs_FailedToStartExe, #ZXb.#c).#Q1i(#Phc.#3hc(107464305), 1, true), #z6h.#b);
					}
				}
				catch (AggregateException ex)
				{
					using (IEnumerator<Exception> enumerator = ex.InnerExceptions.GetEnumerator())
					{
						if (enumerator.MoveNext())
						{
							Exception ex2 = enumerator.Current;
							if (!(ex2 is #C6h))
							{
								Logger.#qn(ex2.Message, ex2);
							}
							throw ex2;
						}
					}
				}
				result = #ZXb.#a;
			}
			catch (#C6h)
			{
				throw;
			}
			catch (Exception #Uic)
			{
				throw new #C6h(string.Format(#Ab.SpImporterExceptionFailedToConnectEtabs_FailedToStartExe, #ZXb.#c).#Q1i(#Phc.#3hc(107464305), 1, true), #z6h.#b, #Uic);
			}
			return result;
		}

		// Token: 0x06008591 RID: 34193 RVA: 0x001CB8E0 File Offset: 0x001C9AE0
		private #Fu #K3i<#Fu>(Func<cOAPI, #Fu> #Thc)
		{
			if (this.Disconnected)
			{
				Logger.#qn(#Phc.#3hc(107228267));
				throw new #C6h(#Ab.SpImporterExceptionEtabsDisconnected_ObjectDisconnected, #z6h.#p);
			}
			#Fu result;
			try
			{
				result = #Thc(this.#c);
			}
			catch (RemotingException ex)
			{
				Logger.#qn(#Phc.#3hc(107228250), ex);
				this.#i2i(true);
				throw new #C6h(#Ab.SpImporterExceptionEtabsDisconnected_DisconnectingObject, #z6h.#p, ex);
			}
			return result;
		}

		// Token: 0x04003726 RID: 14118
		private static readonly string #a = #Phc.#3hc(107228665);

		// Token: 0x04003727 RID: 14119
		private readonly #13i #b;

		// Token: 0x04003728 RID: 14120
		private readonly cOAPI #c;

		// Token: 0x04003729 RID: 14121
		private readonly #33i #d;

		// Token: 0x0400372A RID: 14122
		[CompilerGenerated]
		private bool #e;

		// Token: 0x02000E96 RID: 3734
		[CompilerGenerated]
		private sealed class #61b
		{
			// Token: 0x0600859D RID: 34205 RVA: 0x0006CD74 File Offset: 0x0006AF74
			internal int #O5i(cOAPI #Vg)
			{
				return #Vg.ApplicationExit(this.#a);
			}

			// Token: 0x04003733 RID: 14131
			public bool #a;
		}

		// Token: 0x02000E97 RID: 3735
		[CompilerGenerated]
		private sealed class #ZXb
		{
			// Token: 0x0600859F RID: 34207 RVA: 0x001CB958 File Offset: 0x001C9B58
			internal cOAPI #P5i()
			{
				return this.#a = this.#b.CreateObject(this.#c);
			}

			// Token: 0x04003734 RID: 14132
			public cOAPI #a;

			// Token: 0x04003735 RID: 14133
			public cHelper #b;

			// Token: 0x04003736 RID: 14134
			public string #c;
		}
	}
}
