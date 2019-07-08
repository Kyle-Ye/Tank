using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shileld : Item
{
    public Shileld()
    {
        this.sprite = Resources.Load<Sprite>("Textures and Sprites/Widgets/shileld");
    }

    public override void Use(Tank tank)
    {
        tank.GenArmor(3.0f);//这里写让tank血量恢复的代码
                        //玩家索引是传入的参数
                        //tank.SetOil()之类的
    }
}
