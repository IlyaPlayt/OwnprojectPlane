    using UnityEngine;
    using UnityEngine.UI;

    public class WinPopup: MonoBehaviour
    {
        [SerializeField] private Text score;
        
        [SerializeField] public Button restartButton;
        [SerializeField] public Button exitButton;

        public void Activate(int score)
        {
            this.score.text = score.ToString();
            gameObject.SetActive(true);   
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
