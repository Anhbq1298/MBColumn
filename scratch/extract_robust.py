import docx
import json
import re

def extract_robust(docx_path):
    doc = docx.Document(docx_path)
    results = {}
    current_angle = None
    
    for para in doc.paragraphs:
        # Split paragraph into lines in case of soft returns
        lines = para.text.replace('\r', '\n').split('\n')
        for line in lines:
            text = line.strip()
            if not text: continue
            
            # Header check
            match = re.search(r'Theta\s*\(Degrees\)\s*(\d+)', text, re.IGNORECASE)
            if match:
                current_angle = int(match.group(1))
                if current_angle not in results:
                    results[current_angle] = []
                continue
            
            if current_angle is not None:
                # Robust numeric extraction: find all numbers in the line
                # We expect at least two.
                nums = re.findall(r'[-+]?\d*\.\d+|\b\d+\b', text)
                if len(nums) >= 2:
                    try:
                        p = float(nums[0])
                        m = float(nums[1])
                        results[current_angle].append({"P": p, "M": m})
                    except ValueError:
                        pass
                        
    return results

if __name__ == "__main__":
    path = r"C:\Users\NCPC\Desktop\_ReverseEngineering\s-conc\Gemini_NvsM_Test_Package_v2.docx"
    data = extract_robust(path)
    
    with open(r"C:\Users\NCPC\OneDrive - Meinhardt Singapore Pte Ltd\_ReverseEngineering\spColumnReversed-Solution\tests\MBColumn.Tests\benchmark_multi_angle.json", "w") as f:
        json.dump(data, f, indent=2)
        
    print(f"Angles found: {sorted(data.keys())}")
    for a in sorted(data.keys()):
        print(f"Angle {a}: {len(data[a])} points")
