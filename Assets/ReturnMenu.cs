using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnMenu : MonoBehaviour
{
    public GameObject EndCanvas;
    public void Back()    
    {
        Debug.Log("cnm");
        Application.Quit();
    }

    public void Update()
    {
        if(Tank.IsGameOver())
        {
            EndCanvas.SetActive(true);
        }
        else
        {
            EndCanvas.SetActive(false);
        }
    }
}
