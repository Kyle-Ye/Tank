using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Control_ScrollFlow_Item : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler
{
    private UI_Control_ScrollFlow parent;
    [HideInInspector]
    public RectTransform rect;
    public Image img;
    public bool isSelected = false;
    private bool keyDownStatus;
    private int keyDownCount;
    private float lastTime;
    private float currentTime;
    bool canBeSelected = false;
    public int function;
    private GameObject ButtonChangePanel;
    private GameObject StartGamePanel;
    private GameObject IntroductionPanel;
    public GameObject Title;

    public void Start()
    {
        GameObject root = GameObject.Find("Canvas");
        ButtonChangePanel = root.transform.Find("ButtonChange").gameObject;
        StartGamePanel = root.transform.Find("TankSelection").gameObject;
        IntroductionPanel = root.transform.Find("Introduction").gameObject;
    }

    public float v=0;
    private Vector3 p, s;
    /// <summary>
    /// 缩放值
    /// </summary>
    public float sv;
   // public float index = 0,index_value;
    private Color color;

    public void Init(UI_Control_ScrollFlow _parent)
    {
        rect =this. GetComponent<RectTransform>();
        img = this.GetComponent<Image>();
        parent = _parent;
        color = img.color;
    }

    public void Drag(float value)
    {
        v += value;
        p=rect.localPosition;
        p.x=parent.GetPosition(v);
        rect.localPosition = p;

        color.a = parent.GetApa(v);
        img.color = color;
        sv = parent.GetScale(v);
        s.x = sv;
        s.y = sv;
        s.z=1;
        rect.localScale = s;
    }

    //key -> 要监听的按键， timeElapse -> 双击之间最大时间间隔
    bool DoubleClick(double timeElapse)
    {
        //down --> mouseDownStatus = true; //up --> mouseDownStatus = false
        if (Input.GetMouseButtonDown(0))
        {
            if (!keyDownStatus)
            {
                keyDownStatus = true;
                //Debug.Log("clicked");
                if (keyDownCount == 0)
                {// 如果按住数量为 0
                    lastTime = Time.realtimeSinceStartup;// 记录最后时间
                }
                keyDownCount++;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            keyDownStatus = false;
        }
        if (keyDownStatus)
        {
            if (keyDownCount >= 2)
            {
                currentTime = Time.realtimeSinceStartup;
                if (currentTime - lastTime < timeElapse)
                {
                    lastTime = currentTime;
                    keyDownCount = 0;
                    //Debug.Log("Double clicked");
                    return true;//返回结果，确认双击
                }
                else
                {
                    lastTime = Time.realtimeSinceStartup;  // 记录最后时间
                    keyDownCount = 1;
                }
            }
        }
        return false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        canBeSelected = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        canBeSelected = false;
    }

    public void Update()
    {
        if(canBeSelected == true&&DoubleClick(0.3) == true)
        {
            switch (function){
                case 1:
                    StartGamePanel.SetActive(true);
                    Title.SetActive(false);
                    break;
                    ;
                case 2:
                    ButtonChangePanel.SetActive(true);
                    Title.SetActive(false);
                    break;
                case 3:
                    IntroductionPanel.SetActive(true);
                    Title.SetActive(false);
                    break;
                case 4:
                    Application.Quit();
                    break;
            }
            
            
        }
    }
}
