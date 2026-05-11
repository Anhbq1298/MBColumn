import docx
import json

def extract_benchmark(docx_path):
    doc = docx.Document(docx_path)
    lines = []
    for p in doc.paragraphs:
        lines.extend(p.text.split('\n'))
    
    benchmark = {}
    current_theta = None
    collecting = False
    
    for line in lines:
        line = line.strip()
        if 'Theta (Degrees)' in line:
            parts = line.split(':')
            if len(parts) > 1:
                try:
                    current_theta = float(parts[1].split()[0])
                    benchmark[current_theta] = []
                    collecting = True
                    continue
                except: pass
        
        if collecting:
            # Check if we hit another header or end
            if not line or any(x in line for x in ['Appendix', 'Notes', 'Theta']):
                if line.startswith('Theta'):
                    pass # Handled above
                else:
                    # Don't stop yet if it's just a blank line
                    if not line: continue
                    # collecting = False # Usually we stop at next section
            
            parts = line.split()
            if len(parts) >= 2:
                try:
                    p = float(parts[0])
                    m = float(parts[1])
                    benchmark[current_theta].append({'P': p, 'M': m})
                except:
                    pass

    return benchmark

if __name__ == "__main__":
    path = r"C:\Users\NCPC\Desktop\_ReverseEngineering\s-conc\Gemini_NvsM_Test_Package_v2.docx"
    data = extract_benchmark(path)
    # Save Theta 0 specifically
    if 0.0 in data:
        with open('benchmark_theta_0.json', 'w') as f:
            json.dump(data[0.0], f, indent=2)
        print(f"Extracted {len(data[0.0])} points for Theta 0")
    else:
        print("Theta 0 not found. Available thetas:", list(data.keys()))
        # Print first few lines to debug
        # ...
