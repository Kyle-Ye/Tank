using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missle : Item
{
	public Missle() 
	{
		this.sprite = Resources.Load<Sprite>("Textures and Sprites/Widgets/missle");
	}

	public override void Use(Tank tank)
	{
		MissleBullet.Emmision(tank.gameObject, 40);
	}
}
