using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public class SaveAndLoad : MonoBehaviour
{

    public static int level = 0; //intero che indica il livello

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
}