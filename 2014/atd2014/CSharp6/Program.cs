using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;
using System.Math;

namespace CSharp6
{
    // 1. Auto property initializers
    public class AutoPropertyInitializers
    {
        public bool IsImportant { get; set; } = true;
        public ObservableCollection<int> MyProperty { get; set; } = new ObservableCollection<int>();

        public int MaxCount { get; private set; } = 5;

        public bool IsMaxCountSet { get; }

        public AutoPropertyInitializers()
        {
            IsImportant = true;
            MyProperty = new ObservableCollection<int>();
            //MaxCount = 5;

            IsMaxCountSet = true;
        }
    }

    // 2. Parameterless struct constructor
    public struct ParameterlessStructConstructor
    {
        public int Foo { get; private set; }

        public ParameterlessStructConstructor()
        {
            Foo = 1;
        }
    }

    // 3. dictionary initializers
    public class DictionaryInitializers
    {
        public Dictionary<int, int> Create1()
        {
            return new Dictionary<int, int>
            {
                [1] = 1,
                [2] = 1,
                [3] = 1,
                [1] = 1
            };
        }

        public Dictionary<string, bool> Create2()
        {
            return new Dictionary<string, bool>
            {
                ["C# 6 je zako,n"] = true,
                ["C# 6 je zako,n"] = false
            };
        }
    }

    // 4. using static members
    public class StaticMembers
    {
        public double AddsKinda(double x, double y)
        {
            return Cos(x) * Cos(y) - Sin(x) * Sin(y);
        }
    }

    // 5. await in catch/finally!
    public static class AwaitCatchFinally
    {
        public static async Task<string> DownloadUrl(string url)
        {
            try
            {
                var client = new HttpClient();
                return await client.GetStringAsync(url);
            }
            catch (WebException ex) if (ex?.Response?.As<HttpWebResponse>()?.StatusCode == HttpStatusCode.NotFound)
            {
                return string.Empty;
            }
            catch (WebException ex)
            {
                var response = ex.Response as HttpWebResponse;
                using (var stream = response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    await reader.ReadToEndAsync();
                }

                return null;
            }
        }
    }

    public class ExpressionBodyMembers
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName => FirstName + " " + LastName;
    }

    public static class StringInterpolation
    {
        public static string Format(ExpressionBodyMembers x)
        {
            return "My name is \{x.FirstName} \{x.LastName}";
        }
    }

    public class NameOf : INotifyPropertyChanged
    {
        public int Count
        {
            get { return this.Count; }
            set
            {
                this.Count = value;
                RaisePropertyChanged(CountChangedArgs);
            }
        }

        private static PropertyChangedEventArgs CountChangedArgs = new PropertyChangedEventArgs(nameof(Count));

        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(PropertyChangedEventArgs args)
        {
            PropertyChanged?.Invoke(this, args);
        } 
        #endregion
    }

    class Program
    {
        static void Main(string[] args)
        {
            var x = new ExpressionBodyMembers
            {
                FirstName = "Chuck",
                LastName = "Norris"
            };
            Console.WriteLine(x.FullName);
            Console.WriteLine(StringInterpolation.Format(x));
        }
    }

    public static class Extensions
    {
        public static T As<T>(this object o)
            where T : class
        {
            return o as T;
        }
    }
}
