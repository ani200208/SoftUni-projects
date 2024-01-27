function revealWords(words, templates) {
    
    let wordsArray = words.split(', ');
    let templatesArray = templates.split(' ');

    
    for (let i = 0; i < templatesArray.length; i++) {
        if (templatesArray[i].includes('*')) {
            let wordToReplace = wordsArray.find(word => word.length === templatesArray[i].length);
            templatesArray[i] = wordToReplace;
        }
    }

    
    let result = templatesArray.join(' ');

    return result;
}


let example1 = revealWords('great', 'softuni is ***** place for learning new programming languages');
console.log(example1); 

let example2 = revealWords('great, learning', 'softuni is ***** place for ******** new programming languages');
console.log(example2); 
