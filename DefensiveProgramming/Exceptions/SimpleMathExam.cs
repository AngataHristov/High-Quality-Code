using System;

public class SimpleMathExam : Exam
{
    public const int MinGrade = 2;
    public const int MaxGrade = 6;
    public const int MinProblemsCount = 0;
    public const int MaxProblemsCount = 2;

    private int problemSolved;

    public SimpleMathExam(int problemsSolved)
    {
        this.ProblemsSolved = problemsSolved;
    }

    public int ProblemsSolved
    {
        get
        {
            return this.problemSolved;
        }
        private set
        {
            if (value < MinProblemsCount || value > MaxProblemsCount)
            {
                throw new ArgumentException("Problems solved count has invalid value.");
            }

            this.problemSolved = value;
        }
    }

    public override ExamResult Check()
    {
        ExamResult result = null;

        switch (this.ProblemsSolved)
        {
            case 0:
                result = new ExamResult(2, MinGrade, MaxGrade, "Bad result: nothing done.");
                break;
            case 1:
                result = new ExamResult(4, MinGrade, MaxGrade, "Average result: nothing done.");
                break;
            case 2:
                result = new ExamResult(6, MinGrade, MaxGrade, "Average result: nothing done.");
                break;
            default:
                throw new ArgumentException("Invalid number of problems solved!");
                break;
        }

        return result;
    }
}
