using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace JayaCart
{
    class Helpers
    {
        const string FIREBASE_DATABASE = "https://jaya-cart-2020.firebaseio.com/";

        static Helpers _instance;

        private Helpers()
        {

        }

        public static Helpers Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Helpers();

                return _instance;
            }
        }

        public FirebaseClient GetConnection()
        {
            return new FirebaseClient(FIREBASE_DATABASE);
        }
    }
}
