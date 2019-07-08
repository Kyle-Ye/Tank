using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIplayer : MonoBehaviour
{
    public int tankId;
    private Tank tankInfo;
    // Start is called before the first frame update
    void Start()
    {
        tankInfo = TankManager.Instance.GetTank(tankId);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
