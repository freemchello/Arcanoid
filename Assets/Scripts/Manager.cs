using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Arcanoid
{
    public class Manager : MonoBehaviour
    {
        [SerializeField] private LifeView _lifeView;
        [SerializeField] private ApplyDamageView _applyDamageView;


        public static int score;
        public static bool win;
        public static bool lose;
        public static int playerLife;

        public Text infoText;
        public GameObject winButton;
        public GameObject loseButton;


        void Start()
        {
            //MVVM
            var lifeModel = new LifeModel(4);
            var lifeViewModel = new LifeViewModel(lifeModel);
            _lifeView.Initialize(lifeViewModel);
            _applyDamageView.Initialize(lifeViewModel);


            winButton.SetActive(false);
            loseButton.SetActive(false);
            lose = false;
            win = false;
            Time.timeScale = 1;
            playerLife = 3;

        }
        void OnGUI()
        {
            if (win)
            {
                infoText.text = "!! ������. ��� ������� !!";
                winButton.SetActive(true);
                Time.timeScale = 0;
            }
            else if (lose)
            {
                infoText.text = "!! �� ��������� !!";
                loseButton.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                infoText.text = "����: " + score + " / �����: " + playerLife.ToString();
            }
        }


        public void GameStart(int level)
        {
            SceneManager.LoadScene(0/* + level*/);
        }
    }
}