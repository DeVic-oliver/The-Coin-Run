namespace Assets.Scripts.Core
{
    using Assets.Scripts.Core.InputActions.Player;
    using UnityEngine;
    using UnityEngine.InputSystem;

    public class MovementActionsParser : MonoBehaviour
    {
        public float HorizontalActionValue { get; private set; }
        public float VerticalActionValue { get; private set; }

        [SerializeField] private InputActionAsset _actions;

        private MovementMapFetcher _mapFetcher;
        private InputAction _horizontalAction;
        private InputAction _verticalAction;
        

        private void Awake()
        {
            _mapFetcher = new MovementMapFetcher(_actions);
            FetchInputActions();
        }

        private void FetchInputActions()
        {
            _horizontalAction = _mapFetcher.FetchHorizontalMoveInputAction();
            _verticalAction = _mapFetcher.FetchVerticalMoveInputAction();
        }
       
        void Update()
        {
            SetActionsInputValues();
        }

        private void SetActionsInputValues()
        {
            HorizontalActionValue = _horizontalAction.ReadValue<float>();
            VerticalActionValue = _verticalAction.ReadValue<float>();
        }

        private void OnEnable()
        {
            _actions.Enable();
        }

        private void OnDisable()
        {
            _actions.Disable();
        }
    }
}
