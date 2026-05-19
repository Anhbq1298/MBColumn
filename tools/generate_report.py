import os

input_path = r'C:\Users\NCPC\OneDrive - Meinhardt Singapore Pte Ltd\_ReverseEngineering\refReversed-Solution\final_validation_data_v2.txt'
output_path = r'C:\Users\NCPC\OneDrive - Meinhardt Singapore Pte Ltd\_ReverseEngineering\refReversed-Solution\detailed_validation_report.html'

def parse_data():
    # Use utf-16 as it was detected as UTF-16LE previously
    try:
        with open(input_path, 'r', encoding='utf-16') as f:
            lines = f.readlines()
    except UnicodeDecodeError:
        with open(input_path, 'r', encoding='utf-8') as f:
            lines = f.readlines()
    
    report_data = {}
    current_angle = None
    
    for line in lines:
        line = line.strip()
        if "Validating ref Angle" in line:
            # Format: Validating ref Angle 0 (MB Angle 90)
            try:
                angle_part = line.split("Angle")[1].split("(")[0].strip()
                current_angle = angle_part
                report_data[current_angle] = []
            except:
                continue
        elif "|" in line and current_angle and "Ref P" not in line and "---" not in line:
            parts = [p.strip() for p in line.split("|")]
            if len(parts) >= 6:
                try:
                    # Skip empty/garbage rows
                    if not parts[0]: continue
                    report_data[current_angle].append({
                        "refP": parts[0],
                        "calcP": parts[1],
                        "refM": parts[2],
                        "calcM": parts[3],
                        "delta": parts[4],
                        "error": parts[5]
                    })
                except:
                    continue
    return report_data

data = parse_data()

html = """
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<style>
    body { font-family: 'Segoe UI', sans-serif; line-height: 1.2; color: #333; margin: 0; padding: 20px; font-size: 9px; }
    h1 { color: #2c3e50; border-bottom: 2px solid #3498db; font-size: 18px; margin-bottom: 10px; }
    h2 { color: #2980b9; margin-top: 15px; margin-bottom: 10px; font-size: 14px; }
    table { width: 100%; border-collapse: collapse; margin-bottom: 5px; }
    th, td { border: 1px solid #ddd; padding: 3px; text-align: right; }
    th { background-color: #f2f2f2; font-weight: bold; text-align: center; }
    tr:nth-child(even) { background-color: #fafafa; }
    .summary { background-color: #f9f9f9; padding: 8px; border: 1px solid #3498db; margin-bottom: 10px; font-size: 11px; }
    .page-break { page-break-after: always; }
    @media print {
        .page-break { display: block; page-break-after: always; }
        h2 { page-break-before: always; }
    }
</style>
</head>
<body>
    <h1>MBColumn: Eurocode 2 PMM 500-Point Audit Report</h1>
    <div class="summary">
        <strong>Validation Scope:</strong> 5 Biaxial Angles x 100 Points per Angle <br>
        <strong>Core Configuration:</strong> &alpha;<sub>cc</sub> = 0.80, Enforced Rebar Yield at Pure Axial <br>
        <strong>Reference Benchmark:</strong> ref (EN 1992-1-1)
    </div>
"""

# Sort angles numerically
sorted_angles = sorted(data.keys(), key=lambda x: int(x))

for angle in sorted_angles:
    points = data[angle]
    html += f"<h2>Angle {angle}&deg; Detailed Comparison (100 Points)</h2>"
    html += """
    <table>
        <thead>
            <tr>
                <th>Ref P (kN)</th>
                <th>Calc P (kN)</th>
                <th>Ref M (kNm)</th>
                <th>Calc M (kNm)</th>
                <th>Delta M</th>
                <th>Error %</th>
            </tr>
        </thead>
        <tbody>
    """
    sum_err = 0
    max_err = 0
    for p in points:
        html += f"""
        <tr>
            <td>{p['refP']}</td>
            <td>{p['calcP']}</td>
            <td>{p['refM']}</td>
            <td>{p['calcM']}</td>
            <td>{p['delta']}</td>
            <td>{p['error']}</td>
        </tr>
        """
        try:
            err_val = p['error'].replace('%','').strip()
            if err_val:
                err = float(err_val)
                sum_err += err
                max_err = max(max_err, err)
        except: pass
    
    avg_err = sum_err / len(points) if points else 0
    html += f"""
        </tbody>
    </table>
    <div class="summary">
        <strong>Angle {angle}&deg; Audit Summary:</strong><br>
        Average Deviation: {avg_err:.2f}% | Maximum Divergence: {max_err:.2f}%
    </div>
    <div class="page-break"></div>
    """

html += "</body></html>"

with open(output_path, 'w', encoding='utf-8') as f:
    f.write(html)
