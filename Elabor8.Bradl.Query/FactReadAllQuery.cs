using Elabor8.Bradl.Entities;
using MediatR;

namespace Elabor8.Bradl.Query
{
    public class FactReadAllQuery : IRequest<Fact[]>
    {
    }
}