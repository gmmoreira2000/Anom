namespace Anom.Core.Common.Results;

public static class Validations
{
    public static void IsNull<T>(T obj, Result result, string atribute, string message)
    {
        if (obj == null)
            result.AddValidation(atribute, message);
    }

    public static void IsTrue(bool exp, Result result, string atribute, string message)
    {
        if (exp)
            result.AddValidation(atribute, message);
    }

    public static void IsFalse(bool exp, Result result, string atribute, string message)
    {
        if (!exp)
            result.AddValidation(atribute, message);
    }

    public static void IsNullorEmpty(string obj, Result result, string atribute, string message)
    {
        if (string.IsNullOrEmpty(obj))
            result.AddValidation(atribute, message);
    }

    public static void IsNullorEmpty<T>(ICollection<T> obj, Result result, string atribute, string message)
    {
        if(obj == null ||  obj.Count == 0)
            result.AddValidation(atribute, message);
    }
}