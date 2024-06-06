using Amazon.Rekognition;
using Amazon.Rekognition.Model;
using Atividade15;
using NSubstitute;
using Xunit;

namespace Atividade15.Tests;

public class DetectTextImage
{
    [Fact]
    public async Task DetectTextLabelAsync_ShouldCallDetectTextAsyncSucesfully_AndSaveResults()
    {
        var rekognitionClient = Substitute.For<IRekognitionClientWrapper>();
        var detectTextResponse = new DetectTextResponse
        {
            TextDetections = new List<TextDetection>
                {
                    new TextDetection { DetectedText = "Text Example", Confidence = 98.0f, Id = 1, ParentId = 0, Type = TextTypes.WORD }
                }
        };

        rekognitionClient.DetectTextAsync(Arg.Any<DetectTextRequest>()).Returns(Task.FromResult(detectTextResponse));

        var sourceImage = "test-image.jpg";
        var resultFilePath = "test-result.txt";

        File.WriteAllText(sourceImage, "fake image content");

        var detectTextImage = new DetectTextImage(sourceImage, rekognitionClient);

        await detectTextImage.DetectTextLabelAsync(resultFilePath);

        await rekognitionClient.Received(1).DetectTextAsync(Arg.Any<DetectTextRequest>());

        Assert.True(File.Exists(resultFilePath), "Erro ao gerar arquivo.");

        var fileContent = File.ReadAllText(resultFilePath);
        Assert.Contains("Detected: Text", fileContent);
        Assert.Contains("Confidence: 98", fileContent);
        Assert.Contains("Id: 1", fileContent);
        Assert.Contains("ParentId: 0", fileContent);
        Assert.Contains("Type: WORD", fileContent);

        if (File.Exists(sourceImage))
        {
            File.Delete(sourceImage);
        }
        if (File.Exists(resultFilePath))
        {
            File.Delete(resultFilePath);
        }
    }
}