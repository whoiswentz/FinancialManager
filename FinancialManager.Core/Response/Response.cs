using System.Text.Json.Serialization;

namespace FinancialManager.Core.Response;

public class Response<T>
{
    private readonly int _code = Constants.DefaultHttpCode;
    
    public T? Data { get; set; }
    public int? Code { get; set; }

    public Response(T? data, int code = Constants.DefaultHttpCode)
    {
        Data = data;
        Code = code;
    }

    [JsonConstructor]
    protected Response() => _code = Constants.DefaultHttpCode;
    
    [JsonIgnore]
    public bool IsSuccess => _code is >= 200 and <= 299;
}