using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InputSystem;
using System.Linq;

namespace Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] float speed;

        private IInputController input;

        private CharacterController characterController;


        // Start is called before the first frame update
        void Start()
        {
            input = InputFactory.Instance.GetInputController();
            characterController = GetComponent<CharacterController>();
        }


        // Update is called once per frame
        void Update()
        {

            Vector3 movement = input.GetInputDir();
            movement *= speed * Time.deltaTime;

            if (movement != Vector3.zero)
                transform.rotation = Quaternion.LookRotation(movement, Vector3.up);

            if (!characterController.isGrounded)
                movement = new Vector3(movement.x, -10, movement.z);
                
            characterController.Move(movement);
        }
    }
}