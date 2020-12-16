using System.Collections.Generic;
using System;
using System.Linq;
using System.IO;

var data = (await File.ReadAllTextAsync("data.txt")).Split(',').Select(c => Convert.ToInt32(c)).ToList();
var initialSet = data.Count;
var initialIndex = 0;
var numbers = data.ToDictionary(n => n, n => ++initialIndex);

for (var index = initialSet; index < 2020; index++)
{
    var number = data[index - 1];

    var seenAtleastOnce = numbers.ContainsKey(number);
    if (!seenAtleastOnce)
    {
        numbers[number] = index;
        data.Add(0);
    }
    else
    {
        var last = numbers[number];
        var next = index - last;
        numbers[number] = index;
        data.Add(next);
    }
}

Console.WriteLine(data.Aggregate("", (curr, next) => curr += next.ToString() + ", "));
Console.WriteLine(data.Last());

