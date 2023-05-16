using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventSystem : MonoBehaviour
{
    private void Awake()
    {
        Events.Turn = ScriptableObject.CreateInstance<GameEvent>();
        Events.LevelEnd = ScriptableObject.CreateInstance<GameEvent>();
        Events.DropU = ScriptableObject.CreateInstance<GameEvent>();
        Events.ChangeSoundLevel = ScriptableObject.CreateInstance<GameEvent>();
        Events.ResetLevel = ScriptableObject.CreateInstance<GameEvent>();
    }
}