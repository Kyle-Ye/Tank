using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class TankColorSet : MonoBehaviour
{
	/// <summary>
	/// 根据传入的玩家ID决定坦克的外观
	/// </summary>
	/// <param name="playerNumber"></param>玩家ID
	public abstract void SetColor(int playerNumber);
}

