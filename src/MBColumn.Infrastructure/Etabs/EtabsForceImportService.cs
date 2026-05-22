using ETABSv1;
using MBColumn.Application.DTOs.Etabs;
using MBColumn.Application.Services.Etabs;
using SMath = System.Math;

namespace MBColumn.Infrastructure.Etabs;

public sealed class EtabsForceImportService : IEtabsForceImportService
{
    private readonly EtabsConnectionService connection;

    public EtabsForceImportService(EtabsConnectionService connection)
    {
        this.connection = connection;
    }

    public IReadOnlyList<EtabsForceResultDto> GetForces(
        IReadOnlyList<EtabsColumnImportDto> columns,
        IReadOnlyList<string> loadCombinations)
    {
        var model = connection.Model
            ?? throw new InvalidOperationException("Not connected to ETABS.");

        var units = model.GetPresentUnits();
        var (forceToKn, lengthToMm) = EtabsConnectionService.GetConversionFactors(units);
        var momentFactor = forceToKn * lengthToMm;

        ConfigureOutput(model, loadCombinations);

        var results = new List<EtabsForceResultDto>();
        var selectedComboSet = new HashSet<string>(loadCombinations, StringComparer.OrdinalIgnoreCase);

        foreach (var column in columns)
        {
            var columnResults = QueryColumnForces(model, column, selectedComboSet, forceToKn, momentFactor);
            results.AddRange(columnResults);
        }

        return results;
    }

    private static void ConfigureOutput(cSapModel model, IReadOnlyList<string> loadCombinations)
    {
        model.Results.Setup.DeselectAllCasesAndCombosForOutput();
        foreach (var combo in loadCombinations)
        {
            model.Results.Setup.SetComboSelectedForOutput(combo, true);
        }

        // Envelope mode: returns Max and Min rows per combo
        model.Results.Setup.SetOptionMultiValuedCombo(0);
    }

    private static IEnumerable<EtabsForceResultDto> QueryColumnForces(
        cSapModel model,
        EtabsColumnImportDto column,
        HashSet<string> selectedCombos,
        double forceToKn,
        double momentFactor)
    {
        int numResults = 0;
        string[] obj = [];
        double[] objSta = [];
        string[] elm = [];
        double[] elmSta = [];
        string[] loadCase = [];
        string[] stepType = [];
        double[] stepNum = [];
        double[] p = [];
        double[] v2 = [];
        double[] v3 = [];
        double[] t = [];
        double[] m2 = [];
        double[] m3 = [];

        var ret = model.Results.FrameForce(
            column.ObjectName,
            eItemTypeElm.ObjectElm,
            ref numResults,
            ref obj,
            ref objSta,
            ref elm,
            ref elmSta,
            ref loadCase,
            ref stepType,
            ref stepNum,
            ref p,
            ref v2,
            ref v3,
            ref t,
            ref m2,
            ref m3);

        if (ret != 0 || numResults == 0)
            yield break;

        // Group by (loadCombo, stepType) and take one representative row per combo
        // For envelope output, stepType is "Max" or "Min"; we keep both
        var seen = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        for (var i = 0; i < numResults; i++)
        {
            var combo = loadCase[i];
            if (!selectedCombos.Contains(combo))
                continue;

            var key = $"{combo}|{stepType[i]}";
            if (!seen.Add(key))
                continue;

            var status = stepType[i] switch
            {
                "Max" => "Envelope Max",
                "Min" => "Envelope Min",
                _ => stepType[i]
            };

            yield return new EtabsForceResultDto(
                column.ObjectName,
                column.PierName,
                column.StoryName,
                column.Label,
                column.EtabsSectionName,
                combo,
                SMath.Round(p[i] * forceToKn, 3),
                SMath.Round(m2[i] * momentFactor, 3),
                SMath.Round(m3[i] * momentFactor, 3),
                SMath.Round(v2[i] * forceToKn, 3),
                SMath.Round(v3[i] * forceToKn, 3),
                status);
        }
    }
}
