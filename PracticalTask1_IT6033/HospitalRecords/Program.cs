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
                    Console.WriteLine(enteredID);
                    searchRecords("s");
                    break;
                }
                Console.WriteLine("Incorrect Key, Press S for search, Press E for exit");
                Console.WriteLine();
            }
                
        }
        public static void ObtainRecords()
        {
            
            //Use path to the ListOfPatients.txt here
            String path = "C:/Users/User/source/repos/HospitalRecords-PracticalTask1/PracticalTask1_IT6033/HospitalRecords/ListOfPatients.txt";
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
                        
                        Patient.writePatientFile(RecordsList);

                        counter++;
                    }
                    file.Close();
                    Console.WriteLine($"File has {counter} lines.");
                    //displays message after completion of read line method
                    Console.WriteLine("**Patient records have been recorded successfully**");
                }
            }
            
        }
        public static void searchRecords(string patientID)
        {
            foreach (object item in RecordsList)
            {
                Console.WriteLine("hello");
            }
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
            public static void writePatientFile(List<Patient> info)
            {
                var patientID = info[0].patientID.ToString();
                var name = info[0].name.ToString();
                var checkInDate = info[0].checkInDate.ToString();
                var assignedPersonnel = info[0].assignedPersonnel.ToString();

                Console.WriteLine("Patient ID: {0}", patientID);
                Console.WriteLine("Name: {0}", name);
                Console.WriteLine("Check In Date: {0}", checkInDate);
                Console.WriteLine("Assigned Personnel: {0}", assignedPersonnel);
                Console.WriteLine("");
            }
        }
    }
}