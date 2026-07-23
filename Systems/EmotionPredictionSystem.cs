using LivingStoryEngine.Characters;
using Microsoft.ML;
using Microsoft.ML.Data;

namespace LivingStoryEngine.Systems
{
    public class EmotionInput
    {
        [LoadColumn(0)] public float Mood;
        [LoadColumn(1)] public float Stress;
        [LoadColumn(2)] public float Energy;
        [LoadColumn(3)] public float Happiness;
    }

    public class EmotionOutput
    {
        [ColumnName("Score")] public float PredictedMood;
    }

    /// <summary>
    /// Offline ML-based mood prediction using ML.NET.
    /// </summary>
    public static class EmotionPredictionSystem
    {
        private static MLContext mlContext = new();
        private static ITransformer? model;

        public static void TrainModel(string dataPath)
        {
            // dataPath: CSV with columns Mood,Stress,Energy,Happiness
            var data = mlContext.Data.LoadFromTextFile<EmotionInput>(
                dataPath, hasHeader: true, separatorChar: ',');

            var pipeline = mlContext.Transforms.Concatenate(
                    "Features", nameof(EmotionInput.Stress),
                               nameof(EmotionInput.Energy),
                               nameof(EmotionInput.Happiness))
                .Append(mlContext.Regression.Trainers.FastTree());

            model = pipeline.Fit(data);
        }

        public static void PredictNextMood(Character c)
        {
            if (model == null)
                return; // model not trained yet

            var engine = mlContext.Model.CreatePredictionEngine<EmotionInput, EmotionOutput>(model);

            var input = new EmotionInput
            {
                Mood = c.Mood.Value,
                Stress = c.Stress.Value,
                Energy = c.Energy,
                Happiness = c.Happiness
            };

            var prediction = engine.Predict(input);

            c.Mood.Value = (int)prediction.PredictedMood;
            c.Mood.Value = Math.Clamp(c.Mood.Value, 0, 100);
        }
    }
}
