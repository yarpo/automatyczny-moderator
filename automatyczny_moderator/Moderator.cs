namespace automatyczny_moderator
{
    interface Moderator
    {
        SpellingResult checkSpelling(Post post);
        SwearResult checkSwearWords(Post post);
        void checkEmoticons(Post post);
    }
}
