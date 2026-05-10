using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Interop;
using #eU;
using Vanara.PInvoke;

namespace #qJ
{
	// Token: 0x020002CA RID: 714
	internal sealed class #WP : #iW
	{
		// Token: 0x060018C0 RID: 6336 RVA: 0x00018EFF File Offset: 0x000170FF
		public object #VP()
		{
			Application application = Application.Current;
			if (application == null)
			{
				return null;
			}
			return application.MainWindow;
		}

		// Token: 0x060018C1 RID: 6337 RVA: 0x000B7374 File Offset: 0x000B5574
		public Window #6()
		{
			#WP.#v0b #v0b = new #WP.#v0b();
			#v0b.#a = User32.GetActiveWindow().DangerousGetHandle();
			Window window = null;
			if (#v0b.#a != IntPtr.Zero)
			{
				window = Application.Current.Windows.OfType<Window>().FirstOrDefault(new Func<Window, bool>(#v0b.#t0b));
			}
			return window ?? (this.#VP() as Window);
		}

		// Token: 0x020002CB RID: 715
		[CompilerGenerated]
		private sealed class #v0b
		{
			// Token: 0x060018C4 RID: 6340 RVA: 0x00018F15 File Offset: 0x00017115
			internal bool #t0b(Window #u0b)
			{
				return new WindowInteropHelper(#u0b).Handle == this.#a;
			}

			// Token: 0x04000986 RID: 2438
			public IntPtr #a;
		}
	}
}
