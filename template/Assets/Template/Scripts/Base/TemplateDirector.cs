using System.Collections;
using System.Collections.Generic;
using Template.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Template.Base
{
    public class TemplateDirector : AppDirector
    {
        protected override void Awake()
        {
            base.Awake();

            SceneManager.LoadScene("Menu");
        }
    }
}
