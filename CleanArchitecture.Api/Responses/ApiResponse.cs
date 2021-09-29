using CleanArchitecture.ApplicationCore.CustomEntities;

namespace CleanArchitecture.Api.Responses
{
    public class ApiResponse<T>
    {
        public T Data { get; set; }
        public Metadata Meta { get; set; }
        public ApiResponse(T data)
        {
            Data = data;
        }
        public ApiResponse(T data, Metadata meta)
        {
            Data = data;
            Meta = meta;
        }
    }
}
