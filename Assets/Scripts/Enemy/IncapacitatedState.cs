using UnityEngine;

public class IncapacitatedState : EnemyStateBase
{
    float time;
    public override void EnterState(EnemyStateManager enemyManager)
    {
        time = 0;
        enemyManager.animator.SetTrigger("Hit");
    }
    public override void UpdateState(EnemyStateManager enemyManager)
    {
        time += Time.deltaTime;
        if (time > 5)
        {
            enemyManager.SwitchState(enemyManager.idleState);
        }

    }
    public override void ExitState(EnemyStateManager enemyManager)
    {
        
  
    }
}
