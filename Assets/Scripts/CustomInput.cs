using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CustomInput : MonoBehaviour
{
    Dictionary<int, TankPrepare> keySetting;

    [SerializeField]
    private int playerID;

    public Button up_bt;
    public Button down_bt;
    public Button left_bt;
    public Button right_bt;
    public Button attack_bt;
    public Button use_bt;

    private KeyCode up_key;
    private KeyCode down_key;
    private KeyCode left_key;
    private KeyCode right_key;
    private KeyCode attack_key;
    private KeyCode use_key;

    KeyCode curKey;
    KeyCode newKey;
    Button curButton;

    string functionName = string.Empty;
    bool isWaitingForKey = false;

    private void GetBindKeys()
    {
        up_key = keySetting[playerID].key_Up;
        down_key = keySetting[playerID].key_Down;
        left_key = keySetting[playerID].key_Left;
        right_key = keySetting[playerID].key_Right;
        attack_key = keySetting[playerID].key_Attack;
        use_key = keySetting[playerID].key_Use;

        up_bt.transform.Find("Text").GetComponent<Text>().text = up_key.ToString();
        down_bt.transform.Find("Text").GetComponent<Text>().text = down_key.ToString();
        left_bt.transform.Find("Text").GetComponent<Text>().text = left_key.ToString();
        right_bt.transform.Find("Text").GetComponent<Text>().text = right_key.ToString();
        attack_bt.transform.Find("Text").GetComponent<Text>().text = attack_key.ToString();
        use_bt.transform.Find("Text").GetComponent<Text>().text = use_key.ToString();
    }

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        keySetting = TankModel.TankList;
        GetBindKeys();
        up_bt.onClick.AddListener(upButtonListener);
        down_bt.onClick.AddListener(downButtonListener);
        left_bt.onClick.AddListener(leftButtonListener);
        right_bt.onClick.AddListener(rightButtonListener);
        attack_bt.onClick.AddListener(attackButtonListener);
        use_bt.onClick.AddListener(useButtonListener);

    }
    
    private void OnGUI()
    {
        if (isWaitingForKey)
        {
            Event e = Event.current;
            if (e.isKey)
            {
                newKey = e.keyCode;
                curButton.transform.Find("Text").GetComponent<Text>().text = newKey.ToString();
                isWaitingForKey = false;
                switch (functionName)
                {
                    case "up": 
                        keySetting[playerID].key_Up = newKey;
                        break;
                    case "down":
                        keySetting[playerID].key_Down = newKey;
                        break;
                    case "left":
                        keySetting[playerID].key_Left = newKey;
                        break;
                    case "right":
                        keySetting[playerID].key_Right = newKey;
                        break;
                    case "attack":
                        keySetting[playerID].key_Attack = newKey;
                        break;
                    case "use":
                        keySetting[playerID].key_Use = newKey;
                        break;
                    default:
                        break;
                }
                GetBindKeys();
            }
        }
    }
    void upButtonListener()
    {
        curButton = up_bt;
        curButton.transform.Find("Text").GetComponent<Text>().text = "";
        curKey = up_key;
        functionName = "up";
        isWaitingForKey = true;
    }
    void downButtonListener()
    {
        curButton = down_bt;
        curButton.transform.Find("Text").GetComponent<Text>().text = "";
        curKey = down_key;
        functionName = "down";
        isWaitingForKey = true;
    }
    void leftButtonListener()
    {
        curButton = left_bt;
        curButton.transform.Find("Text").GetComponent<Text>().text = "";
        curKey = left_key;
        functionName = "left";
        isWaitingForKey = true;
    }
    void rightButtonListener()
    {
        curButton = right_bt;
        curButton.transform.Find("Text").GetComponent<Text>().text = "";
        curKey = right_key;
        functionName = "right";
        isWaitingForKey = true;
    }
    void attackButtonListener()
    {
        curButton = attack_bt;
        curButton.transform.Find("Text").GetComponent<Text>().text = "";
        curKey = attack_key;
        functionName = "attack";
        isWaitingForKey = true;
    }
    void useButtonListener()
    {
        curButton = use_bt;
        curButton.transform.Find("Text").GetComponent<Text>().text = "";
        curKey = use_key;
        functionName = "use";
        isWaitingForKey = true;
    }
}
