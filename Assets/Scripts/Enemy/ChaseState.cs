using UnityEngine;

public class ChaseState : EnemyStateBase
{
    public override void EnterState(EnemyStateManager enemyManager)
    {
        enemyManager.Voice.clip = enemyManager.heyYou;
        enemyManager.Voice.Play();
        enemyManager.Walk.pitch = 1.5f;
        enemyManager.Walk.Play();
        enemyManager.isChasing = true;
        if (enemyManager.speed < 1.5f)
        {
            enemyManager.speed += .15f;
        }
        enemyManager.agent.speed = enemyManager.speed;
        enemyManager.animator.SetTrigger("Chase");
    }
    public override void UpdateState(EnemyStateManager enemyManager)
    {
        enemyManager.Looking();
        enemyManager.Move(enemyManager.Player.transform.position);
        
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
        enemyManager.Walk.pitch = 1.0f;

    }
}
