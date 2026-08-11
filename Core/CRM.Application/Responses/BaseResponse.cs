namespace CRM.Application.Responses
{
    public class BaseResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }
        public List<string>? Errors { get; set; }
        public int StatusCode { get; set; }
         
        public static BaseResponse<PagedList<T>> SuccessResult(IEnumerable<T> data, int page, int pageSize, string? message = null)
        {
            var pagedList = new PagedList<T>(data, page, pageSize);
            return new BaseResponse<PagedList<T>> { Success = true, Data = pagedList, Message = message ?? "Operation completed successfully" };
        }

        public static BaseResponse<T> SuccessResult(T? data, int statusCode, string? message = null)
        {
            return new BaseResponse<T> { Success = true, Data = data, Message = message ?? "Requested data retrieved successfully.", StatusCode = statusCode };
        }

        public static BaseResponse<T> FailureResult(List<string> errors, int statusCode, string? message = null)
        {
            return new BaseResponse<T> { Success = false, Data = default, Errors = errors, Message = message ?? "Operation failed.",
            StatusCode = statusCode };
        }

        public static BaseResponse<T> FailureResult(string error, int statusCode, string? message = null)
        {
            return new BaseResponse<T> { Success = false, Data = default, Errors = [error], Message = message ?? "Operation failed.", 
            StatusCode = statusCode };
        }
    }

    public class PagedList<T>
    {
        public IEnumerable<T>? Items { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }

        public PagedList(IEnumerable<T>? items, int page, int pageSize)
        {
            Items = items;
            Page = page;
            PageSize = pageSize;
        }

    }





}
