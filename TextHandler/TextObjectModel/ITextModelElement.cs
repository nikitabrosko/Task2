namespace TextHandler.TextObjectModel
{
    public interface ITextModelElement<T> : IGetStringRepresentationAble
    {
        T Value { get; }
    }
}
