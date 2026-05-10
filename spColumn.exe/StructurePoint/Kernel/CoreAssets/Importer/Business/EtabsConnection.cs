using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using #23i;
using #7hc;
using #H1i;
using #w1i;
using #x1i;
using StructurePoint.Kernel.CoreAssets.Importer.Business.Wrappers;
using StructurePoint.Kernel.CoreAssets.Importer.Core;

namespace StructurePoint.Kernel.CoreAssets.Importer.Business
{
	// Token: 0x02000E6F RID: 3695
	internal sealed class EtabsConnection : IDisposable, #13i
	{
		// Token: 0x1700279B RID: 10139
		// (get) Token: 0x0600841B RID: 33819 RVA: 0x0006BA76 File Offset: 0x00069C76
		private #53i EtabsObject
		{
			get
			{
				if (this.Disconnected)
				{
					Logger.#qn(#Phc.#3hc(107267604));
					throw new #C6h(#Ab.SpImporterExceptionEtabsDisconnected_ObjectDisconnected, #z6h.#p);
				}
				return this.#d;
			}
		}

		// Token: 0x1700279C RID: 10140
		// (get) Token: 0x0600841C RID: 33820 RVA: 0x0006BAA2 File Offset: 0x00069CA2
		internal #33i EtabsModel
		{
			get
			{
				if (this.Disconnected)
				{
					Logger.#qn(#Phc.#3hc(107267604));
					throw new #C6h(#Ab.SpImporterExceptionEtabsDisconnected_ObjectDisconnected, #z6h.#p);
				}
				return this.#c;
			}
		}

		// Token: 0x0600841D RID: 33821 RVA: 0x0006BACE File Offset: 0x00069CCE
		internal void #F6h(int #G6h, string #5, #z6h #Zfc)
		{
			if (#G6h != 0)
			{
				throw new #C6h(#5, #Zfc);
			}
		}

		// Token: 0x0600841E RID: 33822 RVA: 0x001C6F5C File Offset: 0x001C515C
		internal int #H6h()
		{
			Logger.#DSi(#Phc.#3hc(107268035));
			int count = #G1i.#C1i(#Phc.#3hc(107267998)).Count;
			Logger.#DSi(string.Format(#Phc.#3hc(107267989), count));
			return count;
		}

		// Token: 0x0600841F RID: 33823 RVA: 0x001C6FA8 File Offset: 0x001C51A8
		private List<Process> #c2i()
		{
			Logger.#DSi(#Phc.#3hc(107267904));
			List<Process> list = #G1i.#A1i(#Phc.#3hc(107267998));
			Logger.#DSi((string.Format(#Phc.#3hc(107267891), list.Count, Environment.NewLine) + string.Join(Environment.NewLine, list.Select(new Func<Process, string>(EtabsConnection.<>c.<>9.#j4i)))).#Q1i(#Phc.#3hc(107464305), 1, true));
			return list;
		}

		// Token: 0x06008420 RID: 33824 RVA: 0x001C7040 File Offset: 0x001C5240
		private int #d2i()
		{
			Logger.#DSi(#Phc.#3hc(107267322));
			List<Process> list = this.#c2i();
			if (list.Count > 1)
			{
				Logger.#ZSc(#Phc.#3hc(107267237));
				throw new #C6h(#Ab.SpImporterExceptionFailedToConnectEtabs_Unknown_Connect, #z6h.#b);
			}
			if (list.Count == 0)
			{
				Logger.#ZSc(#Phc.#3hc(107267176));
				throw new #C6h(#Ab.SpImporterExceptionFailedToConnectEtabs_Unknown_Connect, #z6h.#b);
			}
			return list[0].Id;
		}

		// Token: 0x06008421 RID: 33825 RVA: 0x001C70B4 File Offset: 0x001C52B4
		internal bool #I6h()
		{
			int num = this.#H6h();
			if (!this.Connected)
			{
				return num > 0;
			}
			return num > 1;
		}

		// Token: 0x06008422 RID: 33826 RVA: 0x001C70DC File Offset: 0x001C52DC
		private void #J6h(#53i #K6h)
		{
			Logger.#DSi(#Phc.#3hc(107267159));
			try
			{
				this.#c = null;
				this.#c = #K6h.SapModel;
				this.#d = #K6h;
				this.#a = this.#d2i();
				this.Disconnected = false;
			}
			catch (#C6h)
			{
				throw;
			}
			catch (Exception #Uic)
			{
				throw new #C6h(#Ab.SpImporterExceptionFailedToConnectEtabs_Unknown_Connect, #z6h.#b, #Uic);
			}
			if (!this.Connected)
			{
				throw new #C6h(#Ab.SpImporterExceptionFailedToConnectEtabs, #z6h.#b);
			}
			Logger.#DSi(string.Concat(new string[]
			{
				#Phc.#3hc(107267122),
				Environment.NewLine,
				#Phc.#3hc(107267089),
				(this.#d == null) ? #Phc.#3hc(107267583) : #Phc.#3hc(107267556),
				#Phc.#3hc(107267578),
				Environment.NewLine,
				#Phc.#3hc(107267569),
				(this.#c == null) ? #Phc.#3hc(107267583) : #Phc.#3hc(107267556),
				#Phc.#3hc(107267578),
				Environment.NewLine,
				string.Format(#Phc.#3hc(107267524), this.#a, Environment.NewLine),
				string.Format(#Phc.#3hc(107267539), this.Disconnected)
			}).#Q1i(#Phc.#3hc(107464305), 1, true));
		}

		// Token: 0x1700279D RID: 10141
		// (get) Token: 0x06008423 RID: 33827 RVA: 0x001C7268 File Offset: 0x001C5468
		internal bool Connected
		{
			get
			{
				Logger.#DSi(string.Concat(new string[]
				{
					#Phc.#3hc(107267514),
					Environment.NewLine,
					#Phc.#3hc(107267089),
					(this.#d == null) ? #Phc.#3hc(107267583) : #Phc.#3hc(107267556),
					#Phc.#3hc(107267578),
					Environment.NewLine,
					#Phc.#3hc(107267569),
					(this.#c == null) ? #Phc.#3hc(107267583) : #Phc.#3hc(107267556),
					#Phc.#3hc(107267578),
					Environment.NewLine,
					string.Format(#Phc.#3hc(107267524), this.#a, Environment.NewLine),
					string.Format(#Phc.#3hc(107267539), this.Disconnected)
				}).#Q1i(#Phc.#3hc(107464305), 1, true));
				if (this.Disconnected || this.#d == null || this.#c == null)
				{
					return false;
				}
				if (this.#a > 0)
				{
					try
					{
						Process.GetProcessById(this.#a);
					}
					catch (Exception ex)
					{
						Logger.#qn(#Phc.#3hc(107267433), ex);
						try
						{
							this.#i2i(false);
						}
						catch (Exception #N1i)
						{
							Logger.#qn(#Phc.#3hc(107267364), #N1i);
						}
						throw new #C6h(#Ab.SpImporterExceptionFailedToConnectEtabs_ConnectionLost, #z6h.#b, ex);
					}
				}
				string str = #Phc.#3hc(107381628);
				double num = 0.0;
				bool result;
				try
				{
					this.#F6h(this.EtabsModel.GetVersion(ref str, ref num), #Ab.SpImporterExceptionFailedToConnectEtabs_ConnectionLost, #z6h.#b);
					Logger.#DSi(#Phc.#3hc(107267335));
					Logger.#pn(#Phc.#3hc(107266790) + str);
					result = true;
				}
				catch (#C6h)
				{
					throw;
				}
				catch (Exception #Uic)
				{
					throw new #C6h(#Ab.SpImporterExceptionFailedToConnectEtabs_Unknown_Connected, #z6h.#b, #Uic);
				}
				return result;
			}
		}

		// Token: 0x06008424 RID: 33828 RVA: 0x001C7484 File Offset: 0x001C5684
		internal void #M6h(string #N6h, bool #O6h)
		{
			Logger.#DSi(string.Concat(new string[]
			{
				#Phc.#3hc(107266777),
				Environment.NewLine,
				#Phc.#3hc(107266700),
				#N6h,
				#Phc.#3hc(107350811),
				string.Format(#Phc.#3hc(107266715), Environment.NewLine, #O6h)
			}));
			#53i #53i = EtabsObjectWrapper.#N3i(#N6h, this);
			try
			{
				Logger.#DSi(#Phc.#3hc(107266658));
				this.#F6h(#53i.ApplicationStart(), #Ab.SpImporterExceptionFailedToConnectEtabs_AppStart, #z6h.#b);
			}
			catch (#C6h)
			{
				throw;
			}
			catch (Exception #Uic)
			{
				throw new #C6h(#Ab.SpImporterExceptionFailedToConnectEtabs_Unknown_StartEtabs, #z6h.#b, #Uic);
			}
			Logger.#DSi(#Phc.#3hc(107266625));
			this.#J6h(#53i);
			try
			{
				if (#O6h)
				{
					Logger.#DSi(#Phc.#3hc(107266612));
					#53i.Hide();
				}
			}
			catch (#C6h)
			{
				throw;
			}
			catch (Exception #Uic2)
			{
				throw new #C6h(#Ab.SpImporterExceptionFailedToConnectEtabs_CantHide, #z6h.#b, #Uic2);
			}
			Logger.#DSi(#Phc.#3hc(107266579));
		}

		// Token: 0x06008425 RID: 33829 RVA: 0x0006BADB File Offset: 0x00069CDB
		public void #1()
		{
			this.#1(true);
		}

		// Token: 0x06008426 RID: 33830 RVA: 0x0006BAE4 File Offset: 0x00069CE4
		protected void #1(bool #POb)
		{
			if (this.#b)
			{
				return;
			}
			if (#POb)
			{
				Logger.#DSi(#Phc.#3hc(107267014));
				this.#i2i(false);
				Logger.#DSi(#Phc.#3hc(107266981));
			}
			this.#b = true;
		}

		// Token: 0x06008427 RID: 33831 RVA: 0x001C75B4 File Offset: 0x001C57B4
		private void #f2i()
		{
			if (this.EtabsObject != null && this.EtabsModel != null)
			{
				Logger.#DSi(#Phc.#3hc(107266968));
				if (this.#a <= 0)
				{
					Logger.#DSi((#Phc.#3hc(107266943) + Environment.NewLine + string.Format(#Phc.#3hc(107267524), this.#a, Environment.NewLine) + string.Format(#Phc.#3hc(107267539), this.Disconnected)).#Q1i(#Phc.#3hc(107464305), 1, true));
					return;
				}
				int num = this.#H6h();
				if (num == 0)
				{
					Logger.#ZSc((#Phc.#3hc(107266906) + Environment.NewLine + string.Format(#Phc.#3hc(107267524), this.#a, Environment.NewLine) + string.Format(#Phc.#3hc(107267539), this.Disconnected)).#Q1i(#Phc.#3hc(107464305), 1, true));
					return;
				}
				try
				{
					this.EtabsObject.ApplicationExit(false);
					if (num > 0)
					{
						int num2 = 0;
						while (num2 < 30 && num == this.#H6h())
						{
							Thread.Sleep(1000);
							Logger.#DSi(string.Format(#Phc.#3hc(107266873), num2 + 1));
							if (++num2 >= 30)
							{
								Logger.#DSi(string.Format(#Phc.#3hc(107266280), 30));
							}
						}
					}
					Logger.#DSi(#Phc.#3hc(107266235));
				}
				catch (#C6h #C6h)
				{
					if (#C6h.ErrorCode == #z6h.#p)
					{
						try
						{
							Logger.#DSi(#Phc.#3hc(107266198));
							using (Process processById = Process.GetProcessById(this.#a))
							{
								processById.Kill();
								processById.WaitForExit(30000);
								if (processById.HasExited)
								{
									Logger.#DSi(#Phc.#3hc(107266121));
								}
								else
								{
									Logger.#ZSc(#Phc.#3hc(107266104));
								}
							}
						}
						catch (InvalidCastException #N1i)
						{
							Logger.#qn(#Phc.#3hc(107266906), #N1i);
						}
						catch (Win32Exception #N1i2)
						{
							Logger.#qn(#Phc.#3hc(107266559), #N1i2);
						}
						catch (NotSupportedException #N1i3)
						{
							Logger.#qn(#Phc.#3hc(107266522), #N1i3);
						}
						catch (Exception #N1i4)
						{
							Logger.#qn(#Phc.#3hc(107266437), #N1i4);
						}
						throw;
					}
					throw;
				}
				finally
				{
					this.#c = null;
					this.#d = null;
					this.#a = -1;
				}
			}
		}

		// Token: 0x1700279E RID: 10142
		// (get) Token: 0x06008428 RID: 33832 RVA: 0x0006BB1E File Offset: 0x00069D1E
		// (set) Token: 0x06008429 RID: 33833 RVA: 0x0006BB26 File Offset: 0x00069D26
		public bool Disconnected { get; private set; }

		// Token: 0x0600842A RID: 33834 RVA: 0x001C78CC File Offset: 0x001C5ACC
		public void #i2i(bool #j2i)
		{
			if (!this.Disconnected && !this.#e)
			{
				this.#e = true;
				Logger.#DSi(string.Format(#Phc.#3hc(107266428), Environment.NewLine, #j2i).#Q1i(#Phc.#3hc(107464305), 1, true));
				try
				{
					try
					{
						this.#f2i();
					}
					finally
					{
						#53i #53i = this.EtabsObject;
						if (#53i != null)
						{
							#53i.#i2i(false);
						}
					}
					Logger.#DSi(#Phc.#3hc(107266319));
				}
				catch (#C6h)
				{
					throw;
				}
				catch (Exception #N1i)
				{
					Logger.#qn(#Phc.#3hc(107233018), #N1i);
					throw new #C6h(#Ab.SpImporterExceptionFailedToDisconnectEtabs, #z6h.#p);
				}
				finally
				{
					this.Disconnected = true;
					this.#e = false;
				}
			}
		}

		// Token: 0x0400366F RID: 13935
		private int #a;

		// Token: 0x04003670 RID: 13936
		private bool #b;

		// Token: 0x04003671 RID: 13937
		private #33i #c;

		// Token: 0x04003672 RID: 13938
		private #53i #d;

		// Token: 0x04003673 RID: 13939
		private bool #e;

		// Token: 0x04003674 RID: 13940
		[CompilerGenerated]
		private bool #f;
	}
}
