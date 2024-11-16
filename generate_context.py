import os
from pathlib import Path
import pathspec

def generate_context_paths():
    root_path = os.getcwd()
    
    # Additional files to always ignore
    ALWAYS_IGNORE = {
        '.gitignore',
        'CodyAIBackupPrompt',
        'generate_context.py'
    }
    
    # Read .gitignore and create spec
    gitignore_path = os.path.join(root_path, '.gitignore')
    if os.path.exists(gitignore_path):
        with open(gitignore_path, 'r') as f:
            spec = pathspec.PathSpec.from_lines('gitwildmatch', f)
    else:
        spec = pathspec.PathSpec([])

    context_paths = []
    for root, dirs, files in os.walk(root_path):
        # Skip .git directory
        if '.git' in dirs:
            dirs.remove('.git')
            
        # Get relative paths for current directory
        rel_root = os.path.relpath(root, root_path)
        
        # Filter files based on gitignore and additional ignores
        for file in files:
            if file in ALWAYS_IGNORE:  # Check just the filename
                continue
            rel_path = os.path.join(rel_root, file)
            if not spec.match_file(rel_path):
                formatted_path = rel_path.replace(os.sep, '/')
                context_path = f"@{formatted_path}"
                context_paths.append(context_path)
        
        # Filter directories to avoid walking into ignored ones
        dirs[:] = [d for d in dirs if not spec.match_file(os.path.join(rel_root, d))]

    return ' '.join(context_paths)

if __name__ == "__main__":
    context_string = generate_context_paths()
    print(context_string)
