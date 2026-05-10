using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using #7hc;
using StructurePoint.CoreAssets.GUI.Framework.Services;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Logger;

namespace #LQc
{
	// Token: 0x02000C34 RID: 3124
	internal sealed class #dRc : IGenericLoaderWindow
	{
		// Token: 0x06006558 RID: 25944 RVA: 0x00051C83 File Offset: 0x0004FE83
		public #dRc(Assembly #eRc, string #fRc, ILogger #3x) : this(#eRc, #fRc, #3x, false)
		{
		}

		// Token: 0x06006559 RID: 25945 RVA: 0x0018DF4C File Offset: 0x0018C14C
		public #dRc(Assembly #eRc, string #fRc, ILogger #3x, bool #gRc)
		{
			if (#eRc == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107443525));
			}
			this.#a = #eRc;
			if (#fRc == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107443500));
			}
			this.#b = #fRc;
			this.#c = #3x;
			this.#d = #gRc;
		}

		// Token: 0x17001C4B RID: 7243
		// (get) Token: 0x0600655A RID: 25946 RVA: 0x0002FF35 File Offset: 0x0002E135
		// (set) Token: 0x0600655B RID: 25947 RVA: 0x0002FF35 File Offset: 0x0002E135
		public string LoadingContent
		{
			get
			{
				throw new NotSupportedException();
			}
			set
			{
				throw new NotSupportedException();
			}
		}

		// Token: 0x0600655C RID: 25948 RVA: 0x0018DFA4 File Offset: 0x0018C1A4
		public void #od()
		{
			if (this.#e)
			{
				return;
			}
			try
			{
				while (this.#d)
				{
					if (!false)
					{
						if (4 != 0)
						{
							this.#9Qc();
						}
						if (!false)
						{
							return;
						}
					}
				}
				Application.Current.Dispatcher.BeginInvoke(new Action(this.#9Qc), new object[0]);
			}
			catch (Exception #ob)
			{
				if (2 != 0)
				{
					this.#nb(#ob);
				}
			}
		}

		// Token: 0x0600655D RID: 25949 RVA: 0x0018E018 File Offset: 0x0018C218
		public void #Fgc()
		{
			#dRc.#iZb #iZb = new #dRc.#iZb();
			#dRc.#iZb #iZb2;
			if (5 != 0)
			{
				#iZb2 = #iZb;
			}
			do
			{
				#iZb2.#b = this;
				if (false)
				{
					goto IL_3E;
				}
				#iZb2.#a = this.#f;
			}
			while (false);
			if (this.#e)
			{
				return;
			}
			this.#e = true;
			if (7 != 0 && #iZb2.#a == null)
			{
				return;
			}
			IL_3E:
			try
			{
				do
				{
					Dispatcher dispatcher = Application.Current.Dispatcher;
					Action callback = new Action(#iZb2.#Bad);
					if (3 != 0)
					{
						dispatcher.Invoke(callback);
					}
				}
				while (false);
			}
			catch (Exception #ob)
			{
				this.#nb(#ob);
			}
		}

		// Token: 0x0600655E RID: 25950 RVA: 0x0018E0AC File Offset: 0x0018C2AC
		private void #9Qc()
		{
			try
			{
				if (!false)
				{
					this.#aRc();
				}
				Window window = this.#f;
				if (4 != 0)
				{
					window.Show();
				}
			}
			catch (Exception #ob)
			{
				this.#nb(#ob);
			}
		}

		// Token: 0x0600655F RID: 25951 RVA: 0x00051C8F File Offset: 0x0004FE8F
		private void #nb(Exception #ob)
		{
			ILogger logger = this.#c;
			if (logger == null)
			{
				return;
			}
			LoggingLevel level = LoggingLevel.Error;
			if (!false)
			{
				logger.Log(level, #ob);
			}
		}

		// Token: 0x06006560 RID: 25952 RVA: 0x0018E0F4 File Offset: 0x0018C2F4
		private void #aRc()
		{
			if (this.#f != null)
			{
				return;
			}
			Uri uri = new Uri(#Phc.#3hc(107443515).#D2d(new object[]
			{
				this.#a.GetName().Name,
				this.#b
			}), UriKind.RelativeOrAbsolute);
			Uri #gp;
			if (2 != 0)
			{
				#gp = uri;
			}
			Window window = new Window();
			window.Topmost = true;
			window.BorderThickness = new Thickness(0.0);
			window.WindowStyle = WindowStyle.None;
			window.ShowInTaskbar = false;
			window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
			window.ResizeMode = ResizeMode.NoResize;
			window.IsHitTestVisible = false;
			window.SizeToContent = SizeToContent.WidthAndHeight;
			object content = this.#bRc(#gp);
			if (!false)
			{
				window.Content = content;
			}
			this.#f = window;
		}

		// Token: 0x06006561 RID: 25953 RVA: 0x0018E1AC File Offset: 0x0018C3AC
		private Image #bRc(Uri #gp)
		{
			BitmapImage bitmapImage = new BitmapImage();
			BitmapImage bitmapImage2;
			if (!false)
			{
				bitmapImage2 = bitmapImage;
			}
			BitmapImage bitmapImage3 = bitmapImage2;
			if (4 != 0)
			{
				bitmapImage3.BeginInit();
			}
			BitmapImage bitmapImage4 = bitmapImage2;
			if (4 != 0)
			{
				bitmapImage4.UriSource = #gp;
			}
			BitmapImage bitmapImage5 = bitmapImage2;
			BitmapCacheOption cacheOption = BitmapCacheOption.None;
			if (!false)
			{
				bitmapImage5.CacheOption = cacheOption;
			}
			BitmapImage bitmapImage6 = bitmapImage2;
			if (4 != 0)
			{
				bitmapImage6.EndInit();
			}
			Image image = new Image();
			image.Source = bitmapImage2;
			image.Width = bitmapImage2.Width;
			image.Height = bitmapImage2.Height;
			image.SnapsToDevicePixels = true;
			image.UseLayoutRounding = true;
			image.MinWidth = bitmapImage2.Width;
			image.MaxWidth = bitmapImage2.Width;
			image.MinHeight = bitmapImage2.Height;
			image.MaxHeight = bitmapImage2.Height;
			MouseButtonEventHandler value = new MouseButtonEventHandler(this.#cRc);
			if (4 != 0)
			{
				image.MouseLeftButtonDown += value;
			}
			return image;
		}

		// Token: 0x06006562 RID: 25954 RVA: 0x0018E294 File Offset: 0x0018C494
		private void #cRc(object #Ge, MouseButtonEventArgs #He)
		{
			Image image = #Ge as Image;
			Image image2;
			if (8 != 0)
			{
				image2 = image;
			}
			if (image2 != null)
			{
				UIElement uielement = image2;
				MouseButtonEventHandler value = new MouseButtonEventHandler(this.#cRc);
				if (!false)
				{
					uielement.MouseLeftButtonDown -= value;
				}
			}
			if (!false)
			{
				this.#Fgc();
			}
		}

		// Token: 0x04002995 RID: 10645
		private readonly Assembly #a;

		// Token: 0x04002996 RID: 10646
		private readonly string #b;

		// Token: 0x04002997 RID: 10647
		private readonly ILogger #c;

		// Token: 0x04002998 RID: 10648
		private readonly bool #d;

		// Token: 0x04002999 RID: 10649
		private bool #e;

		// Token: 0x0400299A RID: 10650
		private Window #f;

		// Token: 0x02000C35 RID: 3125
		[CompilerGenerated]
		private sealed class #iZb
		{
			// Token: 0x06006564 RID: 25956 RVA: 0x0018E2D8 File Offset: 0x0018C4D8
			internal void #Bad()
			{
				try
				{
					UIElement uielement = this.#a;
					Visibility visibility = Visibility.Collapsed;
					if (!false)
					{
						uielement.Visibility = visibility;
					}
					Window window = this.#a;
					if (!false)
					{
						window.Close();
					}
				}
				catch (Exception #ob)
				{
					this.#b.#nb(#ob);
				}
			}

			// Token: 0x0400299B RID: 10651
			public Window #a;

			// Token: 0x0400299C RID: 10652
			public #dRc #b;
		}
	}
}
