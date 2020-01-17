using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Rewrite;

namespace IndieVisible.Web.RewriterRules
{
    public class NonWwwRule : IRule
    {
        public void ApplyRule(RewriteContext context)
        {
            HttpRequest request = context.HttpContext.Request;
            HostString host = context.HttpContext.Request.Host;


            if (host.HasValue && host.Value.ToLower().Contains(".indievisible.net"))
            {
                context.Result = RuleResult.SkipRemainingRules;
            }
            else
            {
                context.Result = RuleResult.ContinueRules;
            }
        }
    }
}
