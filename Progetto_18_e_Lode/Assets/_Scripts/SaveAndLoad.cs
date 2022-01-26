using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

public class SaveAndLoad : MonoBehaviour
{

    public static int level = 0; //intero che indica il livello
    public static List<int> scores = new List<int>();//lista statica di score
    public static int nSaves = 0;


    public static void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        using (FileStream fs = new FileStream("save.bin", FileMode.Create, FileAccess.Write))
        {
            bf.Serialize(fs, level);
            bf.Serialize(fs, Score.GetTotScore());
        }
    }

    public static void Load()
    {
        if (!File.Exists("save.bin"))
            return;

        BinaryFormatter bf = new BinaryFormatter();
        using (FileStream fs = new FileStream("save.bin", FileMode.Open, FileAccess.Read))
        {
            level = (int)bf.Deserialize(fs);
            Score.SetTotScore((int)bf.Deserialize(fs));
        }
    }

    public static void SaveScoreEnd()
    {
        scores.Add(Score.GetTotScore());
        nSaves++;
        BinaryFormatter bf = new BinaryFormatter();

        using (FileStream fs = new FileStream("nSaves.bin", FileMode.Create, FileAccess.Write))
        {
            bf.Serialize(fs, nSaves);
        }

        if (!File.Exists("saveScores.bin"))
        {
            using (FileStream fs = new FileStream("saveScores.bin", FileMode.Create, FileAccess.Write))
            {
                bf.Serialize(fs, Score.GetTotScore());
            }
        }
        else
        {
            using (FileStream fs = new FileStream("saveScores.bin", FileMode.Append, FileAccess.Write))
            {
                bf.Serialize(fs, Score.GetTotScore());
            }
        }
        SceneManager.LoadScene("MainMenu2.0");//cambia scena
    }
    public static void LoadScoresEnd()
    {
        if (!File.Exists("saveScores.bin"))
            return;

        scores.Clear();
        BinaryFormatter bf = new BinaryFormatter();
        using (FileStream fs = new FileStream("saveScores.bin", FileMode.Open, FileAccess.Read))
        {
            for (int i = 0; i < nSaves; i++)
            {
                scores.Add((int)bf.Deserialize(fs));
            }
        }
    }

    public static void Load_nSaves()
    {
        BinaryFormatter bf = new BinaryFormatter();

        using (FileStream fs = new FileStream("nSaves.bin", FileMode.Open, FileAccess.Read))
        {
            nSaves = (int)bf.Deserialize(fs);
        }
    }

    public static void DeleteScores()//cancella salvataggi
    {
        if (File.Exists("saveScores.bin"))
            File.Delete("saveScores.bin");
        if (File.Exists("nSaves.bin"))
            File.Delete("nSaves.bin");
    }
}