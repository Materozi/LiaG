using UnityEngine;

public enum CharaState 
{
    IDLE,
    TALKING,
    HAPPY,
    SAD,
    SURPRISED,

    NONE,
};

public enum Character 
{
    IVAN,
    LEOPOLD,
    SAMY,
    NARATOR,
};

public enum CharaSide 
{
    LEFT,
    RIGHT,
    HIDDEN,
};

[CreateAssetMenu(fileName = "Dialog", menuName = "ScriptableObjects/ScriptableDialog", order = 1)]
public class Dialog : ScriptableObject
{
    public CharaState charaState;
    public CharaSide  charaSide;
    public Character  chara;
    public string     text;
};