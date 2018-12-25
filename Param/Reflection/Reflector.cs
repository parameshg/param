using System;
using System.Reflection;

namespace Param.Reflection
{
    public class Reflector<T>
    {
        public T Activate(string s)
        {
            T result = default(T);

            var assembly = Assembly.GetExecutingAssembly();

            if (assembly != null)
            {
                var type = assembly.GetType(s);

                if (type != null)
                {
                    result = (T)Activator.CreateInstance(type);
                }
            }

            return result;
        }

        public T Create(string s)
        {
            T result = default(T);

            var assembly = string.Empty;

            var type = string.Empty;

            var version = string.Empty;

            var culture = string.Empty;

            var publickey = string.Empty;

            var args = s.Split(',');

            if (args.Length >= 2)
            {
                assembly = args[1].Trim();

                type = args[0].Trim();

                if (args.Length.Equals(5))
                {
                    version = args[2].Trim();

                    culture = args[3].Trim();

                    publickey = args[4].Trim();
                }
            }

            if (!string.IsNullOrEmpty(assembly) && !string.IsNullOrEmpty(type))
            {
                Assembly asm = null;

                if (args.Length.Equals(5))
                {
                    asm = Assembly.Load(string.Format("{0}, {1}, {2}, {3}", assembly, version, culture, publickey));
                }

                if (args.Length.Equals(2))
                {
                    asm = Assembly.Load(assembly);
                }

                if (asm != null)
                {
                    var typed = asm.GetType(type);

                    if (typed != null)
                    {
                        result = (T)Activator.CreateInstance(typed);
                    }
                }
            }

            return result;
        }
    }
}