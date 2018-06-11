using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterBehavior
{
    //需要注意的是:动画状态有两种:
    //1、在所处的状态中只需要播放一个动画片段 
    //2、在所处的状态中需要随机播放多个动画片段
    public class CharacterBaseState
    {
        public Character Entity;
        public eCharacterState State;

        protected bool IsEnter = false;

        public CharacterBaseState(eCharacterState state)
        {
            State = state;
        }

        public virtual void Enter()
        {
            IsEnter = true;
        }

        public virtual void Update()
        {
        }
        public virtual void LateUpdate()
        {

        }
        public virtual void Exit()
        {
            IsEnter = false;
        }

        public virtual void Dispose()
        {
            CharacterStateFactory.DisposeState(State, this);
        }
    }

    public enum eCharacterState
    {
        None = 0,

        Idle,
        Walk,

        Max,
    }

    /// <summary>
    /// 状态工厂
    /// </summary>
    public class CharacterStateFactory
    {
        static Queue<CharacterIdleState> idleStateQueue = new Queue<CharacterIdleState>();
        public static CharacterIdleState GetCharacterIdleState()
        {
            if (idleStateQueue.Count > 0)
            {
                return idleStateQueue.Dequeue();
            }
            else
            {
                CharacterIdleState state = new CharacterIdleState();
                return state;
            }
        }

        static Queue<CharacterWalkState> walkStateQueue = new Queue<CharacterWalkState>();
        public static CharacterWalkState GetCharacterWalkState()
        {
            if (walkStateQueue.Count > 0)
            {
                return walkStateQueue.Dequeue();
            }
            else
            {
                CharacterWalkState state = new CharacterWalkState();
                return state;
            }
        }

        public static void DisposeState(eCharacterState type, CharacterBaseState state)
        {
            switch (type)
            {
                case eCharacterState.None:
                    break;
                case eCharacterState.Idle:
                    idleStateQueue.Enqueue((CharacterIdleState)state);
                    break;
                case eCharacterState.Walk:
                    walkStateQueue.Enqueue((CharacterWalkState)state);
                    break;
                case eCharacterState.Max:
                    break;
                default:
                    break;
            }
        }
    }

    public class AnimNameDefine
    {
        public const string Idle = "Idle";
        public const string Walk = "Walk";
        public const string RandomAnim_0 = "RandomAnim_0";
        public const string RandomAnim_1 = "RandomAnim_1";
        public const string RandomAnim_2 = "RandomAnim_2";
        public const string RandomAnim_3 = "RandomAnim_3";
    }
}
