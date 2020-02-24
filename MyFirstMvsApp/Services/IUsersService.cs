namespace MyFirstMvsApp.Services
{
    using System.Collections.Generic;

    public interface IUsersService
    {
        int Count();

        IEnumerable<string> GetUsernames();

        string LatestUsername();
    }
}