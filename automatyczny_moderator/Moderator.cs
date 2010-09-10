namespace automatyczny_moderator
{
    interface Moderator
    {
        SpellingResult checkSpelling(Post post);
        void checkSwearWords(Post post);
        void checkEmoticons(Post post);
    }
}
