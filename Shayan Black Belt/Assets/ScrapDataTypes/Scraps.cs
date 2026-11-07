using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Scrap Data", menuName = "ScriptableObjects/ScrapData", order = 1)]
public class Scraps : ScriptableObject
{
    public string scrapName;
    public int scrapCost;
    public int scrapCondition;
    public string scrapConditionVisualizer;
}
