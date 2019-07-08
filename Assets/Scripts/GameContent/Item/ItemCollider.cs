using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class ItemCollider : MonoBehaviour
{
	public enum ItemType
	{
		Wrench,
		OilBottle,
		Shileld,
		Timer
	}
	ItemType itemType;

	//发生碰撞，赋给玩家
	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			Item item = null;
			switch (itemType)
			{
				case ItemType.Wrench:
					item = new Wrench();
					break;
				case ItemType.Timer:
					item = new Timer();
					break;
				case ItemType.Shileld:
					item = new Shileld();
					break;
				case ItemType.OilBottle:
					item = new OilBottle();
					break;
			}

			other.gameObject.GetComponent<Tank>().item = item;
			Destroy(gameObject);
		}
	}

}
