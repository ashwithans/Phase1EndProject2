using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseEndProj2
{
    internal class Program
    {
        public static string fileLocation = "teacher_data.txt";

        public static void WriteData(Teacher teacher)
        {
            using (StreamWriter sw = File.AppendText(fileLocation))
            {
                sw.WriteLine(teacher.ToString());
            }
            Console.WriteLine("Teacher data added successfully!");
        }

        public static void ReadData()
        {
            if (File.Exists(fileLocation))
            {
                using (StreamReader sr = new StreamReader(fileLocation))
                {
                    string line;
                    Console.WriteLine("Teacher Records:");
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            else
            {
                Console.WriteLine("No teacher records found.");
            }
        }

        public static void UpdateData(int id)
        {
            if (File.Exists(fileLocation))
            {
                string[] lines = File.ReadAllLines(fileLocation);
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] parts = lines[i].Split(',');
                    if (Convert.ToInt32(parts[0]) == id)
                    {
                        Console.Write("Enter teacher's Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter teacher's Class Number: ");
                        int classNum = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter teacher's Section: ");
                        string section = Console.ReadLine();

                        lines[i] = $"{id}, {name}, {classNum}, {section}";
                        File.WriteAllLines(fileLocation, lines);
                        Console.WriteLine("Teacher data updated successfully!");
                        return;
                    }
                }
                Console.WriteLine("Teacher not found with ID: " + id);
            }
            else
            {
                Console.WriteLine("No teacher records found.");
            }
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n-- Teacher Data System --");
                Console.WriteLine("1. Add Teacher");
                Console.WriteLine("2. Update Teacher");
                Console.WriteLine("3. Display Teacher Records");
                Console.WriteLine("4. Exit");

                Console.Write("Enter your choice: ");
                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Enter teacher's ID: ");
                            int id = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Enter teacher's Name: ");
                            string name = Console.ReadLine();
                            Console.Write("Enter teacher's Class Number: ");
                            int classNum = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Enter teacher's Section: ");
                            string section = Console.ReadLine();

                            Teacher newTeacher = new Teacher(id, name, classNum, section);
                            WriteData(newTeacher);
                            break;
                        case 2:
                            Console.Write("Enter teacher's ID to update: ");
                            int updateId = Convert.ToInt32(Console.ReadLine());
                            UpdateData(updateId);
                            break;
                        case 3:
                            ReadData();
                            break;
                        case 4:
                            Console.WriteLine("Exiting the program.");
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
        }
    }
}


        