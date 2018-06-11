using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterBehavior
{
    //假设在改动画状态中，需要播放    多个    动画片段
    public class CharacterIdleState : CharacterBaseState
    {
        float elpseTime = 0,        //时间计数器
              intervalTime = 0;     //播放动画的时间间隔

        public CharacterIdleState()
            : base(eCharacterState.Idle)
        { }

        public override void Enter()
        {
            base.Enter();
            ResetTime();
            Entity.PlayCommonAnim(AnimNameDefine.Idle);
        }

        public override void Update()
        {
            base.Update();
            elpseTime += Time.unscaledDeltaTime;
            if (elpseTime >= intervalTime)
            {
                RangePlayModelAnim();
            }
        }

        //随机播放需要播放的动画片段
        void RangePlayModelAnim()
        {
            //包左不包右
            int index = UnityEngine.Random.Range(1, 3);
            string animName = string.Empty;
            switch (index)
            {
                case 1:
                    animName = AnimNameDefine.RandomAnim_1;
                    break;
                case 2:
                    animName = AnimNameDefine.RandomAnim_2;
                    break;
                default:
                    animName = AnimNameDefine.RandomAnim_0;
                    break;
            }

            Entity.PlayCommonAnim(animName);
            ResetTime();
        }

        void ResetTime()
        {
            elpseTime = 0;
            intervalTime = UnityEngine.Random.Range(10.0f, 15.0f);
        }
    }
}
