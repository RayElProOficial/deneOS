namespace deneAI
{
    internal static class Program
    {
        static ApplicationContext appContext;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            //appContext = new ApplicationContext(new Ollama());
            //appContext.MainForm!.FormClosed += (s, e) => new Form1().Show();

            string? authCode = null;


            foreach (string arg in args)
            {
                if (arg.StartsWith("deneai://", StringComparison.OrdinalIgnoreCase))
                {
                    authCode = GetAuthCode(arg);

                    var form = new Advanced(authCode);
                    Application.Run(form);

                    return;
                }
            }

            Application.Run(new startscreen());
        }

        private static string? GetAuthCode(string value)
        {
            if (!Uri.TryCreate(value, UriKind.Absolute, out Uri? uri))
                return null;

            if (!uri.Scheme.Equals("deneai", StringComparison.OrdinalIgnoreCase))
                return null;

            if (!uri.Host.Equals("auth", StringComparison.OrdinalIgnoreCase))
                return null;

            foreach (string parameter in uri.Query.TrimStart('?').Split('&'))
            {
                string[] parts = parameter.Split('=', 2);

                if (
                    parts.Length == 2 &&
                    parts[0].Equals("code", StringComparison.OrdinalIgnoreCase)
                )
                {
                    return Uri.UnescapeDataString(parts[1]);
                }
            }

            return null;
        }
    }
}       