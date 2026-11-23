using UnityEngine;

public class IdleState : EnemyStateBase
{
    private float timer;
    public override void EnterState(EnemyStateManager enemyManager)
    {
        enemyManager.Walk.Stop();
        timer = 0;
        enemyManager.agent.isStopped = true;
        enemyManager.animator.SetTrigger("Idle");
    }
    public override void UpdateState(EnemyStateManager enemyManager)
    {
        timer += Time.fixedDeltaTime;
        enemyManager.Looking();
        if (timer > 5)
        {
            int randomIndex = Random.Range(0, enemyManager.targets.Length);
            enemyManager.targetIndex = randomIndex;
            enemyManager.SwitchState(enemyManager.patrolState);

        }
    }
    public override void ExitState(EnemyStateManager enemyManager)
    {

        enemyManager.agent.isStopped = false;
    }
}
