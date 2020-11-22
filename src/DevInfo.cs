namespace SpongeQR
{
    class DevInfo
    {
        private string Version { get; set; }
        private string Contact { get; set; }
        private string Message { get; set; }

        public DevInfo(string Version, string Contact, string Message)
        {
            this.Version = Version;
            this.Contact = Contact;
            this.Message = Message;
        }

        public override string ToString()
        {
            return $"SpongeQR was Developed By Jordan McCann (@youugotssponged).\n\n" +
                $"Current Version: ({Version})\n\n" +
                $"Contact: {Contact}\n\n" +
                $"{Message}";
        }

    }
}
