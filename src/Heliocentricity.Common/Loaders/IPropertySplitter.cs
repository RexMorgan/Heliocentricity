namespace Heliocentricity.Common.Loaders
{
    public interface IPropertySplitter
    {
        string GetKey(string keyValue);
        string GetValue(string keyValue);
    }
}