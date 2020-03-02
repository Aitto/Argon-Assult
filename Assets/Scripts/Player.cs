using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [SerializeField][Range(0.1f,10.0f)]
    private float m_Sensitivity = 1.0f;
    [SerializeField]
    private float m_horizontalLimit = 17.15f, m_verticalLimit = 10.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        float horizontalThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float verticalThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float horizontalPosition = this.transform.localPosition.x;
        float verticalPosition = this.transform.localPosition.y;

        horizontalPosition += m_horizontalLimit*m_Sensitivity* horizontalThrow*Time.deltaTime;
        horizontalPosition = Mathf.Clamp(horizontalPosition, - m_horizontalLimit, m_horizontalLimit);
        verticalPosition += m_verticalLimit*m_Sensitivity* verticalThrow*Time.deltaTime;
        verticalPosition = Mathf.Clamp(verticalPosition, -m_verticalLimit,m_verticalLimit);

        Debug.Log("H: " + horizontalPosition + "\nV: "+verticalPosition);

        Vector3 newPosition = new Vector3(horizontalPosition, verticalPosition, this.transform.localPosition.z);
        this.transform.localPosition = newPosition;
    }
}
