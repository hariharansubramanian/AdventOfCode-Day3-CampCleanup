Console.WriteLine("Analyzing assigned sections");

var assignedSections = File.ReadLines("assigned_sections.txt").ToList();

// Puzzle 1
var completelyOverlappingSectionsCount = 0;
assignedSections.ForEach(pair =>
{
    var (firstElfSections, secondElfSections) = GetAssignedSections(pair);
    if (firstElfSections.All(s => secondElfSections.Contains(s)) || secondElfSections.All(s => firstElfSections.Contains(s))) completelyOverlappingSectionsCount++;
});

Console.WriteLine($"There are {completelyOverlappingSectionsCount} assigned sections that are completely overlapping.");

// Puzzle 2
var partiallyOverlappingSectionsCount = 0;
assignedSections.ForEach(pair =>
{
    var (firstElfSections, secondElfSections) = GetAssignedSections(pair);
    if (firstElfSections.Any(s => secondElfSections.Contains(s)) || secondElfSections.Any(s => firstElfSections.Contains(s))) partiallyOverlappingSectionsCount++;
});

Console.WriteLine($"There are {partiallyOverlappingSectionsCount} assigned sections that are partially overlapping.");

Console.WriteLine("Finished analyzing assigned camp sections.");


// Functions
(List<int> firstElfSections, List<int> secondElfSections) GetAssignedSections(string assignmentPair)
{
    var sections = assignmentPair.Split(',');
    var firstElfSectionTag = sections[0].Split("-").Select(int.Parse).ToArray();
    var secondElfSectionTag = sections[1].Split("-").Select(int.Parse).ToArray();

    var firstElfSections = Enumerable.Range(firstElfSectionTag[0], firstElfSectionTag[1] - firstElfSectionTag[0] + 1).ToList();
    var secondElfSections = Enumerable.Range(secondElfSectionTag[0], secondElfSectionTag[1] - secondElfSectionTag[0] + 1).ToList();
    return (firstElfSections, secondElfSections);
}