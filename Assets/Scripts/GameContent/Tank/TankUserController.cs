using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankUserController : MonoBehaviour
{
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
		}
	}

	void FixedUpdate()
	{
		if (Input.GetKey(key_forward))
		{
			tank.GoForward();
		}
		if (Input.GetKey(key_back))
		{
			tank.GoBack();
		}
		if (Input.GetKey(key_left))
		{
			tank.TurnLeft();
		}
		if (Input.GetKey(key_right))
		{
			tank.TurnRight();
		}
	}

}
