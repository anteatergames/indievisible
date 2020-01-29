using System;
using System.Collections.Generic;
using System.Text;

namespace IndieVisible.Infra.CrossCutting.Notifications.Slack
{
    internal class SlackMessage
    {
        public SlackMessage(string text)
        {
            this.Text = text;
        }

        public string Text { get; set; }
    }
}
