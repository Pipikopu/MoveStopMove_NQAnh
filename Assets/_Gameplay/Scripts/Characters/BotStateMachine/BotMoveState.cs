using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotMoveState : BotBaseState
{
    private Vector3 targetPosition;

    public override void EnterState(BotStateMachine bot)
    {
        bot.agent.speed = bot.speedAgent;
        bot.agent.SetDestination(RandomNavMeshLocation(bot));
        bot.botAnimator.SetBool(Constant.ANIM_IS_IDLE, false);
        //bot.botAnimator.SetBool(Constant.ANIM_IS_ATTACK, false);
    }

    public override void UpdateState(BotStateMachine bot)
    {
        if (bot.agent != null && (bot.agent.remainingDistance <= bot.agent.stoppingDistance || bot.agent.speed < 1))
        {
            bot.SwitchState(bot.IdleState);
        }
        else
        {
            SetRotation(bot);
            bot.botAnimator.SetBool(Constant.ANIM_IS_IDLE, false);
        }
    }

    public override void ExitState(BotStateMachine bot)
    {
        bot.botAnimator.SetBool(Constant.ANIM_IS_IDLE, true);
    }

    private Vector3 RandomNavMeshLocation(BotStateMachine bot)
    {
        Vector3 finalPosition = Vector3.zero;
        Vector3 randomPosition = Random.insideUnitSphere * bot.walkRadius;

        randomPosition += bot.botTransform.position;

        if (NavMesh.SamplePosition(randomPosition, out NavMeshHit hit, bot.walkRadius, 1))
        {
            finalPosition = hit.position;
        }

        return finalPosition;
    }

    private void SetRotation(BotStateMachine bot)
    {
        bot.directionVec = bot.agent.desiredVelocity.normalized;
        bot.angleToRotate = Mathf.Rad2Deg * Mathf.Atan2(bot.directionVec.x, bot.directionVec.z);
        bot.botModel.rotation = Quaternion.RotateTowards(bot.botModel.rotation, Quaternion.AngleAxis(bot.angleToRotate, Vector3.up), bot.rotateSpeed * Time.deltaTime);
    }
}
