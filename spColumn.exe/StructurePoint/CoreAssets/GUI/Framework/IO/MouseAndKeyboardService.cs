using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Interactivity;
using #54d;
using #v1c;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.GUI.DesktopControls.Grid;
using StructurePoint.CoreAssets.GUI.DesktopControls.Utils;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;

namespace StructurePoint.CoreAssets.GUI.Framework.IO
{
	// Token: 0x02000CC4 RID: 3268
	public sealed class MouseAndKeyboardService : #R2c
	{
		// Token: 0x06006AB8 RID: 27320 RVA: 0x0005414C File Offset: 0x0005234C
		public bool #w2c(Key #6cc)
		{
			return Keyboard.IsKeyDown(#6cc);
		}

		// Token: 0x06006AB9 RID: 27321 RVA: 0x00054154 File Offset: 0x00052354
		public bool #C2c()
		{
			return Keyboard.Modifiers > ModifierKeys.None;
		}

		// Token: 0x06006ABA RID: 27322 RVA: 0x0019D6F0 File Offset: 0x0019B8F0
		public bool #E2c()
		{
			FrameworkElement frameworkElement = Keyboard.FocusedElement as FrameworkElement;
			FrameworkElement frameworkElement2;
			if (!false)
			{
				frameworkElement2 = frameworkElement;
			}
			return frameworkElement2 != null && Validation.GetHasError(frameworkElement2);
		}

		// Token: 0x06006ABB RID: 27323 RVA: 0x0019D71C File Offset: 0x0019B91C
		public bool #D2c()
		{
			FrameworkElement frameworkElement = Keyboard.FocusedElement as FrameworkElement;
			FrameworkElement #W2c;
			if (!false)
			{
				#W2c = frameworkElement;
			}
			return this.#V2c(#W2c, true);
		}

		// Token: 0x06006ABC RID: 27324 RVA: 0x0019D744 File Offset: 0x0019B944
		public void #mNb()
		{
			FrameworkElement frameworkElement = Keyboard.FocusedElement as FrameworkElement;
			FrameworkElement frameworkElement2;
			if (!false)
			{
				frameworkElement2 = frameworkElement;
			}
			while (frameworkElement2 == null)
			{
				if (true)
				{
					return;
				}
			}
			bool flag2;
			bool flag = flag2 = frameworkElement2.MoveFocus(new TraversalRequest(System.Windows.Input.FocusNavigationDirection.Next));
			TextBoxBase textBoxBase2;
			if (!false && !false)
			{
				if (!flag)
				{
					if (!true)
					{
						goto IL_65;
					}
					frameworkElement2.MoveFocus(new TraversalRequest(System.Windows.Input.FocusNavigationDirection.Previous));
				}
				TextBoxBase textBoxBase = frameworkElement2 as TextBoxBase;
				if (-1 != 0)
				{
					textBoxBase2 = textBoxBase;
				}
				if (textBoxBase2 == null)
				{
					goto IL_5E;
				}
				flag2 = textBoxBase2.IsUndoEnabled;
			}
			bool flag3;
			if (!false)
			{
				flag3 = flag2;
			}
			TextBoxBase textBoxBase3 = textBoxBase2;
			bool isUndoEnabled = false;
			if (!false)
			{
				textBoxBase3.IsUndoEnabled = isUndoEnabled;
			}
			TextBoxBase textBoxBase4 = textBoxBase2;
			bool isUndoEnabled2 = flag3;
			if (!false)
			{
				textBoxBase4.IsUndoEnabled = isUndoEnabled2;
			}
			IL_5E:
			frameworkElement2.Focus();
			IL_65:
			TextBox textBox = textBoxBase2 as TextBox;
			TextBox textBox2;
			if (!false)
			{
				textBox2 = textBox;
			}
			if (textBox2 != null)
			{
				textBox2.SelectionLength = 0;
			}
		}

		// Token: 0x06006ABD RID: 27325 RVA: 0x0019D7E8 File Offset: 0x0019B9E8
		public void #P2c(object #Ee)
		{
			DependencyObject dependencyObject = #Ee as DependencyObject;
			DependencyObject dependencyObject2;
			if (8 != 0)
			{
				dependencyObject2 = dependencyObject;
			}
			if (dependencyObject2 == null)
			{
				return;
			}
			if (-1 != 0)
			{
				IEnumerator<TextBox> enumerator = dependencyObject2.ChildrenOfType<TextBox>().GetEnumerator();
				IEnumerator<TextBox> enumerator2;
				if (2 != 0)
				{
					enumerator2 = enumerator;
				}
				try
				{
					for (;;)
					{
						if (!true)
						{
							goto IL_61;
						}
						if (!enumerator2.MoveNext())
						{
							break;
						}
						TextBox textBox = enumerator2.Current;
						TextBox textBox2;
						if (!false)
						{
							textBox2 = textBox;
						}
						IL_35:
						if (!Validation.GetErrors(textBox2).Any(new Func<ValidationError, bool>(MouseAndKeyboardService.<>c.<>9.#Tbd)))
						{
							continue;
						}
						IL_61:
						if (8 == 0)
						{
							goto IL_35;
						}
						BoundValueInfoBehavior boundValueInfoBehavior = Interaction.GetBehaviors(textBox2).OfType<BoundValueInfoBehavior>().FirstOrDefault<BoundValueInfoBehavior>();
						if (boundValueInfoBehavior != null)
						{
							KeyEventArgs e = null;
							if (!false)
							{
								boundValueInfoBehavior.RevertToLastValue(e);
							}
						}
					}
				}
				finally
				{
					if (enumerator2 != null && !false)
					{
						enumerator2.Dispose();
					}
				}
			}
		}

		// Token: 0x06006ABE RID: 27326 RVA: 0x0019D8B8 File Offset: 0x0019BAB8
		public IList<string> #Q2c(object #Ee)
		{
			UIElement uielement = #Ee as UIElement;
			UIElement uielement2;
			if (6 != 0)
			{
				uielement2 = uielement;
			}
			List<string> list2;
			if (uielement2 == null || !uielement2.IsVisible || uielement2.Visibility != Visibility.Visible)
			{
				if (!false)
				{
					return null;
				}
			}
			else
			{
				List<string> list = new List<string>();
				if (6 != 0)
				{
					list2 = list;
				}
			}
			IEnumerator<TextBox> enumerator = uielement2.ChildrenOfType<TextBox>().GetEnumerator();
			IEnumerator<TextBox> enumerator2;
			if (true)
			{
				enumerator2 = enumerator;
			}
			try
			{
				for (;;)
				{
					if (!enumerator2.MoveNext())
					{
						goto IL_105;
					}
					TextBox textBox = enumerator2.Current;
					TextBox textBox2;
					if (3 != 0)
					{
						textBox2 = textBox;
					}
					if (!textBox2.IsVisible || textBox2.Visibility != Visibility.Visible)
					{
						continue;
					}
					ValidationError validationError = Validation.GetErrors(textBox2).FirstOrDefault(new Func<ValidationError, bool>(MouseAndKeyboardService.<>c.<>9.#Ubd));
					ValidationError validationError2;
					if (4 != 0)
					{
						validationError2 = validationError;
					}
					if (validationError2 == null)
					{
						continue;
					}
					BindingExpression bindingExpression = validationError2.BindingInError as BindingExpression;
					BindingExpression bindingExpression2;
					if (!false)
					{
						bindingExpression2 = bindingExpression;
					}
					if (bindingExpression2 == null)
					{
						continue;
					}
					string text;
					if (2 != 0)
					{
						string path = bindingExpression2.ParentBinding.Path.Path;
						text = ((path != null) ? path.Split(new char[]
						{
							'.'
						}).LastOrDefault<string>() : null);
					}
					IL_E6:
					if (string.IsNullOrWhiteSpace(text))
					{
						continue;
					}
					if (!false)
					{
						list2.Add(text);
						continue;
					}
					IL_105:
					if (!false)
					{
						break;
					}
					goto IL_E6;
				}
			}
			finally
			{
				if (enumerator2 != null)
				{
					enumerator2.Dispose();
				}
			}
			return list2;
		}

		// Token: 0x06006ABF RID: 27327 RVA: 0x0019DA10 File Offset: 0x0019BC10
		public void #x2c(object #y2c)
		{
			DependencyObject dependencyObject3;
			for (;;)
			{
				DependencyObject dependencyObject = #y2c as DependencyObject;
				DependencyObject dependencyObject2;
				if (!false)
				{
					dependencyObject2 = dependencyObject;
				}
				if (dependencyObject2 == null)
				{
					break;
				}
				DependencyObject focusScope = FocusManager.GetFocusScope(dependencyObject2);
				if (-1 != 0)
				{
					dependencyObject3 = focusScope;
				}
				if (2 != 0)
				{
					goto Block_1;
				}
			}
			return;
			Block_1:
			if (dependencyObject3 == null)
			{
				return;
			}
			FocusManager.GetFocusedElement(dependencyObject3);
			do
			{
				FrameworkElement frameworkElement = #y2c as FrameworkElement;
				FrameworkElement frameworkElement2;
				if (!false)
				{
					frameworkElement2 = frameworkElement;
				}
				if (frameworkElement2 != null)
				{
					frameworkElement2.Focus();
				}
				do
				{
					FocusManager.GetFocusedElement(dependencyObject3);
				}
				while (5 == 0);
				bool #f = #44d.#f;
			}
			while (false);
		}

		// Token: 0x06006AC0 RID: 27328 RVA: 0x0019DA74 File Offset: 0x0019BC74
		public void #z2c(object #A2c, object #B2c)
		{
			if (true)
			{
				DependencyObject dependencyObject = #A2c as DependencyObject;
				DependencyObject dependencyObject2;
				if (8 != 0)
				{
					dependencyObject2 = dependencyObject;
				}
				if (dependencyObject2 != null)
				{
					DependencyObject dependencyObject3 = #B2c as DependencyObject;
					DependencyObject dependencyObject4;
					if (!false)
					{
						dependencyObject4 = dependencyObject3;
					}
					if (dependencyObject4 == null)
					{
						return;
					}
					DependencyObject dependencyObject5 = FocusManager.GetFocusedElement(dependencyObject2) as DependencyObject;
					DependencyObject dependencyObject6;
					if (!false)
					{
						dependencyObject6 = dependencyObject5;
					}
					if (dependencyObject6 != null && dependencyObject6.ParentOfType<GridControl>() != null)
					{
						List<IInputElement>.Enumerator enumerator = dependencyObject4.ChildrenOfType<Control>().Where(new Func<Control, bool>(MouseAndKeyboardService.<>c.<>9.#Vbd)).OfType<IInputElement>().ToList<IInputElement>().GetEnumerator();
						List<IInputElement>.Enumerator enumerator2;
						if (!false)
						{
							enumerator2 = enumerator;
						}
						try
						{
							while (enumerator2.MoveNext())
							{
								IInputElement inputElement = enumerator2.Current;
								IInputElement inputElement2;
								if (3 != 0)
								{
									inputElement2 = inputElement;
								}
								DependencyObject element = dependencyObject2;
								IInputElement value = inputElement2;
								if (-1 != 0)
								{
									FocusManager.SetFocusedElement(element, value);
								}
								if (inputElement2.Focus())
								{
									break;
								}
							}
						}
						finally
						{
							((IDisposable)enumerator2).Dispose();
						}
						FocusManager.GetFocusedElement(dependencyObject2);
						bool #f = #44d.#f;
					}
					return;
				}
			}
		}

		// Token: 0x06006AC1 RID: 27329 RVA: 0x0019DB80 File Offset: 0x0019BD80
		public void #J2c(object #K2c, bool #H2c = true)
		{
			DependencyObject dependencyObject = #K2c as DependencyObject;
			DependencyObject dependencyObject2;
			if (!false)
			{
				dependencyObject2 = dependencyObject;
			}
			if (dependencyObject2 == null)
			{
				return;
			}
			List<FrameworkElement>.Enumerator enumerator = MouseAndKeyboardService.#S2c(dependencyObject2).GetEnumerator();
			List<FrameworkElement>.Enumerator enumerator2;
			if (6 != 0)
			{
				enumerator2 = enumerator;
			}
			try
			{
				while (enumerator2.MoveNext())
				{
					FrameworkElement frameworkElement = enumerator2.Current;
					FrameworkElement frameworkElement2;
					if (true)
					{
						frameworkElement2 = frameworkElement;
					}
					try
					{
						RadGridView radGridView2;
						if (!false)
						{
							if (!false)
							{
								if (frameworkElement2.Visibility == Visibility.Visible)
								{
									if (#H2c)
									{
										if (frameworkElement2.GetParents().OfType<UIElement>().Any(new Func<UIElement, bool>(MouseAndKeyboardService.<>c.<>9.#Wbd)))
										{
											continue;
										}
									}
									for (;;)
									{
										RadGridView radGridView = frameworkElement2 as RadGridView;
										if (4 != 0)
										{
											radGridView2 = radGridView;
										}
										if (false)
										{
											goto IL_44;
										}
										if (radGridView2 != null)
										{
											break;
										}
										if (!Validation.GetHasError(frameworkElement2) && BoundValueInfo.GetIsBoundValueCommitted(frameworkElement2))
										{
											goto IL_CF;
										}
										if (2 != 0)
										{
											goto Block_13;
										}
									}
									if (radGridView2.RowInEditMode == null)
									{
										continue;
									}
									goto IL_99;
									Block_13:
									BoundValueInfoBehavior boundValueInfoBehavior = Interaction.GetBehaviors(frameworkElement2).OfType<BoundValueInfoBehavior>().FirstOrDefault<BoundValueInfoBehavior>();
									if (boundValueInfoBehavior != null)
									{
										KeyEventArgs e = null;
										if (7 != 0)
										{
											boundValueInfoBehavior.RevertToLastValue(e);
										}
									}
									IL_CF:;
								}
								IL_44:;
							}
							continue;
						}
						IL_99:
						GridViewDataControl gridViewDataControl = radGridView2;
						if (!false)
						{
							gridViewDataControl.CancelEdit();
						}
					}
					catch (Exception)
					{
					}
				}
			}
			finally
			{
				((IDisposable)enumerator2).Dispose();
			}
		}

		// Token: 0x06006AC2 RID: 27330 RVA: 0x0019DCBC File Offset: 0x0019BEBC
		public void #L2c(object #K2c, bool #H2c = true)
		{
			DependencyObject dependencyObject = #K2c as DependencyObject;
			DependencyObject dependencyObject2;
			if (!false)
			{
				dependencyObject2 = dependencyObject;
			}
			if (dependencyObject2 == null)
			{
				return;
			}
			List<FrameworkElement>.Enumerator enumerator = MouseAndKeyboardService.#S2c(dependencyObject2).GetEnumerator();
			List<FrameworkElement>.Enumerator enumerator2;
			if (4 != 0)
			{
				enumerator2 = enumerator;
			}
			try
			{
				while (enumerator2.MoveNext())
				{
					FrameworkElement frameworkElement = enumerator2.Current;
					FrameworkElement frameworkElement2;
					if (4 != 0)
					{
						frameworkElement2 = frameworkElement;
					}
					try
					{
						if (frameworkElement2.Visibility != Visibility.Visible)
						{
							if (!false)
							{
								continue;
							}
						}
						else
						{
							if (#H2c)
							{
								if (frameworkElement2.GetParents().OfType<UIElement>().Any(new Func<UIElement, bool>(MouseAndKeyboardService.<>c.<>9.#Xbd)))
								{
									continue;
								}
							}
							RadGridView radGridView = frameworkElement2 as RadGridView;
							RadGridView radGridView2;
							if (!false)
							{
								radGridView2 = radGridView;
							}
							if (radGridView2 != null)
							{
								if (radGridView2.RowInEditMode == null)
								{
									continue;
								}
								radGridView2.CommitEdit();
								continue;
							}
						}
						if (!BoundValueInfo.GetIsBoundValueCommitted(frameworkElement2))
						{
							this.#V2c(frameworkElement2, false);
						}
					}
					catch (Exception)
					{
					}
				}
			}
			finally
			{
				do
				{
					((IDisposable)enumerator2).Dispose();
				}
				while (3 == 0);
			}
		}

		// Token: 0x06006AC3 RID: 27331 RVA: 0x0019DDC8 File Offset: 0x0019BFC8
		public void #F2c(object #K2c, bool #H2c = true)
		{
			if (4 != 0)
			{
				DependencyObject dependencyObject = #K2c as DependencyObject;
				DependencyObject dependencyObject2;
				if (!false)
				{
					dependencyObject2 = dependencyObject;
				}
				while (dependencyObject2 == null)
				{
					if (7 != 0)
					{
						return;
					}
				}
				List<FrameworkElement> list2;
				if (!false)
				{
					List<FrameworkElement> list = MouseAndKeyboardService.#S2c(dependencyObject2);
					if (!false)
					{
						list2 = list;
					}
				}
				List<FrameworkElement> #qub = list2;
				if (!false)
				{
					this.#F2c(#H2c, #qub);
				}
			}
		}

		// Token: 0x06006AC4 RID: 27332 RVA: 0x0019DE0C File Offset: 0x0019C00C
		public void #M2c()
		{
			List<FrameworkElement> list = MouseAndKeyboardService.#S2c(Application.Current.MainWindow);
			List<FrameworkElement> list2;
			if (4 != 0)
			{
				list2 = list;
			}
			bool #H2c = true;
			List<FrameworkElement> #qub = list2;
			if (4 != 0)
			{
				this.#F2c(#H2c, #qub);
			}
		}

		// Token: 0x06006AC5 RID: 27333 RVA: 0x0019DE40 File Offset: 0x0019C040
		public bool #N2c(DependencyObject #jA, bool #H2c, bool #w3h = false)
		{
			MouseAndKeyboardService.#61b #61b = new MouseAndKeyboardService.#61b();
			MouseAndKeyboardService.#61b #61b2;
			if (!false)
			{
				#61b2 = #61b;
			}
			#61b2.#a = #jA;
			List<FrameworkElement>.Enumerator enumerator = MouseAndKeyboardService.#S2c(#61b2.#a).GetEnumerator();
			List<FrameworkElement>.Enumerator enumerator2;
			if (5 != 0)
			{
				enumerator2 = enumerator;
			}
			try
			{
				while (enumerator2.MoveNext())
				{
					FrameworkElement frameworkElement = enumerator2.Current;
					FrameworkElement frameworkElement2;
					if (-1 != 0)
					{
						frameworkElement2 = frameworkElement;
					}
					try
					{
						if (frameworkElement2.Visibility == Visibility.Visible)
						{
							if (#H2c)
							{
								IEnumerable<DependencyObject> parents = frameworkElement2.GetParents();
								Func<DependencyObject, bool> predicate;
								if ((predicate = #61b2.#b) == null)
								{
									predicate = (#61b2.#b = new Func<DependencyObject, bool>(#61b2.#F3h));
								}
								List<DependencyObject> list = parents.TakeWhile(predicate).ToList<DependencyObject>();
								List<DependencyObject> list2;
								if (!false)
								{
									list2 = list;
								}
								if (!#w3h)
								{
									List<DependencyObject> list3 = list2;
									DependencyObject item = #61b2.#a;
									if (!false)
									{
										list3.Add(item);
									}
								}
								if (list2.OfType<UIElement>().Any(new Func<UIElement, bool>(MouseAndKeyboardService.<>c.<>9.#E3h)))
								{
									continue;
								}
							}
							RadGridView radGridView = frameworkElement2 as RadGridView;
							RadGridView radGridView2;
							if (!false)
							{
								radGridView2 = radGridView;
							}
							if (radGridView2 != null)
							{
								if (radGridView2.RowInEditMode == null)
								{
									continue;
								}
								if (Validation.GetHasError(radGridView2))
								{
									return true;
								}
							}
							if (Validation.GetHasError(frameworkElement2))
							{
								return true;
							}
							if (!BoundValueInfo.GetIsBoundValueCommitted(frameworkElement2))
							{
								this.#V2c(frameworkElement2, false);
								if (Validation.GetHasError(frameworkElement2))
								{
									return true;
								}
							}
						}
					}
					catch (Exception)
					{
					}
				}
			}
			finally
			{
				((IDisposable)enumerator2).Dispose();
			}
			return false;
		}

		// Token: 0x06006AC6 RID: 27334 RVA: 0x0005415E File Offset: 0x0005235E
		public void #I2c()
		{
			Dictionary<int, string> dictionary = this.#a;
			if (!false)
			{
				dictionary.Clear();
			}
		}

		// Token: 0x06006AC7 RID: 27335 RVA: 0x0019DFE4 File Offset: 0x0019C1E4
		public bool #O2c(object #K2c)
		{
			DependencyObject dependencyObject2;
			if (!false && -1 != 0)
			{
				DependencyObject dependencyObject = #K2c as DependencyObject;
				if (!false)
				{
					dependencyObject2 = dependencyObject;
				}
			}
			if (dependencyObject2 != null)
			{
				List<FrameworkElement>.Enumerator enumerator = MouseAndKeyboardService.#S2c(dependencyObject2).GetEnumerator();
				List<FrameworkElement>.Enumerator enumerator2;
				if (!false)
				{
					enumerator2 = enumerator;
				}
				try
				{
					while (enumerator2.MoveNext())
					{
						if (Validation.GetErrors(enumerator2.Current).Any(new Func<ValidationError, bool>(this.#T2c)))
						{
							bool flag = true;
							bool result;
							if (!false)
							{
								result = flag;
							}
							return result;
						}
					}
				}
				finally
				{
					if (4 != 0)
					{
						((IDisposable)enumerator2).Dispose();
					}
				}
				return false;
			}
			int result2;
			int num = result2 = 0;
			if (num == 0)
			{
				return num != 0;
			}
			return result2 != 0;
		}

		// Token: 0x06006AC8 RID: 27336 RVA: 0x0019E07C File Offset: 0x0019C27C
		private static List<FrameworkElement> #S2c(DependencyObject #G2c)
		{
			List<FrameworkElement> list = new List<FrameworkElement>();
			list.AddRange(#G2c.ChildrenOfType<TextBox>().Where(new Func<TextBox, bool>(MouseAndKeyboardService.<>c.<>9.#Zbd)));
			list.AddRange(#G2c.ChildrenOfType<RadNumericUpDown>().Where(new Func<RadNumericUpDown, bool>(MouseAndKeyboardService.<>c.<>9.#0bd)));
			list.AddRange(#G2c.ChildrenOfType<RadWatermarkTextBox>().Where(new Func<RadWatermarkTextBox, bool>(MouseAndKeyboardService.<>c.<>9.#1bd)));
			list.AddRange(#G2c.ChildrenOfType<RadGridView>());
			IEnumerable<FrameworkElement> collection = #G2c.ChildrenOfType<RadComboBox>();
			if (!false)
			{
				list.AddRange(collection);
			}
			return list;
		}

		// Token: 0x06006AC9 RID: 27337 RVA: 0x00054171 File Offset: 0x00052371
		private bool #T2c(ValidationError #U2c)
		{
			if (#U2c.Exception is FormatException)
			{
				return true;
			}
			if (#U2c.RuleInError == null)
			{
				goto IL_27;
			}
			IL_15:
			if (-1 != 0)
			{
				return #U2c.RuleInError.ValidationStep == ValidationStep.ConvertedProposedValue;
			}
			IL_27:
			if (!false && !false)
			{
				return false;
			}
			goto IL_15;
		}

		// Token: 0x06006ACA RID: 27338 RVA: 0x0019E140 File Offset: 0x0019C340
		private void #F2c(bool #H2c, List<FrameworkElement> #qub)
		{
			List<FrameworkElement>.Enumerator enumerator = #qub.GetEnumerator();
			List<FrameworkElement>.Enumerator enumerator2;
			if (!false)
			{
				enumerator2 = enumerator;
			}
			try
			{
				while (enumerator2.MoveNext())
				{
					FrameworkElement frameworkElement = enumerator2.Current;
					FrameworkElement frameworkElement2;
					if (true)
					{
						frameworkElement2 = frameworkElement;
					}
					try
					{
						if (frameworkElement2.Visibility == Visibility.Visible)
						{
							if (#H2c)
							{
								if (frameworkElement2.GetParents().OfType<UIElement>().Any(new Func<UIElement, bool>(MouseAndKeyboardService.<>c.<>9.#2bd)))
								{
									continue;
								}
							}
							RadGridView radGridView = frameworkElement2 as RadGridView;
							RadGridView radGridView2;
							if (!false)
							{
								radGridView2 = radGridView;
							}
							if (radGridView2 != null)
							{
								if (radGridView2.RowInEditMode != null)
								{
									if (5 != 0 && (!radGridView2.CommitEdit() || Validation.GetHasError(radGridView2)))
									{
										GridViewDataControl gridViewDataControl = radGridView2;
										if (!false)
										{
											gridViewDataControl.CancelEdit();
										}
									}
								}
							}
							else
							{
								BoundValueInfoBehavior boundValueInfoBehavior = Interaction.GetBehaviors(frameworkElement2).OfType<BoundValueInfoBehavior>().FirstOrDefault<BoundValueInfoBehavior>();
								BoundValueInfoBehavior boundValueInfoBehavior2;
								if (!false)
								{
									boundValueInfoBehavior2 = boundValueInfoBehavior;
								}
								if (Validation.GetHasError(frameworkElement2))
								{
									while (boundValueInfoBehavior2 != null)
									{
										if (4 != 0)
										{
											BoundValueInfoBehavior boundValueInfoBehavior3 = boundValueInfoBehavior2;
											KeyEventArgs e = null;
											if (!false)
											{
												boundValueInfoBehavior3.RevertToLastValue(e);
											}
											break;
										}
									}
								}
								else if (!BoundValueInfo.GetIsBoundValueCommitted(frameworkElement2))
								{
									this.#V2c(frameworkElement2, false);
									if ((Validation.GetHasError(frameworkElement2) || (frameworkElement2 is RadComboBox && !BoundValueInfo.GetIsBoundValueCommitted(frameworkElement2))) && boundValueInfoBehavior2 != null)
									{
										boundValueInfoBehavior2.RevertToLastValue(null);
									}
								}
							}
						}
					}
					catch (Exception)
					{
					}
				}
			}
			finally
			{
				((IDisposable)enumerator2).Dispose();
			}
		}

		// Token: 0x06006ACB RID: 27339 RVA: 0x0019E2CC File Offset: 0x0019C4CC
		private bool #V2c(FrameworkElement #W2c, bool #X2c)
		{
			RadGridView radGridView;
			if (#W2c == null)
			{
				radGridView = null;
				goto IL_0C;
			}
			IL_06:
			radGridView = #W2c.ParentOfType<RadGridView>();
			IL_0C:
			RadGridView radGridView2;
			if (!false)
			{
				radGridView2 = radGridView;
			}
			if (radGridView2 != null)
			{
				if (radGridView2.RowInEditMode != null)
				{
					radGridView2.CommitEdit();
				}
				if (5 != 0)
				{
					return true;
				}
				goto IL_06;
			}
			else
			{
				TextBox textBox2;
				bool flag2;
				UnitValueTextBox unitValueTextBox;
				for (;;)
				{
					TextBox textBox = #W2c as TextBox;
					if (3 != 0)
					{
						textBox2 = textBox;
					}
					bool flag4;
					if (textBox2 != null)
					{
						bool flag = true;
						if (!false)
						{
							flag2 = flag;
						}
						bool flag3 = false;
						if (!false)
						{
							flag4 = flag3;
						}
						if (#X2c)
						{
							string a;
							if (!this.#a.TryGetValue(#W2c.GetHashCode(), out a))
							{
								goto IL_84;
							}
							bool flag5 = !string.Equals(a, textBox2.Text);
							if (!false)
							{
								flag2 = flag5;
							}
							bool flag6 = true;
							if (false)
							{
								goto IL_84;
							}
							flag4 = flag6;
							goto IL_84;
						}
					}
					else
					{
						if (#W2c != null)
						{
							#W2c.UpdateBindingSource(true);
						}
						if (!false)
						{
							goto Block_14;
						}
						goto IL_84;
					}
					IL_9B:
					if (Interaction.GetBehaviors(textBox2).OfType<BoundValueInfoBehavior>().FirstOrDefault<BoundValueInfoBehavior>() != null && !flag4)
					{
						flag2 = !BoundValueInfo.GetIsBoundValueCommitted(textBox2);
					}
					if (!flag2)
					{
						return flag2;
					}
					unitValueTextBox = (textBox2 as UnitValueTextBox);
					if (2 != 0)
					{
						break;
					}
					continue;
					IL_84:
					this.#a[#W2c.GetHashCode()] = textBox2.Text;
					goto IL_9B;
				}
				if (unitValueTextBox != null)
				{
					unitValueTextBox.UpdateBindingSource(true);
				}
				else
				{
					textBox2.UpdateBindingSource(false);
				}
				return flag2;
				Block_14:
				if (8 != 0)
				{
					return false;
				}
				goto IL_06;
			}
		}

		// Token: 0x04002B95 RID: 11157
		private readonly Dictionary<int, string> #a = new Dictionary<int, string>();

		// Token: 0x02000CC6 RID: 3270
		[CompilerGenerated]
		private sealed class #61b
		{
			// Token: 0x06006ADA RID: 27354 RVA: 0x00054242 File Offset: 0x00052442
			internal bool #F3h(DependencyObject #Rf)
			{
				return #Rf != this.#a;
			}

			// Token: 0x04002BA1 RID: 11169
			public DependencyObject #a;

			// Token: 0x04002BA2 RID: 11170
			public Func<DependencyObject, bool> #b;
		}
	}
}
