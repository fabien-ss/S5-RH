namespace S5_RH.Models.Front.Candidature;

public class QuestionnaireForm
{
    public String[][] Questions { get; set; }

    public void showQuestion()
    {
        for (int i = 0; i < Questions.Length; i++)
        {
            Console.WriteLine("Question "+i+ " "+Questions[i][0]);
            for (int j = 1; j < Questions[i].Length; j++)
            {
                Console.WriteLine("Reponse "+Questions[i][j]);
            }
        }
    }
}