using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SmallTankColorSet : TankColorSet
{
	public override void SetColor(Color color)
	{
		transform.Find("TankRenderers/TankChassis").GetComponent<MeshRenderer>().material.color = color;
		transform.Find("TankRenderers/TankTracksLeft").GetComponent<MeshRenderer>().material.color = color;
		transform.Find("TankRenderers/TankTracksRight").GetComponent<MeshRenderer>().material.color = color;
		transform.Find("TankRenderers/TankTurret").GetComponent<MeshRenderer>().material.color = color;
	}
}

