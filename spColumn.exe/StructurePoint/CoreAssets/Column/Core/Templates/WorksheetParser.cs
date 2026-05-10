using System;
using System.Collections.Generic;
using System.Linq;
using #7hc;
using #Nhe;
using #vhe;
using StructurePoint.CoreAssets.AppManager.Column.Templates;
using StructurePoint.CoreAssets.AppManager.Column.Templates.Storage;
using StructurePoint.CoreAssets.Column.Core.Templates.Storage;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using Telerik.Windows.Documents.Spreadsheet.Model;

namespace StructurePoint.CoreAssets.Column.Core.Templates
{
	// Token: 0x0200083E RID: 2110
	public sealed class WorksheetParser
	{
		// Token: 0x06004367 RID: 17255 RVA: 0x001382FC File Offset: 0x001364FC
		public WorksheetParseResult ParseWorksheet(Workbook workbook, SectionTemplateDefinition definition, int sheetIndex)
		{
			WorksheetParseResult worksheetParseResult = new WorksheetParseResult();
			this.ParseWorksheet(workbook, definition, worksheetParseResult, sheetIndex);
			return worksheetParseResult;
		}

		// Token: 0x06004368 RID: 17256 RVA: 0x0013831C File Offset: 0x0013651C
		public WorksheetParseResult ParseAll(TemplateDesignerProject project)
		{
			WorksheetParseResult worksheetParseResult = new WorksheetParseResult();
			for (int i = 0; i < project.SectionTemplates.Count; i++)
			{
				SectionTemplateDefinition definition = project.SectionTemplates[i];
				this.ParseWorksheet(project.Workbook, definition, worksheetParseResult, i);
			}
			return worksheetParseResult;
		}

		// Token: 0x06004369 RID: 17257 RVA: 0x00138364 File Offset: 0x00136564
		private void ParseWorksheet(Workbook workbook, SectionTemplateDefinition definition, WorksheetParseResult sink, int index)
		{
			definition.ReinforcementParameters.Clear();
			definition.SectionParameters.Clear();
			definition.OptionsParameters.Clear();
			Worksheet worksheet = workbook.Worksheets.ElementAtOrDefault(index);
			string firstMessage = definition.DisplayName.GetFirstMessage();
			if (worksheet == null)
			{
				sink.Errors.Add(new TemplateError(firstMessage, #Phc.#3hc(107456990).#z2d()));
				return;
			}
			WorksheetParser.TemplatePart? templatePart = null;
			CellRange usedCellRange = worksheet.UsedCellRange;
			TemplateParameterGroupDefinition templateParameterGroupDefinition = null;
			for (int i = usedCellRange.FromIndex.RowIndex; i <= usedCellRange.FromIndex.RowIndex + usedCellRange.RowCount; i++)
			{
				if (!this.IsComment(worksheet, i))
				{
					WorksheetParser.TemplatePart? templatePart2;
					string header;
					if (this.IsMajorPartRow(worksheet, i, out templatePart2))
					{
						templatePart = templatePart2;
						templateParameterGroupDefinition = null;
					}
					else if (this.IsParameterGroupStart(worksheet, i, out header))
					{
						if (templatePart == null)
						{
							sink.Errors.Add(new TemplateError(firstMessage, string.Format(#Phc.#3hc(107456905), i + 1)));
							return;
						}
						templateParameterGroupDefinition = new TemplateParameterGroupDefinition(header);
						this.AddParameterGroup(definition, templatePart.Value, templateParameterGroupDefinition);
					}
					else if (this.IsParameterRow(worksheet, i))
					{
						if (templateParameterGroupDefinition == null)
						{
							sink.Errors.Add(new TemplateError(firstMessage, string.Format(#Phc.#3hc(107456828), i + 1).#z2d()));
							return;
						}
						TemplateParameterDefinition templateParameterDefinition = this.ParseParameter(worksheet, i, sink, firstMessage);
						if (templateParameterDefinition != null)
						{
							templateParameterGroupDefinition.Parameters.Add(templateParameterDefinition);
						}
					}
				}
			}
		}

		// Token: 0x0600436A RID: 17258 RVA: 0x001384F4 File Offset: 0x001366F4
		private bool ParseParameterSelectOptions(TemplateParameterType parameterType, string value, WorksheetParseResult sink, string templateName, int currentRow, out List<TemplateSelectOptionsSet> parsedList)
		{
			parsedList = null;
			if (parameterType <= TemplateParameterType.BarSize)
			{
				parsedList = new List<TemplateSelectOptionsSet>();
				return true;
			}
			if (parameterType - TemplateParameterType.IntegerList > 2)
			{
				throw new ArgumentOutOfRangeException(#Phc.#3hc(107456044), parameterType, null);
			}
			if (string.IsNullOrWhiteSpace(value))
			{
				parsedList = null;
				sink.Errors.Add(new TemplateError(templateName, string.Format(#Phc.#3hc(107456195), currentRow + 1)));
				return false;
			}
			TemplateSelectOptionsSet templateSelectOptionsSet = new TemplateSelectOptionsSet();
			string[] array = value.Split(new char[]
			{
				','
			}, StringSplitOptions.RemoveEmptyEntries);
			for (int i = 0; i < array.Length; i++)
			{
				string[] array2 = array[i].Split(new char[]
				{
					'|'
				}, StringSplitOptions.RemoveEmptyEntries);
				if (array2.Length != 2 && array2.Length != 1)
				{
					sink.Errors.Add(new TemplateError(templateName, string.Format(#Phc.#3hc(107456105), currentRow + 1).#z2d()));
					return false;
				}
				string displayValue = array2[0];
				string text = (array2.Length == 2) ? array2[1] : array2[0];
				#0he #0he;
				if (!#Hhe.#Fhe(parameterType, text, out #0he))
				{
					sink.Errors.Add(new TemplateError(templateName, string.Format(#Phc.#3hc(107456166), currentRow + 1, text)));
					return false;
				}
				templateSelectOptionsSet.Options.Add(new TemplateSelectOption(text, displayValue));
			}
			parsedList = new List<TemplateSelectOptionsSet>
			{
				templateSelectOptionsSet
			};
			return true;
		}

		// Token: 0x0600436B RID: 17259 RVA: 0x00138664 File Offset: 0x00136864
		private TemplateParameterDefinition ParseParameter(Worksheet sheet, int currentRow, WorksheetParseResult result, string templateName)
		{
			string cellValue = this.GetCellValue(sheet, currentRow, 2);
			string cellValue2 = this.GetCellValue(sheet, currentRow, 3);
			string cellValue3 = this.GetCellValue(sheet, currentRow, 4);
			string cellValue4 = this.GetCellValue(sheet, currentRow, 5);
			string cellValue5 = this.GetCellValue(sheet, currentRow, 6);
			string cellValue6 = this.GetCellValue(sheet, currentRow, 7);
			string cellValue7 = this.GetCellValue(sheet, currentRow, 8);
			string cellValue8 = this.GetCellValue(sheet, currentRow, 9);
			string cellValue9 = this.GetCellValue(sheet, currentRow, 10);
			string cellValue10 = this.GetCellValue(sheet, currentRow, 11);
			TemplateParameterType templateParameterType;
			if (!Enum.TryParse<TemplateParameterType>(cellValue2, true, out templateParameterType))
			{
				result.Errors.Add(new TemplateError(templateName, string.Format(#Phc.#3hc(107456055), currentRow + 1).#z2d()));
				return null;
			}
			if (string.IsNullOrWhiteSpace(cellValue3))
			{
				result.Errors.Add(new TemplateError(templateName, string.Format(#Phc.#3hc(107456486), currentRow + 1).#z2d()));
				return null;
			}
			#0he #0he;
			if (!#Hhe.#Fhe(templateParameterType, cellValue4, out #0he))
			{
				result.Errors.Add(new TemplateError(templateName, string.Format(#Phc.#3hc(107456461), currentRow + 1)));
				return null;
			}
			if (!#Hhe.#Fhe(templateParameterType, cellValue5, out #0he))
			{
				result.Errors.Add(new TemplateError(templateName, string.Format(#Phc.#3hc(107456436), currentRow + 1)));
				return null;
			}
			List<TemplateParameterValueDefinition> values = new List<TemplateParameterValueDefinition>
			{
				new TemplateParameterValueDefinition(UnitSystemSpecs.Metric, cellValue5),
				new TemplateParameterValueDefinition(UnitSystemSpecs.USCustomary, cellValue4)
			};
			List<TemplateSelectOptionsSet> selectOptions;
			if (!this.ParseParameterSelectOptions(templateParameterType, cellValue6, result, templateName, currentRow, out selectOptions))
			{
				return null;
			}
			List<ValidatorDefinition> validators;
			if (!this.ParseValidators(sheet, currentRow, templateName, result, out validators))
			{
				return null;
			}
			return new TemplateParameterDefinition
			{
				Key = cellValue3.Trim(),
				Text = new LocalizableProperty(new LocalizableString[]
				{
					new LocalizableString(cellValue.Trim())
				}),
				Type = templateParameterType,
				Values = values,
				SelectOptions = selectOptions,
				LowerRangeValidator = new RangeValidator(cellValue9),
				UpperRangeValidator = new RangeValidator(cellValue10),
				Validators = validators,
				IsReadOnlyExpression = ((cellValue7 != null) ? cellValue7.Trim() : null),
				OverridingParameterKey = ((cellValue8 != null) ? cellValue8.Trim() : null)
			};
		}

		// Token: 0x0600436C RID: 17260 RVA: 0x001388A4 File Offset: 0x00136AA4
		private bool ParseValidators(Worksheet sheet, int currentRow, string templateName, WorksheetParseResult sink, out List<ValidatorDefinition> validators)
		{
			validators = new List<ValidatorDefinition>();
			bool flag = false;
			for (int i = 12; i <= sheet.UsedCellRange.ToIndex.ColumnIndex; i += 2)
			{
				string cellValue = this.GetCellValue(sheet, currentRow, i);
				string cellValue2 = this.GetCellValue(sheet, currentRow, i + 1);
				if (string.IsNullOrWhiteSpace(cellValue))
				{
					break;
				}
				if (string.IsNullOrWhiteSpace(cellValue2))
				{
					flag = true;
					sink.Errors.Add(new TemplateError(templateName, string.Format(#Phc.#3hc(107456383), currentRow + 1, i + 1)));
				}
				else
				{
					validators.Add(new ValidatorDefinition(cellValue, new LocalizableString[]
					{
						new LocalizableString(cellValue2)
					}));
				}
			}
			return !flag;
		}

		// Token: 0x0600436D RID: 17261 RVA: 0x0003877E File Offset: 0x0003697E
		private void AddParameterGroup(SectionTemplateDefinition templateDefinition, WorksheetParser.TemplatePart templatePart, TemplateParameterGroupDefinition groupDefinition)
		{
			if (templatePart == WorksheetParser.TemplatePart.Reinforcement)
			{
				templateDefinition.ReinforcementParameters.Add(groupDefinition);
				return;
			}
			if (templatePart == WorksheetParser.TemplatePart.Section)
			{
				templateDefinition.SectionParameters.Add(groupDefinition);
				return;
			}
			if (templatePart == WorksheetParser.TemplatePart.Options)
			{
				templateDefinition.OptionsParameters.Add(groupDefinition);
			}
		}

		// Token: 0x0600436E RID: 17262 RVA: 0x000387B1 File Offset: 0x000369B1
		private bool IsParameterRow(Worksheet sheet, int currentRow)
		{
			return !string.IsNullOrWhiteSpace(this.GetCellValue(sheet, currentRow, 2));
		}

		// Token: 0x0600436F RID: 17263 RVA: 0x00138958 File Offset: 0x00136B58
		private bool IsParameterGroupStart(Worksheet sheet, int currentRow, out string name)
		{
			string cellValue = this.GetCellValue(sheet, currentRow, 1);
			name = cellValue;
			return !string.IsNullOrWhiteSpace(cellValue);
		}

		// Token: 0x06004370 RID: 17264 RVA: 0x0013897C File Offset: 0x00136B7C
		private bool IsMajorPartRow(Worksheet sheet, int currentRow, out WorksheetParser.TemplatePart? part)
		{
			string cellValue = this.GetCellValue(sheet, currentRow, 0);
			part = null;
			if (!string.IsNullOrWhiteSpace(cellValue))
			{
				if (string.Equals(cellValue, #Phc.#3hc(107352063), StringComparison.OrdinalIgnoreCase))
				{
					part = new WorksheetParser.TemplatePart?(WorksheetParser.TemplatePart.Section);
					return true;
				}
				if (string.Equals(cellValue, #Phc.#3hc(107456310), StringComparison.OrdinalIgnoreCase))
				{
					part = new WorksheetParser.TemplatePart?(WorksheetParser.TemplatePart.Reinforcement);
					return true;
				}
				if (string.Equals(cellValue, #Phc.#3hc(107360163), StringComparison.OrdinalIgnoreCase))
				{
					part = new WorksheetParser.TemplatePart?(WorksheetParser.TemplatePart.Options);
					return true;
				}
			}
			return false;
		}

		// Token: 0x06004371 RID: 17265 RVA: 0x000387C4 File Offset: 0x000369C4
		private string GetCellValue(Worksheet sheet, int row, int column)
		{
			CellSelection cellSelection = sheet.Cells[row, column];
			if (cellSelection == null)
			{
				return null;
			}
			RangePropertyValue<ICellValue> value = cellSelection.GetValue();
			if (value == null)
			{
				return null;
			}
			ICellValue value2 = value.Value;
			if (value2 == null)
			{
				return null;
			}
			string rawValue = value2.RawValue;
			if (rawValue == null)
			{
				return null;
			}
			return rawValue.Trim();
		}

		// Token: 0x06004372 RID: 17266 RVA: 0x000387FF File Offset: 0x000369FF
		private bool IsComment(Worksheet sheet, int currentRow)
		{
			return string.Equals(this.GetCellValue(sheet, currentRow, 0), #Phc.#3hc(107456257));
		}

		// Token: 0x0200083F RID: 2111
		private enum TemplatePart
		{
			// Token: 0x04001E5B RID: 7771
			Section,
			// Token: 0x04001E5C RID: 7772
			Reinforcement,
			// Token: 0x04001E5D RID: 7773
			Options
		}
	}
}
