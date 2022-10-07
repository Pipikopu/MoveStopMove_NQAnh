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

    public enum GameState { PAUSE, PLAY, CHOOSESKIN, END};

    //public const string SELECTED_WEAPON = "SelectedWeapon";
    //public const string SELECTED_WEAPON_SKIN = "SelectedWeaponSkin";

    //public const string SELECTED_PANT = "SelectedPant";
    //public const string SELECTED_HAT = "SelectedHat";
    //public const string SELECTED_SHIELD = "SelectedShield";
    //public const string SELECTED_BODY = "SelectedBody";
    //public const string SELECTED_TAIL = "SelectedTail";
    //public const string SELECTED_WING = "SelectedWing";
    //public const string SELECTED_SET = "SelectedSet";

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
