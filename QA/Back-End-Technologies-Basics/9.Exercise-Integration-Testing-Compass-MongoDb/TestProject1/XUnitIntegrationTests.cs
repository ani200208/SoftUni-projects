using MongoDB.Driver;
using MoviesLibraryAPI.Controllers;
using MoviesLibraryAPI.Controllers.Contracts;
using MoviesLibraryAPI.Data.Models;
using MoviesLibraryAPI.Services;
using MoviesLibraryAPI.Services.Contracts;
using System.ComponentModel.DataAnnotations;

namespace MoviesLibraryAPI.XUnitTests
{
    public class XUnitIntegrationTests : IClassFixture<DatabaseFixture>
    {
        private readonly MoviesLibraryXUnitTestDbContext _dbContext;
        private readonly IMoviesLibraryController _controller;
        private readonly IMoviesRepository _repository;

        public XUnitIntegrationTests(DatabaseFixture fixture)
        {
            _dbContext = fixture.DbContext;
            _repository = new MoviesRepository(_dbContext.Movies);
            _controller = new MoviesLibraryController(_repository);

            InitializeDatabaseAsync().GetAwaiter().GetResult();
        }

        private async Task InitializeDatabaseAsync()
        {
            await _dbContext.ClearDatabaseAsync();
        }

        [Fact]
        public async Task AddMovieAsync_WhenValidMovieProvided_ShouldAddToDatabase()
        {
            // Arrange
            var movie = new Movie
            {
                Title = "Test Movie",
                Director = "Test Director",
                YearReleased = 2022,
                Genre = "Action",
                Duration = 120,
                Rating = 7.5
            };

            // Act
            await _controller.AddAsync(movie);

            // Assert
            var resultMovie = await _dbContext.Movies.Find(m => m.Title == "Test Movie").FirstOrDefaultAsync();
           Assert.NotNull(resultMovie);
            Assert.Equal("Test Movie", resultMovie.Title);
            Assert.Equal("Test Director", resultMovie.Director);
            Assert.Equal(2022, resultMovie.YearReleased);
            Assert.Equal("Action", resultMovie.Genre);
            Assert.Equal(120, resultMovie.Duration);
            Assert.Equal(7.5, resultMovie.Rating);
        }

        [Fact]
        public async Task AddMovieAsync_WhenInvalidMovieProvided_ShouldThrowValidationException()
        {
            // Arrange
            var invalidMovie = new Movie
            {
                YearReleased = 2022,
                Genre = "Action",
                Duration = 120,
                Rating = 7.5
            };

            // Act and Assert
            var exception = await Assert.ThrowsAsync<ValidationException>(() => _controller.AddAsync(invalidMovie));  
            Assert.Equal("Movie is not valid." , exception.Message);
        }

        [Fact]
        public async Task DeleteAsync_WhenValidTitleProvided_ShouldDeleteMovie()
        {
            // Arrange            
            var movie = new Movie
            {
                Title = "Fast and Furious",
                Director = "me",
                YearReleased = 2002,
                Genre = "Action",
                Duration = 160,
                Rating = 10
            };


            await _controller.AddAsync(movie);
            // Act
            await _controller.DeleteAsync(movie.Title);

            // Assert
            // The movie should no longer exist in the database
            var resultMovie = await _dbContext.Movies.Find(m => m.Title == movie.Title).FirstOrDefaultAsync();
            Assert.Null(resultMovie);
        }


        [Fact]
        public async Task DeleteAsync_WhenTitleIsNull_ShouldThrowArgumentException()
        {
            // Act and Assert
        }

        [Fact]
        public async Task DeleteAsync_WhenTitleIsEmpty_ShouldThrowArgumentException()
        {
            // Act and Assert            
        }

        [Fact]
        public async Task DeleteAsync_WhenTitleDoesNotExist_ShouldThrowInvalidOperationException()
        {
            // Act and Assert            
        }

        [Fact]
        public async Task GetAllAsync_WhenNoMoviesExist_ShouldReturnEmptyList()
        {
            // Act
            var result = await _controller.GetAllAsync();

            // Assert
        }

        [Fact]
        public async Task GetAllAsync_WhenMoviesExist_ShouldReturnAllMovies()
        {
            // Arrange
            var firstmovie = new Movie
            {
                Title = "Test",
                Director = "Test Director",
                YearReleased = 2022,
                Genre = "Action",
                Duration = 86,
                Rating = 7.5
            };


            var therdMovie = new Movie
            {
                Title = "Fast ",
                Director = "me",
                YearReleased = 2002,
                Genre = "Action",
                Duration = 160,
                Rating = 10
            };


            await _dbContext.Movies.InsertManyAsync(new[] { firstmovie, therdMovie });

            // Act
            var result = await _controller.GetAllAsync();   

            // Assert
            // Ensure that all movies are returned
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetByTitle_WhenTitleExists_ShouldReturnMatchingMovie()
        {
            // Arrange
            var firstmovie = new Movie
            {
                Title = "Test",
                Director = "Test Director",
                YearReleased = 2022,
                Genre = "Action",
                Duration = 86,
                Rating = 7.5
            };


            var therdMovie = new Movie
            {
                Title = "Fast ",
                Director = "me",
                YearReleased = 2002,
                Genre = "Action",
                Duration = 160,
                Rating = 10
            };


            await _dbContext.Movies.InsertManyAsync(new[] { firstmovie, therdMovie });

            // Act
            var result = await _controller.GetByTitle(firstmovie.Title);


            // Assert
            Assert.NotNull(result);
            Assert.Equal(firstmovie.Director, result.Director);
        }

        [Fact]
        public async Task GetByTitle_WhenTitleDoesNotExist_ShouldReturnNull()
        {
            // Act
            var result = await _controller.GetByTitle("Non Existing Title");


            // Assert
            Assert.Null(result);
        }


        [Fact]
        public async Task SearchByTitleFragmentAsync_WhenTitleFragmentExists_ShouldReturnMatchingMovies()
        {
            // Arrange
            var firstmovie = new Movie
            {
                Title = "Test drun",
                Director = "Test Director",
                YearReleased = 2022,
                Genre = "Action",
                Duration = 86,
                Rating = 7.5
            };


            var therdMovie = new Movie
            {
                Title = "Fast and me ",
                Director = "me",
                YearReleased = 2002,
                Genre = "Action",
                Duration = 160,
                Rating = 10
            };


            await _dbContext.Movies.InsertManyAsync(new[] { firstmovie, therdMovie });


            // Act
            var result = await _controller.SearchByTitleFragmentAsync("Fast");

            // Assert // Should return one matching movie
            Assert.Equal(1, result.Count());
            var movieResult = result.First();
            Assert.Equal(therdMovie.Title, movieResult.Title);
            Assert.Equal(therdMovie.Director, movieResult.Director);
            Assert.Equal(therdMovie.Genre, movieResult.Genre);
            Assert.Equal(therdMovie.Duration, movieResult.Duration);
            Assert.Equal(therdMovie.Rating, movieResult.Rating);
            Assert.Equal(therdMovie.YearReleased, movieResult.YearReleased);
                
        }

        [Fact]
        public async Task SearchByTitleFragmentAsync_WhenNoMatchingTitleFragment_ShouldThrowKeyNotFoundException()
        {
            // Act and Assert
            Assert.ThrowsAsync<KeyNotFoundException>(() => _controller.SearchByTitleFragmentAsync("NoExistingFragment"));
        }

        [Fact]
        public async Task UpdateAsync_WhenValidMovieProvided_ShouldUpdateMovie()
        {
            // Arrange
            var firstmovie = new Movie
            {
                Title = "Test drun drun",
                Director = "Test Director",
                YearReleased = 2022,
                Genre = "Action",
                Duration = 86,
                Rating = 7.5
            };


            var secondmovie = new Movie
            {
                Title = "Fast and me and her",
                Director = "me",
                YearReleased = 2002,
                Genre = "Action",
                Duration = 160,
                Rating = 10
            };
            await _dbContext.Movies.InsertManyAsync(new[] { firstmovie, secondmovie });


            // Modify the movie
            var movieToUpdate = await _dbContext.Movies.Find(x => x.Title == firstmovie.Title).FirstOrDefaultAsync();

            movieToUpdate.Title =" Test drun drun UPDATED";
            movieToUpdate.Rating = 8;

            // Act
            await _controller.UpdateAsync(movieToUpdate);


            // Assert
            var updatedMovie = await _dbContext.Movies.Find(x => x.Title == movieToUpdate.Title).FirstOrDefaultAsync();
            Assert.NotNull(updatedMovie);
            Assert.Equal(movieToUpdate.Rating, updatedMovie.Rating);
        }

        [Fact]
        public async Task UpdateAsync_WhenInvalidMovieProvided_ShouldThrowValidationException()
        {
            // Arrange
            // Movie without required fields
            var invalidMovie = new Movie
            {
                Rating = 10,
            };
            

           

            // Act and Assert
            Assert.ThrowsAsync<ValidationException> (() => _controller.UpdateAsync(invalidMovie));
        }
    }
}
