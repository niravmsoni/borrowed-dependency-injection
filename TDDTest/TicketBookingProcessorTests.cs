using System;
using TDDCore;
using Xunit;

namespace TDDTest
{
    public class TicketBookingProcessorTests
    {
        private readonly TicketBookingProcessor _processor;

        public TicketBookingProcessorTests()
        {
            _processor = new TicketBookingProcessor();
        }

        [Fact]
        public void ShouldReturnTicketBookingResultWithSameValues()
        {
            var request = new TicketBookingRequest
            {
                FirstName = "Abdul",
                LastName = "Rahman",
                Email = "abdulrahman@demo.com"
            };

            TicketBookingResponse response = _processor.Book(request);

            Assert.NotNull(response);
            Assert.Equal(request.FirstName, response.FirstName);
            Assert.Equal(request.LastName, response.LastName);
            Assert.Equal(request.Email, response.Email);
        }

        [Fact]
        public void ShouldThrowExceptionIfRequestIsNull()
        {
            // Act  
            var exception = Assert.Throws<ArgumentNullException>(() => _processor.Book(null));

            // Assert  
            Assert.Equal("request", exception.ParamName);
        }
    }
}
