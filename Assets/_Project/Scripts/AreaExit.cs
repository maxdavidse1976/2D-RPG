using UnityEngine;
using UnityEngine.SceneManagement;

namespace DragonspiritGames
{
    public class AreaExit : MonoBehaviour
    {
        [SerializeField] string _areaToLoad;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                SceneManager.LoadScene(_areaToLoad);
            }
        }
    } 
}
