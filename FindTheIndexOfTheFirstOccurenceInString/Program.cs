
var result = StrStr("sadbutsad", "sad");
Console.WriteLine(result);

int StrStr(string haystack, string needle) {
    return haystack.IndexOf(needle, StringComparison.Ordinal);
}