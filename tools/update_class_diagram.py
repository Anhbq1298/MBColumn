import os
import re

SRC_DIR = r"c:\repo\MBColumn\MBColumn\src"
CLASS_DIAGRAM_PATH = r"c:\repo\MBColumn\MBColumn\src\class_diagram.md"

def extract_types_from_file(filepath, category):
    with open(filepath, 'r', encoding='utf-8', errors='ignore') as f:
        content = f.read()
    
    # Strip block comments /* ... */
    content_clean = re.sub(r'/\*[\s\S]*?\*/', '', content)
    
    # Match type declarations: public/internal/etc class/interface/record/enum Name
    pattern = r'\b(class|interface|record|enum)\s+([a-zA-Z0-9_]+)(?:\s*<[^>]+>)?'
    
    types = []
    matches = list(re.finditer(pattern, content_clean))
    
    for i, match in enumerate(matches):
        decl_type = match.group(1)
        decl_name = match.group(2)
        
        # Avoid matching generic type constraints or standard non-declarations
        # e.g., "where T : class" or "where T : struct"
        pre_text = content_clean[max(0, match.start() - 10):match.start()]
        if ":" in pre_text and "where" in content_clean[max(0, match.start() - 50):match.start()]:
            continue
            
        start_pos = match.start()
        end_pos = matches[i+1].start() if i + 1 < len(matches) else len(content_clean)
        body = content_clean[start_pos:end_pos]
        
        # Extract docstring if present before the type declaration
        prev_start = matches[i-1].end() if i > 0 else 0
        header_area = content_clean[max(prev_start, start_pos - 600):start_pos]
        docstring = ""
        
        summary_match = re.findall(r'///\s*<summary>([\s\S]*?)</summary>', header_area)
        if summary_match:
            docstring = summary_match[-1].strip().replace('\n', ' ').replace('\r', '')
            docstring = re.sub(r'\s+', ' ', docstring)
            docstring = re.sub(r'<see\s+cref="[^"]+"\s*/>', lambda m: m.group(0).split('"')[1].split('.')[-1], docstring)
            docstring = re.sub(r'<[^>]+>', '', docstring)
            docstring = docstring.strip()
        else:
            doc_lines = re.findall(r'///\s*(.*)', header_area)
            if doc_lines:
                doc_lines = [l for l in doc_lines if not any(t in l for t in ['<summary>', '</summary>', '<param', '<returns', '<value'])]
                if doc_lines:
                    docstring = " ".join(doc_lines).strip()
                    docstring = re.sub(r'\s+', ' ', docstring)
        
        # Parse key methods: public methods
        method_pattern = r'\bpublic\s+(?:async\s+)?(?:static\s+)?(?:[a-zA-Z0-9_<>\?\[\]]+\s+)+([a-zA-Z0-9_]+)\s*\('
        methods = []
        for m in re.finditer(method_pattern, body):
            method_name = m.group(1)
            if method_name not in ['if', 'for', 'foreach', 'switch', 'while', 'using', 'lock', 'catch', 'new', decl_name]:
                if method_name not in methods:
                    methods.append(method_name)
                    
        # Parse key properties: public properties
        prop_pattern = r'\bpublic\s+(?:static\s+|readonly\s+|required\s+|virtual\s+|override\s+|sealed\s+)*([a-zA-Z0-9_<>\?\[\]\(\),]+)\s+([a-zA-Z0-9_]+)\s*(?:\{\s*get|=>)'
        properties = []
        for p in re.finditer(prop_pattern, body):
            prop_name = p.group(2)
            if prop_name not in ['if', 'for', 'foreach', 'switch', 'while', 'using', 'lock', 'catch', 'new', decl_name]:
                if prop_name not in properties:
                    properties.append(prop_name)
                    
        types.append({
            'type': decl_type,
            'name': decl_name,
            'docstring': docstring,
            'methods': methods[:4],  # Limit to 4 to keep tables neat
            'properties': properties[:4],  # Limit to 4 to keep tables neat
            'file': os.path.basename(filepath)
        })
        
    return types

def generate_description(t):
    doc = t['docstring']
    name = t['name']
    decl_type = t['type']
    
    desc = ""
    if doc:
        desc = doc
    else:
        # Default templates
        clean_name = name
        if name.endswith('Service'):
            clean_name = name[:-7]
            desc = f"Provides service logic and operations for {clean_name}."
        elif name.endswith('Result'):
            clean_name = name[:-6]
            desc = f"Encapsulates the result of {clean_name} operations."
        elif name.endswith('Dto'):
            clean_name = name[:-3]
            desc = f"Data transfer object carrying {clean_name} data."
        elif name.endswith('Row'):
            clean_name = name[:-3]
            desc = f"Data structure representing a row for {clean_name}."
        elif name.endswith('Validator'):
            clean_name = name[:-9]
            desc = f"Validation logic for {clean_name}."
        elif name.endswith('Mapper'):
            clean_name = name[:-6]
            desc = f"Maps data structures for {clean_name}."
        elif name.endswith('Adapter'):
            desc = f"Represents the {name} class."
        elif decl_type == 'interface':
            desc = f"Defines the contract for {name}."
        elif decl_type == 'enum':
            desc = f"Enumeration defining states/types for {name}."
        else:
            desc = f"Represents the {name} {decl_type}."
            
    parts = []
    if t['methods']:
        parts.append(f"Key methods: {', '.join(t['methods'])}.")
    if t['properties']:
        parts.append(f"Key properties: {', '.join(t['properties'])}.")
        
    if parts:
        if not desc.endswith('.'):
            desc += '.'
        desc += " " + " ".join(parts)
        
    return desc

def main():
    projects = [
        "MBColumn.Application",
        "MBColumn.Domain",
        "MBColumn.Infrastructure",
        "MBColumn.Presentation.Wpf"
    ]
    
    all_data = {}
    
    for proj in projects:
        proj_path = os.path.join(SRC_DIR, proj)
        if not os.path.exists(proj_path):
            continue
            
        all_data[proj] = {}
        
        for root, dirs, files in os.walk(proj_path):
            if any(p in root.split(os.sep) for p in ['bin', 'obj', 'built', '.vs', 'Properties']):
                continue
                
            for file in files:
                if file.endswith('.cs'):
                    filepath = os.path.join(root, file)
                    rel_dir = os.path.relpath(root, proj_path)
                    category = rel_dir.replace('\\', '/')
                    if category == '.':
                        category = "Root"
                        
                    types = extract_types_from_file(filepath, category)
                    if not types:
                        continue
                        
                    if category not in all_data[proj]:
                        all_data[proj][category] = []
                    all_data[proj][category].extend(types)

    markdown = []
    markdown.append("# Project Class Diagram & Overview")
    markdown.append("")
    markdown.append("This document provides an overview of the classes, interfaces, records, and enums in the MBColumn project.")
    markdown.append("")

    for proj in sorted(all_data.keys()):
        markdown.append(f"## {proj}")
        markdown.append("")
        
        categories = all_data[proj]
        for cat in sorted(categories.keys()):
            markdown.append(f"### {cat}")
            markdown.append("")
            markdown.append("| Type | Name | Description | File |")
            markdown.append("|---|---|---|---|")
            
            # Sort types by name
            types = sorted(categories[cat], key=lambda x: x['name'])
            for t in types:
                desc = generate_description(t)
                markdown.append(f"| `{t['type']}` | **{t['name']}** | {desc} | `{t['file']}` |")
                
            markdown.append("")
            
    with open(CLASS_DIAGRAM_PATH, 'w', encoding='utf-8') as f:
        f.write("\n".join(markdown))
        
    print(f"Successfully generated class diagram in {CLASS_DIAGRAM_PATH}")

if __name__ == "__main__":
    main()
