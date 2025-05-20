using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateMethod.V2;
using Xunit.Abstractions;

namespace TemplatePattern.Tests
{
    public class PieBakingServiceTests
    {
        private readonly ITestOutputHelper _output;
        public PieBakingServiceTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void ReturnsAPie()
        {
            var logger = new LoggerAdapter();
            var service = new PieBakingService(logger);

            var pie = service.Prepare();

            Assert.NotNull(pie);
            _output.WriteLine(logger.Dump());
        }
    }
}
