using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class GameStart : MonoBehaviour
{
	void Awake()
	{
		//随便调用一个方法激活单例
		TankModel.Instance.ToString();
	}
}

