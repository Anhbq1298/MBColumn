import docx
import re

def list_all_theta(docx_path):
    doc = docx.Document(docx_path)
    found = []
    for para in doc.paragraphs:
        t = para.text.strip()
        if "Theta" in t:
            # Try to find numbers near Theta
            nums = re.findall(r'\d+', t)
            found.append((t, nums))
    return found

if __name__ == "__main__":
    path = r"C:\Users\NCPC\Desktop\_ReverseEngineering\s-conc\Gemini_NvsM_Test_Package_v2.docx"
    info = list_all_theta(path)
    for t, n in info:
        print(f"[{t}] -> {n}")
