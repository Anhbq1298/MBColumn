import os
import sys
from pathlib import Path
import zipfile
import xml.etree.ElementTree as ET
import csv

def extract_docx_text_and_tables(docx_path):
    """Extract text and tables from docx by reading ZIP contents"""
    
    # Open docx as zip
    with zipfile.ZipFile(docx_path, 'r') as zip_ref:
        # Read document.xml
        try:
            with zip_ref.open('word/document.xml') as f:
                tree = ET.parse(f)
                root = tree.getroot()
                return process_docx_xml(root)
        except Exception as e:
            print(f"Error reading docx: {e}", file=sys.stderr)
            return None, None

def process_docx_xml(root):
    """Process the XML to extract paragraphs and tables"""
    
    namespaces = {
        'w': 'http://schemas.openxmlformats.org/wordprocessingml/2006/main',
        'a': 'http://schemas.openxmlformats.org/drawingml/2006/main',
        'pic': 'http://schemas.openxmlformats.org/drawingml/2006/picture',
    }
    
    full_text = []
    tables_data = []
    
    # Extract paragraphs and tables
    for element in root.iter():
        # Get paragraphs
        if element.tag.endswith('}p'):
            para_text = extract_paragraph_text(element, namespaces)
            if para_text.strip():
                full_text.append(para_text)
                print(para_text)
        
        # Get tables
        elif element.tag.endswith('}tbl'):
            table_rows = extract_table_data(element, namespaces)
            if table_rows:
                tables_data.append(table_rows)
                print(f"\nTABLE with {len(table_rows)} rows:")
                for row in table_rows[:5]:  # Print first 5 rows
                    print(row)
                if len(table_rows) > 5:
                    print(f"... ({len(table_rows) - 5} more rows)")
    
    return full_text, tables_data

def extract_paragraph_text(para_elem, namespaces):
    """Extract text from paragraph"""
    texts = []
    for elem in para_elem.iter():
        if elem.tag.endswith('}t'):
            if elem.text:
                texts.append(elem.text)
    return ''.join(texts)

def extract_table_data(tbl_elem, namespaces):
    """Extract table rows and cells"""
    rows = []
    for tr in tbl_elem.findall('.//w:tr', namespaces):
        row = []
        for tc in tr.findall('.//w:tc', namespaces):
            cell_text = []
            for para in tc.findall('.//w:p', namespaces):
                para_text = extract_paragraph_text(para, namespaces)
                cell_text.append(para_text)
            row.append(' '.join(cell_text).strip())
        if row:
            rows.append(row)
    return rows

def main():
    docx_path = r"c:\_ReverseEngineering\spColumnReversed-Solution\Gemini_NvsM_Test_Package_v2.docx"
    
    if not os.path.exists(docx_path):
        print(f"ERROR: File not found: {docx_path}", file=sys.stderr)
        sys.exit(1)
    
    print("="*80)
    print("EXTRACTING DOCX CONTENT")
    print("="*80 + "\n")
    
    full_text, tables_data = extract_docx_text_and_tables(docx_path)
    
    if full_text is None:
        print("Failed to extract content", file=sys.stderr)
        sys.exit(1)
    
    print("\n" + "="*80)
    print(f"SUMMARY: Found {len(full_text)} text blocks and {len(tables_data)} tables")
    print("="*80)
    
    # Save tables to CSV
    if tables_data:
        validation_dir = r"c:\_ReverseEngineering\spColumnReversed-Solution\docs\validation"
        os.makedirs(validation_dir, exist_ok=True)
        
        for idx, table_rows in enumerate(tables_data):
            csv_filename = f"gemini_table_{idx}.csv"
            csv_path = os.path.join(validation_dir, csv_filename)
            
            with open(csv_path, 'w', newline='', encoding='utf-8') as f:
                writer = csv.writer(f)
                writer.writerows(table_rows)
            
            print(f"\nSaved: {csv_path}")
            print(f"  Rows: {len(table_rows)}, Columns: {len(table_rows[0]) if table_rows else 0}")

if __name__ == '__main__':
    main()
