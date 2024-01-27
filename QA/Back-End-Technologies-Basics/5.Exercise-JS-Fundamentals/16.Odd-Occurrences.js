function extractOddOccurrences(input) {
    let words = input.toLowerCase().split(' ');

    let occurrences = {};
    for (let word of words) {
        occurrences[word] = (occurrences[word] || 0) + 1;
    }

    let result = [];
    for (let word in occurrences) {
        if (occurrences[word] % 2 !== 0) {
            result.push(word);
        }
    }

    console.log(result.join(' '));
}



extractOddOccurrences('Java C# Php PHP Java PhP 3 C# 3 1 5 C#');
extractOddOccurrences('Cake IS SWEET is Soft CAKE sweet Food');
