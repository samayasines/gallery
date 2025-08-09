using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
namespace photo_gallery2
{
    public class Photo
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public DateTime DateAdded { get; set; }
        public string Tags { get; set; }
        public double length { get; set; }
        public double width { get; set; }

        public double bitforonepixel { get; set; }
        public double storage()
        {
            return length * width * bitforonepixel / 8;

        }


    }

    class Node
    {
        public string data;
        public Node next;
        public Node prev;

        public Node(string path)
        {
            data = path;
            next = null;
            prev = null;
        }
    }

    class Gallery
    {
        private Node head;
        private Node tail;
        private Node current;
        private Dictionary<string, DateTime> photoDates = new Dictionary<string, DateTime>();


        public void Add(string path)
        {
            {
                Console.Write("photo name: ");
                string name = Console.ReadLine();

                Console.Write("photo path: ");
                path = Console.ReadLine();


                Photo newPhoto = new Photo
                {
                    Name = name,
                    Path = path,
                    DateAdded = DateTime.Now,

                };



                Node newNode = new Node(path);

                if (head == null)
                {
                    head = tail = current = newNode;
                    head.next = head;
                    head.prev = head;

                }
                else
                {
                    tail.next = newNode;
                    newNode.prev = tail;
                    newNode.next = head;    
                    head.prev = newNode;
                    tail = newNode;
                }
            }
        }
        public void delete()
        {
            if (current == null)
            {
                Console.WriteLine("No current photo to delete.");
                return;
            }
 
            if (current == head && current == tail)
            {
                head = tail = current = null;
                Console.WriteLine("Deleted the only photo in the gallery.");
                return;
            }


            current.prev.next = current.next;
            current.next.prev = current.prev;
            if (current == head)
                head = current.next;
            if (current == tail)
                tail = current.prev;


            current = current.next;

            Console.WriteLine("Photo deleted. Current photo updated.");
        }



        public void Display()
        {
            if (head == null)
            {
                Console.WriteLine("No photos in the gallery.");
                return;
            }
            Node temp = head;
            do
            {
                Console.WriteLine($"Photo Name: {temp.data}");
                temp = temp.next;
            } while (temp != head);

        }
        public void Next()
        {
            if (current == null)
                current = head;
            else
                current = current.next;

            ShowCurrent();
        }

        public void Previous()
        {
            if (current == null)
            {
                current = tail;
            }
            else
            {
                current = current.prev;
            }

            ShowCurrent();

        }
        public void ShowCurrent()
        {
            if (current == null)
            {
                Console.WriteLine("No current photo.");
                return;
            }
            Console.WriteLine($"Current Photo: {current.data}");
        }
        public int Count()
        {
            if (head == null)
                return 0;
            else
            {
                int count = 0;
                Node temp = head;
                do
                {
                    count++;
                    temp = temp.next;
                } while (temp != head);
                return count;
            }
        }
        public void DisplaySortedByDate()
        {
            if (head == null)
            {
                Console.WriteLine("No photos in the gallery.");
                return;
            }

            List<(string path, DateTime dateAdded)> list = new List<(string, DateTime)>();

            Node temp = head;
            do
            {
                if (photoDates.ContainsKey(temp.data))
                    list.Add((temp.data, photoDates[temp.data]));
                else
                    list.Add((temp.data, DateTime.MinValue));

                temp = temp.next;
            } while (temp != head);
            bool check()
            {
                Console.WriteLine(" do you display them Ascending??");
                string input = Console.ReadLine().ToLower();
                if (input == "yes" || input == "y")
                    return true;
                else
                {
                    return false;
                }
            }


            if (check())
                list = list.OrderBy(x => x.dateAdded).ToList();
            else
                list = list.OrderByDescending(x => x.dateAdded).ToList();

            foreach (var item in list)
            {
                Console.WriteLine($"Path: {item.path}, Date Added: {item.dateAdded}");
            }
        }

        public void Clear()
        {
            head = tail = current = null;
            Console.WriteLine("Gallery cleared.");
        }




        internal class Program
        {
            static void Main(string[] args)
            {
                Gallery gallery = new Gallery();
                string command;
                do
                {
                    Console.WriteLine("Enter command (add, delete, display, next, previous, count, sort, clear, exit):");
                    command = Console.ReadLine().ToLower();
                    switch (command)
                    {
                        case "add":
                            Console.Write("Enter photo path: ");
                            string path = Console.ReadLine();
                            gallery.Add(path);
                            break;
                        case "delete":
                            gallery.delete();
                            break;
                        case "display":
                            gallery.Display();
                            break;
                        case "next":
                            gallery.Next();
                            break;
                        case "previous":
                            gallery.Previous();
                            break;
                        case "count":
                            Console.WriteLine($"Total photos: {gallery.Count()}");
                            break;
                        case "sort":
                            gallery.DisplaySortedByDate();
                            break;
                        case "clear":
                            gallery.Clear();
                            break;
                        case "exit":
                            Console.WriteLine("Exiting the program.");
                            break;
                        default:
                            Console.WriteLine("Unknown command. Please try again.");
                            break;
                    }
                } while (command != "exit");
            }
        }
    }
}

