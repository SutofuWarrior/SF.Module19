using System.Collections.Generic;

namespace SF.Module19
{
    public interface IEnglishTrainer
    {
        void AddWord(Word word);

        void DeleteWord(string word);
    }

    public class Word
    {
        public string EnglishWord;

        public string RussianWord;

        public string Subject;
    }

    public class EnglishTrainer : IEnglishTrainer
    {
        private readonly Dictionary<string, Word> Glossary = new Dictionary<string, Word>();

        public void AddWord(Word word)
        {
            if (!Glossary.ContainsKey(word.EnglishWord))
                Glossary.Add(word.EnglishWord, word);
            else
                Glossary[word.EnglishWord] = word;
        }

        public void DeleteWord(string word)
        {
            Glossary.Remove(word);
        }


    }
}
