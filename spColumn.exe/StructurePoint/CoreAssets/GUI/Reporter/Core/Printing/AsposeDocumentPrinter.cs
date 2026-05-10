using System;
using System.Drawing.Printing;
using System.Linq;
using #7hc;
using #Fmc;
using #hId;
using #UYd;
using Aspose.Words;

namespace StructurePoint.CoreAssets.GUI.Reporter.Core.Printing
{
	// Token: 0x02000D99 RID: 3481
	public static class AsposeDocumentPrinter
	{
		// Token: 0x06007DFC RID: 32252 RVA: 0x001BBCC4 File Offset: 0x001B9EC4
		public static void #SHd(Document #bFd, #jJd #GFd)
		{
			if (#bFd == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107281812));
			}
			if (#GFd == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107281908));
			}
			if (!#GFd.IsRealPrinterDevice)
			{
				throw new InvalidOperationException();
			}
			#uzc #uzc = new #uzc(#Phc.#3hc(107281767));
			PrinterSettings printerSettings = new PrinterSettings();
			\u0007\u0003.~\u0012\u0007(printerSettings, #GFd.Printer);
			if (#GFd.PrinterSettings != null)
			{
				printerSettings = #GFd.PrinterSettings;
			}
			foreach (#zId #zId in #GFd.Pages.OrderBy(new Func<IPageSelection, int>(AsposeDocumentPrinter.<>c.<>9.#dVd)).ThenBy(new Func<IPageSelection, int>(AsposeDocumentPrinter.<>c.<>9.#eVd)).#Xoc(new Func<int, int, bool>(AsposeDocumentPrinter.<>c.<>9.#fVd)).OfType<#zId>().ToList<#zId>())
			{
				#zId.#iId(printerSettings);
				\u000E\u0005.~\u009C\u000E(#bFd, printerSettings);
			}
			#uzc.#szc(#Phc.#3hc(107281738));
		}
	}
}
