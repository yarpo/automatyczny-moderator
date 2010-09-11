namespace automatyczny_moderator
{
    interface Moderator
    {
        SpellingResult checkSpelling(Post post);
        SwearResult checkSwearWords(Post post);
        EmoticonsResult checkEmoticons(Post post);
        ModeratorLog getModeratorLog();

        void jadgeEmoticons(EmoticonsResult er);
        void jadgeSwearWords(SwearResult swr);
        void jadgeSpelling(SpellingResult sr);
    }
}
