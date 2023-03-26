﻿using System;
namespace KyleMaui.ToDoList.DbContext
{
    public static class DbConstants
    {
        public const string DatabaseFilename = "TodoSQLite.db3";

        public const SQLite.SQLiteOpenFlags Flags =
             SQLite.SQLiteOpenFlags.ReadWrite |
             SQLite.SQLiteOpenFlags.Create |
             SQLite.SQLiteOpenFlags.SharedCache;


        public static string DatabasePath =>
            Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);
    }
}

