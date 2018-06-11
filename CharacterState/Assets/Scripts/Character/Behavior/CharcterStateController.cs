using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterBehavior
{
    public class CharcterStateController
    {
        public Character Entity;
        private CharacterBaseState currState;
        private CharacterBaseState lastState;

        public CharcterStateController(Character entity)
        {
            Entity = entity;
        }

        public CharacterBaseState CurrState
        {
            get { return currState; }
        }

        public CharacterBaseState LastState
        {
            get { return lastState; }
        }

        public CharacterBaseState NextState
        {
            get;
            private set;
        }

        public void Update()
        {
            if (currState != null)
                currState.Update();
        }

        public void LateUpdate()
        {
            if (currState != null)
                currState.LateUpdate();
            NextState = null;
        }

        public void ChangeState(CharacterBaseState newState)
        {
            if (newState == null)
            {
                Debug.LogError("State Not Exist");
                return;
            }
            NextState = newState;
            newState.Entity = Entity;
            if (currState != null)
            {
                currState.Exit();
                if (lastState != null)
                    lastState.Dispose();
                lastState = currState;
            }
            currState = newState;
            currState.Enter();
        }
    }
}
