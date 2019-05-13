using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Controller : NetworkBehaviour
{
    void Start(){
        //Gambiarra
        BattlerInfo info;
        info.HP = 100;
        info.attack = 20;
        info.defense = 10;
        info.decision = DecisionType.Player;
        for(int i = 0; i < 3; i++){
            if(isLocalPlayer)
                CmdInstantiateBattler(info, i);
        }
    }
    public GameObject battlerPrefab;
    [Client]
    public void InstantiateUI(){
        // Instancia os elementos de UI no client
    }

    [TargetRpc]
    public void TargetShowMenu(NetworkConnection conn, int id){
        // Instancia os botões de ação no client
        Battler currentBattler = null;
        foreach(Battler b in FindObjectsOfType<Battler>()){
            if(b.id == id){
                currentBattler = b;
                break;
            }
        }
        Debug.Log("O Battler " + currentBattler.id + " ira liberar seu menu");

        currentBattler.myCanvas.SetActive(true);

        //foreach(GameObject go in GameObject.FindGameObjectsWithTag("BattleButton")){
        //    go.SetActive(true);
        //}
        // Configura os botoes de acordo com as skills do battler
        // To do: consertar essa bagunça
    }


    [Command]
    public void CmdInstantiateBattler(BattlerInfo info, int indexPosicao){
        GameObject go = Instantiate(battlerPrefab, new Vector3(indexPosicao*3f, 0, this.netId*1), Quaternion.identity);
        Battler btlr = go.GetComponent<Battler>();
        btlr.hp = info.HP;
        btlr.attack = info.attack;
        btlr.defense = info.defense;
        if(info.decision == DecisionType.Player){
            go.AddComponent<PlayerDecision>();
            go.GetComponent<PlayerDecision>().myController = this;
        }else{
        }
        NetworkServer.SpawnWithClientAuthority(go, connectionToClient);
        TurnManager.Instance.AddBattler(go.GetComponent<Battler>());
    }
}
