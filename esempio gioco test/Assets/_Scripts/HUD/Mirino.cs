using UnityEngine;
using UnityEngine.UI;

public class Mirino : MonoBehaviour
{
    private Image mirino;
    public Sprite mirinoSprite;
    public Sprite eButton;
    RaycastHit hit;
    Camera playerCam;
    public float rangeCamera;

    void Start()
    {
        mirino = GetComponent<Image>();
        playerCam = GameObject.FindGameObjectWithTag("Player").GetComponent<Camera>();
        rangeCamera = 100f;
    }

    void Update()
    {
        //da tenere assolutamente (mirino al posto del mouse)
        transform.position = Input.mousePosition;
        Cursor.visible = false;

        //modifiche al mirino
        ChangeMirino();
    }
    public void ChangeMirino()
    {
        if (Physics.Raycast(playerCam.ScreenPointToRay(Input.mousePosition), out hit, rangeCamera))
        {
            switch (hit.collider.tag)
            {
                case "Enemy":
                case "Head":
                    if (hit.collider.tag.Equals("Pickup") || hit.collider.tag.Equals("Weapon"))
                        SetColoreMirino(Color.white);
                    SetColoreMirino(Color.red);
                    break;
                case "Pickup":
                case "Weapon":
                    SetSpriteMirino(eButton);
                    break;
                default:
                    SetSpriteMirino(mirinoSprite);
                    SetColoreMirino(Color.white);
                    break;
            }
        }
    }

    public void SetSpriteMirino(Sprite sprite)
    {
        mirino.sprite = sprite;
    }
    public void SetColoreMirino(Color color)
    {
        mirino.color = color;
    }
}