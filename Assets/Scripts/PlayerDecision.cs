using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerDecision : NetworkBehaviour, IDecision
{
    public Controller myController;
    [Command]
    public void CmdReturnDecision(){
        //Gambiarra
        TurnManager.Instance.ReceiveDecision();
    }
    public void RequestDecision(int id){
        myController.TargetShowMenu(myController.netIdentity.connectionToClient, id);
    }
}
