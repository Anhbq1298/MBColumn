using System;
using System.Collections.Generic;
using System.Windows.Media;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Localizer;

namespace #LQc
{
	// Token: 0x02000C29 RID: 3113
	internal sealed class #3Qc : #xRc
	{
		// Token: 0x0600651F RID: 25887 RVA: 0x0018D5E8 File Offset: 0x0018B7E8
		public void #QQc(IModelEditorControl #RQc, IDrawingResultsFactory #SQc)
		{
			string #R0d = #Phc.#3hc(107444019);
			Component #x6c = Component.GUIFramework;
			string #Qic = #Phc.#3hc(107443307);
			if (!false)
			{
				#X0d.#V0d(#RQc, #R0d, #x6c, #Qic);
			}
			string #R0d2 = #Phc.#3hc(107443393);
			Component #x6c2 = Component.GUIFramework;
			string #Qic2 = #Phc.#3hc(107443286);
			if (4 != 0)
			{
				#X0d.#V0d(#SQc, #R0d2, #x6c2, #Qic2);
			}
			this.#g = #RQc;
			this.#f = #SQc;
			this.#h = true;
			IModelEditorControl modelEditorControl = this.#g;
			EventHandler value = new EventHandler(this.#QEc);
			if (!false)
			{
				modelEditorControl.CameraChanged += value;
			}
		}

		// Token: 0x06006520 RID: 25888 RVA: 0x00051A88 File Offset: 0x0004FC88
		public void #od()
		{
			if (!this.#h)
			{
				return;
			}
			bool #1Qc = true;
			if (!false)
			{
				this.#0Qc(#1Qc);
			}
		}

		// Token: 0x06006521 RID: 25889 RVA: 0x0018D674 File Offset: 0x0018B874
		public void #qd()
		{
			if (this.#i == null)
			{
				goto IL_3B;
			}
			ILinesDrawingResultBase linesDrawingResultBase = this.#i;
			Color transparent = Colors.Transparent;
			if (5 != 0)
			{
				linesDrawingResultBase.LineColor = transparent;
			}
			IL_18:
			if (false)
			{
				goto IL_3B;
			}
			ITextDrawingResult textDrawingResult = this.#j;
			Color transparent2 = Colors.Transparent;
			if (!false)
			{
				textDrawingResult.TextColor = transparent2;
			}
			IL_2B:
			ITextDrawingResult textDrawingResult2 = this.#k;
			Color transparent3 = Colors.Transparent;
			if (!false)
			{
				textDrawingResult2.TextColor = transparent3;
			}
			IL_3B:
			if (false)
			{
				goto IL_2B;
			}
			if (true)
			{
				return;
			}
			goto IL_18;
		}

		// Token: 0x06006522 RID: 25890 RVA: 0x00051AA1 File Offset: 0x0004FCA1
		private void #QEc(object #Ge, EventArgs #He)
		{
			if (this.#h)
			{
				bool #1Qc = false;
				if (7 != 0)
				{
					this.#0Qc(#1Qc);
				}
			}
		}

		// Token: 0x06006523 RID: 25891 RVA: 0x0018D6D8 File Offset: 0x0018B8D8
		private void #0Qc(bool #1Qc)
		{
			if (this.#i != null)
			{
				goto IL_9D;
			}
			IL_0B:
			this.#i = this.#f.CreateMultilineDrawingResult();
			ILinesDrawingResultBase linesDrawingResultBase = this.#i;
			Color lineColor = #3Qc.#a;
			if (!false)
			{
				linesDrawingResultBase.LineColor = lineColor;
			}
			this.#j = this.#f.CreateTextDrawingResult();
			ITextDrawingResult textDrawingResult = this.#j;
			Color textColor = #3Qc.#a;
			if (!false)
			{
				textDrawingResult.TextColor = textColor;
			}
			this.#k = this.#f.CreateTextDrawingResult();
			ITextDrawingResult textDrawingResult2 = this.#k;
			Color textColor2 = #3Qc.#a;
			if (-1 != 0)
			{
				textDrawingResult2.TextColor = textColor2;
			}
			IL_77:
			ITextDrawingResult textDrawingResult3 = this.#j;
			string stringXLowercase = Strings.StringXLowercase;
			if (!false)
			{
				textDrawingResult3.Text = stringXLowercase;
			}
			IL_8A:
			ITextDrawingResult textDrawingResult4 = this.#k;
			string stringYLowercase = Strings.StringYLowercase;
			if (8 != 0)
			{
				textDrawingResult4.Text = stringYLowercase;
			}
			IL_9D:
			if (#1Qc)
			{
				if (false)
				{
					goto IL_77;
				}
				ILinesDrawingResultBase linesDrawingResultBase2 = this.#i;
				Color lineColor2 = #3Qc.#a;
				if (6 != 0)
				{
					linesDrawingResultBase2.LineColor = lineColor2;
				}
				if (!true)
				{
					goto IL_0B;
				}
				this.#j.TextColor = #3Qc.#a;
				if (6 == 0)
				{
					goto IL_8A;
				}
				this.#k.TextColor = #3Qc.#a;
				if (6 != 0)
				{
					this.#g.AddToView(this.#i);
					this.#g.AddToView(this.#j);
					this.#g.AddToView(this.#k);
				}
			}
			this.#2Qc();
		}

		// Token: 0x06006524 RID: 25892 RVA: 0x0018D83C File Offset: 0x0018BA3C
		private void #2Qc()
		{
			double? num = VisualToScreenHelper.ScaleRadiusToRemainFixedSizeOnscreen(this.#g, this.#i, new Point3D(0.0, 0.0, 0.002), 25.0);
			double? num2;
			if (!false)
			{
				num2 = num;
			}
			if (num2 == null)
			{
				return;
			}
			double value = num2.Value;
			double num3;
			if (true)
			{
				num3 = value;
			}
			ILinesDrawingResultBase linesDrawingResultBase = this.#i;
			IEnumerable<Point3D> positions = new Point3D[]
			{
				new Point3D(-0.4 * num3, 0.0, 0.002),
				new Point3D(0.6 * num3, 0.0, 0.002),
				new Point3D(0.0, -0.4 * num3, 0.002),
				new Point3D(0.0, 0.6 * num3, 0.002)
			};
			if (!false)
			{
				linesDrawingResultBase.Positions = positions;
			}
			ITextDrawingResult textDrawingResult = this.#j;
			Point3D position = new Point3D(0.7 * num3, 0.3 * num3, 0.002);
			if (8 != 0)
			{
				textDrawingResult.Position = position;
			}
			ITextDrawingResult textDrawingResult2 = this.#k;
			Point3D position2 = new Point3D(-0.1 * num3, 1.2 * num3, 0.002);
			if (!false)
			{
				textDrawingResult2.Position = position2;
			}
			if (!double.IsNaN(num3))
			{
				ILinesDrawingResultBase linesDrawingResultBase2 = this.#i;
				double lineThickness = 1.0;
				if (!false)
				{
					linesDrawingResultBase2.LineThickness = lineThickness;
				}
				this.#j.FontSize = VisualToScreenHelper.ScaleRadiusToRemainFixedSizeOnscreen(this.#g, this.#j, new Point3D(0.0, 0.0, 0.002), 14.0).Value;
				this.#k.FontSize = VisualToScreenHelper.ScaleRadiusToRemainFixedSizeOnscreen(this.#g, this.#k, new Point3D(0.0, 0.0, 0.002), 14.0).Value;
			}
		}

		// Token: 0x0400297C RID: 10620
		private static readonly Color #a = Colors.Black;

		// Token: 0x0400297D RID: 10621
		private const double #b = 1.0;

		// Token: 0x0400297E RID: 10622
		private const double #c = 14.0;

		// Token: 0x0400297F RID: 10623
		private const double #d = 25.0;

		// Token: 0x04002980 RID: 10624
		private const double #e = 0.002;

		// Token: 0x04002981 RID: 10625
		private IDrawingResultsFactory #f;

		// Token: 0x04002982 RID: 10626
		private IModelEditorControl #g;

		// Token: 0x04002983 RID: 10627
		private bool #h;

		// Token: 0x04002984 RID: 10628
		private IMultilineDrawingResult #i;

		// Token: 0x04002985 RID: 10629
		private ITextDrawingResult #j;

		// Token: 0x04002986 RID: 10630
		private ITextDrawingResult #k;
	}
}
