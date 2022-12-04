Console.WriteLine("Analyzing assigned sections");

var assignedSections = File.ReadLines("assigned_sections.txt").ToList();

// Puzzle 1
var completelyOverlappingSectionsCount = 0;
assignedSections.ForEach(pair =>
{
    var sections = pair.Split(',');
    var firstElfSectionTag = sections[0].Split("-");
    var secondElfSectionTag = sections[1].Split("-");

    var firstElfSections = Enumerable.Range(int.Parse(firstElfSectionTag[0]), int.Parse(firstElfSectionTag[1]) - int.Parse(firstElfSectionTag[0]) + 1).ToList();
    var secondElfSections = Enumerable.Range(int.Parse(secondElfSectionTag[0]), int.Parse(secondElfSectionTag[1]) - int.Parse(secondElfSectionTag[0]) + 1).ToList();

    if (firstElfSections.All(s => secondElfSections.Contains(s)) || secondElfSections.All(s => firstElfSections.Contains(s))) completelyOverlappingSectionsCount++;
});

Console.WriteLine($"There are {completelyOverlappingSectionsCount} assigned sections that are completely overlapping.");

// Puzzle 2
var partiallyOverlappingSectionsCount = 0;
assignedSections.ForEach(pair =>
{
    var sections = pair.Split(',');
    var firstElfSectionTag = sections[0].Split("-");
    var secondElfSectionTag = sections[1].Split("-");

    var firstElfSections = Enumerable.Range(int.Parse(firstElfSectionTag[0]), int.Parse(firstElfSectionTag[1]) - int.Parse(firstElfSectionTag[0]) + 1).ToList();
    var secondElfSections = Enumerable.Range(int.Parse(secondElfSectionTag[0]), int.Parse(secondElfSectionTag[1]) - int.Parse(secondElfSectionTag[0]) + 1).ToList();

    if (firstElfSections.Any(s => secondElfSections.Contains(s)) || secondElfSections.Any(s => firstElfSections.Contains(s))) partiallyOverlappingSectionsCount++;
});

Console.WriteLine($"There are {partiallyOverlappingSectionsCount} assigned sections that are partially overlapping.");

Console.WriteLine("Finished analyzing assigned camp sections.");