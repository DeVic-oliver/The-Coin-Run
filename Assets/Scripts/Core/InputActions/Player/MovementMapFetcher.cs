namespace Assets.Scripts.Core.InputActions.Player
{
    using UnityEngine.InputSystem;

    public class MovementMapFetcher
    {
        private InputActionAsset _actionAsset;


        public MovementMapFetcher(InputActionAsset actionsAsset)
        {
            _actionAsset = actionsAsset;
        }

        public InputAction FetchHorizontalMoveInputAction()
        {
            InputActionMap map = FetchMovementActionMap();
            return map.FindAction("Horizontal Movement");
        }

        public InputAction FetchVerticalMoveInputAction()
        {
            InputActionMap map = FetchMovementActionMap();
            return map.FindAction("Vertical Movement");
        }

        private InputActionMap FetchMovementActionMap()
        {
            return _actionAsset.FindActionMap("Movement");
        }

    }
}