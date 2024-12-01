using System.Security.Cryptography;
using System.Text;

namespace IndustryX.EncryptorX.CipherLayer;

public class EncryptionService(string key, string iv)
{
    private readonly byte[] _key = Encoding.UTF8.GetBytes(key);
    private readonly byte[] _iv = Encoding.UTF8.GetBytes(iv);

    public string Encrypt(string plaintext)
    {
        using var aes = Aes.Create();
        aes.Key = _key;
        aes.IV = _iv;
        
        var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
        using var ms = new MemoryStream();
        using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
        using (var sw = new StreamWriter(cs))
        {
            sw.Write(plaintext);
        }
        
        return Convert.ToBase64String(ms.ToArray());
    }

    public string Decrypt(string ciphertext)
    {
        using var aes = Aes.Create();
        aes.Key = _key;
        aes.IV = _iv;
        
        var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
        using var ms = new MemoryStream(Convert.FromBase64String(ciphertext));
        using var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
        using var sr = new StreamReader(cs);
        
        return sr.ReadToEnd();
    }
}