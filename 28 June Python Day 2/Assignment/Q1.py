def longest_substring_without_repeating_characters(s):
    start = 0
    max_length = 0
    used_chars = {}

    # Iterate through the string
    for i, char in enumerate(s):

        # If the character is already in the used_chars dictionary and the start index is less than or equal to the index of the character in the used_chars dictionary, update the start index to the index of the character in the used_chars dictionary plus 1
        if char in used_chars and start <= used_chars[char]:
            start = used_chars[char] + 1
        else:
            max_length = max(max_length, i - start + 1) # Update the max_length if the current substring length is greater than the max_length
        
        used_chars[char] = i
    
    return max_length

# Example check
input_string = "abcabcbb"
print("Length of Longest Substring Without Repeating Characters:", longest_substring_without_repeating_characters(input_string))
