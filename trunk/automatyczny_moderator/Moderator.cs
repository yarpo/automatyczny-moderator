namespace automatyczny_moderator
{
    interface Moderator
    {
        SpellingResult checkSpelling(Post post);
        SwearResult checkSwearWords(Post post);
        EmoticonsResult checkEmoticons(Post post);
        ModeratorLog getModeratorLog();

        string jadgeEmoticons(EmoticonsResult er);
        string jadgeSwearWords(SwearResult swr);
        string jadgeSpelling(SpellingResult sr);
    }
}
