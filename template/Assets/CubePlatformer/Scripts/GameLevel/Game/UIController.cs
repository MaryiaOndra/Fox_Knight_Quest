using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CubePlatformer
{
    public class UIController : MonoBehaviour
    {
        [SerializeField]
        TMP_Text scoreTxt;

        //List<BaseBtn> btnStates;
        //KeyboardBtns keyboardBtns;

        public Action<BtnState> OnActiveBtn;

        private void Awake()
        {
            //keyboardBtns = FindObjectOfType<KeyboardBtns>();
            //keyboardBtns.OnKeyboardInput += SetBtnStateToPlayer;

            //btnStates = new List<BaseBtn>(FindObjectsOfType<BaseBtn>(true));

            //btnStates.ForEach(_state =>
            //{
            //     _state.BtnAction += SetBtnStateToPlayer;
            //});
        }

        public void WriteScoreText(int _count) 
        {
            scoreTxt.text = "COINS:___" + _count;
        }

        //public void SetBtnStateToPlayer(BtnState _btnState) 
        //{
        //    OnActiveBtn.Invoke(_btnState);            
        //}
    }
}
