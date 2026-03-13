using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private PlayerInputHandler inputHandler;
    private CharacterController characterController;

    private void Awake()
    {
        inputHandler = GetComponent<PlayerInputHandler>();
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float moveX = inputHandler.MoveInput.x;
        Vector3 moveDirection = new Vector3(moveX, 0f, 0f);
        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
    }
}