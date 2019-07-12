﻿using System.Text.RegularExpressions;
using Gambot.Core;
namespace Gambot.IO.Slack
{
    public class SlackMessage : IMessage
    {
        public string Who { get; protected set; }
        public string To { get; protected set; }
        public string Text { get; protected set; }
        public string Where { get; protected set; }
        public bool Action { get; protected set; }

        public SlackMessage(string who, string where, string text, bool action)
        {
            Who = who;
            Where = where;
            Action = action;
            var toMatch = Regex.Match(text, @"^((?:[^:]+?)|(?::.+?:))[,:]\s");
            if (toMatch.Success)
            {
                To = toMatch.Groups[1].Value;
                Text = text.Substring(toMatch.Length).Trim();
            }
            else
                Text = text.Trim();
        }
    }
}
