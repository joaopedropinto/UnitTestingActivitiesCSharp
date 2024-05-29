using Amazon.Rekognition.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade15
{
    public interface IRekognitionClientWrapper
    {
        Task<DetectTextResponse> DetectTextAsync(DetectTextRequest request);
    }
}