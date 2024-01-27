function processMovies(input) {
    let movies = [];

    for (let command of input) {
        let tokens = command.split(' ');

        if (tokens[0] === 'addMovie') {
            let movieName = tokens.slice(1).join(' ');
            movies.push({ name: movieName });
        } else {
            let movieIndex = movies.findIndex(movie => movie.name === tokens[0]);

            if (movieIndex !== -1) {
                if (tokens[1] === 'directedBy') {
                    movies[movieIndex].director = tokens.slice(2).join(' ');
                } else if (tokens[1] === 'onDate') {
                    movies[movieIndex].date = tokens.slice(2).join(' ');
                }
            }
        }
    }

    let validMovies = movies.filter(movie => movie.name && movie.director && movie.date);
    validMovies.forEach(movie => console.log(JSON.stringify(movie)));
}




processMovies([
    'addMovie Fast and Furious',
    'addMovie Godfather',
    'Inception directedBy Christopher Nolan',
    'Godfather directedBy Francis Ford Coppola',
    'Godfather onDate 29.07.2018',
    'Fast and Furious onDate 30.07.2018',
    'Batman onDate 01.08.2018',
    'Fast and Furious directedBy Rob Cohen'
]);
processMovies([
    'addMovie The Avengers',
    'addMovie Superman',
    'The Avengers directedBy Anthony Russo',
    'The Avengers onDate 30.07.2010',
    'Captain America onDate 30.07.2010',
    'Captain America directedBy Joe Russo'
]);
