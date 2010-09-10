namespace automatyczny_moderator
{
    interface Moderator
    {
        SpellingResult checkSpelling(Post post);
        SwearResult checkSwearWords(Post post);
        EmoticonsResult checkEmoticons(Post post);
    }
}
