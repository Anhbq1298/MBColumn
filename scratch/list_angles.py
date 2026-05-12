import docx
import re

def list_angles(docx_path):
    doc = docx.Document(docx_path)
    angles = []
    for para in doc.paragraphs:
        text = para.text.strip()
        match = re.search(r'Theta\s*\(Degrees\)\s*(\d+)', text, re.IGNORECASE)
        if match:
            angles.append(int(match.group(1)))
    return angles

if __name__ == "__main__":
    path = r"C:\Users\NCPC\Desktop\_ReverseEngineering\s-conc\Gemini_NvsM_Test_Package_v2.docx"
    angles = list_angles(path)
    print(f"Found angles: {angles}")
