using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject[] Characters;

    public Sprite[] Sprites;

    public int CharactersIndex;

    public Image ImageCharacter;
    void Start()
    {
        UpdateCharacterDisphay();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateCharacterDisphay()
    {
        for (int i = 0; i < Characters.Length; i++)
        {
            Characters[i].SetActive(i == CharactersIndex);
        }

        if(ImageCharacter != null && Sprites.Length > CharactersIndex)
        {
            ImageCharacter.sprite = Sprites[CharactersIndex];
        }    
    }    

    public void NextCharacter()
    {
        CharactersIndex++;
        if(CharactersIndex >= Characters.Length)
        {
            CharactersIndex = 0;
        }

        UpdateCharacterDisphay();
    }    

    public void BackCharacter()
    {
        CharactersIndex--;
        if(CharactersIndex < 0)
        {
            CharactersIndex = Characters.Length - 1;
        }

        UpdateCharacterDisphay();
    }

    public void ConfirmSelection()
    {
        PlayerPrefs.SetInt("SelectedCharacter",CharactersIndex);
        SceneManager.LoadScene("Game");
    }    
}
