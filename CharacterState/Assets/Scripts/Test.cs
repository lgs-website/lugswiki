using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacterBehavior;

public class Test : MonoBehaviour
{
    Character character = null;

    void Update()
    {
        if (null != character)
            character.Update();
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(20, 50, 100, 50), "Init"))
        {
            if (null == character)
                character = new Character();
        }

        if (GUI.Button(new Rect(20, 110, 100, 50), "Idle"))
        {
            if (null != character)
            {
                character.PlayIdleState();
            }
        }

        if (GUI.Button(new Rect(20, 170, 100, 50), "Walk"))
        {
            if (null != character)
            {
                character.PlayWalkState();
            }
        }
    }
}
