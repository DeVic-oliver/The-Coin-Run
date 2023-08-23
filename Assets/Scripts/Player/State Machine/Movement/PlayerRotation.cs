namespace Assets.Scripts.Player.State_Machine.Movement
{
    using Assets.Scripts.Core;
    using UnityEngine;
    
    public class PlayerRotation : MonoBehaviour
    {
        [SerializeField] private MovementActionsParser _actions;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private Rigidbody _rigidbody;
        private Vector3 _moveRotation;


        void Update()
        {
            _moveRotation = _actions.HorizontalActionValue * _rotationSpeed * Vector3.up ;
        }

        private void FixedUpdate()
        {
            Quaternion rotation = _rigidbody.rotation * Quaternion.Euler(_moveRotation * Time.fixedDeltaTime);
            _rigidbody.MoveRotation(rotation);
        }
    }
}