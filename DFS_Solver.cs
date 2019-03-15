using System;
using System.Collections.Generic;

/*public class Program
{
	public static void Main(){
  List<List<string>> myList = new List<List<string>>();
  myList.Add(new List<string> { "a", "b" });
  myList.Add(new List<string> { "c", "d", "e" });
  myList.Add(new List<string> { "qwerty", "asdf", "zxcv" });
  myList.Add(new List<string> { "a", "b" });

  // To iterate over it.
  foreach (List<string> subList in myList)
  {
      foreach (string item in subList)
      {
          Console.WriteLine(item);
      }
      Console.WriteLine();
  }
}
}
*/

/*public class Program
{
  public static void Main(){
    List<List<int>> tab = new List<List<int>>();
    List<List<bool>> tabBool = new List<List<bool>>();


    List<int> konstruktor = new List<int>();
    List<bool> konstruktorBool = new List<bool>();
    for(int i =0 ; i<3 ;i++){
    tab.Add(konstruktor);
    tabBool.Add(konstruktorBool);
    konstruktor = new List<int>();
    konstruktorBool = new List<bool>();
    }


    tabBool[0].Add(false);
    tabBool[0].Add(false);
    tabBool[1].Add(false);
    tabBool[1].Add(false);
    tabBool[2].Add(false);


    tab[0].Add(9);
    tab[0].Add(8);
    tab[1].Add(3);
    tab[1].Add(2);
    tab[2].Add(4);

    //Console.WriteLine(tab[0].Contains(-99));
    tab[1].Sort();
    tab[1].RemoveAt(tab[1].Count-1);



    foreach (List<int> inner in tab)
    {
      foreach(int i in inner)
      {
        Console.Write(i);
        Console.Write(" ");
      }
      Console.WriteLine();
    }

    foreach (List<bool> inner in tabBool)
    {
      foreach(bool i in inner)
      {
        Console.Write(i);
        Console.Write(" ");
      }
      Console.WriteLine();
    }
  }
}*/

public class Program{

  public static void DFS(int from, int to, List<List<int>> grafList, List <int> solusi, List <int> DFSTrack){
    bool found = false;
    bool backtrack = false;
    solusi.Add(from);
    DFSTrack.Add(from);
    DFSUtil(from,to,grafList,solusi,DFSTrack,ref found,ref backtrack);
  }
  public static void DFSUtil(int from, int to, List<List<int>> grafList, List <int> solusi, List <int> DFSTrack,ref bool found,ref bool backtrack){
    if(from == to)
      {
        found = true;
        //Console.WriteLine("FOund");
        //Console.WriteLine(from);
        //solusi.Add(11111);
        //DFSTrack.Add(11111);
        // solusi.Add(from);
        // DFSTrack.Add(from);
      }
    else if(grafList[from].Count == 0)
    {
      backtrack = true;

      //Console.WriteLine("back");
      //Console.WriteLine(from);
      solusi.RemoveAt(solusi.Count-1);
    }
    else{
      for(int i=0 ; i<grafList[from].Count;i++){
        if(!found){
          solusi.Add(grafList[from][i]);
          DFSTrack.Add(grafList[from][i]);
          DFSUtil(grafList[from][i],to,grafList,solusi,DFSTrack,ref found,ref backtrack);

          if(!found && backtrack){
            // Console.WriteLine("back");
            // DFSTrack.Add(-999);
            DFSTrack.Add(from);
            backtrack = false;
          }
        }
      }
      if(!found)
      {solusi.RemoveAt(solusi.Count-1);}
      backtrack=true;
    }

  }

  public static void Main(){
    List<List<int>> tab = new List<List<int>>();
    List<int> konstruktor = new List<int>();

    for(int i =0 ; i<9+1 ;i++){
    tab.Add(konstruktor);
    konstruktor = new List<int>();
    }

    List <int> solusi = new List<int>();
    List <int> DFSTrack = new List<int>();

    tab[1].Add(2);
    tab[1].Add(3);
    tab[1].Add(7);
    tab[2].Add(9);
    tab[3].Add(5);
    tab[5].Add(4);
    tab[5].Add(6);
    tab[7].Add(8);

    // for(int i=0; i<9+1;i++){
    //   if(tab[i].Count !=0)
    //   {
    //     foreach(int x in tab[i]){
    //       Console.Write(x);
    //       Console.Write(" ");
    //     }
    //     Console.WriteLine();
    //   }
    //   else
    //   {
    //     Console.Write("indeks ke ");
    //     Console.Write(i);
    //     Console.WriteLine("kosong");
    //   }
    // }

    DFS(1,6,tab,solusi,DFSTrack);
    foreach(int i in solusi){
      Console.Write(i);
      Console.Write(" ");
    }
    Console.WriteLine();

    foreach(int i in DFSTrack){
      Console.Write(i);
      Console.Write(" ");
    }
    Console.WriteLine();


  }
}