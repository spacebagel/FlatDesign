﻿using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace FlatDesignApp.Methods;
class DataLogic<T> where T : class
{
    public static void DeleteObjFromDb(object sender, ObservableCollection<T> Collection)
    {
        var item = (T)((Button)sender).DataContext;
        try
        {
            App.Context.Remove(item);
            App.Context.SaveChanges();
            Collection.Remove(item);
        }
        catch (Exception ex) { MessageBox.Show($"Deletion Error: " + ex.Message); }
    }

    public static T TypeFromSender(object sender) => (T)((Button)sender).DataContext;

    public static void AddObjToDb(bool isNull, Microsoft.EntityFrameworkCore.DbSet<T> dbSet, T currentItem, ObservableCollection<T> itemsCollection, T? itemCollection)
    {
        try
        {
            if (isNull)
            {
                dbSet.Add(currentItem);
                itemsCollection.Add(currentItem);
            }
            else
            {
                itemsCollection.Remove(itemCollection);
                itemsCollection.Add(currentItem);
            }
            App.Context.SaveChanges();
            MessageBox.Show("Success!");
        }
        catch (Exception ex) { MessageBox.Show(ex.Message); }
    }
}