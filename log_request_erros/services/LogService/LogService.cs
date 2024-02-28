using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace log_request_erros.services.LogService;

public static class LogService
{
    // Precisa criar uma pasta 'internal_logs' no disco C:, ou seu lugar de preferência.
    private static readonly string Path = @$"C:\internal_logs\";
    private static readonly string NameLog = $@"{DateTime.Now:yyyy'-'MM'-'dd'T'HH'-'mm'-'ss}.txt";

    // Log básico, pode ser feito um melhor;;
    public static void Log(
        ValidationProblemDetails problemDetails)
    {
        try
        {
            File.Create(Path + NameLog).Close();
            File.AppendAllText(Path + NameLog,
                JsonConvert.SerializeObject(problemDetails));
        }
        catch { }
    }

    public static void LogGlobal(HttpContext context)
    {
        try
        {
            var stream = new StreamReader(context.Request.Body);
            var jsonRequest = stream.ReadToEnd();

            File.Create(Path + NameLog).Close();
            File.AppendAllText(Path + NameLog, jsonRequest);

            context.Request.Body = new MemoryStream(Encoding.UTF8.GetBytes(jsonRequest));
        }
        catch { }
    }
}
