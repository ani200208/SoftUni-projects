function findWord(word, text) {
    let lowerCaseWord = word.toLowerCase();
    let lowerCaseText = text.toLowerCase();

    let wordsInText = lowerCaseText.split(/\W+/); 

    if (wordsInText.includes(lowerCaseWord)) {
        console.log(word);
    } else {
        console.log(`${word} not found!`);
    }
}


findWord('javascript', 'JavaScript is the best programming language');
findWord('python', 'JavaScript is the best programming language');
