namespace Assets.Scripts.Core.Management.DataManagement
{
    using System.IO;
    using UnityEngine;
    
    public static class PlayerDataJSONParser
    {
        public static int GetBestScore()
        {
            BestScoreData bestScore = GetBestScoreDataFromJSON();
            return bestScore.Points;
        }

        public static void SaveBestscore(int totalScore) 
        {
            BestScoreData bestScore = GetBestScoreDataFromJSON();
            if(bestScore.Points < totalScore)
                OveverwriteBestScorePoints(bestScore, totalScore);
        }

        private static BestScoreData GetBestScoreDataFromJSON()
        {
            string path = GetJSONFilePath();
            string json = File.ReadAllText(path);
            return JsonUtility.FromJson<BestScoreData>(json);
        }

        private static void OveverwriteBestScorePoints(BestScoreData bestScoreData, int totalPoints)
        {
            bestScoreData.Points = totalPoints;
            string path = GetJSONFilePath();
            string updatedJson = JsonUtility.ToJson(bestScoreData, true);
            File.WriteAllText(path, updatedJson);
        }

        private static string GetJSONFilePath()
        {
            string fileName = "bestscore.json";
            string path = Path.Combine(Application.persistentDataPath, fileName);
            
            if (!File.Exists(path))
                CreateJSONFile(path);
            
            return path;
        }

        private static void CreateJSONFile(string path)
        {
            string json = JsonUtility.ToJson(CreateNewData(), true);
            File.WriteAllText(path, json);
        }

        private static BestScoreData CreateNewData(int bestScore = 0)
        {
            return new BestScoreData() { Points = bestScore };
        }

    }
}