using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Battler : NetworkBehaviour
{
    public int hp;
    public int attack;
    public int defense;
    // Gambiarra, precisa ser property que checa se é o server
    [SyncVar]
    public int id;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [Client]
    public void OnButtonPressed(){
        GetComponent<PlayerDecision>().CmdReturnDecision();
    }

    // Gambiarra
    public int TakeDamage(int atk){
        hp -= (atk - defense);
        return (atk-defense);
    }
}
