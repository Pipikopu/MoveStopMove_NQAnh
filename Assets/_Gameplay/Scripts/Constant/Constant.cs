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

    public const string SOUND_ON = "SoundOn";
    public const string VIBRATE_ON = "VibrateOn";

    public enum GameState { PAUSE, PLAY, CHOOSESKIN, END};

    public const string OBSTACLE = "Obstacle";

    public enum ItemState
    {
        Lock = 0,
        NotEquip = 1,
        NotEquipOneTime = 2,
        Equip = 3,
        EquipOneTime = 4,
    }

    public enum ItemUnlockOneTime
    {
        Used = 0,
        NotUsed = 1
    }

    public const string PLAYER_DATA_PATH = "/_Gameplay/JSonFiles/saveFile.json";
    public const string ITEM_STATE_PATH = "/_Gameplay/JSonFiles/itemUnlockState.json";
}
