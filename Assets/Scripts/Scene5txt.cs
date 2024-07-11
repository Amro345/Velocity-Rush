using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Scene5txt : MonoBehaviour
{
    public float letterDelay = 0.1f; // Delay between each letter
    // Reference to the button GameObject
    private TextMeshProUGUI textMeshPro;
    private string fullText;
    private int currentCharacterIndex;
    private AudioSource textAudio;
    private void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        fullText = textMeshPro.text;
        textMeshPro.text = "";
        currentCharacterIndex = 0;


        StartCoroutine(TypeText());
    }

    private IEnumerator TypeText()
    {
        while (currentCharacterIndex < fullText.Length)
        {
            textMeshPro.text += fullText[currentCharacterIndex];
            currentCharacterIndex++;


            yield return new WaitForSeconds(letterDelay);
        }
    }
}