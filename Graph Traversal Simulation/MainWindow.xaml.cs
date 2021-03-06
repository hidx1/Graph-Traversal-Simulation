﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GraphSharp;
using GraphSharp.Controls;
using QuickGraph;

namespace Graph_Traversal_Simulation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        //Deklarasi Graf Dua Arah
        private static IBidirectionalGraph<object, IEdge<object>> windowGraph;
        //Getter dan Setter Graf
        public static IBidirectionalGraph<object, IEdge<object>> WindowGraph
        {
            get { return windowGraph; }
        }

        //Window Utama untuk Graf
        public MainWindow(string file1, string file2)
        {
            Program.main(file1, file2); //Pemanggilan method main dari class Program pada CodeFile1.cs
            windowGraph = Program.AppGraph;

            InitializeComponent(); //Initialize Window
            if (file2 != "") //Jika menggunakan file query, solve setiap query dan tampilkan pada Result Box
            {
                string[] lines = File.ReadAllLines(file2, Encoding.UTF8);
                int maxQuery = int.Parse(lines[0]);
                for (int i = 1; i < maxQuery + 1; i++)
                {
                    string query = lines[i];
                    string result = Program.SolveQuery(query); //Hasil dari query
                    ResultBox.Text += query + " " + result + System.Environment.NewLine;
                    if(result == "YA")
                    {
                        ResultBox.Text += "Rute: " + System.Environment.NewLine + Program.getroute() + System.Environment.NewLine;
                        ResultBox.Text += "Langkah DFS: " + System.Environment.NewLine + Program.getjourney() + System.Environment.NewLine;
                        ResultBox.Text += System.Environment.NewLine;
                    }
                    else
                    {
                        ResultBox.Text += System.Environment.NewLine;
                    }
                }
            }
        }

        //Tombol Solve
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string query = QueryText.Text;
            QueryText.Text = "";
            string result = Program.SolveQuery(query); //Hasil dari query
            ResultBox.Text += query + " " + result + System.Environment.NewLine;
            if (result == "YA")
            {
                ResultBox.Text += "Rute: " + System.Environment.NewLine + Program.getroute() + System.Environment.NewLine;
                ResultBox.Text += "Langkah DFS: " + System.Environment.NewLine + Program.getjourney() + System.Environment.NewLine;
                ResultBox.Text += System.Environment.NewLine;
            }
            else
            {
                ResultBox.Text += System.Environment.NewLine;
            }
        }

        //Tombol Exit
        private void Graph_Exit(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
