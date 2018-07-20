using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace psappdemo.Services
{
    public class ImageStore
    {
        CloudBlockBlob _blob;
        CloudBlobContainer _container;
        CloudBlobClient _blobClient;
        string baseuri = "https://psappdemostorage.blob.core.windows.net/";
        public ImageStore()
        {
            var credentials = new StorageCredentials("psappdemostorage", "3xzYu4dr+XXWLEPnmAHaJ57lRxbrhpb5cjy2D+7e380mbIKUYiRdFWvJUCud82Ko+pEgRBzScar1nFIUPOg97w==");
            _blobClient = new CloudBlobClient(new Uri(baseuri),credentials);
        }

        //method to upload an image file
        public async Task<string> SaveImage(Stream imageStream)
        {   //generate a random string to use as uploaded file name
            var imageId = Guid.NewGuid().ToString();
            //create a reference to the container
            _container = _blobClient.GetContainerReference("images");
            //use container reference to create a reference to the blob with newly created name from above
            _blob = _container.GetBlockBlobReference(imageId);
            //call blob methold on blob to upload the file stream
            
            await _blob.UploadFromStreamAsync(imageStream);
            return imageId;
        }


        public string UriFor(string filename)
        {
            var accessPolicy = new SharedAccessBlobPolicy
            {
                Permissions = SharedAccessBlobPermissions.Read,
                SharedAccessStartTime = DateTime.UtcNow.AddMinutes(-15),
                SharedAccessExpiryTime = DateTime.UtcNow.AddMinutes(15)
            };
            var sig = _blob.GetSharedAccessSignature(accessPolicy);
            return $"{baseuri}images/{filename}{sig}";
        }
        
    }
}
