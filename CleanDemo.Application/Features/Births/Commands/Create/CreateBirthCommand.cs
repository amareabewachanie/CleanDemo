using MediatR;


namespace CleanDemo.Application.Features.Births.Commands.Create
{
    public class CreateBirthCommand :IRequest<CreateBirthCommandResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
