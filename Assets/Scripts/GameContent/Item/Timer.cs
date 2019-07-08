using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : Item
{
    public Timer()
    {
        this.sprite = Resources.Load<Sprite>("Textures and Sprites/Widgets/timer_mental");
    }

    public override void Use(Tank tank)
    {
        tank.ScaleSpeed(2.0f,5.0f);//这里写让tank血量恢复的代码
                            //玩家索引是传入的参数
                            //tank.SetOil()之类的
    }
}
