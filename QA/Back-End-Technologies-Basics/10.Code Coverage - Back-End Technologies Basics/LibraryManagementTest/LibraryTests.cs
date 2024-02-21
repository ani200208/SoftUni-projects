using LibraryManagementSystem;

namespace LibraryManagementTest;

    [TestFixture]
    public class LibraryTests
    {
        [Test]
        public void AddBook_ShouldAddNewBookToTheLibrary()
        
        {
            //Arrange
             Library library = new Library();
             var newBook = new Book
             {
                 Author = "Ivan",
                 Id = 1,
                 IsCheckedOut = false,
                 Title = "Title",
             };
            //Act
           library.AddBook(newBook);
           //Assert
           var allBooks = library.GetAllBooks();
           Assert.That(allBooks.Count(), Is.EqualTo(1));
           
           var singleBook = allBooks.First();
           Assert.That(singleBook.Id, Is .EqualTo(newBook.Id));
           Assert.That(singleBook.Author, Is.EqualTo(newBook.Author));
           Assert.That(singleBook.IsCheckedOut, Is.EqualTo(newBook.IsCheckedOut));
           Assert.That(singleBook.Title, Is.EqualTo(newBook.Title));





        }

        [Test]
       public void CheckOutBook_ShouldReturFalse_IfBookDoesNotExist()
       {
        //Arange

        Library library = new Library();
        var newBook = new Book
        {
            Author = "An hat",
            Id = 1,
            IsCheckedOut = false,
            Title = "Title",

        };

        //Act

        var result = library.CheckOutBook(999);

        //Assert

        Assert.IsFalse(result);
       }



       [Test]
       public void CheckOutBook_ShouldReturnFalse_IfBookIsAlreadyCheckedOut()
       {
        //Arange

        Library library = new Library();
        var newBook = new Book
        {
            Author = "Ani Mari",
            Id = 1,
            IsCheckedOut = true,
            Title = "Title",
           
        };

        //Act

        var result = library.CheckOutBook(newBook.Id);

        //Assert

        Assert.IsFalse(result);
       }




    [Test]
       public void CheckOutBook_ShouldReturnTrue_IfWeCanCheckoutTheBook()
       {
        //Arange

        Library library = new Library();
        var newBook = new Book
        {
            Author = "Ani Mari",
            Id = 1,
            IsCheckedOut = false,
            Title = "Title",

        };


        library.AddBook(newBook);
        //Act

        var result = library.CheckOutBook(newBook.Id);

        //Assert

        Assert.IsTrue(result);
        var allBooks = library.GetAllBooks();
        var singleBook = allBooks.First();
        Assert.IsTrue(singleBook.IsCheckedOut);
       }

    [Test]
       public void ReturnBook_ShouldReturnFalse_IfBookDoesNotExist()
       {
        //Arange
        var library = new Library();
        var newBook = new Book
        {
            Author = "An hat",
            Id = 1,
            IsCheckedOut = false,
            Title = "Title",

        };

        //Act
        var result = library.ReturnBook(999);

        //Assert
        Assert.IsFalse(result);

       }


    [Test]
       public void ReturnBook_ShouldReturnFalse_IfBookIsNotCheckedOut()
       {
        //Arange
        var library = new Library();
        var newBook = new Book
        {
            Author = "An hat",
            Id = 1,
            IsCheckedOut = false,
            Title = "Title",

        };


        library.AddBook(newBook);


        //Act
        var result = library.ReturnBook(1);

        //Assert
        Assert.IsFalse(result);
       }




    [Test]
      public void ReturnBook_ShouldReturnTrue_IfBookCanBeCheckedOut()
      {
        {
            //Arange
            var library = new Library();
            var newBook = new Book
            {
                Author = "An hat",
                Id = 1,
                IsCheckedOut = true,
                Title = "Title",

            };


            library.AddBook(newBook);


            //Act
            var result = library.ReturnBook(1);

            //Assert
            Assert.IsTrue(result);
            var allBooks = library.GetAllBooks();
            var singleBook = allBooks.First();
            Assert.IsFalse(singleBook.IsCheckedOut);
        }
      }
    }
