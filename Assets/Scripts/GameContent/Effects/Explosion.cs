using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Explosion : MonoBehaviour
{
	float timeVal = 0;

	void Update()
	{
		timeVal += Time.deltaTime;
		if (timeVal > 3)
			Destroy(gameObject);
	}
}

