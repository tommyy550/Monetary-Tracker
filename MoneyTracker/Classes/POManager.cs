//Tommy Huynh
//4/18/19
//Writes/Read to binary file
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MoneyTracker.Classes;

// To read and write files
using System.IO;
// To serialize a persistant object
using System.Runtime.Serialization.Formatters.Binary;


namespace MoneyTracker.Classes
{
    public static class POManager
    {
        // This class manages the persistant object by reading from and writing to a file

        // Write the Person List to file as a serialized binary object
        public static bool writeToFile(RecordList rlist, string fn)
        {
            Stream thisFileStream;
            BinaryFormatter serializer = new BinaryFormatter();

            if (rlist.Count() > 0)
            {
                try
                {
                    thisFileStream = File.Create(fn);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("File open error: Person List not written", "POManager File Open");
                    MessageBox.Show(ex.ToString());
                    return false;
                }  // end Try

                try
                {
                    serializer.Serialize(thisFileStream, rlist);
                    //MsgBox("File write: Person List was written")
                }
                catch (Exception ex)
                {
                    MessageBox.Show("File write error: Person List not written", "POManager File Write");
                    MessageBox.Show(ex.ToString());
                    return false;
                }
                finally
                {
                    thisFileStream.Close();
                }  // end Try
            }
            else
                MessageBox.Show("No Person in List");
            // end if

            return true;  // The file write succeeded

        }  // end WriteToFile


        // Read the Person List from file as a serialized binary object
        public static bool readFromFile(ref RecordList rlist, string fn)
        {
            Stream TestFileStream;
            BinaryFormatter deserializer = new BinaryFormatter();

            if (File.Exists(fn))
            {
                try
                {
                    TestFileStream = File.OpenRead(fn);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("File open error: Open with new Person List", "POManager, File Open");
                    rlist = new Classes.RecordList();
                    return false;
                }  // end Try

                try
                {
                    rlist = (RecordList)deserializer.Deserialize(TestFileStream);
                    // pl = CType(deserializer.Deserialize(TestFileStream), PersonList);
                    // MsgBox("File open: Person loaded to List");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("File read error: Open with new Person List", "POManager File Read");
                    rlist = new Classes.RecordList();
                    return false;
                }
                finally
                {
                    TestFileStream.Close();
                }  // end Try
            }  // end then part of if
            else
            {
                MessageBox.Show("File does not exist: Open with new Person List", "PO Manager Exists ");
                rlist = new Classes.RecordList();
            }  // end if

            return true;   // The file read succeeded

        }  // end readFromFile 

    }  // end POManager Class

}
