using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextWrittingEffect : MonoBehaviour
{
    public string fullText;

    public float timePerCharacter = .4f;
    public float timeUntilNextCharacter = 0f;

    public int textIndex = 0;
    public TMPro.TextMeshProUGUI textField;

    public bool isWriting = false;

    void Start()
    {
        textField = GetComponent<TextMeshProUGUI>();
    }

    public void InitializeWriting(string text)
    {
        fullText = text;
        textField.text = "";
        textIndex = 0;
        isWriting = true;
        StartCoroutine(ProcessWriting());
    }

    public void DisplayFullText() 
    {
        StopAllCoroutines(); 
        isWriting = false;
        textField.text = fullText;
    }

    IEnumerator ProcessWriting() 
    {
        while (textIndex < fullText.Length) 
        {
            while (timeUntilNextCharacter < timePerCharacter) 
            {
                timeUntilNextCharacter += Time.deltaTime;
                yield return null;
            }

            timeUntilNextCharacter = 0f;
            if (textIndex < fullText.Length) 
                textField.text += fullText[textIndex];
            textIndex++;
        }
        isWriting = false;
    }
}
