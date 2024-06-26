using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LIV.Examples
{
    [RequireComponent(typeof(Toggle))]
    public class ToggleColorController : MonoBehaviour
    {
        [Header("Elements")]
        [SerializeField] private Image icon;
        [SerializeField] private TextMeshProUGUI label;

        [Space(16)] 
        [Header("On State Colors")]
        [SerializeField] private ColorBlock colorBlockOn;
        [SerializeField] private Color colorIconOn;
        [SerializeField] private Color labelColorOn;

        [Space(16)] 
        [Header("Off State Colors")]
        [SerializeField] private ColorBlock colorBlockOff;
        [SerializeField] private Color colorIconOff;
        [SerializeField] private Color labelColorOff;

        private Toggle _toggle;

        private void Awake()
        {
            _toggle = GetComponent<Toggle>();
        }

        private void Start()
        {
            UpdateColorSets(_toggle.isOn);
        }

        private void OnEnable()
        {
            UpdateColorSets(_toggle.isOn);
            _toggle.onValueChanged.AddListener(UpdateColorSets);
        }

        private void OnDisable()
        {
            _toggle.onValueChanged.RemoveListener(UpdateColorSets);
        }

        private void UpdateColorSets(bool b)
        {
            if (b)
            {
                _toggle.colors = colorBlockOn;
                if (icon) icon.color = colorIconOn;
                if (label) label.color = labelColorOn;

            }
            else
            {
                _toggle.colors = colorBlockOff;
                if (icon) icon.color = colorIconOff;
                if (label) label.color = labelColorOff;
                
            }
        }
    }
}
