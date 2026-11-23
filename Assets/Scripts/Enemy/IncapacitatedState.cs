using UnityEngine;

public class IncapacitatedState : EnemyStateBase
{
    float time;
    public override void EnterState(EnemyStateManager enemyManager)
    {
        enemyManager.Voice.volume = 0.35f;
        enemyManager.Voice.clip = enemyManager.Scream;
        enemyManager.Voice.Play();
        enemyManager.Walk.Stop();
        time = 0;
        enemyManager.animator.SetTrigger("Hit");
        enemyManager.agent.isStopped = true;
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
        enemyManager.Voice.volume = 1f;
        enemyManager.agent.isStopped = false;


    }
}
