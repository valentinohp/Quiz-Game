using UnityEngine;

namespace QuizGame.Global.Database
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/LevelStructScriptableObject", order = 1)]
    public class LevelStructScriptable : ScriptableObject
    {
        public LevelStruct[] LevelStruct;
    }
}