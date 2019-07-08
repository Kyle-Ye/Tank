using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel : MonoBehaviour
{
    static TankModel instance;

    public static TankModel Instance
    {
        get
        {
            if(instance == null)
            {
				instance = new GameObject("TankInfe").AddComponent<TankModel>();
				DontDestroyOnLoad(instance.gameObject);
            }
            return instance;
        }
    }

    public enum tankType
    {
        big,
        middle,
        small
    }

    public static Dictionary<int, TankPrepare> TankList;
    // Start is called before the first frame update
    void Start()
    {
        TankList = new Dictionary<int, TankPrepare>();
        TankPrepare t1 = new TankPrepare(1,tankType.small, KeyCode.W, KeyCode.S,KeyCode.A,KeyCode.D,KeyCode.Z,KeyCode.X);
        TankPrepare t2 = new TankPrepare(2,tankType.small, KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.KeypadEnter, KeyCode.RightShift);
        TankPrepare t3 = new TankPrepare(3,tankType.small, KeyCode.Y, KeyCode.H, KeyCode.G, KeyCode.J, KeyCode.N, KeyCode.M);
        TankPrepare t4 = new TankPrepare(4,tankType.small, KeyCode.Keypad8,KeyCode.Keypad5,KeyCode.Keypad4,KeyCode.Keypad6,KeyCode.Keypad2,KeyCode.Keypad3);
        TankList.Add(t1.tankId, t1);
        TankList.Add(t2.tankId, t2);
        TankList.Add(t3.tankId, t3);
        TankList.Add(t4.tankId, t4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
