using UnityEngine;
using UnityEngine.UI;

namespace Onomos
{
    public class Collection : MonoBehaviour
    {
        public Text onomoDescriptionText;
        public GameObject player;
        public TrackProperties playerOnomosList;
        public Button[] buttons;
        public Image selectedOnomoImage;

        private void Awake()
        {
            foreach (var button in buttons)
            {
                button.interactable = false;
            }
        }

        public void SelectOnomoInCollection(GameObject selected)
        {
            var onomo = playerOnomosList.GetChoices(player, selected);
            selectedOnomoImage.sprite = player.GetComponentInChildren<SpriteRenderer>().sprite;
            onomoDescriptionText.text = onomo.GetComponent<OnomoStatus>().collectionDescription;
        }
    }
}