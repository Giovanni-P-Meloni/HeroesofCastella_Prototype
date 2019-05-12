using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum DecisionType{
    AI = 0,
    Player
}

[System.Serializable]
public struct BattlerInfo
{
    public DecisionType decision;
    public int HP;
    public int attack;
    public int defense;
}
