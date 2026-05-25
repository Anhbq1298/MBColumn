import os
import time
import subprocess

SRC_DIR = r"c:\repo\MBColumn\MBColumn\src"
SCRIPT_PATH = r"c:\repo\MBColumn\MBColumn\tools\update_class_diagram.py"

def get_mtimes():
    mtimes = {}
    for root, dirs, files in os.walk(SRC_DIR):
        if any(p in root.split(os.sep) for p in ['bin', 'obj', 'built', '.vs']):
            continue
        for file in files:
            if file.endswith('.cs'):
                filepath = os.path.join(root, file)
                try:
                    mtimes[filepath] = os.path.getmtime(filepath)
                except OSError:
                    pass
    return mtimes

def main():
    print("Watching C# files for changes... Press Ctrl+C to stop.")
    last_mtimes = get_mtimes()
    
    try:
        while True:
            time.sleep(2)
            current_mtimes = get_mtimes()
            
            # Check if any file was added, modified or deleted
            changed = False
            if set(last_mtimes.keys()) != set(current_mtimes.keys()):
                changed = True
            else:
                for path, mtime in current_mtimes.items():
                    if last_mtimes.get(path) != mtime:
                        changed = True
                        break
                        
            if changed:
                print("Change detected in C# files. Rebuilding class diagram...")
                try:
                    subprocess.run(["python", SCRIPT_PATH], check=True)
                except subprocess.SubprocessError as e:
                    print(f"Error updating class diagram: {e}")
                last_mtimes = current_mtimes
    except KeyboardInterrupt:
        print("\nWatcher stopped.")

if __name__ == "__main__":
    main()
