// Description: C# Extension Methods | Enhance the .NET Framework and .NET Core with over 1000 extension methods.
// Website & Documentation: https://csharp-extension.com/
// Issues: https://github.com/zzzprojects/Z.ExtensionMethods/issues
// License (MIT): https://github.com/zzzprojects/Z.ExtensionMethods/blob/master/LICENSE
// More projects: https://zzzprojects.com/
// Copyright � ZZZ Projects Inc. All rights reserved.
using System;
using System.Data;
using System.Data.SqlServerCe;
using Z.Data.SQLite;

public static partial class Extensions
{
    /// <summary>
    ///     A SqlCeConnection extension method that executes the entity operation.
    /// </summary>
    /// <typeparam name="T">Generic type parameter.</typeparam>
    /// <param name="this">The @this to act on.</param>
    /// <param name="cmdText">The command text.</param>
    /// <param name="parameters">Options for controlling the operation.</param>
    /// <param name="commandType">Type of the command.</param>
    /// <param name="transaction">The transaction.</param>
    /// <returns>A T.</returns>
    public static T ExecuteEntity<T>(this SqlCeConnection @this, string cmdText, SqlCeParameter[] parameters, CommandType commandType, SqlCeTransaction transaction) where T : new()
    {
        using (SqlCeCommand command = @this.CreateCommand())
        {
            command.CommandText = cmdText;
            command.CommandType = commandType;
            command.Transaction = transaction;

            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }

            using (IDataReader reader = command.ExecuteReader())
            {
                reader.Read();
                return reader.ToEntity<T>();
            }
        }
    }

    /// <summary>
    ///     A SqlCeConnection extension method that executes the entity operation.
    /// </summary>
    /// <typeparam name="T">Generic type parameter.</typeparam>
    /// <param name="this">The @this to act on.</param>
    /// <param name="commandFactory">The command factory.</param>
    /// <returns>A T.</returns>
    public static T ExecuteEntity<T>(this SqlCeConnection @this, Action<SqlCeCommand> commandFactory) where T : new()
    {
        using (SqlCeCommand command = @this.CreateCommand())
        {
            commandFactory(command);

            using (IDataReader reader = command.ExecuteReader())
            {
                reader.Read();
                return reader.ToEntity<T>();
            }
        }
    }

    /// <summary>
    ///     A SqlCeConnection extension method that executes the entity operation.
    /// </summary>
    /// <typeparam name="T">Generic type parameter.</typeparam>
    /// <param name="this">The @this to act on.</param>
    /// <param name="cmdText">The command text.</param>
    /// <returns>A T.</returns>
    public static T ExecuteEntity<T>(this SqlCeConnection @this, string cmdText) where T : new()
    {
        return @this.ExecuteEntity<T>(cmdText, null, CommandType.Text, null);
    }

    /// <summary>
    ///     A SqlCeConnection extension method that executes the entity operation.
    /// </summary>
    /// <typeparam name="T">Generic type parameter.</typeparam>
    /// <param name="this">The @this to act on.</param>
    /// <param name="cmdText">The command text.</param>
    /// <param name="transaction">The transaction.</param>
    /// <returns>A T.</returns>
    public static T ExecuteEntity<T>(this SqlCeConnection @this, string cmdText, SqlCeTransaction transaction) where T : new()
    {
        return @this.ExecuteEntity<T>(cmdText, null, CommandType.Text, transaction);
    }

    /// <summary>
    ///     A SqlCeConnection extension method that executes the entity operation.
    /// </summary>
    /// <typeparam name="T">Generic type parameter.</typeparam>
    /// <param name="this">The @this to act on.</param>
    /// <param name="cmdText">The command text.</param>
    /// <param name="commandType">Type of the command.</param>
    /// <returns>A T.</returns>
    public static T ExecuteEntity<T>(this SqlCeConnection @this, string cmdText, CommandType commandType) where T : new()
    {
        return @this.ExecuteEntity<T>(cmdText, null, commandType, null);
    }

    /// <summary>
    ///     A SqlCeConnection extension method that executes the entity operation.
    /// </summary>
    /// <typeparam name="T">Generic type parameter.</typeparam>
    /// <param name="this">The @this to act on.</param>
    /// <param name="cmdText">The command text.</param>
    /// <param name="commandType">Type of the command.</param>
    /// <param name="transaction">The transaction.</param>
    /// <returns>A T.</returns>
    public static T ExecuteEntity<T>(this SqlCeConnection @this, string cmdText, CommandType commandType, SqlCeTransaction transaction) where T : new()
    {
        return @this.ExecuteEntity<T>(cmdText, null, commandType, transaction);
    }

    /// <summary>
    ///     A SqlCeConnection extension method that executes the entity operation.
    /// </summary>
    /// <typeparam name="T">Generic type parameter.</typeparam>
    /// <param name="this">The @this to act on.</param>
    /// <param name="cmdText">The command text.</param>
    /// <param name="parameters">Options for controlling the operation.</param>
    /// <returns>A T.</returns>
    public static T ExecuteEntity<T>(this SqlCeConnection @this, string cmdText, SqlCeParameter[] parameters) where T : new()
    {
        return @this.ExecuteEntity<T>(cmdText, parameters, CommandType.Text, null);
    }

    /// <summary>
    ///     A SqlCeConnection extension method that executes the entity operation.
    /// </summary>
    /// <typeparam name="T">Generic type parameter.</typeparam>
    /// <param name="this">The @this to act on.</param>
    /// <param name="cmdText">The command text.</param>
    /// <param name="parameters">Options for controlling the operation.</param>
    /// <param name="transaction">The transaction.</param>
    /// <returns>A T.</returns>
    public static T ExecuteEntity<T>(this SqlCeConnection @this, string cmdText, SqlCeParameter[] parameters, SqlCeTransaction transaction) where T : new()
    {
        return @this.ExecuteEntity<T>(cmdText, parameters, CommandType.Text, transaction);
    }

    /// <summary>
    ///     A SqlCeConnection extension method that executes the entity operation.
    /// </summary>
    /// <typeparam name="T">Generic type parameter.</typeparam>
    /// <param name="this">The @this to act on.</param>
    /// <param name="cmdText">The command text.</param>
    /// <param name="parameters">Options for controlling the operation.</param>
    /// <param name="commandType">Type of the command.</param>
    /// <returns>A T.</returns>
    public static T ExecuteEntity<T>(this SqlCeConnection @this, string cmdText, SqlCeParameter[] parameters, CommandType commandType) where T : new()
    {
        return @this.ExecuteEntity<T>(cmdText, parameters, commandType, null);
    }
}