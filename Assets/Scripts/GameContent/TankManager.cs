using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankManager : MonoBehaviour
{
	private static GameObject[] tanks; 

	private static TankManager instance = null;
	public static TankManager Instance
	{
		get
		{
			if(instance == null)
			{
				instance = new GameObject("TankManager").AddComponent<TankManager>();
			}
			return instance;
		}
	}

	public static void PlayerStart()
	{
		Transform playerStartTrans = GameObject.FindWithTag("PlayerStart").transform;

		TankPrepare[] tankPrepares = new TankPrepare[5];
		tanks = new GameObject[5];
		for (int i = 1; i <= 4; i++)
		{
			tankPrepares[i] = TankModel.Instance.TankList[i];

			GameObject tank = null;
			switch (tankPrepares[i].tanktype)
			{
				case TankModel.tankType.small:
					tank = Resources.Load<GameObject>("Prefabs/Tank/SmallTank");
					break;
				case TankModel.tankType.middle:
					tank = Resources.Load<GameObject>("");
					break;
				case TankModel.tankType.big:
					tank = Resources.Load<GameObject>("");
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


	}
}
