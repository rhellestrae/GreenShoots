using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using System;
using System.Data;
using System.Diagnostics;
using Microsoft.Azure.Documents.Linq;
using Xamarin.Forms;
using GreenShoots.Models;
using Xamarin.Essentials;
using GreenShoots.ViewModels;
using GreenShoots.Helpers;

namespace GreenShoots.Services
{
    public class CosmosDBService
    {
        static DocumentClient docClient = null;

        private static string euroCapCity;
        public static string EuroCapCity
        {
            get { return euroCapCity; }
            set { euroCapCity = value; }
        }

        public static string saveCapital;

        private static string categoryOfVisit;
        public static string CategoryOfVisit
        {
            get { return categoryOfVisit; }
            set { categoryOfVisit = value; }
        }

        public static string saveCategory;

        static readonly string databaseName = "Tasks";
        static readonly string collectionName = "Items";

        public CosmosDBService()
        {
        }

        static async Task<bool> Initialize()
        {
            if (docClient != null)
                return true;

            try
            {
                docClient = new DocumentClient(new Uri(APIKeys.CosmosEndpointUrl), APIKeys.CosmosAuthKey);

                // Create the database - this can also be done through the portal
                await docClient.CreateDatabaseIfNotExistsAsync(new Database { Id = databaseName });

                // Create the collection - make sure to specify the RUs - has pricing implications
                // This can also be done through the portal

                await docClient.CreateDocumentCollectionIfNotExistsAsync(
                    UriFactory.CreateDatabaseUri(databaseName),
                    new DocumentCollection { Id = collectionName },
                    new RequestOptions { OfferThroughput = 400 }
                );

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);

                docClient = null;

                return false;
            }

            return true;
        }

        // <GetToDoItems>        
        /// <summary> 
        /// </summary>
        /// <returns></returns>
        public async static Task<List<ToDoItem>> GetToDoItems()
        {
            var todos = new List<ToDoItem>();

            var id = Preferences.Get("my_id", string.Empty);
            if (string.IsNullOrWhiteSpace(id))
            {
                id = System.Guid.NewGuid().ToString();
                Preferences.Set("my_id", id);
            }

            if (!await Initialize())
                return todos;

            var todoQuery = docClient.CreateDocumentQuery<ToDoItem>(
                UriFactory.CreateDocumentCollectionUri(databaseName, collectionName),
                new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true })
                .Where(todo => todo.Completed == false && todo.ValGUID == id)
                .AsDocumentQuery();

            while (todoQuery.HasMoreResults)
            {
                var queryResults = await todoQuery.ExecuteNextAsync<ToDoItem>();

                todos.AddRange(queryResults);
            }

            foreach (var itemTest in todos)
            {
                itemTest.ContactImage = ImageSource.FromFile("GSI.png");
            }

            return todos;
        }

        // <GetCompletedToDoItems>        
        /// <summary> 
        /// </summary>
        /// <returns></returns>
        public async static Task<List<ToDoItem>> GetCompletedToDoItems()
        {
            var todos = new List<ToDoItem>();

            var id = Preferences.Get("my_id", string.Empty);
            if (string.IsNullOrWhiteSpace(id))
            {
                id = System.Guid.NewGuid().ToString();
                Preferences.Set("my_id", id);
            }

            if (!await Initialize())
                return todos;

            var completedToDoQuery = docClient.CreateDocumentQuery<ToDoItem>(
                UriFactory.CreateDocumentCollectionUri(databaseName, collectionName),
                new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true })
                .Where(todo => todo.Completed == true && todo.ValGUID == id)
                .AsDocumentQuery();

            while (completedToDoQuery.HasMoreResults)
            {
                var queryResults = await completedToDoQuery.ExecuteNextAsync<ToDoItem>();

                todos.AddRange(queryResults);
            }

            return todos;
        }

        // <CompleteToDoItem>        
        /// <summary> 
        /// </summary>
        /// <returns></returns>
        public async static Task CompleteToDoItem(ToDoItem item)
        {
            item.Completed = true;

            await UpdateToDoItem(item);
        }

        // <InsertToDoItem>        
        /// <summary> 
        /// </summary>
        /// <returns></returns>
        public async static Task InsertToDoItem(ToDoItem item)
        {
            if (!await Initialize())
                return;

            await docClient.CreateDocumentAsync(
                UriFactory.CreateDocumentCollectionUri(databaseName, collectionName),
                item);
        }

        // <DeleteToDoItem>        
        /// <summary> 
        /// </summary>
        /// <returns></returns>
        public async static Task DeleteToDoItem(ToDoItem item)
        {
            if (!await Initialize())
                return;

            var docUri = UriFactory.CreateDocumentUri(databaseName, collectionName, item.Id);
            await docClient.DeleteDocumentAsync(docUri);
        }

        // <UpdateToDoItem>        
        /// <summary> 
        /// </summary>
        /// <returns></returns>
        public async static Task UpdateToDoItem(ToDoItem item)
        {
            if (!await Initialize())
                return;

            var docUri = UriFactory.CreateDocumentUri(databaseName, collectionName, item.Id);
            await docClient.ReplaceDocumentAsync(docUri, item);
        }

    }
}
