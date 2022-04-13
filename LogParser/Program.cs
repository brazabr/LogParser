using System.IO;
using System.Text.RegularExpressions;

const string regExpression = @"^(?<horario>[0-9:]+)\sKill:\s[0-9\s]+:\s(?<quem_matou>[\<\>\w]+)\skilled\s(?<quem_morreu>[\w\s]+)\sby\s(?<causa_morte>\w+)$";

var allLines = File.ReadAllLines("Quake.txt");

var total_kills = 0;

foreach (var line in allLines)
{
    var parsedLine = Regex.Match(line, regExpression);

    if (parsedLine.Success)
    {
        var horario = parsedLine.Groups["horario"].Value;
        var quem_matou = parsedLine.Groups["quem_matou"].Value;
        var quem_morreu = parsedLine.Groups["quem_morreu"].Value;
        var causa_morte = parsedLine.Groups["causa_morte"].Value;

        Console.WriteLine("{0} matou {1} usando {2} no horário {3}", quem_matou, quem_morreu, causa_morte, horario);

        total_kills++;
    }
}

Console.WriteLine("{0} mortes no total", total_kills);

Console.ReadKey();