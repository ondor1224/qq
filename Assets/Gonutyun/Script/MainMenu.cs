using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Gonutyun
{
    public class MainMenu : MonoBehaviour
    {
        public GameObject MenuBg;
        public GameObject Setting;
        public GameObject SettingBGSound;
        public GameObject SettingSound;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        public void BtnStart()
        {
            SceneManager.LoadScene("SampleScene");
        }

        public void BtnSetting()
        {
            MenuBg.GetComponent<Animator>().SetTrigger("Close");
            Invoke("OpenSetting", 1.5f);
        }

        public void BtnExit()
        {
            Application.Quit();
        }

        public void BtnBack()
        {
            Setting.GetComponent<Animator>().SetTrigger("Close");
            Invoke("OpenMenuBG", 1.5f);
        }

        public void OpenMenuBG()
        {
            MenuBg.GetComponent<Animator>().SetTrigger("Open");
        }

        void OpenSetting()
        {
            Setting.SetActive(true);
            Setting.GetComponent<Animator>().SetTrigger("Open");
        }

        public void BtnBGsound()
        {
            if (SettingBGSound.GetComponent<Text>().text == "¹è°æÀ½¾Ç")
            {
                SettingBGSound.GetComponent<Text>().text = "¹è°æÀ½¾Ç ²û";
            }

            else
            {
                SettingBGSound.GetComponent<Text>().text = "¹è°æÀ½¾Ç";
            }
        }

        public void BtnSound()
        {
            if (SettingSound.GetComponent<Text>().text == "È¿°úÀ½")
            {
                SettingSound.GetComponent<Text>().text = "È¿°úÀ½ ²û";
            }

            else
            {
                SettingSound.GetComponent<Text>().text = "È¿°úÀ½";
            }
        }

    }
}
