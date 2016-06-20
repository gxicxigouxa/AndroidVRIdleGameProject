using UnityEngine;
using System.Collections;
using System;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;
public class DBmanager : MonoBehaviour {

    private static string connectionString;
    private static string DBFilePath;


	// Use this for initialization
	void Start () {
        DBFilePath = Application.persistentDataPath + "/GameDB.sqlite";
        connectionString = "URI=file:" + DBFilePath;

        getInfomation();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private static void getInfomation()
    {
        if (!File.Exists(DBFilePath))
        {
            Debug.LogWarning("File \"" + DBFilePath + "\" does not exist. Attempting to create from \"" +
                             Application.dataPath + "!/assets/GameDB.sqlite");
            // if it doesn't ->
            // open StreamingAssets directory and load the db -> 
            WWW loadDB = new WWW("jar:file://" + Application.dataPath + "!/assets/GameDB.sqlite");
            while (!loadDB.isDone) { }
            // then save to Application.persistentDataPath
            File.WriteAllBytes(DBFilePath, loadDB.bytes);
        }

        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string query = "CREATE TABLE IF NOT EXISTS  main.infomation (ID INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL DEFAULT 0, score INTEGER, unitScore INTEGER, maxObject INTEGER, generateDelay FLOAT, damage FLOAT, scale INTEGER, day INTEGER, hour INTEGER, minute INTEGER, second INTEGER, bossCount INTEGER, totalScore INTEGER)";

                dbCmd.CommandText = query;
                dbCmd.ExecuteNonQuery();

                query = "SELECT * FROM infomation";
                dbCmd.CommandText = query;

                using (IDataReader reader = dbCmd.ExecuteReader())
                {
                    if (reader.Read() == false)
                    {
                        reader.Close();
                        query = "INSERT INTO infomation(score, unitScore, maxObject, generateDelay, damage, scale, day, hour, minute, second, bossCount, totalScore) VALUES("+ MainObjectScript.Score +", "+ MainObjectScript.UnitScore +", " + MainObjectScript.MaxObject + "," + ObjectGenerator.GenerateDelay + ", " + ObjectRemover.Damage + ", " + ObjectGenerator.ObjectScaleCount +  ", 0, 0, 0, 0, " + BossObject.appearCount + ", " + MainObjectScript.totalScore + ")";
                        dbCmd.CommandText = query;
                        dbCmd.ExecuteNonQuery();
                    }
                    else
                    {
                        MainObjectScript.Score = reader.GetInt32(1);
                        MainObjectScript.UnitScore = reader.GetInt32(2);
                        MainObjectScript.MaxObject = reader.GetInt32(3);
                        ObjectGenerator.GenerateDelay = reader.GetFloat(4);
                        ObjectRemover.Damage = reader.GetFloat(5);
                        ObjectGenerator.ObjectScaleCount = reader.GetInt32(6);
                        PlayingTimeTextScript.Day = reader.GetInt32(7);
                        PlayingTimeTextScript.Hour = reader.GetInt32(8);
                        PlayingTimeTextScript.Minute = reader.GetInt32(9);
                        PlayingTimeTextScript.Second = reader.GetInt32(10);
                        BossObject.appearCount = reader.GetInt32(11);
                        MainObjectScript.totalScore = reader.GetInt32(12);
                    }
                    reader.Close();
                    dbConnection.Close();
                }
             
            }
        }
    }

    public static void storeScore()
    {
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
               
                string query = "UPDATE infomation SET score = " + MainObjectScript.Score;
                dbCmd.CommandText = query;
                dbCmd.ExecuteNonQuery();

                query = "UPDATE infomation SET totalScore = " + MainObjectScript.totalScore;
                dbCmd.CommandText = query;
                dbCmd.ExecuteNonQuery();

                dbConnection.Close();
            }
        }
    }

    public static void storeUnitScore()
    {
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {

                string query = "UPDATE infomation SET unitScore = " + MainObjectScript.UnitScore;
                dbCmd.CommandText = query;
                dbCmd.ExecuteNonQuery();
                dbConnection.Close();
            }
        }
    }

    public static void storeMaxObject()
    {
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {

                string query = "UPDATE infomation SET maxObject = " + MainObjectScript.MaxObject;
                dbCmd.CommandText = query;
                dbCmd.ExecuteNonQuery();
                dbConnection.Close();
            }
        }
    }

    public static void storeGenerateDelay()
    {
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {

                string query = "UPDATE infomation SET generateDelay = " + ObjectGenerator.GenerateDelay;
                dbCmd.CommandText = query;
                dbCmd.ExecuteNonQuery();
                dbConnection.Close();
            }
        }
    }

    public static void storeDamage()
    {
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {

                string query = "UPDATE infomation SET damage = " + ObjectRemover.Damage;
                dbCmd.CommandText = query;
                dbCmd.ExecuteNonQuery();
                dbConnection.Close();
            }
        }
    }

    public static void storeScale()
    {
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {

                string query = "UPDATE infomation SET scale = " + ObjectGenerator.ObjectScaleCount;
                dbCmd.CommandText = query;
                dbCmd.ExecuteNonQuery();
                dbConnection.Close();
            }
        }

    }

    public static void storeDate()
    {
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string query = "UPDATE infomation SET day = " + PlayingTimeTextScript.Day;
                dbCmd.CommandText = query;
                dbCmd.ExecuteNonQuery();

                query = "UPDATE infomation SET hour = " + PlayingTimeTextScript.Hour;
                dbCmd.CommandText = query;
                dbCmd.ExecuteNonQuery();

                query = "UPDATE infomation SET minute = " + PlayingTimeTextScript.Minute;
                dbCmd.CommandText = query;
                dbCmd.ExecuteNonQuery();

                query = "UPDATE infomation SET second = " + PlayingTimeTextScript.Second;
                dbCmd.CommandText = query;
                dbCmd.ExecuteNonQuery();

                dbConnection.Close();
            }
        }

    }
}
