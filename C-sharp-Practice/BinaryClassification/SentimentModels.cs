// SentimentModels.cs

namespace SentimentAnalysis
{
    public class SentimentData
    {
        public string Text { get; set; }
        public bool Label { get; set; }  // true: positive, false: negative
    }

    public class SentimentPrediction
    {
        public bool PredictedLabel { get; set; }
    }
}
