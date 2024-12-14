namespace DvachApi.Common.Interfaces;

public interface IConverter <out T>
{
    T Convert(HttpResponseMessage responseMessage);
}