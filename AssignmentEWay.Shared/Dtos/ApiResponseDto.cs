namespace AssignmentEWay.Shared.Dtos
{
    public record ApiResponse<T>(bool IsSuccess, T? Data, string? ErrorMessage = null)
    {
        public static ApiResponse<T> Success(T data) => new ApiResponse<T>(true, data);
        public static ApiResponse<T> Fail(string errorMessage) => new ApiResponse<T>(false, default, errorMessage);
    }
}
