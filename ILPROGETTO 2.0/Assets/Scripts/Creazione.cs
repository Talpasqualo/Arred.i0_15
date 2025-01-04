using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Creazione : MonoBehaviour

{
    Vector3 placeHolder = new Vector3(0, 500, 500);

    public GameObject pavimento_btn;
    public GameObject parete_btn;
    public GameObject parete_porta_btn;


    public GameObject pavimento_prefab;
    public GameObject parete_prefab;
    public GameObject parete_porta_prefab;


    public GameObject avanti_btn;
    public GameObject indietro_btn;
    public GameObject destra_btn;
    public GameObject sinistra_btn;
    public GameObject ruota_btn;


    public GameObject conferma_btn;

    // Start is called before the first frame update
    void Start()
    {
        //RICORDA DI TOGLIERE I LISTEN


        Button pavimento_lstn = pavimento_btn.GetComponent<Button>();
        Button parete_lstn = parete_btn.GetComponent<Button>();
        Button parete_porta_lstn = parete_porta_btn.GetComponent<Button>();

        //crea gli oggetti lontano
        GameObject pavimento_obj = Instantiate(pavimento_prefab, placeHolder, Quaternion.identity);
        GameObject parete_obj = Instantiate(parete_prefab, placeHolder, Quaternion.identity);
        GameObject parete_porta_obj = Instantiate(parete_porta_prefab, placeHolder, Quaternion.identity);

        //cliccando il tasto vengono trasportati al centro della scena e si possono spostare, fino a quando si clicca conferma
        pavimento_lstn.onClick.AddListener(delegate { Crea_oggetto(pavimento_obj); });
        parete_lstn.onClick.AddListener(delegate { Crea_oggetto(parete_obj); });
        parete_porta_lstn.onClick.AddListener(delegate { Crea_oggetto(parete_porta_obj); });

        


    }

    public void Attiva()
    {
        avanti_btn.SetActive(true);
        indietro_btn.SetActive(true);
        destra_btn.SetActive(true);
        sinistra_btn.SetActive(true);
        conferma_btn.SetActive(true);
        ruota_btn.SetActive(true);
    }
    public void Disattiva()
    {
        avanti_btn.SetActive(false);
        indietro_btn.SetActive(false);
        destra_btn.SetActive(false);
        sinistra_btn.SetActive(false);
        conferma_btn.SetActive(false);
        ruota_btn.SetActive(false);
    }
    public void Crea_oggetto(GameObject oggetto_obj)
    {
        Button avanti_lstn = avanti_btn.GetComponent<Button>();
        Button indietro_lstn = indietro_btn.GetComponent<Button>();
        Button destra_lstn = destra_btn.GetComponent<Button>();
        Button sinistra_lstn = sinistra_btn.GetComponent<Button>();
        Button ruota_lstn = ruota_btn.GetComponent<Button>();


        Button conferma_ = conferma_btn.GetComponent<Button>();

        oggetto_obj.transform.localPosition = new Vector3(0, 0, 0);

        //con i tasti di movimento vengono chiamate le funzioni per spostare l'oggetto

        //RICORDA DI TOGLIERE I LISTEN

        avanti_lstn.onClick.AddListener(delegate { Avanti( oggetto_obj);});
        indietro_lstn.onClick.AddListener(delegate { Indietro(oggetto_obj); });
        destra_lstn.onClick.AddListener(delegate { Destra(oggetto_obj); });
        sinistra_lstn.onClick.AddListener(delegate { Sinistra(oggetto_obj); });
        ruota_lstn.onClick.AddListener(delegate { Ruota(oggetto_obj); });

        //conferma crea copie identiche dell'oggetto che poi viene spostato alla posizione originale
        conferma_.onClick.AddListener(delegate { Conferma(oggetto_obj); });
    }

    public void Avanti(GameObject oggetto_obj)
    {
        oggetto_obj.transform.localPosition += new Vector3(0.5f, 0, 0);
    }
    public void Indietro(GameObject oggetto_obj)
    {
        oggetto_obj.transform.localPosition += new Vector3(-0.5f, 0, 0);
    }
    public void Destra(GameObject oggetto_obj)
    {
        oggetto_obj.transform.localPosition += new Vector3(0, 0, 0.5f);
    }
    public void Sinistra(GameObject oggetto_obj)
    {
        oggetto_obj.transform.localPosition += new Vector3(0, 0, -0.5f);
    }
    public void Ruota(GameObject oggetto_obj)
    {
        oggetto_obj.transform.Rotate(0.0f, 90.0f, 0.0f, Space.Self);
    }



    public void Conferma(GameObject oggetto_obj)
    {
        GameObject new_oggetto_obj = Instantiate(oggetto_obj, oggetto_obj.transform.localPosition, oggetto_obj.transform.localRotation);
        oggetto_obj.transform.localPosition = placeHolder;
        oggetto_obj.transform.localRotation = Quaternion.identity;
    }



}
