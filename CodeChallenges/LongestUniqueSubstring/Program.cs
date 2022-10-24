using System.Diagnostics;
using System.Text;

Console.WriteLine("Hello, World!");
Stopwatch watch = new();
watch.Start();

Console.WriteLine(LengthOfLongestSubstring("abcabcbb"));
Console.WriteLine(LengthOfLongestSubstring("bbbbb"));
Console.WriteLine(LengthOfLongestSubstring("pwwkew"));
Console.WriteLine(LengthOfLongestSubstring("au"));
Console.WriteLine(LengthOfLongestSubstring("aab"));
Console.WriteLine(LengthOfLongestSubstring("dvdf"));

Console.WriteLine(watch.ElapsedTicks);

// 40973 - leet: 69ms
int LengthOfLongestSubstring(string s)
{
    if (s.Length <= 1) return s.Length;
    int biggestSize = 0, startIndex = 0;

    Dictionary<char, int> uniqChars = new();
    for (int i = 0; i < s.Length; i++)
    {
        if (uniqChars.ContainsKey(s[i]))
        {
            int lastIndex = uniqChars[s[i]];
            uniqChars[s[i]] = i;


            if (lastIndex >= startIndex)
            {
                startIndex = lastIndex + 1;
            }
        }
        else
        {
            uniqChars.Add(s[i], i);
        }

        biggestSize = Math.Max(biggestSize, i - startIndex + 1);
    }

    return biggestSize;
}

// best of 5 - 40268 - leet: 250ms
int OldLengthOfLongestSubstring(string s)
{
    if (s.Length <= 1) return s.Length;

    HashSet<char> chars = new();
    int biggestSize = 0;
    for (int i = 0; i < s.Length; i++)
    {
        if (biggestSize == s.Length) return biggestSize;

        chars.Add(s[i]);

        for (int z = i + 1; z < s.Length; z++)
        {
            if (chars.Contains(s[z])) break;
            chars.Add(s[z]);
        }

        if (chars.Count > biggestSize)
            biggestSize = chars.Count;

        chars = new();
    }

    return biggestSize;
}


