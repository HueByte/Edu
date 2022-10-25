using System.Text;

Console.WriteLine("Hello, World!");
Console.WriteLine(Reverse(10000));
Console.WriteLine(Reverse(10201));
Console.WriteLine(Reverse(10231));
Console.WriteLine(Reverse(-123));
Console.WriteLine(Reverse(120));
Console.WriteLine(Reverse(123));
Console.WriteLine(Reverse(1534236469));
Console.WriteLine(Reverse(-2147483412));
// 2,147,483,648

static int Reverse(int x)
{
    bool isNegative = false;
    if (x < 0)
    {
        isNegative = true;
        x *= -1;
    }

    string xString = x.ToString();

    StringBuilder sb = new();
    if (isNegative) sb.Append('-');

    for (int i = xString.Length - 1; i >= 0; i--)
    {
        sb.Append(xString[i]);
    }

    _ = int.TryParse(sb.ToString(), out int result);
    return result;
}

static int Reverse2(int x)
{
    bool isNegative = x < 0;
    var charArr = x.ToString().ToCharArray();
    charArr = charArr.Reverse().ToArray();

    string stringResult = new(isNegative ? charArr[..^1] : charArr);

    if (!int.TryParse(stringResult, out int result))
        return 0;


    if (isNegative)
    {
        result *= -1;
    }

    return result;
}

