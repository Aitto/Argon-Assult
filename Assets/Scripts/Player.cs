using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [SerializeField][Range(0.1f,30.0f)][Tooltip("In ms^-1")]
    private float m_Sensitivity = 1.0f;
    [SerializeField][Tooltip("In m")]
    private float m_horizontalLimit = 17.15f, m_verticalLimit = 10.5f,m_pitchFactor=1.5f,m_yawFactor=0.85f;
    [SerializeField]
    private int m_maxFPS = 30;
    [SerializeField]
    private float m_pitchControlFactor = 10f,m_rollControlFactor = 10f;

    private float m_verticalThrow=0f,m_horizontalThrow=0f;


    void Awake()
    {
        Application.targetFrameRate = m_maxFPS ;
    }


    // Start is called before the first frame update
    void Start()
    {
        if(Application.targetFrameRate != m_maxFPS)
            Application.targetFrameRate = m_maxFPS;
        Debug.Log("Max fps: " + Application.targetFrameRate);
    }

    // Update is called once per frame
    void Update()
    {
        
        HandleMovement();
        HandleRotation();
    }

    private void HandleMovement()
    {
        m_horizontalThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        m_verticalThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float horizontalPosition = this.transform.localPosition.x;
        float verticalPosition = this.transform.localPosition.y;

        horizontalPosition += m_horizontalLimit*m_Sensitivity* m_horizontalThrow*Time.deltaTime;
        horizontalPosition = Mathf.Clamp(horizontalPosition, - m_horizontalLimit, m_horizontalLimit);
        verticalPosition += m_verticalLimit*m_Sensitivity* m_verticalThrow*Time.deltaTime;
        verticalPosition = Mathf.Clamp(verticalPosition, -m_verticalLimit,m_verticalLimit);

        //Debug.Log("H: " + horizontalPosition + "\nV: "+verticalPosition);

        Vector3 newPosition = new Vector3(horizontalPosition, verticalPosition, this.transform.localPosition.z);
        this.transform.localPosition = newPosition;

        //transform.localRotation = Quaternion.Euler(1,1,0);
    }

    private void HandleRotation()
    {
        float pitch = transform.localPosition.y * -m_pitchFactor + m_verticalThrow * -m_pitchControlFactor;
        float yaw = transform.localPosition.x * m_yawFactor;

        transform.localRotation = Quaternion.Euler(pitch,yaw, m_horizontalThrow * -m_rollControlFactor);
        
    }
}
