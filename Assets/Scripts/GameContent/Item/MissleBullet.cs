using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MissleBullet : MonoBehaviour
{
	[SerializeField]
	[Header("爆炸攻击范围")]
	private float attackRange = 1.0f;

	private GameObject damageSource;
	private float damage;

	private NavMeshAgent agent;

	private static GameObject bulletPrefab;

	public static void Emmision(GameObject tank, float damage)
	{
		if(bulletPrefab == null)
		{
			bulletPrefab = Resources.Load<GameObject>("Prefabs/Item/MissleBullet");
		}

		//发射坐标
		Vector3 ePos = Vector3.Scale(tank.GetComponent<Tank>().EmissionPosition, tank.transform.localScale);
		ePos = tank.transform.rotation * ePos;

		GameObject instance =
			Instantiate<GameObject>(bulletPrefab,
									ePos + tank.transform.position,
									tank.transform.rotation
				);

	}

	void Awake()
	{
		agent = GetComponent<NavMeshAgent>();
	}

	void Update()
	{
		GameObject[] tanks = GameObject.FindGameObjectsWithTag("Tank");
		GameObject targetTank = null;
		foreach(var t in tanks)
		{
			if(t != damageSource)
			{
				if (targetTank == null)
				{
					targetTank = t;
				}
				else
				{
					if(Vector3.Distance(t.transform.position, transform.position) 
						< Vector3.Distance(targetTank.transform.position, transform.position))
					{
						targetTank = t;
					}
				}
					
			}
		}

		agent.SetDestination(targetTank.transform.position);

	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.transform == damageSource.transform)
		{
			return;
		}

		Collider[] colliders;
		colliders = Physics.OverlapSphere(transform.position, 0.5f * attackRange);
		foreach (Collider collider in colliders)
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
		colliders = Physics.OverlapSphere(transform.position, 1.0f * attackRange);
		foreach (Collider collider in colliders)
		{
			if (collider.CompareTag("Tank"))
			{
				collider.GetComponent<Tank>().Damage(damage * 0.3f);
			}
		}

		Instantiate<GameObject>(
				Resources.Load<GameObject>("Prefabs/Effects/ShellExplosion"),
				transform.position,
				transform.rotation
			);

		Destroy(gameObject);

	}




}
