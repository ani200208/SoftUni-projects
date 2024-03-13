using RestSharp;
using System.Diagnostics.Tracing;


namespace Eventme.Tests
{
    public class Tests
    {
        private RestClient _client;
        private string _baseURL = "https://localhost:7236/";


        [SetUp]
        public void Setup()
        {
            _client = new RestClient(_baseURL);
        }

        [Test]
        public async Task GetAllEvents_ReturnsSuccessStatusCode()
        {
            //Arrange
            var request = new RestRequest("/Event/All", Method.Get);


            //act

            var response = await _client.ExecuteAsync(request);


            //assert

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public async Task Add_GetRequest_ReturnsAddView()
        {
            //Arrange
            var request = new RestRequest("/Event/Add", Method.Get);


            //act

            var response = await _client.ExecuteAsync(request);


            //assert

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public async Task Add_PostRequest_AddsNewEventAndRedirects()
        {
            //Arrange
            var input = new EventAndRedirects()
            {
                NamedParameter = "Soft Uni Conf",
                Place = "Soft Uni",
                Start = new DateTime(2024, 12, 12, 12, 0, 0),
                End = new DateTime(2024, 12, 12, 16, 0, 0)

            };

            var request = new RestRequest("/Event/Add", Method.Post);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");


            request.AddParameter("Name", input.NamedParameter);
            request.AddParameter("Place", input.Place);
            request.AddParameter("Start", input.Start.ToString("MM/dd/yyyyhh:mm tt"));
            request.AddParameter("End", input.End.ToString("MM/dd/yyyyhh:mm tt"));
            //act

            var response = await _client.ExecuteAsync(request);

            //assert

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public async Task Add_PostRequest_RedirectIfDataIsInvalid()
        {
            //Arrange
            var input = new EventAndRedirects()
            {
                NamedParameter = "",
                Place = "",
                Start = new DateTime(2024, 12, 12, 12, 0, 0),
                End = new DateTime(2024, 12, 12, 16, 0, 0)

            };

            var request = new RestRequest("/Event/Add", Method.Post);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");


            request.AddParameter("Name", input.NamedParameter);
            request.AddParameter("Place", input.Place);
            request.AddParameter("Start", input.Start.ToString("MM/dd/yyyyhh:mm tt"));
            request.AddParameter("End", input.End.ToString("MM/dd/yyyyhh:mm tt"));
            //act

            var response = await _client.ExecuteAsync(request);

            //assert

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }


        [Test]
        public async Task Details_GetRequest_ShouldReturnDetailedView()
        {
            //arrange
            var eventId = 1;
            var request = new RestRequest($"Event/Details/{eventId}", Method.Get);

            //act
            var responce = await _client.ExecuteAsync(request);


            //assert
            Assert.That(responce.StatusCode, Is.EqualTo(HttpStatusCode.OK));


        }

        [Test]
        public async Task Edit_GetRequest_ShouldReturnNotFoundIfNoIdIsGiven()
        {
            //arrange

            var request = new RestRequest($"Event/Details/", Method.Get);

            //act
            var responce = await _client.ExecuteAsync(request);


            //assert
            Assert.That(responce.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));


        }
        [Test]
        public async Task Details_GetRequest_ShouldReturnNotFoundIfNoIdIsGiven()
        {
            //arrange

            var request = new RestRequest($"Event/Details/", Method.Get);

            //act
            var responce = await _client.ExecuteAsync(request);


            //assert
            Assert.That(responce.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));


        }

        [Test]
        public async Task EditAction_ReturnsViewForValidId()
        {
            //arrange
            var eventId = 1;
            var request = new RestRequest($"Event/Edit/{eventId}", Method.Get);

            //act
            var responce = await _client.ExecuteAsync(request);


            //assert
            Assert.That(responce.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));


        }

        private bool CheckEventExists(string eventName)
        {
            var options = new DbContextOptionsBuilder<EventmiContext>().UseSqlServer("YourConnectionString").Options;


            using (var context = new EventmiContext(options))
            {
                return context.Events.Any(e => e.EventName);
            }

            Assert.IsTrue(CheckEventExists(newEvent.Name), "The event was not added to the database.");
        }

        



    }
} 