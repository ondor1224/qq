using UnityEngine;

namespace Gonutyun
{
    public class NewMonoBehaviourScript : MonoBehaviour
    {


        public int Score;
        public string  Id;
        

        void Start()
        {
            LoadData();
        }

        public void SaveData()
        {
           
                PlayerPrefs.SetString("id", Id);
            
                PlayerPrefs.SetInt("score", Score);
            
        }

        public void LoadData()
        {
            if (!PlayerPrefs.HasKey("id"))
            {
                PlayerPrefs.SetInt("id", 1);
            }

            if (!PlayerPrefs.HasKey("score"))
            {
                PlayerPrefs.SetInt("score", 1);

            }
            Id = PlayerPrefs.GetString ("id");
            Score = PlayerPrefs.GetInt("score");

        }





    }
    
}
