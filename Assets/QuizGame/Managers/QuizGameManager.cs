using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class QuizGameManager : Singleton<QuizGameManager>
{
    public GameModel Configuration;

    public int currentQuestionIndex;

    List<int> askedQuestionIndex = new List<int>();

    public int TotalQuestionsCount;

    public QuestionModel GetQuestionForCategory(string categoryName)
    {
        CategoryModel categoryModel = Configuration.Categories.FirstOrDefault(category => category.CategoryName == categoryName);
        if (categoryModel != null)
        {
            TotalQuestionsCount = categoryModel.questions.Count;
            int randomIndex = Random.Range(0, categoryModel.questions.Count);
            while (categoryModel.questions.Count > askedQuestionIndex.Count && askedQuestionIndex.Contains(randomIndex))
                randomIndex = Random.Range(0, categoryModel.questions.Count);

            askedQuestionIndex.Add(randomIndex);

            return categoryModel.questions[randomIndex];

            //if (currentQuestionIndex <= categoryModel.questions.Count -1)
                //return categoryModel.questions[currentQuestionIndex++];
            //else return null;
        }
        return null;
    }
}
