using System;

public class CSharpExam : Exam
{
    public const int MinGrade = 0;
    public const int MaxGrade = 100;

    private int score;

    public CSharpExam(int score)
    {
        this.Score = score;
    }

    public int Score
    {
        get
        {
            return this.score;
        }
        private set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentOutOfRangeException(string.Format("Score shoud be in rage [{0}...{1}]!", MinGrade, MaxGrade));
            }

            this.score = value;
        }
    }

    public override ExamResult Check()
    {
        return new ExamResult(this.Score, MinGrade, MaxGrade, "Exam results calculated by score.");
    }
}
