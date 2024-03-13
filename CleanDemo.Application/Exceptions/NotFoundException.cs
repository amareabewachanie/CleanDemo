
namespace CleanDemo.Application.Exceptions
{
    public class NotFoundException: Exception
    {
        public NotFoundException(string name, object key)
            :base($"{name} is not found") { }
       
    }
}
