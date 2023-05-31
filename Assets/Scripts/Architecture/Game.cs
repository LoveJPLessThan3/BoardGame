public class Game
{
    public readonly ICourutineRunner _sceneLoader;
    public StateMachine StateMachine;
    
    public Game(ICourutineRunner sceneLoader, LoadingCurtain curtain)
    {
        _sceneLoader = sceneLoader;

        StateMachine = new StateMachine(new SceneLoader(_sceneLoader), curtain);
    }
}
