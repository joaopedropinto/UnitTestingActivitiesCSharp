using Amazon.Rekognition;
using Amazon.Rekognition.Model;
using Amazon.Runtime;

namespace Atividade15
{
    public class DetectTextImage
    {
        public string SourceImage { get; set; }
        public IRekognitionClientWrapper RekognitionClient { get; set; }

        public DetectTextImage()
        {
            SourceImage = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data", "img-example-for-aws-task.jpg");
            var credentials = new StoredProfileAWSCredentials("default");
            var rekClient = new AmazonRekognitionClient(
                credentials,
                Amazon.RegionEndpoint.USWest2
            );
            RekognitionClient = new RekognitionClientWrapper(rekClient);
        }

        // Construtor para injeção de dependências (útil para testes)
        public DetectTextImage(string sourceImage, IRekognitionClientWrapper rekognitionClient )
        {
            SourceImage = sourceImage;
            RekognitionClient = rekognitionClient;
        }

        public async Task DetectTextLabelAsync(string resultFilePath)
        {
            try
            {
                var imageBytes = File.ReadAllBytes(SourceImage);
                var sourceImage = new Amazon.Rekognition.Model.Image
                {
                    Bytes = new MemoryStream(imageBytes)
                };

                var textRequest = new DetectTextRequest
                {
                    Image = sourceImage
                };

                var textResponse = await RekognitionClient.DetectTextAsync(textRequest);
                var textCollection = textResponse.TextDetections;

                // Salva o resultado em um arquivo TXT
                SaveResultToTextFile(textCollection, resultFilePath);
            } catch (Exception e)
            {
                // Lança a exceção para que xUnit capture e exiba a mensagem de erro completa
                throw new Exception("Erro durante a execução do teste de detecção de texto", e);
            }
        }

        public void SaveResultToTextFile(List<TextDetection> textCollection, string fileName)
        {
            try
            {
                using (var writer = new StreamWriter(fileName))
                {
                    foreach (var textDetection in textCollection)
                    {
                        writer.WriteLine($"Detected: {textDetection.DetectedText}");
                        writer.WriteLine($"Confidence: {textDetection.Confidence}");
                        writer.WriteLine($"Id: {textDetection.Id}");
                        writer.WriteLine($"ParentId: {textDetection.ParentId}");
                        writer.WriteLine($"Type: {textDetection.Type}");
                        writer.WriteLine();
                    }
                    Console.WriteLine($"Results saved to {fileName}");
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}