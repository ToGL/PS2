namespace PS2.Model
{
    public class Settings
    {
        public string LineageWindowTitle { get; set; }
        public string MainLineageClientPath { get; set; }
        public string AlternativeLineageClientPath { get; set; }

        public bool RenameClientWindow { get; set; } = true;
        public bool LoginUpToCharacter { get; set; }

    }
}
