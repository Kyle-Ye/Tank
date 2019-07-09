using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour
{

    private float timeVal = 0;
    private int eventNum;
    private Tank tank1, tank2, tank3,tank4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeVal += Time.deltaTime;
        
        if(timeVal >= 15.0f)
        {
            eventNum = Random.Range(1, 3);
            switch (eventNum)
            {
                case 1: OilBeHalf();break;
                case 2: StartCoroutine(BeOpposite()) ; break;
            }
            
            //事件
            timeVal = 0;
        }
        if (UIplayer.canGet)
        {
            tank1 = TankManager.Instance.GetTank(1);
            tank2 = TankManager.Instance.GetTank(2);
            tank3 = TankManager.Instance.GetTank(3);
            tank4 = TankManager.Instance.GetTank(4);
        }
    }

    public void OilBeHalf()
    {
        //float oil1 = tank1.GetOil();
        tank1.SetOil(-30);
        //float oil2 = tank2.GetOil();
        tank2.SetOil(-30);
        //float oil3 = tank3.GetOil();
        tank3.SetOil(-30);
        //float oil4 = tank4.GetOil();
        tank4.SetOil(-30);
        Debug.Log(1);
    }

    IEnumerator BeOpposite()
    {
        TankUserController.isOpposite = true;
        yield return new WaitForSeconds(5);
        TankUserController.isOpposite = false;
        Debug.Log(2);
    }


}
