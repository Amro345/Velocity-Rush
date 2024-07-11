using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    
        public string startSceneName = "start";

        public void OnButtonPressed()
        {
            SceneManager.LoadScene(startSceneName);
        }
    
}