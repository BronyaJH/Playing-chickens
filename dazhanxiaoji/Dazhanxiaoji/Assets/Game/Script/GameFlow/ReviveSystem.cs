using Mono.Cecil.Cil;
using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

namespace Assets.Game.Script.GameFlow
{
    public class ReviveSystem : MonoBehaviour
    {
        public static ReviveSystem instance;
        public CanvasGroup cgDie;
        public RectTransform reviveBtn;

        public float dieDelay = 1.6f;

        private float _pendingDieTiming;
        private bool _fromFall;

        private void Awake()
        {
            _pendingDieTiming = -1;
            instance = this;
        }

        private void Start()
        {
            Hide();
        }

        void Hide()
        {
            cgDie.alpha = 0;
            cgDie.blocksRaycasts = false;
            reviveBtn.gameObject.SetActive(false);
        }

        void Show()
        {
            Hide();
            cgDie.blocksRaycasts = true;

            cgDie.DOFade(1, 1).OnComplete(
               () => { reviveBtn.gameObject.SetActive(true); }
                );
        }

        public void ReloadScene()
        {
            SceneManager.LoadScene(0);
        }

        private void Update()
        {
            if (_pendingDieTiming > 0)
            {
                if (_pendingDieTiming <= Time.time)
                {
                    _pendingDieTiming = 0;
                    Show();
                }
            }
        }
        public void QueueDie(bool fromFall = false)
        {
            if (_pendingDieTiming < 0)
            {
                _fromFall = fromFall;
                if (_fromFall)
                    _pendingDieTiming = Time.time + dieDelay * 0.1f;
                else
                    _pendingDieTiming = Time.time + dieDelay;
            }
        }
    }
}