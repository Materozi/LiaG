using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class DataSaver : MonoBehaviour
{
    public static void Save(int save)
    {
        PlayerPrefs.SetString("Save"+save, StoryHandler.story.ToString());
        PlayerPrefs.SetInt("Save" + save+ "Situation", StoryHandler.situationIndex);
        PlayerPrefs.SetInt("Save" + save + "Dialog", SituationHandler.dialogIndex);

        //save screenshot from LiaG/tempSC to Application.persistentDataPath/;
        if (File.Exists(Application.persistentDataPath + '/' + save + ".png"))
            File.Delete(Application.persistentDataPath + '/' + save + ".png");

        File.Move("tempSC.png", Application.persistentDataPath+'/'+save+".png");
    }

    public static void Load(int save) 
    {
        //loads tome
        string tome = PlayerPrefs.GetString("Save" + save);
        tome = tome.Substring(0, tome.IndexOf(" "));
        StoryHandler.story = Resources.Load<Story>("Tomes/" + tome);

        //loads situation
        StoryHandler.situationIndex = PlayerPrefs.GetInt("Save" + save + "Situation") - 1;
        
        //loads dialog
        SituationHandler.dialogIndex = PlayerPrefs.GetInt("Save" + save + "Dialog") - 1;
    }

    public static Sprite LoadSprite(string path)
    {
        if (string.IsNullOrEmpty(path)) return null;
        if (File.Exists(path))
        {
            byte[] bytes = File.ReadAllBytes(path);
            Texture2D texture = new Texture2D(1, 1);
            texture.LoadImage(bytes);
            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            return sprite;
        }
        return null;
    }
}
