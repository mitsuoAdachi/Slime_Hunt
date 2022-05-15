using Cinemachine;
using UnityEngine;

/// <summary>
/// This is an add-on behaviour that globally maps the touch control 
/// to standard input channels, such as mouse X and mouse Y.
/// Drop it on any game object in your scene.
/// </summary>
public class Camera_Mapper : MonoBehaviour
{
    /// <summary>Sensitivity multiplier for x-axis</summary>
    [Tooltip("Sensitivity multiplier for x-axis")]
    public float TouchSensitivityX = 10f;

    /// <summary>Sensitivity multiplier for y-axis</summary>
    [Tooltip("Sensitivity multiplier for y-axis")]
    public float TouchSensitivityY = 10f;

    /// <summary>Input channel to spoof for X axis</summary>
    [Tooltip("Input channel to spoof for X axis")]
    public string TouchXInputMapTo = "Mouse X";

    /// <summary>Input channel to spoof for Y axis</summary>
    [Tooltip("Input channel to spoof for Y axis")]
    public string TouchYInputMapTo = "Mouse Y";

    int _fingerId;

    void Start()
    {
        CinemachineCore.GetInputAxis = GetInputAxis;
    }

    private float GetInputAxis(string axisName)
    {
        /*foreach (var touch in Input.touches)
        {
            //Touch touch = Input.touches[i];
            if (touch.position.x > 1000)
            {
                _fingerId = touch.fingerId;
            }

            if (touch.fingerId == _fingerId)*/
        foreach (var touch in Input.touches)
        {
            if (touch.position.x > 1000)
            {
                if (axisName == TouchXInputMapTo)
                    return touch.deltaPosition.x / TouchSensitivityX;          
                if (axisName == TouchYInputMapTo)
                    return touch.deltaPosition.y / TouchSensitivityY;
            }
            
        }
        return Input.GetAxis(axisName);
    }
}
