using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Tank : MonoBehaviour
{
	#region Editor面板设置属性

	[SerializeField]
	[Header("最大生命值")]
	private int maxHealth = 100;

	[SerializeField]
	[Header("最大油量")]
	private float maxOil = 100.0f;

	[SerializeField]
	[Header("坦克护甲")]
	private float armor = 1.0f;

	[SerializeField]
	[Header("默认最大移动速度")]
	private float maxSpeed = 5.0f;

	[SerializeField]
	[Header("默认最大转向速度")]
	private float maxAngleSpeed = 360.0f;

	[SerializeField]
	[Header("炮弹发射冷却时间")]
	private float attackCD = 3.0f;

	#endregion

	#region 私有属性

	private int health;						//当前生命值
	private float oil;						//当前油量
	private float speed;					//当前车速
	private float angleSpeed;				//当前角速度
		
	private float speedScale = 1.0f;		//速度缩放倍率(作用举例：加速道具)

	#endregion


	public void Awake()
	{

	}

	public void Start()
	{

	}

	public void Update()
	{
		//Move
		transform.Translate(Vector3.forward * speed * speedScale * Time.deltaTime);
		speed = speed * 0.95f;
		transform.Rotate(Vector3.up * angleSpeed * speedScale * Time.deltaTime);
		angleSpeed = angleSpeed * 0.9f;

		//Test
		//if(Input.GetKey(KeyCode.W))
		//{
		//	GoForward();
		//}
		//if (Input.GetKey(KeyCode.S))
		//{
		//	GoBack();
		//}
		//if (Input.GetKey(KeyCode.A))
		//{
		//	TurnLeft();
		//}
		//if (Input.GetKey(KeyCode.D))
		//{
		//	TurnRight();
		//}

	}

	//前进方法
	public void GoForward()
	{
		speed += (maxSpeed - speed) * 0.1f;
	}

	//后退方法
	public void GoBack()
	{
		speed += (-0.5f * maxSpeed - speed) * 0.1f;
	}

	//左转向
	public void TurnLeft()
	{
		angleSpeed = (-maxAngleSpeed - speed) * 0.2f;
	}

	//右转向
	public void TurnRight()
	{
		angleSpeed = (maxAngleSpeed - speed) * 0.2f;	
	}



}
