import docx

def find_all_thetas(docx_path):
    doc = docx.Document(docx_path)
    for idx, p in enumerate(doc.paragraphs):
        if 'Theta (Degrees)' in p.text:
            print(f"P{idx}: {p.text}")

if __name__ == "__main__":
    path = r"C:\Users\NCPC\Desktop\_ReverseEngineering\s-conc\Gemini_NvsM_Test_Package_v2.docx"
    find_all_thetas(path)
