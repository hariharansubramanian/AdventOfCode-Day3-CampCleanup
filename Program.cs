using System.Collections.Immutable;

Console.WriteLine("Analyzing assigned sections");
var assignedSections = File.ReadLines("assigned_sections.txt").ToList();

// Puzzle 1
var overlappingSectionsCount = 0;
assignedSections.ForEach(pair =>
{
    var sectionRanges = ParseSections(pair).ToImmutableArray();
    if (IsOverlapping(sectionRanges[0], sectionRanges[1])) overlappingSectionsCount++;
});
Console.WriteLine($"There are {overlappingSectionsCount} assigned sections that are overlapping.");


// Puzzle 2
var intersectingSectionsCount = 0;
assignedSections.ForEach(pair =>
{
    var sectionRanges = ParseSections(pair).ToImmutableArray();
    if (IsIntersecting(sectionRanges[0], sectionRanges[1])) intersectingSectionsCount++;
});
Console.WriteLine($"There are {intersectingSectionsCount} assigned sections that are partially overlapping.");

// Functions
IEnumerable<Range> ParseSections(string assignmentPair)
{
    return assignmentPair.Split(',').Select(GetRange).ToList();
}

Range GetRange(string assignmentPair)
{
    var sections = assignmentPair.Split('-').Select(int.Parse).ToArray();
    return new Range(sections[0], sections[1]);
}

bool IsOverlapping(Range startRange, Range endRange)
{
    return (startRange.Start.Value <= endRange.Start.Value && startRange.End.Value >= endRange.End.Value) || (endRange.Start.Value <= startRange.Start.Value && endRange.End.Value >= startRange.End.Value);
}

bool IsIntersecting(Range startRange, Range endRange)
{
    return startRange.Start.Value <= endRange.End.Value && endRange.Start.Value <= startRange.End.Value;
}