using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS : MonoBehaviour {
	public float interactDistance = 5f;
    public bool activar;
    public bool s;

    //public Inven Script;
	
	// Update is called once per frame
	void Update () 
	{
        
          
         
        if (Input.GetKeyDown (KeyCode.E)) 
		{
			Ray ray = new Ray (transform.position, transform.forward);
			RaycastHit hit;
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * 30.0f, Color.red, 3f);
			if (Physics.Raycast (ray, out hit, interactDistance))
			{
                print(hit.collider.name);
				if (hit.collider.CompareTag ("Door")) {
                  
                    
					DoorScript doorScript = hit.collider.transform.parent.GetComponent<DoorScript> ();
                    print(doorScript);
					if (doorScript == null)
						return;

					if (Inventory.keys [doorScript.index] == true) {
                        //Script.MenosLllave("Key");
                        doorScript.ChangeDoorState ();
                        
                    }
                    else
                    {
                        AudioSource audio = GetComponent<AudioSource>();
                        audio.Play();

                    }
                }
					else if(hit.collider.CompareTag("Key"))
					{
						Inventory.keys [hit.collider.GetComponent<Key>().index] = true;
						Destroy (hit.collider.gameObject);
					}
				}
			}
		}
	}

