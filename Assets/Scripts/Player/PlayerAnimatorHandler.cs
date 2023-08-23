namespace Assets.Scripts.Player
{
    using UnityEngine;

    public class PlayerAnimatorHandler : MonoBehaviour
    {
        [SerializeField] private Animator _animator;


        public void SetIsRunningParamToFalse()
        {
            SetIsRunningParamTo(false);
        }

        public void SetIsRunningParamToTrue()
        {
            SetIsRunningParamTo(true);
        }

        private void SetIsRunningParamTo(bool isAlive)
        {
            _animator.SetBool("isRunning", isAlive);
        }
    }
}