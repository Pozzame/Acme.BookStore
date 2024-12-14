using Volo.Abp;

namespace Acme.BookStore.Dipendenti;

public class DipendenteAlreadyExistsException : BusinessException
{
    public DipendenteAlreadyExistsException(string name)
        : base(BookStoreDomainErrorCodes.DipendenteAlreadyExists)
    {
        WithData("name", name);
    }
}