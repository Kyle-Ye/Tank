using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wrench : Item
{
    private Tank tankInfo;

    public override void Use(Tank tank)
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        tankInfo = TankManager.Instance.GetTank(1);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
