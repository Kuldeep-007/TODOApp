using System.Diagnostics.CodeAnalysis;

namespace TODOApp.Web
{
    public class AppSettings
    {
        public ConnectionStrings ConnectionStrings { get; set; }
    }

    public class ConnectionStrings
    {
        public string TODOAppDbConnection { get; set; }
    }
}
