using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoginManager : MonoBehaviour
{
    public User[] Users;
    public TMP_InputField UsernameInputField, PasswordInputField;
    public Animator loginPanelAnimator;
    public string SceneToLoad;

    // Start is called before the first frame update
    private void Awake()
    {
        Users = new User[]
        {
            new User{ Username = "user1", Password = "password1"},
            new User{ Username = "user2", Password = "password2"},
            new User{ Username = "nwiedel", Password = "1234567"}
        };
    }

    public void OnLoginButtonClick()
    {
        // Texte holen
        string enteredUsername = UsernameInputField.text;
        string enteredPassword = PasswordInputField.text;

        // sind daten richtig
        bool isUserValid = false;
        foreach (var user in Users)
        {
            if (user.Username == enteredUsername &&
                user.Password == enteredPassword)
            {
                isUserValid = true;
                break;
            }
        }

        if (isUserValid)
        {
            Debug.Log("Login erfolgreich!");
            loginPanelAnimator.enabled = true;

            // Speichere den Benutzernamen in den PlayerPrefs
            // print($"username to save: , { enteredUsername}");
            PlayerPrefs.SetString("username", enteredUsername);
            print(PlayerPrefs.GetString("username"));
            // Warten bis Animation beendet
            Invoke("LoadMyLevel", 2f); 
        }
        else
        {
            Debug.Log("Falsche Eingabe für Username oder Passwort!");
        }
    }

    private void LoadMyLevel()
    {
        // Lade eine neue Scene
        SceneManager.LoadScene(SceneToLoad);
    }
}
