using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HostelDll.Bl;

namespace HostelDll.DLInterfaces
{
    public interface IRule
    {
        bool AddRule(Rule rule);
        bool DeleteRule(int ruleId);
        List<Rule> GetAllRules();
        List<int> GetRuleIds();
    }
}
