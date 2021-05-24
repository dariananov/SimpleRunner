using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace AzurSimpleRunner
{    
    public class FinishApplicationView : ApplicationView
    {
        public GameObject finishPrefab;
        public float finishPause = 5f;
        
        protected override void SetWaiting()
        {
            finishPrefab.SetActive(false);
        }
        
        protected override void SetFinish()
        {
            finishPrefab.SetActive(true);
            StartCoroutine(RestartAfterPause());
        }
        
        protected override void SetPlaying()
        {
            finishPrefab.SetActive(false);
        }

        private IEnumerator RestartAfterPause()
        {
            yield return new WaitForSeconds(finishPause);
            controller.ReloadScene();
        }

        private void OnDestroy()
        {
            StopAllCoroutines();
        }
    }
}
