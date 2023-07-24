using System.Security.Cryptography;
using System.Text;

namespace Application.Mapping;

public static class PasswordHashing
{
    public static string Hash(this string password)
    {
        using var hashingAlgorithm = SHA256.Create();
        byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
        return BitConverter.ToString(hashingAlgorithm.ComputeHash(passwordBytes));
    }
}