using System;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using WeatherUpdateScheduler.Models;

namespace WeatherUpdateScheduler
{
    public class WeatherSchedulerFunction
    {
        [FunctionName("WeatherSchedulerFunction")]
        public static async Task Run([TimerTrigger("0 */1 * * * *")] TimerInfo timer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            try
            {
                DataTable table = new();
                DateTime dateTime = DateTime.Now;
                using HttpClient client = new();
                string connectionString = Environment.GetEnvironmentVariable("SqlConnection");
                client.BaseAddress = new Uri(Environment.GetEnvironmentVariable("WeatherApiUrl"));

                foreach (var item in HelperConstants.WeatherDetailTableColumns)
                    table.Columns.Add(item);

                foreach (var city in HelperConstants.Cities)
                {
                    HttpResponseMessage httpResponse = await client.GetAsync($"forecast?latitude={city.Latitude}&longitude={city.Longitude}&current_weather=true");
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        WeatherUpdateResponse weatherUpdateResponse = await httpResponse.Content.ReadAsAsync<WeatherUpdateResponse>();
                        table.Rows.Add(new Object[] { null, city.Country, city.Name, weatherUpdateResponse.Current_Weather.Temperature, weatherUpdateResponse.Current_Weather.WindSpeed, dateTime, weatherUpdateResponse.Current_Weather.WeatherCode });
                    }
                }
                using var bulkCopy = new SqlBulkCopy(connectionString);
                bulkCopy.DestinationTableName = HelperConstants.WeatherDetailTable;
                bulkCopy.BulkCopyTimeout = 60;
                await bulkCopy.WriteToServerAsync(table);
            }
            catch (Exception ex)
            {
                log.LogInformation($"Internal server error : {ex}");
                throw;
            }
        }
    }
}
