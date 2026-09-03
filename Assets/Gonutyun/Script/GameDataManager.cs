using UnityEngine;

namespace Gonutyun
{
    public class GameDataManager : MonoBehaviour
    {
        public static GameDataManager instance;
        public int isMusisc = 0;
        public int isSound = 0;
        public float gameTime = 0;
        public int gameScore = 0;
        public string curId;

        void Awake()
        {
            
            instance = this;
            DontDestroyOnLoad(instance);

        }

        void Start()
        {
           
            LoadData();

        }

        public void SaveData()
        {
            if(PlayerPrefs.HasKey("id"))
            {
                string id = PlayerPrefs.GetString("id");
                Debug.Log(id);
                PlayerPrefs.DeleteKey(id);
            }
            else
            {
                PlayerPrefs.SetString("id", "Gonutyun");
            }
            PlayerPrefs.SetInt("Music", isMusisc);
            PlayerPrefs.SetInt("Sound", isSound);

        }

        public void LoadData()
        {
            if(!PlayerPrefs.HasKey("Music"))
            {
                PlayerPrefs.SetInt("Music", 1);
            }

            if (!PlayerPrefs.HasKey("Sound"))
            {
                PlayerPrefs.SetInt("Sound", 1);

            }
            isMusisc = PlayerPrefs.GetInt("Music");
            isSound = PlayerPrefs.GetInt("Sound");

        }



       
    }
}
