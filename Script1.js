int[] arr = { 1, 2, 2, 3, 4, 4, 5 };
int[] uniqueArr = arr.Distinct().ToArray();

Console.WriteLine("Array without duplicates: " + string.Join(", ", uniqueArr));
