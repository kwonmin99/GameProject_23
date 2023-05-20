using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public GameObject[] prefabs;

    List<GameObject>[] pools;

<<<<<<< HEAD
    void Awake() {
        pools = new List<GameObject>[prefabs.Length];

        for(int index = 0; index < pools.Length; index++){
=======
    void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];

        for (int index = 0; index < pools.Length; index++)
        {
>>>>>>> myeongjun
            pools[index] = new List<GameObject>();
        }
    }

<<<<<<< HEAD
    public GameObject Get(int index){
        GameObject select = null;
        //..ì„ íƒí•œ í’€ì˜ ë†€ê³  ìžˆëŠ” ê²Œìž„ì˜¤ë¸Œì íŠ¸ ì ‘ê·¼
        foreach (GameObject item in pools[index]){
            if(!item.activeSelf){
                //.. ë°œê²¬í•˜ë©´ select ë³€ìˆ˜ì— í• ë‹¹
=======
    public GameObject Get(int index)
    {
        GameObject select = null;
        //..¼±ÅÃÇÑ Ç®ÀÇ ³î°í ÀÖ´Â °ÔÀÓ¿ÀºêÁ§Æ® Á¢±Ù
        foreach (GameObject item in pools[index])
        {
            if (!item.activeSelf)
            {
                //.. ¹ß°ßÇÏ¸é select º¯¼ö¿¡ ÇÒ´ç
>>>>>>> myeongjun
                select = item;
                select.SetActive(true);
                break;
            }
        }
<<<<<<< HEAD

        //.. ëª» ì°¾ì•˜ìœ¼ë©´?
        if(!select){
            //.. ìƒˆë¡­ê²Œ ìƒì„±í•˜ê³  select ë³€ìˆ˜ì— í• ë‹¹
=======
        
        //.. ¸ø Ã£¾ÒÀ¸¸é?
        if (!select)
        {
            //.. »õ·Ó°Ô »ý¼ºÇÏ°í select º¯¼ö¿¡ ÇÒ´ç
>>>>>>> myeongjun
            select = Instantiate(prefabs[index], transform);
            pools[index].Add(select);
        }

        return select;

    }

<<<<<<< HEAD
}
=======
}
>>>>>>> myeongjun
