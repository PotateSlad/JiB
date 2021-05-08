using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_Camera : MonoBehaviour
{
    bool up;
    bool down;
    bool left;
    bool right;
    float boarders = 10f; //map is square!
    float speed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        up = down = left = right = false;        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (up && this.transform.position.y < boarders)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + speed, -10);
        }
        if (down && this.transform.position.y > -boarders)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - speed, -10);
        }
        if (left && this.transform.position.x > -boarders)
        {
            this.transform.position = new Vector3(this.transform.position.x - speed, this.transform.position.y, -10);
        }
        if (right && this.transform.position.x < boarders)
        {
            this.transform.position = new Vector3(this.transform.position.x + speed, this.transform.position.y, -10);
        }
    }

    public void startMove(int dir)
    {
        if (dir == 1)
        {
            up = true;
        }
        else if (dir == 2)
        {
            right = true;
        }
        else if (dir == 3)
        {
            down = true;
        }
        else if (dir == 4)
        {
            left = true;
        }
    }
    public void stopMove(int dir)
    {
        if (dir == 1)
        {
            up = false;
        }
        else if (dir == 2)
        {
            right = false;
        }
        else if (dir == 3)
        {
            down = false;
        }
        else if (dir == 4)
        {
            left = false;
        }
    }
}
