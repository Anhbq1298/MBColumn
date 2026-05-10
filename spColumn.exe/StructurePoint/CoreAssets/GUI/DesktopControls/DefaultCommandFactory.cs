using System;

namespace StructurePoint.CoreAssets.GUI.DesktopControls
{
	// Token: 0x0200088D RID: 2189
	public sealed class DefaultCommandFactory : ICommandFactory
	{
		// Token: 0x06004524 RID: 17700 RVA: 0x0003999C File Offset: 0x00037B9C
		public IDelegateCommand Create(Action<object> execute)
		{
			return new DelegateCommandAdapter(execute);
		}

		// Token: 0x06004525 RID: 17701 RVA: 0x000399AC File Offset: 0x00037BAC
		public IDelegateCommand Create(Action execute)
		{
			return new DelegateCommandAdapter(delegate(object parameter)
			{
				execute();
			});
		}

		// Token: 0x06004526 RID: 17702 RVA: 0x0013CBF4 File Offset: 0x0013ADF4
		public IDelegateCommand Create(Action execute, Func<bool> canExecute)
		{
			DefaultCommandFactory.<>c__DisplayClass2_0 CS$<>8__locals1 = new DefaultCommandFactory.<>c__DisplayClass2_0();
			DefaultCommandFactory.<>c__DisplayClass2_0 CS$<>8__locals2;
			if (!false)
			{
				CS$<>8__locals2 = CS$<>8__locals1;
			}
			CS$<>8__locals2.execute = execute;
			CS$<>8__locals2.canExecute = canExecute;
			return new DelegateCommandAdapter(delegate(object parameter)
			{
				CS$<>8__locals2.execute();
			}, (object parameter) => CS$<>8__locals2.canExecute());
		}

		// Token: 0x06004527 RID: 17703 RVA: 0x000399CE File Offset: 0x00037BCE
		public IDelegateCommand Create(Action<object> execute, Predicate<object> canExecute)
		{
			return new DelegateCommandAdapter(execute, canExecute);
		}

		// Token: 0x06004528 RID: 17704 RVA: 0x000399E3 File Offset: 0x00037BE3
		public IDelegateCommandProxy CreateProxy(IDelegateCommand delegateCommand)
		{
			return new DelegateCommandProxy(delegateCommand);
		}

		// Token: 0x06004529 RID: 17705 RVA: 0x000399F3 File Offset: 0x00037BF3
		public IDelegateCommandProxy CreateProxy()
		{
			return new DelegateCommandProxy();
		}
	}
}
