using UnityEngine;

using Pada1.BBCore;
using Pada1.BBCore.Framework;

[Condition("MyConditions/RobberHiding")]
[Help("Checks whether Cop is near the Treasure.")]
public class RobberHiding : ConditionBase
{
    [InParam("robber")]
    GameObject robber;
    public override bool Check()
    {
        return robber.GetComponent<Moves>().shout;
    }
}
