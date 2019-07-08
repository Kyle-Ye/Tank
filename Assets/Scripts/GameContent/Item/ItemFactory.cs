using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class ItemFactory : MonoBehaviour
{
	[SerializeField]
	[Header("道具列表")]
	private GameObject[] itemObjects;

	[SerializeField]
	[Header("时间间隔")]
	private float timeDuration = 10;

	[SerializeField]
	[Header("最少生成数量")]
	private int minItemNumber = 3;

	[SerializeField]
	[Header("最大生成数量")]
	private int maxItemNumber = 5;

	[SerializeField]
	[Header("道具生成的Y坐标")]
	private float Y = 3;

	void Awake()
	{

	}

	void Start()
	{
		StartCoroutine(GenItemByTime());
	}

	GameObject RandomItem()
	{
		int index = UnityEngine.Random.Range(0, itemObjects.Length);
		return itemObjects[index];
	}

	IEnumerator GenItemByTime()
	{
		while (true)
		{
			float time_duration = UnityEngine.Random.Range(0.8f, 1.2f) * timeDuration;
			yield return new WaitForSeconds(time_duration);
			GameObject[] items = GameObject.FindGameObjectsWithTag("Item");
			foreach (var i in items)
			{
				Destroy(i);
			}
			int num = UnityEngine.Random.Range(minItemNumber, maxItemNumber + 1);

			for (int i = 0; i < num; i++)
			{
				Vector3 pos = Vector3.zero;
				bool flag = true;
				do
				{
					flag = false;
					pos.x = UnityEngine.Random.Range(-50, 50);
					pos.z = UnityEngine.Random.Range(-50, 50);
					pos.y = Y;

					Collider[] colliders = Physics.OverlapSphere(pos, 5);
					foreach (var o in colliders)
					{
						if (!o.gameObject.CompareTag("floor"))
						{
							flag = true;
						}
					}

				} while (flag);

				Instantiate<GameObject>(RandomItem(),pos,Quaternion.Euler(0,0,0)).tag = "Item";

			}

		}
	}
}



