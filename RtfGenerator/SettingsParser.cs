using System;

namespace RtfGenerator
{
    internal class SettingsParser
    {
        private static void ParseArg(Settings s, string arg)
        {
            string[] parts = arg?.Split('=');
            int length = parts?.Length ?? 0;
            if (length < 1 || length > 2)
                return;

            switch(parts[0].TrimStart('-'))
            {
                case "g":
                    s.NeedGenerate = true;
                    break;
                case "f":
                    if (!int.TryParse(parts[1]?.Trim() ?? "a", out int frequency))
                        break;
                    s.Delay = (int)Math.Ceiling(1.0 / (frequency == 0 ? 1 : frequency) * 1000);
                    break;
            }
        }

        internal static Settings Parse(string[] args)
        {
            var settings = new Settings();

            if (args?.Length == 0)
                return settings;

            foreach(string arg in args)
            {
                ParseArg(settings, arg);
            }

            return settings;
        }
    }
}
