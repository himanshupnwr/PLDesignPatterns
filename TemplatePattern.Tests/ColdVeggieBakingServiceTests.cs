using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateMethod.V2;
using Xunit.Abstractions;

namespace TemplatePattern.Tests
{
    public class ColdVeggieBakingServiceTests
    {
        private readonly ITestOutputHelper _output;
        public ColdVeggieBakingServiceTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void ReturnsAPizza()
        {
            var logger = new LoggerAdapter();
            var service = new ColdVeggiePizzaBakingService(logger);

            var pizza = service.Prepare();

            Assert.NotNull(pizza);
            _output.WriteLine(logger.Dump());
        }
    }
}
