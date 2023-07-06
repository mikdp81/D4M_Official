using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System;
using System.IO;

namespace BusinessLogic.Services.blob
{
    public class AzureBlobManager
    {
#pragma warning disable IDE0044 // Add readonly modifier
        private BlobContainerClient _container;
#pragma warning restore IDE0044 // Add readonly modifier

        // ultimo blob usato
        private string _currentBlobName;

        //percorso del file escluso nome ed estensione file
        private string _sourcePath;

        //percorso del file escluso nome ed estensione file
        private string _targetPath;

        public string ContainerName
        {
            get { return _container.Name; }
        }
        public string AccountName
        {
            get { return _container.AccountName; }
        }

        //percorso del file escluso nome ed estensione file
        public string SourcePath
        {
            get
            {
                return _sourcePath;
            }
            set
            {
                if (value != null) _sourcePath = value;
            }
        }

        //percorso del file escluso nome ed estensione file
        public string TargetPath
        {
            get
            {
                return _targetPath;
            }
            set
            {
                if (value != null) _targetPath = value;
            }
        }

        // ultimo blob usato
        public string CurrentBlobName
        {
            get
            {
                return _currentBlobName;
            }
            private set
            {
                if (value != null) _currentBlobName = value;
            }
        }

        public AzureBlobManager(string sas, string sourcePath, string targetPath, string containerName = "root")
        {
            SourcePath = sourcePath;
            TargetPath = targetPath;

            Uri uri = this.ComposeUri(sas, containerName);
            _container = new BlobContainerClient(uri);
#pragma warning disable IDE0059 // Unnecessary assignment of a value
          var result = _container.CreateIfNotExists();
#pragma warning restore IDE0059 // Unnecessary assignment of a value
        }



        public string UploadBlob(string fileName, string blobName = null, bool overwrite = false)
        {
            // gestione parametri opzionali
            CurrentBlobName = blobName;
            string path = SourcePath + "/" + fileName;
            if (overwrite)
                _container.DeleteBlobIfExists(CurrentBlobName);

            try
            {
                BlobClient blobClient = _container.GetBlobClient(CurrentBlobName);
                Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo> result = blobClient.Upload(path);
                return result.GetRawResponse().ReasonPhrase;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return e.Message;
            }


        }



        public string DownloadBlob(string fileName, string blobName = null, bool overwrite = false)
        {
            string response = "Failed";
            // gestione parametri
            CurrentBlobName = blobName;
            string path = TargetPath + "/" + fileName;

            if (overwrite || !File.Exists(path))
            {
                try
                {
                    // Get a reference to a blob named "blobName" in _container 
                    BlobClient blobClient = _container.GetBlobClient(blobName);
                    Azure.Response result = blobClient.DownloadTo(path);
                    response = result.ReasonPhrase;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return e.Message;
                }
            }

            return response;
        }

        public string DeleteBlob(string blobName = null)
        {
            // gestione parametri opzionali
            CurrentBlobName = blobName;
            Azure.Response result = _container.DeleteBlob(CurrentBlobName);

            return result.ReasonPhrase;
        }

        public string DeleteContainer()
        {
            // Get a reference to a blob named "blobName" in _container 
            Azure.Response result = _container.Delete();

            return result.ReasonPhrase;
        }

        public string ListBlob(string containerName)
        {

            string result = "";

            foreach (BlobItem blob in _container.GetBlobs())
            {
                if (blob.Properties.ContentLength > 0)
                {
                    result += "<tr><td>" + blob.Name + "</td><td>" + blob.Properties.LastModified + "</td><td>" + SizeSuffix(Convert.ToInt64(blob.Properties.ContentLength), 2) + "</td><td><a href='../../../DownloadFile?type=" + containerName + "&nomefile=" + blob.Name + "' target='_blank'>Apri</a></td></tr>";
                }
            }

            return result;
        }
        private static readonly string[] SizeSuffixes =
                           { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
        private static string SizeSuffix(Int64 value, int decimalPlaces = 1)
        {
            if (decimalPlaces < 0) { throw new ArgumentOutOfRangeException("decimalPlaces"); }
            if (value < 0) { return "-" + SizeSuffix(-value, decimalPlaces); }
            if (value == 0) { return string.Format("{0:n" + decimalPlaces + "} bytes", 0); }

            int mag = (int)Math.Log(value, 1024);

            decimal adjustedSize = (decimal)value / (1L << (mag * 10));

            if (Math.Round(adjustedSize, decimalPlaces) >= 1000)
            {
                mag += 1;
                adjustedSize /= 1024;
            }

            return string.Format("{0:n" + decimalPlaces + "} {1}",
                adjustedSize,
                SizeSuffixes[mag]);
        }

        public string MoveAndRenameFile(string sas, string sourceFileName, string destinationFileName, string sourceContainerName, string destinationContainerName)
        {
            // Ottieni una riferimento al blob nel contenitore di origine
            BlobClient sourceBlob = _container.GetBlobClient(sourceFileName);

            // Ottieni una riferimento al blob nel contenitore di destinazione con il nuovo nome
            BlobContainerClient _container2;
            Uri uri = this.ComposeUri(sas, destinationContainerName);
            _container2 = new BlobContainerClient(uri);
            BlobClient destinationBlob = _container2.GetBlobClient(destinationFileName);

            // Esegui la copia del blob nel contenitore di destinazione con il nuovo nome
            destinationBlob.StartCopyFromUri(sourceBlob.Uri);

            // Elimina il blob dal contenitore di origine
            sourceBlob.Delete();

            return destinationBlob.Name;
        }


        private Uri ComposeUri(string sas, string containerName)
        {
            string[] temp = sas.Split('?');
            sas = temp[0] + containerName + "/?" + temp[1];

            return new System.Uri(sas);
        }
    }
}
