// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class AchieveManager : MonoBehaviour
// {
//     public GameObject[] lockCharacter;
//     public GameObject[] unlockCharacter;
//     public GameObject[] uiNotice;

//     enum Achieve {UnlockPotato, UnlokcBean}
//     Achieve[] achieves;
//     WaitForSeconds wait;

//     void Awake(){
//         achieves = (Achieve[])Enum.GetValues(typeof(Achieve));
//         wait = new WaitForSeconds(5);

//         if(!PlayerPrefs.Haskey("MyData")){
//             Init();
//         }
//     }
    
//     void Init(){
//         PlayerPrefs.SetInt("MyData", 1);

//         foreach (Achieve achieve in achieves)
//         {
//             PlayerPrefs.SetInt(achieve.ToString(), 0);
//         }
//     }

//     void Start(){
//         UnlockCharacter();
//     }

//     void UnlockCharacter(){
//         for(int index=0; index < lockCharacter.Length; index++){
//             string achieveName = achieves[index].ToString();
//             bool isUnlock = PlayerPrefs.GetInt(achieveName) == 1;
//             lockCharacter[index].SetActive(!isUnlock);
//             unlockCharacter[index].SetActive(!isUnlock);
//         }
//     }

//     void LateUpdate() {
//         foreach (Achieve achieve in achieves){
//             CheckAchieve(achieve);
//         }
//     }

//     void CheckAchieve(Achieve achieve){
//         bool isAchieve = false;

//         switch (achieve){
//             case Achieve.UnlockPotato:
//             isAchieve = GameManager.instance.kill >= 10;
//             break;
//         }

//         if(isAchieve && PlayerPrefs.GetInt(achieve.ToString()) == 0){
//             PlayerPrefs.SetInt(achieve.ToString(), 1);

//             for (int index=0; index < uiNotice.transform.childCount; index++){
//                 bool isAchieve = index ==(int)achieve;
//                 // uiNotice.transform.GetChild(index).gameObject.SetActive(is)
//             }

//             StartCourtine(NoticeRoutine());
//         }
//     }
//     IEnumerator NoticeRoutine(){
//         uiNotice.SetActive(true);
//         AudioManager.instance.PlaySfx(AudioManager.Sfx.LevelUP);
//         yield return wait;

//         uiNotice.SetActive(false);
//     }
// }
