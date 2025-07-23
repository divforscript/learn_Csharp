using System;

/*  Exercise: Update the final grade calculation program creating
arrays and foreach loops
*/

// initialize variables - graded assignments
// int sophia1 = 90;
// int sophia2 = 86;
// int sophia3 = 87;
// int sophia4 = 98;
// int sophia5 = 100;

// int andrew1 = 92;
// int andrew2 = 89;
// int andrew3 = 81;
// int andrew4 = 96;
// int andrew5 = 90;

// int emma1 = 90;
// int emma2 = 85;
// int emma3 = 87;
// int emma4 = 98;
// int emma5 = 68;

// int logan1 = 90;
// int logan2 = 95;
// int logan3 = 87;
// int logan4 = 88;
// int logan5 = 96;

// sophiaSum = sophia1 + sophia2 + sophia3 + sophia4 + sophia5;
// andrewSum = andrew1 + andrew2 + andrew3 + andrew4 + andrew5;
// emmaSum = emma1 + emma2 + emma3 + emma4 + emma5;
// loganSum = logan1 + logan2 + logan3 + logan4 + logan5;
int examAssignments = 5;

int[] sophiaScores = new int[] { 90, 86, 87, 98, 100, 94, 90 };
int[] andrewScores = new int[] { 92, 89, 81, 96, 90, 89 };
int[] emmaScores = new int[] { 90, 85, 87, 98, 68, 89, 89, 89 };
int[] loganScores = new int[] { 90, 95, 87, 88, 96, 96 };
int[] beckyScores = new int[] { 92, 91, 90, 91, 92, 92, 92 };
int[] chrisScores = new int[] { 84, 86, 88, 90, 92, 94, 96, 98 };
int[] ericScores = new int[] { 80, 90, 100, 80, 90, 100, 80, 90 };
int[] gregorScores = new int[] { 91, 91, 91, 91, 91, 91, 91 };

// Student names
string[] studentNames = new string[] { "Sophia", "Andrew", "Emma", "Logan", "Becky", "Chris", "Eric", "Gregor" };

int[] studentScores = new int[10];

Console.WriteLine("Student\t\tGrade\n");
foreach (string name in studentNames)
{
    int studentSum = 0;
    decimal studentScore = 0;
    string nameLetterGrade = "";

    if (name == "Sophia")
    {
        studentScores = sophiaScores;
    }

    else if (name == "Andrew")
    {
        studentScores = andrewScores;
    }

    else if (name == "Emma")
    {
        studentScores = emmaScores;
    }

    else if (name == "Logan")
    {
        studentScores = loganScores;
    }

    else if (name == "Becky")
        studentScores = beckyScores;

    else if (name == "Chris")
        studentScores = chrisScores;

    else if (name == "Eric")
        studentScores = ericScores;

    else if (name == "Gregor")
        studentScores = gregorScores;
        
    else
        continue;

    // initialize/reset a counter for the number of assignments
    int gradedAssignments = 0;
    foreach (int score in studentScores)
    {
        gradedAssignments++;

        if (gradedAssignments <= examAssignments)
        {
            studentSum += score;
        }
        else
        {
            studentSum += score / 10;
        }
    }

    studentScore = (decimal)studentSum / examAssignments;

    // Asgin grade letter based on studentScore rate:
    if (studentScore >= 97)
        nameLetterGrade = "A+";

    else if (studentScore >= 93)
        nameLetterGrade = "A";

    else if (studentScore >= 90)
        nameLetterGrade = "A-";

    else if (studentScore >= 87)
        nameLetterGrade = "B+";

    else if (studentScore >= 83)
        nameLetterGrade = "B";

    else if (studentScore >= 80)
        nameLetterGrade = "B-";

    else if (studentScore >= 77)
        nameLetterGrade = "C+";

    else if (studentScore >= 73)
        nameLetterGrade = "C";

    else if (studentScore >= 70)
        nameLetterGrade = "C-";

    else if (studentScore >= 67)
        nameLetterGrade = "D+";

    else if (studentScore >= 63)
        nameLetterGrade = "D";

    else if (studentScore >= 60)
        nameLetterGrade = "D-";

    else
        nameLetterGrade = "F";

    Console.WriteLine($"{name}:\t\t{studentScore}\t{nameLetterGrade}");

}

Console.WriteLine("Press the Enter key to continue");
Console.ReadLine();




