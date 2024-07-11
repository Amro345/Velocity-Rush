using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Texteffect : MonoBehaviour
{
   
    public float letterDelay = 0.1f; // Delay between each letter
    public GameObject button; // Reference to the button GameObject
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

        // Show the button after typewriter effect finishes
        button.SetActive(true);

       
    }
    public void OnButtonPressed()
    {
        // Transition to another scene when the button is pressed
        SceneManager.LoadScene("Prototype 3");
    }
}