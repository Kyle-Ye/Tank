﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankManager : MonoBehaviour
{
	private static TankManager instance = null;
	public static TankManager Instance
	{
		get
		{
			return instance;
		}
	}

	private GameObject[] tanks;
	
	public Tank GetTank(int tankID)
	{
		if (tanks[tankID] != null)
			return tanks[tankID].GetComponent<Tank>();
		else
			return null;
	}

	void Awake()
	{
		instance = this;
	}

	void Start()
	{
		Invoke("PlayerStart", 1.0f);
		//随便调用一个方法，用于激活
		TankModel.Instance.ToString();
	}

	public void PlayerStart()
	{
		Transform playerStartTrans = GameObject.FindWithTag("PlayerStart").transform;

		TankPrepare[] tankPrepares = new TankPrepare[5];
		tanks = new GameObject[5];
		for (int i = 1; i <= 4; i++)
		{
			tankPrepares[i] = TankModel.TankList[i];

			GameObject tank = null;
			switch (tankPrepares[i].tanktype)
			{
				case TankModel.tankType.small:
					tank = Resources.Load<GameObject>("Prefabs/Tank/SmallTank");
					break;
				case TankModel.tankType.middle:
					tank = Resources.Load<GameObject>("Prefabs/Tank/BigTank");
					break;
				case TankModel.tankType.big:
					tank = Resources.Load<GameObject>("Prefabs/Tank/SpecialTank");
					break;
			}

			tanks[i] = Instantiate<GameObject>(tank, playerStartTrans.Find("PlayerStart" + i).position, playerStartTrans.Find("PlayerStart" + i).rotation);
			TankUserController userController = tanks[i].AddComponent<TankUserController>();
			userController.key_forward = tankPrepares[i].key_Up;
			userController.key_back = tankPrepares[i].key_Down;
			userController.key_left = tankPrepares[i].key_Left;
			userController.key_right = tankPrepares[i].key_Right;
			userController.key_attack = tankPrepares[i].key_Attack;
			userController.key_use = tankPrepares[i].key_Use;

			tanks[i].GetComponent<TankColorSet>().SetColor(i);

		}

		UIplayer.canGet = true;
	}

	void OnDrawGizmos()
	{
		//x red
		Gizmos.color = Color.red;
		for(int i = 1; i <= 4; i++)
		{
			Transform trans = transform.Find("PlayerStart" + i);
			Gizmos.DrawLine(trans.position, trans.position + 10 * trans.right);
		}

		//y green
		Gizmos.color = Color.green;
		for (int i = 1; i <= 4; i++)
		{
			Transform trans = transform.Find("PlayerStart" + i);
			Gizmos.DrawLine(trans.position, trans.position + 10 * trans.up);
		}


		//z blue
		Gizmos.color = Color.blue;
		for (int i = 1; i <= 4; i++)
		{
			Transform trans = transform.Find("PlayerStart" + i);
			Gizmos.DrawLine(trans.position, trans.position + 10 * trans.forward);
		}
	}


}
