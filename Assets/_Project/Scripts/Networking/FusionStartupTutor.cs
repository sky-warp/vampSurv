using Fusion;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Project.Scripts.Networking
{
    public sealed class FusionStartupTutor : MonoBehaviour
    {
        private NetworkRunner _runner;
        private NetworkSceneManagerDefault _sceneManager;

        private void Start()
        {
            _runner = GetComponent<NetworkRunner>();
            _sceneManager = GetComponent<NetworkSceneManagerDefault>();

            StartFusion(GameMode.AutoHostOrClient);
        }

        private async void StartFusion(GameMode mode)
        {
            _runner.ProvideInput = true;

            await _runner.StartGame(new StartGameArgs()
            {
                GameMode = mode,
                SceneManager = _sceneManager,
                Scene = GetSceneRef(),
                SessionName = "Test"
            });
        }

        private SceneRef GetSceneRef()
        {
            int index = SceneManager.GetActiveScene().buildIndex;
            return SceneRef.FromIndex(index);
        }
    }
}