using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoad
{
    public static void Save() {
        Game game = new Game();
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/savedGame.gd");
        bf.Serialize(file, game);
        file.Close();
    }


    public static void Load() {
        if (File.Exists(Application.persistentDataPath + "/savedGame.gd")) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedGame.gd", FileMode.Open);
            Game game = (Game)bf.Deserialize(file);
            game.Load();
            file.Close();
        }
    }
}
