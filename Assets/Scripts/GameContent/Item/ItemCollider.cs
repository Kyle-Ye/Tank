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
		Timer,
		Missle
	}
	public ItemType itemType;

	//发生碰撞，赋给玩家
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Tank"))
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
				case ItemType.Missle:
					item = new Missle();
					break;
			}

			other.gameObject.GetComponent<Tank>().item = item;
			Destroy(gameObject);
		}
	}

}
