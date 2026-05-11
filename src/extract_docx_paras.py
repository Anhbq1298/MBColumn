import docx

def extract_paragraphs(docx_path):
    doc = docx.Document(docx_path)
    for i, p in enumerate(doc.paragraphs):
        text = p.text.strip()
        if text:
            print(f"P{i}: {text[:100]}") # Show first 100 chars

if __name__ == "__main__":
    path = r"C:\Users\NCPC\Desktop\_ReverseEngineering\s-conc\Gemini_NvsM_Test_Package_v2.docx"
    extract_paragraphs(path)
