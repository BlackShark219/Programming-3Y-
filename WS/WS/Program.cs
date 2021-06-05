using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.IO;
using Microsoft.Win32;
using System.Text.RegularExpressions;
using System.Data.Entity.Validation;

namespace WS
{
    public class  Program
    {
        static string path = @"HKEY_LOCAL_MACHINE\Software\Task_Queue\Parameters";
        static int taskduration = (int)Registry.GetValue(path, "Task_Execution_Duration", 60);
        static int claimduration = (int)Registry.GetValue(path, "Task_Claim_Check_Period", 30);
        static int qy = (int)Registry.GetValue(path, "Task_Execution_Quantity", 1);
        static double percent = 0;
        static bool upd = false;
        static string p = "I";
        static string d;
        static DateTime dateTime = DateTime.UtcNow.Date;
        static List<Task> a;
        //List<string> b;

        static void Main(string[] args)
        {
            Timer t = new Timer(claimduration * 1000);
            t.Elapsed += new ElapsedEventHandler(WorkingCycle);
            t.Enabled = true;
            System.Threading.Thread TH = new System.Threading.Thread(ParalelWorkingCycle);
            TH.Start();
        }

        static void WorkingCycle(object source, ElapsedEventArgs e)
        {
            try
            {
                using (PinokkioEntities db = new PinokkioEntities())
                {

                    List<string> d = db.Tasks
                        .Select(y => y.Task_Name.Remove(9))
                        .ToList();
                    var allrec = db.Claims.ToList();
                    allrec.ForEach(x =>
                    {
                        if (!CheckTaskName(x.Task_Claim))
                        {
                            db.Claims.Attach(x);
                            db.Claims.Remove(x);
                            using (StreamWriter E = new StreamWriter("C:\\Windows\\Logs\\TaskQueue_" + dateTime.ToString("dd-MM-yyyy") + ".log", true))
                            {
                                E.WriteLine("ПОМИЛКА розміщення заявки {0}. Некоректний синтаксис ...", x.Task_Claim);
                            }

                        }
                        if (d.Contains(x.Task_Claim))
                        {
                            db.Claims.Attach(x);
                            db.Claims.Remove(x);
                            using (StreamWriter E = new StreamWriter("C:\\Windows\\Logs\\TaskQueue_" + dateTime.ToString("dd-MM-yyyy") + ".log", true))
                            {
                                E.WriteLine("ПОМИЛКА розміщення заявки {0}.Номер вже існує...", x.Task_Claim);
                            }
                        }
                    });
                    var rec = db.Claims.OrderBy(y => y.Task_Claim).First();
                    using (StreamWriter E = new StreamWriter("C:\\Windows\\Logs\\TaskQueue_" + dateTime.ToString("dd-MM-yyyy") + ".log", true))
                    {
                        E.WriteLine("Задача {0} успішно прийнята в обробку...", rec.Task_Claim);
                    }
                    Task t1 = new Task { Task_Name = rec.Task_Claim + "-[....................]-Queued" };
                    db.Tasks.Add(t1);
                    db.Claims.Attach(rec);
                    db.Claims.Remove(rec);
                    db.SaveChanges();




                }
            }
            catch (Exception a)
            {
                using (StreamWriter E = new StreamWriter("C:\\WORK\\Error.log", true))
                {
                    E.WriteLine(a.Message + a.InnerException + a.StackTrace);
                }
            }

        }


        static void ParalelWorkingCycle()
        {

            Timer t = new Timer(1000);
            t.Elapsed += new ElapsedEventHandler(ChangeBar);
            t.Enabled = true;

        }

        static bool CheckTaskName(string p)
        {
            Regex R = new Regex(@"^Task_[0-9]{4}$");
            Match M = R.Match(p);
            return M.Success;
        }

        static void ChangeBar(object source, ElapsedEventArgs e)
        {
            using (PinokkioEntities db = new PinokkioEntities())
            {

                try
                {
                    if (a == null)
                    {
                        a = db.Tasks.Where(x => !x.Task_Name.Contains("COMPLETED")).ToList();
                        //using (StreamWriter E = new StreamWriter("C:\\WORK\\TaskList.log", true))
                        //{
                        //    E.WriteLine(DateTime.Now);
                        //    a.ForEach(x => E.WriteLine(x.Task_Name));
                        //    E.WriteLine("=========================================");
                        //}
                        return;
                    }

                }
                catch (Exception a)
                {
                    using (StreamWriter E = new StreamWriter("C:\\WORK\\Error2.log", true))
                    {
                        E.WriteLine(a.Message + a.InnerException + a.StackTrace);
                        E.WriteLine(DateTime.Now);
                        E.WriteLine("=========================================");
                    }

                }

                try
                {

                    AddPercent();

                    if (!upd)
                    {

                        foreach (var y in a)
                        {
                            using (StreamWriter E = new StreamWriter("C:\\Windows\\Logs\\TaskQueue_" + dateTime.ToString("dd-MM-yyyy") + ".log", true))
                            {
                                E.WriteLine("Задача {0} почала виконуватися! " + DateTime.Now.ToString(), y.Task_Name.Remove(9));
                            }
                            if (percent >= 100)
                            {
                                y.Task_Name = y.Task_Name.Remove(11, (int)(percent / 5));
                                y.Task_Name = y.Task_Name.Insert(11, RepeatForLoop(p, (int)(percent / 5)));
                                y.Task_Name = y.Task_Name.Remove(33);
                                y.Task_Name = y.Task_Name.Insert(33, "COMPLETED");
                                using (StreamWriter E = new StreamWriter("C:\\Windows\\Logs\\TaskQueue_" + dateTime.ToString("dd-MM-yyyy") + ".log", true))
                                {
                                    E.WriteLine("Задача {0} успішно ВИКОНАНА! " + DateTime.Now.ToString(), y.Task_Name.Remove(9));
                                }
                                upd = false;
                                percent = 0;
                                a = null;
                            }

                            using (StreamWriter E = new StreamWriter("C:\\WORK\\Progress.log", true))
                            {
                                E.WriteLine(DateTime.Now + y.Task_Name);
                                E.WriteLine("=========================================");
                            }


                            db.SaveChanges();
                        }
                    }
                    else
                    {

                        foreach (var y in a)
                        {

                            using (StreamWriter E = new StreamWriter("C:\\Windows\\Logs\\TaskQueue_" + dateTime.ToString("dd-MM-yyyy") + ".log", true))
                            {
                                E.WriteLine("Задача {0} почала виконуватися! " + DateTime.Now.ToString(), y.Task_Name.Remove(9));
                            }

                            y.Task_Name = y.Task_Name.Remove(33);
                            y.Task_Name = y.Task_Name.Insert(33, "In progress - " + (int)percent + " percents");
                            y.Task_Name = y.Task_Name.Remove(11, (int)(percent / 5));
                            y.Task_Name = y.Task_Name.Insert(11, RepeatForLoop(p, (int)(percent / 5)));

                            if (percent >= 100)
                            {
                                y.Task_Name = y.Task_Name.Remove(33);
                                y.Task_Name = y.Task_Name.Insert(33, "COMPLETED");
                                using (StreamWriter E = new StreamWriter("C:\\Windows\\Logs\\TaskQueue_" + dateTime.ToString("dd-MM-yyyy") + ".log", true))
                                {
                                    E.WriteLine("Задача {0} успішно ВИКОНАНА! " + DateTime.Now.ToString(), y.Task_Name.Remove(9));
                                }
                                upd = false;
                                percent = 0;
                                a = null;
                            }
                            using (StreamWriter E = new StreamWriter("C:\\WORK\\Progress.log", true))
                            {
                                E.WriteLine(DateTime.Now + y.Task_Name);
                                E.WriteLine("=========================================");
                            }
                            db.SaveChanges();
                        }



                    }

                    upd = !upd;

                }
                catch (Exception a)
                {
                    using (StreamWriter E = new StreamWriter("C:\\WORK\\Error3.log", true))
                    {
                        E.WriteLine(a.Message + a.InnerException + a.StackTrace);
                        E.WriteLine(DateTime.Now);
                        E.WriteLine("=========================================");
                    }
                }

            }
        }


        static double AddPercent()
        {
            double add = 100.0 / taskduration;
            return percent += add;
        }

        static string RepeatForLoop(string s, decimal n)
        {
            var result = s;

            for (var i = 0; i < n - 1; i++)
            {
                result += s;
            }
            return result;
        }

    }




}
