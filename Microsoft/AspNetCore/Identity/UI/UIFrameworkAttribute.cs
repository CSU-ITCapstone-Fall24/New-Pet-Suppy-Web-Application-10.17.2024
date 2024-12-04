namespace Pet_Web_Application_10._12._24_F.Microsoft.AspNetCore.Identity.UI
{
    [AttributeUsage(AttributeTargets.All)]
    internal class UIFrameworkAttribute : Attribute
    {
        public string Framework { get; }

        public UIFrameworkAttribute(string framework) => Framework = framework;
    }
}