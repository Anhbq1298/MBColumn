import docx
import json

def extract_tables(docx_path):
    doc = docx.Document(docx_path)
    tables_data = []
    for table in doc.tables:
        table_data = []
        for row in table.rows:
            table_data.append([cell.text.strip() for cell in row.cells])
        tables_data.append(table_data)
    return tables_data

if __name__ == "__main__":
    path = r"C:\Users\NCPC\Desktop\_ReverseEngineering\s-conc\Gemini_NvsM_Test_Package_v2.docx"
    try:
        data = extract_tables(path)
        print(json.dumps(data, indent=2))
    except Exception as e:
        print(f"Error: {e}")
