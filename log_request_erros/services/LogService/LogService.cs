using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace log_request_erros.services.LogService;

public static class LogService
{
    // Log básico, pode ser feito um melhor;;
    public static void Log(
        ValidationProblemDetails problemDetails)
    {
        // Precisa criar uma pasta 'internal_logs' no disco C:, ou seu lugar de preferência.
        string path = @$"C:\internal_logs\";
        string nameLog = $@"{DateTime.Now:yyyy'-'MM'-'dd'T'HH'-'mm'-'ss}.txt";
        try
        {
            File.Create(path + nameLog).Close();
            File.AppendAllText(path + nameLog, 
                JsonConvert.SerializeObject(problemDetails));
        }
        catch { }
    }
}
