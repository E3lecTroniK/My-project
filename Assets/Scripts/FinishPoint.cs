using UnityEngine;

public class FinishPoint : MonoBehaviour
{
    [SerializeField] bool goNextLevel;
    [SerializeField] string LevelName;

    private void OnTriggerEnter2D(Collider2D Collision)
    {
        if (Collision.CompareTag("Player"))
        {
            if (goNextLevel)
            {
                Scenecontroller.instance.NextLevel();
            }
            else
            {
                Scenecontroller.instance.LoadScene(LevelName);
            }
        }
    }
}