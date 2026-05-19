import docx
import json
import re

def extract_data(docx_path):
    doc = docx.Document(docx_path)
    results = {}
    current_angle = None
    
    # Iterate through all elements (paragraphs and tables)
    for element in doc.element.body:
        if element.tag.endswith('p'):
            # Paragraph
            para = docx.text.paragraph.Paragraph(element, doc)
            text = para.text.strip()
            if "Theta" in text:
                match = re.search(r'Theta\s*\(Degrees\)\s*(\d+)', text, re.IGNORECASE)
                if match:
                    current_angle = int(match.group(1))
                    results[current_angle] = []
        elif element.tag.endswith('tbl'):
            # Table
            if current_angle is not None:
                table = docx.table.Table(element, doc)
                for row in table.rows:
                    cells = [cell.text.strip() for cell in row.cells]
                    if len(cells) >= 2:
                        try:
                            # Try to parse two floats
                            p = float(cells[0].replace(',', ''))
                            m = float(cells[1].replace(',', ''))
                            # Sanity check: P is usually much larger than M in absolute value at peak
                            # Also skip header rows
                            results[current_angle].append({"P": p, "M": m})
                        except ValueError:
                            pass
                current_angle = None # Reset after processing the table
                
    return results

if __name__ == "__main__":
    path = r"C:\Users\NCPC\Desktop\_ReverseEngineering\ref\Gemini_NvsM_Test_Package_v2.docx"
    data = extract_data(path)
    
    # Save to JSON
    with open(r"C:\Users\NCPC\OneDrive - Meinhardt Singapore Pte Ltd\_ReverseEngineering\refReversed-Solution\tests\MBColumn.Tests\benchmark_multi_angle.json", "w") as f:
        json.dump(data, f, indent=2)
        
    print(f"Extracted data for angles: {list(data.keys())}")
    for angle in [0, 16, 75, 90, 135]:
        if angle in data:
            print(f"Angle {angle}: {len(data[angle])} points")
        else:
            print(f"Angle {angle}: NOT FOUND")
