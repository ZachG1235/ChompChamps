using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartCamScript : MonoBehaviour
{
    public void StartCam()
    {
        SceneManager.LoadScene("CameraScreen");
    }
}
