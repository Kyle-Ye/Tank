using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
