using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonTransition : MonoBehaviour
{
    public string sceneName; 

    public void OnButtonPressed()
    {
        SceneManager.LoadScene(sceneName);
    }
}
