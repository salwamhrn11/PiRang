namespace PiRang_WPF
{
    class WargaDesa
    {
        string _email;
        string _nomorHp;
        string _password;

        public string Email
        {
            get {   return _email; }
            set { _email = value; }
        }

        public string NomorHp 
        { 
            get { return _nomorHp; } 
            set { _nomorHp = value; } 
        }

        public string password { get { return _password; } set { _password = value; } }


        public void Save()
        { // to be implemented
          //
        }

        public void Edit()
        { // to be implemented
          //
        }
    }
}