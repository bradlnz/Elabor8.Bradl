using Elabor8.Bradl.Command;
using Elabor8.Bradl.CommandHandler;
using Elabor8.Bradl.Entities;
using Elabor8.Bradl.Query;
using Elabor8.Bradl.Repository;
using MediatR;
using Moq;

namespace Elabor8.Bradl.Tests
{
    public class Tests
    {

        private Mock<IFactRepository> _factRepo;
        private List<Fact> _facts;
        [SetUp]
        public void Setup()
        {
            _factRepo = new Mock<IFactRepository>();

            _facts = new List<Fact>
            {
                new Fact
                {
                    Id = Guid.NewGuid(),
                    Text = "Testing cat val 1",
                    Type = "cat",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    Deleted = false,
                    Source = "user",
                    Status = new Status
                    {
                        Id = 1,
                        SentCount = 3,
                        Verified = false,
                    },
                    Used = false
                },
                new Fact
                {
                    Id = Guid.NewGuid(),
                    Text = "Testing cat val 2",
                    Type = "cat",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    Deleted = false,
                    Source = "user",
                    Status = new Status
                    {
                        Id = 1,
                        SentCount = 3,
                        Verified = false,
                    },
                    Used = false
                }
            };
        }

        [Test]
        public async Task FactReadAllQuery_Return_Result()
        {
            //Arrange
            var mediator = new Mock<IMediator>();

            FactReadAllQuery command = new FactReadAllQuery();

            _factRepo.Setup(_ => _.ReadAllAsync(command))
                .ReturnsAsync(_facts.ToArray());

            FactReadAllCommandHandler handler = new FactReadAllCommandHandler(_factRepo.Object);

            //Act
            var result = await handler.Handle(command, new CancellationToken());

            //Assert
            Assert.IsNotEmpty(result);
        }

        [Test]
        public async Task FactReadQuery_Return_Result()
        {
            //Arrange
            var mediator = new Mock<IMediator>();

            var fact = _facts.ToArray()[0];

            FactReadQuery command = new FactReadQuery(fact.Id);

            _factRepo.Setup(_ => _.ReadAsync(command))
                .ReturnsAsync(fact);

            FactReadCommandHandler handler = new FactReadCommandHandler(_factRepo.Object);

            //Act
            var result = await handler.Handle(command, new CancellationToken());

            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task FactCsvCommand_Return_Result()
        {
            //Arrange
            FactCsvCommand command = new FactCsvCommand(_facts.ToArray());

            FactCsvCommandHandler handler = new FactCsvCommandHandler();

            //Act
            var result = await handler.Handle(command, new CancellationToken());

            //Assert
            Assert.IsNotNull(result);
        }
    }
}