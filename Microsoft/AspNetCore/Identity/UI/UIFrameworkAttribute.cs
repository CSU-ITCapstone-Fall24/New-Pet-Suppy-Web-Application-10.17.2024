namespace Pet_Web_Application_10._12._24_F.Microsoft.AspNetCore.Identity.UI
{
    [AttributeUsage(AttributeTargets.All)]
    internal class UIFrameworkAttribute(string framework) : Attribute
    {
        public string Framework { get; } = framework;
    }
}