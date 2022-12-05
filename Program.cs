Console.WriteLine("Analyzing assigned sections");
var assignedSections = File.ReadLines("assigned_sections.txt").ToList();

// Puzzle 1
var overlappingSectionsCount = 0;
assignedSections.ForEach(pair =>
{
    var (startSection1, endSection1, startSection2, endSection2) = ParseSections(pair);
    if (IsOverlapping(startSection1, endSection1, startSection2, endSection2)) overlappingSectionsCount++;
});
Console.WriteLine($"There are {overlappingSectionsCount} assigned sections that are overlapping.");


// Puzzle 2
var intersectingSectionsCount = 0;
assignedSections.ForEach(pair =>
{
    var (startSection1, endSection1, startSection2, endSection2) = ParseSections(pair);
    if (IsIntersecting(startSection1, endSection1, startSection2, endSection2)) intersectingSectionsCount++;
});
Console.WriteLine($"There are {intersectingSectionsCount} assigned sections that are partially overlapping.");

// Functions
(int startSection1, int endSection1, int startSection2, int endSection2) ParseSections(string assignmentPair)
{
    var sectionRanges = assignmentPair.Split(',');
    var (startSection1, endSection1) = GetRange(sectionRanges[0]);
    var (startSection2, endSection2) = GetRange(sectionRanges[1]);
    return (startSection1, endSection1, startSection2, endSection2);
}

(int startSection, int endSection) GetRange(string assignmentPair)
{
    var sections = assignmentPair.Split('-').Select(int.Parse).ToArray();
    return (sections[0], sections[1]);
}

bool IsOverlapping(int start1, int end1, int start2, int end2)
{
    return start1 <= start2 && end1 >= end2 || start2 <= start1 && end2 >= end1;
}

bool IsIntersecting(int start1, int end1, int start2, int end2)
{
    return start1 <= start2 && end1 >= start2 || start2 <= start1 && end2 >= start1;
}