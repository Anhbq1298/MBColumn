import docx

def find_headers(docx_path):
    doc = docx.Document(docx_path)
    for p in doc.paragraphs:
        if 'Theta' in p.text:
            print(f"Header found: '{p.text}'")

if __name__ == "__main__":
    path = r"C:\Users\NCPC\Desktop\_ReverseEngineering\s-conc\Gemini_NvsM_Test_Package_v2.docx"
    find_headers(path)
