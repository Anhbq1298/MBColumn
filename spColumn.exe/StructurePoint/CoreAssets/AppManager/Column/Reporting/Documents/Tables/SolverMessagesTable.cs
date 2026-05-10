using System;
using System.Linq;
using #FCd;
using #owe;
using #Wse;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Model;

namespace StructurePoint.CoreAssets.AppManager.Column.Reporting.Documents.Tables
{
	// Token: 0x020011BD RID: 4541
	internal sealed class SolverMessagesTable : #qwe
	{
		// Token: 0x06009963 RID: 39267 RVA: 0x00025CC1 File Offset: 0x00023EC1
		public SolverMessagesTable(#lte model) : base(model)
		{
		}

		// Token: 0x06009964 RID: 39268 RVA: 0x00209650 File Offset: 0x00207850
		public override void #npb(#6Dd #opb)
		{
			using (#5Dd #5Dd = #opb.#ul(0, new double[]
			{
				1.0
			}))
			{
				foreach (SolverMessage solverMessage in base.Model.SolverMessages)
				{
					string text = solverMessage.Prefix;
					if (text.All(new Func<char, bool>(SolverMessagesTable.<>c.<>9.#qcf)))
					{
						text = text.PadRight((int)Math.Ceiling((double)text.Length * 1.5), ' ');
					}
					#5Dd.#QDd(new string[]
					{
						text + solverMessage.Message
					});
				}
			}
		}
	}
}
