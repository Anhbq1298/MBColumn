import docx
import json
import re

def extract_from_paras(docx_path):
    doc = docx.Document(docx_path)
    results = {}
    current_angle = None
    
    for para in doc.paragraphs:
        text = para.text.strip()
        if not text: continue
        
        # Header check
        match = re.search(r'Theta\s*\(Degrees\)\s*(\d+)', text, re.IGNORECASE)
        if match:
            current_angle = int(match.group(1))
            results[current_angle] = []
            continue
            
        if current_angle is not None:
            # Check if this line looks like data (two floats)
            # Lines might have tabs or spaces
            parts = text.split()
            if len(parts) == 2:
                try:
                    p = float(parts[0].replace(',', ''))
                    m = float(parts[1].replace(',', ''))
                    results[current_angle].append({"P": p, "M": m})
                except ValueError:
                    pass
            elif len(parts) > 2:
                # Handle cases with more columns if any
                try:
                    p = float(parts[0].replace(',', ''))
                    m = float(parts[1].replace(',', ''))
                    results[current_angle].append({"P": p, "M": m})
                except ValueError:
                    pass
                    
    return results

if __name__ == "__main__":
    path = r"C:\Users\NCPC\Desktop\_ReverseEngineering\s-conc\Gemini_NvsM_Test_Package_v2.docx"
    data = extract_from_paras(path)
    
    with open(r"C:\Users\NCPC\OneDrive - Meinhardt Singapore Pte Ltd\_ReverseEngineering\spColumnReversed-Solution\tests\MBColumn.Tests\benchmark_multi_angle.json", "w") as f:
        json.dump(data, f, indent=2)
        
    print(f"Angles found: {sorted(data.keys())}")
    for a in sorted(data.keys()):
        print(f"Angle {a}: {len(data[a])} points")
