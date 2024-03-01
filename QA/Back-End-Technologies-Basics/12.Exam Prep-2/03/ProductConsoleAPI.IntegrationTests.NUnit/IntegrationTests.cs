using Microsoft.EntityFrameworkCore;
using ProductConsoleAPI.Business;
using ProductConsoleAPI.Business.Contracts;
using ProductConsoleAPI.Data.Models;
using ProductConsoleAPI.DataAccess;
using System.ComponentModel.DataAnnotations;

namespace ProductConsoleAPI.IntegrationTests.NUnit
{
    public  class IntegrationTests
    {
        private TestProductsDbContext dbContext;
        private IProductsManager productsManager;

        [SetUp]
        public void SetUp()
        {
            this.dbContext = new TestProductsDbContext();
            this.productsManager = new ProductsManager(new ProductsRepository(this.dbContext));
        }


        [TearDown]
        public void TearDown()
        {
            this.dbContext.Database.EnsureDeleted();
            this.dbContext.Dispose();
        }


        //positive test
        [Test]
        public async Task AddProductAsync_ShouldAddNewProduct()
        {
            var newProduct = new Product()
            {
                OriginCountry = "Bulgaria",
                ProductName = "TestProduct",
                ProductCode = "AB12C",
                Price = 1.25m,
                Quantity = 100,
                Description = "Anything for description"
            };

            await productsManager.AddAsync(newProduct);

            var dbProduct = await this.dbContext.Products.FirstOrDefaultAsync(p => p.ProductCode == newProduct.ProductCode);

            Assert.NotNull(dbProduct);
            Assert.AreEqual(newProduct.ProductName, dbProduct.ProductName);
            Assert.AreEqual(newProduct.Description, dbProduct.Description);
            Assert.AreEqual(newProduct.Price, dbProduct.Price);
            Assert.AreEqual(newProduct.Quantity, dbProduct.Quantity);
            Assert.AreEqual(newProduct.OriginCountry, dbProduct.OriginCountry);
            Assert.AreEqual(newProduct.ProductCode, dbProduct.ProductCode);
        }

        //Negative test
        [Test]
        public async Task AddProductAsync_TryToAddProductWithInvalidCredentials_ShouldThrowException()
        {
            var newProduct = new Product()
            {
                OriginCountry = "Bulgaria",
                ProductName = "TestProduct",
                ProductCode = "AB12C",
                Price = -1m,
                Quantity = 100,
                Description = "Anything for description"
            };

            var exception = Assert.ThrowsAsync<ValidationException>(async () => await productsManager.AddAsync(newProduct));
            var actual = await dbContext.Products.FirstOrDefaultAsync(c => c.ProductCode == newProduct.ProductCode);

            Assert.IsNull(actual);
            Assert.That(exception.Message, Is.EqualTo("Invalid product!"));

        }

        [Test]
        public async Task DeleteProductAsync_WithValidProductCode_ShouldRemoveProductFromDb()
        {
            // Arrange
            var newProduct = new Product()
            {
                OriginCountry = "Bulgaria",
                ProductName = "TestProduct",
                ProductCode = "AB12C",
                Price = 1.25m,
                Quantity = 100,
                Description = "Anything for description"
            };

            await productsManager.AddAsync(newProduct);

            // Act
            await productsManager.DeleteAsync(newProduct.ProductCode);

            // Assert
            var productInTheDb = await dbContext.Products.FirstOrDefaultAsync(x =>x.ProductCode == newProduct.ProductCode);
            Assert.IsNull(productInTheDb);
        }

        [Test]
        [TestCase (null)]
        [TestCase("")]
        [TestCase("    ")]
        public async Task DeleteProductAsync_TryToDeleteWithNullOrWhiteSpaceProductCode_ShouldThrowException(string invalidCode)
        {
            

            // Act
            var exception = Assert.ThrowsAsync<ArgumentException>(() => productsManager.DeleteAsync(invalidCode));

            // Assert
            Assert.That(exception.Message, Is.EqualTo("Product code cannot be empty."));
        }

        [Test]
        public async Task GetAllAsync_WhenProductsExist_ShouldReturnAllProducts()
        {
            // Arrange
            var firstProduct = new Product()
            {
                OriginCountry = "Bulgaria",
                ProductName = "TestProduct",
                ProductCode = "AB12C",
                Price = 2m,
                Quantity = 100,
                Description = "Anything for description"
            };
            
            var secondtProduct = new Product()
            {
                OriginCountry = "Germany",
                ProductName = "TestProduct second",
                ProductCode = "BA12C",
                Price = 5m,
                Quantity = 100,
                Description = "Anything for description"
            };
            await productsManager.AddAsync(firstProduct);
            await productsManager.AddAsync(secondtProduct);

            // Act
            var result = await productsManager.GetAllAsync();

            // Assert
            Assert.That(result.Count, Is.EqualTo(2));
             
            var firstItem = result.FirstOrDefault(x => x.ProductCode == firstProduct.ProductCode);
            Assert.NotNull(firstItem);
            Assert.AreEqual(firstItem.ProductName, firstProduct.ProductName);
            Assert.AreEqual(firstItem.Description, firstProduct.Description);
            Assert.AreEqual(firstItem.Price, firstProduct.Price);
            Assert.AreEqual(firstItem.Quantity, firstProduct.Quantity);
            Assert.AreEqual(firstItem.OriginCountry, firstProduct.OriginCountry);
            Assert.AreEqual(firstItem.ProductCode, firstProduct.ProductCode);

            var secondItem = result.FirstOrDefault(x => x.ProductName == secondtProduct.ProductName);
            Assert.NotNull (secondItem);

            Assert.NotNull(secondItem);
            Assert.AreEqual(secondItem.ProductName, secondtProduct.ProductName);
            Assert.AreEqual(secondItem.Description, secondtProduct.Description);
            Assert.AreEqual(secondItem.Price, secondtProduct.Price);
            Assert.AreEqual(secondItem.Quantity, secondtProduct.Quantity);
            Assert.AreEqual(secondItem.OriginCountry, secondtProduct.OriginCountry);
            Assert.AreEqual(secondItem.ProductCode, secondtProduct.ProductCode);

        }

        [Test]
        public async Task GetAllAsync_WhenNoProductsExist_ShouldThrowKeyNotFoundException()
        {
            

            // Act
            var exception = Assert.ThrowsAsync<KeyNotFoundException>(() => productsManager.GetAllAsync());

            // Assert
            Assert.That(exception.Message, Is.EqualTo("No product found."));
        }

        [Test]
        public async Task SearchByOriginCountry_WithExistingOriginCountry_ShouldReturnMatchingProducts()
        {
            // Arrange
            var firstProduct = new Product()
            {
                OriginCountry = "Bulgaria",
                ProductName = "TestProduct",
                ProductCode = "AB12C",
                Price = 2m,
                Quantity = 100,
                Description = "Anything for description"
            };

            var secondtProduct = new Product()
            {
                OriginCountry = "Germany",
                ProductName = "TestProduct second",
                ProductCode = "BA12C",
                Price = 5m,
                Quantity = 100,
                Description = "Anything for description"
            };
            await productsManager.AddAsync(firstProduct);
            await productsManager.AddAsync(secondtProduct);

            // Act
             var result = await productsManager.SearchByOriginCountry(firstProduct.OriginCountry);

            // Assert
            Assert.That(result.Count(),Is.EqualTo(1));
            var resultProduct = result.First();

            
            Assert.That(resultProduct.ProductName,Is.EqualTo (firstProduct.ProductName));
            Assert.That(resultProduct.Description, Is.EqualTo (firstProduct.Description));
            Assert.That(resultProduct.Price, Is.EqualTo (firstProduct.Price));
            Assert.That(resultProduct.Quantity, Is.EqualTo (firstProduct.Quantity));
            Assert.That(resultProduct.OriginCountry, Is.EqualTo (firstProduct.OriginCountry));
            Assert.That(resultProduct.ProductCode, Is.EqualTo (firstProduct.ProductCode));
        }

        [Test]
        public async Task SearchByOriginCountryAsync_WithNonExistingOriginCountry_ShouldThrowKeyNotFoundException()
        {
            

            // Act
            var exception = Assert.ThrowsAsync<KeyNotFoundException>(() => productsManager.SearchByOriginCountry("NON_EXISTING_COUNTRY"));

            // Assert
            Assert.That(exception.Message, Is.EqualTo("No product found with the given country of origin."));
        }

        [TestCase("")]
        [TestCase(null)]
        [TestCase("   ")]
        public async Task SearchByOriginCountryAsync_WithInvalidOriginCountry_ShouldThrowArgumentException(string invalidCountryName)
        {


            // Act
            var exception = Assert.ThrowsAsync<ArgumentException>(() => productsManager.SearchByOriginCountry(invalidCountryName));

            // Assert
            Assert.That(exception.Message, Is.EqualTo("Country name cannot be empty."));
        }

        [Test]
        public async Task GetSpecificAsync_WithValidProductCode_ShouldReturnProduct()
        {
            // Arrange
            var firstProduct = new Product()
            {
                OriginCountry = "Bulgaria",
                ProductName = "TestProduct",
                ProductCode = "AB12C",
                Price = 2m,
                Quantity = 100,
                Description = "Anything for description"
            };

            var secondtProduct = new Product()
            {
                OriginCountry = "Germany",
                ProductName = "TestProduct second",
                ProductCode = "BA12C",
                Price = 5m,
                Quantity = 100,
                Description = "Anything for description"
            };
            await productsManager.AddAsync(firstProduct);
            await productsManager.AddAsync(secondtProduct);


            // Act
            var result = await productsManager.GetSpecificAsync(secondtProduct.ProductCode);

            // Assert
            Assert.NotNull(result);

            Assert.That(result.ProductName, Is.EqualTo(secondtProduct.ProductName));
            Assert.That(result.Description, Is.EqualTo(secondtProduct.Description));
            Assert.That(result.Price, Is.EqualTo(secondtProduct.Price));
            Assert.That(result.Quantity, Is.EqualTo(secondtProduct.Quantity));
            Assert.That(result.OriginCountry, Is.EqualTo(secondtProduct.OriginCountry));
            Assert.That(result.ProductCode, Is.EqualTo(secondtProduct.ProductCode));
        }

        [Test]
        public async Task GetSpecificAsync_WithInvalidProductCode_ShouldThrowKeyNotFoundException()
        {
            // Arrange
            const string invalidProductCode = "NON_VALID_CODE";

            // Act
            var exception = Assert.ThrowsAsync<KeyNotFoundException>(() => productsManager.GetSpecificAsync(invalidProductCode));

            // Assert
            Assert.That(exception.Message, Is.EqualTo($"No product found with product code: {invalidProductCode}"));
        }

        [Test]
        public async Task UpdateAsync_WithValidProduct_ShouldUpdateProduct()
        {
            // Arrange
            var firstProduct = new Product()
            {
                OriginCountry = "Bulgaria",
                ProductName = "TestProduct",
                ProductCode = "AB12C",
                Price = 2m,
                Quantity = 100,
                Description = "Anything for description"
            };

            var secondtProduct = new Product()
            {
                OriginCountry = "Germany",
                ProductName = "TestProduct second",
                ProductCode = "BA12C",
                Price = 5m,
                Quantity = 100,
                Description = "Anything for description"
            };
            await productsManager.AddAsync(firstProduct);
            await productsManager.AddAsync(secondtProduct);

            // Act
            firstProduct.ProductName = "UPDATED NAME!";
            await productsManager.UpdateAsync(firstProduct);

            // Assert
            var productInTheDB = await productsManager.GetSpecificAsync(firstProduct.ProductCode);


            Assert.NotNull(productInTheDB);
            Assert.That(productInTheDB.ProductName, Is.EqualTo(firstProduct.ProductName));
            Assert.That(productInTheDB.Description, Is.EqualTo(firstProduct.Description));
            Assert.That(productInTheDB.Price, Is.EqualTo(firstProduct.Price));
            Assert.That(productInTheDB.Quantity, Is.EqualTo(firstProduct.Quantity));
            Assert.That(productInTheDB.OriginCountry, Is.EqualTo(firstProduct.OriginCountry));
            Assert.That(productInTheDB.ProductCode, Is.EqualTo(firstProduct.ProductCode));
        }

        [Test]
        public async Task UpdateAsync_WithInvalidProduct_ShouldThrowValidationException()
        {
            // Arrange
            var InvalidProduct = new Product()
            {
                OriginCountry = "Germany",
                ProductName = "TestProduct second",
                ProductCode = "BA12C",
                Price = -5m,
                Quantity = 100,
                Description = "Anything for description"
            };

            // Act
            var exception = Assert.ThrowsAsync<ValidationException>(() => productsManager.UpdateAsync(InvalidProduct));

            // Assert
            Assert.That(exception.Message, Is.EqualTo("Invalid product!"));
        }
        [Test]
        public async Task UpdateAsync_WithNullProduct_ShouldThrowValidationException()
        {
            // Arrange
            var InvalidProduct = new Product()
            {
                OriginCountry = "Germany",
                ProductName = "TestProduct second",
                ProductCode = "BA12C",
                Price = -5m,
                Quantity = 100,
                Description = "Anything for description"
            };

            // Act
            var exception = Assert.ThrowsAsync<ValidationException>(() => productsManager.UpdateAsync(null));

            // Assert
            Assert.That(exception.Message, Is.EqualTo("Invalid product!"));
        }
    }
}
