using System.Security.Cryptography;
using System.Text;

namespace FlatDesignApp.Methods;
public class AuthUser
{
    public static Task<bool> CheckUser(string login, string password)
    {
        return Task.Run(() => App.Context.Users.FirstOrDefault(x => x.Login == login && x.Password == HashPassword(login, password)) != null);
    }

    public static string HashPassword(string login, string password)
    {
        using SHA256 hash = SHA256.Create();
        return Convert.ToHexString(hash.ComputeHash(Encoding.ASCII.GetBytes(login + password)));
    }
}