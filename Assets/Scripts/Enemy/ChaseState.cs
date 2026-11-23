using UnityEngine;

public class ChaseState : EnemyStateBase
{
    public override void EnterState(EnemyStateManager enemyManager)
    {
        enemyManager.isChasing = true;
        enemyManager.agent.speed = 1.1f;
        enemyManager.animator.SetTrigger("Chase");
    }
    public override void UpdateState(EnemyStateManager enemyManager)
    {
        enemyManager.Looking();
        enemyManager.move(enemyManager.Player.transform.position);
        
        if(enemyManager.lookCounter <= 0)
        {
            enemyManager.SwitchState(enemyManager.idleState);
        }
    }
    public override void ExitState(EnemyStateManager enemyManager)
    {
        enemyManager.lookCounter = 0;
        enemyManager.isChasing = false;
        enemyManager.agent.speed = 0.6f;

    }
}
