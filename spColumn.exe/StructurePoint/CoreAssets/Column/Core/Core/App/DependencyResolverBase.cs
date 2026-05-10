using System;
using System.Threading;
using #7hc;
using SimpleInjector;

namespace StructurePoint.CoreAssets.Column.Core.Core.App
{
	// Token: 0x020001B9 RID: 441
	public abstract class DependencyResolverBase : IDisposable
	{
		// Token: 0x06000F08 RID: 3848 RVA: 0x000118FE File Offset: 0x0000FAFE
		protected DependencyResolverBase()
		{
			this.Container.Options.DefaultLifestyle = Lifestyle.Singleton;
			this.Container.Options.EnableAutoVerification = false;
		}

		// Token: 0x170005C4 RID: 1476
		// (get) Token: 0x06000F09 RID: 3849 RVA: 0x00011937 File Offset: 0x0000FB37
		protected Container Container { get; } = new Container();

		// Token: 0x06000F0A RID: 3850 RVA: 0x0001193F File Offset: 0x0000FB3F
		public void Verify()
		{
			this.Container.Verify();
		}

		// Token: 0x06000F0B RID: 3851 RVA: 0x0001194C File Offset: 0x0000FB4C
		public TDependency Resolve<TDependency>() where TDependency : class
		{
			return this.Container.GetInstance<TDependency>();
		}

		// Token: 0x06000F0C RID: 3852 RVA: 0x00011959 File Offset: 0x0000FB59
		protected void Register<TService, TImplementation>() where TService : class where TImplementation : class, !!0
		{
			this.AssertNotAView<TService>();
			this.Container.Register<TService, TImplementation>(Lifestyle.Singleton);
		}

		// Token: 0x06000F0D RID: 3853 RVA: 0x000A3B2C File Offset: 0x000A1D2C
		protected void RegisterViewResolve<TService>(Func<TService> provider) where TService : class, IView
		{
			this.Container.Register<Lazy<TService>>(() => new Lazy<!0>(provider), Lifestyle.Singleton);
		}

		// Token: 0x06000F0E RID: 3854 RVA: 0x00011971 File Offset: 0x0000FB71
		protected void RegisterViewResolve<TService, TImplementation>() where TService : class, IView where TImplementation : class, !!0
		{
			this.Container.Register<TService, TImplementation>(Lifestyle.Singleton);
			this.Container.Register<Lazy<TService>>(() => new Lazy<!!0>(new Func<!!0>(this.Resolve<TService>), LazyThreadSafetyMode.ExecutionAndPublication), Lifestyle.Singleton);
		}

		// Token: 0x06000F0F RID: 3855 RVA: 0x0001199F File Offset: 0x0000FB9F
		protected void RegisterView<TService, TImplementation>() where TService : class, IView where TImplementation : class, !!0, new()
		{
			this.Container.Register<Lazy<TService>>(() => new Lazy<!0>(() => (!0)((object)Activator.CreateInstance<TImplementation>()), LazyThreadSafetyMode.ExecutionAndPublication), Lifestyle.Singleton);
		}

		// Token: 0x06000F10 RID: 3856 RVA: 0x000119D0 File Offset: 0x0000FBD0
		protected void RegisterInstance<TService>(TService instance) where TService : class
		{
			this.AssertNotAView<TService>();
			this.Container.RegisterInstance(typeof(!!0), instance);
		}

		// Token: 0x06000F11 RID: 3857 RVA: 0x000119F3 File Offset: 0x0000FBF3
		public void Dispose()
		{
			Container container = this.Container;
			if (container == null)
			{
				return;
			}
			container.Dispose();
		}

		// Token: 0x06000F12 RID: 3858 RVA: 0x00011A05 File Offset: 0x0000FC05
		private void AssertNotAView<TService>()
		{
			if (typeof(IView).IsAssignableFrom(typeof(!!0)))
			{
				throw new InvalidOperationException(#Phc.#3hc(107455136));
			}
		}
	}
}
