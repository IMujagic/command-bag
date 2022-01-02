using CommandBag.Core;
using CommandBag.DIConfig;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandBag.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public List<CommandMetadata> Commands { get; private set; }

        public IndexModel(ILogger<IndexModel> logger, ICommandRunner runner)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            this.Commands = MainModule.CommandMetadataList;
        }
    }
}
