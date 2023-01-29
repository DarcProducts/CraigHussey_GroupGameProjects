using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    [SerializeField] UIDocument gameUIDocument;
    [SerializeField] UnityEvent OnCreateButtonPressed;
    [SerializeField] UnityEvent OnCreateButtonEntered;
    [SerializeField] UnityEvent OnCreateButtonExited;
    [SerializeField] UnityEvent OnClearButtonPressed;
    [SerializeField] UnityEvent OnClearButtonEntered;
    [SerializeField] UnityEvent OnClearButtonExited;
    [SerializeField] UnityEvent OnExitButtonPressed;
    [SerializeField] UnityEvent OnExitButtonEntered;
    [SerializeField] UnityEvent OnExitButtonExited;

    private void OnEnable()
    {
        BindGameUIButtons();
    }

    private void OnDisable()
    {
        UnBindGameUIButtons();
    }

    void BindGameUIButtons()
    {
        VisualElement root = gameUIDocument.rootVisualElement;
        var createButton = root.Q<Button>("create-item-button");
        if (createButton != null)
        {
            createButton.clicked += CreateButtonPressed;
            createButton.RegisterCallback<MouseEnterEvent>(CreateButtonEntered);
            createButton.RegisterCallback<MouseOutEvent>(CreateButtonExited);
        }
        var clearButton = root.Q<Button>("clear-items-button");
        if (clearButton != null)
        {
            clearButton.clicked += ClearButtonPressed;
            clearButton.RegisterCallback<MouseEnterEvent>(ClearButtonEntered);
            clearButton.RegisterCallback<MouseOutEvent>(ClearButtonExited);
        }
        var exitButton = root.Q<Button>("exit-button");
        if (exitButton != null)
        {
            exitButton.clicked += ExitButtonPressed;
            exitButton.RegisterCallback<MouseEnterEvent>(ExitButtonEntered);
            exitButton.RegisterCallback<MouseOutEvent>(ExitButtonExited);
        }
    }

    /// <summary>
    /// Not sure if you need to unregister, but what I know about events, you usually do.
    /// </summary>
    void UnBindGameUIButtons()
    {
        VisualElement root = gameUIDocument.rootVisualElement;
        var createButton = root.Q<Button>("create-item-button");
        if (createButton != null)
        {
            createButton.clicked -= CreateButtonPressed;
            createButton.UnregisterCallback<MouseEnterEvent>(CreateButtonEntered);
            createButton.UnregisterCallback<MouseOutEvent>(CreateButtonExited);
        }
        var clearButton = root.Q<Button>("clear-items-button");
        if (clearButton != null)
        {
            clearButton.clicked -= ClearButtonPressed;
            clearButton.UnregisterCallback<MouseEnterEvent>(ClearButtonEntered);
            clearButton.UnregisterCallback<MouseOutEvent>(ClearButtonExited);
        }
        var exitButton = root.Q<Button>("exit-button");
        if (exitButton != null)
        {
            exitButton.clicked -= ExitButtonPressed;
            exitButton.UnregisterCallback<MouseEnterEvent>(ExitButtonEntered);
            exitButton.UnregisterCallback<MouseOutEvent>(ExitButtonExited);
        }
    }


    void CreateButtonPressed() => OnCreateButtonPressed?.Invoke();

    void CreateButtonEntered(MouseEnterEvent evt) => OnCreateButtonEntered?.Invoke();

    void CreateButtonExited(MouseOutEvent evt) => OnCreateButtonExited?.Invoke();

    void ClearButtonPressed() => OnClearButtonPressed?.Invoke();

    void ClearButtonEntered(MouseEnterEvent evt) => OnClearButtonEntered?.Invoke();

    void ClearButtonExited(MouseOutEvent evt) => OnClearButtonExited?.Invoke();

    void ExitButtonPressed() => OnExitButtonPressed?.Invoke();

    void ExitButtonEntered(MouseEnterEvent evt) => OnExitButtonEntered?.Invoke();

    void ExitButtonExited(MouseOutEvent evt) => OnExitButtonExited?.Invoke();
}
