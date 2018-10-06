using System.Collections.Generic;
using System.Text;
using strange.extensions.mediation.impl;
using Server.Services;
using Server.Signals;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace Server.Views
{
    public class ServerView : EventView
    {
        /// <summary>
        /// Port field
        /// </summary>
        [SerializeField] private InputField _posrtField;

        /// <summary>
        /// Start server button
        /// </summary>
        [SerializeField] private Button _startButton;

        /// <summary>
        /// Stop server button
        /// </summary>
        [SerializeField] private Button _stopButton;

        /// <summary>
        /// Restart server button
        /// </summary>
        [SerializeField] private Button _restartButton;

        /// <summary>
        /// Log text
        /// </summary>
        [SerializeField] private Text _logText;

        /// <summary>
        /// Networking game server
        /// </summary>
        [Inject]
        public GameServerService GameServerService { get; set; }

        /// <summary>
        /// Start server signal
        /// </summary>
        [Inject]
        public StartServerSignal StartServerSignal { get; set; }

        /// <summary>
        /// Server port
        /// </summary>
        private int _serverPort = 45555;

        /// <summary>
        /// SErver status
        /// </summary>
        private string _serverStatus = "disconnected";

        /// <summary>
        /// Server errors
        /// </summary>
        private readonly List<string> _serverErrors = new List<string>();

        /// <summary>
        /// On enable view
        /// </summary>
        private void OnEnable()
        {
            _posrtField.text = _serverPort.ToString();
            // on end edit save port
            _posrtField.onEndEdit.AddListener(delegate
            {
                _serverPort = int.TryParse(_posrtField.text, out _serverPort) ? _serverPort : 45555;
                _posrtField.text = _serverPort.ToString();
            });

            // add buttons on click events
            _startButton.onClick.AddListener(() => { StartServerSignal.Dispatch(_serverPort); });
            _restartButton.onClick.AddListener(() => { GameServerService.Restart(_serverPort); });
            _stopButton.onClick.AddListener(() => { GameServerService.Shutdown(); });
        }

        /// <summary>
        /// Update view
        /// </summary>
        private void Update()
        {
            if (!NetworkServer.active)
            {
                _startButton.gameObject.SetActive(true);
                _stopButton.gameObject.SetActive(false);
                _restartButton.gameObject.SetActive(false);
                _logText.gameObject.SetActive(false);
            }
            else
            {
                _startButton.gameObject.SetActive(false);
                _stopButton.gameObject.SetActive(true);
                _restartButton.gameObject.SetActive(true);
                _logText.gameObject.SetActive(true);

                InitLog();
            }
        }

        /// <summary>
        /// Init text log
        /// </summary>
        private void InitLog()
        {
            var textBulder = new StringBuilder();
            textBulder.AppendLine("Server status:" + _serverStatus);
            textBulder.AppendLine("Server Errors: \n");

            foreach (var serverError in _serverErrors)
            {
                textBulder.AppendLine(serverError);
                Debug.LogError(serverError);
            }

            _logText.text = textBulder.ToString();
        }


        /// <summary>
        /// On change status
        /// </summary>
        /// <param name="str"></param>
        public void ChangeStatus(string str)
        {
            _serverStatus = str;
        }

        /// <summary>
        /// Add server errors
        /// </summary>
        /// <param name="errorMsg"></param>
        public void OnGameServerError(string errorMsg)
        {
            _serverErrors.Add(errorMsg);
        }
    }
}