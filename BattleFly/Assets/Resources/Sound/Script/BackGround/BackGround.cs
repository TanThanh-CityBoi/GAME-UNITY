using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public Vector3 MaxPoint;
    public Vector3 MinPoint;
    public Vector3 sizeOfSprite;
    public float WightScreen, HeightScreen;
    //
    public float speedScroll;
    public Vector3 startPos;

    /// ////////

    // Start is called before the first frame update
    void Start()
    {
        speedScroll = 3.0f;
        MaxPoint = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight, 0.0f));
        MinPoint = Camera.main.ScreenToWorldPoint(Vector3.zero);
        //
        WightScreen = MaxPoint.x - MinPoint.x;
        HeightScreen = MaxPoint.y - MinPoint.y;
        //
        float pixelPerUnit = this.GetComponent<SpriteRenderer>().sprite.pixelsPerUnit;
        sizeOfSprite = new Vector3(this.GetComponent<SpriteRenderer>().sprite.rect.width, this.GetComponent<SpriteRenderer>().sprite.rect.height, 0.0f);
        //
        Vector3 sizeOfBackground = new Vector3(WightScreen / (sizeOfSprite.x / pixelPerUnit), HeightScreen / (sizeOfSprite.y / pixelPerUnit), 0.0f);
        this.transform.localScale = sizeOfBackground;
        this.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, 0);
        startPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(translation: Vector3.down * speedScroll * Time.deltaTime);
        if(transform.position.y <= -HeightScreen)
        {
            transform.position = startPos;
        }
    }
}
