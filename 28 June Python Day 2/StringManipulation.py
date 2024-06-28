# This Python program demonstrates various string manipulation techniques

# Initializing a string variable
my_city = "New York"
# Checking the type of the variable (string)
print(type(my_city))  # Output: <class 'str'>

# Single quotes have exactly the same use as double quotes
my_city = 'New York'
# Checking the type of the variable (string)
print(type(my_city))  # Output: <class 'str'>

# Setting the variable type explicitly using the str() constructor
my_city = str("New York")
# Checking the type of the variable (string)
print(type(my_city))  # Output: <class 'str'>

# Concatenating two strings using the + operator
word1 = 'New '
word2 = 'York'
print(word1 + word2)  # Output: New York

# Finding the length of a string using len()
length = len('Rio de Janeiro')
print(length)  # Output: 13

# Replacing a substring within a string using replace()
replaced_string = 'Rio de Janeiro'.replace('Rio', 'Mar')
print(replaced_string)  # Output: Mar de Janeiro

# Counting the occurrences of a character in a string using count()
word = "Rio de Janeiro"
space_count = word.count(' ')
print(space_count)  # Output: 2

# Repeating a string multiple times using the * operator
words = "Tokyo" * 3
print(words)  # Output: TokyoTokyoTokyo

# Splitting a string into a list of words using split()
my_phrase = "let's go to the beach"
my_words = my_phrase.split(" ")

# Iterating over the list of words and printing each word
for word in my_words:
    print(word)

# Splitting a CSV string into a list of values using split()
my_csv = "mary;32;australia;mary@email.com"
my_data = my_csv.split(";")

# Iterating over the list of values and printing each value
for data in my_data:
    print(data)

# Removing multiple spaces from a string using regular expressions
import re
phrase = ' Do   or do    not   there    is  no try   '
# Removing all spaces from the string
phrase_no_space = re.sub(r'\s+', '', phrase)

print(phrase)  # Output: Do   or do    not   there    is  no try   
print(phrase_no_space)  # Output: Doordonotthereisnotry

# Removing leading whitespace from a string using lstrip()
regular_text = "   This is a regular text."
no_space_begin_text = regular_text.lstrip()

print(regular_text)  # Output: '   This is a regular text.'
print(no_space_begin_text)  # Output: 'This is a regular text.'

# Removing leading specified characters from a string using lstrip()
regular_text = "$@G#This is a regular text."
clean_begin_text = regular_text.lstrip("#$@G")

print(regular_text)  # Output: $@G#This is a regular text.
print(clean_begin_text)  # Output: This is a regular text.

# Removing trailing whitespace from a string using rstrip()
regular_text = "This is a regular text.   "
no_space_end_text = regular_text.rstrip()

print(regular_text)  # Output: 'This is a regular text.   '
print(no_space_end_text)  # Output: 'This is a regular text.'

# Removing leading and trailing whitespace from a string using strip()
regular_text = "  This is a regular text.   "
no_space_text = regular_text.strip()

print(regular_text)  # Output: '  This is a regular text.   '
print(no_space_text)  # Output: 'This is a regular text.'

# Converting a string to lowercase using lower()
regular_text = "This is a Regular TEXT."
lower_case_text = regular_text.lower()

print(regular_text)  # Output: This is a Regular TEXT.
print(lower_case_text)  # Output: this is a regular text.

# Converting a string to title case using title()
regular_text = "This is a regular text."
title_case_text = regular_text.title()

print(regular_text)  # Output: This is a regular text.
print(title_case_text)  # Output: This Is A Regular Text.

# Swapping the case of characters in a string using swapcase()
regular_text = "This IS a reguLar text."
swapped_case_text = regular_text.swapcase()

print(regular_text)  # Output: This IS a reguLar text.
print(swapped_case_text)  # Output: tHIS is A REGUlAR TEXT.

# Checking if a string is alphanumeric using isalnum()
word = 'beach'
print(word.isalnum())  # Output: True

word = '32'
print(word.isalnum())  # Output: True

word = 'number32'  # Notice there is no space
print(word.isalnum())  # Output: True

word = 'Favorite number is 32'  # Notice the space between words
print(word.isalnum())  # Output: False

word = '@number32$'  # Notice the special chars '@' and '$'
print(word.isalnum())  # Output: False

# Checking if a string starts with a specified prefix using startswith()
phrase = "This is a regular text"
print(phrase.startswith('This is'))  # Output: True
print(phrase.startswith('text'))  # Output: False

# Checking if a substring within a specific range starts with a specified prefix using startswith()
phrase = "This is a regular text"
print(phrase.startswith('regular', 10))  # The word regular starts at position 10 of the phrase, Output: True
print(phrase.startswith('regular', 10, 22))  # Look for 'regular text', Output: True
print(phrase.startswith('regular', 10, 15))  # Look for 'regul', Output: False

# Checking if a string starts with any of a list of prefixes using startswith()
phrase = "This is a regular text"
print(phrase.startswith(('regular', 'This')))  # Output: True
print(phrase.startswith(('regular', 'text')))  # Output: False
print(phrase.startswith(('regular', 'text'), 10, 22))  # Look for 'regular text', Output: True

# Capitalizing the first character of a string using capitalize()
text = 'this is a regular text'
print(text.capitalize())  # Output: This is a regular text

text = 'THIS IS A REGULAR TEXT'
print(text.capitalize())  # Output: This is a regular text

text = 'THIS $ 1S @ A R3GULAR TEXT!'
print(text.capitalize())  # Output: This $ 1s @ a r3gular text!

text = '3THIS $ 1S @ A R3GULAR TEXT!'
print(text.capitalize())  # Output: 3this $ 1s @ a r3gular text!

# Checking if a string is in uppercase using isupper()
text = 'This is a regular text'
print(text.isupper())  # Output: False

text = 'THIS IS A REGULAR TEXT'
print(text.isupper())  # Output: True

text = 'THIS $ 1S @ A R3GULAR TEXT!'
print(text.isupper())  # Output: True

# Joining a list of strings into a single string using join()
my_list = ['bmw', 'ferrari', 'mclaren']
print('$'.join(my_list))  # Output: bmw$ferrari$mclaren

# Checking if a string is numeric using isnumeric()
word = '32'
print(word.isnumeric())  # Output: True

print("\u2083".isnumeric())  # Unicode for subscript 3, Output: True

print("\u2169".isnumeric())  # Unicode for roman numeral X, Output: True

word = 'beach'
print(word.isnumeric())  # Output: False

word = 'number32'
print(word.isnumeric())  # Output: False

word = '1 2 3'  # Notice the space between chars
print(word.isnumeric())  # Output: False

word = '@32$'  # Notice the special chars '@' and '$'
print(word.isnumeric())  # Output: False

# Checking if a string is alphabetic using isalpha()
word = 'beach'
print(word.isalpha())  # Output: True

word = '32'
print(word.isalpha())  # Output: False

word = 'number32'
print(word.isalpha())  # Output: False

word = 'Favorite number is blue'  # Notice the space between words
print(word.isalpha())  # Output: False

word = '@beach$'  # Notice the special chars '@' and '$'
print(word.isalpha())  # Output: False

# Checking if a string is title cased using istitle()
text = 'This is a regular text'
print(text.istitle())  # Output: False

text = 'This Is A Regular Text'
print(text.istitle())  # Output: True

text = 'This $ Is @ A Regular 3 Text!'
print(text.istitle())  # Output: True

# Reversing a string using slicing
my_string = "ferrari"
my_string_reversed = my_string[::-1]

print(my_string)  # Output: ferrari
print(my_string_reversed)  # Output: irarref
