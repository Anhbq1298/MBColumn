#!/usr/bin/env python3
"""
Extract test parameters and PMM data from Gemini_NvsM_Test_Package_v2.docx
Uses zipfile and xml.etree.ElementTree for extraction (no python-docx required)
"""

import zipfile
import xml.etree.ElementTree as ET
import csv
import re
import os
from pathlib import Path

def extract_docx_structure(docx_path):
    """Extract text and tables from docx by reading XML"""
    
    namespaces = {
        'w': 'http://schemas.openxmlformats.org/wordprocessingml/2006/main',
        'a': 'http://schemas.openxmlformats.org/drawingml/2006/main',
        'pic': 'http://schemas.openxmlformats.org/drawingml/2006/picture',
    }
    
    full_text = []
    tables_data = []
    
    try:
        with zipfile.ZipFile(docx_path, 'r') as zip_ref:
            # Read document.xml
            with zip_ref.open('word/document.xml') as f:
                tree = ET.parse(f)
                root = tree.getroot()
                
                # Extract all paragraphs
                for para in root.findall('.//w:p', namespaces):
                    para_text = extract_text_from_element(para, namespaces)
                    if para_text.strip():
                        full_text.append(para_text)
                
                # Extract all tables
                for table in root.findall('.//w:tbl', namespaces):
                    table_rows = extract_table_rows(table, namespaces)
                    if table_rows:
                        tables_data.append(table_rows)
    
    except Exception as e:
        print(f"Error reading docx: {e}")
        return None, None
    
    return full_text, tables_data

def extract_text_from_element(element, namespaces):
    """Extract all text from element and children"""
    texts = []
    for t_elem in element.findall('.//w:t', namespaces):
        if t_elem.text:
            texts.append(t_elem.text)
    return ''.join(texts)

def extract_table_rows(table, namespaces):
    """Extract table as list of rows (each row is list of cell texts)"""
    rows = []
    for row in table.findall('.//w:tr', namespaces):
        cells = []
        for cell in row.findall('.//w:tc', namespaces):
            cell_text = extract_text_from_element(cell, namespaces)
            cells.append(cell_text.strip())
        if cells:
            rows.append(cells)
    return rows

def parse_test_parameters(full_text):
    """Extract test parameters from text"""
    params = {
        'section_width_mm': None,
        'section_height_mm': None,
        'rebar_diameter_mm': None,
        'rebar_count': None,
        'fc_mpa': None,
        'fy_mpa': None,
        'design_code': None,
        'units': None,
        'full_text': ' '.join(full_text)
    }
    
    combined_text = params['full_text'].lower()
    
    # Detect design code
    if 'aci' in combined_text:
        params['design_code'] = 'ACI'
    elif 'eurocode' in combined_text or 'ec2' in combined_text:
        params['design_code'] = 'Eurocode'
    
    # Detect units
    if 'mm' in combined_text:
        params['units'] = 'mm'
    elif 'in' in combined_text and 'inch' in combined_text:
        params['units'] = 'inches'
    
    # Try to extract numeric values
    # Section dimensions (e.g., "700 mm" or "700x700")
    dim_match = re.search(r'(\d+)\s*(?:x|by|×)\s*(\d+)\s*mm', combined_text)
    if dim_match:
        params['section_width_mm'] = int(dim_match.group(1))
        params['section_height_mm'] = int(dim_match.group(2))
    
    # Rebar diameter
    rebar_match = re.search(r'(\d+)\s*mm?\s*(?:rebar|bar)', combined_text)
    if rebar_match:
        params['rebar_diameter_mm'] = int(rebar_match.group(1))
    
    # Concrete strength (f'c)
    fc_match = re.search(r"f'?c\s*[=:]\s*(\d+(?:\.\d+)?)\s*mpa", combined_text)
    if fc_match:
        params['fc_mpa'] = float(fc_match.group(1))
    
    # Steel strength (fy)
    fy_match = re.search(r"fy\s*[=:]\s*(\d+(?:\.\d+)?)\s*mpa", combined_text)
    if fy_match:
        params['fy_mpa'] = float(fy_match.group(1))
    
    return params

def main():
    docx_path = r"c:\_ReverseEngineering\spColumnReversed-Solution\Gemini_NvsM_Test_Package_v2.docx"
    
    if not os.path.exists(docx_path):
        print(f"ERROR: File not found: {docx_path}")
        return 1
    
    print("="*80)
    print("EXTRACTING GEMINI_NVSM_TEST_PACKAGE_V2.DOCX")
    print("="*80)
    print()
    
    # Extract content
    full_text, tables_data = extract_docx_structure(docx_path)
    
    if full_text is None:
        print("ERROR: Could not extract from docx file")
        return 1
    
    # Parse parameters
    params = parse_test_parameters(full_text)
    
    # Display extracted text
    print("DOCUMENT TEXT CONTENT:")
    print("-" * 80)
    for i, line in enumerate(full_text[:30], 1):  # Show first 30 lines
        print(f"{i:3d}. {line[:76]}")
    if len(full_text) > 30:
        print(f"... ({len(full_text) - 30} more lines)")
    
    # Display tables
    print()
    print("="*80)
    print(f"DOCUMENT CONTAINS {len(tables_data)} TABLE(S)")
    print("="*80)
    
    for table_idx, table_rows in enumerate(tables_data):
        print(f"\nTABLE {table_idx + 1}:")
        print(f"  Rows: {len(table_rows)}")
        print(f"  Columns: {len(table_rows[0]) if table_rows else 0}")
        
        # Show first few rows
        for row_idx, row in enumerate(table_rows[:3]):
            print(f"  Row {row_idx}: {row[:5]}")  # Show first 5 columns
        
        if len(table_rows) > 3:
            print(f"  ... ({len(table_rows) - 3} more rows)")
    
    # Display parsed parameters
    print()
    print("="*80)
    print("EXTRACTED TEST PARAMETERS")
    print("="*80)
    print(f"Section Dimensions: {params['section_width_mm']} x {params['section_height_mm']} mm")
    print(f"Rebar Diameter: {params['rebar_diameter_mm']} mm")
    print(f"Rebar Count: {params['rebar_count']}")
    print(f"f'c (Concrete): {params['fc_mpa']} MPa")
    print(f"fy (Steel): {params['fy_mpa']} MPa")
    print(f"Design Code: {params['design_code']}")
    print(f"Units: {params['units']}")
    
    # Save tables to CSV
    if tables_data:
        print()
        print("="*80)
        print("SAVING TABLES TO CSV")
        print("="*80)
        
        validation_dir = r"c:\_ReverseEngineering\spColumnReversed-Solution\docs\validation"
        os.makedirs(validation_dir, exist_ok=True)
        
        for table_idx, table_rows in enumerate(tables_data):
            csv_filename = f"gemini_table_{table_idx}.csv"
            csv_path = os.path.join(validation_dir, csv_filename)
            
            with open(csv_path, 'w', newline='', encoding='utf-8') as f:
                writer = csv.writer(f)
                writer.writerows(table_rows)
            
            print(f"✓ Saved: {csv_filename}")
            print(f"  Path: {csv_path}")
            print(f"  Rows: {len(table_rows)}, Columns: {len(table_rows[0]) if table_rows else 0}")
    
    return 0

if __name__ == '__main__':
    exit(main())
