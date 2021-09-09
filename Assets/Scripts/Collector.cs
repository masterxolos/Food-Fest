using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Tabtale.TTPlugins;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

public class Collector : MonoBehaviour
{
    [SerializeField] private Transform collectedTooth;
    [SerializeField] private Transform collected;
    [SerializeField] private Transform mainCamera;

    
    public  GameObject[] toothArray = new GameObject[32];
    public  GameObject[] damakdakiDislerArray = new GameObject[15];
    [SerializeField] public Transform mouth;
    [SerializeField] public GameObject body;
    public int currentTeethCount = 0;

    [SerializeField] GameObject[] teethPrefab = new GameObject[4];
    private int teethPrefabCount = 0;
    [SerializeField] GameObject locationPrefab;
    [SerializeField] GameObject dislerr;
    [SerializeField] GameObject failCanvas;
    [SerializeField] GameObject winCanvas;
    
   
    [SerializeField] private GameObject goodParticle;
    [SerializeField] private GameObject lastParticle;
    [SerializeField] private GameObject badParticle;
    
    [SerializeField] private TextMeshProUGUI textMeshPro;
    
    public Slider slider;
    public Image fill;
    
    private bool isZoomed = true;

    private int sceneNum;

    
    private void Awake()
    {
        // Initialize CLIK Plugin
        TTPCore.Setup();
        // Your code here
        sceneNum = SceneManager.GetActiveScene().buildIndex;
    }
    private void Start()
    {
        slider.value = 1;
        fill.fillAmount = slider.value;
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Tooth"))
        {
            Destroy(other.gameObject);
            if (currentTeethCount +1 != 32)
            {
                AddTeeth(currentTeethCount +1);
            }
            else
            {
                AddTeeth(32-currentTeethCount);
            }
        }
      
        else if (other.gameObject.CompareTag("DarkerColor"))
        {
            Destroy(other.gameObject); 
          // var prefab = Instantiate(badParticle, gameObject.transform.position, Quaternion.Euler(-90, 0, 0));
          //  prefab.transform.parent = gameObject.transform;
        }
        else if (other.gameObject.CompareTag("LighterColor"))
        {
            
            Destroy(other.gameObject);
           // var prefab = Instantiate(goodParticle, gameObject.transform.position, Quaternion.Euler(-90,0,0));
           // prefab.transform.parent = gameObject.transform;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("jumpTrigger"))
        {
            collectedTooth.gameObject.GetComponent<Movement>().enabled = false;
            StartCoroutine(Jump());
        }
        if (other.gameObject.CompareTag("X2"))
        {
            if (currentTeethCount * 2 + 1 != 32)
            {
                AddTeeth(currentTeethCount * 2 + 1);
            }
            else
            {
                AddTeeth(32 - currentTeethCount);
            }
            Destroy(other.gameObject);
            //ya destroy ya collider kapat
        }
        else if (other.gameObject.CompareTag("+10"))
        {
            if (currentTeethCount + 10 != 32)
            {
                AddTeeth(currentTeethCount + 10);
            }
            else
            {
                AddTeeth(32 - currentTeethCount);
            }
            Destroy(other.gameObject);
            //ya destroy ya collider kapat
        }
        else if (other.gameObject.CompareTag("-3"))
        {
            if (currentTeethCount >= 3)
            {
                removeTeeth(3);
            }
            else
            {
                removeTeeth(currentTeethCount);
            }
            Destroy(other.gameObject);
            //ya destroy ya collider kapat
        }
        else if (other.gameObject.CompareTag("donut"))
        {
            if (currentTeethCount >= 5)
            {
                removeTeeth(5);
            }
            else
            {
                removeTeeth(currentTeethCount);
            }
        }
            /*
            else if (other.gameObject.CompareTag("-5"))
            {
                if (currentTeethCount >= 5)
                {
                    removeTeeth(5);
                }
                else
                {
                    removeTeeth(currentTeethCount);
                }
                Destroy(other.gameObject);
                //ya destroy ya collider kapat
            }

                //ya destroy ya collider kapat
            }
    */
        }

    IEnumerator Jump()
    {
     
        mouth.parent = collected.transform;
        int i = 0;
        while (currentTeethCount >= 0)
        {
           // toothArray[currentTeethCount].transform.parent = dislerr.transform;
           
           // toothArray[currentTeethCount].GetComponent<Animator>().enabled = false;
            toothArray[currentTeethCount].transform.DOMove(mouth.position, 0.6f);
           // toothArray[currentTeethCount].transform.DOScale(0, 0.6f);
            yield return new WaitForSeconds(0.6f);
          //  damakdakiDislerArray[currentTeethCount].SetActive(true);
           
            i++;
            Destroy(toothArray[currentTeethCount]);
            currentTeethCount--;

            //vücudun boyutunu ayarlamak için
            body.transform.localScale = body.transform.localScale + new Vector3(0.5f, 0f, 0.2f);
            
        }

        yield return new WaitForSeconds(0.5f);
        winCanvas.SetActive(true);
    }

    private void AddTeeth(int newCount)
    {
        int randomNumber;
        while (currentTeethCount < newCount && currentTeethCount+1 < 32)
        {
            randomNumber = Random.Range(0,4);
            currentTeethCount++;
            Debug.Log(currentTeethCount);
            
            switch (sceneNum)
            { 
                case 0:
                    toothArray[currentTeethCount] = Instantiate(teethPrefab[sceneNum], toothArray[currentTeethCount].transform.position, Quaternion.Euler(0, 90, 0));
                    
                        teethPrefabCount++;
                        break;
                case 1: 
                        toothArray[currentTeethCount] = Instantiate(teethPrefab[sceneNum], toothArray[currentTeethCount].transform.position, Quaternion.Euler(0, 0, 0));
                        teethPrefabCount++;
                        break;
                case 2:
                        toothArray[currentTeethCount] = Instantiate(teethPrefab[sceneNum], toothArray[currentTeethCount].transform.position, Quaternion.Euler(0, 180, 0));
                        teethPrefabCount++;
                        break;
                case 3:
                    toothArray[currentTeethCount] = Instantiate(teethPrefab[sceneNum], toothArray[currentTeethCount].transform.position, Quaternion.Euler(53.28f, 90, 0));
                    teethPrefabCount++;
                        break;
            }
                

            toothArray[currentTeethCount].transform.parent = collected;
            toothArray[currentTeethCount].tag = "CollectedTeeth";
            textMeshPro.text = currentTeethCount+1.ToString();
            if (randomNumber == 2)
            {
                
            }
            if (randomNumber == 3)
            {
                
            }
            
        }

        if (currentTeethCount > 20 && isZoomed == true)
        {
            isZoomed = false;
            mainCamera.GetComponent<Camera>().fieldOfView = 70;
            //collectedTooth.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
        }
        else if (currentTeethCount < 20 && isZoomed == false)
        {
            isZoomed = true;
            mainCamera.GetComponent<Camera>().fieldOfView = 60;
            //collectedTooth.transform.localScale = new Vector3(1f, 1f, 1f); 
        }

        slider.value = currentTeethCount + 1;
        fill.fillAmount = slider.value;
    }

    private void removeTeeth(int removeCount)
    {
        if (currentTeethCount - removeCount >= 1)
        {
            int index = 0;
            while (index <= removeCount)
            {
                Debug.Log(currentTeethCount + "silindi");
                Vector3 location = toothArray[currentTeethCount].transform.position;
                Destroy(toothArray[currentTeethCount]);
                toothArray[currentTeethCount] =
                    Instantiate(locationPrefab, location, Quaternion.identity);
//                toothArray[currentTeethCount].transform.parent = collectedTooth;
                currentTeethCount--;
                textMeshPro.text = currentTeethCount+1.ToString();
                index++;
            }
        }
        else
        {
            Debug.Log("game ended");
            collectedTooth.GetComponent<Movement>().enabled = false;
            failCanvas.SetActive(true);
        }
        slider.value = currentTeethCount + 1;
        fill.fillAmount = slider.value;
    }
}
