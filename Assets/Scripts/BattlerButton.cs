using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlerButton : MonoBehaviour
{

    public Battler myBattler;


    public void OnButtonPressed()
    {
        myBattler.OnButtonPressed();
    }
}
