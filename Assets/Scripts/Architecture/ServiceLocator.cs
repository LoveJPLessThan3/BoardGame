public class ServiceLocator
{
    // Сервис локатор - это частный случай синглтона. Нужен для инициализации всех сервисов и удобного пробрасывания зависимостей.
    private static ServiceLocator _instantiate;

    public static ServiceLocator Instantiate
        => _instantiate ?? (_instantiate = new ServiceLocator());

    public void RegisterService<TService>(TService implementation) where TService : IService => 
        Implementation<TService>.ServiceInstance = implementation;

    public TService GetService<TService>() where TService : IService =>
        Implementation<TService>.ServiceInstance;

    //Из-за того, что дженерик тип сохраняется в статическом классе, в сборке создается свой класс, тем самым не нужно создавать структуру данных
    //В моем случае словарь, чтобы можно было обращаться к сервисам
    private static class Implementation<TService> where TService : IService
    {
        public static TService ServiceInstance;
    }
}