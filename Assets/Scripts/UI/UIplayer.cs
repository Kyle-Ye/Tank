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
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canGet)
        {
            tankInfo = TankManager.Instance.GetTank(tankId);
//            canGet = false;
            numberGet = true;
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
            bloodSlider.value = blood / 100;
            oilSlider.value = oil / 100.0f;
        }
       
    }



}
