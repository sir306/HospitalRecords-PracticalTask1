using System;
using System.Collections.Generic;
using System.IO;

namespace Hospital
{
    public class Records
    {
        static List<Patient> RecordsList = new List<Patient>();
        public static void Main()
        {
            //initiate obtain records from file
            ObtainRecords();
            Console.WriteLine();
            PerformSearchExitRequest();

        }
        // Method to output to the console a search or exit request and respond in the appropriate manner
        public static void PerformSearchExitRequest()
        {
            while (true)
            {
                Console.WriteLine("Press S for search, Press E for exit");
                ConsoleKeyInfo keyPressed = Console.ReadKey();
                Console.WriteLine();
                if (keyPressed.KeyChar == 'e' || keyPressed.KeyChar == 'E')
                {
                    Console.WriteLine("Key pressed was E");
                    break;
                }
                else if (keyPressed.KeyChar == 's' || keyPressed.KeyChar == 'S')
                {
                    Console.WriteLine("Enter Patient ID to search and then press enter");
                    Console.WriteLine();
                    string enteredID = Console.ReadLine();
                    SearchRecords(enteredID);
                }
                Console.WriteLine("Incorrect Key, Press S for search, Press E for exit");
                Console.WriteLine();
            }
        }
        public static void ObtainRecords()
        {
            //Use path to the ListOfPatients.txt here
            String path = "C:/Users/Nick/Source/Repos/HospitalRecords-PracticalTask1/PracticalTask1_IT6033/HospitalRecords/ListOfPatients.txt";
            //an array to store info about one patient
            String[] oneRecord = new String[4];
            //an array to store info about one patient
            Patient pat;

            if (File.Exists(path))
            {
                // Read file using StreamReader. Reads file line by line
                using (StreamReader file = new StreamReader(path))
                {
                    int counter = 0;
                    //to store each line of this file
                    string ln;
                    while ((ln = file.ReadLine()) != null)
                    {
                        oneRecord = ln.Split(',');
                        pat = new Patient(oneRecord[0], oneRecord[1], oneRecord[2], oneRecord[3])
                        {
                            //[YOUR CODE HERE]
                            //adding patient to the List
                            patientID = oneRecord[0],
                            name = oneRecord[1],
                            checkInDate = oneRecord[2],
                            assignedPersonnel = oneRecord[3]
                        };

                        //add new patient to list
                        RecordsList.Add(new Patient(pat.patientID, pat.name, pat.checkInDate, pat.assignedPersonnel));

                        //check to see if list is correctly inputting
                        //Console.WriteLine(RecordsList[counter].patientID.ToString());
                        //Console.WriteLine(RecordsList[counter].name.ToString());
                        //Console.WriteLine(RecordsList[counter].checkInDate.ToString());
                        //Console.WriteLine(RecordsList[counter].assignedPersonnel.ToString());

                        Patient.writePatientFile(RecordsList, counter);

                        counter++;
                    }
                    file.Close();
                    Console.WriteLine($"File has {counter} lines.");
                    //displays message after completion of read line method
                    Console.WriteLine("**Patient records have been recorded successfully**");
                }
            }

        }
        // Initiate record search with input id
        public static void SearchRecords(string patientID)
        {
            var i = 0;
            foreach (var item in RecordsList)
            {
                Console.WriteLine("searching records");
                Console.WriteLine();
                if (item.patientID == patientID)
                {
                    Console.WriteLine("match");
                    Console.WriteLine("{0} many iterations", i);
                    Patient.writePatientFile(RecordsList, i);
                    Console.WriteLine();
                    //perform delete request
                    Console.WriteLine("Would you like to remove the patient's record(s)?");
                    Console.WriteLine("Y or N?");
                    ConsoleKeyInfo key;
                    key = Console.ReadKey();
                    do
                    {
                        if (key.Key == ConsoleKey.Y)
                        {
                            Console.WriteLine("performing delete");

                        }
                        else if (key.Key == ConsoleKey.N)
                        {

                        }
                        else
                        {
                            Console.WriteLine("Invalid key pressed");
                            Console.WriteLine("Press Y or N");
                        }
                    } while (key.Key != ConsoleKey.Y || key.Key != ConsoleKey.N);
                    
                    //minus 1 from counter so smaller than list length for next step
                    i--;
                }
                i++;
            }
            int len = RecordsList.Count;
            if (i == len)
            {
                Console.WriteLine("Patient ID does not exist");
            }
            PerformSearchExitRequest();
        }
        class Patient
        {
            public string patientID;
            public string name;
            public string checkInDate;
            public string assignedPersonnel;

            public Patient(string patientID, string name, string checkInDate, string assignedPersonnel)
            {
                this.patientID = patientID;
                this.name = name;
                this.checkInDate = checkInDate;
                this.assignedPersonnel = assignedPersonnel;
            }

            //method to write patient files
            public static void writePatientFile(List<Patient> info, int listPos)
            {
                var patientID = info[listPos].patientID.ToString();
                var name = info[listPos].name.ToString();
                var checkInDate = info[listPos].checkInDate.ToString();
                var assignedPersonnel = info[listPos].assignedPersonnel.ToString();

                Console.WriteLine("Patient ID: {0}", patientID);
                Console.WriteLine("Name: {0}", name);
                Console.WriteLine("Check In Date: {0}", checkInDate);
                Console.WriteLine("Assigned Personnel: {0}", assignedPersonnel);
                Console.WriteLine("");
            }
        }
    }
}