using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System.Linq;

public class SubscriberView : MonoBehaviour, IView
{
    [SerializeField]
    private Image _avatarImage;
    [SerializeField]
    private TMP_Text _nicknameField;
    [SerializeField]
    private TMP_Text _messsgeField;
    [SerializeField]
    List<Image> _emojiImages;
    [Space (20)]
    [SerializeField]
    List<Sprite> _emojiSpriteSet;
    [SerializeField]
    List<Sprite> _avatarsSet;

    private List<string> _nicknames;


    private string _nickNamesPath = Application.streamingAssetsPath + "/Texts/" + "NickNames" + ".txt";


    private void OnEnable()
    {
        CreateListFromFile(_nickNamesPath, out _nicknames);
        UpdateView();
    }

    private void Awake()
    {

    }

    private void CreateListFromFile(string pathToFile, out List<string> list)
    {
        list = File.ReadAllLines(pathToFile).ToList();
    }

    public void UpdateView()
    {
        string randomNick = _nicknames[Random.Range(0, _nicknames.Count)];
        _nicknameField.text = randomNick + ":";
        _nicknameField.color = Random.ColorHSV();
        int randomAvatarIndex = Random.Range(0, _avatarsSet.Count);
        _avatarImage.sprite = _avatarsSet[randomAvatarIndex];

        if (_emojiSpriteSet != null)
        {
            int randomValue = Random.Range(2, _emojiImages.Count);
            for (int i = 0; i < randomValue; i++)
            {
                _emojiImages[i].color = Color.white;
                int rand = Random.Range(0, _emojiSpriteSet.Count);
                _emojiImages[i].sprite = _emojiSpriteSet[rand];

            }
        }
    }
}