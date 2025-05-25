using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorizer
{
    // 👑 Class: Word — Handles a single word's hidden/display state
    public class Word
    {
        private string _text;
        private bool _isHidden;

        public Word(string text)
        {
            _text = text;
            _isHidden = false;
        }

        public bool IsHidden => _isHidden;

        public void Hide()
        {
            _isHidden = true;
        }

        public string GetDisplayText()
        {
            return _isHidden ? new string('_', _text.Length) : _text;
        }
    }

    // 📖 Class: ScriptureReference — Stores book, chapter, verses
    public class ScriptureReference
    {
        private string _book;
        private int _chapter;
        private int _startVerse;
        private int? _endVerse;

        public ScriptureReference(string book, int chapter, int verse)
        {
            _book = book;
            _chapter = chapter;
            _startVerse = verse;
            _endVerse = null;
        }

        public ScriptureReference(string book, int chapter, int startVerse, int endVerse)
        {
            _book = book;
            _chapter = chapter;
            _startVerse = startVerse;
            _endVerse = endVerse;
        }

        public override string ToString()
        {
            return _endVerse.HasValue
                ? $"{_book} {_chapter}:{_startVerse}-{_endVerse}"
                : $"{_book} {_chapter}:{_startVerse}";
        }
    }

    // 📜 Class: Scripture — Encapsulates full scripture logic and display
    public class Scripture
    {
        private ScriptureReference _reference;
        private List<Word> _words;

        public Scripture(ScriptureReference reference, string text)
        {
            _reference = reference;
            _words = text.Split(' ')
                         .Select(word => new Word(word))
                         .ToList();
        }

        public void HideRandomWords(int count)
        {
            Random rand = new Random();
            List<Word> unhiddenWords = _words.Where(w => !w.IsHidden).ToList();

            for (int i = 0; i < count && unhiddenWords.Count > 0; i++)
            {
                int index = rand.Next(unhiddenWords.Count);
                unhiddenWords[index].Hide();
                unhiddenWords.RemoveAt(index);
            }
        }

        public bool IsCompletelyHidden()
        {
            return _words.All(w => w.IsHidden);
        }

        public string GetDisplayText()
        {
            string verse = string.Join(" ", _words.Select(w => w.GetDisplayText()));
            return $"{_reference}\n{verse}";
        }
    }

    // 🏁 Main Program: Displays, hides words, handles loop
    class Program
    {
        static void Main()
        {
            // 📌 Load scripture manually — you can load from file for extra credit
            ScriptureReference reference = new ScriptureReference("Proverbs", 3, 5, 6);
            string text = "Trust in the Lord with all thine heart and lean not unto thine own understanding.";
            Scripture scripture = new Scripture(reference, text);

            while (!scripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit.");

                string input = Console.ReadLine();
                if (input.Trim().ToLower() == "quit")
                    break;

                scripture.HideRandomWords(3); // 💡 You can change the number hidden here
            }

            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nAll words are hidden. Program ended.");

            // 🧠 Exceeding Requirements:
            // - Word hiding only targets unhidden words (stretch requirement)
            // - Clean class separation and encapsulation
            // - Consistent naming and formatting
        }
    }
}
