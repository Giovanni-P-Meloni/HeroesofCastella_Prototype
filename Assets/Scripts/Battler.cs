using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Battler : NetworkBehaviour
{
    public GameObject canvas;
    public GameObject myCanvas;
    public int hp;
    public int attack;
    public int defense;
    // Gambiarra, precisa ser property que checa se é o server
    [SyncVar]
    public int id;
    // Start is called before the first frame update
    void Start()
    {
        //Gambiarra
        //instancia seu botao
        GameObject obj = Instantiate(canvas);
        obj.GetComponent<BattlerButton>().myBattler = this;
        obj.SetActive(false);
        myCanvas = obj;
        
    }

    [Client]
    public void OnButtonPressed(){
        //Gambiarra: para fechar o menu de escolha
        myCanvas.SetActive(false);
        CmdReturnDecision();
    }

    [Command]
    public void CmdReturnDecision()
    {
        GetComponent<PlayerDecision>().CmdReturnDecision();
    }
    
    // Gambiarra
    public int TakeDamage(int atk){
        hp -= (atk - defense);
        return (atk-defense);
    }
}
