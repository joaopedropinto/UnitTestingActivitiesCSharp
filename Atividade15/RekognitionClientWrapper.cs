using Amazon.Rekognition.Model;
using Amazon.Rekognition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade15
{
    public class RekognitionClientWrapper : IRekognitionClientWrapper
    {
        private readonly AmazonRekognitionClient _rekognitionClient;

        public RekognitionClientWrapper(AmazonRekognitionClient rekognitionClient)
        {
            _rekognitionClient = rekognitionClient;
        }

        public async Task<DetectTextResponse> DetectTextAsync(DetectTextRequest request)
        {
            return await _rekognitionClient.DetectTextAsync(request);
        }
    }
}