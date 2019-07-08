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
					
					break;
				case ItemType.Timer:
					break;
				case ItemType.Shileld:
					break;
				case ItemType.OilBottle:
					break;
			}


			other.gameObject.GetComponent<Tank>().item = item;
		}
	}

}
