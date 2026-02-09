using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("=== Endpoint Security Agent Started ===");
        while (true)
        {
            string disk = GetDiskStatus();
            string av = GetAntivirusStatus();
            Console.WriteLine($"[{DateTime.Now}] Local Status -> Disk: {disk}, AV: {av}");
            await SendPing(disk, av);
            Thread.Sleep(15000);
        }
    }

    static string GetDiskStatus()
    {
        try
        {
            Process p = new Process();
            p.StartInfo = new ProcessStartInfo("manage-bde", "-status") { RedirectStandardOutput = true, UseShellExecute = false, CreateNoWindow = true };
            p.Start();
            string output = p.StandardOutput.ReadToEnd();
            return output.Contains("Protection On") ? "Yes" : "No";
        }
        catch { return "Unknown"; }
    }

    static string GetAntivirusStatus()
    {
        try
        {
            Process p = new Process();
            p.StartInfo = new ProcessStartInfo("powershell", "Get-MpComputerStatus | Select -ExpandProperty AntivirusEnabled") { RedirectStandardOutput = true, UseShellExecute = false, CreateNoWindow = true };
            p.Start();
            string result = p.StandardOutput.ReadToEnd().Trim();
            return result == "True" ? "Enabled" : "Disabled";
        }
        catch { return "Unknown"; }
    }

    static async Task SendPing(string disk, string av)
    {
        try
        {
            using var client = new HttpClient();
            string json = $"{{\"DiskEncrypted\":\"{disk}\", \"Antivirus\":\"{av}\"}}";
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await client.PostAsync("https://localhost:7063/status", content);
            Console.WriteLine("Status sent to server successfully.");
        }
        catch
        {
            Console.WriteLine("Status failed to send.");
        }
    }
}