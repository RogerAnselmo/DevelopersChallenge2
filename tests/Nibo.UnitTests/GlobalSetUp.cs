using Bogus;

namespace Nibo.UnitTests
{
    public class GlobalSetUp
    {
        protected Faker Faker;

        public GlobalSetUp() => Faker = new Faker();
    }
}
