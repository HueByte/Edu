using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

Console.WriteLine("Hello, World!");
Console.WriteLine(LongestPalindrome("aaaabaaa"));

Console.WriteLine(LongestPalindrome("aaaa"));
Console.WriteLine(LongestPalindrome("ccd"));
Console.WriteLine(LongestPalindrome("abb"));
Console.WriteLine(LongestPalindrome("aabba"));
Console.WriteLine(LongestPalindrome("ccc"));
Console.WriteLine(LongestPalindrome("cccw"));
Console.WriteLine(LongestPalindrome("qqweeeww"));
Console.WriteLine(LongestPalindrome("qoijiejeieeeeeei"));
Console.WriteLine(LongestPalindrome("aaaaaaaaaaaaaaaaaaaaaaaab"));
Console.WriteLine(LongestPalindrome("babad"));
Console.WriteLine(LongestPalindrome("caba"));
Console.WriteLine(LongestPalindrome("cabaq"));
Console.WriteLine(LongestPalindrome("vommleztyrbrnoij"));
Console.WriteLine(LongestPalindrome("1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111"));


string LongestPalindrome(string s)
{
    if (s.Length <= 1) return s;
    char currentChar;
    int startMark;
    string currentLongest = "";

    for (int i = 0; i < s.Length; i++)
    {
        if (currentLongest.Length >= s.Length - i) break;

        currentChar = s[i];
        startMark = i;

        for (int z = s.Length - 1; z >= 0; z--)
        {
            if (currentChar == s[z])
            {
                string palindrome = GetPalidrome(s, startMark, z);
                if (palindrome != "")
                {
                    if (palindrome.Length > currentLongest.Length)
                        currentLongest = palindrome;
                    break;
                }
            }
        }
    }

    return currentLongest;
}

string GetPalidrome(string input, int start, int end)
{
    for (int y = 0; y < end - start; y++)
    {
        if (input[start + y] != input[end - y])
        {
            return "";
        }
    }

    return input[start..(end + 1)];
}

string OldSolution(string s)
{
    if (s.Length == 1) return s;

    List<string> words = new();
    char currentChar;

    for (int i = 0; i < s.Length; i++)
    {
        currentChar = s[i];
        int startMark = i;
        List<int> endMarks = new();

        // find ending index
        for (int z = startMark + 1; z < s.Length; z++)
        {
            if (currentChar == s[z])
                endMarks.Add(z);
        }

        for (int q = endMarks.Count - 1; q >= 0; q--)
        {
            // check if possible to be palindrome
            if (startMark >= endMarks[q]) continue;

            // verify palindrome
            bool skip = false;
            for (int y = 0; y < endMarks[q] - startMark; y++)
            {
                if (s[startMark + y] != s[endMarks[q] - y])
                {
                    skip = true;
                    break;
                }
            }

            if (skip) continue;

            // add to words
            words.Add(s[startMark..(endMarks[q] + 1)]);
            break;
        }
    }

    if (words.Count <= 0) return s[0].ToString();

    // find largest
    int max = 0;
    int index = 0;
    for (int i = 0; i < words.Count; i++)
    {
        if (words[i].Length > max)
        {
            max = words[i].Length;
            index = i;
        }
    }

    return words[index];
}