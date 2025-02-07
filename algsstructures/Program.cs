//using var input = new StreamReader(Console.OpenStandardInput());
//using var output = new StreamWriter(Console.OpenStandardOutput());
//int n = int.Parse(input.ReadLine());

//List<Tuple<int, int, String>> res = new List<Tuple<int, int, string>>();
//int[] resL = new int[n];
//for (int i = 0; i < n; i++)
//{

//    var s = input.ReadLine().Split();
//    int m = int.Parse(s[0]);
//    int y = int.Parse(s[1]);
//    if (y == 1) { res.Add(new Tuple<int, int, string>(1, 1, "D")); resL[i] = 1; }
//    else if (m == 1) { res.Add(new Tuple<int, int, string>(1, 1, "R")); resL[i] = 1; }
//    else if (m < y) { resL[i] = 2; res.Add(new Tuple<int, int, string>(1, 1, "R")); res.Add(new Tuple<int, int, string>(m, y, "L")); }
//    else if (m > y) { resL[i] = 2; res.Add(new Tuple<int, int, string>(1, 1, "D")); res.Add(new Tuple<int, int, string>(m, y, "U")); }
//    else if (m == y) { resL[i] = 2; res.Add(new Tuple<int, int, string>(1, 1, "R")); res.Add(new Tuple<int, int, string>(m, y, "L")); }
//}
//int prev = 0;
//Tuple<int, int, String>[] r = res.ToArray();
//for (int i = 0; i < n; i++)
//{
//    Console.WriteLine(resL[i]);
//    for (int j = 0; j < resL[i]; j++)
//    {
//        Console.WriteLine(r[prev + j].Item1 + " " + r[prev + j].Item2 + " " + r[prev + j].Item3);

//    }
//    prev += resL[i];
//}

//using var input = new StreamReader(Console.OpenStandardInput());
//using var output = new StreamWriter(Console.OpenStandardOutput());
//int n = int.Parse(input.ReadLine());
//int[] arr = new int[n];
//for (int i = 0; i < n; i++)
//{
//    arr[i] = int.Parse(input.ReadLine());
//}
//int promo = 0;
//for (int i = 0; i < n; i++)
//{
//    promo = arr[i];

//    if (promo < 10)
//    {
//        Console.WriteLine(promo + 1);
//        continue;
//    }
//    else
//    {

//        string t = arr[i].ToString();
//        int count = 0;
//        string newt = t[0].ToString();
//        for (int j = 1; j < t.Length; j++) newt+= t[0].ToString();
//        if (promo>=int.Parse( newt)) { Console.WriteLine(int.Parse(t[0].ToString()) + 10*(t.Length-1)); continue; }
//        else
//        {
//            Console.WriteLine(int.Parse(t[0].ToString()) + 10 * (t.Length - 1) -1 ); continue;
//        }

//    }
//}

using algsstructures.AVL;
using algsstructures.RedBlackTree;

RedBlackTree<int,int> a = new RedBlackTree<int,int>();
a.insert(11,0);
a.insert(12,0);
a.insert(13,0);
a.insert(14,0);
a.insert(15,0);
a.insert(16,0);
a.displayTree();
a.remove(13);
a.displayTree();