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
	private float moveOilWear = 2.0f;

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
	[Header("坦克色调材质所挂载的GameObject")]
	private GameObject colorObject;

	[SerializeField]
	[Header("炮口局部坐标")]
	private Vector3 emissionPosition;
	public Vector3 EmissionPosition { get { return emissionPosition; } }

	#endregion

	#region 私有属性

	private static int levelTankNum = 4;		//场上剩余坦克数量

	private int health;						//当前生命值
	private float oil;						//当前油量
	private float speed;					//当前车速
	private float angleSpeed;				//当前角速度
		
	private float speedScale = 1.0f;        //速度缩放倍率(作用举例：加速道具)

	private float cd_timeVal = 0.0f;        //攻击CD计时器
	private float oil_timeVal = 0.0f;       //油量恢复计时器
	private float speed_timeVal = 0.0f;     //加速BUFF计时器
	private float armor_timeVal = 0.0f;     //护盾计时器

	private Rigidbody rb;

	#endregion

	#region 基础对外接口

	public static bool IsGameOver()
	{
		return (levelTankNum <= 1);
	}

	//坦克受到攻击
	public void Damage(float damage)
	{
		//无敌判定
		if (armor_timeVal > 0)
			return;

		//Caculate random damage scale
		float damageScale = Random.Range(0.5f, 1.5f);

		float _damage = damage * damageScale;
		this.health -= (int)(_damage / armor);

		if (transform.name == "TTT")
			Debug.Log(health);

		if (this.health <= 0)
			Die();

	}

    public void SetHealth(int blood)
    {
        health += blood;
        if (health >= 100)
            health = 100;
    }

    public void SetOil(float _oil )
    {
        oil += _oil;
        if (oil >= 100)
            oil = 100;
    }

	/// <summary>
	/// 改变速度scale（实现加速减速）
	/// </summary>
	/// <param name="scale"></param>新的scale
	/// <param name="time"></param>持续时间
	public void ScaleSpeed(float scale,float time)
	{
		speed_timeVal = time;
		speedScale = scale;
	}

	/// <summary>
	/// 提供无敌护盾
	/// </summary>
	/// <param name="time"></param>持续时间 
	public void GenArmor(float time)
	{
		armor_timeVal = time;
	}

	public int GetHealth()
	{
		return health;
	}

	public float GetOil()
	{
		return oil;
	}

	public int GetMaxHealth()
	{
		return maxHealth;
	}

	public float GetMaxOil()
	{
		return maxOil;
	}

	public bool IsDead()
	{
		if (health <= 0)
			return true;
		else
			return false;
	}

	#endregion

	#region 道具相关

	[HideInInspector]
	public Item item;                     //当前玩家身上的道具

	public void UseItem()
	{
		item.Use(this);
		item = null;
	}

	public Sprite GetItemSprite()
	{
		if(item != null)
		{
			return item.sprite;
		}
		else
		{
			return null;
		}
		
	}

	#endregion

	public void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}

	public void Start()
	{
		if (!bullet.CompareTag("Bullet"))
		{
			Debug.LogError("BulletObject不是一个合法的Bullet");
			return;
		}

		health = maxHealth;
		oil = maxOil;

		levelTankNum = 4;
	}

	public void Update()
	{
		Debug.Log(item);
		//油量计算
		if (Mathf.Abs(speed) < 0.5f)
		{
			oil_timeVal += Time.deltaTime;
		}
		else
		{
			oil_timeVal = 0.0f;
			oil -= moveOilWear * Mathf.Abs(speed) * Time.deltaTime;
		}
		if(oil_timeVal > 1.5f)
		{
			if(oil < maxOil)
			{
				oil += oilRegenerateSpeed * maxOil * Time.deltaTime;
			}
			else
			{
				oil = maxOil;
			}
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

		//SpeedScale相关
		if(speed_timeVal > 0)
		{
			speed_timeVal -= Time.deltaTime;
		}
		else
		{
			speed_timeVal = 0;
			speedScale = 1;
		}

		//Armor相关
		if (armor_timeVal > 0)
		{
			armor_timeVal -= Time.deltaTime;
		}
		else
		{
			armor_timeVal = 0;
		}

		//翻车检测
		if (Vector3.Angle(Vector3.down,transform.up) <= 90)
		{
			Die();
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

	//发射炮弹
	public void Attack()
	{
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
		Instantiate<GameObject>(
			Resources.Load<GameObject>("Prefabs/Effects/TankExplosion"),
			transform.position,
			transform.rotation
		);
		oil = 0;
		health = 0;
		gameObject.SetActive(false);

		levelTankNum--;

	}


}
