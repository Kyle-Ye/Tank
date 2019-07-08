using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankUserController : MonoBehaviour
{
	public static bool isOpposite = false;

	public KeyCode key_forward;
	public KeyCode key_back;
	public KeyCode key_left;
	public KeyCode key_right;
	public KeyCode key_attack;
	public KeyCode key_use;

	Tank tank;

	void Awake()
	{
		tank = GetComponent<Tank>();
	}
	   
	void Update()
	{
		if (Input.GetKeyDown(key_attack))
		{
			tank.Attack();
		}
		if(Input.GetKeyDown(key_use))
		{
			//UnFinished function
			tank.UseItem();
		}
	}

	void FixedUpdate()
	{
		if (Input.GetKey(key_forward))
		{
            if (!isOpposite)
                tank.GoForward();
            else
                tank.GoBack();
        }
		if (Input.GetKey(key_back))
		{
            if (!isOpposite)
                tank.GoBack();
            else
                tank.GoForward();
        }
		if (Input.GetKey(key_left))
		{
			if (!isOpposite)
				tank.TurnLeft();
			else
				tank.TurnRight();
		}
		if (Input.GetKey(key_right))
		{
			if (!isOpposite)
				tank.TurnRight();
			else
				tank.TurnLeft();
		}
	}

}
