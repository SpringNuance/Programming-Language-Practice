
using System;
using System.Linq;
using Microsoft.ML;
using Microsoft.ML.Data;
using SentimentAnalysis;
class Program
{
    static void Main(string[] args)
    {
        var context = new MLContext();

        // Example data
        var data = new[]
        {
            new SentimentData { Text = "I love ML.NET", Label = true },
            new SentimentData { Text = "This is amazing", Label = true },
            new SentimentData { Text = "Disappointing results", Label = false },
            new SentimentData { Text = "Not a fan of this", Label = false }
        };

        var trainData = context.Data.LoadFromEnumerable(data);

        // Define training pipeline
        var pipeline = context.Transforms.Text.FeaturizeText("Features", "Text")
            .Append(context.BinaryClassification.Trainers.SdcaLogisticRegression(labelColumnName: "Label", featureColumnName: "Features"));

        // Train the model
        var model = pipeline.Fit(trainData);

        // Test the model
        var predictionEngine = context.Model.CreatePredictionEngine<SentimentData, SentimentPrediction>(model);
        var sampleStatement = new SentimentData { Text = "I really enjoy using ML.NET" };
        var prediction = predictionEngine.Predict(sampleStatement);

        Console.WriteLine($"The sentiment of the statement '{sampleStatement.Text}' is {(prediction.PredictedLabel ? "Positive" : "Negative")}");
    }
}
