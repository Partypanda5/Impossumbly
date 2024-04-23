using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;

public class InteractionTest : MonoBehaviour
{
    public InputActionReference touch;
    public NavMeshAgent character;

    private void OnEnable()
    {
        touch.action.Enable();
        touch.action.performed += OnTouchPerformed;
    }

    private void OnDisable()
    {
        touch.action.Disable();
        touch.action.performed -= OnTouchPerformed;
    }
    private void OnTouchPerformed(InputAction.CallbackContext context)
    {
        Debug.Log("Screen was touched");

        if (touch.action.ReadValue<float> () > 0)
        {
            Ray ray = Camera.main.ScreenPointToRay(Touchscreen.current.primaryTouch.position.ReadValue());
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (NavMesh.SamplePosition(hit.point, out NavMeshHit navMeshHit, 2.0f, NavMesh.AllAreas))
                {
                    character.SetDestination(navMeshHit.position);

                    if (hit.collider.gameObject.CompareTag("Interactable"))
                    {
                        Debug.Log("Interactable object has been tapped!");
                    }
                }
            }
        }

    }
}
