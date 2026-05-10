using System;
using System.Collections.Concurrent;
using System.Linq;
using #7hc;
using #8Cc;

namespace StructurePoint.CoreAssets.GUI.Framework.UndoRedo
{
	// Token: 0x02000B5B RID: 2907
	public static class UndoAction
	{
		// Token: 0x06005EF0 RID: 24304 RVA: 0x00177CEC File Offset: 0x00175EEC
		public static void #uRb(#bDc #DJ, Action #nd)
		{
			if (#DJ == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107404911));
			}
			if (#nd == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107351365));
			}
			try
			{
				if (5 != 0)
				{
					#DJ.#uCc();
				}
				if (!false)
				{
					#nd();
				}
				ConcurrentStack<bool> concurrentStack = #DJ.TransactionInfo.TransactionChanges;
				bool item = true;
				if (!false)
				{
					concurrentStack.Push(item);
				}
			}
			catch (UndoAction.UndoActionException)
			{
				throw;
			}
			catch (Exception ex)
			{
				do
				{
					#DJ.#yCc(false);
				}
				while (6 == 0);
				throw new UndoAction.UndoActionException(ex.Message, ex);
			}
			finally
			{
				do
				{
					#DJ.#vCc();
				}
				while (3 == 0);
			}
		}

		// Token: 0x06005EF1 RID: 24305 RVA: 0x00177DA0 File Offset: 0x00175FA0
		public static bool #uRb(#bDc #DJ, Func<bool> #nd)
		{
			if (#DJ == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107404911));
			}
			if (#nd == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107351365));
			}
			int result;
			for (;;)
			{
				bool flag = false;
				bool flag2;
				if (3 != 0)
				{
					flag2 = flag;
				}
				int num = 0;
				for (;;)
				{
					bool flag3;
					if (!false)
					{
						flag3 = (num != 0);
					}
					bool flag7;
					try
					{
						if (7 != 0)
						{
							#DJ.#uCc();
						}
						bool flag4 = #DJ.TransactionDepth == 1L;
						if (!false)
						{
							flag3 = flag4;
						}
						bool flag5 = #nd();
						bool flag6;
						if (!false)
						{
							flag6 = flag5;
						}
						ConcurrentStack<bool> concurrentStack = #DJ.TransactionInfo.TransactionChanges;
						bool item = flag6;
						if (-1 != 0)
						{
							concurrentStack.Push(item);
						}
						flag7 = flag6;
					}
					catch (UndoAction.UndoActionException)
					{
						do
						{
							flag2 = true;
						}
						while (5 == 0);
						throw;
					}
					catch (Exception ex)
					{
						flag2 = true;
						#DJ.#yCc(false);
						throw new UndoAction.UndoActionException(ex.Message, ex);
					}
					finally
					{
						bool flag8;
						if (!#DJ.TransactionInfo.TransactionChanges.Any(new Func<bool, bool>(UndoAction.<>c.<>9.#D8c)))
						{
							flag8 = !flag2;
						}
						else
						{
							if (false)
							{
								goto IL_E0;
							}
							flag8 = false;
						}
						if (!flag8 || !flag3)
						{
							goto IL_E6;
						}
						IL_E0:
						#DJ.#wCc();
						IL_E6:
						#DJ.#vCc();
					}
					if (2 == 0)
					{
						break;
					}
					result = (num = (flag7 ? 1 : 0));
					if (3 != 0)
					{
						return result != 0;
					}
				}
			}
			return result != 0;
		}

		// Token: 0x02000B5C RID: 2908
		[Serializable]
		public sealed class UndoActionException : Exception
		{
			// Token: 0x06005EF2 RID: 24306 RVA: 0x0004ED35 File Offset: 0x0004CF35
			public UndoActionException()
			{
			}

			// Token: 0x06005EF3 RID: 24307 RVA: 0x0003326E File Offset: 0x0003146E
			public UndoActionException(string message) : base(message)
			{
			}

			// Token: 0x06005EF4 RID: 24308 RVA: 0x0004ED3D File Offset: 0x0004CF3D
			public UndoActionException(string message, Exception innerException) : base(message, innerException)
			{
			}
		}
	}
}
