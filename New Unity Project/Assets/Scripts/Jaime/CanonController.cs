using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanonController : MonoBehaviour
{

    public GameObject suckerPrefab;

    public Transform fireTransform;

    public float rotationSpeed;

    private float rotateH;

    public Image chargeBar;


    public float minLaunchForce = 10f;
    public float maxLaunchForce = 25f;
    public float maxChargeTime = 1f;
    public float currentLaunchForce;
    public float chargeSpeed;
    public bool suckerLaunched = false;


    private void Start()
    {

        chargeSpeed = (maxLaunchForce - minLaunchForce) / maxChargeTime;

        currentLaunchForce = minLaunchForce;

    }


    void Update()
    {

        GetInputs();

        RotateCanon();

        FillBar();
        
    }

    private void GetInputs(){

        rotateH = Input.GetAxisRaw("Horizontal");

        if (currentLaunchForce >= maxLaunchForce && !suckerLaunched)
        {
            
          currentLaunchForce = maxLaunchForce;
          Fire();

        }else if (Input.GetKeyDown(KeyCode.Space) && !suckerLaunched){

            currentLaunchForce = minLaunchForce;


        }else if (Input.GetKey(KeyCode.Space) && !suckerLaunched){

            currentLaunchForce += chargeSpeed * Time.deltaTime;


        }else if (Input.GetKeyUp(KeyCode.Space) && !suckerLaunched){

            Fire();


        }


    }

    private void Fire(){

        suckerLaunched = true;

        GameObject suckerInstance = Instantiate(suckerPrefab, new Vector2 (fireTransform.position.x, fireTransform.position.y), fireTransform.rotation);

        Debug.Log(fireTransform.forward);
        
        suckerInstance.GetComponent<Rigidbody2D>().velocity = 20f * fireTransform.right;

        


        currentLaunchForce = minLaunchForce;

    }



    private void RotateCanon(){

        transform.RotateAround(transform.position, Vector3.forward, rotationSpeed * -rotateH * Time.deltaTime);

    }


    public void BarFill(float amount)
    {
        chargeBar.fillAmount = amount;
    }

    private void FillBar(){

        BarFill((currentLaunchForce - minLaunchForce)/(maxLaunchForce - minLaunchForce));

    }

}
