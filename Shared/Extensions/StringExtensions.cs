namespace Notes.API.Shared.Extensions;

public static class StringExtensions
{
    public static string ToSnakeCase(this string text)
    {
        static IEnumerable<Char> Convert(CharEnumerator letterEnumerator)
        {
            if(!letterEnumerator.MoveNext())
                yield break;
            yield return char.ToLower(letterEnumerator.Current);
            while (letterEnumerator.MoveNext())
            {
                if (char.IsUpper(letterEnumerator.Current))
                {
                    yield return '_';
                    yield return char.ToLower(letterEnumerator.Current);
                }
                else
                {
                    yield return letterEnumerator.Current;
                }
            }
        }

        return new string(Convert(text.GetEnumerator()).ToArray());
    }
}