import docx

def extract_theta_0_data(docx_path):
    doc = docx.Document(docx_path)
    found = False
    for p in doc.paragraphs:
        if 'Theta (Degrees)' in p.text and ' 0' in p.text and '351' not in p.text and '106' not in p.text:
            found = True
            print(f"Header: {p.text}")
            continue
        if found:
            if 'Theta (Degrees)' in p.text:
                break
            text = p.text.strip()
            if text:
                print(text)

if __name__ == "__main__":
    path = r"C:\Users\NCPC\Desktop\_ReverseEngineering\s-conc\Gemini_NvsM_Test_Package_v2.docx"
    extract_theta_0_data(path)
