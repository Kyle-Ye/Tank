using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class ItemCollider : MonoBehaviour
{
	[SerializeField]
	public Item item;
	

	//发生碰撞，赋给玩家
	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			other.gameObject.GetComponent<Tank>().item = item;
		}
	}

}
