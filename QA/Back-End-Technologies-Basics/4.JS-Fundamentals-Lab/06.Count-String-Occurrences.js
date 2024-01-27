function countOccurrences(text, word) {
    let words = text.split(' ');
    let occurrences = 0;
    for (let i = 0; i < words.length; i++) {
        
        if (words[i].toLowerCase() === word.toLowerCase()) {
            occurrences++;
        }
    }

    console.log(occurrences);
}


countOccurrences('This is a word and it also is a sentence', 'is');  
countOccurrences('softuni is great place for learning new programming languages', 'softuni');  
