using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterBehavior
{
    public class Character
    {
        public Character()
        {
            Init();
        }

        public CharcterStateController stateController = null;

        public void PlayIdleState()
        {
            CharacterIdleState state = CharacterStateFactory.GetCharacterIdleState();
            stateController.ChangeState(state);
        }

        public void PlayWalkState()
        {
            CharacterWalkState state = CharacterStateFactory.GetCharacterWalkState();
            stateController.ChangeState(state);
        }

        public void Update()
        {
            if (null != stateController)
                stateController.Update();
        }

        public void PlayCommonAnim(string animName)
        {
            Debug.Log("animName = " + animName);
        }

        private void Init()
        {
            if (null == stateController)
                stateController = new CharcterStateController(this);
            CharacterIdleState idleState = CharacterStateFactory.GetCharacterIdleState();
            stateController.ChangeState(idleState);
        }
    }
}