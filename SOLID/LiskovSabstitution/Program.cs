using System;
using System.Collections.Generic;

namespace LiskovSabstitution
{
    class Program
    {
        static void Main(string[] args)
        {
            var goodStore = new AnimalStore();
            var badStore = new CatStore();

            goodStore.Feed(new Animal());
            goodStore.Feed(new Cat());
            goodStore.Feed(new BengalCat());

            //badStore.Feed(new Animal()); //error
            badStore.Feed(new Cat());
            //badStore.Feed(new BengalCat()); //error

            var badProj = new BadProject();
            var goodProj = new GoodProject();

            var badDocs = new List<Document>()
            {
                new Document(),
                new ReadOnlyDocument()
            };

            var goodDocs = new List<WritableDocument>() { new GoodDocument()};

            goodProj.SaveAll(goodDocs);
            badProj.SaveAll(badDocs);


        }
    }


    public class Animal
    {

    }

    public class Cat : Animal
    {

    }

    public class BengalCat : Animal
    {

    }

    //bad
    public class CatStore
    {
        public void Feed(Cat cat)
        {
            if (cat.GetType() == typeof(Cat)) Console.WriteLine("Feed Cat");
            else
            {
                Console.WriteLine("Not working");
            }
        }
    }

    //good
    public class AnimalStore
    {
        public void Feed(Animal animal)
        {
            Console.WriteLine($"Feed {animal.GetType()}");
        }
    }

    public class Document
    {
        public string Data { get; set; }
        public string FileName { get; set; }
        public virtual void Open()
        {
            Console.WriteLine("Open doc");
        }
        public virtual void Save()
        {
            Console.WriteLine("Save doc");
        }
    }

    public class ReadOnlyDocument : Document
    {
        public override void Save()
        {
            throw new Exception("Unable to save");
        }
    }

    public interface WritableDocument
    {
        void Save();
    }

    public class GoodDocument : WritableDocument
    {
        public void Save()
        {
            Console.WriteLine("Save doc");
        }
    }

    public class BadProject
    {
        public void SaveAll(List<Document> documents)
        {
            documents.ForEach(x => x.Save());
        }
    }


    public class GoodProject
    {
        public void SaveAll(List<WritableDocument> documents)
        {
            documents.ForEach(x => x.Save());
        }
    }
}
