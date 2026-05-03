using System.Text;

namespace Anom.Core.Common.Results;

public class Result
{
    public int Code { get; protected set; } = (int)ResultCode.Ok;
    private bool IsValid => Code < 400;
    public bool Success => Code == (int)ResultCode.Ok;
    private List<ResultValidation> Validations { get; set; } = [];

    public void AddValidation(string attribute, string message)
    {
        Code = (int)ResultCode.BusinessError;
        Validations.Add(new ResultValidation(attribute, message));
    }
    
    public void SetCode(ResultCode code)
    {
        Code = (int)code;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        if (!IsValid && Validations.Any())
        {
            sb.AppendLine($"Validations:");
            Validations.ForEach(x => sb.Append($"- {x.Attribute}: {x.Message}"));
        }
        
        return sb.ToString();
    }
}

public class Result<T> : Result
{
    public T Data { get; set; }
}