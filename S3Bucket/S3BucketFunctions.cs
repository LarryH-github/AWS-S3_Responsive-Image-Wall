using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;

namespace AWS_S3_ImageWall.S3Bucket
{
    public class S3BucketFunctions
    {
        private const string bucketName = "AWS S3 BUCKET NAME"; //name of aws s3 bucket
        private static readonly RegionEndpoint bucketRegion = RegionEndpoint.USEast2; //s3 bucket region
        private static IAmazonS3 client;

        public async Task<List<S3Object>> GetAllBucketImages()
        {
            try
            {
                using (client = new AmazonS3Client("AWS ACCESS KEY ID", "AWS SECRET ACCES KEY", bucketRegion))
                {
                    ListObjectsV2Request request = new ListObjectsV2Request
                    {
                        BucketName = bucketName,
                        MaxKeys = 10
                    };
                    ListObjectsV2Response response = await client.ListObjectsV2Async(request);
                    List<S3Object> s3ObjectList = response.S3Objects;

                    return s3ObjectList;
                }
            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                Console.WriteLine("S3 error occurred. Exception: " + amazonS3Exception.ToString());
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.ToString());
                Console.ReadKey();
            }
            throw new Exception("Error: Unable to get bucket objects");
        }
    }
}
