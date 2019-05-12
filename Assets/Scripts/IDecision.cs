using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDecision
{
    void CmdReturnDecision();
    void RequestDecision(int id);
}
