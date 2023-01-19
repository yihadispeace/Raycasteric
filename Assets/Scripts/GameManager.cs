using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField]private LayerMask rayLayer;
    private GameObject hit;
    [SerializeField]private float i = 5f;
    public Text timerText;

     public IEnumerator Tim()
    {
        for ( i = 5; i > 0; i--){
            Debug.Log("Faltan " + i + " segundos");
            yield return new WaitForSeconds(1f);
             timerText.text=i.ToString(); }
       
      

        LoadLevel();

    }    

    void Update()
    { 

	
	if(Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayHit;
            StartCoroutine(Tim());                

            if(Physics.Raycast(ray, out rayHit, rayLayer))
            {
  
                hit = rayHit.transform.gameObject;               
                
            }
        }        
    }

    void LoadLevel()
    {

        if(hit.gameObject.layer == 6)
        {

            SceneManager.LoadScene(1);

        }
        if(hit.gameObject.layer == 7)
        {

            SceneManager.LoadScene(2);

        }
        if(hit.gameObject.layer == 8)
        {

            SceneManager.LoadScene(3);

        }

    }
}