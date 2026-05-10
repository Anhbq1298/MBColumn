using System;
using System.Runtime.CompilerServices;
using #7hc;
using #g7e;
using #y6e;

namespace StructurePoint.CoreAssets.AppManager.Column.Engineer.Communication
{
	// Token: 0x020012C0 RID: 4800
	public sealed class Message
	{
		// Token: 0x0600A0C0 RID: 41152 RVA: 0x0007E28E File Offset: 0x0007C48E
		private Message(Message.EnumType type, #M6e code, params object[] parameters)
		{
			this.Type = type;
			this.Code = code;
			this.Parameters = (parameters ?? new object[0]);
		}

		// Token: 0x17002E48 RID: 11848
		// (get) Token: 0x0600A0C1 RID: 41153 RVA: 0x0007E2B5 File Offset: 0x0007C4B5
		public Message.EnumType Type { get; }

		// Token: 0x17002E49 RID: 11849
		// (get) Token: 0x0600A0C2 RID: 41154 RVA: 0x0007E2BD File Offset: 0x0007C4BD
		public #M6e Code { get; }

		// Token: 0x17002E4A RID: 11850
		// (get) Token: 0x0600A0C3 RID: 41155 RVA: 0x0007E2C5 File Offset: 0x0007C4C5
		public object[] Parameters { get; }

		// Token: 0x17002E4B RID: 11851
		// (get) Token: 0x0600A0C4 RID: 41156 RVA: 0x0007E2CD File Offset: 0x0007C4CD
		// (set) Token: 0x0600A0C5 RID: 41157 RVA: 0x0007E2D5 File Offset: 0x0007C4D5
		public string DebugInfo { get; set; }

		// Token: 0x0600A0C6 RID: 41158 RVA: 0x0007E2DE File Offset: 0x0007C4DE
		public static Message #qn(#M6e #3, params object[] #Pc)
		{
			return new Message(Message.EnumType.Error, #3, #Pc);
		}

		// Token: 0x0600A0C7 RID: 41159 RVA: 0x0007E2E8 File Offset: 0x0007C4E8
		public static Message #ZSc(#M6e #3, params object[] #Pc)
		{
			return new Message(Message.EnumType.Warning, #3, #Pc);
		}

		// Token: 0x0600A0C8 RID: 41160 RVA: 0x0007E2F2 File Offset: 0x0007C4F2
		public static Message #R6e(#M6e #3, params object[] #Pc)
		{
			return new Message(Message.EnumType.Note, #3, #Pc);
		}

		// Token: 0x0600A0C9 RID: 41161 RVA: 0x0007E2FC File Offset: 0x0007C4FC
		public static Message #S6e(#M6e #3, params object[] #Pc)
		{
			return new Message(Message.EnumType.DesignTrace, #3, #Pc);
		}

		// Token: 0x0600A0CA RID: 41162 RVA: 0x00223B84 File Offset: 0x00221D84
		public string #T6e()
		{
			if (this.Type == Message.EnumType.Error)
			{
				return #Phc.#3hc(107291531);
			}
			if (this.Type == Message.EnumType.Warning)
			{
				return #Phc.#3hc(107311464);
			}
			if (this.Type == Message.EnumType.Note)
			{
				return #Phc.#3hc(107311487);
			}
			return #Phc.#3hc(107311478);
		}

		// Token: 0x0600A0CB RID: 41163 RVA: 0x0007E306 File Offset: 0x0007C506
		public string #U6e()
		{
			return #j7e.#h7e(this.Code);
		}

		// Token: 0x0600A0CC RID: 41164 RVA: 0x0007E313 File Offset: 0x0007C513
		public string #V6e()
		{
			return #j7e.#i7e(this.Code);
		}

		// Token: 0x04004653 RID: 18003
		[CompilerGenerated]
		private readonly Message.EnumType #a;

		// Token: 0x04004654 RID: 18004
		[CompilerGenerated]
		private readonly #M6e #b;

		// Token: 0x04004655 RID: 18005
		[CompilerGenerated]
		private readonly object[] #c;

		// Token: 0x04004656 RID: 18006
		[CompilerGenerated]
		private string #d;

		// Token: 0x020012C1 RID: 4801
		public enum EnumType
		{
			// Token: 0x04004658 RID: 18008
			Error,
			// Token: 0x04004659 RID: 18009
			Warning,
			// Token: 0x0400465A RID: 18010
			Note,
			// Token: 0x0400465B RID: 18011
			DesignTrace
		}
	}
}
