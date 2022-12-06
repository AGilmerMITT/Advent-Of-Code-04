namespace Advent_Of_Code_04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int containedAssignments = 0;
            int overlappedAssignments = 0;

            bool collectingData = true;
            while (collectingData)
            {
                string input = GetInput("Assignments: ");
                if (input == "")
                {
                    collectingData = false;
                    break;
                }

                string[] assignments = input.Split(',');
                string a1 = assignments[0];
                string a2 = assignments[1];

                string[] a1Split = a1.Split('-');
                string[] a2Split = a2.Split('-');

                int a1Start = int.Parse(a1Split[0]);
                int a1End = int.Parse(a1Split[1]);

                int a2Start = int.Parse(a2Split[0]);
                int a2End = int.Parse(a2Split[1]);

                if (AContainsB(a1Start, a1End, a2Start, a2End) || AContainsB(a2Start, a2End, a1Start, a1End))
                {
                    containedAssignments++;
                }

                if (AOverlapsB(a1Start, a1End, a2Start, a2End))
                {
                    overlappedAssignments++;
                }
            }
            Console.WriteLine("Contained: " + containedAssignments + ", Overlapped: " + overlappedAssignments);
        }

        static string GetInput(string prompt)
        {
            bool validResult = false;
            string? input = null;
            while (!validResult)
            {
                Console.WriteLine(prompt);
                input = Console.ReadLine();
                if (input != null)
                {
                    validResult = true;
                }
            }

            return input!;
        }

        static bool AContainsB(int aStart, int aEnd, int bStart, int bEnd)
        {
            return aStart <= bStart && aEnd >= bEnd;
        }

        static bool AOverlapsB(int aStart, int aEnd, int bStart, int bEnd)
        {
            return (aStart <= bStart && aEnd >= bStart) || (bStart <= aStart && bEnd >= aStart);
        }
    }
}