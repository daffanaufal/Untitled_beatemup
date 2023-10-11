using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Diagnostics;

public class next : MonoBehaviour
{
    private Button nextButton;

    [SerializeField]
    private string CharacterSelection; // Nama scene berikutnya

    private void Start()
    {
        nextButton = GetComponent<Button>();

        if (nextButton != null)
        {
            // Menambahkan event listener saat tombol ditekan
            nextButton.onClick.AddListener(NextButtonClicked);
        }
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            // Jika tombol "TAB" ditekan, kita akan memuat scene berikutnya
            LoadNextScene();
        }
    }

    private void NextButtonClicked()
    {
        // Fungsi yang dipanggil saat tombol ditekan
        LoadNextScene();
    }

    private void LoadNextScene()
    {
        // Memuat scene berikutnya
        SceneManager.LoadScene(CharacterSelection);
    }
}
