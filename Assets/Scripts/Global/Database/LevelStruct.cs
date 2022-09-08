namespace QuizGame.Global.Database
{
    [System.Serializable]
    public struct LevelStruct
    {
        public string LevelID;
        public string PackID;
        public string Question;
        public string Hint;
        public string[] Choice;
        public int Answer;
    }
}