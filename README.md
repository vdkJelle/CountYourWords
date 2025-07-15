##My solution for a CountYourWords assignment, where the subject was described as follows:

You are writing the software or script for CountYourWords, a word processing util that is capable of counting words in a text DOCUMENT. The document is basically a text file that needs to be parsed. The following remarks below apply:
- Numbers in the document are ignored and are not processed
- Other characters than words should be filtered out of the input, so ## or @ or !! are ignored
- You do not have to take in account strange combinations like: love4u or mail@address.nl, combinations like these are out of scope for this assignment
- Next to showing the total number of words in the document, the number of occurrences of each word is also calculated
- The total number of occurrences next to the word must be shown on screen one by one (in lowercase)
- Counting the occurrences per word is case insensitive (so Matchbox, matchbox, and MATCHBOX are all the same word)
- When printing the occurrences, the words must be in alphabetical order
- The document is a text file that will be read by your app/script and has the fixed name: input.txt

Example:

If your document is
- “..... The big brown fox number 4 jumped over the lazy dog. THE BIG BROWN FOX JUMPED OVER THE LAZY DOG. The Big Brown Fox 123 !!”

Your console output would be:

Number of words: 23
big 3
brown 3
dog 2
fox 3
jumped 2
lazy 2
number 1
over 2
the 5