using Microsoft.AspNetCore.Mvc;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;

namespace hw5_asb_asp.Controllers
{
    public class HomeController : Controller
    {
        private const string connectionString = "DefaultEndpointsProtocol=https;AccountName=devitstephw5stordocweu;AccountKey=SEPz/nvkoXWpKm5UgsKErkoNsbUoAluZj9dVD6Wt5c8FJOSpiHKFJx5FxVUyO77w8z2oFSigfJRw+ASte5oElw==;EndpointSuffix=core.windows.net";
        private const string containerName = "hw5";

        // Головна сторінка з кнопками
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // Сторінка завантаження файлу
        [HttpGet]
        public IActionResult Upload()
        {
            return View();
        }

        // Обробка завантаження файлу
        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file != null)
            {
                BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
                BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);
                var blobClient = containerClient.GetBlobClient(file.FileName);

                using (var stream = file.OpenReadStream())
                {
                    await blobClient.UploadAsync(stream, true);
                }

                ViewBag.Message = "Файл успішно завантажено на сервіс!";

                return View();
            }

            ViewBag.Message = "Помилка: файл не завантажено.";

            return View();
        }

        // Сторінка зі списком файлів
        [HttpGet]
        public async Task<IActionResult> Download()
        {
            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);
            List<string> fileNames = new List<string>();

            await foreach (var blobItem in containerClient.GetBlobsAsync())
            {
                fileNames.Add(blobItem.Name);
            }

            return View(fileNames);
        }

        // Обробка запиту на завантаження файлу
        [HttpGet]
        public async Task<IActionResult> DownloadFile(string fileName)
        {
            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);
            var blobClient = containerClient.GetBlobClient(fileName);

            var downloadInfo = await blobClient.DownloadAsync();

            var stream = downloadInfo.Value.Content;
            var contentType = downloadInfo.Value.ContentType;

            return File(stream, contentType, fileName);
        }

    }
}
