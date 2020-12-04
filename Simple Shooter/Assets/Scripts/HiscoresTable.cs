using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HiscoresTable : MonoBehaviour
{
    public GameObject textPrefab;
    public TMP_ColorGradient highlightGradient;

    private List<HiscoreEntry> hiscoreList = new List<HiscoreEntry>();
    private int maxEntries = 5;
    private string prefKey = "hiscores";
    private int highlightIndex = -1;

    void Awake()
    {
        LoadHiscores();
        AddScore(ScoreText.killCount);
        CreateTable();
    }

    void CreateTable()
    {
        Debug.Log("highlight " + highlightIndex);
        // Create the table cells
        for (int i = 0; i < hiscoreList.Count; ++i)
        {
            GameObject entry = Instantiate(textPrefab, gameObject.transform);
            RectTransform entryTransform = entry.GetComponent<RectTransform>();
            entryTransform.anchoredPosition = new Vector2(0, -entryTransform.rect.height * i);
            TextMeshProUGUI textMesh = entry.GetComponent<TextMeshProUGUI>();
            textMesh.text = ((i + 1) + ". " + hiscoreList[i].score);
            if (i == highlightIndex)
            {
                textMesh.colorGradientPreset = highlightGradient;
            }
        }
    }

    void AddScore(int score)
    {
        int originalScore = score;
        // Insert in descending order and shift the rest
        for (int i = 0; i < hiscoreList.Count; ++i)
        {
            if (score > hiscoreList[i].score)
            {
                if (score == originalScore)
                {
                    highlightIndex = i;
                }
                int temp = hiscoreList[i].score;
                hiscoreList[i].score = score;
                score = temp;
            }
        }

        // Add at the end if we aren't at maxEntries
        if (hiscoreList.Count < maxEntries)
        {
            hiscoreList.Add(new HiscoreEntry { score = score });
            if (score == originalScore)
            {
                highlightIndex = hiscoreList.Count - 1;
            }
            
        }

        SaveHiscores();
    }

    void SaveHiscores()
    {
        Debug.Log("Save pref");
        PlayerPrefs.SetString(prefKey, JsonUtility.ToJson(new HiscoreList { list = hiscoreList }));
        PlayerPrefs.Save();
    }

    void LoadHiscores()
    {
        Debug.Log("Load pref");
        string prefString = PlayerPrefs.GetString(prefKey);
        if (prefString != null)
        {
            HiscoreList loadedList = JsonUtility.FromJson<HiscoreList>(prefString);
            if (loadedList != null)
            {
                hiscoreList = loadedList.list;
            }
        }
    }

    // Wrapper class for serialization
    private class HiscoreList
    {
        public List<HiscoreEntry> list;
    }

    [System.Serializable]
    public class HiscoreEntry
    {
        public int score;
    }
}
