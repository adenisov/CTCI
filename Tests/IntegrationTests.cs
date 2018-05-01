using Runner;
using Xunit;

namespace Tests
{
    public class IntegrationTests
    {
        [Fact]
        public void RunAll()
        {
            Program.Main(new string[0]);
        }
    }
}