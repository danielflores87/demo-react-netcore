namespace demo.back.Application.Utils
{
    public class ApiResponse<T>
    {
        public T Data { get; set; }
        public int? Total { get; set; }
        public IOperation Operation { get; set; }

        public ApiResponse(T data, EResponseCodes code, string? message = null, int? total = null)
        {
            Data = data;
            Total = total;
            Operation = new Operation
            {
                Code = code.ToStringValue(),
                Message = message ?? "Operacion Exitosa."
            };
        }
    }


    public interface IOperation
    {
        string Code { get; set; }
        string Message { get; set; }
    }

    // Implementación de la interfaz en la clase Operation
    public class Operation : IOperation
    {
        public string Code { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
    }

    // Enumeración de los códigos de respuesta
    public enum EResponseCodes
    {
        Success,
        Error,
        NotFound,
        Warning,
        Unauthorized
    }


    public static class EResponseCodesExtensions
    {
        public static string ToStringValue(this EResponseCodes code)
        {
            return code switch
            {
                EResponseCodes.Success => "OK",
                EResponseCodes.Error => "FAIL",
                EResponseCodes.NotFound => "FAIL",
                EResponseCodes.Warning => "WARN",
                EResponseCodes.Unauthorized => "FAIL",
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}
