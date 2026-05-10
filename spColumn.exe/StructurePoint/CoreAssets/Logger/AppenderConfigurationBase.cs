using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace StructurePoint.CoreAssets.Logger
{
	// Token: 0x02000F18 RID: 3864
	[DataContract]
	public abstract class AppenderConfigurationBase
	{
		// Token: 0x0600897F RID: 35199 RVA: 0x0006FEDA File Offset: 0x0006E0DA
		protected AppenderConfigurationBase()
		{
			this.Levels = new Collection<LoggingLevel>();
		}

		// Token: 0x06008980 RID: 35200 RVA: 0x0006FEED File Offset: 0x0006E0ED
		protected AppenderConfigurationBase(IEnumerable<LoggingLevel> levels)
		{
			#X0d.#V0d(levels, #Phc.#3hc(107223219), Component.Logger, #Phc.#3hc(107223178));
			this.Levels = new Collection<LoggingLevel>(levels.ToList<LoggingLevel>());
		}

		// Token: 0x17002887 RID: 10375
		// (get) Token: 0x06008981 RID: 35201 RVA: 0x0006FF21 File Offset: 0x0006E121
		// (set) Token: 0x06008982 RID: 35202 RVA: 0x0006FF2D File Offset: 0x0006E12D
		[DataMember]
		public Collection<LoggingLevel> Levels { get; private set; }
	}
}
