namespace fncConsumidor
{
    using System;
    using System.Threading.Tasks;
    using fncConsumidor.Models;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Host;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;

    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task RunAsync(
            [ServiceBusTrigger(
                "raspberryqueue",
                Connection = "raspberryqueueConn"
            )]string myQueueItem,

            [CosmosDB(
                databaseName:"dbRaspberryPI",
                collectionName:"Data",
                ConnectionStringSetting = "strCosmos"
            )] IAsyncCollector<object> datos,

            ILogger log)
        {
            try
            {
                log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
                var data = JsonConvert.DeserializeObject<Data>(myQueueItem);
                await datos.AddAsync(data);
            }
            catch (Exception ex)
            {
                log.LogError($"No es posible insertar datos: {ex.Message}");
            }
        }
    }

}
