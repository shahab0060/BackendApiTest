namespace BackendApiTest.Domain.ViewModels.Common
{
    public class BaseListDto<T> where T : struct
    {
        public T Id { get; set; }
    }
}
