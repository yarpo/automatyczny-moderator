using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHunspell;
using System.Text.RegularExpressions;

namespace automatyczny_moderator
{
    class ModeratorImpl : Moderator
    {
        private Hunspell hunspell;

        private const string POLISH_AFF = "../../dict/pl_pl.aff";
        private const string POLISH_DICT = "../../dict/pl_pl.dic";
        private string[] emoticons = { @":\)", @":\>", @":\(", @":\$", @":\*", ":D", ":P", ";P" };

        public ModeratorImpl()
        {
            hunspell = new Hunspell(POLISH_AFF, POLISH_DICT);
        }

        #region Moderator Members

        public SpellingResult checkSpelling(Post post)
        {
            string []words = splitWords(post.Content);
            SpellingResult result = new SpellingResult();
            result.Words = words.Length;

            foreach(string word in words)
            {
                bool spelling = hunspell.Spell(word);
                bool abbreviation = isItAbbreviation(word);

                if (false == spelling && false == abbreviation)
                {
                    result.MisspelledWords.Add(word);
                }
            }
            return result;
        }

        private bool isItAbbreviation(string s)
        {
            return Regex.IsMatch(s, @"[A-Z0-9\.-_]{1,8}");
        }

        private string[] splitWords(string s)
        {
             return Regex.Split(s, @"\W+");
        }

        public SwearResult checkSwearWords(Post post)
        {
            string[] swears = {"kurwa", "chuj"};
            string[] words = splitWords(post.Content);

            SwearResult result = new SwearResult();
            result.Words = words.Length;

            foreach (string word in words)
            {
                foreach (string swear in swears)
                {
                    if (word.Equals(swear))
                    {
                        result.SwearWords.Add(word);
                    }
                }
            }
            return result;
        }

        public EmoticonsResult checkEmoticons(Post post)
        {
            EmoticonsResult result = new EmoticonsResult();

            string[] words = splitWords(post.Content);
            foreach (string word in words)
            {
                Console.WriteLine(word);
            }

            result.Words = splitWords(post.Content).Length;
            string regExpEmoticons = createRegExpEmots();

            var matches = Regex.Matches(post.Content, regExpEmoticons);
            result.Counter = matches.Count;

            return result;
        }

        private string createRegExpEmots()
        {
            string reg = "";
            foreach (string emot in emoticons)
            {
                reg += "[.]*" + emot + "[.]*|";
            }
            return reg.Substring(0, reg.Length - 1);
        }

        #endregion
    }
}

/*
            Console.WriteLine("NHunspell functions and classes demo");

            Console.WriteLine("");
            Console.WriteLine("Spell Check with with Hunspell");

            // Important: Due to the fact Hunspell will use unmanaged memory
            // you have to serve the IDisposable pattern
            // In this block of code this is be done
            // by a using block. But you can also call hunspell.Dispose()
            using (NHunspell.Hunspell hunspell = new Hunspell("pl_pl.aff", "pl_pl.dic"))
            {
                Console.WriteLine("Sprawdzam slowo 'rekomendacja'");
                bool correct = hunspell.Spell("Rekomendacja");
                Console.WriteLine("Rekomendacja jest napisana " +
                          (correct ? "porawnie" : "niepoprawnie"));

                Console.WriteLine("");
                Console.WriteLine("Sprawdzmy dla 'Rekomendaca'");
                List<string> suggestions = hunspell.Suggest("Rekomendaca");
                Console.WriteLine("Sa sugerowane slowa " + suggestions.Count.ToString());
                foreach (string suggestion in suggestions)
                {
                    Console.WriteLine("Podpowiedz: " + suggestion);
                }
            }

            Console.WriteLine("");
            Console.WriteLine("Hyphenation with Hyph");

            // Important: Due to the fact Hyphen will use unmanaged
            // memory you have to serve the IDisposable pattern
            // In this block of code this is be done by a using block.
            // But you can also call hyphen.Dispose()
            using (NHunspell.Hyphen hyphen = new Hyphen("hyph_en_us.dic"))
            {
                Console.WriteLine("Get the hyphenation of the word 'Recommendation'");
                NHunspell.HyphenResult hyphenated = hyphen.Hyphenate("Recommendation");
                Console.WriteLine("'Recommendation' is hyphenated as: " +
                                  hyphenated.HyphenatedWord);
            }

            Console.WriteLine("");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }*/
