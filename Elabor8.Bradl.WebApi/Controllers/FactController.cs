using CsvHelper;
using CsvHelper.Configuration;
using Elabor8.Bradl.Command;
using Elabor8.Bradl.Entities;
using Elabor8.Bradl.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Formats.Asn1;
using System.Globalization;
using static System.Net.Mime.MediaTypeNames;
using System.Text;
using System.IO;

namespace Elabor8.Bradl.WebApi.Controllers
{
    [ApiController]
    [Route("facts")]
    public class FactController : Controller
    {
        private readonly IMediator _mediator;
        public FactController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("seed")]
        public async Task Seed()
        {
            await _mediator.Send(new FactCreateCommand(Guid.NewGuid(), "Testing the first Cat", "cat"));
            await _mediator.Send(new FactCreateCommand(Guid.NewGuid(), "Testing the second Cat", "cat"));
            await _mediator.Send(new FactCreateCommand(Guid.NewGuid(), "Testing the third Cat", "cat"));
            await _mediator.Send(new FactCreateCommand(Guid.NewGuid(), "Testing number four Cat", "cat"));
        }

        [HttpGet("")]
        public async Task<Fact[]> GetAll()
        {
            var facts = await _mediator.Send(new FactReadAllQuery());
            return facts;
        }

        [HttpGet("{id}")]
        public async Task<Fact> GetById(Guid id)
        {
            var fact = await _mediator.Send(new FactReadQuery(id));
            return fact;
        }

        [HttpGet("csv")]
        public async Task<FileContentResult> Csv()
        {
            var csv = await _mediator.Send(new FactCsvQuery());
            return File(csv, "text/csv", $"{DateTime.Now.Ticks}-data.csv");
        }
    }
}