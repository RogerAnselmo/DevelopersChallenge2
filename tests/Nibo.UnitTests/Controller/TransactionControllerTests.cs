using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Controllers;
using API.Enums;
using API.Models;
using API.Repositories;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace Nibo.UnitTests.Controller
{
    public class TransactionControllerTests: GlobalSetUp
    {
        private TransactionController _transactionController;
        private TransactionRepository _transactionRepository;
        private ObjectResult _result;
        private Transaction[] _transactions;

        [SetUp]
        public void AllClassesSetUp()
        {
            _transactions = new Transaction[]
            {
                GenerateRandomTransaction(),
                GenerateRandomTransaction(),
                GenerateRandomTransaction()
            };

            _transactionRepository = A.Fake<TransactionRepository>();
            _transactionController = new TransactionController(_transactionRepository);
        }

        public class Post: TransactionControllerTests
        {
            [SetUp]
            public async Task SetUp()
            {
                A.CallTo(()=>_transactionRepository.AddAsync(_transactions))
                    .Returns(Task.FromResult(true));

                _result = await _transactionController.Post(_transactions);
            }

            [Test]
            public void ShouldCallRepository() =>
                A.CallTo(() => _transactionRepository.AddAsync(_transactions))
                    .MustHaveHappenedOnceExactly();

            [Test]
            public void ShouldReturnCreated() =>
                _result.GetType().Should().Be(typeof(CreatedResult));

            [Test]
            public void ShouldReturnCorrectMessage() =>
                _result.Value
                    .Should()
                    .BeEquivalentTo(new { message = "transações salvas com sucesso." });

            [Test]
            public async Task ShouldReturnBadRequestWhenSaveFails()
            {
                A.CallTo(() => _transactionRepository.AddAsync(_transactions))
                    .Returns(Task.FromResult(false));

                _result = await _transactionController.Post(_transactions);

                _result.GetType().Should().Be(typeof(BadRequestObjectResult));
            }

            [Test]
            public async Task ShouldReturnErrorMessageWhenSaveFails()
            {
                A.CallTo(() => _transactionRepository.AddAsync(_transactions))
                    .Returns(Task.FromResult(false));

                _result = await _transactionController.Post(_transactions);

                _result.Value.Should().BeEquivalentTo(new { message = "erro ao salvar transações." });
            }
        }

        public class Get : TransactionControllerTests
        {
            [SetUp]
            public async Task SetUp()
            {
                A.CallTo(() => _transactionRepository.GetAsync())
                    .Returns(_transactions);

                _result = await _transactionController.Get();
            }

            [Test]
            public void ShouldReturnOk() => _result.GetType().Should().Be(typeof(OkObjectResult));

            [Test]
            public void ShouldOrderList()
            {
                var list = (IEnumerable<Transaction>)_result.Value;

                var firstOfList = list.FirstOrDefault();
                var firstOfTransactions = _transactions.OrderBy(x => x.DatePosted).FirstOrDefault();

                    firstOfList.Should()
                    .Be(firstOfTransactions);

            }
        }

        public class VerifyNewTransactions : TransactionControllerTests
        {
            [SetUp]
            public void SetUp()
            {
                A.CallTo(() => _transactionRepository.VerifyNewTransactions(_transactions))
                    .Returns(_transactions);

                _result = _transactionController.VerifyNewTransactions(_transactions);
            }

            [Test]
            public void ShouldCallRepository() =>
                A.CallTo(() => _transactionRepository.VerifyNewTransactions(_transactions))
                    .MustHaveHappenedOnceExactly();

            [Test]
            public void ShouldReturnOk() => 
                _result.GetType().Should().Be(typeof(OkObjectResult));
        }

        private Transaction GenerateRandomTransaction() =>
            new Transaction
            {
                DatePosted = Faker.Date.Recent(),
                Id = Faker.Random.Int(),
                Memo = Faker.Random.Words(),
                TransactionAmount = Faker.Random.Decimal(),
                Type = (TransactionType) Faker.Random.Int(0, 1)
            };
    }
}
