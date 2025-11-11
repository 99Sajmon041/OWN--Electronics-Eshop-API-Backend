namespace ElectronicsEshop.Application.Exceptions;

public class NotFoundException(string resource, object key) : Exception($"{resource} with ({key}) was not found.")
{
}
