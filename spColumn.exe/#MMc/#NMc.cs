using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Windows.Input;
using #7hc;
using #8Cc;
using #IDc;
using #YKc;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;
using StructurePoint.CoreAssets.GUI.Framework;
using StructurePoint.CoreAssets.GUI.Framework.Model.Entities;
using StructurePoint.CoreAssets.GUI.Framework.Model.Infrastructure;
using StructurePoint.CoreAssets.GUI.Framework.Tools.Selection;
using StructurePoint.CoreAssets.GUI.SharedResources.Icons.Tools;
using StructurePoint.CoreAssets.Localizer;

namespace #MMc
{
	// Token: 0x02000BD3 RID: 3027
	internal sealed class #NMc : SelectionToolBase, INotifyPropertyChanged, IEditionToolData, #8Hc, #LMc
	{
		// Token: 0x060062CD RID: 25293 RVA: 0x000508F8 File Offset: 0x0004EAF8
		public #NMc(#6Ic #JDc) : base(#JDc)
		{
			base.Header = Strings.StringModifyShape;
			base.IconImage = base.ToolContext.ResourcesHelper.ImageFromResourceBitmap(ToolsIcons.ModifyShape);
			base.HelpId = HelpIdentifiers.ToolModifyShape;
		}

		// Token: 0x060062CE RID: 25294 RVA: 0x00181618 File Offset: 0x0017F818
		[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Unexpected errors catch.")]
		protected override void #2kb(KeyEventArgs #HA)
		{
			while (#HA != null && #HA.Key == Key.Delete && base.ModelEditorViewModel.AreShapesVisible)
			{
				List<ShapeDataModel> list = base.SelectedObjects.OfType<ShapeDataModel>().ToList<ShapeDataModel>();
				List<ShapeDataModel> list2;
				if (!false)
				{
					list2 = list;
				}
				if (!list2.Any<ShapeDataModel>())
				{
					return;
				}
				if (6 != 0)
				{
					try
					{
						bool isWorking = true;
						if (!false)
						{
							base.IsWorking = isWorking;
						}
						#bDc #bDc = base.UndoManager;
						if (!false)
						{
							#bDc.#uCc();
						}
						#6Kc #6Kc = base.ToolOperationsHelper;
						IEnumerable<ShapeDataModel> #6Y = list2;
						if (8 != 0)
						{
							#6Kc.#nEc(#6Y);
						}
						if (3 != 0)
						{
							base.#MIc();
						}
						if (!false)
						{
							this.#zIc();
						}
						return;
					}
					catch (ModelValidationException #PIc)
					{
						base.#OIc(#PIc);
						return;
					}
					catch (Exception #ob)
					{
						for (;;)
						{
							base.ErrorsHandlingService.#bzc(#ob, #Phc.#3hc(107414332), base.ToolInfo);
							if (!false)
							{
								base.UndoManager.#yCc(false);
								if (2 != 0)
								{
									break;
								}
							}
						}
						return;
					}
					finally
					{
						base.UndoManager.#vCc();
						this.#iLc();
						if (!false)
						{
							this.#1kb();
							base.IsWorking = false;
						}
					}
					break;
				}
			}
			base.#2kb(#HA);
		}
	}
}
