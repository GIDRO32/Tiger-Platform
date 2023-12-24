using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelRoster : MonoBehaviour
{
    private int stars;
    private int progress;
    public string Level_Tag;
    public string progress_tag;
    public GameObject Bronze;
    public GameObject Silver;
    public GameObject Gold;
    // Start is called before the first frame update
    void Start()
    {
        Bronze.SetActive(false);
        Silver.SetActive(false);
        Gold.SetActive(false);
        stars = PlayerPrefs.GetInt(Level_Tag, stars);
        progress = PlayerPrefs.GetInt(progress_tag, progress);
    }

    // Update is called once per frame
    void Update()
    {
        stars = PlayerPrefs.GetInt(Level_Tag, stars);
        progress = PlayerPrefs.GetInt(progress_tag, progress);
        if(progress == 1)
        {
            if(stars == 1)
            {
            Bronze.SetActive(true);
            Silver.SetActive(false);
            Gold.SetActive(false);
            }
        else if(stars == 2)
        {
            Bronze.SetActive(false);
            Silver.SetActive(true);
            Gold.SetActive(false);
        }
        else if(stars == 3)
        {
            Bronze.SetActive(false);
            Silver.SetActive(false);
            Gold.SetActive(true);
        }
        }
        else
        {
        stars = 0;
        Bronze.SetActive(false);
        Silver.SetActive(false);
        Gold.SetActive(false);
        }
    }
}
