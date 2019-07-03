using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
	#region Editor面板设置属性

	[SerializeField]
	[Header("最大生命值")]
	private int maxHealth = 100;

	[SerializeField]
	[Header("最大油量")]
	private float maxOil = 100.0f;

	[SerializeField]
	[Header("移动油耗")]
	private float moveOilWear = 4.0f;

	[SerializeField]
	[Header("攻击油耗")]
	private float attackOilWear = 20.0f;

	[SerializeField]
	[Header("油量恢复速度")]
	private float oilRegenerateSpeed = 0.2f;

	[SerializeField]
	[Header("坦克护甲")]
	private float armor = 1.0f;

	[SerializeField]
	[Header("坦克伤害")]
	private float damage = 50.0f;

	[SerializeField]
	[Header("默认最大移动速度")]
	private float maxSpeed = 5.0f;

	[SerializeField]
	[Header("默认最大转向速度")]
	private float maxAngleSpeed = 360.0f;

	[SerializeField]
	[Header("炮弹发射冷却时间")]
	private float attackCD = 3.0f;

	[SerializeField]
	[Header("炮弹")]
	private GameObject bullet;

	[SerializeField]
	[Header("炮口局部坐标")]
	private Vector3 emissionPosition;
	public Vector3 EmissionPosition { get { return emissionPosition; } }

	#endregion

	#region 私有属性

	private int health;						//当前生命值
	private float oil;						//当前油量
	private float speed;					//当前车速
	private float angleSpeed;				//当前角速度
		
	private float speedScale = 1.0f;        //速度缩放倍率(作用举例：加速道具)

	private float cd_timeVal = 0.0f;        //攻击CD计时器
	private float oil_timeVal = 0.0f;		//油量恢复计时器

	#endregion


	public void Awake()
	{

	}

	public void Start()
	{
		if (!bullet.CompareTag("Bullet"))
		{
			Debug.LogError("BulletObject不是一个合法的Bullet");
			return;
		}

		health = maxHealth;
	}

	public void Update()
	{
		//油量计算
		if (speed < 0.5f)
		{
			oil_timeVal += Time.deltaTime;
		}
		else
		{
			oil_timeVal = 0.0f;
			oil -= moveOilWear * speed * Time.deltaTime;
		}
		if(oil_timeVal > 1.5f)
		{
			oil += oilRegenerateSpeed * maxOil * Time.deltaTime;
		}

		//Attack 相关
		if(cd_timeVal > 0)
		{
			cd_timeVal -= Time.deltaTime;
		}
		else
		{
			cd_timeVal = 0.0f;
		}

	}

	public void FixedUpdate()
	{
		//Move
		transform.Translate(Vector3.forward * speed * speedScale * Time.deltaTime);
		speed = speed * 0.95f;
		transform.Rotate(Vector3.up * angleSpeed * speedScale * Time.deltaTime);
		angleSpeed = angleSpeed * 0.9f;

	}

	//前进方法
	public void GoForward()
	{
		if (oil <= 0)
		{
			return;
		}

		speed += (maxSpeed - speed) * 0.1f;

		oil -= Mathf.Abs(speed) * moveOilWear * Time.deltaTime;
		if(oil < 0)
		{
			oil = 0;
		}
	}

	//后退方法
	public void GoBack()
	{
		if (oil <= 0)
		{
			return;
		}

		speed += (-0.5f * maxSpeed - speed) * 0.1f;

		oil -= Mathf.Abs(speed) * moveOilWear * Time.deltaTime;
		if (oil < 0)
		{
			oil = 0;
		}
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

	//坦克受到攻击
	public void Damage(float damage)
	{
		//Caculate random damage scale
		float damageScale = Random.Range(-1.0f, 1.0f);
		damageScale = damageScale * damageScale * damageScale;

		float _damage = damage * damageScale;
		this.health -= (int)(_damage / armor);

		if (this.health <= 0)
			Die();

	}

	//发射炮弹
	public void Attack()
	{
		//Caculate oil
		if(oil - attackOilWear > 0)
		{
			oil -= attackOilWear;
		}
		else
		{
			return;
		}

		//Apply CDs
		if(cd_timeVal > 1e-6)
		{
			return;
		}
		else
		{
			cd_timeVal = attackCD;
		}

		//Aenerate attack
		Bullet.Emmision(bullet, gameObject, damage);
	}

	private void Die()
	{
		Destroy(gameObject);
	}


}
