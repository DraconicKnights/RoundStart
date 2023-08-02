namespace RoundStart.EventHandler.EventManager
{
    public class Events
    {
        private int _id;
        private string _name;
        private string _permission;
        private bool _active;

        protected Events(int id, string name, string permission, bool active)
        {
            ID = id;
            Name = name;
            Permission = permission;
            Active = active;
        }
        public int ID
        {
            get => _id;
            set => _id = value;
        }
        
        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public string Permission
        {
            get => _permission;
            set => _permission = value;
        }

        public bool Active
        {
            get => _active;
            set => _active = value;
        }


        public override string ToString()
        {
            return "";
        }
    }
}