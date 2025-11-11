namespace ElectronicsEshop.Application.Exceptions;

public class ConflictException : Exception
{
    public ConflictException(string duplicateKey, string resourceName = "Resource", string message = "Nastal konflikt") :
        base($"{message}: {resourceName} s hodnotou '{duplicateKey}' již existuje.")
    {
    }
}
