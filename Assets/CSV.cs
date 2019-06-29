using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Text;
public class CSV : MonoBehaviour
{
    public string input;

    // Use this for initialization
    void Start()
    {
        input = "";
    }

    // Update is called once per frame
    void Update()
    {


    }
    public void Clean()//清空暫存
    {
        input = "";
    }
    public void ChangeLine()//換行
    {
        input = input + "\n";
    }
    public void Write(string data)//每次輸入同行一格
    {

        input = input + data;
        input = input + ",";
    }

    public void WriteInExcel(string s2, string id)//3.將input完整資料匯出CSV.
    {

        string path = @"d:\BCI\" + id;

        path = path + "\\" + s2 + ".csv";

        //建立資料夾
        CreateDir();
        CreateIdDir(id);

        try
        {

            // Delete the file if it exists.
            if (File.Exists(path))
            {
                // Note that no lock is put on the
                // file and the possibility exists
                // that another process could do
                // something with it between
                // the calls to Exists and Delete.
                File.Delete(path);
            }

            // Create the file.
            using (FileStream fs = File.Create(path))
            {
                Byte[] info = new UTF8Encoding(true).GetBytes(input);


                // Add some information to the file.
                fs.Write(info, 0, info.Length);

            }

            // Open the stream and read it back.
            using (StreamReader sr = File.OpenText(path))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }
        }

        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());

        }
    }
    public void CreateDir()//1.創一個根目錄
    {
        // Specify the directory you want to manipulate.
        string path = @"d:\BCI";

        try
        {
            // Determine whether the directory exists.
            if (Directory.Exists(path))
            {
                Console.WriteLine("That path exists already.");
                return;
            }

            // Try to create the directory.
            DirectoryInfo di = Directory.CreateDirectory(path);
            Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(path));

        }
        catch (Exception e)
        {
            Console.WriteLine("The process failed: {0}", e.ToString());
        }
        finally { }
    }
    public void CreateIdDir(string id)//2.創個別用戶資料夾
    {
        // Specify the directory you want to manipulate.
        string path = @"d:\BCI\" + id;

        try
        {
            // Determine whether the directory exists.
            if (Directory.Exists(path))
            {
                Console.WriteLine("That path exists already.");
                return;
            }

            // Try to create the directory.
            DirectoryInfo di = Directory.CreateDirectory(path);
            Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(path));

        }
        catch (Exception e)
        {
            Console.WriteLine("The process failed: {0}", e.ToString());
        }
        finally { }
    }
}

