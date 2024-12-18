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

        var clientiPermission = bookStoreGroup.AddPermission(BookStorePermissions.Clienti.Default, L("Permission:Clienti"));
        clientiPermission.AddChild(BookStorePermissions.Clienti.Create, L("Permission:Clienti.Create"));
        clientiPermission.AddChild(BookStorePermissions.Clienti.Edit, L("Permission:Clienti.Edit"));
        clientiPermission.AddChild(BookStorePermissions.Clienti.Delete, L("Permission:Clienti.Delete"));

        var commessePermission = bookStoreGroup.AddPermission(BookStorePermissions.Commesse.Default, L("Permission:Commesse"));
        commessePermission.AddChild(BookStorePermissions.Commesse.Create, L("Permission:Commesse.Create"));
        commessePermission.AddChild(BookStorePermissions.Commesse.Edit, L("Permission:Commesse.Edit"));
        commessePermission.AddChild(BookStorePermissions.Commesse.Delete, L("Permission:Commesse.Delete"));

    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<BookStoreResource>(name);
    }
}
