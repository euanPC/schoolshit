using UnityEngine;
using UnityEngine.UI;

public class control : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject follow;
    public Transform CameraTransform;
    Vector2 lookInput;
    public Camera camera;
    public Rigidbody rb;

    GameObject hudCenterGO;
    GameObject velocityMarkerGO;
    GameObject targetBoxGO;
    Image targetBoxImage;
    GameObject missileLockGO;
    Image missileLockImage;
    GameObject reticleGO;
    GameObject targetArrowGO;
    GameObject missileArrowGO;
    [SerializeField]
    Transform hudCenter;
    [SerializeField]
    Transform speedMarker;
    void Start()
    {
        hudCenterGO=hudCenter.gameObject;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = follow.transform.position;
        Vector3 look= follow.transform.rotation.eulerAngles;
        look.z = 0;
        transform.rotation = Quaternion.Euler(look);
    }
    private void LateUpdate()
    {
        UpdateHUDCenter();
    }
    void UpdateHUDCenter() {
        var rotation = CameraTransform.rotation.eulerAngles;
        var hudPos = TransformToHUDSpace(camera.transform.position+follow.transform.forward);
        var velPos = TransformToHUDSpace(camera.transform.position + rb.angularVelocity);
        if (hudPos.z > 0)
        {
            hudCenterGO.SetActive(true);
            hudCenter.localPosition = new Vector3(hudPos.x,hudPos.y, 0);
            hudCenter.localEulerAngles = new Vector3(0, 0, -rotation.z);
        }
        else
        {
            print(hudPos.z);

        }
        if (velPos.z > 0)
        {
            
            speedMarker.localPosition = new Vector3(velPos.x, velPos.y, 0);
            speedMarker.localEulerAngles = new Vector3(0,0, -rotation.z);
        }
        else
        {

        }
    
    }
    Vector3 TransformToHUDSpace(Vector3 pos)
    {
       var screenspace= camera.WorldToScreenPoint(pos);
        return screenspace- new Vector3(camera.pixelWidth / 2, camera.pixelHeight / 2);

    }
}
