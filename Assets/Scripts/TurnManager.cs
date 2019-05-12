using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TurnManager : MonoBehaviour
{

    public static TurnManager instance;
    public static TurnManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<TurnManager>();

                if (instance == null)
                {
                    GameObject container = new GameObject("TurnManager");
                    instance = container.AddComponent<TurnManager>();
                }
            }

            return instance;
        }
    }

    private void Awake()
    {
        if (TurnManager.Instance != null)
            Destroy(this);
    }

    [SerializeField]
    private int maxNBattlers = 6;
    private List<Battler> battlers = new List<Battler>();
    private bool battleStarted = false;
    //Gambiarra
    private int currentBattlerID;

    public void AddBattler(Battler battler)
    {
        if(battleStarted)
            return;

        battler.id = battlers.Count;
        battlers.Add(battler);
        if(battlers.Count == maxNBattlers){
            battleStarted = true;
            currentBattlerID = -1;
            NextTurn();
        }
    }

    public void RemoveBattler()
    {

    }

    private void NextTurn(){
        currentBattlerID = (currentBattlerID+1) % battlers.Count;
        Battler currentBattler = battlers[currentBattlerID];
        currentBattler.GetComponent<IDecision>().RequestDecision(currentBattlerID);
        // Começa a corrotina de esperar o tempo do turno acabar
    }

    public void ReceiveDecision(){
        //Gambiarra
        int targetID;
        do{
            targetID = Random.Range(0, battlers.Count-1);
        }while(targetID == currentBattlerID);
        Battler target = battlers[targetID];
        Battler currentBattler = battlers[currentBattlerID];
        int dmg = target.TakeDamage(currentBattler.attack);
        Debug.Log("Battler " + currentBattlerID + " deals " + dmg + " dmg to battler " + targetID);
        NextTurn();
    }
}
