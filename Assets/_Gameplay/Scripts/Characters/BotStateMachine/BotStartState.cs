using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotStartState : BotBaseState
{
    public override void EnterState(BotStateMachine bot)
    {
        //bot.isDead = false;

        bot.SwitchState(bot.MoveState);
    }

    public override void UpdateState(BotStateMachine bot) { }

    public override void ExitState(BotStateMachine bot)
    {

    }
}
