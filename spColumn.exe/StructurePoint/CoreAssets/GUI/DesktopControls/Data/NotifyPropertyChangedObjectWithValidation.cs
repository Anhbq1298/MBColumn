using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Data;
using #7hc;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Data
{
	// Token: 0x020000C4 RID: 196
	public abstract class NotifyPropertyChangedObjectWithValidation : NotifyPropertyChangedObjectBase, INotifyDataErrorInfo
	{
		// Token: 0x1400001F RID: 31
		// (add) Token: 0x0600061D RID: 1565 RVA: 0x0008B724 File Offset: 0x00089924
		// (remove) Token: 0x0600061E RID: 1566 RVA: 0x0008B768 File Offset: 0x00089968
		public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

		// Token: 0x170002EA RID: 746
		// (get) Token: 0x0600061F RID: 1567 RVA: 0x0000A9B3 File Offset: 0x00008BB3
		protected IDictionary<string, string> EffectivePropertyMap { get; }

		// Token: 0x170002EB RID: 747
		// (get) Token: 0x06000620 RID: 1568 RVA: 0x0000A9BF File Offset: 0x00008BBF
		// (set) Token: 0x06000621 RID: 1569 RVA: 0x0000A9CB File Offset: 0x00008BCB
		public bool SetBindingValidationErrorsAsHandled { get; set; }

		// Token: 0x170002EC RID: 748
		// (get) Token: 0x06000622 RID: 1570 RVA: 0x0000A9DC File Offset: 0x00008BDC
		public virtual bool HasErrors
		{
			get
			{
				return this.errors.Any<KeyValuePair<string, List<string>>>();
			}
		}

		// Token: 0x170002ED RID: 749
		// (get) Token: 0x06000623 RID: 1571 RVA: 0x0000A9F1 File Offset: 0x00008BF1
		public bool IsValid
		{
			get
			{
				return !this.HasErrors;
			}
		}

		// Token: 0x06000624 RID: 1572 RVA: 0x0000AA04 File Offset: 0x00008C04
		protected virtual void OnErrorsChanged(DataErrorsChangedEventArgs e)
		{
			EventHandler<DataErrorsChangedEventArgs> errorsChanged = this.ErrorsChanged;
			if (errorsChanged == null)
			{
				return;
			}
			errorsChanged(this, e);
		}

		// Token: 0x06000625 RID: 1573 RVA: 0x0008B7AC File Offset: 0x000899AC
		public IEnumerable GetErrors(string propertyName)
		{
			if (string.IsNullOrWhiteSpace(propertyName))
			{
				return this.GetAllErrors();
			}
			propertyName = this.GetEffectivePropertyName(propertyName);
			if (this.errors.ContainsKey(propertyName))
			{
				return this.errors[propertyName];
			}
			return null;
		}

		// Token: 0x06000626 RID: 1574 RVA: 0x0000AA24 File Offset: 0x00008C24
		public override void UnsubscribeAllEvents()
		{
			base.UnsubscribeAllEvents();
			this.ErrorsChanged = null;
		}

		// Token: 0x06000627 RID: 1575 RVA: 0x0008B7FC File Offset: 0x000899FC
		public void RefreshErrors()
		{
			List<string> list = this.errors.Keys.ToList<string>();
			var list2 = this.errors.SelectMany((KeyValuePair<string, List<string>> item) => from error in item.Value
			select new
			{
				Property = item.Key,
				Error = error
			}).ToList();
			foreach (string propertyName in list)
			{
				this.RemoveError(this.GetEffectivePropertyName(propertyName));
			}
			foreach (var <>f__AnonymousType in list2)
			{
				string effectivePropertyName = this.GetEffectivePropertyName(<>f__AnonymousType.Property);
				this.AddError(effectivePropertyName, <>f__AnonymousType.Error);
			}
		}

		// Token: 0x06000628 RID: 1576 RVA: 0x0008B904 File Offset: 0x00089B04
		public void HandleBindingValidationError(ValidationErrorEventArgs e)
		{
			if (e == null || e.Error == null)
			{
				return;
			}
			BindingExpression bindingExpression = e.Error.BindingInError as BindingExpression;
			e.Handled = this.SetBindingValidationErrorsAsHandled;
			string text = (bindingExpression != null) ? bindingExpression.ResolvedSourcePropertyName : null;
			if (string.IsNullOrEmpty(text))
			{
				return;
			}
			this.HandleAddingBindingValidationError(this.GetEffectivePropertyName(text), e);
		}

		// Token: 0x06000629 RID: 1577 RVA: 0x0008B96C File Offset: 0x00089B6C
		public virtual void HandleAddingBindingValidationError(string propertyName, ValidationErrorEventArgs e)
		{
			ValidationErrorEventAction action = e.Action;
			if (action == ValidationErrorEventAction.Added)
			{
				this.AddError(propertyName, NotifyPropertyChangedObjectWithValidation.MyPrepareErrorMessage(e.Error));
				return;
			}
			if (action != ValidationErrorEventAction.Removed)
			{
				return;
			}
			this.RemoveError(propertyName);
		}

		// Token: 0x0600062A RID: 1578 RVA: 0x0008B9B0 File Offset: 0x00089BB0
		public virtual string GetErrorsDescription()
		{
			Dictionary<string, List<string>> dictionary = this.errors;
			if (dictionary == null || !dictionary.Any<KeyValuePair<string, List<string>>>())
			{
				return null;
			}
			List<string> list = (from item in dictionary
			select item.Value.FirstOrDefault<string>() into item
			where !string.IsNullOrWhiteSpace(item)
			select item).ToList<string>();
			if (!list.Any<string>())
			{
				return null;
			}
			return string.Join(Environment.NewLine, list);
		}

		// Token: 0x0600062B RID: 1579 RVA: 0x0000AA3F File Offset: 0x00008C3F
		public bool CheckIfPropertyHasErrors(string propertyName)
		{
			return this.errors.ContainsKey(propertyName) && this.errors[propertyName].Any<string>();
		}

		// Token: 0x0600062C RID: 1580 RVA: 0x0008BA54 File Offset: 0x00089C54
		public virtual void SetError(string propertyName, string error)
		{
			if (string.IsNullOrWhiteSpace(error))
			{
				return;
			}
			List<string> list;
			if (this.errors.TryGetValue(propertyName, out list) && list.Count == 1 && list.Contains(error))
			{
				return;
			}
			propertyName = this.GetEffectivePropertyName(propertyName);
			list = new List<string>
			{
				error
			};
			this.errors[propertyName] = list;
			this.NotifyErrorsChanged(propertyName);
		}

		// Token: 0x0600062D RID: 1581 RVA: 0x0008BAC4 File Offset: 0x00089CC4
		public virtual void AddError(string propertyName, string error)
		{
			if (string.IsNullOrWhiteSpace(error))
			{
				return;
			}
			propertyName = this.GetEffectivePropertyName(propertyName);
			List<string> list = this.errors.#F1d(propertyName);
			if (list == null)
			{
				list = new List<string>();
				this.errors.Add(propertyName, list);
			}
			if (!list.Contains(error))
			{
				list.Add(error);
			}
			this.NotifyErrorsChanged(propertyName);
		}

		// Token: 0x0600062E RID: 1582 RVA: 0x0000AA6E File Offset: 0x00008C6E
		public bool RemoveErrorIfAny([CallerMemberName] string propertyName = null)
		{
			if (this.CheckIfPropertyHasErrors(propertyName))
			{
				this.RemoveError(propertyName);
				return true;
			}
			return false;
		}

		// Token: 0x0600062F RID: 1583 RVA: 0x0008BB2C File Offset: 0x00089D2C
		public void RemoveError([CallerMemberName] string propertyName = null)
		{
			if (propertyName == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107451548));
			}
			propertyName = this.GetEffectivePropertyName(propertyName);
			if (this.errors.ContainsKey(propertyName))
			{
				this.errors.Remove(propertyName);
			}
			this.NotifyErrorsChanged(propertyName);
		}

		// Token: 0x06000630 RID: 1584 RVA: 0x0008BB84 File Offset: 0x00089D84
		public void NotifyErrorsChanged(string propertyName)
		{
			this.OnErrorsChanged(new DataErrorsChangedEventArgs(propertyName));
			base.RaisePropertyChanged<bool>(() => this.HasErrors);
			base.RaisePropertyChanged<bool>(() => this.IsValid);
		}

		// Token: 0x06000631 RID: 1585 RVA: 0x0000AA8F File Offset: 0x00008C8F
		public void ClearErrorsIfAny()
		{
			if (this.errors.Any<KeyValuePair<string, List<string>>>())
			{
				this.ClearErrors();
			}
		}

		// Token: 0x06000632 RID: 1586 RVA: 0x0008BC1C File Offset: 0x00089E1C
		public void ClearErrors()
		{
			List<string> list = this.errors.Keys.ToList<string>();
			this.errors.Clear();
			foreach (string propertyName in list)
			{
				this.NotifyErrorsChanged(propertyName);
			}
			base.RaisePropertyChanged<bool>(() => this.HasErrors);
			base.RaisePropertyChanged<bool>(() => this.IsValid);
		}

		// Token: 0x06000633 RID: 1587 RVA: 0x0008BD0C File Offset: 0x00089F0C
		protected static string MyPrepareErrorMessage(ValidationError validationError)
		{
			if (validationError.Exception is FormatException || (validationError.RuleInError != null && validationError.RuleInError.ValidationStep == ValidationStep.ConvertedProposedValue))
			{
				validationError.ErrorContent = Strings.StringInputIsNotInTheCorrectFormat.#z2d();
			}
			return validationError.ErrorContent.ToString();
		}

		// Token: 0x06000634 RID: 1588 RVA: 0x0008BD64 File Offset: 0x00089F64
		private string GetEffectivePropertyName(string propertyName)
		{
			string result;
			if (this.EffectivePropertyMap.TryGetValue(propertyName, out result))
			{
				return result;
			}
			return propertyName;
		}

		// Token: 0x06000635 RID: 1589 RVA: 0x0000AAB0 File Offset: 0x00008CB0
		private List<string> GetAllErrors()
		{
			return this.errors.SelectMany((KeyValuePair<string, List<string>> propertyErrors) => propertyErrors.Value).ToList<string>();
		}

		// Token: 0x06000636 RID: 1590 RVA: 0x0000AAED File Offset: 0x00008CED
		protected NotifyPropertyChangedObjectWithValidation()
		{
			this.<EffectivePropertyMap>k__BackingField = new Dictionary<string, string>();
			base..ctor();
		}

		// Token: 0x0400015A RID: 346
		private readonly Dictionary<string, List<string>> errors = new Dictionary<string, List<string>>();
	}
}
