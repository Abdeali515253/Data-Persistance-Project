using System.IO;
using UnityEditor.Overlays;
using UnityEngine;

public class DataPresistor : MonoBehaviour
{
    public static DataPresistor Instance;
    public string name;

    public string bestName;
    public int bestScore;

    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [System.Serializable]
    class BestScore
    {
        public string name;
        public int score;
    }

    public void SaveScore(string name, int score)
    {
        BestScore data = new BestScore();
        data.name = name;
        data.score = score;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            BestScore data = JsonUtility.FromJson<BestScore>(json);
            DataPresistor.Instance.bestName = data.name;
            DataPresistor.Instance.bestScore = data.score;
        }
    }


}
