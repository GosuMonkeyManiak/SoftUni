namespace CustomIoC
{
    public interface ICustomServiceCollection
    {
        void Map<TInterface, TImplementation>()
            where TInterface : class
            where TImplementation : class;

        public ICustomServiceProvider BuildCustomServiceProvider();
    }
}