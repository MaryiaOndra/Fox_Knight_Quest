using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public enum LevelState 
    {
        Locked,
        NeedUnlock,
        Unlocked        
    }

    public enum LevelContentId 
    {
        Level1,
        Level2,
        Level3,
        Level4,
        Level5,
        Level6,
        Level7,
        Level8
    }
    public enum PlayerState
    {
        Idle = 0,
        Run = 1,
        JumpNoNeedYet = 2,
        Fall = 3,
        Win = 4,
        Attack = 5,
        Die = 6,
        Attacked = 7,
        Defend = 8
    }

    public enum EnemyState 
    {
        Idle = 0,
        Walk = 1,
        IdleBattle = 2,
        Attack = 3,
        GetHit = 4,
        Die = 5,
        Win = 6
    }

    public enum BtnState
    {
        MoveForward,
        MoveRight,
        MoveLeft,
        MoveBack,
        Jump,
        Attack,
        Slider,
        None
    }
}
