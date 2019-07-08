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
			yield return new WaitForSeconds(1);
		}
		
	}

}

