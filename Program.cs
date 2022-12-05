Console.WriteLine("Analyzing assigned sections");

var assignedSections = File.ReadLines("assigned_sections.txt").ToList();

#region Puzzle 1

var completelyOverlappingSectionsCount = 0;
assignedSections.ForEach(pair =>
{
    var (firstElfStart, firstElfEnd, secondElfStart, secondElfEnd) = GetAssignedSections(pair);
    if (IsOverlapping(firstElfStart, firstElfEnd, secondElfStart, secondElfEnd)) completelyOverlappingSectionsCount++;
});
Console.WriteLine($"There are {completelyOverlappingSectionsCount} assigned sections that are completely overlapping.");

#endregion

#region Puzzle 2

var intersectingSectionsCount = 0;
assignedSections.ForEach(pair =>
{
    var (firstElfStart, firstElfEnd, secondElfStart, secondElfEnd) = GetAssignedSections(pair);
    if (IsIntersecting(firstElfStart, firstElfEnd, secondElfStart, secondElfEnd)) intersectingSectionsCount++;
});
Console.WriteLine($"There are {intersectingSectionsCount} assigned sections that are partially overlapping.");

#endregion

#region Functions

(int firstElfStart, int firstElfEnd, int secondElfStart, int secondElfEnd) GetAssignedSections(string assignmentPair)
{
    var sections = assignmentPair.Split(',');
    var firstElfSectionTag = sections[0].Split("-").Select(int.Parse).ToArray();
    var firstElfStart = firstElfSectionTag[0];
    var firstElfEnd = firstElfSectionTag[1];

    var secondElfSectionTag = sections[1].Split("-").Select(int.Parse).ToArray();
    var secondElfStart = secondElfSectionTag[0];
    var secondElfEnd = secondElfSectionTag[1];

    return (firstElfStart, firstElfEnd, secondElfStart, secondElfEnd);
}

bool IsOverlapping(int start1, int end1, int start2, int end2)
{
    return start1 <= start2 && end1 >= end2 || start2 <= start1 && end2 >= end1;
}

bool IsIntersecting(int start1, int end1, int start2, int end2)
{
    return start1 <= start2 && end1 >= start2 || start2 <= start1 && end2 >= start1;
}

#endregion