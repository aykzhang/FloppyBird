using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveManager
{
    public static string directory = "SaveData";
    public static string fileName = "FloppyData";
    public static void Save(SaveObject saveData){
        //If Directory does not exist, create it
        if(!DirectoryExists()){
            Directory.CreateDirectory(Application.persistentDataPath + "/" + directory);
        }

        //Save data onto file. If the file does not exist, create it
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(GetFullPath());
        bf.Serialize(file, saveData);
        file.Close();
    }

    public static SaveObject Load(){
        if(SaveExists()){
            try{
                //Read data from file
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(GetFullPath(), FileMode.Open);
                SaveObject saveData = (SaveObject)bf.Deserialize(file);
                file.Close();

                return saveData;
            }
            catch(SerializationException){
                Debug.Log("Failed to load file");
            }
        }
        return new SaveObject();
    }

    public static void Delete(){
        if(SaveExists()){
            try{
                File.Delete(GetFullPath());
            }
            catch (IOException ioExp){
                Debug.Log(ioExp.Message);
            }
        }   
    }
    
    private static bool SaveExists(){
        return File.Exists(GetFullPath());
    }
    private static bool DirectoryExists(){
        return Directory.Exists(Application.persistentDataPath + "/" + directory);
    }
    private static string GetFullPath(){
        return Application.persistentDataPath + "/" + directory + "/" + fileName;
    }
}
