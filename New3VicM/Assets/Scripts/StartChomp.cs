using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartChopm : MonoBehaviour
{
    public void OnStartButtonClick()
    {
        // Load a scene, start a game, or any other behavior
        
        SceneManager.LoadScene("BattleScene");
        Debug.Log("Button Clicked"); 
    }
}
