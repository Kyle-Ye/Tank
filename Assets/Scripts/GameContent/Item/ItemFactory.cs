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
	private float timeDuration;

	[SerializeField]
	[Header("最少生成数量范围")]
	private int minItemNumber;
	
	[SerializeField]
	[Header("最大生成数量范围")]
	private int maxItemNumber;

	void Awake()
	{

	}

	void Start()
	{
		StartCoroutine(GenItemByTime());
	}

	IEnumerator GenItemByTime()
	{
		while(true)
		{
			float time_duration = UnityEngine.Random.Range(0.8f, 1.2f);
			yield return new WaitForSeconds(time_duration);

			GameObject[] items = GameObject.FindGameObjectsWithTag("Item");
			foreach(var i in items)
			{
				Destroy(i);
			}

			int num = UnityEngine.Random.Range(minItemNumber, maxItemNumber + 1);

			for(int i = 0; i < num; i++)
			{

			}

		}
		
	}

}

