using FitnessReservation.BL.Domain;
using FitnessReservation.BL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectDomain {
    public class ClientTest {
        [Fact]
        public void SetID_valid() {
            Client c = new Client(1,"bart@preeters", "bart", "janssens");
            Assert.Equal(1, c.ID);
            c.SetID(2);
            Assert.Equal(2, c.ID);
        }
        
        [Fact]
        public void SetID_invalid() {
            Client c = new Client(1,"bart@preeters", "bart", "janssens");
            Assert.Equal(1, c.ID);
            Assert.Throws<ClientException>(() => c.SetID(0));
            Assert.Equal(1, c.ID);
        }

        [Theory]
        [InlineData("bart@preeters.com")]
        [InlineData("bert@peeters.be")]
        public void SetEmail_valid(string email) { 

        }

    }
}
