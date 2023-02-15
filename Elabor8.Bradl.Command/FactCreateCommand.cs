using Elabor8.Bradl.Entities;
using MediatR;

namespace Elabor8.Bradl.Command
{
    public class FactCreateCommand : IRequest
    {
        private readonly Guid _id;
        private readonly string _text;
        private readonly string _type;
        private readonly Guid? _userId;

        public FactCreateCommand(Guid id, string text, string type)
        {
            _id = id;
            _text = text ?? throw new ArgumentNullException(nameof(text));
            _type = type ?? throw new ArgumentNullException(nameof(type));
        }
        public Guid Id => _id;
        public string Text => _text;
        public string Type => _type;
    }
}