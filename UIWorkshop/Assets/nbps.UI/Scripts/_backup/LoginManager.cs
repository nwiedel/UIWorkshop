using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace nbps.UI.Scripts._backup
{
    public class LoginManager : MonoBehaviour
    {
        public User[] Users;
        public TMP_InputField UsernameInput, PasswordInput;
        public Animator LoginPanelAnimator;
        public string SceneToLoad;

        private void Awake()
        {
            Users = new User[]
            {
                new User { Username = "user1", Password = "password1" },
                new User { Username = "user2", Password = "password2" },
            };
        }

        // Button Login ruft diese Funktion auf
        public void OnLoginButtonClick()
        {
            // Text aus InputFeldern auslesen + zuweisen
            string enteredUsername = UsernameInput.text;
            string enteredPassword = PasswordInput.text;
            // Sind die Daten überhaupt richtig?
            bool isUserValid = false;

            foreach (var user in Users)
            {
                if (user.Username == enteredUsername && user.Password == enteredPassword)
                {
                    isUserValid = true;
                    break;
                }
            }

            if (isUserValid)
            {
                print("Login successful!");
                LoginPanelAnimator.enabled = true;

                // Speichere den Benutzernamen in den PlayerPrefs
                //print($"username to save: {enteredUsername}");
                PlayerPrefs.SetString("username", enteredUsername);
                print(PlayerPrefs.GetString("username"));
                // Lade die nächste Scene (Level1 / Game)
                Invoke("LoadMyLevel", 2f);
            }
            else
            {
                print("Invalid username or password.");
            }
        }

        private void LoadMyLevel()
        {
            SceneManager.LoadScene(SceneToLoad);
        }
    }
}
