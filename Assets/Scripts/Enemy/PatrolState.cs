using UnityEngine;

public class PatrolState : EnemyStateBase
{
    public override void EnterState(EnemyStateManager enemyManager)
    {
        enemyManager.animator.SetTrigger("Patrol");
        
    }
    public override void UpdateState(EnemyStateManager enemyManager)
    {
        enemyManager.Looking();
        enemyManager.move(enemyManager.targets[enemyManager.targetIndex].transform.position);
    }
    public override void ExitState(EnemyStateManager enemyManager)
    {


    }
}
