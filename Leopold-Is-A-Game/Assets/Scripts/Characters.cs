using UnityEngine;

public class Characters
{
    public static string GetCharacterName(Character chara)
    {
        switch (chara)
        {
            case Character.NARATOR: return "";
            case Character.S_L: return "Sœur de Leopold";
            case Character.NOPE: return "???";
            default: return chara.ToString();
        }
    }

    public static Sprite GetCharacterSprite(Character chara)
    {
        switch (chara)
        {
            case Character.NARATOR: return null;
            default: return Resources.Load<Sprite>("Chibis/" + chara.ToString());
        }
    }
}
