using System;

namespace InterfaceSegregation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }


        //Bad
        public interface CloudProvider
        {
            void StoreFile();
            void LoadFile();
            void CreateServer();
            void ListServers();
            void GetCDNAddress();
        }

        public class Amazon : CloudProvider
        {
            public void CreateServer()
            {
                Console.WriteLine("Implemented");
            }

            public void GetCDNAddress()
            {
                Console.WriteLine("Implemented");

            }

            public void ListServers()
            {
                Console.WriteLine("Implemented");

            }

            public void LoadFile()
            {
                Console.WriteLine("Implemented");

            }

            public void StoreFile()
            {
                Console.WriteLine("Implemented");

            }
        }

        public class DropBox : CloudProvider
        {
            public void CreateServer()
            {
                throw new NotImplementedException();
            }

            public void GetCDNAddress()
            {
                throw new NotImplementedException();


            }

            public void ListServers()
            {
                throw new NotImplementedException();

            }

            public void LoadFile()
            {
                Console.WriteLine("Implemented");

            }

            public void StoreFile()
            {
                Console.WriteLine("Implemented");

            }
        }

        //Good 
        public interface CloudHostingProvider
        {
            void CreateServer();
            void ListServers();
        }

        public interface CDNProvider
        {
            void GetCDNAddress();
        }

        public interface CloudStorageProvider
        {
            void StoreFile();
            void LoadFile();
        }

        public class GoodAmazon : CloudHostingProvider, CDNProvider, CloudStorageProvider
        {
            public void CreateServer()
            {
                Console.WriteLine("Implemented");
            }

            public void GetCDNAddress()
            {
                Console.WriteLine("Implemented");

            }

            public void ListServers()
            {
                Console.WriteLine("Implemented");

            }

            public void LoadFile()
            {
                Console.WriteLine("Implemented");

            }

            public void StoreFile()
            {
                Console.WriteLine("Implemented");

            }
        }

        public class Dropbox : CloudStorageProvider
        {
            public void LoadFile()
            {
                Console.WriteLine("Implemented");
            }

            public void StoreFile()
            {
                Console.WriteLine("Implemented");
            }
        }
    }
}
