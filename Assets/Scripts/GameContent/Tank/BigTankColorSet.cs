using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class BigTankColorSet : TankColorSet
{

	public override void SetColor(int playerNumber)
	{
		GameObject renderer = null;
		switch (playerNumber)
		{
			case 1:
				renderer = Resources.Load<GameObject>("Models/Tank/BigTank/tank_red");
				break;
			case 2:
				renderer = Resources.Load<GameObject>("Models/Tank/BigTank/tank_yellow");
				break;
			case 3:
				renderer = Resources.Load<GameObject>("Models/Tank/BigTank/tank_blue");
				break;
			case 4:
				renderer = Resources.Load<GameObject>("Models/Tank/BigTank/tank_green");
				break;
		}
		Destroy(transform.Find("TankRenderers").gameObject);
		Instantiate<GameObject>(renderer, transform).name = "TankRenderers";
		
	}
}
