using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constant
{
    public const string HORIZONTAL_AXIS = "Horizontal";
    public const string VERTICAL_AXIS = "Vertical";

    public const string ANIM_IS_IDLE = "IsIdle";
    public const string ANIM_IS_DEAD = "IsDead";
    public const string ANIM_IS_ATTACK = "IsAttack";
    public const string ANIM_IS_WIN = "IsWin";
    public const string ANIM_IS_DANCE = "IsDance";

    public const string TAG_CHAR_MODEL = "CharModel";
    public const string TAG_CHARACTER = "Character";
    public const string TAG_BULLET = "Bullet";

    public const string ANIM_ATTACK = "Attack";

    public enum GameState { PAUSE, PLAY, END};
}
