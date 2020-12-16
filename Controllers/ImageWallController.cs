using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using AWS_S3_ImageWall.S3Bucket;

namespace AWS_S3_ImageWall.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageWallController : ControllerBase
    {
        private readonly S3BucketFunctions s3BucketFunctions = new S3BucketFunctions();


        // GET: api/Counter
        [HttpGet]
        public async Task<List<S3Object>> GetAllImages()
        {
            var s3ImageList = await s3BucketFunctions.GetAllBucketImages();
            var expandedImageList = new List<S3Object>(); //using same objects to make a larger list for testing
            for (int i = 0; i < 5; i++)
            {
                foreach (var image in s3ImageList)
                {
                    expandedImageList.Add(image);
                }
            }

            //return s3ImageList;
            return expandedImageList;
        }
    }
}
