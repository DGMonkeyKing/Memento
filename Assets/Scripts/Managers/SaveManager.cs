using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using DGMKCollections.Rankings;

public static class SaveManager
{
    private static string filePath = "/ranking.save";
    public static void Save(Ranking entry)
    {
        RankingData data = new RankingData(entry);
        
        string dataPath = Application.persistentDataPath + filePath;
        FileStream fileStream = new FileStream(dataPath, FileMode.OpenOrCreate);
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        binaryFormatter.Serialize(fileStream, data);
        fileStream.Close();
    }

    public static RankingData Load()
    {
        string dataPath = Application.persistentDataPath + filePath;
        
        if(File.Exists(dataPath))
        {
            FileStream fileStream = new FileStream(dataPath, FileMode.Open);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            RankingData data = (RankingData) binaryFormatter.Deserialize(fileStream);
            fileStream.Close();
            return data;
        }
        else
        {
            Debug.LogWarning("No se encontró el archivo " + dataPath);
            return null;
        }
    }
}
