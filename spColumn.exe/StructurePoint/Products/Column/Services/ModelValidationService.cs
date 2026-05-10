using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using #0be;
using #2be;
using #qJ;
using devDept.Geometry;
using FluentValidation.Results;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.Validation;
using StructurePoint.Products.Column.Model;
using StructurePoint.Products.Column.Model.Entities;

namespace StructurePoint.Products.Column.Services
{
	// Token: 0x0200029F RID: 671
	internal sealed class ModelValidationService : #LJ
	{
		// Token: 0x060015E4 RID: 5604 RVA: 0x000B3478 File Offset: 0x000B1678
		public #SJ #IH(ColumnModel #Od)
		{
			ModelValidationService.#GTb #GTb = new ModelValidationService.#GTb();
			#SJ #SJ = new #SJ();
			#GTb.#a = #Od.#BY();
			StorageModelValidator storageModelValidator = new StorageModelValidator(#GTb.#a);
			ColumnStorageModel instance = #Od.#CY();
			ValidationResult validationResult = storageModelValidator.Validate(instance);
			#SJ.Errors.AddRange(validationResult.Errors.Where(new Func<ValidationFailure, bool>(ModelValidationService.<>c.<>9.#5Zb)));
			#SJ.Warnings.AddRange(validationResult.Errors.Where(new Func<ValidationFailure, bool>(ModelValidationService.<>c.<>9.#6Zb)));
			if (#SJ.Errors.Any<ValidationFailure>())
			{
				#SJ.FormattedErrors = #Zbe.#Ybe(#SJ.Errors, #GTb.#a);
				#SJ.FormattedErrorsCompact = string.Join(Environment.NewLine, #SJ.Errors.Select(new Func<ValidationFailure, string>(#GTb.#4Zb)));
			}
			return #SJ;
		}

		// Token: 0x060015E5 RID: 5605 RVA: 0x000B3590 File Offset: 0x000B1790
		public ISet<Point3D> #JJ(IList<ReinforcementBar> #KJ)
		{
			HashSet<Point3D> hashSet = new HashSet<Point3D>();
			List<ModelValidationService.BarDistanceMetadata> list = #KJ.Select(new Func<ReinforcementBar, ModelValidationService.BarDistanceMetadata>(ModelValidationService.<>c.<>9.#7Zb)).ToList<ModelValidationService.BarDistanceMetadata>();
			for (int i = 0; i < list.Count; i++)
			{
				ModelValidationService.BarDistanceMetadata barDistanceMetadata = list[i];
				Point3D point3D = barDistanceMetadata.Location;
				for (int j = i + 1; j < list.Count; j++)
				{
					ModelValidationService.BarDistanceMetadata barDistanceMetadata2 = list[j];
					if (point3D.DistanceTo(barDistanceMetadata2.Location) < barDistanceMetadata.Radius + barDistanceMetadata2.Radius)
					{
						hashSet.Add(barDistanceMetadata.Location);
						hashSet.Add(barDistanceMetadata2.Location);
					}
				}
			}
			return hashSet;
		}

		// Token: 0x020002A0 RID: 672
		private struct BarDistanceMetadata
		{
			// Token: 0x170007BD RID: 1981
			// (get) Token: 0x060015E7 RID: 5607 RVA: 0x00016E06 File Offset: 0x00015006
			// (set) Token: 0x060015E8 RID: 5608 RVA: 0x00016E12 File Offset: 0x00015012
			public Point3D Location { readonly get; set; }

			// Token: 0x170007BE RID: 1982
			// (get) Token: 0x060015E9 RID: 5609 RVA: 0x00016E23 File Offset: 0x00015023
			// (set) Token: 0x060015EA RID: 5610 RVA: 0x00016E2F File Offset: 0x0001502F
			public double Radius { readonly get; set; }

			// Token: 0x040008C0 RID: 2240
			[CompilerGenerated]
			private Point3D #a;

			// Token: 0x040008C1 RID: 2241
			[CompilerGenerated]
			private double #b;
		}

		// Token: 0x020002A2 RID: 674
		[CompilerGenerated]
		private sealed class #GTb
		{
			// Token: 0x060015F1 RID: 5617 RVA: 0x00016E76 File Offset: 0x00015076
			internal string #4Zb(ValidationFailure #Rf)
			{
				return #Zbe.#qp(#Rf, this.#a);
			}

			// Token: 0x040008C6 RID: 2246
			public #ice #a;
		}
	}
}
