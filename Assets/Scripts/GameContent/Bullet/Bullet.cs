using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

	[SerializeField]
	[Header("子弹飞行速度")]
	private float speed = 20.0f;

	[SerializeField]
	[Header("爆炸攻击范围")]
	private float attackRange = 1.0f;


	private Rigidbody m_rigidbody;
	private GameObject damageSource;
	private float damage;

	public static void Emmision(GameObject bullet, GameObject tank, float damage)
	{
		if(!bullet.CompareTag("Bullet"))
		{
			Debug.LogError("试图将一个非bullet的Gameobject当初bullet");
			return;
		}
		if (!tank.CompareTag("Tank"))
		{
			Debug.LogError("试图将一个非tank的Gameobject当初tank");
			return;
		}

		GameObject instance =
			Instantiate<GameObject>(bullet,
									tank.GetComponent<Tank>().EmissionPosition + tank.transform.position,
									tank.transform.rotation
				);

		Bullet bulletScript = instance.transform.GetComponent<Bullet>();
		bulletScript.damageSource = tank;
		bulletScript.damage = damage;

		bulletScript.Emission();

	}


	public virtual void Awake()
	{
		m_rigidbody = GetComponent<Rigidbody>();
	}

	public virtual void Start()
	{

	}

	public virtual void Update()
	{

	}

	private void Emission()
	{
		m_rigidbody.velocity = speed * transform.forward;
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.transform == damageSource.transform)
			return;

		Collider[] colliders;
		colliders = Physics.OverlapSphere(transform.position, 0.5f * attackRange);
		foreach(Collider collider in colliders)
		{
			if (collider.CompareTag("Tank"))
			{
				collider.GetComponent<Tank>().Damage(damage * 0.4f);
			}
		}
		colliders = Physics.OverlapSphere(transform.position, 0.8f * attackRange);
		foreach (Collider collider in colliders)
		{
			if (collider.CompareTag("Tank"))
			{
				collider.GetComponent<Tank>().Damage(damage * 0.3f);
			}
		}
		colliders = Physics.OverlapSphere(transform.position,  1.0f * attackRange);
		foreach (Collider collider in colliders)
		{
			if (collider.CompareTag("Tank"))
			{
				collider.GetComponent<Tank>().Damage(damage * 0.3f);
			}
		}

		Destroy(gameObject);

	}




}
