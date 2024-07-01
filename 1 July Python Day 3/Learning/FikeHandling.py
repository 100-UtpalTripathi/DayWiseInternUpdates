def read_file(file_name):
    """Read and print the contents of a file."""
    with open(file_name, "r") as file:
        content = file.read()
        print(f"Contents of {file_name}:")
        print(content)
        print()

def write_file(file_name, content):
    """Write content to a file."""
    with open(file_name, "w") as file:
        file.write(content)
        print(f"Written to {file_name}:\n{content}\n")

def append_file(file_name, content):
    """Append content to a file."""
    with open(file_name, "a") as file:
        file.write(content)
        print(f"Appended to {file_name}:\n{content}\n")

def read_file_lines(file_name):
    """Read and print the contents of a file line by line."""
    with open(file_name, "r") as file:
        print(f"Contents of {file_name} (line by line):")
        for line in file:
            print(line, end="")
        print()

# Main function to demonstrate file handling
def main():
    # File names
    file_name = "example.txt"
    new_file_name = "new_example.txt"

    # Content to write and append
    content_to_write = "Hello, World!\nThis is the first line.\nThis is the second line.\n"
    content_to_append = "This is an appended line.\n"

    # Step 1: Write to a file
    write_file(file_name, content_to_write)

    # Step 2: Read from the file
    read_file(file_name)

    # Step 3: Append to the file
    append_file(file_name, content_to_append)

    # Step 4: Read from the file again to see the appended content
    read_file(file_name)

    # Step 5: Read the file line by line
    read_file_lines(file_name)

    # Step 6: Copy the contents to a new file
    with open(file_name, "r") as original_file, open(new_file_name, "w") as new_file:
        for line in original_file:
            new_file.write(line)

    # Step 7: Read the new file to verify the copy
    read_file(new_file_name)

if __name__ == "__main__":
    main()
