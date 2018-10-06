using Client.Signals;
using strange.extensions.mediation.impl;
using Services;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Client.Views.UI
{
    public class MenuView : EventView
    {
        [SerializeField] private GameObject _content;

        [SerializeField] private GameObject _gameOverText;
        [SerializeField] private GameObject _welcomeText;
        [SerializeField] private GameObject _cubeWinText;
        [SerializeField] private GameObject _circleWinText;

        [SerializeField] private Button _startGame;
        [SerializeField] private Button _startServer;
        [SerializeField] private Button _quitGame;

        /// <summary>
        /// Game service
        /// </summary>
        [Inject]
        public GameService GameService { get; set; }

        /// <summary>
        /// Player service
        /// </summary>
        [Inject]
        public PlayerService PlayerService { get; set; }

        /// <summary>
        /// Game service
        /// </summary>
        [Inject]
        public GameOverSignal GameOverSignal { get; set; }

        protected override void Start()
        {
            _startServer.onClick.AddListener(() =>
            {
                _content.SetActive(false);
                SceneManager.LoadSceneAsync("ServerView", LoadSceneMode.Additive);
            });
            
            _startGame.onClick.AddListener(() =>
            {
                _content.SetActive(false);
                SceneManager.LoadSceneAsync("Game", LoadSceneMode.Additive);
            });

            _quitGame.onClick.AddListener(Application.Quit);

            GameOverSignal.AddListener(() =>
            {
                _content.SetActive(true);
                if (_gameOverText != null)
                {
                    _gameOverText.SetActive(true);
                }

                if (_welcomeText != null)
                {
                    _welcomeText.SetActive(false);
                }

                GameService.IsGameOver = false;

                if (!PlayerService.PlayerStatus)
                {
                    if (_cubeWinText != null)
                    {
                        _cubeWinText.SetActive(true);
                        _circleWinText.SetActive(false);
                    }
                    else
                    {
                        _circleWinText.SetActive(false);
                        _cubeWinText.SetActive(false);
                    }
                }
                else
                {
                    if (_circleWinText != null)
                    {
                        _circleWinText.SetActive(true);
                        _cubeWinText.SetActive(false);
                    }
                    else
                    {
                        _circleWinText.SetActive(false);
                        _cubeWinText.SetActive(false);
                    }
                }
            });
        }

        private void Update()
        {
            if (Input.GetKey("escape"))
            {
                Application.Quit();
            }
        }
    }
}