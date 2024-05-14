namespace InvoiceApp.StartUpHelpers
{
    public interface IAbstractFactory<T>
    {
        T Create();
    }
}