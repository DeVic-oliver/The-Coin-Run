namespace Assets.Scripts.Core
{
    using Assets.Scripts.Core.InputActions.Player;
    using UnityEngine;
    using UnityEngine.InputSystem;

    public class MovementActionsParser : MonoBehaviour
    {
        public Vector3 PlayerVelocity { get; private set; }

        [SerializeField] private InputActionAsset _actions;

        private MovementMapFetcher _mapFetcher;
        private InputAction _horizontalAction;
        private InputAction _verticalAction;
        private InputAction _jump;
        private bool _hasJumpActionMade { get; set; }
        

        public bool HasJumpActionMade()
        {
            return (_hasJumpActionMade) ? GetBufferedThenSetActionToFalse() : false;
        }

        private bool GetBufferedThenSetActionToFalse()
        {
            bool temp = _hasJumpActionMade;
            _hasJumpActionMade = false;
            return temp;
        }

        private void Awake()
        {
            _mapFetcher = new MovementMapFetcher(_actions);
            FetchInputActions();
            SubscribeEvents();
        }

        private void FetchInputActions()
        {
            _horizontalAction = _mapFetcher.FetchHorizontalMoveInputAction();
            _verticalAction = _mapFetcher.FetchVerticalMoveInputAction();
            _jump = _mapFetcher.FetchJumpInputAction();
        }

        private void SubscribeEvents()
        {
            _jump.performed += OnJump;
        }
       
        private void OnJump(InputAction.CallbackContext context)
        {
            _hasJumpActionMade = true;
        }

        void Update()
        {
            PlayerVelocity = GetMovementVector();
        }

        private Vector3 GetMovementVector()
        {
            float fowardsBackwardsValue = _verticalAction.ReadValue<float>();
            float sidesValue = _horizontalAction.ReadValue<float>();
            Vector3 position = new(sidesValue, 0, fowardsBackwardsValue);
            return position;
        }

        private void OnEnable()
        {
            _actions.Enable();
        }

        private void OnDisable()
        {
            _actions.Disable();
            _jump.performed -= OnJump;
        }
    }
}
