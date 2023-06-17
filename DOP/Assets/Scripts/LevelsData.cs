using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Levels")]
public class LevelsData : ScriptableObject
{
    public List<Level> levels;
}

[Serializable]
public struct Level
{
    public Scratch level;
    public string condition;
}
