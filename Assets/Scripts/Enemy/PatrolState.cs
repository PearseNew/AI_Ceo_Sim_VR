using UnityEngine;

public class PatrolState : EnemyStateBase
{
    public override void EnterState(EnemyStateManager enemyManager)
    {
        enemyManager.Walk.Play();
        enemyManager.animator.SetTrigger("Patrol");
    }
    public override void UpdateState(EnemyStateManager enemyManager)
    {
        enemyManager.Looking();
        enemyManager.Move(enemyManager.targets[enemyManager.targetIndex].transform.position);
    }
    public override void ExitState(EnemyStateManager enemyManager)
    {
        

    }
}
