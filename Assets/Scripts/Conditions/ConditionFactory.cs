using System.Collections;
using System.Collections.Generic;

namespace Conditions
{
    public class ConditionFactory
    {
        public static string[] GetAllConditionsNames()
        {
            return new string[] {new MailCondition().GetConditionName(), new DestinationCondition().GetConditionName()};
        }

        public static Condition[] GetAllConditiions()
        {
            return new Condition[] {new MailCondition(), new DestinationCondition()};
        }
    }
}