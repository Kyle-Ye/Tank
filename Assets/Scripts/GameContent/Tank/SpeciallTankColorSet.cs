using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class SpeciallTankColorSet : TankColorSet
{

    public override void SetColor(int playerNumber)
    {
        GameObject renderer = null;
        switch (playerNumber)
        {
            case 1:
                renderer = Resources.Load<GameObject>("Models/Tank/SpecialTank/special_tank_red");
                break;
            case 2:
                renderer = Resources.Load<GameObject>("Models/Tank/SpecialTank/special_tank_yellow");
                break;
            case 3:
                renderer = Resources.Load<GameObject>("Models/Tank/SpecialTank/special_tank_blue");
                break;
            case 4:
                renderer = Resources.Load<GameObject>("Models/Tank/SpecialTank/special_tank_green");
                break;
        }
        renderer = Instantiate<GameObject>(renderer, transform);
        renderer.transform.position = transform.Find("TankRenderers").position;
        renderer.transform.rotation = transform.Find("TankRenderers").rotation;
        renderer.transform.localScale = transform.Find("TankRenderers").localScale;
        Destroy(transform.Find("TankRenderers").gameObject);
        renderer.name = "TankRenderers";

    }
}
