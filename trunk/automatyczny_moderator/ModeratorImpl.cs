﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHunspell;
using System.Text.RegularExpressions;

namespace automatyczny_moderator
{
    class ModeratorImpl : Moderator
    {
        private ModeratorLog mlog;
        private Hunspell hunspell;

        private const string POLISH_AFF = "../../dict/pl_pl.aff";
        private const string POLISH_DICT = "../../dict/pl_pl.dic";
        private string[] emoticons = { @":\)", @":\>", @":\(", @":\$", @":\*", ":D", ":P", ";P" };

        public ModeratorImpl(ModeratorLog log)
        {
            hunspell = new Hunspell(POLISH_AFF, POLISH_DICT);
            this.mlog = log; 
        }

        #region Moderator Members

        public SpellingResult checkSpelling(Post post)
        {
            string []words = splitWords(post.Content);
            SpellingResult result = new SpellingResult();
            result.Words = words.Length;
            result.Iduser = post.Iduser;

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
            result.Iduser = post.Iduser;

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
            result.Iduser = post.Iduser;
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

        public ModeratorLog getModeratorLog()
        {
            return this.mlog;
        }

        public const string EMO_INFO = "EMO_INFO";
        public const string EMO_WARN = "EMO_WARNING";
        public const string EMO_DISQ = "EMO_DISQUALIFICATION";
        public const string EMO_BAN = "EMO_BAN";

        public string jadgeEmoticons(EmoticonsResult er)
        {
            UserHistory user = new UserHistoryDB(er.Iduser);

            if (er.Procentage > 30 && er.Procentage <= 35)
            {
                return user.emots(EMO_INFO);
            }
            else if (er.Procentage > 35 && er.Procentage <= 50)
            {
                return user.emots(EMO_WARN);
            }
            else if (er.Procentage > 50 && er.Procentage <= 75)
            {
                return user.emots(EMO_DISQ);
            }
            else if (er.Procentage > 75)
            {
                return user.emots(EMO_BAN);
            }

            return "Poprawny post usera o id " + er.Iduser;
        }

        public const string SWEAR_INFO = "SWEAR_INFO";
        public const string SWEAR_WARN = "SWEAR_WARNING";
        public const string SWEAR_DISQ = "SWEAR_DISQUALIFICATION";
        public const string SWEAR_BAN  = "SWEAR_BAN";

        public string jadgeSwearWords(SwearResult swr)
        {
            UserHistory user = new UserHistoryDB(swr.Iduser);

            if (swr.Swears > 0)
            {
                user.swears(SWEAR_INFO);
            }

            if (swr.Procentage > 1 && swr.Procentage <= 3)
            {
                return user.swears(SWEAR_WARN);
            }
            else if (swr.Procentage > 3 && swr.Procentage <= 5)
            {
                return user.swears(SWEAR_DISQ);
            }
            else if (swr.Procentage > 5)
            {
                return user.swears(SWEAR_BAN);
            }

            return "Brak wulgaryzmow w poście usera o id " + swr.Iduser;
        }

        public const string ORT_INFO = "ORT_INFO";
        public const string ORT_WARN = "ORT_WARNING";
        public const string ORT_DISQ = "ORT_DISQUALIFICATION";
        public const string ORT_BAN = "ORT_BAN";
        public const string ORT_DEL = "ORT_DELETE";
        
        public string jadgeSpelling(SpellingResult sr)
        {
            UserHistory user = new UserHistoryDB(sr.Iduser);

            if (sr.Procentage > 2 && sr.Procentage <= 5)
            {
                return user.ort(ORT_INFO);
            }
            else if (sr.Procentage > 5 && sr.Procentage <= 20)
            {
                return user.ort(ORT_INFO);
            }
            else if (sr.Procentage > 20 && sr.Procentage <= 30)
            {
                return user.ort(ORT_INFO);
            }
            else if (sr.Procentage > 30)
            {
                return user.ort(ORT_BAN, 3);
            }

            return "Brak wulgaryzmow w poście usera o id " + sr.Iduser;
        }

        #endregion

        private string createRegExpEmots()
        {
            string reg = "";
            foreach (string emot in emoticons)
            {
                reg += "[.]*" + emot + "[.]*|";
            }
            return reg.Substring(0, reg.Length - 1);
        }
    }
}