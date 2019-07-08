using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wrench : Item
{
    Wrench()
	{
		this.sprite = Resources.Load<Sprite>("扳手图片的路径");
	}

	public override void Use(Tank tank)
	{
		//这里写让tank血量恢复的代码
		//玩家索引是传入的参数
		//tank.SetOil()之类的
	}


}
