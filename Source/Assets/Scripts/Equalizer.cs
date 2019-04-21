using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EqualizerSaver
{
    public string nameEq = "";

    [System.Serializable]
    public class EqualizerDescSaver
    {
        public EqualizerDescSaver(string names, float val)
        {
            name = names;
            value = val;
        }
        public string name = "";
        public float value = 0;
    }
    public EqualizerDescSaver[] eqDescSaver;
}

public class Equalizer : MonoBehaviour
{
    public string nameEQ;
    public string relativePath = "/Sound/Settings";
    public List<EqualizerDescriptor> slider;

    // Start is called before the first frame update

    private void adaptSlider()
    {
        foreach (EqualizerDescriptor value in slider)
        {
            value.slide.onValueChanged.AddListener(delegate { valueChecked(value); });
        }
       
    }

    private void valueChecked(EqualizerDescriptor desc)
    {
        AudioStruct[] src = SoundManager.SoundLibrary().getSourceByCategories(desc.category);

        foreach(AudioStruct val in src)
        {
            val.source.volume = val.volume * desc.slide.value;
        }
    }
    public void save(string nameSave)
    {
        EqualizerSaver eqSave = new EqualizerSaver();
        eqSave.nameEq = nameEQ;
        List<EqualizerSaver.EqualizerDescSaver> descSaver =  new List<EqualizerSaver.EqualizerDescSaver>();
        foreach(EqualizerDescriptor eqDesc in slider)
        {
            descSaver.Add(new EqualizerSaver.EqualizerDescSaver(eqDesc.category, eqDesc.slide.value));
        }
        eqSave.eqDescSaver = descSaver.ToArray();
        string f = JsonUtility.ToJson(eqSave);
        if (!System.IO.Directory.Exists(Application.dataPath + "\\" + relativePath))
        {
            System.IO.Directory.CreateDirectory(Application.dataPath + "\\" + relativePath);
        }
        System.IO.File.WriteAllText(Application.dataPath + "\\" + relativePath + nameSave + ".json", f);
        print("save : " + nameSave);
    }
    private void Awake()
    {
        GameObject same = GameObject.Find(gameObject.name);
        if (same && same != this.gameObject)
        {
            Destroy(same);
        }
    }
    private void resetSound()
    {
        foreach (EqualizerDescriptor eq in slider)
        {
            valueChecked(eq);
        }
    }
    void Start()
    {
        DontDestroyOnLoad(this);
        resetSound();
        adaptSlider();
    }
    public void load(string name)
    {
        if (System.IO.File.Exists(Application.dataPath + "\\" + relativePath + name + ".json"))
        {
            string f = System.IO.File.ReadAllText(Application.dataPath + "\\" + relativePath + name + ".json");
            EqualizerSaver eq = JsonUtility.FromJson<EqualizerSaver>(f);
            if (nameEQ == eq.nameEq)
            {
                for (int i = 0; i < eq.eqDescSaver.Length; i++)
                {
                    slider[i].slide.value = eq.eqDescSaver[i].value;
                    print(eq.eqDescSaver[i].value);
                }
            }
            else
            {
                print("Wrong eq");
            }
        }
        else
        {
            print("No file found");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
