using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[Serializable]
public abstract class Item
{

	public Sprite sprite;

	/// <summary>
	/// 使道具生效的方法
	/// </summary>
	/// <param name="tank"></param>使用道具的坦克
	public abstract void Use(Tank tank);

}
