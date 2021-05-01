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
        Level5
    }
    public enum PlayerState
    {
        Idle = 0,
        Run = 1,
        JumpNoNeedYet = 2,
        Fall = 3,
        Win = 4,
        Attack = 5,
        Die = 6
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
