using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPrepare
{
    public int tankId;
    public TankModel.tankType tanktype { get;  set; }       
    public KeyCode key_Up { get; private set; }
    public KeyCode key_Down { get; private set; }
    public KeyCode key_Left { get; private set; }
    public KeyCode key_Right { get; private set; }
    public KeyCode key_Attack { get; private set; }
    public KeyCode key_Use { get; private set; }

    public TankPrepare(int tankid, TankModel.tankType tank_type, KeyCode key_up, KeyCode key_down, KeyCode key_left, KeyCode key_right, KeyCode key_attack, KeyCode key_use)
    {
        this.tankId = tankid;
        this.tanktype = tank_type;
        this.key_Up = key_up;
        this.key_Down = key_down;
        this.key_Left = key_left;
        this.key_Right = key_right;
        this.key_Attack = key_attack;
        this.key_Use = key_use;

    }
}