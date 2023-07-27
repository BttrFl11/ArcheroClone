using UnityEngine;

namespace UI
{
    public class OpenUrl : MonoBehaviour
    {
        public void Open(string url)
        {
            Application.OpenURL(url);
        }
    }
}
