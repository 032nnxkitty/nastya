using System.Collections;

namespace Zkouska
{
    class Book
    {
        public string Name1;
        public string Name2;
        public string Id;
        public string Author;
        // ... и так далее все данные о книги
        // в задании это nazev, podnazev, id, autori и тд
        // на этом экзамене было каждая книга имела 9 параметров
        // следовательно надо 9 переменный

        // так же их можно написать таким видом: public string Name1 { get; set; }
        // тогда это будет не переменная а свойство
        
        // так же было задание переопределить метод ToString()
        // это делается так 
        public override string ToString()
        {
            return $"{Name1} {Name2} {Id} {Author}"; // и так все переменные (поля) класса
        }
    }

    class Library
    {
        public List<Book> Lib = new List<Book>();
        // тут создае List<Book> в котором будут храниться наши Book

        // далее в этом классе надо расписать методы типа
        // 1) найти количество всех книг в библиотеке (именно названий книг)
        // 2) найти количество всех экземпляров книг
        // 3) найти все книги написанные определенным автором
        
        // 1) найти количество всех книг в библиотеке (именно названий книг)
        public string GetBooksCount()
        {
            return Lib.Count.ToString();
        }
        
        // 3) найти все книги написанные определенным автором
        // такие задачи на поиск чего решаются одинаково с помощью foreach
        public string GetAllBooksByAuthor(string authorName)
        {
            string result = "";
            foreach (var book in Lib)
            {
                if (book.Author == authorName)
                {
                    result += book.ToString() + " ";
                }
            }

            return result;
        }
    }

    class Program
    {
        static void Main()
        {
            //прочитаем файл котороый мы убрали в папку ко всем файлам проекта
            // bin -> debug -> ну и может быть еще одна папка там 
            string[] text = File.ReadAllLines("ИМЯ_ФАЙЛА.txt"); //тут мы получили массив строк, где каждая строка это книга
            
            //потом обьявляем нашу библиотеку
            Library library = new Library();

            foreach (var strBook in text)  // пробегаемся по каждой книге
            {
                // strBook выглядит так nazev;podnazev;id;autori и тд
                string[] bookinfo =strBook.Split(';'); // строку кажой книги делим на еще один массив, но теперь это массив данных книги

                Book book = new Book(); //каждую итерацию цикла создаем новую книгу которуя затем добавим в нашу библиотеку
                
                
                // заполняем данные о книге:
                // важно соблюдать порядок 
                book.Name1 = bookinfo[0]; //nazev
                book.Name2 = bookinfo[1]; // podnazev
                book.Id = bookinfo[2]; // id
                // .. и тд все поля
                
                // и каждую книгу добавляем в библиотеку (в каждой итерауии цикла)
                library.Lib.Add(book);
            }
            
            // ну на данном моменте вся библиотека заполнена и необходимл только выздать методы библиотеки чтобы показать их функционал
            
            Console.WriteLine("book count = ", library.GetBooksCount());
            //и так все методы из класса library
            
            //п.с. мне пиздец впадлу заново полностью писать этот код поэтому я накидал так
            //в понедльник схожу в библиотеку и кину оригинал кода
        }
    }
}