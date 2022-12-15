using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Arcanoid
{
    internal sealed class ApplyDamageView : MonoBehaviour
    {
        [SerializeField] private float _damage;
        [SerializeField] private Button _button;

        private ILifeViewModel _lifeViewModel;

        public void Initialize(ILifeViewModel lifeViewModel)
        {
            _lifeViewModel = lifeViewModel;

            _button.onClick.RemoveAllListeners();
            _button.onClick.AddListener(() => _lifeViewModel.ApplyDamage(_damage));
        }
        private void OnTriggerEnter2D (Collider2D col)
        {
            if (col.gameObject.tag == "BallLoss")
            {
                Debug.Log("BallLoss");
                //_lifeViewModel.ApplyDamage(_damage);
            }
        }

    }

}