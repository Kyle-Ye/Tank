using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIplayer : MonoBehaviour
{
	public static bool canGet = false;
    

    public int tankId;
    private Tank tankInfo;
    public Slider bloodSlider, oilSlider;
    public Image itemImage;
    private int blood;
    private float oil;
    private bool numberGet = false;
    private bool refreshNumber = false;
    public Sprite DeadSprite;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
		if(canGet)
		{
			if (tankInfo = TankManager.Instance.GetTank(tankId))
                if (tankInfo.IsDead()==false)
                {
                    itemImage.sprite = tankInfo.GetItemSprite();
                    numberGet = true;
                }             
		}

        if (numberGet)
        {
            blood = tankInfo.GetHealth();
            oil = tankInfo.GetOil();
            numberGet = false;
            refreshNumber = true;
        }

        if (refreshNumber)
        {
            bloodSlider.value = blood / 100.0f;
            oilSlider.value = oil / 100.0f;
        }

        if (tankInfo.IsDead())
        {
            itemImage.sprite = DeadSprite;
        }
    }



}
