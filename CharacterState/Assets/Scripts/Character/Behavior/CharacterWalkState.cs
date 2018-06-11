using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterBehavior
{
    //假设在改动画状态中，需要播放    一个    动画片段
    public class CharacterWalkState : CharacterBaseState
    {
        public CharacterWalkState()
            : base(eCharacterState.Walk)
        {
        }

        public override void Enter()
        {
            base.Enter();
            Entity.PlayCommonAnim(AnimNameDefine.Walk);
        }
    }
}
