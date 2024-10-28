using System;
using System.Collections.Generic;

var dictionary = new Dictionary<string, int> { { "One", 1 }, { "Two", 2 } };
foreach (var item in dictionary)
    Console.WriteLine($"{item.Key}: {item.Value}");
