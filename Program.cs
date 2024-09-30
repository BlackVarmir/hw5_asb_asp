using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs;

namespace hw5_asb_asp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            var app = builder.Build();


            app.UseRouting();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            //app.MapPost("/upload", async (HttpRequest request) =>
            //{
            //    var form = await request.ReadFormAsync();
            //    var file = form.Files.GetFile("file");

            //    if (file != null)
            //    {
            //        var connectionString = "DefaultEndpointsProtocol=https;AccountName=devitstephw5stordocweu;AccountKey=SEPz/nvkoXWpKm5UgsKErkoNsbUoAluZj9dVD6Wt5c8FJOSpiHKFJx5FxVUyO77w8z2oFSigfJRw+ASte5oElw==;EndpointSuffix=core.windows.net";
            //        var containerName = "hw5";
            //        BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
            //        BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);

            //        var blobClient = containerClient.GetBlobClient(file.FileName);

            //        using (var stream = file.OpenReadStream())
            //        {
            //            await blobClient.UploadAsync(stream, true);
            //        }
            //        return Results.Ok("File uploaded successfully.");
            //    }

            //    return Results.BadRequest("No file uploaded.");
            //});

            //app.MapGet("/download/{fileName}", async (string fileName) =>
            //{
            //    var connectionString = "DefaultEndpointsProtocol=https;AccountName=devitstephw5stordocweu;AccountKey=SEPz/nvkoXWpKm5UgsKErkoNsbUoAluZj9dVD6Wt5c8FJOSpiHKFJx5FxVUyO77w8z2oFSigfJRw+ASte5oElw==;EndpointSuffix=core.windows.net";
            //    var containerName = "hw5";
            //    BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
            //    BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);
            //    BlobClient blobClient = containerClient.GetBlobClient(fileName);

            //    var downloadInfo = await blobClient.DownloadAsync();
            //    return Results.File(downloadInfo.Value.Content, downloadInfo.Value.ContentType, fileName);
            //});

            //app.MapGet("/list", async () =>
            //{
            //    var connectionString = "DefaultEndpointsProtocol=https;AccountName=devitstephw5stordocweu;AccountKey=SEPz/nvkoXWpKm5UgsKErkoNsbUoAluZj9dVD6Wt5c8FJOSpiHKFJx5FxVUyO77w8z2oFSigfJRw+ASte5oElw==;EndpointSuffix=core.windows.net";
            //    var containerName = "hw5";
            //    BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
            //    BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);

            //    var blobs = new List<string>();
            //    await foreach (BlobItem blobItem in containerClient.GetBlobsAsync())
            //    {
            //        blobs.Add(blobItem.Name);
            //    }

            //    return Results.Ok(blobs);
            //});

            app.Run();

        }
    }
}
