using Eabor8.Bradl.Models;
using Elabor8.Bradl.Command;
using Elabor8.Bradl.CommandHandler;
using Elabor8.Bradl.Entities;
using Elabor8.Bradl.Query;
using Elabor8.Bradl.Repository;
using Elbor8.Bradl.CommandUtility;
using MediatR;
using Moq;
using Newtonsoft.Json;
using System.Collections;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace Elabor8.Bradl.Tests
{
    public class Fact_UnitTests
    {

        private Mock<IFactRepository> _factRepo;
        private List<Fact> _facts;
        private FactCsvField[] _factFields;

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
                    Used = false
                }
            };

            _factFields = _facts
            .Select(f => new FactCsvField($"{f.User.FirstName} {f.User.LastName}", f.Upvotes))
            .OrderByDescending(f => f.UpvoteCount)
            .ToArray();
        }

        [Test]
        public async Task FactReadAllQuery_Return_Result()
        {
            //Arrange
            FactReadAllQuery command = new FactReadAllQuery();

            _factRepo.Setup(_ => _.ReadAllAsync())
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
            FactCsvQuery command = new FactCsvQuery();

            _factRepo.Setup(_ => _.ReadCsvDataAsync())
                .ReturnsAsync(_factFields);

            FactCsvCommandHandler handler = new FactCsvCommandHandler(_factRepo.Object, new CsvCommandHelper());

            //Act
            var result = await handler.Handle(command, new CancellationToken());

            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task FactCsvCommand_Return_ValidCsvSequence()
        {
            //Arrange
            FactCsvQuery command = new FactCsvQuery();

            _factRepo.Setup(_ => _.ReadCsvDataAsync())
                .ReturnsAsync(_factFields);

            FactCsvCommandHandler handler = new FactCsvCommandHandler(_factRepo.Object, new CsvCommandHelper());

            //Act
            var result = await handler.Handle(command, new CancellationToken());

            using (var fs = new FileStream("data.csv", FileMode.Create, FileAccess.Write))
            {
                fs.Write(result, 0, result.Length);
            }

            var data = await File.ReadAllLinesAsync("data.csv");

            var csv = new List<FactCsvField>();

            //Start from index 1 so we don't get headers
            for(var i = 1; i < data.Length; i++)
            {
                var entry = data[i].Split(',');
                var fullName = entry[0];
                int.TryParse(entry[1], out int upvote);
                csv.Add(new FactCsvField(fullName, upvote));
            }
            //Assert
            Assert.That(_factFields, Is.EqualTo(csv.ToArray()).Using(new CompareFactField()));
        }
    }
}