using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private UIDocument uiDocument;
    private Button startButton;
    private Slider sensitivitySlider;

    void Awake()
    {
        uiDocument = GetComponent<UIDocument>();

        startButton = uiDocument.rootVisualElement.Q<Button>("StartButton");
        startButton.RegisterCallback<ClickEvent>(OnStartButtonClick);

        sensitivitySlider = uiDocument.rootVisualElement.Q<Slider>("SensitivitySlider");
        sensitivitySlider.RegisterValueChangedCallback(OnSliderValueChanged);
    }

    private void OnDisable()
    {
        if (startButton != null)
            startButton.UnregisterCallback<ClickEvent>(OnStartButtonClick);

        if (sensitivitySlider != null)
            sensitivitySlider.UnregisterValueChangedCallback(OnSliderValueChanged);
    }

    private void OnStartButtonClick(ClickEvent evt)
    {
        Debug.Log("Start button clicked. Loading SampleScene...");
        SceneManager.LoadScene("SampleScene");
    }

    private void OnSliderValueChanged(ChangeEvent<float> evt)
    {
        float sensitivity = evt.newValue;
        Debug.Log($"Sensitivity changed to: {sensitivity}");

        PlayerPrefs.SetFloat("MouseSensitivity", sensitivity);
        PlayerPrefs.Save();
    }
}
