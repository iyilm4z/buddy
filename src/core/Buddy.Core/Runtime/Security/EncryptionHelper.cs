using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Buddy.Runtime.Security;

public class EncryptionHelper
{
    private static byte[] EncryptTextToMemory(string data, byte[] key, byte[] iv)
    {
        using var ms = new MemoryStream();
        using (var cs = new CryptoStream(ms, TripleDES.Create().CreateEncryptor(key, iv), CryptoStreamMode.Write))
        {
            var toEncrypt = Encoding.Unicode.GetBytes(data);
            cs.Write(toEncrypt, 0, toEncrypt.Length);
            cs.FlushFinalBlock();
        }

        return ms.ToArray();
    }

    private static string DecryptTextFromMemory(byte[] data, byte[] key, byte[] iv)
    {
        using var ms = new MemoryStream(data);
        using var cs = new CryptoStream(ms, TripleDES.Create().CreateDecryptor(key, iv), CryptoStreamMode.Read);
        using var sr = new StreamReader(cs, Encoding.Unicode);
        return sr.ReadToEnd();
    }

    public static string CreateHash(byte[] data, string hashAlgorithm, int trimByteCount = 0)
    {
        if (string.IsNullOrEmpty(hashAlgorithm))
            throw new ArgumentNullException(nameof(hashAlgorithm));

        var algorithm = (HashAlgorithm)CryptoConfig.CreateFromName(hashAlgorithm);
        if (algorithm == null)
            throw new ArgumentException("Unrecognized hash name");

        if (trimByteCount > 0 && data.Length > trimByteCount)
        {
            var newData = new byte[trimByteCount];
            Array.Copy(data, newData, trimByteCount);

            return BitConverter.ToString(algorithm.ComputeHash(newData)).Replace("-", string.Empty);
        }

        return BitConverter.ToString(algorithm.ComputeHash(data)).Replace("-", string.Empty);
    }

    public static string CreateSaltKey(int size)
    {
        //generate a cryptographic random number
        using var provider = RandomNumberGenerator.Create();
        var buff = new byte[size];
        provider.GetBytes(buff);

        // Return a Base64 string representation of the random number
        return Convert.ToBase64String(buff);
    }

    public static string CreatePasswordHash(string password, string saltkey, string passwordFormat)
    {
        return CreateHash(Encoding.UTF8.GetBytes(string.Concat(password, saltkey)), passwordFormat);
    }

    public static string EncryptText(string plainText, string encryptionPrivateKey = "")
    {
        if (string.IsNullOrEmpty(plainText))
            return plainText;

        if (string.IsNullOrEmpty(encryptionPrivateKey))
            encryptionPrivateKey = SecuritySettings.EncryptionKey;

        using var provider = TripleDES.Create();
        provider.Key = Encoding.ASCII.GetBytes(encryptionPrivateKey[0..16]);
        provider.IV = Encoding.ASCII.GetBytes(encryptionPrivateKey[8..16]);

        var encryptedBinary = EncryptTextToMemory(plainText, provider.Key, provider.IV);
        return Convert.ToBase64String(encryptedBinary);
    }

    public static string DecryptText(string cipherText, string encryptionPrivateKey = "")
    {
        if (string.IsNullOrEmpty(cipherText))
            return cipherText;

        if (string.IsNullOrEmpty(encryptionPrivateKey))
            encryptionPrivateKey = SecuritySettings.EncryptionKey;

        using var provider = TripleDES.Create();
        provider.Key = Encoding.ASCII.GetBytes(encryptionPrivateKey[0..16]);
        provider.IV = Encoding.ASCII.GetBytes(encryptionPrivateKey[8..16]);

        var buffer = Convert.FromBase64String(cipherText);
        return DecryptTextFromMemory(buffer, provider.Key, provider.IV);
    }
}