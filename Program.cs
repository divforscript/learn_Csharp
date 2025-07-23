using System;

/* 
This C# console application is designed to:
- Use arrays to store student names and assignment scores.
- Use a `foreach` statement to iterate through the student names as an outer program loop.
- Use an `if` statement within the outer loop to identify the current student name and access that student's assignment scores.
- Use a `foreach` statement within the outer loop to iterate though the assignment scores array and sum the values.
- Use an algorithm within the outer loop to calculate the average exam score for each student.
- Use an `if-elseif-else` construct within the outer loop to evaluate the average exam score and assign a letter grade automatically.
- Integrate extra credit scores when calculating the student's final score and letter grade as follows:
    - detects extra credit assignments based on the number of elements in the student's scores array.
    - divides the values of extra credit assignments by 10 before adding extra credit scores to the sum of exam scores.
- use the following report format to report student grades: 

    Student         Grade

    Sophia:         92.2    A-
    Andrew:         89.6    B+
    Emma:           85.6    B
    Logan:          91.2    A-


    Final format:

    Student         Exam Score      Overall Grade   Extra Credit

    Sophia          92.2            95.88   A       92 (3.68 pts)
*/


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

Console.WriteLine($"{"Student",-12}{"Exam Score",-16}{"Overall Grade",-16}Extra Credit\n");

foreach (string name in studentNames)
{
    

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
    int studentExamSum = 0;
    int studentExtraSum = 0;
    
    foreach (int score in studentScores)
    {
        gradedAssignments++;

        if (gradedAssignments <= examAssignments)
        {
            studentExamSum += score;
        }
        else
        {
            studentExtraSum += score;
        }
    }

    decimal studentExamScore = 0.0m;
    studentExamScore = (decimal)studentExamSum / examAssignments;

    decimal studentScore = 0;
    studentScore = (decimal)(studentExamSum + 0.1 * studentExtraSum) / examAssignments;

    decimal studentExtraScore = 0.0m;
    studentExtraScore = (decimal)studentExtraSum / (gradedAssignments - examAssignments);

    string nameLetterGrade = "";

    // Asgin grade letter based on studentScore rate:
    if (studentScore >= 97)
        nameLetterGrade = "A+";

    else if (studentScore >= 93)
        nameLetterGrade = "A ";

    else if (studentScore >= 90)
        nameLetterGrade = "A-";

    else if (studentScore >= 87)
        nameLetterGrade = "B+";

    else if (studentScore >= 83)
        nameLetterGrade = "B ";

    else if (studentScore >= 80)
        nameLetterGrade = "B-";

    else if (studentScore >= 77)
        nameLetterGrade = "C+";

    else if (studentScore >= 73)
        nameLetterGrade = "C ";

    else if (studentScore >= 70)
        nameLetterGrade = "C-";

    else if (studentScore >= 67)
        nameLetterGrade = "D+";

    else if (studentScore >= 63)
        nameLetterGrade = "D ";

    else if (studentScore >= 60)
        nameLetterGrade = "D-";

    else
        nameLetterGrade = "F ";

    Console.WriteLine($"{name + ":",-12}{studentExamScore,-16}{studentScore,-8:F2}{nameLetterGrade,-8}{studentExtraScore} ({studentScore - studentExamScore,0:F2} pts)");

}

// Sophia:     92.2            95.88       A 92 (3.68 pts)


// Student     Exam Score      Overall Grade    Extra Credit
// Sophia:     92.2            95.88A          92 (3.68 pts)