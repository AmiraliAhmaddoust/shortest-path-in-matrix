using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alghoritm_design
{
    class Program
    {
        //ابتدا میاییم خونه ریشه را وارد صف مرتب میکنیم سپس  4 خانه فرزنند ان را در صورت ازاد بودن اد کرده سپس ریشه را حذف کرده از صف و حد خونه های داخل صف را حساب کرده و صف را طبق حد کم تر مرتب میکنیم و دوباره فرزندهای خونه صفر ارایه را اد کرده و خونه صفر را حذف میکنیم و حد ها را دوباره حساب میکنیم و این چرخه تا رسیدن به خانهی مقصد ادامه دارد
      //تقریبا الگوریتیم شباهت بسیار بالایی به الگوریتم دایحسترا دارد که به نوعی الگوریتمی با سرعت بیشتر نسبت به بی اف اس هست
        public static bool checkingXY(int x, int y, int z)
        {
            // barrsi  dorost bodan x va y va n matrix
            if (x >= z || y >= z || x < 0 || y < 0)
                return false;
            else
                return true;


        }
        public static bool point_is_visited(point check, List<node> ways)
        {
            //barrsi in ke aya khone visit shode ghablan ya na
            bool answer = false;
            for (int i = 0; i < ways.Count; i++)
            {

                if (check.x == ways[i].p.x && check.y == ways[i].p.y)
                    answer = true;
            }
            return answer;
        }
        public static bool point_Is_Block(point a, List<point> blockpoints)
        {
            //barrsi in ke aya point block hast ya na
            bool answer = false;
            for (int i = 0; i < blockpoints.Count; i++)
            {
                if (a.x == blockpoints[i].x && a.y == blockpoints[i].y)
                    answer = true;
            }
            return answer;
        }

        static void Main()
        {
            try
            {
                //khondan vorodi ha
                Console.WriteLine("please enter your n of matrix");
                int matrix = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("please enter your y of first point");
                int src_x = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("please enter your y of first point");
                int src_Y = Convert.ToInt32(Console.ReadLine());
                point src_P = new point(src_x, src_Y);


                Console.WriteLine("please enter your x of last point");
                int ds_x = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("please enter your x of last point");
                int ds_y = Convert.ToInt32(Console.ReadLine());

                point ds_P = new point(ds_x, ds_y);

                List<point> blockpoints = new List<point>();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("type true to add block home or type false if you dont want to add block home");
                bool block_check = Convert.ToBoolean(Console.ReadLine());

                //khondan block point ha
                while (block_check == true)
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("please enter your block home x ");
                    int b_x = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("please enter your block home y ");
                    int b_y = Convert.ToInt32(Console.ReadLine());
                    point bllock = new point(b_x, b_y);
                    blockpoints.Add(bllock);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("type true to add block home or type false if you dont want to add block home");
                    block_check = Convert.ToBoolean(Console.ReadLine());

                }

                Console.ForegroundColor = ConsoleColor.Red;

                //inja 3 list darim be name haye path,existance va way,
                //har point ke visit mishe vared existance mishavad ta da mthod is visited betavan barrsi kard ke on point gablan visit nashode bashad va az visit tekrary jologiri shavad
                //path listi ast ke root ebtada be on vared shode va sepas farzandash vard mishan va root az path hazf shode va be way add karede va sepas path bar mabnaye bound sort mishavad
                //in kar ta zami ke khoneye maghsad be waye add shavad anjam mishavad
                //tozihat khat haye 98-170



                List<node> ways = new List<node>();
                node src = new node(src_P, 0);

                List<node> existence = new List<node>();
                List<node> path = new List<node>();
                path.Add(src);
                existence.Add(src);
                point help;
                while (point_is_visited(ds_P, ways) == false)
                {


                    help = path[0].p.up();

                    if (checkingXY(help.x, help.y, matrix) == true && point_is_visited(help, existence) == false && point_Is_Block(help, blockpoints) == false)
                    {

                        node help1 = new node(help, path[0].level + 1);
                        help1.initial_parent(new node(path[0].p.x, path[0].p.y, path[0].level));

                        path.Add(help1);
                        existence.Add(help1);

                    }

                    help = path[0].p.down();

                    if (checkingXY(help.x, help.y, matrix) == true && point_is_visited(help, existence) == false && point_Is_Block(help, blockpoints) == false)
                    {

                        node help1 = new node(help, path[0].level + 1);
                        help1.initial_parent(new node(path[0].p.x, path[0].p.y, path[0].level));


                        path.Add(help1);
                        existence.Add(help1);
                    }

                    help = path[0].p.right();

                    if (checkingXY(help.x, help.y, matrix) == true && point_is_visited(help, existence) == false && point_Is_Block(help, blockpoints) == false)
                    {


                        node help1 = new node(help, path[0].level + 1);
                        help1.initial_parent(new node(path[0].p.x, path[0].p.y, path[0].level));


                        path.Add(help1);
                        existence.Add(help1);
                    }

                    help = path[0].p.left();

                    if (checkingXY(help.x, help.y, matrix) == true && point_is_visited(help, existence) == false && point_Is_Block(help, blockpoints) == false)
                    {


                        node help1 = new node(help, path[0].level + 1);
                        help1.initial_parent(new node(path[0].p.x, path[0].p.y, path[0].level));


                        path.Add(help1);
                        existence.Add(help1);
                    }
                    ways.Add(path[0]);
                    path.RemoveAt(0);//pathe empty
                    path.Sort(delegate (node x, node y)
                    {
                        return x.bound(ds_P).CompareTo(y.bound(ds_P));
                    });

                }


                //hala ma way ro darim va tebgh parent az khoney akhar way shoro karde ke point maghsad ast va parentash ke dar way hast ro be answer add kardeh va in kar ra ta rsidan be point mabda anjam midahim
                //hala masir harkat ma dar list answer hast

                List<node> answer = new List<node>();
                answer.Add(ways[ways.Count - 1]);
                int answer_counter = ways.Count - 1;
                answer_counter--;

                while (answer_counter != 0)
                {

                    int level_answer = answer[answer.Count - 1].level - 1;
                    if (ways[answer_counter].level == level_answer && ways[answer_counter].p.x == answer[answer.Count - 1].parent.p.x && ways[answer_counter].p.y == answer[answer.Count - 1].parent.p.y)
                    {
                        answer.Add(ways[answer_counter]);

                    }
                    answer_counter--;

                }


                for (int i = answer.Count() - 1; i >= 0; i--)
                {
                    Console.WriteLine("(" + answer[i].p.x + "," + answer[i].p.y + ")");
                }


                Console.WriteLine(ways.Count());
            }catch(Exception e)
            {
                Console.WriteLine(" your distination point is unreachable,plase check the inputs");
            }
            
            Console.ReadKey();
        }
    }

}
class point
{
    //class baray point 
    public int x;
    public int y;
    public point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
    //movements
    public point up()
    {
        return new point(x, y + 1);
    }
    public point down()
    {
        return new point(x, y - 1);

    }
    public point right()
    {
        return new point(x + 1, y);
    }
    public point left()
    {
        return new point(x - 1, y);
    }
}
class node
{
    public point p;

    public node parent;//baraye hefz khoneye parent har point
    
    public int level;//masiri ke az khoney mabda ta node hazer omadim
  
    public node() { }
    public node(int x1, int y1, int level)
    {
        p = new point(x1, y1);
        this.level = level;
    }
    public node(point p)
    {
        this.p = p;
    }
    public node(point p, int level, node parent)
    {
        this.p = p;
        this.level = level;

    }
    public node(point p, int level)
    {
        this.p = p;
        this.level = level;
    }
    public node(point p, node parent)
    {
        this.p = p;

        this.parent = parent;
    }

    public double bound(point ds)
    {
//baraye hesab kardan bound har khoone
     //   bound_holder= Math.Sqrt(((ds.x - p.x) * (ds.x - p.x) + (ds.y - p.y) * (ds.y - p.y))) * level;
        return Math.Sqrt(((ds.x - p.x) * (ds.x - p.x) + (ds.y - p.y) * (ds.y - p.y))) + level;

    
    }

    public void initial_parent(node parent)
    {
        this.parent = parent;
    }
    
}


