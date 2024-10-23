using System;
using System.Linq;

bool IsPrime(int num)
{
    if (num < 2) return false;
    for (int i = 2; i <= Math.Sqrt(num); i++)
    {
        if (num % i == 0) return false;
    }
    return true;
}

int[] arr = { 2, 3, 4, 5, 6, 7, 8, 9, 10 };
var primes = arr.Where(IsPrime).ToArray();

Console.WriteLine("Prime numbers: " + string.Join(", ", primes));
