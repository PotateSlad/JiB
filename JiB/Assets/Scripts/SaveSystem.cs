//Referenced from https://www.youtube.com/watch?v=XOjd_qU2Ido
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    public static void SaveValues(Creature creature)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/savedData.coms437";
        FileStream stream = new FileStream(path, FileMode.Create);

        CreatureData data = new CreatureData(creature);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static CreatureData LoadValues()
    {
        string path = Application.persistentDataPath + "/savedData.coms437";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            CreatureData data = formatter.Deserialize(stream) as CreatureData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
//End Reference