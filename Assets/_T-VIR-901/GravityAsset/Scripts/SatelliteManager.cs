//Standard Unity/C# functionality
using UnityEngine;

//These tell our project to use pieces from the Lightship ARDK


//Define our main class
public class SatelliteManager : MonoBehaviour
{
    public GameObject _ballPrefab;  //This will store the Ball Prefab we created earlier, so we can spawn a new Ball whenever we want
    public Camera _mainCamera;  //This will reference the MainCamera in the scene, so the ARDK can leverage the device camera
    private float force = 500f;
    public AudioClip[] audioClips;
    private AudioSource audioSource;
    private int indexClip = 0;
    private ItemManger itemManger;

    private static SatelliteManager _instance;

    public static SatelliteManager Instance
    {
        get 
        {
            if(_instance == null){
               Debug.LogWarning("No instance of SatelliteManager in the scene");
            }
            return _instance;
        }
    }

    private void Awake() {
        _instance = this;
    }

    public void DestroyAllSat() {
        GameObject[] sats = GameObject.FindGameObjectsWithTag("Sat");

        foreach(GameObject sat in sats)
        {
            if(sat.GetComponent<Satelite>() != null)
                sat.GetComponent<Satelite>().Destroy();
        }
    }

    
    


    // Start is called before the first frame update
    void Start()
    {
        //ARSessionFactory helps create our AR Session. Here, we're telling our 'ARSessionFactory' to listen to when a new ARSession is created, then call an 'OnSessionInitialized' function when we get notified of one being created
        audioSource = GetComponent<AudioSource>();
        itemManger = ItemManger.Instance;
        
    }

    void Update(){

        if(itemManger.vitesse != 0){
            force = itemManger.vitesse;
        }
    }

   

    

   public void SendSattelite(){
        // playRandomClip();
        //Spawn a new ball to bounce around our space
        GameObject newBall = Instantiate(_ballPrefab);  //Spawn a new ball from our Ball Prefab
        newBall.transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f));   //Set the rotation of our new Ball
        newBall.transform.position = _mainCamera.transform.position + _mainCamera.transform.forward;    //Set the position of our new Ball to just in front of our Main Camera

        //Add velocity to our Ball, here we're telling the game to put Force behind the Ball in the direction Forward from our Camera (so, straight ahead)
        Rigidbody rigbod = newBall.GetComponent<Rigidbody>();
        rigbod.velocity = new Vector3(0f, 0f, 0f);
        rigbod.AddForce(_mainCamera.transform.forward * (force * 100f));
        playRandomClip();
   }

   

    private void playRandomClip() {
        indexClip ++;
        audioSource.clip = audioClips[indexClip];
        audioSource.pitch = Random.Range(0.95f, 1.25f);
        audioSource.PlayOneShot(audioSource.clip);
        if(indexClip == audioClips.Length - 1){
            indexClip = 0;
        }
    }
}
