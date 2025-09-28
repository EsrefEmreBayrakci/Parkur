using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Cinemachine;

[RequireComponent(typeof(CinemachineFreeLook))]
public class FreeLookInputHandler : MonoBehaviour
{
    [Header("Input Actions")]
    public InputActionAsset inputActions;      
    public string actionMapName = "Player";    
    public string lookActionName = "Look";     

    private InputAction lookAction;
    private CinemachineFreeLook freeLookCam;

    [Header("Sensitivity")]
    public float sensitivityX = 0.1f;
    public float sensitivityY = 0.1f;

    private void Awake()
    {
        freeLookCam = GetComponent<CinemachineFreeLook>();

        if (inputActions == null)
        {
            Debug.LogError("InputActions asset is not assigned!");
            return;
        }

        var map = inputActions.FindActionMap(actionMapName);
        if (map == null)
        {
            Debug.LogError($"Action Map '{actionMapName}' not found!");
            return;
        }

        lookAction = map.FindAction(lookActionName);
        if (lookAction == null)
        {
            Debug.LogError($"Look Action '{lookActionName}' not found in map '{actionMapName}'!");
        }
    }

    private void OnEnable()
    {
        lookAction?.Enable();
    }

    private void OnDisable()
    {
        lookAction?.Disable();
    }

    private void Update()
    {
        if (lookAction == null) return;

        Vector2 lookDelta = lookAction.ReadValue<Vector2>();

        freeLookCam.m_XAxis.Value += lookDelta.x * sensitivityX;
        freeLookCam.m_YAxis.Value -= lookDelta.y * sensitivityY;
    }
}
