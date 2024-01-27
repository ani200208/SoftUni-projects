function solve(text, word) {
    function repeat(str, n) {
        return new Array(n + 1).join(str);
    }

    let repeatCount = word.length;
    let censored = text.split(word).join(repeat('*', repeatCount));

    console.log(censored);
}

solve('A small sentence with some words', 'small');
solve('Find the hidden word', 'hidden');
