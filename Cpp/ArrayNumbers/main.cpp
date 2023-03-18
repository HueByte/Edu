#include <iostream>
#include <vector>
#include <algorithm>

using namespace std;

int power(int x, int n)
{
    if (n == 0)
        return 1;

    if (x == 0)
        return 0;

    return x * power(x, n - 1);
}

vector<int> arrayize(int num)
{
    vector<int> arr;
    while (num > 0)
    {
        arr.push_back(num % 10);
        num /= 10;
    }

    std::reverse(arr.begin(), arr.end());

    return arr;
}

auto get_measured_arrays(vector<int> &arr1, vector<int> &arr2)
{
    int addNext = 0;
    vector<int> *largerArr = nullptr;
    vector<int> *smallerArr = nullptr;

    if (arr1.size() > arr2.size())
    {
        largerArr = &arr1;
        smallerArr = &arr2;
    }
    else
    {
        largerArr = &arr2;
        smallerArr = &arr1;
    }

    struct result
    {
        vector<int> *largerArr;
        vector<int> *smallerArr;
    };

    return result{largerArr, smallerArr};
}

int add(vector<int> &arr1, vector<int> &arr2)
{
    auto measured = get_measured_arrays(arr1, arr2);
    std::vector<int> &largerArr = *(measured.largerArr);
    std::vector<int> &smallerArr = *(measured.smallerArr);

    int result = 0;
    int carry = 0;

    int largerSize = largerArr.size();
    int smallerSize = smallerArr.size();

    for (int i = 0; i < largerSize; i++)
    {
        int temp = largerArr[largerSize - 1 - i] + carry;
        if (i < smallerSize)
        {
            temp += smallerArr[smallerSize - 1 - i];
        }

        carry = temp / 10;
        result += temp % 10 * power(10, i);
    }
    if (carry > 0)
    {
        result += carry * power(10, largerSize);
    }

    return result;
}

int multiply(vector<int> &arr1, vector<int> &arr2)
{
    auto measured = get_measured_arrays(arr1, arr2);
    std::vector<int> &largerArr = *(measured.largerArr);
    std::vector<int> &smallerArr = *(measured.smallerArr);

    int result = 0;
    int carry = 0;

    for (int i = 0; i < smallerArr.size(); i++)
    {
        int subresult = 0;

        for (int j = 0; j < largerArr.size(); j++)
        {
            int temp = largerArr[largerArr.size() - 1 - j] * smallerArr[smallerArr.size() - 1 - i] + carry;
            carry = temp / 10;
            subresult += temp % 10 * power(10, j);
        }

        if (carry > 0)
        {
            subresult += carry * power(10, largerArr.size());
            carry = 0;
        }

        result += subresult * power(10, i);
    }

    return result;
}

int main()
{
    int firstNum = 0;
    cout << "Enter a number 1: ";
    cin >> firstNum;

    int secondNum = 0;
    cout << "Enter a number 1: ";
    cin >> secondNum;

    vector<int> arrFirst = arrayize(firstNum);
    vector<int> arrSecond = arrayize(secondNum);

    int addResult = add(arrFirst, arrSecond);
    int multiplyResult = multiply(arrFirst, arrSecond);

    cout << "Add result: " << addResult << endl;
    cout << "Multiply result: " << multiplyResult;
}