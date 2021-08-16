using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSystem
{
    public static void SaveData(MenuController menu){
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.uwu";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(menu);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadData(MenuController menu){
        string path = Application.persistentDataPath + "/player.uwu";

        if(File.Exists(path)){
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;

        } else{
            SaveData(menu);
            return null;
        }
    }
}
