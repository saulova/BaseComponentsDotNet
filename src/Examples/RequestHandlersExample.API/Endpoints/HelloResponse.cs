namespace RequestHandlersExample.API.Endpoints;

public class HelloResponse(string result)
{
    public string Result { get; set; } = result;
}
