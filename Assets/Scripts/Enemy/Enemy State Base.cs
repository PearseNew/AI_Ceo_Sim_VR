using Unity.VisualScripting;
using UnityEngine;

public abstract class EnemyStateBase
{
    public abstract void EnterState(EnemyStateManager enemyManager);
    public abstract void UpdateState(EnemyStateManager enemyManager);
    public abstract void ExitState(EnemyStateManager enemyManager);
}
