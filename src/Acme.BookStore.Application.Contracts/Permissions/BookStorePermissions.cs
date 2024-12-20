namespace Acme.BookStore.Permissions;

public static class BookStorePermissions
{
    public const string GroupName = "BookStore";

    // other permissions...
    // other permissions...

    // *** ADDED a NEW NESTED CLASS ***
   
    public static class Dipendenti
    {
        public const string Default = GroupName + ".Dipendenti";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }
    public static class Clienti
    {
        public const string Default = GroupName + ".Clienti";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }
    public static class Commesse
    {
        public const string Default = GroupName + ".Commesse";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }
}
