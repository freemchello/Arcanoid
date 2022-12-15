using UnityEngine;
using UnityEngine.UI;

namespace Arcanoid
{
    internal sealed class LifeView : MonoBehaviour
    {
        [SerializeField] private Text _text;
        private ILifeViewModel _lifeViewModel;
        public void Initialize(ILifeViewModel lifeViewModel)
        {
            _lifeViewModel = lifeViewModel;
            _lifeViewModel.OnLifeChange += OnLifeChange;
            OnLifeChange(_lifeViewModel.LifeModel.CurrentLife);
        }

        private void OnLifeChange(float currentLife)
        {
            _text.text = _lifeViewModel.isDead ? "Вы погибли." : currentLife.ToString();
        }
        ~LifeView()
        {
            _lifeViewModel.OnLifeChange -= OnLifeChange;
        }
    }
}