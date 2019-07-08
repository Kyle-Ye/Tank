using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wrench : Item
{
    public Wrench()
	{
		this.sprite = Resources.Load<Sprite>("Textures and Sprites/Widgets/wrench");
	}

	public override void Use(Tank tank)
	{
        tank.SetHealth(30);//这里写让tank血量恢复的代码
		//玩家索引是传入的参数
		//tank.SetOil()之类的
	}


}
