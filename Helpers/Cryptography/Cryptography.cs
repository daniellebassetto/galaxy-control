using System.Security.Cryptography;
using System.Text;

namespace GalaxyControl.Helpers;

public static class Cryptography
{
    public static string GenerateHash(this string value)
    {
        var encoding = new ASCIIEncoding();
        var array = encoding.GetBytes(value);

        array = SHA1.HashData(array);

        var strhexa = new StringBuilder();

        foreach (var item in array)
        {
            strhexa.Append(item.ToString("x2"));
        }

        return strhexa.ToString();
    }
}