using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using #0I;
using #5Z;
using #EZ;
using #v1c;
using #WI;
using FluentValidation;
using FluentValidation.Internal;
using FluentValidation.Results;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.Infrastructure.Helpers;
using StructurePoint.Products.Column.Model;

namespace #lH
{
	// Token: 0x020000C1 RID: 193
	internal abstract class #TH : NotifyPropertyChangedObjectWithValidation, #VI, #5I
	{
		// Token: 0x170002E9 RID: 745
		// (get) Token: 0x06000607 RID: 1543 RVA: 0x0000A8BF File Offset: 0x00008ABF
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x06000608 RID: 1544 RVA: 0x00009E6A File Offset: 0x0000806A
		public virtual void #cD(IView #Ee)
		{
		}

		// Token: 0x06000609 RID: 1545 RVA: 0x00009E6A File Offset: 0x0000806A
		public virtual void UpdateFromModel(ColumnModel model)
		{
		}

		// Token: 0x0600060A RID: 1546 RVA: 0x00009E6A File Offset: 0x0000806A
		public virtual void UpdateModel(ColumnModel model)
		{
		}

		// Token: 0x0600060B RID: 1547 RVA: 0x00003375 File Offset: 0x00001575
		public virtual bool #jG()
		{
			return true;
		}

		// Token: 0x0600060C RID: 1548 RVA: 0x00009E6A File Offset: 0x0000806A
		public virtual void #IH()
		{
		}

		// Token: 0x0600060D RID: 1549 RVA: 0x0008B44C File Offset: 0x0008964C
		protected bool #JH(#HZ #ns, [CallerMemberName] string #em = null)
		{
			#TH.#92b #92b = new #TH.#92b();
			#TH.#92b #92b2;
			if (!false)
			{
				#92b2 = #92b;
			}
			#92b2.#a = #em;
			ValidationResult validationResult = #ns.#IH(this);
			ValidationFailure validationFailure = validationResult.Errors.FirstOrDefault(new Func<ValidationFailure, bool>(#92b2.#LZb));
			if (validationFailure != null)
			{
				this.SetError(#92b2.#a, validationFailure.ErrorMessage);
				return false;
			}
			if (base.CheckIfPropertyHasErrors(#92b2.#a))
			{
				base.RemoveError(#92b2.#a);
			}
			return true;
		}

		// Token: 0x0600060E RID: 1550 RVA: 0x0008B4C8 File Offset: 0x000896C8
		protected bool #JH(IValidator #ns, [CallerMemberName] string #em = null)
		{
			#TH.#W9b #W9b = new #TH.#W9b();
			#W9b.#a = #em;
			ValidationResult validationResult = #ns.Validate(#U0.#ul(base.GetType(), this, new PropertyChain()));
			ValidationFailure validationFailure = validationResult.Errors.FirstOrDefault(new Func<ValidationFailure, bool>(#W9b.#LZb));
			if (validationFailure != null)
			{
				this.SetError(#W9b.#a, validationFailure.ErrorMessage);
				return false;
			}
			if (base.CheckIfPropertyHasErrors(#W9b.#a))
			{
				base.RemoveError(#W9b.#a);
			}
			return true;
		}

		// Token: 0x0600060F RID: 1551 RVA: 0x0000A8CF File Offset: 0x00008ACF
		protected void #KH<#Fu>(ref #Fu #LH, #Fu #f, IValidator #ns, Action #MH = null, [CallerMemberName] string #em = null)
		{
			base.RaisePropertyChanging(#em);
			#LH = #f;
			base.RaisePropertyChanged(#em);
			if (this.#JH(#ns, #em) && #MH != null)
			{
				#MH();
			}
		}

		// Token: 0x06000610 RID: 1552 RVA: 0x0000A90A File Offset: 0x00008B0A
		protected bool #KH<#Fu>(ref #Fu #LH, #Fu #f, #HZ #ns, Action #MH = null, [CallerMemberName] string #em = null)
		{
			base.RaisePropertyChanging(#em);
			#LH = #f;
			base.RaisePropertyChanged(#em);
			if (this.#JH(#ns, #em))
			{
				if (#MH != null)
				{
					#MH();
				}
				return true;
			}
			return false;
		}

		// Token: 0x06000611 RID: 1553 RVA: 0x0008B55C File Offset: 0x0008975C
		protected bool #NH(IValidator #ns, params string[] #OH)
		{
			bool result = true;
			foreach (string text in #OH)
			{
				if (base.CheckIfPropertyHasErrors(text))
				{
					base.RemoveError(text);
				}
				if (!this.#JH(#ns, text))
				{
					result = false;
				}
			}
			return result;
		}

		// Token: 0x06000612 RID: 1554 RVA: 0x0008B5A8 File Offset: 0x000897A8
		protected bool #NH(#HZ #ns, params string[] #OH)
		{
			bool result = true;
			foreach (string text in #OH)
			{
				if (base.CheckIfPropertyHasErrors(text))
				{
					base.RemoveError(text);
				}
				if (!this.#JH(#ns, text))
				{
					result = false;
				}
			}
			return result;
		}

		// Token: 0x06000613 RID: 1555 RVA: 0x0008B5F4 File Offset: 0x000897F4
		public bool #PH<#QH, #fx>(#HZ #ns, Lazy<#fx> #Ee, #R2c #ts) where #fx : class, IView
		{
			IList<string> #RH = #ts.#Q2c(#Ee.IsValueCreated ? #Ee.Value : default(!!1));
			return this.#PH<#QH>(#ns, #RH);
		}

		// Token: 0x06000614 RID: 1556 RVA: 0x0008B63C File Offset: 0x0008983C
		public bool #PH<#Fu>(#HZ #ns, IList<string> #RH = null)
		{
			IList<string> list = ReflectionHelper.#r0d<#Fu>(true);
			if (#RH != null)
			{
				for (int i = list.Count - 1; i >= 0; i--)
				{
					if (#RH.Contains(list[i]))
					{
						list.RemoveAt(i);
					}
				}
			}
			foreach (string propertyName in list)
			{
				if (base.CheckIfPropertyHasErrors(propertyName))
				{
					base.RemoveError(propertyName);
				}
			}
			return this.#NH(#ns, list.ToArray<string>());
		}

		// Token: 0x06000615 RID: 1557 RVA: 0x0008B6E8 File Offset: 0x000898E8
		protected void #SH(params string[] #OH)
		{
			foreach (string propertyName in #OH)
			{
				base.RaisePropertyChanging(propertyName);
				base.RaisePropertyChanged(propertyName);
			}
		}

		// Token: 0x06000617 RID: 1559 RVA: 0x0000A950 File Offset: 0x00008B50
		void #5I.#Lr()
		{
			base.ClearErrors();
		}

		// Token: 0x06000618 RID: 1560 RVA: 0x0000A960 File Offset: 0x00008B60
		void #5I.#Or(string #em)
		{
			base.RemoveError(#em);
		}

		// Token: 0x020000C2 RID: 194
		[CompilerGenerated]
		private sealed class #92b
		{
			// Token: 0x0600061A RID: 1562 RVA: 0x0000A975 File Offset: 0x00008B75
			internal bool #LZb(ValidationFailure #Rf)
			{
				return #Rf.PropertyName == this.#a;
			}

			// Token: 0x04000158 RID: 344
			public string #a;
		}

		// Token: 0x020000C3 RID: 195
		[CompilerGenerated]
		private sealed class #W9b
		{
			// Token: 0x0600061C RID: 1564 RVA: 0x0000A994 File Offset: 0x00008B94
			internal bool #LZb(ValidationFailure #Rf)
			{
				return #Rf.PropertyName == this.#a;
			}

			// Token: 0x04000159 RID: 345
			public string #a;
		}
	}
}
