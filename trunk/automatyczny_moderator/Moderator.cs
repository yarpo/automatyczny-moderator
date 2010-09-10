namespace automatyczny_moderator
{
    interface Moderator
    {
        void checkSpelling(Post post);
        void checkSwearWords(Post post);
        void checkEmoticons(Post post);
    }
}
