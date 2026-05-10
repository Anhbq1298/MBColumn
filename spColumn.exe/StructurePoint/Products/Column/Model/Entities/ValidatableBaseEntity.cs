using System;
using System.Linq;
using System.Runtime.CompilerServices;
using #EZ;
using #xZ;
using FluentValidation.Results;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;

namespace StructurePoint.Products.Column.Model.Entities
{
	// Token: 0x020001EE RID: 494
	[Serializable]
	public abstract class ValidatableBaseEntity : NotifyPropertyChangedObjectWithValidation
	{
		// Token: 0x1700065B RID: 1627
		// (get) Token: 0x06001102 RID: 4354 RVA: 0x000130F4 File Offset: 0x000112F4
		protected #HZ Validator
		{
			get
			{
				return #wZ.#uZ(base.GetType());
			}
		}

		// Token: 0x1700065C RID: 1628
		// (get) Token: 0x06001103 RID: 4355 RVA: 0x0001310D File Offset: 0x0001130D
		// (set) Token: 0x06001104 RID: 4356 RVA: 0x00013119 File Offset: 0x00011319
		protected bool SkipValidation { get; set; }

		// Token: 0x06001105 RID: 4357 RVA: 0x0001312A File Offset: 0x0001132A
		public IDisposable #Y0()
		{
			return new ValidatableBaseEntity.#72b(this);
		}

		// Token: 0x06001106 RID: 4358 RVA: 0x000A7E38 File Offset: 0x000A6038
		protected bool #dm([CallerMemberName] string #em = null)
		{
			ValidatableBaseEntity.#92b #92b = new ValidatableBaseEntity.#92b();
			#92b.#a = #em;
			if (this.SkipValidation)
			{
				return true;
			}
			ValidationResult validationResult = this.Validator.#IH(this);
			ValidationFailure validationFailure = validationResult.Errors.FirstOrDefault(new Func<ValidationFailure, bool>(#92b.#82b));
			if (validationFailure != null)
			{
				this.AddError(#92b.#a, validationFailure.ErrorMessage);
				return false;
			}
			base.RemoveError(#92b.#a);
			return true;
		}

		// Token: 0x06001107 RID: 4359 RVA: 0x000A7EB4 File Offset: 0x000A60B4
		protected bool #Z0<#Fu>(ref #Fu #LH, #Fu #f, [CallerMemberName] string #em = null)
		{
			bool result = this.SetProperty<#Fu>(ref #LH, #f, #em);
			this.#dm(#em);
			return result;
		}

		// Token: 0x06001108 RID: 4360 RVA: 0x000A7EE0 File Offset: 0x000A60E0
		protected bool #00<#10>(ref #10 #LH, #10 #f, [CallerMemberName] string #em = null)
		{
			#10 # = #LH;
			#LH = #f;
			bool flag = this.#dm(#em);
			#LH = #;
			if (flag)
			{
				this.SetProperty<#10>(ref #LH, #f, #em);
			}
			return flag;
		}

		// Token: 0x020001EF RID: 495
		private sealed class #72b : IDisposable
		{
			// Token: 0x0600110A RID: 4362 RVA: 0x0001313A File Offset: 0x0001133A
			public #72b(ValidatableBaseEntity #8Y)
			{
				this.#a = #8Y;
				this.#a.SkipValidation = true;
			}

			// Token: 0x0600110B RID: 4363 RVA: 0x00013155 File Offset: 0x00011355
			public void #1()
			{
				this.#a.SkipValidation = false;
			}

			// Token: 0x040006B7 RID: 1719
			private readonly ValidatableBaseEntity #a;
		}

		// Token: 0x020001F0 RID: 496
		[CompilerGenerated]
		private sealed class #92b
		{
			// Token: 0x0600110D RID: 4365 RVA: 0x0001316B File Offset: 0x0001136B
			internal bool #82b(ValidationFailure #Rf)
			{
				return #Rf.PropertyName == this.#a;
			}

			// Token: 0x040006B8 RID: 1720
			public string #a;
		}
	}
}
