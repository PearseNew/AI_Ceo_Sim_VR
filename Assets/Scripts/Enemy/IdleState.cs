using UnityEngine;

public class IdleState : EnemyStateBase
{
    private float timer;
    public override void EnterState(EnemyStateManager enemyManager)
    {
        timer = 0;
        enemyManager.animator.SetTrigger("Idle");
    }
    public override void UpdateState(EnemyStateManager enemyManager)
    {
        timer += Time.fixedDeltaTime;

        if(timer > 5)
        {
            int randomIndex = Random.Range(0, enemyManager.targets.Length);
            enemyManager.targetIndex = randomIndex;
            enemyManager.SwitchState(enemyManager.patrolState);
            enemyManager.Looking();
        }
    }
    public override void ExitState(EnemyStateManager enemyManager)
    {


    }
}
