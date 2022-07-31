using System.Fabric;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly StatelessServiceContext _context;

        public IndexModel(ILogger<IndexModel> logger, StatelessServiceContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {
            var configSettings = _context.CodePackageActivationContext.GetConfigurationPackageObject("Config").Settings;
            var data = configSettings.Sections["MyConfigSection"];

            var settings = new Dictionary<string, string>();
            foreach (var parameter in data.Parameters)
            {
                settings.Add(parameter.Name, parameter.Value);
            }
            ViewData.Add("pageConfig", settings);
        }
    }
}