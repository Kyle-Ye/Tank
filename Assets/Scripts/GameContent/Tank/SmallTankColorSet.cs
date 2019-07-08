using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SmallTankColorSet : TankColorSet
{

	public override void SetColor(int playerNumber)
	{
		Color color = Color.red;
		switch (playerNumber)
		{
			case 1:
				color = Color.red;
				break;
			case 2:
				color = Color.yellow;
				break;
			case 3:
				color = Color.blue;
				break;
			case 4:
				color = Color.green;
				break;
		}
		transform.Find("TankRenderers/TankChassis").GetComponent<MeshRenderer>().material.color = color;
		transform.Find("TankRenderers/TankTracksLeft").GetComponent<MeshRenderer>().material.color = color;
		transform.Find("TankRenderers/TankTracksRight").GetComponent<MeshRenderer>().material.color = color;
		transform.Find("TankRenderers/TankTurret").GetComponent<MeshRenderer>().material.color = color;
	}
}

