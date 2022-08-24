using UnityEngine;

public enum CharaState 
{
    IDLE,
    HAPPY,
    SCARED,
    SAD,
    ANGRY,
    LOVELY,
    SADIC,
    BORED,
};

public enum Character 
{
    IVAN,
    LEOPOLD,
    SAMY,
    NARATOR,
    CAMILLE,
    ROMAIN,
    BAPTISTE,
    AMBRA,
    NOPE,
    S_L,
    BAZINE,
    ALEXIS,
    MATEO,
    XYDOE,
    MAELLE,
    YANN,
    ADEN,
    SOPHIANE,
    AUGUSTIN,
    ANTOINE,
    MATHIS,
    ABDALLAH,
    ALAN,
    AMBRE,
    ESTEBAN,
    FARAH,
    GENIE,
    GUILLAUME,
    HAPE,
    JONATHAN,
    JUAN,
    KENY,
    KIKI,
    LEOPOLD_HAT,
    LUDIVINE,
    PAULINE,
    RECEPTIONNISTE,
    SOLDAT,
    SOLDAT_MAROC,
    THIBAULT,
    TV,
    VALENTIN,
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
    public AudioClip  audioEffect;
    public bool       hasVisualEffect;
    public bool       cutAmbiant;
};