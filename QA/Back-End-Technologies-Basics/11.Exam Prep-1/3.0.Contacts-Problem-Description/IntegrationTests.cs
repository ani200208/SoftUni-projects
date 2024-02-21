using ContactsConsoleAPI.Business;
using ContactsConsoleAPI.Business.Contracts;
using ContactsConsoleAPI.Data.Models;
using ContactsConsoleAPI.DataAccess;
using ContactsConsoleAPI.DataAccess.Contrackts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsConsoleAPI.IntegrationTests.NUnit
{
    public class IntegrationTests
    {
        private TestContactDbContext dbContext;
        private IContactManager contactManager;

        [SetUp]
        public void SetUp()
        {
            this.dbContext = new TestContactDbContext();
            this.contactManager = new ContactManager(new ContactRepository(this.dbContext));
        }


        [TearDown]
        public void TearDown()
        {
            this.dbContext.Database.EnsureDeleted();
            this.dbContext.Dispose();
        }


        //positive test
        [Test]
        public async Task AddContactAsync_ShouldAddNewContact()
        {
            var newContact = new Contact()
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                Address = "Anything for testing address",
                Contact_ULID = "1ABC23456HH", //must be minimum 10 symbols - numbers or Upper case letters
                Email = "test@gmail.com",
                Gender = "Male",
                Phone = "0889933779"
            };

            await contactManager.AddAsync(newContact);

            var dbContact = await dbContext.Contacts.FirstOrDefaultAsync(c => c.Contact_ULID == newContact.Contact_ULID);

            Assert.NotNull(dbContact);
            Assert.AreEqual(newContact.FirstName, dbContact.FirstName);
            Assert.AreEqual(newContact.LastName, dbContact.LastName);
            Assert.AreEqual(newContact.Phone, dbContact.Phone);
            Assert.AreEqual(newContact.Email, dbContact.Email);
            Assert.AreEqual(newContact.Address, dbContact.Address);
            Assert.AreEqual(newContact.Contact_ULID, dbContact.Contact_ULID);
        }

        //Negative test
        [Test]
        public async Task AddContactAsync_TryToAddContactWithInvalidCredentials_ShouldThrowException()
        {
            var newContact = new Contact()
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                Address = "Anything for testing address",
                Contact_ULID = "1ABC23456HH", //must be minimum 10 symbols - numbers or Upper case letters
                Email = "invalid_Mail", //invalid email
                Gender = "Male",
                Phone = "0889933779"
            };

            var ex = Assert.ThrowsAsync<ValidationException>(async () => await contactManager.AddAsync(newContact));
            var actual = await dbContext.Contacts.FirstOrDefaultAsync(c => c.Contact_ULID == newContact.Contact_ULID);

            Assert.IsNull(actual);
            Assert.That(ex?.Message, Is.EqualTo("Invalid contact!"));

        }

        [Test]
        public async Task DeleteContactAsync_WithValidULID_ShouldRemoveContactFromDb()
        {
            // Arrange
            var newContact = new Contact()
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                Address = "Anything for testing address",
                Contact_ULID = "1ABC23456HH", //must be minimum 10 symbols - numbers or Upper case letters
                Email = "test@gmail.com",
                Gender = "Male",
                Phone = "0889933779"
            };

            await contactManager.AddAsync(newContact);

            // Act

            await contactManager.DeleteAsync(newContact.Contact_ULID);


            // Assert
            var contactInDb = await dbContext.Contacts.FirstOrDefaultAsync(x => x.Contact_ULID == newContact.Contact_ULID);
            Assert.IsNull(contactInDb);

        }

        [TestCase("")]
        [TestCase("   ")]
        [TestCase(null)]
        public async Task DeleteContactAsync_TryToDeleteWithNullOrWhiteSpaceULID_ShouldThrowException(string invalidUlid)
        {

            // Act and Assert
            Assert.ThrowsAsync<ArgumentException>(() => contactManager.DeleteAsync(invalidUlid));
           

        }

        [Test]
        public async Task GetAllAsync_WhenContactsExist_ShouldReturnAllContacts()
        {
            // Arrange
            var newContact = new Contact()
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                Address = "Anything for testing address",
                Contact_ULID = "1ABC23456HH", //must be minimum 10 symbols - numbers or Upper case letters
                Email = "test@gmail.com",
                Gender = "Male",
                Phone = "0889933779"
            };

            var newContact2 = new Contact()
            {
                FirstName = "TestSecondtName",
                LastName = "SecondTestLastName",
                Address = "1Anything for testing address",
                Contact_ULID = "2ABC23456HH", //must be minimum 10 symbols - numbers or Upper case letters
                Email = "test@gmail.com",
                Gender = "Male",
                Phone = "0889933777"
            };
            await contactManager.AddAsync(newContact);
            await contactManager.AddAsync(newContact2);
           

            // Act
            var result = await contactManager.GetAllAsync();

            // Assert
            Assert.That(result.Count, Is.EqualTo(2));

            var firstContact = result.First();
            Assert.That(firstContact.Email, Is.EqualTo(newContact.Email));
            Assert.That(firstContact.Address, Is.EqualTo(newContact.Address));
            Assert.That(firstContact.Contact_ULID, Is.EqualTo(newContact.Contact_ULID));
            Assert.That(firstContact.Gender, Is.EqualTo(newContact.Gender));
            Assert.That(firstContact.Phone, Is.EqualTo(newContact.Phone));
            Assert.That(firstContact.FirstName, Is.EqualTo(newContact.FirstName));
            Assert.That(firstContact.LastName, Is.EqualTo(newContact.LastName));


        }

        [Test]
        public async Task GetAllAsync_WhenNoContactsExist_ShouldThrowKeyNotFoundException()
        {
            // Arrange

            // Act
            var exception = Assert.ThrowsAsync<KeyNotFoundException>(() => contactManager.GetAllAsync());

            // Assert
            Assert.That(exception.Message, Is.EqualTo("No contact found."));
        }

        [Test]
        public async Task SearchByFirstNameAsync_WithExistingFirstName_ShouldReturnMatchingContacts()
        {
            // Arrange
            var newContact = new Contact()
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                Address = "Anything for testing address",
                Contact_ULID = "1ABC23456HH", //must be minimum 10 symbols - numbers or Upper case letters
                Email = "test@gmail.com",
                Gender = "Male",
                Phone = "0889933779"
            };

            var newContact2 = new Contact()
            {
                FirstName = "TestSecondtName",
                LastName = "SecondTestLastName",
                Address = "1Anything for testing address",
                Contact_ULID = "2ABC23456HH", //must be minimum 10 symbols - numbers or Upper case letters
                Email = "test@gmail.com",
                Gender = "Male",
                Phone = "0889933777"
            };
            await contactManager.AddAsync(newContact);
            await contactManager.AddAsync(newContact2);


            // Act
            var result = await contactManager.SearchByFirstNameAsync(newContact2.FirstName);


            // Assert
            Assert.That(result.Count(),Is.EqualTo(1));
            var itemInTheDb = result.First();
            Assert.That(itemInTheDb.FirstName, Is.EqualTo(newContact2.FirstName));
            Assert.That(itemInTheDb.LastName, Is.EqualTo(newContact2.LastName));
            Assert.That(itemInTheDb.Address, Is.EqualTo(newContact2.Address));
            Assert.That(itemInTheDb.Contact_ULID, Is.EqualTo(newContact2.Contact_ULID));
            Assert.That(itemInTheDb.Email, Is.EqualTo(newContact2.Email));
            Assert.That(itemInTheDb.Gender, Is.EqualTo(newContact2.Gender));
            Assert.That(itemInTheDb.Phone, Is.EqualTo(newContact2.Phone));
        }

        [Test]
        public async Task SearchByFirstNameAsync_WithNonExistingFirstName_ShouldThrowKeyNotFoundException()
        {
            // Arrange

            // Act
            var exception = Assert.ThrowsAsync<KeyNotFoundException>(() => contactManager.SearchByFirstNameAsync("NO_SUCH_KEY"));

            // Assert
            Assert.That(exception.Message, Is.EqualTo("No contact found with the given first name."));
        }

        [Test]
        public async Task SearchByLastNameAsync_WithExistingLastName_ShouldReturnMatchingContacts()
        {
            // Arrange
            var newContact = new Contact()
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                Address = "Anything for testing address",
                Contact_ULID = "1ABC23456HH", //must be minimum 10 symbols - numbers or Upper case letters
                Email = "test@gmail.com",
                Gender = "Male",
                Phone = "0889933779"
            };

            var newContact2 = new Contact()
            {
                FirstName = "TestSecondtName",
                LastName = "SecondTestLastName",
                Address = "1Anything for testing address",
                Contact_ULID = "2ABC23456HH", //must be minimum 10 symbols - numbers or Upper case letters
                Email = "test@gmail.com",
                Gender = "Male",
                Phone = "0889933777"
            };

            await contactManager.AddAsync(newContact);
            await contactManager.AddAsync(newContact2);

            // Act
            var result = await contactManager.SearchByLastNameAsync(newContact.LastName);

            // Assert
            Assert.That(result.Count(), Is.EqualTo(1));
            var itemInDB = result.First();
            Assert.That(itemInDB.FirstName, Is.EqualTo(newContact.FirstName));
        }

        [Test]
        public async Task SearchByLastNameAsync_WithNonExistingLastName_ShouldThrowKeyNotFoundException()
        {
            // Arrange

            // Act
            var exception = Assert.ThrowsAsync<KeyNotFoundException>(() => contactManager.SearchByLastNameAsync("NON_EXISTING_NAME"));

            // Assert
            Assert.That(exception.Message, Is.EqualTo("No contact found with the given last name."));
        }

        [Test]
        public async Task GetSpecificAsync_WithValidULID_ShouldReturnContact()
        {
            // Arrange
            var newContact = new Contact()
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                Address = "Anything for testing address",
                Contact_ULID = "1ABC23456HH", //must be minimum 10 symbols - numbers or Upper case letters
                Email = "test@gmail.com",
                Gender = "Male",
                Phone = "0889933779"
            };

            var newContact2 = new Contact()
            {
                FirstName = "TestSecondtName",
                LastName = "SecondTestLastName",
                Address = "1Anything for testing address",
                Contact_ULID = "2ABC23456HH", //must be minimum 10 symbols - numbers or Upper case letters
                Email = "test@gmail.com",
                Gender = "Male",
                Phone = "0889933777"
            };

            await contactManager.AddAsync(newContact);
            await contactManager.AddAsync(newContact2);

            // Act
            var result = await contactManager.GetSpecificAsync(newContact.Contact_ULID);

            // Assert
            Assert.NotNull(result);
            Assert.That(result.FirstName, Is.EqualTo(newContact.FirstName));
            Assert.That(result.LastName, Is.EqualTo(newContact.LastName));
            Assert.That(result.Address, Is.EqualTo(newContact.Address));
            Assert.That(result.Contact_ULID, Is.EqualTo(newContact.Contact_ULID));
            Assert.That(result.Email, Is.EqualTo(newContact.Email));
            Assert.That(result.Gender, Is.EqualTo(newContact.Gender));
            Assert.That(result.Phone, Is.EqualTo(newContact.Phone));

        }

        [Test]
        public async Task GetSpecificAsync_WithInvalidULID_ShouldThrowKeyNotFoundException()
        {
            // Arrange

            // Act
            const string invalidUlid = "NON_VALID_ID";
            var exception = Assert.ThrowsAsync<KeyNotFoundException>(() => contactManager.GetSpecificAsync(invalidUlid));

            // Assert
            Assert.That(exception.Message, Is.EqualTo($"No contact found with ULID: {invalidUlid}"));
            Assert.NotNull(exception);
        }

        [Test]
        public async Task UpdateAsync_WithValidContact_ShouldUpdateContact()
        {
            // Arrange
            var newContact = new Contact()
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                Address = "Anything for testing address",
                Contact_ULID = "1ABC23456HH", //must be minimum 10 symbols - numbers or Upper case letters
                Email = "test@gmail.com",
                Gender = "Male",
                Phone = "0889933779"
            };

            var newContact2 = new Contact()
            {
                FirstName = "TestSecondtName",
                LastName = "SecondTestLastName",
                Address = "1Anything for testing address",
                Contact_ULID = "2ABC23456HH", //must be minimum 10 symbols - numbers or Upper case letters
                Email = "test@gmail.com",
                Gender = "Male",
                Phone = "0889933777"
            };

            await contactManager.AddAsync(newContact);
            await contactManager.AddAsync(newContact2);
            var modifiedContact = newContact;
            modifiedContact.FirstName = "UPDATED!";

            // Act
            await contactManager.UpdateAsync(modifiedContact);
            // Assert
            var itemInDb = await dbContext.Contacts.FirstOrDefaultAsync(x => x.Contact_ULID == modifiedContact.Contact_ULID);

            Assert.NotNull(itemInDb);
            Assert.That(itemInDb.FirstName, Is.EqualTo(modifiedContact.FirstName));
            Assert.That(itemInDb.LastName, Is.EqualTo(modifiedContact.LastName));
            Assert.That(itemInDb.Address, Is.EqualTo(modifiedContact.Address));
            Assert.That(itemInDb.Contact_ULID, Is.EqualTo(modifiedContact.Contact_ULID));
            Assert.That(itemInDb.Email, Is.EqualTo(modifiedContact.Email));
            Assert.That(itemInDb.Gender, Is.EqualTo(modifiedContact.Gender));
            Assert.That(itemInDb.Phone, Is.EqualTo(modifiedContact.Phone));
        }

        [Test]
        public async Task UpdateAsync_WithInvalidContact_ShouldThrowValidationException()
        {
            // Arrange

            // Act
            var exception = Assert.ThrowsAsync<ValidationException>(() => contactManager.UpdateAsync(new Contact()));

            // Assert
            Assert.That(exception.Message, Is.EqualTo("Invalid contact!"));
        }
    }
}
