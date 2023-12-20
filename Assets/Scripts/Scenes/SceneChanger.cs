using UnityEngine.SceneManagement;
public class SceneChanger
{
    public void LoadSceneAsync(string sceneName, LoadSceneMode mode =LoadSceneMode.Single) 
    {
        SceneManager.LoadSceneAsync(sceneName, mode);
    }
}
