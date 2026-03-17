using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static int totalScore = 0;

    public static void AddScore(int points)
    {
        totalScore += points;
        Debug.Log("сумокийо сйоя: " + totalScore);
    }
}