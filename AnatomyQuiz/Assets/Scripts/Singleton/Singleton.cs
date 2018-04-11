using UnityEngine;

public class Singleton : MonoBehaviour
{

    // QuizManager
    private QuizManager _quizManager = null;
    static private QuizManager _quizManagerS = null;
    static public QuizManager QuizManager { get { return _quizManagerS; } }

    // event manager
    private EventManager _eventManager = null;
    static private EventManager _eventManagerS = null;
    static public EventManager EventManager { get { return _eventManagerS; } }

    // singleton
    static private Singleton _instance = null;
    static private bool _isQuitting = false;
    static private bool _isInitialized = false;

    // singleton accessor
    static public bool IsValid { get { return !_isQuitting && _instance != null && _isInitialized; } }
    static public Singleton Instance { get { return _instance; } }

    //
    void Awake()
    {
        _instance = this;
        _isQuitting = false;
        _isInitialized = false;

        Create();
    }

    private void Create()
    {
        _quizManager = new QuizManager();
        _quizManagerS = _quizManager;

        _eventManager = new EventManager();
        _eventManagerS = _eventManager;
    }

    public void Initialize()
    {
        _quizManager.Initialize();
        _eventManager.Initialize();
    }

    void Update()
    {
        if (_isInitialized == false)
        {
            Initialize();
            _isInitialized = true;

            DontDestroyOnLoad(gameObject);

            return;
        }

    }

    void OnApplicationQuit()
    {
        if (IsValid == false)
            return;

    }

    void OnDestroy()
    {
        StopAllCoroutines();
    }

    public void Deinitialize()
    {
        _quizManager.Deinitialize();
        _eventManager.Deinitialize();

        _isInitialized = false;
    }

    private void DestroyObjects()
    {
        _quizManager = null;
        _quizManagerS = null;

        _eventManagerS = null;
        _eventManager = null;
    }

    void OnDisable()
    {
        _isQuitting = true;

        DestroyObjects();

        // free static instance of singleton
        _instance = null;

        Debug.Log("Singleton Destroyed");
    }
}
