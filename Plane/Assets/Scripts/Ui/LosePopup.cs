

    using UnityEngine;
    using UnityEngine.UI;

    public class LosePopup: MonoBehaviour
    {
        [SerializeField] public Button restartButton;
        [SerializeField] public Button exitButton;
        [SerializeField] public Text reasonText;

        public void Activate (string reason)
        {
            reasonText.text = reason;
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
        
    }
