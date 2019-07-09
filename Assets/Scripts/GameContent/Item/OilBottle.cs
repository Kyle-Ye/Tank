using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilBottle : Item
{

    public OilBottle()
    {
        this.sprite = Resources.Load<Sprite>("Textures and Sprites/Widgets/petrolCan");
    }

    public override void Use(Tank tank)
    {
        tank.SetOil(50);//这里写让tank血量恢复的代码
                           //玩家索引是传入的参数
                           //tank.SetOil()之类的
    }
}
