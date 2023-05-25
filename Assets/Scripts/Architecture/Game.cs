public class Game
{
    public readonly ICourutineRunner _sceneLoader;
    public StateMachine StateMachine;
    

    public Game(ICourutineRunner sceneLoader)
    {
        _sceneLoader = sceneLoader;

        StateMachine = new StateMachine(new SceneLoader(_sceneLoader));
    }
}
