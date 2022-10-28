using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameOverCondition
{
    delegate void GameOverCondition();
    static event GameOverCondition ConditionFulfilled;
}
