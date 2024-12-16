using Acme.BookStore.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Acme.BookStore.Permissions;

public class BookStorePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var bookStoreGroup = context.AddGroup(BookStorePermissions.GroupName, L("Permission:BookStore"));

        var dipendentiPermission = bookStoreGroup.AddPermission(BookStorePermissions.Dipendenti.Default, L("Permission:Dipendenti"));
        dipendentiPermission.AddChild(BookStorePermissions.Dipendenti.Create, L("Permission:Dipendenti.Create"));
        dipendentiPermission.AddChild(BookStorePermissions.Dipendenti.Edit, L("Permission:Dipendenti.Edit"));
        dipendentiPermission.AddChild(BookStorePermissions.Dipendenti.Delete, L("Permission:Dipendenti.Delete"));

    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<BookStoreResource>(name);
    }
}
