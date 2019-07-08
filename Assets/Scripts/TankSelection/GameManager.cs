using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    static GameManager instance;

    public GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameManager();
            }
            return instance;
        }
    }
    public int tankModel;
    public static int _tankId;
    public static TankModel.tankType tanktype;


    public void loadMain()
    {
        SceneManager.LoadScene(1);
    }
}
