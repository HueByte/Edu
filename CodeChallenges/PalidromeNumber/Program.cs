Console.WriteLine(IsPalindrome(121));

static bool IsPalindrome(int x)
{
    if (x < 0) return false;
    if (x > 0 && x < 10) return true;

    string input = x.ToString();
    for (int i = 0; i < input.Length / 2; i++)
    {
        if (input[i] != input[^(i + 1)])
            return false;
    }

    return true;
}
